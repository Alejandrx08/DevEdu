namespace DevEdu.Core.Interfaces
{
    public interface IPasswordRecoveryView
    {
        string Correo { get; }
        string Codigo { get; }
        string NuevaContrasena { get; }
        string ConfirmacionContrasena { get; }

        void MostrarMensaje(string mensaje);
        void MostrarError(string mensaje);
        void CerrarFormulario();
    }
}
