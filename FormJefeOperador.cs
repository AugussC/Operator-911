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
            DialogResult confirm = MessageBox.Show(
                "¿Está seguro que quiere cargar una copia de seguridad?\n\n⚠️ Se pisarán los datos actuales.",
                "Confirmar restauración",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Archivos de Backup (*.bak)|*.bak"; // Solo mostrar .bak
                openFileDialog.Title = "Seleccionar archivo de backup";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaBackup = openFileDialog.FileName;

                    try
                    {
                        Database.RestoreBackup(rutaBackup); // Restaurar backup
                        MessageBox.Show("Backup restaurado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUserControl(new UCInicioSupervisor());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al restaurar el backup: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "¿Está seguro que quiere crear una copia de seguridad?",
                "Confirmar copia de seguridad",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                string fechaHora = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string ruta = $@"C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\Backup\Operador911_{fechaHora}.bak";

                try
                {
                    Database.HacerBackup(ruta); // Crear backup
                    MessageBox.Show("Copia de seguridad creada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear el backup: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

