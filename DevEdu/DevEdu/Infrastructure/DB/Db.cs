using DevEdu.Infraestructure.DB;
using MySql.Data.MySqlClient;

namespace DevEdu.Infrastructure.Db
{
    public static class Db
    {
        public static MySqlConnection CreateConnection()
        {
            return new MySqlConnection(DbConfig.ConnectionString);
        }
    }
}


