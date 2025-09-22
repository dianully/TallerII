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
        private int rolUsuarioOriginal;

        // Constructor con parámetros que es el que tu otro formulario necesita
        public EdicionUsuario(int id, string nombre, string apellido, string dni, string email, string telefono,string contraseña, string rol)
        {
            InitializeComponent();
            CargarRoles();

            this.idUsuario = id;
            tEditarNombre.Text = nombre;
            tEditarApellido.Text = apellido;
            tEditarDni.Text = dni;
            tEditarEmail.Text = email;
            tEditarTelefono.Text = telefono;
            tEditarContraseña.Text = contraseña;

            // Seleccionar el rol actual del usuario en el ComboBox
            if (cbRol.Items.Count > 0)
            {
                cbRol.SelectedIndex = cbRol.FindStringExact(rol);
            }
        }
        // El constructor vacío que Visual Studio crea por defecto, puedes mantenerlo
        public EdicionUsuario()
        {
            InitializeComponent();
        }

        private void CargarRoles()
        {
            string query = "SELECT id_rol, nombre FROM rol WHERE id_rol IN (2, 3)";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable rolesTable = new DataTable();
                    adapter.Fill(rolesTable);

                    cbRol.DataSource = rolesTable;
                    cbRol.DisplayMember = "nombre";
                    cbRol.ValueMember = "id_rol";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bEditarUsuario_Click(object sender, EventArgs e)
        {
            ActualizarUsuario();
        }

        // Método para actualizar los datos en la base de datos
        private void ActualizarUsuario()
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(tEditarNombre.Text) ||
                string.IsNullOrWhiteSpace(tEditarApellido.Text) ||
                string.IsNullOrWhiteSpace(tEditarDni.Text) ||
                string.IsNullOrWhiteSpace(tEditarEmail.Text) ||
                string.IsNullOrWhiteSpace(tEditarTelefono.Text) ||
                string.IsNullOrWhiteSpace(tEditarContraseña.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tEditarDni.Text.Length != 8)
            {
                MessageBox.Show("El DNI debe tener exactamente 8 caracteres.", "DNI Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tEditarTelefono.Text.Length != 10)
            {
                MessageBox.Show("El teléfono debe tener exactamente 10 caracteres.", "Teléfono Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!tEditarEmail.Text.Contains("@") || !tEditarEmail.Text.EndsWith(".com"))
            {
                MessageBox.Show("El correo electrónico debe tener el formato 'nombre@dominio.com'.", "Correo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE usuario SET nombre = @nombre, apellido = @apellido, dni = @dni, email = @email, telefono = @telefono, contraseña = @contraseña, id_rol = @idRol WHERE id_usuario = @idUsuario";

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombre", tEditarNombre.Text);
                        command.Parameters.AddWithValue("@apellido", tEditarApellido.Text);
                        command.Parameters.AddWithValue("@dni", tEditarDni.Text);
                        command.Parameters.AddWithValue("@email", tEditarEmail.Text);
                        command.Parameters.AddWithValue("@telefono", tEditarTelefono.Text);
                        command.Parameters.AddWithValue("@contraseña", tEditarContraseña.Text);
                        command.Parameters.AddWithValue("@idRol", cbRol.SelectedValue);
                        command.Parameters.AddWithValue("@idUsuario", this.idUsuario);

                        connection.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Usuario actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

