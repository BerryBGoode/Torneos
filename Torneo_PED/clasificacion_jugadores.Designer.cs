namespace Torneo_PED
{
    partial class clasificacion_jugadores
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
            this.dgvClasificacion = new System.Windows.Forms.DataGridView();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.victorias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puntuacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRefrescar = new ProyectoADS.ClasesApariencia.RoundedButton();
            this.roundedControl1 = new Torneo_PED.RoundedControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasificacion)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tabla de resultados";
            // 
            // dgvClasificacion
            // 
            this.dgvClasificacion.AllowUserToResizeColumns = false;
            this.dgvClasificacion.AllowUserToResizeRows = false;
            this.dgvClasificacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClasificacion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvClasificacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClasificacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numero,
            this.nombre,
            this.victorias,
            this.puntuacion});
            this.dgvClasificacion.Location = new System.Drawing.Point(85, 173);
            this.dgvClasificacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvClasificacion.Name = "dgvClasificacion";
            this.dgvClasificacion.ReadOnly = true;
            this.dgvClasificacion.RowHeadersWidth = 62;
            this.dgvClasificacion.RowTemplate.Height = 28;
            this.dgvClasificacion.Size = new System.Drawing.Size(764, 454);
            this.dgvClasificacion.TabIndex = 3;
            // 
            // numero
            // 
            this.numero.HeaderText = "#";
            this.numero.MinimumWidth = 8;
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.MinimumWidth = 8;
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // victorias
            // 
            this.victorias.HeaderText = "Victorias";
            this.victorias.MinimumWidth = 8;
            this.victorias.Name = "victorias";
            this.victorias.ReadOnly = true;
            // 
            // puntuacion
            // 
            this.puntuacion.HeaderText = "Puntuación";
            this.puntuacion.MinimumWidth = 8;
            this.puntuacion.Name = "puntuacion";
            this.puntuacion.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(905, 49);
            this.panel1.TabIndex = 7;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Torneo_PED.Properties.Resources.closeX;
            this.pictureBox1.Location = new System.Drawing.Point(853, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 39);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnRefrescar.BorderColor = System.Drawing.Color.Transparent;
            this.btnRefrescar.BorderRadius = 10;
            this.btnRefrescar.DisabledTextColor = System.Drawing.Color.Empty;
            this.btnRefrescar.FlatAppearance.BorderSize = 0;
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Location = new System.Drawing.Point(329, 649);
            this.btnRefrescar.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(258, 53);
            this.btnRefrescar.TabIndex = 6;
            this.btnRefrescar.Text = "Refrescar clasificación";
            this.btnRefrescar.TextColor = System.Drawing.Color.White;
            this.btnRefrescar.UseVisualStyleBackColor = false;
            // 
            // roundedControl1
            // 
            this.roundedControl1.CornerRadius = 15;
            this.roundedControl1.TargetControl = this;
            // 
            // clasificacion_jugadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(905, 733);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.dgvClasificacion);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "clasificacion_jugadores";
            this.Text = "clasificacion_jugadores";
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasificacion)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvClasificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn victorias;
        private System.Windows.Forms.DataGridViewTextBoxColumn puntuacion;
        private ProyectoADS.ClasesApariencia.RoundedButton btnRefrescar;
        private RoundedControl roundedControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}