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
            pictureBoxReporte.Visible = false;
            btnOcultarReporte.Visible = false;

        }

        private void labelTitulo_Click(object sender, EventArgs e)
        {

        }

        private void UCPlanillaSupervisor_Load(object sender, EventArgs e)
        {
            dataGridReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridReportes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       
        }

        private void btnVerReporte_Click(object sender, EventArgs e)
        {
            pictureBoxReporte.Visible = true;
            pictureBoxReporte.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxReporte.BringToFront();
            btnOcultarReporte.Visible = true;
        }

        private void btnOcultarReporte_Click(object sender, EventArgs e)
        {
            pictureBoxReporte.Visible = false;
            btnOcultarReporte.Visible = false;
        }
    }
}

