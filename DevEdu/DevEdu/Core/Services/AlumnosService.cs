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
    public class AlumnoService
    {
        private const string QueryAlumnos = @"
            SELECT
                u.id AS ID,
                u.nombre AS Nombre,
                u.apellido AS Apellido,
                u.correo AS Correo,
                u.rango AS Rango
            FROM usuarios u
            INNER JOIN alumnos a
                ON a.usuario_id = u.id
            WHERE u.activo = 1;";

        public List<AlumnoDto> ObtenerAlumnos()
        {
            using (SELECT select = new SELECT())
            {
                DataTable tabla = select.ExecuteSelect(QueryAlumnos);
                return ConvertirAlumnos(tabla);
            }
        }

        public async Task<List<AlumnoDto>> ObtenerAlumnosAsync(
            CancellationToken cancellationToken = default)
        {
            using (SELECT select = new SELECT())
            {
                DataTable tabla = await select.ExecuteSelectAsync(
                    QueryAlumnos,
                    cancellationToken: cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();

                return ConvertirAlumnos(tabla);
            }
        }

        private List<AlumnoDto> ConvertirAlumnos(DataTable tabla)
        {
            List<AlumnoDto> alumnos = new List<AlumnoDto>();

            foreach (DataRow fila in tabla.Rows)
            {
                alumnos.Add(new AlumnoDto
                {
                    Id = Convert.ToInt32(fila["ID"]),
                    Nombre = Convert.ToString(fila["Nombre"])
                        ?? string.Empty,
                    Apellido = Convert.ToString(fila["Apellido"])
                        ?? string.Empty,
                    Correo = Convert.ToString(fila["Correo"])
                        ?? string.Empty,
                    Rango = fila["Rango"] == DBNull.Value
                        ? string.Empty
                        : Convert.ToString(fila["Rango"])
                            ?? string.Empty
                });
            }

            return alumnos;
        }

        public int ObtenerCantidad()
        {
            using (SELECT select = new SELECT())
            {
                object resultado = select.ExecuteScalar(
                    @"SELECT COUNT(*)
                      FROM usuarios u
                      INNER JOIN alumnos a
                          ON a.usuario_id = u.id
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
                      INNER JOIN alumnos a
                          ON a.usuario_id = u.id
                      WHERE u.activo = 1;",
                    cancellationToken: cancellationToken);

                return Convert.ToInt32(resultado);
            }
        }

        public bool CorreoDisponible(Alumno alumno)
        {
            if (alumno == null)
                throw new ArgumentNullException(nameof(alumno));

            using (SELECT select = new SELECT())
            {
                object resultado = select.ExecuteScalar(
                    @"SELECT COUNT(*)
                      FROM usuarios
                      WHERE correo = @correo
                        AND id <> @id;",
                    new[]
                    {
                        new SqlParameter("@correo", alumno.Correo),
                        new SqlParameter("@id", alumno.Id)
                    });

                return Convert.ToInt32(resultado) == 0;
            }
        }

        public async Task<bool> CorreoDisponibleAsync(
            Alumno alumno,
            CancellationToken cancellationToken = default)
        {
            if (alumno == null)
                throw new ArgumentNullException(nameof(alumno));

            using (SELECT select = new SELECT())
            {
                object resultado = await select.ExecuteScalarAsync(
                    @"SELECT COUNT(*)
                      FROM usuarios
                      WHERE correo = @correo
                        AND id <> @id;",
                    new[]
                    {
                        new SqlParameter("@correo", alumno.Correo),
                        new SqlParameter("@id", alumno.Id)
                    },
                    cancellationToken: cancellationToken);

                return Convert.ToInt32(resultado) == 0;
            }
        }

        public void ActualizarAlumno(Alumno alumno)
        {
            if (alumno == null)
                throw new ArgumentNullException(nameof(alumno));

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
                            FROM alumnos
                            WHERE usuario_id = @id
                        );",
                    CrearParametrosAlumno(alumno));
            }
        }

        public async Task ActualizarAlumnoAsync(
            Alumno alumno,
            CancellationToken cancellationToken = default)
        {
            if (alumno == null)
                throw new ArgumentNullException(nameof(alumno));

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
                            FROM alumnos
                            WHERE usuario_id = @id
                        );",
                    CrearParametrosAlumno(alumno),
                    cancellationToken: cancellationToken);
            }
        }

        private SqlParameter[] CrearParametrosAlumno(Alumno alumno)
        {
            return new[]
            {
                new SqlParameter("@id", alumno.Id),
                new SqlParameter("@nombre", alumno.Nombre),
                new SqlParameter("@apellido", alumno.Apellido),
                new SqlParameter("@correo", alumno.Correo)
            };
        }

        public void EliminarAlumno(int id)
        {
            using (DELETE delete = new DELETE())
            {
                delete.ExecuteDelete(
                    CrearConsultaEliminarAlumno(),
                    new[]
                    {
                        new SqlParameter("@id", id)
                    });
            }
        }

        public async Task EliminarAlumnoAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            using (DELETE delete = new DELETE())
            {
                await delete.ExecuteDeleteAsync(
                    CrearConsultaEliminarAlumno(),
                    new[]
                    {
                        new SqlParameter("@id", id)
                    },
                    cancellationToken: cancellationToken);
            }
        }

        private string CrearConsultaEliminarAlumno()
        {
            return @"
                SET NOCOUNT ON;

                BEGIN TRY
                    BEGIN TRANSACTION;

                    DELETE FROM alumnos
                    WHERE usuario_id = @id;

                    IF @@ROWCOUNT = 0
                        THROW 50001,
                            'No se encontró el registro de alumno.',
                            1;

                    UPDATE usuarios
                    SET tipo = NULL
                    WHERE id = @id
                      AND tipo = 'Alumno';

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
