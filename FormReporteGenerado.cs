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
    public partial class FormReporteGenerado : Form
    {
        public FormReporteGenerado(string textoReporte)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            textReporte.Text = textoReporte;
        }

        private void labelTituloReporte_Click(object sender, EventArgs e)
        {

        }

        private void FormReporteGenerado_Load(object sender, EventArgs e)
        {

        }

        private void labelPrimeraParte_Click(object sender, EventArgs e)
        {

        }

        private void labelFecha_Click(object sender, EventArgs e)
        {

        }
    }
}
