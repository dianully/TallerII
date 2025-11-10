using PuntoDeVentaGameBox.Administrador;
using PuntoDeVentaGameBox.Gerente;
using PuntoDeVentaGameBox.Vendedor;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace PuntoDeVentaGameBox
{
    public partial class Login : Form
    {
        string conecctionString = "server=localhost;Database=game_box;Trusted_Connection=True";

        public Login()
        {
            InitializeComponent();
        }

        private void BIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxUsuario.Text) || string.IsNullOrWhiteSpace(TxContraseña.Text))
            {
                MessageBox.Show("Por favor, ingrese DNI y contraseña.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string contraseñaIngresada = TxContraseña.Text;
            string hash = HashearContraseña(contraseñaIngresada);

            // Consulta SQL para buscar al usuario y obtener sus datos, incluyendo el campo 'activo'
            string query = @"
                SELECT id_usuario, nombre, apellido, dni, email, telefono, contraseña, id_rol, activo
                FROM usuario 
                WHERE dni = @dni AND contraseña = @contraseña";

            try
            {
                using (SqlConnection connection = new SqlConnection(conecctionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@dni", TxUsuario.Text);
                        command.Parameters.AddWithValue("@contraseña", hash);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Si se encuentra el usuario, guarda sus datos en la clase SesionUsuario
                                SesionUsuario.IdUsuario = Convert.ToInt32(reader["id_usuario"]);
                                SesionUsuario.Nombre = reader["nombre"].ToString();
                                SesionUsuario.Apellido = reader["apellido"].ToString();
                                SesionUsuario.Dni = reader["dni"].ToString();
                                SesionUsuario.Email = reader["email"].ToString();
                                SesionUsuario.Telefono = reader["telefono"].ToString();
                                SesionUsuario.Contraseña = reader["contraseña"].ToString();
                                SesionUsuario.IdRol = Convert.ToInt32(reader["id_rol"]);

                                // Valida si la cuenta está activa (activo = 1) o deshabilitada (activo = 0)
                                int activo = Convert.ToInt32(reader["activo"]);
                                if (activo == 0)
                                {
                                    MessageBox.Show("Tu cuenta ha sido deshabilitada. Por favor, contacta a un administrador.", "Cuenta Deshabilitada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                // Ahora, redirige según el rol
                                switch (SesionUsuario.IdRol)
                                {
                                    case 3: // Vendedor
                                        PuntoDeVentaGameBox.Vendedor.Vendedor formVendedor = new PuntoDeVentaGameBox.Vendedor.Vendedor();
                                        formVendedor.Show();
                                        this.Hide();
                                        break;
                                    case 2: // Administrador
                                        PuntoDeVentaGameBox.Administrador.Administrador formAdmin = new PuntoDeVentaGameBox.Administrador.Administrador();
                                        formAdmin.Show();
                                        this.Hide();
                                        break;
                                    case 1: // Gerente (Asumiendo que el rol 1 es Gerente)
                                        PanelGerente formGerente = new PanelGerente();
                                        formGerente.Show();
                                        this.Hide();
                                        break;
                                    default:
                                        MessageBox.Show("Rol de usuario no reconocido o sin acceso.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("DNI o contraseña incorrectos. Intente de nuevo.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string HashearContraseña(string contraseña)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(contraseña);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }


        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TxContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo números y la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void bSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LListTitle_Click(object sender, EventArgs e)
        {

        }

        private void TxUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
