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

        private void txtBloqueado_MouseDown(object sender, MouseEventArgs e)
        {
           
            this.ActiveControl = null;
        }

        private void txtSoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
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

                dgvListaDeCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                foreach (DataGridViewColumn col in dgvListaDeCompra.Columns)
                {
                    col.ReadOnly = true;
                }
                dgvListaDeCompra.Columns["Cantidad"].ReadOnly = false;

                dgvListaDeCompra.CellValueChanged += dgvListaDeCompra_CellValueChanged;
            }
        }

        private void dgvListaDeCompra_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Solo actuamos si el cambio es en una fila válida y en la columna "Cantidad"
            if (e.RowIndex >= 0 && dgvListaDeCompra.Columns[e.ColumnIndex]?.Name == "Cantidad")
            {
                var fila = dgvListaDeCompra.Rows[e.RowIndex];
                var celdaCantidad = fila.Cells["Cantidad"].Value;
                string nombreProducto = fila.Cells["Nombre"]?.Value?.ToString();

                // 1. Validar que la nueva cantidad sea un número válido y mayor a cero
                if (!int.TryParse(celdaCantidad?.ToString(), out int nuevaCantidad) || nuevaCantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser un número entero mayor a cero.", "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fila.Cells["Cantidad"].Value = 1;
                    nuevaCantidad = 1;
                }

                // =======================================================
                // LÓGICA DE VERIFICACIÓN DE STOCK (SIN FUNCIÓN AUXILIAR)
                // =======================================================
                int stockActual = -1; // Inicializamos a un valor de error

                if (!string.IsNullOrEmpty(nombreProducto))
                {
                    string consultaStock = "SELECT cantidad_stock FROM producto WHERE nombre = @nombre COLLATE Latin1_General_CI_AI";

                    using (SqlConnection conexion = new SqlConnection(conecctionString))
                    using (SqlCommand comando = new SqlCommand(consultaStock, conexion))
                    {
                        comando.Parameters.AddWithValue("@nombre", nombreProducto);
                        try
                        {
                            conexion.Open();
                            object resultado = comando.ExecuteScalar();

                            if (resultado != null && resultado != DBNull.Value)
                            {
                                stockActual = Convert.ToInt32(resultado);
                            }
                            else
                            {
                                stockActual = 0; // Producto encontrado pero stock es nulo o 0
                            }
                        }
                        catch (Exception ex)
                        {
                            // Manejo de errores de base de datos
                            MessageBox.Show("Error al obtener stock: " + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Detener el proceso por error crítico
                        }
                    }
                }

                // 2. Comprobar el Stock
                if (stockActual != -1) // Si la consulta se ejecutó sin errores críticos
                {
                    if (nuevaCantidad > stockActual)
                    {
                        MessageBox.Show($"La cantidad solicitada ({nuevaCantidad}) supera el stock disponible ({stockActual}).", "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // RESTAURAR AL MÁXIMO STOCK PERMITIDO
                        fila.Cells["Cantidad"].Value = stockActual;
                        nuevaCantidad = stockActual; // Usamos el stock máximo para el cálculo
                    }
                }
               


                var celdaPrecio = fila.Cells["PrecioUnitario"].Value;

                if (celdaPrecio != null)
                {
                    if (decimal.TryParse(celdaPrecio.ToString().Replace("$", "").Trim(), out decimal precioUnitario))
                    {
                        decimal nuevoTotal = nuevaCantidad * precioUnitario;
                        fila.Cells["Total"].Value = nuevoTotal.ToString("C");
                        ActualizarTotal();
                    }
                }
            }
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

        public void SetGeneroCliente(string genero)
        {
            tbGenero.Text = genero;
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

            if (!int.TryParse(tbCantidad.Text.Trim(), out int cantidadSolicitada) || cantidadSolicitada <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataGridViewRow fila in dgvListaDeCompra.Rows)
            {
                if (fila.IsNewRow) continue;

                // Asumiendo que la columna de nombre es la primera o se llama "Nombre"
                if (fila.Cells["Nombre"]?.Value?.ToString().Equals(nombreProducto, StringComparison.OrdinalIgnoreCase) == true)
                {
                    MessageBox.Show($"El producto '{nombreProducto}' ya se encuentra en la lista de compra. Para modificar la cantidad, edite la celda directamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // No permite agregarlo si ya existe
                }
            }

            // 💡 MODIFICACIÓN: La consulta ahora pide el precio de venta Y la cantidad de stock
            string consulta = "SELECT precio_venta, cantidad_stock FROM producto WHERE nombre = @nombre COLLATE Latin1_General_CI_AI";

            using (SqlConnection conexion = new SqlConnection(conecctionString))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@nombre", nombreProducto);
                conexion.Open();

                // Usamos ExecuteReader para obtener ambas columnas (precio y stock)
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read()) // Si se encontró el producto
                    {
                        decimal precioUnitario = reader.GetDecimal(reader.GetOrdinal("precio_venta"));
                        int stockActual = reader.GetInt32(reader.GetOrdinal("cantidad_stock"));

                        // 💡 NUEVA LÓGICA DE VALIDACIÓN DE STOCK
                        if (cantidadSolicitada > stockActual)
                        {
                            MessageBox.Show($"Stock insuficiente para el producto '{nombreProducto}'. Stock disponible: {stockActual}.", "Error de Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Detiene la adición si no hay stock suficiente
                        }

                        // Si el stock es suficiente, procedemos a agregar la fila
                        decimal total = precioUnitario * cantidadSolicitada;

                        dgvListaDeCompra.Rows.Add(nombreProducto, precioUnitario.ToString("C"), cantidadSolicitada, total.ToString("C"));

                        // Limpiar campos
                        tbNombreProducto.Clear();
                        tbCantidad.Clear();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el producto en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } // El reader se cierra automáticamente aquí
            } // La conexión se cierra automáticamente aquí

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

        private void tbMontoPagado_TextChanged(object sender, EventArgs e)
        {
            // 1. Verificar si el método de pago es 'Efectivo'
            if (cbMetodoDePago.SelectedItem == null || cbMetodoDePago.SelectedItem.ToString() != "Efectivo")
            {
                tbCambio.Text = ""; // Limpiar si no es efectivo
                return;
            }

            // 2. Obtener el Total de la Factura
            decimal totalFactura = CalcularTotal();
            decimal montoPagado;

            // 3. Intentar convertir lo escrito a un número decimal
            // Usamos .Replace('$', '') para limpiar cualquier formato que se haya puesto por error
            string textoMonto = tbMontoPagado.Text.Trim().Replace("$", "");

            if (decimal.TryParse(textoMonto, out montoPagado))
            {
                // 4. Calcular el cambio y mostrarlo
                decimal cambio = montoPagado - totalFactura;

                // Muestra el cambio. Se usa "C2" para formato de moneda con 2 decimales.
                // Si el monto pagado es menor, el cambio será negativo, indicando que falta dinero.
                tbCambio.Text = cambio.ToString("C2");
            }
            else
            {
                // Si el texto no es un número válido (ej: solo un punto, o letras), limpiar el campo de cambio.
                tbCambio.Text = "";
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
            int idCliente = 0; // 💡 Por defecto, la factura se asocia al ID 0 (Cliente Genérico)

            if (!string.IsNullOrEmpty(dniCliente))
            {
                // Si el usuario ingresó un DNI, intentamos encontrarlo
                idCliente = ObtenerIdClientePorDNI(dniCliente);

                if (idCliente == -1) // Asumiendo que ObtenerIdClientePorDNI retorna -1 si no lo encuentra
                {
                    MessageBox.Show("El DNI ingresado no corresponde a un cliente registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Detiene la ejecución si se ingresó un DNI inválido
                }
                // Si el DNI se encuentra, idCliente ya contiene el ID real del cliente.
            }

            if (cbMetodoDePago.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un método de pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string metodoPago = cbMetodoDePago.SelectedItem.ToString();
            decimal totalFac = CalcularTotal();
            decimal montoPagado = 0;

            if (metodoPago == "Efectivo")
            {
                // 1. Efectivo: Obtiene el monto del TextBox y valida
                if (!decimal.TryParse(tbMontoPagado.Text.Trim(), out montoPagado) || montoPagado <= 0)
                {
                    MessageBox.Show("Debe ingresar un monto válido para el pago en efectivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. Validación de pago insuficiente
                if (montoPagado < totalFac)
                {
                    MessageBox.Show("El monto pagado es insuficiente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Nota: El cálculo del cambio en tiempo real (Punto 1) ya se encarga de tbCambio
            }
            else
            {
                // 1. Tarjeta/Otro: Obtener el total del Label lCantidad
                // (Asumimos que lCantidad.Text contiene el valor final de la compra)
                totalFac = ExtraerValorDecimal(lCantidad.Text);

                // 2. Establecer monto_pagado a 0, según la especificación
                montoPagado = 0;

                // Para tarjeta/otros, no hay cambio a calcular ni validación de insuficiencia.
            }

            decimal totalFactura = CalcularTotal();

            if (metodoPago == "Efectivo" && montoPagado < totalFactura)
            {
                MessageBox.Show("El monto pagado es insuficiente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


                string insertFactura = @"INSERT INTO factura (fecha_compra, total, monto_pagado, metodo_pago, id_cliente, id_usuario, activo)
                         VALUES (@fecha, @total, @monto, @metodo, @idCliente, @idUsuario, @activo);
                         SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(insertFactura, conexion))
                {
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                    cmd.Parameters.AddWithValue("@total", totalFactura);
                    cmd.Parameters.AddWithValue("@monto", montoPagado);
                    cmd.Parameters.AddWithValue("@metodo", metodoPago);
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    cmd.Parameters.AddWithValue("@idUsuario", SesionUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@activo", 1); 

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

                    tbCambio.Clear();

                    // Opcional: limpiar también los campos de DNI y Monto Pagado
                    tbDNI.Clear();
                    tbNombreCliente.Clear();
                    tbGenero.Clear(); 
                    tbMontoPagado.Clear();

                    // Opcional: Restaurar el ComboBox
                    cbMetodoDePago.SelectedItem = null;
                }
            }
        }
        private void cbMetodoDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Aseguramos que haya un ítem seleccionado
            if (cbMetodoDePago.SelectedItem == null)
            {
                tbMontoPagado.ReadOnly = true;
                tbMontoPagado.TabStop = false;
                tbMontoPagado.Clear();
                tbCambio.Clear();
                return;
            }

            string metodo = cbMetodoDePago.SelectedItem.ToString();

            if (metodo == "Efectivo")
            {
                // 1. Efectivo: Habilita la escritura y selección
                tbMontoPagado.ReadOnly = false;
                tbMontoPagado.TabStop = true;
            }
            else
            {
                // 2. Tarjeta/Otro: Bloquea la escritura y selección (como solicitaste)
                tbMontoPagado.ReadOnly = true;
                tbMontoPagado.TabStop = false;
            }

            // Siempre limpia los campos al cambiar de método de pago
            tbMontoPagado.Clear();
            tbCambio.Clear();
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
        private decimal ExtraerValorDecimal(string texto)
        {
            // 1. Limpia el texto (quita el '$' y espacios)
            string limpio = texto.Trim().Replace("$", "");

            // 2. Intenta parsear el valor usando la cultura actual para manejar comas/puntos decimales
            // Esto es importante para que funcione correctamente con tu formato regional.
            if (decimal.TryParse(limpio, System.Globalization.NumberStyles.Currency, System.Globalization.CultureInfo.CurrentCulture, out decimal valor))
            {
                return valor;
            }
            return 0;
        }

        private void bNuevoCliente_Click(object sender, EventArgs e)
        {
            AgregarCliente pagina = new AgregarCliente();
            pagina.ShowDialog();
        }

        private void bReestablecer_Click(object sender, EventArgs e)
        {
            tbDNI.Clear();  
            tbNombreCliente.Clear();    
            tbGenero.Clear();
        }
    }
}

