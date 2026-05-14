using System;
using System.Data.SqlClient;

namespace PryBarreraSP1ER
{
    public class clsConexion : IDisposable
    {
        private readonly string _connectionString;
        private SqlConnection _conexion;
        private bool _disposed = false;

        public clsConexion(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("El string de conexión no puede estar vacío.", nameof(connectionString));

            _connectionString = connectionString;
        }

        public SqlConnection ObtenerConexion()
        {
            if (_conexion == null)
                _conexion = new SqlConnection(_connectionString);

            if (_conexion.State == System.Data.ConnectionState.Closed)
                _conexion.Open();

            return _conexion;
        }

        public void CerrarConexion()
        {
            if (_conexion != null && _conexion.State == System.Data.ConnectionState.Open)
                _conexion.Close();
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
                    CerrarConexion();
                    _conexion?.Dispose();
                }
                _disposed = true;
            }
        }
    }
}