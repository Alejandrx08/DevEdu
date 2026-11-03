using DevEdu.Core.Services.SQLite;
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
            // Inicia la sincronización local en segundo plano junto con la aplicación.
            var worker = new SQLiteSyncWorker();

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
