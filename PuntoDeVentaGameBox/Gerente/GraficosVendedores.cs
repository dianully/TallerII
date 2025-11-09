using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PuntoDeVentaGameBox.Gerente
{
    public partial class GraficosVendedores : Form
    {
        private readonly string _connString;
        private readonly DateTime? _desde;
        private readonly DateTime? _hasta;
        private readonly CultureInfo _ars = new CultureInfo("es-AR");

        public GraficosVendedores(string connString, DateTime? desde, DateTime? hasta)
        {
            InitializeComponent();
            _connString = connString;
            _desde = desde;
            _hasta = hasta;

            this.Load -= GraficosVendedores_Load;
            this.Load += GraficosVendedores_Load;
        }

        private void GraficosVendedores_Load(object sender, EventArgs e)
        {
            CargarChartRendimiento();
            CargarChartTransacciones();
            CargarChartTicketPromedio();

            // Diseño común
            chartRendimientoVendedor.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartTransaccionesVendedor.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartTicketPromedio.ChartAreas[0].AxisX.MajorGrid.Enabled = false;

            chartRendimientoVendedor.Legends.Clear();
            chartTransaccionesVendedor.Legends.Clear();
            chartTicketPromedio.Legends.Clear();
        }

        private string RangoWhere(string campoFecha)
            => (_desde.HasValue && _hasta.HasValue) ? $" AND {campoFecha} BETWEEN @desde AND @hasta" : string.Empty;

        private void AgregarParametrosRango(SqlCommand cmd)
        {
            if (_desde.HasValue && _hasta.HasValue)
            {
                cmd.Parameters.AddWithValue("@desde", _desde.Value);
                cmd.Parameters.AddWithValue("@hasta", _hasta.Value);
            }
        }

        private void CargarChartRendimiento()
        {
            string sql = $@"
SELECT TOP 5 
    u.nombre + ' ' + u.apellido AS vendedor,
    SUM(f.total) AS total_ganado
FROM dbo.factura f
JOIN dbo.usuario u ON u.id_usuario = f.id_usuario
WHERE (f.activo = 1 OR f.activo IS NULL)
{RangoWhere("f.fecha_compra")}
GROUP BY u.nombre, u.apellido
ORDER BY total_ganado DESC;";

            chartRendimientoVendedor.Series.Clear();
            var serie = new Series("Rendimiento")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                LabelFormat = "C2"
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
                        string nombre = rd.GetString(0);
                        decimal total = rd.IsDBNull(1) ? 0m : rd.GetDecimal(1);
                        int idx = serie.Points.AddXY(nombre, total);
                        serie.Points[idx].Label = total.ToString("C2", _ars);
                    }
                }
            }

            chartRendimientoVendedor.Series.Add(serie);
        }

        private void CargarChartTransacciones()
        {
            string sql = $@"
SELECT TOP 5 
    u.nombre + ' ' + u.apellido AS vendedor,
    COUNT(f.id_factura) AS cantidad_transacciones
FROM dbo.factura f
JOIN dbo.usuario u ON u.id_usuario = f.id_usuario
WHERE (f.activo = 1 OR f.activo IS NULL)
{RangoWhere("f.fecha_compra")}
GROUP BY u.nombre, u.apellido
ORDER BY cantidad_transacciones DESC;";

            chartTransaccionesVendedor.Series.Clear();
            var serie = new Series("Transacciones")
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
                        string nombre = rd.GetString(0);
                        int cant = rd.IsDBNull(1) ? 0 : rd.GetInt32(1);
                        int idx = serie.Points.AddXY(nombre, cant);
                        serie.Points[idx].Label = cant.ToString("N0");
                    }
                }
            }

            chartTransaccionesVendedor.Series.Add(serie);
        }

        private void CargarChartTicketPromedio()
        {
            string sql = $@"
SELECT TOP 5 
    u.nombre + ' ' + u.apellido AS vendedor,
    AVG(CAST(f.total AS decimal(18,2))) AS ticket_promedio
FROM dbo.factura f
JOIN dbo.usuario u ON u.id_usuario = f.id_usuario
WHERE (f.activo = 1 OR f.activo IS NULL)
{RangoWhere("f.fecha_compra")}
GROUP BY u.nombre, u.apellido
ORDER BY ticket_promedio DESC;";

            chartTicketPromedio.Series.Clear();
            var serie = new Series("Ticket Promedio")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                LabelFormat = "C2"
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
                        string nombre = rd.GetString(0);
                        decimal prom = rd.IsDBNull(1) ? 0m : rd.GetDecimal(1);
                        int idx = serie.Points.AddXY(nombre, prom);
                        serie.Points[idx].Label = prom.ToString("C2", _ars);
                    }
                }
            }

            chartTicketPromedio.Series.Add(serie);
        }

        private void BVolverAtras_Click(object sender, EventArgs e) => this.Close();
        private void PGraficos_Paint(object sender, PaintEventArgs e) { }
    }
}
