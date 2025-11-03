using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace PuntoDeVentaGameBox.Gerente
{
    public partial class RendimientosVendedorExtendido : Form
    {
        private readonly CultureInfo _culturaAR = new CultureInfo("es-AR");

        private readonly DataTable _datos;

        public RendimientosVendedorExtendido(DataTable datos)
        {
            InitializeComponent();

            _datos = datos ?? new DataTable();

            this.Load += RendimientosVendedorExtendido_Load;

            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Rendimiento por Vendedor";
        }

        private void RendimientosVendedorExtendido_Load(object sender, EventArgs e)
        {
            DGVRendimientosVendedorExtendido.AutoGenerateColumns = true;
            DGVRendimientosVendedorExtendido.DataSource = _datos;

            DGVRendimientosVendedorExtendido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVRendimientosVendedorExtendido.ReadOnly = true;
            DGVRendimientosVendedorExtendido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            foreach (DataGridViewColumn col in DGVRendimientosVendedorExtendido.Columns)
            {
                col.MinimumWidth = 100;

                // Moneda
                if (col.HeaderText.Equals("Total Dinero en Ventas", StringComparison.OrdinalIgnoreCase) ||
                    col.HeaderText.Equals("Ticket Promedio", StringComparison.OrdinalIgnoreCase))
                {
                    col.DefaultCellStyle.FormatProvider = _culturaAR;
                    col.DefaultCellStyle.Format = "C2";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                // Números enteros
                if (col.HeaderText.Equals("Ventas", StringComparison.OrdinalIgnoreCase))
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }
    }
}
