using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DevEdu.Core.Services.Offline
{
    public sealed class OfflineSyncService
    {
        private readonly OfflineSyncLogger _logger;
        private readonly OfflineOperationQueue _queue;
        private readonly OfflineRegistrationRepository _repository;

        public OfflineSyncService()
            : this(
                new OfflineOperationQueue(),
                new OfflineRegistrationRepository(),
                new OfflineSyncLogger())
        {
        }

        public OfflineSyncService(
            OfflineOperationQueue queue,
            OfflineRegistrationRepository repository)
            : this(
                queue,
                repository,
                new OfflineSyncLogger())
        {
        }

        public OfflineSyncService(
            OfflineOperationQueue queue,
            OfflineRegistrationRepository repository,
            OfflineSyncLogger logger)
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

                    continue;
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
                        break;
                }
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
                // Un fallo del logger no debe impedir el tratamiento
                // del error original de sincronización.
            }
        }
    }
}
