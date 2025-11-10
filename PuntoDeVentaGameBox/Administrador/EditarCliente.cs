using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions; // Usar Regex para una mejor validación de email
using System.Windows.Forms;

namespace PuntoDeVentaGameBox.Administrador
{
    // Asegúrate de que este Formulario sea accesible desde donde lo llamas.
    public partial class EditarClientes : Form
    {
        private int idCliente;
        private string connectionString = "server=localhost;Database=game_box;Trusted_Connection=True";
        private int idGeneroOriginal; // Almacena el ID original para referencia

        // Constructor para cargar los datos del cliente a editar
        public EditarClientes(int id, string nombre, string apellido, string dni, string email, string telefono, string genero, int idGenero)
        {
            InitializeComponent();

            // 👉 Solo números en DNI y Teléfono
            AttachNumericOnlyHandlers();

            // 👉 Limites de longitud (ajustados a los estándares comunes de Argentina)
            tEditarDni.MaxLength = 8;
            tEditarTelefono.MaxLength = 10;

            // Carga las opciones de Género en el ComboBox
            CargarGeneros();

            this.idCliente = id;
            this.idGeneroOriginal = idGenero;

            // Asignación de valores a los TextBoxes
            tEditarNombre.Text = nombre;
            tEditarApellido.Text = apellido;
            tEditarDni.Text = dni;
            tEditarEmail.Text = email;
            tEditarTelefono.Text = telefono;
            // No se usa tEditarContraseña ya que los clientes no tienen ese campo

            // Seleccionar el Género en el ComboBox
            if (cbGenero.Items.Count > 0 && !string.IsNullOrEmpty(genero))
            {
                // Busca y selecciona el nombre del género
                cbGenero.SelectedIndex = cbGenero.FindStringExact(genero);
            }

            // Si no encontró el género en el combo (por nombre), setea el original por valor
            if (cbGenero.SelectedIndex == -1 && idGeneroOriginal > 0)
            {
                cbGenero.SelectedValue = idGeneroOriginal;
            }
        }

        public EditarClientes()
        {
            InitializeComponent();
            AttachNumericOnlyHandlers();
            tEditarDni.MaxLength = 8;
            tEditarTelefono.MaxLength = 10;
        }
        
        // -----------------------------------------------------
        // MÉTODOS DE SOPORTE
        // -----------------------------------------------------

        /// <summary>
        /// Carga las opciones de Género (asumiendo que hay una tabla 'genero' con id_genero y nombre).
        /// </summary>
        private void CargarGeneros()
        {
            // Ajusta esta query si tu tabla de géneros es diferente.
            // Aquí se asume una tabla llamada 'genero'.
            string query = "SELECT id_genero, nombre FROM genero"; 
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable generosTable = new DataTable();
                    adapter.Fill(generosTable);

                    cbGenero.DataSource = generosTable;
                    cbGenero.DisplayMember = "nombre";
                    cbGenero.ValueMember = "id_genero";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los géneros: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Verifica si el DNI ya existe en la tabla de clientes para otro cliente.
        /// </summary>
        private bool DniYaExiste(string dni, int idClienteActual)
        {
            // MODIFICADO: Busca en la tabla 'cliente'
            string query = "SELECT COUNT(*) FROM cliente WHERE dni = @dni AND id_cliente != @idCliente";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@dni", dni);
                    command.Parameters.AddWithValue("@idCliente", idClienteActual);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        /// <summary>
        /// Verifica si el Email ya existe en la tabla de clientes para otro cliente.
        /// </summary>
        private bool EmailYaExiste(string email, int idClienteActual)
        {
            // MODIFICADO: Busca en la tabla 'cliente'
            string query = "SELECT COUNT(*) FROM cliente WHERE email = @email AND id_cliente != @idCliente";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@idCliente", idClienteActual);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // -----------------------------------------------------
        // LÓGICA DE ACTUALIZACIÓN
        // -----------------------------------------------------

        private void bEditarCliente_Click(object sender, EventArgs e)
        {
            ActualizarCliente();
        }

        private void ActualizarCliente()
        {
            // Validaciones de campos obligatorios
            if (string.IsNullOrWhiteSpace(tEditarNombre.Text) ||
                string.IsNullOrWhiteSpace(tEditarApellido.Text) ||
                string.IsNullOrWhiteSpace(tEditarDni.Text) ||
                string.IsNullOrWhiteSpace(tEditarEmail.Text) ||
                string.IsNullOrWhiteSpace(tEditarTelefono.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos (excepto contraseña, que no aplica).", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validación de DNI (8 caracteres)
            if (tEditarDni.Text.Length != 8)
            {
                MessageBox.Show("El DNI debe tener exactamente 8 caracteres.", "DNI Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validación de DNI duplicado
            if (DniYaExiste(tEditarDni.Text, this.idCliente))
            {
                MessageBox.Show("El DNI ingresado ya existe en la base de datos para otro cliente.", "DNI Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validación de Teléfono (10 caracteres, ajusta si es necesario)
            if (tEditarTelefono.Text.Length != 10)
            {
                MessageBox.Show("El teléfono debe tener exactamente 10 caracteres.", "Teléfono Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validación de formato de Email (mejorada con Regex)
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(tEditarEmail.Text, emailPattern))
            {
                MessageBox.Show("El correo electrónico no tiene un formato válido.", "Correo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validación de Email duplicado
            if (EmailYaExiste(tEditarEmail.Text, this.idCliente))
            {
                MessageBox.Show("Este correo electronico ya está registrado. Por favor inserte otro.", "Correo Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Query de ACTUALIZACIÓN para la tabla 'cliente'
            string query = "UPDATE cliente SET nombre = @nombre, apellido = @apellido, dni = @dni, email = @email, telefono = @telefono, id_genero = @idGenero WHERE id_cliente = @idCliente";

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombre", tEditarNombre.Text);
                        command.Parameters.AddWithValue("@apellido", tEditarApellido.Text);
                        command.Parameters.AddWithValue("@dni", tEditarDni.Text);
                        command.Parameters.AddWithValue("@email", tEditarEmail.Text);
                        command.Parameters.AddWithValue("@telefono", tEditarTelefono.Text);
                        
                        // Determinar el ID de Género a actualizar
                        int idGeneroParaActualizar;
                        if (cbGenero.SelectedValue == null)
                            idGeneroParaActualizar = idGeneroOriginal; // Usa el original si no se seleccionó nada
                        else
                            idGeneroParaActualizar = Convert.ToInt32(cbGenero.SelectedValue);

                        command.Parameters.Add("@idGenero", SqlDbType.Int).Value = idGeneroParaActualizar;

                        // 🔒 Aseguramos que el WHERE reciba el id correcto
                        command.Parameters.AddWithValue("@idCliente", this.idCliente);

                        connection.Open();

                        int filas = command.ExecuteNonQuery();

                        if (filas == 0)
                        {
                            MessageBox.Show(
                                $"No se encontró el cliente con id {this.idCliente}. No se realizó ninguna actualización.",
                                "Sin cambios",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                            return;
                        }

                        MessageBox.Show("Cliente actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void bSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void button1_Click(object sender, EventArgs e) // Asumo que es el botón "Limpiar"
        {
            tEditarApellido.Clear();
            tEditarDni.Clear();
            tEditarEmail.Clear();
            tEditarTelefono.Clear();
            tEditarNombre.Clear();
            cbGenero.SelectedIndex = -1; // Deseleccionar el género si es posible
        }

        /// <summary>
        /// Engancha handlers para permitir únicamente dígitos en DNI y Teléfono.
        /// </summary>
        private void AttachNumericOnlyHandlers()
        {
            tEditarDni.KeyPress += SoloDigitos_KeyPress;
            tEditarTelefono.KeyPress += SoloDigitos_KeyPress;

            tEditarDni.TextChanged += SoloDigitos_TextChanged;
            tEditarTelefono.TextChanged += SoloDigitos_TextChanged;
        }

        private void SoloDigitos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void SoloDigitos_TextChanged(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (tb == null) return;

            int sel = tb.SelectionStart;
            string soloDigitos = new string(tb.Text.Where(char.IsDigit).ToArray());
            if (soloDigitos != tb.Text)
            {
                tb.Text = soloDigitos;
                tb.SelectionStart = Math.Min(sel, tb.Text.Length);
            }
        }
        
        // Métodos de evento vacíos o no utilizados (se mantienen para compatibilidad)
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void tEditarDni_TextChanged(object sender, EventArgs e) { }
    }
}