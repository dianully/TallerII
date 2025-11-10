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

            dgvClientes.CellClick += dgvClientes_CellClick;


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

            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void RefrescarTablaDadoDeBaja(SqlDataAdapter adapter)
        {
            dgvClientes.Columns.Clear();

            DataTable table = new DataTable();
            adapter.Fill(table);
            dgvClientes.DataSource = table;

            if (dgvClientes.Columns.Contains("id_usuario"))
            {
                dgvClientes.Columns["id_usuario"].Visible = false;
            }

            // Botón Reingresar
            DataGridViewButtonColumn btnReingresar = new DataGridViewButtonColumn();
            btnReingresar.Name = "Reingresar";
            btnReingresar.HeaderText = "";
            btnReingresar.Text = "Reingresar";
            btnReingresar.UseColumnTextForButtonValue = true;
            btnReingresar.FlatStyle = FlatStyle.Popup;
            dgvClientes.Columns.Add(btnReingresar);

            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataGridViewRow row in dgvClientes.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.LightCoral; // Rojo suave
                row.DefaultCellStyle.ForeColor = Color.White;       // Texto blanco para contraste
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validar que no se hizo clic en el encabezado
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Verificar si se hizo clic en la columna "Eliminar"
            if (dgvClientes.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                // Obtener el ID del cliente
                int idCliente = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["id_cliente"].Value);

                DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que deseas dar de baja este cliente?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(conecctionString))
                        {
                            string query = "UPDATE cliente SET activo = 0 WHERE id_cliente = @id";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@id", idCliente);
                                connection.Open();
                                command.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Cliente dado de baja correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatos(); // Refrescar la tabla
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al dar de baja al cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


            if (dgvClientes.Columns[e.ColumnIndex].Name == "Reingresar")
            {
                int idCliente = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["id_cliente"].Value);

                DialogResult confirmacion = MessageBox.Show("¿Deseas reactivar este cliente?", "Confirmar reingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(conecctionString))
                        {
                            string query = "UPDATE cliente SET activo = 1 WHERE id_cliente = @id";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@id", idCliente);
                                connection.Open();
                                command.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Cliente reactivado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bClientesDadoDeBaja_Click(null, null); // Refrescar la vista de dados de baja
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al reactivar al cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
    
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
               cliente AS u";

            List<string> conditions = new List<string>();
            conditions.Add("u.activo = 1");

            if (!string.IsNullOrEmpty(tbBusquedaDNI.Text))
            {
                conditions.Add("u.dni LIKE '%' + @dni + '%'");
            }

            if (!string.IsNullOrEmpty(tbCorreo.Text))
            {
                conditions.Add("u.email LIKE '%' + @email + '%'");
            }

            if (!string.IsNullOrEmpty(tbTelefono.Text))
            {
                conditions.Add("u.telefono LIKE '%' + @telefono + '%'");
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
                            command.Parameters.AddWithValue("@genero", cbGenero.Text);
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

        private void bClientesDadoDeBaja_Click(object sender, EventArgs e)
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
               cliente AS u";

            List<string> conditions = new List<string>();
            conditions.Add("u.activo = 0 AND id_cliente > 0");

            if (!string.IsNullOrEmpty(tbBusquedaDNI.Text))
            {
                conditions.Add("u.dni LIKE '%' + @dni + '%'");
            }

            if (!string.IsNullOrEmpty(tbCorreo.Text))
            {
                conditions.Add("u.email LIKE '%' + @email + '%'");
            }

            if (!string.IsNullOrEmpty(tbTelefono.Text))
            {
                conditions.Add("u.telefono LIKE '%' + @telefono + '%'");
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
                            command.Parameters.AddWithValue("@genero", cbGenero.Text);
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        RefrescarTablaDadoDeBaja(adapter);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar datos: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtSoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
