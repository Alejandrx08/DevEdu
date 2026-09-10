using System;

namespace DevEdu.Core.Interfaces
{
    public interface IMainMenuView
    {
        void MostrarMenuUsuarios(bool visible);
        void MostrarMensaje(string mensaje);
        void Cerrar();

        void AbrirDevTrivia();
        void AbrirDevVis();
        void AbrirDevEx();
        void AbrirDevBot();
        void AbrirDevHub();

        void AbrirAlumnos();
        void AbrirMaestros();
        void AbrirGeneral();
        void AbrirBitacora();

        bool ConfirmarCerrarSesion();
        void CerrarSesion();
        void AbrirLogin();
    }
}