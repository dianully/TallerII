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
            this.PImagen = new System.Windows.Forms.Panel();
            this.BAbrirImagen = new System.Windows.Forms.Button();
            this.PBImagenProducto = new System.Windows.Forms.PictureBox();
            this.TBDireccionImagen = new System.Windows.Forms.TextBox();
            this.LURLImagen = new System.Windows.Forms.Label();
            this.PAccion = new System.Windows.Forms.Panel();
            this.BSalir = new System.Windows.Forms.Button();
            this.BRegistrarProducto = new System.Windows.Forms.Button();
            this.PDatosProductos = new System.Windows.Forms.Panel();
            this.CBProveedorProducto = new System.Windows.Forms.ComboBox();
            this.DTPFechaAlta = new System.Windows.Forms.DateTimePicker();
            this.CBGeneroProducto = new System.Windows.Forms.ComboBox();
            this.LGernero = new System.Windows.Forms.Label();
            this.LProveedor = new System.Windows.Forms.Label();
            this.LFechaAlta = new System.Windows.Forms.Label();
            this.LPrecioVenta = new System.Windows.Forms.Label();
            this.LCantidad = new System.Windows.Forms.Label();
            this.LDescripcion = new System.Windows.Forms.Label();
            this.LNombre = new System.Windows.Forms.Label();
            this.TBNombreProducto = new System.Windows.Forms.TextBox();
            this.TBPrecioVentaProducto = new System.Windows.Forms.TextBox();
            this.TBCantidadProducto = new System.Windows.Forms.TextBox();
            this.TBDescripcionProducto = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            this.PImagen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBImagenProducto)).BeginInit();
            this.PAccion.SuspendLayout();
            this.PDatosProductos.SuspendLayout();
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
            this.panel3.Size = new System.Drawing.Size(689, 582);
            this.panel3.TabIndex = 3;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // PImagen
            // 
            this.PImagen.BackColor = System.Drawing.SystemColors.Control;
            this.PImagen.Controls.Add(this.BAbrirImagen);
            this.PImagen.Controls.Add(this.PBImagenProducto);
            this.PImagen.Controls.Add(this.TBDireccionImagen);
            this.PImagen.Controls.Add(this.LURLImagen);
            this.PImagen.Location = new System.Drawing.Point(337, 3);
            this.PImagen.Name = "PImagen";
            this.PImagen.Size = new System.Drawing.Size(350, 312);
            this.PImagen.TabIndex = 2;
            // 
            // BAbrirImagen
            // 
            this.BAbrirImagen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.BAbrirImagen.FlatAppearance.BorderSize = 0;
            this.BAbrirImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAbrirImagen.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAbrirImagen.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BAbrirImagen.Location = new System.Drawing.Point(7, 11);
            this.BAbrirImagen.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.BAbrirImagen.Name = "BAbrirImagen";
            this.BAbrirImagen.Size = new System.Drawing.Size(111, 39);
            this.BAbrirImagen.TabIndex = 45;
            this.BAbrirImagen.Text = "Abrir...";
            this.BAbrirImagen.UseVisualStyleBackColor = false;
            // 
            // PBImagenProducto
            // 
            this.PBImagenProducto.Location = new System.Drawing.Point(41, 96);
            this.PBImagenProducto.Name = "PBImagenProducto";
            this.PBImagenProducto.Size = new System.Drawing.Size(274, 183);
            this.PBImagenProducto.TabIndex = 39;
            this.PBImagenProducto.TabStop = false;
            this.PBImagenProducto.Click += new System.EventHandler(this.PBImagenProducto_Click);
            // 
            // TBDireccionImagen
            // 
            this.TBDireccionImagen.Location = new System.Drawing.Point(116, 56);
            this.TBDireccionImagen.Name = "TBDireccionImagen";
            this.TBDireccionImagen.Size = new System.Drawing.Size(199, 22);
            this.TBDireccionImagen.TabIndex = 2;
            this.TBDireccionImagen.TextChanged += new System.EventHandler(this.TBDireccionImagen_TextChanged);
            // 
            // LURLImagen
            // 
            this.LURLImagen.AutoSize = true;
            this.LURLImagen.BackColor = System.Drawing.SystemColors.Control;
            this.LURLImagen.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LURLImagen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LURLImagen.Location = new System.Drawing.Point(3, 54);
            this.LURLImagen.Name = "LURLImagen";
            this.LURLImagen.Size = new System.Drawing.Size(108, 23);
            this.LURLImagen.TabIndex = 38;
            this.LURLImagen.Text = "URL Imagen:";
            // 
            // PAccion
            // 
            this.PAccion.BackColor = System.Drawing.SystemColors.Control;
            this.PAccion.Controls.Add(this.BSalir);
            this.PAccion.Controls.Add(this.BRegistrarProducto);
            this.PAccion.Location = new System.Drawing.Point(378, 371);
            this.PAccion.Name = "PAccion";
            this.PAccion.Size = new System.Drawing.Size(274, 146);
            this.PAccion.TabIndex = 1;
            // 
            // BSalir
            // 
            this.BSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.BSalir.FlatAppearance.BorderSize = 0;
            this.BSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSalir.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSalir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BSalir.Location = new System.Drawing.Point(51, 86);
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
            this.BRegistrarProducto.Location = new System.Drawing.Point(51, 30);
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
            this.PDatosProductos.Controls.Add(this.CBProveedorProducto);
            this.PDatosProductos.Controls.Add(this.DTPFechaAlta);
            this.PDatosProductos.Controls.Add(this.CBGeneroProducto);
            this.PDatosProductos.Controls.Add(this.LGernero);
            this.PDatosProductos.Controls.Add(this.LProveedor);
            this.PDatosProductos.Controls.Add(this.LFechaAlta);
            this.PDatosProductos.Controls.Add(this.LPrecioVenta);
            this.PDatosProductos.Controls.Add(this.LCantidad);
            this.PDatosProductos.Controls.Add(this.LDescripcion);
            this.PDatosProductos.Controls.Add(this.LNombre);
            this.PDatosProductos.Controls.Add(this.TBNombreProducto);
            this.PDatosProductos.Controls.Add(this.TBPrecioVentaProducto);
            this.PDatosProductos.Controls.Add(this.TBCantidadProducto);
            this.PDatosProductos.Controls.Add(this.TBDescripcionProducto);
            this.PDatosProductos.Location = new System.Drawing.Point(3, 3);
            this.PDatosProductos.Name = "PDatosProductos";
            this.PDatosProductos.Size = new System.Drawing.Size(310, 576);
            this.PDatosProductos.TabIndex = 0;
            this.PDatosProductos.Paint += new System.Windows.Forms.PaintEventHandler(this.PDatosProductos_Paint);
            // 
            // CBProveedorProducto
            // 
            this.CBProveedorProducto.FormattingEnabled = true;
            this.CBProveedorProducto.Location = new System.Drawing.Point(25, 282);
            this.CBProveedorProducto.Name = "CBProveedorProducto";
            this.CBProveedorProducto.Size = new System.Drawing.Size(261, 24);
            this.CBProveedorProducto.TabIndex = 51;
            this.CBProveedorProducto.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // DTPFechaAlta
            // 
            this.DTPFechaAlta.Location = new System.Drawing.Point(23, 216);
            this.DTPFechaAlta.Name = "DTPFechaAlta";
            this.DTPFechaAlta.Size = new System.Drawing.Size(263, 22);
            this.DTPFechaAlta.TabIndex = 50;
            this.DTPFechaAlta.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // CBGeneroProducto
            // 
            this.CBGeneroProducto.FormattingEnabled = true;
            this.CBGeneroProducto.Location = new System.Drawing.Point(23, 343);
            this.CBGeneroProducto.Name = "CBGeneroProducto";
            this.CBGeneroProducto.Size = new System.Drawing.Size(263, 24);
            this.CBGeneroProducto.TabIndex = 49;
            // 
            // LGernero
            // 
            this.LGernero.AutoSize = true;
            this.LGernero.BackColor = System.Drawing.SystemColors.Control;
            this.LGernero.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LGernero.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LGernero.Location = new System.Drawing.Point(21, 317);
            this.LGernero.Name = "LGernero";
            this.LGernero.Size = new System.Drawing.Size(77, 23);
            this.LGernero.TabIndex = 44;
            this.LGernero.Text = "Generos:";
            this.LGernero.Click += new System.EventHandler(this.label9_Click);
            // 
            // LProveedor
            // 
            this.LProveedor.AutoSize = true;
            this.LProveedor.BackColor = System.Drawing.SystemColors.Control;
            this.LProveedor.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LProveedor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LProveedor.Location = new System.Drawing.Point(21, 256);
            this.LProveedor.Name = "LProveedor";
            this.LProveedor.Size = new System.Drawing.Size(94, 23);
            this.LProveedor.TabIndex = 43;
            this.LProveedor.Text = "Proveedor:";
            // 
            // LFechaAlta
            // 
            this.LFechaAlta.AutoSize = true;
            this.LFechaAlta.BackColor = System.Drawing.SystemColors.Control;
            this.LFechaAlta.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaAlta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LFechaAlta.Location = new System.Drawing.Point(19, 190);
            this.LFechaAlta.Name = "LFechaAlta";
            this.LFechaAlta.Size = new System.Drawing.Size(94, 23);
            this.LFechaAlta.TabIndex = 41;
            this.LFechaAlta.Text = "Fecha Alta:";
            this.LFechaAlta.Click += new System.EventHandler(this.LFechaAlta_Click);
            // 
            // LPrecioVenta
            // 
            this.LPrecioVenta.AutoSize = true;
            this.LPrecioVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPrecioVenta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LPrecioVenta.Location = new System.Drawing.Point(15, 70);
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
            this.LCantidad.Location = new System.Drawing.Point(19, 130);
            this.LCantidad.Name = "LCantidad";
            this.LCantidad.Size = new System.Drawing.Size(83, 23);
            this.LCantidad.TabIndex = 39;
            this.LCantidad.Text = "Cantidad:";
            // 
            // LDescripcion
            // 
            this.LDescripcion.AutoSize = true;
            this.LDescripcion.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDescripcion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LDescripcion.Location = new System.Drawing.Point(21, 382);
            this.LDescripcion.Name = "LDescripcion";
            this.LDescripcion.Size = new System.Drawing.Size(102, 23);
            this.LDescripcion.TabIndex = 37;
            this.LDescripcion.Text = "Descripcion:";
            this.LDescripcion.Click += new System.EventHandler(this.LDescripcion_Click);
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombre.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LNombre.Location = new System.Drawing.Point(19, 11);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(77, 23);
            this.LNombre.TabIndex = 36;
            this.LNombre.Text = "Nombre:";
            // 
            // TBNombreProducto
            // 
            this.TBNombreProducto.Location = new System.Drawing.Point(20, 37);
            this.TBNombreProducto.Name = "TBNombreProducto";
            this.TBNombreProducto.Size = new System.Drawing.Size(266, 22);
            this.TBNombreProducto.TabIndex = 0;
            this.TBNombreProducto.TextChanged += new System.EventHandler(this.TBNombreProducto_TextChanged);
            // 
            // TBPrecioVentaProducto
            // 
            this.TBPrecioVentaProducto.Location = new System.Drawing.Point(20, 96);
            this.TBPrecioVentaProducto.Name = "TBPrecioVentaProducto";
            this.TBPrecioVentaProducto.Size = new System.Drawing.Size(266, 22);
            this.TBPrecioVentaProducto.TabIndex = 4;
            this.TBPrecioVentaProducto.TextChanged += new System.EventHandler(this.TBPrecioVentaProducto_TextChanged);
            // 
            // TBCantidadProducto
            // 
            this.TBCantidadProducto.Location = new System.Drawing.Point(23, 156);
            this.TBCantidadProducto.Name = "TBCantidadProducto";
            this.TBCantidadProducto.Size = new System.Drawing.Size(263, 22);
            this.TBCantidadProducto.TabIndex = 3;
            // 
            // TBDescripcionProducto
            // 
            this.TBDescripcionProducto.Location = new System.Drawing.Point(23, 408);
            this.TBDescripcionProducto.Multiline = true;
            this.TBDescripcionProducto.Name = "TBDescripcionProducto";
            this.TBDescripcionProducto.Size = new System.Drawing.Size(263, 143);
            this.TBDescripcionProducto.TabIndex = 1;
            // 
            // AgregarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(780, 628);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AgregarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgregarProducto";
            this.Load += new System.EventHandler(this.AgregarProducto_Load);
            this.panel3.ResumeLayout(false);
            this.PImagen.ResumeLayout(false);
            this.PImagen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBImagenProducto)).EndInit();
            this.PAccion.ResumeLayout(false);
            this.PDatosProductos.ResumeLayout(false);
            this.PDatosProductos.PerformLayout();
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
        private System.Windows.Forms.Label LURLImagen;
        private System.Windows.Forms.Label LDescripcion;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.TextBox TBNombreProducto;
        private System.Windows.Forms.TextBox TBPrecioVentaProducto;
        private System.Windows.Forms.TextBox TBCantidadProducto;
        private System.Windows.Forms.TextBox TBDescripcionProducto;
        private System.Windows.Forms.TextBox TBDireccionImagen;
        private System.Windows.Forms.Label LGernero;
        private System.Windows.Forms.Label LProveedor;
        private System.Windows.Forms.Label LFechaAlta;
        private System.Windows.Forms.Panel PImagen;
        private System.Windows.Forms.Button BAbrirImagen;
        private System.Windows.Forms.PictureBox PBImagenProducto;
        private System.Windows.Forms.ComboBox CBGeneroProducto;
        private System.Windows.Forms.DateTimePicker DTPFechaAlta;
        private System.Windows.Forms.ComboBox CBProveedorProducto;
    }
}