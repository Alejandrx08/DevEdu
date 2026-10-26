using DevEdu.Core.DTOs;
using DevEdu.Core.Services.Query;
using System;
using System.Collections.Generic;
using System.Data;

namespace DevEdu.Core.Services
{
    public class BitacoraService
    {
        public List<BitacoraDto> ObtenerBitacora()
        {
            string query = @"
                SELECT
                    id,
                    tabla,
                    operacion,
                    usuario_id,
                    fecha,
                    descripcion
                FROM bitacora
                ORDER BY fecha DESC, id DESC;";

            using (SELECT select = new SELECT())
            {
                DataTable tabla = select.ExecuteSelect(query);
                List<BitacoraDto> registros =
                    new List<BitacoraDto>();

                foreach (DataRow fila in tabla.Rows)
                {
                    registros.Add(new BitacoraDto
                    {
                        Id = Convert.ToInt32(fila["id"]),
                        Tabla = fila["tabla"]?.ToString()
                            ?? string.Empty,
                        Operacion = fila["operacion"]?.ToString()
                            ?? string.Empty,
                        UsuarioId = fila["usuario_id"] == DBNull.Value
                            ? (int?)null
                            : Convert.ToInt32(fila["usuario_id"]),
                        Fecha = Convert.ToDateTime(fila["fecha"]),
                        Descripcion = fila["descripcion"]?.ToString()
                            ?? string.Empty
                    });
                }

                return registros;
            }
        }
    }
}
