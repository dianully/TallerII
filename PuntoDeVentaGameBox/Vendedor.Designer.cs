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
            this.Total = new System.Windows.Forms.Label();
            this.gbCliente = new System.Windows.Forms.GroupBox();
            this.BCobrar = new System.Windows.Forms.Button();
            this.BSalir = new System.Windows.Forms.Button();
            this.TBNombreCliente = new System.Windows.Forms.TextBox();
            this.LNombreCliente = new System.Windows.Forms.Label();
            this.LApellidoCliente = new System.Windows.Forms.Label();
            this.LClienteDNI = new System.Windows.Forms.Label();
            this.LClienteGmail = new System.Windows.Forms.Label();
            this.TBApellidoCliente = new System.Windows.Forms.TextBox();
            this.TBDniCliente = new System.Windows.Forms.TextBox();
            this.TBClienteGmail = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.BCargarProducto = new System.Windows.Forms.Button();
            this.gbCliente.SuspendLayout();
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
            this.LCantidad.Location = new System.Drawing.Point(379, 100);
            this.LCantidad.Name = "LCantidad";
            this.LCantidad.Size = new System.Drawing.Size(61, 16);
            this.LCantidad.TabIndex = 1;
            this.LCantidad.Text = "Cantidad";
            // 
            // LCliente
            // 
            this.LCliente.AutoSize = true;
            this.LCliente.Location = new System.Drawing.Point(212, 150);
            this.LCliente.Name = "LCliente";
            this.LCliente.Size = new System.Drawing.Size(51, 16);
            this.LCliente.TabIndex = 2;
            this.LCliente.Text = "Cliente:";
            // 
            // Total
            // 
            this.Total.AutoSize = true;
            this.Total.Location = new System.Drawing.Point(212, 549);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(41, 16);
            this.Total.TabIndex = 5;
            this.Total.Text = "Total:";
            // 
            // gbCliente
            // 
            this.gbCliente.Controls.Add(this.TBClienteGmail);
            this.gbCliente.Controls.Add(this.TBDniCliente);
            this.gbCliente.Controls.Add(this.TBApellidoCliente);
            this.gbCliente.Controls.Add(this.LClienteGmail);
            this.gbCliente.Controls.Add(this.LClienteDNI);
            this.gbCliente.Controls.Add(this.LApellidoCliente);
            this.gbCliente.Controls.Add(this.LNombreCliente);
            this.gbCliente.Controls.Add(this.TBNombreCliente);
            this.gbCliente.Location = new System.Drawing.Point(570, 100);
            this.gbCliente.Name = "gbCliente";
            this.gbCliente.Size = new System.Drawing.Size(378, 136);
            this.gbCliente.TabIndex = 6;
            this.gbCliente.TabStop = false;
            this.gbCliente.Text = "Datos del Cliente";
            // 
            // BCobrar
            // 
            this.BCobrar.Location = new System.Drawing.Point(215, 586);
            this.BCobrar.Name = "BCobrar";
            this.BCobrar.Size = new System.Drawing.Size(75, 23);
            this.BCobrar.TabIndex = 7;
            this.BCobrar.Text = "Cobrar";
            this.BCobrar.UseVisualStyleBackColor = true;
            // 
            // BSalir
            // 
            this.BSalir.Location = new System.Drawing.Point(518, 586);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(75, 23);
            this.BSalir.TabIndex = 8;
            this.BSalir.Text = "Salir";
            this.BSalir.UseVisualStyleBackColor = true;
            // 
            // TBNombreCliente
            // 
            this.TBNombreCliente.Location = new System.Drawing.Point(79, 21);
            this.TBNombreCliente.Name = "TBNombreCliente";
            this.TBNombreCliente.Size = new System.Drawing.Size(100, 22);
            this.TBNombreCliente.TabIndex = 0;
            // 
            // LNombreCliente
            // 
            this.LNombreCliente.AutoSize = true;
            this.LNombreCliente.Location = new System.Drawing.Point(7, 24);
            this.LNombreCliente.Name = "LNombreCliente";
            this.LNombreCliente.Size = new System.Drawing.Size(59, 16);
            this.LNombreCliente.TabIndex = 9;
            this.LNombreCliente.Text = "Nombre:";
            // 
            // LApellidoCliente
            // 
            this.LApellidoCliente.AutoSize = true;
            this.LApellidoCliente.Location = new System.Drawing.Point(7, 50);
            this.LApellidoCliente.Name = "LApellidoCliente";
            this.LApellidoCliente.Size = new System.Drawing.Size(60, 16);
            this.LApellidoCliente.TabIndex = 10;
            this.LApellidoCliente.Text = "Apellido:";
            // 
            // LClienteDNI
            // 
            this.LClienteDNI.AutoSize = true;
            this.LClienteDNI.Location = new System.Drawing.Point(7, 77);
            this.LClienteDNI.Name = "LClienteDNI";
            this.LClienteDNI.Size = new System.Drawing.Size(33, 16);
            this.LClienteDNI.TabIndex = 11;
            this.LClienteDNI.Text = "DNI:";
            // 
            // LClienteGmail
            // 
            this.LClienteGmail.AutoSize = true;
            this.LClienteGmail.Location = new System.Drawing.Point(7, 103);
            this.LClienteGmail.Name = "LClienteGmail";
            this.LClienteGmail.Size = new System.Drawing.Size(45, 16);
            this.LClienteGmail.TabIndex = 12;
            this.LClienteGmail.Text = "Gmail:";
            // 
            // TBApellidoCliente
            // 
            this.TBApellidoCliente.Location = new System.Drawing.Point(79, 50);
            this.TBApellidoCliente.Name = "TBApellidoCliente";
            this.TBApellidoCliente.Size = new System.Drawing.Size(100, 22);
            this.TBApellidoCliente.TabIndex = 13;
            // 
            // TBDniCliente
            // 
            this.TBDniCliente.Location = new System.Drawing.Point(79, 78);
            this.TBDniCliente.Name = "TBDniCliente";
            this.TBDniCliente.Size = new System.Drawing.Size(100, 22);
            this.TBDniCliente.TabIndex = 14;
            // 
            // TBClienteGmail
            // 
            this.TBClienteGmail.Location = new System.Drawing.Point(79, 108);
            this.TBClienteGmail.Name = "TBClienteGmail";
            this.TBClienteGmail.Size = new System.Drawing.Size(100, 22);
            this.TBClienteGmail.TabIndex = 15;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Cliente General",
            "Cliente Registrado",
            "Nuevo Cliente"});
            this.comboBox1.Location = new System.Drawing.Point(273, 150);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(273, 97);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 16;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(446, 100);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 17;
            // 
            // BCargarProducto
            // 
            this.BCargarProducto.Location = new System.Drawing.Point(297, 196);
            this.BCargarProducto.Name = "BCargarProducto";
            this.BCargarProducto.Size = new System.Drawing.Size(158, 23);
            this.BCargarProducto.TabIndex = 18;
            this.BCargarProducto.Text = "Cargar Producto";
            this.BCargarProducto.UseVisualStyleBackColor = true;
            // 
            // Vendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 652);
            this.Controls.Add(this.BCargarProducto);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.BSalir);
            this.Controls.Add(this.BCobrar);
            this.Controls.Add(this.gbCliente);
            this.Controls.Add(this.Total);
            this.Controls.Add(this.LCliente);
            this.Controls.Add(this.LCantidad);
            this.Controls.Add(this.LProducto);
            this.Name = "Vendedor";
            this.Text = "Vendedor";
            this.gbCliente.ResumeLayout(false);
            this.gbCliente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LProducto;
        private System.Windows.Forms.Label LCantidad;
        private System.Windows.Forms.Label LCliente;
        private System.Windows.Forms.Label Total;
        private System.Windows.Forms.GroupBox gbCliente;
        private System.Windows.Forms.Button BCobrar;
        private System.Windows.Forms.Button BSalir;
        private System.Windows.Forms.Label LNombreCliente;
        private System.Windows.Forms.TextBox TBNombreCliente;
        private System.Windows.Forms.Label LClienteDNI;
        private System.Windows.Forms.Label LApellidoCliente;
        private System.Windows.Forms.Label LClienteGmail;
        private System.Windows.Forms.TextBox TBClienteGmail;
        private System.Windows.Forms.TextBox TBDniCliente;
        private System.Windows.Forms.TextBox TBApellidoCliente;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button BCargarProducto;
    }
}