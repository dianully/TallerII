using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace PuntoDeVentaGameBox.Gerente
{
    public partial class Reportes : Form
    {
        private readonly string _connString =
            "Server=localhost;Database=game_box;Trusted_Connection=True;TrustServerCertificate=True";

        private readonly CultureInfo _culturaAR = new CultureInfo("es-AR");

        private bool _usarFiltroFechas = false;
        private DateTimePicker _dtpDesde;
        private DateTimePicker _dtpHasta;

        private DataTable _ultimoTopProductos;
        private DataTable _ultimoVendedores;

        private const int LIMITE_COMPACTO = 5;

        // === NUEVO: host de scroll (panel scrolleable si existe, sino el propio form) ===
        private ScrollableControl _scrollHost;

        public Reportes()
        {
            InitializeComponent();

            // === NUEVO: detectar host de scroll ===
            _scrollHost = Controls.Find("PNLScroll", true).FirstOrDefault() as ScrollableControl ?? this;

            if (BExportarPDF != null) { BExportarPDF.Click -= BExportarPDF_Click; BExportarPDF.Click += BExportarPDF_Click; }
            if (BExportarExcel != null) { BExportarExcel.Click -= BExportarExcel_Click; BExportarExcel.Click += BExportarExcel_Click; }

            if (BVerGraficosProductos != null) { BVerGraficosProductos.Click -= BVerGraficosProductos_Click; BVerGraficosProductos.Click += BVerGraficosProductos_Click; }
            if (BVerGraficosVendedores != null) { BVerGraficosVendedores.Click -= BVerGraficosVendedores_Click; BVerGraficosVendedores.Click += BVerGraficosVendedores_Click; }

            if (BMasVendidosExtendido != null) { BMasVendidosExtendido.Click -= BMasVendidosExtendido_Click; BMasVendidosExtendido.Click += BMasVendidosExtendido_Click; }
            if (BRendimientosExtendido != null) { BRendimientosExtendido.Click -= BRendimientosExtendido_Click; BRendimientosExtendido.Click += BRendimientosExtendido_Click; }
            if (BLimpiar != null) { BLimpiar.Click -= BLimpiar_Click; BLimpiar.Click += BLimpiar_Click; }
            if (BAplicarFiltros != null) { BAplicarFiltros.Click -= BAplicarFiltros_Click; BAplicarFiltros.Click += BAplicarFiltros_Click; }

            _dtpDesde = FindControl<DateTimePicker>("DTPDesde");
            _dtpHasta = FindControl<DateTimePicker>("DTPHasta") ?? FindControl<DateTimePicker>("DTMPHasta");

            if (_dtpDesde != null) { _dtpDesde.MaxDate = DateTime.Today; _dtpDesde.ValueChanged += FiltroFechas_ValueChanged; }
            if (_dtpHasta != null) { _dtpHasta.MaxDate = DateTime.Today; _dtpHasta.ValueChanged += FiltroFechas_ValueChanged; }

            // Estética botones (opcional)
            if (BVerGraficosProductos != null)
            {
                BVerGraficosProductos.BackColor = Color.White;
                BVerGraficosProductos.ForeColor = Color.Black;
                BVerGraficosProductos.FlatStyle = FlatStyle.Flat;
                BVerGraficosProductos.FlatAppearance.BorderColor = Color.DarkGray;
            }
            if (BVerGraficosVendedores != null)
            {
                BVerGraficosVendedores.BackColor = Color.White;
                BVerGraficosVendedores.ForeColor = Color.Black;
                BVerGraficosVendedores.FlatStyle = FlatStyle.Flat;
                BVerGraficosVendedores.FlatAppearance.BorderColor = Color.DarkGray;
            }

            // === NUEVO: doble buffer para menos parpadeo ===
            TryEnableDoubleBuffer(this);
            if (_scrollHost != null) TryEnableDoubleBuffer(_scrollHost);

            this.AutoScroll = _scrollHost == this ? true : this.AutoScroll; // si el form mismo scrollea
            this.DoubleBuffered = true;

            this.Load -= Reportes_Load;
            this.Load += Reportes_Load;
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            // Estado inicial: SIN filtro y sin datos
            _usarFiltroFechas = false;
            SetHoyEnPickers();
            WithScrollFrozen(LimpiarVistas);   // <- no carga nada hasta que se aplique filtro
        }

        // Solo valida y corrige rangos; no refresca datos
        private void FiltroFechas_ValueChanged(object sender, EventArgs e)
        {
            ValidarYCorregirRango();
        }

        private void BLimpiar_Click(object sender, EventArgs e)
        {
            WithScrollFrozen(() =>
            {
                _usarFiltroFechas = false;
                SetHoyEnPickers();
                LimpiarVistas();        // <- deja todo vacío
            });
        }

        private void BAplicarFiltros_Click(object sender, EventArgs e)
        {
            WithScrollFrozen(() =>
            {
                ValidarYCorregirRango();
                _usarFiltroFechas = true;
                RefrescarTodo();        // <- recién acá se cargan datos
            });
        }

        private void BVerGraficosProductos_Click(object sender, EventArgs e)
        {
            DateTime? d = null, h = null;
            if (_usarFiltroFechas)
            {
                var r = ObtenerRangoFechas();
                d = r.desde; h = r.hasta;
            }
            using (var frm = new GraficosProductos(_connString, d, h))
                frm.ShowDialog(this);
        }

        private void BVerGraficosVendedores_Click(object sender, EventArgs e)
        {
            DateTime? d = null, h = null;
            if (_usarFiltroFechas)
            {
                var r = ObtenerRangoFechas();
                d = r.desde; h = r.hasta;
            }
            using (var frm = new GraficosVendedores(_connString, d, h))
                frm.ShowDialog(this);
        }

        private void BMasVendidosExtendido_Click(object sender, EventArgs e)
        {
            if (_ultimoTopProductos == null || _ultimoTopProductos.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos de Productos Más Vendidos para mostrar.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (var frm = new MasVendidosExtendido(_ultimoTopProductos))
                frm.ShowDialog(this);
        }

        private void BRendimientosExtendido_Click(object sender, EventArgs e)
        {
            if (_ultimoVendedores == null || _ultimoVendedores.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos de Rendimiento por Vendedor para mostrar.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (var frm = new RendimientosVendedorExtendido(_ultimoVendedores))
                frm.ShowDialog(this);
        }

        // ================== REFRESH ==================
        private void RefrescarTodo()
        {
            // Congelamos layout/scroll en todas las secciones para evitar “salto”
            WithScrollFrozen(() =>
            {
                CargarKPIs();
                CargarTopProductos();
                CargarVendedores();
            });
        }

        // ================== KPIs ==================
        private void CargarKPIs()
        {
            string sqlVentas = @"
SELECT 
    SUM(f.total)      AS TotalVentas,
    COUNT(*)          AS CantVentas,
    AVG(f.total)      AS TicketPromedio
FROM dbo.factura f
WHERE (f.activo = 1 OR f.activo IS NULL)";
            if (_usarFiltroFechas)
                sqlVentas += " AND f.fecha_compra BETWEEN @desde AND @hasta";

            string sqlProductosActivos = @"SELECT COUNT(*) AS CantProductos FROM dbo.producto WHERE activo = 1;";

            using (var cn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sqlVentas, cn))
            {
                if (_usarFiltroFechas)
                {
                    var (desde, hasta) = ObtenerRangoFechas();
                    cmd.Parameters.Add(new SqlParameter("@desde", desde));
                    cmd.Parameters.Add(new SqlParameter("@hasta", hasta));
                }
                else
                {
                    // Si no hay filtro, mostramos guiones y salimos
                    if (LPesosTotalDinero != null) LPesosTotalDinero.Text = "—";
                    if (LNroVentas != null) LNroVentas.Text = "—";
                    if (LTicketPromedio != null) LTicketPromedio.Text = "—";
                    if (LCantProductos != null)
                    {
                        // Cant. productos activos sí puede mostrarse sin filtro (stock actual).
                        using (var cn2 = new SqlConnection(_connString))
                        using (var cmdProd2 = new SqlCommand(sqlProductosActivos, cn2))
                        {
                            cn2.Open();
                            var cant = Convert.ToInt32(cmdProd2.ExecuteScalar() ?? 0);
                            LCantProductos.Text = cant.ToString("N0");
                        }
                    }
                    return;
                }

                cn.Open();

                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        decimal total = rd.IsDBNull(0) ? 0 : rd.GetDecimal(0);
                        int ventas = rd.IsDBNull(1) ? 0 : rd.GetInt32(1);
                        decimal ticket = rd.IsDBNull(2) ? 0 : rd.GetDecimal(2);

                        if (LPesosTotalDinero != null) LPesosTotalDinero.Text = total.ToString("C2", _culturaAR);
                        if (LNroVentas != null) LNroVentas.Text = ventas.ToString("N0");
                        if (LTicketPromedio != null) LTicketPromedio.Text = ticket.ToString("C2", _culturaAR);
                    }
                }

                using (var cmdProd = new SqlCommand(sqlProductosActivos, cn))
                {
                    var cant = Convert.ToInt32(cmdProd.ExecuteScalar() ?? 0);
                    if (LCantProductos != null) LCantProductos.Text = cant.ToString("N0");
                }
            }
        }

        // ================== TOP PRODUCTOS ==================
        private void CargarTopProductos()
        {
            string sql = @"
    SELECT TOP (@lim)
        p.nombre AS [Videojuego],
        SUM(fd.cantidad) AS [Unidades Vendidas],
        SUM(fd.cantidad * fd.precio) AS [Ingresos]
    FROM dbo.factura f
    JOIN dbo.factura_detalle fd ON fd.id_factura_cabecera = f.id_factura
    JOIN dbo.producto p ON p.id_producto = fd.id_producto
    WHERE (f.activo = 1 OR f.activo IS NULL)
      {RANGO_FECHA}
    GROUP BY p.nombre
    ORDER BY [Unidades Vendidas] DESC;";

            sql = sql.Replace("{RANGO_FECHA}", _usarFiltroFechas ? "AND f.fecha_compra BETWEEN @desde AND @hasta" : "");

            SqlParameter[] ps;
            if (_usarFiltroFechas)
            {
                var (desde, hasta) = ObtenerRangoFechas();
                ps = new SqlParameter[] {
                    new SqlParameter("@lim", LIMITE_COMPACTO),
                    new SqlParameter("@desde", desde),
                    new SqlParameter("@hasta", hasta)
                };
            }
            else
            {
                ps = new SqlParameter[] { new SqlParameter("@lim", LIMITE_COMPACTO) };
            }

            var dt = _usarFiltroFechas ? GetDataTable(sql, ps) : new DataTable(); // vacío si no hay filtro
            _ultimoTopProductos = dt;

            if (DGVTopProductos != null)
            {
                // Encapsulamos el rebind para que no resetee scroll
                WithScrollFrozen(() =>
                {
                    DGVTopProductos.SuspendLayout();
                    DGVTopProductos.Columns.Clear();
                    DGVTopProductos.AutoGenerateColumns = true;
                    DGVTopProductos.DataSource = dt;
                    AplicarEstiloCompacto(DGVTopProductos);
                    FormatearMoneda(DGVTopProductos, "Ingresos");
                    DGVTopProductos.ResumeLayout();
                });
            }
        }

        // ================== VENDEDOR ==================
        private void CargarVendedores()
        {
            string sql = @"
    SELECT TOP (@lim)
        u.nombre AS [Vendedor],
        SUM(f.total) AS [Total Dinero en Ventas],
        COUNT(*) AS [Ventas],
        AVG(f.total) AS [Ticket Promedio]
    FROM dbo.factura f
    JOIN dbo.usuario u ON u.id_usuario = f.id_usuario
    WHERE (f.activo = 1 OR f.activo IS NULL)
      {RANGO_FECHA}
    GROUP BY u.nombre
    ORDER BY [Total Dinero en Ventas] DESC;";

            sql = sql.Replace("{RANGO_FECHA}", _usarFiltroFechas ? "AND f.fecha_compra BETWEEN @desde AND @hasta" : "");

            SqlParameter[] ps;
            if (_usarFiltroFechas)
            {
                var (desde, hasta) = ObtenerRangoFechas();
                ps = new SqlParameter[] {
                    new SqlParameter("@lim", LIMITE_COMPACTO),
                    new SqlParameter("@desde", desde),
                    new SqlParameter("@hasta", hasta)
                };
            }
            else
            {
                ps = new SqlParameter[] { new SqlParameter("@lim", LIMITE_COMPACTO) };
            }

            var dt = _usarFiltroFechas ? GetDataTable(sql, ps) : new DataTable(); // vacío si no hay filtro
            _ultimoVendedores = dt;

            if (DGVVendedores != null)
            {
                WithScrollFrozen(() =>
                {
                    DGVVendedores.SuspendLayout();
                    DGVVendedores.Columns.Clear();
                    DGVVendedores.AutoGenerateColumns = true;
                    DGVVendedores.DataSource = dt;
                    AplicarEstiloCompacto(DGVVendedores);
                    FormatearMoneda(DGVVendedores, "Total Dinero en Ventas");
                    FormatearMoneda(DGVVendedores, "Ticket Promedio");
                    DGVVendedores.ResumeLayout();
                });
            }
        }

        // ================== EXPORTAR PDF ==================
        private void BExportarPDF_Click(object sender, EventArgs e)
        {
            if ((_ultimoTopProductos == null || _ultimoTopProductos.Rows.Count == 0) &&
                (_ultimoVendedores == null || _ultimoVendedores.Rows.Count == 0))
            {
                MessageBox.Show("No hay datos para exportar. Aplicá filtros primero.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                //  Ruta fija para guardar los PDFs
                string folder = @"C:\Users\diana\source\repos\Taller\PuntoDeVentaGameBox\PDFGameBox";

                Directory.CreateDirectory(folder);
                string filePath = Path.Combine(folder, $"Reporte_Ventas_{DateTime.Now:yyyyMMdd_HHmm}.pdf");

                string periodoTexto =
                    _usarFiltroFechas
                        ? $"{(_dtpDesde != null ? _dtpDesde.Value : DateTime.Today):dd/MM/yyyy} - {(_dtpHasta != null ? _dtpHasta.Value : DateTime.Today):dd/MM/yyyy}"
                        : "(sin filtros)";

                Document doc = new Document(PageSize.A4, 30, 30, 40, 30);
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                var fontTitulo = FontFactory.GetFont("Helvetica", 16f, iTextSharp.text.Font.BOLD);
                var fontSub = FontFactory.GetFont("Helvetica", 12f, iTextSharp.text.Font.BOLD);

                Paragraph titulo = new Paragraph("REPORTE DE VENTAS", fontTitulo)
                {
                    Alignment = Element.ALIGN_CENTER
                };
                doc.Add(titulo);
                doc.Add(new Paragraph($"Generado el: {DateTime.Now:G}"));
                doc.Add(new Paragraph($"Período: {periodoTexto}\n"));

                // === Sección Productos ===
                doc.Add(new Paragraph("\nProductos Más Vendidos\n", fontSub));
                PdfPTable t1 = new PdfPTable(DGVTopProductos.Columns.Count)
                {
                    WidthPercentage = 100
                };
                foreach (DataGridViewColumn c in DGVTopProductos.Columns)
                    t1.AddCell(new Phrase(c.HeaderText));
                foreach (DataGridViewRow r in DGVTopProductos.Rows)
                {
                    if (r.IsNewRow) continue;
                    foreach (DataGridViewCell cell in r.Cells)
                        t1.AddCell(cell.Value?.ToString() ?? "");
                }
                doc.Add(t1);

                // === Sección Vendedores ===
                doc.Add(new Paragraph("\nRendimiento por Vendedor\n", fontSub));
                PdfPTable t2 = new PdfPTable(DGVVendedores.Columns.Count)
                {
                    WidthPercentage = 100
                };
                foreach (DataGridViewColumn c in DGVVendedores.Columns)
                    t2.AddCell(new Phrase(c.HeaderText));
                foreach (DataGridViewRow r in DGVVendedores.Rows)
                {
                    if (r.IsNewRow) continue;
                    foreach (DataGridViewCell cell in r.Cells)
                        t2.AddCell(cell.Value?.ToString() ?? "");
                }
                doc.Add(t2);

                doc.Close();

                MessageBox.Show($"PDF generado correctamente en:\n{filePath}",
                    "Exportación completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar el PDF:\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ================== EXPORTAR EXCEL (EPPlus si está, CSV si no) ==================
        private void BExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Ruta fija para guardar los Excels
                string folder = @"C:\Users\diana\source\repos\Taller\PuntoDeVentaGameBox\ExcelGameBox";

                Directory.CreateDirectory(folder);
                string filePath = Path.Combine(folder, $"Reporte_Ventas_{DateTime.Now:yyyyMMdd_HHmm}.xlsx");

                string periodoTexto =
                    $"{(_dtpDesde != null ? _dtpDesde.Value : DateTime.Today):dd/MM/yyyy} - " +
                    $"{(_dtpHasta != null ? _dtpHasta.Value : DateTime.Today):dd/MM/yyyy}";

                // Intentar configurar EPPlus
                bool licenseOk = TryConfigureEpplusLicense();
                if (!licenseOk)
                {
                    string csvPath = Path.ChangeExtension(filePath, ".csv");
                    ExportWholeReportToSingleCsv(csvPath, periodoTexto);
                    MessageBox.Show($"No se pudo configurar EPPlus.\nSe generó un CSV en:\n{csvPath}",
                        "Exportación (CSV)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // === Generar Excel ===
                using (var package = new OfficeOpenXml.ExcelPackage())
                {
                    // Hoja 1 - Productos
                    var ws1 = package.Workbook.Worksheets.Add("Productos Más Vendidos");
                    ws1.Cells["A1"].Value = "Reporte de Ventas - Productos Más Vendidos";
                    ws1.Cells["A1"].Style.Font.Bold = true;
                    ws1.Cells["A2"].Value = $"Generado: {DateTime.Now:G}";
                    ws1.Cells["A3"].Value = $"Período: {periodoTexto}";
                    ws1.Cells["A5"].LoadFromDataTable(_ultimoTopProductos, true);

                    // Hoja 2 - Vendedores
                    var ws2 = package.Workbook.Worksheets.Add("Rendimiento por Vendedor");
                    ws2.Cells["A1"].Value = "Reporte de Ventas - Rendimiento por Vendedor";
                    ws2.Cells["A1"].Style.Font.Bold = true;
                    ws2.Cells["A2"].Value = $"Generado: {DateTime.Now:G}";
                    ws2.Cells["A3"].Value = $"Período: {periodoTexto}";
                    ws2.Cells["A5"].LoadFromDataTable(_ultimoVendedores, true);

                    if (ws1.Dimension != null) ws1.Cells[ws1.Dimension.Address].AutoFitColumns();
                    if (ws2.Dimension != null) ws2.Cells[ws2.Dimension.Address].AutoFitColumns();

                    // Protección simple (solo lectura)
                    package.Workbook.Protection.LockStructure = true;
                    foreach (var ws in package.Workbook.Worksheets)
                    {
                        ws.Cells.Style.Locked = true;
                        ws.Protection.IsProtected = true;
                        ws.Protection.AllowSelectLockedCells = true;
                    }

                    package.SaveAs(new FileInfo(filePath));
                }

                MessageBox.Show($"Excel generado correctamente en:\n{filePath}",
                    "Exportación completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string folder = @"C:\Users\diana\OneDrive\Desktop\FACULTAD\FACULTAD 2025\Cuatrimestre 2\TPII\ExcelGameBox";
                Directory.CreateDirectory(folder);
                string csvPath = Path.Combine(folder, $"Reporte_Ventas_{DateTime.Now:yyyyMMdd_HHmm}.csv");

                ExportWholeReportToSingleCsv(csvPath,
                    $"{(_dtpDesde != null ? _dtpDesde.Value : DateTime.Today):dd/MM/yyyy} - {(_dtpHasta != null ? _dtpHasta.Value : DateTime.Today):dd/MM/yyyy}");

                MessageBox.Show(
                    "No se pudo generar el .xlsx. Se creó un archivo CSV como alternativa en:\n" + csvPath +
                    "\n\nDetalles del error:\n" + ex.Message,
                    "Exportación alternativa (CSV)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private bool TryExportXlsxWithEpplus(string filePath, string periodoTexto)
        {
            var epType = Type.GetType("OfficeOpenXml.ExcelPackage, EPPlus");
            if (epType == null) return false;

            dynamic package = Activator.CreateInstance(epType);

            try
            {
                var licProp = epType.GetProperty("LicenseContext");
                if (licProp != null)
                {
                    var licenseContextType = licProp.PropertyType;
                    var nonComm = Enum.Parse(licenseContextType, "NonCommercial");
                    licProp.SetValue(null, nonComm, null);
                }

                dynamic wb = package.Workbook;

                dynamic ws1 = wb.Worksheets.Add("Productos Más Vendidos");
                ws1.Cells["A1"].Value = "Reporte de Ventas - Productos Más Vendidos";
                ws1.Cells["A1"].Style.Font.Bold = true;
                ws1.Cells["A2"].Value = "Generado: " + DateTime.Now.ToString("G");
                ws1.Cells["A3"].Value = "Período: " + periodoTexto;
                ws1.Cells["A5"].LoadFromDataTable(_ultimoTopProductos, true);

                dynamic ws2 = wb.Worksheets.Add("Rendimiento por Vendedor");
                ws2.Cells["A1"].Value = "Reporte de Ventas - Rendimiento por Vendedor";
                ws2.Cells["A1"].Style.Font.Bold = true;
                ws2.Cells["A2"].Value = "Generado: " + DateTime.Now.ToString("G");
                ws2.Cells["A3"].Value = "Período: " + periodoTexto;
                ws2.Cells["A5"].LoadFromDataTable(_ultimoVendedores, true);

                if (ws1.Dimension != null) ws1.Cells[ws1.Dimension.Address].AutoFitColumns();
                if (ws2.Dimension != null) ws2.Cells[ws2.Dimension.Address].AutoFitColumns();

                package.SaveAs(new FileInfo(filePath));
                return true;
            }
            finally
            {
                try { package.Dispose(); } catch { }
            }
        }

        private void ExportDataTableToCsv(DataTable dt, string path)
        {
            using (var sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(string.Join(";", dt.Columns.Cast<DataColumn>().Select(c => EscapeCsv(c.ColumnName))));
                foreach (DataRow r in dt.Rows)
                    sw.WriteLine(string.Join(";", dt.Columns.Cast<DataColumn>().Select(c => EscapeCsv(Convert.ToString(r[c])))));
            }
        }

        private string EscapeCsv(string s)
        {
            if (s == null) return "";
            if (s.Contains(";") || s.Contains("\"") || s.Contains("\n"))
                return "\"" + s.Replace("\"", "\"\"") + "\"";
            return s;
        }

        // ================== HELPERS ==================

        // EPPlus
        private bool TryConfigureEpplusLicense()
        {
            try
            {
#pragma warning disable CS0618
                OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
#pragma warning restore CS0618
                return true;
            }
            catch
            {
                return false;
            }
        }

        // CSV único
        private void ExportWholeReportToSingleCsv(string path, string periodoTexto)
        {
            using (var sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                // Encabezado general
                sw.WriteLine("Reporte de Ventas");
                sw.WriteLine("Generado: " + DateTime.Now.ToString("G"));
                sw.WriteLine("Período: " + periodoTexto);
                sw.WriteLine();

                // Sección Productos
                sw.WriteLine("Productos Más Vendidos");
                sw.WriteLine(string.Join(";", _ultimoTopProductos.Columns
                    .Cast<DataColumn>().Select(c => EscapeCsv(c.ColumnName))));
                foreach (DataRow r in _ultimoTopProductos.Rows)
                    sw.WriteLine(string.Join(";", _ultimoTopProductos.Columns
                        .Cast<DataColumn>().Select(c => EscapeCsv(Convert.ToString(r[c])))));
                sw.WriteLine();

                // Sección Vendedores
                sw.WriteLine("Rendimiento por Vendedor");
                sw.WriteLine(string.Join(";", _ultimoVendedores.Columns
                    .Cast<DataColumn>().Select(c => EscapeCsv(c.ColumnName))));
                foreach (DataRow r in _ultimoVendedores.Rows)
                    sw.WriteLine(string.Join(";", _ultimoVendedores.Columns
                        .Cast<DataColumn>().Select(c => EscapeCsv(Convert.ToString(r[c])))));
            }
        }

        private void AplicarEstiloCompacto(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.ReadOnly = true;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;

            dgv.RowHeadersVisible = false;
            dgv.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            dgv.AutoGenerateColumns = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dgv.ScrollBars = ScrollBars.Vertical;

            foreach (DataGridViewColumn c in dgv.Columns)
            {
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
                c.MinimumWidth = 80;
            }

            TryEnableDoubleBuffer(dgv);
        }

        private (DateTime desde, DateTime hasta) ObtenerRangoFechas()
        {
            DateTime desde = _dtpDesde?.Value.Date ?? DateTime.Today;
            DateTime hasta = (_dtpHasta?.Value.Date ?? DateTime.Today).AddDays(1).AddTicks(-1);
            return (desde, hasta);
        }

        private DataTable GetDataTable(string sql, SqlParameter[] ps = null)
        {
            using (var cn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sql, cn))
            using (var da = new SqlDataAdapter(cmd))
            {
                if (ps != null && ps.Length > 0) cmd.Parameters.AddRange(ps);
                var dt = new DataTable();
                cn.Open();
                da.Fill(dt);
                return dt;
            }
        }

        private void FormatearMoneda(DataGridView dgv, string colName)
        {
            if (dgv == null || !dgv.Columns.Contains(colName)) return;
            dgv.Columns[colName].DefaultCellStyle.FormatProvider = _culturaAR;
            dgv.Columns[colName].DefaultCellStyle.Format = "C2";
            dgv.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void SetHoyEnPickers()
        {
            var hoy = DateTime.Today;
            if (_dtpDesde != null) { _dtpDesde.MaxDate = hoy; _dtpDesde.Value = hoy; }
            if (_dtpHasta != null) { _dtpHasta.MaxDate = hoy; _dtpHasta.Value = hoy; }
        }

        // Deja KPIs y DGVs vacíos/guiones (estado por defecto o tras Limpiar)
        private void LimpiarVistas()
        {
            // KPIs
            if (LPesosTotalDinero != null) LPesosTotalDinero.Text = "—";
            if (LNroVentas != null) LNroVentas.Text = "—";
            if (LTicketPromedio != null) LTicketPromedio.Text = "—";
            if (LCantProductos != null)
            {
                // Podrías mostrar stock actual; lo dejo en "—" para consistencia.
                LCantProductos.Text = "—";
            }

            // DGVs
            _ultimoTopProductos = new DataTable();
            _ultimoVendedores = new DataTable();

            if (DGVTopProductos != null)
            {
                DGVTopProductos.SuspendLayout();
                DGVTopProductos.Columns.Clear();
                DGVTopProductos.DataSource = _ultimoTopProductos;
                DGVTopProductos.ResumeLayout();
            }
            if (DGVVendedores != null)
            {
                DGVVendedores.SuspendLayout();
                DGVVendedores.Columns.Clear();
                DGVVendedores.DataSource = _ultimoVendedores;
                DGVVendedores.ResumeLayout();
            }
        }

        // Garantiza: Desde <= Hasta y Hasta <= Hoy
        private void ValidarYCorregirRango()
        {
            var hoy = DateTime.Today;

            if (_dtpHasta != null && _dtpHasta.Value.Date > hoy)
                _dtpHasta.Value = hoy;

            if (_dtpDesde != null && _dtpDesde.Value.Date > hoy)
                _dtpDesde.Value = hoy;

            if (_dtpDesde != null && _dtpHasta != null &&
                _dtpDesde.Value.Date > _dtpHasta.Value.Date)
            {
                _dtpHasta.Value = _dtpDesde.Value.Date;
            }
        }

        private void TryUncheck(DateTimePicker dtp)
        {
            if (dtp == null) return;
            try { dtp.Checked = false; } catch { }
        }

        private T FindControl<T>(string name) where T : class
        {
            var arr = Controls.Find(name, true);
            return arr.Length > 0 ? arr[0] as T : null;
        }

        // ====== NUEVO: helpers anti “mini recarga” / preservación de scroll ======

        private void WithScrollFrozen(Action uiWork)
        {
            if (uiWork == null) return;

            if (_scrollHost == null)
            {
                // fallback simple
                this.SuspendLayout();
                try { uiWork(); }
                finally { this.ResumeLayout(true); }
                return;
            }

            // Guardar posición de scroll actual
            int v = _scrollHost.VerticalScroll.Visible ? _scrollHost.VerticalScroll.Value : 0;
            int h = _scrollHost.HorizontalScroll.Visible ? _scrollHost.HorizontalScroll.Value : 0;

            _scrollHost.SuspendLayout();
            this.SuspendLayout();
            try
            {
                uiWork();
            }
            finally
            {
                // Restaurar scroll y reanudar layout
                _scrollHost.ResumeLayout(false);
                this.ResumeLayout(false);

                // WinForms usa AutoScrollPosition (coordenadas positivas → se convierten a negativas internamente)
                try
                {
                    // Clampear por seguridad
                    v = Math.Max(0, Math.Min(v, _scrollHost.VerticalScroll.Maximum));
                    h = Math.Max(0, Math.Min(h, _scrollHost.HorizontalScroll.Maximum));

                    _scrollHost.AutoScrollPosition = new Point(h, v);
                    // Algunas veces necesita un PerformLayout para aplicar
                    _scrollHost.PerformLayout();
                }
                catch { /* ignorar si no aplica */ }
            }
        }

        private void TryEnableDoubleBuffer(Control c)
        {
            try
            {
                var prop = typeof(Control).GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic);
                prop?.SetValue(c, true, null);
            }
            catch { }
        }

        // Stubs del diseñador
        private void TPLRoot_Paint(object sender, PaintEventArgs e) { }
        private void PNLScroll_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e) { }
        private void LResumenTitulo_Click(object sender, EventArgs e) { }
        private void PCardTotal_Paint(object sender, PaintEventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void GVTopProductos_Enter(object sender, EventArgs e) { }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) { }
    }
}
