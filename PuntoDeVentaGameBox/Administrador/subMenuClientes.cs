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
using PuntoDeVentaGameBox.Vendedor;
using PuntoDeVentaGameBox.Administrador;
using PuntoDeVentaGameBox.Gerente;

namespace PuntoDeVentaGameBox.Administrador
{
    public partial class subMenuClientes : Form
    {
        public subMenuClientes()
        {
            InitializeComponent();
        }

        string conecctionString = "server=localhost;Database=game_box;Trusted_Connection=True";

        private void subMenuClientes_Load(object sender, EventArgs e)
        {
            //CargarRoles();
            CargarDatos();
            dgvClientes.ClearSelection();

            // 🔒 Limitar el campo de búsqueda por DNI a 8 caracteres
            tbBusquedaDNI.MaxLength = 8;

            // 🔒 Limitar el campo de búsqueda por Teléfono a 10 caracteres
            tbTelefono.MaxLength = 10;

        }

        private void CargarDatos()
        {
            using (SqlConnection connection = new SqlConnection(conecctionString))
            {
                string query = @"
            SELECT
               u.id_cliente,
               u.nombre AS 'Nombre',
               u.apellido AS 'Apellido',
               u.dni AS 'DNI',
               u.email AS 'Correo',
               u.genero AS 'Sexo',
               u.telefono AS 'Telefono'
            FROM
               cliente AS u
            WHERE u.activo = 1;";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                RefrescarTabla(adapter);
            }
        }

        private void RefrescarTabla(SqlDataAdapter adapter)
        {
            dgvClientes.Columns.Clear();

            DataTable table = new DataTable();
            adapter.Fill(table);
            dgvClientes.DataSource = table;

            if (dgvClientes.Columns.Contains("id_usuario"))
            {
                dgvClientes.Columns["id_usuario"].Visible = false;
            }
            

            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.Name = "Eliminar";
            btnEliminar.HeaderText = "";
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
            btnEliminar.FlatStyle = FlatStyle.Popup;
            dgvClientes.Columns.Add(btnEliminar);

            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.Name = "Editar";
            btnEditar.HeaderText = "";
            btnEditar.Text = "Editar";
            btnEditar.UseColumnTextForButtonValue = true;
            btnEditar.FlatStyle = FlatStyle.Popup;
            dgvClientes.Columns.Add(btnEditar);

            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            string query = @"
            SELECT
               u.id_cliente,
               u.nombre AS 'Nombre',
               u.apellido AS 'Apellido',
               u.dni AS 'DNI',
               u.email AS 'Correo',
               u.genero AS 'Sexo',
               u.telefono AS 'Telefono'
            FROM
               cliente AS u
            WHERE u.activo = 1;";

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

            if (!string.IsNullOrEmpty(cbGenero.Text))
            {
                conditions.Add("u.genero = @genero");
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

                        if (cbGenero.SelectedItem != null)
                        {
                            command.Parameters.AddWithValue("@sexo", cbGenero.Text);
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

        private void LimpiarFiltros_Click(object sender, EventArgs e)
        {
            tbBusquedaDNI.Clear();
            tbCorreo.Clear();
            tbTelefono.Clear();
            cbGenero.SelectedIndex = 0;
        }

        private void MostrarTodo_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
        
        private void bAgregarUsuario_Click(object sender, EventArgs e)
        {
            AgregarCliente nuevoFormulario = new AgregarCliente();
            nuevoFormulario.ShowDialog();
        }
    }
}
