using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PuntoDeVentaGameBox.Gerente
{
    public partial class EditarProducto : Form
    {
        private readonly string _connString = "Server=localhost;Database=game_box;Trusted_Connection=True;TrustServerCertificate=True";
        private readonly int? _idProducto;

        private string _rutaImagen = null;
        private MultiCategoriaHelper _mc;

        public EditarProducto()
        {
            InitializeComponent();
            _idProducto = null;
            WireEventos();
            PrepararControles();
            _mc = new MultiCategoriaHelper(_connString, CBGeneroProducto);
            _mc.CargarDesdeBd();
            CargarProveedores();
        }

        public EditarProducto(int idProducto)
        {
            InitializeComponent();
            _idProducto = idProducto;
            WireEventos();
            PrepararControles();
            _mc = new MultiCategoriaHelper(_connString, CBGeneroProducto);
            _mc.CargarDesdeBd();
            CargarProveedores();
            CargarProducto(idProducto);
        }

        private SqlConnection NuevaConexion() => new SqlConnection(_connString);

        private void WireEventos()
        {
            if (BSalir != null) { BSalir.Click -= BSalir_Click; BSalir.Click += BSalir_Click; }
            if (BGuardarCambios != null) { BGuardarCambios.Click -= BGuardarCambios_Click; BGuardarCambios.Click += BGuardarCambios_Click; }
            if (BAbrirImagen != null) { BAbrirImagen.Click -= BAbrirImagen_Click; BAbrirImagen.Click += BAbrirImagen_Click; }
            if (TBPrecioVentaProducto != null) { TBPrecioVentaProducto.KeyPress -= TBPrecioVentaProducto_KeyPressSoloNumeroDecimal; TBPrecioVentaProducto.KeyPress += TBPrecioVentaProducto_KeyPressSoloNumeroDecimal; }
            if (TBCantidadProducto != null) { TBCantidadProducto.KeyPress -= TBCantidadProducto_KeyPressSoloEntero; TBCantidadProducto.KeyPress += TBCantidadProducto_KeyPressSoloEntero; }
        }

        private void PrepararControles()
        {
            if (CBGeneroProducto != null) { CBGeneroProducto.DropDownStyle = ComboBoxStyle.DropDownList; CBGeneroProducto.SelectedIndex = -1; }
            if (CBProveedorProducto != null) { CBProveedorProducto.DropDownStyle = ComboBoxStyle.DropDownList; CBProveedorProducto.SelectedIndex = -1; }
            if (DTPFechaEdicionProducto != null) DTPFechaEdicionProducto.Value = DateTime.Today;
        }

        private void CargarProveedores()
        {
            try
            {
                using (var cn = NuevaConexion())
                using (var da = new SqlDataAdapter("select id_proveedor, nombre from dbo.proveedor where activo = 1 order by nombre", cn))
                {
                    var dt = new DataTable();
                    try { da.Fill(dt); }
                    catch (SqlException)
                    {
                        da.SelectCommand.CommandText = "select id_proveedor, nombre from dbo.proveedor order by nombre";
                        dt.Clear(); da.Fill(dt);
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
                        select p.nombre, p.descripcion, p.precio_venta, p.cantidad_stock,
                               p.url_imagen, p.fecha_alta, p.fecha_edicion, p.id_proveedor
                        from dbo.producto p
                        where p.id_producto = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cn.Open();

                    using (var rd = cmd.ExecuteReader())
                    {
                        if (!rd.Read())
                        { MessageBox.Show("producto no encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

                        TBNombreProducto.Text = rd["nombre"]?.ToString();
                        TBDescripcionProducto.Text = rd["descripcion"]?.ToString();
                        TBPrecioVentaProducto.Text = Convert.ToDecimal(rd["precio_venta"]).ToString("0.##");
                        TBCantidadProducto.Text = rd["cantidad_stock"]?.ToString();
                        _rutaImagen = rd["url_imagen"] as string;

                        TBFechaAlta.Text = (rd["fecha_alta"] == DBNull.Value) ? "" : Convert.ToDateTime(rd["fecha_alta"]).ToString("yyyy-MM-dd");
                        if (rd["fecha_edicion"] != DBNull.Value && DTPFechaEdicionProducto != null)
                            DTPFechaEdicionProducto.Value = Convert.ToDateTime(rd["fecha_edicion"]);
                        if (rd["id_proveedor"] != DBNull.Value)
                            CBProveedorProducto.SelectedValue = Convert.ToInt32(rd["id_proveedor"]);

                        PBImagenProducto.ImageLocation = File.Exists(_rutaImagen ?? "") ? _rutaImagen : null;
                    }
                }

                using (var cn = NuevaConexion())
                using (var da = new SqlDataAdapter(@"select id_categoria from dbo.producto_categoria where id_producto = @id", cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@id", id);
                    var dt = new DataTable(); da.Fill(dt);
                    var ids = new List<int>();
                    foreach (DataRow r in dt.Rows) ids.Add(Convert.ToInt32(r["id_categoria"]));
                    _mc.SetSeleccionInicial(ids);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al cargar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BAbrirImagen_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog { Filter = "Imagenes|*.jpg;*.jpeg;*.png;*.gif;*.bmp", Title = "Seleccionar imagen" })
            { if (ofd.ShowDialog(this) == DialogResult.OK) { _rutaImagen = ofd.FileName; PBImagenProducto.ImageLocation = _rutaImagen; } }
        }

        private void BSalir_Click(object sender, EventArgs e) => this.Close();

        private void BGuardarCambios_Click(object sender, EventArgs e)
        {
            if (_idProducto == null) { MessageBox.Show("no se indico producto a editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!ValidarFormulario(out var precio, out var stock, out var idProv, out var fechaAlta)) return;

            try
            {
                using (var cn = NuevaConexion())
                {
                    cn.Open();
                    using (var tx = cn.BeginTransaction())
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.Transaction = tx;

                        cmd.CommandText = @"
                            update dbo.producto
                            set nombre = @nombre,
                                descripcion = @descripcion,
                                precio_venta = @precio,
                                cantidad_stock = @stock,
                                url_imagen = @img,
                                fecha_alta = @falta,
                                fecha_edicion = GETDATE(),
                                id_proveedor = @prov
                            where id_producto = @id;";
                        cmd.Parameters.AddWithValue("@nombre", TBNombreProducto.Text.Trim());
                        cmd.Parameters.AddWithValue("@descripcion", (object)(TBDescripcionProducto.Text ?? "").Trim());
                        cmd.Parameters.AddWithValue("@precio", precio);
                        cmd.Parameters.AddWithValue("@stock", stock);
                        cmd.Parameters.AddWithValue("@img", string.IsNullOrWhiteSpace(_rutaImagen) ? (object)DBNull.Value : _rutaImagen);
                        var pFecha = cmd.Parameters.Add("@falta", SqlDbType.Date); pFecha.Value = fechaAlta.Date;
                        cmd.Parameters.AddWithValue("@prov", (object)idProv ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@id", _idProducto.Value);
                        cmd.ExecuteNonQuery();

                        // reemplaza categorias
                        cmd.Parameters.Clear();
                        cmd.CommandText = "delete from dbo.producto_categoria where id_producto = @p;";
                        cmd.Parameters.Add("@p", SqlDbType.Int).Value = _idProducto.Value;
                        cmd.ExecuteNonQuery();

                        cmd.Parameters.Clear();
                        cmd.CommandText = "insert into dbo.producto_categoria(id_producto, id_categoria) values (@p,@c);";
                        cmd.Parameters.Add("@p", SqlDbType.Int).Value = _idProducto.Value;
                        var pCat = cmd.Parameters.Add("@c", SqlDbType.Int);
                        foreach (var idCat in _mc.ObtenerSeleccion())
                        { pCat.Value = idCat; cmd.ExecuteNonQuery(); }

                        tx.Commit();
                    }
                }

                MessageBox.Show("producto actualizado", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al actualizar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TBCantidadProducto_KeyPressSoloEntero(object sender, KeyPressEventArgs e)
        { if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; }

        private void TBPrecioVentaProducto_KeyPressSoloNumeroDecimal(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) return;
            if ((e.KeyChar == ',' || e.KeyChar == '.') && (sender as TextBox).Text.IndexOfAny(new[] { ',', '.' }) == -1) return;
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

        private bool ValidarFormulario(out decimal precio, out int stock, out int? idProv, out DateTime fechaAlta)
        {
            precio = 0m; stock = 0; idProv = null; fechaAlta = DateTime.MinValue;

            if (string.IsNullOrWhiteSpace(TBNombreProducto.Text))
            { MessageBox.Show("nombre es obligatorio", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }

            if (!TryParsePrecio(TBPrecioVentaProducto.Text, out precio) || precio < 0)
            { MessageBox.Show("precio invalido", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }

            if (!int.TryParse(TBCantidadProducto.Text, out stock) || stock < 0)
            { MessageBox.Show("stock debe ser entero y mayor o igual a 0", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }

            if (!DateTime.TryParse(TBFechaAlta.Text?.Trim(), out fechaAlta))
            { MessageBox.Show("fecha de alta invalida, usar aaaa-mm-dd", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }

            if (CBProveedorProducto.SelectedValue != null && int.TryParse(CBProveedorProducto.SelectedValue.ToString(), out var p))
                idProv = p;

            return true;
        }

        // ===== helper interno (igual al de AgregarProducto) =====
        // ===== helper interno MULTICATEGORÍA (sin BeginInvoke) =====
        // ===== Helper multi-categoría (scroll real, sin desbordes, selección inmediata) =====
        // ===== Helper multi-categoría (scroll real, sin desbordes, selección inmediata) =====
        // ===== Helper multi-categoría (idéntico al de Inventario, con scroll real y selección inmediata) =====
        // ===== Helper multi-categoría (idéntico a Inventario, scroll real y selección inmediata) =====
        private sealed class MultiCategoriaHelper
        {
            private sealed class CatItem
            {
                public int Id { get; }
                public string Nombre { get; }
                public CatItem(int id, string nombre) { Id = id; Nombre = nombre; }
                public override string ToString() => Nombre;
            }

            private readonly string _connString;
            private readonly ComboBox _combo;
            private readonly HashSet<int> _seleccion = new HashSet<int>();
            private readonly List<CatItem> _items = new List<CatItem>();

            private readonly ToolStripDropDown _drop = new ToolStripDropDown();
            private readonly CheckedListBox _clb = new CheckedListBox();
            private readonly ToolStripControlHost _host;

            private const float FONT_PT = 11.0f;
            private const int ITEM_H = 22;
            private const int MAX_HEIGHT = 180;
            private const int MIN_HEIGHT = 120;
            private const int MARGIN = 8;

            private bool _silencio = false;

            public MultiCategoriaHelper(string connString, ComboBox combo)
            {
                _connString = connString;
                _combo = combo;

                _combo.DropDownStyle = ComboBoxStyle.DropDownList;
                _combo.Items.Clear();
                _combo.SelectedIndex = -1;
                _combo.Text = "Seleccionar géneros…";
                _combo.Cursor = Cursors.Hand;

                // CheckedListBox con scroll real (no se estira)
                _clb.CheckOnClick = true;
                _clb.BorderStyle = BorderStyle.None;
                _clb.IntegralHeight = false;
                _clb.Font = new Font(_combo.Font.FontFamily, FONT_PT, FontStyle.Regular);
                _clb.ItemHeight = Math.Max(_clb.ItemHeight, ITEM_H);
                _clb.HorizontalScrollbar = true;

                _clb.ItemCheck += (s, e) =>
                {
                    if (_silencio) return;
                    var it = (CatItem)_clb.Items[e.Index];
                    if (e.NewValue == CheckState.Checked) _seleccion.Add(it.Id);
                    else _seleccion.Remove(it.Id);
                    ActualizarTextoCombo();
                };
                _clb.PreviewKeyDown += (s, e) => { if (e.KeyCode == Keys.Escape) _drop.Close(); };

                _host = new ToolStripControlHost(_clb)
                { Padding = Padding.Empty, Margin = Padding.Empty, AutoSize = false };

                _drop.Padding = Padding.Empty;
                _drop.Items.Add(_host);
                _drop.AutoClose = true; // clic afuera => cerrar

                // Abrir con un tap (y sin cerrar en Leave para no auto-cancelar)
                _combo.MouseUp += (s, e) => { if (!_drop.Visible) OpenDropFitted(); };
                _combo.Click += (s, e) => { if (!_drop.Visible) OpenDropFitted(); };

                _combo.SizeChanged += (s, e) => { if (_drop.Visible) _drop.Close(); };
                _combo.LocationChanged += (s, e) => { if (_drop.Visible) _drop.Close(); };
                _combo.ParentChanged += (s, e) =>
                {
                    if (_combo.Parent != null)
                        _combo.Parent.VisibleChanged += (s2, e2) => { if (_drop.Visible) _drop.Close(); };
                };
                var form = _combo.FindForm();
                if (form != null)
                    form.Deactivate += (s, e) => { if (_drop.Visible) _drop.Close(); };
            }

            private void OpenDropFitted()
            {
                var form = _combo.FindForm();
                if (form == null) return;

                Rectangle formScreen = form.RectangleToScreen(form.ClientRectangle);
                Point comboScreen = _combo.PointToScreen(new Point(0, 0));

                int spaceBelow = formScreen.Bottom - (comboScreen.Y + _combo.Height) - MARGIN;
                int spaceAbove = (comboScreen.Y - formScreen.Top) - MARGIN;

                int width = Math.Max(_combo.ClientSize.Width, 200);
                int desired;
                bool openUp;

                if (spaceBelow >= MIN_HEIGHT) { desired = Math.Min(MAX_HEIGHT, spaceBelow); openUp = false; }
                else if (spaceAbove >= MIN_HEIGHT) { desired = Math.Min(MAX_HEIGHT, spaceAbove); openUp = true; }
                else
                {
                    if (spaceAbove > spaceBelow) { desired = Math.Max(MIN_HEIGHT, Math.Max(0, spaceAbove)); openUp = true; }
                    else { desired = Math.Max(MIN_HEIGHT, Math.Max(0, spaceBelow)); openUp = false; }
                }

                _host.Size = new Size(width, desired);
                _clb.Size = _host.Size;

                var offset = openUp ? new Point(0, -desired - 2) : new Point(0, _combo.Height - 1);
                _drop.Show(_combo, offset);
                _clb.Focus();
            }

            public void CargarDesdeBd()
            {
                _items.Clear();
                _clb.Items.Clear();

                using (var cn = new SqlConnection(_connString))
                using (var da = new SqlDataAdapter("SELECT id_categoria, nombre FROM dbo.categoria ORDER BY nombre", cn))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow r in dt.Rows)
                    {
                        var it = new CatItem(Convert.ToInt32(r["id_categoria"]), Convert.ToString(r["nombre"]));
                        _items.Add(it);
                        _clb.Items.Add(it, _seleccion.Contains(it.Id));
                    }
                }
                ActualizarTextoCombo();
            }

            public void SetSeleccionInicial(IEnumerable<int> ids)
            {
                _seleccion.Clear();
                foreach (var id in ids) _seleccion.Add(id);

                _silencio = true;
                for (int i = 0; i < _clb.Items.Count; i++)
                {
                    var it = (CatItem)_clb.Items[i];
                    _clb.SetItemChecked(i, _seleccion.Contains(it.Id));
                }
                _silencio = false;

                ActualizarTextoCombo();
            }

            public IReadOnlyCollection<int> ObtenerSeleccion() => _seleccion;

            private void ActualizarTextoCombo()
            {
                if (_seleccion.Count == 0) { _combo.Text = "Seleccionar géneros…"; return; }

                var nombres = new List<string>();
                foreach (var it in _items) if (_seleccion.Contains(it.Id)) nombres.Add(it.Nombre);
                nombres.Sort(StringComparer.CurrentCultureIgnoreCase);

                _combo.Text = (nombres.Count <= 2)
                    ? string.Join(", ", nombres)
                    : string.Join(", ", nombres.Take(2)) + $" +{nombres.Count - 2}";
            }
        }






        // stubs
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void panel3_Paint_1(object sender, PaintEventArgs e) { }
        private void pLimpiarParametros_Paint(object sender, PaintEventArgs e) { }
        private void TBDescripcionProducto_TextChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void EditarProducto_Load(object sender, EventArgs e) { }
    }
}
