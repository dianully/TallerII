using System;
using System.Data.SqlClient;
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
        }

        public AgregarProducto(int idProducto)
        {
            InitializeComponent();
            _idEditar = idProducto; // modo edicion
            BRegistrarProducto.Text = "Guardar Cambios"; // texto de edicion
            WireEventos(); // vincula eventos
            CargarProducto(idProducto); // carga datos del producto
        }

        private SqlConnection NuevaConexion() => new SqlConnection(_connString); // crea conexion sql

        private void WireEventos()
        {
            // limpia handlers viejos del diseñador
            BRegistrarProducto.Click -= BAbrirImagen_Click;  // evita que registrar abra el explorador
            BRegistrarProducto.Click -= bBuscar_Click;       // desengancha handler viejo si estaba
            BAbrirImagen.Click -= bBuscar_Click;        // evita doble wiring en abrir imagen

            // engancha handlers correctos
            BAbrirImagen.Click -= BAbrirImagen_Click;   // evita doble suscripcion
            BAbrirImagen.Click += BAbrirImagen_Click;   // abre explorador para imagen

            BRegistrarProducto.Click -= BRegistrarProducto_Click; // evita doble suscripcion
            BRegistrarProducto.Click += BRegistrarProducto_Click; // guarda alta o edicion
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
                    PBImagenProducto.ImageLocation = ofd.FileName; // muestra imagen en picturebox
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
                               fecha_alta, fecha_edicion, id_proveedor, id_categoria
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
                            TBFechaAltaProducto.Text = rd["fecha_alta"]?.ToString(); // llena fecha alta
                            TBFechaEdicionProducto.Text = rd["fecha_edicion"]?.ToString(); // llena fecha edicion
                            TBProveedorProducto.Text = rd["id_proveedor"]?.ToString(); // llena proveedor
                            TBGeneroProducto.Text = rd["id_categoria"]?.ToString(); // llena categoria

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

        private bool ValidarFormulario(out decimal precio, out int stock, out int? prov, out int? cat)
        {
            // valida datos obligatorios y parsea numericos
            precio = 0m; stock = 0; prov = null; cat = null; // inicializa variables

            if (string.IsNullOrWhiteSpace(TBNombreProducto.Text))
            {
                MessageBox.Show("nombre es obligatorio", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning); // valida nombre
                return false;
            }

            if (!decimal.TryParse(TBPrecioVentaProducto.Text, out precio) || precio < 0)
            {
                MessageBox.Show("precio debe ser numero y mayor o igual a 0", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning); // valida precio
                return false;
            }

            if (!int.TryParse(TBCantidadProducto.Text, out stock) || stock < 0)
            {
                MessageBox.Show("stock debe ser entero y mayor o igual a 0", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning); // valida stock
                return false;
            }

            // proveedor ahora se ingresa por nombre, no validamos entero aca

            if (!string.IsNullOrWhiteSpace(TBGeneroProducto.Text))
            {
                if (int.TryParse(TBGeneroProducto.Text, out var g)) cat = g;
                else
                {
                    MessageBox.Show("genero debe ser entero", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning); // valida categoria
                    return false;
                }
            }

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

                    // resuelve proveedor por nombre o id
                    var provId = ResolverProveedorId(cn, TBProveedorProducto.Text); // resuelve id proveedor

                    cmd.CommandText = @"
                INSERT INTO dbo.producto
                    (nombre, descripcion, precio_venta, cantidad_stock, url_imagen, fecha_alta, fecha_edicion, id_proveedor, id_categoria, activo)
                VALUES
                    (@nombre, @descripcion, @precio, @stock, @img, GETDATE(), NULL, @prov, @cat, 1)"; // insert parametrizado

                    cmd.Parameters.AddWithValue("@nombre", TBNombreProducto.Text.Trim()); // setea nombre
                    cmd.Parameters.AddWithValue("@descripcion", (object)TBDescripcionProducto.Text.Trim() ?? DBNull.Value); // setea descripcion
                    cmd.Parameters.AddWithValue("@precio", precio); // setea precio
                    cmd.Parameters.AddWithValue("@stock", stock); // setea stock
                    cmd.Parameters.AddWithValue("@img", string.IsNullOrWhiteSpace(TBDireccionImagen.Text) ? (object)DBNull.Value : TBDireccionImagen.Text.Trim()); // setea imagen
                    cmd.Parameters.AddWithValue("@prov", (object)provId ?? DBNull.Value); // setea proveedor resuelto
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

                    var provId = ResolverProveedorId(cn, TBProveedorProducto.Text); // resuelve id proveedor

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
                    cmd.Parameters.AddWithValue("@descripcion", (object)TBDescripcionProducto.Text.Trim() ?? DBNull.Value); // setea descripcion
                    cmd.Parameters.AddWithValue("@precio", precio); // setea precio
                    cmd.Parameters.AddWithValue("@stock", stock); // setea stock
                    cmd.Parameters.AddWithValue("@img", string.IsNullOrWhiteSpace(TBDireccionImagen.Text) ? (object)DBNull.Value : TBDireccionImagen.Text.Trim()); // setea imagen
                    cmd.Parameters.AddWithValue("@prov", (object)provId ?? DBNull.Value); // setea proveedor resuelto
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
        // ====== STUBS AUTOGENERADOS POR EL DISENADOR ======
        // estos metodos existen solo para que compile porque hay eventos conectados en el .Designer
        // podes dejarlos vacios o redirigirlos a handlers reales

        private void AgregarProducto_Load(object sender, EventArgs e)
        {
            // evento load autogenerado por el disenador
            // no hacemos nada aca porque el flujo real lo manejamos en los constructores
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // click de un boton autogenerado por el disenador
            // cierro por si era el boton salir
            this.Close(); // cierra el formulario si corresponde
        }

        private void bBuscar_Click(object sender, EventArgs e)
        {
            // viejo handler de buscar imagen
            // reutilizo el handler nuevo para abrir imagen
            BAbrirImagen_Click(sender, e); // invoca el handler real de abrir imagen
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            // evento paint autogenerado por el disenador
            // no hacemos nada aca
        }

        private void label9_Click(object sender, EventArgs e)
        {
            // click de label autogenerado por el disenador
            // no hacemos nada aca
        }

        private int? ResolverProveedorId(SqlConnection cn, string valor)
        {
            // resuelve id_proveedor a partir de un texto que puede ser id o nombre
            // si no existe proveedor con ese nombre lo crea y devuelve su id

            // si viene vacio devolvemos null
            if (string.IsNullOrWhiteSpace(valor)) return null; // sin proveedor

            // si ponen un numero y existe ese id lo usamos
            if (int.TryParse(valor.Trim(), out var idPosible))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(1) FROM dbo.proveedor WHERE id_proveedor = @id";
                    cmd.Parameters.AddWithValue("@id", idPosible);
                    var existe = (int)cmd.ExecuteScalar() > 0; // consulta existencia
                    if (existe) return idPosible; // usa id existente
                }
                // si no existe, seguimos como si fuera nombre
            }

            var nombre = valor.Trim(); // toma nombre

            // buscamos por nombre
            using (var cmd = cn.CreateCommand())
            {
                cmd.CommandText = "SELECT TOP 1 id_proveedor FROM dbo.proveedor WHERE nombre = @nom ORDER BY id_proveedor";
                cmd.Parameters.AddWithValue("@nom", nombre);
                var found = cmd.ExecuteScalar();
                if (found != null && found != DBNull.Value) return Convert.ToInt32(found); // devuelve id encontrado
            }

            // si no existe lo creamos con campos minimos
            using (var cmd = cn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO dbo.proveedor(nombre)
                    VALUES(@nom);
                    SELECT CAST(SCOPE_IDENTITY() AS int);";
                cmd.Parameters.AddWithValue("@nom", nombre);
                var nuevoId = (int)cmd.ExecuteScalar(); // crea proveedor y devuelve id
                return nuevoId; // devuelve id nuevo
            }
        }

    }

}

