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
using System.Data.SqlClient;

namespace PuntoDeVentaGameBox.Administrador
{
    public partial class subMenuCopiaDeSeguridad : Form
    {

        private static readonly string connectionString = "server=localhost;Database=game_box;Trusted_Connection=True";

        public subMenuCopiaDeSeguridad()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(Properties.Settings.Default.UltimaFecha))
            {
                lFechaCopia.Text = Properties.Settings.Default.UltimaFecha;
            }

            if (!string.IsNullOrEmpty(Properties.Settings.Default.RutaBackup))
            {
                tbRutaDeGuardado.Text = Properties.Settings.Default.RutaBackup;
            }
        }

        private void bElegirRuta_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Selecciona la carpeta donde guardar la copia de seguridad";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    tbRutaDeGuardado.Text = fbd.SelectedPath;
                    Properties.Settings.Default.RutaBackup = fbd.SelectedPath;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void bCopiaDeSeguridad_Click(object sender, EventArgs e)
        {
            string ruta = tbRutaDeGuardado.Text.Trim();
            if (string.IsNullOrEmpty(ruta))
            {
                MessageBox.Show("⚠️ Por favor, selecciona una ruta de guardado.");
                return;
            }

            string nombreBD = "game_box";
            string archivoBackup = $"{ruta}\\{nombreBD}_backup.bak";

            string query = $@"
                BACKUP DATABASE [{nombreBD}]
                TO DISK = N'{archivoBackup}'
                WITH FORMAT, INIT, NAME = N'CopiaCompleta', SKIP, NOREWIND, NOUNLOAD, STATS = 10;
            ";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("✅ Copia de seguridad realizada con éxito.");

                        // Actualizar la fecha en el label
                        lFechaCopia.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        Properties.Settings.Default.UltimaFecha = lFechaCopia.Text;
                        Properties.Settings.Default.Save();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al realizar la copia: " + ex.Message);
            }
        }
    }
}
