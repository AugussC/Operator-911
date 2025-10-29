using System;

namespace Operador_911
{
    partial class FormReporte
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.textBoxIncidente = new System.Windows.Forms.TextBox();
            this.textBoxDireccion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.labelTitulo_Reporte = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.labelDireccion = new System.Windows.Forms.Label();
            this.labelPolicia = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.textBoxDescripcion);
            this.panel2.Controls.Add(this.textBoxIncidente);
            this.panel2.Controls.Add(this.textBoxDireccion);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Controls.Add(this.labelTitulo_Reporte);
            this.panel2.Controls.Add(this.btnGuardar);
            this.panel2.Controls.Add(this.labelDireccion);
            this.panel2.Controls.Add(this.labelPolicia);
            this.panel2.Location = new System.Drawing.Point(46, 16);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(549, 454);
            this.panel2.TabIndex = 28;

            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Location = new System.Drawing.Point(75, 155);
            this.textBoxDescripcion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxDescripcion.Multiline = true;
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(429, 224);
            this.textBoxDescripcion.TabIndex = 35;
            // 
            // textBoxIncidente
            // 
            this.textBoxIncidente.Location = new System.Drawing.Point(318, 91);
            this.textBoxIncidente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxIncidente.Name = "textBoxIncidente";
            this.textBoxIncidente.Size = new System.Drawing.Size(186, 20);
            this.textBoxIncidente.TabIndex = 31;
            // 
            // textBoxDireccion
            // 
            this.textBoxDireccion.Location = new System.Drawing.Point(75, 91);
            this.textBoxDireccion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxDireccion.Name = "textBoxDireccion";
            this.textBoxDireccion.Size = new System.Drawing.Size(158, 20);
            this.textBoxDireccion.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(72, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 14);
            this.label2.TabIndex = 26;
            this.label2.Text = "Descripcion";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(275, 407);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(111, 31);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // labelTitulo_Reporte
            // 
            this.labelTitulo_Reporte.AutoSize = true;
            this.labelTitulo_Reporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo_Reporte.Location = new System.Drawing.Point(161, 27);
            this.labelTitulo_Reporte.Name = "labelTitulo_Reporte";
            this.labelTitulo_Reporte.Size = new System.Drawing.Size(225, 25);
            this.labelTitulo_Reporte.TabIndex = 24;
            this.labelTitulo_Reporte.Text = "Informe de la Alerta ";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(122, 407);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(111, 31);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // labelDireccion
            // 
            this.labelDireccion.AutoSize = true;
            this.labelDireccion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDireccion.Location = new System.Drawing.Point(72, 75);
            this.labelDireccion.Name = "labelDireccion";
            this.labelDireccion.Size = new System.Drawing.Size(56, 14);
            this.labelDireccion.TabIndex = 2;
            this.labelDireccion.Text = "Direccion";
            // 
            // labelPolicia
            // 
            this.labelPolicia.AutoSize = true;
            this.labelPolicia.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPolicia.Location = new System.Drawing.Point(315, 75);
            this.labelPolicia.Name = "labelPolicia";
            this.labelPolicia.Size = new System.Drawing.Size(59, 14);
            this.labelPolicia.TabIndex = 3;
            this.labelPolicia.Text = "Incidente";
            // 
            // FormReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 487);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormReporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormReporte";
            this.Load += new System.EventHandler(this.FormReporte_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label labelTitulo_Reporte;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label labelDireccion;
        private System.Windows.Forms.Label labelPolicia;
        private System.Windows.Forms.TextBox textBoxIncidente;
        private System.Windows.Forms.TextBox textBoxDireccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDescripcion;
    }
}