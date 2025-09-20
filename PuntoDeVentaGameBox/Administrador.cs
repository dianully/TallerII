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
    public partial class Administrador : Form
    {
        public Administrador()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void AbrirFormInPanel(object Formhijo)
        {
            // Verifica si el panel ya tiene un formulario y lo cierra
            if (this.panel3.Controls.Count > 0)
            {
                // Remueve el formulario anterior
                this.panel3.Controls.RemoveAt(0);
            }

            // Convierte el objeto a un formulario para poder usar sus propiedades
            Form fh = Formhijo as Form;

            // Le dice al formulario que no es una ventana independiente
            fh.TopLevel = false;

            // Lo hace invisible para el usuario antes de agregarlo
            fh.FormBorderStyle = FormBorderStyle.None;

            // Ancla el formulario para que llene todo el panel
            fh.Dock = DockStyle.Fill;

            // Agrega el formulario al panel
            this.panel3.Controls.Add(fh);

            // Muestra el formulario
            fh.Show();
        }

        private void BUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new subMenuUsuario());
        }

        private void BCopiaDeSeguridad_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new subMenuCopiaDeSeguridad());
        }

        private void LTitle_Click(object sender, EventArgs e)
        {

        }

        private void Administrador_Load(object sender, EventArgs e)
        {

        }
    }
}
