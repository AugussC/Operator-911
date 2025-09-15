using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace Operador_911
{
    public partial class FormJefeOperador : Form
    {
        public FormJefeOperador()
        {
            InitializeComponent();

            // asignar eventos por código (opcional)
            this.btnInicio_supervisor.Click += btnInicio_supervisor_Click;
            this.btnReportes.Click += btnReportes_Click;
            this.btnUsuarios.Click += btnUsuarios_Click;
            

            this.Load += FormJefeOperador_Load; // para mostrar Inicio por defecto al arrancar
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

        private void FormJefeOperador_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            LoadUserControl(new UCInicioSupervisor());
        }

        private void panelNavegacion_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de Backup (*.bak)|*.bak"; // Solo mostrar .bak
            openFileDialog.Title = "Seleccionar archivo de backup";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obtenemos la ruta del archivo seleccionado
                string rutaBackup = openFileDialog.FileName;

                try
                {
                    Database.RestoreBackup(rutaBackup); // Llamamos a tu función
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al restaurar el backup: " + ex.Message);
                }
            }
        }
    }
}
