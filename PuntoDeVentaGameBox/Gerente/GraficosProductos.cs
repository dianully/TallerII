using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PuntoDeVentaGameBox.Gerente
{
    public partial class GraficosProductos : Form
    {
        private readonly string _connString;
        private readonly DateTime? _desde;
        private readonly DateTime? _hasta;
        private readonly CultureInfo _ars = new CultureInfo("es-AR");

        // ===== CONSTRUCTOR (con parámetros) =====
        public GraficosProductos(string connString, DateTime? desde, DateTime? hasta)
        {
            InitializeComponent();
            _connString = connString;
            _desde = desde;
            _hasta = hasta;

            // Aseguramos un único handler (y compatibilidad con el Designer)
            this.Load -= GraficosProductos_Load_1;
            this.Load -= GraficosProductos_Load;
            this.Load += GraficosProductos_Load;
        }

        // ===== CONSTRUCTOR (sin parámetros) — solo para el Designer =====
        public GraficosProductos()
        {
            InitializeComponent();
            this.Load -= GraficosProductos_Load_1;
            this.Load -= GraficosProductos_Load;
            this.Load += GraficosProductos_Load;
        }

        // ===== HANDLER PRINCIPAL =====
        private void GraficosProductos_Load(object sender, EventArgs e)
        {
            // Evita ejecutar consultas en modo diseñador o sin conexión
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime ||
                string.IsNullOrEmpty(_connString))
            {
                return;
            }

            CargarChartTopProductos();
            CargarChartEvolucionVentas();
            CargarChartDistribucionCategoria();
        }

        // Alias por si el .Designer está cableado al _1
        private void GraficosProductos_Load_1(object sender, EventArgs e)
        {
            GraficosProductos_Load(sender, e);
        }

        // ===== Helpers de rango =====
        private string RangoWhere(string campoFecha)
        {
            return (_desde.HasValue && _hasta.HasValue)
                ? $" AND {campoFecha} BETWEEN @desde AND @hasta"
                : string.Empty;
        }

        private void AgregarParametrosRango(SqlCommand cmd)
        {
            if (_desde.HasValue && _hasta.HasValue)
            {
                cmd.Parameters.AddWithValue("@desde", _desde.Value);
                cmd.Parameters.AddWithValue("@hasta", _hasta.Value);
            }
        }

        // ===== GRÁFICO 1: Top Productos =====
        private void CargarChartTopProductos()
        {
            string sql = $@"
SELECT TOP 5 
    p.nombre AS Producto, 
    SUM(fd.cantidad) AS CantidadVendida
FROM dbo.factura_detalle fd
JOIN dbo.factura f   ON fd.id_factura_cabecera = f.id_factura
JOIN dbo.producto p  ON fd.id_producto = p.id_producto
WHERE (f.activo = 1 OR f.activo IS NULL)
{RangoWhere("f.fecha_compra")}
GROUP BY p.nombre
ORDER BY CantidadVendida DESC;";

            chartTopProductos.Series.Clear();
            var serie = new Series("Top Productos")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                LabelFormat = "N0"
            };

            using (var cn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sql, cn))
            {
                AgregarParametrosRango(cmd);
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        string producto = rd.GetString(0);
                        int cantidad = rd.IsDBNull(1) ? 0 : Convert.ToInt32(rd.GetValue(1));
                        int idx = serie.Points.AddXY(producto, cantidad);
                        serie.Points[idx].Label = cantidad.ToString("N0");
                    }
                }
            }

            chartTopProductos.Series.Add(serie);
            var area = chartTopProductos.ChartAreas[0];
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;
            chartTopProductos.Legends.Clear();
        }

        // ===== GRÁFICO 2: Evolución de Ventas =====
        private void CargarChartEvolucionVentas()
        {
            string sql;
            bool usarParametros = false;

            if (_desde.HasValue && _hasta.HasValue)
            {
                sql = @"
SELECT 
    CAST(f.fecha_compra AS DATE) AS Fecha,
    COUNT(*) AS VentasDelDia
FROM dbo.factura f
WHERE (f.activo = 1 OR f.activo IS NULL)
  AND f.fecha_compra BETWEEN @desde AND @hasta
GROUP BY CAST(f.fecha_compra AS DATE)
ORDER BY Fecha;";
                usarParametros = true;
            }
            else
            {
                // Default: último mes
                sql = @"
SELECT 
    CAST(f.fecha_compra AS DATE) AS Fecha,
    COUNT(*) AS VentasDelDia
FROM dbo.factura f
WHERE (f.activo = 1 OR f.activo IS NULL)
  AND f.fecha_compra >= DATEADD(MONTH, -1, CAST(GETDATE() AS DATE))
GROUP BY CAST(f.fecha_compra AS DATE)
ORDER BY Fecha;";
            }

            chartEvolucionVentas.Series.Clear();
            var serie = new Series("Evolución")
            {
                ChartType = SeriesChartType.Line,
                IsValueShownAsLabel = true,
                LabelFormat = "N0"
            };

            using (var cn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sql, cn))
            {
                if (usarParametros) AgregarParametrosRango(cmd);
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    int acumulado = 0;
                    while (rd.Read())
                    {
                        DateTime fecha = rd.GetDateTime(0);
                        int ventasDia = rd.IsDBNull(1) ? 0 : rd.GetInt32(1);
                        acumulado += ventasDia;
                        int idx = serie.Points.AddXY(fecha.ToString("dd/MM"), acumulado);
                        serie.Points[idx].Label = acumulado.ToString("N0");
                    }
                }
            }

            chartEvolucionVentas.Series.Add(serie);
            var area = chartEvolucionVentas.ChartAreas[0];
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;
            chartEvolucionVentas.Legends.Clear();
        }

        // ===== GRÁFICO 3: Distribución por Categoría =====
        private void CargarChartDistribucionCategoria()
        {
            string sql = $@"
SELECT 
    c.nombre AS Categoria,
    COUNT(*) AS CantidadVentas
FROM dbo.factura_detalle fd
JOIN dbo.factura  f ON fd.id_factura_cabecera = f.id_factura
JOIN dbo.producto p ON fd.id_producto = p.id_producto
JOIN dbo.categoria c ON p.id_categoria = c.id_categoria
WHERE (f.activo = 1 OR f.activo IS NULL)
{RangoWhere("f.fecha_compra")}
GROUP BY c.nombre
ORDER BY CantidadVentas DESC;";

            chartDistribucionGenero.Series.Clear();
            var serie = new Series("Distribución")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
            };

            using (var cn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sql, cn))
            {
                AgregarParametrosRango(cmd);
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        string categoria = rd.GetString(0);
                        int cantidad = rd.IsDBNull(1) ? 0 : Convert.ToInt32(rd.GetValue(1));
                        serie.Points.AddXY(categoria, cantidad);
                    }
                }
            }

            chartDistribucionGenero.Series.Add(serie);

            var area = chartDistribucionGenero.ChartAreas[0];
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;

            chartDistribucionGenero.Legends.Clear();
            var leyenda = new Legend { Docking = Docking.Left };
            chartDistribucionGenero.Legends.Add(leyenda);
            serie.Legend = leyenda.Name;
        }

        // ===== BOTÓN VOLVER ATRÁS =====
        private void BVolverAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ==== stubs del diseñador ====
        private void PGraficos_Paint_1(object sender, PaintEventArgs e) { }
    }
}
