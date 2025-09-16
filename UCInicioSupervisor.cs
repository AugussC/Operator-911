using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Operador_911
{
    public partial class UCInicioSupervisor : UserControl
    {
        public UCInicioSupervisor()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UCInicioSupervisor_Load(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Title = "Día";
            chart1.ChartAreas[0].AxisY.Title = "Cantidad de Alertas";

            Series serieAlertasDia = new Series("Alertas");
            serieAlertasDia.ChartType = SeriesChartType.Column;

            // Datos de ejemplo: primeros 7 días del mes
            serieAlertasDia.Points.AddXY("1", 5);
            serieAlertasDia.Points.AddXY("2", 8);
            serieAlertasDia.Points.AddXY("3", 3);
            serieAlertasDia.Points.AddXY("4", 10);
            serieAlertasDia.Points.AddXY("5", 7);
            serieAlertasDia.Points.AddXY("6", 6);
            serieAlertasDia.Points.AddXY("7", 9);

            chart1.Series.Add(serieAlertasDia);


            // ---- Gráfico Derecho: Tiempo promedio de Atención ----
            chart2.Series.Clear();
            chart2.ChartAreas[0].AxisX.Title = "Día";
            chart2.ChartAreas[0].AxisY.Title = "Tiempo (minutos)";

            Series serieTiempo = new Series("Tiempo Promedio");
            serieTiempo.ChartType = SeriesChartType.Column;

            // Datos de ejemplo: mismos 7 días con tiempos ficticios
            serieTiempo.Points.AddXY("1", 12);
            serieTiempo.Points.AddXY("2", 9);
            serieTiempo.Points.AddXY("3", 15);
            serieTiempo.Points.AddXY("4", 8);
            serieTiempo.Points.AddXY("5", 11);
            serieTiempo.Points.AddXY("6", 10);
            serieTiempo.Points.AddXY("7", 13);

            chart2.Series.Add(serieTiempo);
        }
    }
}
