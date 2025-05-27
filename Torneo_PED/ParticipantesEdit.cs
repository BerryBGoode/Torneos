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
using Torneo_PED.Clases.Modelo;
using Torneo_PED.Clases.Repository;

namespace Torneo_PED
{
    public partial class ParticipantesEdit : Form
    {
        private readonly JugadorController _jugadorController;
        private readonly InscripcionRepository _inscripcionRepo;
        private readonly int _idJugador;
        private Jugador _jugador;
        private string _duiOriginal;

        public ParticipantesEdit(int idJugador)
        {
            InitializeComponent();
            _jugadorController = new JugadorController();
            _inscripcionRepo = new InscripcionRepository();
            _idJugador = idJugador;

            ConfigurarFormulario();
            CargarEstados();
            CargarDatosJugador();
        }

        private void ConfigurarFormulario()
        {
            this.Text = "Editar Participante";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            // Configurar evento KeyPress para edad
            txtEdad.KeyPress += txtEdad_KeyPress;
        }

        private void CargarEstados()
        {
            try
            {
                var estados = _inscripcionRepo.ObtenerTodosEstados();
                cmbEstado.DataSource = estados;
                cmbEstado.DisplayMember = "NombreEstado";
                cmbEstado.ValueMember = "IdEstado";
                cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar estados: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }


        private void CargarDatosJugador()
        {
            try
            {
                _jugador = _jugadorController.ObtenerJugadorPorId(_idJugador);
                if (_jugador == null)
                {
                    MessageBox.Show("Jugador no encontrado", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                _duiOriginal = _jugador.DUI;

                txtNombre.Text = _jugador.Nombre;
                txtApellido.Text = _jugador.Apellido;
                txtDui.Text = _jugador.DUI;
                txtEdad.Text = _jugador.Edad.ToString();

                var inscripcion = _inscripcionRepo.ObtenerInscripcionPorJugador(_idJugador);
                if (inscripcion != null)
                {
                    cmbEstado.SelectedValue = inscripcion.IdEstado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void ParticipantesEdit_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos()) return;

            try
            {
                if (txtDui.Text.Trim() != _duiOriginal)
                {
                    var jugadores = _jugadorController.ObtenerTodosJugadores();
                    if (jugadores.Any(j => j.DUI == txtDui.Text.Trim() && j.IdJugador != _idJugador))
                    {
                        MessageBox.Show("Ya existe un jugador con este DUI", "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDui.Focus();
                        txtDui.SelectAll();
                        return;
                    }
                }

                // Actualizar datos del jugador
                _jugador.Nombre = txtNombre.Text.Trim();
                _jugador.Apellido = txtApellido.Text.Trim();
                _jugador.DUI = txtDui.Text.Trim();
                _jugador.Edad = Convert.ToInt32(txtEdad.Text);

                _jugadorController.ActualizarJugador(_jugador);

                // Actualizar estado de inscripción
                int nuevoEstado = (int)cmbEstado.SelectedValue;
                var inscripcion = _inscripcionRepo.ObtenerInscripcionPorJugador(_idJugador);

                if (inscripcion != null && inscripcion.IdEstado != nuevoEstado)
                {
                    _inscripcionRepo.CambiarEstadoInscripcion(inscripcion.IdInscripcion, nuevoEstado);
                }

                MessageBox.Show("Cambios guardados correctamente", "Éxito",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar cambios: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MostrarError("El nombre es requerido", txtNombre);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MostrarError("El apellido es requerido", txtApellido);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDui.Text) || !System.Text.RegularExpressions.Regex.IsMatch(txtDui.Text, @"^\d{8}-\d{1}$"))
            {
                MostrarError("Formato de DUI inválido. Debe ser 12345678-9", txtDui);
                return false;
            }

            if (!int.TryParse(txtEdad.Text, out int edad) || edad <= 18)
            {
                MostrarError("La edad debe ser un número mayor a 18", txtEdad);
                return false;
            }

            return true;
        }

        private void MostrarError(string mensaje, Control control)
        {
            MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
            if (control is TextBox textBox)
            {
                textBox.SelectAll();
            }
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
