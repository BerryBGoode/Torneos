using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torneo_PED.Clases
{
    public class DatabaseConnection
    {
        private SqlConnection _connection;

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
    
    public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
    {
        DataTable dataTable = new DataTable();
        
        try
        {
            Open();
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
            }
            return dataTable;
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
    
    public int ExecuteNonQuery(string commandText, SqlParameter[] parameters = null)
    {
        try
        {
            Open();
            using (SqlCommand command = new SqlCommand(commandText, _connection))
            {
                if (parameters != null)
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
    
    public object ExecuteScalar(string commandText, SqlParameter[] parameters = null)
    {
        try
        {
            Open();
            using (SqlCommand command = new SqlCommand(commandText, _connection))
            {
                if (parameters != null)
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
        if (_connection != null)
        {
            Close();
            _connection.Dispose();
        }
    }
    }
}
