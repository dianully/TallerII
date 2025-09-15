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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BIngresar_Click(object sender, EventArgs e)
        {
            //Vendedor siguientePagina = new Vendedor();
            subMenuUsuario siguientePagina = new subMenuUsuario();
            
            siguientePagina.Show();

            this.Hide();
        }
    }
}
