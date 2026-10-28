using System;
using System.Threading;
using System.Threading.Tasks;

namespace DevEdu.Core.Services.Offline
{
    public sealed class OfflineSyncWorker
    {
        private readonly OfflineSyncService _syncService;
        private readonly OfflineSyncLogger _logger;
        private readonly TimeSpan _interval;

        public OfflineSyncWorker()
            : this(
                new OfflineSyncService(),
                new OfflineSyncLogger(),
                TimeSpan.FromSeconds(30))
        {
        }

        public OfflineSyncWorker(
            OfflineSyncService syncService,
            OfflineSyncLogger logger,
            TimeSpan interval)
        {
            _syncService = syncService
                ?? throw new ArgumentNullException(nameof(syncService));

            _logger = logger
                ?? throw new ArgumentNullException(nameof(logger));

            if (interval <= TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(interval),
                    "El intervalo debe ser mayor que cero.");
            }

            _interval = interval;
        }

        public async Task RunAsync(
            CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    await _syncService.SynchronizePendingAsync(
                        cancellationToken);
                }
                catch (OperationCanceledException)
                    when (cancellationToken.IsCancellationRequested)
                {
                    break;
                }
                catch (Exception ex)
                {
                    await RegistrarErrorSeguroAsync(
                        "SynchronizePendingAsync",
                        ex,
                        cancellationToken);
                }

                try
                {
                    await Task.Delay(
                        _interval,
                        cancellationToken);
                }
                catch (OperationCanceledException)
                    when (cancellationToken.IsCancellationRequested)
                {
                    break;
                }
            }
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
                // La cancelación del cierre es normal.
            }
            catch (Exception)
            {
                // Un fallo al escribir el log no debe cerrar DevEdu.
            }
        }
    }
}
