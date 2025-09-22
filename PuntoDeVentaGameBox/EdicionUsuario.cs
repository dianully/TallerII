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
        private int idUsuario;
        private string connectionString = "server=localhost;Database=game_box;Trusted_Connection=True";

        public EdicionUsuario(int id, string nombre, string apellido, string dni, string email, string telefono, string contraseña, string rol)
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

            if (cbRol.Items.Count > 0 && !string.IsNullOrEmpty(rol))
            {
                cbRol.SelectedIndex = cbRol.FindStringExact(rol);
            }

            if (SesionUsuario.IdRol != 2)
            {
                cbRol.Enabled = false;
            }
        }

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

        private bool DniYaExiste(string dni, int idUsuarioActual)
        {
            string query = "SELECT COUNT(*) FROM usuario WHERE dni = @dni AND id_usuario != @idUsuario";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@dni", dni);
                    command.Parameters.AddWithValue("@idUsuario", idUsuarioActual);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void bEditarUsuario_Click(object sender, EventArgs e)
        {
            ActualizarUsuario();
        }

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

            if (DniYaExiste(tEditarDni.Text, this.idUsuario))
            {
                MessageBox.Show("El DNI ingresado ya existe en la base de datos para otro usuario.", "DNI Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                        if (this.idUsuario == SesionUsuario.IdUsuario)
                        {
                            SesionUsuario.Nombre = tEditarNombre.Text;
                            SesionUsuario.Apellido = tEditarApellido.Text;
                            SesionUsuario.Dni = tEditarDni.Text;
                            SesionUsuario.Email = tEditarEmail.Text;
                            SesionUsuario.Telefono = tEditarTelefono.Text;
                            SesionUsuario.Contraseña = tEditarContraseña.Text;
                        }
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