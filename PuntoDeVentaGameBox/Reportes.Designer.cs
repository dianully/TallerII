namespace PuntoDeVentaGameBox
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
            this.GBPeriodo = new System.Windows.Forms.GroupBox();
            this.TLPPeriodo = new System.Windows.Forms.TableLayoutPanel();
            this.LTipoPeriodo = new System.Windows.Forms.Label();
            this.CBTipoPeriodo = new System.Windows.Forms.ComboBox();
            this.LDesde = new System.Windows.Forms.Label();
            this.LHasta = new System.Windows.Forms.Label();
            this.DTPDesde = new System.Windows.Forms.DateTimePicker();
            this.DTPHasta = new System.Windows.Forms.DateTimePicker();
            this.PVentas = new System.Windows.Forms.Panel();
            this.LResumenTitulo = new System.Windows.Forms.Label();
            this.TPLVentas = new System.Windows.Forms.TableLayoutPanel();
            this.PCardTotal = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PCardVentas = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PCardTicket = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PCardProductos = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.GVTopProductos = new System.Windows.Forms.GroupBox();
            this.DGVTopProductos = new System.Windows.Forms.DataGridView();
            this.DGVProductoCVideojuego = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVProductoCUnidadesVendidas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVProductoCIngresos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GVVendedores = new System.Windows.Forms.GroupBox();
            this.DGVVendedores = new System.Windows.Forms.DataGridView();
            this.DGVVendedoresCVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVProductoCTotalDineroenVentas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVProductoCVentas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVProductoCTicketPromedio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PHeader = new System.Windows.Forms.Panel();
            this.LRol = new System.Windows.Forms.Label();
            this.LGeneraciondereportesdeventas = new System.Windows.Forms.Label();
            this.LReportes = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.TPLRoot.SuspendLayout();
            this.PNLScroll.SuspendLayout();
            this.TLPContent.SuspendLayout();
            this.GBPeriodo.SuspendLayout();
            this.TLPPeriodo.SuspendLayout();
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
            this.PHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // TPLRoot
            // 
            this.TPLRoot.ColumnCount = 1;
            this.TPLRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TPLRoot.Controls.Add(this.PNLScroll, 0, 1);
            this.TPLRoot.Controls.Add(this.PHeader, 0, 0);
            this.TPLRoot.Location = new System.Drawing.Point(2, 1);
            this.TPLRoot.Name = "TPLRoot";
            this.TPLRoot.RowCount = 2;
            this.TPLRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.TPLRoot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TPLRoot.Size = new System.Drawing.Size(1176, 754);
            this.TPLRoot.TabIndex = 0;
            // 
            // PNLScroll
            // 
            this.PNLScroll.Controls.Add(this.TLPContent);
            this.PNLScroll.Dock = System.Windows.Forms.DockStyle.Top;
            this.PNLScroll.Location = new System.Drawing.Point(3, 75);
            this.PNLScroll.Name = "PNLScroll";
            this.PNLScroll.Padding = new System.Windows.Forms.Padding(16);
            this.PNLScroll.Size = new System.Drawing.Size(1170, 750);
            this.PNLScroll.TabIndex = 3;
            // 
            // TLPContent
            // 
            this.TLPContent.AutoSize = true;
            this.TLPContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TLPContent.ColumnCount = 1;
            this.TLPContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPContent.Controls.Add(this.GBPeriodo, 0, 0);
            this.TLPContent.Controls.Add(this.PVentas, 0, 1);
            this.TLPContent.Controls.Add(this.GVTopProductos, 0, 2);
            this.TLPContent.Controls.Add(this.GVVendedores, 0, 3);
            this.TLPContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPContent.Location = new System.Drawing.Point(16, 16);
            this.TLPContent.Name = "TLPContent";
            this.TLPContent.RowCount = 4;
            this.TLPContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.TLPContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.TLPContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.TLPContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 174F));
            this.TLPContent.Size = new System.Drawing.Size(1138, 718);
            this.TLPContent.TabIndex = 0;
            this.TLPContent.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // GBPeriodo
            // 
            this.GBPeriodo.Controls.Add(this.TLPPeriodo);
            this.GBPeriodo.Dock = System.Windows.Forms.DockStyle.Top;
            this.GBPeriodo.Location = new System.Drawing.Point(8, 8);
            this.GBPeriodo.Margin = new System.Windows.Forms.Padding(8);
            this.GBPeriodo.Name = "GBPeriodo";
            this.GBPeriodo.Padding = new System.Windows.Forms.Padding(16);
            this.GBPeriodo.Size = new System.Drawing.Size(1122, 164);
            this.GBPeriodo.TabIndex = 0;
            this.GBPeriodo.TabStop = false;
            this.GBPeriodo.Text = "Periodo del Reporte";
            // 
            // TLPPeriodo
            // 
            this.TLPPeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TLPPeriodo.ColumnCount = 2;
            this.TLPPeriodo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPPeriodo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 419F));
            this.TLPPeriodo.Controls.Add(this.LTipoPeriodo, 0, 0);
            this.TLPPeriodo.Controls.Add(this.CBTipoPeriodo, 0, 1);
            this.TLPPeriodo.Controls.Add(this.LDesde, 0, 2);
            this.TLPPeriodo.Controls.Add(this.LHasta, 1, 2);
            this.TLPPeriodo.Controls.Add(this.DTPDesde, 0, 3);
            this.TLPPeriodo.Controls.Add(this.DTPHasta, 1, 3);
            this.TLPPeriodo.Location = new System.Drawing.Point(11, 29);
            this.TLPPeriodo.Name = "TLPPeriodo";
            this.TLPPeriodo.RowCount = 4;
            this.TLPPeriodo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.26866F));
            this.TLPPeriodo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.73134F));
            this.TLPPeriodo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.TLPPeriodo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.TLPPeriodo.Size = new System.Drawing.Size(752, 135);
            this.TLPPeriodo.TabIndex = 0;
            this.TLPPeriodo.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel3_Paint);
            // 
            // LTipoPeriodo
            // 
            this.LTipoPeriodo.AutoSize = true;
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
            this.CBTipoPeriodo.Location = new System.Drawing.Point(3, 32);
            this.CBTipoPeriodo.Name = "CBTipoPeriodo";
            this.CBTipoPeriodo.Size = new System.Drawing.Size(143, 31);
            this.CBTipoPeriodo.TabIndex = 1;
            // 
            // LDesde
            // 
            this.LDesde.AutoSize = true;
            this.LDesde.Dock = System.Windows.Forms.DockStyle.Top;
            this.LDesde.Location = new System.Drawing.Point(3, 62);
            this.LDesde.Name = "LDesde";
            this.LDesde.Size = new System.Drawing.Size(327, 23);
            this.LDesde.TabIndex = 1;
            this.LDesde.Text = "Fecha Incio";
            // 
            // LHasta
            // 
            this.LHasta.AutoSize = true;
            this.LHasta.Dock = System.Windows.Forms.DockStyle.Top;
            this.LHasta.Location = new System.Drawing.Point(336, 62);
            this.LHasta.Name = "LHasta";
            this.LHasta.Size = new System.Drawing.Size(413, 23);
            this.LHasta.TabIndex = 2;
            this.LHasta.Text = "Fecha Fin";
            // 
            // DTPDesde
            // 
            this.DTPDesde.Location = new System.Drawing.Point(3, 96);
            this.DTPDesde.Name = "DTPDesde";
            this.DTPDesde.Size = new System.Drawing.Size(200, 30);
            this.DTPDesde.TabIndex = 3;
            // 
            // DTPHasta
            // 
            this.DTPHasta.Location = new System.Drawing.Point(336, 96);
            this.DTPHasta.Name = "DTPHasta";
            this.DTPHasta.Size = new System.Drawing.Size(200, 30);
            this.DTPHasta.TabIndex = 4;
            // 
            // PVentas
            // 
            this.PVentas.Controls.Add(this.LResumenTitulo);
            this.PVentas.Controls.Add(this.TPLVentas);
            this.PVentas.Location = new System.Drawing.Point(3, 189);
            this.PVentas.Name = "PVentas";
            this.PVentas.Size = new System.Drawing.Size(1132, 130);
            this.PVentas.TabIndex = 3;
            // 
            // LResumenTitulo
            // 
            this.LResumenTitulo.AutoSize = true;
            this.LResumenTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LResumenTitulo.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.TPLVentas.Location = new System.Drawing.Point(6, 34);
            this.TPLVentas.Margin = new System.Windows.Forms.Padding(0);
            this.TPLVentas.Name = "TPLVentas";
            this.TPLVentas.RowCount = 1;
            this.TPLVentas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.TPLVentas.Size = new System.Drawing.Size(1121, 99);
            this.TPLVentas.TabIndex = 2;
            // 
            // PCardTotal
            // 
            this.PCardTotal.Controls.Add(this.label3);
            this.PCardTotal.Controls.Add(this.label2);
            this.PCardTotal.Controls.Add(this.label1);
            this.PCardTotal.Location = new System.Drawing.Point(3, 3);
            this.PCardTotal.Name = "PCardTotal";
            this.PCardTotal.Size = new System.Drawing.Size(200, 93);
            this.PCardTotal.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // PCardVentas
            // 
            this.PCardVentas.Controls.Add(this.label6);
            this.PCardVentas.Controls.Add(this.label5);
            this.PCardVentas.Controls.Add(this.label4);
            this.PCardVentas.Location = new System.Drawing.Point(283, 3);
            this.PCardVentas.Name = "PCardVentas";
            this.PCardVentas.Size = new System.Drawing.Size(200, 93);
            this.PCardVentas.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 23);
            this.label6.TabIndex = 2;
            this.label6.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 23);
            this.label5.TabIndex = 1;
            this.label5.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "label4";
            // 
            // PCardTicket
            // 
            this.PCardTicket.Controls.Add(this.label9);
            this.PCardTicket.Controls.Add(this.label8);
            this.PCardTicket.Controls.Add(this.label7);
            this.PCardTicket.Location = new System.Drawing.Point(563, 3);
            this.PCardTicket.Name = "PCardTicket";
            this.PCardTicket.Size = new System.Drawing.Size(200, 93);
            this.PCardTicket.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(58, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 23);
            this.label9.TabIndex = 2;
            this.label9.Text = "label9";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(58, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 23);
            this.label8.TabIndex = 1;
            this.label8.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "label7";
            // 
            // PCardProductos
            // 
            this.PCardProductos.Controls.Add(this.label12);
            this.PCardProductos.Controls.Add(this.label11);
            this.PCardProductos.Controls.Add(this.label10);
            this.PCardProductos.Location = new System.Drawing.Point(843, 3);
            this.PCardProductos.Name = "PCardProductos";
            this.PCardProductos.Size = new System.Drawing.Size(199, 90);
            this.PCardProductos.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(64, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 23);
            this.label12.TabIndex = 2;
            this.label12.Text = "label12";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(68, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 23);
            this.label11.TabIndex = 1;
            this.label11.Text = "label11";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(64, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 23);
            this.label10.TabIndex = 0;
            this.label10.Text = "label10";
            // 
            // GVTopProductos
            // 
            this.GVTopProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.GVTopProductos.Controls.Add(this.DGVTopProductos);
            this.GVTopProductos.Location = new System.Drawing.Point(3, 325);
            this.GVTopProductos.Name = "GVTopProductos";
            this.GVTopProductos.Size = new System.Drawing.Size(1132, 98);
            this.GVTopProductos.TabIndex = 4;
            this.GVTopProductos.TabStop = false;
            this.GVTopProductos.Text = "Productos Mas Vendidos";
            // 
            // DGVTopProductos
            // 
            this.DGVTopProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVTopProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVTopProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVTopProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGVProductoCVideojuego,
            this.DGVProductoCUnidadesVendidas,
            this.DGVProductoCIngresos});
            this.DGVTopProductos.Location = new System.Drawing.Point(3, 26);
            this.DGVTopProductos.Name = "DGVTopProductos";
            this.DGVTopProductos.ReadOnly = true;
            this.DGVTopProductos.RowHeadersVisible = false;
            this.DGVTopProductos.RowHeadersWidth = 51;
            this.DGVTopProductos.RowTemplate.Height = 24;
            this.DGVTopProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVTopProductos.Size = new System.Drawing.Size(1123, 69);
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
            this.GVVendedores.Controls.Add(this.DGVVendedores);
            this.GVVendedores.Dock = System.Windows.Forms.DockStyle.Top;
            this.GVVendedores.Location = new System.Drawing.Point(3, 429);
            this.GVVendedores.Name = "GVVendedores";
            this.GVVendedores.Size = new System.Drawing.Size(1132, 100);
            this.GVVendedores.TabIndex = 5;
            this.GVVendedores.TabStop = false;
            this.GVVendedores.Text = "Rendimientos por Vendedor";
            // 
            // DGVVendedores
            // 
            this.DGVVendedores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVVendedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVVendedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGVVendedoresCVendedor,
            this.DGVProductoCTotalDineroenVentas,
            this.DGVProductoCVentas,
            this.DGVProductoCTicketPromedio});
            this.DGVVendedores.Location = new System.Drawing.Point(3, 26);
            this.DGVVendedores.Name = "DGVVendedores";
            this.DGVVendedores.ReadOnly = true;
            this.DGVVendedores.RowHeadersVisible = false;
            this.DGVVendedores.RowHeadersWidth = 51;
            this.DGVVendedores.RowTemplate.Height = 24;
            this.DGVVendedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVVendedores.Size = new System.Drawing.Size(1099, 144);
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
            // PHeader
            // 
            this.PHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.PHeader.Controls.Add(this.LRol);
            this.PHeader.Controls.Add(this.LGeneraciondereportesdeventas);
            this.PHeader.Controls.Add(this.LReportes);
            this.PHeader.Location = new System.Drawing.Point(3, 3);
            this.PHeader.Name = "PHeader";
            this.PHeader.Size = new System.Drawing.Size(1170, 66);
            this.PHeader.TabIndex = 0;
            // 
            // LRol
            // 
            this.LRol.AutoSize = true;
            this.LRol.BackColor = System.Drawing.Color.Transparent;
            this.LRol.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LRol.ForeColor = System.Drawing.Color.White;
            this.LRol.Location = new System.Drawing.Point(1026, 13);
            this.LRol.Name = "LRol";
            this.LRol.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.LRol.Size = new System.Drawing.Size(120, 43);
            this.LRol.TabIndex = 2;
            this.LRol.Text = "Gerente";
            // 
            // LGeneraciondereportesdeventas
            // 
            this.LGeneraciondereportesdeventas.AutoSize = true;
            this.LGeneraciondereportesdeventas.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LGeneraciondereportesdeventas.Location = new System.Drawing.Point(153, 20);
            this.LGeneraciondereportesdeventas.Name = "LGeneraciondereportesdeventas";
            this.LGeneraciondereportesdeventas.Size = new System.Drawing.Size(276, 23);
            this.LGeneraciondereportesdeventas.TabIndex = 1;
            this.LGeneraciondereportesdeventas.Text = ": Generación de reportes de ventas";
            // 
            // LReportes
            // 
            this.LReportes.AutoSize = true;
            this.LReportes.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LReportes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LReportes.Location = new System.Drawing.Point(3, 5);
            this.LReportes.Name = "LReportes";
            this.LReportes.Size = new System.Drawing.Size(144, 41);
            this.LReportes.TabIndex = 0;
            this.LReportes.Text = "Reportes";
            // 
            // Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 703);
            this.Controls.Add(this.TPLRoot);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Reportes";
            this.Text = "Form1";
            this.TPLRoot.ResumeLayout(false);
            this.PNLScroll.ResumeLayout(false);
            this.PNLScroll.PerformLayout();
            this.TLPContent.ResumeLayout(false);
            this.GBPeriodo.ResumeLayout(false);
            this.TLPPeriodo.ResumeLayout(false);
            this.TLPPeriodo.PerformLayout();
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
            this.PHeader.ResumeLayout(false);
            this.PHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TPLRoot;
        private System.Windows.Forms.Panel PHeader;
        private System.Windows.Forms.Label LRol;
        private System.Windows.Forms.Label LGeneraciondereportesdeventas;
        private System.Windows.Forms.Label LReportes;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PCardVentas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel PCardTicket;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel PCardProductos;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
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
    }
}