using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Torneo_PED.Clases.Controlador;

namespace Torneo_PED
{
    public partial class participantes: Form
    {
        private readonly JugadorController _jugadorController;
        public participantes()
        {
            InitializeComponent();
            Fuentes fuentes = new Fuentes();
            Font PoppinsBold = new Font(fuentes.CargarFuente(Properties.Resources.Poppins_Bold), 17, FontStyle.Bold);
            Font PoppinsRegular = new Font(fuentes.CargarFuente(Properties.Resources.Poppins_Regular), 11);
            Font PoppinsDgv = new Font(fuentes.CargarFuente(Properties.Resources.Poppins_Regular), 9);
            label1.Font = PoppinsBold;
            dgvParticipantes.Font = PoppinsDgv;

            _jugadorController = new JugadorController();

            // Configurar columnas del DataGridView
            ConfigurarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            // Asegurarse de que las columnas estén configuradas correctamente
            dgvParticipantes.AutoGenerateColumns = false;
            dgvParticipantes.Columns.Clear();

            // Columnas básicas
            dgvParticipantes.Columns.Add("IdJugador", "ID");
            dgvParticipantes.Columns.Add("Nombre", "Nombre");
            dgvParticipantes.Columns.Add("Apellido", "Apellido");
            dgvParticipantes.Columns.Add("DUI", "DUI");
            dgvParticipantes.Columns.Add("Estado", "Estado");
            dgvParticipantes.Columns.Add("Puntuacion", "Puntuación");

            // Configurar ancho de columnas
            dgvParticipantes.Columns["IdJugador"].Width = 50;
            dgvParticipantes.Columns["Nombre"].Width = 150;
            dgvParticipantes.Columns["Apellido"].Width = 150;
            dgvParticipantes.Columns["DUI"].Width = 100;
            dgvParticipantes.Columns["Estado"].Width = 100;
            dgvParticipantes.Columns["Puntuacion"].Width = 80;

            // Columna para botones
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.Name = "Editar";
            btnEditar.Text = "Editar";
            btnEditar.UseColumnTextForButtonValue = true;
            btnEditar.Width = 70;
            dgvParticipantes.Columns.Add(btnEditar);

            DataGridViewButtonColumn btnBorrar = new DataGridViewButtonColumn();
            btnBorrar.Name = "Borrar";
            btnBorrar.Text = "Borrar";
            btnBorrar.UseColumnTextForButtonValue = true;
            btnBorrar.Width = 70;
            dgvParticipantes.Columns.Add(btnBorrar);
        }


        private void participantes_Load(object sender, EventArgs e)
        {
            dgvParticipantes.EnableHeadersVisualStyles = false;
            dgvParticipantes.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dgvParticipantes.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(0, 51, 102);

            CargarParticipantes();
        }

        private void CargarParticipantes()
        {
            try
            {
                dgvParticipantes.Rows.Clear();

                // Obtener jugadores confirmados
                var confirmados = _jugadorController.ObtenerJugadoresConfirmados();
                foreach (var jugador in confirmados)
                {
                    dgvParticipantes.Rows.Add(
                        jugador.IdJugador,
                        jugador.Nombre,
                        jugador.Apellido,
                        jugador.DUI,
                        "Confirmado",
                        jugador.Puntuacion
                    );
                }

                // Obtener jugadores en espera
                var enEspera = _jugadorController.ObtenerJugadoresEnEspera();
                foreach (var jugador in enEspera)
                {
                    dgvParticipantes.Rows.Add(
                        jugador.IdJugador,
                        jugador.Nombre,
                        jugador.Apellido,
                        jugador.DUI,
                        "En espera",
                        jugador.Puntuacion
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar participantes: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvParticipantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que se hizo clic en un botón y no en el encabezado
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var columnName = dgvParticipantes.Columns[e.ColumnIndex].Name;
            var idJugador = Convert.ToInt32(dgvParticipantes.Rows[e.RowIndex].Cells["IdJugador"].Value);
            var nombre = dgvParticipantes.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();

            if (columnName == "Borrar")
            {
                // Confirmar eliminación
                var confirmacion = MessageBox.Show($"¿Está seguro que desea eliminar a {nombre}?",
                                                 "Confirmar eliminación",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.Yes)
                {
                    try
                    {
                        _jugadorController.EliminarJugador(nombre);
                        CargarParticipantes();
                        MessageBox.Show("Jugador eliminado correctamente", "Éxito",
                                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar jugador: {ex.Message}", "Error",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (columnName == "Editar")
            {
                using (var formEditar = new ParticipantesEdit(idJugador))
                {
                    if (formEditar.ShowDialog() == DialogResult.OK)
                    {
                        CargarParticipantes();
                    }
                }
            }
        }
    }
}
