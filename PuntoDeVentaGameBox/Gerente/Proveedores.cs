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

namespace PuntoDeVentaGameBox.Gerente
{
    public partial class Proveedores : Form
    {
        public Proveedores()
        {
            InitializeComponent();

            // Aseguramos eventos aunque el diseñador no los tenga enlazados
            this.Load -= Proveedores_Load;
            this.Load += Proveedores_Load;

            DGVDatosProveedores.CellContentClick -= DGVDatosProveedores_CellContentClick;
            DGVDatosProveedores.CellContentClick += DGVDatosProveedores_CellContentClick;

            // Texto en negro para toda la grilla
            DGVDatosProveedores.DefaultCellStyle.ForeColor = Color.Black;
            DGVDatosProveedores.RowsDefaultCellStyle.ForeColor = Color.Black;
            DGVDatosProveedores.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BNuevoProveedor_Click(object sender, EventArgs e)
        {
            AgregarProveedor nuevoproveedor = new AgregarProveedor();
            nuevoproveedor.Show();
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            // --- Datos de ejemplo ---
            // Columnas esperadas: Nombre, Direccion, Telefono, Correo, (Ver), Editar, Eliminar
            DGVDatosProveedores.Rows.Add("Tech Supplies SRL", "Av. Siempre Viva 742", "1122334455", "ventas@techsupplies.com");
            DGVDatosProveedores.Rows.Add("Gamers World", "Calle Pixel 1200", "1198765432", "contacto@gamersworld.com");
            DGVDatosProveedores.Rows.Add("Distribuidora Norte", "Ruta 3 KM 45", "1133344556", "info@distnorte.com");
            DGVDatosProveedores.Rows.Add("ElectroMax", "Bv. Central 150", "1144455566", "soporte@electromax.com");
            DGVDatosProveedores.Rows.Add("Nova Import", "Parque Ind. Lote 5", "1177788899", "comercial@novaimport.com");

            // --- Asegurar que haya exactamente UNA columna Editar y UNA Eliminar (como botones) ---
            NormalizarBotonAccion("Editar");
            NormalizarBotonAccion("Eliminar");
        }

        private void DGVDatosProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = DGVDatosProveedores.Columns[e.ColumnIndex];
            string name = col.Name ?? "";
            string header = col.HeaderText ?? "";

            bool esEditar = name.Equals("Editar", StringComparison.OrdinalIgnoreCase) ||
                            header.Equals("Editar", StringComparison.OrdinalIgnoreCase);

            bool esEliminar = name.Equals("Eliminar", StringComparison.OrdinalIgnoreCase) ||
                              header.Equals("Eliminar", StringComparison.OrdinalIgnoreCase);

            if (esEditar)
            {
                // Abre el formulario de edición
                using (var frm = new EditarProveedor())
                {
                    frm.ShowDialog(this);
                }
            }
            else if (esEliminar)
            {
                var fila = DGVDatosProveedores.Rows[e.RowIndex];
                string nombre = Convert.ToString(
                    fila.Cells.Cast<DataGridViewCell>()
                        .FirstOrDefault(c => c.OwningColumn.Name.Equals("Nombre", StringComparison.OrdinalIgnoreCase) ||
                                             c.OwningColumn.HeaderText.Equals("Nombre", StringComparison.OrdinalIgnoreCase))?.Value
                );

                var resp = MessageBox.Show(
                    $"¿Eliminar al proveedor \"{nombre}\"?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resp == DialogResult.Yes)
                {
                    // Aquí podrías llamar a tu eliminación en BD; por ahora removemos la fila de la grilla
                    DGVDatosProveedores.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        // ================= Helpers =================

        /// <summary>
        /// Garantiza que exista exactamente UNA columna botón con el título indicado.
        /// Si hay duplicadas, deja la primera y elimina el resto. Si no es botón, la reemplaza.
        /// Además fuerza texto visible y color negro.
        /// </summary>
        private void NormalizarBotonAccion(string titulo)
        {
            var coinciden = DGVDatosProveedores.Columns
                .Cast<DataGridViewColumn>()
                .Where(c => string.Equals(c.Name, titulo, StringComparison.OrdinalIgnoreCase) ||
                            string.Equals(c.HeaderText, titulo, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (coinciden.Count == 0)
            {
                DGVDatosProveedores.Columns.Add(NuevaColumnaBoton(titulo));
                return;
            }

            // Dejar solo una
            for (int i = 1; i < coinciden.Count; i++)
                DGVDatosProveedores.Columns.Remove(coinciden[i]);

            // Asegurar que sea botón y con texto visible
            var col = coinciden[0];
            if (!(col is DataGridViewButtonColumn))
            {
                int idx = col.Index;
                DGVDatosProveedores.Columns.Remove(col);
                DGVDatosProveedores.Columns.Insert(idx, NuevaColumnaBoton(titulo));
            }
            else
            {
                var btn = (DataGridViewButtonColumn)col;
                btn.Text = titulo;
                btn.UseColumnTextForButtonValue = true;
                btn.HeaderText = titulo;
                btn.Name = titulo;
                btn.DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private DataGridViewButtonColumn NuevaColumnaBoton(string titulo)
        {
            return new DataGridViewButtonColumn
            {
                Name = titulo,
                HeaderText = titulo,
                Text = titulo,
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Popup,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    ForeColor = Color.Black
                }
            };
        }
    }
}
