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
            this.panelNavegacion = new System.Windows.Forms.Panel();
            this.tituloPrograma = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHorarios = new System.Windows.Forms.Button();
            this.btnPolicias = new System.Windows.Forms.Button();
            this.btnPatrulla = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.panelComisario = new System.Windows.Forms.Panel();
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
            this.panelNavegacion.Size = new System.Drawing.Size(2040, 68);
            this.panelNavegacion.TabIndex = 2;
            // 
            // tituloPrograma
            // 
            this.tituloPrograma.AutoSize = true;
            this.tituloPrograma.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloPrograma.Location = new System.Drawing.Point(138, 26);
            this.tituloPrograma.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tituloPrograma.Name = "tituloPrograma";
            this.tituloPrograma.Size = new System.Drawing.Size(119, 22);
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
            this.panel1.Controls.Add(this.btnHorarios);
            this.panel1.Controls.Add(this.btnPolicias);
            this.panel1.Controls.Add(this.btnPatrulla);
            this.panel1.Controls.Add(this.btnInicio);
            this.panel1.Location = new System.Drawing.Point(0, 68);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 1075);
            this.panel1.TabIndex = 3;
            // 
            // btnHorarios
            // 
            this.btnHorarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHorarios.Location = new System.Drawing.Point(20, 446);
            this.btnHorarios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHorarios.Name = "btnHorarios";
            this.btnHorarios.Size = new System.Drawing.Size(226, 77);
            this.btnHorarios.TabIndex = 3;
            this.btnHorarios.Text = "Planilla Horarios";
            this.btnHorarios.UseVisualStyleBackColor = true;
            this.btnHorarios.Click += new System.EventHandler(this.btnHorarios_Click);
            // 
            // btnPolicias
            // 
            this.btnPolicias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPolicias.Location = new System.Drawing.Point(20, 311);
            this.btnPolicias.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPolicias.Name = "btnPolicias";
            this.btnPolicias.Size = new System.Drawing.Size(226, 77);
            this.btnPolicias.TabIndex = 2;
            this.btnPolicias.Text = "Policias";
            this.btnPolicias.UseVisualStyleBackColor = true;
            this.btnPolicias.Click += new System.EventHandler(this.btnPolicias_Click);
            // 
            // btnPatrulla
            // 
            this.btnPatrulla.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPatrulla.Location = new System.Drawing.Point(20, 175);
            this.btnPatrulla.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPatrulla.Name = "btnPatrulla";
            this.btnPatrulla.Size = new System.Drawing.Size(226, 77);
            this.btnPatrulla.TabIndex = 1;
            this.btnPatrulla.Text = "Patrulla";
            this.btnPatrulla.UseVisualStyleBackColor = true;
            this.btnPatrulla.Click += new System.EventHandler(this.btnPatrulla_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.Location = new System.Drawing.Point(20, 58);
            this.btnInicio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(226, 77);
            this.btnInicio.TabIndex = 0;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // panelComisario
            // 
            this.panelComisario.Location = new System.Drawing.Point(254, 51);
            this.panelComisario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelComisario.Name = "panelComisario";
            this.panelComisario.Size = new System.Drawing.Size(1786, 1087);
            this.panelComisario.TabIndex = 4;
            this.panelComisario.Paint += new System.Windows.Forms.PaintEventHandler(this.panelComisario_Paint);
            // 
            // FormComisario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2025, 1122);
            this.Controls.Add(this.panelNavegacion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelComisario);
            this.Name = "FormComisario";
            this.Text = "FormComisario";
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
        private System.Windows.Forms.Button btnPatrulla;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Panel panelComisario;
        private System.Windows.Forms.Button btnHorarios;
        private System.Windows.Forms.Button btnPolicias;
    }
}