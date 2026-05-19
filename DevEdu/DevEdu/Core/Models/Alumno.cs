using DevEdu.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu.Models
{
    public class Alumno : Persona
    {
        public List<Curso> Cursos { get; set; }
            = new List<Curso>();
        public string Matricula { get; set; }
        public bool Asistencia { get; set; }

        public void AsignarAsistencia(bool presente)
        {
            Asistencia = presente;
        }
    }
}
