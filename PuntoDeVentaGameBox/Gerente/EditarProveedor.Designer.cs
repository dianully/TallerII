namespace PuntoDeVentaGameBox.Gerente
{
    partial class EditarProveedor
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.PanelAcciones = new System.Windows.Forms.Panel();
            this.BSalir = new System.Windows.Forms.Button();
            this.BGuardarCambiosProveedor = new System.Windows.Forms.Button();
            this.PDatosProveedores = new System.Windows.Forms.Panel();
            this.LTelefono = new System.Windows.Forms.Label();
            this.LCorreo = new System.Windows.Forms.Label();
            this.LDireccion = new System.Windows.Forms.Label();
            this.LNombre = new System.Windows.Forms.Label();
            this.TBNombre = new System.Windows.Forms.TextBox();
            this.TBTelefono = new System.Windows.Forms.TextBox();
            this.TBCorreo = new System.Windows.Forms.TextBox();
            this.TBDireccion = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            this.PanelAcciones.SuspendLayout();
            this.PDatosProveedores.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.panel3.Controls.Add(this.PanelAcciones);
            this.panel3.Controls.Add(this.PDatosProveedores);
            this.panel3.Location = new System.Drawing.Point(59, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(683, 354);
            this.panel3.TabIndex = 3;
            // 
            // PanelAcciones
            // 
            this.PanelAcciones.BackColor = System.Drawing.SystemColors.Control;
            this.PanelAcciones.Controls.Add(this.BSalir);
            this.PanelAcciones.Controls.Add(this.BGuardarCambiosProveedor);
            this.PanelAcciones.Location = new System.Drawing.Point(404, 41);
            this.PanelAcciones.Name = "PanelAcciones";
            this.PanelAcciones.Size = new System.Drawing.Size(240, 272);
            this.PanelAcciones.TabIndex = 1;
            // 
            // BSalir
            // 
            this.BSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.BSalir.FlatAppearance.BorderSize = 0;
            this.BSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSalir.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSalir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BSalir.Location = new System.Drawing.Point(37, 153);
            this.BSalir.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(178, 39);
            this.BSalir.TabIndex = 44;
            this.BSalir.Text = "Salir";
            this.BSalir.UseVisualStyleBackColor = false;
            this.BSalir.Click += new System.EventHandler(this.BSalir_Click);
            // 
            // BGuardarCambiosProveedor
            // 
            this.BGuardarCambiosProveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.BGuardarCambiosProveedor.FlatAppearance.BorderSize = 0;
            this.BGuardarCambiosProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BGuardarCambiosProveedor.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGuardarCambiosProveedor.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BGuardarCambiosProveedor.Location = new System.Drawing.Point(37, 76);
            this.BGuardarCambiosProveedor.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.BGuardarCambiosProveedor.Name = "BGuardarCambiosProveedor";
            this.BGuardarCambiosProveedor.Size = new System.Drawing.Size(178, 39);
            this.BGuardarCambiosProveedor.TabIndex = 43;
            this.BGuardarCambiosProveedor.Text = "Guardar Cambios";
            this.BGuardarCambiosProveedor.UseVisualStyleBackColor = false;
            // 
            // PDatosProveedores
            // 
            this.PDatosProveedores.BackColor = System.Drawing.SystemColors.Control;
            this.PDatosProveedores.Controls.Add(this.LTelefono);
            this.PDatosProveedores.Controls.Add(this.LCorreo);
            this.PDatosProveedores.Controls.Add(this.LDireccion);
            this.PDatosProveedores.Controls.Add(this.LNombre);
            this.PDatosProveedores.Controls.Add(this.TBNombre);
            this.PDatosProveedores.Controls.Add(this.TBTelefono);
            this.PDatosProveedores.Controls.Add(this.TBCorreo);
            this.PDatosProveedores.Controls.Add(this.TBDireccion);
            this.PDatosProveedores.Location = new System.Drawing.Point(38, 41);
            this.PDatosProveedores.Name = "PDatosProveedores";
            this.PDatosProveedores.Size = new System.Drawing.Size(300, 272);
            this.PDatosProveedores.TabIndex = 0;
            // 
            // LTelefono
            // 
            this.LTelefono.AutoSize = true;
            this.LTelefono.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTelefono.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LTelefono.Location = new System.Drawing.Point(22, 76);
            this.LTelefono.Name = "LTelefono";
            this.LTelefono.Size = new System.Drawing.Size(79, 23);
            this.LTelefono.TabIndex = 40;
            this.LTelefono.Text = "Telefono:";
            // 
            // LCorreo
            // 
            this.LCorreo.AutoSize = true;
            this.LCorreo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCorreo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LCorreo.Location = new System.Drawing.Point(20, 137);
            this.LCorreo.Name = "LCorreo";
            this.LCorreo.Size = new System.Drawing.Size(66, 23);
            this.LCorreo.TabIndex = 39;
            this.LCorreo.Text = "Correo:";
            // 
            // LDireccion
            // 
            this.LDireccion.AutoSize = true;
            this.LDireccion.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDireccion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LDireccion.Location = new System.Drawing.Point(16, 206);
            this.LDireccion.Name = "LDireccion";
            this.LDireccion.Size = new System.Drawing.Size(85, 23);
            this.LDireccion.TabIndex = 38;
            this.LDireccion.Text = "Direccion:";
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombre.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LNombre.Location = new System.Drawing.Point(20, 11);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(77, 23);
            this.LNombre.TabIndex = 36;
            this.LNombre.Text = "Nombre:";
            // 
            // TBNombre
            // 
            this.TBNombre.Location = new System.Drawing.Point(24, 37);
            this.TBNombre.Name = "TBNombre";
            this.TBNombre.Size = new System.Drawing.Size(253, 22);
            this.TBNombre.TabIndex = 0;
            // 
            // TBTelefono
            // 
            this.TBTelefono.Location = new System.Drawing.Point(24, 102);
            this.TBTelefono.Name = "TBTelefono";
            this.TBTelefono.Size = new System.Drawing.Size(253, 22);
            this.TBTelefono.TabIndex = 4;
            // 
            // TBCorreo
            // 
            this.TBCorreo.Location = new System.Drawing.Point(24, 170);
            this.TBCorreo.Name = "TBCorreo";
            this.TBCorreo.Size = new System.Drawing.Size(253, 22);
            this.TBCorreo.TabIndex = 3;
            // 
            // TBDireccion
            // 
            this.TBDireccion.Location = new System.Drawing.Point(20, 232);
            this.TBDireccion.Name = "TBDireccion";
            this.TBDireccion.Size = new System.Drawing.Size(257, 22);
            this.TBDireccion.TabIndex = 2;
            // 
            // EditarProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditarProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditarProveedor";
            this.Load += new System.EventHandler(this.EditarProveedor_Load);
            this.panel3.ResumeLayout(false);
            this.PanelAcciones.ResumeLayout(false);
            this.PDatosProveedores.ResumeLayout(false);
            this.PDatosProveedores.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel PanelAcciones;
        private System.Windows.Forms.Button BSalir;
        private System.Windows.Forms.Button BGuardarCambiosProveedor;
        private System.Windows.Forms.Panel PDatosProveedores;
        private System.Windows.Forms.Label LTelefono;
        private System.Windows.Forms.Label LCorreo;
        private System.Windows.Forms.Label LDireccion;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.TextBox TBNombre;
        private System.Windows.Forms.TextBox TBTelefono;
        private System.Windows.Forms.TextBox TBCorreo;
        private System.Windows.Forms.TextBox TBDireccion;
    }
}