using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace DevEdu.Core.Services.Query
{
    public class INSERT : DatabaseConnection
    {
        public INSERT() : base() { }
        public INSERT(string connectionString) : base(connectionString) { }

        public int ExecuteInsert(string query, SqlParameter[] parameters = null)
        {
            try
            {
                OpenConn();
                _command = new SqlCommand(query, _connection);
                _command.CommandType = CommandType.Text;

                if (parameters != null)
                    _command.Parameters.AddRange(parameters);

                return _command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL al ejecutar INSERT: " + ex.Message, ex);
            }
            finally
            {
                CloseConn();
            }
        }

        public int ExecuteInsertReturnId(string query, SqlParameter[] parameters = null)
        {
            string queryWithId = query.TrimEnd().TrimEnd(';') + "; SELECT SCOPE_IDENTITY();";
            try
            {
                OpenConn();
                _command = new SqlCommand(queryWithId, _connection);
                _command.CommandType = CommandType.Text;

                if (parameters != null)
                    _command.Parameters.AddRange(parameters);

                object result = _command.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL al ejecutar INSERT con ID: " + ex.Message, ex);
            }
            finally
            {
                CloseConn();
            }
        }
    }
}