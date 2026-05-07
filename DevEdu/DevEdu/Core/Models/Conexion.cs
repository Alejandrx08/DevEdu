using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu.Core.Models
{
    public class ConexionDB
    {
        private string conexion =
            "server=localhost;database=baseusuarios;user=root;password=123456;";

        public MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(conexion);
        }
    }
}
