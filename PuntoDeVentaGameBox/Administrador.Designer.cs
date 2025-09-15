namespace PuntoDeVentaGameBox
{
    partial class Administrador
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
            this.LRol = new System.Windows.Forms.Label();
            this.LTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BUsuarios = new System.Windows.Forms.Button();
            this.BCopiaDeSeguridad = new System.Windows.Forms.Button();
            this.BSalir = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LRol
            // 
            this.LRol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LRol.AutoSize = true;
            this.LRol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.LRol.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LRol.Location = new System.Drawing.Point(381, 9);
            this.LRol.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LRol.Name = "LRol";
            this.LRol.Size = new System.Drawing.Size(204, 37);
            this.LRol.TabIndex = 26;
            this.LRol.Text = "Administrador";
            // 
            // LTitle
            // 
            this.LTitle.AutoSize = true;
            this.LTitle.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitle.Location = new System.Drawing.Point(212, 9);
            this.LTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LTitle.Name = "LTitle";
            this.LTitle.Size = new System.Drawing.Size(161, 37);
            this.LTitle.TabIndex = 27;
            this.LTitle.Text = "Bienvenido";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LTitle);
            this.panel1.Controls.Add(this.LRol);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(795, 67);
            this.panel1.TabIndex = 28;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BSalir);
            this.panel2.Controls.Add(this.BCopiaDeSeguridad);
            this.panel2.Controls.Add(this.BUsuarios);
            this.panel2.Location = new System.Drawing.Point(-1, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(803, 103);
            this.panel2.TabIndex = 29;
            // 
            // BUsuarios
            // 
            this.BUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.BUsuarios.FlatAppearance.BorderSize = 0;
            this.BUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BUsuarios.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BUsuarios.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BUsuarios.Location = new System.Drawing.Point(71, 2);
            this.BUsuarios.Margin = new System.Windows.Forms.Padding(11, 2, 2, 2);
            this.BUsuarios.Name = "BUsuarios";
            this.BUsuarios.Size = new System.Drawing.Size(175, 98);
            this.BUsuarios.TabIndex = 5;
            this.BUsuarios.Text = "Usuarios";
            this.BUsuarios.UseVisualStyleBackColor = false;
            this.BUsuarios.Click += new System.EventHandler(this.BUsuarios_Click);
            // 
            // BCopiaDeSeguridad
            // 
            this.BCopiaDeSeguridad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.BCopiaDeSeguridad.FlatAppearance.BorderSize = 0;
            this.BCopiaDeSeguridad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCopiaDeSeguridad.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCopiaDeSeguridad.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BCopiaDeSeguridad.Location = new System.Drawing.Point(310, 3);
            this.BCopiaDeSeguridad.Margin = new System.Windows.Forms.Padding(11, 2, 2, 2);
            this.BCopiaDeSeguridad.Name = "BCopiaDeSeguridad";
            this.BCopiaDeSeguridad.Size = new System.Drawing.Size(175, 98);
            this.BCopiaDeSeguridad.TabIndex = 6;
            this.BCopiaDeSeguridad.Text = "Copia de Seguridad";
            this.BCopiaDeSeguridad.UseVisualStyleBackColor = false;
            this.BCopiaDeSeguridad.Click += new System.EventHandler(this.BCopiaDeSeguridad_Click);
            // 
            // BSalir
            // 
            this.BSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.BSalir.FlatAppearance.BorderSize = 0;
            this.BSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSalir.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSalir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BSalir.Location = new System.Drawing.Point(555, 3);
            this.BSalir.Margin = new System.Windows.Forms.Padding(11, 2, 2, 2);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(175, 97);
            this.BSalir.TabIndex = 7;
            this.BSalir.Text = "Salir";
            this.BSalir.UseVisualStyleBackColor = false;
            this.BSalir.Click += new System.EventHandler(this.button2_Click);
            // 
            // Administrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 524);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Administrador";
            this.Text = "Administrador";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LRol;
        private System.Windows.Forms.Label LTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BUsuarios;
        private System.Windows.Forms.Button BCopiaDeSeguridad;
        private System.Windows.Forms.Button BSalir;
    }
}