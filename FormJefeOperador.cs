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
            this.Load += FormJefeOperador_Load;
        }

        // Método para cargar UserControls en el panel
        private void LoadUserControl(UserControl uc)
        {
            panel_supervisor.Controls.Clear();   
            uc.Dock = DockStyle.Fill;            
            panel_supervisor.Controls.Add(uc);  

        }

        private void btnInicio_supervisor_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCInicioSupervisor());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCReportesSupervisor());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCUsuariosSupervisor());
        }

        //agranda la pantalla y pone el usercontrol por defecto
        private void FormJefeOperador_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            LoadUserControl(new UCInicioSupervisor());
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
                    Database.RestoreBackup(rutaBackup); // Restaurar backup
                    MessageBox.Show("Backup restaurado correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al restaurar el backup: " + ex.Message);
                }
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string fechaHora = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string ruta = $@"C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\Backup\Operador911_{fechaHora}.bak";
            try
            {
                Database.HacerBackup(ruta); // Crear backup
                MessageBox.Show("Copia de seguridad creada con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el backup: " + ex.Message);
            }
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

