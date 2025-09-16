namespace PuntoDeVentaGameBox
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TxUsuario = new System.Windows.Forms.TextBox();
            this.TxContraseña = new System.Windows.Forms.TextBox();
            this.BAplicar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LListTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(312, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(157, 148);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // TxUsuario
            // 
            this.TxUsuario.Location = new System.Drawing.Point(159, 38);
            this.TxUsuario.Name = "TxUsuario";
            this.TxUsuario.Size = new System.Drawing.Size(124, 22);
            this.TxUsuario.TabIndex = 3;
            // 
            // TxContraseña
            // 
            this.TxContraseña.Location = new System.Drawing.Point(159, 93);
            this.TxContraseña.Name = "TxContraseña";
            this.TxContraseña.Size = new System.Drawing.Size(124, 22);
            this.TxContraseña.TabIndex = 4;
            // 
            // BAplicar
            // 
            this.BAplicar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.BAplicar.FlatAppearance.BorderSize = 0;
            this.BAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAplicar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAplicar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BAplicar.Location = new System.Drawing.Point(238, 363);
            this.BAplicar.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.BAplicar.Name = "BAplicar";
            this.BAplicar.Size = new System.Drawing.Size(141, 39);
            this.BAplicar.TabIndex = 22;
            this.BAplicar.Text = "Ingresar";
            this.BAplicar.UseVisualStyleBackColor = false;
            this.BAplicar.Click += new System.EventHandler(this.BIngresar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(397, 363);
            this.button1.Margin = new System.Windows.Forms.Padding(15, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 39);
            this.button1.TabIndex = 23;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.LListTitle);
            this.panel1.Controls.Add(this.TxUsuario);
            this.panel1.Controls.Add(this.TxContraseña);
            this.panel1.Location = new System.Drawing.Point(238, 192);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 143);
            this.panel1.TabIndex = 24;
            // 
            // LListTitle
            // 
            this.LListTitle.AutoSize = true;
            this.LListTitle.Font = new System.Drawing.Font("Segoe UI", 12.2F, System.Drawing.FontStyle.Bold);
            this.LListTitle.Location = new System.Drawing.Point(18, 30);
            this.LListTitle.Margin = new System.Windows.Forms.Padding(0);
            this.LListTitle.Name = "LListTitle";
            this.LListTitle.Size = new System.Drawing.Size(88, 30);
            this.LListTitle.TabIndex = 25;
            this.LListTitle.Text = "Usuario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(18, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 30);
            this.label1.TabIndex = 26;
            this.label1.Text = "Contraseña";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BAplicar);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio de Sesion";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox TxUsuario;
        private System.Windows.Forms.TextBox TxContraseña;
        private System.Windows.Forms.Button BAplicar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LListTitle;
    }
}

