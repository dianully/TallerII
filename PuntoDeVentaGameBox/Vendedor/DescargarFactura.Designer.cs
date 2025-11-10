namespace PuntoDeVentaGameBox.Vendedor
{
    partial class DescargarFactura
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMetodoDePago = new System.Windows.Forms.ComboBox();
            this.LProducto = new System.Windows.Forms.Label();
            this.dtpFechaCompra = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDNI = new System.Windows.Forms.TextBox();
            this.bBuscar = new System.Windows.Forms.Button();
            this.bSalir = new System.Windows.Forms.Button();
            this.dgvFacturasVendedor = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasVendedor)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbMetodoDePago);
            this.groupBox1.Controls.Add(this.LProducto);
            this.groupBox1.Controls.Add(this.dtpFechaCompra);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbDNI);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1156, 136);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Busqueda";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(847, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 25);
            this.label2.TabIndex = 38;
            this.label2.Text = "Metodo De Pago:";
            // 
            // cbMetodoDePago
            // 
            this.cbMetodoDePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMetodoDePago.FormattingEnabled = true;
            this.cbMetodoDePago.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta"});
            this.cbMetodoDePago.Location = new System.Drawing.Point(842, 68);
            this.cbMetodoDePago.Margin = new System.Windows.Forms.Padding(4);
            this.cbMetodoDePago.Name = "cbMetodoDePago";
            this.cbMetodoDePago.Size = new System.Drawing.Size(185, 24);
            this.cbMetodoDePago.TabIndex = 36;
            // 
            // LProducto
            // 
            this.LProducto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LProducto.AutoSize = true;
            this.LProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LProducto.ForeColor = System.Drawing.SystemColors.Control;
            this.LProducto.Location = new System.Drawing.Point(157, 39);
            this.LProducto.Name = "LProducto";
            this.LProducto.Size = new System.Drawing.Size(191, 25);
            this.LProducto.TabIndex = 37;
            this.LProducto.Text = "Fecha de Compra:";
            // 
            // dtpFechaCompra
            // 
            this.dtpFechaCompra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCompra.Location = new System.Drawing.Point(182, 70);
            this.dtpFechaCompra.Name = "dtpFechaCompra";
            this.dtpFechaCompra.Size = new System.Drawing.Size(127, 22);
            this.dtpFechaCompra.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(524, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 25);
            this.label1.TabIndex = 38;
            this.label1.Text = "DNI Cliente:";
            // 
            // tbDNI
            // 
            this.tbDNI.Location = new System.Drawing.Point(496, 70);
            this.tbDNI.Margin = new System.Windows.Forms.Padding(4);
            this.tbDNI.Name = "tbDNI";
            this.tbDNI.Size = new System.Drawing.Size(181, 22);
            this.tbDNI.TabIndex = 35;
            this.tbDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoloNumeros_KeyPress);
            // 
            // bBuscar
            // 
            this.bBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.bBuscar.FlatAppearance.BorderSize = 0;
            this.bBuscar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBuscar.ForeColor = System.Drawing.SystemColors.Control;
            this.bBuscar.Location = new System.Drawing.Point(424, 155);
            this.bBuscar.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.bBuscar.Name = "bBuscar";
            this.bBuscar.Size = new System.Drawing.Size(164, 39);
            this.bBuscar.TabIndex = 40;
            this.bBuscar.Text = "Buscar";
            this.bBuscar.UseVisualStyleBackColor = false;
            this.bBuscar.Click += new System.EventHandler(this.bBuscar_Click);
            // 
            // bSalir
            // 
            this.bSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.bSalir.FlatAppearance.BorderSize = 0;
            this.bSalir.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSalir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bSalir.Location = new System.Drawing.Point(596, 155);
            this.bSalir.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.bSalir.Name = "bSalir";
            this.bSalir.Size = new System.Drawing.Size(164, 39);
            this.bSalir.TabIndex = 41;
            this.bSalir.Text = "Salir";
            this.bSalir.UseVisualStyleBackColor = false;
            this.bSalir.Click += new System.EventHandler(this.bSalir_Click);
            // 
            // dgvFacturasVendedor
            // 
            this.dgvFacturasVendedor.AllowUserToAddRows = false;
            this.dgvFacturasVendedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturasVendedor.Location = new System.Drawing.Point(24, 210);
            this.dgvFacturasVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.dgvFacturasVendedor.Name = "dgvFacturasVendedor";
            this.dgvFacturasVendedor.RowHeadersVisible = false;
            this.dgvFacturasVendedor.RowHeadersWidth = 51;
            this.dgvFacturasVendedor.Size = new System.Drawing.Size(1133, 312);
            this.dgvFacturasVendedor.TabIndex = 42;
            // 
            // DescargarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(1182, 544);
            this.Controls.Add(this.dgvFacturasVendedor);
            this.Controls.Add(this.bSalir);
            this.Controls.Add(this.bBuscar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DescargarFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DescargarFactura";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasVendedor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbDNI;
        private System.Windows.Forms.TextBox tbTotalPagado;
        private System.Windows.Forms.ComboBox cbMetodoDePago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LProducto;
        private System.Windows.Forms.Button bBuscar;
        private System.Windows.Forms.Button bSalir;
        private System.Windows.Forms.DataGridView dgvFacturasVendedor;
        private System.Windows.Forms.DateTimePicker dtpFechaCompra;
    }
}