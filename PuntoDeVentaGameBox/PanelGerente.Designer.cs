namespace PuntoDeVentaGameBox
{
    partial class PanelGerente
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
            this.LRolGerente = new System.Windows.Forms.Label();
            this.TLPPanelGerente = new System.Windows.Forms.TableLayoutPanel();
            this.BInventario = new System.Windows.Forms.Button();
            this.BReportes = new System.Windows.Forms.Button();
            this.BProveedores = new System.Windows.Forms.Button();
            this.BSalir = new System.Windows.Forms.Button();
            this.PVistaGerente = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LNombreUsuario = new System.Windows.Forms.Label();
            this.TLPPanelGerente.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LRolGerente
            // 
            this.LRolGerente.AutoSize = true;
            this.LRolGerente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LRolGerente.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LRolGerente.Location = new System.Drawing.Point(12, 9);
            this.LRolGerente.Name = "LRolGerente";
            this.LRolGerente.Size = new System.Drawing.Size(123, 40);
            this.LRolGerente.TabIndex = 1;
            this.LRolGerente.Text = "Gerente";
            // 
            // TLPPanelGerente
            // 
            this.TLPPanelGerente.ColumnCount = 4;
            this.TLPPanelGerente.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLPPanelGerente.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLPPanelGerente.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLPPanelGerente.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLPPanelGerente.Controls.Add(this.BInventario, 0, 0);
            this.TLPPanelGerente.Controls.Add(this.BReportes, 1, 0);
            this.TLPPanelGerente.Controls.Add(this.BProveedores, 2, 0);
            this.TLPPanelGerente.Controls.Add(this.BSalir, 3, 0);
            this.TLPPanelGerente.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TLPPanelGerente.Location = new System.Drawing.Point(0, 55);
            this.TLPPanelGerente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TLPPanelGerente.Name = "TLPPanelGerente";
            this.TLPPanelGerente.RowCount = 1;
            this.TLPPanelGerente.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPPanelGerente.Size = new System.Drawing.Size(1181, 116);
            this.TLPPanelGerente.TabIndex = 2;
            // 
            // BInventario
            // 
            this.BInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.BInventario.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BInventario.ForeColor = System.Drawing.Color.LightGray;
            this.BInventario.Location = new System.Drawing.Point(3, 2);
            this.BInventario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BInventario.Name = "BInventario";
            this.BInventario.Size = new System.Drawing.Size(283, 110);
            this.BInventario.TabIndex = 0;
            this.BInventario.Text = "Inventario";
            this.BInventario.UseVisualStyleBackColor = false;
            this.BInventario.Click += new System.EventHandler(this.BInventario_Click);
            // 
            // BReportes
            // 
            this.BReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.BReportes.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BReportes.ForeColor = System.Drawing.Color.LightGray;
            this.BReportes.Location = new System.Drawing.Point(298, 2);
            this.BReportes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BReportes.Name = "BReportes";
            this.BReportes.Size = new System.Drawing.Size(283, 110);
            this.BReportes.TabIndex = 1;
            this.BReportes.Text = "Reportes";
            this.BReportes.UseVisualStyleBackColor = false;
            this.BReportes.Click += new System.EventHandler(this.BReportes_Click);
            // 
            // BProveedores
            // 
            this.BProveedores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.BProveedores.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BProveedores.ForeColor = System.Drawing.Color.LightGray;
            this.BProveedores.Location = new System.Drawing.Point(593, 2);
            this.BProveedores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BProveedores.Name = "BProveedores";
            this.BProveedores.Size = new System.Drawing.Size(283, 110);
            this.BProveedores.TabIndex = 2;
            this.BProveedores.Text = "Proveedores";
            this.BProveedores.UseVisualStyleBackColor = false;
            this.BProveedores.Click += new System.EventHandler(this.BProveedores_Click);
            // 
            // BSalir
            // 
            this.BSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.BSalir.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSalir.ForeColor = System.Drawing.Color.LightGray;
            this.BSalir.Location = new System.Drawing.Point(888, 2);
            this.BSalir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(284, 110);
            this.BSalir.TabIndex = 3;
            this.BSalir.Text = "Salir";
            this.BSalir.UseVisualStyleBackColor = false;
            this.BSalir.Click += new System.EventHandler(this.BSalir_Click);
            // 
            // PVistaGerente
            // 
            this.PVistaGerente.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PVistaGerente.Location = new System.Drawing.Point(0, 183);
            this.PVistaGerente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PVistaGerente.Name = "PVistaGerente";
            this.PVistaGerente.Size = new System.Drawing.Size(1181, 803);
            this.PVistaGerente.TabIndex = 3;
            this.PVistaGerente.Paint += new System.Windows.Forms.PaintEventHandler(this.PVistaGerente_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LNombreUsuario);
            this.panel1.Controls.Add(this.LRolGerente);
            this.panel1.Controls.Add(this.TLPPanelGerente);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1181, 171);
            this.panel1.TabIndex = 4;
            // 
            // LNombreUsuario
            // 
            this.LNombreUsuario.AutoSize = true;
            this.LNombreUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LNombreUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombreUsuario.Location = new System.Drawing.Point(964, 9);
            this.LNombreUsuario.Name = "LNombreUsuario";
            this.LNombreUsuario.Size = new System.Drawing.Size(189, 33);
            this.LNombreUsuario.TabIndex = 3;
            this.LNombreUsuario.Text = "Nombre Usuario";
            this.LNombreUsuario.Click += new System.EventHandler(this.label1_Click);
            // 
            // PanelGerente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(1181, 986);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PVistaGerente);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PanelGerente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel Gerente";
            this.Load += new System.EventHandler(this.PanelGerente_Load);
            this.TLPPanelGerente.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LRolGerente;
        private System.Windows.Forms.TableLayoutPanel TLPPanelGerente;
        private System.Windows.Forms.Button BInventario;
        private System.Windows.Forms.Button BReportes;
        private System.Windows.Forms.Button BProveedores;
        private System.Windows.Forms.Button BSalir;
        private System.Windows.Forms.Panel PVistaGerente;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LNombreUsuario;
    }
}