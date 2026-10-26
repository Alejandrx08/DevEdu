using DevEdu.Core.Models;
using DevEdu.Core.Services.Query;
using DevEdu.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using BCrypt.Net;
using DevEdu.Core.DTOs;
using System.Collections.Generic;

namespace DevEdu.Core.Services
{
    public class UsuarioService
    {
        public void Registrar(string nombre, string apellido, string correo, string pass)
        {
            if (CorreoExiste(correo))
                throw new InvalidOperationException("Ese correo ya está registrado.");

            string hash = BCrypt.Net.BCrypt.HashPassword(pass);

            using (INSERT insert = new INSERT())
            {
                int filas = insert.ExecuteInsert(
                    "INSERT INTO usuarios (nombre, apellido, correo, contrasena) VALUES (@nombre, @apellido, @correo, @contrasena);",
                    new SqlParameter[]
                    {
                new SqlParameter("@nombre", nombre),
                new SqlParameter("@apellido", apellido),
                new SqlParameter("@correo", correo),
                new SqlParameter("@contrasena", hash)
                    });

                if (filas <= 0)
                    throw new InvalidOperationException("No se pudo registrar. Intenta de nuevo.");
            }
        }

        private bool CorreoExiste(string correo)
        {
            using (SELECT select = new SELECT())
            {
                object existe = select.ExecuteScalar(
                    "SELECT COUNT(*) FROM usuarios WHERE correo=@correo;",
                    new[] { new SqlParameter("@correo", correo) });

                return Convert.ToInt32(existe) > 0;
            }
        }

        public int ContarUsuarios()
        {
            using (SELECT select = new SELECT())
            {
                object result = select.ExecuteScalar("SELECT COUNT(*) FROM usuarios;");
                return Convert.ToInt32(result);
            }
        }


        public List<UsuarioDto> ObtenerUsuariosGeneral()
        {
            string query = @"SELECT
                         u.id,
                         u.nombre,
                         u.apellido,
                         u.correo,
                         u.rango,
                         ISNULL(u.tipo, 'pendiente') AS estado,
                         u.activo
                     FROM usuarios u";

            using (SELECT select = new SELECT())
            {
                DataTable tabla = select.ExecuteSelect(query);
                List<UsuarioDto> usuarios = new List<UsuarioDto>();

                foreach (DataRow fila in tabla.Rows)
                {
                    usuarios.Add(new UsuarioDto
                    {
                        Id = Convert.ToInt32(fila["id"]),
                        Nombre = fila["nombre"]?.ToString() ?? string.Empty,
                        Apellido = fila["apellido"]?.ToString() ?? string.Empty,
                        Correo = fila["correo"]?.ToString() ?? string.Empty,
                        Rango = fila["rango"] == DBNull.Value
                            ? string.Empty
                            : fila["rango"].ToString() ?? string.Empty,
                        Estado = fila["estado"]?.ToString() ?? "pendiente",
                        Activo = Convert.ToBoolean(fila["activo"])
                    });
                }

                return usuarios;
            }
        }


        public bool CorreoPerteneceAOtroUsuario(string correo, int id)
        {
            using (SELECT select = new SELECT())
            {
                object result = select.ExecuteScalar(
                    "SELECT COUNT(*) FROM usuarios WHERE correo=@correo AND id<>@id;",
                    new[]
                    {
                        new SqlParameter("@correo", correo),
                        new SqlParameter("@id", id)
                    });

                return Convert.ToInt32(result) > 0;
            }
        }

        public void ActualizarUsuario(Persona usuario)
        {
            if (CorreoPerteneceAOtroUsuario(usuario.Correo, usuario.Id))
                throw new InvalidOperationException("Ese correo ya existe en otro usuario.");

            using (UPDATE update = new UPDATE())
            {
                update.ExecuteUpdate(
                    @"UPDATE usuarios 
                      SET nombre=@nombre,
                          apellido=@apellido,
                          correo=@correo,
                          rango=@rango,
                          activo=@activo
                      WHERE id=@id",
                    new[]
                    {
                        new SqlParameter("@nombre", usuario.Nombre),
                        new SqlParameter("@apellido", usuario.Apellido),
                        new SqlParameter("@correo", usuario.Correo),
                        new SqlParameter("@rango", usuario.Rango),
                        new SqlParameter("@activo", usuario.Activo),
                        new SqlParameter("@id", usuario.Id)
                    });
            }
        }

        public void EliminarUsuario(int id)
        {
            using (DELETE delete = new DELETE())
                delete.ExecuteDeleteOptional(
                    "DELETE FROM alumnos WHERE usuario_id=@id;",
                    new[] { new SqlParameter("@id", id) });

            using (DELETE delete = new DELETE())
                delete.ExecuteDeleteOptional(
                    "DELETE FROM maestros WHERE usuario_id=@id;",
                    new[] { new SqlParameter("@id", id) });

            using (DELETE delete = new DELETE())
                delete.ExecuteDelete(
                    "DELETE FROM usuarios WHERE id=@id;",
                    new[] { new SqlParameter("@id", id) });
        }

        public void AsignarRol(int id, string rol)
        {
            string tabla;

            if (rol == "Alumno")
                tabla = "alumnos";
            else if (rol == "Maestro")
                tabla = "maestros";
            else if (rol == "Admin")
                tabla = null;
            else
                throw new ArgumentException("Rol no reconocido: " + rol);

            if (tabla != null)
            {
                using (INSERT insert = new INSERT())
                {
                    insert.ExecuteInsert(
                        $"INSERT INTO {tabla} (usuario_id) VALUES (@id);",
                        new[] { new SqlParameter("@id", id) });
                }
            }

            using (UPDATE update = new UPDATE())
            {
                update.ExecuteUpdate(
                    "UPDATE usuarios SET tipo=@tipo WHERE id=@id;",
                    new[]
                    {
                        new SqlParameter("@tipo", rol),
                        new SqlParameter("@id", id)
                    });
            }
        }

        public void QuitarRol(int id, string estadoActual)
        {
            if (estadoActual == "Alumno")
            {
                using (DELETE delete = new DELETE())
                    delete.ExecuteDelete(
                        "DELETE FROM alumnos WHERE usuario_id=@id;",
                        new[] { new SqlParameter("@id", id) });
            }
            else if (estadoActual == "Maestro")
            {
                using (DELETE delete = new DELETE())
                    delete.ExecuteDelete(
                        "DELETE FROM maestros WHERE usuario_id=@id;",
                        new[] { new SqlParameter("@id", id) });
            }

            using (UPDATE update = new UPDATE())
            {
                update.ExecuteUpdate(
                    "UPDATE usuarios SET tipo=NULL WHERE id=@id;",
                    new[] { new SqlParameter("@id", id) });
            }
        }
    }
}