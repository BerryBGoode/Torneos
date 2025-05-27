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
using Torneo_PED.Clases.Controlador;
using Torneo_PED.Clases.Modelo;


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

        private readonly JugadorController _jugadorController;
        private const int CUPO_MAXIMO = 8;
        public Form1()
        {
            InitializeComponent();
            _jugadorController = new JugadorController(CUPO_MAXIMO);

            //ConfigurarFuentes();
            ActualizarListas();
        }

        //private void ConfigurarFuentes()
        //{
        //    Fuentes fuentes = new Fuentes();
        //    Font PoppinsBold = new Font(fuentes.CargarFuente(Properties.Resources.Poppins_Bold), 20, FontStyle.Bold);
        //    Font PoppinsRegular = new Font(fuentes.CargarFuente(Properties.Resources.Poppins_Regular), 11);

        //    label1.Font = PoppinsBold;
        //    btnInscribir.Font = PoppinsRegular;
        //    label2.Font = PoppinsRegular;
        //    label3.Font = PoppinsRegular;
        //    label4.Font = PoppinsRegular;
        //    txtNombreJugador.Font = PoppinsRegular;
        //    listBoxJugadoresRegistrados.Font = PoppinsRegular;
        //    listBoxJugadoresEspera.Font = PoppinsRegular;
        //    btnIniciarTorneo.Font = PoppinsRegular;
        //    btnLimpiarLista.Font = PoppinsRegular;
        //}
        private void ActualizarListas()
        {
            listBoxJugadoresRegistrados.Items.Clear();
            listBoxJugadoresEspera.Items.Clear();

            var confirmados = _jugadorController.ObtenerJugadoresConfirmados() ?? new List<Jugador>();
            var enEspera = _jugadorController.ObtenerJugadoresEnEspera() ?? new List<Jugador>();

            foreach (var jugador in confirmados)
            {
                listBoxJugadoresRegistrados.Items.Add($"{jugador.Nombre} - {jugador.Apellido}");
            }

            foreach (var jugador in enEspera)
            {
                listBoxJugadoresEspera.Items.Add($"{jugador.Nombre} - {jugador.Apellido}");
            }

            lblCupo.Text = $"{confirmados.Count}/{CUPO_MAXIMO}";
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInscribir_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreJugador.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string dui = txtDui.Text.Trim();

            // Validar que todos los campos tengan datos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(dui))
            {
                MessageBox.Show("Todos los campos son obligatorios", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que nombre y apellido solo contengan letras y espacios
            if (!EsTextoValido(nombre) || !EsTextoValido(apellido))
            {
                MessageBox.Show("Nombre y apellido solo pueden contener letras y espacios", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar edad
            if (!int.TryParse(txtEdad.Text, out int edad) || edad <= 18)
            {
                MessageBox.Show("La edad debe ser un número mayor a 18", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar formato DUI (12345678-9)
            if (!ValidarFormatoDUI(dui))
            {
                MessageBox.Show("El DUI debe tener el formato 12345678-9", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _jugadorController.InscribirJugador(nombre, apellido, edad, dui);
                ActualizarListas();
                LimpiarCampos();
                MessageBox.Show("Jugador inscrito correctamente", "Éxito",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inscribir jugador: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIniciarTorneo_Click(object sender, EventArgs e)
        {
            try
            {
                if (_jugadorController.TorneoPuedeIniciar())
                {
                    AlertBox(Color.LightGreen, Color.DarkGreen, "Éxito", "Torneo iniciado con éxito", Properties.Resources.check);
                    // Aquí iría la lógica para iniciar el torneo
                    dashboard frm = new dashboard();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    AlertBox(Color.LightPink, Color.DarkRed, "Error", "Se requieren 8 participantes", Properties.Resources.cancel);
                }
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
                // Implementar lógica para limpiar listas si es necesario
                _jugadorController.LimpiarInscripciones();
                ActualizarListas();
                AlertBox(Color.LightGreen, Color.DarkGreen, "Éxito", "Listas limpiadas correctamente", Properties.Resources.check);
            }
            catch (Exception ex)
            {
                AlertBox(Color.LightPink, Color.DarkRed, "Error", $"Error al limpiar listas: {ex.Message}", Properties.Resources.cancel);
            }
        }

        private void listBoxJugadoresRegistrados_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void LimpiarCampos()
        {
            txtNombreJugador.Clear();
            txtApellido.Clear();
            txtEdad.Clear();
            txtDui.Clear();
            txtNombreJugador.Focus();
        }

        private bool EsTextoValido(string texto)
        {
            // Permite letras, espacios y acentos
            return System.Text.RegularExpressions.Regex.IsMatch(texto, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$");
        }

        private bool ValidarFormatoDUI(string dui)
        {
            // Formato: 8 dígitos, guión, 1 dígito (12345678-9)
            return System.Text.RegularExpressions.Regex.IsMatch(dui, @"^\d{8}-\d{1}$");
        }

        private void txtNombreJugador_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras, espacios, backspace y acentos
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) &&
                !char.IsControl(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Misma validación que para el nombre
            txtNombreJugador_KeyPress(sender, e);
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y backspace
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDui_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y guión en posición específica
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                !(e.KeyChar == '-' && txtDui.Text.Length == 8 && !txtDui.Text.Contains("-")))
            {
                e.Handled = true;
            }

            // Autoinsertar el guión después de 8 dígitos
            if (char.IsDigit(e.KeyChar) && txtDui.Text.Length == 8 && !txtDui.Text.Contains("-"))
            {
                txtDui.Text += "-";
                txtDui.SelectionStart = txtDui.Text.Length;
            }
        }
    }
}
