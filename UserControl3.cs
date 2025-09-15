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
    public partial class UCPoliciasComisario : UserControl
    {
        public UCPoliciasComisario()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Form1_Load);

            textBoxNombre.KeyPress += textBoxNombre_KeyPress;
            textBoxApellido.KeyPress += textBoxApellido_KeyPress;
            textBoxDNI.KeyPress += textBoxDNI_KeyPress;
            textBoxNroPlaca.KeyPress += textBoxNroPlaca_KeyPress;
            textBoxTelefono.KeyPress += textBoxTelefono_KeyPress;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

        private void UCPoliciasComisario_Load(object sender, EventArgs e)
        {

        }

        // validacion

        private void textBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxNroPlaca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxNroPlaca_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
