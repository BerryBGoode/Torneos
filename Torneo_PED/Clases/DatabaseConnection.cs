using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torneo_PED.Clases
{
    public class DatabaseConnection : IDisposable
    {
        private readonly SqlConnection _connection;

        public DatabaseConnection()
        {
            _connection = new SqlConnection(DatabaseConfig.ConnectionString);
        }

        public void Open()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
        }

        public void Close()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
        }

        public DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            try
            {
                Open();
                using (var command = new SqlCommand(query, _connection))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error en ExecuteQuery: {ex.Message}", ex);
            }
            finally
            {
                Close();
            }
        }

        public int ExecuteNonQuery(string commandText, params SqlParameter[] parameters)
        {
            try
            {
                Open();
                using (var command = new SqlCommand(commandText, _connection))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    return command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error en ExecuteNonQuery: {ex.Message}", ex);
            }
            finally
            {
                Close();
            }
        }

        public object ExecuteScalar(string commandText, params SqlParameter[] parameters)
        {
            try
            {
                Open();
                using (var command = new SqlCommand(commandText, _connection))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    return command.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error en ExecuteScalar: {ex.Message}", ex);
            }
            finally
            {
                Close();
            }
        }

        public void Dispose()
        {
            Close();
            _connection?.Dispose();
        }
    }
}
