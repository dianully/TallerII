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

namespace PuntoDeVentaGameBox.Administrador
{
    public partial class AgregarCliente : Form
    {
        public AgregarCliente()
        {
            InitializeComponent();
        }

        private void bSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bRegistrarCliente_Click(object sender, EventArgs e)
        {
            string nombre = tNombre.Text.Trim();
            string apellido = tApellido.Text.Trim();
            string dniTexto = tDni.Text.Trim();
            string email = tEmail.Text.Trim();
            string telefono = tTelefono.Text.Trim();
            string genero = cbGenero.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(dniTexto) || string.IsNullOrEmpty(genero))
            {
                MessageBox.Show("Debe completar todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(dniTexto, out int dni))
            {
                MessageBox.Show("El DNI debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "server=localhost;Database=game_box;Trusted_Connection=True";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string insertCliente = @"INSERT INTO cliente (nombre, apellido, dni, email, genero, telefono, activo)
                                 VALUES (@nombre, @apellido, @dni, @email, @genero, @telefono, 1);
                                 SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(insertCliente, conexion))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@dni", dni);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@genero", genero);
                    cmd.Parameters.AddWithValue("@telefono", telefono);

                    conexion.Open();
                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {
                        MessageBox.Show("Cliente registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 🔁 Enviar datos al formulario Vendedor
                        foreach (Form form in Application.OpenForms)
                        {
                            if (form is Vendedor.Vendedor vendedorForm)
                            {
                                vendedorForm.SetCliente($"{nombre} {apellido}");
                                vendedorForm.SetDniCliente(dni.ToString());
                                break;
                            }
                        }

                        this.Close(); // Cierra el formulario AgregarCliente
                    }
                    else
                    {
                        MessageBox.Show("No se pudo registrar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}
