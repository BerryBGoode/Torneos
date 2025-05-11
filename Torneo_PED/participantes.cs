using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Torneo_PED
{
    public partial class participantes: Form
    {
        public participantes()
        {
            InitializeComponent();
            Fuentes fuentes = new Fuentes();
            Font PoppinsBold = new Font(fuentes.CargarFuente(Properties.Resources.Poppins_Bold), 17, FontStyle.Bold);
            Font PoppinsRegular = new Font(fuentes.CargarFuente(Properties.Resources.Poppins_Regular), 11);
            Font PoppinsDgv = new Font(fuentes.CargarFuente(Properties.Resources.Poppins_Regular), 9);
            label1.Font = PoppinsBold;
            dgvParticipantes.Font = PoppinsDgv;
            dgvParticipantes.Columns[1].Width = 200;
        }

        private void participantes_Load(object sender, EventArgs e)
        {
            dgvParticipantes.EnableHeadersVisualStyles = false;
            dgvParticipantes.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dgvParticipantes.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(0, 51, 102);
        }
    }
}
