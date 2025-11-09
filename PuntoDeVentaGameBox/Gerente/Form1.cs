using System;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;

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

            // wire de botones
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

            // 🚫 Bloquear edición de todos los TextBox (recursivo)
            SetTextBoxesReadOnlyRecursive(this, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarProducto(_idProducto);
        }

        private SqlConnection NuevaConexion() => new SqlConnection(_connString);

        // ---- BLOQUEO TOTAL DE EDICIÓN (recursivo) ----
        private void SetTextBoxesReadOnlyRecursive(Control root, bool state)
        {
            foreach (Control c in root.Controls)
            {
                if (c is TextBox tb)
                {
                    tb.ReadOnly = state;
                    tb.ShortcutsEnabled = !state ? true : false; // evita pegar Ctrl+V
                    tb.TabStop = false;                          // no entra con TAB
                    tb.BackColor = SystemColors.ControlLight;    // tono "solo lectura"

                    // Captura de teclas para anular cualquier intento de escribir
                    tb.KeyPress -= TextBox_BlockInput_KeyPress;
                    if (state) tb.KeyPress += TextBox_BlockInput_KeyPress;

                    // También bloqueamos el menú contextual (pegar con mouse)
                    tb.ContextMenu = new ContextMenu(); // menú vacío
                }

                if (c.HasChildren)
                    SetTextBoxesReadOnlyRecursive(c, state);
            }
        }

        private void TextBox_BlockInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo teclas de control de navegación (no imprimibles)
            // Bloquea cualquier carácter "escribible"
            if (!char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        // -----------------------------------------------

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
                            c.nombre  AS genero
                        FROM dbo.producto p
                        LEFT JOIN dbo.proveedor pr ON pr.id_proveedor = p.id_proveedor
                        LEFT JOIN dbo.categoria  c ON c.id_categoria  = p.id_categoria
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

                        // Campos de texto
                        TBNombreProducto.Text = rd["nombre"]?.ToString();
                        TBDescripcionProducto.Text = rd["descripcion"]?.ToString();
                        TBPrecioVentaProducto.Text = rd["precio_venta"] == DBNull.Value ? "" :
                                                     Convert.ToDecimal(rd["precio_venta"]).ToString("0.##");
                        TBCantidadProducto.Text = rd["cantidad_stock"]?.ToString();
                        TBProveedor.Text = rd["proveedor"]?.ToString();
                        TBGenero.Text = rd["genero"]?.ToString();

                        // Fecha de alta (siempre cargada)
                        TBFechaAlta.Text = rd["fecha_alta"] == DBNull.Value
                            ? ""
                            : Convert.ToDateTime(rd["fecha_alta"]).ToString("yyyy-MM-dd");

                        // Última actualización (fecha_edicion)
                        TBUltimaActualizacion.Text = rd["fecha_edicion"] == DBNull.Value
                            ? ""
                            : Convert.ToDateTime(rd["fecha_edicion"]).ToString("yyyy-MM-dd");

                        // Imagen
                        var ruta = rd["url_imagen"]?.ToString();
                        TBDireccionImagen.Text = ruta;
                        PBImagenProducto.ImageLocation =
                            (!string.IsNullOrWhiteSpace(ruta) && File.Exists(ruta)) ? ruta : null;
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
                    // 1) Refrescar la vista de detalles (Form1)
                    CargarProducto(_idProducto);

                    // 2) Intentar refrescar el DGV del Inventario si Form1 fue abierto desde allí
                    try
                    {
                        var inv = this.Owner as Form; // puede ser InventarioForm
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
                    catch
                    {
                        // Silenciamos: si no estaba abierto desde InventarioForm, no pasa nada.
                    }
                }
            }
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
