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
                            t.nro_placa AS [Nro Placa],
                            r.descripcion AS Descripcion,
                            c.nombre AS Comisaria
                        FROM Reporte r
                        JOIN Alerta a ON r.id_alerta = a.id_alerta
                        JOIN Llamada l ON a.id_alerta = l.id_alerta
                        JOIN Tiene t ON r.id_planilla = t.id_planilla
                        JOIN Patrulla p ON r.id_patrulla = p.id_patrulla
                        JOIN Comisaria c ON p.id_comisaria = c.id_comisaria;";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridReportes.DataSource = dt;
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
                string nroPlaca = fila.Cells["Nro Placa"].Value?.ToString() ?? "Sin placa";
                string comisaria = fila.Cells["Comisaria"].Value?.ToString() ?? "Comisaría no definida";
                string descripcion = fila.Cells["Descripcion"].Value?.ToString() ?? "Descripción no disponible";
                string fechaLlamada = fila.Cells["Fecha Llamada"].Value?.ToString() ?? "Sin fecha";
                string numeroReporte = fila.Cells["Numero Reporte"].Value?.ToString() ?? "Desconocido";    

                // Crear el texto del reporte
                string textoReporte = $@"
La Policía de Corrientes informa que: {Environment.NewLine} Siendo el día {fechaLlamada}, a través de la línea telefónica de emergencias 911, se recibió un aviso de {incidente} ocurrido en {direccion}.

De inmediato, se desplegó a la patrulla {codigoPatrulla}, de número de placa {nroPlaca}, para acudir a la emergencia.

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


    }
}

