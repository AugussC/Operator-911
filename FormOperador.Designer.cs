namespace Operador_911
{
    partial class FormOperador
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
            this.btnActualizarMapa = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.tituloPrograma = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textDireccion = new System.Windows.Forms.TextBox();
            this.txtLongitud = new System.Windows.Forms.Label();
            this.btnAgregarAlerta = new System.Windows.Forms.Button();
            this.panelMapa = new System.Windows.Forms.Panel();
            this.btnJurisdicciones = new System.Windows.Forms.Button();
            this.btnBomberos = new System.Windows.Forms.Button();
            this.btnHospitales = new System.Windows.Forms.Button();
            this.panelForm = new System.Windows.Forms.Panel();
            this.dataGridViewAlertas = new System.Windows.Forms.DataGridView();
            this.ListDelitos = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textTelefono = new System.Windows.Forms.TextBox();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLatitud = new System.Windows.Forms.Label();
            this.panelNavegacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMapa.SuspendLayout();
            this.panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlertas)).BeginInit();
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
            this.gMapControl1.Location = new System.Drawing.Point(-160, 8);
            this.gMapControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.gMapControl1.Size = new System.Drawing.Size(1582, 1060);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            // 
            // panelNavegacion
            // 
            this.panelNavegacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panelNavegacion.Controls.Add(this.btnActualizarMapa);
            this.panelNavegacion.Controls.Add(this.btnCerrarSesion);
            this.panelNavegacion.Controls.Add(this.tituloPrograma);
            this.panelNavegacion.Controls.Add(this.pictureBox1);
            this.panelNavegacion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelNavegacion.Location = new System.Drawing.Point(-2, 0);
            this.panelNavegacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelNavegacion.Name = "panelNavegacion";
            this.panelNavegacion.Size = new System.Drawing.Size(2054, 68);
            this.panelNavegacion.TabIndex = 1;
            // 
            // btnActualizarMapa
            // 
            this.btnActualizarMapa.BackColor = System.Drawing.Color.DarkGray;
            this.btnActualizarMapa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarMapa.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarMapa.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnActualizarMapa.Location = new System.Drawing.Point(1707, 17);
            this.btnActualizarMapa.Name = "btnActualizarMapa";
            this.btnActualizarMapa.Size = new System.Drawing.Size(164, 42);
            this.btnActualizarMapa.TabIndex = 4;
            this.btnActualizarMapa.Text = "Actualizar Mapa";
            this.btnActualizarMapa.UseVisualStyleBackColor = false;
            this.btnActualizarMapa.Click += new System.EventHandler(this.btnActualizarMapa_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCerrarSesion.Location = new System.Drawing.Point(1876, 15);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(164, 42);
            this.btnCerrarSesion.TabIndex = 3;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
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
            // textDireccion
            // 
            this.textDireccion.Location = new System.Drawing.Point(18, 85);
            this.textDireccion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textDireccion.Name = "textDireccion";
            this.textDireccion.Size = new System.Drawing.Size(596, 26);
            this.textDireccion.TabIndex = 2;
            // 
            // txtLongitud
            // 
            this.txtLongitud.AutoSize = true;
            this.txtLongitud.Location = new System.Drawing.Point(20, 142);
            this.txtLongitud.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtLongitud.Name = "txtLongitud";
            this.txtLongitud.Size = new System.Drawing.Size(71, 20);
            this.txtLongitud.TabIndex = 5;
            this.txtLongitud.Text = "Telefono";
            // 
            // btnAgregarAlerta
            // 
            this.btnAgregarAlerta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarAlerta.Location = new System.Drawing.Point(231, 464);
            this.btnAgregarAlerta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAgregarAlerta.Name = "btnAgregarAlerta";
            this.btnAgregarAlerta.Size = new System.Drawing.Size(206, 52);
            this.btnAgregarAlerta.TabIndex = 6;
            this.btnAgregarAlerta.Text = "Agregar";
            this.btnAgregarAlerta.UseVisualStyleBackColor = true;
            this.btnAgregarAlerta.Click += new System.EventHandler(this.btnAgregarAlerta_Click);
            // 
            // panelMapa
            // 
            this.panelMapa.Controls.Add(this.btnJurisdicciones);
            this.panelMapa.Controls.Add(this.btnBomberos);
            this.panelMapa.Controls.Add(this.btnHospitales);
            this.panelMapa.Controls.Add(this.gMapControl1);
            this.panelMapa.Location = new System.Drawing.Point(-2, 69);
            this.panelMapa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelMapa.Name = "panelMapa";
            this.panelMapa.Size = new System.Drawing.Size(1426, 1052);
            this.panelMapa.TabIndex = 7;
            // 
            // btnJurisdicciones
            // 
            this.btnJurisdicciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnJurisdicciones.BackColor = System.Drawing.Color.White;
            this.btnJurisdicciones.Image = global::Operador_911.Properties.Resources.istockphoto_599271426_612x612__1___1_;
            this.btnJurisdicciones.Location = new System.Drawing.Point(34, 948);
            this.btnJurisdicciones.Margin = new System.Windows.Forms.Padding(0);
            this.btnJurisdicciones.Name = "btnJurisdicciones";
            this.btnJurisdicciones.Size = new System.Drawing.Size(96, 72);
            this.btnJurisdicciones.TabIndex = 2;
            this.btnJurisdicciones.UseVisualStyleBackColor = false;
            this.btnJurisdicciones.Click += new System.EventHandler(this.btnJurisdicciones_Click);
            // 
            // btnBomberos
            // 
            this.btnBomberos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBomberos.BackColor = System.Drawing.Color.White;
            this.btnBomberos.Image = global::Operador_911.Properties.Resources.bombero__2___2_;
            this.btnBomberos.Location = new System.Drawing.Point(250, 948);
            this.btnBomberos.Margin = new System.Windows.Forms.Padding(0);
            this.btnBomberos.Name = "btnBomberos";
            this.btnBomberos.Size = new System.Drawing.Size(96, 72);
            this.btnBomberos.TabIndex = 9;
            this.btnBomberos.UseVisualStyleBackColor = false;
            this.btnBomberos.Click += new System.EventHandler(this.btnBomberos_Click);
            // 
            // btnHospitales
            // 
            this.btnHospitales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHospitales.BackColor = System.Drawing.Color.White;
            this.btnHospitales.Image = global::Operador_911.Properties.Resources.ambulanciaLogo2;
            this.btnHospitales.Location = new System.Drawing.Point(142, 948);
            this.btnHospitales.Margin = new System.Windows.Forms.Padding(0);
            this.btnHospitales.Name = "btnHospitales";
            this.btnHospitales.Size = new System.Drawing.Size(96, 72);
            this.btnHospitales.TabIndex = 10;
            this.btnHospitales.UseVisualStyleBackColor = false;
            this.btnHospitales.Click += new System.EventHandler(this.btnHospitales_Click);
            // 
            // panelForm
            // 
            this.panelForm.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelForm.Controls.Add(this.dataGridViewAlertas);
            this.panelForm.Controls.Add(this.ListDelitos);
            this.panelForm.Controls.Add(this.label2);
            this.panelForm.Controls.Add(this.textTelefono);
            this.panelForm.Controls.Add(this.textNombre);
            this.panelForm.Controls.Add(this.label1);
            this.panelForm.Controls.Add(this.txtLatitud);
            this.panelForm.Controls.Add(this.btnAgregarAlerta);
            this.panelForm.Controls.Add(this.textDireccion);
            this.panelForm.Controls.Add(this.txtLongitud);
            this.panelForm.Location = new System.Drawing.Point(1414, 69);
            this.panelForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(638, 1058);
            this.panelForm.TabIndex = 8;
            this.panelForm.Paint += new System.Windows.Forms.PaintEventHandler(this.panelForm_Paint);
            // 
            // dataGridViewAlertas
            // 
            this.dataGridViewAlertas.AllowUserToAddRows = false;
            this.dataGridViewAlertas.AllowUserToDeleteRows = false;
            this.dataGridViewAlertas.BackgroundColor = System.Drawing.Color.CadetBlue;
            this.dataGridViewAlertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAlertas.Location = new System.Drawing.Point(20, 538);
            this.dataGridViewAlertas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewAlertas.Name = "dataGridViewAlertas";
            this.dataGridViewAlertas.RowHeadersVisible = false;
            this.dataGridViewAlertas.RowHeadersWidth = 62;
            this.dataGridViewAlertas.Size = new System.Drawing.Size(597, 415);
            this.dataGridViewAlertas.TabIndex = 12;
            this.dataGridViewAlertas.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewAlertas_CellBeginEdit);
            this.dataGridViewAlertas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAlertas_CellContentClick);
            // 
            // ListDelitos
            // 
            this.ListDelitos.CheckOnClick = true;
            this.ListDelitos.FormattingEnabled = true;
            this.ListDelitos.Items.AddRange(new object[] {
            "Abuso de armas ",
            "Abuso sexual ",
            "Amenazas ",
            "Asesinato ",
            "Asesinato en Progreso ",
            "Choque ",
            "Contrabando de estupefacientes ",
            "Daños ",
            "Delitos contra el orden público ",
            "Delitos contra la seguridad pública ",
            "Delitos contra las personas ",
            "Desacato ",
            "Descompensación ",
            "Disparo de arma de fuego con herida ",
            "Disparo de arma de fuego sin herir ",
            "Disparo de arma de fuego y agresión en estado de emoción violenta ",
            "Encarcelación u otra privación grave de la libertad física ",
            "Entorpecimiento de transporte o servicio público ",
            "Explotación de Menores ",
            "Homicidio ",
            "Incendio ",
            "Insania ",
            "Intento de Homicidio ",
            "Intento de Suicidio ",
            "Lesiones ",
            "Lesiones leves ",
            "Motín ",
            "Obstrucción de la vía pública ",
            "Prostitución forzada ",
            "Resistencia a la autoridad ",
            "Riña ",
            "Robo ",
            "Robo a mano armada ",
            "Robo en Progreso ",
            "Secuestro ",
            "Solicitud Médica ",
            "Sustracción, retención y ocultamiento de menores ",
            "Trata de menores ",
            "Trata de mujeres ",
            "Usurpación ",
            "Usurpación con gente dentro ",
            "Violación ",
            "Violación de domicilio ",
            "otros"});
            this.ListDelitos.Location = new System.Drawing.Point(20, 280);
            this.ListDelitos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ListDelitos.Name = "ListDelitos";
            this.ListDelitos.Size = new System.Drawing.Size(595, 165);
            this.ListDelitos.TabIndex = 11;
            this.ListDelitos.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListDelitos_ItemCheck);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 215);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nombre";
            // 
            // textTelefono
            // 
            this.textTelefono.Location = new System.Drawing.Point(18, 166);
            this.textTelefono.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textTelefono.Name = "textTelefono";
            this.textTelefono.Size = new System.Drawing.Size(596, 26);
            this.textTelefono.TabIndex = 9;
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(18, 240);
            this.textNombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(596, 26);
            this.textNombre.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(180, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 33);
            this.label1.TabIndex = 7;
            this.label1.Text = "Formulario Alerta";
            // 
            // txtLatitud
            // 
            this.txtLatitud.AutoSize = true;
            this.txtLatitud.Location = new System.Drawing.Point(20, 60);
            this.txtLatitud.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtLatitud.Name = "txtLatitud";
            this.txtLatitud.Size = new System.Drawing.Size(75, 20);
            this.txtLatitud.TabIndex = 4;
            this.txtLatitud.Text = "Direccion";
            // 
            // FormOperador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2055, 1104);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.panelMapa);
            this.Controls.Add(this.panelNavegacion);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormOperador";
            this.Text = "FormOperador";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormOperador_Load_1);
            this.panelNavegacion.ResumeLayout(false);
            this.panelNavegacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMapa.ResumeLayout(false);
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlertas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Panel panelNavegacion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label tituloPrograma;
        private System.Windows.Forms.Button btnJurisdicciones;
        private System.Windows.Forms.TextBox textDireccion;
        private System.Windows.Forms.Label txtLongitud;
        private System.Windows.Forms.Button btnAgregarAlerta;
        private System.Windows.Forms.Panel panelMapa;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Label txtLatitud;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textTelefono;
        private System.Windows.Forms.CheckedListBox ListDelitos;
        private System.Windows.Forms.DataGridView dataGridViewAlertas;
        private System.Windows.Forms.Button btnBomberos;
        private System.Windows.Forms.Button btnHospitales;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnActualizarMapa;
    }
}

