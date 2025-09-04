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
            this.LUsuario = new System.Windows.Forms.Label();
            this.LContraseña = new System.Windows.Forms.Label();
            this.TxUsuario = new System.Windows.Forms.TextBox();
            this.TxContraseña = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(177, 187);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 96);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LUsuario
            // 
            this.LUsuario.AutoSize = true;
            this.LUsuario.Location = new System.Drawing.Point(309, 174);
            this.LUsuario.Name = "LUsuario";
            this.LUsuario.Size = new System.Drawing.Size(54, 16);
            this.LUsuario.TabIndex = 1;
            this.LUsuario.Text = "Usuario";
            // 
            // LContraseña
            // 
            this.LContraseña.AutoSize = true;
            this.LContraseña.Location = new System.Drawing.Point(309, 242);
            this.LContraseña.Name = "LContraseña";
            this.LContraseña.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LContraseña.Size = new System.Drawing.Size(76, 16);
            this.LContraseña.TabIndex = 2;
            this.LContraseña.Text = "Contraseña";
            // 
            // TxUsuario
            // 
            this.TxUsuario.Location = new System.Drawing.Point(312, 194);
            this.TxUsuario.Name = "TxUsuario";
            this.TxUsuario.Size = new System.Drawing.Size(100, 22);
            this.TxUsuario.TabIndex = 3;
            // 
            // TxContraseña
            // 
            this.TxContraseña.Location = new System.Drawing.Point(312, 261);
            this.TxContraseña.Name = "TxContraseña";
            this.TxContraseña.Size = new System.Drawing.Size(100, 22);
            this.TxContraseña.TabIndex = 4;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TxContraseña);
            this.Controls.Add(this.TxUsuario);
            this.Controls.Add(this.LContraseña);
            this.Controls.Add(this.LUsuario);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Login";
            this.Text = "Inicio de Sesion";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LUsuario;
        private System.Windows.Forms.Label LContraseña;
        private System.Windows.Forms.TextBox TxUsuario;
        private System.Windows.Forms.TextBox TxContraseña;
    }
}

