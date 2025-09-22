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
    public partial class PanelGerente : Form
    {
        public PanelGerente()
        {
            InitializeComponent();
        }
        private void AbrirFormInPanel(object Formhijo)
        {
            // Verifica si el panel ya tiene un formulario y lo cierra
            if (this.PVistaGerente.Controls.Count > 0)
            {
                // Remueve el formulario anterior
                this.PVistaGerente.Controls.RemoveAt(0);
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
            this.PVistaGerente.Controls.Add(fh);

            // Muestra el formulario
            fh.Show();
        }

        private void PVistaGerente_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelGerente_Load(object sender, EventArgs e)
        {

        }

        private void BInventario_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new InventarioForm());
        }

        private void BReportes_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Reportes());
        }

        private void BProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Proveedores());
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
