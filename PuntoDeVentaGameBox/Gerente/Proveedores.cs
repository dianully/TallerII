using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using PuntoDeVentaGameBox.Vendedor;
using PuntoDeVentaGameBox.Administrador;
using PuntoDeVentaGameBox.Gerente;

namespace PuntoDeVentaGameBox.Gerente
{
    public partial class Proveedores : Form
    {
        // cadena fija sin appconfig
        private readonly string _connString =
            "Server=localhost;Database=game_box;Trusted_Connection=True;TrustServerCertificate=True";

        // popup de sugerencias
        private Panel _suggestPanel;
        private ListBox _suggestList;
        private readonly List<int> _recientesIds = new List<int>();
        private const int MAX_RECIENTES = 5;

        // --- Cue Banner (placeholder real) ---
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;
        private void SetPlaceholder(TextBox tb, string text)
        {
            try { SendMessage(tb.Handle, EM_SETCUEBANNER, 1, text); } catch { /* fallback noop */ }
        }

        public Proveedores()
        {
            InitializeComponent();

            // asegura eventos aunque el diseñador no los tenga enlazados
            this.Load -= Proveedores_Load;
            this.Load += Proveedores_Load;

            DGVDatosProveedores.CellContentClick -= DGVDatosProveedores_CellContentClick;
            DGVDatosProveedores.CellContentClick += DGVDatosProveedores_CellContentClick;

            // texto en negro para toda la grilla
            DGVDatosProveedores.DefaultCellStyle.ForeColor = Color.Black;
            DGVDatosProveedores.RowsDefaultCellStyle.ForeColor = Color.Black;
            DGVDatosProveedores.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            // eventos de buscador
            TBBuscar.TextChanged -= TBBuscar_TextChanged;
            TBBuscar.TextChanged += TBBuscar_TextChanged;

            TBBuscar.Enter -= TBBuscar_Enter;
            TBBuscar.Enter += TBBuscar_Enter;

            TBBuscar.KeyDown -= TBBuscar_KeyDown;
            TBBuscar.KeyDown += TBBuscar_KeyDown;

            BBuscar.Click -= BBuscar_Click;
            BBuscar.Click += BBuscar_Click;

            this.Click -= Proveedores_Click;
            this.Click += Proveedores_Click;

            BNuevoProveedor.Click -= BNuevoProveedor_Click;
            BNuevoProveedor.Click += BNuevoProveedor_Click;

            // nuevos botones de filtros
            BAplicarFiltros.Click -= BAplicarFiltros_Click;
            BAplicarFiltros.Click += BAplicarFiltros_Click;

            BLimpiarFiltros.Click -= BLimpiarFiltros_Click;
            BLimpiarFiltros.Click += BLimpiarFiltros_Click;

            // combo filtro
            CBFiltroProveedores.Items.Clear();
            CBFiltroProveedores.Items.Add("todos");
            CBFiltroProveedores.Items.Add("recientes");
            CBFiltroProveedores.Items.Add("A - Z");
            CBFiltroProveedores.Items.Add("Z - A");
            CBFiltroProveedores.Items.Add("ID ascendente");
            CBFiltroProveedores.SelectedIndex = 0; // por defecto
        }

        private SqlConnection NuevaConexion() => new SqlConnection(_connString);

        private void Proveedores_Load(object sender, EventArgs e)
        {
            // placeholder real (no texto)
            TBBuscar.Text = string.Empty;
            SetPlaceholder(TBBuscar, "Buscar por nombre o ID");

            PrepararColumnas();
            CargarProveedores();
            ActualizarContador();
            NormalizarBotonAccion("Ver");
            NormalizarBotonAccion("Editar");
            NormalizarBotonAccion("Eliminar");
        }

        private void BNuevoProveedor_Click(object sender, EventArgs e)
        {
            using (var frm = new AgregarProveedor())
            {
                var dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                    BBuscar_Click(this, EventArgs.Empty);
            }
        }

        // ================== columnas y carga ==================

        private void PrepararColumnas()
        {
            DGVDatosProveedores.AutoGenerateColumns = false;
            DGVDatosProveedores.Columns.Clear();

            DGVDatosProveedores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Nombre",
                DataPropertyName = "nombre",
                ReadOnly = true,
                FillWeight = 32,
                MinimumWidth = 160
            });

            DGVDatosProveedores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Direccion",
                HeaderText = "Direccion",
                DataPropertyName = "direccion",
                ReadOnly = true,
                FillWeight = 30,
                MinimumWidth = 160
            });

            var colTel = new DataGridViewTextBoxColumn
            {
                Name = "Telefono",
                HeaderText = "Telefono",
                DataPropertyName = "telefono",
                ReadOnly = true,
                FillWeight = 16,
                MinimumWidth = 110
            };
            colTel.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGVDatosProveedores.Columns.Add(colTel);

            DGVDatosProveedores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Correo",
                HeaderText = "Correo",
                DataPropertyName = "email",
                ReadOnly = true,
                FillWeight = 30,
                MinimumWidth = 160
            });

            DGVDatosProveedores.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Ver",
                HeaderText = "Ver",
                Text = "Ver",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Popup,
                FillWeight = 10,
                MinimumWidth = 80
            });

            DGVDatosProveedores.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Editar",
                HeaderText = "Editar",
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Popup,
                FillWeight = 10,
                MinimumWidth = 80
            });

            DGVDatosProveedores.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Eliminar",
                HeaderText = "Eliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Popup,
                FillWeight = 10,
                MinimumWidth = 90
            });

            DGVDatosProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVDatosProveedores.ReadOnly = false;
            DGVDatosProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVDatosProveedores.MultiSelect = false;
        }

        private bool ExisteColumnaActivo(SqlConnection cn)
        {
            using (var cmd = cn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT COUNT(1)
                    FROM sys.columns
                    WHERE object_id = OBJECT_ID('dbo.proveedor') AND name = 'activo'";
                var n = Convert.ToInt32(cmd.ExecuteScalar());
                return n > 0;
            }
        }

        /// <summary>
        /// Carga proveedores con búsqueda opcional y con orden segun 'ordenCode'.
        /// ordenCode: null/'todos', 'recientes', 'AZ', 'ZA', 'ID_ASC'
        /// </summary>
        private void CargarProveedores(string texto = null, bool soloRecientes = false, string ordenCode = null)
        {
            try
            {
                using (var cn = NuevaConexion())
                using (var da = new SqlDataAdapter())
                using (var cmd = cn.CreateCommand())
                {
                    cn.Open();
                    bool tieneActivo = ExisteColumnaActivo(cn);

                    string whereBase = tieneActivo ? "WHERE p.activo = 1" : "WHERE 1=1";

                    // filtro por texto: nombre o ID (parcial)
                    string filtro = "";
                    if (!string.IsNullOrWhiteSpace(texto))
                    {
                        filtro = @" AND (LOWER(p.nombre) LIKE LOWER(@q)
                                    OR CAST(p.id_proveedor AS varchar(20)) LIKE @qId )";
                        cmd.Parameters.AddWithValue("@q", $"%{texto.Trim()}%");
                        cmd.Parameters.AddWithValue("@qId", $"%{texto.Trim()}%");
                    }

                    // recientes: limitar a ultimos ids elegidos del popup
                    string recientes = "";
                    if (soloRecientes && _recientesIds.Count > 0)
                        recientes = " AND p.id_proveedor IN (" + string.Join(",", _recientesIds) + ")";

                    // orden
                    string order = " ORDER BY p.nombre";
                    switch (ordenCode)
                    {
                        case "AZ": order = " ORDER BY p.nombre ASC"; break;
                        case "ZA": order = " ORDER BY p.nombre DESC"; break;
                        case "ID_ASC": order = " ORDER BY p.id_proveedor ASC"; break;
                        case "REC": order = " ORDER BY p.nombre"; break; // mismos que default
                        default: order = " ORDER BY p.nombre"; break;
                    }

                    cmd.CommandText = $@"
                        SELECT p.id_proveedor, p.nombre, p.direccion, p.telefono, p.email
                        FROM dbo.proveedor p
                        {whereBase} {filtro} {recientes}
                        {order}";
                    da.SelectCommand = cmd;

                    var dt = new DataTable();
                    da.Fill(dt);
                    DGVDatosProveedores.DataSource = dt;
                }

                ActualizarContador();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al cargar proveedores: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarContador()
        {
            try
            {
                using (var cn = NuevaConexion())
                using (var cmd = cn.CreateCommand())
                {
                    cn.Open();
                    bool tieneActivo = ExisteColumnaActivo(cn);
                    cmd.CommandText = tieneActivo
                        ? "SELECT COUNT(*) FROM dbo.proveedor WHERE activo = 1"
                        : "SELECT COUNT(*) FROM dbo.proveedor";
                    int cant = Convert.ToInt32(cmd.ExecuteScalar());
                    LCantProveedores.Text = $"{cant} Proveedores";
                }
            }
            catch
            {
                LCantProveedores.Text = "0 Proveedores";
            }
        }

        // ================= buscador: sugerencias y acciones =================

        private void EnsureSuggestControls()
        {
            if (_suggestPanel != null) return;
            _suggestPanel = new Panel { BorderStyle = BorderStyle.FixedSingle, Visible = false };
            _suggestList = new ListBox { IntegralHeight = false, Dock = DockStyle.Fill };
            _suggestList.Click += SuggestList_Click;
            _suggestList.KeyDown += SuggestList_KeyDown;
            _suggestPanel.Controls.Add(_suggestList);
            this.Controls.Add(_suggestPanel);
        }

        private void ShowSuggestions(DataTable data)
        {
            EnsureSuggestControls();

            _suggestList.BeginUpdate();
            _suggestList.Items.Clear();
            foreach (DataRow r in data.Rows)
            {
                int id = Convert.ToInt32(r["id_proveedor"]);
                string nombre = Convert.ToString(r["nombre"]) ?? "";
                _suggestList.Items.Add(new SItem(id, $"{nombre}  (ID {id})"));
            }
            _suggestList.EndUpdate();

            if (_suggestList.Items.Count == 0)
            {
                _suggestPanel.Visible = false;
                return;
            }

            var screen = TBBuscar.PointToScreen(new Point(0, TBBuscar.Height));
            var local = this.PointToClient(screen);
            _suggestPanel.Location = local;
            _suggestPanel.Width = TBBuscar.Width;

            int itemHeight = _suggestList.ItemHeight;
            int visible = Math.Min(4, _suggestList.Items.Count);
            _suggestPanel.Height = visible * itemHeight + 6;

            _suggestPanel.BringToFront();
            _suggestPanel.Visible = true;
            _suggestList.SelectedIndex = -1;
        }

        private void HideSuggestions()
        {
            if (_suggestPanel != null) _suggestPanel.Visible = false;
        }

        private void TBBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string q = TBBuscar.Text?.Trim();
                if (string.IsNullOrEmpty(q))
                {
                    HideSuggestions();
                    return;
                }

                using (var cn = NuevaConexion())
                using (var da = new SqlDataAdapter(@"
                        SELECT TOP 50 id_proveedor, nombre
                        FROM dbo.proveedor
                        WHERE LOWER(nombre) LIKE LOWER(@q + '%')
                           OR CAST(id_proveedor AS varchar(20)) LIKE @q
                        ORDER BY nombre", cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@q", q);
                    var dt = new DataTable();
                    da.Fill(dt);
                    ShowSuggestions(dt);
                }
            }
            catch
            {
                // silencioso
            }
        }

        private void SuggestList_Click(object sender, EventArgs e)
        {
            if (_suggestList.SelectedItem is SItem si)
            {
                TBBuscar.Text = si.Display;
                _recientesIds.Remove(si.Id);
                _recientesIds.Insert(0, si.Id);
                if (_recientesIds.Count > MAX_RECIENTES) _recientesIds.RemoveAt(_recientesIds.Count - 1);
                HideSuggestions();
                CargarProveedorPorId(si.Id);
            }
        }

        private void SuggestList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SuggestList_Click(sender, EventArgs.Empty);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                HideSuggestions();
                e.Handled = true;
            }
        }

        private void TBBuscar_Enter(object sender, EventArgs e)
        {
            // selecciona todo si había algo, para reescribir rápido
            if (!string.IsNullOrEmpty(TBBuscar.Text))
                TBBuscar.SelectAll();
        }

        private void TBBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BBuscar_Click(sender, EventArgs.Empty);
            }
        }

        private void Proveedores_Click(object sender, EventArgs e)
        {
            HideSuggestions();
        }

        // Boton Buscar: usa lo escrito (parcial) por nombre o ID
        private void BBuscar_Click(object sender, EventArgs e)
        {
            string q =
                string.IsNullOrWhiteSpace(TBBuscar.Text) ? null : TBBuscar.Text.Trim();

            // si el texto viene del popup (ej. "Nombre (ID 5)") extraemos el número al final
            int idPopup;
            if (!string.IsNullOrEmpty(q) &&
                q.EndsWith(")") &&
                int.TryParse(new string(q.Reverse().Skip(1).TakeWhile(char.IsDigit).Reverse().ToArray()), out idPopup))
            {
                CargarProveedorPorId(idPopup);
                HideSuggestions();
                return;
            }

            bool soloRecientes = CBFiltroProveedores.SelectedItem?.ToString()
                                     .Equals("recientes", StringComparison.OrdinalIgnoreCase) == true;

            string orden = MapOrden(CBFiltroProveedores.SelectedItem?.ToString());
            CargarProveedores(q, soloRecientes, orden);
            HideSuggestions();
        }

        private void BAplicarFiltros_Click(object sender, EventArgs e)
        {
            string q = string.IsNullOrWhiteSpace(TBBuscar.Text) ? null : TBBuscar.Text.Trim();
            bool soloRecientes = CBFiltroProveedores.SelectedItem?.ToString()
                                     .Equals("recientes", StringComparison.OrdinalIgnoreCase) == true;
            string orden = MapOrden(CBFiltroProveedores.SelectedItem?.ToString());
            CargarProveedores(q, soloRecientes, orden);
            HideSuggestions();
        }

        private void BLimpiarFiltros_Click(object sender, EventArgs e)
        {
            TBBuscar.Clear();
            SetPlaceholder(TBBuscar, "Buscar por nombre o ID");
            CBFiltroProveedores.SelectedIndex = 0; // "todos"
            HideSuggestions();
            CargarProveedores(null, false, "AZ"); // o default por nombre
        }

        private string MapOrden(string sel)
        {
            if (string.IsNullOrWhiteSpace(sel)) return null;
            if (sel.Equals("A - Z", StringComparison.OrdinalIgnoreCase)) return "AZ";
            if (sel.Equals("Z - A", StringComparison.OrdinalIgnoreCase)) return "ZA";
            if (sel.Equals("ID ascendente", StringComparison.OrdinalIgnoreCase)) return "ID_ASC";
            if (sel.Equals("recientes", StringComparison.OrdinalIgnoreCase)) return "REC";
            return null; // "todos" cae en default
        }

        private void CargarProveedorPorId(int id)
        {
            try
            {
                using (var cn = NuevaConexion())
                using (var da = new SqlDataAdapter(
                           @"SELECT id_proveedor, nombre, direccion, telefono, email
                             FROM dbo.proveedor
                             WHERE id_proveedor = @id", cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@id", id);
                    var dt = new DataTable();
                    da.Fill(dt);
                    DGVDatosProveedores.DataSource = dt;
                }
                ActualizarContador();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error al cargar proveedor: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class SItem
        {
            public int Id { get; }
            public string Display { get; }
            public SItem(int id, string display) { Id = id; Display = display; }
            public override string ToString() => Display;
        }

        // ================= acciones de grilla =================

        private void DGVDatosProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = DGVDatosProveedores.Columns[e.ColumnIndex];
            bool esVer = col.Name.Equals("Ver", StringComparison.OrdinalIgnoreCase);
            bool esEditar = col.Name.Equals("Editar", StringComparison.OrdinalIgnoreCase);
            bool esEliminar = col.Name.Equals("Eliminar", StringComparison.OrdinalIgnoreCase);
            if (!esVer && !esEditar && !esEliminar) return;

            var row = DGVDatosProveedores.Rows[e.RowIndex];
            if (!(row.DataBoundItem is DataRowView drv)) return;

            int id = Convert.ToInt32(drv["id_proveedor"]);
            string nombre = Convert.ToString(drv["nombre"]);

            // VER
            if (esVer)
            {
                using (var frm = new VerProveedor(id))
                {
                    frm.ShowDialog(this);
                }
                _recientesIds.Remove(id);
                _recientesIds.Insert(0, id);
                if (_recientesIds.Count > MAX_RECIENTES) _recientesIds.RemoveAt(_recientesIds.Count - 1);
                return;
            }

            // EDITAR
            if (esEditar)
            {
                using (var frm = new EditarProveedor(id))
                {
                    var dr = frm.ShowDialog(this);
                    if (dr == DialogResult.OK)
                        BBuscar_Click(this, EventArgs.Empty);
                }
                return;
            }

            // ELIMINAR (baja lógica si existe 'activo')
            if (esEliminar)
            {
                var resp = MessageBox.Show(
                    $"confirmar eliminacion de \"{nombre}\"",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resp != DialogResult.Yes) return;

                try
                {
                    using (var cn = NuevaConexion())
                    using (var cmd = cn.CreateCommand())
                    {
                        cn.Open();

                        try
                        {
                            cmd.CommandText = "UPDATE dbo.proveedor SET activo = 0 WHERE id_proveedor = @id";
                            cmd.Parameters.AddWithValue("@id", id);
                            int n = cmd.ExecuteNonQuery();
                            if (n == 0) throw new Exception("no se actualizo ningun registro");
                        }
                        catch
                        {
                            var respHard = MessageBox.Show(
                                "la tabla proveedor no tiene columna activo, desea eliminar fisicamente el registro?",
                                "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (respHard == DialogResult.Yes)
                            {
                                cmd.Parameters.Clear();
                                cmd.CommandText = "DELETE FROM dbo.proveedor WHERE id_proveedor = @id";
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.ExecuteNonQuery();
                            }
                            else return;
                        }
                    }

                    MessageBox.Show("proveedor eliminado", "Ok",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BBuscar_Click(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"error al eliminar proveedor: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ================= helpers botones grid =================

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

            for (int i = 1; i < coinciden.Count; i++)
                DGVDatosProveedores.Columns.Remove(coinciden[i]);

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
                DefaultCellStyle = new DataGridViewCellStyle { ForeColor = Color.Black }
            };
        }

        // ===== stubs autogenerados por el diseñador =====
        private void label1_Click(object sender, EventArgs e) { }
        private void Proveedores_Load_1(object sender, EventArgs e) { }
    }
}
