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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            textBoxDNI.KeyPress += textBoxDNI_KeyPress;
            textBoxContraseña.KeyPress += textBoxContraseña_KeyPress;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        // validacion

        private void textBoxDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Contraseña: podés elegir reglas (ej: letras y números, sin espacios)
        private void textBoxContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Ejemplo: no permitir espacios
            if (char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
