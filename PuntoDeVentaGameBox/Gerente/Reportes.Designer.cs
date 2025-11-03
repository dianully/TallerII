namespace PuntoDeVentaGameBox.Gerente
{
    partial class Reportes
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
            this.TPLRoot = new System.Windows.Forms.TableLayoutPanel();
            this.PNLScroll = new System.Windows.Forms.Panel();
            this.TLPContent = new System.Windows.Forms.TableLayoutPanel();
            this.PVentas = new System.Windows.Forms.Panel();
            this.LResumenTitulo = new System.Windows.Forms.Label();
            this.TPLVentas = new System.Windows.Forms.TableLayoutPanel();
            this.PCardTotal = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.LPesosTotalDinero = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PCardVentas = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.LNroVentas = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PCardTicket = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.LTicketPromedio = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PCardProductos = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.LCantProductos = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.GVTopProductos = new System.Windows.Forms.GroupBox();
            this.BMasVendidosExtendido = new System.Windows.Forms.Button();
            this.DGVTopProductos = new System.Windows.Forms.DataGridView();
            this.DGVProductoCVideojuego = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVProductoCUnidadesVendidas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVProductoCIngresos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GVVendedores = new System.Windows.Forms.GroupBox();
            this.BRendimientosExtendido = new System.Windows.Forms.Button();
            this.DGVVendedores = new System.Windows.Forms.DataGridView();
            this.DGVVendedoresCVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVProductoCTotalDineroenVentas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVProductoCVentas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVProductoCTicketPromedio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TPLBotonesGraficos = new System.Windows.Forms.TableLayoutPanel();
            this.BVerGraficosVendedores = new System.Windows.Forms.Button();
            this.BVerGraficosProductos = new System.Windows.Forms.Button();
            this.GBPeriodo = new System.Windows.Forms.GroupBox();
            this.TLPPeriodo = new System.Windows.Forms.TableLayoutPanel();
            this.LDesde = new System.Windows.Forms.Label();
            this.LHasta = new System.Windows.Forms.Label();
            this.DTPDesde = new System.Windows.Forms.DateTimePicker();
            this.DTPHasta = new System.Windows.Forms.DateTimePicker();
            this.BLimpiar = new System.Windows.Forms.Button();
            this.LTipoPeriodo = new System.Windows.Forms.Label();
            this.CBTipoPeriodo = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BExportarExcel = new System.Windows.Forms.Button();
            this.BExportarPDF = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.TPLRoot.SuspendLayout();
            this.PNLScroll.SuspendLayout();
            this.TLPContent.SuspendLayout();
            this.PVentas.SuspendLayout();
            this.TPLVentas.SuspendLayout();
            this.PCardTotal.SuspendLayout();
            this.PCardVentas.SuspendLayout();
            this.PCardTicket.SuspendLayout();
            this.PCardProductos.SuspendLayout();
            this.GVTopProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTopProductos)).BeginInit();
            this.GVVendedores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVVendedores)).BeginInit();
            this.TPLBotonesGraficos.SuspendLayout();
            this.GBPeriodo.SuspendLayout();
            this.TLPPeriodo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TPLRoot
            // 
            this.TPLRoot.ColumnCount = 1;
            this.TPLRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TPLRoot.Controls.Add(this.PNLScroll, 0, 0);
            this.TPLRoot.Location = new System.Drawing.Point(12, 0);
            this.TPLRoot.Name = "TPLRoot";
            this.TPLRoot.RowCount = 1;
            this.TPLRoot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TPLRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 720F));
            this.TPLRoot.Size = new System.Drawing.Size(902, 731);
            this.TPLRoot.TabIndex = 0;
            this.TPLRoot.Paint += new System.Windows.Forms.PaintEventHandler(this.TPLRoot_Paint);
            // 
            // PNLScroll
            // 
            this.PNLScroll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PNLScroll.AutoScroll = true;
            this.PNLScroll.Controls.Add(this.TLPContent);
            this.PNLScroll.Location = new System.Drawing.Point(11, 4);
            this.PNLScroll.Name = "PNLScroll";
            this.PNLScroll.Padding = new System.Windows.Forms.Padding(16);
            this.PNLScroll.Size = new System.Drawing.Size(880, 723);
            this.PNLScroll.TabIndex = 3;
            this.PNLScroll.Paint += new System.Windows.Forms.PaintEventHandler(this.PNLScroll_Paint);
            // 
            // TLPContent
            // 
            this.TLPContent.AutoScroll = true;
            this.TLPContent.AutoSize = true;
            this.TLPContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TLPContent.ColumnCount = 1;
            this.TLPContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPContent.Controls.Add(this.PVentas, 0, 1);
            this.TLPContent.Controls.Add(this.GVTopProductos, 0, 2);
            this.TLPContent.Controls.Add(this.GVVendedores, 0, 3);
            this.TLPContent.Controls.Add(this.TPLBotonesGraficos, 0, 4);
            this.TLPContent.Controls.Add(this.GBPeriodo, 0, 0);
            this.TLPContent.Controls.Add(this.panel1, 0, 5);
            this.TLPContent.Location = new System.Drawing.Point(0, 0);
            this.TLPContent.Name = "TLPContent";
            this.TLPContent.RowCount = 6;
            this.TLPContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.TLPContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.TLPContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.TLPContent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.TLPContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.TLPContent.Size = new System.Drawing.Size(860, 725);
            this.TLPContent.TabIndex = 0;
            this.TLPContent.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // PVentas
            // 
            this.PVentas.Controls.Add(this.LResumenTitulo);
            this.PVentas.Controls.Add(this.TPLVentas);
            this.PVentas.Location = new System.Drawing.Point(3, 185);
            this.PVentas.Name = "PVentas";
            this.PVentas.Size = new System.Drawing.Size(851, 117);
            this.PVentas.TabIndex = 3;
            // 
            // LResumenTitulo
            // 
            this.LResumenTitulo.AutoSize = true;
            this.LResumenTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LResumenTitulo.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LResumenTitulo.ForeColor = System.Drawing.SystemColors.Control;
            this.LResumenTitulo.Location = new System.Drawing.Point(0, 0);
            this.LResumenTitulo.Name = "LResumenTitulo";
            this.LResumenTitulo.Size = new System.Drawing.Size(220, 31);
            this.LResumenTitulo.TabIndex = 1;
            this.LResumenTitulo.Text = "Resumen de Ventas";
            this.LResumenTitulo.Click += new System.EventHandler(this.LResumenTitulo_Click);
            // 
            // TPLVentas
            // 
            this.TPLVentas.AutoSize = true;
            this.TPLVentas.ColumnCount = 4;
            this.TPLVentas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TPLVentas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TPLVentas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TPLVentas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TPLVentas.Controls.Add(this.PCardTotal, 0, 0);
            this.TPLVentas.Controls.Add(this.PCardVentas, 1, 0);
            this.TPLVentas.Controls.Add(this.PCardTicket, 2, 0);
            this.TPLVentas.Controls.Add(this.PCardProductos, 3, 0);
            this.TPLVentas.Location = new System.Drawing.Point(6, 31);
            this.TPLVentas.Margin = new System.Windows.Forms.Padding(0);
            this.TPLVentas.Name = "TPLVentas";
            this.TPLVentas.RowCount = 1;
            this.TPLVentas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.TPLVentas.Size = new System.Drawing.Size(836, 90);
            this.TPLVentas.TabIndex = 2;
            // 
            // PCardTotal
            // 
            this.PCardTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PCardTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.PCardTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PCardTotal.Controls.Add(this.label3);
            this.PCardTotal.Controls.Add(this.LPesosTotalDinero);
            this.PCardTotal.Controls.Add(this.label1);
            this.PCardTotal.ForeColor = System.Drawing.SystemColors.Control;
            this.PCardTotal.Location = new System.Drawing.Point(4, 5);
            this.PCardTotal.Name = "PCardTotal";
            this.PCardTotal.Size = new System.Drawing.Size(200, 80);
            this.PCardTotal.TabIndex = 0;
            this.PCardTotal.Paint += new System.Windows.Forms.PaintEventHandler(this.PCardTotal_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-4, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "+11% vs período anterior";
            // 
            // LPesosTotalDinero
            // 
            this.LPesosTotalDinero.AutoSize = true;
            this.LPesosTotalDinero.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPesosTotalDinero.Location = new System.Drawing.Point(45, 23);
            this.LPesosTotalDinero.Name = "LPesosTotalDinero";
            this.LPesosTotalDinero.Size = new System.Drawing.Size(101, 28);
            this.LPesosTotalDinero.TabIndex = 1;
            this.LPesosTotalDinero.Text = "$847,250";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Dinero en Ventas";
            // 
            // PCardVentas
            // 
            this.PCardVentas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PCardVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(82)))), ((int)(((byte)(77)))));
            this.PCardVentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PCardVentas.Controls.Add(this.label6);
            this.PCardVentas.Controls.Add(this.LNroVentas);
            this.PCardVentas.Controls.Add(this.label4);
            this.PCardVentas.ForeColor = System.Drawing.SystemColors.Control;
            this.PCardVentas.Location = new System.Drawing.Point(213, 7);
            this.PCardVentas.Name = "PCardVentas";
            this.PCardVentas.Size = new System.Drawing.Size(200, 76);
            this.PCardVentas.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-4, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(207, 23);
            this.label6.TabIndex = 2;
            this.label6.Text = "+8.3% vs período anterior";
            // 
            // LNroVentas
            // 
            this.LNroVentas.AutoSize = true;
            this.LNroVentas.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNroVentas.Location = new System.Drawing.Point(67, 21);
            this.LNroVentas.Name = "LNroVentas";
            this.LNroVentas.Size = new System.Drawing.Size(72, 31);
            this.LNroVentas.TabIndex = 1;
            this.LNroVentas.Text = "1,247";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Numero de Ventas";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // PCardTicket
            // 
            this.PCardTicket.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PCardTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.PCardTicket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PCardTicket.Controls.Add(this.label9);
            this.PCardTicket.Controls.Add(this.LTicketPromedio);
            this.PCardTicket.Controls.Add(this.label7);
            this.PCardTicket.ForeColor = System.Drawing.SystemColors.Control;
            this.PCardTicket.Location = new System.Drawing.Point(422, 3);
            this.PCardTicket.Name = "PCardTicket";
            this.PCardTicket.Size = new System.Drawing.Size(200, 84);
            this.PCardTicket.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(-5, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(207, 23);
            this.label9.TabIndex = 2;
            this.label9.Text = "+3.2% vs período anterior";
            // 
            // LTicketPromedio
            // 
            this.LTicketPromedio.AutoSize = true;
            this.LTicketPromedio.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTicketPromedio.Location = new System.Drawing.Point(56, 27);
            this.LTicketPromedio.Name = "LTicketPromedio";
            this.LTicketPromedio.Size = new System.Drawing.Size(98, 31);
            this.LTicketPromedio.TabIndex = 1;
            this.LTicketPromedio.Text = "$679.50";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(34, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ticket Promedio";
            // 
            // PCardProductos
            // 
            this.PCardProductos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PCardProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(82)))), ((int)(((byte)(77)))));
            this.PCardProductos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PCardProductos.Controls.Add(this.label12);
            this.PCardProductos.Controls.Add(this.LCantProductos);
            this.PCardProductos.Controls.Add(this.label10);
            this.PCardProductos.ForeColor = System.Drawing.SystemColors.Control;
            this.PCardProductos.Location = new System.Drawing.Point(632, 3);
            this.PCardProductos.Name = "PCardProductos";
            this.PCardProductos.Size = new System.Drawing.Size(199, 83);
            this.PCardProductos.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(172, 23);
            this.label12.TabIndex = 2;
            this.label12.Text = "+5 nuevos productos";
            // 
            // LCantProductos
            // 
            this.LCantProductos.AutoSize = true;
            this.LCantProductos.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCantProductos.Location = new System.Drawing.Point(69, 25);
            this.LCantProductos.Name = "LCantProductos";
            this.LCantProductos.Size = new System.Drawing.Size(53, 31);
            this.LCantProductos.TabIndex = 1;
            this.LCantProductos.Text = "127";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(52, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 23);
            this.label10.TabIndex = 0;
            this.label10.Text = "Productos ";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // GVTopProductos
            // 
            this.GVTopProductos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.GVTopProductos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GVTopProductos.Controls.Add(this.BMasVendidosExtendido);
            this.GVTopProductos.Controls.Add(this.DGVTopProductos);
            this.GVTopProductos.ForeColor = System.Drawing.SystemColors.Control;
            this.GVTopProductos.Location = new System.Drawing.Point(10, 308);
            this.GVTopProductos.Name = "GVTopProductos";
            this.GVTopProductos.Size = new System.Drawing.Size(839, 124);
            this.GVTopProductos.TabIndex = 4;
            this.GVTopProductos.TabStop = false;
            this.GVTopProductos.Text = "Productos Mas Vendidos";
            this.GVTopProductos.Enter += new System.EventHandler(this.GVTopProductos_Enter);
            // 
            // BMasVendidosExtendido
            // 
            this.BMasVendidosExtendido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.BMasVendidosExtendido.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BMasVendidosExtendido.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BMasVendidosExtendido.Location = new System.Drawing.Point(666, 1);
            this.BMasVendidosExtendido.Name = "BMasVendidosExtendido";
            this.BMasVendidosExtendido.Size = new System.Drawing.Size(137, 41);
            this.BMasVendidosExtendido.TabIndex = 1;
            this.BMasVendidosExtendido.Text = "Expandir";
            this.BMasVendidosExtendido.UseVisualStyleBackColor = false;
            // 
            // DGVTopProductos
            // 
            this.DGVTopProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVTopProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVTopProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGVProductoCVideojuego,
            this.DGVProductoCUnidadesVendidas,
            this.DGVProductoCIngresos});
            this.DGVTopProductos.Location = new System.Drawing.Point(3, 41);
            this.DGVTopProductos.Name = "DGVTopProductos";
            this.DGVTopProductos.ReadOnly = true;
            this.DGVTopProductos.RowHeadersVisible = false;
            this.DGVTopProductos.RowHeadersWidth = 51;
            this.DGVTopProductos.RowTemplate.Height = 24;
            this.DGVTopProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVTopProductos.Size = new System.Drawing.Size(834, 80);
            this.DGVTopProductos.TabIndex = 0;
            // 
            // DGVProductoCVideojuego
            // 
            this.DGVProductoCVideojuego.HeaderText = "Videojuego";
            this.DGVProductoCVideojuego.MinimumWidth = 6;
            this.DGVProductoCVideojuego.Name = "DGVProductoCVideojuego";
            this.DGVProductoCVideojuego.ReadOnly = true;
            // 
            // DGVProductoCUnidadesVendidas
            // 
            this.DGVProductoCUnidadesVendidas.HeaderText = "Unidades Vendidas";
            this.DGVProductoCUnidadesVendidas.MinimumWidth = 6;
            this.DGVProductoCUnidadesVendidas.Name = "DGVProductoCUnidadesVendidas";
            this.DGVProductoCUnidadesVendidas.ReadOnly = true;
            // 
            // DGVProductoCIngresos
            // 
            this.DGVProductoCIngresos.HeaderText = "Ingresos";
            this.DGVProductoCIngresos.MinimumWidth = 6;
            this.DGVProductoCIngresos.Name = "DGVProductoCIngresos";
            this.DGVProductoCIngresos.ReadOnly = true;
            // 
            // GVVendedores
            // 
            this.GVVendedores.Controls.Add(this.BRendimientosExtendido);
            this.GVVendedores.Controls.Add(this.DGVVendedores);
            this.GVVendedores.ForeColor = System.Drawing.SystemColors.Control;
            this.GVVendedores.Location = new System.Drawing.Point(3, 438);
            this.GVVendedores.Name = "GVVendedores";
            this.GVVendedores.Size = new System.Drawing.Size(840, 136);
            this.GVVendedores.TabIndex = 5;
            this.GVVendedores.TabStop = false;
            this.GVVendedores.Text = "Rendimientos por Vendedor";
            // 
            // BRendimientosExtendido
            // 
            this.BRendimientosExtendido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.BRendimientosExtendido.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BRendimientosExtendido.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BRendimientosExtendido.Location = new System.Drawing.Point(673, 0);
            this.BRendimientosExtendido.Name = "BRendimientosExtendido";
            this.BRendimientosExtendido.Size = new System.Drawing.Size(137, 41);
            this.BRendimientosExtendido.TabIndex = 2;
            this.BRendimientosExtendido.Text = "Expandir";
            this.BRendimientosExtendido.UseVisualStyleBackColor = false;
            // 
            // DGVVendedores
            // 
            this.DGVVendedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVVendedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGVVendedoresCVendedor,
            this.DGVProductoCTotalDineroenVentas,
            this.DGVProductoCVentas,
            this.DGVProductoCTicketPromedio});
            this.DGVVendedores.Location = new System.Drawing.Point(5, 43);
            this.DGVVendedores.Name = "DGVVendedores";
            this.DGVVendedores.ReadOnly = true;
            this.DGVVendedores.RowHeadersVisible = false;
            this.DGVVendedores.RowHeadersWidth = 51;
            this.DGVVendedores.RowTemplate.Height = 24;
            this.DGVVendedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVVendedores.Size = new System.Drawing.Size(832, 106);
            this.DGVVendedores.TabIndex = 0;
            // 
            // DGVVendedoresCVendedor
            // 
            this.DGVVendedoresCVendedor.HeaderText = "Vendedor";
            this.DGVVendedoresCVendedor.MinimumWidth = 6;
            this.DGVVendedoresCVendedor.Name = "DGVVendedoresCVendedor";
            this.DGVVendedoresCVendedor.ReadOnly = true;
            // 
            // DGVProductoCTotalDineroenVentas
            // 
            this.DGVProductoCTotalDineroenVentas.HeaderText = "Total Dinero en Ventas";
            this.DGVProductoCTotalDineroenVentas.MinimumWidth = 6;
            this.DGVProductoCTotalDineroenVentas.Name = "DGVProductoCTotalDineroenVentas";
            this.DGVProductoCTotalDineroenVentas.ReadOnly = true;
            // 
            // DGVProductoCVentas
            // 
            this.DGVProductoCVentas.HeaderText = "Ventas";
            this.DGVProductoCVentas.MinimumWidth = 6;
            this.DGVProductoCVentas.Name = "DGVProductoCVentas";
            this.DGVProductoCVentas.ReadOnly = true;
            // 
            // DGVProductoCTicketPromedio
            // 
            this.DGVProductoCTicketPromedio.HeaderText = "Ticket Promedio";
            this.DGVProductoCTicketPromedio.MinimumWidth = 6;
            this.DGVProductoCTicketPromedio.Name = "DGVProductoCTicketPromedio";
            this.DGVProductoCTicketPromedio.ReadOnly = true;
            // 
            // TPLBotonesGraficos
            // 
            this.TPLBotonesGraficos.ColumnCount = 2;
            this.TPLBotonesGraficos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TPLBotonesGraficos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TPLBotonesGraficos.Controls.Add(this.BVerGraficosVendedores, 1, 0);
            this.TPLBotonesGraficos.Controls.Add(this.BVerGraficosProductos, 0, 0);
            this.TPLBotonesGraficos.Location = new System.Drawing.Point(3, 580);
            this.TPLBotonesGraficos.Name = "TPLBotonesGraficos";
            this.TPLBotonesGraficos.RowCount = 1;
            this.TPLBotonesGraficos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TPLBotonesGraficos.Size = new System.Drawing.Size(845, 38);
            this.TPLBotonesGraficos.TabIndex = 6;
            // 
            // BVerGraficosVendedores
            // 
            this.BVerGraficosVendedores.Location = new System.Drawing.Point(425, 3);
            this.BVerGraficosVendedores.Name = "BVerGraficosVendedores";
            this.BVerGraficosVendedores.Size = new System.Drawing.Size(417, 32);
            this.BVerGraficosVendedores.TabIndex = 3;
            this.BVerGraficosVendedores.Text = "Ver Graficos de Vendedores";
            this.BVerGraficosVendedores.UseVisualStyleBackColor = true;
            // 
            // BVerGraficosProductos
            // 
            this.BVerGraficosProductos.Location = new System.Drawing.Point(3, 3);
            this.BVerGraficosProductos.Name = "BVerGraficosProductos";
            this.BVerGraficosProductos.Size = new System.Drawing.Size(415, 32);
            this.BVerGraficosProductos.TabIndex = 6;
            this.BVerGraficosProductos.Text = "Ver Graficos de Ventas";
            this.BVerGraficosProductos.UseVisualStyleBackColor = true;
            // 
            // GBPeriodo
            // 
            this.GBPeriodo.Controls.Add(this.TLPPeriodo);
            this.GBPeriodo.ForeColor = System.Drawing.SystemColors.Control;
            this.GBPeriodo.Location = new System.Drawing.Point(8, 8);
            this.GBPeriodo.Margin = new System.Windows.Forms.Padding(8);
            this.GBPeriodo.Name = "GBPeriodo";
            this.GBPeriodo.Padding = new System.Windows.Forms.Padding(16);
            this.GBPeriodo.Size = new System.Drawing.Size(838, 162);
            this.GBPeriodo.TabIndex = 0;
            this.GBPeriodo.TabStop = false;
            this.GBPeriodo.Text = "Periodo del Reporte";
            // 
            // TLPPeriodo
            // 
            this.TLPPeriodo.ColumnCount = 2;
            this.TLPPeriodo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPPeriodo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 419F));
            this.TLPPeriodo.Controls.Add(this.LDesde, 0, 2);
            this.TLPPeriodo.Controls.Add(this.LHasta, 1, 2);
            this.TLPPeriodo.Controls.Add(this.DTPDesde, 0, 3);
            this.TLPPeriodo.Controls.Add(this.DTPHasta, 1, 3);
            this.TLPPeriodo.Controls.Add(this.BLimpiar, 1, 0);
            this.TLPPeriodo.Controls.Add(this.LTipoPeriodo, 0, 0);
            this.TLPPeriodo.Controls.Add(this.CBTipoPeriodo, 0, 1);
            this.TLPPeriodo.Location = new System.Drawing.Point(19, 26);
            this.TLPPeriodo.Name = "TLPPeriodo";
            this.TLPPeriodo.RowCount = 4;
            this.TLPPeriodo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.14286F));
            this.TLPPeriodo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.85714F));
            this.TLPPeriodo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.TLPPeriodo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.TLPPeriodo.Size = new System.Drawing.Size(813, 136);
            this.TLPPeriodo.TabIndex = 0;
            this.TLPPeriodo.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel3_Paint);
            // 
            // LDesde
            // 
            this.LDesde.AutoSize = true;
            this.LDesde.Dock = System.Windows.Forms.DockStyle.Top;
            this.LDesde.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDesde.Location = new System.Drawing.Point(3, 63);
            this.LDesde.Name = "LDesde";
            this.LDesde.Size = new System.Drawing.Size(388, 23);
            this.LDesde.TabIndex = 1;
            this.LDesde.Text = "Fecha Incio";
            // 
            // LHasta
            // 
            this.LHasta.AutoSize = true;
            this.LHasta.Dock = System.Windows.Forms.DockStyle.Top;
            this.LHasta.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LHasta.Location = new System.Drawing.Point(397, 63);
            this.LHasta.Name = "LHasta";
            this.LHasta.Size = new System.Drawing.Size(413, 23);
            this.LHasta.TabIndex = 2;
            this.LHasta.Text = "Fecha Fin";
            // 
            // DTPDesde
            // 
            this.DTPDesde.Location = new System.Drawing.Point(3, 93);
            this.DTPDesde.Name = "DTPDesde";
            this.DTPDesde.Size = new System.Drawing.Size(200, 30);
            this.DTPDesde.TabIndex = 3;
            // 
            // DTPHasta
            // 
            this.DTPHasta.Location = new System.Drawing.Point(397, 93);
            this.DTPHasta.Name = "DTPHasta";
            this.DTPHasta.Size = new System.Drawing.Size(200, 30);
            this.DTPHasta.TabIndex = 4;
            // 
            // BLimpiar
            // 
            this.BLimpiar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BLimpiar.Location = new System.Drawing.Point(397, 3);
            this.BLimpiar.Name = "BLimpiar";
            this.BLimpiar.Size = new System.Drawing.Size(90, 30);
            this.BLimpiar.TabIndex = 5;
            this.BLimpiar.Text = "Limpiar";
            this.BLimpiar.UseVisualStyleBackColor = true;
            // 
            // LTipoPeriodo
            // 
            this.LTipoPeriodo.AutoSize = true;
            this.LTipoPeriodo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTipoPeriodo.Location = new System.Drawing.Point(3, 0);
            this.LTipoPeriodo.Name = "LTipoPeriodo";
            this.LTipoPeriodo.Size = new System.Drawing.Size(130, 23);
            this.LTipoPeriodo.TabIndex = 0;
            this.LTipoPeriodo.Text = "Tipo de Periodo";
            // 
            // CBTipoPeriodo
            // 
            this.CBTipoPeriodo.FormattingEnabled = true;
            this.CBTipoPeriodo.Items.AddRange(new object[] {
            "Diario",
            "Semanal",
            "Mensual",
            "Anual"});
            this.CBTipoPeriodo.Location = new System.Drawing.Point(3, 39);
            this.CBTipoPeriodo.Name = "CBTipoPeriodo";
            this.CBTipoPeriodo.Size = new System.Drawing.Size(143, 31);
            this.CBTipoPeriodo.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.BExportarExcel);
            this.panel1.Controls.Add(this.BExportarPDF);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Location = new System.Drawing.Point(3, 624);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 75);
            this.panel1.TabIndex = 1;
            // 
            // BExportarExcel
            // 
            this.BExportarExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(82)))), ((int)(((byte)(77)))));
            this.BExportarExcel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BExportarExcel.Location = new System.Drawing.Point(428, 32);
            this.BExportarExcel.Name = "BExportarExcel";
            this.BExportarExcel.Size = new System.Drawing.Size(417, 35);
            this.BExportarExcel.TabIndex = 2;
            this.BExportarExcel.Text = "Exportar Excel";
            this.BExportarExcel.UseVisualStyleBackColor = false;
            // 
            // BExportarPDF
            // 
            this.BExportarPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(82)))), ((int)(((byte)(77)))));
            this.BExportarPDF.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BExportarPDF.Location = new System.Drawing.Point(14, 32);
            this.BExportarPDF.Name = "BExportarPDF";
            this.BExportarPDF.Size = new System.Drawing.Size(408, 35);
            this.BExportarPDF.TabIndex = 1;
            this.BExportarPDF.Text = "Exportar PDF";
            this.BExportarPDF.UseVisualStyleBackColor = false;
            this.BExportarPDF.Click += new System.EventHandler(this.BExportarPDF_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label13.Location = new System.Drawing.Point(3, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(166, 28);
            this.label13.TabIndex = 0;
            this.label13.Text = "Exportar Reporte";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(908, 740);
            this.Controls.Add(this.TPLRoot);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Reportes";
            this.Text = "FormReportes";
            this.Load += new System.EventHandler(this.Reportes_Load);
            this.TPLRoot.ResumeLayout(false);
            this.PNLScroll.ResumeLayout(false);
            this.PNLScroll.PerformLayout();
            this.TLPContent.ResumeLayout(false);
            this.PVentas.ResumeLayout(false);
            this.PVentas.PerformLayout();
            this.TPLVentas.ResumeLayout(false);
            this.PCardTotal.ResumeLayout(false);
            this.PCardTotal.PerformLayout();
            this.PCardVentas.ResumeLayout(false);
            this.PCardVentas.PerformLayout();
            this.PCardTicket.ResumeLayout(false);
            this.PCardTicket.PerformLayout();
            this.PCardProductos.ResumeLayout(false);
            this.PCardProductos.PerformLayout();
            this.GVTopProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVTopProductos)).EndInit();
            this.GVVendedores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVVendedores)).EndInit();
            this.TPLBotonesGraficos.ResumeLayout(false);
            this.GBPeriodo.ResumeLayout(false);
            this.TLPPeriodo.ResumeLayout(false);
            this.TLPPeriodo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TPLRoot;
        private System.Windows.Forms.Panel PNLScroll;
        private System.Windows.Forms.TableLayoutPanel TLPContent;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox GBPeriodo;
        private System.Windows.Forms.TableLayoutPanel TLPPeriodo;
        private System.Windows.Forms.Label LTipoPeriodo;
        private System.Windows.Forms.ComboBox CBTipoPeriodo;
        private System.Windows.Forms.Label LHasta;
        private System.Windows.Forms.Label LDesde;
        private System.Windows.Forms.DateTimePicker DTPDesde;
        private System.Windows.Forms.DateTimePicker DTPHasta;
        private System.Windows.Forms.Label LResumenTitulo;
        private System.Windows.Forms.Panel PVentas;
        public System.Windows.Forms.TableLayoutPanel TPLVentas;
        private System.Windows.Forms.Panel PCardTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LPesosTotalDinero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PCardVentas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LNroVentas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel PCardTicket;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LTicketPromedio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel PCardProductos;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label LCantProductos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox GVTopProductos;
        private System.Windows.Forms.DataGridView DGVTopProductos;
        private System.Windows.Forms.GroupBox GVVendedores;
        private System.Windows.Forms.DataGridView DGVVendedores;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVProductoCVideojuego;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVProductoCUnidadesVendidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVProductoCIngresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVVendedoresCVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVProductoCTotalDineroenVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVProductoCVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVProductoCTicketPromedio;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BExportarExcel;
        private System.Windows.Forms.Button BExportarPDF;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button BVerGraficosProductos;
        private System.Windows.Forms.TableLayoutPanel TPLBotonesGraficos;
        private System.Windows.Forms.Button BVerGraficosVendedores;
        private System.Windows.Forms.Button BLimpiar;
        private System.Windows.Forms.Button BMasVendidosExtendido;
        private System.Windows.Forms.Button BRendimientosExtendido;
    }
}