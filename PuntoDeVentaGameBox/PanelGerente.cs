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


            // Asigna el nombre y apellido desde la clase SesionUsuario al label
            LNombreUsuario.Text = $"{SesionUsuario.Nombre} {SesionUsuario.Apellido}";

            // La siguiente línea fue eliminada para evitar que el evento se registre dos veces
            // this.lVendedor.Click += new System.EventHandler(this.lVendedor_Click_1);
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
            SesionUsuario.LimpiarSesion();

            // Oculta el formulario actual
            this.Hide();

            // Crea una nueva instancia del formulario de Login y la muestra
            Login loginForm = new Login();
            loginForm.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {

            // Determina el nombre del rol basado en el IdRol
            string nombreRol = "";
            switch (SesionUsuario.IdRol)
            {
                case 2:
                    nombreRol = "Administrador";
                    break;
                case 3:
                    nombreRol = "Vendedor";
                    break;
                default:
                    nombreRol = "Gerente";
                    break;
            }

            // Abre el formulario de edición, pasando los datos del usuario actual desde la sesión
            EdicionUsuario formEdicion = new EdicionUsuario(
                SesionUsuario.IdUsuario,
                SesionUsuario.Nombre,
                SesionUsuario.Apellido,
                SesionUsuario.Dni,
                SesionUsuario.Email,
                SesionUsuario.Telefono,
                SesionUsuario.Contraseña,
                nombreRol,
                SesionUsuario.IdRol   // 👈 nuevo parámetro

            );

            // Usamos ShowDialog() para que la ventana de edición sea modal.
            formEdicion.ShowDialog();
        }
    }

}

