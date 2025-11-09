using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVentaGameBox.Vendedor
{
    public partial class DescargarFactura : Form
    {

        string conecctionString = "server=localhost;Database=game_box;Trusted_Connection=True";
        public DescargarFactura()
        {
            InitializeComponent();
            this.Load += DescargarFactura_Load;
            dgvFacturasVendedor.CellContentClick += dgvFacturasVendedor_CellContentClick;

        }

        private void DescargarFactura_Load(object sender, EventArgs e)
        {
            CargarFacturasDelVendedor(SesionUsuario.IdUsuario);
        }

        private void CargarFacturasDelVendedor(int idUsuario)
        {
            string conecctionString = "server=localhost;Database=game_box;Trusted_Connection=True";
            string query = @"
        SELECT 
            f.fecha_compra AS fecha,
            f.metodo_pago AS MetodoDePago,
            f.total AS montoPagado,
            c.nombre AS cliente
        FROM factura f
        JOIN cliente c ON f.id_cliente = c.id_cliente
        WHERE f.id_usuario = @idUsuario
        ORDER BY f.fecha_compra DESC";

            using (SqlConnection conn = new SqlConnection(conecctionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvFacturasVendedor.DataSource = dt;
            }

            if (!dgvFacturasVendedor.Columns.Contains("btnDescargar"))
            {
                DataGridViewButtonColumn btnDescargar = new DataGridViewButtonColumn();
                btnDescargar.Name = "btnDescargar";
                btnDescargar.HeaderText = "Acción";
                btnDescargar.Text = "Descargar";
                btnDescargar.UseColumnTextForButtonValue = true;
                dgvFacturasVendedor.Columns.Add(btnDescargar);
            }

        }

        private void dgvFacturasVendedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFacturasVendedor.Columns[e.ColumnIndex].Name == "btnDescargar" && e.RowIndex >= 0)
            {
                // Obtener la fecha, método de pago, monto y cliente desde la fila
                DataGridViewRow fila = dgvFacturasVendedor.Rows[e.RowIndex];

                // Obtener el ID de la factura desde la base de datos usando fecha y monto como referencia
                DateTime fecha = Convert.ToDateTime(fila.Cells["fecha"].Value);
                decimal monto = Convert.ToDecimal(fila.Cells["montoPagado"].Value);

                DescargarFacturaComoPDF(fecha, monto);
            }
        }

        private void DescargarFacturaComoPDF(DateTime fechaCompra, decimal montoPagado)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conecctionString))
                {
                    connection.Open();

                    // Buscar la factura exacta
                    string queryFactura = @"
                SELECT TOP 1 * 
                FROM factura 
                WHERE fecha_compra = @fecha AND total = @monto
                ORDER BY fecha_compra DESC";

                    SqlCommand cmdFactura = new SqlCommand(queryFactura, connection);
                    cmdFactura.Parameters.AddWithValue("@fecha", fechaCompra);
                    cmdFactura.Parameters.AddWithValue("@monto", montoPagado);

                    SqlDataReader readerFactura = cmdFactura.ExecuteReader();

                    if (!readerFactura.Read())
                    {
                        MessageBox.Show("No se encontró la factura seleccionada.", "Sin Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    int idFactura = Convert.ToInt32(readerFactura["id_factura"]);
                    decimal total = Convert.ToDecimal(readerFactura["total"]);
                    string metodoPago = readerFactura["metodo_pago"].ToString();
                    object idClienteObj = readerFactura["id_cliente"];
                    readerFactura.Close();

                    // Obtener detalles
                    string queryDetalles = @"
                SELECT fd.cantidad, fd.precio, p.nombre 
                FROM factura_detalle fd
                JOIN producto p ON p.id_producto = fd.id_producto
                WHERE fd.id_factura_cabecera = @IdFactura";

                    SqlCommand cmdDetalles = new SqlCommand(queryDetalles, connection);
                    cmdDetalles.Parameters.AddWithValue("@IdFactura", idFactura);
                    SqlDataReader readerDetalles = cmdDetalles.ExecuteReader();

                    List<string> lineasDetalle = new List<string>();
                    while (readerDetalles.Read())
                    {
                        string nombreProducto = readerDetalles["nombre"].ToString();
                        int cantidad = Convert.ToInt32(readerDetalles["cantidad"]);
                        decimal precio = Convert.ToDecimal(readerDetalles["precio"]);
                        decimal subtotal = cantidad * precio;

                        lineasDetalle.Add($"{nombreProducto} - Cantidad: {cantidad} - Precio: {precio:C2} - Subtotal: {subtotal:C2}");
                    }
                    readerDetalles.Close();

                    // Cliente
                    string nombreCliente = "Cliente General";
                    if (idClienteObj != DBNull.Value)
                    {
                        int idCliente = Convert.ToInt32(idClienteObj);
                        string queryCliente = "SELECT nombre, apellido FROM cliente WHERE id_cliente = @IdCliente";
                        SqlCommand cmdCliente = new SqlCommand(queryCliente, connection);
                        cmdCliente.Parameters.AddWithValue("@IdCliente", idCliente);
                        SqlDataReader readerCliente = cmdCliente.ExecuteReader();

                        if (readerCliente.Read())
                        {
                            nombreCliente = $"{readerCliente["nombre"]} {readerCliente["apellido"]}";
                        }
                        readerCliente.Close();
                    }

                    // PDF
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Title = "Guardar factura como PDF";
                    saveDialog.Filter = "Archivo PDF (*.pdf)|*.pdf";
                    saveDialog.FileName = $"Factura_{idFactura}.pdf";

                    if (saveDialog.ShowDialog() != DialogResult.OK)
                    {
                        return; // El usuario canceló la operación
                    }

                    string rutaCompleta = saveDialog.FileName;

                    Document doc = new Document();
                    PdfWriter.GetInstance(doc, new FileStream(rutaCompleta, FileMode.Create));
                    doc.Open();

                    doc.Add(new Paragraph("Factura GameBox", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18)));
                    doc.Add(new Paragraph($"Fecha: {fechaCompra.ToShortDateString()}"));
                    doc.Add(new Paragraph($"Cliente: {nombreCliente}"));
                    doc.Add(new Paragraph($"Método de Pago: {metodoPago}"));
                    doc.Add(new Paragraph(" "));
                    doc.Add(new Paragraph("Detalles de la compra:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14)));

                    foreach (var linea in lineasDetalle)
                        doc.Add(new Paragraph(linea));

                    doc.Add(new Paragraph(" "));
                    doc.Add(new Paragraph($"Total: {total:C2}"));
                    doc.Add(new Paragraph($"Monto Pagado: {montoPagado:C2}"));
                    doc.Add(new Paragraph($"Cambio: {(montoPagado - total):C2}"));

                    doc.Close();

                    MessageBox.Show($"Factura PDF generada exitosamente en:\n{rutaCompleta}", "PDF Creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar la factura PDF:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void bSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
