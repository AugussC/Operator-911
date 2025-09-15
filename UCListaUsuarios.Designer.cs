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
            this.dataGridUsuarios = new System.Windows.Forms.DataGridView();
            this.labelTitulo_Usuarios = new System.Windows.Forms.Label();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.labelApellido = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.comboBoxRol = new System.Windows.Forms.ComboBox();
            this.textBoxCorreo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxConfirmarContraseña = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUsuarioEliminado = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBoxContraseña1 = new System.Windows.Forms.CheckBox();
            this.checkBoxContraseña2 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsuarios)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Location = new System.Drawing.Point(72, 416);
            this.labelPass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(92, 20);
            this.labelPass.TabIndex = 14;
            this.labelPass.Text = "Contraseña";
            // 
            // labelRol
            // 
            this.labelRol.AutoSize = true;
            this.labelRol.Location = new System.Drawing.Point(72, 631);
            this.labelRol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRol.Name = "labelRol";
            this.labelRol.Size = new System.Drawing.Size(33, 20);
            this.labelRol.TabIndex = 12;
            this.labelRol.Text = "Rol";
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Location = new System.Drawing.Point(67, 282);
            this.textBoxDNI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.Size = new System.Drawing.Size(478, 26);
            this.textBoxDNI.TabIndex = 11;
            // 
            // labelDNI
            // 
            this.labelDNI.AutoSize = true;
            this.labelDNI.Location = new System.Drawing.Point(72, 257);
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
            this.labelAdd_user.Location = new System.Drawing.Point(110, 37);
            this.labelAdd_user.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAdd_user.Name = "labelAdd_user";
            this.labelAdd_user.Size = new System.Drawing.Size(374, 37);
            this.labelAdd_user.TabIndex = 16;
            this.labelAdd_user.Text = "Agregar Nuevo Usuario";
            this.labelAdd_user.Click += new System.EventHandler(this.labelTitulo_Click);
            // 
            // textBoxContraseña
            // 
            this.textBoxContraseña.Location = new System.Drawing.Point(67, 441);
            this.textBoxContraseña.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxContraseña.Name = "textBoxContraseña";
            this.textBoxContraseña.Size = new System.Drawing.Size(478, 26);
            this.textBoxContraseña.TabIndex = 18;
            this.textBoxContraseña.UseSystemPasswordChar = true;
            // 
            // btnEliminarUsuario
            // 
            this.btnEliminarUsuario.Location = new System.Drawing.Point(385, 718);
            this.btnEliminarUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.Size = new System.Drawing.Size(126, 46);
            this.btnEliminarUsuario.TabIndex = 21;
            this.btnEliminarUsuario.Text = "Eliminar";
            this.btnEliminarUsuario.UseVisualStyleBackColor = true;
            this.btnEliminarUsuario.Click += new System.EventHandler(this.btnEliminarUsuario_Click);
            // 
            // btnEditarUsuario
            // 
            this.btnEditarUsuario.Location = new System.Drawing.Point(238, 718);
            this.btnEditarUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditarUsuario.Name = "btnEditarUsuario";
            this.btnEditarUsuario.Size = new System.Drawing.Size(126, 46);
            this.btnEditarUsuario.TabIndex = 20;
            this.btnEditarUsuario.Text = "Editar";
            this.btnEditarUsuario.UseVisualStyleBackColor = true;
            // 
            // btnAgregarUsuario
            // 
            this.btnAgregarUsuario.Location = new System.Drawing.Point(85, 718);
            this.btnAgregarUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAgregarUsuario.Name = "btnAgregarUsuario";
            this.btnAgregarUsuario.Size = new System.Drawing.Size(126, 46);
            this.btnAgregarUsuario.TabIndex = 19;
            this.btnAgregarUsuario.Text = "Agregar";
            this.btnAgregarUsuario.UseVisualStyleBackColor = true;
            this.btnAgregarUsuario.Click += new System.EventHandler(this.btnAgregarUsuario_Click);
            // 
            // dataGridUsuarios
            // 
            this.dataGridUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUsuarios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridUsuarios.Location = new System.Drawing.Point(721, 197);
            this.dataGridUsuarios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridUsuarios.Name = "dataGridUsuarios";
            this.dataGridUsuarios.RowHeadersWidth = 62;
            this.dataGridUsuarios.Size = new System.Drawing.Size(911, 802);
            this.dataGridUsuarios.TabIndex = 22;
            this.dataGridUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridUsuarios_CellClick);
            this.dataGridUsuarios.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridUsuarios_CellValueChanged);
            this.dataGridUsuarios.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridUsuarios_CurrentCellDirtyStateChanged);
            this.dataGridUsuarios.SelectionChanged += new System.EventHandler(this.dataGridUsuarios_SelectionChanged);
            // 
            // labelTitulo_Usuarios
            // 
            this.labelTitulo_Usuarios.AutoSize = true;
            this.labelTitulo_Usuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo_Usuarios.Location = new System.Drawing.Point(990, 136);
            this.labelTitulo_Usuarios.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitulo_Usuarios.Name = "labelTitulo_Usuarios";
            this.labelTitulo_Usuarios.Size = new System.Drawing.Size(337, 37);
            this.labelTitulo_Usuarios.TabIndex = 23;
            this.labelTitulo_Usuarios.Text = "Administrar Usuarios";
            this.labelTitulo_Usuarios.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(67, 203);
            this.textBoxApellido.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(478, 26);
            this.textBoxApellido.TabIndex = 27;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(67, 126);
            this.textBoxNombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(478, 26);
            this.textBoxNombre.TabIndex = 26;
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Location = new System.Drawing.Point(72, 178);
            this.labelApellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(65, 20);
            this.labelApellido.TabIndex = 25;
            this.labelApellido.Text = "Apellido";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(72, 101);
            this.labelNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(65, 20);
            this.labelNombre.TabIndex = 24;
            this.labelNombre.Text = "Nombre";
            this.labelNombre.Click += new System.EventHandler(this.label3_Click);
            // 
            // comboBoxRol
            // 
            this.comboBoxRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRol.FormattingEnabled = true;
            this.comboBoxRol.Items.AddRange(new object[] {
            "Jefe Operador",
            "Operador",
            "Comisario"});
            this.comboBoxRol.Location = new System.Drawing.Point(67, 654);
            this.comboBoxRol.Name = "comboBoxRol";
            this.comboBoxRol.Size = new System.Drawing.Size(478, 28);
            this.comboBoxRol.TabIndex = 28;
            // 
            // textBoxCorreo
            // 
            this.textBoxCorreo.Location = new System.Drawing.Point(67, 360);
            this.textBoxCorreo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCorreo.Name = "textBoxCorreo";
            this.textBoxCorreo.Size = new System.Drawing.Size(478, 26);
            this.textBoxCorreo.TabIndex = 30;
            this.textBoxCorreo.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 335);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Correo";
            // 
            // textBoxConfirmarContraseña
            // 
            this.textBoxConfirmarContraseña.Location = new System.Drawing.Point(67, 550);
            this.textBoxConfirmarContraseña.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxConfirmarContraseña.Name = "textBoxConfirmarContraseña";
            this.textBoxConfirmarContraseña.Size = new System.Drawing.Size(478, 26);
            this.textBoxConfirmarContraseña.TabIndex = 32;
            this.textBoxConfirmarContraseña.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 525);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Confirmar Contraseña";
            // 
            // btnUsuarioEliminado
            // 
            this.btnUsuarioEliminado.Location = new System.Drawing.Point(1408, 132);
            this.btnUsuarioEliminado.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUsuarioEliminado.Name = "btnUsuarioEliminado";
            this.btnUsuarioEliminado.Size = new System.Drawing.Size(224, 55);
            this.btnUsuarioEliminado.TabIndex = 35;
            this.btnUsuarioEliminado.Text = "Ver Usuarios Eliminados";
            this.btnUsuarioEliminado.UseVisualStyleBackColor = true;
            this.btnUsuarioEliminado.Click += new System.EventHandler(this.btnUsuarioEliminado_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(1676, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(117, 1075);
            this.panel1.TabIndex = 36;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.checkBoxContraseña2);
            this.panel2.Controls.Add(this.checkBoxContraseña1);
            this.panel2.Controls.Add(this.labelAdd_user);
            this.panel2.Controls.Add(this.labelNombre);
            this.panel2.Controls.Add(this.textBoxConfirmarContraseña);
            this.panel2.Controls.Add(this.textBoxCorreo);
            this.panel2.Controls.Add(this.textBoxContraseña);
            this.panel2.Controls.Add(this.textBoxApellido);
            this.panel2.Controls.Add(this.comboBoxRol);
            this.panel2.Controls.Add(this.textBoxNombre);
            this.panel2.Controls.Add(this.textBoxDNI);
            this.panel2.Controls.Add(this.labelApellido);
            this.panel2.Controls.Add(this.labelDNI);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnEliminarUsuario);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnEditarUsuario);
            this.panel2.Controls.Add(this.labelPass);
            this.panel2.Controls.Add(this.btnAgregarUsuario);
            this.panel2.Controls.Add(this.labelRol);
            this.panel2.Location = new System.Drawing.Point(68, 197);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(616, 802);
            this.panel2.TabIndex = 37;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // checkBoxContraseña1
            // 
            this.checkBoxContraseña1.AutoSize = true;
            this.checkBoxContraseña1.Location = new System.Drawing.Point(76, 475);
            this.checkBoxContraseña1.Name = "checkBoxContraseña1";
            this.checkBoxContraseña1.Size = new System.Drawing.Size(176, 24);
            this.checkBoxContraseña1.TabIndex = 35;
            this.checkBoxContraseña1.Text = "Mostrar Contraseña";
            this.checkBoxContraseña1.UseVisualStyleBackColor = true;
            this.checkBoxContraseña1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBoxContraseña2
            // 
            this.checkBoxContraseña2.AutoSize = true;
            this.checkBoxContraseña2.Location = new System.Drawing.Point(76, 584);
            this.checkBoxContraseña2.Name = "checkBoxContraseña2";
            this.checkBoxContraseña2.Size = new System.Drawing.Size(176, 24);
            this.checkBoxContraseña2.TabIndex = 36;
            this.checkBoxContraseña2.Text = "Mostrar Contraseña";
            this.checkBoxContraseña2.UseVisualStyleBackColor = true;
            this.checkBoxContraseña2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // UCListaUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnUsuarioEliminado);
            this.Controls.Add(this.labelTitulo_Usuarios);
            this.Controls.Add(this.dataGridUsuarios);
            this.Controls.Add(this.panel2);
            this.Name = "UCListaUsuarios";
            this.Size = new System.Drawing.Size(1743, 1075);
            this.Load += new System.EventHandler(this.UCListaUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsuarios)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.DataGridView dataGridUsuarios;
        private System.Windows.Forms.Label labelTitulo_Usuarios;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.ComboBox comboBoxRol;
        private System.Windows.Forms.TextBox textBoxCorreo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxConfirmarContraseña;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUsuarioEliminado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBoxContraseña2;
        private System.Windows.Forms.CheckBox checkBoxContraseña1;
    }
}
