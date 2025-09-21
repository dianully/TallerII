using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        // Método para validar si un DNI ya existe en la base de datos
        private bool DniYaExiste(string dni)
        {
            string query = "SELECT COUNT(*) FROM usuario WHERE dni = @dni";
            using (SqlConnection connection = new SqlConnection(conecctionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@dni", dni);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void tTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bAgregarUsuario_Click(object sender, EventArgs e)
        {
            // Validaciones
            // 1. Verificar si algún campo está vacío
            if (string.IsNullOrWhiteSpace(tNombre.Text) ||
                string.IsNullOrWhiteSpace(tApellido.Text) ||
                string.IsNullOrWhiteSpace(tDni.Text) ||
                string.IsNullOrWhiteSpace(tEmail.Text) ||
                string.IsNullOrWhiteSpace(tTelefono.Text) ||
                string.IsNullOrWhiteSpace(tContraseña.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validar que el DNI no exista en la base de datos
            if (DniYaExiste(tDni.Text))
            {
                MessageBox.Show("El DNI ingresado ya existe en la base de datos.", "DNI Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Validar la longitud del DNI
            if (tDni.Text.Length != 8)
            {
                MessageBox.Show("El DNI debe tener exactamente 8 caracteres.", "DNI Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Validar la longitud del teléfono
            if (tTelefono.Text.Length != 10)
            {
                MessageBox.Show("Ingrese un numero de teléfono válido", "Teléfono Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 5. Validar la nomenclatura del correo electrónico
            if (!tEmail.Text.Contains("@") || !tEmail.Text.EndsWith(".com"))
            {
                MessageBox.Show("El correo electrónico debe tener el formato 'nombre@dominio.com'.", "Correo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Consulta SQL para insertar un nuevo usuario
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
            1,    
            3     
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
