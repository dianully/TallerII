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
            

            // Consulta SQL para buscar el usuario por DNI y contraseña
            string query = @"
        SELECT id_rol 
        FROM usuario 
        WHERE dni = @dni AND contraseña = @contraseña";

            // Usa 'try-catch' para manejar posibles errores de conexión o consulta
            try
            {
                using (SqlConnection connection = new SqlConnection(conecctionString))
                {
                    // Crea un comando SQL con la consulta y la conexión
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agrega parámetros para evitar inyección SQL
                        command.Parameters.AddWithValue("@dni", TxUsuario.Text);
                        command.Parameters.AddWithValue("@contraseña", TxContraseña.Text);

                        connection.Open();

                        // Ejecuta la consulta y lee el resultado
                        object result = command.ExecuteScalar();

                        // Verifica si se encontró un usuario
                        if (result != null)
                        {
                            int idRol = Convert.ToInt32(result);

                            // Verifica el rol y muestra la página correspondiente
                            if (idRol == 3)
                            {
                                // Si el rol es 3 (Vendedor), muestra el formulario de Vendedor
                                Vendedor siguientePagina = new Vendedor();
                                siguientePagina.Show();
                                this.Hide();
                            }
                            else if (idRol == 2)
                            {
                                // Si el rol es 2 (Administrador), muestra el formulario de Administrador
                                Administrador siguientePagina = new Administrador();
                                siguientePagina.Show();
                                this.Hide();
                            }
                            else
                            {
                                // Si el rol no es 2 ni 3, muestra un mensaje de acceso denegado
                                PanelGerente siguientePagina = new PanelGerente();
                                siguientePagina.Show();
                                this.Hide();
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
    }
}
