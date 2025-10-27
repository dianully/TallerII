using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using PuntoDeVentaGameBox.Gerente;

namespace PuntoDeVentaGameBox.Gerente
{
    public partial class Reportes : Form
    {
        // ⚙️ Ajusta si luego lo pasás a App.config
        private readonly string _connString =
            "Server=localhost;Database=game_box;Trusted_Connection=True;TrustServerCertificate=True";

        // Cultura fija para mostrar $ (pesos argentinos)
        private readonly CultureInfo _culturaAR = new CultureInfo("es-AR");

        // Manejo de filtro
        private bool _usarFiltroFechas = false;
        private DateTimePicker _dtpDesde;
        private DateTimePicker _dtpHasta;

        public Reportes()
        {
            InitializeComponent();

            // ---- Wire seguro de los botones de gráficos ----
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

            // ---- Detectar DateTimePickers por nombre ----
            _dtpDesde = FindControl<DateTimePicker>("DTPDesde");
            _dtpHasta = FindControl<DateTimePicker>("DTPHasta") ?? FindControl<DateTimePicker>("DTMPHasta");

            // Wire de filtros
            if (_dtpDesde != null) _dtpDesde.ValueChanged += FiltroFechas_ValueChanged;
            if (_dtpHasta != null) _dtpHasta.ValueChanged += FiltroFechas_ValueChanged;

            // Botón Limpiar
            if (BLimpiar != null)
            {
                BLimpiar.Click -= BLimpiar_Click;
                BLimpiar.Click += BLimpiar_Click;
            }

            // Load
            this.Load -= Reportes_Load;
            this.Load += Reportes_Load;
        }

        // ================== EVENTOS ==================

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
            if (_dtpDesde != null && _dtpHasta != null && _dtpDesde.Value.Date > _dtpHasta.Value.Date)
            {
                _dtpHasta.Value = _dtpDesde.Value;
            }
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

        // ================== REFRESCO GENERAL ==================

        private void RefrescarTodo()
        {
            CargarKPIs();
            CargarTopProductos();
            CargarVendedores();
        }

        // ================== KPIs ==================

        private void CargarKPIs()
        {
            string sqlBase = @"
SELECT 
    SUM(CASE WHEN f.activo = 1 OR f.activo IS NULL THEN f.total END)       AS TotalVentas,
    COUNT(CASE WHEN f.activo = 1 OR f.activo IS NULL THEN 1 END)           AS CantVentas,
    AVG(CASE WHEN f.activo = 1 OR f.activo IS NULL THEN f.total END)       AS TicketPromedio
FROM dbo.factura f
WHERE 1=1";

            string sqlProductos = @"SELECT COUNT(*) AS CantProductos FROM dbo.producto WHERE activo = 1;";

            using (var cn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sqlBase + RangoWhere(" AND f.fecha_compra BETWEEN @desde AND @hasta", _usarFiltroFechas), cn))
            {
                if (_usarFiltroFechas)
                {
                    var (desde, hasta) = ObtenerRangoFechas();
                    cmd.Parameters.Add(new SqlParameter("@desde", SqlDbType.DateTime) { Value = desde });
                    cmd.Parameters.Add(new SqlParameter("@hasta", SqlDbType.DateTime) { Value = hasta });
                }

                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        decimal totalVentas = rd.IsDBNull(0) ? 0m : rd.GetDecimal(0);
                        int cantVentas = rd.IsDBNull(1) ? 0 : rd.GetInt32(1);
                        decimal ticket = rd.IsDBNull(2) ? 0m : rd.GetDecimal(2);

                        if (LPesosTotalDinero != null) LPesosTotalDinero.Text = totalVentas.ToString("C2", _culturaAR);
                        if (LNroVentas != null) LNroVentas.Text = cantVentas.ToString("N0");
                        if (LTicketPromedio != null) LTicketPromedio.Text = ticket.ToString("C2", _culturaAR);
                    }
                }

                using (var cmdProd = new SqlCommand(sqlProductos, cn))
                {
                    int cantProductos = Convert.ToInt32(cmdProd.ExecuteScalar() ?? 0);
                    if (LCantProductos != null) LCantProductos.Text = cantProductos.ToString("N0");
                }
            }
        }

        // ================== TOP PRODUCTOS ==================

        private void CargarTopProductos()
        {
            string sql = @"
SELECT TOP (20)
    p.nombre                         AS [Videojuego],
    SUM(fd.cantidad)                 AS [Unidades Vendidas],
    SUM(fd.cantidad * fd.precio)     AS [Ingresos]
FROM dbo.factura f
JOIN dbo.factura_detalle fd ON fd.id_factura_cabecera = f.id_factura
JOIN dbo.producto p        ON p.id_producto = fd.id_producto
WHERE (f.activo = 1 OR f.activo IS NULL)
  {__RANGO__}
GROUP BY p.nombre
ORDER BY [Unidades Vendidas] DESC, [Ingresos] DESC;";

            string rango = _usarFiltroFechas ? "AND f.fecha_compra BETWEEN @desde AND @hasta" : "";
            sql = sql.Replace("{__RANGO__}", rango);

            var dt = GetDataTable(sql, _usarFiltroFechas ? ObtenerParametrosRango() : null);

            if (DGVTopProductos != null)
            {
                DGVTopProductos.AutoGenerateColumns = true;
                DGVTopProductos.DataSource = dt;
                FormatearMoneda(DGVTopProductos, "Ingresos");
                AjustarAnchos(DGVTopProductos);
            }
        }

        // ================== VENDEDORES ==================

        private void CargarVendedores()
        {
            string vendedorTable = DetectarTablaVendedor();

            string sql = $@"
SELECT
    v.nombre                                AS [Vendedor],
    SUM(f.total)                            AS [Total Dinero en Ventas],
    COUNT(*)                                AS [Ventas],
    AVG(f.total)                            AS [Ticket Promedio]
FROM dbo.factura f
JOIN dbo.{vendedorTable} v ON v.id_usuario = f.id_usuario
WHERE (f.activo = 1 OR f.activo IS NULL)
  {{__RANGO__}}
GROUP BY v.nombre
ORDER BY [Total Dinero en Ventas] DESC;";

            string rango = _usarFiltroFechas ? "AND f.fecha_compra BETWEEN @desde AND @hasta" : "";
            sql = sql.Replace("{__RANGO__}", rango);

            var dt = GetDataTable(sql, _usarFiltroFechas ? ObtenerParametrosRango() : null);

            if (DGVVendedores != null)
            {
                DGVVendedores.AutoGenerateColumns = true;
                DGVVendedores.DataSource = dt;
                FormatearMoneda(DGVVendedores, "Total Dinero en Ventas");
                FormatearMoneda(DGVVendedores, "Ticket Promedio");
                AjustarAnchos(DGVVendedores);
            }
        }

        private string DetectarTablaVendedor()
        {
            try
            {
                var dt = GetDataTable("SELECT TOP 1 id_usuario, nombre FROM dbo.usuario;");
                if (dt.Columns.Contains("id_usuario")) return "usuario";
            }
            catch { }
            return "vendedor";
        }

        // ================== HELPERS ==================

        private (DateTime desde, DateTime hasta) ObtenerRangoFechas()
        {
            DateTime desde = DateTime.Today.AddDays(-30);
            DateTime hasta = DateTime.Today.AddDays(1).AddTicks(-1);

            if (_dtpDesde != null) desde = _dtpDesde.Value.Date;
            if (_dtpHasta != null) hasta = _dtpHasta.Value.Date.AddDays(1).AddTicks(-1);

            if (desde > hasta) hasta = desde.AddDays(1).AddTicks(-1);
            return (desde, hasta);
        }

        private SqlParameter[] ObtenerParametrosRango()
        {
            var (desde, hasta) = ObtenerRangoFechas();
            return new[]
            {
                new SqlParameter("@desde", SqlDbType.DateTime){ Value = desde },
                new SqlParameter("@hasta", SqlDbType.DateTime){ Value = hasta },
            };
        }

        private string RangoWhere(string clause, bool habilitar)
            => habilitar ? clause : string.Empty;

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
            if (dgv?.Columns.Contains(colName) == true)
            {
                dgv.Columns[colName].DefaultCellStyle.FormatProvider = _culturaAR;
                dgv.Columns[colName].DefaultCellStyle.Format = "C2";
                dgv.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void AjustarAnchos(DataGridView dgv)
        {
            if (dgv == null) return;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns.Cast<DataGridViewColumn>()
               .ToList().ForEach(c => c.MinimumWidth = 80);
        }

        private void TryUncheck(DateTimePicker dtp)
        {
            if (dtp == null) return;
            try { dtp.Checked = false; } catch { }
        }

        private T FindControl<T>(string name) where T : class
        {
            var arr = this.Controls.Find(name, true);
            return arr.Length > 0 ? arr[0] as T : null;
        }

        // ==== Stubs del diseñador (no tocar) ====
        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e) { }
        private void LResumenTitulo_Click(object sender, EventArgs e) { }
        private void PHeader_Paint(object sender, PaintEventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) { }
        private void TPLRoot_Paint(object sender, PaintEventArgs e) { }
        private void PNLScroll_Paint(object sender, PaintEventArgs e) { }
        private void GVTopProductos_Enter(object sender, EventArgs e) { }
    }
}
