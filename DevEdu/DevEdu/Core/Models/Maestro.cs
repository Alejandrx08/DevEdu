using DevEdu.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu.Models
{
    public class Maestro : Persona
    {
        public List<Curso> Cursos { get; set; }
            = new List<Curso>();
    }
}