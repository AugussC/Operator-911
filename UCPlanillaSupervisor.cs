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
    public partial class UCPlanillaSupervisor : UserControl
    {
        public UCPlanillaSupervisor()
        {
            InitializeComponent();
        }

        private void labelTitulo_Click(object sender, EventArgs e)
        {

        }

        private void UCPlanillaSupervisor_Load(object sender, EventArgs e)
        {

        }

        private void dataGridReportes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
