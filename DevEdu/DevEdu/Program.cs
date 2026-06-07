using DevEdu.Core.Services.Query;
using System;
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

            using (SELECT testConn = new SELECT())
            {
                if (!testConn.TestConnection())
                {
                    MessageBox.Show(
                        "No se pudo conectar a SQL Server.\nVerifica la cadena de conexión en appsettings.json.",
                        "Error de conexión",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }

            Application.Run(new Welcome_Splash());
        }
    }
}

// This proyect was created by an student for a university project (learning purposes only).