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
                    r.id_reporte,
                    a.fecha_cierre AS FechaReporte,
                    r.id_alerta,
                    r.id_patrulla,
                    p.nro_placa AS NroPlaca,
                    a.tipo_incidencia AS Incidente,
                    a.direccion AS Direccion
                FROM Reporte r
                JOIN Alerta a ON r.id_alerta = a.id_alerta
                JOIN Tiene p ON r.id_planilla = p.id_planilla;";

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
            if (dataGridReportes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un reporte para ver los detalles.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow fila = dataGridReportes.SelectedRows[0];

            // 📦 Extraemos los valores de la fila seleccionada
            string fechaCierre = fila.Cells["FechaCierre"].Value?.ToString() ?? "Sin fecha";
            string ubicacion = fila.Cells["Ubicacion"].Value?.ToString() ?? "Sin ubicación";
            string nroPlaca = fila.Cells["NroPlaca"].Value?.ToString() ?? "Desconocida";
            string incidente = fila.Cells["Incidente"].Value?.ToString() ?? "No especificado";

            // 📄 Generamos el texto automático del reporte
            string textoGenerado = $"En el día de la fecha {fechaCierre}, se registró un incidente de tipo {incidente} en {ubicacion}. " +
                                   $"El hecho fue atendido por la patrulla con número de placa {nroPlaca}.";

            // 🧱 Abrimos el nuevo formulario y le pasamos el texto generado
            FormReporteGenerado frm = new FormReporteGenerado(textoGenerado);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
    }
}

