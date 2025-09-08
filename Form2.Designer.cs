using System;
using System.Windows.Forms;

namespace Operador_911
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void LoadUserControl(UserControl uc)
        {
            panel_supervisor.Controls.Clear();  // Limpia el panel
            uc.Dock = DockStyle.Fill;           // Hace que el control ocupe todo el panel
            panel_supervisor.Controls.Add(uc);  // Lo agrega dentro del panel
        }

        private void btninicio_supervisor(object sender, EventArgs e)
        {
            LoadUserControl(new UCInicioSupervisor());
        }

        private void btnAlerta_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCPlanillaSupervisor());
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelNavegacion = new System.Windows.Forms.Panel();
            this.tituloPrograma = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnInicio_supervisor = new System.Windows.Forms.Button();
            this.panel_supervisor = new System.Windows.Forms.Panel();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.panelNavegacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelNavegacion
            // 
            this.panelNavegacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panelNavegacion.Controls.Add(this.tituloPrograma);
            this.panelNavegacion.Controls.Add(this.pictureBox1);
            this.panelNavegacion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelNavegacion.Location = new System.Drawing.Point(0, 0);
            this.panelNavegacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelNavegacion.Name = "panelNavegacion";
            this.panelNavegacion.Size = new System.Drawing.Size(2044, 68);
            this.panelNavegacion.TabIndex = 3;
            // 
            // tituloPrograma
            // 
            this.tituloPrograma.AutoSize = true;
            this.tituloPrograma.Location = new System.Drawing.Point(138, 26);
            this.tituloPrograma.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tituloPrograma.Name = "tituloPrograma";
            this.tituloPrograma.Size = new System.Drawing.Size(107, 20);
            this.tituloPrograma.TabIndex = 1;
            this.tituloPrograma.Text = "911 Operador";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Operador_911.Properties.Resources._4fTAsWOK_400x400__1___1_;
            this.pictureBox1.Location = new System.Drawing.Point(20, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 80);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnUsuarios);
            this.panel1.Controls.Add(this.btnReportes);
            this.panel1.Controls.Add(this.btnInicio_supervisor);
            this.panel1.Location = new System.Drawing.Point(0, 68);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 1075);
            this.panel1.TabIndex = 4;
            // 
            // btnReportes
            // 
            this.btnReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.Location = new System.Drawing.Point(20, 175);
            this.btnReportes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(226, 77);
            this.btnReportes.TabIndex = 1;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = true;
            // 
            // btnInicio_supervisor
            // 
            this.btnInicio_supervisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio_supervisor.Location = new System.Drawing.Point(20, 58);
            this.btnInicio_supervisor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInicio_supervisor.Name = "btnInicio_supervisor";
            this.btnInicio_supervisor.Size = new System.Drawing.Size(226, 77);
            this.btnInicio_supervisor.TabIndex = 0;
            this.btnInicio_supervisor.Text = "Inicio/Estadisticas";
            this.btnInicio_supervisor.UseVisualStyleBackColor = true;
            // 
            // panel_supervisor
            // 
            this.panel_supervisor.Location = new System.Drawing.Point(279, 68);
            this.panel_supervisor.Name = "panel_supervisor";
            this.panel_supervisor.Size = new System.Drawing.Size(1748, 1052);
            this.panel_supervisor.TabIndex = 5;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.Location = new System.Drawing.Point(20, 290);
            this.btnUsuarios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(226, 77);
            this.btnUsuarios.TabIndex = 2;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2025, 1122);
            this.Controls.Add(this.panel_supervisor);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelNavegacion);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form2";
            this.Text = "Form2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelNavegacion.ResumeLayout(false);
            this.panelNavegacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelNavegacion;
        private System.Windows.Forms.Label tituloPrograma;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnInicio_supervisor;
        private System.Windows.Forms.Panel panel_supervisor;
        private Button btnUsuarios;
    }
}