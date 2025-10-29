using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            CargarDatosEjemplo();
        }

        private void UCResportesSupervisor_Load(object sender, EventArgs e)
        {
            dataGridReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnVerReporte_Click(object sender, EventArgs e)
        {
            FormReporteGenerado VerReporte = new FormReporteGenerado();
            VerReporte.StartPosition = FormStartPosition.CenterParent;
            VerReporte.ShowDialog(); // 👈 Esto la abre como modal
        }
        

        private void CargarDatosEjemplo()
        {
            // Limpiar filas existentes
            dataGridReportes.Rows.Clear();

            // Agregar primera fila de ejemplo
            dataGridReportes.Rows.Add(
                1,                      // ID_Reporte
                DateTime.Now.ToString("dd/MM/yyyy HH:mm"),  // Fecha Inicio
                DateTime.Now.AddHours(1).ToString("dd/MM/yyyy HH:mm"), // Fecha Fin
                101,                    // ID_Alerta
                1,                      // ID_Patrulla
                "Calle Falsa 123",      // Dirección
                "Juan Pérez",           // Nombre
                "Robo de vehículo"      // Descripción
            );

            // Agregar segunda fila de ejemplo
            dataGridReportes.Rows.Add(
                2,
                DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                DateTime.Now.AddMinutes(45).ToString("dd/MM/yyyy HH:mm"),
                102,
                2,
                "Avenida Siempre Viva 742",
                "María López",
                "Incendio en comercio"
            );
        }
    }
}

