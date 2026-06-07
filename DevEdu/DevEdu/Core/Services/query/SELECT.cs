using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace DevEdu.Core.Services.Query
{
    public class SELECT : DatabaseConnection
    {
        public SELECT() : base() { }
        public SELECT(string connectionString) : base(connectionString) { }

        public DataTable ExecuteSelect(string query, SqlParameter[] parameters = null)
        {
            DataTable result = new DataTable();
            try
            {
                OpenConn();
                _command = new SqlCommand(query, _connection);
                _command.CommandType = CommandType.Text;

                if (parameters != null)
                    _command.Parameters.AddRange(parameters);

                using (SqlDataAdapter adapter = new SqlDataAdapter(_command))
                    adapter.Fill(result);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL al ejecutar SELECT: " + ex.Message, ex);
            }
            finally
            {
                CloseConn();
            }
            return result;
        }

        public object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            try
            {
                OpenConn();
                _command = new SqlCommand(query, _connection);
                _command.CommandType = CommandType.Text;

                if (parameters != null)
                    _command.Parameters.AddRange(parameters);

                return _command.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL al ejecutar Scalar: " + ex.Message, ex);
            }
            finally
            {
                CloseConn();
            }
        }

        public DataTable ExecuteStoredProcedure(string storedProcedure, SqlParameter[] parameters = null)
        {
            DataTable result = new DataTable();
            try
            {
                OpenConn();
                _command = new SqlCommand(storedProcedure, _connection);
                _command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                    _command.Parameters.AddRange(parameters);

                using (SqlDataAdapter adapter = new SqlDataAdapter(_command))
                    adapter.Fill(result);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL al ejecutar SP '" + storedProcedure + "': " + ex.Message, ex);
            }
            finally
            {
                CloseConn();
            }
            return result;
        }
    }
}