using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVentaGameBox
{
    public partial class subMenuUsuario : Form
    {

        public subMenuUsuario()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        string conecctionString = "server=localhost;Database=game_box;Trusted_Connection=True";

        private void subMenuUsuario_Load(object sender, EventArgs e)
        {
            CargarRoles();
            CargarDatos();
            dataGridView1.ClearSelection();
        }

        private void CargarRoles()
        {
            string query = "SELECT id_rol, nombre FROM rol ORDER BY id_rol;";
            try
            {
                using (SqlConnection connection = new SqlConnection(conecctionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable rolesTable = new DataTable();
                    adapter.Fill(rolesTable);

                    cbRol.DataSource = rolesTable;
                    cbRol.DisplayMember = "nombre";
                    cbRol.ValueMember = "id_rol";

                    DataRow newRow = rolesTable.NewRow();
                    newRow["id_rol"] = -1;
                    newRow["nombre"] = "Todos";
                    rolesTable.Rows.InsertAt(newRow, 0);

                    cbRol.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefrescarTabla(SqlDataAdapter adapter)
        {
            dataGridView1.Columns.Clear();

            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

            if (dataGridView1.Columns.Contains("id_usuario"))
            {
                dataGridView1.Columns["id_usuario"].Visible = false;
            }
            if (dataGridView1.Columns.Contains("contraseña"))
            {
                dataGridView1.Columns["contraseña"].Visible = false;
            }

            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.Name = "Eliminar";
            btnEliminar.HeaderText = "";
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
            btnEliminar.FlatStyle = FlatStyle.Popup;
            dataGridView1.Columns.Add(btnEliminar);

            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.Name = "Editar";
            btnEditar.HeaderText = "";
            btnEditar.Text = "Editar";
            btnEditar.UseColumnTextForButtonValue = true;
            btnEditar.FlatStyle = FlatStyle.Popup;
            dataGridView1.Columns.Add(btnEditar);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDatos()
        {
            using (SqlConnection connection = new SqlConnection(conecctionString))
            {
                string query = @"
            SELECT
               u.id_usuario,
                u.nombre AS 'Nombre',
                u.apellido AS 'Apellido',
                u.dni AS 'DNI',
                u.email AS 'Correo',
                u.telefono AS 'Telefono',
                u.contraseña,
                r.nombre AS 'Rol'
            FROM
                usuario AS u
            INNER JOIN
                rol AS r ON u.id_rol = r.id_rol
            WHERE u.activo = 1;";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                RefrescarTabla(adapter);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string rolUsuario = dataGridView1.Rows[e.RowIndex].Cells["Rol"].Value.ToString();

                if (rolUsuario == "Gerente")
                {
                    MessageBox.Show("No se puede editar o eliminar a un usuario con el rol de Gerente.", "Permiso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index && e.RowIndex >= 0)
                {
                    string dniUsuario = dataGridView1.Rows[e.RowIndex].Cells["DNI"].Value.ToString();
                    DialogResult confirmacion = MessageBox.Show(
                        "¿Está seguro de que desea desactivar a este usuario?",
                        "Confirmar Desactivación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );
                    if (confirmacion == DialogResult.Yes)
                    {
                        EliminarUsuario(dniUsuario);
                    }
                }

                if (e.ColumnIndex == dataGridView1.Columns["Editar"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
                    int idUsuario = Convert.ToInt32(fila.Cells["id_usuario"].Value);
                    string nombre = fila.Cells["Nombre"].Value.ToString();
                    string apellido = fila.Cells["Apellido"].Value.ToString();
                    string dni = fila.Cells["DNI"].Value.ToString();
                    string email = fila.Cells["Correo"].Value.ToString();
                    string telefono = fila.Cells["Telefono"].Value.ToString();
                    string contraseña = fila.Cells["contraseña"].Value.ToString(); // Obtiene el valor de la contraseña
                    string rol = fila.Cells["Rol"].Value.ToString();

                    EdicionUsuario formEditar = new EdicionUsuario(idUsuario, nombre, apellido, dni, email, telefono, contraseña, rol);
                    formEditar.ShowDialog();
                    CargarDatos();
                }
            }
        }

        private void EliminarUsuario(string dniUsuario)
        {
            string query = "UPDATE usuario SET activo = 0 WHERE dni = @dniUsuario";

            try
            {
                using (SqlConnection connection = new SqlConnection(conecctionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@dniUsuario", dniUsuario);
                        connection.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Usuario desactivado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al desactivar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT
                    u.id_usuario,
                    u.nombre AS 'Nombre',
                    u.apellido AS 'Apellido',
                    u.dni AS 'DNI',
                    u.email AS 'Correo',
                    u.telefono AS 'Telefono',
                    u.contraseña,
                    r.nombre AS 'Rol'
                FROM
                    usuario AS u
                INNER JOIN
                    rol AS r ON u.id_rol = r.id_rol";

            List<string> conditions = new List<string>();

            conditions.Add("u.activo = 1");

            if (!string.IsNullOrEmpty(tbBusquedaDNI.Text))
            {
                conditions.Add("u.dni = @dni");
            }

            if (!string.IsNullOrEmpty(tbCorreo.Text))
            {
                conditions.Add("u.email = @email");
            }

            if (!string.IsNullOrEmpty(tbTelefono.Text))
            {
                conditions.Add("u.telefono = @telefono");
            }

            if (cbRol.SelectedItem != null && cbRol.Text != "Todos")
            {
                conditions.Add("r.nombre = @rol");
            }

            if (conditions.Count > 0)
            {
                query += " WHERE " + string.Join(" AND ", conditions);
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(conecctionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (!string.IsNullOrEmpty(tbBusquedaDNI.Text))
                        {
                            command.Parameters.AddWithValue("@dni", tbBusquedaDNI.Text);
                        }

                        if (!string.IsNullOrEmpty(tbCorreo.Text))
                        {
                            command.Parameters.AddWithValue("@email", tbCorreo.Text);
                        }

                        if (!string.IsNullOrEmpty(tbTelefono.Text))
                        {
                            command.Parameters.AddWithValue("@telefono", tbTelefono.Text);
                        }

                        if (cbRol.SelectedItem != null && cbRol.Text != "Todos")
                        {
                            command.Parameters.AddWithValue("@rol", cbRol.Text);
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        RefrescarTabla(adapter);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar datos: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarTodo_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void LimpiarFiltros_Click(object sender, EventArgs e)
        {
            tbBusquedaDNI.Clear();
            tbCorreo.Clear();
            tbTelefono.Clear();
            cbRol.SelectedIndex = 0;
            CargarDatos();
        }

        private void bAgregarUsuario_Click(object sender, EventArgs e)
        {
            AgregarUsuario nuevoFormulario = new AgregarUsuario();
            nuevoFormulario.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void LSub_Click(object sender, EventArgs e)
        {

        }
    }
}
