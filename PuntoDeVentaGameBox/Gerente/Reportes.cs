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
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();

            // Wire seguro (evita doble suscripción si el diseñador ya los conectó)
            if (BVerGraficosProductos != null)
            {
                BVerGraficosProductos.Click -= BVerGraficosProductos_Click;
                BVerGraficosProductos.Click += BVerGraficosProductos_Click;
            }

            if (BVerGraficosVendedores != null)
            {
                BVerGraficosVendedores.Click -= BVerGraficosVendedores_Click;
                BVerGraficosVendedores.Click += BVerGraficosVendedores_Click;
            }
        }

        private void BVerGraficosProductos_Click(object sender, EventArgs e)
        {
            // Si más adelante querés pasar rango de fechas, se lo agregamos aquí
            using (var frm = new GraficosProductos())
            {
                frm.ShowDialog(this);
            }
        }

        private void BVerGraficosVendedores_Click(object sender, EventArgs e)
        {
            using (var frm = new GraficosVendedores())
            {
                frm.ShowDialog(this);
            }
        }

        // ==== Stubs que tu diseñador ya usa (no tocar) ====
        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e) { }
        private void LResumenTitulo_Click(object sender, EventArgs e) { }
        private void PHeader_Paint(object sender, PaintEventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) { }
        private void TPLRoot_Paint(object sender, PaintEventArgs e) { }
        private void PNLScroll_Paint(object sender, PaintEventArgs e) { }
        private void Reportes_Load(object sender, EventArgs e) { }

        private void GVTopProductos_Enter(object sender, EventArgs e)
        {

        }
    }
}
