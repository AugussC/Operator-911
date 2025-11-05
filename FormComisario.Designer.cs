namespace Operador_911
{
    partial class FormComisario
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
        
        
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelComisario = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHorarios = new System.Windows.Forms.Button();
            this.btnPolicias = new System.Windows.Forms.Button();
            this.btnPatrulla = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.panelNavegacion = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panelNavegacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelComisario
            // 
            this.panelComisario.Location = new System.Drawing.Point(169, 33);
            this.panelComisario.Name = "panelComisario";
            this.panelComisario.Size = new System.Drawing.Size(1191, 707);
            this.panelComisario.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnHorarios);
            this.panel1.Controls.Add(this.btnPolicias);
            this.panel1.Controls.Add(this.btnPatrulla);
            this.panel1.Controls.Add(this.btnInicio);
            this.panel1.Location = new System.Drawing.Point(0, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(181, 699);
            this.panel1.TabIndex = 3;
            // 
            // btnHorarios
            // 
            this.btnHorarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHorarios.Location = new System.Drawing.Point(13, 267);
            this.btnHorarios.Name = "btnHorarios";
            this.btnHorarios.Size = new System.Drawing.Size(151, 50);
            this.btnHorarios.TabIndex = 3;
            this.btnHorarios.Text = "Planilla Horarios";
            this.btnHorarios.UseVisualStyleBackColor = true;
            this.btnHorarios.Click += new System.EventHandler(this.btnHorarios_Click);
            // 
            // btnPolicias
            // 
            this.btnPolicias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPolicias.Location = new System.Drawing.Point(13, 191);
            this.btnPolicias.Name = "btnPolicias";
            this.btnPolicias.Size = new System.Drawing.Size(151, 50);
            this.btnPolicias.TabIndex = 2;
            this.btnPolicias.Text = "Policias";
            this.btnPolicias.UseVisualStyleBackColor = true;
            this.btnPolicias.Click += new System.EventHandler(this.btnPolicias_Click);
            // 
            // btnPatrulla
            // 
            this.btnPatrulla.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPatrulla.Location = new System.Drawing.Point(13, 112);
            this.btnPatrulla.Name = "btnPatrulla";
            this.btnPatrulla.Size = new System.Drawing.Size(151, 50);
            this.btnPatrulla.TabIndex = 1;
            this.btnPatrulla.Text = "Patrulla";
            this.btnPatrulla.UseVisualStyleBackColor = true;
            this.btnPatrulla.Click += new System.EventHandler(this.btnPatrulla_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.Location = new System.Drawing.Point(13, 36);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(151, 50);
            this.btnInicio.TabIndex = 0;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // panelNavegacion
            // 
            this.panelNavegacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panelNavegacion.Controls.Add(this.label1);
            this.panelNavegacion.Controls.Add(this.pictureBox2);
            this.panelNavegacion.Controls.Add(this.btnCerrarSesion);
            this.panelNavegacion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelNavegacion.Location = new System.Drawing.Point(0, 0);
            this.panelNavegacion.Name = "panelNavegacion";
            this.panelNavegacion.Size = new System.Drawing.Size(1360, 44);
            this.panelNavegacion.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(92, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "911 Operador";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Operador_911.Properties.Resources._4fTAsWOK_400x400__1___1_;
            this.pictureBox2.Location = new System.Drawing.Point(13, -1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(73, 52);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCerrarSesion.Location = new System.Drawing.Point(1216, 8);
            this.btnCerrarSesion.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(109, 27);
            this.btnCerrarSesion.TabIndex = 2;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // FormComisario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 487);
            this.Controls.Add(this.panelNavegacion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelComisario);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormComisario";
            this.Text = "FormComisario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormComisario_Load);
            this.panel1.ResumeLayout(false);
            this.panelNavegacion.ResumeLayout(false);
            this.panelNavegacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelNavegacion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPatrulla;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Panel panelComisario;
        private System.Windows.Forms.Button btnHorarios;
        private System.Windows.Forms.Button btnPolicias;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}