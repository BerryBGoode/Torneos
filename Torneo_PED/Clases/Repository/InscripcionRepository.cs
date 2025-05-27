using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torneo_PED.Clases.Modelo;

namespace Torneo_PED.Clases.Repository
{
    public class InscripcionRepository : IDisposable
    {
        private readonly DatabaseConnection _dbConnection;
        private bool _disposed = false;

        public InscripcionRepository()
        {
            _dbConnection = new DatabaseConnection();
        }

        public void InscribirJugador(int idJugador, int idEstado)
        {
            if (_disposed)
                throw new ObjectDisposedException("InscripcionRepository");

            try
            {
                string query = @"INSERT INTO Inscripciones (IdJugador, IdEstado, FechaInscripcion) 
                                VALUES (@IdJugador, @IdEstado, GETDATE())";

                var parameters = new[]
                {
                    new SqlParameter("@IdJugador", SqlDbType.Int) { Value = idJugador },
                    new SqlParameter("@IdEstado", SqlDbType.Int) { Value = idEstado }
                };

                _dbConnection.ExecuteNonQuery(query, parameters);
            }
            catch (SqlException ex)
            {
                throw new RepositoryException("Error al inscribir jugador en la base de datos", ex);
            }
        }

        public void CambiarEstadoInscripcion(int idInscripcion, int nuevoEstado)
        {
            if (_disposed)
                throw new ObjectDisposedException("InscripcionRepository");

            try
            {
                string query = @"UPDATE Inscripciones 
                               SET IdEstado = @IdEstado 
                               WHERE IdInscripcion = @IdInscripcion";

                var parameters = new[]
                {
                    new SqlParameter("@IdEstado", SqlDbType.Int) { Value = nuevoEstado },
                    new SqlParameter("@IdInscripcion", SqlDbType.Int) { Value = idInscripcion }
                };

                _dbConnection.ExecuteNonQuery(query, parameters);
            }
            catch (SqlException ex)
            {
                throw new RepositoryException("Error al cambiar estado de inscripción", ex);
            }
        }

        public List<Jugador> ObtenerJugadoresConfirmados()
        {
            return ObtenerJugadoresPorEstado(3); // Estado 3 = Confirmado
        }

        public List<Jugador> ObtenerJugadoresEnEspera()
        {
            return ObtenerJugadoresPorEstado(2); // Estado 2 = En espera
        }

        public List<Jugador> ObtenerJugadoresPorEstado(int idEstado)
        {
            if (_disposed)
                throw new ObjectDisposedException("InscripcionRepository");

            try
            {
                var jugadores = new List<Jugador>();
                string query = @"SELECT j.IdJugador, j.Nombre, j.Apellido, j.Edad, j.DUI, j.Puntuacion  
                        FROM Jugadores j
                        JOIN Inscripciones i ON j.IdJugador = i.IdJugador
                        WHERE i.IdEstado = @IdEstado
                        ORDER BY i.FechaInscripcion";

                var parameter = new SqlParameter("@IdEstado", SqlDbType.Int) { Value = idEstado };

                using (var dt = _dbConnection.ExecuteQuery(query, parameter))
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
                return jugadores;
            }
            catch (SqlException ex)
            {
                throw new RepositoryException("Error al obtener jugadores por estado", ex);
            }
        }

        public Inscripcion ObtenerInscripcionPorJugador(int idJugador)
        {
            if (_disposed)
                throw new ObjectDisposedException("InscripcionRepository");

            try
            {
                string query = @"SELECT TOP 1 IdInscripcion, IdJugador, IdEstado, FechaInscripcion
                               FROM Inscripciones
                               WHERE IdJugador = @IdJugador
                               ORDER BY FechaInscripcion DESC";

                var parameter = new SqlParameter("@IdJugador", SqlDbType.Int) { Value = idJugador };

                using (var dt = _dbConnection.ExecuteQuery(query, parameter))
                {
                    if (dt.Rows.Count == 0)
                        return null;

                    var row = dt.Rows[0];
                    return new Inscripcion
                    {
                        IdInscripcion = Convert.ToInt32(row["IdInscripcion"]),
                        IdJugador = Convert.ToInt32(row["IdJugador"]),
                        IdEstado = Convert.ToInt32(row["IdEstado"]),
                        FechaInscripcion = Convert.ToDateTime(row["FechaInscripcion"])
                    };
                }
            }
            catch (SqlException ex)
            {
                throw new RepositoryException("Error al obtener inscripción por jugador", ex);
            }
        }

        public void EliminarInscripcion(int idJugador)
        {
            if (_disposed)
                throw new ObjectDisposedException("InscripcionRepository");

            try
            {
                string query = "DELETE FROM Inscripciones WHERE IdJugador = @IdJugador";
                var parameter = new SqlParameter("@IdJugador", SqlDbType.Int) { Value = idJugador };

                _dbConnection.ExecuteNonQuery(query, parameter);
            }
            catch (SqlException ex)
            {
                throw new RepositoryException("Error al eliminar inscripción", ex);
            }
        }

        public void LimpiarTodasLasInscripciones()
        {
            if (_disposed)
                throw new ObjectDisposedException("InscripcionRepository");

            try
            {
                string query = "DELETE FROM Inscripciones";
                _dbConnection.ExecuteNonQuery(query);
            }
            catch (SqlException ex)
            {
                throw new RepositoryException("Error al limpiar todas las inscripciones", ex);
            }
        }

        // Añade estos métodos al InscripcionRepository
        public List<Estado> ObtenerTodosEstados()
        {
            try
            {
                var estados = new List<Estado>();
                string query = "SELECT IdEstado, Estado AS NombreEstado FROM Estados";

                using (DataTable dt = _dbConnection.ExecuteQuery(query))
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        estados.Add(new Estado
                        {
                            IdEstado = Convert.ToInt32(row["IdEstado"]),
                            NombreEstado = row["NombreEstado"].ToString()
                        });
                    }
                }
                return estados;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error al obtener estados", ex);
            }
        }

        public class Estado
        {
            public int IdEstado { get; set; }
            public string NombreEstado { get; set; }
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

        ~InscripcionRepository()
        {
            Dispose(false);
        }
    }

    public class RepositoryException : Exception
    {
        public RepositoryException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
