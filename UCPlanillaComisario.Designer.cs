namespace Operador_911
{
    partial class UCPlanilla
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridHorarios = new System.Windows.Forms.DataGridView();
            this.labelPatrulla = new System.Windows.Forms.Label();
            this.labelPolicia1 = new System.Windows.Forms.Label();
            this.labelPolicia2 = new System.Windows.Forms.Label();
            this.patrullaBox = new System.Windows.Forms.ComboBox();
            this.policia1Box = new System.Windows.Forms.ComboBox();
            this.policia2Box = new System.Windows.Forms.ComboBox();
            this.horarioBox = new System.Windows.Forms.ComboBox();
            this.labelHorario = new System.Windows.Forms.Label();
            this.btnEditarPatrullas = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminarPatrullas = new System.Windows.Forms.Button();
            this.labelDia = new System.Windows.Forms.Label();
            this.DiaBox = new System.Windows.Forms.ComboBox();
            this.labelTitulo_Usuarios = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.textBoxBuscar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHorarios)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridHorarios
            // 
            this.dataGridHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHorarios.Location = new System.Drawing.Point(481, 128);
            this.dataGridHorarios.Name = "dataGridHorarios";
            this.dataGridHorarios.RowHeadersWidth = 62;
            this.dataGridHorarios.Size = new System.Drawing.Size(607, 521);
            this.dataGridHorarios.TabIndex = 0;
            // 
            // labelPatrulla
            // 
            this.labelPatrulla.AutoSize = true;
            this.labelPatrulla.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPatrulla.Location = new System.Drawing.Point(61, 109);
            this.labelPatrulla.Name = "labelPatrulla";
            this.labelPatrulla.Size = new System.Drawing.Size(46, 14);
            this.labelPatrulla.TabIndex = 1;
            this.labelPatrulla.Text = "Patrulla";
            // 
            // labelPolicia1
            // 
            this.labelPolicia1.AutoSize = true;
            this.labelPolicia1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPolicia1.Location = new System.Drawing.Point(61, 179);
            this.labelPolicia1.Name = "labelPolicia1";
            this.labelPolicia1.Size = new System.Drawing.Size(50, 14);
            this.labelPolicia1.TabIndex = 2;
            this.labelPolicia1.Text = "Policia 1";
            // 
            // labelPolicia2
            // 
            this.labelPolicia2.AutoSize = true;
            this.labelPolicia2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPolicia2.Location = new System.Drawing.Point(61, 242);
            this.labelPolicia2.Name = "labelPolicia2";
            this.labelPolicia2.Size = new System.Drawing.Size(50, 14);
            this.labelPolicia2.TabIndex = 3;
            this.labelPolicia2.Text = "Policia 2";
            // 
            // patrullaBox
            // 
            this.patrullaBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.patrullaBox.FormattingEnabled = true;
            this.patrullaBox.Items.AddRange(new object[] {
            "Patrulla 1",
            "Patrulla 2",
            "Patrulla 3",
            "Patrulla 4",
            "Patrulla 5",
            "Patrulla 6",
            "Patrulla 7"});
            this.patrullaBox.Location = new System.Drawing.Point(64, 127);
            this.patrullaBox.Name = "patrullaBox";
            this.patrullaBox.Size = new System.Drawing.Size(287, 21);
            this.patrullaBox.TabIndex = 4;
            // 
            // policia1Box
            // 
            this.policia1Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.policia1Box.FormattingEnabled = true;
            this.policia1Box.Items.AddRange(new object[] {
            "Romero Franco",
            "Fernandez Nahuel",
            "Gon Victoria",
            "Chamorro Esteban ",
            "Gomez Francisco",
            "Jimenez Nancy",
            "Romero Franco",
            "Juarez Luis",
            "Fernandez Pablo",
            "Diaz Martin",
            "Sosa Ariel",
            "Sosa Maximiliano",
            "Marques Miguel",
            "Acosta Lara",
            "",
            ""});
            this.policia1Box.Location = new System.Drawing.Point(64, 196);
            this.policia1Box.Name = "policia1Box";
            this.policia1Box.Size = new System.Drawing.Size(287, 21);
            this.policia1Box.TabIndex = 5;
            // 
            // policia2Box
            // 
            this.policia2Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.policia2Box.FormattingEnabled = true;
            this.policia2Box.Items.AddRange(new object[] {
            "Romero Franco",
            "Fernandez Nahuel",
            "Gon Victoria",
            "Chamorro Esteban ",
            "Gomez Francisco",
            "Jimenez Nancy",
            "Romero Franco",
            "Juarez Luis",
            "Fernandez Pablo",
            "Diaz Martin",
            "Sosa Ariel",
            "Sosa Maximiliano",
            "Marques Miguel",
            "Acosta Lara",
            ""});
            this.policia2Box.Location = new System.Drawing.Point(64, 260);
            this.policia2Box.Name = "policia2Box";
            this.policia2Box.Size = new System.Drawing.Size(287, 21);
            this.policia2Box.TabIndex = 6;
            // 
            // horarioBox
            // 
            this.horarioBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.horarioBox.FormattingEnabled = true;
            this.horarioBox.Items.AddRange(new object[] {
            "06:00 - 18:00",
            "18:00 - 06:00"});
            this.horarioBox.Location = new System.Drawing.Point(64, 325);
            this.horarioBox.Name = "horarioBox";
            this.horarioBox.Size = new System.Drawing.Size(287, 21);
            this.horarioBox.TabIndex = 7;
            // 
            // labelHorario
            // 
            this.labelHorario.AutoSize = true;
            this.labelHorario.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHorario.Location = new System.Drawing.Point(61, 307);
            this.labelHorario.Name = "labelHorario";
            this.labelHorario.Size = new System.Drawing.Size(45, 14);
            this.labelHorario.TabIndex = 8;
            this.labelHorario.Text = "Horario";
            // 
            // btnEditarPatrullas
            // 
            this.btnEditarPatrullas.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarPatrullas.Location = new System.Drawing.Point(93, 450);
            this.btnEditarPatrullas.Name = "btnEditarPatrullas";
            this.btnEditarPatrullas.Size = new System.Drawing.Size(111, 31);
            this.btnEditarPatrullas.TabIndex = 9;
            this.btnEditarPatrullas.Text = "Editar";
            this.btnEditarPatrullas.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(977, 89);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(111, 33);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEliminarPatrullas
            // 
            this.btnEliminarPatrullas.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarPatrullas.Location = new System.Drawing.Point(219, 450);
            this.btnEliminarPatrullas.Name = "btnEliminarPatrullas";
            this.btnEliminarPatrullas.Size = new System.Drawing.Size(111, 31);
            this.btnEliminarPatrullas.TabIndex = 11;
            this.btnEliminarPatrullas.Text = "Eliminar";
            this.btnEliminarPatrullas.UseVisualStyleBackColor = true;
            // 
            // labelDia
            // 
            this.labelDia.AutoSize = true;
            this.labelDia.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDia.Location = new System.Drawing.Point(61, 374);
            this.labelDia.Name = "labelDia";
            this.labelDia.Size = new System.Drawing.Size(23, 14);
            this.labelDia.TabIndex = 12;
            this.labelDia.Text = "Dia";
            // 
            // DiaBox
            // 
            this.DiaBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DiaBox.FormattingEnabled = true;
            this.DiaBox.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miercoles",
            "Jueves",
            "Viernes",
            "Sabado",
            "Domingo"});
            this.DiaBox.Location = new System.Drawing.Point(64, 391);
            this.DiaBox.Name = "DiaBox";
            this.DiaBox.Size = new System.Drawing.Size(287, 21);
            this.DiaBox.TabIndex = 13;
            this.DiaBox.SelectedIndexChanged += new System.EventHandler(this.DiaBox_SelectedIndexChanged);
            // 
            // labelTitulo_Usuarios
            // 
            this.labelTitulo_Usuarios.AutoSize = true;
            this.labelTitulo_Usuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo_Usuarios.Location = new System.Drawing.Point(45, 40);
            this.labelTitulo_Usuarios.Name = "labelTitulo_Usuarios";
            this.labelTitulo_Usuarios.Size = new System.Drawing.Size(340, 25);
            this.labelTitulo_Usuarios.TabIndex = 24;
            this.labelTitulo_Usuarios.Text = "Gestion de Planilla de Horarios";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(1121, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(78, 699);
            this.panel1.TabIndex = 26;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnEliminarPatrullas);
            this.panel2.Controls.Add(this.labelTitulo_Usuarios);
            this.panel2.Controls.Add(this.btnEditarPatrullas);
            this.panel2.Controls.Add(this.labelDia);
            this.panel2.Controls.Add(this.labelPatrulla);
            this.panel2.Controls.Add(this.patrullaBox);
            this.panel2.Controls.Add(this.policia1Box);
            this.panel2.Controls.Add(this.labelPolicia1);
            this.panel2.Controls.Add(this.policia2Box);
            this.panel2.Controls.Add(this.labelHorario);
            this.panel2.Controls.Add(this.labelPolicia2);
            this.panel2.Controls.Add(this.DiaBox);
            this.panel2.Controls.Add(this.horarioBox);
            this.panel2.Location = new System.Drawing.Point(45, 128);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(411, 521);
            this.panel2.TabIndex = 27;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(699, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 25);
            this.label1.TabIndex = 28;
            this.label1.Text = "Lista de Horarios";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(741, 102);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(97, 23);
            this.btnBuscar.TabIndex = 32;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // textBoxBuscar
            // 
            this.textBoxBuscar.Location = new System.Drawing.Point(481, 102);
            this.textBoxBuscar.Name = "textBoxBuscar";
            this.textBoxBuscar.Size = new System.Drawing.Size(254, 20);
            this.textBoxBuscar.TabIndex = 31;
            // 
            // UCPlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.textBoxBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.dataGridHorarios);
            this.Controls.Add(this.panel2);
            this.Name = "UCPlanilla";
            this.Size = new System.Drawing.Size(1162, 699);
            this.Load += new System.EventHandler(this.UCPlanilla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHorarios)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridHorarios;
        private System.Windows.Forms.Label labelPatrulla;
        private System.Windows.Forms.Label labelPolicia1;
        private System.Windows.Forms.Label labelPolicia2;
        private System.Windows.Forms.ComboBox patrullaBox;
        private System.Windows.Forms.ComboBox policia1Box;
        private System.Windows.Forms.ComboBox policia2Box;
        private System.Windows.Forms.ComboBox horarioBox;
        private System.Windows.Forms.Label labelHorario;
        private System.Windows.Forms.Button btnEditarPatrullas;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEliminarPatrullas;
        private System.Windows.Forms.Label labelDia;
        private System.Windows.Forms.ComboBox DiaBox;
        private System.Windows.Forms.Label labelTitulo_Usuarios;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox textBoxBuscar;
    }
}
