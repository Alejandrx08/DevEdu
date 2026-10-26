using DevEdu.Core.DTOs;
using DevEdu.Core.Presenters;
using System.Collections.Generic;

namespace DevEdu.Core.Interfaces
{
    public interface IBitacoraView : IPermisosView
    {
        void MostrarDatos(List<BitacoraDto> datos);
        void MostrarCantidad(int cantidad);

        void MostrarMensaje(string mensaje);
        void MostrarError(string mensaje);

        void ConfigurarGrid();
    }
}
