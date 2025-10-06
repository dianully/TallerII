using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace PuntoDeVentaGameBox.Gerente
{
    public partial class InventarioForm : Form
    {
        // usa cadena fija sin appconfig
        private readonly string _connString = "Server=localhost;Database=game_box;Trusted_Connection=True;TrustServerCertificate=True"; // cadena de conexion fija

        // umbral para considerar stock bajo
        private const int UMBRAL_STOCK_BAJO = 25; // define umbral de stock bajo

        // cache de placeholder para imagen faltante
        private static Image _placeholderImagen; // cache de imagen de relleno

        // popup de sugerencias reutilizable
        private Panel _suggestPanel;       // panel flotante de sugerencias
        private ListBox _suggestList;      // lista de sugerencias
        private TextBox _suggestTarget;    // textbox objetivo activo

        // clase para opciones de orden
        private class SortOption
        {
            public string Code { get; set; } // codigo interno
            public string Display { get; set; } // texto a mostrar
            public override string ToString() => Display; // devuelve display
        }

        public InventarioForm()
        {
            InitializeComponent();

            // asegura handler unico de clicks en celdas
            DGVProductos.CellContentClick -= DGV_CellContentClick; // evita doble suscripcion
            DGVProductos.CellContentClick += DGV_CellContentClick; // maneja botones editar y eliminar

            // convierte url_imagen en miniatura y maneja errores de formato
            DGVProductos.CellFormatting -= DGVProductos_CellFormatting; // evita doble suscripcion
            DGVProductos.CellFormatting += DGVProductos_CellFormatting; // renderiza imagen en la grilla
            DGVProductos.DataError -= DGVProductos_DataError; // evita doble suscripcion
            DGVProductos.DataError += DGVProductos_DataError; // suprime popups de error de formato

            // estilo del dgv
            DGVProductos.DefaultCellStyle.ForeColor = Color.Black; // asegura texto negro
            DGVProductos.RowsDefaultCellStyle.ForeColor = Color.Black; // asegura texto negro
            DGVProductos.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black; // asegura texto negro

            // wire del boton nuevo
            BNuevoProducto.Click -= BNuevoproducto_Click; // evita doble suscripcion
            BNuevoProducto.Click += BNuevoproducto_Click; // abre formulario de 

            BVerSoloStockBajo.Click -= BVerSoloStockBajo_Click; // evita doble suscripcion
            BVerSoloStockBajo.Click += BVerSoloStockBajo_Click; // filtra por stock bajo rapido


            // wires de filtros
            TBNombre.TextChanged -= TBNombre_TextChanged; // evita doble suscripcion
            TBNombre.TextChanged += TBNombre_TextChanged; // muestra sugerencias por nombre
            TBID.TextChanged -= TBID_TextChanged; // evita doble suscripcion
            TBID.TextChanged += TBID_TextChanged; // muestra sugerencias por id
            TBID.KeyPress -= TBID_KeyPress; // evita doble suscripcion
            TBID.KeyPress += TBID_KeyPress; // restringe a numeros
            BAplicarFiltrosProductos.Click -= BAplicarFiltrosProductos_Click; // evita doble suscripcion
            BAplicarFiltrosProductos.Click += BAplicarFiltrosProductos_Click; // aplica filtros
            BLimpiarFiltrosProductos.Click -= BLimpiarFiltrosProductos_Click; // evita doble suscripcion
            BLimpiarFiltrosProductos.Click += BLimpiarFiltrosProductos_Click; // limpia filtros

            // cierra popup si se hace click fuera
            this.Click -= InventarioForm_Click; // evita doble suscripcion
            this.Click += InventarioForm_Click; // oculta popup al clickear fuera
        }

        private void InventarioForm_Load(object sender, EventArgs e)
        {
            // prepara columnas exactas y carga datos desde la base
            PrepararColumnas(); // define columnas manuales y orden
            CargarGeneros();    // llena el combo de generos
            CargarOrden();      // llena el combo de orden
            CargarProductos();  // trae productos activos con nombre de categoria
        }

        private SqlConnection NuevaConexion() => new SqlConnection(_connString); // crea conexion sql

        // ==================== columnas y carga ====================

        private void PrepararColumnas()
        {
            // definimos columnas manuales para evitar duplicados y controlar tamaños
            DGVProductos.AutoGenerateColumns = false; // desactiva autogeneracion de columnas
            DGVProductos.Columns.Clear(); // limpia columnas existentes

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
            DGVProductos.Columns.Add(colId); // agrega columna id

            // imagen miniatura desde url_imagen
            var colImg = new DataGridViewImageColumn
            {
                Name = "Imagen",
                HeaderText = "Imagen",
                DataPropertyName = "url_imagen", // se transforma a Image en CellFormatting
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None, // ancho fijo chico
                Width = 56
            };
            colImg.DefaultCellStyle.NullValue = null; // evita castear null a imagen
            DGVProductos.Columns.Add(colImg); // agrega columna imagen

            // nombre del juego
            var colNombre = new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Nombre",
                DataPropertyName = "nombre",
                ReadOnly = true,
                FillWeight = 48,
                MinimumWidth = 260
            };
            DGVProductos.Columns.Add(colNombre); // agrega columna nombre

            // genero con nombre de la categoria
            var colGenero = new DataGridViewTextBoxColumn
            {
                Name = "Genero",
                HeaderText = "Genero",
                DataPropertyName = "genero", // viene del join a categoria
                ReadOnly = true,
                FillWeight = 18,
                MinimumWidth = 120
            };
            DGVProductos.Columns.Add(colGenero); // agrega columna genero

            // precio
            var colPrecio = new DataGridViewTextBoxColumn
            {
                Name = "Precio",
                HeaderText = "Precio",
                DataPropertyName = "precio_venta",
                ReadOnly = true,
                FillWeight = 14,
                MinimumWidth = 90
            };
            colPrecio.DefaultCellStyle.Format = "N2"; // muestra dos decimales
            colPrecio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // alinea a la derecha
            DGVProductos.Columns.Add(colPrecio); // agrega columna precio

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
            colStock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // centra el numero
            DGVProductos.Columns.Add(colStock); // agrega columna stock

            // boton editar
            DGVProductos.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Editar",
                HeaderText = "Editar",
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Popup,
                FillWeight = 8,
                MinimumWidth = 80
            }); // agrega boton editar

            // boton eliminar
            DGVProductos.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Eliminar",
                HeaderText = "Eliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Popup,
                FillWeight = 8,
                MinimumWidth = 90
            }); // agrega boton eliminar

            // formato general del grid
            DGVProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // reparte el espacio segun fillweight
            DGVProductos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None; // altura fija de filas
            DGVProductos.RowTemplate.Height = 56; // miniatura chica
            DGVProductos.ReadOnly = false; // habilita botones
            DGVProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // seleccion por fila completa
            DGVProductos.MultiSelect = false; // seleccion unica
        }

        private void CargarProductos(string filtroNombre = null, int? filtroId = null, int? filtroCategoria = null, string ordenCode = null)
        {
            // lee productos activos con join a categoria para traer el nombre del genero y aplica filtros
            try
            {
                using (var cn = NuevaConexion())
                using (var da = new SqlDataAdapter())
                using (var cmd = cn.CreateCommand())
                {
                    // arma where base
                    string sql = @"
                        SELECT
                            p.id_producto,
                            p.url_imagen,
                            p.nombre,
                            c.nombre AS genero,
                            p.precio_venta,
                            p.cantidad_stock
                        FROM dbo.producto p
                        LEFT JOIN dbo.categoria c ON c.id_categoria = p.id_categoria
                        WHERE p.activo = 1
                          AND (@nom IS NULL OR p.nombre LIKE @like)
                          AND (@id IS NULL OR p.id_producto = @id)
                          AND (@cat IS NULL OR p.id_categoria = @cat)
                    ";

                    // aplica filtros segun orden seleccionado
                    switch (ordenCode)
                    {
                        case "AZ":
                            sql += " ORDER BY p.nombre ASC";
                            break;
                        case "ZA":
                            sql += " ORDER BY p.nombre DESC";
                            break;
                        case "STOCK_LOW":   // menor stock (<=25)
                            sql += " AND p.cantidad_stock <= @umbral ORDER BY p.cantidad_stock ASC";
                            break;
                        case "STOCK_HIGH":  // mayor stock (>25)
                            sql += " AND p.cantidad_stock > @umbral ORDER BY p.cantidad_stock DESC";
                            break;
                        case "PRICE_LOW":   // menor precio (<=80)
                            sql += " AND p.precio_venta <= @precioLim ORDER BY p.precio_venta ASC";
                            break;
                        case "PRICE_HIGH":  // mayor precio (>80)
                            sql += " AND p.precio_venta > @precioLim ORDER BY p.precio_venta DESC";
                            break;
                        default:
                            sql += " ORDER BY p.id_producto DESC";
                            break;
                    }

                    cmd.CommandText = sql; // setea texto sql

                    // parametros base
                    cmd.Parameters.AddWithValue("@nom", (object)filtroNombre ?? DBNull.Value); // parametro nombre
                    cmd.Parameters.AddWithValue("@like", filtroNombre == null ? (object)DBNull.Value : $"%{filtroNombre}%"); // parametro like
                    cmd.Parameters.AddWithValue("@id", (object)filtroId ?? DBNull.Value); // parametro id
                    cmd.Parameters.AddWithValue("@cat", (object)filtroCategoria ?? DBNull.Value); // parametro categoria

                    // parametros para ordenes con umbral
                    if (ordenCode == "STOCK_LOW" || ordenCode == "STOCK_HIGH")
                        cmd.Parameters.AddWithValue("@umbral", UMBRAL_STOCK_BAJO); // umbral de stock
                    if (ordenCode == "PRICE_LOW" || ordenCode == "PRICE_HIGH")
                        cmd.Parameters.AddWithValue("@precioLim", 80m); // limite de precio

                    da.SelectCommand = cmd; // asigna select al adapter
                    var dt = new DataTable(); // crea tabla en memoria
                    da.Fill(dt); // ejecuta select

                    DGVProductos.DataSource = dt; // vincula al dgv
                }

                ActualizarResumenInventario(); // actualiza tarjetas con los numeros actuales
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // muestra error
            }
        }

        private void CargarGeneros()
        {
            // llena el combobox de generos desde la tabla categoria
            try
            {
                using (var cn = NuevaConexion())
                using (var da = new SqlDataAdapter("SELECT id_categoria, nombre FROM dbo.categoria ORDER BY nombre", cn))
                {
                    var dt = new DataTable(); // tabla de categorias
                    da.Fill(dt); // llena tabla
                    CBGenero.DisplayMember = "nombre"; // muestra nombre
                    CBGenero.ValueMember = "id_categoria"; // valor es id
                    CBGenero.DataSource = dt; // setea datasource
                    CBGenero.SelectedIndex = -1; // arranca sin seleccion
                    CBGenero.MaxDropDownItems = 4; // limita a cuatro visibles
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al cargar generos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // muestra error
            }
        }

        private void CargarOrden()
        {
            // llena el combobox de orden con las seis opciones
            var data = new[]
            {
                new SortOption{ Code = "AZ",         Display = "A - Z" },
                new SortOption{ Code = "ZA",         Display = "Z - A" },
                new SortOption{ Code = "STOCK_LOW",  Display = "menor stock (<= 25)" },
                new SortOption{ Code = "STOCK_HIGH", Display = "mayor stock (> 25)" },
                new SortOption{ Code = "PRICE_LOW",  Display = "menor precio (<= 80)" },
                new SortOption{ Code = "PRICE_HIGH", Display = "mayor precio (> 80)" },
            };
            CBOrden.DataSource = data; // setea datasource
            CBOrden.DisplayMember = "Display"; // muestra texto
            CBOrden.ValueMember = "Code"; // valor es codigo
            CBOrden.SelectedIndex = -1; // arranca sin seleccion
            CBOrden.MaxDropDownItems = 6; // muestra todas
        }

        // ==================== imagenes ====================

        private static Image PlaceholderImagen()
        {
            // crea un bitmap simple gris con una x para usar como placeholder
            if (_placeholderImagen != null) return _placeholderImagen; // devuelve cache si existe
            var bmp = new Bitmap(64, 64); // crea bitmap en memoria
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.LightGray); // fondo gris claro
                using (var p = new Pen(Color.DarkGray, 3))
                {
                    g.DrawRectangle(p, 1, 1, 62, 62); // dibuja borde
                    g.DrawLine(p, 14, 14, 50, 50); // dibuja linea diagonal
                    g.DrawLine(p, 50, 14, 14, 50); // dibuja otra diagonal
                }
            }
            _placeholderImagen = bmp; // guarda en cache
            return _placeholderImagen; // devuelve placeholder
        }

        private static Image CargarImagenSinBloquear(string ruta)
        {
            // carga imagen desde archivo sin bloquear el archivo
            try
            {
                using (var fs = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var imgTemp = Image.FromStream(fs))
                {
                    return new Bitmap(imgTemp); // devuelve copia que no bloquea
                }
            }
            catch
            {
                return PlaceholderImagen(); // si falla devuelve placeholder
            }
        }

        private void DGVProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // convierte ruta en imagen solo para la columna imagen
            if (e.RowIndex >= 0 && DGVProductos.Columns[e.ColumnIndex].Name == "Imagen")
            {
                try
                {
                    var drv = DGVProductos.Rows[e.RowIndex].DataBoundItem as DataRowView; // toma fila
                    var ruta = drv?["url_imagen"]?.ToString(); // obtiene la ruta
                    if (string.IsNullOrWhiteSpace(ruta))
                    {
                        e.Value = PlaceholderImagen(); // muestra placeholder si no hay ruta
                        e.FormattingApplied = true; // marca formato aplicado
                        return;
                    }

                    if (ruta.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                        ruta.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                    {
                        e.Value = PlaceholderImagen(); // usa placeholder para urls remotas
                        e.FormattingApplied = true; // marca formato aplicado
                        return;
                    }

                    if (File.Exists(ruta))
                    {
                        e.Value = CargarImagenSinBloquear(ruta); // carga imagen desde archivo
                        e.FormattingApplied = true; // marca formato aplicado
                    }
                    else
                    {
                        e.Value = PlaceholderImagen(); // si no existe mostramos placeholder
                        e.FormattingApplied = true; // marca formato aplicado
                    }
                }
                catch
                {
                    e.Value = PlaceholderImagen(); // evita que se caiga si falla la carga
                    e.FormattingApplied = true; // marca formato aplicado
                }
            }
        }

        private void DGVProductos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // suprime dialogo por errores de formato y pone placeholder en imagen
            e.ThrowException = false; // evita popup del datagridview
            if (e.RowIndex >= 0 && DGVProductos.Columns[e.ColumnIndex].Name == "Imagen")
            {
                DGVProductos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = PlaceholderImagen(); // asigna placeholder
            }
        }

        // ==================== acciones de grilla ====================

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // valida indices

            var col = DGVProductos.Columns[e.ColumnIndex]; // obtiene columna clickeada
            bool esEditar = col.Name.Equals("Editar", StringComparison.OrdinalIgnoreCase);   // detecta boton editar
            bool esEliminar = col.Name.Equals("Eliminar", StringComparison.OrdinalIgnoreCase); // detecta boton eliminar
            if (!esEditar && !esEliminar) return; // ignora si no es boton

            // intenta obtener id de forma robusta
            int id = 0; object raw = null; // inicializa
            if (DGVProductos.Columns.Contains("ID")) raw = DGVProductos.Rows[e.RowIndex].Cells["ID"].Value; // lee celda id
            if ((raw == null || raw == DBNull.Value) && DGVProductos.Rows[e.RowIndex].DataBoundItem is DataRowView drv && drv.Row.Table.Columns.Contains("id_producto"))
                raw = drv["id_producto"]; // fallback al datarow
            if ((raw == null || raw == DBNull.Value) && DGVProductos.Rows[e.RowIndex].Cells.Count > 0)
                raw = DGVProductos.Rows[e.RowIndex].Cells[0].Value; // ultimo fallback
            if (raw == null || !int.TryParse(raw.ToString(), out id))
            {
                MessageBox.Show("no se pudo obtener el id del producto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); // muestra aviso
                return;
            }

            if (esEditar)
            {
                using (var frm = new EditarProducto(id)) // abre editar con id
                {
                    var dr = frm.ShowDialog(this); // muestra modal
                    if (dr == DialogResult.OK) CargarProductos(); // recarga si guardo
                }
            }
            else // eliminar
            {
                var nombre = Convert.ToString(DGVProductos.Rows[e.RowIndex].Cells["Nombre"].Value); // toma nombre para mensaje
                var resp = MessageBox.Show($"confirmar eliminacion de \"{nombre}\" (id {id})", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question); // pide confirmacion
                if (resp != DialogResult.Yes) return; // cancela si no confirma

                try
                {
                    using (var cn = NuevaConexion()) // abre conexion
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE dbo.producto SET activo = 0, fecha_edicion = GETDATE() WHERE id_producto = @id"; // baja logica
                        cmd.Parameters.AddWithValue("@id", id); // pasa id
                        cn.Open(); // abre conexion
                        cmd.ExecuteNonQuery(); // ejecuta update
                    }

                    MessageBox.Show("producto eliminado", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information); // muestra exito
                    CargarProductos(); // recarga grilla solo con activos
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // muestra error
                }
            }
        }



        private void BNuevoproducto_Click(object sender, EventArgs e)
        {
            // abre formulario de alta
            using (var frm = new AgregarProducto()) // modo alta
            {
                var dr = frm.ShowDialog(this); // abre modal
                if (dr == DialogResult.OK) CargarProductos(); // recarga si creo producto
            }
        }

        // ==================== filtros: sugerencias y aplicacion ====================

        private void EnsureSuggestControls()
        {
            // crea panel y listbox una sola vez
            if (_suggestPanel != null) return; // ya existen
            _suggestPanel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false
            }; // crea panel contenedor
            _suggestList = new ListBox
            {
                IntegralHeight = false, // permite altura exacta
                Dock = DockStyle.Fill
            }; // crea listbox
            _suggestList.Click += SuggestList_Click; // seleccion con click
            _suggestList.KeyDown += SuggestList_KeyDown; // seleccion con enter
            _suggestPanel.Controls.Add(_suggestList); // agrega listbox al panel
            this.Controls.Add(_suggestPanel); // agrega panel al form
        }

        private void ShowSuggestions(TextBox target, DataTable data, string displayColumn)
        {
            // muestra popup debajo del textbox con hasta 4 visibles
            EnsureSuggestControls(); // se asegura de tener panel y listbox
            _suggestTarget = target; // guarda objetivo

            _suggestList.BeginUpdate(); // inicia actualizacion
            _suggestList.Items.Clear(); // limpia items
            foreach (DataRow r in data.Rows) _suggestList.Items.Add(Convert.ToString(r[displayColumn])); // carga items
            _suggestList.EndUpdate(); // termina actualizacion

            if (_suggestList.Items.Count == 0)
            {
                _suggestPanel.Visible = false; // oculta si no hay items
                return;
            }

            // calcula ubicacion debajo del textbox
            var screen = target.PointToScreen(new Point(0, target.Height)); // punto inferior izquierdo en screen
            var local = this.PointToClient(screen); // lo pasa a coords del form
            _suggestPanel.Location = local; // setea ubicacion
            _suggestPanel.Width = target.Width; // iguala ancho al textbox

            // altura para 4 filas como maximo
            int itemHeight = _suggestList.ItemHeight; // alto por item
            int visible = Math.Min(4, _suggestList.Items.Count); // visibles maximo 4
            _suggestPanel.Height = visible * itemHeight + 6; // ajusta altura con margen

            _suggestPanel.BringToFront(); // trae al frente
            _suggestPanel.Visible = true; // muestra panel
            _suggestList.SelectedIndex = -1; // sin seleccion inicial
        }

        private void HideSuggestions()
        {
            // oculta popup de sugerencias
            if (_suggestPanel != null) _suggestPanel.Visible = false; // oculta panel
        }

        private void SuggestList_Click(object sender, EventArgs e)
        {
            // coloca el item seleccionado en el textbox
            if (_suggestTarget != null && _suggestList.SelectedItem != null)
            {
                _suggestTarget.Text = _suggestList.SelectedItem.ToString(); // setea texto
                _suggestTarget.SelectionStart = _suggestTarget.Text.Length; // mueve caret al final
                HideSuggestions(); // oculta popup
            }
        }

        private void SuggestList_KeyDown(object sender, KeyEventArgs e)
        {
            // permite elegir con enter y cerrar con escape
            if (e.KeyCode == Keys.Enter)
            {
                SuggestList_Click(sender, EventArgs.Empty); // confirma seleccion
                e.Handled = true; // consume evento
            }
            else if (e.KeyCode == Keys.Escape)
            {
                HideSuggestions(); // oculta popup
                e.Handled = true; // consume evento
            }
        }

        private void InventarioForm_Click(object sender, EventArgs e)
        {
            // oculta popup al clickear fuera
            HideSuggestions(); // oculta popup
        }

        private void TBNombre_TextChanged(object sender, EventArgs e)
        {
            // muestra sugerencias por nombre cuando se escribe al menos un caracter
            try
            {
                string pref = TBNombre.Text?.Trim();
                if (string.IsNullOrEmpty(pref))
                {
                    HideSuggestions(); // oculta si no hay prefijo
                    return;
                }

                using (var cn = NuevaConexion())
                using (var da = new SqlDataAdapter(@"
                        SELECT DISTINCT TOP 50 nombre
                        FROM dbo.producto
                        WHERE activo = 1 AND nombre LIKE @p + '%'
                        ORDER BY nombre", cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@p", pref); // setea prefijo
                    var dt = new DataTable(); // crea tabla
                    da.Fill(dt); // llena tabla
                    ShowSuggestions(TBNombre, dt, "nombre"); // muestra popup
                }
            }
            catch
            {
                // silencia errores de sugerencia
            }
        }

        private void TBID_TextChanged(object sender, EventArgs e)
        {
            // muestra sugerencias por id cuando hay al menos un digito
            try
            {
                string pref = TBID.Text?.Trim();
                if (string.IsNullOrEmpty(pref))
                {
                    HideSuggestions(); // oculta si no hay prefijo
                    return;
                }

                using (var cn = NuevaConexion())
                using (var da = new SqlDataAdapter(@"
                        SELECT TOP 50 id_producto
                        FROM dbo.producto
                        WHERE activo = 1 AND CAST(id_producto AS varchar(20)) LIKE @p + '%'
                        ORDER BY id_producto", cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@p", pref); // setea prefijo
                    var dt = new DataTable(); // crea tabla
                    da.Fill(dt); // llena tabla
                    ShowSuggestions(TBID, dt, "id_producto"); // muestra popup
                }
            }
            catch
            {
                // silencia errores de sugerencia
            }
        }

        private void TBID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // restringe a numeros y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true; // bloquea caracter no numerico
        }

        private void BAplicarFiltrosProductos_Click(object sender, EventArgs e)
        {
            // aplica filtros usando los valores ingresados
            string fNombre = string.IsNullOrWhiteSpace(TBNombre.Text) ? null : TBNombre.Text.Trim(); // toma nombre
            int? fId = null; // id nullable
            if (int.TryParse(TBID.Text?.Trim(), out int idVal)) fId = idVal; // convierte id si corresponde

            int? fCat = null; // categoria nullable
            if (CBGenero.SelectedValue != null && int.TryParse(CBGenero.SelectedValue.ToString(), out int catVal))
                fCat = catVal; // convierte categoria si corresponde

            string ordenCode = (CBOrden.SelectedItem as SortOption)?.Code; // toma codigo de orden

            CargarProductos(fNombre, fId, fCat, ordenCode); // recarga con filtros
            HideSuggestions(); // oculta popup
        }

        private void BLimpiarFiltrosProductos_Click(object sender, EventArgs e)
        {
            // limpia todos los filtros y recarga
            TBNombre.Clear(); // limpia nombre
            TBID.Clear(); // limpia id
            CBGenero.SelectedIndex = -1; // limpia genero
            CBOrden.SelectedIndex = -1; // limpia orden
            HideSuggestions(); // oculta popup
            CargarProductos(); // recarga sin filtros
        }

        private void BVerSoloStockBajo_Click(object sender, EventArgs e)
        {
            // arma filtros actuales para respetar lo que ya eligio el usuario
            string fNombre = string.IsNullOrWhiteSpace(TBNombre.Text) ? null : TBNombre.Text.Trim(); // toma nombre si hay
            int? fId = null; // id nullable
            if (int.TryParse(TBID.Text?.Trim(), out int idVal)) fId = idVal; // convierte id si corresponde

            int? fCat = null; // categoria nullable
            if (CBGenero.SelectedValue != null && int.TryParse(CBGenero.SelectedValue.ToString(), out int catVal))
                fCat = catVal; // toma categoria si hay

            // refleja en el combo de orden que se eligio stock bajo
            if (CBOrden.DataSource != null)
                CBOrden.SelectedValue = "STOCK_LOW"; // marca opcion en combo

            // carga solo productos con stock menor o igual al umbral y los ordena ascendente por stock
            CargarProductos(fNombre, fId, fCat, "STOCK_LOW"); // aplica filtro de stock bajo
            HideSuggestions(); // oculta popup de sugerencias si estaba abierto
        }


        // ==================== resumen tablero ====================

        private void ActualizarResumenInventario()
        {
            // calcula productos totales, stock total y cuantos tienen stock bajo y actualiza los labels
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
                    cmd.Parameters.AddWithValue("@u", UMBRAL_STOCK_BAJO); // pasa umbral
                    cn.Open(); // abre conexion

                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            int productosTotales = Convert.ToInt32(rd["productos_totales"]); // total productos
                            int stockTotal = Convert.ToInt32(rd["stock_total"]); // total unidades
                            int conStockBajo = Convert.ToInt32(rd["stock_bajo"]); // productos con stock bajo

                            KpiTotal.Text = productosTotales.ToString(); // actualiza kpi total
                            KpiStock.Text = stockTotal.ToString();       // actualiza kpi stock
                            KpiBajo.Text = conStockBajo.ToString();     // actualiza kpi bajo

                            // reemplaza los ... por el numero real en el banner
                            var txt = LAvisoStockBajo.Text ?? "";
                            if (txt.Contains("..."))
                                LAvisoStockBajo.Text = txt.Replace("...", conStockBajo.ToString()); // reemplaza puntitos
                            else
                                LAvisoStockBajo.Text = $"Tienes {conStockBajo} productos con stock bajo. Es recomendable reabastecer estos productos"; // setea texto por defecto
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al actualizar resumen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // muestra error
            }
        }

        // ====== stubs autogenerados por el disenador ======
        // estos metodos existen solo para que compile porque hay eventos conectados en el .designer

        private void TLRoot_Paint(object sender, PaintEventArgs e)
        {
            // evento paint autogenerado por el disenador
        }

        private void LProductostotales_Click(object sender, EventArgs e)
        {
            // click de label autogenerado por el disenador
        }

        private void LUnidadeseninventario_Click(object sender, EventArgs e)
        {
            // click de label autogenerado por el disenador
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // click de label autogenerado por el disenador
        }

        private void PFilters_Paint(object sender, PaintEventArgs e)
        {
            // evento paint autogenerado por el disenador
        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {
            // evento paint autogenerado por el disenador
        }

        private void TBID_TextChanged_old(object sender, EventArgs e) { } // placeholder si el diseñador estuviera apuntando a otro metodo

        private void TBID_KeyPress_old(object sender, KeyPressEventArgs e) { } // placeholder idem

        private void label1_Click(object sender, EventArgs e)
        {
            // click de label autogenerado por el disenador
        }

        private void BAplicarFiltrosProducto_Click(object sender, EventArgs e)
        {

        }
    }
}
