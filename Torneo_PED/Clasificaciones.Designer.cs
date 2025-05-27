namespace Torneo_PED
{
    partial class Clasificaciones
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
            this.BtnIniciarTorneo = new Torneo_PED.RoundedButton();
            this.BtnDibujarArbol = new Torneo_PED.RoundedButton();
            this.btnSimularRonda = new Torneo_PED.RoundedButton();
            this.panelArbol = new System.Windows.Forms.Panel();
            this.lblParticipantes = new System.Windows.Forms.Label();
            this.panelArbol.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnIniciarTorneo
            // 
            this.BtnIniciarTorneo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.BtnIniciarTorneo.BorderColor = System.Drawing.Color.Transparent;
            this.BtnIniciarTorneo.BorderRadius = 10;
            this.BtnIniciarTorneo.DisabledTextColor = System.Drawing.Color.Empty;
            this.BtnIniciarTorneo.FlatAppearance.BorderSize = 0;
            this.BtnIniciarTorneo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnIniciarTorneo.ForeColor = System.Drawing.Color.White;
            this.BtnIniciarTorneo.Location = new System.Drawing.Point(26, 58);
            this.BtnIniciarTorneo.Margin = new System.Windows.Forms.Padding(0);
            this.BtnIniciarTorneo.Name = "BtnIniciarTorneo";
            this.BtnIniciarTorneo.Size = new System.Drawing.Size(199, 50);
            this.BtnIniciarTorneo.TabIndex = 13;
            this.BtnIniciarTorneo.Text = "Iniciar Torneo";
            this.BtnIniciarTorneo.TextColor = System.Drawing.Color.White;
            this.BtnIniciarTorneo.UseVisualStyleBackColor = false;
            this.BtnIniciarTorneo.Click += new System.EventHandler(this.BtnIniciarTorneo_Click);
            // 
            // BtnDibujarArbol
            // 
            this.BtnDibujarArbol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.BtnDibujarArbol.BorderColor = System.Drawing.Color.Transparent;
            this.BtnDibujarArbol.BorderRadius = 10;
            this.BtnDibujarArbol.DisabledTextColor = System.Drawing.Color.Empty;
            this.BtnDibujarArbol.FlatAppearance.BorderSize = 0;
            this.BtnDibujarArbol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDibujarArbol.ForeColor = System.Drawing.Color.White;
            this.BtnDibujarArbol.Location = new System.Drawing.Point(268, 58);
            this.BtnDibujarArbol.Margin = new System.Windows.Forms.Padding(0);
            this.BtnDibujarArbol.Name = "BtnDibujarArbol";
            this.BtnDibujarArbol.Size = new System.Drawing.Size(199, 50);
            this.BtnDibujarArbol.TabIndex = 14;
            this.BtnDibujarArbol.Text = "Dibujar Arbol";
            this.BtnDibujarArbol.TextColor = System.Drawing.Color.White;
            this.BtnDibujarArbol.UseVisualStyleBackColor = false;
            this.BtnDibujarArbol.Click += new System.EventHandler(this.BtnDibujarArbol_Click);
            // 
            // btnSimularRonda
            // 
            this.btnSimularRonda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnSimularRonda.BorderColor = System.Drawing.Color.Transparent;
            this.btnSimularRonda.BorderRadius = 10;
            this.btnSimularRonda.DisabledTextColor = System.Drawing.Color.Empty;
            this.btnSimularRonda.FlatAppearance.BorderSize = 0;
            this.btnSimularRonda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimularRonda.ForeColor = System.Drawing.Color.White;
            this.btnSimularRonda.Location = new System.Drawing.Point(517, 58);
            this.btnSimularRonda.Margin = new System.Windows.Forms.Padding(0);
            this.btnSimularRonda.Name = "btnSimularRonda";
            this.btnSimularRonda.Size = new System.Drawing.Size(199, 50);
            this.btnSimularRonda.TabIndex = 15;
            this.btnSimularRonda.Text = "Simular Ronda";
            this.btnSimularRonda.TextColor = System.Drawing.Color.White;
            this.btnSimularRonda.UseVisualStyleBackColor = false;
            this.btnSimularRonda.Click += new System.EventHandler(this.btnSimularRonda_Click);
            // 
            // panelArbol
            // 
            this.panelArbol.Controls.Add(this.lblParticipantes);
            this.panelArbol.Location = new System.Drawing.Point(12, 153);
            this.panelArbol.Name = "panelArbol";
            this.panelArbol.Size = new System.Drawing.Size(879, 619);
            this.panelArbol.TabIndex = 16;
            this.panelArbol.Paint += new System.Windows.Forms.PaintEventHandler(this.panelArbol_Paint);
            // 
            // lblParticipantes
            // 
            this.lblParticipantes.AutoSize = true;
            this.lblParticipantes.Location = new System.Drawing.Point(43, 44);
            this.lblParticipantes.Name = "lblParticipantes";
            this.lblParticipantes.Size = new System.Drawing.Size(0, 20);
            this.lblParticipantes.TabIndex = 0;
            // 
            // Clasificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 784);
            this.Controls.Add(this.panelArbol);
            this.Controls.Add(this.btnSimularRonda);
            this.Controls.Add(this.BtnDibujarArbol);
            this.Controls.Add(this.BtnIniciarTorneo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Clasificaciones";
            this.Text = "Clasificaciones";
            this.panelArbol.ResumeLayout(false);
            this.panelArbol.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedButton BtnIniciarTorneo;
        private RoundedButton BtnDibujarArbol;
        private RoundedButton btnSimularRonda;
        private System.Windows.Forms.Panel panelArbol;
        private System.Windows.Forms.Label lblParticipantes;
    }
}