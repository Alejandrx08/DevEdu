using DevEdu.Core.Services.Offline;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DevEdu.Core.Services.SQLite
{
    public sealed class SQLiteSyncService
    {
        private static readonly SemaphoreSlim SynchronizationLock =
            new SemaphoreSlim(1, 1);

        private readonly SQLiteSyncLogger _logger;
        private readonly SQLiteOperationQueue _queue;
        private readonly SQLiteRegistrationRepository _repository;

        public SQLiteSyncService()
            : this(
                new SQLiteOperationQueue(),
                new SQLiteRegistrationRepository(),
                new SQLiteSyncLogger())
        {
        }

        public SQLiteSyncService(
            SQLiteOperationQueue queue,
            SQLiteRegistrationRepository repository)
            : this(
                queue,
                repository,
                new SQLiteSyncLogger())
        {
        }

        public SQLiteSyncService(
            SQLiteOperationQueue queue,
            SQLiteRegistrationRepository repository,
            SQLiteSyncLogger logger)
        {
            _queue = queue
                ?? throw new ArgumentNullException(nameof(queue));

            _repository = repository
                ?? throw new ArgumentNullException(nameof(repository));

            _logger = logger
                ?? throw new ArgumentNullException(nameof(logger));
        }

        private sealed class UserRegistrationPayload
        {
            public string nombre { get; set; }
            public string apellido { get; set; }
            public string correo { get; set; }
            public string contrasenaHash { get; set; }
        }

        public async Task SynchronizePendingAsync(
            CancellationToken cancellationToken = default)
        {
            await SynchronizationLock.WaitAsync(cancellationToken);

            try
            {
                await _queue.InitializeAsync(cancellationToken);

                var operations = await _queue.GetPendingAsync(
                    cancellationToken);

                foreach (var operation in operations)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    if (operation.OperationType != "UserRegistration")
                    {
                        await _queue.MarkConflictAsync(
                            operation.OperationId,
                            "UNSUPPORTED_OPERATION",
                            cancellationToken);

                        continue;
                    }

                    UserRegistrationPayload payload;

                    try
                    {
                        payload =
                            JsonSerializer.Deserialize<UserRegistrationPayload>(
                                operation.PayloadJson);
                    }
                    catch (JsonException)
                    {
                        await _queue.MarkConflictAsync(
                            operation.OperationId,
                            "INVALID_PAYLOAD",
                            cancellationToken);

                        continue;
                    }

                    if (!EsPayloadValido(payload))
                    {
                        await _queue.MarkConflictAsync(
                            operation.OperationId,
                            "INVALID_PAYLOAD",
                            cancellationToken);

                        continue;
                    }

                    RegistrationSyncResult resultado;

                    try
                    {
                        resultado =
                            await _repository.SynchronizeUserRegistrationAsync(
                                operation.OperationId,
                                payload.nombre,
                                payload.apellido,
                                payload.correo,
                                payload.contrasenaHash,
                                cancellationToken);
                    }
                    catch (OperationCanceledException)
                    {
                        throw;
                    }
                    catch (Exception ex)
                    {
                        await RegistrarErrorSeguroAsync(
                            "SynchronizeUserRegistrationAsync",
                            ex,
                            cancellationToken);

                        await _queue.RegisterFailedAttemptAsync(
                            operation.OperationId,
                            "SYNC_RESULT_UNKNOWN",
                            cancellationToken);

                        // No continuar con operaciones posteriores
                        // cuando el resultado de esta operación es desconocido.
                        break;
                    }

                    switch (resultado)
                    {
                        case RegistrationSyncResult.Completed:
                        case RegistrationSyncResult.AlreadyProcessed:

                            await _queue.MarkCompletedAsync(
                                operation.OperationId,
                                cancellationToken);

                            break;

                        case RegistrationSyncResult.DuplicateEmail:

                            await _queue.MarkConflictAsync(
                                operation.OperationId,
                                "DUPLICATE_EMAIL",
                                cancellationToken);

                            break;

                        case RegistrationSyncResult.OperationTypeMismatch:

                            await _queue.MarkConflictAsync(
                                operation.OperationId,
                                "OPERATION_TYPE_MISMATCH",
                                cancellationToken);

                            break;

                        default:
                            await _queue.RegisterFailedAttemptAsync(
                                operation.OperationId,
                                "UNEXPECTED_SYNC_RESULT",
                                cancellationToken);

                            // Detener la sincronización.
                            // El finally liberará el bloqueo.
                            return;
                    }
                }
            }
            finally
            {
                SynchronizationLock.Release();
            }
        }

        private static bool EsPayloadValido(
            UserRegistrationPayload payload)
        {
            return payload != null
                && !string.IsNullOrWhiteSpace(payload.nombre)
                && !string.IsNullOrWhiteSpace(payload.apellido)
                && !string.IsNullOrWhiteSpace(payload.correo)
                && !string.IsNullOrWhiteSpace(payload.contrasenaHash);
        }

        private async Task RegistrarErrorSeguroAsync(
            string operation,
            Exception exception,
            CancellationToken cancellationToken)
        {
            try
            {
                await _logger.LogErrorAsync(
                    operation,
                    exception,
                    cancellationToken);
            }
            catch (OperationCanceledException)
                when (cancellationToken.IsCancellationRequested)
            {
                throw;
            }
            catch (Exception)
            {
                // Un fallo del logger no debe impedir
                // el tratamiento del error de sincronización.
            }
        }
    }
}
