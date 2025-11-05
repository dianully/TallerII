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
    public partial class BuscarProducto : Form
    {
        public BuscarProducto()
        {
            InitializeComponent();
        }

        string conecctionString = "server=localhost;Database=game_box;Trusted_Connection=True";

        private void CargarProductos(string filtroNombre = "")
        {
            string consulta = "SELECT nombre, precio_venta, cantidad_stock, id_categoria " +
                              "FROM producto " +
                              "WHERE nombre LIKE @filtroNombre COLLATE Latin1_General_CI_AI"; // Ignora mayúsculas y acentos

            using (SqlConnection conexion = new SqlConnection(conecctionString))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@filtroNombre", "%" + filtroNombre + "%");

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                dgvBuscarProducto.DataSource = tabla;

                // Configuración visual del DataGridView
                if (tabla.Columns.Contains("imagen"))
                {
                    dgvBuscarProducto.Columns["imagen"].HeaderText = "Imagen";
                    dgvBuscarProducto.Columns["imagen"].Width = 100;
                    dgvBuscarProducto.Columns["imagen"].DefaultCellStyle.NullValue = null;
                    ((DataGridViewImageColumn)dgvBuscarProducto.Columns["imagen"]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                }

                dgvBuscarProducto.Columns["nombre"].HeaderText = "Nombre";
                dgvBuscarProducto.Columns["precio_venta"].HeaderText = "Precio";
                dgvBuscarProducto.Columns["cantidad_stock"].HeaderText = "Stock";
                dgvBuscarProducto.Columns["id_categoria"].HeaderText = "Categoría";
            }
        }
        private void dgvBuscarProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string nombreProducto = dgvBuscarProducto.Rows[e.RowIndex].Cells["nombre"].Value.ToString();

                foreach (Form form in Application.OpenForms)
                {
                    if (form is Vendedor vendedorForm)
                    {
                        vendedorForm.SetNombreProducto(nombreProducto);

                        if (vendedorForm.WindowState == FormWindowState.Minimized)
                        {
                            vendedorForm.WindowState = FormWindowState.Normal;
                        }

                        vendedorForm.Activate(); //
                        break;
                    }
                }

                this.Close();
            }
        }



        private void bBuscarProducto_Click(object sender, EventArgs e)
        {
            string nombreBuscado = tbNombreProducto.Text.Trim();
            CargarProductos(nombreBuscado);
        }


        private void bSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BuscarProducto_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }
    }
}
