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

        string conecctionString = "server=localhost;Database=gamebox;Trusted_Connection=True";

        private void subMenuUsuario_Load(object sender, EventArgs e)
        {
            CargarDatos();
            dataGridView1.ClearSelection();
        }

        private void CargarDatos()
        {
            using (SqlConnection connection = new SqlConnection(conecctionString))
            {
                string query = @"
            SELECT
               
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
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            // Usa la variable de conexión declarada fuera del método

            string query = @"
        SELECT
        
            u.nombre,
            u.apellido,
            u.dni,
            u.email,
            u.telefono,
            r.nombre AS nombre_rol
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
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar datos: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void LSub_Click(object sender, EventArgs e)
        {

        }
    }
}
