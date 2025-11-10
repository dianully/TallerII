using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace PuntoDeVentaGameBox.Gerente
{
    public partial class AgregarProducto : Form
    {
        // cadena fija
        private readonly string _connString = "Server=localhost;Database=game_box;Trusted_Connection=True;TrustServerCertificate=True";
        private readonly int? _idEditar;

        // ruta local de imagen (sin textbox)
        private string _rutaImagen = null;

        // helper interno para dropdown con checks
        private MultiCategoriaHelper _mc;

        public AgregarProducto()
        {
            InitializeComponent();
            _idEditar = null;
            BRegistrarProducto.Text = "Registrar Producto";
            WireEventos();
            PrepararControles();
            _mc = new MultiCategoriaHelper(_connString, CBGeneroProducto);
            _mc.CargarDesdeBd();
            CargarProveedores();
        }

        public AgregarProducto(int idProducto)
        {
            InitializeComponent();
            _idEditar = idProducto;
            BRegistrarProducto.Text = "Guardar Cambios";
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
            BAbrirImagen.Click -= BAbrirImagen_Click;
            BAbrirImagen.Click += BAbrirImagen_Click;

            BRegistrarProducto.Click -= BRegistrarProducto_Click;
            BRegistrarProducto.Click += BRegistrarProducto_Click;

            if (BSalir != null) { BSalir.Click -= BSalir_Click; BSalir.Click += BSalir_Click; }

            TBPrecioVentaProducto.KeyPress -= TBPrecioVentaProducto_KeyPressSoloNumeroDecimal;
            TBPrecioVentaProducto.KeyPress += TBPrecioVentaProducto_KeyPressSoloNumeroDecimal;

            TBCantidadProducto.KeyPress -= TBCantidadProducto_KeyPressSoloEntero;
            TBCantidadProducto.KeyPress += TBCantidadProducto_KeyPressSoloEntero;
        }

        private void PrepararControles()
        {
            if (DTPFechaAlta != null) DTPFechaAlta.Value = DateTime.Today;

            if (CBGeneroProducto != null)
            {
                CBGeneroProducto.DropDownStyle = ComboBoxStyle.DropDownList;
                CBGeneroProducto.SelectedIndex = -1;
            }
            if (CBProveedorProducto != null)
            {
                CBProveedorProducto.DropDownStyle = ComboBoxStyle.DropDownList;
                CBProveedorProducto.SelectedIndex = -1;
            }
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

        private void BAbrirImagen_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog { Filter = "Imagenes|*.jpg;*.jpeg;*.png;*.gif;*.bmp", Title = "Seleccionar imagen" })
            {
                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    _rutaImagen = ofd.FileName;
                    PBImagenProducto.ImageLocation = _rutaImagen;
                }
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
                        select nombre, descripcion, precio_venta, cantidad_stock, url_imagen,
                               fecha_alta, id_proveedor
                        from dbo.producto
                        where id_producto = @id";
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
                            _rutaImagen = rd["url_imagen"] as string;
                            if (rd["fecha_alta"] != DBNull.Value) DTPFechaAlta.Value = Convert.ToDateTime(rd["fecha_alta"]);
                            if (rd["id_proveedor"] != DBNull.Value) CBProveedorProducto.SelectedValue = Convert.ToInt32(rd["id_proveedor"]);
                            PBImagenProducto.ImageLocation = File.Exists(_rutaImagen ?? "") ? _rutaImagen : null;
                        }
                    }
                }
                // marcas iniciales de categorias
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

        private void BRegistrarProducto_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario(out var precio, out var stock, out var provId)) return;

            if (_idEditar == null)
                InsertarProducto(precio, stock, provId);
            else
                ActualizarProducto(_idEditar.Value, precio, stock, provId);
        }

        // ===== validaciones =====
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

        private bool ValidarFormulario(out decimal precio, out int stock, out int? prov)
        {
            precio = 0m; stock = 0; prov = null;

            if (string.IsNullOrWhiteSpace(TBNombreProducto.Text))
            { MessageBox.Show("nombre es obligatorio", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }

            if (!TryParsePrecio(TBPrecioVentaProducto.Text, out precio) || precio < 0)
            { MessageBox.Show("precio invalido", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }

            if (!int.TryParse(TBCantidadProducto.Text, out stock) || stock < 0)
            { MessageBox.Show("stock debe ser entero y mayor o igual a 0", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }

            if (CBProveedorProducto.SelectedValue != null && int.TryParse(CBProveedorProducto.SelectedValue.ToString(), out var p))
                prov = p;

            if (_mc.ObtenerSeleccion().Count == 0)
            {
                var r = MessageBox.Show("no se seleccionaron generos, continuar igual?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No) return false;
            }
            return true;
        }

        // ===== persistencia =====
        private void InsertarProducto(decimal precio, int stock, int? prov)
        {
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
                            insert into dbo.producto
                                (nombre, descripcion, precio_venta, cantidad_stock, url_imagen, fecha_alta, fecha_edicion, id_proveedor, activo)
                            values
                                (@nombre, @descripcion, @precio, @stock, @img, @falta, null, @prov, 1);
                            select cast(SCOPE_IDENTITY() as int);";

                        cmd.Parameters.AddWithValue("@nombre", TBNombreProducto.Text.Trim());
                        cmd.Parameters.AddWithValue("@descripcion", (object)(TBDescripcionProducto.Text ?? "").Trim());
                        cmd.Parameters.AddWithValue("@precio", precio);
                        cmd.Parameters.AddWithValue("@stock", stock);
                        cmd.Parameters.AddWithValue("@img", string.IsNullOrWhiteSpace(_rutaImagen) ? (object)DBNull.Value : _rutaImagen);
                        var pFecha = cmd.Parameters.Add("@falta", SqlDbType.Date); pFecha.Value = DTPFechaAlta.Value.Date;
                        cmd.Parameters.AddWithValue("@prov", (object)prov ?? DBNull.Value);

                        var nuevoId = (int)cmd.ExecuteScalar();

                        // inserta categorias elegidas
                        cmd.Parameters.Clear();
                        cmd.CommandText = "insert into dbo.producto_categoria(id_producto, id_categoria) values (@p,@c);";
                        cmd.Parameters.Add("@p", SqlDbType.Int).Value = nuevoId;
                        var pCat = cmd.Parameters.Add("@c", SqlDbType.Int);

                        foreach (var idCat in _mc.ObtenerSeleccion())
                        { pCat.Value = idCat; cmd.ExecuteNonQuery(); }

                        tx.Commit();
                    }
                }
                MessageBox.Show("producto creado", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al crear producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarProducto(int id, decimal precio, int stock, int? prov)
        {
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
                                fecha_edicion = GETDATE(),
                                id_proveedor = @prov
                            where id_producto = @id;";
                        cmd.Parameters.AddWithValue("@nombre", TBNombreProducto.Text.Trim());
                        cmd.Parameters.AddWithValue("@descripcion", (object)(TBDescripcionProducto.Text ?? "").Trim());
                        cmd.Parameters.AddWithValue("@precio", precio);
                        cmd.Parameters.AddWithValue("@stock", stock);
                        cmd.Parameters.AddWithValue("@img", string.IsNullOrWhiteSpace(_rutaImagen) ? (object)DBNull.Value : _rutaImagen);
                        cmd.Parameters.AddWithValue("@prov", (object)prov ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();

                        // reemplaza categorias
                        cmd.Parameters.Clear();
                        cmd.CommandText = "delete from dbo.producto_categoria where id_producto = @p;";
                        cmd.Parameters.Add("@p", SqlDbType.Int).Value = id;
                        cmd.ExecuteNonQuery();

                        cmd.Parameters.Clear();
                        cmd.CommandText = "insert into dbo.producto_categoria(id_producto, id_categoria) values (@p,@c);";
                        cmd.Parameters.Add("@p", SqlDbType.Int).Value = id;
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

        private void BSalir_Click(object sender, EventArgs e) => this.Close();

        // ===== helper interno (ui dropdown con checks) =====
        // convierte un combobox en un selector multiple usando checkedlistbox en un dropdown
        // ===== helper interno MULTICATEGORÍA (sin BeginInvoke) =====
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

            // flag para no ejecutar el handler mientras seteamos checks por código
            private bool _silencio = false;

            public MultiCategoriaHelper(string connString, ComboBox combo)
            {
                _connString = connString;
                _combo = combo;

                _combo.DropDownStyle = ComboBoxStyle.DropDownList;
                _combo.Items.Clear();
                _combo.SelectedIndex = -1;
                _combo.Text = "sin generos";
                _combo.Cursor = Cursors.Hand;

                _clb.BorderStyle = BorderStyle.None;
                _clb.CheckOnClick = true;
                _clb.IntegralHeight = true;
                _clb.Width = Math.Max(220, _combo.Width);
                _clb.Height = 200;

                var host = new ToolStripControlHost(_clb)
                { Padding = Padding.Empty, Margin = Padding.Empty, AutoSize = false };

                _drop.Padding = Padding.Empty;
                _drop.Items.Add(host);

                // abrir dropdown “flotante”
                _combo.MouseDown += (s, e) =>
                {
                    _drop.Show(_combo, new Point(0, _combo.Height));
                };

                // IMPORTANTE: sin BeginInvoke; usamos e.NewValue y actualizamos directo
                _clb.ItemCheck += (s, e) =>
                {
                    if (_silencio) return; // no reaccionar durante cargas masivas

                    var item = (CatItem)_clb.Items[e.Index];

                    if (e.NewValue == CheckState.Checked)
                        _seleccion.Add(item.Id);
                    else
                        _seleccion.Remove(item.Id);

                    actualizarTextoCombo();
                };
            }

            public void CargarDesdeBd()
            {
                _items.Clear();
                _clb.Items.Clear();

                using (var cn = new SqlConnection(_connString))
                using (var da = new SqlDataAdapter(
                    "select id_categoria, nombre from dbo.categoria order by nombre", cn))
                {
                    var dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow r in dt.Rows)
                    {
                        var it = new CatItem(Convert.ToInt32(r["id_categoria"]),
                                             Convert.ToString(r["nombre"]));
                        _items.Add(it);
                        _clb.Items.Add(it, _seleccion.Contains(it.Id));
                    }
                }

                actualizarTextoCombo();
            }

            public void SetSeleccionInicial(IEnumerable<int> ids)
            {
                _seleccion.Clear();
                foreach (var id in ids) _seleccion.Add(id);

                _silencio = true; // evita invocar el handler en cada SetItemChecked
                for (int i = 0; i < _clb.Items.Count; i++)
                {
                    var it = (CatItem)_clb.Items[i];
                    _clb.SetItemChecked(i, _seleccion.Contains(it.Id));
                }
                _silencio = false;

                actualizarTextoCombo();
            }

            public IReadOnlyCollection<int> ObtenerSeleccion() => _seleccion;

            private void actualizarTextoCombo()
            {
                if (_seleccion.Count == 0) { _combo.Text = "sin generos"; return; }

                var nombres = new List<string>();
                foreach (var it in _items)
                    if (_seleccion.Contains(it.Id)) nombres.Add(it.Nombre);

                nombres.Sort(StringComparer.CurrentCultureIgnoreCase);

                _combo.Text = nombres.Count <= 2
                    ? string.Join(", ", nombres)
                    : string.Join(", ", nombres.GetRange(0, 2)) + $" +{nombres.Count - 2}";
            }
        }


        // stubs viejos
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void PBImagenProducto_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void LFechaAlta_Click(object sender, EventArgs e) { }
        private void LDescripcion_Click(object sender, EventArgs e) { }
        private void TBNombreProducto_TextChanged(object sender, EventArgs e) { }
        private void TBPrecioVentaProducto_TextChanged(object sender, EventArgs e) { }
        private void AgregarProducto_Load(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        // stubs viejos del diseñador, para que no rompa
        private void button2_Click(object sender, EventArgs e) { /* sin uso */ }

        private void bBuscar_Click(object sender, EventArgs e)
        {
            // reusa el boton correcto de abrir imagen
            BAbrirImagen_Click(sender, e);
        }

        private void PDatosProductos_Paint(object sender, PaintEventArgs e) { /* sin uso */ }


    }
}
