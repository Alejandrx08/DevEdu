using System;

namespace DevEdu.Core.Interfaces
{
    public interface IGeneralAddView
    {
        string Nombre { get; }
        string Apellido { get; }
        string Correo { get; }
        string Contrasena { get; }

        void MostrarMensaje(string mensaje);
        void MostrarError(string mensaje);

        void LimpiarCampos();
        void EnfocarNombre();
        void Cerrar();
    }
}