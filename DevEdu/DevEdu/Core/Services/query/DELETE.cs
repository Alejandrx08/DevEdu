using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace DevEdu.Core.Services.Query
{
    public class DELETE : DatabaseConnection
    {
        public DELETE() : base() { }
        public DELETE(string connectionString) : base(connectionString) { }

        public int ExecuteDelete(string query, SqlParameter[] parameters = null)
        {
            try
            {
                OpenConn();
                _command = new SqlCommand(query, _connection);
                _command.CommandType = CommandType.Text;

                if (parameters != null)
                    _command.Parameters.AddRange(parameters);

                int rowsAffected = _command.ExecuteNonQuery();

                if (rowsAffected == 0)
                    throw new Exception("El DELETE no eliminó ningún registro. Verifica que el ID exista.");

                return rowsAffected;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL al ejecutar DELETE: " + ex.Message, ex);
            }
            finally
            {
                CloseConn();
            }
        }
    }
}