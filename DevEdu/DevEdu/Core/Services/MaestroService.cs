using DevEdu.Core.DTOs;
using DevEdu.Core.Services.Query;
using DevEdu.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace DevEdu.Core.Services
{
    public class MaestroService
    {
        private const string QueryMaestros = @"
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

        public List<MaestroDto> ObtenerMaestros()
        {
            using (SELECT select = new SELECT())
            {
                DataTable tabla = select.ExecuteSelect(QueryMaestros);
                return ConvertirMaestros(tabla);
            }
        }

        public async Task<List<MaestroDto>> ObtenerMaestrosAsync(
            CancellationToken cancellationToken = default)
        {
            using (SELECT select = new SELECT())
            {
                DataTable tabla = await select.ExecuteSelectAsync(
                    QueryMaestros,
                    cancellationToken: cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();

                return ConvertirMaestros(tabla);
            }
        }

        private List<MaestroDto> ConvertirMaestros(DataTable tabla)
        {
            List<MaestroDto> maestros = new List<MaestroDto>();

            foreach (DataRow fila in tabla.Rows)
            {
                maestros.Add(new MaestroDto
                {
                    Id = Convert.ToInt32(fila["ID"]),
                    Nombre = fila["Nombre"]?.ToString()
                        ?? string.Empty,
                    Apellido = fila["Apellido"]?.ToString()
                        ?? string.Empty,
                    Correo = fila["Correo"]?.ToString()
                        ?? string.Empty,
                    Rango = fila["Rango"] == DBNull.Value
                        ? string.Empty
                        : fila["Rango"].ToString() ?? string.Empty
                });
            }

            return maestros;
        }

        public int ObtenerCantidad()
        {
            using (SELECT select = new SELECT())
            {
                object resultado = select.ExecuteScalar(
                    @"SELECT COUNT(*)
                      FROM usuarios u
                      INNER JOIN maestros m
                          ON m.usuario_id = u.id
                      WHERE u.activo = 1;");

                return Convert.ToInt32(resultado);
            }
        }

        public async Task<int> ObtenerCantidadAsync(
            CancellationToken cancellationToken = default)
        {
            using (SELECT select = new SELECT())
            {
                object resultado = await select.ExecuteScalarAsync(
                    @"SELECT COUNT(*)
                      FROM usuarios u
                      INNER JOIN maestros m
                          ON m.usuario_id = u.id
                      WHERE u.activo = 1;",
                    cancellationToken: cancellationToken);

                return Convert.ToInt32(resultado);
            }
        }

        public bool CorreoDisponible(Maestro maestro)
        {
            if (maestro == null)
                throw new ArgumentNullException(nameof(maestro));

            using (SELECT select = new SELECT())
            {
                object resultado = select.ExecuteScalar(
                    @"SELECT COUNT(*)
                      FROM usuarios
                      WHERE correo = @correo
                        AND id <> @id;",
                    new[]
                    {
                        new SqlParameter("@correo", maestro.Correo),
                        new SqlParameter("@id", maestro.Id)
                    });

                return Convert.ToInt32(resultado) == 0;
            }
        }

        public async Task<bool> CorreoDisponibleAsync(
            Maestro maestro,
            CancellationToken cancellationToken = default)
        {
            if (maestro == null)
                throw new ArgumentNullException(nameof(maestro));

            using (SELECT select = new SELECT())
            {
                object resultado = await select.ExecuteScalarAsync(
                    @"SELECT COUNT(*)
                      FROM usuarios
                      WHERE correo = @correo
                        AND id <> @id;",
                    new[]
                    {
                        new SqlParameter("@correo", maestro.Correo),
                        new SqlParameter("@id", maestro.Id)
                    },
                    cancellationToken: cancellationToken);

                return Convert.ToInt32(resultado) == 0;
            }
        }

        public void ActualizarMaestro(Maestro maestro)
        {
            if (maestro == null)
                throw new ArgumentNullException(nameof(maestro));

            using (UPDATE update = new UPDATE())
            {
                update.ExecuteUpdate(
                    @"UPDATE usuarios
                      SET nombre = @nombre,
                          apellido = @apellido,
                          correo = @correo
                      WHERE id = @id
                        AND EXISTS
                        (
                            SELECT 1
                            FROM maestros
                            WHERE usuario_id = @id
                        );",
                    CrearParametrosMaestro(maestro));
            }
        }

        public async Task ActualizarMaestroAsync(
            Maestro maestro,
            CancellationToken cancellationToken = default)
        {
            if (maestro == null)
                throw new ArgumentNullException(nameof(maestro));

            using (UPDATE update = new UPDATE())
            {
                await update.ExecuteUpdateAsync(
                    @"UPDATE usuarios
                      SET nombre = @nombre,
                          apellido = @apellido,
                          correo = @correo
                      WHERE id = @id
                        AND EXISTS
                        (
                            SELECT 1
                            FROM maestros
                            WHERE usuario_id = @id
                        );",
                    CrearParametrosMaestro(maestro),
                    cancellationToken: cancellationToken);
            }
        }

        private SqlParameter[] CrearParametrosMaestro(Maestro maestro)
        {
            return new[]
            {
                new SqlParameter("@id", maestro.Id),
                new SqlParameter("@nombre", maestro.Nombre),
                new SqlParameter("@apellido", maestro.Apellido),
                new SqlParameter("@correo", maestro.Correo)
            };
        }

        public void EliminarMaestro(int id)
        {
            using (DELETE delete = new DELETE())
            {
                delete.ExecuteDelete(
                    CrearConsultaEliminarMaestro(),
                    new[]
                    {
                        new SqlParameter("@id", id)
                    });
            }
        }

        public async Task EliminarMaestroAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            using (DELETE delete = new DELETE())
            {
                await delete.ExecuteDeleteAsync(
                    CrearConsultaEliminarMaestro(),
                    new[]
                    {
                        new SqlParameter("@id", id)
                    },
                    cancellationToken: cancellationToken);
            }
        }

        private string CrearConsultaEliminarMaestro()
        {
            return @"
                SET NOCOUNT ON;

                BEGIN TRY
                    BEGIN TRANSACTION;

                    DELETE FROM maestros
                    WHERE usuario_id = @id;

                    IF @@ROWCOUNT = 0
                        THROW 50001,
                            'No se encontró el registro de maestro.',
                            1;

                    UPDATE usuarios
                    SET tipo = NULL
                    WHERE id = @id
                      AND tipo = 'Maestro';

                    IF @@ROWCOUNT = 0
                        THROW 50002,
                            'No se pudo actualizar el rol del usuario.',
                            1;

                    COMMIT TRANSACTION;
                END TRY
                BEGIN CATCH
                    IF XACT_STATE() <> 0
                        ROLLBACK TRANSACTION;

                    THROW;
                END CATCH;";
        }
    }
}
