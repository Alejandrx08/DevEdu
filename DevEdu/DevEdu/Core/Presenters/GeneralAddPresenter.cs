using DevEdu.Core.Interfaces;
using DevEdu.Core.Services;
using DevEdu.Core.Validation;
using System;

namespace DevEdu.Core.Presenters
{
    public class GeneralAddPresenter
    {
        private readonly IGeneralAddView _view;
        private readonly UsuarioService _service;

        public GeneralAddPresenter(IGeneralAddView view)
        {
            _view = view;
            _service = new UsuarioService();
        }

        public void AgregarUsuario()
        {
            string nombre = _view.Nombre.Trim();
            string apellido = _view.Apellido.Trim();
            string correo = _view.Correo.Trim();
            string contrasena = _view.Contrasena;

            if (!UsuarioValidator.EsValidoParaAlta(
                nombre,
                apellido,
                correo,
                contrasena,
                out string mensajeError))
            {
                _view.MostrarMensaje(mensajeError);
                return;
            }

            try
            {
                _service.Registrar(
                    nombre,
                    apellido,
                    correo,
                    contrasena);

                _view.MostrarMensaje(
                    "Usuario agregado con éxito.");

                _view.LimpiarCampos();
                _view.EnfocarNombre();
            }
            catch (Exception ex)
            {
                _view.MostrarError(
                    ex.Message);
            }
        }
    }
}