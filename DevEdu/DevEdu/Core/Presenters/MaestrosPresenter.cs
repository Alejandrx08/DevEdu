using DevEdu.Core.Interfaces;
using DevEdu.Core.Services;
using DevEdu.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace DevEdu.Core.Presenters
{
    public class MaestrosPresenter
    {
        private readonly IMaestrosView _view;
        private readonly MaestroService _service;

        public MaestrosPresenter(IMaestrosView view)
        {
            _view = view
                ?? throw new ArgumentNullException(nameof(view));

            _service = new MaestroService();
        }

        public void Iniciar()
        {
            CargarDatos();
            CargarCantidad();
        }

        public async Task IniciarAsync(
            CancellationToken cancellationToken = default)
        {
            await CargarDatosAsync(cancellationToken);
            await CargarCantidadAsync(cancellationToken);
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
                _view.MostrarError(
                    "Error al cargar maestros: " + ex.Message);
            }
        }

        public async Task CargarDatosAsync(
            CancellationToken cancellationToken = default)
        {
            try
            {
                var datos = await _service.ObtenerMaestrosAsync(
                    cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();

                _view.MostrarDatos(datos);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _view.MostrarError(
                    "Error al cargar maestros: " + ex.Message);
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
                _view.MostrarError(
                    "Error al contar maestros: " + ex.Message);
            }
        }

        public async Task CargarCantidadAsync(
            CancellationToken cancellationToken = default)
        {
            try
            {
                int cantidad = await _service.ObtenerCantidadAsync(
                    cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();

                _view.MostrarCantidad(cantidad);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _view.MostrarError(
                    "Error al contar maestros: " + ex.Message);
            }
        }

        public void EditarDatos()
        {
            if (!ValidarID() ||
                !ValidarDatos() ||
                !ValidarCorreo())
            {
                return;
            }

            Maestro maestro = ObtenerMaestro();

            try
            {
                if (!_service.CorreoDisponible(maestro))
                {
                    MostrarCorreoDuplicado();
                    return;
                }

                _service.ActualizarMaestro(maestro);

                _view.MostrarMensaje(
                    "Maestro actualizado correctamente.");

                _view.LimpiarCampos();

                CargarDatos();
                CargarCantidad();
            }
            catch (Exception ex)
            {
                _view.MostrarError(
                    "Error al actualizar el maestro: " + ex.Message);
            }
        }

        public async Task EditarDatosAsync(
            CancellationToken cancellationToken = default)
        {
            if (!ValidarID() ||
                !ValidarDatos() ||
                !ValidarCorreo())
            {
                return;
            }

            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                Maestro maestro = ObtenerMaestro();

                bool correoDisponible =
                    await _service.CorreoDisponibleAsync(
                        maestro,
                        cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();

                if (!correoDisponible)
                {
                    MostrarCorreoDuplicado();
                    return;
                }

                await _service.ActualizarMaestroAsync(
                    maestro,
                    cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();

                _view.MostrarMensaje(
                    "Maestro actualizado correctamente.");

                _view.LimpiarCampos();

                await CargarDatosAsync(cancellationToken);
                await CargarCantidadAsync(cancellationToken);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _view.MostrarError(
                    "Error al actualizar el maestro: " + ex.Message);
            }
        }

        private void MostrarCorreoDuplicado()
        {
            _view.MostrarMensaje(
                "Ese correo ya está registrado en otro usuario.");

            _view.EnfocarCorreo();
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
                    "Rol de maestro retirado correctamente. " +
                    "El usuario ahora está pendiente.");

                _view.LimpiarCampos();

                CargarDatos();
                CargarCantidad();
            }
            catch (Exception ex)
            {
                _view.MostrarError(
                    "Error al retirar el rol: " + ex.Message);
            }
        }

        public async Task EliminarDatosAsync(
            CancellationToken cancellationToken = default)
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
                cancellationToken.ThrowIfCancellationRequested();

                int id = int.Parse(_view.Id);

                await _service.EliminarMaestroAsync(
                    id,
                    cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();

                _view.MostrarMensaje(
                    "Rol de maestro retirado correctamente. " +
                    "El usuario ahora está pendiente.");

                _view.LimpiarCampos();

                await CargarDatosAsync(cancellationToken);
                await CargarCantidadAsync(cancellationToken);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _view.MostrarError(
                    "Error al retirar el rol: " + ex.Message);
            }
        }

        private bool ValidarID()
        {
            if (string.IsNullOrWhiteSpace(_view.Id))
            {
                _view.MostrarMensaje("El ID es obligatorio.");
                _view.EnfocarId();
                return false;
            }

            if (!int.TryParse(_view.Id, out int id) || id <= 0)
            {
                _view.MostrarMensaje(
                    "El ID debe ser un número entero positivo.");

                _view.EnfocarId();
                return false;
            }

            return true;
        }

        private bool ValidarDatos()
        {
            string nombre = _view.Nombre?.Trim() ?? string.Empty;
            string apellido = _view.Apellido?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(nombre))
            {
                _view.MostrarMensaje(
                    "El campo Nombre no puede estar vacío.");

                return false;
            }

            if (string.IsNullOrWhiteSpace(apellido))
            {
                _view.MostrarMensaje(
                    "El campo Apellido no puede estar vacío.");

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
                    "El apellido solo puede contener letras.");

                return false;
            }

            return true;
        }

        private bool ValidarCorreo()
        {
            string correo = _view.Correo?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(correo))
            {
                _view.MostrarMensaje(
                    "El correo es obligatorio.");

                _view.EnfocarCorreo();
                return false;
            }

            if (!Regex.IsMatch(
                correo,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                _view.MostrarMensaje("El correo no es válido.");

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
