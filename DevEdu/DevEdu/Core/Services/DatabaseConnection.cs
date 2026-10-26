using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace DevEdu.Core.Services
{
    public abstract class DatabaseConnection : IDisposable
    {
        protected SqlConnection _connection;
        protected SqlCommand _command;
        protected bool _disposed = false;

        protected DatabaseConnection()
        {
            _connection = new SqlConnection(GetConnectionString());
        }

        protected DatabaseConnection(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        protected void OpenConn()
        {
            if (_connection == null)
                throw new InvalidOperationException("La conexión no ha sido inicializada.");

            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
        }

        protected async Task OpenConnAsync(CancellationToken cancellationToken = default)
        {
            if (_connection == null)
            {
                throw new InvalidOperationException(
                    "La conexión no ha sido inicializada.");
            }

            if (_connection.State == ConnectionState.Closed)
            {
                await _connection.OpenAsync(cancellationToken);
            }
        }

        protected void CloseConn()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
                _connection.Close();
        }

        private static string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .Build();

            string connStr = config.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connStr))
                throw new InvalidOperationException("No se encontró 'DefaultConnection' en appsettings.json.");

            return connStr;
        }

        public bool TestConnection()
        {
            try
            {
                OpenConn();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                CloseConn();
            }
        }

        public async Task<bool> TestConnectionAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await OpenConnAsync(cancellationToken);
                return true;
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch
            {
                return false;
            }
            finally
            {
                CloseConn();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _command?.Dispose();
                    CloseConn();
                    _connection?.Dispose();
                }
                _disposed = true;
            }
        }
    }
}