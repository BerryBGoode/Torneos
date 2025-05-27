using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torneo_PED.Clases.Modelo;
using Torneo_PED.Clases.Repository;

namespace Torneo_PED.Clases.Controlador
{
    public class JugadorController
    {
        private readonly JugadorRepository _jugadorRepo;
        private readonly InscripcionRepository _inscripcionRepo;
        private readonly Cola<Jugador> _colaEspera;
        private readonly int _cupoMaximo;

        public JugadorController(int cupoMaximo = 8)
        {
            _jugadorRepo = new JugadorRepository();
            _inscripcionRepo = new InscripcionRepository();
            _colaEspera = new Cola<Jugador>(cupoMaximo * 2); // Capacidad doble como buffer
            _cupoMaximo = cupoMaximo;
        }

        public void InscribirJugador(string nombre, string apellido, int edad, string dui)
        {
            if (edad <= 18)
                throw new Exception("La edad debe ser mayor a 18 años");

            if (!System.Text.RegularExpressions.Regex.IsMatch(dui, @"^\d{8}-\d{1}$"))
                throw new Exception("Formato de DUI inválido. Debe ser 12345678-9");

            if (_jugadorRepo.ExisteDUI(dui))
                throw new Exception("Ya existe un jugador con este DUI");

            int idJugador = _jugadorRepo.AgregarJugador(nombre, apellido, edad, dui);
            if (idJugador <= 0)
                throw new Exception("No se pudo registrar el jugador");

            var jugador = new Jugador
            {
                IdJugador = idJugador,
                Nombre = nombre,
                Apellido = apellido,
                Edad = edad,
                DUI = dui
            };

            var confirmados = _inscripcionRepo.ObtenerJugadoresConfirmados() ?? new List<Jugador>();
            if (confirmados.Count < _cupoMaximo)
            {
                _inscripcionRepo.InscribirJugador(idJugador, 3);
            }
            else
            {
                _inscripcionRepo.InscribirJugador(idJugador, 2);
                _colaEspera.Encolar(jugador);
            }
        }


        public void EliminarJugador(string nombre)
        {
            var jugadores = _jugadorRepo.ObtenerTodosJugadores();
            var jugador = jugadores.Find(j => j.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (jugador == null)
            {
                throw new Exception("Jugador no encontrado");
            }

            // Eliminar inscripción primero (por la relación de clave foránea)
            _inscripcionRepo.EliminarInscripcion(jugador.IdJugador);

            // Eliminar jugador
            _jugadorRepo.EliminarJugador(jugador.IdJugador);

            // Si había espacio, mover el primero de la cola de espera a confirmados
            var confirmados = _inscripcionRepo.ObtenerJugadoresConfirmados();
            if (confirmados.Count < _cupoMaximo && !_colaEspera.EstaVacia)
            {
                var siguienteJugador = _colaEspera.Desencolar();
                var inscripciones = ObtenerInscripcionesPorJugador(siguienteJugador.IdJugador);
                foreach (var insc in inscripciones)
                {
                    _inscripcionRepo.CambiarEstadoInscripcion(insc.IdInscripcion, 3); // Confirmado
                }
            }
        }

        public List<Jugador> ObtenerJugadoresConfirmados()
        {
            return _inscripcionRepo.ObtenerJugadoresConfirmados() ?? new List<Jugador>();
        }

        public List<Jugador> ObtenerJugadoresEnEspera()
        {
            return _inscripcionRepo.ObtenerJugadoresEnEspera() ?? new List<Jugador>();
        }

        public bool TorneoPuedeIniciar()
        {
            return ObtenerJugadoresConfirmados().Count == _cupoMaximo;
        }

        public void LimpiarInscripciones()
        {
            // Implementación para limpiar todas las inscripciones
            // (esto requeriría un método adicional en el repositorio)
        }

        private List<Inscripcion> ObtenerInscripcionesPorJugador(int idJugador)
        {
            // Implementación para obtener todas las inscripciones de un jugador
            // (esto requeriría un método adicional en el repositorio)
            return new List<Inscripcion>();
        }

        public Jugador ObtenerJugadorPorId(int idJugador)
        {
            return _jugadorRepo.ObtenerTodosJugadores()
                .FirstOrDefault(j => j.IdJugador == idJugador);
        }

        public void ActualizarJugador(Jugador jugador)
        {
            try
            {
                // Necesitarás implementar este método en JugadorRepository
                _jugadorRepo.ActualizarJugador(jugador);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar jugador", ex);
            }
        }

        public Dictionary<int, string> ObtenerEstadosInscripcion()
        {
            return _inscripcionRepo.ObtenerTodosEstados()
                .ToDictionary(e => e.IdEstado, e => e.NombreEstado);
        }

        public List<Jugador> ObtenerTodosJugadores()
        {
            return _jugadorRepo.ObtenerTodosJugadores();
        }

        public List<Jugador> ObtenerJugadoresConfirmadosOrdenadosPorPuntuacion()
        {
            return _inscripcionRepo.ObtenerJugadoresConfirmados()
                .OrderByDescending(j => j.Puntuacion)
                .ToList();
        }

        public void ActualizarPuntuacion(Jugador jugador)
        {
            try
            {
                _jugadorRepo.ActualizarJugador(jugador);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar puntuación", ex);
            }
        }
    }
}
