using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuntoDeVentaGameBox.Vendedor;
using PuntoDeVentaGameBox.Administrador;
using PuntoDeVentaGameBox.Gerente;

namespace PuntoDeVentaGameBox.Administrador
{
    public partial class Administrador : Form
    {
        public Administrador()
        {
            InitializeComponent();
            // Asigna el nombre y apellido del usuario logueado al label lAdministrador
            lAdministrador.Text = $"{SesionUsuario.Nombre} {SesionUsuario.Apellido}";
        }

        //

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

        private void label3_Click(object sender, EventArgs e)
        {

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

        private void lAdministrador_Click_1(object sender, EventArgs e)
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

