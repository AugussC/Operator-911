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
    public partial class UCPatrullasComisario : UserControl
    {
        public UCPatrullasComisario()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.FormOperador_Load);

            textNroVehiculo.KeyPress += textNroVehiculo_KeyPress;
        }

        private void FormOperador_Load(object sender, EventArgs e)
        {
            dataGridViewPatrullas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            
        }

        private void textNroVehiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void UCPatrullasComisario_Load(object sender, EventArgs e)
        {

            dataGridViewPatrullas.Rows.Add("V-001", "Auto", "En Servicio");
            dataGridViewPatrullas.Rows.Add("V-002", "Auto", "En Servicio");
            dataGridViewPatrullas.Rows.Add("V-003", "Moto", "En Servicio");
            dataGridViewPatrullas.Rows.Add("V-004", "Auto", "En Base");
            dataGridViewPatrullas.Rows.Add("V-005", "Auto", "En Base");
        }
    }
}
