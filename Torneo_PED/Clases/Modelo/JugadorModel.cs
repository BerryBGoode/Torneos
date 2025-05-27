using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torneo_PED.Clases.Modelo
{
    public class Jugador
    {
        public int IdJugador { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string DUI { get; set; }
        public int Puntuacion { get; set; }

        public override string ToString()
        {
            return $"{Nombre} {Apellido}";
        }
    }

    public class Inscripcion
    {
        public int IdInscripcion { get; set; }
        public int IdJugador { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public int IdEstado { get; set; }
    }

    public class Estado
    {
        public int IdEstado { get; set; }
        public string NombreEstado { get; set; }
    }
}
