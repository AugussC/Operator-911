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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelEficienciaJurisdiccion = new System.Windows.Forms.Label();
            this.labelAlertasAtendidas = new System.Windows.Forms.Label();
            this.labelPatrullas = new System.Windows.Forms.Label();
            this.labelPolicias = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateTimeDesde = new System.Windows.Forms.DateTimePicker();
            this.dateTimeHasta = new System.Windows.Forms.DateTimePicker();
            this.labelDesde = new System.Windows.Forms.Label();
            this.labelHasta = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(418, 32);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(254, 27);
            this.labelTitulo.TabIndex = 1;
            this.labelTitulo.Text = "Bienvenido Comisario";
            // 
            // labelEficienciaJurisdiccion
            // 
            this.labelEficienciaJurisdiccion.AutoSize = true;
            this.labelEficienciaJurisdiccion.Location = new System.Drawing.Point(618, 147);
            this.labelEficienciaJurisdiccion.Name = "labelEficienciaJurisdiccion";
            this.labelEficienciaJurisdiccion.Size = new System.Drawing.Size(53, 13);
            this.labelEficienciaJurisdiccion.TabIndex = 9;
            this.labelEficienciaJurisdiccion.Text = "Eficiencia";
            // 
            // labelAlertasAtendidas
            // 
            this.labelAlertasAtendidas.AutoSize = true;
            this.labelAlertasAtendidas.Location = new System.Drawing.Point(321, 147);
            this.labelAlertasAtendidas.Name = "labelAlertasAtendidas";
            this.labelAlertasAtendidas.Size = new System.Drawing.Size(84, 13);
            this.labelAlertasAtendidas.TabIndex = 8;
            this.labelAlertasAtendidas.Text = "Alerta Atendidas";
            // 
            // labelPatrullas
            // 
            this.labelPatrullas.AutoSize = true;
            this.labelPatrullas.Location = new System.Drawing.Point(844, 147);
            this.labelPatrullas.Name = "labelPatrullas";
            this.labelPatrullas.Size = new System.Drawing.Size(47, 13);
            this.labelPatrullas.TabIndex = 7;
            this.labelPatrullas.Text = "Patrullas";
            // 
            // labelPolicias
            // 
            this.labelPolicias.AutoSize = true;
            this.labelPolicias.Location = new System.Drawing.Point(142, 147);
            this.labelPolicias.Name = "labelPolicias";
            this.labelPolicias.Size = new System.Drawing.Size(43, 13);
            this.labelPolicias.TabIndex = 6;
            this.labelPolicias.Text = "Policias";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(1117, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(78, 699);
            this.panel1.TabIndex = 26;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.chart2);
            this.panel3.Location = new System.Drawing.Point(599, 305);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(462, 333);
            this.panel3.TabIndex = 30;
            // 
            // chart2
            // 
            chartArea7.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chart2.Legends.Add(legend7);
            this.chart2.Location = new System.Drawing.Point(21, 26);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chart2.Series.Add(series7);
            this.chart2.Size = new System.Drawing.Size(418, 286);
            this.chart2.TabIndex = 6;
            this.chart2.Text = "chart2";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.chart1);
            this.panel2.Location = new System.Drawing.Point(67, 305);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(462, 333);
            this.panel2.TabIndex = 29;
            // 
            // chart1
            // 
            chartArea8.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chart1.Legends.Add(legend8);
            this.chart1.Location = new System.Drawing.Point(24, 26);
            this.chart1.Name = "chart1";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.chart1.Series.Add(series8);
            this.chart1.Size = new System.Drawing.Size(418, 286);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // dateTimeDesde
            // 
            this.dateTimeDesde.Location = new System.Drawing.Point(205, 275);
            this.dateTimeDesde.Name = "dateTimeDesde";
            this.dateTimeDesde.Size = new System.Drawing.Size(200, 20);
            this.dateTimeDesde.TabIndex = 31;
            // 
            // dateTimeHasta
            // 
            this.dateTimeHasta.Location = new System.Drawing.Point(205, 241);
            this.dateTimeHasta.Name = "dateTimeHasta";
            this.dateTimeHasta.Size = new System.Drawing.Size(200, 20);
            this.dateTimeHasta.TabIndex = 32;
            // 
            // labelDesde
            // 
            this.labelDesde.AutoSize = true;
            this.labelDesde.Location = new System.Drawing.Point(144, 241);
            this.labelDesde.Name = "labelDesde";
            this.labelDesde.Size = new System.Drawing.Size(41, 13);
            this.labelDesde.TabIndex = 33;
            this.labelDesde.Text = "Desde ";
            // 
            // labelHasta
            // 
            this.labelHasta.AutoSize = true;
            this.labelHasta.Location = new System.Drawing.Point(144, 281);
            this.labelHasta.Name = "labelHasta";
            this.labelHasta.Size = new System.Drawing.Size(35, 13);
            this.labelHasta.TabIndex = 34;
            this.labelHasta.Text = "Hasta";
            // 
            // UCInicioComisario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelHasta);
            this.Controls.Add(this.labelDesde);
            this.Controls.Add(this.dateTimeHasta);
            this.Controls.Add(this.dateTimeDesde);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelEficienciaJurisdiccion);
            this.Controls.Add(this.labelAlertasAtendidas);
            this.Controls.Add(this.labelPatrullas);
            this.Controls.Add(this.labelPolicias);
            this.Controls.Add(this.labelTitulo);
            this.Name = "UCInicioComisario";
            this.Size = new System.Drawing.Size(1162, 699);
            this.Load += new System.EventHandler(this.UCInicioComisario_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelEficienciaJurisdiccion;
        private System.Windows.Forms.Label labelAlertasAtendidas;
        private System.Windows.Forms.Label labelPatrullas;
        private System.Windows.Forms.Label labelPolicias;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DateTimePicker dateTimeDesde;
        private System.Windows.Forms.DateTimePicker dateTimeHasta;
        private System.Windows.Forms.Label labelDesde;
        private System.Windows.Forms.Label labelHasta;
    }
}
