using DevEdu.Core.Interfaces;
using DevEdu.Core.Services;
using System;
using System.Threading.Tasks;

namespace DevEdu.Core.Presenters
{
    public sealed class PasswordRecoveryPresenter
    {
        private readonly IPasswordRecoveryView _view;
        private readonly PasswordRecoveryService _service;

        public PasswordRecoveryPresenter(
            IPasswordRecoveryView view,
            PasswordRecoveryService service)
        {
            _view = view
                ?? throw new ArgumentNullException(nameof(view));

            _service = service
                ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task SolicitarCodigoAsync()
        {
            string correo = (_view.Correo ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(correo)
                || !correo.Contains('@'))
            {
                _view.MostrarError(
                    "Ingresa un correo electrónico válido.");
                return;
            }

            try
            {
                await _service.SolicitarCodigoAsync(correo);

                _view.MostrarMensaje(
                    "Si el correo corresponde a una cuenta activa, " +
                    "recibirás un código de recuperación. " +
                    "Revisa también la carpeta de spam.");
            }
            catch (Exception)
            {
                _view.MostrarError(
                    "No fue posible procesar la solicitud. " +
                    "Inténtalo más tarde.");
            }
        }

        public async Task RestablecerContrasenaAsync()
        {
            string correo = (_view.Correo ?? string.Empty).Trim();
            string codigo = (_view.Codigo ?? string.Empty).Trim();
            string nueva = _view.NuevaContrasena ?? string.Empty;
            string confirmacion =
                _view.ConfirmacionContrasena ?? string.Empty;

            if (string.IsNullOrWhiteSpace(correo)
                || !correo.Contains('@'))
            {
                _view.MostrarError(
                    "Ingresa un correo electrónico válido.");
                return;
            }

            if (codigo.Length != 6 || !EsCodigoNumerico(codigo))
            {
                _view.MostrarError(
                    "El código debe contener seis dígitos.");
                return;
            }

            if (nueva.Length < 6)
            {
                _view.MostrarError(
                    "La contraseña debe tener al menos 6 caracteres.");
                return;
            }

            if (!string.Equals(
                nueva,
                confirmacion,
                StringComparison.Ordinal))
            {
                _view.MostrarError(
                    "Las contraseñas no coinciden.");
                return;
            }

            try
            {
                bool restablecida =
                    await _service.RestablecerContrasenaAsync(
                        correo,
                        codigo,
                        nueva);

                if (!restablecida)
                {
                    _view.MostrarError(
                        "El código no es válido, ha vencido " +
                        "o superó el límite de intentos.");
                    return;
                }

                _view.MostrarMensaje(
                    "Contraseña actualizada. " +
                    "Ya puedes iniciar sesión.");

                _view.CerrarFormulario();
            }
            catch (Exception)
            {
                _view.MostrarError(
                    "No fue posible restablecer la contraseña. " +
                    "Inténtalo más tarde.");
            }
        }

        private static bool EsCodigoNumerico(string value)
        {
            foreach (char c in value)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}