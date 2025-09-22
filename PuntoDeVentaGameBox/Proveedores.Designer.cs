namespace PuntoDeVentaGameBox
{
    partial class Proveedores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.DGVDatosProveedores = new System.Windows.Forms.DataGridView();
            this.DGVProveedorCNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVProveedorCDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVProveedorCTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVProveedorCCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVProveedorCVer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVProveedorCEditar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVProveedorCEliminar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TLPFiltros = new System.Windows.Forms.TableLayoutPanel();
            this.BBuscar = new System.Windows.Forms.Button();
            this.CBFiltroProveedores = new System.Windows.Forms.ComboBox();
            this.LCantProveedores = new System.Windows.Forms.Label();
            this.BNuevoProveedor = new System.Windows.Forms.Button();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDatosProveedores)).BeginInit();
            this.TLPFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.DGVDatosProveedores);
            this.panel2.Controls.Add(this.TLPFiltros);
            this.panel2.Font = new System.Drawing.Font("Segoe Fluent Icons", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(3, -69);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(831, 765);
            this.panel2.TabIndex = 1;
            // 
            // DGVDatosProveedores
            // 
            this.DGVDatosProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVDatosProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVDatosProveedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGVProveedorCNombre,
            this.DGVProveedorCDireccion,
            this.DGVProveedorCTelefono,
            this.DGVProveedorCCorreo,
            this.DGVProveedorCVer,
            this.DGVProveedorCEditar,
            this.DGVProveedorCEliminar});
            this.DGVDatosProveedores.Location = new System.Drawing.Point(12, 199);
            this.DGVDatosProveedores.Name = "DGVDatosProveedores";
            this.DGVDatosProveedores.RowHeadersVisible = false;
            this.DGVDatosProveedores.RowHeadersWidth = 51;
            this.DGVDatosProveedores.RowTemplate.Height = 24;
            this.DGVDatosProveedores.Size = new System.Drawing.Size(812, 396);
            this.DGVDatosProveedores.TabIndex = 3;
            // 
            // DGVProveedorCNombre
            // 
            this.DGVProveedorCNombre.HeaderText = "Nombre";
            this.DGVProveedorCNombre.MinimumWidth = 6;
            this.DGVProveedorCNombre.Name = "DGVProveedorCNombre";
            // 
            // DGVProveedorCDireccion
            // 
            this.DGVProveedorCDireccion.HeaderText = "Direccion";
            this.DGVProveedorCDireccion.MinimumWidth = 6;
            this.DGVProveedorCDireccion.Name = "DGVProveedorCDireccion";
            // 
            // DGVProveedorCTelefono
            // 
            this.DGVProveedorCTelefono.HeaderText = "Telefono";
            this.DGVProveedorCTelefono.MinimumWidth = 6;
            this.DGVProveedorCTelefono.Name = "DGVProveedorCTelefono";
            // 
            // DGVProveedorCCorreo
            // 
            this.DGVProveedorCCorreo.HeaderText = "Correo";
            this.DGVProveedorCCorreo.MinimumWidth = 6;
            this.DGVProveedorCCorreo.Name = "DGVProveedorCCorreo";
            // 
            // DGVProveedorCVer
            // 
            this.DGVProveedorCVer.HeaderText = "Ver";
            this.DGVProveedorCVer.MinimumWidth = 6;
            this.DGVProveedorCVer.Name = "DGVProveedorCVer";
            // 
            // DGVProveedorCEditar
            // 
            this.DGVProveedorCEditar.HeaderText = "Editar";
            this.DGVProveedorCEditar.MinimumWidth = 6;
            this.DGVProveedorCEditar.Name = "DGVProveedorCEditar";
            // 
            // DGVProveedorCEliminar
            // 
            this.DGVProveedorCEliminar.HeaderText = "Eliminar";
            this.DGVProveedorCEliminar.MinimumWidth = 6;
            this.DGVProveedorCEliminar.Name = "DGVProveedorCEliminar";
            // 
            // TLPFiltros
            // 
            this.TLPFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TLPFiltros.ColumnCount = 5;
            this.TLPFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLPFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.33452F));
            this.TLPFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.65836F));
            this.TLPFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.38671F));
            this.TLPFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.45433F));
            this.TLPFiltros.Controls.Add(this.BBuscar, 2, 0);
            this.TLPFiltros.Controls.Add(this.CBFiltroProveedores, 3, 0);
            this.TLPFiltros.Controls.Add(this.LCantProveedores, 4, 0);
            this.TLPFiltros.Controls.Add(this.BNuevoProveedor, 0, 0);
            this.TLPFiltros.Controls.Add(this.TBBuscar, 1, 0);
            this.TLPFiltros.Location = new System.Drawing.Point(4, 76);
            this.TLPFiltros.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TLPFiltros.Name = "TLPFiltros";
            this.TLPFiltros.RowCount = 1;
            this.TLPFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPFiltros.Size = new System.Drawing.Size(824, 102);
            this.TLPFiltros.TabIndex = 2;
            // 
            // BBuscar
            // 
            this.BBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.BBuscar.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBuscar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BBuscar.Location = new System.Drawing.Point(385, 29);
            this.BBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(123, 43);
            this.BBuscar.TabIndex = 1;
            this.BBuscar.Text = "Buscar";
            this.BBuscar.UseVisualStyleBackColor = false;
            // 
            // CBFiltroProveedores
            // 
            this.CBFiltroProveedores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CBFiltroProveedores.FormattingEnabled = true;
            this.CBFiltroProveedores.Items.AddRange(new object[] {
            "Todos",
            "Recientes"});
            this.CBFiltroProveedores.Location = new System.Drawing.Point(514, 40);
            this.CBFiltroProveedores.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CBFiltroProveedores.Name = "CBFiltroProveedores";
            this.CBFiltroProveedores.Size = new System.Drawing.Size(145, 22);
            this.CBFiltroProveedores.TabIndex = 3;
            // 
            // LCantProveedores
            // 
            this.LCantProveedores.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LCantProveedores.AutoSize = true;
            this.LCantProveedores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.LCantProveedores.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCantProveedores.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LCantProveedores.Location = new System.Drawing.Point(694, 41);
            this.LCantProveedores.Name = "LCantProveedores";
            this.LCantProveedores.Size = new System.Drawing.Size(97, 19);
            this.LCantProveedores.TabIndex = 4;
            this.LCantProveedores.Text = "0 Proveedores";
            // 
            // BNuevoProveedor
            // 
            this.BNuevoProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BNuevoProveedor.AutoSize = true;
            this.BNuevoProveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.BNuevoProveedor.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNuevoProveedor.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BNuevoProveedor.Location = new System.Drawing.Point(3, 27);
            this.BNuevoProveedor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BNuevoProveedor.Name = "BNuevoProveedor";
            this.BNuevoProveedor.Size = new System.Drawing.Size(159, 48);
            this.BNuevoProveedor.TabIndex = 0;
            this.BNuevoProveedor.Text = "+ Nuevo Proveedor";
            this.BNuevoProveedor.UseVisualStyleBackColor = false;
            // 
            // TBBuscar
            // 
            this.TBBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TBBuscar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBBuscar.Location = new System.Drawing.Point(168, 38);
            this.TBBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(211, 26);
            this.TBBuscar.TabIndex = 2;
            this.TBBuscar.Text = "Buscar por Nombre o Correo";
            // 
            // Proveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(846, 538);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Proveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proveedores";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDatosProveedores)).EndInit();
            this.TLPFiltros.ResumeLayout(false);
            this.TLPFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel TLPFiltros;
        private System.Windows.Forms.Button BNuevoProveedor;
        private System.Windows.Forms.Button BBuscar;
        private System.Windows.Forms.TextBox TBBuscar;
        private System.Windows.Forms.ComboBox CBFiltroProveedores;
        private System.Windows.Forms.Label LCantProveedores;
        private System.Windows.Forms.DataGridView DGVDatosProveedores;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVProveedorCNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVProveedorCDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVProveedorCTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVProveedorCCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVProveedorCVer;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVProveedorCEditar;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVProveedorCEliminar;
    }
}