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
using OfficeOpenXml;

namespace PuntoDeVentaGameBox.Gerente
{
    public partial class Reportes : Form
    {
        // Cadena conexión fija (local)
        private readonly string _connString =
            "Server=localhost;Database=game_box;Trusted_Connection=True;TrustServerCertificate=True";

        // Cultura moneda ARS (para formato $)
        private readonly CultureInfo _culturaAR = new CultureInfo("es-AR");

        // Filtro de fechas
        private bool _usarFiltroFechas = false;
        private DateTimePicker _dtpDesde;
        private DateTimePicker _dtpHasta;

        // Data cache para expandir/exportar
        private DataTable _ultimoTopProductos;
        private DataTable _ultimoVendedores;

        public Reportes()
        {
            InitializeComponent();

            // === BOTONES EXPORTAR ===
            if (BExportarPDF != null)
            {
                BExportarPDF.Click -= BExportarPDF_Click;
                BExportarPDF.Click += BExportarPDF_Click;
            }

            if (BExportarExcel != null)
            {
                BExportarExcel.Click -= BExportarExcel_Click;
                BExportarExcel.Click += BExportarExcel_Click;
            }

            // === BOTONES GRAFICOS ===
            if (BVerGraficosProductos != null)
            {
                BVerGraficosProductos.Click -= BVerGraficosProductos_Click;
                BVerGraficosProductos.Click += BVerGraficosProductos_Click;
            }

            if (BVerGraficosVendedores != null)
            {
                BVerGraficosVendedores.Click -= BVerGraficosVendedores_Click;
                BVerGraficosVendedores.Click += BVerGraficosVendedores_Click;
            }

            // === BOTONES EXPANDIR DGVs ===
            if (BMasVendidosExtendido != null)
            {
                BMasVendidosExtendido.Click -= BMasVendidosExtendido_Click;
                BMasVendidosExtendido.Click += BMasVendidosExtendido_Click;
            }

            if (BRendimientosExtendido != null)
            {
                BRendimientosExtendido.Click -= BRendimientosExtendido_Click;
                BRendimientosExtendido.Click += BRendimientosExtendido_Click;
            }

            // === DATEPICKERS RANGO ===
            _dtpDesde = FindControl<DateTimePicker>("DTPDesde");
            _dtpHasta = FindControl<DateTimePicker>("DTPHasta") ?? FindControl<DateTimePicker>("DTMPHasta");

            if (_dtpDesde != null)
                _dtpDesde.ValueChanged += FiltroFechas_ValueChanged;

            if (_dtpHasta != null)
                _dtpHasta.ValueChanged += FiltroFechas_ValueChanged;

            // === BOTON LIMPIAR ===
            if (BLimpiar != null)
            {
                BLimpiar.Click -= BLimpiar_Click;
                BLimpiar.Click += BLimpiar_Click;
            }

            // === LOAD DEL FORM ===
            this.Load -= Reportes_Load;
            this.Load += Reportes_Load;
        }

        // ================== EVENTOS GENERALES ==================

        private void Reportes_Load(object sender, EventArgs e)
        {
            _usarFiltroFechas = false;
            TryUncheck(_dtpDesde);
            TryUncheck(_dtpHasta);
            RefrescarTodo();
        }

        private void FiltroFechas_ValueChanged(object sender, EventArgs e)
        {
            _usarFiltroFechas = true;

            // coherencia: desde <= hasta
            if (_dtpDesde != null && _dtpHasta != null && _dtpDesde.Value.Date > _dtpHasta.Value.Date)
                _dtpHasta.Value = _dtpDesde.Value;

            RefrescarTodo();
        }

        private void BLimpiar_Click(object sender, EventArgs e)
        {
            _usarFiltroFechas = false;
            TryUncheck(_dtpDesde);
            TryUncheck(_dtpHasta);
            RefrescarTodo();
        }

        private void BVerGraficosProductos_Click(object sender, EventArgs e)
        {
            using (var frm = new GraficosProductos())
                frm.ShowDialog(this);
        }

        private void BVerGraficosVendedores_Click(object sender, EventArgs e)
        {
            using (var frm = new GraficosVendedores())
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

        // ================== REFRESCAR TODA LA INFO ==================

        private void RefrescarTodo()
        {
            CargarKPIs();
            CargarTopProductos();
            CargarVendedores();
        }

        // ================== CARDS KPI ==================

        private void CargarKPIs()
        {
            string sqlVentas = @"
SELECT 
    SUM(f.total)      AS TotalVentas,
    COUNT(*)          AS CantVentas,
    AVG(f.total)      AS TicketPromedio
FROM dbo.factura f
WHERE (f.activo = 1 OR f.activo IS NULL)
";

            string sqlProductosActivos = @"SELECT COUNT(*) AS CantProductos FROM dbo.producto WHERE activo = 1;";

            using (var cn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(
                sqlVentas + RangoWhere(" AND f.fecha_compra BETWEEN @desde AND @hasta", _usarFiltroFechas),
                cn))
            {
                if (_usarFiltroFechas)
                {
                    var (desde, hasta) = ObtenerRangoFechas();
                    cmd.Parameters.Add(new SqlParameter("@desde", desde));
                    cmd.Parameters.Add(new SqlParameter("@hasta", hasta));
                }

                cn.Open();

                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        decimal total = rd.IsDBNull(0) ? 0 : rd.GetDecimal(0);
                        int ventas = rd.IsDBNull(1) ? 0 : rd.GetInt32(1);
                        decimal ticket = rd.IsDBNull(2) ? 0 : rd.GetDecimal(2);

                        LPesosTotalDinero.Text = total.ToString("C2", _culturaAR);
                        LNroVentas.Text = ventas.ToString("N0");
                        LTicketPromedio.Text = ticket.ToString("C2", _culturaAR);
                    }
                }

                using (var cmdProd = new SqlCommand(sqlProductosActivos, cn))
                {
                    LCantProductos.Text = Convert.ToInt32(cmdProd.ExecuteScalar() ?? 0).ToString("N0");
                }
            }
        }

        // ================== GRID: PRODUCTOS MÁS VENDIDOS ==================

        private void CargarTopProductos()
        {
            string sql = @"
SELECT TOP (20)
    p.nombre AS [Videojuego],
    SUM(fd.cantidad) AS [Unidades Vendidas],
    SUM(fd.cantidad * fd.precio) AS [Ingresos]
FROM dbo.factura f
JOIN dbo.factura_detalle fd ON fd.id_factura_cabecera = f.id_factura
JOIN dbo.producto p ON p.id_producto = fd.id_producto
WHERE (f.activo = 1 OR f.activo IS NULL)
  {__RANGO__}
GROUP BY p.nombre
ORDER BY [Unidades Vendidas] DESC;";

            sql = sql.Replace("{__RANGO__}", _usarFiltroFechas ? "AND f.fecha_compra BETWEEN @desde AND @hasta" : "");

            var dt = GetDataTable(sql, _usarFiltroFechas ? ObtenerParametrosRango() : null);
            _ultimoTopProductos = dt;

            DGVTopProductos.Columns.Clear();
            DGVTopProductos.AutoGenerateColumns = true;
            DGVTopProductos.DataSource = dt;
            FormatearMoneda(DGVTopProductos, "Ingresos");
            DGVTopProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ================== GRID: RENDIMIENTO POR VENDEDOR ==================

        private void CargarVendedores()
        {
            string sql = @"
SELECT
    u.nombre AS [Vendedor],
    SUM(f.total) AS [Total Dinero en Ventas],
    COUNT(*) AS [Ventas],
    AVG(f.total) AS [Ticket Promedio]
FROM dbo.factura f
JOIN dbo.usuario u ON u.id_usuario = f.id_usuario
WHERE (f.activo = 1 OR f.activo IS NULL)
  {__RANGO__}
GROUP BY u.nombre
ORDER BY [Total Dinero en Ventas] DESC;";

            sql = sql.Replace("{__RANGO__}", _usarFiltroFechas ? "AND f.fecha_compra BETWEEN @desde AND @hasta" : "");

            var dt = GetDataTable(sql, _usarFiltroFechas ? ObtenerParametrosRango() : null);
            _ultimoVendedores = dt;

            DGVVendedores.Columns.Clear();
            DGVVendedores.AutoGenerateColumns = true;
            DGVVendedores.DataSource = dt;
            FormatearMoneda(DGVVendedores, "Total Dinero en Ventas");
            FormatearMoneda(DGVVendedores, "Ticket Promedio");
            DGVVendedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ================== EXPORTAR PDF ==================

        private void BExportarPDF_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog()
            {
                Title = "Guardar reporte como PDF",
                Filter = "PDF (*.pdf)|*.pdf",
                FileName = $"Reporte_Ventas_{DateTime.Now:yyyyMMdd_HHmm}.pdf"
            })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;

                string filePath = sfd.FileName;

                // Documento PDF A4 con márgenes
                Document doc = new Document(PageSize.A4, 30, 30, 40, 30);
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                // Fuentes para título y subtítulo
                var fontTitulo = new iTextSharp.text.Font(
                    iTextSharp.text.Font.FontFamily.HELVETICA,
                    16f,
                    iTextSharp.text.Font.BOLD
                );

                var fontSubtitulo = new iTextSharp.text.Font(
                    iTextSharp.text.Font.FontFamily.HELVETICA,
                    12f,
                    iTextSharp.text.Font.BOLD
                );

                // Encabezado general
                Paragraph titulo = new Paragraph("REPORTE DE VENTAS", fontTitulo)
                {
                    Alignment = Element.ALIGN_CENTER
                };
                doc.Add(titulo);

                string periodoTexto = _usarFiltroFechas
                    ? $"{_dtpDesde.Value:dd/MM/yyyy} - {_dtpHasta.Value:dd/MM/yyyy}"
                    : "Todos";

                doc.Add(new Paragraph($"Generado el: {DateTime.Now:G}"));
                doc.Add(new Paragraph($"Período: {periodoTexto}\n"));

                // --- Sección Productos Más Vendidos ---
                doc.Add(new Paragraph("\nProductos Más Vendidos\n", fontSubtitulo));

                PdfPTable tablaProductos = new PdfPTable(DGVTopProductos.Columns.Count)
                {
                    WidthPercentage = 100
                };

                // Headers
                foreach (DataGridViewColumn col in DGVTopProductos.Columns)
                {
                    tablaProductos.AddCell(new Phrase(col.HeaderText));
                }

                // Rows
                foreach (DataGridViewRow row in DGVTopProductos.Rows)
                {
                    if (row.IsNewRow) continue;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        tablaProductos.AddCell(cell.Value?.ToString() ?? "");
                    }
                }

                doc.Add(tablaProductos);

                // --- Sección Rendimiento por Vendedor ---
                doc.Add(new Paragraph("\nRendimiento por Vendedor\n", fontSubtitulo));

                PdfPTable tablaVendedores = new PdfPTable(DGVVendedores.Columns.Count)
                {
                    WidthPercentage = 100
                };

                // Headers
                foreach (DataGridViewColumn col in DGVVendedores.Columns)
                {
                    tablaVendedores.AddCell(new Phrase(col.HeaderText));
                }

                // Rows
                foreach (DataGridViewRow row in DGVVendedores.Rows)
                {
                    if (row.IsNewRow) continue;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        tablaVendedores.AddCell(cell.Value?.ToString() ?? "");
                    }
                }

                doc.Add(tablaVendedores);

                // Cerrar PDF
                doc.Close();

                MessageBox.Show(
                    $"PDF generado en:\n{filePath}",
                    "Exportación completada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        // ================== EXPORTAR EXCEL ==================

        private void BExportarExcel_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog()
            {
                Title = "Guardar reporte como Excel",
                Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                FileName = $"Reporte_Ventas_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
            })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;

                string filePath = sfd.FileName;

                // EPPlus 8+ requiere setear la licencia
                ExcelPackage.License.SetNonCommercialPersonal("USO_DEV_LOCAL");

                using (var package = new ExcelPackage())
                {
                    string periodoTexto = _usarFiltroFechas
                        ? $"{_dtpDesde.Value:dd/MM/yyyy} - {_dtpHasta.Value:dd/MM/yyyy}"
                        : "Todos";

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

                    // AutoFit columnas
                    ws1.Cells[ws1.Dimension.Address].AutoFitColumns();
                    ws2.Cells[ws2.Dimension.Address].AutoFitColumns();

                    // Guardar archivo
                    package.SaveAs(new FileInfo(filePath));
                }

                MessageBox.Show(
                    $"Excel generado en:\n{filePath}",
                    "Exportación completada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        // ================== HELPERS ==================

        private (DateTime desde, DateTime hasta) ObtenerRangoFechas()
        {
            DateTime desde = _dtpDesde?.Value.Date ?? DateTime.Today.AddDays(-30);
            DateTime hasta = _dtpHasta?.Value.Date.AddDays(1).AddTicks(-1) ?? DateTime.Today;
            return (desde, hasta);
        }

        private SqlParameter[] ObtenerParametrosRango()
        {
            var (desde, hasta) = ObtenerRangoFechas();
            return new[]
            {
                new SqlParameter("@desde", desde),
                new SqlParameter("@hasta", hasta),
            };
        }

        private string RangoWhere(string clause, bool habilitar)
        {
            return habilitar ? clause : string.Empty;
        }

        private DataTable GetDataTable(string sql, SqlParameter[] ps = null)
        {
            using (var cn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sql, cn))
            using (var da = new SqlDataAdapter(cmd))
            {
                if (ps != null && ps.Length > 0)
                    cmd.Parameters.AddRange(ps);

                var dt = new DataTable();
                cn.Open();
                da.Fill(dt);
                return dt;
            }
        }

        private void FormatearMoneda(DataGridView dgv, string colName)
        {
            if (dgv == null) return;
            if (!dgv.Columns.Contains(colName)) return;

            dgv.Columns[colName].DefaultCellStyle.FormatProvider = _culturaAR;
            dgv.Columns[colName].DefaultCellStyle.Format = "C2";
            dgv.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void TryUncheck(DateTimePicker dtp)
        {
            if (dtp == null) return;
            try { dtp.Checked = false; } catch { /* ignorar */ }
        }

        private T FindControl<T>(string name) where T : class
        {
            var arr = Controls.Find(name, true);
            return arr.Length > 0 ? arr[0] as T : null;
        }

        // ================== STUBS DEL DISEÑADOR ==================
        // (para que el diseñador del form no grite
        // si ya cableaste eventos desde el .Designer)
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
