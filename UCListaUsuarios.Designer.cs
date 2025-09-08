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
            this.labelCod = new System.Windows.Forms.Label();
            this.textNroVehiculo = new System.Windows.Forms.TextBox();
            this.labelCorreo = new System.Windows.Forms.Label();
            this.labelAdd_user = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnEliminarUsuario = new System.Windows.Forms.Button();
            this.btnEditarUsuario = new System.Windows.Forms.Button();
            this.btnAgregarUsuario = new System.Windows.Forms.Button();
            this.dataGrid_Usuarios = new System.Windows.Forms.DataGridView();
            this.labelTitulo_Usuarios = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.labelDni = new System.Windows.Forms.Label();
            this.labelNombyAp = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.labelTel = new System.Windows.Forms.Label();
            this.Nro_Vehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_Patrulla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Usuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Location = new System.Drawing.Point(95, 721);
            this.labelPass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(84, 20);
            this.labelPass.TabIndex = 14;
            this.labelPass.Text = "Contraeña";
            // 
            // labelCod
            // 
            this.labelCod.AutoSize = true;
            this.labelCod.Location = new System.Drawing.Point(94, 625);
            this.labelCod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCod.Name = "labelCod";
            this.labelCod.Size = new System.Drawing.Size(179, 20);
            this.labelCod.TabIndex = 12;
            this.labelCod.Text = "Codigo de Identificacion";
            // 
            // textNroVehiculo
            // 
            this.textNroVehiculo.Location = new System.Drawing.Point(96, 554);
            this.textNroVehiculo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textNroVehiculo.Name = "textNroVehiculo";
            this.textNroVehiculo.Size = new System.Drawing.Size(478, 26);
            this.textNroVehiculo.TabIndex = 11;
            // 
            // labelCorreo
            // 
            this.labelCorreo.AutoSize = true;
            this.labelCorreo.Location = new System.Drawing.Point(93, 519);
            this.labelCorreo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCorreo.Name = "labelCorreo";
            this.labelCorreo.Size = new System.Drawing.Size(140, 20);
            this.labelCorreo.TabIndex = 10;
            this.labelCorreo.Text = "Correo Electronico";
            this.labelCorreo.Click += new System.EventHandler(this.labelCodigo_Click);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(99, 650);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(478, 26);
            this.textBox1.TabIndex = 17;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(100, 746);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(478, 26);
            this.textBox2.TabIndex = 18;
            // 
            // btnEliminarUsuario
            // 
            this.btnEliminarUsuario.Location = new System.Drawing.Point(422, 890);
            this.btnEliminarUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.Size = new System.Drawing.Size(126, 46);
            this.btnEliminarUsuario.TabIndex = 21;
            this.btnEliminarUsuario.Text = "Eliminar";
            this.btnEliminarUsuario.UseVisualStyleBackColor = true;
            // 
            // btnEditarUsuario
            // 
            this.btnEditarUsuario.Location = new System.Drawing.Point(272, 890);
            this.btnEditarUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditarUsuario.Name = "btnEditarUsuario";
            this.btnEditarUsuario.Size = new System.Drawing.Size(126, 46);
            this.btnEditarUsuario.TabIndex = 20;
            this.btnEditarUsuario.Text = "Editar";
            this.btnEditarUsuario.UseVisualStyleBackColor = true;
            // 
            // btnAgregarUsuario
            // 
            this.btnAgregarUsuario.Location = new System.Drawing.Point(120, 890);
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
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(97, 456);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(478, 26);
            this.textBox3.TabIndex = 27;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(97, 373);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(478, 26);
            this.textBox4.TabIndex = 26;
            // 
            // labelDni
            // 
            this.labelDni.AutoSize = true;
            this.labelDni.Location = new System.Drawing.Point(92, 431);
            this.labelDni.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDni.Name = "labelDni";
            this.labelDni.Size = new System.Drawing.Size(37, 20);
            this.labelDni.TabIndex = 25;
            this.labelDni.Text = "DNI";
            // 
            // labelNombyAp
            // 
            this.labelNombyAp.AutoSize = true;
            this.labelNombyAp.Location = new System.Drawing.Point(92, 348);
            this.labelNombyAp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNombyAp.Name = "labelNombyAp";
            this.labelNombyAp.Size = new System.Drawing.Size(136, 20);
            this.labelNombyAp.TabIndex = 24;
            this.labelNombyAp.Text = "Nombre y Apellido";
            this.labelNombyAp.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(100, 836);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(478, 26);
            this.textBox5.TabIndex = 29;
            // 
            // labelTel
            // 
            this.labelTel.AutoSize = true;
            this.labelTel.Location = new System.Drawing.Point(95, 811);
            this.labelTel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTel.Name = "labelTel";
            this.labelTel.Size = new System.Drawing.Size(71, 20);
            this.labelTel.TabIndex = 28;
            this.labelTel.Text = "Telefono";
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
            // UCListaUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.labelTel);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.labelDni);
            this.Controls.Add(this.labelNombyAp);
            this.Controls.Add(this.labelTitulo_Usuarios);
            this.Controls.Add(this.dataGrid_Usuarios);
            this.Controls.Add(this.btnEliminarUsuario);
            this.Controls.Add(this.btnEditarUsuario);
            this.Controls.Add(this.btnAgregarUsuario);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelAdd_user);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.labelCod);
            this.Controls.Add(this.textNroVehiculo);
            this.Controls.Add(this.labelCorreo);
            this.Name = "UCListaUsuarios";
            this.Size = new System.Drawing.Size(1743, 1075);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Usuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.Label labelCod;
        private System.Windows.Forms.TextBox textNroVehiculo;
        private System.Windows.Forms.Label labelCorreo;
        private System.Windows.Forms.Label labelAdd_user;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnEliminarUsuario;
        private System.Windows.Forms.Button btnEditarUsuario;
        private System.Windows.Forms.Button btnAgregarUsuario;
        private System.Windows.Forms.DataGridView dataGrid_Usuarios;
        private System.Windows.Forms.Label labelTitulo_Usuarios;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label labelDni;
        private System.Windows.Forms.Label labelNombyAp;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label labelTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nro_Vehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_Patrulla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaTelefono;
    }
}
