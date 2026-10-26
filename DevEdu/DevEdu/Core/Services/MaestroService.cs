using DevEdu.Core.DTOs;
using DevEdu.Core.Services.Query;
using DevEdu.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DevEdu.Core.Services
{
    public class MaestroService
    {

        public List<MaestroDto> ObtenerMaestros()
        {
            string query = @"
        SELECT
            u.id AS ID,
            u.nombre AS Nombre,
            u.apellido AS Apellido,
            u.correo AS Correo,
            u.rango AS Rango
        FROM usuarios u
        INNER JOIN maestros m
            ON m.usuario_id = u.id
        WHERE u.activo = 1;";

            using (SELECT select = new SELECT())
            {
                DataTable tabla = select.ExecuteSelect(query);
                List<MaestroDto> maestros = new List<MaestroDto>();

                foreach (DataRow fila in tabla.Rows)
                {
                    maestros.Add(new MaestroDto
                    {
                        Id = Convert.ToInt32(fila["ID"]),
                        Nombre = fila["Nombre"]?.ToString() ?? string.Empty,
                        Apellido = fila["Apellido"]?.ToString() ?? string.Empty,
                        Correo = fila["Correo"]?.ToString() ?? string.Empty,
                        Rango = fila["Rango"] == DBNull.Value
                            ? string.Empty
                            : fila["Rango"].ToString() ?? string.Empty
                    });
                }

                return maestros;
            }
        }


        public int ObtenerCantidad()
        {
            using (SELECT select = new SELECT())
            {
                object resultado = select.ExecuteScalar(
                    "SELECT COUNT(*) FROM maestros;");

                return Convert.ToInt32(resultado);
            }
        }

        public bool CorreoDisponible(Maestro maestro)
        {
            using (SELECT select = new SELECT())
            {
                object resultado = select.ExecuteScalar(
                    @"SELECT COUNT(*)
                      FROM usuarios
                      WHERE correo = @correo
                      AND id <> @id;",
                    new[]
                    {
                        new SqlParameter(
                            "@correo",
                            maestro.Correo),

                        new SqlParameter(
                            "@id",
                            maestro.Id)
                    });

                return Convert.ToInt32(resultado) == 0;
            }
        }

        public void ActualizarMaestro(Maestro maestro)
        {
            using (UPDATE update = new UPDATE())
            {
                update.ExecuteUpdate(
                    @"UPDATE usuarios
                      SET nombre = @nombre,
                          apellido = @apellido,
                          correo = @correo
                      WHERE id = @id;",
                    new[]
                    {
                        new SqlParameter(
                            "@id",
                            maestro.Id),

                        new SqlParameter(
                            "@nombre",
                            maestro.Nombre),

                        new SqlParameter(
                            "@apellido",
                            maestro.Apellido),

                        new SqlParameter(
                            "@correo",
                            maestro.Correo)
                    });
            }
        }

        public void EliminarMaestro(int id)
        {
            using (DELETE delete = new DELETE())
            {
                delete.ExecuteDelete(
                    @"DELETE FROM maestros
                      WHERE usuario_id = @id;",
                    new[]
                    {
                        new SqlParameter("@id", id)
                    });
            }

            using (UPDATE update = new UPDATE())
            {
                update.ExecuteUpdate(
                    @"UPDATE usuarios
                      SET tipo = NULL
                      WHERE id = @id;",
                    new[]
                    {
                        new SqlParameter("@id", id)
                    });
            }
        }
    }
}