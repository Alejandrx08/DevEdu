using DevEdu.Core.Models;
using DevEdu.Core.Services.Query;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace DevEdu.Core.Services
{
    public class AuthService
    {
        public UsuarioAutenticado IniciarSesion(string correo, string password)
        {
            string query = @"SELECT id, nombre, rango, tipo
                              FROM usuarios
                              WHERE correo = @correo
                                AND contrasena = @pass
                                AND activo = 1";

            SqlParameter[] parametros =
            {
                new SqlParameter("@correo", correo),
                new SqlParameter("@pass", password)
            };

            using (SELECT select = new SELECT())
            {
                DataTable result = select.ExecuteSelect(query, parametros);

                if (result.Rows.Count == 0)
                    return null;

                DataRow row = result.Rows[0];

                return new UsuarioAutenticado
                {
                    Id = Convert.ToInt32(row["id"]),
                    Nombre = row["nombre"].ToString(),
                    Rango = row["rango"].ToString(),
                    Tipo = row["tipo"] == DBNull.Value ? null : row["tipo"].ToString()
                };
            }
        }
    }
}