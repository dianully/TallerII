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
            this.gbCliente = new System.Windows.Forms.GroupBox();
            this.TBClienteGmail = new System.Windows.Forms.TextBox();
            this.TBDniCliente = new System.Windows.Forms.TextBox();
            this.TBApellidoCliente = new System.Windows.Forms.TextBox();
            this.LClienteGmail = new System.Windows.Forms.Label();
            this.LClienteDNI = new System.Windows.Forms.Label();
            this.LApellidoCliente = new System.Windows.Forms.Label();
            this.LNombreCliente = new System.Windows.Forms.Label();
            this.TBNombreCliente = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.LTitle = new System.Windows.Forms.Label();
            this.BAplicar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.LRol = new System.Windows.Forms.Label();
            this.gbCliente.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // LProducto
            // 
            this.LProducto.AutoSize = true;
            this.LProducto.Location = new System.Drawing.Point(20, 14);
            this.LProducto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LProducto.Name = "LProducto";
            this.LProducto.Size = new System.Drawing.Size(50, 13);
            this.LProducto.TabIndex = 0;
            this.LProducto.Text = "Producto";
            // 
            // LCantidad
            // 
            this.LCantidad.AutoSize = true;
            this.LCantidad.Location = new System.Drawing.Point(145, 16);
            this.LCantidad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LCantidad.Name = "LCantidad";
            this.LCantidad.Size = new System.Drawing.Size(49, 13);
            this.LCantidad.TabIndex = 1;
            this.LCantidad.Text = "Cantidad";
            // 
            // LCliente
            // 
            this.LCliente.AutoSize = true;
            this.LCliente.Location = new System.Drawing.Point(20, 57);
            this.LCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LCliente.Name = "LCliente";
            this.LCliente.Size = new System.Drawing.Size(42, 13);
            this.LCliente.TabIndex = 2;
            this.LCliente.Text = "Cliente:";
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
            this.gbCliente.Location = new System.Drawing.Point(377, 60);
            this.gbCliente.Margin = new System.Windows.Forms.Padding(2);
            this.gbCliente.Name = "gbCliente";
            this.gbCliente.Padding = new System.Windows.Forms.Padding(2);
            this.gbCliente.Size = new System.Drawing.Size(284, 127);
            this.gbCliente.TabIndex = 6;
            this.gbCliente.TabStop = false;
            this.gbCliente.Text = "Datos del Cliente";
            // 
            // TBClienteGmail
            // 
            this.TBClienteGmail.Location = new System.Drawing.Point(59, 88);
            this.TBClienteGmail.Margin = new System.Windows.Forms.Padding(2);
            this.TBClienteGmail.Name = "TBClienteGmail";
            this.TBClienteGmail.Size = new System.Drawing.Size(76, 20);
            this.TBClienteGmail.TabIndex = 15;
            // 
            // TBDniCliente
            // 
            this.TBDniCliente.Location = new System.Drawing.Point(59, 63);
            this.TBDniCliente.Margin = new System.Windows.Forms.Padding(2);
            this.TBDniCliente.Name = "TBDniCliente";
            this.TBDniCliente.Size = new System.Drawing.Size(76, 20);
            this.TBDniCliente.TabIndex = 14;
            // 
            // TBApellidoCliente
            // 
            this.TBApellidoCliente.Location = new System.Drawing.Point(59, 41);
            this.TBApellidoCliente.Margin = new System.Windows.Forms.Padding(2);
            this.TBApellidoCliente.Name = "TBApellidoCliente";
            this.TBApellidoCliente.Size = new System.Drawing.Size(76, 20);
            this.TBApellidoCliente.TabIndex = 13;
            // 
            // LClienteGmail
            // 
            this.LClienteGmail.AutoSize = true;
            this.LClienteGmail.Location = new System.Drawing.Point(5, 84);
            this.LClienteGmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LClienteGmail.Name = "LClienteGmail";
            this.LClienteGmail.Size = new System.Drawing.Size(36, 13);
            this.LClienteGmail.TabIndex = 12;
            this.LClienteGmail.Text = "Gmail:";
            // 
            // LClienteDNI
            // 
            this.LClienteDNI.AutoSize = true;
            this.LClienteDNI.Location = new System.Drawing.Point(5, 63);
            this.LClienteDNI.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LClienteDNI.Name = "LClienteDNI";
            this.LClienteDNI.Size = new System.Drawing.Size(29, 13);
            this.LClienteDNI.TabIndex = 11;
            this.LClienteDNI.Text = "DNI:";
            // 
            // LApellidoCliente
            // 
            this.LApellidoCliente.AutoSize = true;
            this.LApellidoCliente.Location = new System.Drawing.Point(5, 41);
            this.LApellidoCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LApellidoCliente.Name = "LApellidoCliente";
            this.LApellidoCliente.Size = new System.Drawing.Size(47, 13);
            this.LApellidoCliente.TabIndex = 10;
            this.LApellidoCliente.Text = "Apellido:";
            // 
            // LNombreCliente
            // 
            this.LNombreCliente.AutoSize = true;
            this.LNombreCliente.Location = new System.Drawing.Point(5, 20);
            this.LNombreCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LNombreCliente.Name = "LNombreCliente";
            this.LNombreCliente.Size = new System.Drawing.Size(47, 13);
            this.LNombreCliente.TabIndex = 9;
            this.LNombreCliente.Text = "Nombre:";
            // 
            // TBNombreCliente
            // 
            this.TBNombreCliente.Location = new System.Drawing.Point(59, 17);
            this.TBNombreCliente.Margin = new System.Windows.Forms.Padding(2);
            this.TBNombreCliente.Name = "TBNombreCliente";
            this.TBNombreCliente.Size = new System.Drawing.Size(76, 20);
            this.TBNombreCliente.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Cliente General",
            "Cliente Registrado",
            "Nuevo Cliente"});
            this.comboBox1.Location = new System.Drawing.Point(66, 54);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(92, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(66, 14);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(76, 20);
            this.textBox1.TabIndex = 16;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(195, 16);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(76, 20);
            this.textBox2.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.LProducto);
            this.panel1.Controls.Add(this.LCantidad);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.LCliente);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Location = new System.Drawing.Point(48, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 127);
            this.panel1.TabIndex = 19;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(89, 88);
            this.button2.Margin = new System.Windows.Forms.Padding(11, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 32);
            this.button2.TabIndex = 24;
            this.button2.Text = "Cargar Producto";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // LTitle
            // 
            this.LTitle.AutoSize = true;
            this.LTitle.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitle.Location = new System.Drawing.Point(55, 425);
            this.LTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LTitle.Name = "LTitle";
            this.LTitle.Size = new System.Drawing.Size(96, 37);
            this.LTitle.TabIndex = 20;
            this.LTitle.Text = "Total: ";
            // 
            // BAplicar
            // 
            this.BAplicar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.BAplicar.FlatAppearance.BorderSize = 0;
            this.BAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAplicar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAplicar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BAplicar.Location = new System.Drawing.Point(48, 475);
            this.BAplicar.Margin = new System.Windows.Forms.Padding(11, 2, 2, 2);
            this.BAplicar.Name = "BAplicar";
            this.BAplicar.Size = new System.Drawing.Size(106, 32);
            this.BAplicar.TabIndex = 21;
            this.BAplicar.Text = "Cobrar";
            this.BAplicar.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(213, 475);
            this.button1.Margin = new System.Windows.Forms.Padding(11, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 32);
            this.button1.TabIndex = 22;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Nombre,
            this.PrecioUnitario,
            this.Cantidad,
            this.Total});
            this.dataGridView1.Location = new System.Drawing.Point(48, 212);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(901, 211);
            this.dataGridView1.TabIndex = 23;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Producto";
            this.Nombre.Name = "Nombre";
            // 
            // PrecioUnitario
            // 
            this.PrecioUnitario.HeaderText = "Precio Unitario";
            this.PrecioUnitario.Name = "PrecioUnitario";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(155, 425);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 37);
            this.label1.TabIndex = 24;
            // 
            // LRol
            // 
            this.LRol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LRol.AutoSize = true;
            this.LRol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.LRol.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LRol.Location = new System.Drawing.Point(872, 18);
            this.LRol.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LRol.Name = "LRol";
            this.LRol.Size = new System.Drawing.Size(102, 28);
            this.LRol.TabIndex = 25;
            this.LRol.Text = "Vendedor";
            // 
            // Vendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 530);
            this.Controls.Add(this.LRol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BAplicar);
            this.Controls.Add(this.LTitle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbCliente);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Vendedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vendedor";
            this.gbCliente.ResumeLayout(false);
            this.gbCliente.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LProducto;
        private System.Windows.Forms.Label LCantidad;
        private System.Windows.Forms.Label LCliente;
        private System.Windows.Forms.GroupBox gbCliente;
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LTitle;
        private System.Windows.Forms.Button BAplicar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LRol;
    }
}