namespace Operador_911
{
    partial class UCListaUsuarios
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
            this.labelPass = new System.Windows.Forms.Label();
            this.labelRol = new System.Windows.Forms.Label();
            this.textBoxDNI = new System.Windows.Forms.TextBox();
            this.labelDNI = new System.Windows.Forms.Label();
            this.labelAdd_user = new System.Windows.Forms.Label();
            this.textBoxContraseña = new System.Windows.Forms.TextBox();
            this.btnEliminarUsuario = new System.Windows.Forms.Button();
            this.btnEditarUsuario = new System.Windows.Forms.Button();
            this.btnAgregarUsuario = new System.Windows.Forms.Button();
            this.dataGrid_Usuarios = new System.Windows.Forms.DataGridView();
            this.Nro_Vehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_Patrulla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelTitulo_Usuarios = new System.Windows.Forms.Label();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.labelApellido = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.comboBoxRol = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Usuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Location = new System.Drawing.Point(96, 603);
            this.labelPass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(84, 20);
            this.labelPass.TabIndex = 14;
            this.labelPass.Text = "Contraeña";
            // 
            // labelRol
            // 
            this.labelRol.AutoSize = true;
            this.labelRol.Location = new System.Drawing.Point(95, 697);
            this.labelRol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRol.Name = "labelRol";
            this.labelRol.Size = new System.Drawing.Size(33, 20);
            this.labelRol.TabIndex = 12;
            this.labelRol.Text = "Rol";
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Location = new System.Drawing.Point(96, 544);
            this.textBoxDNI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.Size = new System.Drawing.Size(478, 26);
            this.textBoxDNI.TabIndex = 11;
            // 
            // labelDNI
            // 
            this.labelDNI.AutoSize = true;
            this.labelDNI.Location = new System.Drawing.Point(93, 519);
            this.labelDNI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDNI.Name = "labelDNI";
            this.labelDNI.Size = new System.Drawing.Size(301, 20);
            this.labelDNI.TabIndex = 10;
            this.labelDNI.Text = "Documento Nacional de Indentidad (DNI)";
            this.labelDNI.Click += new System.EventHandler(this.labelCodigo_Click);
            // 
            // labelAdd_user
            // 
            this.labelAdd_user.AutoSize = true;
            this.labelAdd_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdd_user.Location = new System.Drawing.Point(155, 255);
            this.labelAdd_user.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAdd_user.Name = "labelAdd_user";
            this.labelAdd_user.Size = new System.Drawing.Size(374, 37);
            this.labelAdd_user.TabIndex = 16;
            this.labelAdd_user.Text = "Agregar Nuevo Usuario";
            this.labelAdd_user.Click += new System.EventHandler(this.labelTitulo_Click);
            // 
            // textBoxContraseña
            // 
            this.textBoxContraseña.Location = new System.Drawing.Point(97, 628);
            this.textBoxContraseña.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxContraseña.Name = "textBoxContraseña";
            this.textBoxContraseña.Size = new System.Drawing.Size(478, 26);
            this.textBoxContraseña.TabIndex = 18;
            // 
            // btnEliminarUsuario
            // 
            this.btnEliminarUsuario.Location = new System.Drawing.Point(425, 842);
            this.btnEliminarUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.Size = new System.Drawing.Size(126, 46);
            this.btnEliminarUsuario.TabIndex = 21;
            this.btnEliminarUsuario.Text = "Eliminar";
            this.btnEliminarUsuario.UseVisualStyleBackColor = true;
            // 
            // btnEditarUsuario
            // 
            this.btnEditarUsuario.Location = new System.Drawing.Point(275, 842);
            this.btnEditarUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditarUsuario.Name = "btnEditarUsuario";
            this.btnEditarUsuario.Size = new System.Drawing.Size(126, 46);
            this.btnEditarUsuario.TabIndex = 20;
            this.btnEditarUsuario.Text = "Editar";
            this.btnEditarUsuario.UseVisualStyleBackColor = true;
            // 
            // btnAgregarUsuario
            // 
            this.btnAgregarUsuario.Location = new System.Drawing.Point(123, 842);
            this.btnAgregarUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAgregarUsuario.Name = "btnAgregarUsuario";
            this.btnAgregarUsuario.Size = new System.Drawing.Size(126, 46);
            this.btnAgregarUsuario.TabIndex = 19;
            this.btnAgregarUsuario.Text = "Agregar";
            this.btnAgregarUsuario.UseVisualStyleBackColor = true;
            // 
            // dataGrid_Usuarios
            // 
            this.dataGrid_Usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Usuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nro_Vehiculo,
            this.Tipo_Patrulla,
            this.Column4,
            this.Column2,
            this.Column3,
            this.Estado,
            this.columnaTelefono});
            this.dataGrid_Usuarios.Location = new System.Drawing.Point(680, 197);
            this.dataGrid_Usuarios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGrid_Usuarios.Name = "dataGrid_Usuarios";
            this.dataGrid_Usuarios.RowHeadersWidth = 62;
            this.dataGrid_Usuarios.Size = new System.Drawing.Size(939, 802);
            this.dataGrid_Usuarios.TabIndex = 22;
            this.dataGrid_Usuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Nro_Vehiculo
            // 
            this.Nro_Vehiculo.HeaderText = "id_usuario";
            this.Nro_Vehiculo.MinimumWidth = 8;
            this.Nro_Vehiculo.Name = "Nro_Vehiculo";
            this.Nro_Vehiculo.Width = 125;
            // 
            // Tipo_Patrulla
            // 
            this.Tipo_Patrulla.HeaderText = "Rol";
            this.Tipo_Patrulla.MinimumWidth = 8;
            this.Tipo_Patrulla.Name = "Tipo_Patrulla";
            this.Tipo_Patrulla.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "NombreUsuario";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Contraseña";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Nombre y Apellido";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Correo";
            this.Estado.MinimumWidth = 8;
            this.Estado.Name = "Estado";
            this.Estado.Width = 125;
            // 
            // columnaTelefono
            // 
            this.columnaTelefono.HeaderText = "Telefono";
            this.columnaTelefono.MinimumWidth = 8;
            this.columnaTelefono.Name = "columnaTelefono";
            this.columnaTelefono.Width = 125;
            // 
            // labelTitulo_Usuarios
            // 
            this.labelTitulo_Usuarios.AutoSize = true;
            this.labelTitulo_Usuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo_Usuarios.Location = new System.Drawing.Point(967, 79);
            this.labelTitulo_Usuarios.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitulo_Usuarios.Name = "labelTitulo_Usuarios";
            this.labelTitulo_Usuarios.Size = new System.Drawing.Size(337, 37);
            this.labelTitulo_Usuarios.TabIndex = 23;
            this.labelTitulo_Usuarios.Text = "Administrar Usuarios";
            this.labelTitulo_Usuarios.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(96, 456);
            this.textBoxApellido.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(478, 26);
            this.textBoxApellido.TabIndex = 27;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(97, 373);
            this.textBoxNombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(478, 26);
            this.textBoxNombre.TabIndex = 26;
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Location = new System.Drawing.Point(92, 431);
            this.labelApellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(65, 20);
            this.labelApellido.TabIndex = 25;
            this.labelApellido.Text = "Apellido";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(92, 348);
            this.labelNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(65, 20);
            this.labelNombre.TabIndex = 24;
            this.labelNombre.Text = "Nombre";
            this.labelNombre.Click += new System.EventHandler(this.label3_Click);
            // 
            // comboBoxRol
            // 
            this.comboBoxRol.FormattingEnabled = true;
            this.comboBoxRol.Location = new System.Drawing.Point(97, 720);
            this.comboBoxRol.Name = "comboBoxRol";
            this.comboBoxRol.Size = new System.Drawing.Size(478, 28);
            this.comboBoxRol.TabIndex = 28;
            // 
            // UCListaUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.comboBoxRol);
            this.Controls.Add(this.textBoxApellido);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.labelApellido);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.labelTitulo_Usuarios);
            this.Controls.Add(this.dataGrid_Usuarios);
            this.Controls.Add(this.btnEliminarUsuario);
            this.Controls.Add(this.btnEditarUsuario);
            this.Controls.Add(this.btnAgregarUsuario);
            this.Controls.Add(this.textBoxContraseña);
            this.Controls.Add(this.labelAdd_user);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.labelRol);
            this.Controls.Add(this.textBoxDNI);
            this.Controls.Add(this.labelDNI);
            this.Name = "UCListaUsuarios";
            this.Size = new System.Drawing.Size(1743, 1075);
            this.Load += new System.EventHandler(this.UCListaUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Usuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.Label labelRol;
        private System.Windows.Forms.TextBox textBoxDNI;
        private System.Windows.Forms.Label labelDNI;
        private System.Windows.Forms.Label labelAdd_user;
        private System.Windows.Forms.TextBox textBoxContraseña;
        private System.Windows.Forms.Button btnEliminarUsuario;
        private System.Windows.Forms.Button btnEditarUsuario;
        private System.Windows.Forms.Button btnAgregarUsuario;
        private System.Windows.Forms.DataGridView dataGrid_Usuarios;
        private System.Windows.Forms.Label labelTitulo_Usuarios;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nro_Vehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_Patrulla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaTelefono;
        private System.Windows.Forms.ComboBox comboBoxRol;
    }
}
