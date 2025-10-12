using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PuntoDeVentaGameBox.Gerente
{
    public partial class AgregarProveedor : Form
    {
        // cadena fija sin appconfig (igual a la que usas en el resto)
        private readonly string _connString =
            "Server=localhost;Database=game_box;Trusted_Connection=True;TrustServerCertificate=True";

        public AgregarProveedor()
        {
            InitializeComponent();

            // asegurar wiring (por si el diseñador no lo tiene)
            this.Load -= AgregarProveedor_Load;
            this.Load += AgregarProveedor_Load;

            BRegistrarProveedor.Click -= BRegistrarProveedor_Click;
            BRegistrarProveedor.Click += BRegistrarProveedor_Click;

            // algunos diseños conectan el botón Salir a BSalir_Click
            // si tu botón ya cierra por propiedad DialogResult, esto no molesta
            this.Click -= label3_Click; // no hace nada, sólo para evitar doble wiring accidental

            // sólo números en teléfono
            TBTelefono.KeyPress -= TBTelefono_KeyPress;
            TBTelefono.KeyPress += TBTelefono_KeyPress;
        }

        private SqlConnection NuevaConexion() => new SqlConnection(_connString);

        // ===================== Eventos requeridos por el diseñador =====================

        // stub de etiqueta (el diseñador apunta a esto): no hace nada
        private void label3_Click(object sender, EventArgs e) { /* sin acción */ }

        // algunos diseños apuntan el botón Salir a este método
        private void BSalir_Click(object sender, EventArgs e) => this.Close();

        private void AgregarProveedor_Load(object sender, EventArgs e)
        {
            // placeholder: podrías inicializar cosas aquí si hace falta
        }

        // ===================== Validaciones y helpers =====================

        private void TBTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // sólo dígitos y teclas de control (borrar, flechas, etc.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private static bool EmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return true; // opcional
            // validación simple y rápida
            return Regex.IsMatch(email.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private bool ExisteColumnaActivo(SqlConnection cn)
        {
            using (var cmd = cn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT COUNT(1)
                    FROM sys.columns
                    WHERE object_id = OBJECT_ID('dbo.proveedor') AND name = 'activo'";
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        // ===================== Alta =====================

        private void BRegistrarProveedor_Click(object sender, EventArgs e)
        {
            // 1) Validaciones
            string nombre = TBNombre.Text?.Trim();
            string telefonoTxt = TBTelefono.Text?.Trim();
            string correo = TBCorreo.Text?.Trim();
            string direccion = TBDireccion.Text?.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("el nombre es obligatorio", "Validacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBNombre.Focus();
                return;
            }

            long? telefono = null;
            if (!string.IsNullOrWhiteSpace(telefonoTxt))
            {
                if (!long.TryParse(telefonoTxt, out long tel) || tel < 0)
                {
                    MessageBox.Show("telefono debe ser un numero entero mayor o igual a 0",
                        "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TBTelefono.Focus();
                    return;
                }
                telefono = tel;
            }

            if (!EmailValido(correo))
            {
                MessageBox.Show("correo no tiene un formato valido",
                    "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBCorreo.Focus();
                return;
            }

            // 2) Insert a BD
            try
            {
                using (var cn = NuevaConexion())
                using (var cmd = cn.CreateCommand())
                {
                    cn.Open();
                    bool tieneActivo = ExisteColumnaActivo(cn);

                    if (tieneActivo)
                    {
                        cmd.CommandText = @"
                            INSERT INTO dbo.proveedor(nombre, telefono, email, direccion, activo)
                            VALUES(@n, @t, @e, @d, 1)";
                    }
                    else
                    {
                        cmd.CommandText = @"
                            INSERT INTO dbo.proveedor(nombre, telefono, email, direccion)
                            VALUES(@n, @t, @e, @d)";
                    }

                    cmd.Parameters.AddWithValue("@n", nombre);
                    if (telefono.HasValue)
                        cmd.Parameters.Add("@t", SqlDbType.BigInt).Value = telefono.Value;
                    else
                        cmd.Parameters.Add("@t", SqlDbType.BigInt).Value = DBNull.Value;

                    cmd.Parameters.AddWithValue("@e",
                        string.IsNullOrWhiteSpace(correo) ? (object)DBNull.Value : correo);
                    cmd.Parameters.AddWithValue("@d",
                        string.IsNullOrWhiteSpace(direccion) ? (object)DBNull.Value : direccion);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("proveedor registrado", "Ok",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK; // permite refrescar lista
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al registrar proveedor: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
