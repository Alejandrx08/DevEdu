using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevEdu.Core.Services.Offline
{
    public sealed class OfflineSyncLogger
    {
        private static readonly SemaphoreSlim FileLock = new(1, 1);

        private readonly string _logPath;

        public OfflineSyncLogger()
        {
            string directory = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "DevEdu",
                "Logs");

            _logPath = Path.Combine(directory, "offline-sync.log");
        }

        public async Task LogErrorAsync(
            string operation,
            Exception exception,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(operation))
                operation = "OfflineSync";

            // No registrar mensajes ni payloads que puedan contener
            // información personal o credenciales.
            string entry =
                $"[{DateTime.UtcNow:O}] ERROR | {operation} | " +
                $"{exception.GetType().Name}{Environment.NewLine}";

            await FileLock.WaitAsync(cancellationToken);

            try
            {
                string directory = Path.GetDirectoryName(_logPath)!;
                Directory.CreateDirectory(directory);

                await File.AppendAllTextAsync(
                    _logPath,
                    entry,
                    Encoding.UTF8,
                    cancellationToken);
            }
            finally
            {
                FileLock.Release();
            }
        }
    }
}
