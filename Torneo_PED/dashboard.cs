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

namespace Torneo_PED
{
    public partial class dashboard: Form
    {
        //Panel drag
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public dashboard()
        {
            InitializeComponent();
            CargarFuentes();
        }

        void CargarFuentes()
        {
            Fuentes fuentes = new Fuentes();
            Font PoppinsBold = new Font(fuentes.CargarFuente(Properties.Resources.Poppins_Bold), 20, FontStyle.Bold);
            Font PoppinsRegular = new Font(fuentes.CargarFuente(Properties.Resources.Poppins_Regular), 11);
            lblNombreTorneo.Font = PoppinsRegular;
            label1.Font = PoppinsRegular;
            label2.Font = PoppinsRegular;
            label3.Font = PoppinsRegular;
            label4.Font = PoppinsRegular;
        }

        private void CargarFormPanel(Form formHijo)
        {
            formHijo.TopLevel = false;
            Contenedor.Controls.Clear();
            Contenedor.Controls.Add(formHijo);
            formHijo.Dock = DockStyle.Fill;
            formHijo.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void PanelParticipantes_MouseEnter(object sender, EventArgs e)
        {
            PanelParticipantes.BackColor = Color.FromArgb(226, 226, 226);
        }

        private void PanelParticipantes_MouseLeave(object sender, EventArgs e)
        {
            PanelParticipantes.BackColor = Color.WhiteSmoke;
        }

        private void PanelClasificaciones_MouseEnter(object sender, EventArgs e)
        {
            PanelClasificaciones.BackColor = Color.FromArgb(226, 226, 226);
        }

        private void PanelClasificaciones_MouseLeave(object sender, EventArgs e)
        {
            PanelClasificaciones.BackColor = Color.WhiteSmoke;
        }

        private void PanelResultados_MouseEnter(object sender, EventArgs e)
        {
            PanelResultados.BackColor = Color.FromArgb(226, 226, 226);
        }

        private void PanelResultados_MouseLeave(object sender, EventArgs e)
        {
            PanelResultados.BackColor = Color.WhiteSmoke;
        }

        private void PanelGestion_MouseEnter(object sender, EventArgs e)
        {
            PanelGestion.BackColor = Color.FromArgb(226, 226, 226);
        }

        private void PanelGestion_MouseLeave(object sender, EventArgs e)
        {
            PanelGestion.BackColor = Color.WhiteSmoke;
        }

        private void PanelParticipantes_Click(object sender, EventArgs e)
        {
            participantes frm = new participantes() { TopLevel = false, TopMost = true };
            CargarFormPanel(frm);
        }

        private void PanelClasificaciones_Click(object sender, EventArgs e)
        {
            clasificacion_jugadores frm = new clasificacion_jugadores() { TopLevel = false, TopMost = true };
            CargarFormPanel(frm);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void PanelResultados_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelResultados_Click(object sender, EventArgs e)
        {
            Clasificaciones frm = new Clasificaciones() { TopLevel = false, TopMost = true };
            CargarFormPanel(frm);
        }
    }
}
