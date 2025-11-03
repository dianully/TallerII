namespace PuntoDeVentaGameBox.Gerente
{
    partial class GraficosProductos
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.PGraficos = new System.Windows.Forms.Panel();
            this.chartDistribucionGenero = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartEvolucionVentas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTopProductos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.LTitulo = new System.Windows.Forms.Label();
            this.BVolverAtras = new System.Windows.Forms.Button();
            this.PGraficos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDistribucionGenero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEvolucionVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // PGraficos
            // 
            this.PGraficos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.PGraficos.Controls.Add(this.chartDistribucionGenero);
            this.PGraficos.Controls.Add(this.chartEvolucionVentas);
            this.PGraficos.Controls.Add(this.chartTopProductos);
            this.PGraficos.Controls.Add(this.LTitulo);
            this.PGraficos.Controls.Add(this.BVolverAtras);
            this.PGraficos.Location = new System.Drawing.Point(0, 1);
            this.PGraficos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PGraficos.Name = "PGraficos";
            this.PGraficos.Size = new System.Drawing.Size(1051, 757);
            this.PGraficos.TabIndex = 10;
            this.PGraficos.Paint += new System.Windows.Forms.PaintEventHandler(this.PGraficos_Paint_1);
            // 
            // chartDistribucionGenero
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDistribucionGenero.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDistribucionGenero.Legends.Add(legend1);
            this.chartDistribucionGenero.Location = new System.Drawing.Point(283, 459);
            this.chartDistribucionGenero.Name = "chartDistribucionGenero";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDistribucionGenero.Series.Add(series1);
            this.chartDistribucionGenero.Size = new System.Drawing.Size(500, 250);
            this.chartDistribucionGenero.TabIndex = 48;
            this.chartDistribucionGenero.Text = "chart3";
            // 
            // chartEvolucionVentas
            // 
            chartArea2.Name = "ChartArea1";
            this.chartEvolucionVentas.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartEvolucionVentas.Legends.Add(legend2);
            this.chartEvolucionVentas.Location = new System.Drawing.Point(538, 132);
            this.chartEvolucionVentas.Name = "chartEvolucionVentas";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartEvolucionVentas.Series.Add(series2);
            this.chartEvolucionVentas.Size = new System.Drawing.Size(500, 250);
            this.chartEvolucionVentas.TabIndex = 47;
            this.chartEvolucionVentas.Text = "chart2";
            // 
            // chartTopProductos
            // 
            chartArea3.Name = "ChartArea1";
            this.chartTopProductos.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartTopProductos.Legends.Add(legend3);
            this.chartTopProductos.Location = new System.Drawing.Point(13, 132);
            this.chartTopProductos.Name = "chartTopProductos";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartTopProductos.Series.Add(series3);
            this.chartTopProductos.Size = new System.Drawing.Size(500, 250);
            this.chartTopProductos.TabIndex = 46;
            this.chartTopProductos.Text = "chart1";
            // 
            // LTitulo
            // 
            this.LTitulo.AutoSize = true;
            this.LTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitulo.ForeColor = System.Drawing.SystemColors.Control;
            this.LTitulo.Location = new System.Drawing.Point(15, 24);
            this.LTitulo.Name = "LTitulo";
            this.LTitulo.Size = new System.Drawing.Size(272, 35);
            this.LTitulo.TabIndex = 45;
            this.LTitulo.Text = "Graficos de Productos";
            // 
            // BVolverAtras
            // 
            this.BVolverAtras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.BVolverAtras.FlatAppearance.BorderSize = 0;
            this.BVolverAtras.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BVolverAtras.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BVolverAtras.Location = new System.Drawing.Point(833, 24);
            this.BVolverAtras.Margin = new System.Windows.Forms.Padding(17, 3, 3, 3);
            this.BVolverAtras.Name = "BVolverAtras";
            this.BVolverAtras.Size = new System.Drawing.Size(200, 45);
            this.BVolverAtras.TabIndex = 44;
            this.BVolverAtras.Text = "Volver Atras";
            this.BVolverAtras.UseVisualStyleBackColor = false;
            // 
            // GraficosProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 757);
            this.Controls.Add(this.PGraficos);
            this.Name = "GraficosProductos";
            this.Text = "GraficosProductos";
            this.Load += new System.EventHandler(this.GraficosProductos_Load_1);
            this.PGraficos.ResumeLayout(false);
            this.PGraficos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDistribucionGenero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEvolucionVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PGraficos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDistribucionGenero;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEvolucionVentas;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopProductos;
        private System.Windows.Forms.Label LTitulo;
        private System.Windows.Forms.Button BVolverAtras;
    }
}