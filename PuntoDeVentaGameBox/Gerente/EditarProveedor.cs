using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PuntoDeVentaGameBox.Gerente
{
    public partial class EditarProveedor : Form
    {
        // usa cadena fija sin appconfig
        private readonly string _connString = "Server=localhost;Database=game_box;Trusted_Connection=True;TrustServerCertificate=True"; // cadena de conexion fija
        private readonly int? _idEditar; // guarda id a editar

        public EditarProveedor()
        {
            InitializeComponent();
            _idEditar = null; // sin id no se puede editar
            // wire por si se usa como modal vacio
            BGuardarCambiosProveedor.Click -= BGuardarCambiosProveedor_Click;
            BGuardarCambiosProveedor.Click += BGuardarCambiosProveedor_Click;

            // restricciones de teclado
            TBTelefono.KeyPress -= TBTelefono_KeyPress;
            TBTelefono.KeyPress += TBTelefono_KeyPress; // solo numeros
        }

        public EditarProveedor(int idProveedor)
        {
            InitializeComponent();
            _idEditar = idProveedor; // guarda id
            // wire boton guardar
            BGuardarCambiosProveedor.Click -= BGuardarCambiosProveedor_Click;
            BGuardarCambiosProveedor.Click += BGuardarCambiosProveedor_Click;

            // restricciones de teclado
            TBTelefono.KeyPress -= TBTelefono_KeyPress;
            TBTelefono.KeyPress += TBTelefono_KeyPress; // solo numeros

            // carga datos
            CargarProveedor(idProveedor);
        }

        private SqlConnection NuevaConexion() => new SqlConnection(_connString); // crea conexion sql

        private void TBTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // solo numeros y control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true; // bloquea caracter no numerico
        }

        private void CargarProveedor(int id)
        {
            // trae datos de proveedor y llena controles
            try
            {
                using (var cn = NuevaConexion())
                using (var da = new SqlDataAdapter(@"SELECT nombre, telefono, email, direccion FROM dbo.proveedor WHERE id_proveedor = @id", cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@id", id);
                    var dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("proveedor no encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    var r = dt.Rows[0];
                    TBNombre.Text = Convert.ToString(r["nombre"]);
                    TBTelefono.Text = r["telefono"] == DBNull.Value ? "" : Convert.ToString(r["telefono"]);
                    TBCorreo.Text = r["email"] == DBNull.Value ? "" : Convert.ToString(r["email"]);
                    TBDireccion.Text = r["direccion"] == DBNull.Value ? "" : Convert.ToString(r["direccion"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al cargar proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarFormulario()
        {
            // nombre requerido
            if (string.IsNullOrWhiteSpace(TBNombre.Text))
            {
                MessageBox.Show("nombre es obligatorio", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // telefono numerico si existe
            if (!string.IsNullOrWhiteSpace(TBTelefono.Text) && !long.TryParse(TBTelefono.Text, out _))
            {
                MessageBox.Show("telefono debe ser numerico", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // correo con patron simple si existe
            if (!string.IsNullOrWhiteSpace(TBCorreo.Text))
            {
                var re = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                if (!re.IsMatch(TBCorreo.Text.Trim()))
                {
                    MessageBox.Show("correo no tiene formato valido", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true; // validaciones ok
        }

        private void BGuardarCambiosProveedor_Click(object sender, EventArgs e)
        {
            // guarda cambios con validaciones
            if (_idEditar == null)
            {
                MessageBox.Show("no se indico proveedor a editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarFormulario()) return;

            try
            {
                using (var cn = NuevaConexion())
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE dbo.proveedor
                        SET nombre = @n, telefono = @t, email = @e, direccion = @d
                        WHERE id_proveedor = @id";
                    cmd.Parameters.AddWithValue("@n", TBNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@t", string.IsNullOrWhiteSpace(TBTelefono.Text) ? (object)DBNull.Value : TBTelefono.Text.Trim());
                    cmd.Parameters.AddWithValue("@e", string.IsNullOrWhiteSpace(TBCorreo.Text) ? (object)DBNull.Value : TBCorreo.Text.Trim());
                    cmd.Parameters.AddWithValue("@d", string.IsNullOrWhiteSpace(TBDireccion.Text) ? (object)DBNull.Value : TBDireccion.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", _idEditar.Value);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("proveedor actualizado", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // avisa al padre que recargue
                this.Close(); // cierra form
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al actualizar proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== stubs autogenerados por el diseñador que debo mantener =====

        private void BSalir_Click(object sender, EventArgs e) { this.Close(); } // salir solo de este form
        private void EditarProveedor_Load(object sender, EventArgs e) { } // stub del diseñador
    }
}
