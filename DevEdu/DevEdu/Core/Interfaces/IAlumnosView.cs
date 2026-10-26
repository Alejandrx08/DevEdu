
using DevEdu.Core.DTOs;
using System.Collections.Generic;

namespace DevEdu.Core.Interfaces
{
    public interface IAlumnosView
    {
        string Id { get; }
        string Nombre { get; }
        string Apellido { get; }
        string Correo { get; }

        void MostrarDatos(List<AlumnoDto> datos);
        void MostrarMensaje(string mensaje);
        void MostrarError(string mensaje);
        bool Confirmar(string mensaje);

        void LimpiarCampos();
        void EnfocarCorreo();
        void EnfocarId();

        void MostrarCantidad(int cantidad);
    }
}
