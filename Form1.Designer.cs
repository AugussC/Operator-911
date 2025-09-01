namespace Operador_911
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.panelNavegacion = new System.Windows.Forms.Panel();
            this.btnJurisdicciones = new System.Windows.Forms.Button();
            this.tituloPrograma = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textLatitud = new System.Windows.Forms.TextBox();
            this.textLongitud = new System.Windows.Forms.TextBox();
            this.txtLatitud = new System.Windows.Forms.Label();
            this.txtLongitud = new System.Windows.Forms.Label();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.panelNavegacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(-1, 33);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(764, 433);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            // 
            // panelNavegacion
            // 
            this.panelNavegacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panelNavegacion.Controls.Add(this.btnJurisdicciones);
            this.panelNavegacion.Controls.Add(this.tituloPrograma);
            this.panelNavegacion.Controls.Add(this.pictureBox1);
            this.panelNavegacion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelNavegacion.Location = new System.Drawing.Point(-1, 0);
            this.panelNavegacion.Name = "panelNavegacion";
            this.panelNavegacion.Size = new System.Drawing.Size(967, 44);
            this.panelNavegacion.TabIndex = 1;
            // 
            // btnJurisdicciones
            // 
            this.btnJurisdicciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnJurisdicciones.Location = new System.Drawing.Point(177, 4);
            this.btnJurisdicciones.Margin = new System.Windows.Forms.Padding(0);
            this.btnJurisdicciones.Name = "btnJurisdicciones";
            this.btnJurisdicciones.Size = new System.Drawing.Size(90, 38);
            this.btnJurisdicciones.TabIndex = 2;
            this.btnJurisdicciones.Text = "Jurisdicciones";
            this.btnJurisdicciones.UseVisualStyleBackColor = false;
            this.btnJurisdicciones.Click += new System.EventHandler(this.btnJurisdicciones_Click);
            // 
            // tituloPrograma
            // 
            this.tituloPrograma.AutoSize = true;
            this.tituloPrograma.Location = new System.Drawing.Point(92, 17);
            this.tituloPrograma.Name = "tituloPrograma";
            this.tituloPrograma.Size = new System.Drawing.Size(72, 13);
            this.tituloPrograma.TabIndex = 1;
            this.tituloPrograma.Text = "911 Operador";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Operador_911.Properties.Resources._4fTAsWOK_400x400__1___1_;
            this.pictureBox1.Location = new System.Drawing.Point(13, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(73, 52);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textLatitud
            // 
            this.textLatitud.Location = new System.Drawing.Point(769, 89);
            this.textLatitud.Name = "textLatitud";
            this.textLatitud.Size = new System.Drawing.Size(142, 20);
            this.textLatitud.TabIndex = 2;
            // 
            // textLongitud
            // 
            this.textLongitud.Location = new System.Drawing.Point(769, 135);
            this.textLongitud.Name = "textLongitud";
            this.textLongitud.Size = new System.Drawing.Size(141, 20);
            this.textLongitud.TabIndex = 3;
            // 
            // txtLatitud
            // 
            this.txtLatitud.AutoSize = true;
            this.txtLatitud.Location = new System.Drawing.Point(767, 73);
            this.txtLatitud.Name = "txtLatitud";
            this.txtLatitud.Size = new System.Drawing.Size(39, 13);
            this.txtLatitud.TabIndex = 4;
            this.txtLatitud.Text = "Latitud";
            // 
            // txtLongitud
            // 
            this.txtLongitud.AutoSize = true;
            this.txtLongitud.Location = new System.Drawing.Point(767, 119);
            this.txtLongitud.Name = "txtLongitud";
            this.txtLongitud.Size = new System.Drawing.Size(48, 13);
            this.txtLongitud.TabIndex = 5;
            this.txtLongitud.Text = "Longitud";
            // 
            // btnCopiar
            // 
            this.btnCopiar.Location = new System.Drawing.Point(781, 177);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(75, 23);
            this.btnCopiar.TabIndex = 6;
            this.btnCopiar.Text = "copiar";
            this.btnCopiar.UseVisualStyleBackColor = true;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 469);
            this.Controls.Add(this.btnCopiar);
            this.Controls.Add(this.txtLongitud);
            this.Controls.Add(this.txtLatitud);
            this.Controls.Add(this.textLongitud);
            this.Controls.Add(this.textLatitud);
            this.Controls.Add(this.panelNavegacion);
            this.Controls.Add(this.gMapControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.panelNavegacion.ResumeLayout(false);
            this.panelNavegacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Panel panelNavegacion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label tituloPrograma;
        private System.Windows.Forms.Button btnJurisdicciones;
        private System.Windows.Forms.TextBox textLatitud;
        private System.Windows.Forms.TextBox textLongitud;
        private System.Windows.Forms.Label txtLatitud;
        private System.Windows.Forms.Label txtLongitud;
        private System.Windows.Forms.Button btnCopiar;
    }
}

