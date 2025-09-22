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
    public partial class Vendedor : Form
    {
        // Constructor
        public Vendedor()
        {
            InitializeComponent();
            // Asigna el nombre y apellido desde la clase SesionUsuario al label
            lVendedor.Text = $"{SesionUsuario.Nombre} {SesionUsuario.Apellido}";

            // La siguiente línea fue eliminada para evitar que el evento se registre dos veces
            // this.lVendedor.Click += new System.EventHandler(this.lVendedor_Click_1);
        }

        string conecctionString = "server=localhost;Database=game_box;Trusted_Connection=True";

        private void button1_Click(object sender, EventArgs e)
        {
            SesionUsuario.LimpiarSesion();

            // Oculta el formulario actual
            this.Hide();

            // Crea una nueva instancia del formulario de Login y la muestra
            Login loginForm = new Login();
            loginForm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbElegirUsuario.SelectedItem != null)
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

        private void gbCliente_Enter(object sender, EventArgs e)
        {

        }

        private void lVendedor_Click_1(object sender, EventArgs e)
        {

        }
    }
}

