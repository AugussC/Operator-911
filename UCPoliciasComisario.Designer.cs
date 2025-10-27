namespace Operador_911
{
    partial class UCPoliciasComisario
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
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelApellido = new System.Windows.Forms.Label();
            this.labelDNI = new System.Windows.Forms.Label();
            this.textBoxDNI = new System.Windows.Forms.TextBox();
            this.labelTelefono = new System.Windows.Forms.Label();
            this.btnAgregarPolicia = new System.Windows.Forms.Button();
            this.btnEditarPolicia = new System.Windows.Forms.Button();
            this.btnEliminarPolicia = new System.Windows.Forms.Button();
            this.dataGridViewPolicias = new System.Windows.Forms.DataGridView();
            this.labelTitulo_Patrullas = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBoxGenero = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnPoliciasEliminado = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPolicias)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(33, 150);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(263, 20);
            this.textBoxNombre.TabIndex = 2;
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(33, 205);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(263, 20);
            this.textBoxApellido.TabIndex = 3;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre.Location = new System.Drawing.Point(31, 133);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(50, 14);
            this.labelNombre.TabIndex = 4;
            this.labelNombre.Text = "Nombre";
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelApellido.Location = new System.Drawing.Point(31, 187);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(49, 14);
            this.labelApellido.TabIndex = 5;
            this.labelApellido.Text = "Apellido";
            // 
            // labelDNI
            // 
            this.labelDNI.AutoSize = true;
            this.labelDNI.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDNI.Location = new System.Drawing.Point(31, 244);
            this.labelDNI.Name = "labelDNI";
            this.labelDNI.Size = new System.Drawing.Size(234, 14);
            this.labelDNI.TabIndex = 6;
            this.labelDNI.Text = "Documento Nacional de Indentidad (DNI)";
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Location = new System.Drawing.Point(33, 263);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.Size = new System.Drawing.Size(263, 20);
            this.textBoxDNI.TabIndex = 7;
            // 
            // labelTelefono
            // 
            this.labelTelefono.AutoSize = true;
            this.labelTelefono.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTelefono.Location = new System.Drawing.Point(31, 302);
            this.labelTelefono.Name = "labelTelefono";
            this.labelTelefono.Size = new System.Drawing.Size(47, 14);
            this.labelTelefono.TabIndex = 9;
            this.labelTelefono.Text = "Genero";
            // 
            // btnAgregarPolicia
            // 
            this.btnAgregarPolicia.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarPolicia.Location = new System.Drawing.Point(24, 408);
            this.btnAgregarPolicia.Name = "btnAgregarPolicia";
            this.btnAgregarPolicia.Size = new System.Drawing.Size(84, 30);
            this.btnAgregarPolicia.TabIndex = 10;
            this.btnAgregarPolicia.Text = "Agregar";
            this.btnAgregarPolicia.UseVisualStyleBackColor = true;
            this.btnAgregarPolicia.Click += new System.EventHandler(this.btnAgregarPolicia_Click);
            // 
            // btnEditarPolicia
            // 
            this.btnEditarPolicia.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarPolicia.Location = new System.Drawing.Point(121, 408);
            this.btnEditarPolicia.Name = "btnEditarPolicia";
            this.btnEditarPolicia.Size = new System.Drawing.Size(84, 30);
            this.btnEditarPolicia.TabIndex = 11;
            this.btnEditarPolicia.Text = "Editar";
            this.btnEditarPolicia.UseVisualStyleBackColor = true;
            this.btnEditarPolicia.Click += new System.EventHandler(this.btnEditarPolicia_Click);
            // 
            // btnEliminarPolicia
            // 
            this.btnEliminarPolicia.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarPolicia.Location = new System.Drawing.Point(220, 408);
            this.btnEliminarPolicia.Name = "btnEliminarPolicia";
            this.btnEliminarPolicia.Size = new System.Drawing.Size(84, 30);
            this.btnEliminarPolicia.TabIndex = 12;
            this.btnEliminarPolicia.Text = "Eliminar";
            this.btnEliminarPolicia.UseVisualStyleBackColor = true;
            this.btnEliminarPolicia.Click += new System.EventHandler(this.btnEliminarPolicia_Click);
            // 
            // dataGridViewPolicias
            // 
            this.dataGridViewPolicias.AllowUserToAddRows = false;
            this.dataGridViewPolicias.AllowUserToDeleteRows = false;
            this.dataGridViewPolicias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPolicias.Location = new System.Drawing.Point(407, 128);
            this.dataGridViewPolicias.Name = "dataGridViewPolicias";
            this.dataGridViewPolicias.RowHeadersVisible = false;
            this.dataGridViewPolicias.RowHeadersWidth = 62;
            this.dataGridViewPolicias.Size = new System.Drawing.Size(681, 521);
            this.dataGridViewPolicias.TabIndex = 13;
            this.dataGridViewPolicias.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPolicias_CellValueChanged);
            this.dataGridViewPolicias.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewPolicias_CurrentCellDirtyStateChanged);
            this.dataGridViewPolicias.SelectionChanged += new System.EventHandler(this.DataGridViewPolicias_SelectionChanged);
            // 
            // labelTitulo_Patrullas
            // 
            this.labelTitulo_Patrullas.AutoSize = true;
            this.labelTitulo_Patrullas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo_Patrullas.Location = new System.Drawing.Point(60, 68);
            this.labelTitulo_Patrullas.Name = "labelTitulo_Patrullas";
            this.labelTitulo_Patrullas.Size = new System.Drawing.Size(221, 25);
            this.labelTitulo_Patrullas.TabIndex = 24;
            this.labelTitulo_Patrullas.Text = "Administrar Policias";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(1117, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(78, 699);
            this.panel1.TabIndex = 26;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.comboBoxGenero);
            this.panel2.Controls.Add(this.labelTitulo_Patrullas);
            this.panel2.Controls.Add(this.labelNombre);
            this.panel2.Controls.Add(this.btnEliminarPolicia);
            this.panel2.Controls.Add(this.textBoxNombre);
            this.panel2.Controls.Add(this.btnEditarPolicia);
            this.panel2.Controls.Add(this.labelApellido);
            this.panel2.Controls.Add(this.btnAgregarPolicia);
            this.panel2.Controls.Add(this.textBoxApellido);
            this.panel2.Controls.Add(this.labelTelefono);
            this.panel2.Controls.Add(this.labelDNI);
            this.panel2.Controls.Add(this.textBoxDNI);
            this.panel2.Location = new System.Drawing.Point(45, 128);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(333, 521);
            this.panel2.TabIndex = 27;
            // 
            // comboBoxGenero
            // 
            this.comboBoxGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGenero.FormattingEnabled = true;
            this.comboBoxGenero.Location = new System.Drawing.Point(33, 318);
            this.comboBoxGenero.Name = "comboBoxGenero";
            this.comboBoxGenero.Size = new System.Drawing.Size(263, 21);
            this.comboBoxGenero.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(667, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 25);
            this.label1.TabIndex = 28;
            this.label1.Text = "Lista de Policias";
            // 
            // textBoxBuscar
            // 
            this.textBoxBuscar.Location = new System.Drawing.Point(428, 96);
            this.textBoxBuscar.Name = "textBoxBuscar";
            this.textBoxBuscar.Size = new System.Drawing.Size(320, 20);
            this.textBoxBuscar.TabIndex = 29;
            this.textBoxBuscar.TextChanged += new System.EventHandler(this.textBoxBuscar_TextChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(761, 93);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(97, 23);
            this.btnBuscar.TabIndex = 30;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnPoliciasEliminado
            // 
            this.btnPoliciasEliminado.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPoliciasEliminado.Location = new System.Drawing.Point(925, 86);
            this.btnPoliciasEliminado.Name = "btnPoliciasEliminado";
            this.btnPoliciasEliminado.Size = new System.Drawing.Size(149, 36);
            this.btnPoliciasEliminado.TabIndex = 37;
            this.btnPoliciasEliminado.Text = "Ver Eliminados";
            this.btnPoliciasEliminado.UseVisualStyleBackColor = true;
            this.btnPoliciasEliminado.Click += new System.EventHandler(this.btnPoliciasEliminado_Click);
            // 
            // UCPoliciasComisario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPoliciasEliminado);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.textBoxBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewPolicias);
            this.Controls.Add(this.panel2);
            this.Name = "UCPoliciasComisario";
            this.Size = new System.Drawing.Size(1162, 699);
            this.Load += new System.EventHandler(this.UCPoliciasComisario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPolicias)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.Label labelDNI;
        private System.Windows.Forms.TextBox textBoxDNI;
        private System.Windows.Forms.Label labelTelefono;
        private System.Windows.Forms.Button btnAgregarPolicia;
        private System.Windows.Forms.Button btnEditarPolicia;
        private System.Windows.Forms.Button btnEliminarPolicia;
        private System.Windows.Forms.DataGridView dataGridViewPolicias;
        private System.Windows.Forms.Label labelTitulo_Patrullas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnPoliciasEliminado;
        private System.Windows.Forms.ComboBox comboBoxGenero;
    }
}
