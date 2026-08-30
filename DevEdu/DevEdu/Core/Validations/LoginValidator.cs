namespace DevEdu.Core.Validation
{
    public static class LoginValidator
    {
        public static bool EsValido(string correo, string password, out string mensajeError)
        {
            if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(password))
            {
                mensajeError = "Ingresa correo y contraseña";
                return false;
            }

            if (!EsCorreoValido(correo))
            {
                mensajeError = "El formato del correo no es válido";
                return false;
            }

            mensajeError = string.Empty;
            return true;
        }

        private static bool EsCorreoValido(string correo)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(
                correo,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}