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
            this.tituloPrograma = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textDireccion = new System.Windows.Forms.TextBox();
            this.txtLongitud = new System.Windows.Forms.Label();
            this.btnAgregarAlerta = new System.Windows.Forms.Button();
            this.panelMapa = new System.Windows.Forms.Panel();
            this.panelForm = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ListDelitos = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textTelefono = new System.Windows.Forms.TextBox();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLatitud = new System.Windows.Forms.Label();
            this.btnJurisdicciones = new System.Windows.Forms.Button();
            this.id_alerta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.incidente_alerta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelNavegacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMapa.SuspendLayout();
            this.panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.gMapControl1.Location = new System.Drawing.Point(-107, 5);
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
            this.gMapControl1.Size = new System.Drawing.Size(856, 423);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            // 
            // panelNavegacion
            // 
            this.panelNavegacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panelNavegacion.Controls.Add(this.tituloPrograma);
            this.panelNavegacion.Controls.Add(this.pictureBox1);
            this.panelNavegacion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelNavegacion.Location = new System.Drawing.Point(-1, 0);
            this.panelNavegacion.Name = "panelNavegacion";
            this.panelNavegacion.Size = new System.Drawing.Size(967, 44);
            this.panelNavegacion.TabIndex = 1;
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
            // textDireccion
            // 
            this.textDireccion.Location = new System.Drawing.Point(12, 55);
            this.textDireccion.Name = "textDireccion";
            this.textDireccion.Size = new System.Drawing.Size(370, 20);
            this.textDireccion.TabIndex = 2;
            // 
            // txtLongitud
            // 
            this.txtLongitud.AutoSize = true;
            this.txtLongitud.Location = new System.Drawing.Point(13, 92);
            this.txtLongitud.Name = "txtLongitud";
            this.txtLongitud.Size = new System.Drawing.Size(49, 13);
            this.txtLongitud.TabIndex = 5;
            this.txtLongitud.Text = "Telefono";
            // 
            // btnAgregarAlerta
            // 
            this.btnAgregarAlerta.Location = new System.Drawing.Point(134, 297);
            this.btnAgregarAlerta.Name = "btnAgregarAlerta";
            this.btnAgregarAlerta.Size = new System.Drawing.Size(137, 34);
            this.btnAgregarAlerta.TabIndex = 6;
            this.btnAgregarAlerta.Text = "Agregar";
            this.btnAgregarAlerta.UseVisualStyleBackColor = true;
            this.btnAgregarAlerta.Click += new System.EventHandler(this.btnAgregarAlerta_Click);
            // 
            // panelMapa
            // 
            this.panelMapa.Controls.Add(this.gMapControl1);
            this.panelMapa.Location = new System.Drawing.Point(-1, 45);
            this.panelMapa.Name = "panelMapa";
            this.panelMapa.Size = new System.Drawing.Size(762, 426);
            this.panelMapa.TabIndex = 7;
            // 
            // panelForm
            // 
            this.panelForm.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelForm.Controls.Add(this.dataGridView1);
            this.panelForm.Controls.Add(this.ListDelitos);
            this.panelForm.Controls.Add(this.label2);
            this.panelForm.Controls.Add(this.textTelefono);
            this.panelForm.Controls.Add(this.textNombre);
            this.panelForm.Controls.Add(this.label1);
            this.panelForm.Controls.Add(this.txtLatitud);
            this.panelForm.Controls.Add(this.btnAgregarAlerta);
            this.panelForm.Controls.Add(this.textDireccion);
            this.panelForm.Controls.Add(this.txtLongitud);
            this.panelForm.Location = new System.Drawing.Point(692, 45);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(274, 459);
            this.panelForm.TabIndex = 8;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_alerta,
            this.incidente_alerta,
            this.Estado,
            this.Telefono,
            this.Nombre,
            this.direccion});
            this.dataGridView1.Location = new System.Drawing.Point(13, 350);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(370, 270);
            this.dataGridView1.TabIndex = 12;
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
            this.ListDelitos.Location = new System.Drawing.Point(13, 182);
            this.ListDelitos.Name = "ListDelitos";
            this.ListDelitos.Size = new System.Drawing.Size(370, 109);
            this.ListDelitos.TabIndex = 11;
            this.ListDelitos.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListDelitos_ItemCheck);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nombre";
            // 
            // textTelefono
            // 
            this.textTelefono.Location = new System.Drawing.Point(12, 108);
            this.textTelefono.Name = "textTelefono";
            this.textTelefono.Size = new System.Drawing.Size(370, 20);
            this.textTelefono.TabIndex = 9;
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(12, 156);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(370, 20);
            this.textNombre.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Formulario Alerta";
            // 
            // txtLatitud
            // 
            this.txtLatitud.AutoSize = true;
            this.txtLatitud.Location = new System.Drawing.Point(13, 39);
            this.txtLatitud.Name = "txtLatitud";
            this.txtLatitud.Size = new System.Drawing.Size(52, 13);
            this.txtLatitud.TabIndex = 4;
            this.txtLatitud.Text = "Direccion";
            // 
            // btnJurisdicciones
            // 
            this.btnJurisdicciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnJurisdicciones.BackColor = System.Drawing.Color.White;
            this.btnJurisdicciones.Image = global::Operador_911.Properties.Resources.istockphoto_599271426_612x612__1___1_;
            this.btnJurisdicciones.Location = new System.Drawing.Point(12, 454);
            this.btnJurisdicciones.Margin = new System.Windows.Forms.Padding(0);
            this.btnJurisdicciones.Name = "btnJurisdicciones";
            this.btnJurisdicciones.Size = new System.Drawing.Size(64, 40);
            this.btnJurisdicciones.TabIndex = 2;
            this.btnJurisdicciones.UseVisualStyleBackColor = false;
            this.btnJurisdicciones.Click += new System.EventHandler(this.btnJurisdicciones_Click);
            // 
            // id_alerta
            // 
            this.id_alerta.HeaderText = "ID";
            this.id_alerta.MinimumWidth = 3;
            this.id_alerta.Name = "id_alerta";
            this.id_alerta.Width = 35;
            // 
            // incidente_alerta
            // 
            this.incidente_alerta.HeaderText = "Incidente";
            this.incidente_alerta.Name = "incidente_alerta";
            this.incidente_alerta.Width = 75;
            // 
            // Estado
            // 
            this.Estado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Estado.HeaderText = "Estado";
            this.Estado.Items.AddRange(new object[] {
            "En Espera",
            "Atendido"});
            this.Estado.Name = "Estado";
            this.Estado.Width = 75;
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            this.Telefono.Width = 75;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 90;
            // 
            // direccion
            // 
            this.direccion.HeaderText = "Direccion";
            this.direccion.Name = "direccion";
            this.direccion.Width = 90;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 503);
            this.Controls.Add(this.btnJurisdicciones);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.panelMapa);
            this.Controls.Add(this.panelNavegacion);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.panelNavegacion.ResumeLayout(false);
            this.panelNavegacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMapa.ResumeLayout(false);
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_alerta;
        private System.Windows.Forms.DataGridViewTextBoxColumn incidente_alerta;
        private System.Windows.Forms.DataGridViewComboBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
    }
}

