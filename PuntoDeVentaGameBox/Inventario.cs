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
    public partial class InventarioForm : Form
    {
        public InventarioForm()
        {
            InitializeComponent();

            // Asegurar que el click de celdas del DGV dispare nuestro handler
            DGV.CellContentClick -= DGV_CellContentClick;
            DGV.CellContentClick += DGV_CellContentClick;

            // Texto en negro para todas las filas
            DGV.DefaultCellStyle.ForeColor = Color.Black;
            DGV.RowsDefaultCellStyle.ForeColor = Color.Black;
            DGV.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void TLRoot_Paint(object sender, PaintEventArgs e) { }
        private void PFilters_Paint(object sender, PaintEventArgs e) { }
        private void LSub_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void LProductostotales_Click(object sender, EventArgs e) { }
        private void LUnidadeseninventario_Click(object sender, EventArgs e) { }
        private void LblBanner_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e) { }
        private void TBID_TextChanged(object sender, EventArgs e) { }
        private void LTitle_Click(object sender, EventArgs e) { }

        private void InventarioForm_Load(object sender, EventArgs e)
        {
            // Cargar datos de ejemplo (Columnas esperadas: ID, Imagen, Nombre, Género, Precio, Stock)
            DGV.Rows.Add(1, @"C:\Imagenes\Juegos\elden_ring.jpg", "Elden Ring", "RPG", 79.99m, 8);
            DGV.Rows.Add(2, @"C:\Imagenes\Juegos\fifa25.jpg", "FIFA 25", "Deportes", 69.99m, 15);
            DGV.Rows.Add(3, @"C:\Imagenes\Juegos\minecraft.png", "Minecraft", "Aventura", 29.99m, 30);
            DGV.Rows.Add(4, @"C:\Imagenes\Juegos\god_of_war.jpg", "God of War", "Acción", 59.99m, 12);
            DGV.Rows.Add(5, @"C:\Imagenes\Juegos\fortnite.jpg", "Fortnite", "Shooter", 0.00m, 99);

            // Dejar exactamente UNA columna Editar y UNA Eliminar (y que sean botones con texto)
            NormalizarBotonAccion("Editar");
            NormalizarBotonAccion("Eliminar");
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = DGV.Columns[e.ColumnIndex];
            string name = col.Name ?? "";
            string header = col.HeaderText ?? "";

            bool esEditar = name.Equals("Editar", StringComparison.OrdinalIgnoreCase) ||
                            header.Equals("Editar", StringComparison.OrdinalIgnoreCase);
            bool esEliminar = name.Equals("Eliminar", StringComparison.OrdinalIgnoreCase) ||
                              header.Equals("Eliminar", StringComparison.OrdinalIgnoreCase);

            if (esEditar)
            {
                // Abrir el formulario EditarProducto (modal)
                using (var frm = new EditarProducto())
                {
                    frm.ShowDialog(this);
                }
            }
            else if (esEliminar)
            {
                var fila = DGV.Rows[e.RowIndex];

                // Obtener el nombre de forma robusta (por Name, por HeaderText o por índice 2)
                string nombre = GetCellText(DGV, fila, "Nombre");
                if (string.IsNullOrWhiteSpace(nombre) && DGV.Columns.Count > 2)
                    nombre = Convert.ToString(fila.Cells[2].Value); // 0=ID, 1=Imagen, 2=Nombre según Rows.Add

                var resp = MessageBox.Show(
                    $"¿Eliminar el producto \"{nombre}\"?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resp == DialogResult.Yes)
                {
                    // Aquí podrías llamar a tu eliminación en BD; por ahora removemos la fila de la grilla
                    DGV.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        // ================= Helpers =================

        /// <summary>
        /// Garantiza que exista exactamente UNA columna botón con el header y nombre indicados.
        /// Si hay duplicadas, deja la primera y elimina el resto. Si no es botón, la reemplaza por una de botón.
        /// Asegura texto visible y color negro en el botón.
        /// </summary>
        private void NormalizarBotonAccion(string titulo)
        {
            // Buscar columnas que coincidan por Name o HeaderText
            var coinciden = DGV.Columns
                .Cast<DataGridViewColumn>()
                .Where(c => string.Equals(c.Name, titulo, StringComparison.OrdinalIgnoreCase) ||
                            string.Equals(c.HeaderText, titulo, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (coinciden.Count == 0)
            {
                // No existe: crearla
                var btn = NuevaColumnaBoton(titulo);
                DGV.Columns.Add(btn);
            }
            else
            {
                // Dejar solo una
                for (int i = 1; i < coinciden.Count; i++)
                    DGV.Columns.Remove(coinciden[i]);

                // Asegurar que sea botón y tenga texto visible
                var col = coinciden[0];
                if (!(col is DataGridViewButtonColumn))
                {
                    int idx = col.Index;
                    DGV.Columns.Remove(col);
                    DGV.Columns.Insert(idx, NuevaColumnaBoton(titulo));
                }
                else
                {
                    var btn = (DataGridViewButtonColumn)col;
                    btn.Text = titulo;
                    btn.UseColumnTextForButtonValue = true;
                    btn.DefaultCellStyle.ForeColor = Color.Black;
                    btn.HeaderText = titulo;
                    btn.Name = titulo; // normalizamos el Name
                }
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

        /// <summary>
        /// Devuelve el texto de una celda buscando primero por Name exacto,
        /// luego por HeaderText y, si no existe, retorna null.
        /// </summary>
        private string GetCellText(DataGridView grid, DataGridViewRow row, params string[] posiblesNombres)
        {
            foreach (var n in posiblesNombres)
            {
                // 1) Por Name exacto
                if (grid.Columns.Contains(n))
                    return Convert.ToString(row.Cells[n].Value);

                // 2) Por HeaderText (o Name con otra capitalización)
                var col = grid.Columns.Cast<DataGridViewColumn>()
                    .FirstOrDefault(c =>
                        string.Equals(c.HeaderText, n, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(c.Name, n, StringComparison.OrdinalIgnoreCase));

                if (col != null)
                    return Convert.ToString(row.Cells[col.Index].Value);
            }
            return null;
        }

        private void BNuevoproducto_Click(object sender, EventArgs e)
        {
            using (var frm = new AgregarProducto())
            {
                frm.ShowDialog(this);
            }
        }
    }
}
