using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System.Net;

namespace PuntoDeVentaGameBox.Gerente
{
    public partial class Form1 : Form
    {
        private readonly string _connString =
            "Server=localhost;Database=game_box;Trusted_Connection=True;TrustServerCertificate=True";

        private readonly int _idProducto;

        public Form1(int idProducto)
        {
            InitializeComponent();
            _idProducto = idProducto;

            if (BEditar != null)
            {
                BEditar.Click -= BEditar_Click;
                BEditar.Click += BEditar_Click;
            }
            if (BSalir != null)
            {
                BSalir.Click -= BSalir_Click;
                BSalir.Click += BSalir_Click;
            }

            // Asegura que el PictureBox use Zoom siempre
            if (PBImagenProducto != null)
                PBImagenProducto.SizeMode = PictureBoxSizeMode.Zoom;

            SetTextBoxesReadOnlyRecursive(this, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarProducto(_idProducto);
        }

        private SqlConnection NuevaConexion() => new SqlConnection(_connString);

        // ---- Bloqueo de edición en todos los TextBox ----
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

                    tb.KeyPress -= TextBox_BlockInput_KeyPress;
                    if (state) tb.KeyPress += TextBox_BlockInput_KeyPress;

                    tb.ContextMenu = new ContextMenu();
                }

                if (c.HasChildren)
                    SetTextBoxesReadOnlyRecursive(c, state);
            }
        }

        private void TextBox_BlockInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)) e.Handled = true;
        }

        // ===== Helpers de imágenes =====

        private static Image Placeholder()
        {
            // mini placeholder gris con X
            var bmp = new Bitmap(256, 256);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.LightGray);
                using (var p = new Pen(Color.DarkGray, 6))
                {
                    g.DrawRectangle(p, 6, 6, bmp.Width - 12, bmp.Height - 12);
                    g.DrawLine(p, 40, 40, bmp.Width - 40, bmp.Height - 40);
                    g.DrawLine(p, bmp.Width - 40, 40, 40, bmp.Height - 40);
                }
            }
            return bmp;
        }

        private static Image ImageFromBytes(byte[] data)
        {
            if (data == null || data.Length == 0) return null;
            try
            {
                using (var ms = new MemoryStream(data))
                using (var tmp = Image.FromStream(ms))
                {
                    return new Bitmap(tmp);
                }
            }
            catch { return null; }
        }

        private static byte[] DescargarUrlBytes(string url)
        {
            try
            {
                ServicePointManager.SecurityProtocol =
                    SecurityProtocolType.Tls12 | (SecurityProtocolType)12288; // incluye Tls13 si está

                var req = (HttpWebRequest)WebRequest.Create(url);
                req.AllowAutoRedirect = true;
                req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120 Safari/537.36";
                req.Accept = "image/avif,image/webp,image/apng,image/*,*/*;q=0.8";
                req.Referer = "https://unsplash.com/";

                using (var resp = (HttpWebResponse)req.GetResponse())
                using (var respStream = resp.GetResponseStream())
                using (var ms = new MemoryStream())
                {
                    respStream.CopyTo(ms);
                    var bytes = ms.ToArray();

                    // Validación rápida: si no es image/* igual intentamos decodificar
                    var ct = resp.ContentType?.ToLowerInvariant() ?? "";
                    if (!ct.StartsWith("image/"))
                    {
                        try
                        {
                            using (var ims = new MemoryStream(bytes))
                            using (var img = Image.FromStream(ims)) { /* ok */ }
                        }
                        catch { return null; }
                    }

                    return bytes;
                }
            }
            catch { return null; }
        }

        private bool GuardarImagenEnBD(int idProducto, byte[] data)
        {
            try
            {
                if (data == null || data.Length == 0) return false;
                using (var cn = NuevaConexion())
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE dbo.producto SET imagen = @img, fecha_edicion = GETDATE() WHERE id_producto = @id";
                    cmd.Parameters.Add("@img", SqlDbType.VarBinary, -1).Value = data;
                    cmd.Parameters.AddWithValue("@id", idProducto);
                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch { return false; }
        }

        /// <summary>
        /// Devuelve (Image img, byte[] bytes) desde una ruta local o URL.
        /// No tira excepción (maneja placeholders).
        /// </summary>
        private (Image img, byte[] bytes) CargarDesdeRutaOUrl(string ruta)
        {
            if (string.IsNullOrWhiteSpace(ruta))
                return (null, null);

            try
            {
                // URL
                if (ruta.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                    ruta.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                {
                    var bytes = DescargarUrlBytes(ruta);
                    if (bytes != null && bytes.Length > 0)
                    {
                        var img = ImageFromBytes(bytes);
                        if (img != null) return (img, bytes);
                    }
                    return (null, null);
                }

                // LOCAL
                if (File.Exists(ruta))
                {
                    var bytes = File.ReadAllBytes(ruta);
                    var img = ImageFromBytes(bytes);
                    if (img != null) return (img, bytes);
                }

                return (null, null);
            }
            catch
            {
                return (null, null);
            }
        }

        // ===== Carga de datos =====

        private void CargarProducto(int id)
        {
            try
            {
                using (var cn = NuevaConexion())
                using (var cmd = cn.CreateCommand())
                {
                    // Traemos también p.imagen (VARBINARY)
                    cmd.CommandText = @"
DECLARE @hasPuente BIT = CASE WHEN EXISTS(
    SELECT 1 FROM sys.tables WHERE name='producto_categoria' AND schema_id = SCHEMA_ID('dbo')
) THEN 1 ELSE 0 END;

IF @hasPuente = 1
BEGIN
    IF EXISTS (SELECT 1 FROM dbo.producto_categoria WHERE id_producto = @id)
    BEGIN
        SELECT
            p.nombre, p.descripcion, p.precio_venta, p.cantidad_stock,
            p.url_imagen, p.imagen, p.fecha_alta, p.fecha_edicion,
            pr.nombre AS proveedor,
            (SELECT STRING_AGG(c.nombre, ', ')
             FROM dbo.producto_categoria pc
             INNER JOIN dbo.categoria c ON c.id_categoria = pc.id_categoria
             WHERE pc.id_producto = p.id_producto) AS generos
        FROM dbo.producto p
        LEFT JOIN dbo.proveedor pr ON pr.id_proveedor = p.id_proveedor
        WHERE p.id_producto = @id;
    END
    ELSE
    BEGIN
        SELECT
            p.nombre, p.descripcion, p.precio_venta, p.cantidad_stock,
            p.url_imagen, p.imagen, p.fecha_alta, p.fecha_edicion,
            pr.nombre AS proveedor,
            c.nombre AS generos
        FROM dbo.producto p
        LEFT JOIN dbo.proveedor pr ON pr.id_proveedor = p.id_proveedor
        LEFT JOIN dbo.categoria  c ON c.id_categoria = p.id_categoria
        WHERE p.id_producto = @id;
    END
END
ELSE
BEGIN
    SELECT
        p.nombre, p.descripcion, p.precio_venta, p.cantidad_stock,
        p.url_imagen, p.imagen, p.fecha_alta, p.fecha_edicion,
        pr.nombre AS proveedor,
        c.nombre AS generos
    FROM dbo.producto p
    LEFT JOIN dbo.proveedor pr ON pr.id_proveedor = p.id_proveedor
    LEFT JOIN dbo.categoria  c ON c.id_categoria = p.id_categoria
    WHERE p.id_producto = @id;
END";
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

                        TBNombreProducto.Text = rd["nombre"]?.ToString();
                        TBDescripcionProducto.Text = rd["descripcion"]?.ToString();
                        TBPrecioVentaProducto.Text = rd["precio_venta"] == DBNull.Value ? "" :
                                                        Convert.ToDecimal(rd["precio_venta"]).ToString("0.##");
                        TBCantidadProducto.Text = rd["cantidad_stock"]?.ToString();
                        TBProveedor.Text = rd["proveedor"]?.ToString();

                        var generos = rd["generos"]?.ToString() ?? "";
                        TBGenero.Text = string.IsNullOrWhiteSpace(generos) ? "(Sin categorías)" : generos;

                        TBFechaAlta.Text = rd["fecha_alta"] == DBNull.Value
                            ? ""
                            : Convert.ToDateTime(rd["fecha_alta"]).ToString("yyyy-MM-dd");

                        TBUltimaActualizacion.Text = rd["fecha_edicion"] == DBNull.Value
                            ? ""
                            : Convert.ToDateTime(rd["fecha_edicion"]).ToString("yyyy-MM-dd");

                        var ruta = rd["url_imagen"]?.ToString();
                        TBDireccionImagen.Text = ruta; // siempre mostramos la ruta guardada (si existe)

                        // === Imagen prioridad: BD (varbinary) -> URL/Local -> Placeholder ===
                        byte[] bin = rd["imagen"] == DBNull.Value ? null : (byte[])rd["imagen"];
                        Image img = ImageFromBytes(bin);

                        if (img != null)
                        {
                            PBImagenProducto.Image = img;
                        }
                        else
                        {
                            // Si no hay binario, intentamos ruta/url
                            var (img2, bytes2) = CargarDesdeRutaOUrl(ruta);

                            if (img2 != null)
                            {
                                PBImagenProducto.Image = img2;

                                // Persistimos en BD para no depender más del archivo/Internet
                                if (bytes2 != null && bytes2.Length > 0)
                                {
                                    var ok = GuardarImagenEnBD(_idProducto, bytes2);
                                    if (ok)
                                    {
                                        // refrescamos fecha de edición en UI
                                        TBUltimaActualizacion.Text = DateTime.Now.ToString("yyyy-MM-dd");
                                    }
                                }
                            }
                            else
                            {
                                PBImagenProducto.Image = Placeholder();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar producto: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                PBImagenProducto.Image = Placeholder();
            }
        }

        private void BEditar_Click(object sender, EventArgs e)
        {
            using (var frm = new EditarProducto(_idProducto))
            {
                var dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    // refresca detalle
                    CargarProducto(_idProducto);

                    // intenta refrescar inventario si fue abierto desde allí
                    try
                    {
                        var inv = this.Owner as Form;
                        if (inv != null)
                        {
                            var mi = inv.GetType().GetMethod(
                                "CargarProductos",
                                BindingFlags.Instance | BindingFlags.NonPublic
                            );
                            if (mi != null)
                            {
                                object[] args = new object[] { null, null, null, null };
                                mi.Invoke(inv, args);
                            }
                        }
                    }
                    catch { /* silencio */ }
                }
            }
        }

        private void BSalir_Click(object sender, EventArgs e) => Close();
    }
}
