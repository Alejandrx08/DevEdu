using DevEdu.Core.Interfaces;

namespace DevEdu.Core.Presenters
{
    public class PermisosPresenter
    {
        private readonly IPermisosView _view;

        public PermisosPresenter(IPermisosView view)
        {
            _view = view;
        }

        public bool ValidarSoloAdmin()
        {
            if (!Sesion.EsSuperSU && !Sesion.EsAdmin)
            {
                _view.AccesoDenegado();
                return false;
            }

            return true;
        }

        public bool ValidarAdminOMaestro()
        {
            if (!Sesion.EsSuperSU &&
                !Sesion.EsAdmin &&
                !Sesion.EsMaestro)
            {
                _view.AccesoDenegado();
                return false;
            }

            return true;
        }

        public bool ValidarSesionActiva()
        {
            if (!Sesion.EstaAutenticado)
            {
                _view.AccesoDenegado();
                return false;
            }

            return true;
        }

        public bool ValidarSupervision()
        {
            if (!Sesion.EsSupervision)
            {
                _view.AccesoDenegado();
                return false;
            }

            return true;
        }

        public bool ValidarSupervisionOAdmin()
        {
            if (!Sesion.EsSuperSU &&
                !Sesion.EsAdmin &&
                !Sesion.EsSupervision)
            {
                _view.AccesoDenegado();
                return false;
            }

            return true;
        }
    }
}