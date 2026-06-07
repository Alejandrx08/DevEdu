using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Data.SqlClient;
using System.Data;

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