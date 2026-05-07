using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Correo { get; set; }

        public string Rango { get; set; }

        public string Estado { get; set; }

        public bool Activo { get; set; }

        public string ObtenerNombreCompleto()
        {
            return Nombre + " " + Apellido;
        }
    }
}
