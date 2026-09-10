using DevEdu.Core.Presenters;
using System.Data;

namespace DevEdu.Core.Interfaces
{
    public interface IBitacoraView : IPermisosView
    {
        void MostrarDatos(DataTable datos);
        void MostrarCantidad(int cantidad);

        void MostrarMensaje(string mensaje);
        void MostrarError(string mensaje);

        void ConfigurarGrid();
    }
}