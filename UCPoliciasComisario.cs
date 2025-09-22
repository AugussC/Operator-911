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

            this.Load += new System.EventHandler(this.FormOperador_Load);

            textBoxNombre.KeyPress += textBoxNombre_KeyPress;
            textBoxApellido.KeyPress += textBoxApellido_KeyPress;
            textBoxDNI.KeyPress += textBoxDNI_KeyPress;
            textBoxNroPlaca.KeyPress += textBoxNroPlaca_KeyPress;
            textBoxTelefono.KeyPress += textBoxTelefono_KeyPress;
        }

        private void FormOperador_Load(object sender, EventArgs e)
        {
            // Ajusta automáticamente el ancho de las columnas al tamaño del DataGridView
            dataGridViewPolicias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

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

        private void UCPoliciasComisario_Load(object sender, EventArgs e)
        {
            dataGridViewPolicias.Rows.Add("12345", "González", "Juan", "30111222", "3795031245");
            dataGridViewPolicias.Rows.Add("23456", "Pérez", "María", "28999888", "3794102412");
            dataGridViewPolicias.Rows.Add("34567", "Ramírez", "Carlos", "31222333","3795041586");
            dataGridViewPolicias.Rows.Add("45678", "López", "Ana", "30123456", "3794986721");
        }
    }
}
