using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // Consulta SQL para buscar el usuario por DNI y contraseña, y obtener su nombre, apellido y rol
            string query = @"
            SELECT u.nombre, u.apellido, u.id_rol
            FROM usuario AS u
            WHERE u.dni = @dni AND u.contraseña = @contraseña";

            try
            {
                using (SqlConnection connection = new SqlConnection(conecctionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@dni", TxUsuario.Text);
                        command.Parameters.AddWithValue("@contraseña", TxContraseña.Text);

                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            string nombre = reader["nombre"].ToString();
                            string apellido = reader["apellido"].ToString();
                            int idRol = Convert.ToInt32(reader["id_rol"]);

                            if (idRol == 1) // ID de Gerente
                            {
                                // Aquí puedes abrir el formulario de Gerente
                                // Gerente formGerente = new Gerente();
                                // formGerente.Show();
                                MessageBox.Show("Acceso de Gerente concedido.");
                            }
                            else if (idRol == 2) // ID de Vendedor
                            {
                                Vendedor formVendedor = new Vendedor(nombre, apellido);
                                formVendedor.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Rol de usuario no reconocido.", "Error de Rol", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("DNI o contraseña incorrectos. Intente de nuevo.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
