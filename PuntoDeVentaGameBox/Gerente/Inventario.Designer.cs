namespace PuntoDeVentaGameBox.Gerente
{
    partial class InventarioForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TLRoot = new System.Windows.Forms.TableLayoutPanel();
            this.PBanner = new System.Windows.Forms.Panel();
            this.LAvisoStockBajo = new System.Windows.Forms.Label();
            this.BVerSoloStockBajo = new System.Windows.Forms.Button();
            this.TLKPI = new System.Windows.Forms.TableLayoutPanel();
            this.CardKpi1 = new System.Windows.Forms.Panel();
            this.LProductostotales = new System.Windows.Forms.Label();
            this.LCantproductosunicos = new System.Windows.Forms.Label();
            this.KpiTotal = new System.Windows.Forms.Label();
            this.CardKpi3 = new System.Windows.Forms.Panel();
            this.LConstockbajo = new System.Windows.Forms.Label();
            this.LStockmenora = new System.Windows.Forms.Label();
            this.KpiBajo = new System.Windows.Forms.Label();
            this.CardKpi2 = new System.Windows.Forms.Panel();
            this.LStocktotal = new System.Windows.Forms.Label();
            this.LUnidadeseninventario = new System.Windows.Forms.Label();
            this.KpiStock = new System.Windows.Forms.Label();
            this.PFilters = new System.Windows.Forms.Panel();
            this.TLFlters = new System.Windows.Forms.TableLayoutPanel();
            this.CBOrden = new System.Windows.Forms.ComboBox();
            this.LFiltroGenero = new System.Windows.Forms.Label();
            this.LFiltroOrden = new System.Windows.Forms.Label();
            this.LFiltroID = new System.Windows.Forms.Label();
            this.CBGenero = new System.Windows.Forms.ComboBox();
            this.BLimpiarFiltrosProductos = new System.Windows.Forms.Button();
            this.BAplicarFiltrosProductos = new System.Windows.Forms.Button();
            this.TBID = new System.Windows.Forms.TextBox();
            this.TBNombre = new System.Windows.Forms.TextBox();
            this.LFiltroNombre = new System.Windows.Forms.Label();
            this.PListHeader = new System.Windows.Forms.Panel();
            this.BNuevoProducto = new System.Windows.Forms.Button();
            this.LListTitle = new System.Windows.Forms.Label();
            this.PGrid = new System.Windows.Forms.Panel();
            this.DGVProductos = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColImagen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TLRoot.SuspendLayout();
            this.PBanner.SuspendLayout();
            this.TLKPI.SuspendLayout();
            this.CardKpi1.SuspendLayout();
            this.CardKpi3.SuspendLayout();
            this.CardKpi2.SuspendLayout();
            this.PFilters.SuspendLayout();
            this.TLFlters.SuspendLayout();
            this.PListHeader.SuspendLayout();
            this.PGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // TLRoot
            // 
            this.TLRoot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TLRoot.ColumnCount = 1;
            this.TLRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLRoot.Controls.Add(this.PBanner, 0, 1);
            this.TLRoot.Controls.Add(this.TLKPI, 0, 0);
            this.TLRoot.Controls.Add(this.PFilters, 0, 2);
            this.TLRoot.Controls.Add(this.PListHeader, 0, 3);
            this.TLRoot.Controls.Add(this.PGrid, 0, 4);
            this.TLRoot.Location = new System.Drawing.Point(26, 32);
            this.TLRoot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TLRoot.Name = "TLRoot";
            this.TLRoot.RowCount = 5;
            this.TLRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.TLRoot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.TLRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.TLRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.TLRoot.Size = new System.Drawing.Size(1175, 715);
            this.TLRoot.TabIndex = 0;
            this.TLRoot.Paint += new System.Windows.Forms.PaintEventHandler(this.TLRoot_Paint);
            // 
            // PBanner
            // 
            this.PBanner.BackColor = System.Drawing.Color.Transparent;
            this.PBanner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PBanner.Controls.Add(this.LAvisoStockBajo);
            this.PBanner.Controls.Add(this.BVerSoloStockBajo);
            this.PBanner.Location = new System.Drawing.Point(11, 120);
            this.PBanner.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.PBanner.Name = "PBanner";
            this.PBanner.Padding = new System.Windows.Forms.Padding(12);
            this.PBanner.Size = new System.Drawing.Size(1153, 100);
            this.PBanner.TabIndex = 2;
            // 
            // LAvisoStockBajo
            // 
            this.LAvisoStockBajo.AutoSize = true;
            this.LAvisoStockBajo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LAvisoStockBajo.Location = new System.Drawing.Point(57, 37);
            this.LAvisoStockBajo.Name = "LAvisoStockBajo";
            this.LAvisoStockBajo.Size = new System.Drawing.Size(691, 25);
            this.LAvisoStockBajo.TabIndex = 2;
            this.LAvisoStockBajo.Text = "Tienes ... productos con stock bajo. Es recomendable reabastecer estos productos." +
    "";
            // 
            // BVerSoloStockBajo
            // 
            this.BVerSoloStockBajo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BVerSoloStockBajo.AutoSize = true;
            this.BVerSoloStockBajo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BVerSoloStockBajo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.BVerSoloStockBajo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BVerSoloStockBajo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.BVerSoloStockBajo.Location = new System.Drawing.Point(875, 37);
            this.BVerSoloStockBajo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BVerSoloStockBajo.Name = "BVerSoloStockBajo";
            this.BVerSoloStockBajo.Size = new System.Drawing.Size(179, 34);
            this.BVerSoloStockBajo.TabIndex = 1;
            this.BVerSoloStockBajo.Text = "Ver solo stock bajo";
            this.BVerSoloStockBajo.UseVisualStyleBackColor = true;
            // 
            // TLKPI
            // 
            this.TLKPI.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TLKPI.ColumnCount = 3;
            this.TLKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 403F));
            this.TLKPI.Controls.Add(this.CardKpi1, 0, 0);
            this.TLKPI.Controls.Add(this.CardKpi3, 2, 0);
            this.TLKPI.Controls.Add(this.CardKpi2, 1, 0);
            this.TLKPI.ForeColor = System.Drawing.SystemColors.Control;
            this.TLKPI.Location = new System.Drawing.Point(13, 3);
            this.TLKPI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TLKPI.Name = "TLKPI";
            this.TLKPI.RowCount = 1;
            this.TLKPI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLKPI.Size = new System.Drawing.Size(1149, 103);
            this.TLKPI.TabIndex = 0;
            // 
            // CardKpi1
            // 
            this.CardKpi1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CardKpi1.Controls.Add(this.LProductostotales);
            this.CardKpi1.Controls.Add(this.LCantproductosunicos);
            this.CardKpi1.Controls.Add(this.KpiTotal);
            this.CardKpi1.Location = new System.Drawing.Point(3, 2);
            this.CardKpi1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CardKpi1.Name = "CardKpi1";
            this.CardKpi1.Size = new System.Drawing.Size(367, 98);
            this.CardKpi1.TabIndex = 0;
            // 
            // LProductostotales
            // 
            this.LProductostotales.AutoSize = true;
            this.LProductostotales.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LProductostotales.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LProductostotales.Location = new System.Drawing.Point(109, 11);
            this.LProductostotales.Name = "LProductostotales";
            this.LProductostotales.Size = new System.Drawing.Size(144, 23);
            this.LProductostotales.TabIndex = 0;
            this.LProductostotales.Text = "Productos Totales";
            this.LProductostotales.Click += new System.EventHandler(this.LProductostotales_Click);
            // 
            // LCantproductosunicos
            // 
            this.LCantproductosunicos.AutoSize = true;
            this.LCantproductosunicos.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LCantproductosunicos.Location = new System.Drawing.Point(89, 73);
            this.LCantproductosunicos.Name = "LCantproductosunicos";
            this.LCantproductosunicos.Size = new System.Drawing.Size(185, 16);
            this.LCantproductosunicos.TabIndex = 2;
            this.LCantproductosunicos.Text = "Cantidad de productos únicos";
            // 
            // KpiTotal
            // 
            this.KpiTotal.AutoSize = true;
            this.KpiTotal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KpiTotal.Location = new System.Drawing.Point(157, 32);
            this.KpiTotal.Name = "KpiTotal";
            this.KpiTotal.Size = new System.Drawing.Size(35, 41);
            this.KpiTotal.TabIndex = 1;
            this.KpiTotal.Text = "0";
            // 
            // CardKpi3
            // 
            this.CardKpi3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CardKpi3.Controls.Add(this.LConstockbajo);
            this.CardKpi3.Controls.Add(this.LStockmenora);
            this.CardKpi3.Controls.Add(this.KpiBajo);
            this.CardKpi3.Location = new System.Drawing.Point(749, 2);
            this.CardKpi3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CardKpi3.Name = "CardKpi3";
            this.CardKpi3.Size = new System.Drawing.Size(393, 98);
            this.CardKpi3.TabIndex = 2;
            // 
            // LConstockbajo
            // 
            this.LConstockbajo.AutoSize = true;
            this.LConstockbajo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LConstockbajo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LConstockbajo.Location = new System.Drawing.Point(136, 11);
            this.LConstockbajo.Name = "LConstockbajo";
            this.LConstockbajo.Size = new System.Drawing.Size(126, 23);
            this.LConstockbajo.TabIndex = 0;
            this.LConstockbajo.Text = "Con Stock Bajo";
            // 
            // LStockmenora
            // 
            this.LStockmenora.AutoSize = true;
            this.LStockmenora.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LStockmenora.Location = new System.Drawing.Point(83, 73);
            this.LStockmenora.Name = "LStockmenora";
            this.LStockmenora.Size = new System.Drawing.Size(239, 16);
            this.LStockmenora.TabIndex = 2;
            this.LStockmenora.Text = "Productos menor o igual a 25 unidades";
            // 
            // KpiBajo
            // 
            this.KpiBajo.AutoSize = true;
            this.KpiBajo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KpiBajo.Location = new System.Drawing.Point(183, 32);
            this.KpiBajo.Name = "KpiBajo";
            this.KpiBajo.Size = new System.Drawing.Size(35, 41);
            this.KpiBajo.TabIndex = 1;
            this.KpiBajo.Text = "0";
            // 
            // CardKpi2
            // 
            this.CardKpi2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CardKpi2.Controls.Add(this.LStocktotal);
            this.CardKpi2.Controls.Add(this.LUnidadeseninventario);
            this.CardKpi2.Controls.Add(this.KpiStock);
            this.CardKpi2.Location = new System.Drawing.Point(376, 2);
            this.CardKpi2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CardKpi2.Name = "CardKpi2";
            this.CardKpi2.Size = new System.Drawing.Size(367, 98);
            this.CardKpi2.TabIndex = 1;
            // 
            // LStocktotal
            // 
            this.LStocktotal.AutoSize = true;
            this.LStocktotal.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LStocktotal.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LStocktotal.Location = new System.Drawing.Point(145, 11);
            this.LStocktotal.Name = "LStocktotal";
            this.LStocktotal.Size = new System.Drawing.Size(93, 23);
            this.LStocktotal.TabIndex = 0;
            this.LStocktotal.Text = "Total Stock";
            // 
            // LUnidadeseninventario
            // 
            this.LUnidadeseninventario.AutoSize = true;
            this.LUnidadeseninventario.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LUnidadeseninventario.Location = new System.Drawing.Point(120, 73);
            this.LUnidadeseninventario.Name = "LUnidadeseninventario";
            this.LUnidadeseninventario.Size = new System.Drawing.Size(145, 16);
            this.LUnidadeseninventario.TabIndex = 2;
            this.LUnidadeseninventario.Text = "Unidades en Inventario";
            this.LUnidadeseninventario.Click += new System.EventHandler(this.LUnidadeseninventario_Click);
            // 
            // KpiStock
            // 
            this.KpiStock.AutoSize = true;
            this.KpiStock.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KpiStock.Location = new System.Drawing.Point(173, 32);
            this.KpiStock.Name = "KpiStock";
            this.KpiStock.Size = new System.Drawing.Size(35, 41);
            this.KpiStock.TabIndex = 1;
            this.KpiStock.Text = "0";
            this.KpiStock.Click += new System.EventHandler(this.label2_Click);
            // 
            // PFilters
            // 
            this.PFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PFilters.Controls.Add(this.TLFlters);
            this.PFilters.Cursor = System.Windows.Forms.Cursors.Default;
            this.PFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PFilters.Location = new System.Drawing.Point(11, 240);
            this.PFilters.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.PFilters.Name = "PFilters";
            this.PFilters.Padding = new System.Windows.Forms.Padding(16);
            this.PFilters.Size = new System.Drawing.Size(1153, 140);
            this.PFilters.TabIndex = 3;
            this.PFilters.Paint += new System.Windows.Forms.PaintEventHandler(this.PFilters_Paint);
            // 
            // TLFlters
            // 
            this.TLFlters.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.TLFlters.ColumnCount = 4;
            this.TLFlters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLFlters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLFlters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLFlters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLFlters.Controls.Add(this.CBOrden, 3, 1);
            this.TLFlters.Controls.Add(this.LFiltroGenero, 2, 0);
            this.TLFlters.Controls.Add(this.LFiltroOrden, 3, 0);
            this.TLFlters.Controls.Add(this.LFiltroID, 1, 0);
            this.TLFlters.Controls.Add(this.CBGenero, 2, 1);
            this.TLFlters.Controls.Add(this.BLimpiarFiltrosProductos, 1, 2);
            this.TLFlters.Controls.Add(this.BAplicarFiltrosProductos, 0, 2);
            this.TLFlters.Controls.Add(this.TBID, 1, 1);
            this.TLFlters.Controls.Add(this.TBNombre, 0, 1);
            this.TLFlters.Controls.Add(this.LFiltroNombre, 0, 0);
            this.TLFlters.ForeColor = System.Drawing.SystemColors.Control;
            this.TLFlters.Location = new System.Drawing.Point(-1, -1);
            this.TLFlters.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TLFlters.Name = "TLFlters";
            this.TLFlters.RowCount = 3;
            this.TLFlters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLFlters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLFlters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLFlters.Size = new System.Drawing.Size(1147, 140);
            this.TLFlters.TabIndex = 0;
            this.TLFlters.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint_1);
            // 
            // CBOrden
            // 
            this.CBOrden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CBOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBOrden.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBOrden.FormattingEnabled = true;
            this.CBOrden.Items.AddRange(new object[] {
            "ID",
            "Nombre A-Z",
            "Nombre Z-A",
            "Stock ▲",
            "Stock ▼",
            "Precio ▲",
            "Precio ▼"});
            this.CBOrden.Location = new System.Drawing.Point(874, 49);
            this.CBOrden.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.CBOrden.Name = "CBOrden";
            this.CBOrden.Size = new System.Drawing.Size(269, 31);
            this.CBOrden.TabIndex = 3;
            // 
            // LFiltroGenero
            // 
            this.LFiltroGenero.AutoSize = true;
            this.LFiltroGenero.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFiltroGenero.Location = new System.Drawing.Point(588, 1);
            this.LFiltroGenero.Margin = new System.Windows.Forms.Padding(15, 0, 0, 2);
            this.LFiltroGenero.Name = "LFiltroGenero";
            this.LFiltroGenero.Size = new System.Drawing.Size(73, 23);
            this.LFiltroGenero.TabIndex = 2;
            this.LFiltroGenero.Text = "Géneros";
            // 
            // LFiltroOrden
            // 
            this.LFiltroOrden.AutoSize = true;
            this.LFiltroOrden.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFiltroOrden.Location = new System.Drawing.Point(874, 1);
            this.LFiltroOrden.Margin = new System.Windows.Forms.Padding(15, 0, 0, 2);
            this.LFiltroOrden.Name = "LFiltroOrden";
            this.LFiltroOrden.Size = new System.Drawing.Size(104, 23);
            this.LFiltroOrden.TabIndex = 3;
            this.LFiltroOrden.Text = "Ordenar por";
            // 
            // LFiltroID
            // 
            this.LFiltroID.AutoSize = true;
            this.LFiltroID.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFiltroID.Location = new System.Drawing.Point(302, 1);
            this.LFiltroID.Margin = new System.Windows.Forms.Padding(15, 0, 0, 2);
            this.LFiltroID.Name = "LFiltroID";
            this.LFiltroID.Size = new System.Drawing.Size(106, 23);
            this.LFiltroID.TabIndex = 1;
            this.LFiltroID.Text = "Filtrar por ID";
            // 
            // CBGenero
            // 
            this.CBGenero.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBGenero.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBGenero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CBGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBGenero.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBGenero.FormattingEnabled = true;
            this.CBGenero.Items.AddRange(new object[] {
            "Todos",
            "Aventura",
            "RPG",
            "Acción",
            "Deportes",
            "Estrategia"});
            this.CBGenero.Location = new System.Drawing.Point(588, 49);
            this.CBGenero.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.CBGenero.Name = "CBGenero";
            this.CBGenero.Size = new System.Drawing.Size(267, 31);
            this.CBGenero.TabIndex = 2;
            // 
            // BLimpiarFiltrosProductos
            // 
            this.BLimpiarFiltrosProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.BLimpiarFiltrosProductos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.BLimpiarFiltrosProductos.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BLimpiarFiltrosProductos.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BLimpiarFiltrosProductos.Location = new System.Drawing.Point(302, 95);
            this.BLimpiarFiltrosProductos.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.BLimpiarFiltrosProductos.Name = "BLimpiarFiltrosProductos";
            this.BLimpiarFiltrosProductos.Size = new System.Drawing.Size(91, 39);
            this.BLimpiarFiltrosProductos.TabIndex = 7;
            this.BLimpiarFiltrosProductos.Text = "Limpiar";
            this.BLimpiarFiltrosProductos.UseVisualStyleBackColor = false;
            // 
            // BAplicarFiltrosProductos
            // 
            this.BAplicarFiltrosProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.BAplicarFiltrosProductos.FlatAppearance.BorderSize = 0;
            this.BAplicarFiltrosProductos.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAplicarFiltrosProductos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BAplicarFiltrosProductos.Location = new System.Drawing.Point(16, 95);
            this.BAplicarFiltrosProductos.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.BAplicarFiltrosProductos.Name = "BAplicarFiltrosProductos";
            this.BAplicarFiltrosProductos.Size = new System.Drawing.Size(141, 39);
            this.BAplicarFiltrosProductos.TabIndex = 4;
            this.BAplicarFiltrosProductos.Text = "Aplicar filtros";
            this.BAplicarFiltrosProductos.UseVisualStyleBackColor = false;
            this.BAplicarFiltrosProductos.Click += new System.EventHandler(this.BAplicarFiltrosProducto_Click);
            // 
            // TBID
            // 
            this.TBID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBID.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBID.Location = new System.Drawing.Point(302, 49);
            this.TBID.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.TBID.MaxLength = 9;
            this.TBID.Name = "TBID";
            this.TBID.Size = new System.Drawing.Size(267, 30);
            this.TBID.TabIndex = 1;
            this.TBID.TextChanged += new System.EventHandler(this.TBID_TextChanged);
            // 
            // TBNombre
            // 
            this.TBNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBNombre.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBNombre.Location = new System.Drawing.Point(16, 49);
            this.TBNombre.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.TBNombre.MaxLength = 200;
            this.TBNombre.Name = "TBNombre";
            this.TBNombre.Size = new System.Drawing.Size(267, 30);
            this.TBNombre.TabIndex = 0;
            this.TBNombre.TextChanged += new System.EventHandler(this.TBNombre_TextChanged);
            // 
            // LFiltroNombre
            // 
            this.LFiltroNombre.AutoSize = true;
            this.LFiltroNombre.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFiltroNombre.ForeColor = System.Drawing.SystemColors.Control;
            this.LFiltroNombre.Location = new System.Drawing.Point(16, 1);
            this.LFiltroNombre.Margin = new System.Windows.Forms.Padding(15, 0, 0, 2);
            this.LFiltroNombre.Name = "LFiltroNombre";
            this.LFiltroNombre.Size = new System.Drawing.Size(156, 23);
            this.LFiltroNombre.TabIndex = 0;
            this.LFiltroNombre.Text = "Buscar por nombre";
            this.LFiltroNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LFiltroNombre.Click += new System.EventHandler(this.label1_Click);
            // 
            // PListHeader
            // 
            this.PListHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PListHeader.Controls.Add(this.BNuevoProducto);
            this.PListHeader.Controls.Add(this.LListTitle);
            this.PListHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PListHeader.Location = new System.Drawing.Point(11, 400);
            this.PListHeader.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.PListHeader.Name = "PListHeader";
            this.PListHeader.Padding = new System.Windows.Forms.Padding(12);
            this.PListHeader.Size = new System.Drawing.Size(1153, 51);
            this.PListHeader.TabIndex = 4;
            // 
            // BNuevoProducto
            // 
            this.BNuevoProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BNuevoProducto.AutoSize = true;
            this.BNuevoProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.BNuevoProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BNuevoProducto.FlatAppearance.BorderSize = 0;
            this.BNuevoProducto.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNuevoProducto.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BNuevoProducto.Location = new System.Drawing.Point(887, 2);
            this.BNuevoProducto.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.BNuevoProducto.Name = "BNuevoProducto";
            this.BNuevoProducto.Padding = new System.Windows.Forms.Padding(11, 6, 11, 6);
            this.BNuevoProducto.Size = new System.Drawing.Size(237, 48);
            this.BNuevoProducto.TabIndex = 1;
            this.BNuevoProducto.Text = "+ Nuevo producto";
            this.BNuevoProducto.UseVisualStyleBackColor = false;
            this.BNuevoProducto.Click += new System.EventHandler(this.BNuevoproducto_Click);
            // 
            // LListTitle
            // 
            this.LListTitle.AutoSize = true;
            this.LListTitle.Font = new System.Drawing.Font("Segoe UI", 12.2F, System.Drawing.FontStyle.Bold);
            this.LListTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.LListTitle.Location = new System.Drawing.Point(13, 7);
            this.LListTitle.Margin = new System.Windows.Forms.Padding(0);
            this.LListTitle.Name = "LListTitle";
            this.LListTitle.Size = new System.Drawing.Size(194, 30);
            this.LListTitle.TabIndex = 0;
            this.LListTitle.Text = "Lista de Productos";
            // 
            // PGrid
            // 
            this.PGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PGrid.Controls.Add(this.DGVProductos);
            this.PGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrid.Location = new System.Drawing.Point(11, 471);
            this.PGrid.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.PGrid.Name = "PGrid";
            this.PGrid.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.PGrid.Size = new System.Drawing.Size(1153, 234);
            this.PGrid.TabIndex = 5;
            // 
            // DGVProductos
            // 
            this.DGVProductos.AllowUserToAddRows = false;
            this.DGVProductos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.DGVProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColId,
            this.ColImagen,
            this.ColNombre,
            this.ColPrecio,
            this.ColStock,
            this.ColEditar,
            this.ColEliminar});
            this.DGVProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVProductos.Location = new System.Drawing.Point(8, 7);
            this.DGVProductos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DGVProductos.MultiSelect = false;
            this.DGVProductos.Name = "DGVProductos";
            this.DGVProductos.ReadOnly = true;
            this.DGVProductos.RowHeadersVisible = false;
            this.DGVProductos.RowHeadersWidth = 51;
            this.DGVProductos.RowTemplate.Height = 56;
            this.DGVProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVProductos.Size = new System.Drawing.Size(1135, 218);
            this.DGVProductos.TabIndex = 0;
            this.DGVProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellContentClick);
            // 
            // ColId
            // 
            this.ColId.DataPropertyName = "Id";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColId.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColId.FillWeight = 3.788457F;
            this.ColId.HeaderText = "ID";
            this.ColId.MinimumWidth = 6;
            this.ColId.Name = "ColId";
            this.ColId.ReadOnly = true;
            // 
            // ColImagen
            // 
            this.ColImagen.FillWeight = 5.270591F;
            this.ColImagen.HeaderText = "Imagen";
            this.ColImagen.MinimumWidth = 6;
            this.ColImagen.Name = "ColImagen";
            this.ColImagen.ReadOnly = true;
            this.ColImagen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColImagen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColNombre
            // 
            this.ColNombre.DataPropertyName = "Nombre";
            this.ColNombre.FillWeight = 18.44707F;
            this.ColNombre.HeaderText = "Nombre";
            this.ColNombre.MinimumWidth = 6;
            this.ColNombre.Name = "ColNombre";
            this.ColNombre.ReadOnly = true;
            // 
            // ColPrecio
            // 
            this.ColPrecio.DataPropertyName = "Precio";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            this.ColPrecio.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColPrecio.FillWeight = 19.25784F;
            this.ColPrecio.HeaderText = "Precio";
            this.ColPrecio.MinimumWidth = 6;
            this.ColPrecio.Name = "ColPrecio";
            this.ColPrecio.ReadOnly = true;
            // 
            // ColStock
            // 
            this.ColStock.DataPropertyName = "Stock";
            this.ColStock.FillWeight = 10.83251F;
            this.ColStock.HeaderText = "Stock";
            this.ColStock.MinimumWidth = 6;
            this.ColStock.Name = "ColStock";
            this.ColStock.ReadOnly = true;
            // 
            // ColEditar
            // 
            this.ColEditar.FillWeight = 5.513864F;
            this.ColEditar.HeaderText = "Editar";
            this.ColEditar.MinimumWidth = 6;
            this.ColEditar.Name = "ColEditar";
            this.ColEditar.ReadOnly = true;
            this.ColEditar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColEditar.ToolTipText = "Editar";
            // 
            // ColEliminar
            // 
            this.ColEliminar.FillWeight = 4.374791F;
            this.ColEliminar.HeaderText = "Eliminar";
            this.ColEliminar.MinimumWidth = 6;
            this.ColEliminar.Name = "ColEliminar";
            this.ColEliminar.ReadOnly = true;
            this.ColEliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColEliminar.ToolTipText = "Eliminar";
            // 
            // InventarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(1224, 745);
            this.Controls.Add(this.TLRoot);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "InventarioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario";
            this.Load += new System.EventHandler(this.InventarioForm_Load);
            this.TLRoot.ResumeLayout(false);
            this.PBanner.ResumeLayout(false);
            this.PBanner.PerformLayout();
            this.TLKPI.ResumeLayout(false);
            this.CardKpi1.ResumeLayout(false);
            this.CardKpi1.PerformLayout();
            this.CardKpi3.ResumeLayout(false);
            this.CardKpi3.PerformLayout();
            this.CardKpi2.ResumeLayout(false);
            this.CardKpi2.PerformLayout();
            this.PFilters.ResumeLayout(false);
            this.TLFlters.ResumeLayout(false);
            this.TLFlters.PerformLayout();
            this.PListHeader.ResumeLayout(false);
            this.PListHeader.PerformLayout();
            this.PGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLRoot;
        private System.Windows.Forms.TableLayoutPanel TLKPI;
        private System.Windows.Forms.Panel PBanner;
        private System.Windows.Forms.Panel PFilters;
        private System.Windows.Forms.Panel PListHeader;
        private System.Windows.Forms.Panel PGrid;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel CardKpi1;
        private System.Windows.Forms.Label LProductostotales;
        private System.Windows.Forms.Panel CardKpi2;
        private System.Windows.Forms.Label LStocktotal;
        private System.Windows.Forms.Panel CardKpi3;
        private System.Windows.Forms.Label LConstockbajo;
        private System.Windows.Forms.Label KpiTotal;
        private System.Windows.Forms.Label KpiStock;
        private System.Windows.Forms.Label KpiBajo;
        private System.Windows.Forms.Label LCantproductosunicos;
        private System.Windows.Forms.Label LUnidadeseninventario;
        private System.Windows.Forms.Label LStockmenora;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Button BVerSoloStockBajo;
        private System.Windows.Forms.TableLayoutPanel TLFlters;
        private System.Windows.Forms.Label LFiltroNombre;
        private System.Windows.Forms.Label LFiltroID;
        private System.Windows.Forms.Label LFiltroGenero;
        private System.Windows.Forms.Label LFiltroOrden;
        private System.Windows.Forms.ComboBox CBOrden;
        private System.Windows.Forms.TextBox TBID;
        private System.Windows.Forms.TextBox TBNombre;
        private System.Windows.Forms.ComboBox CBGenero;
        private System.Windows.Forms.Button BLimpiarFiltrosProductos;
        private System.Windows.Forms.Button BAplicarFiltrosProductos;
        private System.Windows.Forms.Label LListTitle;
        private System.Windows.Forms.Button BNuevoProducto;
        private System.Windows.Forms.DataGridView DGVProductos;
        private System.Windows.Forms.Label LAvisoStockBajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColImagen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStock;
        private System.Windows.Forms.DataGridViewButtonColumn ColEditar;
        private System.Windows.Forms.DataGridViewButtonColumn ColEliminar;
    }
}