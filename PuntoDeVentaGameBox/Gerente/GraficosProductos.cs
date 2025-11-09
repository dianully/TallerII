using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PuntoDeVentaGameBox.Gerente
{
    public partial class GraficosProductos : Form
    {
        // ⚙️ Ajusta tu connection string aquí o léela de App.config
        private readonly string _connString =
            "Server=localhost;Database=game_box;Trusted_Connection=True;TrustServerCertificate=True";

        private DateTime _desde;
        private DateTime _hasta;

        public GraficosProductos()
        {
            InitializeComponent();
            _desde = DateTime.Today.AddDays(-30);
            _hasta = DateTime.Today.AddDays(1).AddTicks(-1);

            Wire();
        }

        public GraficosProductos(DateTime desde, DateTime hasta)
        {
            InitializeComponent();
            _desde = desde.Date;
            _hasta = hasta.Date.AddDays(1).AddTicks(-1);

            Wire();
        }

        private void Wire()
        {
            this.Load -= GraficosProductos_Load;
            this.Load += GraficosProductos_Load;

            if (BVolverAtras != null)
            {
                BVolverAtras.Click -= (_, __) => { };
                BVolverAtras.Click += (s, e) => this.Close();
            }
        }

        private void GraficosProductos_Load(object sender, EventArgs e)
        {
            // Configuración base de charts
            SetupChart(chartTopProductos, SeriesChartType.Bar,
                "Productos más vendidos (Unidades)", "Producto", "Unidades");
            SetupChart(chartEvolucionVentas, SeriesChartType.Area,
                "Evolución de ventas (Unidades)", "Fecha/Período", "Unidades");
            SetupChart(chartDistribucionGenero, SeriesChartType.Doughnut,
                "Distribución de Ventas por Género", "", "Unidades");

            CargarDatos();
        }

        // ======== Carga de datos ========

        private void CargarDatos()
        {
            try
            {
                // 1) Top N productos (unidades)
                var sqlTop = @"
SELECT TOP (@TopN) p.nombre AS Producto, SUM(fd.cantidad) AS Unidades
FROM dbo.factura f
JOIN dbo.factura_detalle fd ON fd.id_factura_cabecera = f.id_factura
JOIN dbo.producto p ON p.id_producto = fd.id_producto
WHERE (f.activo = 1 OR f.activo IS NULL)
  AND f.fecha_compra BETWEEN @desde AND @hasta
GROUP BY p.nombre
ORDER BY Unidades DESC;";

                var dtTop = GetDataTable(sqlTop,
                    new SqlParameter("@TopN", SqlDbType.Int) { Value = 10 },
                    new SqlParameter("@desde", SqlDbType.DateTime) { Value = _desde },
                    new SqlParameter("@hasta", SqlDbType.DateTime) { Value = _hasta });

                BindChart(chartTopProductos, dtTop, "Producto", "Unidades");

                // 2) Evolución de ventas por día (unidades)
                var sqlEvo = @"
SELECT CONVERT(date, f.fecha_compra) AS Dia, SUM(fd.cantidad) AS Unidades
FROM dbo.factura f
JOIN dbo.factura_detalle fd ON fd.id_factura_cabecera = f.id_factura
WHERE (f.activo = 1 OR f.activo IS NULL)
  AND f.fecha_compra BETWEEN @desde AND @hasta
GROUP BY CONVERT(date, f.fecha_compra)
ORDER BY Dia;";

                var dtEvo = GetDataTable(sqlEvo,
                    new SqlParameter("@desde", SqlDbType.DateTime) { Value = _desde },
                    new SqlParameter("@hasta", SqlDbType.DateTime) { Value = _hasta });

                // Para series de tiempo
                var sEvo = chartEvolucionVentas.Series[0];
                sEvo.Points.Clear();
                sEvo.XValueType = ChartValueType.Date;
                foreach (DataRow r in dtEvo.Rows)
                {
                    DateTime x = Convert.ToDateTime(r["Dia"]);
                    double y = Convert.ToDouble(r["Unidades"]);
                    sEvo.Points.AddXY(x, y);
                }
                chartEvolucionVentas.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM";

                // 3) Distribución por género (doughnut)
                var sqlGen = @"
SELECT c.nombre AS Genero, SUM(fd.cantidad) AS Unidades
FROM dbo.factura f
JOIN dbo.factura_detalle fd ON fd.id_factura_cabecera = f.id_factura
JOIN dbo.producto p ON p.id_producto = fd.id_producto
LEFT JOIN dbo.categoria c ON c.id_categoria = p.id_categoria
WHERE (f.activo = 1 OR f.activo IS NULL)
  AND f.fecha_compra BETWEEN @desde AND @hasta
GROUP BY c.nombre
ORDER BY Unidades DESC;";

                var dtGen = GetDataTable(sqlGen,
                    new SqlParameter("@desde", SqlDbType.DateTime) { Value = _desde },
                    new SqlParameter("@hasta", SqlDbType.DateTime) { Value = _hasta });

                var sGen = chartDistribucionGenero.Series[0];
                sGen.Points.Clear();
                sGen.IsValueShownAsLabel = true;
                sGen.LegendText = "#VALX (#PERCENT)";
                sGen.Label = "#PERCENT";
                foreach (DataRow r in dtGen.Rows)
                {
                    string x = Convert.ToString(r["Genero"] ?? "Sin género");
                    double y = Convert.ToDouble(r["Unidades"] == DBNull.Value ? 0 : r["Unidades"]);
                    sGen.Points.AddXY(x, y);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar gráficos de productos:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======== Utilitarios ========

        private void SetupChart(Chart ch, SeriesChartType type, string title, string xTitle, string yTitle)
        {
            ch.Series.Clear(); ch.ChartAreas.Clear(); ch.Titles.Clear(); ch.Legends.Clear();

            var area = new ChartArea("Area1");
            area.AxisX.Title = xTitle;
            area.AxisY.Title = yTitle;
            area.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            ch.ChartAreas.Add(area);

            var s = new Series("S1") { ChartType = type, IsValueShownAsLabel = true, ChartArea = "Area1" };
            s.ToolTip = "#VALX: #VALY";
            ch.Series.Add(s);

            ch.Titles.Add(title);
            ch.Legends.Add(new Legend { Docking = Docking.Top, LegendStyle = LegendStyle.Row });
            ch.Palette = ChartColorPalette.SeaGreen; // tonos agradables sobre fondo oscuro
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

        // ==== stubs opcionales del diseñador ====
        private void chartTopProductos_Click(object sender, EventArgs e) { }
        private void chartEvolucionVentas_Click(object sender, EventArgs e) { }
        private void chartDistribucionGenero_Click(object sender, EventArgs e) { }
        private void PGraficos_Paint(object sender, PaintEventArgs e) { }

        private void PGraficos_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
