using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace PuntoDeVentaGameBox.Gerente
{
    public partial class AgregarProducto : Form
    {
        // usa cadena fija sin appconfig
        private readonly string _connString = "Server=localhost;Database=game_box;Trusted_Connection=True;TrustServerCertificate=True"; // cadena de conexion fija
        private readonly int? _idEditar; // guarda id si es modo edicion

        public AgregarProducto()
        {
            InitializeComponent();
            _idEditar = null; // modo alta
            BRegistrarProducto.Text = "Registrar Producto"; // texto de alta
            WireEventos(); // vincula eventos
            CargarCategorias(); // llena combo de generos
            CargarProveedores(); // llena combo de proveedores
            PrepararControles(); // estados iniciales de controles
        }

        public AgregarProducto(int idProducto)
        {
            InitializeComponent();
            _idEditar = idProducto; // modo edicion
            BRegistrarProducto.Text = "Guardar Cambios"; // texto de edicion
            WireEventos(); // vincula eventos
            CargarCategorias(); // llena combo de generos
            CargarProveedores(); // llena combo de proveedores
            PrepararControles(); // estados iniciales
            CargarProducto(idProducto); // carga datos del producto
        }

        private SqlConnection NuevaConexion() => new SqlConnection(_connString); // crea conexion sql

        private void WireEventos()
        {
            // limpia handlers viejos del disenador
            BRegistrarProducto.Click -= BAbrirImagen_Click;  // evita que registrar abra el explorador
            BRegistrarProducto.Click -= bBuscar_Click;       // desengancha handler viejo si estaba
            BAbrirImagen.Click -= bBuscar_Click;             // evita doble wiring en abrir imagen

            // engancha handlers correctos
            BAbrirImagen.Click -= BAbrirImagen_Click;   // evita doble suscripcion
            BAbrirImagen.Click += BAbrirImagen_Click;   // abre explorador para imagen

            BRegistrarProducto.Click -= BRegistrarProducto_Click; // evita doble suscripcion
            BRegistrarProducto.Click += BRegistrarProducto_Click; // guarda alta o edicion

            if (BSalir != null)
            {
                BSalir.Click -= BSalir_Click; // evita doble suscripcion
                BSalir.Click += BSalir_Click; // cierra solo este formulario
            }

            // restricciones de entrada en precio y cantidad
            TBPrecioVentaProducto.KeyPress -= TBPrecioVentaProducto_KeyPressSoloNumeroDecimal; // evita doble wiring
            TBPrecioVentaProducto.KeyPress += TBPrecioVentaProducto_KeyPressSoloNumeroDecimal; // restringe a numero decimal

            TBCantidadProducto.KeyPress -= TBCantidadProducto_KeyPressSoloEntero; // evita doble wiring
            TBCantidadProducto.KeyPress += TBCantidadProducto_KeyPressSoloEntero; // restringe a entero
        }

        private void PrepararControles()
        {
            // configura controles base
            if (DTPFechaAlta != null) DTPFechaAlta.Value = DateTime.Today; // setea fecha por defecto

            if (CBGeneroProducto != null)
            {
                CBGeneroProducto.DropDownStyle = ComboBoxStyle.DropDownList; // obliga a elegir de la lista
                CBGeneroProducto.MaxDropDownItems = 4; // muestra maximo 4 sin scroll
                CBGeneroProducto.SelectedIndex = -1; // sin seleccion
            }

            if (CBProveedorProducto != null)
            {
                CBProveedorProducto.DropDownStyle = ComboBoxStyle.DropDownList; // obliga a elegir de la lista
                CBProveedorProducto.MaxDropDownItems = 4; // muestra maximo 4 sin scroll
                CBProveedorProducto.SelectedIndex = -1; // sin seleccion
            }
        }

        private void CargarCategorias()
        {
            // carga generos desde la tabla categoria
            try
            {
                using (var cn = NuevaConexion())
                using (var da = new SqlDataAdapter("SELECT id_categoria, nombre FROM dbo.categoria ORDER BY nombre", cn))
                {
                    var dt = new DataTable(); // tabla en memoria
                    da.Fill(dt); // llena tabla
                    CBGeneroProducto.DisplayMember = "nombre"; // muestra nombre
                    CBGeneroProducto.ValueMember = "id_categoria"; // valor es id
                    CBGeneroProducto.DataSource = dt; // asigna datasource
                    CBGeneroProducto.SelectedIndex = -1; // sin seleccion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al cargar generos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // muestra error
            }
        }

        private void CargarProveedores()
        {
            // carga proveedores activos si existe la columna activo, sino carga todos
            try
            {
                using (var cn = NuevaConexion())
                using (var da = new SqlDataAdapter("SELECT id_proveedor, nombre FROM dbo.proveedor WHERE activo = 1 ORDER BY nombre", cn))
                {
                    var dt = new DataTable(); // tabla para proveedores
                    try
                    {
                        da.Fill(dt); // intenta con filtro activo
                    }
                    catch (SqlException)
                    {
                        da.SelectCommand.CommandText = "SELECT id_proveedor, nombre FROM dbo.proveedor ORDER BY nombre"; // fallback sin activo
                        dt.Clear(); // limpia
                        da.Fill(dt); // vuelve a llenar
                    }

                    CBProveedorProducto.DisplayMember = "nombre"; // muestra nombre
                    CBProveedorProducto.ValueMember = "id_proveedor"; // valor es id
                    CBProveedorProducto.DataSource = dt; // asigna datasource
                    CBProveedorProducto.SelectedIndex = -1; // arranca sin seleccion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al cargar proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // muestra error
            }
        }

        private void BAbrirImagen_Click(object sender, EventArgs e)
        {
            // abre explorador y previsualiza imagen
            using (var ofd = new OpenFileDialog
            {
                Filter = "Imagenes|*.jpg;*.jpeg;*.png;*.gif;*.bmp",
                Title = "Seleccionar imagen"
            })
            {
                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    TBDireccionImagen.Text = ofd.FileName; // setea ruta
                    PBImagenProducto.ImageLocation = ofd.FileName; // muestra imagen
                }
            }
        }

        private void CargarProducto(int id)
        {
            // carga datos del producto para edicion
            try
            {
                using (var cn = NuevaConexion()) // abre conexion
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT nombre, descripcion, precio_venta, cantidad_stock, url_imagen,
                               fecha_alta, id_proveedor, id_categoria
                        FROM dbo.producto
                        WHERE id_producto = @id"; // consulta por id
                    cmd.Parameters.AddWithValue("@id", id); // setea id
                    cn.Open(); // abre conexion
                    using (var rd = cmd.ExecuteReader()) // ejecuta reader
                    {
                        if (rd.Read())
                        {
                            TBNombreProducto.Text = rd["nombre"]?.ToString(); // llena nombre
                            TBDescripcionProducto.Text = rd["descripcion"]?.ToString(); // llena descripcion
                            TBPrecioVentaProducto.Text = Convert.ToDecimal(rd["precio_venta"]).ToString("0.##"); // llena precio
                            TBCantidadProducto.Text = rd["cantidad_stock"]?.ToString(); // llena stock
                            TBDireccionImagen.Text = rd["url_imagen"]?.ToString(); // llena ruta imagen

                            if (rd["fecha_alta"] != DBNull.Value)
                                DTPFechaAlta.Value = Convert.ToDateTime(rd["fecha_alta"]); // setea fecha alta
                            else
                                DTPFechaAlta.Value = DateTime.Today; // por defecto

                            if (rd["id_categoria"] != DBNull.Value)
                                CBGeneroProducto.SelectedValue = Convert.ToInt32(rd["id_categoria"]); // selecciona categoria
                            else
                                CBGeneroProducto.SelectedIndex = -1; // sin seleccion

                            if (rd["id_proveedor"] != DBNull.Value)
                                CBProveedorProducto.SelectedValue = Convert.ToInt32(rd["id_proveedor"]); // selecciona proveedor
                            else
                                CBProveedorProducto.SelectedIndex = -1; // sin seleccion

                            var ruta = TBDireccionImagen.Text; // toma ruta
                            PBImagenProducto.ImageLocation = File.Exists(ruta) ? ruta : null; // muestra imagen si existe
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al cargar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // muestra error
            }
        }

        private void BRegistrarProducto_Click(object sender, EventArgs e)
        {
            // decide entre alta o edicion segun _idEditar
            if (!ValidarFormulario(out var precio, out var stock, out var prov, out var cat)) return; // valida formulario

            if (_idEditar == null)
                InsertarProducto(precio, stock, prov, cat); // alta
            else
                ActualizarProducto(_idEditar.Value, precio, stock, prov, cat); // edicion
        }

        // ==================== validaciones y restricciones ====================

        private void TBCantidadProducto_KeyPressSoloEntero(object sender, KeyPressEventArgs e)
        {
            // permite solo numeros y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true; // bloquea caracter no numerico
        }

        private void TBPrecioVentaProducto_KeyPressSoloNumeroDecimal(object sender, KeyPressEventArgs e)
        {
            // permite digitos, coma, punto y teclas de control
            if (char.IsControl(e.KeyChar)) return; // deja backspace etc
            if (char.IsDigit(e.KeyChar)) return; // deja digitos

            // permite un unico separador decimal . o ,
            if ((e.KeyChar == ',' || e.KeyChar == '.') &&
                (sender as TextBox).Text.IndexOfAny(new[] { ',', '.' }) == -1)
                return; // permite primer separador

            e.Handled = true; // bloquea lo demas
        }

        private bool TryParsePrecio(string txt, out decimal value)
        {
            // intenta parsear precio respetando coma o punto
            txt = (txt ?? "").Trim();
            // primero intenta con cultura actual
            if (decimal.TryParse(txt, NumberStyles.Number, CultureInfo.CurrentCulture, out value)) return true;
            // reemplaza punto por coma y vuelve a intentar
            var alt = txt.Replace(".", ",");
            if (decimal.TryParse(alt, NumberStyles.Number, new CultureInfo("es-AR"), out value)) return true;
            // intenta invariante por si acaso
            return decimal.TryParse(txt, NumberStyles.Number, CultureInfo.InvariantCulture, out value);
        }

        private bool ValidarFormulario(out decimal precio, out int stock, out int? prov, out int? cat)
        {
            // valida datos obligatorios y parsea numericos
            precio = 0m; stock = 0; prov = null; cat = null; // inicializa

            if (string.IsNullOrWhiteSpace(TBNombreProducto.Text))
            {
                MessageBox.Show("nombre es obligatorio", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning); // valida nombre
                return false;
            }

            // usa parser tolerante a coma o punto y valida >= 0
            if (!TryParsePrecio(TBPrecioVentaProducto.Text, out precio) || precio < 0)
            {
                MessageBox.Show("precio invalido", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning); // valida precio
                return false;
            }

            // cantidad entero y >= 0
            if (!int.TryParse(TBCantidadProducto.Text, out stock) || stock < 0)
            {
                MessageBox.Show("stock debe ser entero y mayor o igual a 0", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning); // valida stock
                return false;
            }

            // toma proveedor del combo si esta seleccionado
            if (CBProveedorProducto.SelectedValue != null && int.TryParse(CBProveedorProducto.SelectedValue.ToString(), out var provId))
                prov = provId; // setea id de proveedor

            // toma categoria del combo si esta seleccionada
            if (CBGeneroProducto.SelectedValue != null && int.TryParse(CBGeneroProducto.SelectedValue.ToString(), out var catId))
                cat = catId; // setea id de categoria

            return true; // validaciones correctas
        }

        private void InsertarProducto(decimal precio, int stock, int? prov, int? cat)
        {
            // inserta nuevo producto
            try
            {
                using (var cn = NuevaConexion()) // abre conexion
                using (var cmd = cn.CreateCommand())
                {
                    cn.Open(); // abre conexion

                    cmd.CommandText = @"
                        INSERT INTO dbo.producto
                            (nombre, descripcion, precio_venta, cantidad_stock, url_imagen, fecha_alta, fecha_edicion, id_proveedor, id_categoria, activo)
                        VALUES
                            (@nombre, @descripcion, @precio, @stock, @img, @falta, NULL, @prov, @cat, 1)"; // insert parametrizado

                    cmd.Parameters.AddWithValue("@nombre", TBNombreProducto.Text.Trim()); // setea nombre
                    cmd.Parameters.AddWithValue("@descripcion", (object)(TBDescripcionProducto.Text ?? "").Trim()); // setea descripcion
                    cmd.Parameters.AddWithValue("@precio", precio); // setea precio
                    cmd.Parameters.AddWithValue("@stock", stock); // setea stock
                    cmd.Parameters.AddWithValue("@img", string.IsNullOrWhiteSpace(TBDireccionImagen.Text) ? (object)DBNull.Value : TBDireccionImagen.Text.Trim()); // setea imagen

                    var pFecha = cmd.Parameters.Add("@falta", SqlDbType.Date); // crea parametro date
                    pFecha.Value = DTPFechaAlta.Value.Date; // setea solo la fecha

                    cmd.Parameters.AddWithValue("@prov", (object)prov ?? DBNull.Value); // setea proveedor seleccionado
                    cmd.Parameters.AddWithValue("@cat", (object)cat ?? DBNull.Value); // setea categoria

                    cmd.ExecuteNonQuery(); // ejecuta insert
                }

                MessageBox.Show("producto creado", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information); // muestra exito
                this.DialogResult = DialogResult.OK; // devuelve ok al inventario
                this.Close(); // cierra formulario
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al crear producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // muestra error
            }
        }

        private void ActualizarProducto(int id, decimal precio, int stock, int? prov, int? cat)
        {
            // actualiza un producto existente
            try
            {
                using (var cn = NuevaConexion()) // abre conexion
                using (var cmd = cn.CreateCommand())
                {
                    cn.Open(); // abre conexion

                    cmd.CommandText = @"
                        UPDATE dbo.producto
                        SET nombre = @nombre,
                            descripcion = @descripcion,
                            precio_venta = @precio,
                            cantidad_stock = @stock,
                            url_imagen = @img,
                            fecha_edicion = GETDATE(),
                            id_proveedor = @prov,
                            id_categoria = @cat
                        WHERE id_producto = @id"; // update parametrizado

                    cmd.Parameters.AddWithValue("@nombre", TBNombreProducto.Text.Trim()); // setea nombre
                    cmd.Parameters.AddWithValue("@descripcion", (object)(TBDescripcionProducto.Text ?? "").Trim()); // setea descripcion
                    cmd.Parameters.AddWithValue("@precio", precio); // setea precio
                    cmd.Parameters.AddWithValue("@stock", stock); // setea stock
                    cmd.Parameters.AddWithValue("@img", string.IsNullOrWhiteSpace(TBDireccionImagen.Text) ? (object)DBNull.Value : TBDireccionImagen.Text.Trim()); // setea imagen
                    cmd.Parameters.AddWithValue("@prov", (object)prov ?? DBNull.Value); // setea proveedor seleccionado
                    cmd.Parameters.AddWithValue("@cat", (object)cat ?? DBNull.Value); // setea categoria
                    cmd.Parameters.AddWithValue("@id", id); // setea id

                    cmd.ExecuteNonQuery(); // ejecuta update
                }

                MessageBox.Show("producto actualizado", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information); // muestra exito
                this.DialogResult = DialogResult.OK; // devuelve ok al inventario
                this.Close(); // cierra formulario
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al actualizar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // muestra error
            }
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            // cierra solo este formulario
            this.Close(); // cierra la ventana actual
        }

        // ====== stubs para eventos del disenador que pueden seguir conectados ======

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void PBImagenProducto_Click(object sender, EventArgs e) { }
        private void TBDireccionImagen_TextChanged(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void PDatosProductos_Paint(object sender, PaintEventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void LFechaAlta_Click(object sender, EventArgs e) { }
        private void LDescripcion_Click(object sender, EventArgs e) { }
        private void TBNombreProducto_TextChanged(object sender, EventArgs e) { }
        private void TBPrecioVentaProducto_TextChanged(object sender, EventArgs e) { }
        private void bBuscar_Click(object sender, EventArgs e) { BAbrirImagen_Click(sender, e); }
        private void AgregarProducto_Load(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // evento viejo del disenador sin uso
        }

    }
}
