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
            if (dataGridReportes.CurrentRow != null)
            {
                DataGridViewRow fila = dataGridReportes.CurrentRow;

                // Obtener los valores con los nombres exactos de tu consulta
                string fechaReporte = fila.Cells["FechaReporte"].Value?.ToString() ?? "Sin fecha";
                string incidente = fila.Cells["Incidente"].Value?.ToString() ?? "No especificado";
                string direccion = fila.Cells["Direccion"].Value?.ToString() ?? "Sin dirección";
                string codigoPatrulla = fila.Cells["id_patrulla"].Value?.ToString() ?? "Desconocida";
                string nroPlaca = fila.Cells["NroPlaca"].Value?.ToString() ?? "Sin placa";
                string oficial = "Oficial asignado"; // Si tenés otro campo, después lo reemplazamos
                string comisaria = "Comisaría correspondiente"; // lo mismo
                string descripcion = "Descripción no disponible"; // si la querés después, la agregamos

                // Crear el texto del reporte
                string textoReporte = $@"
                La Policía de Corrientes informa que:

                Siendo el día {fechaReporte}, a través de la línea telefónica de emergencias 911 se recibió un aviso de {incidente} ocurrido en {direccion}.

                De inmediato, se desplegó a la patrulla {codigoPatrulla}, de número de placa {nroPlaca}, para acudir a la emergencia.

                Una vez normalizada la situación, el oficial a cargo constató:
                {descripcion}

                El caso fue remitido a la {comisaria}, donde se dará continuidad a la investigación y se determinarán las respectivas responsabilidades conforme a la ley.

                {fechaReporte}
                ";

                // Mostrar el formulario
                FormReporteGenerado verReporte = new FormReporteGenerado(textoReporte);
                verReporte.StartPosition = FormStartPosition.CenterParent;
                verReporte.textReporte.Text = textoReporte; // 👈 asegurate que txtReporte sea público o tenga un setter
                verReporte.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, seleccioná un reporte de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}

