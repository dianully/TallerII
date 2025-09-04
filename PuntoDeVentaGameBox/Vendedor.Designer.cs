namespace PuntoDeVentaGameBox
{
    partial class Vendedor
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
            this.LProducto = new System.Windows.Forms.Label();
            this.LCantidad = new System.Windows.Forms.Label();
            this.LCliente = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Total = new System.Windows.Forms.Label();
            this.gbCliente = new System.Windows.Forms.GroupBox();
            this.BCobrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LProducto
            // 
            this.LProducto.AutoSize = true;
            this.LProducto.Location = new System.Drawing.Point(212, 97);
            this.LProducto.Name = "LProducto";
            this.LProducto.Size = new System.Drawing.Size(61, 16);
            this.LProducto.TabIndex = 0;
            this.LProducto.Text = "Producto";
            // 
            // LCantidad
            // 
            this.LCantidad.AutoSize = true;
            this.LCantidad.Location = new System.Drawing.Point(355, 97);
            this.LCantidad.Name = "LCantidad";
            this.LCantidad.Size = new System.Drawing.Size(61, 16);
            this.LCantidad.TabIndex = 1;
            this.LCantidad.Text = "Cantidad";
            // 
            // LCliente
            // 
            this.LCliente.AutoSize = true;
            this.LCliente.Location = new System.Drawing.Point(212, 149);
            this.LCliente.Name = "LCliente";
            this.LCliente.Size = new System.Drawing.Size(51, 16);
            this.LCliente.TabIndex = 2;
            this.LCliente.Text = "Cliente:";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(215, 191);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 66);
            this.panel1.TabIndex = 3;
            // 
            // Total
            // 
            this.Total.AutoSize = true;
            this.Total.Location = new System.Drawing.Point(212, 515);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(41, 16);
            this.Total.TabIndex = 5;
            this.Total.Text = "Total:";
            // 
            // gbCliente
            // 
            this.gbCliente.Location = new System.Drawing.Point(215, 301);
            this.gbCliente.Name = "gbCliente";
            this.gbCliente.Size = new System.Drawing.Size(378, 136);
            this.gbCliente.TabIndex = 6;
            this.gbCliente.TabStop = false;
            this.gbCliente.Text = "Datos del Cliente";
            // 
            // BCobrar
            // 
            this.BCobrar.Location = new System.Drawing.Point(215, 552);
            this.BCobrar.Name = "BCobrar";
            this.BCobrar.Size = new System.Drawing.Size(75, 23);
            this.BCobrar.TabIndex = 7;
            this.BCobrar.Text = "Cobrar";
            this.BCobrar.UseVisualStyleBackColor = true;
            // 
            // Vendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 652);
            this.Controls.Add(this.BCobrar);
            this.Controls.Add(this.gbCliente);
            this.Controls.Add(this.Total);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LCliente);
            this.Controls.Add(this.LCantidad);
            this.Controls.Add(this.LProducto);
            this.Name = "Vendedor";
            this.Text = "LVendedor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LProducto;
        private System.Windows.Forms.Label LCantidad;
        private System.Windows.Forms.Label LCliente;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Total;
        private System.Windows.Forms.GroupBox gbCliente;
        private System.Windows.Forms.Button BCobrar;
    }
}