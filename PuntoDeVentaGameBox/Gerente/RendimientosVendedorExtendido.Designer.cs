namespace PuntoDeVentaGameBox.Gerente
{
    partial class RendimientosVendedorExtendido
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
            this.DGVRendimientosVendedorExtendido = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGVRendimientosVendedorExtendido)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVRendimientosVendedorExtendido
            // 
            this.DGVRendimientosVendedorExtendido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVRendimientosVendedorExtendido.Location = new System.Drawing.Point(3, 54);
            this.DGVRendimientosVendedorExtendido.Name = "DGVRendimientosVendedorExtendido";
            this.DGVRendimientosVendedorExtendido.RowHeadersWidth = 51;
            this.DGVRendimientosVendedorExtendido.RowTemplate.Height = 24;
            this.DGVRendimientosVendedorExtendido.Size = new System.Drawing.Size(794, 393);
            this.DGVRendimientosVendedorExtendido.TabIndex = 1;
            // 
            // RendimientosVendedorExtendido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DGVRendimientosVendedorExtendido);
            this.Name = "RendimientosVendedorExtendido";
            this.Text = "RendimientosVendedorExtendido";
            this.Load += new System.EventHandler(this.RendimientosVendedorExtendido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVRendimientosVendedorExtendido)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVRendimientosVendedorExtendido;
    }
}