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
    public partial class Alerta: Form
    {
        public Alerta()
        {
            InitializeComponent();
            Fuentes fuenteb = new Fuentes();
            Fuentes fuenter = new Fuentes();
            Font PoppinsBold = new Font(fuenteb.CargarFuente(Properties.Resources.Poppins_Bold), 13,FontStyle.Bold);
            Font PoppinsRegular = new Font(fuenter.CargarFuente(Properties.Resources.Poppins_Regular), 12);
            lblTextAlertBox.Font = PoppinsRegular;
            lblTitleAlertBox.Font = PoppinsBold;
        }

        public Color BackColorAlertBox
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }

        public Color ColorAlertBox
        {
            get { return LinAlertBox.BackColor; }
            set { LinAlertBox.BackColor = lblTitleAlertBox.ForeColor = lblTextAlertBox.ForeColor = value; }
        }

        public Image IconAlertBox
        {
            get { return picAlertBox.Image; }
            set { picAlertBox.Image = value; }
        }

        public string TitleAlertBox
        {
            get { return lblTextAlertBox.Text; }
            set { lblTitleAlertBox.Text = value; }
        }

        public string TextAlertBox
        {
            get { return lblTextAlertBox.Text; }
            set { lblTextAlertBox.Text = value; }
        }

        private void PositionAlertBox()
        {
            int xPos = 0; int yPos = 0;
            xPos = Screen.GetWorkingArea(this).Width;
            yPos = Screen.GetWorkingArea(this).Height;
            this.Location = new Point(xPos - this.Width, yPos - this.Height);
        }

        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            LinAlertBox.Width = LinAlertBox.Width + 2;
            if (LinAlertBox.Width == 499)
                this.Close();
        }

        private void Alerta_Load(object sender, EventArgs e)
        {
            PositionAlertBox();
            for (int i = 0; i < 500; i++)
                timerAnimation.Start();
        }
    }
}
