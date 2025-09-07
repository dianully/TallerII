namespace PuntoDeVentaGameBox
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
            this.TLRoot = new System.Windows.Forms.TableLayoutPanel();
            this.TLKPI = new System.Windows.Forms.TableLayoutPanel();
            this.PHeader = new System.Windows.Forms.Panel();
            this.PBanner = new System.Windows.Forms.Panel();
            this.PFilters = new System.Windows.Forms.Panel();
            this.PListHeader = new System.Windows.Forms.Panel();
            this.PGrid = new System.Windows.Forms.Panel();
            this.LTitle = new System.Windows.Forms.Label();
            this.LSub = new System.Windows.Forms.Label();
            this.LRol = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.CardKpi1 = new System.Windows.Forms.Panel();
            this.CardKpi2 = new System.Windows.Forms.Panel();
            this.CardKpi3 = new System.Windows.Forms.Panel();
            this.LProductostotales = new System.Windows.Forms.Label();
            this.LStocktotal = new System.Windows.Forms.Label();
            this.LConstockbajo = new System.Windows.Forms.Label();
            this.KpiTotal = new System.Windows.Forms.Label();
            this.KpiStock = new System.Windows.Forms.Label();
            this.KpiBajo = new System.Windows.Forms.Label();
            this.LCantproductosunicos = new System.Windows.Forms.Label();
            this.LUnidadeseninventario = new System.Windows.Forms.Label();
            this.LStockmenora = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.LblBanner = new System.Windows.Forms.Label();
            this.BVerSoloBajo = new System.Windows.Forms.Button();
            this.TLFlters = new System.Windows.Forms.TableLayoutPanel();
            this.LFiltroNombre = new System.Windows.Forms.Label();
            this.LFiltroID = new System.Windows.Forms.Label();
            this.LFiltroGenero = new System.Windows.Forms.Label();
            this.LFiltroOrden = new System.Windows.Forms.Label();
            this.CBOrden = new System.Windows.Forms.ComboBox();
            this.TBID = new System.Windows.Forms.TextBox();
            this.TBNombre = new System.Windows.Forms.TextBox();
            this.BAplicar = new System.Windows.Forms.Button();
            this.BLimpiar = new System.Windows.Forms.Button();
            this.CBGenero = new System.Windows.Forms.ComboBox();
            this.LListTitle = new System.Windows.Forms.Label();
            this.BNuevoproducto = new System.Windows.Forms.Button();
            this.TLRoot.SuspendLayout();
            this.TLKPI.SuspendLayout();
            this.PHeader.SuspendLayout();
            this.PBanner.SuspendLayout();
            this.PFilters.SuspendLayout();
            this.PListHeader.SuspendLayout();
            this.CardKpi1.SuspendLayout();
            this.CardKpi2.SuspendLayout();
            this.CardKpi3.SuspendLayout();
            this.TLFlters.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLRoot
            // 
            this.TLRoot.ColumnCount = 1;
            this.TLRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLRoot.Controls.Add(this.TLKPI, 0, 1);
            this.TLRoot.Controls.Add(this.PHeader, 0, 0);
            this.TLRoot.Controls.Add(this.PBanner, 0, 2);
            this.TLRoot.Controls.Add(this.PFilters, 0, 3);
            this.TLRoot.Controls.Add(this.PListHeader, 0, 4);
            this.TLRoot.Controls.Add(this.PGrid, 0, 5);
            this.TLRoot.Location = new System.Drawing.Point(3, 12);
            this.TLRoot.Name = "TLRoot";
            this.TLRoot.RowCount = 6;
            this.TLRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.TLRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.TLRoot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.TLRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.TLRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLRoot.Size = new System.Drawing.Size(1167, 679);
            this.TLRoot.TabIndex = 0;
            this.TLRoot.Paint += new System.Windows.Forms.PaintEventHandler(this.TLRoot_Paint);
            // 
            // TLKPI
            // 
            this.TLKPI.ColumnCount = 3;
            this.TLKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 398F));
            this.TLKPI.Controls.Add(this.CardKpi1, 0, 0);
            this.TLKPI.Controls.Add(this.CardKpi2, 1, 0);
            this.TLKPI.Controls.Add(this.CardKpi3, 2, 0);
            this.TLKPI.Location = new System.Drawing.Point(3, 83);
            this.TLKPI.Name = "TLKPI";
            this.TLKPI.RowCount = 1;
            this.TLKPI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLKPI.Size = new System.Drawing.Size(1161, 104);
            this.TLKPI.TabIndex = 0;
            // 
            // PHeader
            // 
            this.PHeader.Controls.Add(this.LRol);
            this.PHeader.Controls.Add(this.LSub);
            this.PHeader.Controls.Add(this.LTitle);
            this.PHeader.Location = new System.Drawing.Point(3, 3);
            this.PHeader.Name = "PHeader";
            this.PHeader.Size = new System.Drawing.Size(1161, 74);
            this.PHeader.TabIndex = 1;
            // 
            // PBanner
            // 
            this.PBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(237)))));
            this.PBanner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PBanner.Controls.Add(this.BVerSoloBajo);
            this.PBanner.Controls.Add(this.LblBanner);
            this.PBanner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PBanner.Location = new System.Drawing.Point(3, 193);
            this.PBanner.Name = "PBanner";
            this.PBanner.Padding = new System.Windows.Forms.Padding(12);
            this.PBanner.Size = new System.Drawing.Size(1161, 100);
            this.PBanner.TabIndex = 2;
            // 
            // PFilters
            // 
            this.PFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PFilters.Controls.Add(this.TLFlters);
            this.PFilters.Cursor = System.Windows.Forms.Cursors.Default;
            this.PFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PFilters.Location = new System.Drawing.Point(10, 306);
            this.PFilters.Margin = new System.Windows.Forms.Padding(10);
            this.PFilters.Name = "PFilters";
            this.PFilters.Padding = new System.Windows.Forms.Padding(16);
            this.PFilters.Size = new System.Drawing.Size(1147, 140);
            this.PFilters.TabIndex = 3;
            this.PFilters.Paint += new System.Windows.Forms.PaintEventHandler(this.PFilters_Paint);
            // 
            // PListHeader
            // 
            this.PListHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PListHeader.Controls.Add(this.BNuevoproducto);
            this.PListHeader.Controls.Add(this.LListTitle);
            this.PListHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PListHeader.Location = new System.Drawing.Point(10, 466);
            this.PListHeader.Margin = new System.Windows.Forms.Padding(10);
            this.PListHeader.Name = "PListHeader";
            this.PListHeader.Padding = new System.Windows.Forms.Padding(12);
            this.PListHeader.Size = new System.Drawing.Size(1147, 52);
            this.PListHeader.TabIndex = 4;
            // 
            // PGrid
            // 
            this.PGrid.Location = new System.Drawing.Point(3, 531);
            this.PGrid.Name = "PGrid";
            this.PGrid.Size = new System.Drawing.Size(1161, 145);
            this.PGrid.TabIndex = 5;
            // 
            // LTitle
            // 
            this.LTitle.AutoSize = true;
            this.LTitle.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitle.Location = new System.Drawing.Point(11, 10);
            this.LTitle.Name = "LTitle";
            this.LTitle.Size = new System.Drawing.Size(185, 46);
            this.LTitle.TabIndex = 0;
            this.LTitle.Text = "Inventario";
            // 
            // LSub
            // 
            this.LSub.AutoSize = true;
            this.LSub.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSub.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LSub.Location = new System.Drawing.Point(188, 27);
            this.LSub.Name = "LSub";
            this.LSub.Size = new System.Drawing.Size(384, 23);
            this.LSub.TabIndex = 1;
            this.LSub.Text = ": Gestión completa del inventario de videojuegos";
            this.LSub.Click += new System.EventHandler(this.LSub_Click);
            // 
            // LRol
            // 
            this.LRol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LRol.AutoSize = true;
            this.LRol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.LRol.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LRol.Location = new System.Drawing.Point(1002, 21);
            this.LRol.Name = "LRol";
            this.LRol.Size = new System.Drawing.Size(110, 35);
            this.LRol.TabIndex = 2;
            this.LRol.Text = "Gerente";
            // 
            // CardKpi1
            // 
            this.CardKpi1.Controls.Add(this.LProductostotales);
            this.CardKpi1.Controls.Add(this.LCantproductosunicos);
            this.CardKpi1.Controls.Add(this.KpiTotal);
            this.CardKpi1.Location = new System.Drawing.Point(3, 3);
            this.CardKpi1.Name = "CardKpi1";
            this.CardKpi1.Size = new System.Drawing.Size(375, 98);
            this.CardKpi1.TabIndex = 0;
            // 
            // CardKpi2
            // 
            this.CardKpi2.Controls.Add(this.LStocktotal);
            this.CardKpi2.Controls.Add(this.LUnidadeseninventario);
            this.CardKpi2.Controls.Add(this.KpiStock);
            this.CardKpi2.Location = new System.Drawing.Point(384, 3);
            this.CardKpi2.Name = "CardKpi2";
            this.CardKpi2.Size = new System.Drawing.Size(375, 98);
            this.CardKpi2.TabIndex = 1;
            // 
            // CardKpi3
            // 
            this.CardKpi3.Controls.Add(this.LConstockbajo);
            this.CardKpi3.Controls.Add(this.LStockmenora);
            this.CardKpi3.Controls.Add(this.KpiBajo);
            this.CardKpi3.Location = new System.Drawing.Point(765, 3);
            this.CardKpi3.Name = "CardKpi3";
            this.CardKpi3.Size = new System.Drawing.Size(393, 98);
            this.CardKpi3.TabIndex = 2;
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
            // LStockmenora
            // 
            this.LStockmenora.AutoSize = true;
            this.LStockmenora.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LStockmenora.Location = new System.Drawing.Point(82, 73);
            this.LStockmenora.Name = "LStockmenora";
            this.LStockmenora.Size = new System.Drawing.Size(234, 16);
            this.LStockmenora.TabIndex = 2;
            this.LStockmenora.Text = "Productos menor o igual a ... unidades";
            // 
            // LblBanner
            // 
            this.LblBanner.AutoSize = true;
            this.LblBanner.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBanner.Location = new System.Drawing.Point(28, 38);
            this.LblBanner.Name = "LblBanner";
            this.LblBanner.Size = new System.Drawing.Size(672, 23);
            this.LblBanner.TabIndex = 0;
            this.LblBanner.Text = "Tienes 0 productos con stock bajo (≤ 5). Es recomendable reabastecer estos produc" +
    "tos.";
            this.LblBanner.Click += new System.EventHandler(this.LblBanner_Click);
            // 
            // BVerSoloBajo
            // 
            this.BVerSoloBajo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BVerSoloBajo.AutoSize = true;
            this.BVerSoloBajo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BVerSoloBajo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.BVerSoloBajo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BVerSoloBajo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.BVerSoloBajo.Location = new System.Drawing.Point(930, 37);
            this.BVerSoloBajo.Name = "BVerSoloBajo";
            this.BVerSoloBajo.Size = new System.Drawing.Size(134, 28);
            this.BVerSoloBajo.TabIndex = 1;
            this.BVerSoloBajo.Text = "Ver solo stock bajo";
            this.BVerSoloBajo.UseVisualStyleBackColor = true;
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
            this.TLFlters.Controls.Add(this.LFiltroNombre, 0, 0);
            this.TLFlters.Controls.Add(this.LFiltroID, 1, 0);
            this.TLFlters.Controls.Add(this.CBGenero, 2, 1);
            this.TLFlters.Controls.Add(this.BLimpiar, 1, 2);
            this.TLFlters.Controls.Add(this.BAplicar, 0, 2);
            this.TLFlters.Controls.Add(this.TBID, 1, 1);
            this.TLFlters.Controls.Add(this.TBNombre, 0, 1);
            this.TLFlters.Location = new System.Drawing.Point(-1, -1);
            this.TLFlters.Name = "TLFlters";
            this.TLFlters.RowCount = 3;
            this.TLFlters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLFlters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLFlters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLFlters.Size = new System.Drawing.Size(1147, 140);
            this.TLFlters.TabIndex = 0;
            this.TLFlters.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint_1);
            // 
            // LFiltroNombre
            // 
            this.LFiltroNombre.AutoSize = true;
            this.LFiltroNombre.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFiltroNombre.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LFiltroNombre.Location = new System.Drawing.Point(16, 1);
            this.LFiltroNombre.Margin = new System.Windows.Forms.Padding(15, 0, 0, 2);
            this.LFiltroNombre.Name = "LFiltroNombre";
            this.LFiltroNombre.Size = new System.Drawing.Size(156, 23);
            this.LFiltroNombre.TabIndex = 0;
            this.LFiltroNombre.Text = "Buscar por nombre";
            this.LFiltroNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LFiltroNombre.Click += new System.EventHandler(this.label1_Click);
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
            this.CBOrden.Location = new System.Drawing.Point(874, 50);
            this.CBOrden.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.CBOrden.Name = "CBOrden";
            this.CBOrden.Size = new System.Drawing.Size(269, 31);
            this.CBOrden.TabIndex = 3;
            // 
            // TBID
            // 
            this.TBID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBID.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBID.Location = new System.Drawing.Point(302, 50);
            this.TBID.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
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
            this.TBNombre.Location = new System.Drawing.Point(16, 50);
            this.TBNombre.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.TBNombre.MaxLength = 200;
            this.TBNombre.Name = "TBNombre";
            this.TBNombre.Size = new System.Drawing.Size(267, 30);
            this.TBNombre.TabIndex = 0;
            // 
            // BAplicar
            // 
            this.BAplicar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.BAplicar.FlatAppearance.BorderSize = 0;
            this.BAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAplicar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAplicar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BAplicar.Location = new System.Drawing.Point(16, 96);
            this.BAplicar.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.BAplicar.Name = "BAplicar";
            this.BAplicar.Size = new System.Drawing.Size(141, 40);
            this.BAplicar.TabIndex = 4;
            this.BAplicar.Text = "Aplicar filtros";
            this.BAplicar.UseVisualStyleBackColor = false;
            // 
            // BLimpiar
            // 
            this.BLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.BLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BLimpiar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BLimpiar.ForeColor = System.Drawing.Color.DimGray;
            this.BLimpiar.Location = new System.Drawing.Point(302, 96);
            this.BLimpiar.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.BLimpiar.Name = "BLimpiar";
            this.BLimpiar.Size = new System.Drawing.Size(91, 40);
            this.BLimpiar.TabIndex = 7;
            this.BLimpiar.Text = "Limpiar";
            this.BLimpiar.UseVisualStyleBackColor = true;
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
            this.CBGenero.Location = new System.Drawing.Point(588, 50);
            this.CBGenero.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.CBGenero.Name = "CBGenero";
            this.CBGenero.Size = new System.Drawing.Size(267, 31);
            this.CBGenero.TabIndex = 2;
            // 
            // LListTitle
            // 
            this.LListTitle.AutoSize = true;
            this.LListTitle.Font = new System.Drawing.Font("Segoe UI", 12.2F, System.Drawing.FontStyle.Bold);
            this.LListTitle.Location = new System.Drawing.Point(14, 8);
            this.LListTitle.Margin = new System.Windows.Forms.Padding(0);
            this.LListTitle.Name = "LListTitle";
            this.LListTitle.Size = new System.Drawing.Size(194, 30);
            this.LListTitle.TabIndex = 0;
            this.LListTitle.Text = "Lista de Productos";
            // 
            // BNuevoproducto
            // 
            this.BNuevoproducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BNuevoproducto.AutoSize = true;
            this.BNuevoproducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.BNuevoproducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BNuevoproducto.FlatAppearance.BorderSize = 0;
            this.BNuevoproducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BNuevoproducto.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNuevoproducto.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BNuevoproducto.Location = new System.Drawing.Point(938, 2);
            this.BNuevoproducto.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.BNuevoproducto.Name = "BNuevoproducto";
            this.BNuevoproducto.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.BNuevoproducto.Size = new System.Drawing.Size(182, 45);
            this.BNuevoproducto.TabIndex = 1;
            this.BNuevoproducto.Text = "+ Nuevo producto";
            this.BNuevoproducto.UseVisualStyleBackColor = false;
            // 
            // InventarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1182, 703);
            this.Controls.Add(this.TLRoot);
            this.Name = "InventarioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario";
            this.TLRoot.ResumeLayout(false);
            this.TLKPI.ResumeLayout(false);
            this.PHeader.ResumeLayout(false);
            this.PHeader.PerformLayout();
            this.PBanner.ResumeLayout(false);
            this.PBanner.PerformLayout();
            this.PFilters.ResumeLayout(false);
            this.PListHeader.ResumeLayout(false);
            this.PListHeader.PerformLayout();
            this.CardKpi1.ResumeLayout(false);
            this.CardKpi1.PerformLayout();
            this.CardKpi2.ResumeLayout(false);
            this.CardKpi2.PerformLayout();
            this.CardKpi3.ResumeLayout(false);
            this.CardKpi3.PerformLayout();
            this.TLFlters.ResumeLayout(false);
            this.TLFlters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLRoot;
        private System.Windows.Forms.TableLayoutPanel TLKPI;
        private System.Windows.Forms.Panel PHeader;
        private System.Windows.Forms.Panel PBanner;
        private System.Windows.Forms.Panel PFilters;
        private System.Windows.Forms.Panel PListHeader;
        private System.Windows.Forms.Panel PGrid;
        private System.Windows.Forms.Label LRol;
        private System.Windows.Forms.Label LSub;
        private System.Windows.Forms.Label LTitle;
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
        private System.Windows.Forms.Button BVerSoloBajo;
        private System.Windows.Forms.Label LblBanner;
        private System.Windows.Forms.TableLayoutPanel TLFlters;
        private System.Windows.Forms.Label LFiltroNombre;
        private System.Windows.Forms.Label LFiltroID;
        private System.Windows.Forms.Label LFiltroGenero;
        private System.Windows.Forms.Label LFiltroOrden;
        private System.Windows.Forms.ComboBox CBOrden;
        private System.Windows.Forms.TextBox TBID;
        private System.Windows.Forms.TextBox TBNombre;
        private System.Windows.Forms.ComboBox CBGenero;
        private System.Windows.Forms.Button BLimpiar;
        private System.Windows.Forms.Button BAplicar;
        private System.Windows.Forms.Label LListTitle;
        private System.Windows.Forms.Button BNuevoproducto;
    }
}