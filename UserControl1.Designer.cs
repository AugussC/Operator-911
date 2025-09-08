namespace Operador_911
{
    partial class UCInicioComisario
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelEficienciaJurisdiccion = new System.Windows.Forms.Label();
            this.labelAlertasAtendidas = new System.Windows.Forms.Label();
            this.labelPatrullas = new System.Windows.Forms.Label();
            this.labelPolicias = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(554, 30);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(129, 25);
            this.labelTitulo.TabIndex = 1;
            this.labelTitulo.Text = "Bienvenido";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(36, 299);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1094, 342);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // labelEficienciaJurisdiccion
            // 
            this.labelEficienciaJurisdiccion.AutoSize = true;
            this.labelEficienciaJurisdiccion.Location = new System.Drawing.Point(750, 190);
            this.labelEficienciaJurisdiccion.Name = "labelEficienciaJurisdiccion";
            this.labelEficienciaJurisdiccion.Size = new System.Drawing.Size(53, 13);
            this.labelEficienciaJurisdiccion.TabIndex = 9;
            this.labelEficienciaJurisdiccion.Text = "Eficiencia";
            // 
            // labelAlertasAtendidas
            // 
            this.labelAlertasAtendidas.AutoSize = true;
            this.labelAlertasAtendidas.Location = new System.Drawing.Point(376, 190);
            this.labelAlertasAtendidas.Name = "labelAlertasAtendidas";
            this.labelAlertasAtendidas.Size = new System.Drawing.Size(84, 13);
            this.labelAlertasAtendidas.TabIndex = 8;
            this.labelAlertasAtendidas.Text = "Alerta Atendidas";
            // 
            // labelPatrullas
            // 
            this.labelPatrullas.AutoSize = true;
            this.labelPatrullas.Location = new System.Drawing.Point(750, 91);
            this.labelPatrullas.Name = "labelPatrullas";
            this.labelPatrullas.Size = new System.Drawing.Size(47, 13);
            this.labelPatrullas.TabIndex = 7;
            this.labelPatrullas.Text = "Patrullas";
            // 
            // labelPolicias
            // 
            this.labelPolicias.AutoSize = true;
            this.labelPolicias.Location = new System.Drawing.Point(376, 91);
            this.labelPolicias.Name = "labelPolicias";
            this.labelPolicias.Size = new System.Drawing.Size(43, 13);
            this.labelPolicias.TabIndex = 6;
            this.labelPolicias.Text = "Policias";
            // 
            // UCInicioComisario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelEficienciaJurisdiccion);
            this.Controls.Add(this.labelAlertasAtendidas);
            this.Controls.Add(this.labelPatrullas);
            this.Controls.Add(this.labelPolicias);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.labelTitulo);
            this.Name = "UCInicioComisario";
            this.Size = new System.Drawing.Size(1162, 699);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label labelEficienciaJurisdiccion;
        private System.Windows.Forms.Label labelAlertasAtendidas;
        private System.Windows.Forms.Label labelPatrullas;
        private System.Windows.Forms.Label labelPolicias;
    }
}
