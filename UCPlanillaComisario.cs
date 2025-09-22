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
            string[] dias = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };
            foreach (string dia in dias)
            {
                dataGridHorarios.Columns.Add(dia, dia);
            }

            dataGridHorarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridHorarios.RowHeadersWidth = 150; 
            dataGridHorarios.AllowUserToAddRows = false;
            dataGridHorarios.AllowUserToResizeRows = false;

            CrearPatrulla("Patrulla 1");
            CrearPatrulla("Patrulla 2");

            // Ejemplo: asignar policías
            dataGridHorarios["Lunes", 1].Value = "GÓMEZ FRANCISCO - ROMERO FRANCO"; 
            dataGridHorarios["Martes", 2].Value = "JUÁREZ LUIS - FERNÁNDEZ PABLO";  
            dataGridHorarios["Lunes", 4].Value = "DÍAZ MARTÍN - SOSA ARIEL";        
        }

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
