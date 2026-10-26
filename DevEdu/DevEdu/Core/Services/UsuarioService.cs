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
    public class UsuarioService
    {
        public void Registrar(
            string nombre,
            string apellido,
            string correo,
            string pass)
        {
            if (CorreoExiste(correo))
                throw new InvalidOperationException(
                    "Ese correo ya está registrado.");

            string hash = BCrypt.Net.BCrypt.HashPassword(pass);

            using (INSERT insert = new INSERT())
            {
                int filas = insert.ExecuteInsert(
                    @"INSERT INTO usuarios
                      (nombre, apellido, correo, contrasena)
                      VALUES
                      (@nombre, @apellido, @correo, @contrasena);",
                    new[]
                    {
                        new SqlParameter("@nombre", nombre),
                        new SqlParameter("@apellido", apellido),
                        new SqlParameter("@correo", correo),
                        new SqlParameter("@contrasena", hash)
                    });

                if (filas <= 0)
                    throw new InvalidOperationException(
                        "No se pudo registrar. Intenta de nuevo.");
            }
        }

        private bool CorreoExiste(string correo)
        {
            using (SELECT select = new SELECT())
            {
                object resultado = select.ExecuteScalar(
                    "SELECT COUNT(*) FROM usuarios WHERE correo=@correo;",
                    new[]
                    {
                        new SqlParameter("@correo", correo)
                    });

                return Convert.ToInt32(resultado) > 0;
            }
        }

        public int ContarUsuarios()
        {
            using (SELECT select = new SELECT())
            {
                object resultado =
                    select.ExecuteScalar(
                        "SELECT COUNT(*) FROM usuarios;");

                return Convert.ToInt32(resultado);
            }
        }

        public async Task<int> ContarUsuariosAsync(
            CancellationToken cancellationToken = default)
        {
            using (SELECT select = new SELECT())
            {
                object resultado = await select.ExecuteScalarAsync(
                    "SELECT COUNT(*) FROM usuarios;",
                    cancellationToken: cancellationToken);

                return Convert.ToInt32(resultado);
            }
        }

        private const string QueryUsuarios = @"
            SELECT
                u.id,
                u.nombre,
                u.apellido,
                u.correo,
                u.rango,
                ISNULL(u.tipo, 'pendiente') AS estado,
                u.activo
            FROM usuarios u;";

        public List<UsuarioDto> ObtenerUsuariosGeneral()
        {
            using (SELECT select = new SELECT())
            {
                DataTable tabla =
                    select.ExecuteSelect(QueryUsuarios);

                return ConvertirUsuarios(tabla);
            }
        }

        public async Task<List<UsuarioDto>> ObtenerUsuariosGeneralAsync(
            CancellationToken cancellationToken = default)
        {
            using (SELECT select = new SELECT())
            {
                DataTable tabla = await select.ExecuteSelectAsync(
                    QueryUsuarios,
                    cancellationToken: cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();

                return ConvertirUsuarios(tabla);
            }
        }

        private List<UsuarioDto> ConvertirUsuarios(DataTable tabla)
        {
            List<UsuarioDto> usuarios = new List<UsuarioDto>();

            foreach (DataRow fila in tabla.Rows)
            {
                usuarios.Add(new UsuarioDto
                {
                    Id = Convert.ToInt32(fila["id"]),
                    Nombre = fila["nombre"]?.ToString()
                        ?? string.Empty,
                    Apellido = fila["apellido"]?.ToString()
                        ?? string.Empty,
                    Correo = fila["correo"]?.ToString()
                        ?? string.Empty,
                    Rango = fila["rango"] == DBNull.Value
                        ? string.Empty
                        : fila["rango"].ToString() ?? string.Empty,
                    Estado = fila["estado"]?.ToString()
                        ?? "pendiente",
                    Activo = Convert.ToBoolean(fila["activo"])
                });
            }

            return usuarios;
        }

        public bool CorreoPerteneceAOtroUsuario(
            string correo,
            int id)
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
                        new SqlParameter("@correo", correo),
                        new SqlParameter("@id", id)
                    });

                return Convert.ToInt32(resultado) > 0;
            }
        }

        private async Task<bool> CorreoPerteneceAOtroUsuarioAsync(
            string correo,
            int id,
            CancellationToken cancellationToken)
        {
            using (SELECT select = new SELECT())
            {
                object resultado = await select.ExecuteScalarAsync(
                    @"SELECT COUNT(*)
                      FROM usuarios
                      WHERE correo = @correo
                        AND id <> @id;",
                    new[]
                    {
                        new SqlParameter("@correo", correo),
                        new SqlParameter("@id", id)
                    },
                    cancellationToken);

                return Convert.ToInt32(resultado) > 0;
            }
        }

        public void ActualizarUsuario(Persona usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            if (CorreoPerteneceAOtroUsuario(
                usuario.Correo, usuario.Id))
            {
                throw new InvalidOperationException(
                    "Ese correo ya existe en otro usuario.");
            }

            using (UPDATE update = new UPDATE())
            {
                update.ExecuteUpdate(
                    @"UPDATE usuarios
                      SET nombre = @nombre,
                          apellido = @apellido,
                          correo = @correo,
                          rango = @rango,
                          activo = @activo
                      WHERE id = @id;",
                    ParametrosUsuario(usuario));
            }
        }

        public async Task ActualizarUsuarioAsync(
            Persona usuario,
            CancellationToken cancellationToken = default)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            if (await CorreoPerteneceAOtroUsuarioAsync(
                usuario.Correo,
                usuario.Id,
                cancellationToken))
            {
                throw new InvalidOperationException(
                    "Ese correo ya existe en otro usuario.");
            }

            cancellationToken.ThrowIfCancellationRequested();

            using (UPDATE update = new UPDATE())
            {
                await update.ExecuteUpdateAsync(
                    @"UPDATE usuarios
                      SET nombre = @nombre,
                          apellido = @apellido,
                          correo = @correo,
                          rango = @rango,
                          activo = @activo
                      WHERE id = @id;",
                    ParametrosUsuario(usuario),
                    cancellationToken);
            }
        }

        private SqlParameter[] ParametrosUsuario(Persona usuario)
        {
            return new[]
            {
                new SqlParameter("@nombre", usuario.Nombre),
                new SqlParameter("@apellido", usuario.Apellido),
                new SqlParameter("@correo", usuario.Correo),
                new SqlParameter("@rango", usuario.Rango),
                new SqlParameter("@activo", usuario.Activo),
                new SqlParameter("@id", usuario.Id)
            };
        }

        public void EliminarUsuario(int id)
        {
            using (DELETE delete = new DELETE())
            {
                delete.ExecuteDelete(
                    @"BEGIN TRY
                          BEGIN TRANSACTION;

                          DELETE FROM alumnos
                          WHERE usuario_id = @id;

                          DELETE FROM maestros
                          WHERE usuario_id = @id;

                          DELETE FROM usuarios
                          WHERE id = @id;

                          IF @@ROWCOUNT = 0
                              THROW 50001,
                                  'No se encontró el usuario.',
                                  1;

                          COMMIT TRANSACTION;
                      END TRY
                      BEGIN CATCH
                          IF XACT_STATE() <> 0
                              ROLLBACK TRANSACTION;
                          THROW;
                      END CATCH;",
                    new[]
                    {
                        new SqlParameter("@id", id)
                    });
            }
        }

        public async Task EliminarUsuarioAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            using (DELETE delete = new DELETE())
            {
                await delete.ExecuteDeleteAsync(
                    @"BEGIN TRY
                          BEGIN TRANSACTION;

                          DELETE FROM alumnos
                          WHERE usuario_id = @id;

                          DELETE FROM maestros
                          WHERE usuario_id = @id;

                          DELETE FROM usuarios
                          WHERE id = @id;

                          IF @@ROWCOUNT = 0
                              THROW 50001,
                                  'No se encontró el usuario.',
                                  1;

                          COMMIT TRANSACTION;
                      END TRY
                      BEGIN CATCH
                          IF XACT_STATE() <> 0
                              ROLLBACK TRANSACTION;
                          THROW;
                      END CATCH;",
                    new[]
                    {
                        new SqlParameter("@id", id)
                    },
                    cancellationToken);
            }
        }

        public void AsignarRol(int id, string rol)
        {
            string tabla = ObtenerTablaRol(rol);

            string insertarAlumnoMaestro = tabla == null
                ? string.Empty
                : $@"INSERT INTO {tabla} (usuario_id)
                     VALUES (@id);";

            using (INSERT insert = new INSERT())
            {
                int filas = insert.ExecuteInsert(
                    $@"BEGIN TRY
                           BEGIN TRANSACTION;

                           UPDATE usuarios
                           SET tipo = @tipo
                           WHERE id = @id
                             AND tipo IS NULL;

                           IF @@ROWCOUNT = 0
                               THROW 50002,
                                   'El usuario no existe o ya tiene rol.',
                                   1;

                           {insertarAlumnoMaestro}

                           COMMIT TRANSACTION;
                       END TRY
                       BEGIN CATCH
                           IF XACT_STATE() <> 0
                               ROLLBACK TRANSACTION;
                           THROW;
                       END CATCH;",
                    new[]
                    {
                        new SqlParameter("@tipo", rol),
                        new SqlParameter("@id", id)
                    });

                if (filas == 0)
                    throw new InvalidOperationException(
                        "No se pudo asignar el rol.");
            }
        }

        public async Task AsignarRolAsync(
            int id,
            string rol,
            CancellationToken cancellationToken = default)
        {
            string tabla = ObtenerTablaRol(rol);

            string insertarAlumnoMaestro = tabla == null
                ? string.Empty
                : $@"INSERT INTO {tabla} (usuario_id)
                     VALUES (@id);";

            using (INSERT insert = new INSERT())
            {
                int filas = await insert.ExecuteInsertAsync(
                    $@"BEGIN TRY
                           BEGIN TRANSACTION;

                           UPDATE usuarios
                           SET tipo = @tipo
                           WHERE id = @id
                             AND tipo IS NULL;

                           IF @@ROWCOUNT = 0
                               THROW 50002,
                                   'El usuario no existe o ya tiene rol.',
                                   1;

                           {insertarAlumnoMaestro}

                           COMMIT TRANSACTION;
                       END TRY
                       BEGIN CATCH
                           IF XACT_STATE() <> 0
                               ROLLBACK TRANSACTION;
                           THROW;
                       END CATCH;",
                    new[]
                    {
                        new SqlParameter("@tipo", rol),
                        new SqlParameter("@id", id)
                    },
                    cancellationToken);

                if (filas == 0)
                    throw new InvalidOperationException(
                        "No se pudo asignar el rol.");
            }
        }

        private string ObtenerTablaRol(string rol)
        {
            switch (rol)
            {
                case "Alumno":
                    return "alumnos";

                case "Maestro":
                    return "maestros";

                case "Admin":
                    return null;

                default:
                    throw new ArgumentException(
                        "Rol no reconocido: " + rol,
                        nameof(rol));
            }
        }

        public void QuitarRol(int id, string estadoActual)
        {
            string tabla = ObtenerTablaRolParaRetirar(estadoActual);

            string eliminarRelacion = tabla == null
                ? string.Empty
                : $@"DELETE FROM {tabla}
                     WHERE usuario_id = @id;";

            using (DELETE delete = new DELETE())
            {
                delete.ExecuteDelete(
                    $@"BEGIN TRY
                           BEGIN TRANSACTION;

                           {eliminarRelacion}

                           UPDATE usuarios
                           SET tipo = NULL
                           WHERE id = @id
                             AND tipo = @rol;

                           IF @@ROWCOUNT = 0
                               THROW 50003,
                                   'No se encontró el usuario con ese rol.',
                                   1;

                           COMMIT TRANSACTION;
                       END TRY
                       BEGIN CATCH
                           IF XACT_STATE() <> 0
                               ROLLBACK TRANSACTION;
                           THROW;
                       END CATCH;",
                    new[]
                    {
                        new SqlParameter("@id", id),
                        new SqlParameter("@rol", estadoActual)
                    });
            }
        }

        public async Task QuitarRolAsync(
            int id,
            string estadoActual,
            CancellationToken cancellationToken = default)
        {
            string tabla = ObtenerTablaRolParaRetirar(estadoActual);

            string eliminarRelacion = tabla == null
                ? string.Empty
                : $@"DELETE FROM {tabla}
                     WHERE usuario_id = @id;";

            using (DELETE delete = new DELETE())
            {
                await delete.ExecuteDeleteAsync(
                    $@"BEGIN TRY
                           BEGIN TRANSACTION;

                           {eliminarRelacion}

                           UPDATE usuarios
                           SET tipo = NULL
                           WHERE id = @id
                             AND tipo = @rol;

                           IF @@ROWCOUNT = 0
                               THROW 50003,
                                   'No se encontró el usuario con ese rol.',
                                   1;

                           COMMIT TRANSACTION;
                       END TRY
                       BEGIN CATCH
                           IF XACT_STATE() <> 0
                               ROLLBACK TRANSACTION;
                           THROW;
                       END CATCH;",
                    new[]
                    {
                        new SqlParameter("@id", id),
                        new SqlParameter("@rol", estadoActual)
                    },
                    cancellationToken);
            }
        }

        private string ObtenerTablaRolParaRetirar(string rol)
        {
            switch (rol)
            {
                case "Alumno":
                    return "alumnos";

                case "Maestro":
                    return "maestros";

                case "Admin":
                    return null;

                default:
                    throw new ArgumentException(
                        "Rol no reconocido: " + rol,
                        nameof(rol));
            }
        }

        public void DesactivarUsuario(int id)
        {
            using (UPDATE update = new UPDATE())
            {
                update.ExecuteUpdate(
                    @"UPDATE usuarios
                      SET activo = 0
                      WHERE id = @id
                        AND activo = 1;",
                    new[]
                    {
                        new SqlParameter("@id", id)
                    });
            }
        }

        public async Task DesactivarUsuarioAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            using (UPDATE update = new UPDATE())
            {
                await update.ExecuteUpdateAsync(
                    @"UPDATE usuarios
                      SET activo = 0
                      WHERE id = @id
                        AND activo = 1;",
                    new[]
                    {
                        new SqlParameter("@id", id)
                    },
                    cancellationToken);
            }
        }

        public async Task RegistrarAsync(
            string nombre,
            string apellido,
            string correo,
            string pass,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            bool correoExiste = await CorreoExisteAsync(
                correo,
                cancellationToken);

            cancellationToken.ThrowIfCancellationRequested();

            if (correoExiste)
            {
                throw new InvalidOperationException(
                    "Ese correo ya está registrado.");
            }

            string hash = BCrypt.Net.BCrypt.HashPassword(pass);

            cancellationToken.ThrowIfCancellationRequested();

            using (INSERT insert = new INSERT())
            {
                int filas = await insert.ExecuteInsertAsync(
                    @"INSERT INTO usuarios
              (nombre, apellido, correo, contrasena)
              VALUES
              (@nombre, @apellido, @correo, @contrasena);",
                    new[]
                    {
                new SqlParameter("@nombre", nombre),
                new SqlParameter("@apellido", apellido),
                new SqlParameter("@correo", correo),
                new SqlParameter("@contrasena", hash)
                    },
                    cancellationToken);

                if (filas <= 0)
                {
                    throw new InvalidOperationException(
                        "No se pudo registrar el usuario.");
                }
            }
        }

        private async Task<bool> CorreoExisteAsync(
            string correo,
            CancellationToken cancellationToken = default)
        {
            using (SELECT select = new SELECT())
            {
                object resultado = await select.ExecuteScalarAsync(
                    @"SELECT COUNT(*)
              FROM usuarios
              WHERE correo = @correo;",
                    new[]
                    {
                new SqlParameter("@correo", correo)
                    },
                    cancellationToken);

                return Convert.ToInt32(resultado) > 0;
            }
        }
    }
}
