using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torneo_PED.Clases
{
    public class JugadoresRepository
    {

        private readonly DatabaseConnection _dbConnection;

        public JugadoresRepository()
        {
            _dbConnection = new DatabaseConnection();
        }

        public void InsertarJugador(string nombre)
        {
            string query = "INSERT INTO Jugadores (Nombre) VALUES (@Nombre)";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Nombre", nombre)
            };

            _dbConnection.ExecuteNonQuery(query, parameters);
        }

        public List<string> ObtenerTodosJugadores()
        {
            string query = "SELECT Nombre FROM Jugadores ORDER BY Nombre";
            DataTable dt = _dbConnection.ExecuteQuery(query);

            return dt.AsEnumerable()
                    .Select(row => row.Field<string>("Nombre"))
                    .ToList();
        }
    }
}
