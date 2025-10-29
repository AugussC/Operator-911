namespace Operador_911
{
    partial class FormReporteGenerado
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
            this.labelTituloReporte = new System.Windows.Forms.Label();
            this.labelEncabezado = new System.Windows.Forms.Label();
            this.labelSubEncabezado = new System.Windows.Forms.Label();
            this.labelPrimeraParte = new System.Windows.Forms.Label();
            this.labelPrimerParrafo = new System.Windows.Forms.Label();
            this.labelSegundoParrafo = new System.Windows.Forms.Label();
            this.labelDescripcion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTituloReporte
            // 
            this.labelTituloReporte.AutoSize = true;
            this.labelTituloReporte.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTituloReporte.Location = new System.Drawing.Point(413, 134);
            this.labelTituloReporte.Name = "labelTituloReporte";
            this.labelTituloReporte.Size = new System.Drawing.Size(101, 27);
            this.labelTituloReporte.TabIndex = 17;
            this.labelTituloReporte.Text = "Reporte";
            this.labelTituloReporte.Click += new System.EventHandler(this.labelTituloReporte_Click);
            // 
            // labelEncabezado
            // 
            this.labelEncabezado.AutoSize = true;
            this.labelEncabezado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEncabezado.Location = new System.Drawing.Point(361, 32);
            this.labelEncabezado.Name = "labelEncabezado";
            this.labelEncabezado.Size = new System.Drawing.Size(200, 24);
            this.labelEncabezado.TabIndex = 19;
            this.labelEncabezado.Text = "Republica Argentina";
            // 
            // labelSubEncabezado
            // 
            this.labelSubEncabezado.AutoSize = true;
            this.labelSubEncabezado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubEncabezado.Location = new System.Drawing.Point(298, 81);
            this.labelSubEncabezado.Name = "labelSubEncabezado";
            this.labelSubEncabezado.Size = new System.Drawing.Size(348, 24);
            this.labelSubEncabezado.TabIndex = 20;
            this.labelSubEncabezado.Text = "Policia de la Provincia de Corrientes";
            // 
            // labelPrimeraParte
            // 
            this.labelPrimeraParte.AutoSize = true;
            this.labelPrimeraParte.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrimeraParte.Location = new System.Drawing.Point(101, 224);
            this.labelPrimeraParte.Name = "labelPrimeraParte";
            this.labelPrimeraParte.Size = new System.Drawing.Size(271, 19);
            this.labelPrimeraParte.TabIndex = 22;
            this.labelPrimeraParte.Text = "La Policia de Corrientes informa que:";
            // 
            // labelPrimerParrafo
            // 
            this.labelPrimerParrafo.AutoSize = true;
            this.labelPrimerParrafo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrimerParrafo.Location = new System.Drawing.Point(101, 269);
            this.labelPrimerParrafo.Name = "labelPrimerParrafo";
            this.labelPrimerParrafo.Size = new System.Drawing.Size(665, 38);
            this.labelPrimerParrafo.TabIndex = 23;
            this.labelPrimerParrafo.Text = "Siendo el día de hoy, [Fecha Creacion de la Alerta ], a través de la línea de \r\ne" +
    "mergenciase recibió aviso de un [Incidente de la Alerta] ocurrido en [Direccion " +
    "de la Alerta]";
            // 
            // labelSegundoParrafo
            // 
            this.labelSegundoParrafo.AutoSize = true;
            this.labelSegundoParrafo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSegundoParrafo.Location = new System.Drawing.Point(101, 359);
            this.labelSegundoParrafo.Name = "labelSegundoParrafo";
            this.labelSegundoParrafo.Size = new System.Drawing.Size(670, 38);
            this.labelSegundoParrafo.TabIndex = 24;
            this.labelSegundoParrafo.Text = "De inmediato, se desplazó al lugar la [codigo de la patrulla] a cargo del Oficial" +
    " de Seguridad, \r\n[Oficial a Cargo de la Patrulla],  quien constató:";
            // 
            // labelDescripcion
            // 
            this.labelDescripcion.AutoSize = true;
            this.labelDescripcion.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescripcion.Location = new System.Drawing.Point(101, 411);
            this.labelDescripcion.Name = "labelDescripcion";
            this.labelDescripcion.Size = new System.Drawing.Size(321, 19);
            this.labelDescripcion.TabIndex = 25;
            this.labelDescripcion.Text = "[Descripcion] de lo que paso segun el oficial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(101, 454);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(782, 38);
            this.label2.TabIndex = 26;
            this.label2.Text = "El caso fue remitido a la [Comisaria que pertence la Patrulla], donde se dará con" +
    "tinuidad a las investigaciones\r\n y se determinarán las responsabilidades conform" +
    "e a la Ley.";
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFecha.Location = new System.Drawing.Point(49, 633);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(100, 19);
            this.labelFecha.TabIndex = 28;
            this.labelFecha.Text = "Dia/Mes/Año";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Operador_911.Properties.Resources.WhatsApp_Image_2025_09_12_at_22_07_25_removebg_preview;
            this.pictureBox3.Location = new System.Drawing.Point(507, 495);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(387, 157);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 27;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Operador_911.Properties.Resources.Escudo_de_la_Provincia_de_Corrientes__variante_3_1;
            this.pictureBox2.Location = new System.Drawing.Point(744, 32);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(139, 129);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Operador_911.Properties.Resources._4fTAsWOK_400x400__1___1_;
            this.pictureBox1.Location = new System.Drawing.Point(69, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 129);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // FormReporteGenerado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 661);
            this.Controls.Add(this.labelFecha);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelDescripcion);
            this.Controls.Add(this.labelSegundoParrafo);
            this.Controls.Add(this.labelPrimerParrafo);
            this.Controls.Add(this.labelPrimeraParte);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.labelSubEncabezado);
            this.Controls.Add(this.labelEncabezado);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelTituloReporte);
            this.Name = "FormReporteGenerado";
            this.Text = "FormReporteGenerado";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTituloReporte;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelEncabezado;
        private System.Windows.Forms.Label labelSubEncabezado;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelPrimeraParte;
        private System.Windows.Forms.Label labelPrimerParrafo;
        private System.Windows.Forms.Label labelSegundoParrafo;
        private System.Windows.Forms.Label labelDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label labelFecha;
    }
}