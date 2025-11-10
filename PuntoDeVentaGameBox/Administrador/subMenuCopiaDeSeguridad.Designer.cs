namespace PuntoDeVentaGameBox.Administrador
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
            this.LSub = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lFechaCopia = new System.Windows.Forms.Label();
            this.tbRutaDeGuardado = new System.Windows.Forms.TextBox();
            this.bElegirRuta = new System.Windows.Forms.Button();
            this.bCopiaSeguridad = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LSub
            // 
            this.LSub.AutoSize = true;
            this.LSub.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSub.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LSub.Location = new System.Drawing.Point(23, 26);
            this.LSub.Name = "LSub";
            this.LSub.Size = new System.Drawing.Size(297, 23);
            this.LSub.TabIndex = 23;
            this.LSub.Text = "Ultima Copia de Seguridad Realizada:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(331, 22);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(511, 445);
            this.panel1.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bCopiaSeguridad);
            this.panel2.Controls.Add(this.bElegirRuta);
            this.panel2.Controls.Add(this.lFechaCopia);
            this.panel2.Controls.Add(this.tbRutaDeGuardado);
            this.panel2.Controls.Add(this.LSub);
            this.panel2.Location = new System.Drawing.Point(87, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(344, 202);
            this.panel2.TabIndex = 44;
            // 
            // lFechaCopia
            // 
            this.lFechaCopia.AutoSize = true;
            this.lFechaCopia.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFechaCopia.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lFechaCopia.Location = new System.Drawing.Point(126, 49);
            this.lFechaCopia.Name = "lFechaCopia";
            this.lFechaCopia.Size = new System.Drawing.Size(92, 23);
            this.lFechaCopia.TabIndex = 45;
            this.lFechaCopia.Text = "dd/mm/yy";
            // 
            // tbRutaDeGuardado
            // 
            this.tbRutaDeGuardado.Location = new System.Drawing.Point(14, 102);
            this.tbRutaDeGuardado.Name = "tbRutaDeGuardado";
            this.tbRutaDeGuardado.Size = new System.Drawing.Size(158, 22);
            this.tbRutaDeGuardado.TabIndex = 43;
            // 
            // bElegirRuta
            // 
            this.bElegirRuta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.bElegirRuta.FlatAppearance.BorderSize = 0;
            this.bElegirRuta.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bElegirRuta.ForeColor = System.Drawing.SystemColors.Control;
            this.bElegirRuta.Location = new System.Drawing.Point(190, 92);
            this.bElegirRuta.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.bElegirRuta.Name = "bElegirRuta";
            this.bElegirRuta.Size = new System.Drawing.Size(138, 39);
            this.bElegirRuta.TabIndex = 46;
            this.bElegirRuta.Text = "Elegir Ruta";
            this.bElegirRuta.UseVisualStyleBackColor = false;
            this.bElegirRuta.Click += new System.EventHandler(this.bElegirRuta_Click);
            // 
            // bCopiaSeguridad
            // 
            this.bCopiaSeguridad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.bCopiaSeguridad.FlatAppearance.BorderSize = 0;
            this.bCopiaSeguridad.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCopiaSeguridad.ForeColor = System.Drawing.SystemColors.Control;
            this.bCopiaSeguridad.Location = new System.Drawing.Point(52, 144);
            this.bCopiaSeguridad.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.bCopiaSeguridad.Name = "bCopiaSeguridad";
            this.bCopiaSeguridad.Size = new System.Drawing.Size(235, 39);
            this.bCopiaSeguridad.TabIndex = 47;
            this.bCopiaSeguridad.Text = "Realizar Copia de Seguridad";
            this.bCopiaSeguridad.UseVisualStyleBackColor = false;
            this.bCopiaSeguridad.Click += new System.EventHandler(this.bCopiaDeSeguridad_Click);
            // 
            // subMenuCopiaDeSeguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(1182, 492);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "subMenuCopiaDeSeguridad";
            this.Text = "subMenuCopiaDeSeguridad";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label LSub;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbRutaDeGuardado;
        private System.Windows.Forms.Label lFechaCopia;
        private System.Windows.Forms.Button bCopiaSeguridad;
        private System.Windows.Forms.Button bElegirRuta;
    }
}