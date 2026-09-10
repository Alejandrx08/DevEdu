using DevEdu.Core.Models;
using DevEdu.Models;
using System.Data;

namespace DevEdu.Core.Interfaces
{
    public interface IGeneralView
    {
        Persona UsuarioSeleccionado { get; }

        void MostrarDatos(DataTable datos);
        void MostrarCantidad(int cantidad);

        void MostrarMensaje(string mensaje);
        void MostrarError(string mensaje);

        bool Confirmar(string mensaje);

        void ConfigurarGrid();
        void AbrirAgregarUsuario();
    }
}