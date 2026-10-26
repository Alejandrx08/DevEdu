
using DevEdu.Core.DTOs;
using System.Collections.Generic;

namespace DevEdu.Core.Interfaces
{
    public interface IMaestrosView
    {
        string Id { get; }
        string Nombre { get; }
        string Apellido { get; }
        string Correo { get; }

        void MostrarDatos(List<MaestroDto> datos);
        void MostrarMensaje(string mensaje);
        void MostrarError(string mensaje);
        bool Confirmar(string mensaje);

        void LimpiarCampos();
        void EnfocarCorreo();
        void EnfocarId();

        void MostrarCantidad(int cantidad);
    }
}
