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
            this.Load += new System.EventHandler(this.Form1_Load);

            textNroVehiculo.KeyPress += textNroVehiculo_KeyPress;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            
        }

        private void labelTitulo_Usuarios_Click(object sender, EventArgs e)
        {

        }

        private void UCPatrullasComisario_Load(object sender, EventArgs e)
        {

        }


        // validacion
        private void textNroVehiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
