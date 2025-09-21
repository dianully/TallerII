using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PuntoDeVentaGameBox
{
    public partial class EdicionUsuario : Form
    {
        // Declara variables a nivel de clase para almacenar la información
        private int idUsuario;
        private string connectionString = "server=localhost;Database=game_box;Trusted_Connection=True";

        // Constructor con parámetros que es el que tu otro formulario necesita
        public EdicionUsuario(int id, string nombre, string apellido, string dni, string email, string telefono)
        {
            InitializeComponent();

            this.idUsuario = id;
            tEditarNombre.Text = nombre;
            tEditarApellido.Text = apellido;
            tEditarDni.Text = dni;
            tEditarEmail.Text = email;
            tEditarTelefono.Text = telefono;

            
        }

        // El constructor vacío que Visual Studio crea por defecto, puedes mantenerlo
        public EdicionUsuario()
        {
            InitializeComponent();
        }

        private void bEditarUsuario_Click(object sender, EventArgs e)
        {
            ActualizarUsuario();
        }

        // Método para actualizar los datos en la base de datos
        private void ActualizarUsuario()
        {
            string query = @"
                UPDATE usuario SET
                    nombre = @nombre,
                    apellido = @apellido,
                    dni = @dni,
                    email = @email,
                    telefono = @telefono
                WHERE
                    id_usuario = @idUsuario";

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agrega los parámetros para la actualización
                        command.Parameters.AddWithValue("@nombre", tEditarNombre.Text);
                        command.Parameters.AddWithValue("@apellido", tEditarApellido.Text);
                        command.Parameters.AddWithValue("@dni", tEditarDni.Text);
                        command.Parameters.AddWithValue("@email", tEditarEmail.Text);
                        command.Parameters.AddWithValue("@telefono", tEditarTelefono.Text);
                        command.Parameters.AddWithValue("@idUsuario", this.idUsuario);

                        connection.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Usuario actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Cierra el formulario de edición después de guardar
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
