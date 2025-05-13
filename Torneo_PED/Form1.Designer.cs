namespace Torneo_PED
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreJugador = new System.Windows.Forms.TextBox();
            this.listBoxJugadoresRegistrados = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBoxJugadoresEspera = new System.Windows.Forms.ListBox();
            this.lblCupo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLimpiarLista = new ProyectoADS.ClasesApariencia.RoundedButton();
            this.btnIniciarTorneo = new ProyectoADS.ClasesApariencia.RoundedButton();
            this.btnInscribir = new ProyectoADS.ClasesApariencia.RoundedButton();
            this.roundedControl1 = new Torneo_PED.RoundedControl();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(113, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = " Inscripción de jugadores ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // txtNombreJugador
            // 
            this.txtNombreJugador.Location = new System.Drawing.Point(159, 152);
            this.txtNombreJugador.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombreJugador.Multiline = true;
            this.txtNombreJugador.Name = "txtNombreJugador";
            this.txtNombreJugador.Size = new System.Drawing.Size(328, 39);
            this.txtNombreJugador.TabIndex = 2;
            // 
            // listBoxJugadoresRegistrados
            // 
            this.listBoxJugadoresRegistrados.FormattingEnabled = true;
            this.listBoxJugadoresRegistrados.HorizontalScrollbar = true;
            this.listBoxJugadoresRegistrados.ItemHeight = 16;
            this.listBoxJugadoresRegistrados.Location = new System.Drawing.Point(60, 305);
            this.listBoxJugadoresRegistrados.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxJugadoresRegistrados.Name = "listBoxJugadoresRegistrados";
            this.listBoxJugadoresRegistrados.Size = new System.Drawing.Size(265, 244);
            this.listBoxJugadoresRegistrados.TabIndex = 4;
            this.listBoxJugadoresRegistrados.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBoxJugadoresRegistrados_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(56, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Jugadores registrados";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(393, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "En espera:";
            // 
            // listBoxJugadoresEspera
            // 
            this.listBoxJugadoresEspera.FormattingEnabled = true;
            this.listBoxJugadoresEspera.HorizontalScrollbar = true;
            this.listBoxJugadoresEspera.ItemHeight = 16;
            this.listBoxJugadoresEspera.Location = new System.Drawing.Point(397, 305);
            this.listBoxJugadoresEspera.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxJugadoresEspera.Name = "listBoxJugadoresEspera";
            this.listBoxJugadoresEspera.Size = new System.Drawing.Size(248, 244);
            this.listBoxJugadoresEspera.TabIndex = 7;
            // 
            // lblCupo
            // 
            this.lblCupo.AutoSize = true;
            this.lblCupo.Location = new System.Drawing.Point(40, 130);
            this.lblCupo.Name = "lblCupo";
            this.lblCupo.Size = new System.Drawing.Size(0, 16);
            this.lblCupo.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Torneo_PED.Properties.Resources.closeX;
            this.pictureBox1.Location = new System.Drawing.Point(678, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 39);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnLimpiarLista
            // 
            this.btnLimpiarLista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnLimpiarLista.BorderColor = System.Drawing.Color.Transparent;
            this.btnLimpiarLista.BorderRadius = 15;
            this.btnLimpiarLista.DisabledTextColor = System.Drawing.Color.Empty;
            this.btnLimpiarLista.FlatAppearance.BorderSize = 0;
            this.btnLimpiarLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarLista.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarLista.Location = new System.Drawing.Point(397, 576);
            this.btnLimpiarLista.Margin = new System.Windows.Forms.Padding(0);
            this.btnLimpiarLista.Name = "btnLimpiarLista";
            this.btnLimpiarLista.Size = new System.Drawing.Size(171, 53);
            this.btnLimpiarLista.TabIndex = 14;
            this.btnLimpiarLista.Text = "Limpiar lista";
            this.btnLimpiarLista.TextColor = System.Drawing.Color.White;
            this.btnLimpiarLista.UseVisualStyleBackColor = false;
            this.btnLimpiarLista.Click += new System.EventHandler(this.btnLimpiarLista_Click);
            // 
            // btnIniciarTorneo
            // 
            this.btnIniciarTorneo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnIniciarTorneo.BorderColor = System.Drawing.Color.Transparent;
            this.btnIniciarTorneo.BorderRadius = 15;
            this.btnIniciarTorneo.DisabledTextColor = System.Drawing.Color.Empty;
            this.btnIniciarTorneo.FlatAppearance.BorderSize = 0;
            this.btnIniciarTorneo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarTorneo.ForeColor = System.Drawing.Color.White;
            this.btnIniciarTorneo.Location = new System.Drawing.Point(154, 576);
            this.btnIniciarTorneo.Margin = new System.Windows.Forms.Padding(0);
            this.btnIniciarTorneo.Name = "btnIniciarTorneo";
            this.btnIniciarTorneo.Size = new System.Drawing.Size(171, 53);
            this.btnIniciarTorneo.TabIndex = 13;
            this.btnIniciarTorneo.Text = "Iniciar torneo";
            this.btnIniciarTorneo.TextColor = System.Drawing.Color.White;
            this.btnIniciarTorneo.UseVisualStyleBackColor = false;
            this.btnIniciarTorneo.Click += new System.EventHandler(this.btnIniciarTorneo_Click);
            // 
            // btnInscribir
            // 
            this.btnInscribir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnInscribir.BorderColor = System.Drawing.Color.Transparent;
            this.btnInscribir.BorderRadius = 10;
            this.btnInscribir.DisabledTextColor = System.Drawing.Color.Empty;
            this.btnInscribir.FlatAppearance.BorderSize = 0;
            this.btnInscribir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInscribir.ForeColor = System.Drawing.Color.White;
            this.btnInscribir.Location = new System.Drawing.Point(507, 152);
            this.btnInscribir.Margin = new System.Windows.Forms.Padding(0);
            this.btnInscribir.Name = "btnInscribir";
            this.btnInscribir.Size = new System.Drawing.Size(177, 40);
            this.btnInscribir.TabIndex = 12;
            this.btnInscribir.Text = "Inscribir";
            this.btnInscribir.TextColor = System.Drawing.Color.White;
            this.btnInscribir.UseVisualStyleBackColor = false;
            this.btnInscribir.Click += new System.EventHandler(this.btnInscribir_Click);
            // 
            // roundedControl1
            // 
            this.roundedControl1.CornerRadius = 15;
            this.roundedControl1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(730, 49);
            this.panel1.TabIndex = 15;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(730, 684);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLimpiarLista);
            this.Controls.Add(this.btnIniciarTorneo);
            this.Controls.Add(this.btnInscribir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCupo);
            this.Controls.Add(this.listBoxJugadoresEspera);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxJugadoresRegistrados);
            this.Controls.Add(this.txtNombreJugador);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inscripciones de jugadores";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreJugador;
        private System.Windows.Forms.ListBox listBoxJugadoresRegistrados;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxJugadoresEspera;
        private System.Windows.Forms.Label lblCupo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private RoundedControl roundedControl1;
        private ProyectoADS.ClasesApariencia.RoundedButton btnInscribir;
        private ProyectoADS.ClasesApariencia.RoundedButton btnIniciarTorneo;
        private ProyectoADS.ClasesApariencia.RoundedButton btnLimpiarLista;
        private System.Windows.Forms.Panel panel1;
    }
}

