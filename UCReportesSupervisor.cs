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
                    string query = "SELECT * FROM Reporte"; // o el nombre real de tu tabla
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
            FormReporteGenerado VerReporte = new FormReporteGenerado();
            VerReporte.StartPosition = FormStartPosition.CenterParent;
            VerReporte.ShowDialog(); // 👈 Esto la abre como modal
        }
    }
}

