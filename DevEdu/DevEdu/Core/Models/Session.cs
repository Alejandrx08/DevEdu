using DevEdu.Core.Models;

namespace DevEdu
{
    public static class Sesion
    {
        public static int Id { get; private set; }
        public static string Nombre { get; private set; }
        public static string Rango { get; private set; }
        public static string Tipo { get; private set; }

        public static bool EstaAutenticado => Id != 0;

        public static void Iniciar(UsuarioAutenticado usuario)
        {
            Id = usuario.Id;
            Nombre = usuario.Nombre;
            Rango = usuario.Rango;
            Tipo = usuario.Tipo;
        }

        public static void Cerrar()
        {
            Id = 0;
            Nombre = null;
            Rango = null;
            Tipo = null;
        }

        public static bool EsSuperSU =>
            Rango == "SuperSU";

        public static bool EsAdmin =>
            Rango == "Admin";

        public static bool EsSupervision =>
            Rango == "Supervision";

        public static bool EsRegular =>
            Rango == "Regular";

        public static bool EsTipoAdmin =>
            Tipo == "Admin";

        public static bool EsTipoMaestro =>
            Tipo == "Maestro";

        public static bool EsTipoAlumno =>
            Tipo == "Alumno";

        public static bool EsMaestro =>
            Tipo == "Maestro";

        public static bool EsAlumno =>
            Tipo == "Alumno";
    }
}