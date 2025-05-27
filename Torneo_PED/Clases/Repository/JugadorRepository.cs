using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Torneo_PED.Clases.Modelo;

namespace Torneo_PED.Clases.Repository
{
    public class JugadorRepository : IDisposable
    {
        private readonly DatabaseConnection _dbConnection;
        private bool _disposed = false;

        public JugadorRepository()
        {
            _dbConnection = new DatabaseConnection();
        }

        public int AgregarJugador(string nombre, string apellido, int edad, string dui)
        {
            try
            {
                if (ExisteDUI(dui))
                    throw new Exception("Ya existe un jugador con este DUI");

                string query = @"INSERT INTO Jugadores (Nombre, Apellido, Edad, DUI) 
                         OUTPUT INSERTED.IdJugador 
                         VALUES (@Nombre, @Apellido, @Edad, @DUI)";

                var parameters = new[]
                {
            new SqlParameter("@Nombre", SqlDbType.NVarChar, 100) { Value = nombre },
            new SqlParameter("@Apellido", SqlDbType.NVarChar, 100) { Value = apellido },
            new SqlParameter("@Edad", SqlDbType.Int) { Value = edad },
            new SqlParameter("@DUI", SqlDbType.NVarChar, 10) { Value = dui }
        };

                object result = _dbConnection.ExecuteScalar(query, parameters);
                if (result == null || result == DBNull.Value)
                    throw new Exception("No se pudo obtener el ID del jugador insertado.");

                return Convert.ToInt32(result);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error de base de datos al agregar jugador", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar jugador", ex);
            }
        }

        public bool ExisteDUI(string dui)
        {
            try
            {
                string query = "SELECT COUNT(1) FROM Jugadores WHERE DUI = @DUI";
                var parameter = new SqlParameter("@DUI", SqlDbType.NVarChar, 10) { Value = dui };

                int count = (int)_dbConnection.ExecuteScalar(query, parameter);
                return count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar DUI", ex);
            }
        }

        public void EliminarJugador(int idJugador)
        {
            try
            {
                string query = "DELETE FROM Jugadores WHERE IdJugador = @IdJugador";
                var parameter = new SqlParameter("@IdJugador", SqlDbType.Int) { Value = idJugador };

                _dbConnection.ExecuteNonQuery(query, parameter);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error de base de datos al eliminar jugador", ex);
            }
        }

        public List<Jugador> ObtenerTodosJugadores()
        {
            try
            {
                var jugadores = new List<Jugador>();
                string query = "SELECT IdJugador, Nombre, Apellido, Edad, DUI, Puntuacion FROM Jugadores";

                using (DataTable dt = _dbConnection.ExecuteQuery(query))
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        jugadores.Add(new Jugador
                        {
                            IdJugador = Convert.ToInt32(row["IdJugador"]),
                            Nombre = row["Nombre"].ToString(),
                            Apellido = row["Apellido"].ToString(),
                            Edad = row["Edad"] != DBNull.Value ? Convert.ToInt32(row["Edad"]) : 0,
                            DUI = row["DUI"].ToString(),
                            Puntuacion = row["Puntuacion"] != DBNull.Value ? Convert.ToInt32(row["Puntuacion"]) : 0
                        });
                    }
                }
                return jugadores ?? new List<Jugador>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener jugadores", ex);
            }
        }

        public Jugador ObtenerJugadorPorDUI(string dui)
        {
            try
            {
                string query = @"SELECT IdJugador, Nombre, Apellido, Edad, DUI, Puntuacion 
                                FROM Jugadores WHERE DUI = @DUI";
                var parameter = new SqlParameter("@DUI", SqlDbType.NVarChar, 10) { Value = dui };

                using (DataTable dt = _dbConnection.ExecuteQuery(query, parameter))
                {
                    if (dt.Rows.Count == 0)
                        return null;

                    DataRow row = dt.Rows[0];
                    return new Jugador
                    {
                        IdJugador = Convert.ToInt32(row["IdJugador"]),
                        Nombre = row["Nombre"].ToString(),
                        Apellido = row["Apellido"].ToString(),
                        Edad = row["Edad"] != DBNull.Value ? Convert.ToInt32(row["Edad"]) : 0,
                        DUI = row["DUI"].ToString(),
                        Puntuacion = row["Puntuacion"] != DBNull.Value ? Convert.ToInt32(row["Puntuacion"]) : 0
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener jugador por DUI", ex);
            }
        }
        public void ActualizarJugador(Jugador jugador)
        {
            try
            {
                string query = @"UPDATE Jugadores 
                        SET Nombre = @Nombre, 
                            Apellido = @Apellido, 
                            Edad = @Edad, 
                            DUI = @DUI,
                            Puntuacion = @Puntuacion
                        WHERE IdJugador = @IdJugador";

                var parameters = new[]
                {
            new SqlParameter("@Nombre", SqlDbType.NVarChar, 100) { Value = jugador.Nombre },
            new SqlParameter("@Apellido", SqlDbType.NVarChar, 100) { Value = jugador.Apellido },
            new SqlParameter("@Edad", SqlDbType.Int) { Value = jugador.Edad },
            new SqlParameter("@DUI", SqlDbType.NVarChar, 10) { Value = jugador.DUI },
            new SqlParameter("@Puntuacion", SqlDbType.Int) { Value = jugador.Puntuacion },
            new SqlParameter("@IdJugador", SqlDbType.Int) { Value = jugador.IdJugador }
        };

                _dbConnection.ExecuteNonQuery(query, parameters);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error de base de datos al actualizar jugador", ex);
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
                    _dbConnection?.Dispose();
                }
                _disposed = true;
            }
        }

        ~JugadorRepository()
        {
            Dispose(false);
        }

    }
}
