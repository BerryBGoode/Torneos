using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torneo_PED.Clases
{
    public class GestorInscripciones
    {

        private readonly Cola<string> _colaPrincipal;
        private readonly Cola<string> _colaEspera;
        private readonly InscripcionesRepository _inscripcionesRepo;
        private readonly int _cupoMaximo;

        public GestorInscripciones(int cupoMaximo)
        {
            _cupoMaximo = cupoMaximo;
            _colaPrincipal = new Cola<string>(cupoMaximo);
            _colaEspera = new Cola<string>();
            _inscripcionesRepo = new InscripcionesRepository();

            CargarInscripcionesExistentes(); // Llamada al cargar el gestor
        }

        private void CargarInscripcionesExistentes()
        {
            try
            {
                // Cargar jugadores confirmados (estado 1)
                var confirmados = _inscripcionesRepo.ObtenerInscripcionesPorEstado(1);
                foreach (var nombre in confirmados)
                {
                    if (_colaPrincipal.Count < _cupoMaximo)
                    {
                        _colaPrincipal.Encolar(nombre);
                    }
                    else
                    {
                        // Esto no debería pasar, pero por si hay inconsistencia en la BD
                        _colaEspera.Encolar(nombre);
                    }
                }

                // Cargar jugadores en espera (estado 2)
                var enEspera = _inscripcionesRepo.ObtenerInscripcionesPorEstado(2);
                foreach (var nombre in enEspera)
                {
                    _colaEspera.Encolar(nombre);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cargar inscripciones existentes: {ex.Message}", ex);
            }
        }

        public void InscribirJugador(string nombreJugador)
        {
            try
            {
                // Verificar si el jugador ya está inscrito
                if (_colaPrincipal.Contiene(nombreJugador) || _colaEspera.Contiene(nombreJugador))
                {
                    throw new Exception("El jugador ya está inscrito");
                }

                // Insertar el jugador si no existe
                var jugadoresRepo = new JugadoresRepository();
                jugadoresRepo.InsertarJugador(nombreJugador);

                // Asignar estado según cupo disponible
                if (_colaPrincipal.Count < _cupoMaximo)
                {
                    _colaPrincipal.Encolar(nombreJugador);
                    _inscripcionesRepo.RegistrarInscripcion(nombreJugador, 1); // 1 = Confirmado
                }
                else
                {
                    _colaEspera.Encolar(nombreJugador);
                    _inscripcionesRepo.RegistrarInscripcion(nombreJugador, 2); // 2 = En espera
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al inscribir jugador: {ex.Message}", ex);
            }
        }

        public List<string> ObtenerJugadoresRegistrados() => _colaPrincipal.ObtenerElementos();
        public List<string> ObtenerJugadoresEnEspera() => _colaEspera.ObtenerElementos();
    }
}
