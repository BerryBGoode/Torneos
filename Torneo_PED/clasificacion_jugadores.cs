﻿using System;
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
    public partial class clasificacion_jugadores : Form
    {
        public clasificacion_jugadores()
        {
            InitializeComponent();
            Fuentes fuentes = new Fuentes();
            Font PoppinsBold = new Font(fuentes.CargarFuente(Properties.Resources.Poppins_Bold), 17, FontStyle.Bold);
            Font PoppinsRegular = new Font(fuentes.CargarFuente(Properties.Resources.Poppins_Regular), 11);
            Font PoppinsDgv = new Font(fuentes.CargarFuente(Properties.Resources.Poppins_Regular), 9);
            label1.Font = PoppinsBold;
            dgvClasificacion.Font = PoppinsDgv;
            btnRefrescar.Font = PoppinsRegular;
            dgvClasificacion.Columns[1].Width = 200;
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
