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
            this.BSalir = new System.Windows.Forms.Button();
            this.BCopiaDeSeguridad = new System.Windows.Forms.Button();
            this.BUsuarios = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
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
            this.LRol.Location = new System.Drawing.Point(579, 5);
            this.LRol.Name = "LRol";
            this.LRol.Size = new System.Drawing.Size(253, 46);
            this.LRol.TabIndex = 26;
            this.LRol.Text = "Administrador";
            // 
            // LTitle
            // 
            this.LTitle.AutoSize = true;
            this.LTitle.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitle.Location = new System.Drawing.Point(325, 6);
            this.LTitle.Name = "LTitle";
            this.LTitle.Size = new System.Drawing.Size(193, 45);
            this.LTitle.TabIndex = 27;
            this.LTitle.Text = "Bienvenido";
            this.LTitle.Click += new System.EventHandler(this.LTitle_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LTitle);
            this.panel1.Controls.Add(this.LRol);
            this.panel1.Location = new System.Drawing.Point(0, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1182, 64);
            this.panel1.TabIndex = 28;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BSalir);
            this.panel2.Controls.Add(this.BCopiaDeSeguridad);
            this.panel2.Controls.Add(this.BUsuarios);
            this.panel2.Location = new System.Drawing.Point(0, 76);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1182, 127);
            this.panel2.TabIndex = 29;
            // 
            // BSalir
            // 
            this.BSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.BSalir.FlatAppearance.BorderSize = 0;
            this.BSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSalir.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSalir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BSalir.Location = new System.Drawing.Point(774, 6);
            this.BSalir.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(233, 119);
            this.BSalir.TabIndex = 7;
            this.BSalir.Text = "Salir";
            this.BSalir.UseVisualStyleBackColor = false;
            this.BSalir.Click += new System.EventHandler(this.button2_Click);
            // 
            // BCopiaDeSeguridad
            // 
            this.BCopiaDeSeguridad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.BCopiaDeSeguridad.FlatAppearance.BorderSize = 0;
            this.BCopiaDeSeguridad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCopiaDeSeguridad.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCopiaDeSeguridad.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BCopiaDeSeguridad.Location = new System.Drawing.Point(447, 6);
            this.BCopiaDeSeguridad.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.BCopiaDeSeguridad.Name = "BCopiaDeSeguridad";
            this.BCopiaDeSeguridad.Size = new System.Drawing.Size(233, 119);
            this.BCopiaDeSeguridad.TabIndex = 6;
            this.BCopiaDeSeguridad.Text = "Copia de Seguridad";
            this.BCopiaDeSeguridad.UseVisualStyleBackColor = false;
            this.BCopiaDeSeguridad.Click += new System.EventHandler(this.BCopiaDeSeguridad_Click);
            // 
            // BUsuarios
            // 
            this.BUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.BUsuarios.FlatAppearance.BorderSize = 0;
            this.BUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BUsuarios.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BUsuarios.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BUsuarios.Location = new System.Drawing.Point(129, 4);
            this.BUsuarios.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.BUsuarios.Name = "BUsuarios";
            this.BUsuarios.Size = new System.Drawing.Size(233, 121);
            this.BUsuarios.TabIndex = 5;
            this.BUsuarios.Text = "Usuarios";
            this.BUsuarios.UseVisualStyleBackColor = false;
            this.BUsuarios.Click += new System.EventHandler(this.BUsuarios_Click);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 210);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1182, 492);
            this.panel3.TabIndex = 30;
            // 
            // Administrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 703);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Administrador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador";
            this.Load += new System.EventHandler(this.Administrador_Load);
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
        private System.Windows.Forms.Panel panel3;
    }
}