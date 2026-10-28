using DevEdu.Core.Services.Offline;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevEdu
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using var cancellationTokenSource =
                new CancellationTokenSource();

            var worker = new OfflineSyncWorker();

            Task syncTask = Task.CompletedTask;

            try
            {
                syncTask = Task.Run(
                    () => worker.RunAsync(
                        cancellationTokenSource.Token));

                Application.Run(new Welcome_Splash());
            }
            finally
            {
                cancellationTokenSource.Cancel();

                try
                {
                    syncTask.GetAwaiter().GetResult();
                }
                catch (OperationCanceledException)
                {
                    // Cierre normal del trabajador.
                }
            }
        }
    }
}
