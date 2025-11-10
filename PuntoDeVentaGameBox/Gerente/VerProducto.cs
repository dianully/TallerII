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

        public VerProducto(int idProducto)
        {
            InitializeComponent();
            _idProducto = idProducto;

            if (BEditar != null) { BEditar.Click -= BEditar_Click; BEditar.Click += BEditar_Click; }
            if (BSalir != null) { BSalir.Click -= BSalir_Click; BSalir.Click += BSalir_Click; }

            // bloquea edicion en todos los textbox
            SetTextBoxesReadOnlyRecursive(this, true);
        }

        private void VerProducto_Load(object sender, EventArgs e) => CargarProducto(_idProducto);

        // --- compatibilidad con el evento antiguo del diseñador ---
        private void Form1_Load(object sender, EventArgs e)
        {
            VerProducto_Load(sender, e); // redirige al evento actual
        }


        private SqlConnection NuevaConexion() => new SqlConnection(_connString);

        // bloquea edicion de forma recursiva
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
                if (c.HasChildren) SetTextBoxesReadOnlyRecursive(c, state);
            }
        }

        private void TextBox_BlockInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)) e.Handled = true;
        }

        private void CargarProducto(int id)
        {
            try
            {
                using (var cn = NuevaConexion())
                using (var cmd = cn.CreateCommand())
                {
                    // arma generos con string_agg directo en la consulta
                    cmd.CommandText = @"
                        select
                            p.nombre,
                            p.descripcion,
                            p.precio_venta,
                            p.cantidad_stock,
                            p.url_imagen,
                            p.fecha_alta,
                            p.fecha_edicion,
                            pr.nombre as proveedor,
                            (
                                select string_agg(c.nombre, ', ') within group(order by c.nombre)
                                from dbo.producto_categoria pc
                                join dbo.categoria c on c.id_categoria = pc.id_categoria
                                where pc.id_producto = p.id_producto
                            ) as generos
                        from dbo.producto p
                        left join dbo.proveedor pr on pr.id_proveedor = p.id_proveedor
                        where p.id_producto = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (!rd.Read())
                        {
                            MessageBox.Show("producto no encontrado", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        TBNombreProducto.Text = rd["nombre"]?.ToString();
                        TBDescripcionProducto.Text = rd["descripcion"]?.ToString();
                        TBPrecioVentaProducto.Text = rd["precio_venta"] == DBNull.Value ? "" :
                                                     Convert.ToDecimal(rd["precio_venta"]).ToString("0.##");
                        TBCantidadProducto.Text = rd["cantidad_stock"]?.ToString();
                        TBProveedor.Text = rd["proveedor"]?.ToString();

                        // trae todas las categorias separadas por comas
                        TBGenero.Text = rd["generos"] == DBNull.Value ? "" : rd["generos"].ToString();

                        TBFechaAlta.Text = rd["fecha_alta"] == DBNull.Value
                            ? ""
                            : Convert.ToDateTime(rd["fecha_alta"]).ToString("yyyy-MM-dd");

                        TBUltimaActualizacion.Text = rd["fecha_edicion"] == DBNull.Value
                            ? ""
                            : Convert.ToDateTime(rd["fecha_edicion"]).ToString("yyyy-MM-dd");

                        var ruta = rd["url_imagen"]?.ToString();
                        PBImagenProducto.ImageLocation =
                            (!string.IsNullOrWhiteSpace(ruta) && File.Exists(ruta)) ? ruta : null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al cargar producto: {ex.Message}", "Error",
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
                    CargarProducto(_idProducto);

                    // intenta refrescar el listado si este form fue abierto desde alli
                    try
                    {
                        var inv = this.Owner as Form;
                        if (inv != null)
                        {
                            var mi = inv.GetType().GetMethod(
                                "CargarProductos",
                                BindingFlags.Instance | BindingFlags.NonPublic
                            );
                            if (mi != null) mi.Invoke(inv, new object[] { null, null, null, null });
                        }
                    }
                    catch { }
                }
            }
        }

        private void BSalir_Click(object sender, EventArgs e) => this.Close();

        private void PEditar_Paint(object sender, PaintEventArgs e) { }
    }
}
