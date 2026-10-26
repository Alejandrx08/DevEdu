using DevEdu.Core.Interfaces;
using DevEdu.Core.Services;
using System;
using DevEdu.Core.DTOs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DevEdu.Core.Presenters
{
    public class BitacoraPresenter
    {
        private readonly IBitacoraView _view;
        private readonly BitacoraService _service;
        private readonly PermisosPresenter _permisosPresenter;

        public BitacoraPresenter(IBitacoraView view)
        {
            _view = view;
            _service = new BitacoraService();
            _permisosPresenter = new PermisosPresenter(view);
        }

        public void Iniciar()
        {
            if (!_permisosPresenter.ValidarSoloAdmin())
                return;

            _view.ConfigurarGrid();
            CargarDatos();
        }

        public async Task IniciarAsync(CancellationToken cancellationToken = default)
        {
            if (!_permisosPresenter.ValidarSoloAdmin())
                return;

            _view.ConfigurarGrid();

            await CargarDatosAsync(cancellationToken);
        }

        public void CargarDatos()
        {
            try
            {
                var datos = _service.ObtenerBitacora();

                _view.MostrarDatos(datos);
                _view.MostrarCantidad(datos.Count);
            }
            catch (Exception ex)
            {
                _view.MostrarError(
                    "Error al cargar la bitácora: " + ex.Message);
            }
        }

        public async Task CargarDatosAsync(
            CancellationToken cancellationToken = default)
        {
            try
            {
                var datos = await _service.ObtenerBitacoraAsync(
                    cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();

                _view.MostrarDatos(datos);
                _view.MostrarCantidad(datos.Count);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _view.MostrarError(
                    "Error al cargar la bitácora: " + ex.Message);
            }
        }
    }
}