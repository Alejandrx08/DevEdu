using DevEdu.Core.DTOs;
using DevEdu.Core.Interfaces;
using DevEdu.Core.Services;
using DevEdu.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;


namespace DevEdu.Core.Presenters
{
    public class MaestrosPresenter
    {
        private readonly IMaestrosView _view;
        private readonly MaestroService _service;

        public MaestrosPresenter(IMaestrosView view)
        {
            _view = view;
            _service = new MaestroService();
        }

        public void Iniciar()
        {
            CargarDatos();
            CargarCantidad();
        }

        public void CargarDatos()
        {
            try
            {
                var datos = _service.ObtenerMaestros();

                _view.MostrarDatos(datos);
            }
            catch (Exception ex)
            {
                _view.MostrarError("Error: " + ex.Message);
            }
        }


        public void CargarCantidad()
        {
            try
            {
                int cantidad = _service.ObtenerCantidad();
                _view.MostrarCantidad(cantidad);
            }
            catch (Exception ex)
            {
                _view.MostrarError("Error: " + ex.Message);
            }
        }

        public void EditarDatos()
        {
            if (!ValidarID())
                return;

            if (!ValidarDatos())
                return;

            if (!ValidarCorreo())
                return;

            Maestro maestro = ObtenerMaestro();

            try
            {
                if (!_service.CorreoDisponible(maestro))
                {
                    _view.MostrarMensaje(
                        "Ese correo ya está registrado en otro usuario.");

                    _view.EnfocarCorreo();
                    return;
                }

                _service.ActualizarMaestro(maestro);

                _view.MostrarMensaje(
                    "Dato actualizado correctamente");

                _view.LimpiarCampos();

                CargarDatos();
                CargarCantidad();
            }
            catch (Exception ex)
            {
                _view.MostrarError("Error: " + ex.Message);
            }
        }

        public void EliminarDatos()
        {
            if (!ValidarID())
                return;

            if (!_view.Confirmar(
                "¿Deseas quitar el rol de maestro a este usuario?"))
            {
                return;
            }

            try
            {
                int id = int.Parse(_view.Id);

                _service.EliminarMaestro(id);

                _view.MostrarMensaje(
                    "Rol maestro removido (ahora es pendiente).");

                _view.LimpiarCampos();

                CargarDatos();
                CargarCantidad();
            }
            catch (Exception ex)
            {
                _view.MostrarError("Error: " + ex.Message);
            }
        }

        private bool ValidarID()
        {
            if (string.IsNullOrWhiteSpace(_view.Id))
            {
                _view.MostrarMensaje("El ID es obligatorio");
                _view.EnfocarId();
                return false;
            }

            if (!int.TryParse(_view.Id, out _))
            {
                _view.MostrarMensaje("El ID debe ser numérico");
                _view.EnfocarId();
                return false;
            }

            return true;
        }

        private bool ValidarDatos()
        {
            string nombre = _view.Nombre.Trim();
            string apellido = _view.Apellido.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                _view.MostrarMensaje(
                    "El Campo 'Nombre' no puede estar vacio");

                return false;
            }

            if (string.IsNullOrWhiteSpace(apellido))
            {
                _view.MostrarMensaje(
                    "El campo 'Apellido' no puede estar vacio");

                return false;
            }

            if (!nombre.All(char.IsLetter))
            {
                _view.MostrarMensaje(
                    "El nombre solo puede contener letras.");

                return false;
            }

            if (!apellido.All(char.IsLetter))
            {
                _view.MostrarMensaje(
                    "El Apellido solo puede contener letras.");

                return false;
            }

            return true;
        }

        private bool ValidarCorreo()
        {
            string correo = _view.Correo.Trim();

            if (string.IsNullOrWhiteSpace(correo))
            {
                _view.MostrarMensaje("El correo es obligatorio");
                _view.EnfocarCorreo();
                return false;
            }

            if (!Regex.IsMatch(
                correo,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                _view.MostrarMensaje("Correo inválido");
                _view.EnfocarCorreo();
                return false;
            }

            return true;
        }

        private Maestro ObtenerMaestro()
        {
            return new Maestro
            {
                Id = int.Parse(_view.Id),
                Nombre = _view.Nombre.Trim(),
                Apellido = _view.Apellido.Trim(),
                Correo = _view.Correo.Trim()
            };
        }
    }
}