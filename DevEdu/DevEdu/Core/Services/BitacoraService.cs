using DevEdu.Core.Services.Query;
using System;
using System.Data;

namespace DevEdu.Core.Services
{
    public class BitacoraService
    {
        public DataTable ObtenerBitacora()
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
                return select.ExecuteSelect(query);
            }
        }
    }
}