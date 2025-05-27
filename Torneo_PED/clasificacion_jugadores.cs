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
using Torneo_PED.Clases.Controlador;

namespace Torneo_PED
{
    public partial class clasificacion_jugadores : Form
    {
        private readonly JugadorController _jugadorController;
        public clasificacion_jugadores()
        {
            InitializeComponent();
            _jugadorController = new JugadorController();

            ConfigurarEstilos();
            ConfigurarDataGridView();
            CargarClasificacion();
        }

        private void ConfigurarEstilos()
        {
            Fuentes fuentes = new Fuentes();
            Font PoppinsBold = new Font(fuentes.CargarFuente(Properties.Resources.Poppins_Bold), 17, FontStyle.Bold);
            Font PoppinsRegular = new Font(fuentes.CargarFuente(Properties.Resources.Poppins_Regular), 11);
            Font PoppinsDgv = new Font(fuentes.CargarFuente(Properties.Resources.Poppins_Regular), 9);

            label1.Font = PoppinsBold;
            dgvClasificacion.Font = PoppinsDgv;
            btnRefrescar.Font = PoppinsRegular;

            dgvClasificacion.EnableHeadersVisualStyles = false;
            dgvClasificacion.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dgvClasificacion.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(0, 51, 102);
        }

        private void ConfigurarDataGridView()
        {
            dgvClasificacion.AutoGenerateColumns = false;
            dgvClasificacion.Columns.Clear();

            // Configurar columnas
            dgvClasificacion.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Width = 150
            });

            dgvClasificacion.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Apellido",
                HeaderText = "Apellido",
                Width = 150
            });

            dgvClasificacion.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Puntuacion",
                HeaderText = "Puntuación",
                Width = 100
            });
        }

        private void CargarClasificacion()
        {
            try
            {
                var jugadores = _jugadorController.ObtenerJugadoresConfirmadosOrdenadosPorPuntuacion();
                dgvClasificacion.DataSource = jugadores;

                // Opcional: agregar número de posición
                for (int i = 0; i < dgvClasificacion.Rows.Count; i++)
                {
                    dgvClasificacion.Rows[i].HeaderCell.Value = (i + 1).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clasificación: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clasificacion_jugadores_Load(object sender, EventArgs e)
        {
            dgvClasificacion.EnableHeadersVisualStyles = false;
            dgvClasificacion.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dgvClasificacion.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(0, 51, 102);
        }
    }
}
