using DevEdu.Core.Interfaces;
using DevEdu.Core.Services;
using DevEdu.Core.Validation;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DevEdu.Core.Presenters
{
    public class GeneralAddPresenter
    {
        private readonly IGeneralAddView _view;
        private readonly UsuarioService _service;

        public GeneralAddPresenter(IGeneralAddView view)
        {
            _view = view
                ?? throw new ArgumentNullException(nameof(view));

            _service = new UsuarioService();
        }

        public void AgregarUsuario()
        {
            if (!ValidarFormulario(
                out string nombre,
                out string apellido,
                out string correo,
                out string contrasena))
            {
                return;
            }

            try
            {
                _service.Registrar(
                    nombre,
                    apellido,
                    correo,
                    contrasena);

                FinalizarRegistro();
            }
            catch (Exception ex)
            {
                _view.MostrarError(ex.Message);
            }
        }

        public async Task AgregarUsuarioAsync(
            CancellationToken cancellationToken = default)
        {
            if (!ValidarFormulario(
                out string nombre,
                out string apellido,
                out string correo,
                out string contrasena))
            {
                return;
            }

            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                await _service.RegistrarAsync(
                    nombre,
                    apellido,
                    correo,
                    contrasena,
                    cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();

                FinalizarRegistro();
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _view.MostrarError(ex.Message);
            }
        }

        private bool ValidarFormulario(
            out string nombre,
            out string apellido,
            out string correo,
            out string contrasena)
        {
            nombre = (_view.Nombre ?? string.Empty).Trim();
            apellido = (_view.Apellido ?? string.Empty).Trim();
            correo = (_view.Correo ?? string.Empty).Trim();
            contrasena = _view.Contrasena ?? string.Empty;

            if (!UsuarioValidator.EsValidoParaAlta(
                nombre,
                apellido,
                correo,
                contrasena,
                out string mensajeError))
            {
                _view.MostrarMensaje(mensajeError);
                return false;
            }

            return true;
        }

        private void FinalizarRegistro()
        {
            _view.MostrarMensaje(
                "Usuario agregado con éxito.");

            _view.LimpiarCampos();
            _view.EnfocarNombre();
        }
    }
}
