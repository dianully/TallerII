using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace PuntoDeVentaGameBox.Gerente
{
    public partial class EditarProducto : Form
    {
        // usa cadena fija sin appconfig
        private readonly string _connString = "Server=localhost;Database=game_box;Trusted_Connection=True;TrustServerCertificate=True"; // cadena de conexion fija

        private readonly int? _idProducto; // id del producto a editar o null si no lo pasaron

        public EditarProducto()
        {
            InitializeComponent(); // inicializa controles
            _idProducto = null; // sin id explicito
            WireEventos(); // conecta eventos
            PrepararControles(); // configura combos y dp
            CargarCategorias(); // carga generos
            CargarProveedores(); // carga proveedores
            // si no te pasan id solo se muestra la vista, pero no carga datos
        }

        public EditarProducto(int idProducto)
        {
            InitializeComponent(); // inicializa controles
            _idProducto = idProducto; // guarda id
            WireEventos(); // conecta eventos
            PrepararControles(); // configura combos y dp
            CargarCategorias(); // carga generos
            CargarProveedores(); // carga proveedores
            CargarProducto(idProducto); // carga datos del producto
        }

        // ================= helpers base =================

        private SqlConnection NuevaConexion() => new SqlConnection(_connString); // crea conexion sql

        private void WireEventos()
        {
            // conecta eventos de botones y entradas
            if (BSalir != null)
            {
                BSalir.Click -= BSalir_Click; // evita doble wiring
                BSalir.Click += BSalir_Click; // cierra el formulario
            }

            if (BGuardarCambios != null)
            {
                BGuardarCambios.Click -= BGuardarCambios_Click; // evita doble wiring
                BGuardarCambios.Click += BGuardarCambios_Click; // guarda cambios
            }

            if (BAbrirImagen != null)
            {
                BAbrirImagen.Click -= BAbrirImagen_Click; // evita doble wiring
                BAbrirImagen.Click += BAbrirImagen_Click; // abre explorador de archivos
            }

            if (TBDireccionImagen != null)
            {
                TBDireccionImagen.TextChanged -= TBDireccionImagen_TextChanged_Preview; // evita doble wiring
                TBDireccionImagen.TextChanged += TBDireccionImagen_TextChanged_Preview; // refresca preview
            }

            if (TBPrecioVentaProducto != null)
            {
                TBPrecioVentaProducto.KeyPress -= TBPrecioVentaProducto_KeyPressSoloNumeroDecimal; // evita doble wiring
                TBPrecioVentaProducto.KeyPress += TBPrecioVentaProducto_KeyPressSoloNumeroDecimal; // restringe entrada
            }

            if (TBCantidadProducto != null)
            {
                TBCantidadProducto.KeyPress -= TBCantidadProducto_KeyPressSoloEntero; // evita doble wiring
                TBCantidadProducto.KeyPress += TBCantidadProducto_KeyPressSoloEntero; // restringe entrada
            }
        }

        private void PrepararControles()
        {
            // configura combos y datepickers
            if (CBGeneroProducto != null)
            {
                CBGeneroProducto.DropDownStyle = ComboBoxStyle.DropDownList; // fuerza seleccion
                CBGeneroProducto.MaxDropDownItems = 4; // maximo visibles
                CBGeneroProducto.SelectedIndex = -1; // sin seleccion
            }

            if (CBProveedorProducto != null)
            {
                CBProveedorProducto.DropDownStyle = ComboBoxStyle.DropDownList; // fuerza seleccion
                CBProveedorProducto.MaxDropDownItems = 4; // maximo visibles
                CBProveedorProducto.SelectedIndex = -1; // sin seleccion
            }

            // CAMBIO: se elimina DTPFechaAlta; ahora se usa TBFechaAlta (no seteamos nada aquí)
            // if (DTPFechaAlta != null) DTPFechaAlta.Value = DateTime.Today;

            if (DTPFechaEdicionProducto != null) DTPFechaEdicionProducto.Value = DateTime.Today; // solo informativo
        }

        // ============== carga de listas ==============

        private void CargarCategorias()
        {
            // carga categorias desde la bd
            try
            {
                using (var cn = NuevaConexion())
                using (var da = new SqlDataAdapter("SELECT id_categoria, nombre FROM dbo.categoria ORDER BY nombre", cn))
                {
                    var dt = new DataTable(); // tabla en memoria
                    da.Fill(dt); // llena tabla
                    CBGeneroProducto.DisplayMember = "nombre"; // muestra nombre
                    CBGeneroProducto.ValueMember = "id_categoria"; // valor id
                    CBGeneroProducto.DataSource = dt; // asigna data
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
            // carga proveedores activos si existe la columna activo, sino todos
            try
            {
                using (var cn = NuevaConexion())
                using (var da = new SqlDataAdapter("SELECT id_proveedor, nombre FROM dbo.proveedor WHERE activo = 1 ORDER BY nombre", cn))
                {
                    var dt = new DataTable(); // tabla en memoria
                    try { da.Fill(dt); }
                    catch (SqlException)
                    {
                        da.SelectCommand.CommandText = "SELECT id_proveedor, nombre FROM dbo.proveedor ORDER BY nombre"; // fallback sin activo
                        dt.Clear();
                        da.Fill(dt);
                    }
                    CBProveedorProducto.DisplayMember = "nombre"; // muestra nombre
                    CBProveedorProducto.ValueMember = "id_proveedor"; // valor id
                    CBProveedorProducto.DataSource = dt; // asigna data
                    CBProveedorProducto.SelectedIndex = -1; // sin seleccion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al cargar proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // muestra error
            }
        }

        // ============== carga de producto ==============

        private void CargarProducto(int id)
        {
            // trae producto de la bd y llena controles
            try
            {
                using (var cn = NuevaConexion())
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT p.nombre, p.descripcion, p.precio_venta, p.cantidad_stock,
                               p.url_imagen, p.fecha_alta, p.fecha_edicion,
                               p.id_proveedor, p.id_categoria
                        FROM dbo.producto p
                        WHERE p.id_producto = @id";
                    cmd.Parameters.AddWithValue("@id", id); // setea id
                    cn.Open(); // abre conexion

                    using (var rd = cmd.ExecuteReader())
                    {
                        if (!rd.Read())
                        {
                            MessageBox.Show("producto no encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information); // informa no encontrado
                            return;
                        }

                        TBNombreProducto.Text = rd["nombre"]?.ToString(); // llena nombre
                        TBDescripcionProducto.Text = rd["descripcion"]?.ToString(); // llena descripcion
                        TBPrecioVentaProducto.Text = Convert.ToDecimal(rd["precio_venta"]).ToString("0.##"); // llena precio
                        TBCantidadProducto.Text = rd["cantidad_stock"]?.ToString(); // llena stock
                        TBDireccionImagen.Text = rd["url_imagen"]?.ToString(); // llena ruta

                        // CAMBIO: fecha de alta ahora va al TextBox TBFechaAlta
                        TBFechaAlta.Text = (rd["fecha_alta"] == DBNull.Value)
                            ? ""
                            : Convert.ToDateTime(rd["fecha_alta"]).ToString("yyyy-MM-dd");

                        if (rd["fecha_edicion"] != DBNull.Value && DTPFechaEdicionProducto != null)
                            DTPFechaEdicionProducto.Value = Convert.ToDateTime(rd["fecha_edicion"]); // setea fecha edicion

                        if (rd["id_categoria"] != DBNull.Value)
                            CBGeneroProducto.SelectedValue = Convert.ToInt32(rd["id_categoria"]); // selecciona categoria
                        if (rd["id_proveedor"] != DBNull.Value)
                            CBProveedorProducto.SelectedValue = Convert.ToInt32(rd["id_proveedor"]); // selecciona proveedor

                        // muestra imagen si existe o deja vacio
                        var ruta = TBDireccionImagen.Text;
                        PBImagenProducto.ImageLocation = File.Exists(ruta) ? ruta : null; // renderiza imagen si el archivo existe
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al cargar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // muestra error
            }
        }

        // ============== validaciones y parseos ==============

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

        private bool ValidarFormulario(out decimal precio, out int stock, out int? idProv, out int? idCat, out DateTime fechaAlta)
        {
            // valida y convierte entradas
            precio = 0m; stock = 0; idProv = null; idCat = null; fechaAlta = DateTime.MinValue; // inicializa

            if (string.IsNullOrWhiteSpace(TBNombreProducto.Text))
            {
                MessageBox.Show("nombre es obligatorio", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning); // valida nombre
                return false;
            }

            if (!TryParsePrecio(TBPrecioVentaProducto.Text, out precio) || precio < 0)
            {
                MessageBox.Show("precio invalido", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning); // valida precio
                return false;
            }

            if (!int.TryParse(TBCantidadProducto.Text, out stock) || stock < 0)
            {
                MessageBox.Show("stock debe ser entero y mayor o igual a 0", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning); // valida stock
                return false;
            }

            if (!DateTime.TryParse(TBFechaAlta.Text?.Trim(), out fechaAlta))
            {
                MessageBox.Show("Fecha de alta inválida. Usar formato AAAA-MM-DD.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (CBProveedorProducto.SelectedValue != null &&
                int.TryParse(CBProveedorProducto.SelectedValue.ToString(), out var p))
                idProv = p; // toma id proveedor si hay

            if (CBGeneroProducto.SelectedValue != null &&
                int.TryParse(CBGeneroProducto.SelectedValue.ToString(), out var c))
                idCat = c; // toma id categoria si hay

            return true; // validaciones correctas
        }

        // ============== acciones de botones ==============

        private void BAbrirImagen_Click(object sender, EventArgs e)
        {
            // abre explorador para elegir imagen y previsualiza
            using (var ofd = new OpenFileDialog
            {
                Filter = "Imagenes|*.jpg;*.jpeg;*.png;*.gif;*.bmp",
                Title = "Seleccionar imagen"
            })
            {
                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    TBDireccionImagen.Text = ofd.FileName; // guarda ruta
                    PBImagenProducto.ImageLocation = ofd.FileName; // previsualiza
                }
            }
        }

        private void TBDireccionImagen_TextChanged_Preview(object sender, EventArgs e)
        {
            // actualiza preview cuando cambia la ruta a mano
            var ruta = TBDireccionImagen.Text?.Trim();
            PBImagenProducto.ImageLocation = File.Exists(ruta) ? ruta : null; // carga si existe
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            // cierra solo este formulario
            this.Close(); // cierra ventana
        }

        private void BGuardarCambios_Click(object sender, EventArgs e)
        {
            // guarda cambios en bd y devuelve ok al padre
            if (_idProducto == null)
            {
                MessageBox.Show("no se indico producto a editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); // sin id
                return;
            }

            if (!ValidarFormulario(out var precio, out var stock, out var idProv, out var idCat, out var fechaAlta)) return; // valida form

            try
            {
                using (var cn = NuevaConexion())
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
                            fecha_alta = @falta,
                            fecha_edicion = GETDATE(),
                            id_proveedor = @prov,
                            id_categoria = @cat
                        WHERE id_producto = @id"; // update parametrizado

                    cmd.Parameters.AddWithValue("@nombre", TBNombreProducto.Text.Trim()); // setea nombre
                    cmd.Parameters.AddWithValue("@descripcion", (object)(TBDescripcionProducto.Text ?? "").Trim()); // setea descripcion
                    cmd.Parameters.AddWithValue("@precio", precio); // setea precio
                    cmd.Parameters.AddWithValue("@stock", stock); // setea stock
                    cmd.Parameters.AddWithValue("@img", string.IsNullOrWhiteSpace(TBDireccionImagen.Text) ? (object)DBNull.Value : TBDireccionImagen.Text.Trim()); // setea imagen

                    // CAMBIO: tomamos fecha de alta desde TBFechaAlta
                    var pFecha = cmd.Parameters.Add("@falta", SqlDbType.Date); // parametro date
                    pFecha.Value = fechaAlta.Date;

                    cmd.Parameters.AddWithValue("@prov", (object)idProv ?? DBNull.Value); // setea proveedor
                    cmd.Parameters.AddWithValue("@cat", (object)idCat ?? DBNull.Value); // setea categoria
                    cmd.Parameters.AddWithValue("@id", _idProducto.Value); // setea id

                    cmd.ExecuteNonQuery(); // ejecuta update
                }

                MessageBox.Show("producto actualizado", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information); // confirma
                this.DialogResult = DialogResult.OK; // avisa al inventario para recargar
                this.Close(); // cierra form
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al actualizar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // muestra error
            }
        }

        // ================= stubs viejos del diseñador =================
        // estos metodos vacios evitan errores si el diseñador aun apunta a ellos

        private void panel3_Paint(object sender, PaintEventArgs e) { }  // evento viejo
        private void panel3_Paint_1(object sender, PaintEventArgs e) { } // evento viejo
        private void pLimpiarParametros_Paint(object sender, PaintEventArgs e) { } // evento viejo
        private void TBDescripcionProducto_TextChanged(object sender, EventArgs e) { } // evento viejo
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { } // evento viejo

        private void EditarProducto_Load(object sender, EventArgs e)
        {

        }
    }
}
