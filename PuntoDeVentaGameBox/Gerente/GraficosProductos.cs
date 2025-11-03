using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PuntoDeVentaGameBox.Gerente
{
    public partial class GraficosProductos : Form
    {
        public GraficosProductos()
        {
            InitializeComponent();
        }

        private void CargarChartTopProductos()
        {
            string connectionString = "Server=localhost;Database=game_box;Trusted_Connection=True;";
            string query = @"
        SELECT TOP 5 
            p.nombre AS Producto, 
            SUM(fd.cantidad) AS CantidadVendida
        FROM factura_detalle fd
        JOIN producto p ON fd.id_producto = p.id_producto
        JOIN factura f ON fd.id_factura_cabecera = f.id_factura
        WHERE f.activo = 1
        GROUP BY p.nombre
        ORDER BY CantidadVendida DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                chartTopProductos.Series.Clear();
                Series serie = new Series("Top Productos");
                serie.ChartType = SeriesChartType.Column;
                serie.IsValueShownAsLabel = true;

                while (reader.Read())
                {
                    string producto = reader["Producto"].ToString();
                    int cantidad = Convert.ToInt32(reader["CantidadVendida"]);
                    serie.Points.AddXY(producto, cantidad);
                }

                chartTopProductos.Series.Add(serie);

                chartTopProductos.Legends.Clear();
                var area = chartTopProductos.ChartAreas[0];
                area.AxisX.Title = "";
                area.AxisY.Title = "";
                area.AxisX.LabelStyle.Angle = 0; // Horizontal
                area.AxisX.MajorGrid.Enabled = false;
                area.AxisY.MajorGrid.Enabled = false;
            }
        }

        private void CargarChartEvolucionVentas()
        {
            string connectionString = "Server=localhost;Database=game_box;Trusted_Connection=True;";
            string query = @"
        SELECT 
            CAST(f.fecha_compra AS DATE) AS Fecha,
            COUNT(*) AS VentasDelDia
        FROM factura f
        WHERE f.activo = 1
          AND f.fecha_compra >= DATEADD(MONTH, -1, CAST(GETDATE() AS DATE))
        GROUP BY CAST(f.fecha_compra AS DATE)
        ORDER BY Fecha";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                chartEvolucionVentas.Series.Clear();
                Series serie = new Series();
                serie.ChartType = SeriesChartType.Line;
                serie.IsValueShownAsLabel = true;

                int acumulado = 0;
                while (reader.Read())
                {
                    DateTime fecha = Convert.ToDateTime(reader["Fecha"]);
                    int ventasDelDia = Convert.ToInt32(reader["VentasDelDia"]);
                    acumulado += ventasDelDia;
                    serie.Points.AddXY(fecha.ToString("dd/MM"), acumulado);
                }

                chartEvolucionVentas.Series.Add(serie);

                // Configuración visual igual que el gráfico anterior
                chartEvolucionVentas.Legends.Clear();
                var area = chartEvolucionVentas.ChartAreas[0];
                area.AxisX.Title = "";
                area.AxisY.Title = "";
                area.AxisX.LabelStyle.Angle = 0; // Horizontal
                area.AxisX.MajorGrid.Enabled = false;
                area.AxisY.MajorGrid.Enabled = false;
            }
        }

        private void CargarChartDistribucionGenero()
        {
            string connectionString = "Server=localhost;Database=game_box;Trusted_Connection=True;";
            string query = @"
        SELECT TOP 5 
            c.nombre AS Categoria,
            COUNT(*) AS CantidadVentas
        FROM factura_detalle fd
        JOIN producto p ON fd.id_producto = p.id_producto
        JOIN categoria c ON p.id_categoria = c.id_categoria
        JOIN factura f ON fd.id_factura_cabecera = f.id_factura
        WHERE f.activo = 1
        GROUP BY c.nombre
        ORDER BY CantidadVentas DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                chartDistribucionGenero.Series.Clear();
                Series serie = new Series();
                serie.ChartType = SeriesChartType.Pie;
                serie.IsValueShownAsLabel = true;

                while (reader.Read())
                {
                    string categoria = reader["Categoria"].ToString();
                    int cantidad = Convert.ToInt32(reader["CantidadVentas"]);
                    serie.Points.AddXY(categoria, cantidad);
                }

                chartDistribucionGenero.Series.Add(serie);

                // Configuración visual
                var area = chartDistribucionGenero.ChartAreas[0];
                area.AxisX.Title = "";
                area.AxisY.Title = "";
                area.AxisX.MajorGrid.Enabled = false;
                area.AxisY.MajorGrid.Enabled = false;

                // Posición de la leyenda a la izquierda
                chartDistribucionGenero.Legends.Clear();
                Legend leyenda = new Legend();
                leyenda.Docking = Docking.Left;
                leyenda.Alignment = StringAlignment.Center;
                leyenda.Font = new Font("Segoe UI", 9);
                chartDistribucionGenero.Legends.Add(leyenda);
                serie.Legend = leyenda.Name;
            }
        }


        // ======== Carga de datos ========


        // ======== Utilitarios ========





        // ==== stubs opcionales del diseñador ====

        private void PGraficos_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void GraficosProductos_Load_1(object sender, EventArgs e)
        {
            CargarChartTopProductos();
            CargarChartEvolucionVentas();
            CargarChartDistribucionGenero();

        }
    }
}
