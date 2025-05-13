using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Torneo_PED.Clases;


namespace Torneo_PED
{
    public partial class Form1 : Form
    {
        //Panel drag
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private readonly GestorInscripciones _gestorInscripciones;
        private const int CUPO_MAXIMO = 8;
        public Form1()
        {
            InitializeComponent();
            _gestorInscripciones = new GestorInscripciones(CUPO_MAXIMO);
            ActualizarListas();
            Fuentes fuentes = new Fuentes();
            Font PoppinsBold = new Font(fuentes.CargarFuente(Properties.Resources.Poppins_Bold), 20, FontStyle.Bold);
            Font PoppinsRegular = new Font(fuentes.CargarFuente(Properties.Resources.Poppins_Regular), 11);
            label1.Font = PoppinsBold;
            btnInscribir.Font = PoppinsRegular;
            label2.Font = PoppinsRegular;
            label3.Font = PoppinsRegular;
            label4.Font = PoppinsRegular;
            txtNombreJugador.Font = PoppinsRegular;
            listBoxJugadoresRegistrados.Font = PoppinsRegular;
            listBoxJugadoresEspera.Font = PoppinsRegular;
            btnIniciarTorneo.Font = PoppinsRegular;
            btnLimpiarLista.Font = PoppinsRegular;
        }

        void AlertBox(Color backColor, Color color, string title, string text, Image Icon)
        {
            Alerta frm = new Alerta();
            frm.BackColor = backColor;
            frm.ColorAlertBox = color;
            frm.TitleAlertBox = title;
            frm.TextAlertBox = text;
            frm.IconAlertBox = Icon;
            frm.ShowDialog();
        }

        private void ActualizarListas()
        {
            listBoxJugadoresRegistrados.Items.Clear();
            listBoxJugadoresEspera.Items.Clear();

            // Obtener listas actualizadas desde la base de datos
            var repo = new InscripcionesRepository();
            var confirmados = repo.ObtenerJugadoresConfirmados();
            var enEspera = repo.ObtenerJugadoresEnEspera();

            foreach (var jugador in confirmados)
            {
                listBoxJugadoresRegistrados.Items.Add(jugador);
            }

            foreach (var jugador in enEspera)
        {
                listBoxJugadoresEspera.Items.Add(jugador);
            }

            lblCupo.Text = $"{confirmados.Count}/8";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInscribir_Click(object sender, EventArgs e)
        {
            string nombreJugador = txtNombreJugador.Text.Trim();

            if (string.IsNullOrEmpty(nombreJugador))
            {
                MessageBox.Show("Ingrese el nombre del jugador", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _gestorInscripciones.InscribirJugador(nombreJugador);
                ActualizarListas();
                txtNombreJugador.Clear();
                AlertBox(Color.LightGreen, Color.DarkGreen, "Éxito", "Jugador inscrito correctamente", Properties.Resources.check);

            }
            catch (Exception ex)
            {
                AlertBox(Color.LightPink, Color.DarkRed, "Error", $"{ex.Message}", Properties.Resources.cancel);
            }
        }

        private void btnIniciarTorneo_Click(object sender, EventArgs e)
        {
            try
            {
                if(_gestorInscripciones.ObtenerJugadoresRegistrados().Count==8)
                {
                    AlertBox(Color.LightGreen, Color.DarkGreen, "Éxito", "Torneo iniciado con éxito", Properties.Resources.check);
                    // Aquí iría la lógica para iniciar el torneo
                    dashboard frm = new dashboard();
                    frm.Show();
                    this.Hide();
                }    
                else
                    AlertBox(Color.LightPink, Color.DarkRed, "Error", $"Se requieren 8 participantes", Properties.Resources.cancel);
                
            }
            catch (Exception ex)
            {
                AlertBox(Color.LightPink, Color.DarkRed, "Error", $"Error al iniciar torneo: {ex.Message}", Properties.Resources.cancel);
            }
        }

        //Evento para mover el formulario
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnLimpiarLista_Click(object sender, EventArgs e)
        {
            try
            {
                // Aquí iría la lógica para limpiar las listas
                MessageBox.Show("Listas limpiadas correctamente", "Éxito",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al limpiar listas: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBoxJugadoresRegistrados_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBoxJugadoresRegistrados.SelectedItem != null)
            {
                try
                {
                    string selectedItem = listBoxJugadoresRegistrados.SelectedItem.ToString();
                    _gestorInscripciones.EliminarJugadores(selectedItem);
                    ActualizarListas();
                    txtNombreJugador.Clear();
                    AlertBox(Color.LightGreen, Color.DarkGreen, "Éxito", "Jugador eliminado correctamente", Properties.Resources.check);

                }
                catch (Exception ex)
                {
                    AlertBox(Color.LightPink, Color.DarkRed, "Error", $"{ex.Message}", Properties.Resources.cancel);
                }
            }
        }
    }
}
