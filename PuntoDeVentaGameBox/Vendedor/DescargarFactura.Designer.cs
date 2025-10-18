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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCorreo = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTelefono = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbBusquedaDNI = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LProducto = new System.Windows.Forms.Label();
            this.cbRol = new System.Windows.Forms.ComboBox();
            this.bNuevoCliente = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvFacturasVendedor = new System.Windows.Forms.DataGridView();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MetodoDePago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoPagado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasVendedor)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(11, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1137, 100);
            this.tableLayoutPanel1.TabIndex = 38;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.tbCorreo);
            this.panel4.Location = new System.Drawing.Point(288, 7);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(276, 86);
            this.panel4.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(94, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 25);
            this.label1.TabIndex = 38;
            this.label1.Text = "Cliente:";
            // 
            // tbCorreo
            // 
            this.tbCorreo.Location = new System.Drawing.Point(49, 43);
            this.tbCorreo.Margin = new System.Windows.Forms.Padding(4);
            this.tbCorreo.Name = "tbCorreo";
            this.tbCorreo.Size = new System.Drawing.Size(181, 22);
            this.tbCorreo.TabIndex = 35;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.tbTelefono);
            this.panel3.Location = new System.Drawing.Point(856, 7);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(277, 86);
            this.panel3.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(59, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 25);
            this.label3.TabIndex = 39;
            this.label3.Text = "Fecha de Compra:";
            // 
            // tbTelefono
            // 
            this.tbTelefono.Location = new System.Drawing.Point(64, 41);
            this.tbTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.tbTelefono.Name = "tbTelefono";
            this.tbTelefono.Size = new System.Drawing.Size(181, 22);
            this.tbTelefono.TabIndex = 35;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tbBusquedaDNI);
            this.panel2.Location = new System.Drawing.Point(572, 7);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(276, 86);
            this.panel2.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(55, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 25);
            this.label2.TabIndex = 38;
            this.label2.Text = "Metodo De Pago:";
            // 
            // tbBusquedaDNI
            // 
            this.tbBusquedaDNI.Location = new System.Drawing.Point(54, 41);
            this.tbBusquedaDNI.Margin = new System.Windows.Forms.Padding(4);
            this.tbBusquedaDNI.Name = "tbBusquedaDNI";
            this.tbBusquedaDNI.Size = new System.Drawing.Size(181, 22);
            this.tbBusquedaDNI.TabIndex = 35;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.LProducto);
            this.panel1.Controls.Add(this.cbRol);
            this.panel1.Location = new System.Drawing.Point(4, 7);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 86);
            this.panel1.TabIndex = 34;
            // 
            // LProducto
            // 
            this.LProducto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LProducto.AutoSize = true;
            this.LProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LProducto.ForeColor = System.Drawing.SystemColors.Control;
            this.LProducto.Location = new System.Drawing.Point(33, 12);
            this.LProducto.Name = "LProducto";
            this.LProducto.Size = new System.Drawing.Size(191, 25);
            this.LProducto.TabIndex = 37;
            this.LProducto.Text = "Fecha de Compra:";
            // 
            // cbRol
            // 
            this.cbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRol.FormattingEnabled = true;
            this.cbRol.Items.AddRange(new object[] {
            "Masculino",
            "Femenino"});
            this.cbRol.Location = new System.Drawing.Point(47, 41);
            this.cbRol.Margin = new System.Windows.Forms.Padding(4);
            this.cbRol.Name = "cbRol";
            this.cbRol.Size = new System.Drawing.Size(185, 24);
            this.cbRol.TabIndex = 36;
            // 
            // bNuevoCliente
            // 
            this.bNuevoCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.bNuevoCliente.FlatAppearance.BorderSize = 0;
            this.bNuevoCliente.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bNuevoCliente.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bNuevoCliente.Location = new System.Drawing.Point(424, 155);
            this.bNuevoCliente.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.bNuevoCliente.Name = "bNuevoCliente";
            this.bNuevoCliente.Size = new System.Drawing.Size(164, 39);
            this.bNuevoCliente.TabIndex = 40;
            this.bNuevoCliente.Text = "Buscar";
            this.bNuevoCliente.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(596, 155);
            this.button1.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 39);
            this.button1.TabIndex = 41;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // dgvFacturasVendedor
            // 
            this.dgvFacturasVendedor.AllowUserToAddRows = false;
            this.dgvFacturasVendedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturasVendedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fecha,
            this.MetodoDePago,
            this.montoPagado,
            this.Cliente});
            this.dgvFacturasVendedor.Location = new System.Drawing.Point(24, 210);
            this.dgvFacturasVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.dgvFacturasVendedor.Name = "dgvFacturasVendedor";
            this.dgvFacturasVendedor.RowHeadersVisible = false;
            this.dgvFacturasVendedor.RowHeadersWidth = 51;
            this.dgvFacturasVendedor.Size = new System.Drawing.Size(1133, 312);
            this.dgvFacturasVendedor.TabIndex = 42;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha";
            this.fecha.MinimumWidth = 6;
            this.fecha.Name = "fecha";
            this.fecha.Width = 125;
            // 
            // MetodoDePago
            // 
            this.MetodoDePago.HeaderText = "Metodo De Pago";
            this.MetodoDePago.MinimumWidth = 6;
            this.MetodoDePago.Name = "MetodoDePago";
            this.MetodoDePago.Width = 150;
            // 
            // montoPagado
            // 
            this.montoPagado.HeaderText = "Monto";
            this.montoPagado.MinimumWidth = 6;
            this.montoPagado.Name = "montoPagado";
            this.montoPagado.Width = 125;
            // 
            // Cliente
            // 
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.MinimumWidth = 6;
            this.Cliente.Name = "Cliente";
            this.Cliente.Width = 125;
            // 
            // DescargarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(1182, 544);
            this.Controls.Add(this.dgvFacturasVendedor);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bNuevoCliente);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DescargarFactura";
            this.Text = "DescargarFactura";
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasVendedor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tbCorreo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tbTelefono;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbBusquedaDNI;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbRol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LProducto;
        private System.Windows.Forms.Button bNuevoCliente;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvFacturasVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn MetodoDePago;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoPagado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
    }
}