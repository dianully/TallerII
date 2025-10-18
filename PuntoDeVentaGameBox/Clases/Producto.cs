using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms; // Necesario para MessageBox.Show

namespace PuntoDeVentaGameBox.Clases
{
    public class Producto
    {
        // ====================================================================
        // 1. PROPIEDADES (Modelo de Datos)
        // ====================================================================

        // Propiedades que coinciden con las columnas de tu tabla
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioVenta { get; set; }
        public int CantidadStock { get; set; }
        // Si necesitas otros campos, añádelos aquí (ej: Descripcion, etc.)

        // ====================================================================
        // 2. MÉTODO TOSTRING()
        // ====================================================================

        public override string ToString()
        {
            // Esto fuerza al ComboBox a mostrar el ID en lugar del Nombre
            return IdProducto.ToString();
        }

        // ====================================================================
        // 3. LÓGICA DE ACCESO A DATOS (Métodos Estáticos)
        // ====================================================================

        // La cadena de conexión es fija y privada
        private static readonly string connectionString = "server=localhost;Database=game_box;Trusted_Connection=True";

        /// <summary>
        /// Obtiene una lista con todos los productos (solo ID y Nombre) para cargar el ComboBox.
        /// </summary>
        public static List<Producto> ObtenerTodosLosProductos()
        {
            List<Producto> lista = new List<Producto>();
            // Solo necesitamos ID y Nombre para el ComboBox.
            string query = "SELECT id_producto, nombre FROM producto ORDER BY nombre";

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
                            Producto p = new Producto
                            {
                                IdProducto = Convert.ToInt32(reader["id_producto"]),
                                Nombre = reader["nombre"].ToString()
                                // Los demás campos se llenarán al buscar detalles
                            };
                            lista.Add(p);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar productos: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Opción inicial
            lista.Insert(0, new Producto { IdProducto = 0, Nombre = "-- Seleccione un Producto --" });

            return lista;
        }

        /// <summary>
        /// Busca todos los detalles de un producto por su ID. Se usa al seleccionar un ítem del ComboBox.
        /// </summary>
        public static Producto BuscarDetallesPorId(int idProducto)
        {
            Producto p = null;
            // Consulta que trae todos los campos necesarios para la venta
            string query = "SELECT nombre, precio_venta, cantidad_stock FROM producto WHERE id_producto = @IdProducto";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@IdProducto", idProducto);
                try
                {
                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            p = new Producto
                            {
                                IdProducto = idProducto, // Ya lo conocemos
                                Nombre = reader["nombre"].ToString(),
                                // Se usa Convert.ToDecimal y Convert.ToInt32 para asegurar el tipo
                                PrecioVenta = Convert.ToDecimal(reader["precio_venta"]),
                                CantidadStock = Convert.ToInt32(reader["cantidad_stock"])
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar detalles del producto: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return p;
        }
    }
}