using DevEdu.Core.Services.Query;
using DevEdu.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace DevEdu.Core.Services
{
    public class AlumnoService
    {
        public DataTable ObtenerAlumnos()
        {
            string query = @"SELECT 
                                u.id       AS ID,
                                u.nombre   AS Nombre,
                                u.apellido AS Apellido,
                                u.correo   AS Correo,
                                u.rango    AS Rango
                             FROM usuarios u
                             INNER JOIN alumnos a ON a.usuario_id = u.id
                             WHERE u.activo = 1";

            using (SELECT select = new SELECT())
            {
                return select.ExecuteSelect(query);
            }
        }

        public int ObtenerCantidad()
        {
            using (SELECT select = new SELECT())
            {
                object result =
                    select.ExecuteScalar("SELECT COUNT(*) FROM alumnos;");

                return Convert.ToInt32(result);
            }
        }

        public bool CorreoDisponible(Alumno alumno)
        {
            using (SELECT select = new SELECT())
            {
                object result = select.ExecuteScalar(
                    "SELECT COUNT(*) FROM usuarios WHERE correo=@c AND id<>@id;",
                    new[]
                    {
                        new SqlParameter("@c", alumno.Correo),
                        new SqlParameter("@id", alumno.Id)
                    });

                return Convert.ToInt32(result) == 0;
            }
        }

        public void ActualizarAlumno(Alumno alumno)
        {
            using (UPDATE update = new UPDATE())
            {
                update.ExecuteUpdate(
                    @"UPDATE usuarios
                      SET nombre=@nombre,
                          apellido=@apellido,
                          correo=@correo
                      WHERE id=@id",
                    new[]
                    {
                        new SqlParameter("@id", alumno.Id),
                        new SqlParameter("@nombre", alumno.Nombre),
                        new SqlParameter("@apellido", alumno.Apellido),
                        new SqlParameter("@correo", alumno.Correo)
                    });
            }
        }

        public void EliminarAlumno(int id)
        {
            using (DELETE delete = new DELETE())
            {
                delete.ExecuteDelete(
                    "DELETE FROM alumnos WHERE usuario_id=@id;",
                    new[]
                    {
                        new SqlParameter("@id", id)
                    });
            }

            using (UPDATE update = new UPDATE())
            {
                update.ExecuteUpdate(
                    "UPDATE usuarios SET tipo=NULL WHERE id=@id;",
                    new[]
                    {
                        new SqlParameter("@id", id)
                    });
            }
        }
    }
}