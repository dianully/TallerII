namespace PuntoDeVentaGameBox.Vendedor
{
    partial class BuscarProducto
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
            this.tbNombreProducto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bSalir = new System.Windows.Forms.Button();
            this.bBuscarProducto = new System.Windows.Forms.Button();
            this.dgvBuscarProducto = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscarProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbNombreProducto);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.bSalir);
            this.panel1.Controls.Add(this.bBuscarProducto);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 100);
            this.panel1.TabIndex = 0;
            // 
            // tbNombreProducto
            // 
            this.tbNombreProducto.Location = new System.Drawing.Point(307, 16);
            this.tbNombreProducto.Margin = new System.Windows.Forms.Padding(4);
            this.tbNombreProducto.Name = "tbNombreProducto";
            this.tbNombreProducto.Size = new System.Drawing.Size(275, 22);
            this.tbNombreProducto.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(79, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 25);
            this.label2.TabIndex = 44;
            this.label2.Text = "Nombre del Producto:";
            // 
            // bSalir
            // 
            this.bSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.bSalir.FlatAppearance.BorderSize = 0;
            this.bSalir.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSalir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bSalir.Location = new System.Drawing.Point(386, 49);
            this.bSalir.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.bSalir.Name = "bSalir";
            this.bSalir.Size = new System.Drawing.Size(164, 39);
            this.bSalir.TabIndex = 43;
            this.bSalir.Text = "Salir";
            this.bSalir.UseVisualStyleBackColor = false;
            this.bSalir.Click += new System.EventHandler(this.bSalir_Click);
            // 
            // bBuscarProducto
            // 
            this.bBuscarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.bBuscarProducto.FlatAppearance.BorderSize = 0;
            this.bBuscarProducto.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBuscarProducto.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bBuscarProducto.Location = new System.Drawing.Point(214, 49);
            this.bBuscarProducto.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.bBuscarProducto.Name = "bBuscarProducto";
            this.bBuscarProducto.Size = new System.Drawing.Size(164, 39);
            this.bBuscarProducto.TabIndex = 42;
            this.bBuscarProducto.Text = "Buscar";
            this.bBuscarProducto.UseVisualStyleBackColor = false;
            this.bBuscarProducto.Click += new System.EventHandler(this.bBuscarProducto_Click);
            // 
            // dgvBuscarProducto
            // 
            this.dgvBuscarProducto.AllowUserToAddRows = false;
            this.dgvBuscarProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuscarProducto.Location = new System.Drawing.Point(12, 134);
            this.dgvBuscarProducto.Margin = new System.Windows.Forms.Padding(4);
            this.dgvBuscarProducto.Name = "dgvBuscarProducto";
            this.dgvBuscarProducto.RowHeadersVisible = false;
            this.dgvBuscarProducto.RowHeadersWidth = 51;
            this.dgvBuscarProducto.Size = new System.Drawing.Size(775, 303);
            this.dgvBuscarProducto.TabIndex = 44;
            this.dgvBuscarProducto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBuscarProducto_CellClick);
            // 
            // BuscarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvBuscarProducto);
            this.Controls.Add(this.panel1);
            this.Name = "BuscarProducto";
            this.Text = "BuscarProducto";
            this.Load += new System.EventHandler(this.BuscarProducto_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscarProducto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bSalir;
        private System.Windows.Forms.Button bBuscarProducto;
        private System.Windows.Forms.DataGridView dgvBuscarProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNombreProducto;
    }
}