using PuntoDeVentaGameBox.Administrador;
using PuntoDeVentaGameBox.Clases;
using PuntoDeVentaGameBox.Gerente;
using PuntoDeVentaGameBox.Vendedor;
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

namespace PuntoDeVentaGameBox.Vendedor
{
    public partial class BuscarCliente : Form
    {
        public BuscarCliente()
        {
            InitializeComponent();
        }

        string conecctionString = "server=localhost;Database=game_box;Trusted_Connection=True";

        private void CargarClientes(string filtroNombre = "")
        {
            string consulta = "SELECT nombre, apellido, dni, telefono,email, genero " +
                              "FROM cliente " +
                              "WHERE dni LIKE @filtroDni COLLATE Latin1_General_CI_AI"; // Ignora mayúsculas y acentos

            using (SqlConnection conexion = new SqlConnection(conecctionString))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@filtroDni", "%" + filtroNombre + "%");

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                dgvClientes.DataSource = tabla;

                // Configuración visual del DataGridView

                dgvClientes.Columns["nombre"].HeaderText = "Nombre";
                dgvClientes.Columns["apellido"].HeaderText = "Apellido";
                dgvClientes.Columns["dni"].HeaderText = "Dni";
                dgvClientes.Columns["telefono"].HeaderText = "Telefono";
                dgvClientes.Columns["email"].HeaderText = "Email";
                dgvClientes.Columns["genero"].HeaderText = "Genero";

            }
        }
        private void dgvBuscarCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string nombre = dgvClientes.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                string apellido = dgvClientes.Rows[e.RowIndex].Cells["apellido"].Value.ToString();
                string nombreCompleto = $"{nombre} {apellido}";
                string dni = dgvClientes.Rows[e.RowIndex].Cells["dni"].Value.ToString();

                foreach (Form form in Application.OpenForms)
                {
                    if (form is Vendedor vendedorForm)
                    {
                        vendedorForm.SetCliente(nombreCompleto);
                        vendedorForm.SetDniCliente(dni);

                        if (vendedorForm.WindowState == FormWindowState.Minimized)
                        {
                            vendedorForm.WindowState = FormWindowState.Normal;
                        }

                        vendedorForm.Activate();
                        break;
                    }
                }

                this.Close();
            }
        }


        private void bBuscarCliente_Click(object sender, EventArgs e)
        {
            string dniBuscado = tbDni.Text.Trim();
            CargarClientes(dniBuscado);
        }


        private void bSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BuscarCliente_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }
    }
}
