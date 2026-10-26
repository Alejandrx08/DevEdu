using DevEdu.Core.Interfaces;
using DevEdu.Core.Models;
using DevEdu.Core.Services;
using DevEdu.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DevEdu.Core.Presenters
{
    public class GeneralPresenter
    {
        private readonly IGeneralView _view;
        private readonly UsuarioService _service;

        public GeneralPresenter(IGeneralView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _service = new UsuarioService();
        }

        public void Iniciar()
        {
            _view.ConfigurarGrid();
            ActualizarVista();
        }

        public async Task IniciarAsync(
            CancellationToken cancellationToken = default)
        {
            _view.ConfigurarGrid();

            await ActualizarVistaAsync(cancellationToken);
        }

        public void ActualizarVista()
        {
            try
            {
                int cantidad = _service.ContarUsuarios();
                var datos = _service.ObtenerUsuariosGeneral();

                _view.MostrarCantidad(cantidad);
                _view.MostrarDatos(datos);
            }
            catch (Exception ex)
            {
                _view.MostrarError(
                    "Error al cargar los usuarios: " + ex.Message);
            }
        }

        public async Task ActualizarVistaAsync(
            CancellationToken cancellationToken = default)
        {
            try
            {
                int cantidad = await _service.ContarUsuariosAsync(
                    cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();

                var datos = await _service.ObtenerUsuariosGeneralAsync(
                    cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();

                _view.MostrarCantidad(cantidad);
                _view.MostrarDatos(datos);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _view.MostrarError(
                    "Error al cargar los usuarios: " + ex.Message);
            }
        }

        public void GuardarCambios()
        {
            Persona usuario = _view.UsuarioSeleccionado;

            if (usuario == null)
            {
                _view.MostrarMensaje(
                    "Debe seleccionar un usuario válido.");
                return;
            }

            try
            {
                _service.ActualizarUsuario(usuario);

                _view.MostrarMensaje(
                    "Cambios guardados correctamente.");

                ActualizarVista();
            }
            catch (Exception ex)
            {
                _view.MostrarError(
                    "Error al guardar los cambios: " + ex.Message);
            }
        }

        public async Task GuardarCambiosAsync(
            CancellationToken cancellationToken = default)
        {
            Persona usuario = _view.UsuarioSeleccionado;

            if (usuario == null)
            {
                _view.MostrarMensaje(
                    "Debe seleccionar un usuario válido.");
                return;
            }

            try
            {
                await _service.ActualizarUsuarioAsync(
                    usuario, cancellationToken);

                _view.MostrarMensaje(
                    "Cambios guardados correctamente.");

                await ActualizarVistaAsync(cancellationToken);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _view.MostrarError(
                    "Error al guardar los cambios: " + ex.Message);
            }
        }

        public void EliminarUsuario()
        {
            Persona usuario = _view.UsuarioSeleccionado;

            if (usuario == null)
            {
                _view.MostrarMensaje(
                    "Debe seleccionar un usuario válido.");
                return;
            }

            string mensaje =
                $"¿Deseas ELIMINAR el usuario " +
                $"{usuario.ObtenerNombreCompleto()} " +
                $"con ID {usuario.Id}?\n\n" +
                "Esta acción no se puede deshacer.";

            if (!_view.Confirmar(mensaje))
                return;

            try
            {
                _service.EliminarUsuario(usuario.Id);

                _view.MostrarMensaje(
                    "Usuario eliminado con éxito.");

                ActualizarVista();
            }
            catch (Exception ex)
            {
                _view.MostrarError(
                    "Error al eliminar: " + ex.Message);
            }
        }

        public async Task EliminarUsuarioAsync(
            CancellationToken cancellationToken = default)
        {
            Persona usuario = _view.UsuarioSeleccionado;

            if (usuario == null)
            {
                _view.MostrarMensaje(
                    "Debe seleccionar un usuario válido.");
                return;
            }

            string mensaje =
                $"¿Deseas ELIMINAR el usuario " +
                $"{usuario.ObtenerNombreCompleto()} " +
                $"con ID {usuario.Id}?\n\n" +
                "Esta acción no se puede deshacer.";

            if (!_view.Confirmar(mensaje))
                return;

            try
            {
                await _service.EliminarUsuarioAsync(
                    usuario.Id, cancellationToken);

                _view.MostrarMensaje(
                    "Usuario eliminado con éxito.");

                await ActualizarVistaAsync(cancellationToken);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _view.MostrarError(
                    "Error al eliminar: " + ex.Message);
            }
        }

        public void AsignarAlumno()
        {
            AsignarRol("Alumno");
        }

        public void AsignarMaestro()
        {
            AsignarRol("Maestro");
        }

        public void AsignarAdmin()
        {
            AsignarRol("Admin");
        }

        private void AsignarRol(string rol)
        {
            Persona usuario = _view.UsuarioSeleccionado;

            if (usuario == null)
            {
                _view.MostrarMensaje(
                    "Debe seleccionar un usuario válido.");
                return;
            }

            if (!string.Equals(
                usuario.Estado, "pendiente",
                StringComparison.OrdinalIgnoreCase))
            {
                _view.MostrarMensaje(
                    "Ya tiene rol: " + usuario.Estado);
                return;
            }

            try
            {
                _service.AsignarRol(usuario.Id, rol);

                _view.MostrarMensaje(
                    "Rol asignado correctamente.");

                ActualizarVista();
            }
            catch (Exception ex)
            {
                _view.MostrarError(
                    "Error al asignar el rol: " + ex.Message);
            }
        }

        public Task AsignarAlumnoAsync(
            CancellationToken cancellationToken = default)
        {
            return AsignarRolAsync("Alumno", cancellationToken);
        }

        public Task AsignarMaestroAsync(
            CancellationToken cancellationToken = default)
        {
            return AsignarRolAsync("Maestro", cancellationToken);
        }

        public Task AsignarAdminAsync(
            CancellationToken cancellationToken = default)
        {
            return AsignarRolAsync("Admin", cancellationToken);
        }

        private async Task AsignarRolAsync(
            string rol,
            CancellationToken cancellationToken)
        {
            Persona usuario = _view.UsuarioSeleccionado;

            if (usuario == null)
            {
                _view.MostrarMensaje(
                    "Debe seleccionar un usuario válido.");
                return;
            }

            if (!string.Equals(
                usuario.Estado, "pendiente",
                StringComparison.OrdinalIgnoreCase))
            {
                _view.MostrarMensaje(
                    "Ya tiene rol: " + usuario.Estado);
                return;
            }

            try
            {
                await _service.AsignarRolAsync(
                    usuario.Id, rol, cancellationToken);

                _view.MostrarMensaje(
                    "Rol asignado correctamente.");

                await ActualizarVistaAsync(cancellationToken);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _view.MostrarError(
                    "Error al asignar el rol: " + ex.Message);
            }
        }

        public void QuitarRol()
        {
            Persona usuario = _view.UsuarioSeleccionado;

            if (usuario == null)
            {
                _view.MostrarMensaje(
                    "Debe seleccionar un usuario válido.");
                return;
            }

            if (string.Equals(
                usuario.Estado, "pendiente",
                StringComparison.OrdinalIgnoreCase))
            {
                _view.MostrarMensaje(
                    "El usuario ya está pendiente.");
                return;
            }

            try
            {
                _service.QuitarRol(
                    usuario.Id, usuario.Estado);

                _view.MostrarMensaje(
                    "Rol eliminado correctamente.");

                ActualizarVista();
            }
            catch (Exception ex)
            {
                _view.MostrarError(
                    "Error al quitar el rol: " + ex.Message);
            }
        }

        public async Task QuitarRolAsync(
            CancellationToken cancellationToken = default)
        {
            Persona usuario = _view.UsuarioSeleccionado;

            if (usuario == null)
            {
                _view.MostrarMensaje(
                    "Debe seleccionar un usuario válido.");
                return;
            }

            if (string.Equals(
                usuario.Estado, "pendiente",
                StringComparison.OrdinalIgnoreCase))
            {
                _view.MostrarMensaje(
                    "El usuario ya está pendiente.");
                return;
            }

            try
            {
                await _service.QuitarRolAsync(
                    usuario.Id,
                    usuario.Estado,
                    cancellationToken);

                _view.MostrarMensaje(
                    "Rol eliminado correctamente.");

                await ActualizarVistaAsync(cancellationToken);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _view.MostrarError(
                    "Error al quitar el rol: " + ex.Message);
            }
        }

        public void AgregarUsuario()
        {
            _view.AbrirAgregarUsuario();
        }
    }
}
