using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torneo_PED.Clases.Modelo;

namespace Torneo_PED.Clases
{
    public class ArbolTorneo
    {

        public NodoTorneo Raiz { get; set; }
        private readonly Random _random = new Random();

        public void ConstruirArbol(List<Jugador> participantes)
        {
            if (participantes == null || participantes.Count == 0)
                throw new ArgumentException("La lista de participantes no puede estar vacía");

            Raiz = ConstruirSubarbol(participantes.OrderBy(x => _random.Next()).ToList(), 0);
        }

        private NodoTorneo ConstruirSubarbol(List<Jugador> participantes, int nivel)
        {
            if (participantes.Count == 1)
            {
                return new NodoTorneo
                {
                    Partido = new Partido { Jugador1 = participantes[0] }
                };
            }

            int mitad = participantes.Count / 2;
            var izquierda = participantes.Take(mitad).ToList();
            var derecha = participantes.Skip(mitad).Take(mitad).ToList();

            var nodo = new NodoTorneo
            {
                Partido = new Partido(),
                Izquierdo = ConstruirSubarbol(izquierda, nivel + 1),
                Derecho = ConstruirSubarbol(derecha, nivel + 1)
            };

            // Asignar jugadores al partido actual basado en los ganadores de los subárboles
            nodo.Partido.Jugador1 = ObtenerGanadorSubarbol(nodo.Izquierdo);
            nodo.Partido.Jugador2 = ObtenerGanadorSubarbol(nodo.Derecho);

            return nodo;
        }

        private Jugador ObtenerGanadorSubarbol(NodoTorneo nodo)
        {
            if (nodo == null) return null;
            return nodo.Partido?.Ganador ?? (nodo.Partido?.Jugador1 ?? null);
        }

        public int ObtenerAltura()
        {
            return ObtenerAlturaNodo(Raiz);
        }

        private int ObtenerAlturaNodo(NodoTorneo nodo)
        {
            if (nodo == null) return 0;
            return 1 + Math.Max(ObtenerAlturaNodo(nodo.Izquierdo), ObtenerAlturaNodo(nodo.Derecho));
        }

        public int ObtenerNivelPartido(Partido partido)
        {
            return ObtenerNivelPartido(Raiz, partido, 0);
        }

        private int ObtenerNivelPartido(NodoTorneo nodo, Partido partido, int nivelActual)
        {
            if (nodo == null) return -1;
            if (nodo.Partido == partido) return nivelActual;

            int nivelIzq = ObtenerNivelPartido(nodo.Izquierdo, partido, nivelActual + 1);
            if (nivelIzq != -1) return nivelIzq;

            return ObtenerNivelPartido(nodo.Derecho, partido, nivelActual + 1);
        }

        public List<Partido> ObtenerPartidosSinGanador()
        {
            var partidos = new List<Partido>();
            ObtenerPartidosSinGanador(Raiz, partidos);
            return partidos.Where(p => p.Ganador == null && (p.Jugador1 != null || p.Jugador2 != null)).ToList();
        }

        private void ObtenerPartidosSinGanador(NodoTorneo nodo, List<Partido> partidos)
        {
            if (nodo == null) return;

            if (nodo.Partido != null)
            {
                partidos.Add(nodo.Partido);
            }

            ObtenerPartidosSinGanador(nodo.Izquierdo, partidos);
            ObtenerPartidosSinGanador(nodo.Derecho, partidos);
        }

        public List<Partido> ObtenerTodosPartidos()
        {
            var partidos = new List<Partido>();
            ObtenerTodosPartidos(Raiz, partidos);
            return partidos;
        }

        private void ObtenerTodosPartidos(NodoTorneo nodo, List<Partido> partidos)
        {
            if (nodo == null) return;

            if (nodo.Partido != null)
            {
                partidos.Add(nodo.Partido);
            }

            ObtenerTodosPartidos(nodo.Izquierdo, partidos);
            ObtenerTodosPartidos(nodo.Derecho, partidos);
        }

        public Jugador ObtenerCampeon()
        {
            return Raiz?.Partido?.Ganador;
        }
    }

    public class NodoTorneo
    {
        public Partido Partido { get; set; }
        public NodoTorneo Izquierdo { get; set; }
        public NodoTorneo Derecho { get; set; }
    }

    public class Partido
    {
        public Jugador Jugador1 { get; set; }
        public Jugador Jugador2 { get; set; }
        public Jugador Ganador { get; set; }

        public override string ToString()
        {
            return $"{Jugador1?.Nombre ?? "Bye"} vs {Jugador2?.Nombre ?? "Bye"} -> Ganador: {Ganador?.Nombre ?? "Por definir"}";
        }
    }
}
