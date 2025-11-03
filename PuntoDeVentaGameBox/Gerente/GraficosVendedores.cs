using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PuntoDeVentaGameBox.Gerente
{
    public partial class GraficosVendedores : Form
    {
  

        public GraficosVendedores()
        {
            InitializeComponent();
        }

        private void GraficosVendedores_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=game_box;Trusted_Connection=True;";
            string query = @"
        SELECT TOP 5 
            u.nombre + ' ' + u.apellido AS vendedor,
            SUM(f.monto_pagado) AS total_ganado
        FROM factura f
        JOIN usuario u ON f.id_usuario = u.id_usuario
        WHERE u.id_rol = 3 AND f.activo = 1
        GROUP BY u.nombre, u.apellido
        ORDER BY total_ganado DESC;
    ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                chartRendimientoVendedor.Series.Clear();
                Series serie = new Series("Rendimiento");
                serie.ChartType = SeriesChartType.Column;
                serie.IsValueShownAsLabel = true;

                while (reader.Read())
                {
                    string nombre = reader.GetString(0);
                    decimal total = reader.GetDecimal(1);
                    serie.Points.AddXY(nombre, total);
                }

                chartRendimientoVendedor.Series.Add(serie);
            }

            //2 Grafico
            string queryTransacciones = @"
    SELECT TOP 5 
        u.nombre + ' ' + u.apellido AS vendedor,
        COUNT(f.id_factura) AS cantidad_transacciones
    FROM factura f
    JOIN usuario u ON f.id_usuario = u.id_usuario
    WHERE u.id_rol = 3 AND f.activo = 1
    GROUP BY u.nombre, u.apellido
    ORDER BY cantidad_transacciones DESC;
";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryTransacciones, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                chartTransaccionesVendedor.Series.Clear();
                Series serie = new Series("Transacciones");
                serie.ChartType = SeriesChartType.Column;
                serie.IsValueShownAsLabel = true;

                while (reader.Read())
                {
                    string nombre = reader.GetString(0);
                    int cantidad = reader.GetInt32(1);
                    serie.Points.AddXY(nombre, cantidad);
                }

                chartTransaccionesVendedor.Series.Add(serie);
            }

            //3 Grafico
            string queryTicketPromedio = @"
    SELECT TOP 5 
        u.nombre + ' ' + u.apellido AS vendedor,
        AVG(f.monto_pagado) AS ticket_promedio
    FROM factura f
    JOIN usuario u ON f.id_usuario = u.id_usuario
    WHERE u.id_rol = 3 AND f.activo = 1
    GROUP BY u.nombre, u.apellido
    ORDER BY ticket_promedio DESC;
";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryTicketPromedio, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                chartTicketPromedio.Series.Clear();
                Series serie = new Series("Ticket Promedio");
                serie.ChartType = SeriesChartType.Column;
                serie.IsValueShownAsLabel = true;

                while (reader.Read())
                {
                    string nombre = reader.GetString(0);
                    decimal promedio = reader.GetDecimal(1);
                    serie.Points.AddXY(nombre, promedio);
                }

                chartTicketPromedio.Series.Add(serie);
            }

            //Diseño de los gráficos
            chartRendimientoVendedor.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartTransaccionesVendedor.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartTicketPromedio.ChartAreas[0].AxisX.MajorGrid.Enabled = false;

            chartTicketPromedio.Series[0].Label = "#VALY{N2}";

            chartRendimientoVendedor.Legends.Clear();
            chartTransaccionesVendedor.Legends.Clear();
            chartTicketPromedio.Legends.Clear();
        }


        // Detecta si existe dbo.usuario; si no, intenta dbo.vendedor


        // ======== Utilitarios ========


        // ==== Handlers y stubs para eventos de diseñador ====
        private void BVolverAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void PGraficos_Paint(object sender, PaintEventArgs e) { }
    }
}
