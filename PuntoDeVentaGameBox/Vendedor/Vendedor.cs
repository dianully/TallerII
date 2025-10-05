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

namespace PuntoDeVentaGameBox.Vendedor
{
    public partial class Vendedor : Form
    {

        string conecctionString = "server=localhost;Database=game_box;Trusted_Connection=True";
        // Constructor
        public Vendedor()
        {
            InitializeComponent();
            // Asigna el nombre y apellido desde la clase SesionUsuario al label
            lVendedor.Text = $"{SesionUsuario.Nombre} {SesionUsuario.Apellido}";

            // Aplica la validación para que solo acepte números en el DNI del cliente
            //AplicarSoloNumeros(TBDniCliente);

            // Aplica la validación para que el correo contenga '@' y '.com'
            tbClienteGmail.TextChanged += tClienteGmail_TextChanged;

            // La siguiente línea fue eliminada para evitar que el evento se registre dos veces
            // this.lVendedor.Click += new System.EventHandler(this.lVendedor_Click_1);


            // >>> CAMBIO CLAVE AQUÍ: AUMENTAR EL TAMAÑO DE LA FUENTE <<<
            tbMontoPagado.Font = new Font(tbMontoPagado.Font.FontFamily, 14, FontStyle.Regular);
            // Puedes probar con 16 si 14 no es suficiente.

            // Configuración inicial del Placeholder
            tbMontoPagado.Text = "Ingresar Monto";
            tbMontoPagado.ForeColor = Color.Gray;

            // Asignar los eventos
            tbMontoPagado.Enter += tbMontoPagado_Enter;
            tbMontoPagado.Leave += tbMontoPagado_Leave;

            ConfigurarPlaceholder(tbCambio, "Cambio");
            tbCambio.ForeColor = Color.Gray;
            tbCambio.Font = new Font(tbCambio.Font.FontFamily, 14, FontStyle.Regular); // Mantén el tamaño de fuente aquí


            // Aplicar a otros TextBoxes con diferentes textos
            ConfigurarPlaceholder(tbNombreCliente, "Nombre");
            ConfigurarPlaceholder(tbApellidoCliente, "Apellido");
            ConfigurarPlaceholder(tbClienteGmail, "Correo");
            ConfigurarPlaceholder(tbSexo, "Sexo");
            ConfigurarPlaceholder(tbTelefono, "Telefono");


        }

        private void tbMontoPagado_Enter(object sender, EventArgs e)
        {
            if (tbMontoPagado.Text == "Ingresar Monto")
            {
                tbMontoPagado.Text = "";
                tbMontoPagado.ForeColor = Color.Black; // Cambia el color a uno normal

                // Opcional: Si quieres que el texto escrito sea negrita
                // tbMontoPagado.Font = new Font(tbMontoPagado.Font.FontFamily, 14, FontStyle.Bold); 
            }
        }

        private void tbMontoPagado_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbMontoPagado.Text))
            {
                tbMontoPagado.Text = "Ingresar Monto";
                tbMontoPagado.ForeColor = Color.Gray; // Restaura el color del placeholder

                // Asegúrate de que el estilo de fuente se mantenga si lo cambiaste en Enter
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
    }
 }

