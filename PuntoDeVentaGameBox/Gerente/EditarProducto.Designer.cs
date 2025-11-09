namespace PuntoDeVentaGameBox.Gerente
{
    partial class EditarProducto
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
            this.PFormEdicion = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BAbrirImagen = new System.Windows.Forms.Button();
            this.PBImagenProducto = new System.Windows.Forms.PictureBox();
            this.TBDireccionImagen = new System.Windows.Forms.TextBox();
            this.LURLImagen = new System.Windows.Forms.Label();
            this.PAccion = new System.Windows.Forms.Panel();
            this.BSalir = new System.Windows.Forms.Button();
            this.BGuardarCambios = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TBFechaAlta = new System.Windows.Forms.TextBox();
            this.DTPFechaEdicionProducto = new System.Windows.Forms.DateTimePicker();
            this.LFechaEdicion = new System.Windows.Forms.Label();
            this.CBProveedorProducto = new System.Windows.Forms.ComboBox();
            this.CBGeneroProducto = new System.Windows.Forms.ComboBox();
            this.LGenero = new System.Windows.Forms.Label();
            this.LProveedor = new System.Windows.Forms.Label();
            this.LFechaAlta = new System.Windows.Forms.Label();
            this.LPrecioVenta = new System.Windows.Forms.Label();
            this.LCantidad = new System.Windows.Forms.Label();
            this.LDescripcion = new System.Windows.Forms.Label();
            this.Lnombre = new System.Windows.Forms.Label();
            this.TBNombreProducto = new System.Windows.Forms.TextBox();
            this.TBPrecioVentaProducto = new System.Windows.Forms.TextBox();
            this.TBCantidadProducto = new System.Windows.Forms.TextBox();
            this.TBDescripcionProducto = new System.Windows.Forms.TextBox();
            this.PEditar = new System.Windows.Forms.Panel();
            this.PFormEdicion.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBImagenProducto)).BeginInit();
            this.PAccion.SuspendLayout();
            this.panel2.SuspendLayout();
            this.PEditar.SuspendLayout();
            this.SuspendLayout();
            // 
            // PFormEdicion
            // 
            this.PFormEdicion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.PFormEdicion.Controls.Add(this.panel1);
            this.PFormEdicion.Controls.Add(this.PAccion);
            this.PFormEdicion.Controls.Add(this.panel2);
            this.PFormEdicion.Location = new System.Drawing.Point(3, 13);
            this.PFormEdicion.Name = "PFormEdicion";
            this.PFormEdicion.Size = new System.Drawing.Size(695, 624);
            this.PFormEdicion.TabIndex = 8;
            this.PFormEdicion.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.BAbrirImagen);
            this.panel1.Controls.Add(this.PBImagenProducto);
            this.panel1.Controls.Add(this.TBDireccionImagen);
            this.panel1.Controls.Add(this.LURLImagen);
            this.panel1.Location = new System.Drawing.Point(337, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 312);
            this.panel1.TabIndex = 2;
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
            // 
            // TBDireccionImagen
            // 
            this.TBDireccionImagen.Location = new System.Drawing.Point(116, 56);
            this.TBDireccionImagen.Name = "TBDireccionImagen";
            this.TBDireccionImagen.Size = new System.Drawing.Size(199, 22);
            this.TBDireccionImagen.TabIndex = 2;
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
            this.PAccion.Controls.Add(this.BGuardarCambios);
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
            // 
            // BGuardarCambios
            // 
            this.BGuardarCambios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.BGuardarCambios.FlatAppearance.BorderSize = 0;
            this.BGuardarCambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BGuardarCambios.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGuardarCambios.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BGuardarCambios.Location = new System.Drawing.Point(51, 20);
            this.BGuardarCambios.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.BGuardarCambios.Name = "BGuardarCambios";
            this.BGuardarCambios.Size = new System.Drawing.Size(178, 39);
            this.BGuardarCambios.TabIndex = 43;
            this.BGuardarCambios.Text = "Guardar Cambios";
            this.BGuardarCambios.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.TBFechaAlta);
            this.panel2.Controls.Add(this.DTPFechaEdicionProducto);
            this.panel2.Controls.Add(this.LFechaEdicion);
            this.panel2.Controls.Add(this.CBProveedorProducto);
            this.panel2.Controls.Add(this.CBGeneroProducto);
            this.panel2.Controls.Add(this.LGenero);
            this.panel2.Controls.Add(this.LProveedor);
            this.panel2.Controls.Add(this.LFechaAlta);
            this.panel2.Controls.Add(this.LPrecioVenta);
            this.panel2.Controls.Add(this.LCantidad);
            this.panel2.Controls.Add(this.LDescripcion);
            this.panel2.Controls.Add(this.Lnombre);
            this.panel2.Controls.Add(this.TBNombreProducto);
            this.panel2.Controls.Add(this.TBPrecioVentaProducto);
            this.panel2.Controls.Add(this.TBCantidadProducto);
            this.panel2.Controls.Add(this.TBDescripcionProducto);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(310, 618);
            this.panel2.TabIndex = 0;
            // 
            // TBFechaAlta
            // 
            this.TBFechaAlta.Location = new System.Drawing.Point(23, 217);
            this.TBFechaAlta.Name = "TBFechaAlta";
            this.TBFechaAlta.Size = new System.Drawing.Size(263, 22);
            this.TBFechaAlta.TabIndex = 54;
            // 
            // DTPFechaEdicionProducto
            // 
            this.DTPFechaEdicionProducto.Location = new System.Drawing.Point(24, 279);
            this.DTPFechaEdicionProducto.Name = "DTPFechaEdicionProducto";
            this.DTPFechaEdicionProducto.Size = new System.Drawing.Size(262, 22);
            this.DTPFechaEdicionProducto.TabIndex = 53;
            // 
            // LFechaEdicion
            // 
            this.LFechaEdicion.AutoSize = true;
            this.LFechaEdicion.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaEdicion.Location = new System.Drawing.Point(20, 253);
            this.LFechaEdicion.Name = "LFechaEdicion";
            this.LFechaEdicion.Size = new System.Drawing.Size(115, 23);
            this.LFechaEdicion.TabIndex = 52;
            this.LFechaEdicion.Text = "Fecha Edición";
            // 
            // CBProveedorProducto
            // 
            this.CBProveedorProducto.FormattingEnabled = true;
            this.CBProveedorProducto.Location = new System.Drawing.Point(23, 341);
            this.CBProveedorProducto.Name = "CBProveedorProducto";
            this.CBProveedorProducto.Size = new System.Drawing.Size(261, 24);
            this.CBProveedorProducto.TabIndex = 51;
            // 
            // CBGeneroProducto
            // 
            this.CBGeneroProducto.FormattingEnabled = true;
            this.CBGeneroProducto.Location = new System.Drawing.Point(23, 398);
            this.CBGeneroProducto.Name = "CBGeneroProducto";
            this.CBGeneroProducto.Size = new System.Drawing.Size(263, 24);
            this.CBGeneroProducto.TabIndex = 49;
            // 
            // LGenero
            // 
            this.LGenero.AutoSize = true;
            this.LGenero.BackColor = System.Drawing.SystemColors.Control;
            this.LGenero.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LGenero.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LGenero.Location = new System.Drawing.Point(19, 368);
            this.LGenero.Name = "LGenero";
            this.LGenero.Size = new System.Drawing.Size(77, 23);
            this.LGenero.TabIndex = 44;
            this.LGenero.Text = "Generos:";
            // 
            // LProveedor
            // 
            this.LProveedor.AutoSize = true;
            this.LProveedor.BackColor = System.Drawing.SystemColors.Control;
            this.LProveedor.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LProveedor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LProveedor.Location = new System.Drawing.Point(20, 315);
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
            this.LDescripcion.Location = new System.Drawing.Point(19, 428);
            this.LDescripcion.Name = "LDescripcion";
            this.LDescripcion.Size = new System.Drawing.Size(102, 23);
            this.LDescripcion.TabIndex = 37;
            this.LDescripcion.Text = "Descripcion:";
            // 
            // Lnombre
            // 
            this.Lnombre.AutoSize = true;
            this.Lnombre.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lnombre.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Lnombre.Location = new System.Drawing.Point(19, 11);
            this.Lnombre.Name = "Lnombre";
            this.Lnombre.Size = new System.Drawing.Size(77, 23);
            this.Lnombre.TabIndex = 36;
            this.Lnombre.Text = "Nombre:";
            // 
            // TBNombreProducto
            // 
            this.TBNombreProducto.Location = new System.Drawing.Point(20, 37);
            this.TBNombreProducto.Name = "TBNombreProducto";
            this.TBNombreProducto.Size = new System.Drawing.Size(266, 22);
            this.TBNombreProducto.TabIndex = 0;
            // 
            // TBPrecioVentaProducto
            // 
            this.TBPrecioVentaProducto.Location = new System.Drawing.Point(20, 96);
            this.TBPrecioVentaProducto.Name = "TBPrecioVentaProducto";
            this.TBPrecioVentaProducto.Size = new System.Drawing.Size(266, 22);
            this.TBPrecioVentaProducto.TabIndex = 4;
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
            this.TBDescripcionProducto.Location = new System.Drawing.Point(20, 464);
            this.TBDescripcionProducto.Multiline = true;
            this.TBDescripcionProducto.Name = "TBDescripcionProducto";
            this.TBDescripcionProducto.Size = new System.Drawing.Size(263, 143);
            this.TBDescripcionProducto.TabIndex = 1;
            this.TBDescripcionProducto.TextChanged += new System.EventHandler(this.TBDescripcionProducto_TextChanged);
            // 
            // PEditar
            // 
            this.PEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.PEditar.Controls.Add(this.PFormEdicion);
            this.PEditar.Location = new System.Drawing.Point(31, 25);
            this.PEditar.Name = "PEditar";
            this.PEditar.Size = new System.Drawing.Size(707, 651);
            this.PEditar.TabIndex = 7;
            this.PEditar.Paint += new System.Windows.Forms.PaintEventHandler(this.pLimpiarParametros_Paint);
            // 
            // EditarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(763, 697);
            this.Controls.Add(this.PEditar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.EditarProducto_Load);
            this.PFormEdicion.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBImagenProducto)).EndInit();
            this.PAccion.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.PEditar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PFormEdicion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BAbrirImagen;
        private System.Windows.Forms.Button BGuardarCambios;
        private System.Windows.Forms.PictureBox PBImagenProducto;
        private System.Windows.Forms.TextBox TBDireccionImagen;
        private System.Windows.Forms.Label LURLImagen;
        private System.Windows.Forms.Panel PAccion;
        private System.Windows.Forms.Button BSalir;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox CBProveedorProducto;
        private System.Windows.Forms.ComboBox CBGeneroProducto;
        private System.Windows.Forms.Label LGenero;
        private System.Windows.Forms.Label LProveedor;
        private System.Windows.Forms.Label LFechaAlta;
        private System.Windows.Forms.Label LPrecioVenta;
        private System.Windows.Forms.Label LCantidad;
        private System.Windows.Forms.Label LDescripcion;
        private System.Windows.Forms.Label Lnombre;
        private System.Windows.Forms.TextBox TBNombreProducto;
        private System.Windows.Forms.TextBox TBPrecioVentaProducto;
        private System.Windows.Forms.TextBox TBCantidadProducto;
        private System.Windows.Forms.TextBox TBDescripcionProducto;
        private System.Windows.Forms.Panel PEditar;
        private System.Windows.Forms.DateTimePicker DTPFechaEdicionProducto;
        private System.Windows.Forms.Label LFechaEdicion;
        private System.Windows.Forms.TextBox TBFechaAlta;
    }
}