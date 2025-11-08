using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        private void UCInicioSupervisor_Load(object sender, EventArgs e)
        {
            // Ajustamos fechas iniciales
            dateTimeHasta.Value = DateTime.Today;
            dateTimeDesde.Value = DateTime.Today.AddDays(-7); // 🔹 Una semana antes

            // Vinculamos el evento de cambio de fecha
            dateTimeDesde.ValueChanged += DatePicker_ValueChanged;
            dateTimeHasta.ValueChanged += DatePicker_ValueChanged;

            // Cargamos inicialmente
            CargarGraficos();
        }


        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            CargarGraficos();
        }

        private void CargarGraficos()
        {
            DateTime desde = dateTimeDesde.Value.Date;
            DateTime hasta = dateTimeHasta.Value.Date.AddDays(1).AddTicks(-1);

            // Validación básica de rango
            if (desde > hasta)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.", "Rango inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            chart1.Series.Clear();
            chart2.Series.Clear();

            try
            {
                // --- ALERTAS POR DÍA ---
                Series serieAlertasDia = new Series("Alertas")
                {
                    ChartType = SeriesChartType.Spline,
                    BorderWidth = 3,
                    MarkerStyle = MarkerStyle.Circle,
                    MarkerSize = 7
                };

                using (SqlConnection con = Database.GetConnection())
                {
                    string queryAlertas = @"
                SELECT CONVERT(date, L.fecha_creacion) AS Dia,
                       COUNT(*) AS CantidadAlertas
                FROM Llamada L
                WHERE L.fecha_creacion BETWEEN @Desde AND @Hasta
                GROUP BY CONVERT(date, L.fecha_creacion)
                ORDER BY Dia;";

                    using (SqlCommand cmd = new SqlCommand(queryAlertas, con))
                    {
                        cmd.Parameters.AddWithValue("@Desde", desde);
                        cmd.Parameters.AddWithValue("@Hasta", hasta);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                MessageBox.Show("No se encontraron alertas en el rango seleccionado.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                while (reader.Read())
                                {
                                    DateTime dia = reader.GetDateTime(0);
                                    int cantidad = reader.GetInt32(1);
                                    serieAlertasDia.Points.AddXY(dia.ToString("dd/MM"), cantidad);
                                }
                                chart1.Series.Add(serieAlertasDia);
                            }
                        }
                    }
                }

                chart1.ChartAreas[0].AxisX.Title = "Día";
                chart1.ChartAreas[0].AxisY.Title = "Cantidad de Alertas";
                chart1.ChartAreas[0].RecalculateAxesScale();

                // --- TIEMPO PROMEDIO DE ATENCIÓN ---
                Series serieTiempo = new Series("Tiempo Promedio")
                {
                    ChartType = SeriesChartType.Spline,
                    BorderWidth = 3,
                    MarkerStyle = MarkerStyle.Square,
                    MarkerSize = 7
                };

                using (SqlConnection conn = Database.GetConnection())
                {
                    string queryTiempo = @"
                SELECT CONVERT(date, L.fecha_creacion) AS Dia,
                       AVG(DATEDIFF(MINUTE, L.fecha_creacion, A.fecha_cierre)) AS TiempoPromedio
                FROM Llamada L
                JOIN Alerta A ON L.id_alerta = A.id_alerta
                WHERE L.fecha_creacion BETWEEN @Desde AND @Hasta
                  AND A.fecha_cierre IS NOT NULL
                GROUP BY CONVERT(date, L.fecha_creacion)
                ORDER BY Dia;";

                    using (SqlCommand cmd = new SqlCommand(queryTiempo, conn))
                    {
                        cmd.Parameters.AddWithValue("@Desde", desde);
                        cmd.Parameters.AddWithValue("@Hasta", hasta);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                MessageBox.Show("No hay datos de tiempo promedio para el rango seleccionado.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                while (reader.Read())
                                {
                                    DateTime dia = reader.GetDateTime(0);
                                    double tiempoPromedio = reader.IsDBNull(1) ? 0 : Convert.ToDouble(reader.GetValue(1));
                                    serieTiempo.Points.AddXY(dia.ToString("dd/MM"), tiempoPromedio);
                                }

                                chart2.Series.Add(serieTiempo);
                            }
                        }
                    }
                }

                chart2.ChartAreas[0].AxisX.Title = "Día";
                chart2.ChartAreas[0].AxisY.Title = "Tiempo Promedio (minutos)";
                chart2.ChartAreas[0].RecalculateAxesScale();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error de base de datos: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
