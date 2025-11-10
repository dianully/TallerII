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

            // Quitar bordes/botones del sistema
            AplicarEstiloSinBordes();

            _connString = connString;
            _desde = desde;
            _hasta = hasta;

            // Asegurar un único Load
            this.Load -= GraficosProductos_Load_1;
            this.Load -= GraficosProductos_Load;
            this.Load += GraficosProductos_Load;

            // Asegurar que el botón cierre
            AsegurarEventoVolver();

            // Permitir cerrar con Esc
            HabilitarCerrarConEsc();
        }

        // ===== CONSTRUCTOR (sin parámetros) — solo para el Designer =====
        public GraficosProductos()
        {
            InitializeComponent();

            // Quitar bordes/botones del sistema
            AplicarEstiloSinBordes();

            this.Load -= GraficosProductos_Load_1;
            this.Load -= GraficosProductos_Load;
            this.Load += GraficosProductos_Load;

            // Asegurar que el botón cierre
            AsegurarEventoVolver();

            // Permitir cerrar con Esc
            HabilitarCerrarConEsc();
        }

        // ======= Estilo sin bordes =======
        private void AplicarEstiloSinBordes()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Text = string.Empty;
            this.Padding = new Padding(0);
            this.Margin = new Padding(0);
            this.DoubleBuffered = true;
            this.AutoScaleMode = AutoScaleMode.None;
        }

        // ======= Esc cierra =======
        private void HabilitarCerrarConEsc()
        {
            this.KeyPreview = true;
            this.KeyDown -= GraficosProductos_KeyDown;
            this.KeyDown += GraficosProductos_KeyDown;
        }

        private void GraficosProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                CerrarSeguro();
            }
        }

        // ======= Wiring botón Volver =======
        private void AsegurarEventoVolver()
        {
            // Si el botón existe en el diseñador, su nombre suele ser BVolverAtras.
            // Si tu nombre es otro, cambialo acá.
            if (this.Controls.ContainsKey("BVolverAtras"))
            {
                var btn = this.Controls["BVolverAtras"] as Button;
                if (btn != null)
                {
                    btn.Click -= BVolverAtras_Click;
                    btn.Click += BVolverAtras_Click;
                }
            }
            // Si el botón está dentro de un contenedor (por ejemplo TableLayoutPanel/Panel),
            // buscamos recursivamente:
            else
            {
                Button btn = BuscarControlRecursivo<Button>(this, "BVolverAtras");
                if (btn != null)
                {
                    btn.Click -= BVolverAtras_Click;
                    btn.Click += BVolverAtras_Click;
                }
            }
        }

        private T BuscarControlRecursivo<T>(Control root, string name) where T : Control
        {
            foreach (Control c in root.Controls)
            {
                if (c.Name == name && c is T) return (T)c;
                var encontrado = BuscarControlRecursivo<T>(c, name);
                if (encontrado != null) return encontrado;
            }
            return null;
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
    SUM(fd.cantidad) AS CantidadVentas
FROM dbo.factura_detalle fd
JOIN dbo.factura  f  ON fd.id_factura_cabecera = f.id_factura
JOIN dbo.producto p  ON fd.id_producto = p.id_producto
JOIN dbo.producto_categoria pc ON pc.id_producto = p.id_producto
JOIN dbo.categoria c ON c.id_categoria = pc.id_categoria
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
            CerrarSeguro();
        }

        /// <summary>
        /// Cierra el form si es TopLevel. Si está embebido en un Panel u otro contenedor,
        /// lo quita del contenedor y lo dispone para liberar recursos.
        /// </summary>
        private void CerrarSeguro()
        {
            try
            {
                if (this.TopLevel)
                {
                    this.Close();
                }
                else
                {
                    var contenedor = this.Parent;
                    if (contenedor != null)
                    {
                        contenedor.Controls.Remove(this);
                    }
                    this.Dispose();
                }
            }
            catch
            {
                // Como fallback, intenta cerrar normal.
                try { this.Close(); } catch { /* ignore */ }
            }
        }

        // ==== stubs del diseñador ====
        private void PGraficos_Paint_1(object sender, PaintEventArgs e) { }
    }
}
