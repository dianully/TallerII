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

            tbClienteGmail.TextChanged += tClienteGmail_TextChanged;

            tbMontoPagado.Font = new System.Drawing.Font(tbMontoPagado.Font.FontFamily, 14, System.Drawing.FontStyle.Regular);

            // Puedes probar con 16 si 14 no es suficiente.

            // Configuración inicial del Placeholder
            tbMontoPagado.Text = "Ingresar Monto";
            tbMontoPagado.ForeColor = Color.Gray;

            // Asignar los eventos
            tbMontoPagado.Enter += tbMontoPagado_Enter;
            tbMontoPagado.Leave += tbMontoPagado_Leave;

            ConfigurarPlaceholder(tbCambio, "Cambio");
            tbCambio.ForeColor = Color.Gray;
            tbCambio.Font = new System.Drawing.Font(tbCambio.Font.FontFamily, 14, System.Drawing.FontStyle.Regular);


            // Aplicar a otros TextBoxes con diferentes textos
            ConfigurarPlaceholder(tbNombreCliente, "Nombre");
            ConfigurarPlaceholder(tbApellidoCliente, "Apellido");
            ConfigurarPlaceholder(tbClienteGmail, "Correo");
            ConfigurarPlaceholder(tbSexo, "Sexo");
            ConfigurarPlaceholder(tbTelefono, "Telefono");

            CargarClientesEnComboBox();
        }

        private void tbMontoPagado_Enter(object sender, EventArgs e)
        {
            if (tbMontoPagado.Text == "Ingresar Monto")
            {
                tbMontoPagado.Text = "";
                tbMontoPagado.ForeColor = Color.Black; // Cambia el color a uno normal
                // tbMontoPagado.Font = new Font(tbMontoPagado.Font.FontFamily, 14, FontStyle.Bold); 
            }
        }

        private void tbMontoPagado_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbMontoPagado.Text))
            {
                tbMontoPagado.Text = "Ingresar Monto";
                tbMontoPagado.ForeColor = Color.Gray; // Restaura el color del placeholder
                // tbMontoPagado.Font = new Font(tbMontoPagado.Font.FontFamily, 14, FontStyle.Regular); 
            }
        }

        private void ConfigurarPlaceholder(TextBox textBox, string placeholderText)
        {
            // 1. Configuración inicial
            textBox.Text = placeholderText;
            textBox.ForeColor = Color.Gray;
            // 2. Asignar los eventos con la lógica de placeholder
            textBox.Enter -= Placeholder_Enter; // Asegura que el evento no esté duplicado
            textBox.Leave -= Placeholder_Leave;
            textBox.Enter += Placeholder_Enter;
            textBox.Leave += Placeholder_Leave;
            // 3. Almacenar el texto original para el evento Leave
            textBox.Tag = placeholderText;
        }
        // Evento genérico para cuando el TextBox recibe el foco
        private void Placeholder_Enter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null && tb.Text == tb.Tag.ToString())
            {
                tb.Text = "";
                tb.ForeColor = Color.Gray;
            }
        }
        // Evento genérico para cuando el TextBox pierde el foco
        private void Placeholder_Leave(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null && string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = tb.Tag.ToString(); // Usa el texto guardado en la propiedad Tag
                tb.ForeColor = Color.Gray;
            }
        }

        private void AlternarControlesCliente()
        {
            bool registradoSeleccionado = rbClienteRegistrado.Checked;

            // Si usaste un Panel/GroupBox para agrupar los controles (RECOMENDADO):
            // pnlClienteRegistrado.Enabled = registradoSeleccionado;

            // Si manejas los controles individualmente:
            cbCliente.Enabled = registradoSeleccionado;

            // Deshabilita los TextBoxes de información si no está registrado
            // y los limpia.
            tbNombreCliente.Enabled = false;
            tbApellidoCliente.Enabled = false;
            tbClienteGmail.Enabled = false;
            tbTelefono.Enabled = false;
            tbSexo.Enabled = false;

            if (!registradoSeleccionado)
            {
                // Si se cambia a Cliente General, limpia los campos de datos
                LimpiarCamposCliente();
                // Asegúrate de que el ComboBox de cliente vuelva a "Cliente General"
                cbCliente.SelectedIndex = 0;
            }
        }

        private void rbClienteGeneral_CheckedChanged(object sender, EventArgs e)
        {
            // Solo actuamos si el RadioButton está siendo marcado, no desmarcado
            if (rbClienteGeneral.Checked)
            {
                AlternarControlesCliente();
            }
        }

        private void rbClienteRegistrado_CheckedChanged(object sender, EventArgs e)
        {
            // Solo actuamos si el RadioButton está siendo marcado, no desmarcado
            if (rbClienteRegistrado.Checked)
            {
                AlternarControlesCliente();

                // Opcional: Enfocar el ComboBox para que el usuario empiece a buscar
                cbCliente.Focus();
            }
        }

        private void CargarClientesEnComboBox()
        {
            List<Cliente> clientes = Cliente.ObtenerTodosLosClientes();

            cbCliente.DataSource = clientes;
            // ValueMember: Usamos el ID interno
            cbCliente.ValueMember = "Dni";
            // DisplayMember: No lo definimos para que use ToString(), que devuelve el DNI.
            // cbCliente.DisplayMember = "Dni"; // Si lo dejas así, también funciona.

            cbCliente.SelectedIndex = 0; // Selecciona la opción "Cliente General" (DNI=0)
        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!rbClienteRegistrado.Checked)
            {
                return;
            }
            // Obtener el objeto Cliente directamente
            Cliente clienteSeleccionado = cbCliente.SelectedItem as Cliente;

            // Si el objeto no es nulo y el DNI es válido (> 0)
            if (clienteSeleccionado != null && clienteSeleccionado.Dni > 0)
            {
                int dniSeleccionado = clienteSeleccionado.Dni;

                // Buscar todos los detalles usando el DNI
                Cliente detallesCompletos = Cliente.BuscarDetallesPorDni(dniSeleccionado);

                if (detallesCompletos != null)
                {
                    // Llenar los TextBoxes del formulario
                    tbNombreCliente.Text = detallesCompletos.Nombre;
                    tbApellidoCliente.Text = detallesCompletos.Apellido;
                    tbClienteGmail.Text = detallesCompletos.Email;
                    tbTelefono.Text = detallesCompletos.Telefono;
                    tbSexo.Text = detallesCompletos.Genero; // Asumo tbSexo corresponde a Genero
                }
            }
            else
            {
                // Limpiar todos los campos si se selecciona la opción "Cliente General" (DNI=0) o no hay selección.
                LimpiarCamposCliente();
            }
        }

        private void LimpiarCamposCliente()
        {
            tbNombreCliente.Text = string.Empty;
            tbApellidoCliente.Text = string.Empty;
            tbClienteGmail.Text = string.Empty;
            tbTelefono.Text = string.Empty;
            tbSexo.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SesionUsuario.LimpiarSesion();

            // Oculta el formulario actual
            this.Hide();

            // Crea una nueva instancia del formulario de Login y la muestra
            Login loginForm = new Login();
            loginForm.Show();
        }


        private void gbCliente_Enter(object sender, EventArgs e)
        {

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

        // Método para validar el formato del correo
        private void tClienteGmail_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (!string.IsNullOrEmpty(textBox.Text))
                {
                    // Verifica si el texto contiene '@' y '.com'
                    if (!textBox.Text.Contains("@") || !textBox.Text.Contains(".com"))
                    {
                        // Puedes mostrar una advertencia visual o simplemente no permitir el siguiente paso
                        // Por ahora, no haremos nada para no interrumpir la escritura.
                    }
                }
            }
        }

        // ======== MÉTODO REUTILIZABLE: SOLO NÚMEROS ========
        /// <summary>
        /// Hace que el TextBox acepte únicamente dígitos (tecleo y pegado).
        /// </summary>
        private void AplicarSoloNumeros(TextBox tb)
        {
            // KeyPress: bloquea cualquier char no numérico
            tb.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };

            // TextChanged: limpia si pegaron contenido no numérico
            tb.TextChanged += (s, e) =>
            {
                var t = (TextBox)s;
                int sel = t.SelectionStart;
                string solo = new string(t.Text.Where(char.IsDigit).ToArray());
                if (solo != t.Text)
                {
                    t.Text = solo;
                    t.SelectionStart = Math.Min(sel, t.Text.Length);
                }
            };
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Vendedor_Load(object sender, EventArgs e)
        {
            CargarProductosEnComboBox();
            ConfigurarDataGridView();
            CalcularTotalGeneral();
            rbClienteGeneral.Checked = true;
            AlternarControlesCliente();
        }

        private void CalcularTotalGeneral()
        {
            decimal totalGeneral = 0m; // Inicializar en 0 (la 'm' indica decimal)

            // Iterar sobre todas las filas del DataGridView
            foreach (DataGridViewRow row in dgvListaDeCompra.Rows)
            {
                // Asegurarse de que la fila no sea la de "nueva fila" y que el valor exista
                if (!row.IsNewRow && row.Cells["Total"].Value != null)
                {
                    // Intentar convertir el valor de la celda a decimal y sumarlo
                    if (decimal.TryParse(row.Cells["Total"].Value.ToString(), out decimal totalFila))
                    {
                        totalGeneral += totalFila;
                    }
                }
            }

            // Mostrar el total general formateado como moneda en el Label
            // Asumo que lCantidad es el Label que muestra el total a pagar
            lCantidad.Text = totalGeneral.ToString("C2"); // "C2" da formato de moneda local (ej: $0.00)
        }

        private void ConfigurarDataGridView()
        {
            dgvListaDeCompra.Columns.Clear();
            dgvListaDeCompra.AutoGenerateColumns = false; // Necesario para la columna Button

            // 1. Nombre
            dgvListaDeCompra.Columns.Add("Nombre", "Nombre");

            // 2. Precio Unitario (Formato de moneda)
            DataGridViewTextBoxColumn colPrecio = new DataGridViewTextBoxColumn();
            colPrecio.Name = "PrecioUnitario";
            colPrecio.HeaderText = "Precio Unitario";
            colPrecio.DefaultCellStyle.Format = "C2"; // Formato de moneda (ej: $49.99)
            dgvListaDeCompra.Columns.Add(colPrecio);

            // 3. Cantidad
            dgvListaDeCompra.Columns.Add("Cantidad", "Cantidad");

            // 4. Total (Formato de moneda, de solo lectura)
            DataGridViewTextBoxColumn colTotal = new DataGridViewTextBoxColumn();
            colTotal.Name = "Total";
            colTotal.HeaderText = "Total";
            colTotal.DefaultCellStyle.Format = "C2";
            colTotal.ReadOnly = true;
            dgvListaDeCompra.Columns.Add(colTotal);

            // 5. Columna Botón Eliminar (AHORA EN EL ÍNDICE 4)
            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.HeaderText = "Acción";
            btnEliminar.Text = "Eliminar";
            btnEliminar.Name = "btnEliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
            dgvListaDeCompra.Columns.Add(btnEliminar); // Última columna visible

            // 6. Columna oculta para el ID del Producto (ÍNDICE 5 - CRUCIAL para evitar duplicados)
            dgvListaDeCompra.Columns.Add("IdProducto", "IdProducto");
            dgvListaDeCompra.Columns["IdProducto"].Visible = false;
        }

        private void bCargarProducto_Click(object sender, EventArgs e)
        {
            // 1. Obtener y validar la selección del producto
            Producto productoSeleccionado = cbCodigoProducto.SelectedItem as Producto;

            if (productoSeleccionado == null || productoSeleccionado.IdProducto == 0)
            {
                MessageBox.Show("Debe seleccionar un producto válido.", "Error de Selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Obtener y validar la cantidad deseada
            int cantidadDeseada;
            if (!int.TryParse(tbCantidad.Text, out cantidadDeseada) || cantidadDeseada <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida (número entero mayor que cero).", "Error de Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Obtener los detalles completos del producto (para Stock y Precio)
            Producto detalles = Producto.BuscarDetallesPorId(productoSeleccionado.IdProducto);

            if (detalles == null)
            {
                MessageBox.Show("No se encontraron detalles del producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Validación de Stock
            if (cantidadDeseada > detalles.CantidadStock)
            {
                MessageBox.Show($"Stock insuficiente. Stock actual: {detalles.CantidadStock}.", "Sin Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 5. Validación de Producto Duplicado en la Lista
            int idProductoNuevo = detalles.IdProducto;

            foreach (DataGridViewRow row in dgvListaDeCompra.Rows)
            {
                // Se itera para verificar si el IdProducto (columna oculta) ya existe.
                if (!row.IsNewRow && row.Cells["IdProducto"].Value != null && Convert.ToInt32(row.Cells["IdProducto"].Value) == idProductoNuevo)
                {
                    MessageBox.Show($"El producto '{detalles.Nombre}' ya se encuentra en la lista. Por favor, elimínelo y agréguelo de nuevo con la cantidad correcta.",
                                    "Producto Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Detiene la adición si el producto ya existe
                }
            }

            // 6. Cálculo del Total
            decimal precioUnitario = detalles.PrecioVenta;
            decimal total = precioUnitario * cantidadDeseada;

            // 7. Agregar la Fila al DataGridView
            // El orden de las columnas debe coincidir con ConfigurarDataGridView():
            // [Nombre, PrecioUnitario, Cantidad, Total, Acción(Eliminar), IdProducto(Oculta)]
            dgvListaDeCompra.Rows.Add(
                detalles.Nombre,              // Columna 0: Nombre
                precioUnitario,               // Columna 1: Precio Unitario
                cantidadDeseada,              // Columna 2: Cantidad
                total,                        // Columna 3: Total
                "Eliminar",                   // Columna 4: Botón (Acción)
                detalles.IdProducto           // Columna 5: IdProducto (oculta)
            );

            // 8. Recalcular el total general y actualizar el Label lCantidad
            CalcularTotalGeneral();

            // 9. Limpiar campos después de agregar
            tbCantidad.Text = "1";
            tbNombreProducto.Text = string.Empty;
            cbCodigoProducto.SelectedIndex = 0; // Vuelve a la opción "-- Seleccione un Producto --"
        }

        // Debes crear este método y asociarlo al evento CellContentClick del dgvListaDeCompra

        private void dgvListaDeCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que se haya hecho clic en la columna del botón "Eliminar"
            if (dgvListaDeCompra.Columns[e.ColumnIndex].Name == "btnEliminar" && e.RowIndex >= 0)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este producto de la lista?",
                                                      "Confirmar Eliminación",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Eliminar la fila
                    dgvListaDeCompra.Rows.RemoveAt(e.RowIndex);

                    // =========================================================
                    // NUEVO PASO: Recalcular el total general después de eliminar
                    // =========================================================
                    CalcularTotalGeneral();
                }
            }
        }

        private void CargarProductosEnComboBox()
        {
            // Llamada directa al método estático de la clase Producto
            List<Producto> productos = Producto.ObtenerTodosLosProductos();

            cbCodigoProducto.DataSource = productos;

            // Este define el valor interno que se usará (el ID)
            cbCodigoProducto.ValueMember = "IdProducto";

            // ¡¡¡CAMBIO CLAVE AQUÍ!!!
            // Este define qué propiedad del objeto Producto se mostrará en la lista.
            cbCodigoProducto.DisplayMember = "IdProducto";

            cbCodigoProducto.SelectedIndex = 0;
        }

        private void cbCodigoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 1. Obtener el objeto Producto directamente desde el ComboBox.
            Producto productoSeleccionado = cbCodigoProducto.SelectedItem as Producto;

            // 2. Verificar que la selección es válida (no es null y no es el ID 0).
            if (productoSeleccionado != null && productoSeleccionado.IdProducto > 0)
            {
                int idSeleccionado = productoSeleccionado.IdProducto;

                // 3. Llamar al método estático para obtener todos los detalles del producto
                // (Nombre, PrecioVenta, CantidadStock, etc.)
                Producto detallesCompletos = Producto.BuscarDetallesPorId(idSeleccionado);

                if (detallesCompletos != null)
                {
                    // 4. Mostrar el NOMBRE del producto en el TextBox (tbNombreProducto)
                    tbNombreProducto.Text = detallesCompletos.Nombre;

                    // 5. Llenar otros TextBoxes con los detalles
                    // Aquí puedes rellenar la Cantidad, el Precio de Venta, etc.
                    // Ejemplo:
                    // txtPrecioVenta.Text = detallesCompletos.PrecioVenta.ToString("N2");
                    // txtStock.Text = detallesCompletos.CantidadStock.ToString();
                }
            }
            else
            {
                // 6. Limpiar el TextBox y otros campos si se selecciona la opción inicial (ID=0)
                tbNombreProducto.Text = string.Empty;
                // txtPrecioVenta.Text = string.Empty;
                // txtStock.Text = string.Empty;
            }
        }

        // **Función de Búsqueda de Detalles por ID (necesaria para obtener Precio/Stock/etc.)**
        public Producto BuscarDetallesProductoPorId(int idProducto)
        {
            // Aquí repetirías una lógica similar a ObtenerTodosLosProductos,
            // pero con un WHERE id_producto = @idProducto y seleccionando *TODOS* los campos
            // (Nombre, Precio, Stock, etc.) en lugar de solo id_producto y Nombre.
            // Deberías completar la clase Producto con Precio y Stock para que funcione.

            // Por simplicidad, retornamos el objeto del ComboBox:
            return cbCodigoProducto.SelectedItem as Producto;
        }

        private void bCobrar_Click(object sender, EventArgs e)
        {
            // ... (Validaciones de Método de Pago, Total y Monto Pagado, Mismos que antes) ...

            if (!cbEfectivo.Checked && !cbCredito.Checked)
            {
                MessageBox.Show("Debe seleccionar al menos un método de pago (Efectivo o Crédito).", "Método de Pago Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal totalAPagar;
            if (!decimal.TryParse(lCantidad.Text, System.Globalization.NumberStyles.Currency, System.Globalization.CultureInfo.CurrentCulture, out totalAPagar))
            {
                MessageBox.Show("Error al leer el total de la compra.", "Error de Cálculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (totalAPagar <= 0)
            {
                MessageBox.Show("La lista de compra está vacía. No hay productos que cobrar.", "No hay productos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal montoPagado;
            // Usar InvariantCulture y reemplazar ',' por '.' para parsear el monto pagado de forma segura
            if (string.IsNullOrWhiteSpace(tbMontoPagado.Text) || !decimal.TryParse(tbMontoPagado.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out montoPagado))
            {
                MessageBox.Show("Por favor, ingrese un monto válido en el campo 'Ingresar Monto'.", "Monto Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (montoPagado < totalAPagar)
            {
                if (cbEfectivo.Checked && !cbCredito.Checked)
                {
                    MessageBox.Show($"El monto ingresado ({montoPagado:C2}) es menor al total a pagar ({totalAPagar:C2}).", "Monto Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            decimal cambio = montoPagado - totalAPagar;

            // =========================================================
            // 7. PREPARAR DATOS DE LA VENTA Y DETALLES
            // =========================================================

            // 7.1. Obtener ID del Vendedor (Usuario conectado)
            int idVendedor = 0;
            try
            {
                idVendedor = SesionUsuario.IdUsuario;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el ID del Vendedor. La sesión podría no estar inicializada correctamente: {ex.Message}",
                                "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (idVendedor <= 0)
            {
                MessageBox.Show("Error: La sesión del Vendedor no contiene un ID de usuario válido (ID <= 0). Cierre y vuelva a iniciar sesión.",
                                "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // 7.2. Determinar ID del Cliente
            int? idCliente = null;
            if (rbClienteRegistrado.Checked)
            {
                // Asegúrate de que la clase Cliente está disponible via using PuntoDeVentaGameBox.Clases;
                Cliente clienteSeleccionado = cbCliente.SelectedItem as Cliente;
                if (clienteSeleccionado != null && clienteSeleccionado.IdCliente > 0)
                {
                    idCliente = clienteSeleccionado.IdCliente;
                }
            }

            // 7.3. Determinar Método de Pago
            string metodoPago = "";
            if (cbEfectivo.Checked) metodoPago += "Efectivo";
            if (cbCredito.Checked)
            {
                if (!string.IsNullOrEmpty(metodoPago)) metodoPago += ", ";
                metodoPago += "Crédito";
            }

            // 7.4. Recolectar Detalles del DataGridView (CON PARSEO ROBUSTO)
            List<ItemDetalle> detallesVenta = new List<ItemDetalle>();

            foreach (DataGridViewRow row in dgvListaDeCompra.Rows)
            {
                if (row.IsNewRow) continue;

                int idProducto;
                int cantidad;
                decimal precioTotalLinea;

                // --- VALIDACIÓN Y PARSEO ROBUSTO PARA IdProducto ---
                var idProductoValue = row.Cells["IdProducto"].Value;
                if (idProductoValue == null || !int.TryParse(idProductoValue.ToString(), out idProducto))
                {
                    MessageBox.Show("Error de datos: El ID del producto en una fila es inválido o no existe.", "Error en DataGridView", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // --- VALIDACIÓN Y PARSEO ROBUSTO PARA Cantidad ---
                // *** CORRECCIÓN FINAL: La cantidad se extrae de la columna "Cantidad" ***
                var cantidadValue = row.Cells["Cantidad"].Value;
                if (cantidadValue == null || !int.TryParse(cantidadValue.ToString(), out cantidad))
                {
                    MessageBox.Show($"Error de datos: La cantidad para el producto ID {idProducto} es inválida o no existe.", "Error en DataGridView", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // --- VALIDACIÓN Y PARSEO ROBUSTO PARA Subtotal de la Línea ---
                // *** CORRECCIÓN FINAL: El subtotal de la línea (Total) se extrae de la columna "CantidadTotal" ***
                var totalValue = row.Cells["Total"].Value;
                if (totalValue == null || !decimal.TryParse(totalValue.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out precioTotalLinea))
                {
                    MessageBox.Show($"Error de datos: El subtotal para el producto ID {idProducto} es inválido o no existe.", "Error en DataGridView", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // --- VALIDACIÓN CRÍTICA: EVITAR DIVISIÓN POR CERO EN Facturacion.cs ---
                if (cantidad <= 0)
                {
                    MessageBox.Show($"Error de datos: La cantidad para el producto ID {idProducto} debe ser mayor a cero.", "Error en DataGridView", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                detallesVenta.Add(new ItemDetalle
                {
                    IdProducto = idProducto,
                    Cantidad = cantidad,
                    PrecioTotalLinea = precioTotalLinea // Esto es el subtotal que se usará para calcular el precio unitario en Facturacion.cs
                });
            }

            // Validar que se haya podido extraer al menos un detalle
            if (detallesVenta.Count == 0)
            {
                MessageBox.Show("No se pudo procesar ningún detalle de la lista de compra. Revise los datos de la tabla.", "Error de Procesamiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // =========================================================
            // 8. REGISTRAR EN BASE DE DATOS
            // =========================================================
            bool exito = Facturacion.RegistrarVentaCompleta(
                idVendedor,
                idCliente,
                totalAPagar,
                montoPagado,
                metodoPago,
                detallesVenta
            );

            // =========================================================
            // 9. FINALIZAR TRANSACCIÓN Y UI
            // =========================================================
            if (exito)
            {
                // Mostrar el cambio (Formateado como moneda)
                tbCambio.Text = cambio.ToString("C2");


                MessageBox.Show("¡Venta registrada exitosamente!", "Cobro Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Si no fue exitoso, el mensaje de error ya se mostró dentro de Facturacion.RegistrarVentaCompleta

        }

        private void bDescargarFactura_Click(object sender, EventArgs e)
        {
            DescargarFactura descargarFactura = new DescargarFactura();
            descargarFactura.ShowDialog();
            /*try
            {
                using (SqlConnection connection = new SqlConnection(conecctionString))
                {
                    connection.Open();

                    // 1. Obtener la última factura
                    string queryFactura = @"
                SELECT TOP 1 * 
                FROM factura 
                ORDER BY fecha_compra DESC";

                    SqlCommand cmdFactura = new SqlCommand(queryFactura, connection);
                    SqlDataReader readerFactura = cmdFactura.ExecuteReader();

                    if (!readerFactura.Read())
                    {
                        MessageBox.Show("No se encontró ninguna factura registrada.", "Sin Facturas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    int idFactura = Convert.ToInt32(readerFactura["id_factura"]);
                    DateTime fechaCompra = Convert.ToDateTime(readerFactura["fecha_compra"]);
                    decimal total = Convert.ToDecimal(readerFactura["total"]);
                    decimal montoPagado = Convert.ToDecimal(readerFactura["monto_pagado"]);
                    string metodoPago = readerFactura["metodo_pago"].ToString();
                    object idClienteObj = readerFactura["id_cliente"];

                    readerFactura.Close();

                    // 2. Obtener detalles de la factura
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

                    // 3. Obtener datos del cliente (si existe)
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

                    // 4. Crear el PDF
                    string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string nombreArchivo = $"Factura_{idFactura}.pdf";
                    string rutaCompleta = Path.Combine(rutaEscritorio, nombreArchivo);

                    Document doc = new Document();
                    PdfWriter.GetInstance(doc, new FileStream(rutaCompleta, FileMode.Create));
                    doc.Open();

                    // Encabezado
                    doc.Add(new Paragraph("Factura GameBox", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18)));
                    doc.Add(new Paragraph($"Fecha: {fechaCompra.ToShortDateString()}"));
                    doc.Add(new Paragraph($"Cliente: {nombreCliente}"));
                    doc.Add(new Paragraph($"Método de Pago: {metodoPago}"));
                    doc.Add(new Paragraph(" "));

                    // Detalles
                    doc.Add(new Paragraph("Detalles de la compra:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14)));
                    foreach (var linea in lineasDetalle)
                    {
                        doc.Add(new Paragraph(linea));
                    }

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
            }*/
        }

    }
}

