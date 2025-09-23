namespace PuntoDeVentaGameBox.Gerente
{
    partial class AgregarProducto
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
            this.PAccion = new System.Windows.Forms.Panel();
            this.BSalir = new System.Windows.Forms.Button();
            this.BRegistrarProducto = new System.Windows.Forms.Button();
            this.PDatosProductos = new System.Windows.Forms.Panel();
            this.LPrecioVenta = new System.Windows.Forms.Label();
            this.LCantidad = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LDescripcion = new System.Windows.Forms.Label();
            this.LNombre = new System.Windows.Forms.Label();
            this.TBNombre = new System.Windows.Forms.TextBox();
            this.TBPrecioVenta = new System.Windows.Forms.TextBox();
            this.TBCantidad = new System.Windows.Forms.TextBox();
            this.TBDescripcion = new System.Windows.Forms.TextBox();
            this.TBDireccionImagen = new System.Windows.Forms.TextBox();
            this.LFechaAlta = new System.Windows.Forms.Label();
            this.LFechaEdicion = new System.Windows.Forms.Label();
            this.LProveedor = new System.Windows.Forms.Label();
            this.LGernero = new System.Windows.Forms.Label();
            this.TBFechaEdicion = new System.Windows.Forms.TextBox();
            this.TBProveedor = new System.Windows.Forms.TextBox();
            this.TBFechaAlta = new System.Windows.Forms.TextBox();
            this.TBGenero = new System.Windows.Forms.TextBox();
            this.PImagen = new System.Windows.Forms.Panel();
            this.PBImagenProducto = new System.Windows.Forms.PictureBox();
            this.BAbrirImagen = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.PAccion.SuspendLayout();
            this.PDatosProductos.SuspendLayout();
            this.PImagen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBImagenProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.panel3.Controls.Add(this.PImagen);
            this.panel3.Controls.Add(this.PAccion);
            this.panel3.Controls.Add(this.PDatosProductos);
            this.panel3.Location = new System.Drawing.Point(50, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(683, 354);
            this.panel3.TabIndex = 3;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // PAccion
            // 
            this.PAccion.BackColor = System.Drawing.SystemColors.Control;
            this.PAccion.Controls.Add(this.BSalir);
            this.PAccion.Controls.Add(this.BRegistrarProducto);
            this.PAccion.Location = new System.Drawing.Point(360, 243);
            this.PAccion.Name = "PAccion";
            this.PAccion.Size = new System.Drawing.Size(240, 111);
            this.PAccion.TabIndex = 1;
            // 
            // BSalir
            // 
            this.BSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.BSalir.FlatAppearance.BorderSize = 0;
            this.BSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSalir.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSalir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BSalir.Location = new System.Drawing.Point(31, 55);
            this.BSalir.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(178, 39);
            this.BSalir.TabIndex = 44;
            this.BSalir.Text = "Salir";
            this.BSalir.UseVisualStyleBackColor = false;
            this.BSalir.Click += new System.EventHandler(this.button2_Click);
            // 
            // BRegistrarProducto
            // 
            this.BRegistrarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.BRegistrarProducto.FlatAppearance.BorderSize = 0;
            this.BRegistrarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BRegistrarProducto.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BRegistrarProducto.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BRegistrarProducto.Location = new System.Drawing.Point(31, 12);
            this.BRegistrarProducto.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.BRegistrarProducto.Name = "BRegistrarProducto";
            this.BRegistrarProducto.Size = new System.Drawing.Size(178, 39);
            this.BRegistrarProducto.TabIndex = 43;
            this.BRegistrarProducto.Text = "Registrar Producto";
            this.BRegistrarProducto.UseVisualStyleBackColor = false;
            this.BRegistrarProducto.Click += new System.EventHandler(this.bBuscar_Click);
            // 
            // PDatosProductos
            // 
            this.PDatosProductos.BackColor = System.Drawing.SystemColors.Control;
            this.PDatosProductos.Controls.Add(this.TBFechaEdicion);
            this.PDatosProductos.Controls.Add(this.TBProveedor);
            this.PDatosProductos.Controls.Add(this.TBFechaAlta);
            this.PDatosProductos.Controls.Add(this.TBGenero);
            this.PDatosProductos.Controls.Add(this.LGernero);
            this.PDatosProductos.Controls.Add(this.LProveedor);
            this.PDatosProductos.Controls.Add(this.LFechaEdicion);
            this.PDatosProductos.Controls.Add(this.LFechaAlta);
            this.PDatosProductos.Controls.Add(this.LPrecioVenta);
            this.PDatosProductos.Controls.Add(this.LCantidad);
            this.PDatosProductos.Controls.Add(this.LDescripcion);
            this.PDatosProductos.Controls.Add(this.LNombre);
            this.PDatosProductos.Controls.Add(this.TBNombre);
            this.PDatosProductos.Controls.Add(this.TBPrecioVenta);
            this.PDatosProductos.Controls.Add(this.TBCantidad);
            this.PDatosProductos.Controls.Add(this.TBDescripcion);
            this.PDatosProductos.Location = new System.Drawing.Point(32, 46);
            this.PDatosProductos.Name = "PDatosProductos";
            this.PDatosProductos.Size = new System.Drawing.Size(240, 254);
            this.PDatosProductos.TabIndex = 0;
            // 
            // LPrecioVenta
            // 
            this.LPrecioVenta.AutoSize = true;
            this.LPrecioVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPrecioVenta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LPrecioVenta.Location = new System.Drawing.Point(8, 74);
            this.LPrecioVenta.Name = "LPrecioVenta";
            this.LPrecioVenta.Size = new System.Drawing.Size(110, 23);
            this.LPrecioVenta.TabIndex = 40;
            this.LPrecioVenta.Text = "Precio Venta:";
            // 
            // LCantidad
            // 
            this.LCantidad.AutoSize = true;
            this.LCantidad.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCantidad.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LCantidad.Location = new System.Drawing.Point(26, 100);
            this.LCantidad.Name = "LCantidad";
            this.LCantidad.Size = new System.Drawing.Size(83, 23);
            this.LCantidad.TabIndex = 39;
            this.LCantidad.Text = "Cantidad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(3, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 38;
            this.label3.Text = "Imagen:";
            // 
            // LDescripcion
            // 
            this.LDescripcion.AutoSize = true;
            this.LDescripcion.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDescripcion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LDescripcion.Location = new System.Drawing.Point(16, 46);
            this.LDescripcion.Name = "LDescripcion";
            this.LDescripcion.Size = new System.Drawing.Size(102, 23);
            this.LDescripcion.TabIndex = 37;
            this.LDescripcion.Text = "Descripcion:";
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombre.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LNombre.Location = new System.Drawing.Point(24, 11);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(77, 23);
            this.LNombre.TabIndex = 36;
            this.LNombre.Text = "Nombre:";
            // 
            // TBNombre
            // 
            this.TBNombre.Location = new System.Drawing.Point(124, 13);
            this.TBNombre.Name = "TBNombre";
            this.TBNombre.Size = new System.Drawing.Size(100, 22);
            this.TBNombre.TabIndex = 0;
            // 
            // TBPrecioVenta
            // 
            this.TBPrecioVenta.Location = new System.Drawing.Point(124, 74);
            this.TBPrecioVenta.Name = "TBPrecioVenta";
            this.TBPrecioVenta.Size = new System.Drawing.Size(100, 22);
            this.TBPrecioVenta.TabIndex = 4;
            // 
            // TBCantidad
            // 
            this.TBCantidad.Location = new System.Drawing.Point(124, 102);
            this.TBCantidad.Name = "TBCantidad";
            this.TBCantidad.Size = new System.Drawing.Size(100, 22);
            this.TBCantidad.TabIndex = 3;
            // 
            // TBDescripcion
            // 
            this.TBDescripcion.Location = new System.Drawing.Point(124, 46);
            this.TBDescripcion.Name = "TBDescripcion";
            this.TBDescripcion.Size = new System.Drawing.Size(100, 22);
            this.TBDescripcion.TabIndex = 1;
            // 
            // TBDireccionImagen
            // 
            this.TBDireccionImagen.Location = new System.Drawing.Point(81, 20);
            this.TBDireccionImagen.Name = "TBDireccionImagen";
            this.TBDireccionImagen.Size = new System.Drawing.Size(100, 22);
            this.TBDireccionImagen.TabIndex = 2;
            // 
            // LFechaAlta
            // 
            this.LFechaAlta.AutoSize = true;
            this.LFechaAlta.BackColor = System.Drawing.SystemColors.Control;
            this.LFechaAlta.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaAlta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LFechaAlta.Location = new System.Drawing.Point(15, 128);
            this.LFechaAlta.Name = "LFechaAlta";
            this.LFechaAlta.Size = new System.Drawing.Size(94, 23);
            this.LFechaAlta.TabIndex = 41;
            this.LFechaAlta.Text = "Fecha Alta:";
            // 
            // LFechaEdicion
            // 
            this.LFechaEdicion.AutoSize = true;
            this.LFechaEdicion.BackColor = System.Drawing.SystemColors.Control;
            this.LFechaEdicion.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaEdicion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LFechaEdicion.Location = new System.Drawing.Point(8, 156);
            this.LFechaEdicion.Name = "LFechaEdicion";
            this.LFechaEdicion.Size = new System.Drawing.Size(119, 23);
            this.LFechaEdicion.TabIndex = 42;
            this.LFechaEdicion.Text = "Fecha Edicion:";
            // 
            // LProveedor
            // 
            this.LProveedor.AutoSize = true;
            this.LProveedor.BackColor = System.Drawing.SystemColors.Control;
            this.LProveedor.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LProveedor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LProveedor.Location = new System.Drawing.Point(24, 184);
            this.LProveedor.Name = "LProveedor";
            this.LProveedor.Size = new System.Drawing.Size(94, 23);
            this.LProveedor.TabIndex = 43;
            this.LProveedor.Text = "Proveedor:";
            // 
            // LGernero
            // 
            this.LGernero.AutoSize = true;
            this.LGernero.BackColor = System.Drawing.SystemColors.Control;
            this.LGernero.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LGernero.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LGernero.Location = new System.Drawing.Point(31, 214);
            this.LGernero.Name = "LGernero";
            this.LGernero.Size = new System.Drawing.Size(70, 23);
            this.LGernero.TabIndex = 44;
            this.LGernero.Text = "Genero:";
            this.LGernero.Click += new System.EventHandler(this.label9_Click);
            // 
            // TBFechaEdicion
            // 
            this.TBFechaEdicion.Location = new System.Drawing.Point(124, 158);
            this.TBFechaEdicion.Name = "TBFechaEdicion";
            this.TBFechaEdicion.Size = new System.Drawing.Size(100, 22);
            this.TBFechaEdicion.TabIndex = 48;
            // 
            // TBProveedor
            // 
            this.TBProveedor.Location = new System.Drawing.Point(124, 186);
            this.TBProveedor.Name = "TBProveedor";
            this.TBProveedor.Size = new System.Drawing.Size(100, 22);
            this.TBProveedor.TabIndex = 47;
            // 
            // TBFechaAlta
            // 
            this.TBFechaAlta.Location = new System.Drawing.Point(124, 130);
            this.TBFechaAlta.Name = "TBFechaAlta";
            this.TBFechaAlta.Size = new System.Drawing.Size(100, 22);
            this.TBFechaAlta.TabIndex = 45;
            // 
            // TBGenero
            // 
            this.TBGenero.Location = new System.Drawing.Point(124, 214);
            this.TBGenero.Name = "TBGenero";
            this.TBGenero.Size = new System.Drawing.Size(100, 22);
            this.TBGenero.TabIndex = 46;
            // 
            // PImagen
            // 
            this.PImagen.BackColor = System.Drawing.SystemColors.Control;
            this.PImagen.Controls.Add(this.BAbrirImagen);
            this.PImagen.Controls.Add(this.PBImagenProducto);
            this.PImagen.Controls.Add(this.TBDireccionImagen);
            this.PImagen.Controls.Add(this.label3);
            this.PImagen.Location = new System.Drawing.Point(319, 3);
            this.PImagen.Name = "PImagen";
            this.PImagen.Size = new System.Drawing.Size(329, 222);
            this.PImagen.TabIndex = 2;
            // 
            // PBImagenProducto
            // 
            this.PBImagenProducto.Location = new System.Drawing.Point(41, 56);
            this.PBImagenProducto.Name = "PBImagenProducto";
            this.PBImagenProducto.Size = new System.Drawing.Size(257, 139);
            this.PBImagenProducto.TabIndex = 39;
            this.PBImagenProducto.TabStop = false;
            // 
            // BAbrirImagen
            // 
            this.BAbrirImagen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.BAbrirImagen.FlatAppearance.BorderSize = 0;
            this.BAbrirImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAbrirImagen.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAbrirImagen.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BAbrirImagen.Location = new System.Drawing.Point(206, 9);
            this.BAbrirImagen.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.BAbrirImagen.Name = "BAbrirImagen";
            this.BAbrirImagen.Size = new System.Drawing.Size(111, 39);
            this.BAbrirImagen.TabIndex = 45;
            this.BAbrirImagen.Text = "Abrir...";
            this.BAbrirImagen.UseVisualStyleBackColor = false;
            // 
            // AgregarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(782, 403);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AgregarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgregarProducto";
            this.Load += new System.EventHandler(this.AgregarProducto_Load);
            this.panel3.ResumeLayout(false);
            this.PAccion.ResumeLayout(false);
            this.PDatosProductos.ResumeLayout(false);
            this.PDatosProductos.PerformLayout();
            this.PImagen.ResumeLayout(false);
            this.PImagen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBImagenProducto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel PAccion;
        private System.Windows.Forms.Button BSalir;
        private System.Windows.Forms.Button BRegistrarProducto;
        private System.Windows.Forms.Panel PDatosProductos;
        private System.Windows.Forms.Label LPrecioVenta;
        private System.Windows.Forms.Label LCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LDescripcion;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.TextBox TBNombre;
        private System.Windows.Forms.TextBox TBPrecioVenta;
        private System.Windows.Forms.TextBox TBCantidad;
        private System.Windows.Forms.TextBox TBDescripcion;
        private System.Windows.Forms.TextBox TBDireccionImagen;
        private System.Windows.Forms.TextBox TBFechaEdicion;
        private System.Windows.Forms.TextBox TBProveedor;
        private System.Windows.Forms.TextBox TBFechaAlta;
        private System.Windows.Forms.TextBox TBGenero;
        private System.Windows.Forms.Label LGernero;
        private System.Windows.Forms.Label LProveedor;
        private System.Windows.Forms.Label LFechaEdicion;
        private System.Windows.Forms.Label LFechaAlta;
        private System.Windows.Forms.Panel PImagen;
        private System.Windows.Forms.Button BAbrirImagen;
        private System.Windows.Forms.PictureBox PBImagenProducto;
    }
}