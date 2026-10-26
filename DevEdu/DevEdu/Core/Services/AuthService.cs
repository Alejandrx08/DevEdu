
using BCrypt.Net;
using DevEdu.Core.Models;
using DevEdu.Core.Services.Query;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace DevEdu.Core.Services
{
    public class AuthService
    {
        public async Task<UsuarioAutenticado> IniciarSesionAsync(
            string correo,
            string password,
            CancellationToken cancellationToken = default)
        {
            const string query = @"
                SELECT id, nombre, rango, tipo, contrasena
                FROM usuarios
                WHERE correo = @correo;";

            SqlParameter[] parametros =
            {
                new SqlParameter("@correo", correo)
            };

            using (SELECT select = new SELECT())
            {
                DataTable result = await select.ExecuteSelectAsync(
                    query,
                    parametros,
                    cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();

                if (result.Rows.Count == 0)
                    return null;

                DataRow row = result.Rows[0];

                string hashAlmacenado =
                    row["contrasena"]?.ToString();

                if (string.IsNullOrEmpty(hashAlmacenado))
                    return null;

                if (!BCrypt.Net.BCrypt.Verify(
                    password,
                    hashAlmacenado))
                {
                    return null;
                }

                cancellationToken.ThrowIfCancellationRequested();

                return new UsuarioAutenticado
                {
                    Id = Convert.ToInt32(row["id"]),
                    Nombre = row["nombre"].ToString(),
                    Rango = row["rango"].ToString(),
                    Tipo = row["tipo"] == DBNull.Value
                        ? null
                        : row["tipo"].ToString()
                };
            }
        }
    }
}
