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
using PuntoDeVentaGameBox.Vendedor;
using PuntoDeVentaGameBox.Administrador;
using PuntoDeVentaGameBox.Gerente;

namespace PuntoDeVentaGameBox.Administrador
{
    public partial class AgregarUsuario : Form
    {
        public AgregarUsuario()
        {
            InitializeComponent();

            // Aplica "solo números" de forma reutilizable
            AplicarSoloNumeros(tDni);
            AplicarSoloNumeros(tTelefono);
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

        // Nuevo método para validar si un Email ya existe en la base de datos
        private bool EmailYaExiste(string email)
        {
            string query = "SELECT COUNT(*) FROM usuario WHERE email = @email";
            using (SqlConnection connection = new SqlConnection(conecctionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
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

            // 3. Validar que el Email no exista en la base de datos (nueva validación)
            if (EmailYaExiste(tEmail.Text))
            {
                MessageBox.Show("El correo electrónico ingresado ya está registrado.", "Email Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Validar la longitud del DNI
            if (tDni.Text.Length != 8)
            {
                MessageBox.Show("El DNI debe tener exactamente 8 caracteres.", "DNI Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 5. Validar la longitud del teléfono
            if (tTelefono.Text.Length != 10)
            {
                MessageBox.Show("Ingrese un numero de teléfono válido", "Teléfono Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 6. Validar la nomenclatura del correo electrónico
            if (!tEmail.Text.Contains("@") || !tEmail.Text.Contains(".com"))
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

        private void tNombre_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tNombre.Text))
            {
                // Guarda la posición del cursor antes de modificar el texto
                int cursorPosition = tNombre.SelectionStart;

                // Convierte la primera letra a mayúscula
                if (tNombre.Text.Length > 0)
                {
                    tNombre.Text = char.ToUpper(tNombre.Text[0]) + tNombre.Text.Substring(1);
                }

                // Restablece el cursor a su posición original para una mejor experiencia de usuario
                tNombre.SelectionStart = cursorPosition;
            }
        }

        private void tApellido_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tApellido.Text))
            {
                // Guarda la posición del cursor antes de modificar el texto
                int cursorPosition = tApellido.SelectionStart;

                // Convierte la primera letra a mayúscula
                if (tApellido.Text.Length > 0)
                {
                    tApellido.Text = char.ToUpper(tApellido.Text[0]) + tApellido.Text.Substring(1);
                }

                // Restablece el cursor a su posición original para una mejor experiencia de usuario
                tApellido.SelectionStart = cursorPosition;
            }
        }

        private void AgregarUsuario_Load(object sender, EventArgs e)
        {

        }

        // ======== MÉTODO REUTILIZABLE: SOLO NÚMEROS ========
        /// <summary>
        /// Hace que el TextBox acepte únicamente dígitos (tecleo y pegado).
        /// </summary>
        private void AplicarSoloNumeros(TextBox tb)
        {
            // KeyPress: bloquea cualquier char no numérico
            tb.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };

            // TextChanged: limpia si pegaron contenido no numérico
            tb.TextChanged += (s, e) =>
            {
                var t = (TextBox)s;
                int sel = t.SelectionStart;
                string solo = new string(t.Text.Where(char.IsDigit).ToArray());
                if (solo != t.Text)
                {
                    t.Text = solo;
                    t.SelectionStart = Math.Min(sel, t.Text.Length);
                }
            };
        }

        private void tEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
