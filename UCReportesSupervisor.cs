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

namespace Operador_911
{
    public partial class UCReportesSupervisor : UserControl
    {
        public UCReportesSupervisor()
        {
            InitializeComponent();
            CargarReportes();
        }

        private void UCResportesSupervisor_Load(object sender, EventArgs e)
        {
            dataGridReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarReportes()
        {
            try
            {

                btnVerReporte.Enabled = true;

                using (SqlConnection con = Database.GetConnection())
                {
                    string query = @"
                    SELECT 
                        r.id_reporte AS [Numero Reporte],
                        l.fecha_creacion AS [Fecha Llamada],
                        a.fecha_cierre AS [Fecha Reporte],
                        a.tipo_incidencia AS Incidente,
                        a.direccion AS Direccion,
                        p.codigo_patrulla AS [Codigo Patrulla],
                
                        STRING_AGG(CONCAT(pol.nombre, ' ', pol.apellido, ' (Placa: ', pol.nro_placa, ')'), ', ') 
                            WITHIN GROUP (ORDER BY pol.apellido) AS Policias,
                
                        r.descripcion AS Descripcion,
                        c.nombre AS Comisaria
                    FROM Reporte r
                    JOIN Alerta a ON r.id_alerta = a.id_alerta
                    JOIN Llamada l ON a.id_alerta = l.id_alerta
                    JOIN Tiene t ON r.id_planilla = t.id_planilla
                    JOIN Policia pol ON t.nro_placa = pol.nro_placa
                    JOIN Patrulla p ON r.id_patrulla = p.id_patrulla
                    JOIN Comisaria c ON p.id_comisaria = c.id_comisaria
                    GROUP BY 
                        r.id_reporte, l.fecha_creacion, a.fecha_cierre, a.tipo_incidencia,
                        a.direccion, p.codigo_patrulla, r.descripcion, c.nombre;";


                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridReportes.DataSource = dt;
                    dataGridReportes.Columns["Descripcion"].Visible = false;
                    dataGridReportes.Columns["Policias"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reportes: " + ex.Message);
            }
        }

        private void btnVerReporte_Click(object sender, EventArgs e)
        {
            if (dataGridReportes.CurrentRow != null)
            {
                DataGridViewRow fila = dataGridReportes.CurrentRow;

                // Obtener los valores con los nombres exactos de tu consulta
                string fechaReporte = fila.Cells["Fecha Reporte"].Value?.ToString() ?? "Sin fecha";
                string incidente = fila.Cells["Incidente"].Value?.ToString() ?? "No especificado";
                string direccion = fila.Cells["Direccion"].Value?.ToString() ?? "Sin dirección";
                string codigoPatrulla = fila.Cells["Codigo Patrulla"].Value?.ToString() ?? "Desconocida";
                string policias = fila.Cells["Policias"].Value?.ToString() ?? "Sin personal asignado";
                string comisaria = fila.Cells["Comisaria"].Value?.ToString() ?? "Comisaría no definida";
                string descripcion = fila.Cells["Descripcion"].Value?.ToString() ?? "Descripción no disponible";
                string fechaLlamada = fila.Cells["Fecha Llamada"].Value?.ToString() ?? "Sin fecha";
                string numeroReporte = fila.Cells["Numero Reporte"].Value?.ToString() ?? "Desconocido";
                string nroPlaca = dataGridReportes.Columns.Contains("Nro Placa") ? fila.Cells["Nro Placa"].Value?.ToString() : "Sin placa";

                // Crear el texto del reporte
                string textoReporte = $@"
La Policía de Corrientes informa que: {Environment.NewLine} Siendo el día {fechaLlamada}, a través de la línea telefónica de emergencias 911, se recibió un aviso de {incidente} ocurrido en {direccion}.

De inmediato, se desplegó a la patrulla {codigoPatrulla}, a cargo del/la policia: {policias}, para acudir a la emergencia.

Una vez normalizada la situación, el oficial a cargo constató: {Environment.NewLine} {descripcion}

El caso fue remitido a la {comisaria}, donde se dará continuidad a la investigación y se determinarán las respectivas responsabilidades conforme a la ley.
                ";
                
                string FechaReporte = $@"{fechaReporte}";


                string NumeroReporte = $@"{numeroReporte}";

                // Mostrar el formulario
                FormReporteGenerado verReporte = new FormReporteGenerado(textoReporte, FechaReporte, NumeroReporte);
                verReporte.StartPosition = FormStartPosition.CenterParent;
                verReporte.textReporte.Text = textoReporte; // 👈 asegurate que txtReporte sea público o tenga un setter
                verReporte.textFecha.Text = FechaReporte;
                verReporte.textNumeroReporte.Text = NumeroReporte;
                verReporte.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, seleccioná un reporte de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = Database.GetConnection())
                {
                    string query = @"
                    SELECT 
                        r.id_reporte AS [Numero Reporte],
                        l.fecha_creacion AS [Fecha Llamada],
                        a.fecha_cierre AS [Fecha Reporte],
                        a.tipo_incidencia AS Incidente,
                        a.direccion AS Direccion,
                        p.codigo_patrulla AS [Codigo Patrulla],
                        STRING_AGG(CONCAT(pol.nombre, ' ', pol.apellido, ' (Placa: ', pol.nro_placa, ')'), ', ') 
                            WITHIN GROUP (ORDER BY pol.apellido) AS Policias,
                        r.descripcion AS Descripcion,
                        c.nombre AS Comisaria
                    FROM Reporte r
                    JOIN Alerta a ON r.id_alerta = a.id_alerta
                    JOIN Llamada l ON a.id_alerta = l.id_alerta
                    JOIN Tiene t ON r.id_planilla = t.id_planilla
                    JOIN Policia pol ON t.nro_placa = pol.nro_placa
                    JOIN Patrulla p ON r.id_patrulla = p.id_patrulla
                    JOIN Comisaria c ON p.id_comisaria = c.id_comisaria
                    WHERE l.fecha_creacion BETWEEN @desde AND @hasta
                    GROUP BY 
                        r.id_reporte, l.fecha_creacion, a.fecha_cierre, a.tipo_incidencia,
                        a.direccion, p.codigo_patrulla, r.descripcion, c.nombre;";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@desde", dtpDesde.Value.Date);
                    cmd.Parameters.AddWithValue("@hasta", dtpHasta.Value.Date.AddDays(1).AddSeconds(-1));

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridReportes.DataSource = dt;

                    // Ocultar columna Descripción
                    if (dataGridReportes.Columns.Contains("Descripcion"))
                        dataGridReportes.Columns["Descripcion"].Visible = false;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron reportes entre las fechas seleccionadas.",
                                        "Sin resultados",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar reportes: " + ex.Message);
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            try
            {
                // Reiniciar los DateTimePicker a la fecha actual o a un valor predeterminado
                dtpDesde.Value = DateTime.Now.AddDays(-7); // por ejemplo, hace 7 días
                dtpHasta.Value = DateTime.Now;

                // Volver a cargar todos los reportes (sin filtros)
                CargarReportes();

                MessageBox.Show("Filtros reiniciados correctamente.", "Reinicio",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al reiniciar filtros: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAlertas_Reportes_Click(object sender, EventArgs e)
        {
            if (btnAlertas_Reportes.Text == "Ver Alertas sin Atender")
            {
                CargarAlertasPendientes();
                btnAlertas_Reportes.Text = "Ver Reportes";
            }
            else
            {
                CargarReportes();
                btnAlertas_Reportes.Text = "Ver Alertas sin Atender";
            }
        }

        private void CargarAlertasPendientes()
        {
            try
            {

                btnVerReporte.Enabled = false;

                using (SqlConnection con = Database.GetConnection())
                {
                    string query = @"
                SELECT 
                    a.id_alerta AS [ID Alerta],
                    a.estado AS Estado,
                    a.tipo_incidencia AS Incidente,
                    a.importancia AS Importancia,
                    a.direccion AS Dirección,
                    ISNULL(p.codigo_patrulla, 'Sin asignar') AS [Patrulla Asignada]
                FROM Alerta a
                LEFT JOIN Patrulla p ON a.id_patrulla = p.id_patrulla
                WHERE a.estado IN ('En Espera', 'Asignada');";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridReportes.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No hay alertas pendientes o asignadas actualmente.",
                                        "Sin resultados",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar alertas pendientes: " + ex.Message);
            }
        }

    }
}

