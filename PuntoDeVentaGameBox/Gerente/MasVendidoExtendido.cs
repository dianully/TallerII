using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace PuntoDeVentaGameBox.Gerente
{
    public partial class MasVendidosExtendido : Form
    {
        private readonly CultureInfo _culturaAR = new CultureInfo("es-AR");

        private readonly DataTable _datos; // guardamos los datos

        public MasVendidosExtendido(DataTable datos)
        {
            InitializeComponent();

            _datos = datos ?? new DataTable();

            // El diseñador tiene engancha este evento con el nombre sin 's'
            this.Load += MasVendidoExtendido_Load;

            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Productos Más Vendidos";
        }

        // Evento que llama el diseñador
        private void MasVendidoExtendido_Load(object sender, EventArgs e)
        {
            DGVMasVendidosExtendido.AutoGenerateColumns = true;
            DGVMasVendidosExtendido.DataSource = _datos;

            DGVMasVendidosExtendido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVMasVendidosExtendido.ReadOnly = true;
            DGVMasVendidosExtendido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            foreach (DataGridViewColumn col in DGVMasVendidosExtendido.Columns)
            {
                col.MinimumWidth = 100;

                // Formato moneda
                if (col.HeaderText.Equals("Ingresos", StringComparison.OrdinalIgnoreCase))
                {
                    col.DefaultCellStyle.FormatProvider = _culturaAR;
                    col.DefaultCellStyle.Format = "C2";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                // Alinear columnas numéricas de unidades
                if (col.HeaderText.IndexOf("Unidades", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }
    }
}
