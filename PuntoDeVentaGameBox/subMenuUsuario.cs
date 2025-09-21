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
            CargarDatos();
            dataGridView1.ClearSelection();
        }

        // Método para inicializar y configurar el DataGridView
        private void InicializarDataGridView()
        {
            // Limpia las columnas existentes para evitar duplicados al recargar la tabla
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = true;
        }

        // Carga todos los datos y configura el DataGridView
        private void CargarDatos()
        {
            InicializarDataGridView();

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
                        r.nombre AS 'Rol'
                    FROM
                        usuario AS u
                    INNER JOIN
                        rol AS r ON u.id_rol = r.id_rol;";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }

            // Agrega las columnas de los botones después de que se han cargado los datos
            // Esto asegura que estén al final
            if (dataGridView1.Columns.Contains("id_usuario"))
            {
                dataGridView1.Columns["id_usuario"].Visible = false;
            }

            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.Name = "Eliminar";
            btnEliminar.HeaderText = "Eliminar";
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
            btnEliminar.FlatStyle = FlatStyle.Popup;
            dataGridView1.Columns.Add(btnEliminar);

            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.Name = "Editar";
            btnEditar.HeaderText = "Editar";
            btnEditar.Text = "Editar";
            btnEditar.UseColumnTextForButtonValue = true;
            btnEditar.FlatStyle = FlatStyle.Popup;
            dataGridView1.Columns.Add(btnEditar);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Maneja el clic en la columna de 'Eliminar'
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    string dniUsuario = dataGridView1.Rows[e.RowIndex].Cells["DNI"].Value.ToString();
                    DialogResult confirmacion = MessageBox.Show(
                        "¿Está seguro de que desea eliminar a este usuario?",
                        "Confirmar Eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirmacion == DialogResult.Yes)
                    {
                        EliminarUsuario(dniUsuario);
                    }
                }

                // Maneja el clic en la columna de 'Editar'
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Editar")
                {
                    DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
                    // Asegúrate de que los nombres de las celdas coincidan con los nombres de las columnas en tu tabla
                    // Ahora se utiliza el id_usuario que está oculto
                    int idUsuario = Convert.ToInt32(fila.Cells["id_usuario"].Value);
                    string nombre = fila.Cells["Nombre"].Value.ToString();
                    string apellido = fila.Cells["Apellido"].Value.ToString();
                    string dni = fila.Cells["DNI"].Value.ToString();
                    string email = fila.Cells["Correo"].Value.ToString();
                    string telefono = fila.Cells["Telefono"].Value.ToString();

                    EdicionUsuario formEditar = new EdicionUsuario(idUsuario, nombre, apellido, dni, email, telefono);
                    formEditar.ShowDialog();
                    CargarDatos();
                }
            }
        }

        private void EliminarUsuario(string dniUsuario)
        {
            string query = "DELETE FROM usuario WHERE dni = @dniUsuario";

            try
            {
                using (SqlConnection connection = new SqlConnection(conecctionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@dniUsuario", dniUsuario);
                        connection.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Usuario eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            // Inicializa la tabla y las columnas de botones antes de la búsqueda
            InicializarDataGridView();

            string query = @"
                SELECT
                    u.id_usuario,
                    u.nombre AS 'Nombre',
                    u.apellido AS 'Apellido',
                    u.dni AS 'DNI',
                    u.email AS 'Correo',
                    u.telefono AS 'Telefono',
                    r.nombre AS 'Rol'
                FROM
                    usuario AS u
                INNER JOIN
                    rol AS r ON u.id_rol = r.id_rol";

            List<string> conditions = new List<string>();

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

            if (conditions.Count > 0)
            {
                query += " WHERE " + string.Join(" OR ", conditions);
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

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dataGridView1.DataSource = table;

                        if (dataGridView1.Columns.Contains("id_usuario"))
                        {
                            dataGridView1.Columns["id_usuario"].Visible = false;
                        }

                        // Agrega las columnas de los botones después de la búsqueda
                        DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                        btnEliminar.Name = "Eliminar";
                        btnEliminar.HeaderText = "Eliminar";
                        btnEliminar.Text = "Eliminar";
                        btnEliminar.UseColumnTextForButtonValue = true;
                        btnEliminar.FlatStyle = FlatStyle.Popup;
                        dataGridView1.Columns.Add(btnEliminar);

                        DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                        btnEditar.Name = "Editar";
                        btnEditar.HeaderText = "Editar";
                        btnEditar.Text = "Editar";
                        btnEditar.UseColumnTextForButtonValue = true;
                        btnEditar.FlatStyle = FlatStyle.Popup;
                        dataGridView1.Columns.Add(btnEditar);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar datos: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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


