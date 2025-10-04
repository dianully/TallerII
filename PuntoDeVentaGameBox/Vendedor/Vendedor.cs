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

namespace PuntoDeVentaGameBox.Vendedor
{
    public partial class Vendedor : Form
    {
        // Constructor
        public Vendedor()
        {
            InitializeComponent();
            // Asigna el nombre y apellido desde la clase SesionUsuario al label
            lVendedor.Text = $"{SesionUsuario.Nombre} {SesionUsuario.Apellido}";

            // Aplica la validación para que solo acepte números en el DNI del cliente
            //AplicarSoloNumeros(TBDniCliente);

            // Aplica la validación para que el correo contenga '@' y '.com'
            tbClienteGmail.TextChanged += tClienteGmail_TextChanged;

            // La siguiente línea fue eliminada para evitar que el evento se registre dos veces
            // this.lVendedor.Click += new System.EventHandler(this.lVendedor_Click_1);


            // >>> CAMBIO CLAVE AQUÍ: AUMENTAR EL TAMAÑO DE LA FUENTE <<<
            tbMontoPagado.Font = new Font(tbMontoPagado.Font.FontFamily, 14, FontStyle.Regular);
            // Puedes probar con 16 si 14 no es suficiente.

            // Configuración inicial del Placeholder
            tbMontoPagado.Text = "Ingresar Monto";
            tbMontoPagado.ForeColor = Color.Gray;

            // Asignar los eventos
            tbMontoPagado.Enter += tbMontoPagado_Enter;
            tbMontoPagado.Leave += tbMontoPagado_Leave;
        }

        private void tbMontoPagado_Enter(object sender, EventArgs e)
        {
            if (tbMontoPagado.Text == "Ingresar Monto")
            {
                tbMontoPagado.Text = "";
                tbMontoPagado.ForeColor = Color.Black; // Cambia el color a uno normal

                // Opcional: Si quieres que el texto escrito sea negrita
                // tbMontoPagado.Font = new Font(tbMontoPagado.Font.FontFamily, 14, FontStyle.Bold); 
            }
        }

        private void tbMontoPagado_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbMontoPagado.Text))
            {
                tbMontoPagado.Text = "Ingresar Monto";
                tbMontoPagado.ForeColor = Color.Gray; // Restaura el color del placeholder

                // Asegúrate de que el estilo de fuente se mantenga si lo cambiaste en Enter
                // tbMontoPagado.Font = new Font(tbMontoPagado.Font.FontFamily, 14, FontStyle.Regular); 
            }
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


        private void gbCliente_Enter(object sender, EventArgs e)
        {

        }

        private void lVendedor_Click_1(object sender, EventArgs e)
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
                SesionUsuario.IdRol
            );

            // Usamos ShowDialog() para que la ventana de edición sea modal.
            formEdicion.ShowDialog();
        }

        // Método para validar el formato del correo
        private void tClienteGmail_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (!string.IsNullOrEmpty(textBox.Text))
                {
                    // Verifica si el texto contiene '@' y '.com'
                    if (!textBox.Text.Contains("@") || !textBox.Text.Contains(".com"))
                    {
                        // Puedes mostrar una advertencia visual o simplemente no permitir el siguiente paso
                        // Por ahora, no haremos nada para no interrumpir la escritura.
                    }
                }
            }
        }

        // ======== MÉTODO REUTILIZABLE: SOLO NÚMEROS ========
        /// <summary>
        /// Hace que el TextBox acepte únicamente dígitos (tecleo y pegado).
        /// </summary>
        private void AplicarSoloNumeros(TextBox tb)
        {
            // KeyPress: bloquea cualquier char no numérico
            tb.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };

            // TextChanged: limpia si pegaron contenido no numérico
            tb.TextChanged += (s, e) =>
            {
                var t = (TextBox)s;
                int sel = t.SelectionStart;
                string solo = new string(t.Text.Where(char.IsDigit).ToArray());
                if (solo != t.Text)
                {
                    t.Text = solo;
                    t.SelectionStart = Math.Min(sel, t.Text.Length);
                }
            };
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Vendedor_Load(object sender, EventArgs e)
        {

        }
    }
}

