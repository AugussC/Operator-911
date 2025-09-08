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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Form4_Load);

        }

        private void Form4_Load(object sender, EventArgs e)
        {

            
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            LoadUserControl(new UCInicioComisario());

        }
        private void LoadUserControl(UserControl uc)
        {
            // Limpia el contenido del panel
            panelComisario.Controls.Clear();

            // Ajusta el user control al tamaño del panel
            uc.Dock = DockStyle.Fill;

            // Agrega el nuevo user control al panel
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
    }
}
