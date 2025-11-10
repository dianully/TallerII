using System;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;

namespace PuntoDeVentaGameBox.Gerente
{
    public partial class VerProducto : Form
    {
        private readonly string _connString =
            "Server=localhost;Database=game_box;Trusted_Connection=True;TrustServerCertificate=True";

        private readonly int _idProducto;

        // === IMÁGENES (carpeta del proyecto local) ===
        private static readonly string REPO_IMG_REL = @"ImagenesProductos";
        private static readonly string REPO_IMG_DIR =
            Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..", REPO_IMG_REL));

        public VerProducto(int idProducto)
        {
            InitializeComponent();
            _idProducto = idProducto;

            if (BEditar != null) { BEditar.Click -= BEditar_Click; BEditar.Click += BEditar_Click; }
            if (BSalir != null) { BSalir.Click -= BSalir_Click; BSalir.Click += BSalir_Click; }

            // Evento de carga correcto
            this.Load -= VerProducto_Load;
            this.Load += VerProducto_Load;

            SetTextBoxesReadOnlyRecursive(this, true);
        }

        private void VerProducto_Load(object sender, EventArgs e)
        {
            CargarProducto(_idProducto);
        }

        private SqlConnection NuevaConexion() => new SqlConnection(_connString);

        private void SetTextBoxesReadOnlyRecursive(Control root, bool state)
        {
            foreach (Control c in root.Controls)
            {
                if (c is TextBox tb)
                {
                    tb.ReadOnly = state;
                    tb.ShortcutsEnabled = !state ? true : false;
                    tb.TabStop = false;
                    tb.BackColor = SystemColors.ControlLight;
                    tb.ContextMenu = new ContextMenu();
                }
                if (c.HasChildren) SetTextBoxesReadOnlyRecursive(c, state);
            }
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

        private void CargarProducto(int id)
        {
            try
            {
                using (var cn = NuevaConexion())
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT
                            p.nombre,
                            p.descripcion,
                            p.precio_venta,
                            p.cantidad_stock,
                            p.url_imagen,
                            p.fecha_alta,
                            p.fecha_edicion,
                            pr.nombre AS proveedor,
                            (
                                SELECT STRING_AGG(c.nombre, ', ') WITHIN GROUP(ORDER BY c.nombre)
                                FROM dbo.producto_categoria pc
                                JOIN dbo.categoria c ON c.id_categoria = pc.id_categoria
                                WHERE pc.id_producto = p.id_producto
                            ) AS generos
                        FROM dbo.producto p
                        LEFT JOIN dbo.proveedor pr ON pr.id_proveedor = p.id_proveedor
                        WHERE p.id_producto = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (!rd.Read())
                        {
                            MessageBox.Show("Producto no encontrado", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // === Carga de datos ===
                        TBNombreProducto.Text = rd["nombre"]?.ToString();
                        TBDescripcionProducto.Text = rd["descripcion"]?.ToString();
                        TBPrecioVentaProducto.Text = rd["precio_venta"] == DBNull.Value ? "" :
                            Convert.ToDecimal(rd["precio_venta"]).ToString("0.##");
                        TBCantidadProducto.Text = rd["cantidad_stock"]?.ToString();
                        TBProveedor.Text = rd["proveedor"]?.ToString();
                        TBGenero.Text = rd["generos"] == DBNull.Value ? "" : rd["generos"].ToString();

                        TBFechaAlta.Text = rd["fecha_alta"] == DBNull.Value
                            ? ""
                            : Convert.ToDateTime(rd["fecha_alta"]).ToString("yyyy-MM-dd");

                        TBUltimaActualizacion.Text = rd["fecha_edicion"] == DBNull.Value
                            ? ""
                            : Convert.ToDateTime(rd["fecha_edicion"]).ToString("yyyy-MM-dd");

                        // === Carga de imagen ===
                        string rutaBd = rd["url_imagen"]?.ToString();
                        string rutaLocal = Path.Combine(REPO_IMG_DIR, $"producto{id}.jpg");

                        if (File.Exists(rutaLocal))
                        {
                            PBImagenProducto.Image = Image.FromFile(rutaLocal);
                        }
                        else if (!string.IsNullOrWhiteSpace(rutaBd) && File.Exists(rutaBd))
                        {
                            PBImagenProducto.Image = Image.FromFile(rutaBd);
                        }
                        else
                        {
                            PBImagenProducto.Image = PlaceholderImagen();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar producto: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BEditar_Click(object sender, EventArgs e)
        {
            using (var frm = new EditarProducto(_idProducto))
            {
                var dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    // Recarga los datos actualizados
                    CargarProducto(_idProducto);
                }
            }
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ==== Stubs requeridos por el diseñador (sin lógica) ====
        private void PEditar_Paint(object sender, PaintEventArgs e) { }
        // Compatibilidad con el nombre viejo que quedó en el diseñador
        // === Compatibilidad con el evento antiguo del diseñador ===
        private void Form1_Load(object sender, EventArgs e)
        {
            // Redirige al nuevo método de carga real
            VerProducto_Load(sender, e);
        }

    }
}
