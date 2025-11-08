using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static Operador_911.FormLogin;

namespace Operador_911
{
    public partial class UCInicioComisario : UserControl
    {
        private int idComisariaActual = 0;

        public UCInicioComisario()
        {
            InitializeComponent();
        }

        private void UCInicioComisario_Load(object sender, EventArgs e)
        {

            dateTimeHasta.Value = DateTime.Today;
            dateTimeDesde.Value = DateTime.Today.AddDays(-7); // 🔹 Una semana antes

            dateTimeDesde.ValueChanged += DatePicker_ValueChanged;
            dateTimeHasta.ValueChanged += DatePicker_ValueChanged;
            CargarDashboard();
        }

        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            CargarDashboard();
        }

        private void CargarDashboard()
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    // 1️⃣ Obtener el ID de la comisaría del comisario logueado
                    string queryComisaria = "SELECT id_comisaria FROM Comisaria WHERE id_usuario_comisario = @idUsuario";
                    SqlCommand cmdComisaria = new SqlCommand(queryComisaria, conn);
                    cmdComisaria.Parameters.AddWithValue("@idUsuario", Sesion.IdUsuario);

                    object result = cmdComisaria.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("No se encontró una comisaría asociada a este usuario.");
                        return;
                    }
                    this.idComisariaActual = Convert.ToInt32(result); // 👈 guardamos para reutilizar
                }

                // 🔹 Validar rango de fechas
                if (dateTimeDesde.Value.Date > dateTimeHasta.Value.Date)
                {
                    MessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.",
                        "Error de fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime desde = dateTimeDesde.Value.Date;
                DateTime hasta = dateTimeHasta.Value.Date;

                int idComisaria = idComisariaActual;

                // 🔹 Obtener datos protegidos
                int totalPolicias = ObtenerCantidadPoliciasActivos(idComisaria);
                int totalPatrullas = ObtenerCantidadPatrullasDisponibles(idComisaria);
                int totalAlertas = ObtenerCantidadAlertasAtendidas(desde, hasta, idComisaria);
                double eficiencia = CalcularEficiencia(idComisaria);

                // 🔹 Mostrar resultados
                NroPolicias.Text = totalPolicias >= 0 ? totalPolicias.ToString() : "0";
                NroPatrullas.Text = totalPatrullas >= 0 ? totalPatrullas.ToString() : "0";
                AlertasAtendidas.Text = totalAlertas >= 0 ? totalAlertas.ToString() : "0";
                Eficiencia.Text = eficiencia >= 0 ? eficiencia.ToString("0.00") + "%" : "N/A";

                // 🔹 Gráfico Recursos
                chart2.Series.Clear();
                Series serieRecursos = new Series("Recursos")
                {
                    ChartType = SeriesChartType.Column,
                    Color = System.Drawing.Color.Green
                };
                serieRecursos.Points.AddXY("Policías", totalPolicias);
                serieRecursos.Points.AddXY("Patrullas", totalPatrullas);
                chart2.Series.Add(serieRecursos);

                // 🔹 Gráfico Alertas por día
                chart1.Series.Clear();
                Series serieAlertas = new Series("Alertas")
                {
                    ChartType = SeriesChartType.Column,
                    Color = System.Drawing.Color.RoyalBlue
                };

                DataTable alertasPorDia = ObtenerAlertasPorDia(desde, hasta, idComisaria);
                if (alertasPorDia.Rows.Count == 0)
                {
                    serieAlertas.Points.AddXY("Sin datos", 0);
                }
                else
                {
                    foreach (DataRow fila in alertasPorDia.Rows)
                    {
                        DateTime fecha = Convert.ToDateTime(fila["fecha"]);
                        int cantidad = Convert.ToInt32(fila["cantidad"]);
                        serieAlertas.Points.AddXY(fecha.ToString("dd/MM"), cantidad);
                    }
                }

                chart1.Series.Add(serieAlertas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar dashboard: " + ex.Message,
                    "Error general", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ObtenerCantidadPoliciasActivos(int idComisaria)
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    string query = @"
                        SELECT COUNT(*) 
                        FROM Policia 
                        WHERE activo = 1 AND id_comisaria = @idComisaria";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idComisaria", idComisaria);
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al contar policias: " + ex.Message);
                return 0;
            }
        }

        private int ObtenerCantidadPatrullasDisponibles(int idComisaria)
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    string query = @"
                        SELECT COUNT(*) 
                        FROM Patrulla 
                        WHERE activo = 1 AND id_comisaria = @idComisaria";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idComisaria", idComisaria);
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al contar patrullas: " + ex.Message);
                return 0;
            }
        }

        private int ObtenerCantidadAlertasAtendidas(DateTime desde, DateTime hasta, int idComisaria)
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    string query = @"
                        SELECT COUNT(DISTINCT r.id_alerta)
                        FROM Reporte r
                        INNER JOIN Patrulla p ON r.id_patrulla = p.id_patrulla
                        INNER JOIN Llamada l ON l.id_alerta = r.id_alerta
                        WHERE p.id_comisaria = @idComisaria
                          AND l.fecha_creacion BETWEEN @desde AND @hasta";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idComisaria", idComisaria);
                        cmd.Parameters.AddWithValue("@desde", desde);
                        cmd.Parameters.AddWithValue("@hasta", hasta);
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al contar alertas: " + ex.Message);
                return 0;
            }
        }

        private double CalcularEficiencia(int idComisaria)
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    string query = @"
                SELECT 
                    AVG(DATEDIFF(MINUTE, l.fecha_creacion, a.fecha_cierre)) AS minutos_promedio
                FROM Alerta a
                INNER JOIN Llamada l ON a.id_alerta = l.id_alerta
                INNER JOIN Patrulla p ON a.id_patrulla = p.id_patrulla
                WHERE p.id_comisaria = @idComisaria
                  AND a.fecha_cierre IS NOT NULL;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idComisaria", idComisaria);
                        object result = cmd.ExecuteScalar();

                        if (result == null || result == DBNull.Value)
                            return 0;

                        double minutos = Convert.ToDouble(result);
                        double eficiencia = 100 - Math.Min(100, (minutos / 2));
                        return Math.Max(0, eficiencia);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular eficiencia: " + ex.Message);
                return 0;
            }
        }


        private DataTable ObtenerAlertasPorDia(DateTime desde, DateTime hasta, int idComisaria)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    string query = @"
                        SELECT 
                            CAST(l.fecha_creacion AS DATE) AS fecha,
                            COUNT(DISTINCT r.id_alerta) AS cantidad
                        FROM Reporte r
                        INNER JOIN Patrulla p ON r.id_patrulla = p.id_patrulla
                        INNER JOIN Llamada l ON l.id_alerta = r.id_alerta
                        WHERE p.id_comisaria = @idComisaria
                          AND l.fecha_creacion BETWEEN @desde AND @hasta
                        GROUP BY CAST(l.fecha_creacion AS DATE)
                        ORDER BY fecha;";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idComisaria", idComisaria);
                        cmd.Parameters.AddWithValue("@desde", desde);
                        cmd.Parameters.AddWithValue("@hasta", hasta);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt.Load(dr);
                        }
                    }
                }
            }
            catch { }
            return dt;
        }

    }
}
