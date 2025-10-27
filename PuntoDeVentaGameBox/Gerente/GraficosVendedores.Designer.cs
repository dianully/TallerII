﻿namespace PuntoDeVentaGameBox.Gerente
{
    partial class GraficosVendedores
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
            this.chartTicketPromedio = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTransaccionesVendedor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartRendimientoVendedor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.LTitulo = new System.Windows.Forms.Label();
            this.BVolverAtras = new System.Windows.Forms.Button();
            this.PGraficos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTicketPromedio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTransaccionesVendedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRendimientoVendedor)).BeginInit();
            this.SuspendLayout();
            // 
            // PGraficos
            // 
            this.PGraficos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(62)))), ((int)(((byte)(77)))));
            this.PGraficos.Controls.Add(this.chartTicketPromedio);
            this.PGraficos.Controls.Add(this.chartTransaccionesVendedor);
            this.PGraficos.Controls.Add(this.chartRendimientoVendedor);
            this.PGraficos.Controls.Add(this.LTitulo);
            this.PGraficos.Controls.Add(this.BVolverAtras);
            this.PGraficos.Location = new System.Drawing.Point(-1, -3);
            this.PGraficos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PGraficos.Name = "PGraficos";
            this.PGraficos.Size = new System.Drawing.Size(1051, 757);
            this.PGraficos.TabIndex = 9;
            this.PGraficos.Paint += new System.Windows.Forms.PaintEventHandler(this.PGraficos_Paint);
            // 
            // chartTicketPromedio
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTicketPromedio.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTicketPromedio.Legends.Add(legend1);
            this.chartTicketPromedio.Location = new System.Drawing.Point(283, 459);
            this.chartTicketPromedio.Name = "chartTicketPromedio";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartTicketPromedio.Series.Add(series1);
            this.chartTicketPromedio.Size = new System.Drawing.Size(500, 250);
            this.chartTicketPromedio.TabIndex = 48;
            this.chartTicketPromedio.Text = "chart3";
            // 
            // chartTransaccionesVendedor
            // 
            chartArea2.Name = "ChartArea1";
            this.chartTransaccionesVendedor.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartTransaccionesVendedor.Legends.Add(legend2);
            this.chartTransaccionesVendedor.Location = new System.Drawing.Point(538, 132);
            this.chartTransaccionesVendedor.Name = "chartTransaccionesVendedor";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartTransaccionesVendedor.Series.Add(series2);
            this.chartTransaccionesVendedor.Size = new System.Drawing.Size(500, 250);
            this.chartTransaccionesVendedor.TabIndex = 47;
            this.chartTransaccionesVendedor.Text = "chart2";
            // 
            // chartRendimientoVendedor
            // 
            chartArea3.Name = "ChartArea1";
            this.chartRendimientoVendedor.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartRendimientoVendedor.Legends.Add(legend3);
            this.chartRendimientoVendedor.Location = new System.Drawing.Point(13, 132);
            this.chartRendimientoVendedor.Name = "chartRendimientoVendedor";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartRendimientoVendedor.Series.Add(series3);
            this.chartRendimientoVendedor.Size = new System.Drawing.Size(500, 250);
            this.chartRendimientoVendedor.TabIndex = 46;
            this.chartRendimientoVendedor.Text = "chart1";
            // 
            // LTitulo
            // 
            this.LTitulo.AutoSize = true;
            this.LTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitulo.ForeColor = System.Drawing.SystemColors.Control;
            this.LTitulo.Location = new System.Drawing.Point(15, 24);
            this.LTitulo.Name = "LTitulo";
            this.LTitulo.Size = new System.Drawing.Size(281, 35);
            this.LTitulo.TabIndex = 45;
            this.LTitulo.Text = "Grafico de Vendedores";
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
            this.BVolverAtras.Click += new System.EventHandler(this.BVolverAtras_Click);
            // 
            // GraficosVendedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 758);
            this.Controls.Add(this.PGraficos);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GraficosVendedores";
            this.Text = "GraficosVendedores";
            this.Load += new System.EventHandler(this.GraficosVendedores_Load);
            this.PGraficos.ResumeLayout(false);
            this.PGraficos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTicketPromedio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTransaccionesVendedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRendimientoVendedor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PGraficos;
        private System.Windows.Forms.Button BVolverAtras;
        private System.Windows.Forms.Label LTitulo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRendimientoVendedor;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTicketPromedio;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTransaccionesVendedor;
    }
}