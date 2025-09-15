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
    public partial class UCPlanilla : UserControl
    {
        public UCPlanilla()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.FormOperador_Load);
        }

        private void FormOperador_Load(object sender, EventArgs e)
        {
            // Crear columnas (días de la semana)
            string[] dias = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };
            foreach (string dia in dias)
            {
                dataGridHorarios.Columns.Add(dia, dia);
            }

            // Ajustar columnas para ocupar todo el ancho
            dataGridHorarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Estilo general
            dataGridHorarios.RowHeadersWidth = 150; // ancho del encabezado de fila
            dataGridHorarios.AllowUserToAddRows = false;
            dataGridHorarios.AllowUserToResizeRows = false;

            // Crear tabla con patrullas y turnos
            CrearPatrulla("Patrulla 1");
            CrearPatrulla("Patrulla 2");

            // Ejemplo: asignar policías
            dataGridHorarios["Lunes", 1].Value = "GÓMEZ FRANCISCO - ROMERO FRANCO"; // Patrulla 1 - 06/18
            dataGridHorarios["Martes", 2].Value = "JUÁREZ LUIS - FERNÁNDEZ PABLO";  // Patrulla 1 - 18/06
            dataGridHorarios["Lunes", 4].Value = "DÍAZ MARTÍN - SOSA ARIEL";        // Patrulla 2 - 06/18
        }

        // Método para agregar fila de patrulla + sus turnos
        private void CrearPatrulla(string nombrePatrulla)
        {
            // Fila de título (solo muestra el nombre de la patrulla)
            int filaTitulo = dataGridHorarios.Rows.Add();
            dataGridHorarios.Rows[filaTitulo].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridHorarios.Rows[filaTitulo].DefaultCellStyle.Font = new Font(dataGridHorarios.Font, FontStyle.Bold);
            dataGridHorarios.Rows[filaTitulo].Cells[0].Value = nombrePatrulla;
            dataGridHorarios.Rows[filaTitulo].ReadOnly = true;

            // Turno 06-18
            int filaTurno1 = dataGridHorarios.Rows.Add();
            dataGridHorarios.Rows[filaTurno1].HeaderCell.Value = "06-18";

            // Turno 18-06
            int filaTurno2 = dataGridHorarios.Rows.Add();
            dataGridHorarios.Rows[filaTurno2].HeaderCell.Value = "18-06";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void UCPlanilla_Load(object sender, EventArgs e)
        {

        }

        private void DiaBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
 }
