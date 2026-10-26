using DevEdu.Core.DTOs;
using DevEdu.Core.Models;
using DevEdu.Models;
using System.Collections.Generic;

namespace DevEdu.Core.Interfaces
{
    public interface IGeneralView
    {
        Persona UsuarioSeleccionado { get; }

        void MostrarDatos(List<UsuarioDto> datos);
        void MostrarCantidad(int cantidad);

        void MostrarMensaje(string mensaje);
        void MostrarError(string mensaje);

        bool Confirmar(string mensaje);

        void ConfigurarGrid();
        void AbrirAgregarUsuario();
    }
}
