using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace DevEdu.Core.Services.Query
{
    public class UPDATE : DatabaseConnection
    {
        public UPDATE() : base() { }
        public UPDATE(string connectionString) : base(connectionString) { }

        public int ExecuteUpdate(string query, SqlParameter[] parameters = null)
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
                    throw new Exception("El UPDATE no afectó ningún registro. Verifica que el ID exista.");

                return rowsAffected;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL al ejecutar UPDATE: " + ex.Message, ex);
            }
            finally
            {
                CloseConn();
            }
        }

        public async Task<int> ExecuteUpdateAsync(
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

                int rowsAffected =
                    await command.ExecuteNonQueryAsync(cancellationToken);

                if (rowsAffected == 0)
                {
                    throw new Exception(
                        "El UPDATE no afectó ningún registro. " +
                        "Verifica que el ID exista.");
                }

                return rowsAffected;
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (SqlException ex)
            {
                throw new Exception(
                    "Error SQL al ejecutar UPDATE: " + ex.Message,
                    ex);
            }
            finally
            {
                CloseConn();
            }
        }
    }
}