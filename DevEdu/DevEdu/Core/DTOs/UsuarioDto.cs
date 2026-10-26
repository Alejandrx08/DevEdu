namespace DevEdu.Core.DTOs
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Rango { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public bool Activo { get; set; }
    }
}
