using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torneo_PED.Clases
{
    public class InscripcionesRepository
    {
        private readonly DatabaseConnection _dbConnection;

        public InscripcionesRepository()
        {
            _dbConnection = new DatabaseConnection();
        }

        public void RegistrarInscripcion(string nombreJugador, int estado)
        {
            // Solo permitir estados 1 (Confirmado) o 2 (En espera)
            if (estado != 1 && estado != 2)
                throw new ArgumentException("Estado debe ser 1 (Confirmado) o 2 (En espera)");

            string query = @"INSERT INTO Inscripciones (IdJugador, IdEstado)
                         SELECT IdJugador, @Estado 
                         FROM Jugadores 
                         WHERE Nombre = @Nombre";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Nombre", nombreJugador),
            new SqlParameter("@Estado", estado)
            };

            _dbConnection.ExecuteNonQuery(query, parameters);
        }

        public List<string> ObtenerJugadoresConfirmados()
        {
            string query = @"SELECT j.Nombre 
                        FROM Inscripciones i
                        JOIN Jugadores j ON i.IdJugador = j.IdJugador
                        WHERE i.IdEstado = 1 -- Confirmados
                        ORDER BY i.FechaInscripcion";

            DataTable dt = _dbConnection.ExecuteQuery(query);
            return dt.AsEnumerable()
                    .Select(row => row.Field<string>("Nombre"))
                    .ToList();
        }

        public List<string> ObtenerJugadoresEnEspera()
        {
            string query = @"SELECT j.Nombre 
                        FROM Inscripciones i
                        JOIN Jugadores j ON i.IdJugador = j.IdJugador
                        WHERE i.IdEstado = 2 -- En espera
                        ORDER BY i.FechaInscripcion";

            DataTable dt = _dbConnection.ExecuteQuery(query);
            return dt.AsEnumerable()
                    .Select(row => row.Field<string>("Nombre"))
                    .ToList();
        }

        public bool ExisteInscripcion(string nombreJugador)
        {
            string query = @"SELECT COUNT(*) 
                        FROM Inscripciones i
                        JOIN Jugadores j ON i.IdJugador = j.IdJugador
                        WHERE j.Nombre = @Nombre";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Nombre", nombreJugador)
            };

            int count = Convert.ToInt32(_dbConnection.ExecuteScalar(query, parameters));
            return count > 0;
        }

        public List<string> ObtenerInscripcionesPorEstado(int estado)
        {
            string query = @"SELECT j.Nombre 
                        FROM Inscripciones i
                        INNER JOIN Jugadores j ON i.IdJugador = j.IdJugador
                        WHERE i.IdEstado = @Estado
                        ORDER BY i.FechaInscripcion";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Estado", estado)
            };

            try
            {
                DataTable result = _dbConnection.ExecuteQuery(query, parameters);
                return result.AsEnumerable()
                           .Select(row => row.Field<string>("Nombre"))
                           .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener inscripciones por estado: {ex.Message}", ex);
            }
        }
    }
}
