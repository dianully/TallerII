using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace PuntoDeVentaGameBox.Gerente
{
    public partial class EditarProducto : Form
    {
        private readonly string _connString = "Server=localhost;Database=game_box;Trusted_Connection=True;TrustServerCertificate=True";
        private readonly int? _idProducto;

        // ========== IMAGEN ==========
        private byte[] _imagenOriginal = null; // guarda los bytes de la BD para conservar si no cambiás

        // ========== Multi-categoría (dropdown externo con checks) ==========
        private ToolStripDropDown _ddCategorias;
        private CheckedListBox _clbCategorias;
        private readonly HashSet<int> _selectedCatIds = new HashSet<int>();
        private List<ItemCategoria> _todasLasCategorias = new List<ItemCategoria>();

        public EditarProducto()
        {
            InitializeComponent();
            _idProducto = null;

            WireEventos();
            PrepararControles();

            EnsureTablaPuente();
            CargarCategorias();
            CargarProveedores();
        }

        public EditarProducto(int idProducto)
        {
            InitializeComponent();
            _idProducto = idProducto;

            WireEventos();
            PrepararControles();

            EnsureTablaPuente();
            CargarCategorias();
            CargarProveedores();
            CargarProducto(idProducto);
        }

        private SqlConnection NuevaConexion() => new SqlConnection(_connString);

        // ===================== Helpers de Imagen =====================
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
                using (var imgTemp = Image.FromStream(ms))
                    return new Bitmap(imgTemp); // copia: no queda atado al stream
            }
            catch { return null; }
        }

        private static Image PlaceholderImagen()
        {
            var bmp = new Bitmap(64, 64);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.LightGray);
                using (var p = new Pen(Color.DarkGray, 3))
                {
                    g.DrawRectangle(p, 1, 1, 62, 62);
                    g.DrawLine(p, 14, 14, 50, 50);
                    g.DrawLine(p, 50, 14, 14, 50);
                }
            }
            return bmp;
        }

        // ===================== Multi-categoría =====================
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
            catch { /* si no hay permisos, seguimos con fallback */ }
        }

        private void WireEventos()
        {
            if (BSalir != null)
            {
                BSalir.Click -= BSalir_Click;
                BSalir.Click += BSalir_Click;
            }

            if (BGuardarCambios != null)
            {
                BGuardarCambios.Click -= BGuardarCambios_Click;
                BGuardarCambios.Click += BGuardarCambios_Click;
            }

            if (BAbrirImagen != null)
            {
                BAbrirImagen.Click -= BAbrirImagen_Click;
                BAbrirImagen.Click += BAbrirImagen_Click;
            }

            if (TBDireccionImagen != null)
            {
                TBDireccionImagen.TextChanged -= TBDireccionImagen_TextChanged_Preview;
                TBDireccionImagen.TextChanged += TBDireccionImagen_TextChanged_Preview;
            }

            if (TBPrecioVentaProducto != null)
            {
                TBPrecioVentaProducto.KeyPress -= TBPrecioVentaProducto_KeyPressSoloNumeroDecimal;
                TBPrecioVentaProducto.KeyPress += TBPrecioVentaProducto_KeyPressSoloNumeroDecimal;
            }

            if (TBCantidadProducto != null)
            {
                TBCantidadProducto.KeyPress -= TBCantidadProducto_KeyPressSoloEntero;
                TBCantidadProducto.KeyPress += TBCantidadProducto_KeyPressSoloEntero;
            }

            CBGeneroProducto.DropDown -= CBGeneroProducto_DropDown;
            CBGeneroProducto.DropDown += CBGeneroProducto_DropDown;
            CBGeneroProducto.KeyPress -= CBGeneroProducto_KeyPress_BloquearEscritura;
            CBGeneroProducto.KeyPress += CBGeneroProducto_KeyPress_BloquearEscritura;
        }

        private void PrepararControles()
        {
            if (CBProveedorProducto != null)
            {
                CBProveedorProducto.DropDownStyle = ComboBoxStyle.DropDownList;
                CBProveedorProducto.MaxDropDownItems = 4;
                CBProveedorProducto.SelectedIndex = -1;
            }

            CBGeneroProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            CBGeneroProducto.Items.Clear();
            CBGeneroProducto.Items.Add("(Sin categorías)");
            CBGeneroProducto.SelectedIndex = 0;

            if (DTPFechaEdicionProducto != null) DTPFechaEdicionProducto.Value = DateTime.Today;
            // Ajuste de render del PictureBox (escala automática al tamaño del cuadro)
            if (PBImagenProducto != null)
            {
                PBImagenProducto.SizeMode = PictureBoxSizeMode.Zoom;
                PBImagenProducto.BackColor = Color.Transparent; // opcional
            }

        }

        // ============ Dropdown externo con CheckedListBox ============
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
                _selectedCatIds.Clear();
                for (int i = 0; i < _clbCategorias.Items.Count; i++)
                    if (_clbCategorias.GetItemChecked(i))
                        _selectedCatIds.Add(((ItemCategoria)_clbCategorias.Items[i]).Id);

                ActualizarTextoComboCategorias();
            };
        }

        private void CBGeneroProducto_DropDown(object sender, EventArgs e)
        {
            CBGeneroProducto.DroppedDown = false;
            AsegurarDropdownCategorias();
            var p = CBGeneroProducto.PointToScreen(new System.Drawing.Point(0, CBGeneroProducto.Height));
            _ddCategorias.Show(p);
        }

        private void CBGeneroProducto_KeyPress_BloquearEscritura(object sender, KeyPressEventArgs e) => e.Handled = true;

        private void ActualizarTextoComboCategorias()
        {
            string texto = "(Sin categorías)";
            if (_selectedCatIds.Count > 0)
            {
                var nombres = _todasLasCategorias.Where(c => _selectedCatIds.Contains(c.Id)).Select(c => c.Nombre);
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
                MessageBox.Show($"error al cargar generos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void CargarProducto(int id)
        {
            try
            {
                using (var cn = NuevaConexion())
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT p.nombre, p.descripcion, p.precio_venta, p.cantidad_stock,
                               p.url_imagen, p.imagen, p.fecha_alta, p.fecha_edicion,
                               p.id_proveedor, ISNULL(p.id_categoria, 0) AS id_categoria
                        FROM dbo.producto p
                        WHERE p.id_producto = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cn.Open();

                    using (var rd = cmd.ExecuteReader())
                    {
                        if (!rd.Read())
                        {
                            MessageBox.Show("producto no encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        TBNombreProducto.Text = rd["nombre"]?.ToString();
                        TBDescripcionProducto.Text = rd["descripcion"]?.ToString();
                        TBPrecioVentaProducto.Text = Convert.ToDecimal(rd["precio_venta"]).ToString("0.##");
                        TBCantidadProducto.Text = rd["cantidad_stock"]?.ToString();
                        TBDireccionImagen.Text = rd["url_imagen"]?.ToString();

                        // cachear imagen original (BD)
                        _imagenOriginal = rd["imagen"] == DBNull.Value ? null : (byte[])rd["imagen"];

                        // fechas
                        TBFechaAlta.Text = (rd["fecha_alta"] == DBNull.Value)
                            ? ""
                            : Convert.ToDateTime(rd["fecha_alta"]).ToString("yyyy-MM-dd");

                        if (rd["fecha_edicion"] != DBNull.Value && DTPFechaEdicionProducto != null)
                            DTPFechaEdicionProducto.Value = Convert.ToDateTime(rd["fecha_edicion"]);

                        if (rd["id_proveedor"] != DBNull.Value)
                            CBProveedorProducto.SelectedValue = Convert.ToInt32(rd["id_proveedor"]);
                    }
                }

                // Categorías seleccionadas (puente o fallback a id_categoria)
                CargarCategoriasProductoSeleccionadas(id);
                ActualizarTextoComboCategorias();

                // Mostrar imagen: 1) binaria 2) url local 3) url http 4) placeholder
                MostrarImagenDesdeBDyRuta(TBDireccionImagen.Text, _imagenOriginal);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al cargar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarImagenDesdeBDyRuta(string ruta, byte[] bin)
        {
            Image img = BytesAImagen(bin);

            if (img == null)
            {
                if (!string.IsNullOrWhiteSpace(ruta))
                {
                    if (ruta.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                    {
                        var data = DescargarUrlBytes(ruta);
                        img = BytesAImagen(data);
                    }
                    else if (File.Exists(ruta))
                    {
                        try { img = Image.FromFile(ruta); } catch { img = null; }
                    }
                }
            }

            PBImagenProducto.Image = img ?? PlaceholderImagen();
        }

        private void CargarCategoriasProductoSeleccionadas(int idProducto)
        {
            _selectedCatIds.Clear();
            try
            {
                using (var cn = NuevaConexion())
                using (var da = new SqlDataAdapter(@"
DECLARE @hasPuente BIT = CASE WHEN EXISTS(
    SELECT 1 FROM sys.tables WHERE name='producto_categoria' AND schema_id = SCHEMA_ID('dbo')
) THEN 1 ELSE 0 END;

IF @hasPuente = 1
BEGIN
    IF EXISTS (SELECT 1 FROM dbo.producto_categoria WHERE id_producto = @id)
    BEGIN
        SELECT id_categoria
        FROM dbo.producto_categoria
        WHERE id_producto = @id;
    END
    ELSE
    BEGIN
        SELECT ISNULL(p.id_categoria, 0) AS id_categoria
        FROM dbo.producto p
        WHERE p.id_producto = @id AND p.id_categoria IS NOT NULL;
    END
END
ELSE
BEGIN
    SELECT ISNULL(p.id_categoria, 0) AS id_categoria
    FROM dbo.producto p
    WHERE p.id_producto = @id AND p.id_categoria IS NOT NULL;
END
", cn))
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
                // silencio
            }
        }

        // ===================== Guardado =====================

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

        private List<int> LeerCategoriasSeleccionadas() => _selectedCatIds.ToList();

        private bool ValidarFormulario(out decimal precio, out int stock, out int? idProv, out List<int> categorias, out DateTime fechaAlta, out byte[] imgBytes)
        {
            precio = 0m; stock = 0; idProv = null; categorias = LeerCategoriasSeleccionadas(); fechaAlta = DateTime.MinValue; imgBytes = null;

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

            if (!DateTime.TryParse(TBFechaAlta.Text?.Trim(), out fechaAlta))
            {
                MessageBox.Show("Fecha de alta inválida. Usar formato AAAA-MM-DD.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (CBProveedorProducto.SelectedValue != null &&
                int.TryParse(CBProveedorProducto.SelectedValue.ToString(), out var p))
                idProv = p;

            // Imagen: armar bytes a partir de la ruta/URL si hay algo nuevo
            var ruta = TBDireccionImagen.Text?.Trim();
            if (!string.IsNullOrWhiteSpace(ruta))
            {
                if (ruta.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                {
                    imgBytes = DescargarUrlBytes(ruta);
                }
                else
                {
                    imgBytes = LeerArchivoComoBytes(ruta);
                }
            }

            // Si no se pudo obtener bytes nuevos, conservamos la imagen original
            if (imgBytes == null || imgBytes.Length == 0)
                imgBytes = _imagenOriginal;

            return true;
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
                    // preview inmediata desde archivo
                    try
                    {
                        PBImagenProducto.Image = Image.FromFile(ofd.FileName);
                    }
                    catch
                    {
                        PBImagenProducto.Image = PlaceholderImagen();
                    }
                }
            }
        }

        private void TBDireccionImagen_TextChanged_Preview(object sender, EventArgs e)
        {
            // preview al editar ruta/URL a mano
            var ruta = TBDireccionImagen.Text?.Trim();
            MostrarImagenDesdeBDyRuta(ruta, null); // le pasamos null para forzar solo ruta/URL
        }

        private void BSalir_Click(object sender, EventArgs e) => Close();

        private void BGuardarCambios_Click(object sender, EventArgs e)
        {
            if (_idProducto == null)
            {
                MessageBox.Show("no se indico producto a editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarFormulario(out var precio, out var stock, out var idProv, out var categorias, out var fechaAlta, out var imgBytes)) return;

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
    fecha_alta = @falta,
    fecha_edicion = GETDATE(),
    id_proveedor = @prov,
    id_categoria = NULL
WHERE id_producto = @id";

                    cmd.Parameters.AddWithValue("@nombre", TBNombreProducto.Text.Trim());
                    cmd.Parameters.AddWithValue("@descripcion", (object)(TBDescripcionProducto.Text ?? "").Trim());
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@stock", stock);

                    // Guardamos siempre la ruta textual tal cual esté (puede ser URL o local)
                    cmd.Parameters.AddWithValue("@img", string.IsNullOrWhiteSpace(TBDireccionImagen.Text) ? (object)DBNull.Value : TBDireccionImagen.Text.Trim());

                    // Binario (prioritario para mostrar)
                    var pImg = cmd.Parameters.Add("@imgBin", SqlDbType.VarBinary, -1);
                    pImg.Value = (object)imgBytes ?? DBNull.Value;

                    cmd.Parameters.Add("@falta", SqlDbType.Date).Value = fechaAlta.Date;
                    cmd.Parameters.AddWithValue("@prov", (object)idProv ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@id", _idProducto.Value);

                    cmd.ExecuteNonQuery();

                    // refrescar filas en puente
                    ReemplazarCategoriasProducto(cn, _idProducto.Value, categorias);
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

        private void ReemplazarCategoriasProducto(SqlConnection cn, int idProducto, List<int> categorias)
        {
            if (!ExisteTablaPuente(cn)) return;

            using (var del = cn.CreateCommand())
            {
                del.CommandText = "DELETE FROM dbo.producto_categoria WHERE id_producto = @p";
                del.Parameters.AddWithValue("@p", idProducto);
                del.ExecuteNonQuery();
            }

            if (categorias == null || categorias.Count == 0) return;

            using (var ins = cn.CreateCommand())
            {
                ins.CommandText = "INSERT INTO dbo.producto_categoria (id_producto, id_categoria) VALUES (@p, @c)";
                ins.Parameters.Add("@p", SqlDbType.Int).Value = idProducto;
                var pCat = ins.Parameters.Add("@c", SqlDbType.Int);
                foreach (var c in categorias.Distinct())
                {
                    pCat.Value = c;
                    ins.ExecuteNonQuery();
                }
            }
        }

        // ===================== stubs diseñador =====================
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void panel3_Paint_1(object sender, PaintEventArgs e) { }
        private void pLimpiarParametros_Paint(object sender, PaintEventArgs e) { }
        private void TBDescripcionProducto_TextChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void EditarProducto_Load(object sender, EventArgs e) { }

        private sealed class ItemCategoria
        {
            public int Id { get; }
            public string Nombre { get; }
            public ItemCategoria(int id, string nombre) { Id = id; Nombre = nombre; }
            public override string ToString() => Nombre;
        }
    }
}
