using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PuntoDeVentaGameBox.Gerente
{
    public partial class GraficosVendedores : Form
    {
        private readonly string _connString =
            "Server=localhost;Database=game_box;Trusted_Connection=True;TrustServerCertificate=True";

        private DateTime _desde;
        private DateTime _hasta;

        public GraficosVendedores()
        {
            InitializeComponent();
            _desde = DateTime.Today.AddDays(-30);
            _hasta = DateTime.Today.AddDays(1).AddTicks(-1);
            Wire();
        }

        public GraficosVendedores(DateTime desde, DateTime hasta)
        {
            InitializeComponent();
            _desde = desde.Date;
            _hasta = hasta.Date.AddDays(1).AddTicks(-1);
            Wire();
        }

        private void Wire()
        {
            this.Load -= GraficosVendedores_Load;
            this.Load += GraficosVendedores_Load;
            // Dejamos que el diseñador maneje el Click del botón VolverAtras
        }

        private void GraficosVendedores_Load(object sender, EventArgs e)
        {
            SetupChart(chartRendimientoVendedor, SeriesChartType.Column,
                "Rendimiento por Vendedor (Monto)", "Vendedor", "Monto");
            chartRendimientoVendedor.Series[0].LabelFormat = "C0";

            SetupChart(chartTransaccionesVendedor, SeriesChartType.Bar,
                "Transacciones por Vendedor", "Vendedor", "Transacciones");

            SetupChart(chartTicketPromedio, SeriesChartType.Bar,
                "Ticket Promedio por Vendedor", "Vendedor", "Ticket Promedio");
            chartTicketPromedio.Series[0].LabelFormat = "C0";

            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                // 🔁 Intentamos con tabla USUARIO; si no existe, caemos a VENDEDOR
                string vendedorTable = DetectarTablaVendedor();

                // 1) Monto total por vendedor
                var sqlMonto = $@"
SELECT v.nombre AS Vendedor, SUM(f.total) AS Monto
FROM dbo.factura f
JOIN dbo.{vendedorTable} v ON v.id_usuario = f.id_usuario
WHERE (f.activo = 1 OR f.activo IS NULL)
  AND f.fecha_compra BETWEEN @desde AND @hasta
GROUP BY v.nombre
ORDER BY Monto DESC;";

                var dtMonto = GetDataTable(sqlMonto,
                    new SqlParameter("@desde", SqlDbType.DateTime) { Value = _desde },
                    new SqlParameter("@hasta", SqlDbType.DateTime) { Value = _hasta });
                BindChart(chartRendimientoVendedor, dtMonto, "Vendedor", "Monto");

                // 2) Transacciones por vendedor
                var sqlTrans = $@"
SELECT v.nombre AS Vendedor, COUNT(*) AS Transacciones
FROM dbo.factura f
JOIN dbo.{vendedorTable} v ON v.id_usuario = f.id_usuario
WHERE (f.activo = 1 OR f.activo IS NULL)
  AND f.fecha_compra BETWEEN @desde AND @hasta
GROUP BY v.nombre
ORDER BY Transacciones DESC;";
                var dtTrans = GetDataTable(sqlTrans,
                    new SqlParameter("@desde", SqlDbType.DateTime) { Value = _desde },
                    new SqlParameter("@hasta", SqlDbType.DateTime) { Value = _hasta });
                BindChart(chartTransaccionesVendedor, dtTrans, "Vendedor", "Transacciones");

                // 3) Ticket promedio por vendedor
                var sqlTicket = $@"
SELECT v.nombre AS Vendedor, AVG(f.total) AS TicketPromedio
FROM dbo.factura f
JOIN dbo.{vendedorTable} v ON v.id_usuario = f.id_usuario
WHERE (f.activo = 1 OR f.activo IS NULL)
  AND f.fecha_compra BETWEEN @desde AND @hasta
GROUP BY v.nombre
ORDER BY TicketPromedio DESC;";
                var dtTicket = GetDataTable(sqlTicket,
                    new SqlParameter("@desde", SqlDbType.DateTime) { Value = _desde },
                    new SqlParameter("@hasta", SqlDbType.DateTime) { Value = _hasta });
                BindChart(chartTicketPromedio, dtTicket, "Vendedor", "TicketPromedio");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar gráficos de vendedores:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Detecta si existe dbo.usuario; si no, intenta dbo.vendedor
        private string DetectarTablaVendedor()
        {
            try
            {
                var dt = GetDataTable("SELECT TOP 1 id_usuario, nombre FROM dbo.usuario;");
                if (dt.Columns.Contains("id_usuario")) return "usuario";
            }
            catch { /* ignorar */ }

            return "vendedor"; // fallback
        }

        // ======== Utilitarios ========

        private void SetupChart(Chart ch, SeriesChartType type, string title, string xTitle, string yTitle)
        {
            ch.Series.Clear();
            ch.ChartAreas.Clear();
            ch.Titles.Clear();
            ch.Legends.Clear();

            var area = new ChartArea("Area1");
            area.AxisX.Title = xTitle;
            area.AxisY.Title = yTitle;
            area.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            ch.ChartAreas.Add(area);

            var s = new Series("S1")
            {
                ChartType = type,
                IsValueShownAsLabel = true,
                ChartArea = "Area1"
            };
            s.ToolTip = "#VALX: #VALY";
            ch.Series.Add(s);

            ch.Titles.Add(title);
            ch.Legends.Add(new Legend { Docking = Docking.Top, LegendStyle = LegendStyle.Row });
            ch.Palette = ChartColorPalette.BrightPastel;
        }

        private void BindChart(Chart ch, DataTable dt, string x, string y)
        {
            var s = ch.Series[0];
            s.Points.Clear();
            foreach (DataRow r in dt.Rows)
            {
                var xv = Convert.ToString(r[x] ?? "");
                var yv = Convert.ToDouble(r[y] == DBNull.Value ? 0 : r[y]);
                s.Points.AddXY(xv, yv);
            }
        }

        private DataTable GetDataTable(string sql, params SqlParameter[] ps)
        {
            using (var cn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sql, cn))
            using (var da = new SqlDataAdapter(cmd))
            {
                if (ps != null) cmd.Parameters.AddRange(ps);
                var dt = new DataTable();
                cn.Open();
                da.Fill(dt);
                return dt;
            }
        }

        // ==== Handlers y stubs para eventos de diseñador ====
        private void BVolverAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chartRendimientoVendedor_Click(object sender, EventArgs e) { }
        private void chartTransaccionesVendedor_Click(object sender, EventArgs e) { }
        private void chartTicketPromedio_Click(object sender, EventArgs e) { }
        private void PGraficos_Paint(object sender, PaintEventArgs e) { }
    }
}
