namespace Operador_911
{
    partial class Form3
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
            this.btnInicioSesion = new System.Windows.Forms.Button();
            this.labelCorreo = new System.Windows.Forms.Label();
            this.labelContraseña = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxContraseña = new System.Windows.Forms.TextBox();
            this.textBoxCorreo = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxContraseña = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInicioSesion
            // 
            this.btnInicioSesion.Location = new System.Drawing.Point(135, 279);
            this.btnInicioSesion.Name = "btnInicioSesion";
            this.btnInicioSesion.Size = new System.Drawing.Size(134, 42);
            this.btnInicioSesion.TabIndex = 0;
            this.btnInicioSesion.Text = "Iniciar Sesion";
            this.btnInicioSesion.UseVisualStyleBackColor = true;
            this.btnInicioSesion.Click += new System.EventHandler(this.btnInicioSesion_Click);
            // 
            // labelCorreo
            // 
            this.labelCorreo.AutoSize = true;
            this.labelCorreo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelCorreo.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCorreo.Location = new System.Drawing.Point(57, 67);
            this.labelCorreo.Name = "labelCorreo";
            this.labelCorreo.Size = new System.Drawing.Size(86, 32);
            this.labelCorreo.TabIndex = 1;
            this.labelCorreo.Text = "Correo";
            this.labelCorreo.Click += new System.EventHandler(this.labelCorreo_Click);
            // 
            // labelContraseña
            // 
            this.labelContraseña.AutoSize = true;
            this.labelContraseña.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelContraseña.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContraseña.Location = new System.Drawing.Point(57, 152);
            this.labelContraseña.Name = "labelContraseña";
            this.labelContraseña.Size = new System.Drawing.Size(134, 32);
            this.labelContraseña.TabIndex = 2;
            this.labelContraseña.Text = "Contraseña";
            this.labelContraseña.Click += new System.EventHandler(this.labelContraseña_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(488, 434);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(378, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ministerio de Seguridad de la provincia de Corrientes";
            // 
            // textBoxContraseña
            // 
            this.textBoxContraseña.Location = new System.Drawing.Point(48, 187);
            this.textBoxContraseña.Name = "textBoxContraseña";
            this.textBoxContraseña.Size = new System.Drawing.Size(305, 26);
            this.textBoxContraseña.TabIndex = 5;
            this.textBoxContraseña.UseSystemPasswordChar = true;
            this.textBoxContraseña.TextChanged += new System.EventHandler(this.textBoxContraseña_TextChanged);
            // 
            // textBoxCorreo
            // 
            this.textBoxCorreo.Location = new System.Drawing.Point(48, 102);
            this.textBoxCorreo.Name = "textBoxCorreo";
            this.textBoxCorreo.Size = new System.Drawing.Size(305, 26);
            this.textBoxCorreo.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Operador_911.Properties.Resources._4fTAsWOK_400x400__1___1_;
            this.pictureBox1.Location = new System.Drawing.Point(510, 81);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(344, 348);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.checkBoxContraseña);
            this.panel1.Controls.Add(this.textBoxCorreo);
            this.panel1.Controls.Add(this.textBoxContraseña);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnInicioSesion);
            this.panel1.Controls.Add(this.labelContraseña);
            this.panel1.Controls.Add(this.labelCorreo);
            this.panel1.Location = new System.Drawing.Point(46, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 340);
            this.panel1.TabIndex = 10;
            // 
            // checkBoxContraseña
            // 
            this.checkBoxContraseña.AutoSize = true;
            this.checkBoxContraseña.Location = new System.Drawing.Point(63, 234);
            this.checkBoxContraseña.Name = "checkBoxContraseña";
            this.checkBoxContraseña.Size = new System.Drawing.Size(176, 24);
            this.checkBoxContraseña.TabIndex = 11;
            this.checkBoxContraseña.Text = "Mostrar Contraseña";
            this.checkBoxContraseña.UseVisualStyleBackColor = true;
            this.checkBoxContraseña.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Font = new System.Drawing.Font("Segoe UI Symbol", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(43, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(310, 28);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ingrese sus Credenciales de Sesion";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(892, 525);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInicioSesion;
        private System.Windows.Forms.Label labelCorreo;
        private System.Windows.Forms.Label labelContraseña;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxContraseña;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxCorreo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxContraseña;
    }
}