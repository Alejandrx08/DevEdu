
using System;

namespace DevEdu.Core.DTOs
{
    public class BitacoraDto
    {
        public int Id { get; set; }
        public string Tabla { get; set; } = string.Empty;
        public string Operacion { get; set; } = string.Empty;
        public int? UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; } = string.Empty;
    }
}
