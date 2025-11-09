using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Drawing;

namespace PuntoDeVentaGameBox.Gerente
{
    public partial class AgregarProducto : Form
    {
        private readonly string _connString = "Server=localhost;Database=game_box;Trusted_Connection=True;TrustServerCertificate=True";
        private readonly int? _idEditar;

        // --- Estado para multi-categoría (UI y datos) ---
        private ToolStripDropDown _ddCategorias;
        private CheckedListBox _clbCategorias;
        private readonly HashSet<int> _selectedCatIds = new HashSet<int>();
        private List<ItemCategoria> _todasLasCategorias = new List<ItemCategoria>();

        public AgregarProducto()
        {
            InitializeComponent();
            _idEditar = null;
            BRegistrarProducto.Text = "Registrar Producto";

            WireEventos();
            PrepararControles();

            EnsureTablaPuente();   // si no existe, la crea
            CargarCategorias();    // llena lista en dropdown
            CargarProveedores();
        }

        public AgregarProducto(int idProducto)
        {
            InitializeComponent();
            _idEditar = idProducto;
            BRegistrarProducto.Text = "Guardar Cambios";

            WireEventos();
            PrepararControles();

            EnsureTablaPuente();   // si no existe, la crea
            CargarCategorias();
            CargarProveedores();
            CargarProducto(idProducto); // carga campos base y categorías
        }

        private SqlConnection NuevaConexion() => new SqlConnection(_connString);

        // === Helpers de imagen para alta/edición ===
        private static byte[] LeerArchivoComoBytes(string path)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(path) || !File.Exists(path)) return null;
                return File.ReadAllBytes(path);
            }
            catch { return null; }
        }

        private static byte[] DescargarUrlBytes(string url)
        {
            try
            {
                using (var wc = new WebClient())
                {
                    wc.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
                    wc.Headers.Add("User-Agent", "Mozilla/5.0");
                    return wc.DownloadData(url);
                }
            }
            catch { return null; }
        }

        private static Image BytesAImagen(byte[] data)
        {
            if (data == null || data.Length == 0) return null;
            try
            {
                using (var ms = new MemoryStream(data))
                using (var temp = Image.FromStream(ms))
                    return new Bitmap(temp);
            }
            catch { return null; }
        }

        private static Image PlaceholderImagen()
        {
            var bmp = new Bitmap(128, 128);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.LightGray);
                using (var p = new Pen(Color.Gray, 4))
                {
                    g.DrawRectangle(p, 6, 6, bmp.Width - 12, bmp.Height - 12);
                    g.DrawLine(p, 20, 20, bmp.Width - 20, bmp.Height - 20);
                    g.DrawLine(p, bmp.Width - 20, 20, 20, bmp.Height - 20);
                }
            }
            return bmp;
        }

        // ==== Infra: crear tabla puente si no existe ====
        private void EnsureTablaPuente()
        {
            try
            {
                using (var cn = NuevaConexion())
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"
IF NOT EXISTS (SELECT * FROM sys.tables t 
               WHERE t.name = 'producto_categoria' AND SCHEMA_ID('dbo') = t.schema_id)
BEGIN
    CREATE TABLE dbo.producto_categoria(
        id_producto  INT NOT NULL,
        id_categoria INT NOT NULL,
        CONSTRAINT PK_producto_categoria PRIMARY KEY (id_producto, id_categoria),
        CONSTRAINT FK_pc_producto  FOREIGN KEY (id_producto)  REFERENCES dbo.producto(id_producto),
        CONSTRAINT FK_pc_categoria FOREIGN KEY (id_categoria) REFERENCES dbo.categoria(id_categoria)
    );
END";
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                // Si por permisos no se puede crear, seguimos; el resto del código igual
                // maneja la ausencia con fallback (pero en este form intentamos crearla).
            }
        }

        private void WireEventos()
        {
            // limpiar handlers heredados del diseñador
            BRegistrarProducto.Click -= BAbrirImagen_Click;
            BRegistrarProducto.Click -= bBuscar_Click;
            BAbrirImagen.Click -= bBuscar_Click;

            BAbrirImagen.Click -= BAbrirImagen_Click;
            BAbrirImagen.Click += BAbrirImagen_Click;

            BRegistrarProducto.Click -= BRegistrarProducto_Click;
            BRegistrarProducto.Click += BRegistrarProducto_Click;

            if (BSalir != null)
            {
                BSalir.Click -= BSalir_Click;
                BSalir.Click += BSalir_Click;
            }

            TBPrecioVentaProducto.KeyPress -= TBPrecioVentaProducto_KeyPressSoloNumeroDecimal;
            TBPrecioVentaProducto.KeyPress += TBPrecioVentaProducto_KeyPressSoloNumeroDecimal;

            TBCantidadProducto.KeyPress -= TBCantidadProducto_KeyPressSoloEntero;
            TBCantidadProducto.KeyPress += TBCantidadProducto_KeyPressSoloEntero;

            // intercepto el despliegue del combo para mostrar el dropdown externo
            CBGeneroProducto.DropDown -= CBGeneroProducto_DropDown;
            CBGeneroProducto.DropDown += CBGeneroProducto_DropDown;
            CBGeneroProducto.KeyPress -= CBGeneroProducto_KeyPress_BloquearEscritura;
            CBGeneroProducto.KeyPress += CBGeneroProducto_KeyPress_BloquearEscritura;

            // preview al escribir/pegar ruta/URL
            TBDireccionImagen.TextChanged -= TBDireccionImagen_TextChanged;
            TBDireccionImagen.TextChanged += TBDireccionImagen_TextChanged;
        }

        private void PrepararControles()
        {
            if (DTPFechaAlta != null) DTPFechaAlta.Value = DateTime.Today;

            // CB de proveedor como antes
            if (CBProveedorProducto != null)
            {
                CBProveedorProducto.DropDownStyle = ComboBoxStyle.DropDownList;
                CBProveedorProducto.MaxDropDownItems = 4;
                CBProveedorProducto.SelectedIndex = -1;
            }

            // CB de género lo usamos como display (texto) únicamente
            CBGeneroProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            CBGeneroProducto.Items.Clear();
            CBGeneroProducto.Items.Add("(Sin categorías)");
            CBGeneroProducto.SelectedIndex = 0;

            // Ajuste del PictureBox para que escale a sus píxeles
            if (PBImagenProducto != null)
            {
                PBImagenProducto.SizeMode = PictureBoxSizeMode.Zoom;
                PBImagenProducto.Image = PlaceholderImagen();
            }
        }

        // === UI: dropdown externo con checks ===
        private void AsegurarDropdownCategorias()
        {
            if (_ddCategorias != null) return;

            _clbCategorias = new CheckedListBox
            {
                CheckOnClick = true,
                IntegralHeight = false,
                BorderStyle = BorderStyle.None,
                Width = CBGeneroProducto.Width,
                Height = Math.Min(200, CBGeneroProducto.Height * 6)
            };

            var host = new ToolStripControlHost(_clbCategorias)
            {
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                AutoSize = false,
                Width = _clbCategorias.Width,
                Height = _clbCategorias.Height
            };

            _ddCategorias = new ToolStripDropDown { Padding = Padding.Empty };
            _ddCategorias.Items.Add(host);

            _ddCategorias.Closed += (s, e) =>
            {
                // sincronizamos selección y texto del combo
                _selectedCatIds.Clear();
                for (int i = 0; i < _clbCategorias.Items.Count; i++)
                    if (_clbCategorias.GetItemChecked(i))
                        _selectedCatIds.Add(((ItemCategoria)_clbCategorias.Items[i]).Id);
                ActualizarTextoComboCategorias();
            };
        }

        private void CBGeneroProducto_DropDown(object sender, EventArgs e)
        {
            // cancelamos el dropdown nativo y mostramos el nuestro afuera
            CBGeneroProducto.DroppedDown = false;
            AsegurarDropdownCategorias();

            // posicionar debajo del combo
            var p = CBGeneroProducto.PointToScreen(new System.Drawing.Point(0, CBGeneroProducto.Height));
            _ddCategorias.Show(p);
        }

        private void CBGeneroProducto_KeyPress_BloquearEscritura(object sender, KeyPressEventArgs e)
        {
            // no permitimos escribir en el combo de display
            e.Handled = true;
        }

        private void ActualizarTextoComboCategorias()
        {
            string texto = "(Sin categorías)";
            if (_selectedCatIds.Count > 0)
            {
                var nombres = _todasLasCategorias
                    .Where(c => _selectedCatIds.Contains(c.Id))
                    .Select(c => c.Nombre);
                texto = string.Join(", ", nombres);
            }
            CBGeneroProducto.Items.Clear();
            CBGeneroProducto.Items.Add(texto);
            CBGeneroProducto.SelectedIndex = 0;
        }

        private void CargarCategorias()
        {
            try
            {
                using (var cn = NuevaConexion())
                using (var da = new SqlDataAdapter("SELECT id_categoria, nombre FROM dbo.categoria ORDER BY nombre", cn))
                {
                    var dt = new DataTable();
                    da.Fill(dt);

                    _todasLasCategorias = dt.AsEnumerable()
                        .Select(r => new ItemCategoria(r.Field<int>("id_categoria"), r.Field<string>("nombre") ?? ""))
                        .ToList();

                    AsegurarDropdownCategorias();
                    _clbCategorias.Items.Clear();
                    foreach (var c in _todasLasCategorias)
                        _clbCategorias.Items.Add(c, _selectedCatIds.Contains(c.Id));

                    ActualizarTextoComboCategorias();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al cargar categorias: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProveedores()
        {
            try
            {
                using (var cn = NuevaConexion())
                using (var da = new SqlDataAdapter("SELECT id_proveedor, nombre FROM dbo.proveedor WHERE activo = 1 ORDER BY nombre", cn))
                {
                    var dt = new DataTable();
                    try { da.Fill(dt); }
                    catch (SqlException)
                    {
                        da.SelectCommand.CommandText = "SELECT id_proveedor, nombre FROM dbo.proveedor ORDER BY nombre";
                        dt.Clear();
                        da.Fill(dt);
                    }

                    CBProveedorProducto.DisplayMember = "nombre";
                    CBProveedorProducto.ValueMember = "id_proveedor";
                    CBProveedorProducto.DataSource = dt;
                    CBProveedorProducto.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al cargar proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BAbrirImagen_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog
            {
                Filter = "Imagenes|*.jpg;*.jpeg;*.png;*.gif;*.bmp",
                Title = "Seleccionar imagen"
            })
            {
                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    TBDireccionImagen.Text = ofd.FileName;

                    // preview inmediata con copia segura
                    try
                    {
                        using (var img = Image.FromFile(ofd.FileName))
                            PBImagenProducto.Image = new Bitmap(img);
                    }
                    catch
                    {
                        PBImagenProducto.Image = PlaceholderImagen();
                    }
                }
            }
        }

        private void TBDireccionImagen_TextChanged(object sender, EventArgs e)
        {
            var ruta = TBDireccionImagen.Text?.Trim();
            Image img = null;

            if (!string.IsNullOrWhiteSpace(ruta))
            {
                if (ruta.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                    img = BytesAImagen(DescargarUrlBytes(ruta));
                else if (File.Exists(ruta))
                {
                    try { using (var f = Image.FromFile(ruta)) img = new Bitmap(f); } catch { img = null; }
                }
            }

            PBImagenProducto.Image = img ?? PlaceholderImagen();
        }

        private void CargarProducto(int id)
        {
            try
            {
                using (var cn = NuevaConexion())
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT nombre, descripcion, precio_venta, cantidad_stock, url_imagen, imagen,
                               fecha_alta, id_proveedor, ISNULL(id_categoria, 0) AS id_categoria
                        FROM dbo.producto
                        WHERE id_producto = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cn.Open();

                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            TBNombreProducto.Text = rd["nombre"]?.ToString();
                            TBDescripcionProducto.Text = rd["descripcion"]?.ToString();
                            TBPrecioVentaProducto.Text = Convert.ToDecimal(rd["precio_venta"]).ToString("0.##");
                            TBCantidadProducto.Text = rd["cantidad_stock"]?.ToString();
                            TBDireccionImagen.Text = rd["url_imagen"]?.ToString();

                            DTPFechaAlta.Value = rd["fecha_alta"] == DBNull.Value
                                ? DateTime.Today
                                : Convert.ToDateTime(rd["fecha_alta"]);

                            if (rd["id_proveedor"] != DBNull.Value)
                                CBProveedorProducto.SelectedValue = Convert.ToInt32(rd["id_proveedor"]);

                            // Mostrar imagen: primero binaria, si no hay, intento ruta/URL
                            Image img = BytesAImagen(rd["imagen"] == DBNull.Value ? null : (byte[])rd["imagen"]);
                            if (img == null)
                            {
                                var ruta = TBDireccionImagen.Text?.Trim();
                                if (!string.IsNullOrWhiteSpace(ruta))
                                {
                                    if (ruta.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                                        img = BytesAImagen(DescargarUrlBytes(ruta));
                                    else if (File.Exists(ruta))
                                    {
                                        try { using (var f = Image.FromFile(ruta)) img = new Bitmap(f); } catch { img = null; }
                                    }
                                }
                            }
                            PBImagenProducto.Image = img ?? PlaceholderImagen();
                        }
                    }
                }

                // cargar categorías seleccionadas del producto (puente si existe; sino, viejo id_categoria)
                CargarCategoriasProductoSeleccionadas(id);
                ActualizarTextoComboCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al cargar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCategoriasProductoSeleccionadas(int idProducto)
        {
            _selectedCatIds.Clear();
            try
            {
                using (var cn = NuevaConexion())
                using (var da = new SqlDataAdapter(@"
IF EXISTS (SELECT 1 FROM sys.tables WHERE name='producto_categoria' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    SELECT pc.id_categoria
    FROM dbo.producto_categoria pc
    WHERE pc.id_producto = @id
END
ELSE
BEGIN
    SELECT ISNULL(p.id_categoria, 0) AS id_categoria
    FROM dbo.producto p
    WHERE p.id_producto = @id AND p.id_categoria IS NOT NULL
END", cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@id", idProducto);
                    var dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow r in dt.Rows)
                    {
                        var idc = Convert.ToInt32(r["id_categoria"]);
                        if (idc > 0) _selectedCatIds.Add(idc);
                    }
                }

                // reflejar en la lista
                if (_clbCategorias != null)
                {
                    for (int i = 0; i < _clbCategorias.Items.Count; i++)
                    {
                        var it = (ItemCategoria)_clbCategorias.Items[i];
                        _clbCategorias.SetItemChecked(i, _selectedCatIds.Contains(it.Id));
                    }
                }
            }
            catch
            {
                // si algo falla, dejamos sin selección
            }
        }

        private void BRegistrarProducto_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario(out var precio, out var stock, out var prov, out var categorias)) return;

            if (_idEditar == null)
                InsertarProducto(precio, stock, prov, categorias);
            else
                ActualizarProducto(_idEditar.Value, precio, stock, prov, categorias);
        }

        // ================= Validaciones =================

        private void TBCantidadProducto_KeyPressSoloEntero(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void TBPrecioVentaProducto_KeyPressSoloNumeroDecimal(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            if (char.IsDigit(e.KeyChar)) return;

            if ((e.KeyChar == ',' || e.KeyChar == '.') &&
                (sender as TextBox).Text.IndexOfAny(new[] { ',', '.' }) == -1) return;

            e.Handled = true;
        }

        private bool TryParsePrecio(string txt, out decimal value)
        {
            txt = (txt ?? "").Trim();
            if (decimal.TryParse(txt, NumberStyles.Number, CultureInfo.CurrentCulture, out value)) return true;
            var alt = txt.Replace(".", ",");
            if (decimal.TryParse(alt, NumberStyles.Number, new CultureInfo("es-AR"), out value)) return true;
            return decimal.TryParse(txt, NumberStyles.Number, CultureInfo.InvariantCulture, out value);
        }

        private bool ValidarFormulario(out decimal precio, out int stock, out int? prov, out List<int> categorias)
        {
            precio = 0m; stock = 0; prov = null; categorias = _selectedCatIds.ToList();

            if (string.IsNullOrWhiteSpace(TBNombreProducto.Text))
            {
                MessageBox.Show("nombre es obligatorio", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!TryParsePrecio(TBPrecioVentaProducto.Text, out precio) || precio < 0)
            {
                MessageBox.Show("precio invalido", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(TBCantidadProducto.Text, out stock) || stock < 0)
            {
                MessageBox.Show("stock debe ser entero y mayor o igual a 0", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (CBProveedorProducto.SelectedValue != null && int.TryParse(CBProveedorProducto.SelectedValue.ToString(), out var provId))
                prov = provId;

            if (categorias.Count == 0)
            {
                var r = MessageBox.Show("No seleccionaste categorías. ¿Continuar sin categorías?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No) return false;
            }

            return true;
        }

        private void InsertarProducto(decimal precio, int stock, int? prov, List<int> categorias)
        {
            try
            {
                using (var cn = NuevaConexion())
                using (var cmd = cn.CreateCommand())
                {
                    cn.Open();

                    cmd.CommandText = @"
INSERT INTO dbo.producto
    (nombre, descripcion, precio_venta, cantidad_stock, url_imagen, imagen, fecha_alta, fecha_edicion, id_proveedor, id_categoria, activo)
VALUES
    (@nombre, @descripcion, @precio, @stock, @img, @imgBin, @falta, NULL, @prov, NULL, 1);
SELECT SCOPE_IDENTITY();";

                    cmd.Parameters.AddWithValue("@nombre", TBNombreProducto.Text.Trim());
                    cmd.Parameters.AddWithValue("@descripcion", (object)(TBDescripcionProducto.Text ?? "").Trim());
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@stock", stock);

                    var ruta = string.IsNullOrWhiteSpace(TBDireccionImagen.Text) ? null : TBDireccionImagen.Text.Trim();
                    cmd.Parameters.AddWithValue("@img", (object)ruta ?? DBNull.Value);

                    // Bytes binarios desde ruta/URL (si hay)
                    byte[] imgBytes = null;
                    if (!string.IsNullOrWhiteSpace(ruta))
                        imgBytes = ruta.StartsWith("http", StringComparison.OrdinalIgnoreCase)
                            ? DescargarUrlBytes(ruta)
                            : LeerArchivoComoBytes(ruta);

                    var pImg = cmd.Parameters.Add("@imgBin", SqlDbType.VarBinary, -1);
                    pImg.Value = (object)imgBytes ?? DBNull.Value;

                    cmd.Parameters.Add("@falta", SqlDbType.Date).Value = DTPFechaAlta.Value.Date;
                    cmd.Parameters.AddWithValue("@prov", (object)prov ?? DBNull.Value);

                    int idProducto = Convert.ToInt32(cmd.ExecuteScalar());

                    // inserta categorías (si existe la tabla)
                    InsertarCategoriasProducto(cn, idProducto, categorias);
                }

                MessageBox.Show("producto creado", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al crear producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarProducto(int id, decimal precio, int stock, int? prov, List<int> categorias)
        {
            try
            {
                using (var cn = NuevaConexion())
                using (var cmd = cn.CreateCommand())
                {
                    cn.Open();

                    cmd.CommandText = @"
UPDATE dbo.producto
SET nombre = @nombre,
    descripcion = @descripcion,
    precio_venta = @precio,
    cantidad_stock = @stock,
    url_imagen = @img,
    imagen = @imgBin,
    fecha_edicion = GETDATE(),
    id_proveedor = @prov,
    id_categoria = NULL
WHERE id_producto = @id";

                    cmd.Parameters.AddWithValue("@nombre", TBNombreProducto.Text.Trim());
                    cmd.Parameters.AddWithValue("@descripcion", (object)(TBDescripcionProducto.Text ?? "").Trim());
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@stock", stock);

                    var ruta = string.IsNullOrWhiteSpace(TBDireccionImagen.Text) ? null : TBDireccionImagen.Text.Trim();
                    cmd.Parameters.AddWithValue("@img", (object)ruta ?? DBNull.Value);

                    byte[] imgBytes = null;
                    if (!string.IsNullOrWhiteSpace(ruta))
                        imgBytes = ruta.StartsWith("http", StringComparison.OrdinalIgnoreCase)
                            ? DescargarUrlBytes(ruta)
                            : LeerArchivoComoBytes(ruta);

                    var pImg = cmd.Parameters.Add("@imgBin", SqlDbType.VarBinary, -1);
                    pImg.Value = (object)imgBytes ?? DBNull.Value;

                    cmd.Parameters.AddWithValue("@prov", (object)prov ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();

                    // reemplaza categorías (si existe la tabla)
                    ReemplazarCategoriasProducto(cn, id, categorias);
                }

                MessageBox.Show("producto actualizado", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al actualizar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ExisteTablaPuente(SqlConnection cn)
        {
            using (var cmd = cn.CreateCommand())
            {
                cmd.CommandText = "SELECT 1 FROM sys.tables WHERE name='producto_categoria' AND schema_id = SCHEMA_ID('dbo')";
                var x = cmd.ExecuteScalar();
                return x != null;
            }
        }

        private void InsertarCategoriasProducto(SqlConnection cn, int idProducto, List<int> categorias)
        {
            if (categorias == null || categorias.Count == 0) return;
            if (!ExisteTablaPuente(cn)) return;

            using (var cmd = cn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO dbo.producto_categoria (id_producto, id_categoria) VALUES (@p, @c)";
                cmd.Parameters.Add("@p", SqlDbType.Int).Value = idProducto;
                var pCat = cmd.Parameters.Add("@c", SqlDbType.Int);

                foreach (var c in categorias.Distinct())
                {
                    pCat.Value = c;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void ReemplazarCategoriasProducto(SqlConnection cn, int idProducto, List<int> categorias)
        {
            if (!ExisteTablaPuente(cn)) return;

            using (var del = cn.CreateCommand())
            {
                del.CommandText = "DELETE FROM dbo.producto_categoria WHERE id_producto = @p";
                del.Parameters.AddWithValue("@p", idProducto);
                del.ExecuteNonQuery();
            }

            InsertarCategoriasProducto(cn, idProducto, categorias);
        }

        private void BSalir_Click(object sender, EventArgs e) => Close();

        // stubs del diseñador
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void PBImagenProducto_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void PDatosProductos_Paint(object sender, PaintEventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void LFechaAlta_Click(object sender, EventArgs e) { }
        private void LDescripcion_Click(object sender, EventArgs e) { }
        private void TBNombreProducto_TextChanged(object sender, EventArgs e) { }
        private void TBPrecioVentaProducto_TextChanged(object sender, EventArgs e) { }
        private void bBuscar_Click(object sender, EventArgs e) { BAbrirImagen_Click(sender, e); }
        private void AgregarProducto_Load(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        // DTO para categorías
        private sealed class ItemCategoria
        {
            public int Id { get; }
            public string Nombre { get; }
            public ItemCategoria(int id, string nombre) { Id = id; Nombre = nombre; }
            public override string ToString() => Nombre;
        }
    }
}
