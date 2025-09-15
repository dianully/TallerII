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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BNuevoProveedor = new System.Windows.Forms.Button();
            this.BBuscar = new System.Windows.Forms.Button();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.CBFiltroProveedores = new System.Windows.Forms.ComboBox();
            this.LCantProveedores = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DGVProveedorCNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVProveedorCDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVProveedorCTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVProveedorCCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVProveedorCVer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVProveedorCEditar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVProveedorCEliminar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1179, 82);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Font = new System.Drawing.Font("Segoe Fluent Icons", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(-1, 104);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1170, 765);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.33452F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.65836F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.38671F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.45433F));
            this.tableLayoutPanel1.Controls.Add(this.BBuscar, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.CBFiltroProveedores, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.LCantProveedores, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.BNuevoProveedor, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TBBuscar, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1167, 102);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestión de Proveedores";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(1059, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gerente";
            // 
            // BNuevoProveedor
            // 
            this.BNuevoProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BNuevoProveedor.AutoSize = true;
            this.BNuevoProveedor.BackColor = System.Drawing.Color.CornflowerBlue;
            this.BNuevoProveedor.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNuevoProveedor.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BNuevoProveedor.Location = new System.Drawing.Point(3, 27);
            this.BNuevoProveedor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BNuevoProveedor.Name = "BNuevoProveedor";
            this.BNuevoProveedor.Size = new System.Drawing.Size(227, 48);
            this.BNuevoProveedor.TabIndex = 0;
            this.BNuevoProveedor.Text = "+ Nuevo Proveedor";
            this.BNuevoProveedor.UseVisualStyleBackColor = false;
            // 
            // BBuscar
            // 
            this.BBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BBuscar.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBuscar.Location = new System.Drawing.Point(543, 35);
            this.BBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(177, 31);
            this.BBuscar.TabIndex = 1;
            this.BBuscar.Text = "Buscar";
            this.BBuscar.UseVisualStyleBackColor = true;
            // 
            // TBBuscar
            // 
            this.TBBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TBBuscar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBBuscar.Location = new System.Drawing.Point(236, 36);
            this.TBBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(301, 30);
            this.TBBuscar.TabIndex = 2;
            this.TBBuscar.Text = "Buscar por Nombre o Correo";
            // 
            // CBFiltroProveedores
            // 
            this.CBFiltroProveedores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CBFiltroProveedores.FormattingEnabled = true;
            this.CBFiltroProveedores.Items.AddRange(new object[] {
            "Todos",
            "Recientes"});
            this.CBFiltroProveedores.Location = new System.Drawing.Point(726, 38);
            this.CBFiltroProveedores.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CBFiltroProveedores.Name = "CBFiltroProveedores";
            this.CBFiltroProveedores.Size = new System.Drawing.Size(208, 25);
            this.CBFiltroProveedores.TabIndex = 3;
            // 
            // LCantProveedores
            // 
            this.LCantProveedores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LCantProveedores.AutoSize = true;
            this.LCantProveedores.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCantProveedores.Location = new System.Drawing.Point(940, 39);
            this.LCantProveedores.Name = "LCantProveedores";
            this.LCantProveedores.Size = new System.Drawing.Size(224, 23);
            this.LCantProveedores.TabIndex = 4;
            this.LCantProveedores.Text = "0 Proveedores";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGVProveedorCNombre,
            this.DGVProveedorCDireccion,
            this.DGVProveedorCTelefono,
            this.DGVProveedorCCorreo,
            this.DGVProveedorCVer,
            this.DGVProveedorCEditar,
            this.DGVProveedorCEliminar});
            this.dataGridView1.Location = new System.Drawing.Point(13, 109);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1154, 487);
            this.dataGridView1.TabIndex = 3;
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
            // Proveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 703);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Proveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BNuevoProveedor;
        private System.Windows.Forms.Button BBuscar;
        private System.Windows.Forms.TextBox TBBuscar;
        private System.Windows.Forms.ComboBox CBFiltroProveedores;
        private System.Windows.Forms.Label LCantProveedores;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVProveedorCNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVProveedorCDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVProveedorCTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVProveedorCCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVProveedorCVer;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVProveedorCEditar;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVProveedorCEliminar;
    }
}