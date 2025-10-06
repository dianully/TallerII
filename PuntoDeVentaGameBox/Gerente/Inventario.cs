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
            BNuevoProducto.Click += BNuevoproducto_Click; // abre formulario de alta
        }

        private void InventarioForm_Load(object sender, EventArgs e)
        {
            // prepara columnas exactas y carga datos desde la base
            PrepararColumnas(); // define columnas manuales y orden
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

        private void CargarProductos(string filtroNombre = null, int? filtroId = null, int? filtroCategoria = null)
        {
            // lee productos activos con join a categoria para traer el nombre del genero
            try
            {
                using (var cn = NuevaConexion()) // abre la conexion con la base de datos
                using (var da = new SqlDataAdapter())
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"
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
                        ORDER BY p.id_producto DESC"; // consulta con join y filtros

                    cmd.Parameters.AddWithValue("@nom", (object)filtroNombre ?? DBNull.Value); // parametro nombre
                    cmd.Parameters.AddWithValue("@like", filtroNombre == null ? (object)DBNull.Value : $"%{filtroNombre}%"); // parametro like
                    cmd.Parameters.AddWithValue("@id", (object)filtroId ?? DBNull.Value); // parametro id
                    cmd.Parameters.AddWithValue("@cat", (object)filtroCategoria ?? DBNull.Value); // parametro categoria

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

                    // si es http o https no intentamos descargar, usamos placeholder
                    if (ruta.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                        ruta.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                    {
                        e.Value = PlaceholderImagen(); // usa placeholder para urls remotas
                        e.FormattingApplied = true; // marca formato aplicado
                        return;
                    }

                    // si el archivo existe lo cargamos
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
            // maneja clicks en los botones editar y eliminar
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // valida indices

            var col = DGVProductos.Columns[e.ColumnIndex]; // toma columna clickeada
            bool esEditar = col.Name.Equals("Editar", StringComparison.OrdinalIgnoreCase); // detecta boton editar
            bool esEliminar = col.Name.Equals("Eliminar", StringComparison.OrdinalIgnoreCase); // detecta boton eliminar
            if (!esEditar && !esEliminar) return; // ignora si no es boton

            var id = Convert.ToInt32(DGVProductos.Rows[e.RowIndex].Cells["ID"].Value); // toma id seleccionado

            if (esEditar)
            {
                // abre la vista de edicion como antes
                using (var frm = new EditarProducto()) // si tu editar recibe id cambia a new EditarProducto(id)
                {
                    frm.ShowDialog(this); // abre modal
                }
            }
            else if (esEliminar)
            {
                // por ahora solo mostramos la vista de confirmacion
                var nombre = Convert.ToString(DGVProductos.Rows[e.RowIndex].Cells["Nombre"].Value); // toma nombre del producto
                MessageBox.Show($"se mostraria la vista de eliminar para \"{nombre}\" (id {id})", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information); // muestra vista mock
                // cuando quieras hacer baja logica aca reemplazamos por update a activo=0 y recarga
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

        // ==================== resumen tablero ====================

        private void ActualizarResumenInventario()
        {
            // calcula productos totales, stock total y cuantos tienen stock bajo y actualiza los labels que me diste
            try
            {
                using (var cn = NuevaConexion()) // abre conexion
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT
                            COUNT(*)                                 AS productos_totales,
                            ISNULL(SUM(p.cantidad_stock), 0)         AS stock_total,
                            SUM(CASE WHEN p.cantidad_stock <= @u THEN 1 ELSE 0 END) AS stock_bajo
                        FROM dbo.producto p
                        WHERE p.activo = 1"; // consulta agregada sobre activos

                    cmd.Parameters.AddWithValue("@u", UMBRAL_STOCK_BAJO); // pasa umbral
                    cn.Open(); // abre conexion

                    using (var rd = cmd.ExecuteReader()) // ejecuta lector
                    {
                        if (rd.Read())
                        {
                            int productosTotales = Convert.ToInt32(rd["productos_totales"]); // toma total de productos
                            int stockTotal = Convert.ToInt32(rd["stock_total"]); // toma suma de stock
                            int conStockBajo = Convert.ToInt32(rd["stock_bajo"]); // toma cantidad con stock bajo

                            // actualiza directamente los labels provistos
                            KpiTotal.Text = productosTotales.ToString(); // pone numero en productos totales
                            KpiStock.Text = stockTotal.ToString();       // pone numero en total stock
                            KpiBajo.Text = conStockBajo.ToString();     // pone numero en con stock bajo

                            // reemplaza los tres puntitos por el valor en el banner
                            var txt = LAvisoStockBajo.Text ?? ""; // toma texto actual
                            if (txt.Contains("..."))
                                LAvisoStockBajo.Text = txt.Replace("...", conStockBajo.ToString()); // reemplaza puntitos por numero
                            else
                                LAvisoStockBajo.Text = $"Tienes {conStockBajo} productos con stock bajo. Es recomendable reabastecer estos productos."; // setea texto si no estaba
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

        private void TBID_TextChanged(object sender, EventArgs e)
        {
            // cambio de texto autogenerado por el disenador
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // click de label autogenerado por el disenador
        }
    }
}
