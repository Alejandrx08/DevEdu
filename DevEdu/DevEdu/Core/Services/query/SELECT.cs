using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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

        public async Task<DataTable> ExecuteSelectAsync(
            string query,
            SqlParameter[] parameters = null,
            CancellationToken cancellationToken = default)
        {
            DataTable result = new DataTable();

            try
            {
                await OpenConnAsync(cancellationToken);

                using var command = new SqlCommand(query, _connection);
                command.CommandType = CommandType.Text;

                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                using SqlDataReader reader =
                    await command.ExecuteReaderAsync(cancellationToken);

                var columnNames = new HashSet<string>(
                    StringComparer.OrdinalIgnoreCase);

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string columnName = reader.GetName(i);

                    if (!columnNames.Add(columnName))
                    {
                        string baseName = columnName;
                        int suffix = 1;

                        do
                        {
                            columnName = $"{baseName}_{suffix++}";
                        }
                        while (!columnNames.Add(columnName));
                    }

                    result.Columns.Add(
                        columnName,
                        reader.GetFieldType(i));
                }

                while (await reader.ReadAsync(cancellationToken))
                {
                    object[] values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    result.Rows.Add(values);
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (SqlException ex)
            {
                throw new Exception(
                    "Error SQL al ejecutar SELECT: " + ex.Message,
                    ex);
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

        public async Task<object> ExecuteScalarAsync(
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

                return await command.ExecuteScalarAsync(cancellationToken);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (SqlException ex)
            {
                throw new Exception(
                    "Error SQL al ejecutar Scalar: " + ex.Message,
                    ex);
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

        public async Task<DataTable> ExecuteStoredProcedureAsync(
            string storedProcedure,
            SqlParameter[] parameters = null,
            CancellationToken cancellationToken = default)
        {
            DataTable result = new DataTable();

            try
            {
                await OpenConnAsync(cancellationToken);

                using var command = new SqlCommand(
                    storedProcedure,
                    _connection);

                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                using SqlDataReader reader =
                    await command.ExecuteReaderAsync(cancellationToken);

                var columnNames = new HashSet<string>(
                    StringComparer.OrdinalIgnoreCase);

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string columnName = reader.GetName(i);

                    if (!columnNames.Add(columnName))
                    {
                        string baseName = columnName;
                        int suffix = 1;

                        do
                        {
                            columnName = $"{baseName}_{suffix++}";
                        }
                        while (!columnNames.Add(columnName));
                    }

                    result.Columns.Add(
                        columnName,
                        reader.GetFieldType(i));
                }

                while (await reader.ReadAsync(cancellationToken))
                {
                    object[] values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    result.Rows.Add(values);
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (SqlException ex)
            {
                throw new Exception(
                    $"Error SQL al ejecutar SP '{storedProcedure}': {ex.Message}",
                    ex);
            }
            finally
            {
                CloseConn();
            }

            return result;
        }
    }
}