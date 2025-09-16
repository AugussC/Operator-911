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
    public partial class UCInicioComisario : UserControl
    {
        public UCInicioComisario()
        {
            InitializeComponent();
        }

        private void UCInicioComisario_Load(object sender, EventArgs e)
        {
            // ---- Gráfico Izquierdo: Policías vs Patrullas ----
            chart2.Series.Clear();
            chart2.ChartAreas[0].AxisX.Title = "Categorías";
            chart2.ChartAreas[0].AxisY.Title = "Cantidad";

            Series serieComparativa = new Series("Recursos");
            serieComparativa.ChartType = SeriesChartType.Column;
            serieComparativa.Points.AddXY("Policías", 120);  // dato estático
            serieComparativa.Points.AddXY("Patrullas", 40);  // dato estático

            chart2.Series.Add(serieComparativa);

            // ---- Gráfico Derecho: Alertas atendidas por mes ----
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Title = "Día";
            chart1.ChartAreas[0].AxisY.Title = "Alertas Atendidas";

            Series serieAlertas = new Series("Alertas");
            serieAlertas.ChartType = SeriesChartType.Column;

            // Ejemplo: datos ficticios para los primeros 10 días
            serieAlertas.Points.AddXY("1", 5);
            serieAlertas.Points.AddXY("2", 3);
            serieAlertas.Points.AddXY("3", 7);
            serieAlertas.Points.AddXY("4", 2);
            serieAlertas.Points.AddXY("5", 8);
            serieAlertas.Points.AddXY("6", 4);
            serieAlertas.Points.AddXY("7", 6);
            serieAlertas.Points.AddXY("8", 9);
            serieAlertas.Points.AddXY("9", 3);
            serieAlertas.Points.AddXY("10", 5);

            chart1.Series.Add(serieAlertas);
        }
    }
}
