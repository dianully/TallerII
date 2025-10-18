using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVentaGameBox.Clases
{
    public class Cliente
    {
        // ====================================================================
        // 1. PROPIEDADES (Modelo de Datos)
        // ====================================================================

        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; } // Usado como DisplayMember en el ComboBox
        public string Email { get; set; }
        public string Genero { get; set; } // Corresponde a 'tbSexo' en el formulario
        public string Telefono { get; set; }
        // public int Activo { get; set; } // Puedes incluir este si lo necesitas

        // ====================================================================
        // 2. MÉTODO TOSTRING()
        // ====================================================================

        public override string ToString()
        {
            // Usamos el DNI como el texto a mostrar en el ComboBox, tal como solicitaste.
            // Esto permite que el ComboBox actúe como buscador por DNI.
            return Dni.ToString();
        }

        // ====================================================================
        // 3. LÓGICA DE ACCESO A DATOS (Métodos Estáticos)
        // ====================================================================

        private static readonly string connectionString = "server=localhost;Database=game_box;Trusted_Connection=True";

        /// <summary>
        /// Obtiene una lista con todos los clientes (ID y DNI) para cargar el ComboBox.
        /// </summary>
        public static List<Cliente> ObtenerTodosLosClientes()
        {
            List<Cliente> lista = new List<Cliente>();
            string query = "SELECT id_cliente, dni FROM cliente WHERE activo = 1 ORDER BY dni";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                try
                {
                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente c = new Cliente
                            {
                                IdCliente = Convert.ToInt32(reader["id_cliente"]),
                                Dni = Convert.ToInt32(reader["dni"])
                            };
                            lista.Add(c);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Opción inicial: Cliente "General" o "No Seleccionado"
            lista.Insert(0, new Cliente { IdCliente = 0, Dni = 0, Nombre = "Cliente General" });

            return lista;
        }

        /// <summary>
        /// Busca todos los detalles de un cliente por su DNI. Se usa al seleccionar el ComboBox.
        /// </summary>
        public static Cliente BuscarDetallesPorDni(int dni)
        {
            Cliente c = null;
            string query = "SELECT id_cliente, nombre, apellido, email, genero, telefono FROM cliente WHERE dni = @Dni";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@Dni", dni);
                try
                {
                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            c = new Cliente
                            {
                                IdCliente = Convert.ToInt32(reader["id_cliente"]),
                                Dni = dni, // Ya lo conocemos
                                Nombre = reader["nombre"].ToString(),
                                Apellido = reader["apellido"].ToString(),
                                Email = reader["email"].ToString(),
                                Genero = reader["genero"].ToString(),
                                Telefono = reader["telefono"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar detalles del cliente: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return c;
        }
    }
}
