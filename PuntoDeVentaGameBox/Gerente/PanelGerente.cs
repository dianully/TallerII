using System;
using System.Drawing;
using System.Windows.Forms;
using PuntoDeVentaGameBox.Vendedor;
using PuntoDeVentaGameBox.Administrador;
using PuntoDeVentaGameBox.Gerente;

namespace PuntoDeVentaGameBox.Gerente
{
    public partial class PanelGerente : Form
    {
        public PanelGerente()
        {
            InitializeComponent();

            if (LNombreUsuario != null)
                LNombreUsuario.Text = $"{SesionUsuario.Nombre} {SesionUsuario.Apellido}";

            // ÚNICO scroll: el contenedor
            PVistaGerente.AutoScroll = true;
            PVistaGerente.HorizontalScroll.Enabled = false;
            PVistaGerente.HorizontalScroll.Visible = false;
            PVistaGerente.AutoScrollMargin = new Size(0, 8);

            this.DoubleBuffered = true;
            PVistaGerente.GetType().GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(PVistaGerente, true, null);
        }

        private void CargarEnPanel(Form hijo)
        {
            PVistaGerente.Resize -= PVistaGerente_ResizeSync;

            foreach (Control c in PVistaGerente.Controls) c.Dispose();
            PVistaGerente.Controls.Clear();

            hijo.TopLevel = false;
            hijo.FormBorderStyle = FormBorderStyle.None;
            hijo.AutoScroll = false;          // los hijos no scrollean
            hijo.Dock = DockStyle.Fill;

            PVistaGerente.Controls.Add(hijo);
            hijo.Show();

            PVistaGerente.Resize += PVistaGerente_ResizeSync;
        }

        private void PVistaGerente_ResizeSync(object sender, EventArgs e)
        {
            if (PVistaGerente.Controls.Count == 1 && PVistaGerente.Controls[0] is Form f)
                f.Width = PVistaGerente.ClientSize.Width;
        }

        private void PVistaGerente_Paint(object sender, PaintEventArgs e) { }
        private void PanelGerente_Load(object sender, EventArgs e) { }

        private void BInventario_Click(object sender, EventArgs e)
        {
            CargarEnPanel(new InventarioForm()); // cambia el nombre si tu form es otro
        }

        private void BReportes_Click(object sender, EventArgs e)
        {
            CargarEnPanel(new Reportes());
        }

        private void BProveedores_Click(object sender, EventArgs e)
        {
            CargarEnPanel(new Proveedores());
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            SesionUsuario.LimpiarSesion();
            this.Hide();
            var login = new Login();
            login.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string nombreRol;
            switch (SesionUsuario.IdRol) // ✅ switch clásico (C# 7.3)
            {
                case 2: nombreRol = "Administrador"; break;
                case 3: nombreRol = "Vendedor"; break;
                default: nombreRol = "Gerente"; break;
            }

            var formEdicion = new EdicionUsuario(
                SesionUsuario.IdUsuario,
                SesionUsuario.Nombre,
                SesionUsuario.Apellido,
                SesionUsuario.Dni,
                SesionUsuario.Email,
                SesionUsuario.Telefono,
                SesionUsuario.Contraseña,
                nombreRol,
                SesionUsuario.IdRol
            );

            formEdicion.ShowDialog();
        }
    }
}
