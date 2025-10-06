using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using static PuntoDeVentaGameBox.Vendedor.Vendedor; // Para acceder a ItemDetalle

namespace PuntoDeVentaGameBox.Clases
{
    public static class Facturacion
    {
        private static string conecctionString = "server=localhost;Database=game_box;Trusted_Connection=True";

        public static bool RegistrarVentaCompleta(
            int idVendedor,
            int? idCliente,
            decimal totalAPagar,
            decimal montoPagado,
            string metodoPago,
            List<ItemDetalle> detallesVenta)
        {
            // Usamos System.Transactions.TransactionScope para asegurar que, si falla alguna parte, 
            // toda la operación (factura, detalles y stock) se revierta.
            using (SqlConnection connection = new SqlConnection(conecctionString))
            {
                SqlTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    // =========================================================
                    // 1. INSERTAR CABECERA DE FACTURA
                    // =========================================================

                    string queryFactura = @"
                        INSERT INTO factura (fecha_compra, total, monto_pagado, metodo_pago, id_cliente, id_usuario)
                        VALUES (@FechaCompra, @Total, @MontoPagado, @MetodoPago, @IdCliente, @IdUsuario);
                        SELECT SCOPE_IDENTITY();"; // Recuperar el ID de la nueva factura

                    int idFactura = 0;
                    using (SqlCommand cmdFactura = new SqlCommand(queryFactura, connection, transaction))
                    {
                        cmdFactura.Parameters.AddWithValue("@FechaCompra", DateTime.Now);
                        cmdFactura.Parameters.AddWithValue("@Total", totalAPagar);
                        cmdFactura.Parameters.AddWithValue("@MontoPagado", montoPagado); // Columna confirmada
                        cmdFactura.Parameters.AddWithValue("@MetodoPago", metodoPago);

                        // Manejo de id_cliente: usa DBNull.Value si es null
                        cmdFactura.Parameters.AddWithValue("@IdCliente", idCliente.HasValue ? (object)idCliente.Value : DBNull.Value);

                        cmdFactura.Parameters.AddWithValue("@IdUsuario", idVendedor);

                        // Ejecutar y obtener el ID de la factura (Importante convertir a decimal y luego a int)
                        object result = cmdFactura.ExecuteScalar();
                        if (result != null)
                        {
                            idFactura = Convert.ToInt32(result);
                        }
                        else
                        {
                            throw new Exception("No se pudo obtener el ID de la factura insertada.");
                        }
                    }

                    // =========================================================
                    // 2. INSERTAR DETALLES Y ACTUALIZAR STOCK
                    // =========================================================

                    string queryDetalle = @"
    INSERT INTO factura_detalle (id_factura_cabecera, id_producto, cantidad, precio)
    VALUES (@IdFactura, @IdProducto, @Cantidad, @Precio);";


                    string queryStock = @"
                        UPDATE producto 
                        SET cantidad_stock = cantidad_stock - @Cantidad 
                        WHERE id_producto = @IdProducto;";

                    foreach (var detalle in detallesVenta)
                    {
                        // 2.1. Cálculo del Precio Unitario
                        // PrecioTotalLinea es el Subtotal de la línea (Cantidad * PrecioUnitario)
                        // Para obtener el Precio Unitario (Precio) = Subtotal / Cantidad
                        decimal precioUnitario = detalle.PrecioTotalLinea / detalle.Cantidad;


                        // 2.2. Insertar Detalle
                        using (SqlCommand cmdDetalle = new SqlCommand(queryDetalle, connection, transaction))
                        {
                            cmdDetalle.Parameters.AddWithValue("@IdFactura", idFactura);
                            cmdDetalle.Parameters.AddWithValue("@IdProducto", detalle.IdProducto);
                            cmdDetalle.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                            cmdDetalle.Parameters.AddWithValue("@Precio", precioUnitario);

                            cmdDetalle.ExecuteNonQuery();
                        }


                        // 2.3. Actualizar Stock
                        using (SqlCommand cmdStock = new SqlCommand(queryStock, connection, transaction))
                        {
                            cmdStock.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                            cmdStock.Parameters.AddWithValue("@IdProducto", detalle.IdProducto);
                            cmdStock.ExecuteNonQuery();
                        }
                    }

                    // =========================================================
                    // 3. CONFIRMAR TRANSACCIÓN
                    // =========================================================
                    transaction.Commit();
                    return true;

                }
                catch (Exception ex)
                {
                    // Si ocurre algún error, revertir todos los cambios
                    if (transaction != null)
                    {
                        try { transaction.Rollback(); }
                        catch (Exception rbEx)
                        {
                            MessageBox.Show($"Error fatal al intentar revertir la transacción: {rbEx.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    // Mostrar el error principal al usuario
                    MessageBox.Show($"Error al registrar la venta y actualizar stock. La transacción fue revertida.\nDetalle: {ex.Message}",
                                    "Error de Transacción SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }
}
