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
        }

        private void CargarDatos()
        {
            using (SqlConnection connection = new SqlConnection(conecctionString))
            {
                string query = @"
            SELECT
               
                u.nombre AS 'Nombre',
                u.apellido AS 'Apellido',
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

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
