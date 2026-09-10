using DevEdu.Core.Interfaces;
using DevEdu.Core.Services;
using System;

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

        public void CargarDatos()
        {
            try
            {
                var datos = _service.ObtenerBitacora();

                _view.MostrarDatos(datos);
                _view.MostrarCantidad(datos.Rows.Count);
            }
            catch (Exception ex)
            {
                _view.MostrarError(
                    "Error al cargar la bitácora: " + ex.Message);
            }
        }
    }
}