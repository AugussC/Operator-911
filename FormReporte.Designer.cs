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
            this.textBoxIdAlerta = new System.Windows.Forms.TextBox();
            this.textBoxFecha = new System.Windows.Forms.TextBox();
            this.textBoxTelefono = new System.Windows.Forms.TextBox();
            this.textBoxIncidente = new System.Windows.Forms.TextBox();
            this.textBoxDireccion = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.labelDNI = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.labelTitulo_Reporte = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.labelFecha = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelDireccion = new System.Windows.Forms.Label();
            this.labelOperador = new System.Windows.Forms.Label();
            this.labelPolicia = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.textBoxDescripcion);
            this.panel2.Controls.Add(this.textBoxIdAlerta);
            this.panel2.Controls.Add(this.textBoxFecha);
            this.panel2.Controls.Add(this.textBoxTelefono);
            this.panel2.Controls.Add(this.textBoxIncidente);
            this.panel2.Controls.Add(this.textBoxDireccion);
            this.panel2.Controls.Add(this.textBoxNombre);
            this.panel2.Controls.Add(this.labelDNI);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Controls.Add(this.labelTitulo_Reporte);
            this.panel2.Controls.Add(this.btnGuardar);
            this.panel2.Controls.Add(this.labelFecha);
            this.panel2.Controls.Add(this.labelNombre);
            this.panel2.Controls.Add(this.labelDireccion);
            this.panel2.Controls.Add(this.labelOperador);
            this.panel2.Controls.Add(this.labelPolicia);
            this.panel2.Location = new System.Drawing.Point(69, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(824, 887);
            this.panel2.TabIndex = 28;
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Location = new System.Drawing.Point(129, 652);
            this.textBoxDescripcion.Multiline = true;
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(523, 101);
            this.textBoxDescripcion.TabIndex = 35;
            // 
            // textBoxIdAlerta
            // 
            this.textBoxIdAlerta.Location = new System.Drawing.Point(129, 565);
            this.textBoxIdAlerta.Name = "textBoxIdAlerta";
            this.textBoxIdAlerta.Size = new System.Drawing.Size(523, 26);
            this.textBoxIdAlerta.TabIndex = 34;
            // 
            // textBoxFecha
            // 
            this.textBoxFecha.Location = new System.Drawing.Point(129, 480);
            this.textBoxFecha.Name = "textBoxFecha";
            this.textBoxFecha.Size = new System.Drawing.Size(523, 26);
            this.textBoxFecha.TabIndex = 33;
            // 
            // textBoxTelefono
            // 
            this.textBoxTelefono.Location = new System.Drawing.Point(129, 394);
            this.textBoxTelefono.Name = "textBoxTelefono";
            this.textBoxTelefono.Size = new System.Drawing.Size(523, 26);
            this.textBoxTelefono.TabIndex = 32;
            // 
            // textBoxIncidente
            // 
            this.textBoxIncidente.Location = new System.Drawing.Point(129, 304);
            this.textBoxIncidente.Name = "textBoxIncidente";
            this.textBoxIncidente.Size = new System.Drawing.Size(523, 26);
            this.textBoxIncidente.TabIndex = 31;
            // 
            // textBoxDireccion
            // 
            this.textBoxDireccion.Location = new System.Drawing.Point(129, 218);
            this.textBoxDireccion.Name = "textBoxDireccion";
            this.textBoxDireccion.Size = new System.Drawing.Size(523, 26);
            this.textBoxDireccion.TabIndex = 30;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(129, 131);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(523, 26);
            this.textBoxNombre.TabIndex = 29;
            // 
            // labelDNI
            // 
            this.labelDNI.AutoSize = true;
            this.labelDNI.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDNI.Location = new System.Drawing.Point(125, 540);
            this.labelDNI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDNI.Name = "labelDNI";
            this.labelDNI.Size = new System.Drawing.Size(80, 22);
            this.labelDNI.TabIndex = 25;
            this.labelDNI.Text = "ID Alerta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(125, 627);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 22);
            this.label2.TabIndex = 26;
            this.label2.Text = "Descripcion";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(393, 776);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(166, 48);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // labelTitulo_Reporte
            // 
            this.labelTitulo_Reporte.AutoSize = true;
            this.labelTitulo_Reporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo_Reporte.Location = new System.Drawing.Point(208, 52);
            this.labelTitulo_Reporte.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitulo_Reporte.Name = "labelTitulo_Reporte";
            this.labelTitulo_Reporte.Size = new System.Drawing.Size(390, 37);
            this.labelTitulo_Reporte.TabIndex = 24;
            this.labelTitulo_Reporte.Text = "Redactar Nuevo Reporte";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(205, 776);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(166, 48);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFecha.Location = new System.Drawing.Point(125, 455);
            this.labelFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(55, 22);
            this.labelFecha.TabIndex = 12;
            this.labelFecha.Text = "Fecha";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre.Location = new System.Drawing.Point(125, 106);
            this.labelNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(72, 22);
            this.labelNombre.TabIndex = 1;
            this.labelNombre.Text = "Nombre";
            // 
            // labelDireccion
            // 
            this.labelDireccion.AutoSize = true;
            this.labelDireccion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDireccion.Location = new System.Drawing.Point(125, 193);
            this.labelDireccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDireccion.Name = "labelDireccion";
            this.labelDireccion.Size = new System.Drawing.Size(81, 22);
            this.labelDireccion.TabIndex = 2;
            this.labelDireccion.Text = "Direccion";
            // 
            // labelOperador
            // 
            this.labelOperador.AutoSize = true;
            this.labelOperador.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOperador.Location = new System.Drawing.Point(125, 369);
            this.labelOperador.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOperador.Name = "labelOperador";
            this.labelOperador.Size = new System.Drawing.Size(79, 22);
            this.labelOperador.TabIndex = 8;
            this.labelOperador.Text = "Telefono";
            // 
            // labelPolicia
            // 
            this.labelPolicia.AutoSize = true;
            this.labelPolicia.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPolicia.Location = new System.Drawing.Point(125, 279);
            this.labelPolicia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPolicia.Name = "labelPolicia";
            this.labelPolicia.Size = new System.Drawing.Size(83, 22);
            this.labelPolicia.TabIndex = 3;
            this.labelPolicia.Text = "Incidente";
            // 
            // FormReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 950);
            this.Controls.Add(this.panel2);
            this.Name = "FormReporte";
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
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelDireccion;
        private System.Windows.Forms.Label labelOperador;
        private System.Windows.Forms.Label labelPolicia;
        private System.Windows.Forms.TextBox textBoxIncidente;
        private System.Windows.Forms.TextBox textBoxDireccion;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label labelDNI;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.TextBox textBoxIdAlerta;
        private System.Windows.Forms.TextBox textBoxFecha;
        private System.Windows.Forms.TextBox textBoxTelefono;
    }
}