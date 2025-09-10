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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            // asignar eventos por código (opcional)
            this.btnInicio_supervisor.Click += btnInicio_supervisor_Click;
            this.btnReportes.Click += btnReportes_Click;
            this.btnUsuarios.Click += btnUsuarios_Click;

            this.Load += Form2_Load; // para mostrar Inicio por defecto al arrancar
        }

        private void LoadUserControl(UserControl uc)
        {
            panel_supervisor.Controls.Clear();   // borra lo que haya antes
            uc.Dock = DockStyle.Fill;            // que ocupe todo el panel
            panel_supervisor.Controls.Add(uc);   // lo agrega al panel
        }

        private void btnInicio_supervisor_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCInicioSupervisor());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCPlanillaSupervisor());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCListaUsuarios());
        }

        private void panelNavegacion_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void panelNavegacion_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
