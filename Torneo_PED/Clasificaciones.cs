using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Torneo_PED.Clases;
using Torneo_PED.Clases.Controlador;
using Torneo_PED.Clases.Modelo;
using Torneo_PED.Clases.Repository;

namespace Torneo_PED
{
    public partial class Clasificaciones : Form
    {
        private readonly JugadorController _jugadorController;
        private readonly InscripcionRepository _inscripcionRepo;
        private List<Jugador> _participantes;
        private ArbolTorneo _arbolTorneo;
        private Random _random;
        private const int PUNTOS_VICTORIA = 2;

        public Clasificaciones()
        {
            InitializeComponent();

            _jugadorController = new JugadorController();
            _inscripcionRepo = new InscripcionRepository();
            _random = new Random();

            ConfigurarInterfaz();
            CargarParticipantes();
        }
        private void ConfigurarInterfaz()
        {
            this.Text = "Torneo de Eliminación Directa";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Configuración de botones (asegúrate de que existen en el diseñador)
            BtnIniciarTorneo.Click += BtnIniciarTorneo_Click;
            BtnDibujarArbol.Click += BtnDibujarArbol_Click;
            btnSimularRonda.Click += btnSimularRonda_Click;

            panelArbol.AutoScroll = true;
            panelArbol.Paint += panelArbol_Paint; // Nuevo evento para dibujar líneas
        }

        private void CargarParticipantes()
        {
            _participantes = _jugadorController.ObtenerJugadoresConfirmados();
            lblParticipantes.Text = $"Jugadores Confirmados: {_participantes.Count}";
        }

        private void BtnIniciarTorneo_Click(object sender, EventArgs e)
        {
            if (_participantes.Count < 2)
            {
                MessageBox.Show("Se necesitan al menos 2 participantes para iniciar el torneo",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!EsPotenciaDeDos(_participantes.Count))
            {
                MessageBox.Show("El número de participantes debe ser potencia de 2 (2, 4, 8, 16...)",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IniciarTorneo();
        }

        private void BtnDibujarArbol_Click(object sender, EventArgs e)
        {
            if (_arbolTorneo == null)
            {
                MessageBox.Show("Primero debe iniciar el torneo", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DibujarArbol();
        }

        private bool EsPotenciaDeDos(int numero)
        {
            return (numero & (numero - 1)) == 0;
        }

        private void IniciarTorneo()
        {
            _arbolTorneo = new ArbolTorneo();
            var participantesMezclados = _participantes.OrderBy(x => _random.Next()).ToList();
            _arbolTorneo.ConstruirArbol(participantesMezclados);

            // Eliminado el MessageBox duplicado
            DibujarArbol();
        }

        private void DibujarArbol()
        {
            panelArbol.Controls.Clear();
            panelArbol.Invalidate(); // Forzar redibujado de las líneas

            int anchoPanel = panelArbol.Width;
            int nivelMaximo = _arbolTorneo.ObtenerAltura();
            int espacioVertical = 100; // Aumentado para más espacio
            int espacioHorizontal = 100; // Aumentado para más espacio

            DibujarNodo(_arbolTorneo.Raiz, anchoPanel / 2, 30, anchoPanel / 4, espacioVertical,
                       nivelMaximo, espacioHorizontal);
        }

        private void DibujarLineasArbol(Graphics g)
        {
            if (_arbolTorneo?.Raiz == null) return;

            int anchoPanel = panelArbol.Width;
            int nivelMaximo = _arbolTorneo.ObtenerAltura();
            int espacioVertical = 100;
            int espacioHorizontal = 100;

            DibujarLineasNodo(g, _arbolTorneo.Raiz, anchoPanel / 2, 30, anchoPanel / 4,
                            espacioVertical, nivelMaximo, espacioHorizontal);
        }

        private void DibujarLineasNodo(Graphics g, NodoTorneo nodo, int x, int y, int offsetX,
                                    int offsetY, int nivelMaximo, int espacioHorizontal)
        {
            if (nodo == null) return;

            if (nodo.Izquierdo.Partido.Jugador1 == null || 
                nodo.Izquierdo.Partido.Jugador2 == null ||
                nodo.Derecho.Partido.Jugador1 == null ||
                nodo.Derecho.Partido.Jugador1 == null
                )
                return;
            // Dibujar líneas conectivas
            if (nodo.Izquierdo != null)
            {
                g.DrawLine(Pens.Black, x, y + 60, x - offsetX, y + offsetY);
                DibujarLineasNodo(g, nodo.Izquierdo, x - offsetX, y + offsetY, offsetX / 2,
                                offsetY, nivelMaximo, espacioHorizontal);
            }

            if (nodo.Derecho != null)
            {
                g.DrawLine(Pens.Black, x, y + 60, x + offsetX, y + offsetY);
                DibujarLineasNodo(g, nodo.Derecho, x + offsetX, y + offsetY, offsetX / 2,
                                offsetY, nivelMaximo, espacioHorizontal);
            }
        }

        private void DibujarNodo(NodoTorneo nodo, int x, int y, int offsetX, int offsetY,
                               int nivelMaximo, int espacioHorizontal)
        {
            if (nodo == null) return;

            if (nodo.Partido.Jugador1 == null || nodo.Partido.Jugador2 == null)
                return;

            // Dibujar el nodo actual con tamaño aumentado
            var lblPartido = new Label
            {
                Text = nodo.Partido != null ?
                      $"{nodo.Partido.Jugador1?.Nombre ?? "Bye"} vs {nodo.Partido.Jugador2?.Nombre ?? "Bye"}\n" +
                      $"Ganador: {nodo.Partido.Ganador?.Nombre ?? "Por definir"}" : "Final",
                Location = new Point(x - 100, y), // Aumentado el ancho
                Size = new Size(200, 80), // Tamaño aumentado
                BackColor = Color.LightBlue,
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 10) // Fuente más grande
            };

            panelArbol.Controls.Add(lblPartido);

            // Dibujar nodos hijos
            if (nodo.Izquierdo != null)
            {
                DibujarNodo(nodo.Izquierdo, x - offsetX, y + offsetY, offsetX / 2, offsetY,
                           nivelMaximo, espacioHorizontal);
            }

            if (nodo.Derecho != null)
            {
                DibujarNodo(nodo.Derecho, x + offsetX, y + offsetY, offsetX / 2, offsetY,
                            nivelMaximo, espacioHorizontal);
            }
        }

        private void SimularRonda()
        {
            if (_arbolTorneo == null) return;

            var partidosPorJugar = _arbolTorneo.ObtenerPartidosSinGanador();
            if (!partidosPorJugar.Any())
            {
                MessageBox.Show("El torneo ha concluido!", "Información",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Simular solo una ronda (el primer nivel de partidos sin ganador)
            var nivelActual = partidosPorJugar.Max(p => _arbolTorneo.ObtenerNivelPartido(p));
            var partidosRondaActual = partidosPorJugar
                .Where(p => _arbolTorneo.ObtenerNivelPartido(p) == nivelActual)
                .ToList();

            foreach (var partido in partidosRondaActual)
            {
                if (partido.Jugador1 != null && partido.Jugador2 != null)
                {
                    // Simular resultado aleatorio
                    int ganador = _random.Next(0, 2);
                    partido.Ganador = ganador == 0 ? partido.Jugador1 : partido.Jugador2;

                    // Asignar puntos
                    if (ganador == 0)
                    {
                        partido.Jugador1.Puntuacion += PUNTOS_VICTORIA;
                    }
                    else
                    {
                        partido.Jugador2.Puntuacion += PUNTOS_VICTORIA;
                    }

                    // Actualizar en base de datos
                    _jugadorController.ActualizarJugador(partido.Jugador1);
                    _jugadorController.ActualizarJugador(partido.Jugador2);
                }
                else
                {
                    // Manejar "bye" (participante sin oponente)
                    partido.Ganador = partido.Jugador1 ?? partido.Jugador2;
                }
            }

            DibujarArbol();
        }

        private void btnSimularRonda_Click(object sender, EventArgs e)
        {
            SimularRonda();
        }

        private void panelArbol_Paint(object sender, PaintEventArgs e)
        {
            if (_arbolTorneo != null)
            {
                DibujarLineasArbol(e.Graphics);
            }
        }
    }
}
