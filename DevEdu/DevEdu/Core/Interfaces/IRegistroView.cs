namespace DevEdu.Core.Interfaces
{
    public interface IRegistroView
    {
        string Nombre { get; }
        string Apellido { get; }
        string Correo { get; }
        string Password { get; }
        string Confirmacion { get; }

        void MostrarError(string mensaje);
        void MostrarExito(string mensaje);
        void LimpiarCampos();
    }
}