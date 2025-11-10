using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace PuntoDeVentaGameBox.Gerente
{
    public partial class InventarioForm : Form
    {
        // usa cadena fija sin appconfig
        private readonly string _connString = "Server=localhost;Database=game_box;Trusted_Connection=True;TrustServerCertificate=True";

        // umbral para considerar stock bajo
        private const int UMBRAL_STOCK_BAJO = 25;

        // cache de placeholder para imagen faltante
        private static Image _placeholderImagen;

        // popup de sugerencias reutilizable
        private Panel _suggestPanel;
        private ListBox _suggestList;
        private TextBox _suggestTarget;

        // helper del combo multi-categoría (filtro)
        private MultiCategoriaFiltroHelper _mf;

        // clase para opciones de orden
        private class SortOption
        {
            public string Code { get; set; }
            public string Display { get; set; }
            public override string ToString() => Display;
        }

        public InventarioForm()
        {
            InitializeComponent();

            // handers de la grilla
            DGVProductos.CellContentClick -= DGV_CellContentClick;
            DGVProductos.CellContentClick += DGV_CellContentClick;

            DGVProductos.CellFormatting -= DGVProductos_CellFormatting;
            DGVProductos.CellFormatting += DGVProductos_CellFormatting;
            DGVProductos.DataError -= DGVProductos_DataError;
            DGVProductos.DataError += DGVProductos_DataError;

            DGVProductos.DataBindingComplete -= DGVProductos_DataBindingComplete;
            DGVProductos.DataBindingComplete += DGVProductos_DataBindingComplete;

            // estilo del dgv
            DGVProductos.DefaultCellStyle.ForeColor = Color.Black;
            DGVProductos.RowsDefaultCellStyle.ForeColor = Color.Black;
            DGVProductos.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            // botones
            BNuevoProducto.Click -= BNuevoproducto_Click;
            BNuevoProducto.Click += BNuevoproducto_Click;

            BVerSoloStockBajo.Click -= BVerSoloStockBajo_Click;
            BVerSoloStockBajo.Click += BVerSoloStockBajo_Click;

            // filtros y sugerencias
            TBNombre.TextChanged -= TBNombre_TextChanged;
            TBNombre.TextChanged += TBNombre_TextChanged;

            TBID.TextChanged -= TBID_TextChanged;
            TBID.TextChanged += TBID_TextChanged;

            TBID.KeyPress -= TBID_KeyPress;
            TBID.KeyPress += TBID_KeyPress;

            BAplicarFiltrosProductos.Click -= BAplicarFiltrosProductos_Click;
            BAplicarFiltrosProductos.Click += BAplicarFiltrosProductos_Click;

            BLimpiarFiltrosProductos.Click -= BLimpiarFiltrosProductos_Click;
            BLimpiarFiltrosProductos.Click += BLimpiarFiltrosProductos_Click;

            this.Click -= InventarioForm_Click;
            this.Click += InventarioForm_Click;
        }

        private void InventarioForm_Load(object sender, EventArgs e)
        {
            PrepararColumnas();
            CargarGeneros();    // ahora multi-select
            CargarOrden();
            CargarProductos();  // carga inicial
        }

        private SqlConnection NuevaConexion() => new SqlConnection(_connString);

        // ==================== columnas y carga ====================

        private void PrepararColumnas()
        {
            DGVProductos.AutoGenerateColumns = false;
            DGVProductos.Columns.Clear();

            // id
            var colId = new DataGridViewTextBoxColumn
            {
                Name = "ID",
                HeaderText = "ID",
                DataPropertyName = "id_producto",
                ReadOnly = true,
                FillWeight = 8,
                MinimumWidth = 55
            };
            DGVProductos.Columns.Add(colId);

            // imagen
            var colImg = new DataGridViewImageColumn
            {
                Name = "Imagen",
                HeaderText = "Imagen",
                DataPropertyName = "url_imagen",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = 56
            };
            colImg.DefaultCellStyle.NullValue = null;
            DGVProductos.Columns.Add(colImg);

            // nombre
            var colNombre = new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Nombre",
                DataPropertyName = "nombre",
                ReadOnly = true,
                FillWeight = 56,
                MinimumWidth = 260
            };
            DGVProductos.Columns.Add(colNombre);

            // *** Se elimina la columna Género ***

            // precio
            var colPrecio = new DataGridViewTextBoxColumn
            {
                Name = "Precio",
                HeaderText = "Precio",
                DataPropertyName = "precio_venta",
                ReadOnly = true,
                FillWeight = 16,
                MinimumWidth = 90
            };
            colPrecio.DefaultCellStyle.Format = "N2";
            colPrecio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVProductos.Columns.Add(colPrecio);

            // stock
            var colStock = new DataGridViewTextBoxColumn
            {
                Name = "Stock",
                HeaderText = "Stock",
                DataPropertyName = "cantidad_stock",
                ReadOnly = true,
                FillWeight = 12,
                MinimumWidth = 70
            };
            colStock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGVProductos.Columns.Add(colStock);

            // botón ver
            DGVProductos.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Ver",
                HeaderText = "Ver",
                Text = "Ver",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Popup,
                FillWeight = 4,
                MinimumWidth = 70
            });

            // boton editar
            DGVProductos.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Editar",
                HeaderText = "Editar",
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Popup,
                FillWeight = 4,
                MinimumWidth = 80
            });

            // boton ACCION (dinámico: Eliminar / Reactivar)
            var colAccion = new DataGridViewButtonColumn
            {
                Name = "Accion",
                HeaderText = "Acción",
                UseColumnTextForButtonValue = false,
                FlatStyle = FlatStyle.Popup,
                FillWeight = 4,
                MinimumWidth = 90
            };
            DGVProductos.Columns.Add(colAccion);

            // formato general
            DGVProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVProductos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            DGVProductos.RowTemplate.Height = 56;
            DGVProductos.ReadOnly = false;
            DGVProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVProductos.MultiSelect = false;
        }

        private void CargarProductos(
            string filtroNombre = null,
            int? filtroId = null,
            IReadOnlyCollection<int> filtroCategorias = null,
            string ordenCode = null)
        {
            try
            {
                using (var cn = NuevaConexion())
                using (var da = new SqlDataAdapter())
                using (var cmd = cn.CreateCommand())
                {
                    string catsCsv = (filtroCategorias != null && filtroCategorias.Count > 0)
                        ? string.Join(",", filtroCategorias)
                        : null;

                    string sql = @"
                        SELECT
                            p.id_producto,
                            p.url_imagen,
                            p.nombre,
                            p.precio_venta,
                            p.cantidad_stock,
                            p.activo
                        FROM dbo.producto p
                        WHERE 1 = 1
                          AND (@nom IS NULL OR p.nombre LIKE @like)
                          AND (@id  IS NULL OR p.id_producto = @id)
                          AND (
                                @cats IS NULL
                                OR EXISTS (
                                    SELECT 1
                                    FROM dbo.producto_categoria pc
                                    WHERE pc.id_producto = p.id_producto
                                      AND CAST(pc.id_categoria AS varchar(10))
                                          IN (SELECT value FROM string_split(@cats, ','))
                                )
                          )
                    ";

                    // filtros de visibilidad / orden
                    if (string.Equals(ordenCode, "INACTIVOS", StringComparison.OrdinalIgnoreCase))
                        sql += " AND p.activo = 0";

                    switch (ordenCode)
                    {
                        case "AZ":
                            sql += " ORDER BY p.nombre ASC";
                            break;
                        case "ZA":
                            sql += " ORDER BY p.nombre DESC";
                            break;
                        case "STOCK_LOW":
                            sql += " AND p.cantidad_stock <= @umbral ORDER BY p.cantidad_stock ASC, p.id_producto DESC";
                            break;
                        case "STOCK_HIGH":
                            sql += " AND p.cantidad_stock > @umbral ORDER BY p.cantidad_stock DESC, p.id_producto DESC";
                            break;
                        case "INACTIVOS":
                            sql += " ORDER BY p.id_producto DESC";
                            break;
                        default:
                            sql += @"
                            ORDER BY
                                CASE
                                    WHEN p.activo = 0 THEN 3
                                    WHEN p.cantidad_stock = 0 THEN 2
                                    WHEN p.cantidad_stock > 0 AND p.cantidad_stock <= @umbral THEN 1
                                    ELSE 0
                                END ASC,
                                p.id_producto DESC";
                            break;
                    }

                    cmd.CommandText = sql;

                    cmd.Parameters.AddWithValue("@nom", (object)filtroNombre ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@like", filtroNombre == null ? (object)DBNull.Value : $"%{filtroNombre}%");
                    cmd.Parameters.AddWithValue("@id", (object)filtroId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@cats", (object)catsCsv ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@umbral", UMBRAL_STOCK_BAJO);

                    da.SelectCommand = cmd;
                    var dt = new DataTable();
                    da.Fill(dt);

                    DGVProductos.DataSource = dt;
                }

                ActualizarResumenInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGeneros()
        {
            // Convierte CBGenero a multi-selección con checks a la derecha
            _mf = new MultiCategoriaFiltroHelper(_connString, CBGenero);
            _mf.CargarDesdeBd();
        }

        private void CargarOrden()
        {
            var data = new[]
            {
                new SortOption{ Code = "AZ",         Display = "A - Z" },
                new SortOption{ Code = "ZA",         Display = "Z - A" },
                new SortOption{ Code = "STOCK_LOW",  Display = "menor stock (<= 25)" },
                new SortOption{ Code = "STOCK_HIGH", Display = "mayor stock (> 25)" },
                new SortOption{ Code = "INACTIVOS",  Display = "Inactivos" }
            };
            CBOrden.DataSource = data;
            CBOrden.DisplayMember = "Display";
            CBOrden.ValueMember = "Code";
            CBOrden.SelectedIndex = -1;
            CBOrden.MaxDropDownItems = data.Length;
        }

        // ==================== imagenes ====================

        private static Image PlaceholderImagen()
        {
            if (_placeholderImagen != null) return _placeholderImagen;
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
            _placeholderImagen = bmp;
            return _placeholderImagen;
        }

        private static Image CargarImagenSinBloquear(string ruta)
        {
            try
            {
                using (var fs = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var imgTemp = Image.FromStream(fs))
                {
                    return new Bitmap(imgTemp);
                }
            }
            catch
            {
                return PlaceholderImagen();
            }
        }

        private void DGVProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && DGVProductos.Columns[e.ColumnIndex].Name == "Imagen")
            {
                try
                {
                    var drv = DGVProductos.Rows[e.RowIndex].DataBoundItem as DataRowView;
                    var ruta = drv?["url_imagen"]?.ToString();
                    if (string.IsNullOrWhiteSpace(ruta))
                    {
                        e.Value = PlaceholderImagen();
                        e.FormattingApplied = true;
                        return;
                    }

                    if (ruta.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                        ruta.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                    {
                        e.Value = PlaceholderImagen();
                        e.FormattingApplied = true;
                        return;
                    }

                    if (File.Exists(ruta))
                    {
                        e.Value = CargarImagenSinBloquear(ruta);
                        e.FormattingApplied = true;
                    }
                    else
                    {
                        e.Value = PlaceholderImagen();
                        e.FormattingApplied = true;
                    }
                }
                catch
                {
                    e.Value = PlaceholderImagen();
                    e.FormattingApplied = true;
                }
            }
        }

        private void DGVProductos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            if (e.RowIndex >= 0 && DGVProductos.Columns[e.ColumnIndex].Name == "Imagen")
            {
                DGVProductos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = PlaceholderImagen();
            }
        }

        private void DGVProductos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in DGVProductos.Rows)
                {
                    if (row.DataBoundItem is DataRowView drv)
                    {
                        int activo = drv.Row.Table.Columns.Contains("activo") && drv["activo"] != DBNull.Value
                            ? Convert.ToInt32(drv["activo"])
                            : 1;

                        int stock = drv.Row.Table.Columns.Contains("cantidad_stock") && drv["cantidad_stock"] != DBNull.Value
                            ? Convert.ToInt32(drv["cantidad_stock"])
                            : 0;

                        if (activo == 0)
                            row.DefaultCellStyle.BackColor = Color.LightYellow;
                        else if (stock == 0)
                            row.DefaultCellStyle.BackColor = Color.LightCoral;
                        else if (stock > 0 && stock <= UMBRAL_STOCK_BAJO)
                            row.DefaultCellStyle.BackColor = Color.MistyRose;
                        else
                            row.DefaultCellStyle.BackColor = Color.White;

                        var accionCell = row.Cells["Accion"] as DataGridViewButtonCell;
                        if (accionCell != null)
                            accionCell.Value = (activo == 1) ? "Eliminar" : "Reactivar";
                    }
                }
            }
            catch
            {
                // silencio
            }
        }

        // ==================== acciones de grilla ====================

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = DGVProductos.Columns[e.ColumnIndex];
            bool esVer = col.Name.Equals("Ver", StringComparison.OrdinalIgnoreCase);
            bool esEditar = col.Name.Equals("Editar", StringComparison.OrdinalIgnoreCase);
            bool esAccion = col.Name.Equals("Accion", StringComparison.OrdinalIgnoreCase);
            if (!esVer && !esEditar && !esAccion) return;

            int id = 0; object raw = null;
            if (DGVProductos.Columns.Contains("ID")) raw = DGVProductos.Rows[e.RowIndex].Cells["ID"].Value;
            if ((raw == null || raw == DBNull.Value) && DGVProductos.Rows[e.RowIndex].DataBoundItem is DataRowView drv && drv.Row.Table.Columns.Contains("id_producto"))
                raw = drv["id_producto"];
            if ((raw == null || raw == DBNull.Value) && DGVProductos.Rows[e.RowIndex].Cells.Count > 0)
                raw = DGVProductos.Rows[e.RowIndex].Cells[0].Value;
            if (raw == null || !int.TryParse(raw.ToString(), out id))
            {
                MessageBox.Show("no se pudo obtener el id del producto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int activoRow = 1;
            if (DGVProductos.Rows[e.RowIndex].DataBoundItem is DataRowView drv2 && drv2.Row.Table.Columns.Contains("activo") && drv2["activo"] != DBNull.Value)
                activoRow = Convert.ToInt32(drv2["activo"]);

            if (esVer)
            {
                using (var frm = new VerProducto(id)) { frm.ShowDialog(this); }
                return;
            }

            if (esEditar)
            {
                using (var frm = new EditarProducto(id))
                {
                    var dr = frm.ShowDialog(this);
                    if (dr == DialogResult.OK) CargarProductos();
                }
                return;
            }

            if (esAccion)
            {
                bool vaAInactivar = (activoRow == 1);
                string confirmMsg = vaAInactivar
                    ? $"confirmar eliminacion (baja lógica) del producto id {id}?"
                    : $"confirmar reactivacion del producto id {id}?";

                var resp = MessageBox.Show(confirmMsg, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp != DialogResult.Yes) return;

                try
                {
                    using (var cn = NuevaConexion())
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = @"
                            UPDATE dbo.producto
                               SET activo = @activo,
                                   fecha_edicion = GETDATE()
                             WHERE id_producto = @id";
                        cmd.Parameters.AddWithValue("@activo", vaAInactivar ? 0 : 1);
                        cmd.Parameters.AddWithValue("@id", id);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show(vaAInactivar ? "producto eliminado (inactivado)" : "producto reactivado",
                        "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"error al actualizar estado: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BNuevoproducto_Click(object sender, EventArgs e)
        {
            using (var frm = new AgregarProducto())
            {
                var dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK) CargarProductos();
            }
        }

        // ==================== sugerencias ====================

        private void EnsureSuggestControls()
        {
            if (_suggestPanel != null) return;
            _suggestPanel = new Panel { BorderStyle = BorderStyle.FixedSingle, Visible = false };
            _suggestList = new ListBox { IntegralHeight = false, Dock = DockStyle.Fill };
            _suggestList.Click += SuggestList_Click;
            _suggestList.KeyDown += SuggestList_KeyDown;
            _suggestPanel.Controls.Add(_suggestList);
            this.Controls.Add(_suggestPanel);
        }

        private void ShowSuggestions(TextBox target, DataTable data, string displayColumn)
        {
            EnsureSuggestControls();
            _suggestTarget = target;

            _suggestList.BeginUpdate();
            _suggestList.Items.Clear();
            foreach (DataRow r in data.Rows) _suggestList.Items.Add(Convert.ToString(r[displayColumn]));
            _suggestList.EndUpdate();

            if (_suggestList.Items.Count == 0)
            {
                _suggestPanel.Visible = false;
                return;
            }

            var screen = target.PointToScreen(new Point(0, target.Height));
            var local = this.PointToClient(screen);
            _suggestPanel.Location = local;
            _suggestPanel.Width = target.Width;

            int itemHeight = _suggestList.ItemHeight;
            int visible = Math.Min(4, _suggestList.Items.Count);
            _suggestPanel.Height = visible * itemHeight + 6;

            _suggestPanel.BringToFront();
            _suggestPanel.Visible = true;
            _suggestList.SelectedIndex = -1;
        }

        private void HideSuggestions()
        {
            if (_suggestPanel != null) _suggestPanel.Visible = false;
        }

        private void SuggestList_Click(object sender, EventArgs e)
        {
            if (_suggestTarget != null && _suggestList.SelectedItem != null)
            {
                _suggestTarget.Text = _suggestList.SelectedItem.ToString();
                _suggestTarget.SelectionStart = _suggestTarget.Text.Length;
                HideSuggestions();
            }
        }

        private void SuggestList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SuggestList_Click(sender, EventArgs.Empty);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                HideSuggestions();
                e.Handled = true;
            }
        }

        private void InventarioForm_Click(object sender, EventArgs e) => HideSuggestions();

        private void TBNombre_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string pref = TBNombre.Text?.Trim();
                if (string.IsNullOrEmpty(pref)) { HideSuggestions(); return; }

                using (var cn = NuevaConexion())
                using (var da = new SqlDataAdapter(@"
                        SELECT DISTINCT TOP 50 nombre
                        FROM dbo.producto
                        WHERE nombre LIKE @p + '%'
                        ORDER BY nombre", cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@p", pref);
                    var dt = new DataTable();
                    da.Fill(dt);
                    ShowSuggestions(TBNombre, dt, "nombre");
                }
            }
            catch { }
        }

        private void TBID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string pref = TBID.Text?.Trim();
                if (string.IsNullOrEmpty(pref)) { HideSuggestions(); return; }

                using (var cn = NuevaConexion())
                using (var da = new SqlDataAdapter(@"
                        SELECT TOP 50 id_producto
                        FROM dbo.producto
                        WHERE CAST(id_producto AS varchar(20)) LIKE @p + '%'
                        ORDER BY id_producto", cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@p", pref);
                    var dt = new DataTable();
                    da.Fill(dt);
                    ShowSuggestions(TBID, dt, "id_producto");
                }
            }
            catch { }
        }

        private void TBID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // ==================== filtros (aplicar / limpiar / stock bajo) ====================

        private void BAplicarFiltrosProductos_Click(object sender, EventArgs e)
        {
            string fNombre = string.IsNullOrWhiteSpace(TBNombre.Text) ? null : TBNombre.Text.Trim();

            int? fId = null;
            if (int.TryParse(TBID.Text?.Trim(), out int idVal)) fId = idVal;

            var cats = _mf?.ObtenerSeleccion(); // múltiples categorías
            string ordenCode = (CBOrden.SelectedItem as SortOption)?.Code;

            CargarProductos(fNombre, fId, cats, ordenCode);
            HideSuggestions();
        }

        private void BLimpiarFiltrosProductos_Click(object sender, EventArgs e)
        {
            TBNombre.Clear();
            TBID.Clear();
            CBOrden.SelectedIndex = -1;
            HideSuggestions();
            CargarProductos();
        }

        private void BVerSoloStockBajo_Click(object sender, EventArgs e)
        {
            string fNombre = string.IsNullOrWhiteSpace(TBNombre.Text) ? null : TBNombre.Text.Trim();

            int? fId = null;
            if (int.TryParse(TBID.Text?.Trim(), out int idVal)) fId = idVal;

            var cats = _mf?.ObtenerSeleccion();

            if (CBOrden.DataSource != null)
                CBOrden.SelectedValue = "STOCK_LOW";

            CargarProductos(fNombre, fId, cats, "STOCK_LOW");
            HideSuggestions();
        }

        // ==================== resumen tablero ====================

        private void ActualizarResumenInventario()
        {
            try
            {
                using (var cn = NuevaConexion())
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT
                            COUNT(*)                                 AS productos_totales,
                            ISNULL(SUM(p.cantidad_stock), 0)         AS stock_total,
                            SUM(CASE WHEN p.cantidad_stock <= @u THEN 1 ELSE 0 END) AS stock_bajo
                        FROM dbo.producto p
                        WHERE p.activo = 1";
                    cmd.Parameters.AddWithValue("@u", UMBRAL_STOCK_BAJO);
                    cn.Open();

                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            int productosTotales = Convert.ToInt32(rd["productos_totales"]);
                            int stockTotal = Convert.ToInt32(rd["stock_total"]);
                            int conStockBajo = Convert.ToInt32(rd["stock_bajo"]);

                            KpiTotal.Text = productosTotales.ToString();
                            KpiStock.Text = stockTotal.ToString();
                            KpiBajo.Text = conStockBajo.ToString();

                            var txt = LAvisoStockBajo.Text ?? "";
                            if (txt.Contains("..."))
                                LAvisoStockBajo.Text = txt.Replace("...", conStockBajo.ToString());
                            else
                                LAvisoStockBajo.Text = $"Tienes {conStockBajo} productos con stock bajo. Es recomendable reabastecer estos productos";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al actualizar resumen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====== stubs autogenerados por el diseñador ======
        private void TLRoot_Paint(object sender, PaintEventArgs e) { }
        private void LProductostotales_Click(object sender, EventArgs e) { }
        private void LUnidadeseninventario_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void PFilters_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e) { }
        private void TBID_TextChanged_old(object sender, EventArgs e) { }
        private void TBID_KeyPress_old(object sender, KeyPressEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void BAplicarFiltrosProducto_Click(object sender, EventArgs e) { }

        // ==================== Helper interno multi-categoría (checks a la derecha) ====================

        private sealed class MultiCategoriaFiltroHelper
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

            public MultiCategoriaFiltroHelper(string connString, ComboBox combo)
            {
                _connString = connString;
                _combo = combo;

                _combo.DropDownStyle = ComboBoxStyle.DropDownList;
                _combo.Items.Clear();
                _combo.SelectedIndex = -1;
                _combo.Text = "Desplegar…";
                _combo.Cursor = Cursors.Hand;

                // Owner draw para dibujar el check a la DERECHA
                _clb.DrawMode = DrawMode.OwnerDrawFixed;
                _clb.BorderStyle = BorderStyle.None;
                _clb.CheckOnClick = true;
                _clb.IntegralHeight = true;
                _clb.ItemHeight = Math.Max(_clb.ItemHeight, 18);
                _clb.Width = Math.Max(220, _combo.Width);
                _clb.Height = 200;

                // SINCRONIZA la selección cuando el usuario tilda/destilda
                _clb.ItemCheck += (s, e) =>
                {
                    if (e.Index < 0) return;
                    var it = (CatItem)_clb.Items[e.Index];

                    if (e.NewValue == CheckState.Checked)
                        _seleccion.Add(it.Id);
                    else
                        _seleccion.Remove(it.Id);

                    ActualizarTextoCombo();
                };

                _clb.DrawItem += (s, e) =>
                {
                    e.DrawBackground();
                    if (e.Index >= 0)
                    {
                        var g = e.Graphics;
                        var it = (CatItem)_clb.Items[e.Index];
                        bool isChecked = _clb.GetItemChecked(e.Index);

                        // Texto a la izquierda
                        var textBounds = new Rectangle(e.Bounds.X + 6, e.Bounds.Y + 1, e.Bounds.Width - 28, e.Bounds.Height - 2);
                        TextRenderer.DrawText(g, it.Nombre, e.Font, textBounds, SystemColors.ControlText,
                            TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

                        // Checkbox a la DERECHA
                        var cb = CheckBoxRenderer.GetGlyphSize(g, System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
                        var cbX = e.Bounds.Right - cb.Width - 8;
                        var cbY = e.Bounds.Y + (e.Bounds.Height - cb.Height) / 2;
                        var state = isChecked
                            ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal
                            : System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal;
                        CheckBoxRenderer.DrawCheckBox(g, new Point(cbX, cbY), state);
                    }
                    e.DrawFocusRectangle();
                };

                // Dejamos que CheckOnClick haga su trabajo en todo el ítem.
                // (Handler vacío para no interferir con el toggle por defecto)
                _clb.MouseDown += (s, e) => { /* intencionalmente vacío */ };


                var host = new ToolStripControlHost(_clb)
                { Padding = Padding.Empty, Margin = Padding.Empty, AutoSize = false, Size = new Size(_clb.Width, _clb.Height) };
                _drop.Padding = Padding.Empty;
                _drop.Items.Add(host);

                _combo.MouseDown += (s, e) =>
                {
                    host.Size = new Size(Math.Max(_combo.Width, 220), _clb.Height);
                    _drop.Show(_combo, new Point(0, _combo.Height));
                };
            }

            public void CargarDesdeBd()
            {
                _items.Clear();
                _clb.Items.Clear();

                using (var cn = new SqlConnection(_connString))
                using (var da = new SqlDataAdapter("select id_categoria, nombre from dbo.categoria order by nombre", cn))
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

            public IReadOnlyCollection<int> ObtenerSeleccion() => _seleccion;

            private void ActualizarTextoCombo()
            {
                if (_seleccion.Count == 0) { _combo.Text = "Desplegar…"; return; }
                var nombres = new List<string>();
                foreach (var it in _items) if (_seleccion.Contains(it.Id)) nombres.Add(it.Nombre);
                nombres.Sort(StringComparer.CurrentCultureIgnoreCase);
                _combo.Text = (nombres.Count <= 2)
                    ? string.Join(", ", nombres)
                    : string.Join(", ", nombres.GetRange(0, 2)) + $" +{nombres.Count - 2}";
            }
        }
    }
}
