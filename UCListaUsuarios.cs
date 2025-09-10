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
    public partial class UCListaUsuarios : UserControl
    {
        public UCListaUsuarios()
        {
            InitializeComponent();

            textBoxNombre.KeyPress += textBoxNombre_KeyPress;
            textBoxApellido.KeyPress += textBoxApellido_KeyPress;
            textBoxDNI.KeyPress += textBoxDNI_KeyPress;
            textBoxContraseña.KeyPress += textBoxContraseña_KeyPress;
        }

        private void labelTitulo_Click(object sender, EventArgs e)
        {

        }

        private void labelCodigo_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UCListaUsuarios_Load(object sender, EventArgs e)
        {

        }



        // validacion

        // Nombre: solo letras y espacio
        private void textBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Apellido: igual que nombre
        private void textBoxApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // DNI: solo números
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
