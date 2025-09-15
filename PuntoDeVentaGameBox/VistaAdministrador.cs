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
    public partial class VistaAdministrador : Form
    {
        public VistaAdministrador()
        {
            InitializeComponent();
        }

        private void VistaAdministrador_Load(object sender, EventArgs e)
        {





        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form formularioAbierto in this.MdiChildren)
            {
                // 2. Verifica si el formulario ya es del tipo subMenuUsuario
                if (formularioAbierto is subMenuUsuario)
                {
                    // 3. Si lo encuentra, lo trae al frente y termina el proceso
                    formularioAbierto.BringToFront();
                    return;
                }
            }

            // 4. Si el formulario no está abierto, crea una nueva instancia
            subMenuUsuario usuariosForm = new subMenuUsuario();
            usuariosForm.MdiParent = this; // Le dice al nuevo formulario quién es su padre
            usuariosForm.Dock = DockStyle.Fill;
            usuariosForm.Show();
        }

        private void copiaDeSeguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form formularioAbierto in this.MdiChildren)
            {
                // 2. Verifica si el formulario ya es del tipo subMenuCopiaDeSeguridad
                if (formularioAbierto is subMenuCopiaDeSeguridad)
                {
                    // 3. Si lo encuentra, lo trae al frente y termina el proceso
                    formularioAbierto.BringToFront();
                    return;
                }
            }

            // 4. Si el formulario no está abierto, crea una nueva instancia
            subMenuCopiaDeSeguridad copiaSeguridadForm = new subMenuCopiaDeSeguridad();
            copiaSeguridadForm.MdiParent = this; // Le dice al nuevo formulario quién es su padre
            copiaSeguridadForm.Dock = DockStyle.Fill;
            copiaSeguridadForm.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
