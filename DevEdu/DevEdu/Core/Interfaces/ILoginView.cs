namespace DevEdu.Core.Interfaces
{
    public interface ILoginView
    {
        string Correo { get; }
        string Password { get; }
        void MostrarError(string mensaje);
        void MostrarBienvenida(string nombre);
        void NavegarAMenuPrincipal();
    }
}