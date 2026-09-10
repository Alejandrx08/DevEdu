using DevEdu.Core.Interfaces;

namespace DevEdu.Core.Presenters
{
    public class MainMenuPresenter
    {
        private readonly IMainMenuView _view;

        public MainMenuPresenter(IMainMenuView view)
        {
            _view = view;
        }

        public void Iniciar()
        {
            if (!Sesion.EstaAutenticado)
            {
                _view.MostrarMensaje("Debe iniciar sesión.");
                _view.Cerrar();
                return;
            }

            AplicarPermisos();
        }

        private void AplicarPermisos()
        {
            bool puedeAdministrarUsuarios =
                Sesion.EsSuperSU ||
                Sesion.EsAdmin;

            _view.MostrarMenuUsuarios(
                puedeAdministrarUsuarios);
        }

        public void AbrirBitacora()
        {
            _view.AbrirBitacora();
        }

        public void AbrirDevTrivia()
        {
            _view.AbrirDevTrivia();
        }

        public void AbrirDevVis()
        {
            _view.AbrirDevVis();
        }

        public void AbrirDevEx()
        {
            _view.AbrirDevEx();
        }

        public void AbrirDevBot()
        {
            _view.AbrirDevBot();
        }

        public void AbrirDevHub()
        {
            _view.AbrirDevHub();
        }

        public void AbrirAlumnos()
        {
            _view.AbrirAlumnos();
        }

        public void AbrirMaestros()
        {
            _view.AbrirMaestros();
        }

        public void AbrirGeneral()
        {
            _view.AbrirGeneral();
        }

        public void CerrarSesion()
        {
            if (!_view.ConfirmarCerrarSesion())
                return;

            Sesion.Cerrar();

            _view.CerrarSesion();
            _view.AbrirLogin();
        }
    }
}