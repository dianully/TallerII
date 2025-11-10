namespace PuntoDeVentaGameBox.Vendedor
{
    partial class Vendedor
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
            this.label11 = new System.Windows.Forms.Label();
            this.tbCantidad = new System.Windows.Forms.TextBox();
            this.bBuscarCliente = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.bCargarProducto = new System.Windows.Forms.Button();
            this.LTitle = new System.Windows.Forms.Label();
            this.bCobrar = new System.Windows.Forms.Button();
            this.bCerrar = new System.Windows.Forms.Button();
            this.dgvListaDeCompra = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lVendedor = new System.Windows.Forms.Label();
            this.lCantidad = new System.Windows.Forms.Label();
            this.bDescargarFactura = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbNombreProducto = new System.Windows.Forms.TextBox();
            this.bElegirProducto = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.panelCliente = new System.Windows.Forms.Panel();
            this.bReestablecer = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbGenero = new System.Windows.Forms.TextBox();
            this.tbDNI = new System.Windows.Forms.TextBox();
            this.tbNombreCliente = new System.Windows.Forms.TextBox();
            this.lNombreCliente = new System.Windows.Forms.Label();
            this.bNuevoCliente = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.tbMontoPagado = new System.Windows.Forms.TextBox();
            this.cbMetodoDePago = new System.Windows.Forms.ComboBox();
            this.tbCambio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaDeCompra)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panelCliente.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.Control;
            this.label11.Location = new System.Drawing.Point(42, 626);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(177, 25);
            this.label11.TabIndex = 39;
            this.label11.Text = "Metodo de Pago:";
            // 
            // tbCantidad
            // 
            this.tbCantidad.Location = new System.Drawing.Point(313, 96);
            this.tbCantidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbCantidad.Name = "tbCantidad";
            this.tbCantidad.Size = new System.Drawing.Size(154, 22);
            this.tbCantidad.TabIndex = 17;
            this.tbCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoloNumeros_KeyPress);
            // 
            // bBuscarCliente
            // 
            this.bBuscarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.bBuscarCliente.FlatAppearance.BorderSize = 0;
            this.bBuscarCliente.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBuscarCliente.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bBuscarCliente.Location = new System.Drawing.Point(172, 53);
            this.bBuscarCliente.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.bBuscarCliente.Name = "bBuscarCliente";
            this.bBuscarCliente.Size = new System.Drawing.Size(169, 39);
            this.bBuscarCliente.TabIndex = 27;
            this.bBuscarCliente.Text = "Buscar Cliente";
            this.bBuscarCliente.UseVisualStyleBackColor = false;
            this.bBuscarCliente.Click += new System.EventHandler(this.bBuscarCliente_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(176, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 25);
            this.label5.TabIndex = 25;
            this.label5.Text = "Cantidad:";
            // 
            // bCargarProducto
            // 
            this.bCargarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.bCargarProducto.FlatAppearance.BorderSize = 0;
            this.bCargarProducto.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCargarProducto.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bCargarProducto.Location = new System.Drawing.Point(133, 126);
            this.bCargarProducto.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.bCargarProducto.Name = "bCargarProducto";
            this.bCargarProducto.Size = new System.Drawing.Size(179, 39);
            this.bCargarProducto.TabIndex = 24;
            this.bCargarProducto.Text = "Cargar Producto";
            this.bCargarProducto.UseVisualStyleBackColor = false;
            this.bCargarProducto.Click += new System.EventHandler(this.bCargarProducto_Click);
            // 
            // LTitle
            // 
            this.LTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LTitle.AutoSize = true;
            this.LTitle.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.LTitle.Location = new System.Drawing.Point(39, 667);
            this.LTitle.Name = "LTitle";
            this.LTitle.Size = new System.Drawing.Size(105, 45);
            this.LTitle.TabIndex = 20;
            this.LTitle.Text = "Total:";
            // 
            // bCobrar
            // 
            this.bCobrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.bCobrar.FlatAppearance.BorderSize = 0;
            this.bCobrar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCobrar.ForeColor = System.Drawing.SystemColors.Control;
            this.bCobrar.Location = new System.Drawing.Point(740, 643);
            this.bCobrar.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.bCobrar.Name = "bCobrar";
            this.bCobrar.Size = new System.Drawing.Size(114, 39);
            this.bCobrar.TabIndex = 21;
            this.bCobrar.Text = "Cobrar";
            this.bCobrar.UseVisualStyleBackColor = false;
            this.bCobrar.Click += new System.EventHandler(this.bCobrar_Click);
            // 
            // bCerrar
            // 
            this.bCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.bCerrar.FlatAppearance.BorderSize = 0;
            this.bCerrar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCerrar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.bCerrar.Location = new System.Drawing.Point(981, 643);
            this.bCerrar.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.bCerrar.Name = "bCerrar";
            this.bCerrar.Size = new System.Drawing.Size(114, 39);
            this.bCerrar.TabIndex = 22;
            this.bCerrar.Text = "Cerrar";
            this.bCerrar.UseVisualStyleBackColor = false;
            this.bCerrar.Click += new System.EventHandler(this.bCerrar_Click);
            // 
            // dgvListaDeCompra
            // 
            this.dgvListaDeCompra.AllowUserToAddRows = false;
            this.dgvListaDeCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaDeCompra.Location = new System.Drawing.Point(47, 251);
            this.dgvListaDeCompra.Margin = new System.Windows.Forms.Padding(4);
            this.dgvListaDeCompra.Name = "dgvListaDeCompra";
            this.dgvListaDeCompra.RowHeadersVisible = false;
            this.dgvListaDeCompra.RowHeadersWidth = 51;
            this.dgvListaDeCompra.Size = new System.Drawing.Size(1048, 359);
            this.dgvListaDeCompra.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(190, 565);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 45);
            this.label1.TabIndex = 24;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.lVendedor);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1182, 51);
            this.panel4.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(283, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(279, 38);
            this.label3.TabIndex = 3;
            this.label3.Text = "Panel del Vendedor:";
            // 
            // lVendedor
            // 
            this.lVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lVendedor.AutoSize = true;
            this.lVendedor.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lVendedor.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lVendedor.Location = new System.Drawing.Point(568, 9);
            this.lVendedor.Name = "lVendedor";
            this.lVendedor.Size = new System.Drawing.Size(163, 38);
            this.lVendedor.TabIndex = 1;
            this.lVendedor.Text = "(Vendedor)";
            this.lVendedor.Click += new System.EventHandler(this.lVendedor_Click_1);
            // 
            // lCantidad
            // 
            this.lCantidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lCantidad.AutoSize = true;
            this.lCantidad.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCantidad.ForeColor = System.Drawing.SystemColors.Control;
            this.lCantidad.Location = new System.Drawing.Point(145, 667);
            this.lCantidad.Name = "lCantidad";
            this.lCantidad.Size = new System.Drawing.Size(183, 45);
            this.lCantidad.TabIndex = 26;
            this.lCantidad.Text = "(Cantidad)";
            // 
            // bDescargarFactura
            // 
            this.bDescargarFactura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.bDescargarFactura.FlatAppearance.BorderSize = 0;
            this.bDescargarFactura.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bDescargarFactura.ForeColor = System.Drawing.SystemColors.Control;
            this.bDescargarFactura.Location = new System.Drawing.Point(862, 643);
            this.bDescargarFactura.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.bDescargarFactura.Name = "bDescargarFactura";
            this.bDescargarFactura.Size = new System.Drawing.Size(114, 39);
            this.bDescargarFactura.TabIndex = 43;
            this.bDescargarFactura.Text = "Facturas";
            this.bDescargarFactura.UseVisualStyleBackColor = false;
            this.bDescargarFactura.Click += new System.EventHandler(this.bDescargarFactura_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbNombreProducto);
            this.panel2.Controls.Add(this.bElegirProducto);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.bCargarProducto);
            this.panel2.Controls.Add(this.tbCantidad);
            this.panel2.Location = new System.Drawing.Point(47, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(515, 175);
            this.panel2.TabIndex = 44;
            // 
            // tbNombreProducto
            // 
            this.tbNombreProducto.Location = new System.Drawing.Point(313, 59);
            this.tbNombreProducto.Name = "tbNombreProducto";
            this.tbNombreProducto.ReadOnly = true;
            this.tbNombreProducto.Size = new System.Drawing.Size(154, 22);
            this.tbNombreProducto.TabIndex = 48;
            this.tbNombreProducto.TabStop = false;
            this.tbNombreProducto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtBloqueado_MouseDown);
            // 
            // bElegirProducto
            // 
            this.bElegirProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.bElegirProducto.FlatAppearance.BorderSize = 0;
            this.bElegirProducto.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bElegirProducto.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bElegirProducto.Location = new System.Drawing.Point(15, 55);
            this.bElegirProducto.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.bElegirProducto.Name = "bElegirProducto";
            this.bElegirProducto.Size = new System.Drawing.Size(128, 67);
            this.bElegirProducto.TabIndex = 38;
            this.bElegirProducto.Text = "Elegir producto";
            this.bElegirProducto.UseVisualStyleBackColor = false;
            this.bElegirProducto.Click += new System.EventHandler(this.bElegirProducto_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(187, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 25);
            this.label4.TabIndex = 37;
            this.label4.Text = "Nombre:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label12);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(515, 48);
            this.panel5.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Location = new System.Drawing.Point(76, 2);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(354, 38);
            this.label12.TabIndex = 4;
            this.label12.Text = "Informacion del Producto";
            // 
            // panelCliente
            // 
            this.panelCliente.Controls.Add(this.bReestablecer);
            this.panelCliente.Controls.Add(this.label6);
            this.panelCliente.Controls.Add(this.label2);
            this.panelCliente.Controls.Add(this.tbGenero);
            this.panelCliente.Controls.Add(this.tbDNI);
            this.panelCliente.Controls.Add(this.tbNombreCliente);
            this.panelCliente.Controls.Add(this.lNombreCliente);
            this.panelCliente.Controls.Add(this.bNuevoCliente);
            this.panelCliente.Controls.Add(this.bBuscarCliente);
            this.panelCliente.Controls.Add(this.panel6);
            this.panelCliente.Location = new System.Drawing.Point(568, 62);
            this.panelCliente.Name = "panelCliente";
            this.panelCliente.Size = new System.Drawing.Size(527, 175);
            this.panelCliente.TabIndex = 45;
            // 
            // bReestablecer
            // 
            this.bReestablecer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.bReestablecer.FlatAppearance.BorderSize = 0;
            this.bReestablecer.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bReestablecer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bReestablecer.Location = new System.Drawing.Point(359, 53);
            this.bReestablecer.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.bReestablecer.Name = "bReestablecer";
            this.bReestablecer.Size = new System.Drawing.Size(151, 39);
            this.bReestablecer.TabIndex = 52;
            this.bReestablecer.Text = "Reestablecer";
            this.bReestablecer.UseVisualStyleBackColor = false;
            this.bReestablecer.Click += new System.EventHandler(this.bReestablecer_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(251, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 25);
            this.label6.TabIndex = 51;
            this.label6.Text = "Genero:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(48, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 25);
            this.label2.TabIndex = 50;
            this.label2.Text = "DNI:";
            // 
            // tbGenero
            // 
            this.tbGenero.Location = new System.Drawing.Point(358, 136);
            this.tbGenero.Name = "tbGenero";
            this.tbGenero.ReadOnly = true;
            this.tbGenero.Size = new System.Drawing.Size(94, 22);
            this.tbGenero.TabIndex = 49;
            this.tbGenero.TabStop = false;
            this.tbGenero.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtBloqueado_MouseDown);
            // 
            // tbDNI
            // 
            this.tbDNI.Location = new System.Drawing.Point(121, 136);
            this.tbDNI.Name = "tbDNI";
            this.tbDNI.ReadOnly = true;
            this.tbDNI.Size = new System.Drawing.Size(94, 22);
            this.tbDNI.TabIndex = 48;
            this.tbDNI.TabStop = false;
            this.tbDNI.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtBloqueado_MouseDown);
            // 
            // tbNombreCliente
            // 
            this.tbNombreCliente.Location = new System.Drawing.Point(267, 101);
            this.tbNombreCliente.Name = "tbNombreCliente";
            this.tbNombreCliente.ReadOnly = true;
            this.tbNombreCliente.Size = new System.Drawing.Size(187, 22);
            this.tbNombreCliente.TabIndex = 48;
            this.tbNombreCliente.TabStop = false;
            this.tbNombreCliente.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtBloqueado_MouseDown);
            // 
            // lNombreCliente
            // 
            this.lNombreCliente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lNombreCliente.AutoSize = true;
            this.lNombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNombreCliente.ForeColor = System.Drawing.SystemColors.Control;
            this.lNombreCliente.Location = new System.Drawing.Point(37, 97);
            this.lNombreCliente.Name = "lNombreCliente";
            this.lNombreCliente.Size = new System.Drawing.Size(192, 25);
            this.lNombreCliente.TabIndex = 39;
            this.lNombreCliente.Text = "Nombre Completo:";
            // 
            // bNuevoCliente
            // 
            this.bNuevoCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.bNuevoCliente.FlatAppearance.BorderSize = 0;
            this.bNuevoCliente.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bNuevoCliente.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bNuevoCliente.Location = new System.Drawing.Point(0, 53);
            this.bNuevoCliente.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.bNuevoCliente.Name = "bNuevoCliente";
            this.bNuevoCliente.Size = new System.Drawing.Size(153, 39);
            this.bNuevoCliente.TabIndex = 34;
            this.bNuevoCliente.Text = "Nuevo Cliente";
            this.bNuevoCliente.UseVisualStyleBackColor = false;
            this.bNuevoCliente.Click += new System.EventHandler(this.bNuevoCliente_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label13);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(527, 48);
            this.panel6.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label13.Location = new System.Drawing.Point(97, 2);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(325, 38);
            this.label13.TabIndex = 4;
            this.label13.Text = "Informacion del Cliente";
            // 
            // tbMontoPagado
            // 
            this.tbMontoPagado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMontoPagado.Location = new System.Drawing.Point(539, 626);
            this.tbMontoPagado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbMontoPagado.Multiline = true;
            this.tbMontoPagado.Name = "tbMontoPagado";
            this.tbMontoPagado.Size = new System.Drawing.Size(192, 33);
            this.tbMontoPagado.TabIndex = 35;
            this.tbMontoPagado.TextChanged += new System.EventHandler(this.tbMontoPagado_TextChanged);
            this.tbMontoPagado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoloNumeros_KeyPress);
            // 
            // cbMetodoDePago
            // 
            this.cbMetodoDePago.FormattingEnabled = true;
            this.cbMetodoDePago.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta"});
            this.cbMetodoDePago.Location = new System.Drawing.Point(213, 630);
            this.cbMetodoDePago.Name = "cbMetodoDePago";
            this.cbMetodoDePago.Size = new System.Drawing.Size(161, 24);
            this.cbMetodoDePago.TabIndex = 47;
            this.cbMetodoDePago.SelectedIndexChanged += new System.EventHandler(this.cbMetodoDePago_SelectedIndexChanged);
            // 
            // tbCambio
            // 
            this.tbCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCambio.Location = new System.Drawing.Point(539, 676);
            this.tbCambio.Multiline = true;
            this.tbCambio.Name = "tbCambio";
            this.tbCambio.Size = new System.Drawing.Size(192, 33);
            this.tbCambio.TabIndex = 48;
            this.tbCambio.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtBloqueado_MouseDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(447, 630);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 25);
            this.label7.TabIndex = 49;
            this.label7.Text = "Abono:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(447, 676);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 25);
            this.label8.TabIndex = 50;
            this.label8.Text = "Cambio:";
            // 
            // Vendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(1182, 721);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbCambio);
            this.Controls.Add(this.cbMetodoDePago);
            this.Controls.Add(this.tbMontoPagado);
            this.Controls.Add(this.panelCliente);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.bDescargarFactura);
            this.Controls.Add(this.lCantidad);
            this.Controls.Add(this.LTitle);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvListaDeCompra);
            this.Controls.Add(this.bCerrar);
            this.Controls.Add(this.bCobrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Vendedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vendedor";
            this.Load += new System.EventHandler(this.Vendedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaDeCompra)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panelCliente.ResumeLayout(false);
            this.panelCliente.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbCantidad;
        private System.Windows.Forms.Label LTitle;
        private System.Windows.Forms.Button bCobrar;
        private System.Windows.Forms.Button bCerrar;
        private System.Windows.Forms.DataGridView dgvListaDeCompra;
        private System.Windows.Forms.Button bCargarProducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lVendedor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lCantidad;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button bBuscarCliente;
        private System.Windows.Forms.Button bDescargarFactura;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panelCliente;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbMontoPagado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bElegirProducto;
        private System.Windows.Forms.ComboBox cbMetodoDePago;
        private System.Windows.Forms.Button bNuevoCliente;
        private System.Windows.Forms.Label lNombreCliente;
        private System.Windows.Forms.TextBox tbNombreProducto;
        private System.Windows.Forms.TextBox tbNombreCliente;
        private System.Windows.Forms.TextBox tbDNI;
        private System.Windows.Forms.TextBox tbGenero;
        private System.Windows.Forms.TextBox tbCambio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bReestablecer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}