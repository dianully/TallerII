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
    public partial class AgregarUsuario : Form
    {
        public AgregarUsuario()
        {
            InitializeComponent();
        }

        string conecctionString = "server=localhost;Database=game_box;Trusted_Connection=True";

        private void tTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bAgregarUsuario_Click(object sender, EventArgs e)
        {
            // La cadena de conexión, que debería estar declarada a nivel de clase
            // string connectionString = "Data Source=FRANCIS\\fran9;Initial Catalog=DBGAME_BOX;Integrated Security=True;";

            // Consulta SQL para insertar un nuevo usuario
            // Las columnas id_usuario, activo e id_rol se manejan de forma automática
            string query = @"
        INSERT INTO usuario (
            nombre, 
            apellido, 
            dni, 
            email, 
            telefono, 
            contraseña, 
            activo, 
            id_rol
        )
        VALUES (
            @nombre, 
            @apellido, 
            @dni, 
            @email, 
            @telefono, 
            @contraseña, 
            1,    -- Valor fijo de 1 para la columna 'activo'
            3     -- Valor fijo de 3 para la columna 'id_rol' (Vendedor)
        )";

            try
            {
                using (SqlConnection connection = new SqlConnection(conecctionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agrega parámetros para prevenir la inyección SQL
                        command.Parameters.AddWithValue("@nombre", tNombre.Text);
                        command.Parameters.AddWithValue("@apellido", tApellido.Text);
                        command.Parameters.AddWithValue("@dni", tDni.Text);
                        command.Parameters.AddWithValue("@email", tEmail.Text);
                        command.Parameters.AddWithValue("@telefono", tTelefono.Text);
                        command.Parameters.AddWithValue("@contraseña", tContraseña.Text);

                        connection.Open();

                        // Ejecuta la consulta de inserción. ExecuteNonQuery devuelve el número de filas afectadas.
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("¡Usuario registrado exitosamente!", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Llama a un método para limpiar los TextBoxes
                        }
                        else
                        {
                            MessageBox.Show("No se pudo registrar al usuario. Intente de nuevo.", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
