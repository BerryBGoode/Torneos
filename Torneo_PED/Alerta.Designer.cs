namespace Torneo_PED
{
    partial class Alerta
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
            this.components = new System.ComponentModel.Container();
            this.lblTitleAlertBox = new System.Windows.Forms.Label();
            this.lblTextAlertBox = new System.Windows.Forms.Label();
            this.LinAlertBox = new System.Windows.Forms.Panel();
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            this.picAlertBox = new System.Windows.Forms.PictureBox();
            this.ellipse = new Torneo_PED.RoundedControl();
            ((System.ComponentModel.ISupportInitialize)(this.picAlertBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitleAlertBox
            // 
            this.lblTitleAlertBox.AutoSize = true;
            this.lblTitleAlertBox.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleAlertBox.Location = new System.Drawing.Point(85, 18);
            this.lblTitleAlertBox.Name = "lblTitleAlertBox";
            this.lblTitleAlertBox.Size = new System.Drawing.Size(149, 27);
            this.lblTitleAlertBox.TabIndex = 1;
            this.lblTitleAlertBox.Text = "TitleAlertBox";
            // 
            // lblTextAlertBox
            // 
            this.lblTextAlertBox.AutoSize = true;
            this.lblTextAlertBox.Location = new System.Drawing.Point(86, 49);
            this.lblTextAlertBox.Name = "lblTextAlertBox";
            this.lblTextAlertBox.Size = new System.Drawing.Size(128, 23);
            this.lblTextAlertBox.TabIndex = 2;
            this.lblTextAlertBox.Text = "TextAlertBox";
            // 
            // LinAlertBox
            // 
            this.LinAlertBox.BackColor = System.Drawing.Color.Black;
            this.LinAlertBox.Location = new System.Drawing.Point(0, 83);
            this.LinAlertBox.Name = "LinAlertBox";
            this.LinAlertBox.Size = new System.Drawing.Size(5, 6);
            this.LinAlertBox.TabIndex = 3;
            // 
            // timerAnimation
            // 
            this.timerAnimation.Interval = 10;
            this.timerAnimation.Tick += new System.EventHandler(this.timerAnimation_Tick);
            // 
            // picAlertBox
            // 
            this.picAlertBox.Location = new System.Drawing.Point(29, 20);
            this.picAlertBox.Name = "picAlertBox";
            this.picAlertBox.Size = new System.Drawing.Size(51, 49);
            this.picAlertBox.TabIndex = 0;
            this.picAlertBox.TabStop = false;
            // 
            // ellipse
            // 
            this.ellipse.CornerRadius = 20;
            this.ellipse.TargetControl = this;
            // 
            // Alerta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 90);
            this.Controls.Add(this.LinAlertBox);
            this.Controls.Add(this.lblTextAlertBox);
            this.Controls.Add(this.lblTitleAlertBox);
            this.Controls.Add(this.picAlertBox);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Alerta";
            this.Text = "Alerta";
            this.Load += new System.EventHandler(this.Alerta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAlertBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picAlertBox;
        private System.Windows.Forms.Label lblTitleAlertBox;
        private System.Windows.Forms.Label lblTextAlertBox;
        private System.Windows.Forms.Panel LinAlertBox;
        private System.Windows.Forms.Timer timerAnimation;
        private Torneo_PED.RoundedControl ellipse;
    }
}