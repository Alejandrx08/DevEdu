using DevEdu.Core.Interfaces;
using DevEdu.Core.Services;
using DevEdu.Core.Validation;
using System;

namespace DevEdu.Core.Presenters
{
    public class RegistroPresenter
    {
        private readonly IRegistroView _view;
        private readonly UsuarioService _usuarioService;

        public RegistroPresenter(IRegistroView view, UsuarioService usuarioService)
        {
            _view = view;
            _usuarioService = usuarioService;
        }

        public void Registrar()
        {
            string nombre = _view.Nombre;
            string apellido = _view.Apellido;
            string correo = _view.Correo;
            string pass = _view.Password;
            string confirmacion = _view.Confirmacion;

            if (!UsuarioValidator.EsValido(nombre, apellido, correo, pass, confirmacion, out string mensajeError))
            {
                _view.MostrarError(mensajeError);
                return;
            }

            try
            {
                _usuarioService.Registrar(nombre, apellido, correo, pass);

                _view.MostrarExito("Registro exitoso. Ya puedes iniciar sesión.");
                _view.LimpiarCampos();
            }
            catch (Exception ex)
            {
                _view.MostrarError(ex.Message);
            }
        }
    }
}