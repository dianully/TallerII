using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
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

        private void CargarFacturasDelVendedor(int idUsuario, DateTime? fechaFiltro = null, string dniFiltro = null, string metodoPagoFiltro = null, decimal? totalFiltro = null)
        {
            // Mantengo la definición local de connectionString según tu código original
            string conecctionString = "server=localhost;Database=game_box;Trusted_Connection=True";

            // Usaremos un StringBuilder para construir la consulta dinámicamente
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append(@"
        SELECT 
            f.id_factura AS idFactura,
            f.fecha_compra AS fecha,
            f.metodo_pago AS MetodoDePago,
            f.total AS total,
            RTRIM(c.nombre) + ' ' + RTRIM(c.apellido) AS cliente, 
            f.monto_pagado AS monto_pagado
        FROM factura f
        JOIN cliente c ON f.id_cliente = c.id_cliente
        WHERE f.id_usuario = @idUsuario"); // Condición base: facturas del vendedor actual

            // 1. Filtrar por Fecha (solo DATE)
            if (fechaFiltro.HasValue)
            {
                queryBuilder.Append(" AND CAST(f.fecha_compra AS DATE) = @fechaFiltro");
            }

            // 2. Filtrar por Método de Pago
            if (!string.IsNullOrEmpty(metodoPagoFiltro))
            {
                queryBuilder.Append(" AND f.metodo_pago = @metodoPagoFiltro");
            }

            if (totalFiltro.HasValue)
            {
                queryBuilder.Append(" AND CAST(f.total AS DECIMAL(10,2)) = CAST(@totalFiltro AS DECIMAL(10,2))");
            }


            // 4. Filtrar por DNI de Cliente (requiere subconsulta)
            if (!string.IsNullOrEmpty(dniFiltro))
            {
                // Buscamos el id_cliente cuyo dni coincida con el filtro
                queryBuilder.Append(" AND f.id_cliente IN (SELECT id_cliente FROM cliente WHERE LEFT(dni, 2) = LEFT(@dniFiltro, 2))");

            }

            queryBuilder.Append(" ORDER BY f.fecha_compra DESC");
    
            using (SqlConnection conn = new SqlConnection(conecctionString))
            using (SqlCommand cmd = new SqlCommand(queryBuilder.ToString(), conn))
            {
                // 1. Parámetro obligatorio (ID de Vendedor)
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                // 2. Agregar parámetros de filtro si se usaron
                if (fechaFiltro.HasValue)
                {
                    cmd.Parameters.Add("@fechaFiltro", SqlDbType.Date).Value = fechaFiltro.Value;
                }

                if (!string.IsNullOrEmpty(metodoPagoFiltro))
                {
                    cmd.Parameters.AddWithValue("@metodoPagoFiltro", metodoPagoFiltro);
                }

                if (totalFiltro.HasValue)
                {
                    cmd.Parameters.AddWithValue("@totalFiltro", totalFiltro.Value);
                }

                if (!string.IsNullOrEmpty(dniFiltro))
                {
                    cmd.Parameters.AddWithValue("@dniFiltro", dniFiltro);
                }

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

            dgvFacturasVendedor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvFacturasVendedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFacturasVendedor.Columns[e.ColumnIndex].Name == "btnDescargar" && e.RowIndex >= 0)
            {
                // Obtener la fecha, método de pago, monto y cliente desde la fila
                DataGridViewRow fila = dgvFacturasVendedor.Rows[e.RowIndex];

                // Obtener el ID de la factura desde la base de datos usando fecha y monto como referencia
                DateTime fecha = Convert.ToDateTime(fila.Cells["fecha"].Value);
                decimal monto = Convert.ToDecimal(fila.Cells["total"].Value);
                decimal montoPagado = Convert.ToDecimal(fila.Cells["monto_pagado"].Value);
                DescargarFacturaComoPDF(fecha, monto, montoPagado);
            }
        }

        private void txtSoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void bBuscar_Click(object sender, EventArgs e)
        {
            // Obtener valores de los filtros
            DateTime? fecha = dtpFechaCompra.Value.Date;
            string dni = tbDNI.Text.Trim();
            string metodoPago = cbMetodoDePago.SelectedItem?.ToString();

            // Intentar parsear el monto pagado (usando un nullable decimal)
            decimal? totalFiltro = null;
            if (decimal.TryParse(tbTotalPagado.Text.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal monto))
            {
                totalFiltro = monto;
            }


            // Llamar al método de carga, pasando todos los filtros
            CargarFacturasDelVendedor(SesionUsuario.IdUsuario, fecha, dni, metodoPago, totalFiltro);
        }

        private void DescargarFacturaComoPDF(DateTime fechaCompra, decimal total, decimal montoPagado)
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
                    cmdFactura.Parameters.AddWithValue("@monto", total);

                    SqlDataReader readerFactura = cmdFactura.ExecuteReader();

                    if (!readerFactura.Read())
                    {
                        MessageBox.Show("No se encontró la factura seleccionada.", "Sin Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    int idFactura = Convert.ToInt32(readerFactura["id_factura"]);
                    decimal totalb = Convert.ToDecimal(readerFactura["total"]);
                    string metodoPago = readerFactura["metodo_pago"].ToString();
                    montoPagado = Convert.ToDecimal(readerFactura["monto_pagado"]);
                    object idClienteObj = readerFactura["id_cliente"];
                    // 💡 CAMBIO CRÍTICO: Obtén idUsuario ANTES de cerrar el lector
                    int idUsuarioFactura = Convert.ToInt32(readerFactura["id_usuario"]);

                    // Ya tenemos todos los datos de la factura, cerramos el lector
                    readerFactura.Close();

                    string nombreVendedor = "Vendedor desconocido";

                    string queryVendedor = "SELECT nombre, apellido FROM usuario WHERE id_usuario = @IdUsuario";
                    SqlCommand cmdVendedor = new SqlCommand(queryVendedor, connection);
                    // 💡 Usa la variable local guardada
                    cmdVendedor.Parameters.AddWithValue("@IdUsuario", idUsuarioFactura);

                    SqlDataReader readerVendedor = cmdVendedor.ExecuteReader();
                    if (readerVendedor.Read())
                    {
                        nombreVendedor = $"{readerVendedor["nombre"]} {readerVendedor["apellido"]}";
                    }
                    readerVendedor.Close();


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
                    string dni = "", email = "", telefono = "", genero = "";

                    if (idClienteObj != DBNull.Value)
                    {
                        int idCliente = Convert.ToInt32(idClienteObj);
                        string queryCliente = @"
        SELECT nombre, apellido, dni, email, telefono, genero 
        FROM cliente 
        WHERE id_cliente = @IdCliente";

                        SqlCommand cmdCliente = new SqlCommand(queryCliente, connection);
                        cmdCliente.Parameters.AddWithValue("@IdCliente", idCliente);
                        SqlDataReader readerCliente = cmdCliente.ExecuteReader();

                        if (readerCliente.Read())
                        {
                            nombreCliente = $"{readerCliente["nombre"]} {readerCliente["apellido"]}";
                            dni = readerCliente["dni"]?.ToString() ?? "";
                            email = readerCliente["email"]?.ToString() ?? "";
                            telefono = readerCliente["telefono"]?.ToString() ?? "";
                            genero = readerCliente["genero"]?.ToString() ?? "";
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
                    Document doc = new Document(PageSize.A4, 50, 50, 50, 50);
                    PdfWriter.GetInstance(doc, new FileStream(rutaCompleta, FileMode.Create));
                    doc.Open();

                    // --- SECCIÓN DE ENCABEZADO PRINCIPAL (REEMPLAZAR) ---

                    // 1. Crear una tabla de 2 columnas para el Encabezado
                    PdfPTable tituloFactura = new PdfPTable(2);
                    tituloFactura.WidthPercentage = 100;

                    // Ajustamos los anchos: GAME-BOX (80%) ocupa mucho más espacio que la info de la factura (20%)
                    tituloFactura.SetWidths(new float[] { 80f, 20f });
                    tituloFactura.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    // 2. Celda 1 (Izquierda): Título "GAME-BOX"
                    PdfPCell cellTitulo = new PdfPCell(new Phrase("GAME-BOX", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 30))); // Tamaño 30 para hacerlo más grande
                    cellTitulo.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    // Alinear el texto GAME-BOX a la parte inferior de su celda (para acercarlo a la línea)
                    cellTitulo.VerticalAlignment = Element.ALIGN_BOTTOM;
                    tituloFactura.AddCell(cellTitulo);

                    // 3. Celda 2 (Derecha): Número y Fecha compactos
                    PdfPCell cellInfo = new PdfPCell();
                    cellInfo.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    // Usamos ALIGN_TOP para que el contenido de la factura empiece en la parte superior de su celda (alineado con la parte superior de GAME-BOX)
                    cellInfo.VerticalAlignment = Element.ALIGN_TOP;
                    cellInfo.HorizontalAlignment = Element.ALIGN_RIGHT; // Alinea todo el contenido de esta celda a la derecha

                    // Párrafo para el número de factura y la fecha en dos líneas compactas
                    Paragraph pInfo = new Paragraph();
                    pInfo.Alignment = Element.ALIGN_RIGHT;
                    pInfo.Add(new Chunk($"Factura N.º: {idFactura}\n", FontFactory.GetFont(FontFactory.HELVETICA, 10))); // Tamaño 10
                                                                                                                         // Combinamos fecha y hora en una sola línea para evitar saltos
                    pInfo.Add(new Chunk($"Fecha de Emisión: {fechaCompra:dd/MM/yyyy HH:mm}", FontFactory.GetFont(FontFactory.HELVETICA, 10)));

                    cellInfo.AddElement(pInfo);

                    // Agregar la celda de información de la factura a la tabla
                    tituloFactura.AddCell(cellInfo);

                    // 4. Agregar la tabla principal al documento
                    doc.Add(tituloFactura);
                    // Crear una línea para simular la división
                    doc.Add(new LineSeparator());

                    // 1. Crear una tabla de 2 columnas para el encabezado de datos
                    PdfPTable datosEncabezado = new PdfPTable(2);
                    datosEncabezado.WidthPercentage = 100;
                    // Ajustar el ancho de las columnas (opcional, 50/50 por defecto)
                    // datosEncabezado.SetWidths(new float[] { 50f, 50f }); 

                    // --- Configuración de la Columna Izquierda (Datos del Cliente) ---
                    PdfPCell cellCliente = new PdfPCell();
                    cellCliente.Border = iTextSharp.text.Rectangle.NO_BORDER; // Asegura que no tenga bordes
                    cellCliente.AddElement(new Paragraph("Datos del Cliente:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14)));
                    cellCliente.AddElement(new Paragraph($"Nombre y Apellido: {nombreCliente}"));
                    cellCliente.AddElement(new Paragraph($"DNI: {dni}"));
                    cellCliente.AddElement(new Paragraph($"Email: {email}"));
                    cellCliente.AddElement(new Paragraph($"Teléfono: {telefono}"));
                    cellCliente.AddElement(new Paragraph($"Género: {genero}"));

                    // --- Configuración de la Columna Derecha (Datos Emisora) ---
                    PdfPCell cellEmisora = new PdfPCell();
                    cellEmisora.Border = iTextSharp.text.Rectangle.NO_BORDER; // Asegura que no tenga bordes
                    cellEmisora.AddElement(new Paragraph("Datos Emisora:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14)));
                    cellEmisora.AddElement(new Paragraph("Dirección: Moreno 1503, Corrientes Capital"));
                    cellEmisora.AddElement(new Paragraph("Correo: gameboxofficial@gmail.com"));
                    cellEmisora.AddElement(new Paragraph("Teléfono: +54 379 4621207"));
                    cellEmisora.AddElement(new Paragraph($"Vendedor: {nombreVendedor}"));

                    // 2. Agregar las celdas a la tabla
                    datosEncabezado.AddCell(cellCliente);
                    datosEncabezado.AddCell(cellEmisora);

                    // 3. Agregar la tabla al documento
                    doc.Add(datosEncabezado);
                    doc.Add(new Paragraph(" ")); // Espacio entre el encabezado de datos y la tabla de productos

                    // Tabla de productos
                    PdfPTable tabla = new PdfPTable(5);
                    tabla.WidthPercentage = 100;
                    tabla.SetWidths(new float[] { 10, 40, 20, 15, 15 });

                    tabla.AddCell("Nro");
                    tabla.AddCell("Nombre");
                    tabla.AddCell("Precio Unit.");
                    tabla.AddCell("Cantidad");
                    tabla.AddCell("Total");

                    int nro = 1;
                    decimal sumaTotal = 0;
                    foreach (var linea in lineasDetalle)
                    {
                        // Parsear la línea
                        var partes = linea.Split(new[] { " - " }, StringSplitOptions.None);
                        string nombre = partes[0];
                        string cantidadStr = partes[1].Split(':')[1].Trim();
                        string precioStr = partes[2].Split(':')[1].Trim().Replace("$", "");
                        string subtotalStr = partes[3].Split(':')[1].Trim().Replace("$", "");

                        int cantidad = int.Parse(cantidadStr);
                        decimal precio = decimal.Parse(precioStr);
                        decimal subtotal = decimal.Parse(subtotalStr);

                        tabla.AddCell(nro.ToString());
                        tabla.AddCell(nombre);
                        tabla.AddCell($"{precio:C2}");
                        tabla.AddCell(cantidad.ToString());
                        tabla.AddCell($"{subtotal:C2}");

                        sumaTotal += subtotal;
                        nro++;
                    }
                    doc.Add(tabla);
                    doc.Add(new Paragraph(" "));

                    // Totales
                    Paragraph pTotal = new Paragraph($"Total: {total:C2}", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12));
                    pTotal.Alignment = Element.ALIGN_RIGHT;
                    doc.Add(pTotal);

                    if (metodoPago.ToLower() == "efectivo")
                    {
                        Paragraph ptotal = new Paragraph($"Monto Pagado: {montoPagado:C2}", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12));
                        ptotal.Alignment = Element.ALIGN_RIGHT;
                        doc.Add(ptotal);
                    }

                    Paragraph pMetodoPago = new Paragraph($"Método de Pago: {metodoPago}", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12));
                    pMetodoPago.Alignment = Element.ALIGN_RIGHT;
                    doc.Add(pMetodoPago);

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
