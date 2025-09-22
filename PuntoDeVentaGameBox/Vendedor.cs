using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVentaGameBox
{
    public partial class Vendedor : Form
    {
        // Constructor sin parámetros (se mantiene por defecto)
        public Vendedor()
        {
            InitializeComponent();
        }

        // Nuevo constructor que recibe el nombre y apellido del vendedor
        public Vendedor(string nombre, string apellido)
        {
            InitializeComponent();
            lVendedor.Text = $"{nombre} {apellido}";
        }

        string conecctionString = "server=localhost;Database=game_box;Trusted_Connection=True";
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void LRol_Click(object sender, EventArgs e)
        {
        }

        private void Vendedor_Load(object sender, EventArgs e)
        {
        }

        private void lVendedor_Click(object sender, EventArgs e)
        {
        }

        private void lNombre_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rolSeleccionado = cbElegirUsuario.SelectedItem.ToString();

            string rolDeseado = "Nuevo Cliente";
            if (rolSeleccionado == rolDeseado)
            {
                gbCliente.Enabled = true;
            }
            else
            {
                gbCliente.Enabled = false;
            }
        }
    }
}
