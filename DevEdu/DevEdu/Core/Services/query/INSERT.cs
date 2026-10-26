using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

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

        public async Task<int> ExecuteInsertAsync(
            string query,
            SqlParameter[] parameters = null,
            CancellationToken cancellationToken = default)
        {
            try
            {
                await OpenConnAsync(cancellationToken);

                using var command = new SqlCommand(query, _connection);
                command.CommandType = CommandType.Text;

                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                return await command.ExecuteNonQueryAsync(cancellationToken);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (SqlException ex)
            {
                throw new Exception(
                    "Error SQL al ejecutar INSERT: " + ex.Message,
                    ex);
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

        public async Task<int> ExecuteInsertReturnIdAsync(
            string query,
            SqlParameter[] parameters = null,
            CancellationToken cancellationToken = default)
        {
            string queryWithId =
                query.TrimEnd().TrimEnd(';') + "; SELECT SCOPE_IDENTITY();";

            try
            {
                await OpenConnAsync(cancellationToken);

                using var command = new SqlCommand(queryWithId, _connection);
                command.CommandType = CommandType.Text;

                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                object result =
                    await command.ExecuteScalarAsync(cancellationToken);

                return result != null && result != DBNull.Value
                    ? Convert.ToInt32(result)
                    : -1;
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (SqlException ex)
            {
                throw new Exception(
                    "Error SQL al ejecutar INSERT con ID: " + ex.Message,
                    ex);
            }
            finally
            {
                CloseConn();
            }
        }
    }
}