namespace PuntoDeVentaGameBox.Gerente
{
    partial class VerProducto
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
            this.PEditar = new System.Windows.Forms.Panel();
            this.PFormEdicion = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PBImagenProducto = new System.Windows.Forms.PictureBox();
            this.PAccion = new System.Windows.Forms.Panel();
            this.BSalir = new System.Windows.Forms.Button();
            this.BEditar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TBGenero = new System.Windows.Forms.TextBox();
            this.TBProveedor = new System.Windows.Forms.TextBox();
            this.TBUltimaActualizacion = new System.Windows.Forms.TextBox();
            this.TBFechaAlta = new System.Windows.Forms.TextBox();
            this.LFUltimaActualizacion = new System.Windows.Forms.Label();
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
            this.PEditar.SuspendLayout();
            this.PFormEdicion.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBImagenProducto)).BeginInit();
            this.PAccion.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PEditar
            // 
            this.PEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.PEditar.Controls.Add(this.PFormEdicion);
            this.PEditar.Location = new System.Drawing.Point(0, 0);
            this.PEditar.Name = "PEditar";
            this.PEditar.Size = new System.Drawing.Size(744, 667);
            this.PEditar.TabIndex = 8;
            this.PEditar.Paint += new System.Windows.Forms.PaintEventHandler(this.PEditar_Paint);
            // 
            // PFormEdicion
            // 
            this.PFormEdicion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.PFormEdicion.Controls.Add(this.panel1);
            this.PFormEdicion.Controls.Add(this.PAccion);
            this.PFormEdicion.Controls.Add(this.panel2);
            this.PFormEdicion.Location = new System.Drawing.Point(29, 24);
            this.PFormEdicion.Name = "PFormEdicion";
            this.PFormEdicion.Size = new System.Drawing.Size(695, 624);
            this.PFormEdicion.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.PBImagenProducto);
            this.panel1.Location = new System.Drawing.Point(337, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 312);
            this.panel1.TabIndex = 2;
            // 
            // PBImagenProducto
            // 
            this.PBImagenProducto.Location = new System.Drawing.Point(41, 37);
            this.PBImagenProducto.Name = "PBImagenProducto";
            this.PBImagenProducto.Size = new System.Drawing.Size(274, 242);
            this.PBImagenProducto.TabIndex = 39;
            this.PBImagenProducto.TabStop = false;
            // 
            // PAccion
            // 
            this.PAccion.BackColor = System.Drawing.SystemColors.Control;
            this.PAccion.Controls.Add(this.BSalir);
            this.PAccion.Controls.Add(this.BEditar);
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
            // BEditar
            // 
            this.BEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.BEditar.FlatAppearance.BorderSize = 0;
            this.BEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BEditar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BEditar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BEditar.Location = new System.Drawing.Point(51, 20);
            this.BEditar.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.BEditar.Name = "BEditar";
            this.BEditar.Size = new System.Drawing.Size(178, 39);
            this.BEditar.TabIndex = 43;
            this.BEditar.Text = "Editar";
            this.BEditar.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.TBGenero);
            this.panel2.Controls.Add(this.TBProveedor);
            this.panel2.Controls.Add(this.TBUltimaActualizacion);
            this.panel2.Controls.Add(this.TBFechaAlta);
            this.panel2.Controls.Add(this.LFUltimaActualizacion);
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
            // TBGenero
            // 
            this.TBGenero.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBGenero.Location = new System.Drawing.Point(20, 397);
            this.TBGenero.Multiline = true;
            this.TBGenero.Name = "TBGenero";
            this.TBGenero.Size = new System.Drawing.Size(259, 62);
            this.TBGenero.TabIndex = 56;
            // 
            // TBProveedor
            // 
            this.TBProveedor.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBProveedor.Location = new System.Drawing.Point(24, 341);
            this.TBProveedor.Name = "TBProveedor";
            this.TBProveedor.Size = new System.Drawing.Size(259, 30);
            this.TBProveedor.TabIndex = 55;
            // 
            // TBUltimaActualizacion
            // 
            this.TBUltimaActualizacion.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBUltimaActualizacion.Location = new System.Drawing.Point(24, 280);
            this.TBUltimaActualizacion.Name = "TBUltimaActualizacion";
            this.TBUltimaActualizacion.Size = new System.Drawing.Size(259, 30);
            this.TBUltimaActualizacion.TabIndex = 54;
            // 
            // TBFechaAlta
            // 
            this.TBFechaAlta.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBFechaAlta.Location = new System.Drawing.Point(23, 217);
            this.TBFechaAlta.Name = "TBFechaAlta";
            this.TBFechaAlta.Size = new System.Drawing.Size(263, 30);
            this.TBFechaAlta.TabIndex = 53;
            // 
            // LFUltimaActualizacion
            // 
            this.LFUltimaActualizacion.AutoSize = true;
            this.LFUltimaActualizacion.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFUltimaActualizacion.Location = new System.Drawing.Point(20, 253);
            this.LFUltimaActualizacion.Name = "LFUltimaActualizacion";
            this.LFUltimaActualizacion.Size = new System.Drawing.Size(166, 23);
            this.LFUltimaActualizacion.TabIndex = 52;
            this.LFUltimaActualizacion.Text = "Última Actualización";
            // 
            // LGenero
            // 
            this.LGenero.AutoSize = true;
            this.LGenero.BackColor = System.Drawing.SystemColors.Control;
            this.LGenero.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LGenero.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LGenero.Location = new System.Drawing.Point(19, 374);
            this.LGenero.Name = "LGenero";
            this.LGenero.Size = new System.Drawing.Size(70, 23);
            this.LGenero.TabIndex = 44;
            this.LGenero.Text = "Genero:";
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
            this.LDescripcion.Location = new System.Drawing.Point(19, 469);
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
            this.TBNombreProducto.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBNombreProducto.Location = new System.Drawing.Point(20, 37);
            this.TBNombreProducto.Name = "TBNombreProducto";
            this.TBNombreProducto.Size = new System.Drawing.Size(266, 30);
            this.TBNombreProducto.TabIndex = 0;
            // 
            // TBPrecioVentaProducto
            // 
            this.TBPrecioVentaProducto.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBPrecioVentaProducto.Location = new System.Drawing.Point(20, 96);
            this.TBPrecioVentaProducto.Name = "TBPrecioVentaProducto";
            this.TBPrecioVentaProducto.Size = new System.Drawing.Size(266, 30);
            this.TBPrecioVentaProducto.TabIndex = 4;
            // 
            // TBCantidadProducto
            // 
            this.TBCantidadProducto.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCantidadProducto.Location = new System.Drawing.Point(23, 156);
            this.TBCantidadProducto.Name = "TBCantidadProducto";
            this.TBCantidadProducto.Size = new System.Drawing.Size(263, 30);
            this.TBCantidadProducto.TabIndex = 3;
            // 
            // TBDescripcionProducto
            // 
            this.TBDescripcionProducto.Location = new System.Drawing.Point(20, 495);
            this.TBDescripcionProducto.Multiline = true;
            this.TBDescripcionProducto.Name = "TBDescripcionProducto";
            this.TBDescripcionProducto.Size = new System.Drawing.Size(263, 112);
            this.TBDescripcionProducto.TabIndex = 1;
            // 
            // VerProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 667);
            this.Controls.Add(this.PEditar);
            this.Name = "VerProducto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VerProducto";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PEditar.ResumeLayout(false);
            this.PFormEdicion.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PBImagenProducto)).EndInit();
            this.PAccion.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PEditar;
        private System.Windows.Forms.Panel PFormEdicion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox PBImagenProducto;
        private System.Windows.Forms.Panel PAccion;
        private System.Windows.Forms.Button BSalir;
        private System.Windows.Forms.Button BEditar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LFUltimaActualizacion;
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
        private System.Windows.Forms.TextBox TBGenero;
        private System.Windows.Forms.TextBox TBProveedor;
        private System.Windows.Forms.TextBox TBUltimaActualizacion;
        private System.Windows.Forms.TextBox TBFechaAlta;
    }
}