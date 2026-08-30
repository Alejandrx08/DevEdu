using System.Text.RegularExpressions;

namespace DevEdu.Core.Validation
{
    public static class UsuarioValidator
    {
        // Usado por FrmRegistro (incluye confirmación de contraseña)
        public static bool EsValido(string nombre, string apellido, string correo,
                                     string pass, string confirmacion, out string mensajeError)
        {
            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(pass) ||
                string.IsNullOrWhiteSpace(confirmacion))
            {
                mensajeError = "Por favor, complete todos los campos.";
                return false;
            }

            if (!CorreoValido(correo))
            {
                mensajeError = "Correo inválido.";
                return false;
            }

            if (pass.Length < 6)
            {
                mensajeError = "La contraseña debe tener al menos 6 caracteres.";
                return false;
            }

            if (pass != confirmacion)
            {
                mensajeError = "Las contraseñas no coinciden.";
                return false;
            }

            mensajeError = string.Empty;
            return true;
        }

        // Usado por DgvGeneralAdd (sin confirmación, valida que nombre/apellido no sean números)
        public static bool EsValidoParaAlta(string nombre, string apellido, string correo,
                                             string pass, out string mensajeError)
        {
            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(pass))
            {
                mensajeError = "Por favor, complete todos los campos.";
                return false;
            }

            if (int.TryParse(nombre, out _))
            {
                mensajeError = "El nombre no puede ser un número.";
                return false;
            }

            if (int.TryParse(apellido, out _))
            {
                mensajeError = "El apellido no puede ser un número.";
                return false;
            }

            if (!CorreoValido(correo))
            {
                mensajeError = "Correo inválido.";
                return false;
            }

            if (pass.Length < 6)
            {
                mensajeError = "La contraseña debe tener al menos 6 caracteres.";
                return false;
            }

            mensajeError = string.Empty;
            return true;
        }

        private static bool CorreoValido(string correo)
        {
            return Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}