using PuntoDeVentaGameBox.Administrador;
using PuntoDeVentaGameBox.Clases;
using PuntoDeVentaGameBox.Gerente;
using PuntoDeVentaGameBox.Vendedor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;    


namespace PuntoDeVentaGameBox.Vendedor
{
    public partial class Vendedor : Form
    {

        string conecctionString = "server=localhost;Database=game_box;Trusted_Connection=True";
        // Constructor

        public struct ItemDetalle
        {
            public int IdProducto { get; set; }
            public int Cantidad { get; set; }
            public decimal PrecioTotalLinea { get; set; }
        }

        public Vendedor()
        {
            InitializeComponent();

            lVendedor.Text = $"{SesionUsuario.Nombre} {SesionUsuario.Apellido}";

        }


        private void bCerrar_Click(object sender, EventArgs e)
        {
            SesionUsuario.LimpiarSesion();

            // Oculta el formulario actual
            this.Hide();

            // Crea una nueva instancia del formulario de Login y la muestra
            Login loginForm = new Login();
            loginForm.Show();
        }

        private void lVendedor_Click_1(object sender, EventArgs e)
        {
            // Determina el nombre del rol basado en el IdRol
            string nombreRol = "";
            switch (SesionUsuario.IdRol)
            {
                case 2:
                    nombreRol = "Administrador";
                    break;
                case 3:
                    nombreRol = "Vendedor";
                    break;
                default:
                    nombreRol = "Gerente";
                    break;
            }

            // Abre el formulario de edición, pasando los datos del usuario actual desde la sesión
            EdicionUsuario formEdicion = new EdicionUsuario(
                SesionUsuario.IdUsuario,
                SesionUsuario.Nombre,
                SesionUsuario.Apellido,
                SesionUsuario.Dni,
                SesionUsuario.Email,
                SesionUsuario.Telefono,
                SesionUsuario.Contraseña,
                nombreRol,
                SesionUsuario.IdRol
            );

            // Usamos ShowDialog() para que la ventana de edición sea modal.
            formEdicion.ShowDialog();
        }


        private void Vendedor_Load(object sender, EventArgs e)
        {

            dgvListaDeCompra.CellContentClick += dgvListaDeCompra_CellContentClick;
            lCantidad.Text = "$0.00";
        }

        public void SetNombreProducto(string nombre)
        {
            tbNombreProducto.Text = nombre;
        }

        public void SetCliente(string nombre)
        {
            tbNombreCliente.Text = nombre;
        }

        public void SetDniCliente(string dni)
        {
            tbDNI.Text = dni;
        }

        private void bDescargarFactura_Click(object sender, EventArgs e)
        {
            DescargarFactura descargarFactura = new DescargarFactura();
            descargarFactura.ShowDialog();
        }


        private void bElegirProducto_Click(object sender, EventArgs e)
        {
            BuscarProducto pagina = new BuscarProducto();
            pagina.ShowDialog();
        }

        private void bCargarProducto_Click(object sender, EventArgs e)
        {
            string nombreProducto = tbNombreProducto.Text.Trim();
            if (string.IsNullOrEmpty(nombreProducto))
            {
                MessageBox.Show("Debe seleccionar un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(tbCantidad.Text.Trim(), out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string consulta = "SELECT precio_venta FROM producto WHERE nombre = @nombre COLLATE Latin1_General_CI_AI";

            using (SqlConnection conexion = new SqlConnection(conecctionString))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@nombre", nombreProducto);
                conexion.Open();

                object resultado = comando.ExecuteScalar();

                if (resultado != null)
                {
                    decimal precioUnitario = Convert.ToDecimal(resultado);
                    decimal total = precioUnitario * cantidad;

                    // Si el DataGridView no tiene columnas, las definimos
                    if (dgvListaDeCompra.Columns.Count == 0)
                    {
                        dgvListaDeCompra.Columns.Add("Nombre", "Nombre");
                        dgvListaDeCompra.Columns.Add("PrecioUnitario", "Precio Unitario");
                        dgvListaDeCompra.Columns.Add("Cantidad", "Cantidad");
                        dgvListaDeCompra.Columns.Add("Total", "Total");

                        // Columna de botón "Quitar"
                        DataGridViewButtonColumn btnQuitar = new DataGridViewButtonColumn();
                        btnQuitar.Name = "Quitar";
                        btnQuitar.HeaderText = "Acción";
                        btnQuitar.Text = "Quitar";
                        btnQuitar.UseColumnTextForButtonValue = true;
                        dgvListaDeCompra.Columns.Add(btnQuitar);
                    }


                    dgvListaDeCompra.Rows.Add(nombreProducto, precioUnitario.ToString("C"), cantidad, total.ToString("C"));

                    // Limpiar campos
                    tbNombreProducto.Clear();
                    tbCantidad.Clear();
                }
                else
                {
                    MessageBox.Show("No se encontró el producto en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            ActualizarTotal();
        }

        private void ActualizarTotal()
        {
            decimal totalGeneral = 0;

            foreach (DataGridViewRow fila in dgvListaDeCompra.Rows)
            {
                if (fila.Cells["Total"].Value != null)
                {
                    string valorTexto = fila.Cells["Total"].Value.ToString().Replace("$", "").Trim();
                    if (decimal.TryParse(valorTexto, out decimal valor))
                    {
                        totalGeneral += valor;
                    }
                }
            }

            lCantidad.Text = $"${totalGeneral:F2}";
        }

        private void dgvListaDeCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvListaDeCompra.Columns[e.ColumnIndex].Name == "Quitar")
            {
                dgvListaDeCompra.Rows.RemoveAt(e.RowIndex);
                ActualizarTotal();
            }
        }

        private void bBuscarCliente_Click(object sender, EventArgs e)
        {
            BuscarCliente pagina = new BuscarCliente();
            pagina.ShowDialog();
        }

        private void bCobrar_Click(object sender, EventArgs e)
        {
            if (dgvListaDeCompra.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dniCliente = tbDNI.Text.Trim();
            if (string.IsNullOrEmpty(dniCliente))
            {
                MessageBox.Show("Debe ingresar el dni del cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbMetodoDePago.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un método de pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string metodoPago = cbMetodoDePago.SelectedItem.ToString();
            decimal montoPagado = 0;

            if (metodoPago == "Efectivo")
            {
                if (!decimal.TryParse(tbMontoPagado.Text.Trim(), out montoPagado) || montoPagado <= 0)
                {
                    MessageBox.Show("Debe ingresar un monto válido para el pago en efectivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                montoPagado = CalcularTotal(); // Para tarjeta, asumimos que paga el total
            }

            decimal totalFactura = CalcularTotal();

            if (metodoPago == "Efectivo" && montoPagado < totalFactura)
            {
                MessageBox.Show("El monto pagado es insuficiente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idCliente = ObtenerIdClientePorDNI(dniCliente); // Método que podés definir
            if (idCliente == -1)
            {
                MessageBox.Show("Cliente no encontrado en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conexion = new SqlConnection(conecctionString))
            {
                conexion.Open();

                foreach (DataGridViewRow fila in dgvListaDeCompra.Rows)
                {
                    if (fila.IsNewRow) continue;

                    var celdaNombre = fila.Cells["Nombre"]?.Value;
                    var celdaCantidad = fila.Cells["Cantidad"]?.Value;

                    if (celdaNombre == null || celdaCantidad == null)
                    {
                        MessageBox.Show("Hay una fila incompleta en la lista de compra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string nombreProducto = celdaNombre.ToString();
                    int cantidadSolicitada = Convert.ToInt32(celdaCantidad);

                    int idProducto = ObtenerIdProductoPorNombre(nombreProducto);

                    using (SqlCommand stockCheckCmd = new SqlCommand("SELECT cantidad_stock FROM producto WHERE id_producto = @idProducto", conexion))
                    {
                        stockCheckCmd.Parameters.AddWithValue("@idProducto", idProducto);
                        int stockActual = Convert.ToInt32(stockCheckCmd.ExecuteScalar());

                        if (cantidadSolicitada > stockActual)
                        {
                            MessageBox.Show($"Stock insuficiente para el producto '{nombreProducto}'. Disponible: {stockActual}, solicitado: {cantidadSolicitada}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }


                string insertFactura = @"INSERT INTO factura (fecha_compra, total, monto_pagado, metodo_pago, id_cliente, id_usuario)
                                 VALUES (@fecha, @total, @monto, @metodo, @idCliente, @idUsuario);
                                 SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(insertFactura, conexion))
                {
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                    cmd.Parameters.AddWithValue("@total", totalFactura);
                    cmd.Parameters.AddWithValue("@monto", montoPagado);
                    cmd.Parameters.AddWithValue("@metodo", metodoPago);
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    cmd.Parameters.AddWithValue("@idUsuario", SesionUsuario.IdUsuario);

                    int idFactura = Convert.ToInt32(cmd.ExecuteScalar());

                    // Insertar factura_detalle
                    foreach (DataGridViewRow fila in dgvListaDeCompra.Rows)
                    {
                        if (fila.IsNewRow) continue; // Evita la fila vacía al final

                        var celdaNombre = fila.Cells["Nombre"]?.Value;
                        var celdaCantidad = fila.Cells["Cantidad"]?.Value;
                        var celdaPrecio = fila.Cells["PrecioUnitario"]?.Value;

                        if (celdaNombre == null || celdaCantidad == null || celdaPrecio == null)
                        {
                            MessageBox.Show("Hay una fila incompleta en la lista de compra. Verifique los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }

                        string nombreProducto = celdaNombre.ToString();
                        int cantidad = Convert.ToInt32(celdaCantidad);
                        decimal precioUnitario = Convert.ToDecimal(celdaPrecio.ToString().Replace("$", ""));

                        int idProducto = ObtenerIdProductoPorNombre(nombreProducto);

                        string insertDetalle = @"INSERT INTO factura_detalle (id_factura_cabecera, id_producto, cantidad, precio)
                             VALUES (@idFactura, @idProducto, @cantidad, @precio)";

                        using (SqlCommand detalleCmd = new SqlCommand(insertDetalle, conexion))
                        {
                            detalleCmd.Parameters.AddWithValue("@idFactura", idFactura);
                            detalleCmd.Parameters.AddWithValue("@idProducto", idProducto);
                            detalleCmd.Parameters.AddWithValue("@cantidad", cantidad);
                            detalleCmd.Parameters.AddWithValue("@precio", precioUnitario);

                            detalleCmd.ExecuteNonQuery();
                        }

                        string actualizarStock = @"UPDATE producto
                               SET cantidad_stock = cantidad_stock - @cantidad
                               WHERE id_producto = @idProducto";

                        using (SqlCommand stockCmd = new SqlCommand(actualizarStock, conexion))
                        {
                            stockCmd.Parameters.AddWithValue("@cantidad", cantidad);
                            stockCmd.Parameters.AddWithValue("@idProducto", idProducto);
                            stockCmd.ExecuteNonQuery();
                        }
                    }



                    MessageBox.Show("Venta registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvListaDeCompra.Rows.Clear();
                    ActualizarTotal();
                }
            }
        }

        private decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow fila in dgvListaDeCompra.Rows)
            {
                if (fila.Cells["Total"].Value != null)
                {
                    string valorTexto = fila.Cells["Total"].Value.ToString().Replace("$", "").Trim();
                    if (decimal.TryParse(valorTexto, out decimal valor))
                    {
                        total += valor;
                    }
                }
            }
            return total;
        }

        private int ObtenerIdClientePorNombre(string nombre)
        {
            using (SqlConnection conexion = new SqlConnection(conecctionString))
            {
                string consulta = "SELECT id_cliente FROM cliente WHERE nombre = @nombre";
                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    conexion.Open();
                    object resultado = cmd.ExecuteScalar();
                    return resultado != null ? Convert.ToInt32(resultado) : -1;
                }
            }
        }

        private int ObtenerIdClientePorDNI(string dni)
        {
            using (SqlConnection conexion = new SqlConnection(conecctionString))
            {
                string consulta = "SELECT id_cliente FROM cliente WHERE dni = @dni";
                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@dni", dni);
                    conexion.Open();
                    object resultado = cmd.ExecuteScalar();
                    return resultado != null ? Convert.ToInt32(resultado) : -1;
                }
            }
        }


        private int ObtenerIdProductoPorNombre(string nombre)
        {
            using (SqlConnection conexion = new SqlConnection(conecctionString))
            {
                string consulta = "SELECT id_producto FROM producto WHERE nombre = @nombre";
                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    conexion.Open();
                    object resultado = cmd.ExecuteScalar();
                    return resultado != null ? Convert.ToInt32(resultado) : -1;
                }
            }
        }

    }
}

