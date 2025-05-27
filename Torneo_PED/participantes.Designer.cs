namespace Torneo_PED
{
    partial class participantes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.roundedControl1 = new Torneo_PED.RoundedControl();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvParticipantes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParticipantes)).BeginInit();
            this.SuspendLayout();
            // 
            // roundedControl1
            // 
            this.roundedControl1.CornerRadius = 15;
            this.roundedControl1.TargetControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(278, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lista de participantes";
            // 
            // dgvParticipantes
            // 
            this.dgvParticipantes.AllowUserToResizeColumns = false;
            this.dgvParticipantes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.dgvParticipantes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvParticipantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvParticipantes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvParticipantes.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvParticipantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvParticipantes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvParticipantes.GridColor = System.Drawing.Color.LightBlue;
            this.dgvParticipantes.Location = new System.Drawing.Point(94, 108);
            this.dgvParticipantes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvParticipantes.Name = "dgvParticipantes";
            this.dgvParticipantes.ReadOnly = true;
            this.dgvParticipantes.RowHeadersWidth = 62;
            this.dgvParticipantes.RowTemplate.Height = 28;
            this.dgvParticipantes.Size = new System.Drawing.Size(728, 568);
            this.dgvParticipantes.TabIndex = 4;
            this.dgvParticipantes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParticipantes_CellContentClick);
            // 
            // participantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(917, 784);
            this.Controls.Add(this.dgvParticipantes);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "participantes";
            this.Text = "participantes";
            this.Load += new System.EventHandler(this.participantes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParticipantes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedControl roundedControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvParticipantes;
    }
}