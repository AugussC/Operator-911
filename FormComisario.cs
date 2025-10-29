using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
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
    public partial class FormComisario : Form
    {
        public FormComisario()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.FormComisario_Load);

        }
        // Cargar el UserControl inicial al cargar el formulario y configurar el PictureBox
        private void FormComisario_Load(object sender, EventArgs e)
        {

            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            LoadUserControl(new UCInicioComisario());

        }
        // Método para cargar un UserControl en el panel
        private void LoadUserControl(UserControl uc)
        {
            panelComisario.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelComisario.Controls.Add(uc);
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCInicioComisario());
        }

        private void btnPatrulla_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCPatrullasComisario());
        }

        private void btnPolicias_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCPoliciasComisario());
        }

        private void btnHorarios_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCPlanilla());
        }
   
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Seguro que desea cerrar sesión?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
