using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PuntoDeVentaGameBox.Gerente
{
    public partial class VerProveedor : Form
    {
        // usa cadena fija como en el resto del proyecto
        private readonly string _connString =
            "Server=localhost;Database=game_box;Trusted_Connection=True;TrustServerCertificate=True";
        private readonly int _idProveedor; // id que viene desde la grilla

        // ctor para uso normal pasando el id del proveedor
        public VerProveedor(int idProveedor)
        {
            InitializeComponent();
            _idProveedor = idProveedor;

            // deja cajas en solo lectura
            SoloLectura();

            // wire de botones
            BEditar.Click -= TBEditar_Click;
            BEditar.Click += TBEditar_Click;

            BSalir.Click -= TBSalir_Click;
            BSalir.Click += TBSalir_Click;

            // carga datos al iniciar
            this.Load -= VerProveedor_Load;
            this.Load += VerProveedor_Load;
        }

        // ctor de seguridad (no usar)
        public VerProveedor() : this(idProveedor: 0) { }

        private SqlConnection NuevaConexion() => new SqlConnection(_connString);

        private void VerProveedor_Load(object sender, EventArgs e)
        {
            if (_idProveedor <= 0)
            {
                MessageBox.Show("no se indico proveedor a ver", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            CargarProveedor(_idProveedor);
        }

        private void SoloLectura()
        {
            if (TBNombre != null) TBNombre.ReadOnly = true;
            if (TBTelefono != null) TBTelefono.ReadOnly = true;
            if (TBCorreo != null) TBCorreo.ReadOnly = true;
            if (TBDireccion != null) TBDireccion.ReadOnly = true;
            if (TBFechaCreacion != null) TBFechaCreacion.ReadOnly = true;
            if (TBUltimaActualizacion != null) TBUltimaActualizacion.ReadOnly = true;
        }

        private void CargarProveedor(int idProveedor)
        {
            try
            {
                using (var cn = NuevaConexion())
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT 
                            p.nombre,
                            p.telefono,
                            p.email      AS correo,
                            p.direccion,
                            p.fecha_alta,
                            p.fecha_edicion
                        FROM dbo.proveedor p
                        WHERE p.id_proveedor = @id";

                    cmd.Parameters.AddWithValue("@id", idProveedor);
                    cn.Open();

                    using (var rd = cmd.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (!rd.Read())
                        {
                            MessageBox.Show("no se encontro el proveedor", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                            return;
                        }

                        TBNombre.Text = rd["nombre"]?.ToString() ?? "";
                        TBTelefono.Text = rd["telefono"] == DBNull.Value ? "" : rd["telefono"].ToString();
                        TBCorreo.Text = rd["correo"]?.ToString() ?? "";
                        TBDireccion.Text = rd["direccion"]?.ToString() ?? "";

                        TBFechaCreacion.Text = rd["fecha_alta"] == DBNull.Value
                            ? ""
                            : Convert.ToDateTime(rd["fecha_alta"]).ToString("yyyy-MM-dd");

                        TBUltimaActualizacion.Text = rd["fecha_edicion"] == DBNull.Value
                            ? ""
                            : Convert.ToDateTime(rd["fecha_edicion"]).ToString("yyyy-MM-dd");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al cargar proveedor: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TBEditar_Click(object sender, EventArgs e)
        {
            using (var frm = new EditarProveedor(_idProveedor))
            {
                var dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    // se recarga y verás la nueva fecha en TBUltimaActualizacion
                    CargarProveedor(_idProveedor);
                }
            }
        }

        private void TBSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PBaseAzul_Paint(object sender, PaintEventArgs e)
        {
            // sin uso
        }
    }
}
