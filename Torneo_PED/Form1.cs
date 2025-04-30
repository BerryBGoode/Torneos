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

namespace Torneo_PED
{
    public partial class Form1 : Form
    {

        private readonly GestorInscripciones _gestorInscripciones;
        private const int CUPO_MAXIMO = 8;
        public Form1()
        {
            InitializeComponent();
            _gestorInscripciones = new GestorInscripciones(CUPO_MAXIMO);
            ActualizarListas();
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

            lblCupo.Text = $"{confirmados.Count}/9";
        }

        private void button1_Click(object sender, EventArgs e)
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
            MessageBox.Show("Jugador inscrito correctamente", "Éxito", 
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al inscribir jugador: {ex.Message}", "Error", 
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Aquí iría la lógica para iniciar el torneo
                MessageBox.Show("Torneo iniciado con éxito", "Éxito",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar torneo: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
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
    }
}
