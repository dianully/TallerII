namespace PuntoDeVentaGameBox
{
    partial class subMenuCopiaDeSeguridad
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
            this.BAplicar = new System.Windows.Forms.Button();
            this.LSub = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblBanner = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BAplicar
            // 
            this.BAplicar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.BAplicar.FlatAppearance.BorderSize = 0;
            this.BAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAplicar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAplicar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BAplicar.Location = new System.Drawing.Point(111, 135);
            this.BAplicar.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.BAplicar.Name = "BAplicar";
            this.BAplicar.Size = new System.Drawing.Size(291, 39);
            this.BAplicar.TabIndex = 22;
            this.BAplicar.Text = "Realizar Copia de Segurdad";
            this.BAplicar.UseVisualStyleBackColor = false;
            // 
            // LSub
            // 
            this.LSub.AutoSize = true;
            this.LSub.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSub.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LSub.Location = new System.Drawing.Point(92, 52);
            this.LSub.Name = "LSub";
            this.LSub.Size = new System.Drawing.Size(297, 23);
            this.LSub.TabIndex = 23;
            this.LSub.Text = "Ultima Copia de Seguridad Realizada:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(188, 94);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(127, 22);
            this.dateTimePicker1.TabIndex = 24;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LblBanner);
            this.panel1.Controls.Add(this.LSub);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.BAplicar);
            this.panel1.Location = new System.Drawing.Point(272, 115);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(511, 256);
            this.panel1.TabIndex = 25;
            // 
            // LblBanner
            // 
            this.LblBanner.AutoSize = true;
            this.LblBanner.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBanner.Location = new System.Drawing.Point(152, 193);
            this.LblBanner.Name = "LblBanner";
            this.LblBanner.Size = new System.Drawing.Size(168, 23);
            this.LblBanner.TabIndex = 26;
            this.LblBanner.Text = "(Aviso de Operacion)";
            // 
            // subMenuCopiaDeSeguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 492);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "subMenuCopiaDeSeguridad";
            this.Text = "subMenuCopiaDeSeguridad";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BAplicar;
        private System.Windows.Forms.Label LSub;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblBanner;
    }
}