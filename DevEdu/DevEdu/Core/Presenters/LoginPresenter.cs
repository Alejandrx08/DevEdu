
using DevEdu.Core.Interfaces;
using DevEdu.Core.Models;
using DevEdu.Core.Services;
using DevEdu.Core.Validation;
using System;
using System.Threading.Tasks;

namespace DevEdu.Core.Presenters
{
    public class LoginPresenter
    {
        private readonly ILoginView _view;
        private readonly AuthService _authService;

        public LoginPresenter(
            ILoginView view,
            AuthService authService)
        {
            _view = view;
            _authService = authService;
        }

        public async Task IniciarSesionAsync()
        {
            string correo = _view.Correo;
            string pass = _view.Password;

            if (!LoginValidator.EsValido(
                correo,
                pass,
                out string mensajeError))
            {
                _view.MostrarError(mensajeError);
                return;
            }

            try
            {
                UsuarioAutenticado usuario =
                    await _authService.IniciarSesionAsync(
                        correo,
                        pass);

                if (usuario == null)
                {
                    _view.MostrarError(
                        "Correo o contraseña incorrectos");
                    return;
                }

                Sesion.Iniciar(usuario);

                _view.MostrarBienvenida(Sesion.Nombre);
                _view.NavegarAMenuPrincipal();
            }
            catch (Exception ex)
            {
                _view.MostrarError(
                    "Error al iniciar sesión: " + ex.Message);
            }
        }
    }
}
