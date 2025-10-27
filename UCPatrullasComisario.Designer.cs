namespace Operador_911
{
    partial class UCPatrullasComisario
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
            this.labelCodigo = new System.Windows.Forms.Label();
            this.btnAgregarPatrulla = new System.Windows.Forms.Button();
            this.btnEditarPatrulla = new System.Windows.Forms.Button();
            this.btnEliminarPatrulla = new System.Windows.Forms.Button();
            this.textNroVehiculo = new System.Windows.Forms.TextBox();
            this.labelTipo = new System.Windows.Forms.Label();
            this.TipoVehiculoBox = new System.Windows.Forms.ComboBox();
            this.labelEstado = new System.Windows.Forms.Label();
            this.EstadoVehiculoBox = new System.Windows.Forms.ComboBox();
            this.labelTitulo_Vehiculos = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.textBoxBuscar = new System.Windows.Forms.TextBox();
            this.btnVehiculosEliminado = new System.Windows.Forms.Button();
            this.dataGridViewPatrullas = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatrullas)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCodigo
            // 
            this.labelCodigo.AutoSize = true;
            this.labelCodigo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCodigo.Location = new System.Drawing.Point(46, 260);
            this.labelCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCodigo.Name = "labelCodigo";
            this.labelCodigo.Size = new System.Drawing.Size(110, 22);
            this.labelCodigo.TabIndex = 1;
            this.labelCodigo.Text = "Nro Vehiculo";
            // 
            // btnAgregarPatrulla
            // 
            this.btnAgregarPatrulla.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarPatrulla.Location = new System.Drawing.Point(41, 614);
            this.btnAgregarPatrulla.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAgregarPatrulla.Name = "btnAgregarPatrulla";
            this.btnAgregarPatrulla.Size = new System.Drawing.Size(126, 46);
            this.btnAgregarPatrulla.TabIndex = 2;
            this.btnAgregarPatrulla.Text = "Agregar";
            this.btnAgregarPatrulla.UseVisualStyleBackColor = true;
            this.btnAgregarPatrulla.Click += new System.EventHandler(this.btnAgregarPatrulla_Click);
            // 
            // btnEditarPatrulla
            // 
            this.btnEditarPatrulla.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarPatrulla.Location = new System.Drawing.Point(185, 614);
            this.btnEditarPatrulla.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditarPatrulla.Name = "btnEditarPatrulla";
            this.btnEditarPatrulla.Size = new System.Drawing.Size(126, 46);
            this.btnEditarPatrulla.TabIndex = 3;
            this.btnEditarPatrulla.Text = "Editar";
            this.btnEditarPatrulla.UseVisualStyleBackColor = true;
            this.btnEditarPatrulla.Click += new System.EventHandler(this.btnEditarPatrulla_Click);
            // 
            // btnEliminarPatrulla
            // 
            this.btnEliminarPatrulla.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarPatrulla.Location = new System.Drawing.Point(327, 614);
            this.btnEliminarPatrulla.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEliminarPatrulla.Name = "btnEliminarPatrulla";
            this.btnEliminarPatrulla.Size = new System.Drawing.Size(126, 46);
            this.btnEliminarPatrulla.TabIndex = 4;
            this.btnEliminarPatrulla.Text = "Eliminar";
            this.btnEliminarPatrulla.UseVisualStyleBackColor = true;
            this.btnEliminarPatrulla.Click += new System.EventHandler(this.btnEliminarPatrulla_Click);
            // 
            // textNroVehiculo
            // 
            this.textNroVehiculo.Location = new System.Drawing.Point(51, 286);
            this.textNroVehiculo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textNroVehiculo.Name = "textNroVehiculo";
            this.textNroVehiculo.Size = new System.Drawing.Size(393, 26);
            this.textNroVehiculo.TabIndex = 5;
            // 
            // labelTipo
            // 
            this.labelTipo.AutoSize = true;
            this.labelTipo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipo.Location = new System.Drawing.Point(46, 352);
            this.labelTipo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTipo.Name = "labelTipo";
            this.labelTipo.Size = new System.Drawing.Size(45, 22);
            this.labelTipo.TabIndex = 6;
            this.labelTipo.Text = "Tipo";
            // 
            // TipoVehiculoBox
            // 
            this.TipoVehiculoBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoVehiculoBox.FormattingEnabled = true;
            this.TipoVehiculoBox.Items.AddRange(new object[] {
            "Auto",
            "Moto"});
            this.TipoVehiculoBox.Location = new System.Drawing.Point(51, 379);
            this.TipoVehiculoBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TipoVehiculoBox.Name = "TipoVehiculoBox";
            this.TipoVehiculoBox.Size = new System.Drawing.Size(393, 28);
            this.TipoVehiculoBox.TabIndex = 7;
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstado.Location = new System.Drawing.Point(46, 439);
            this.labelEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(63, 22);
            this.labelEstado.TabIndex = 8;
            this.labelEstado.Text = "Estado";
            // 
            // EstadoVehiculoBox
            // 
            this.EstadoVehiculoBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EstadoVehiculoBox.FormattingEnabled = true;
            this.EstadoVehiculoBox.Items.AddRange(new object[] {
            "En Servicio",
            "En Base"});
            this.EstadoVehiculoBox.Location = new System.Drawing.Point(51, 466);
            this.EstadoVehiculoBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EstadoVehiculoBox.Name = "EstadoVehiculoBox";
            this.EstadoVehiculoBox.Size = new System.Drawing.Size(393, 28);
            this.EstadoVehiculoBox.TabIndex = 9;
            // 
            // labelTitulo_Vehiculos
            // 
            this.labelTitulo_Vehiculos.AutoSize = true;
            this.labelTitulo_Vehiculos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo_Vehiculos.Location = new System.Drawing.Point(71, 131);
            this.labelTitulo_Vehiculos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitulo_Vehiculos.Name = "labelTitulo_Vehiculos";
            this.labelTitulo_Vehiculos.Size = new System.Drawing.Size(350, 37);
            this.labelTitulo_Vehiculos.TabIndex = 24;
            this.labelTitulo_Vehiculos.Text = "Administrar Vehiculos";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(1676, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(117, 1075);
            this.panel1.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.labelTitulo_Vehiculos);
            this.panel2.Controls.Add(this.btnEliminarPatrulla);
            this.panel2.Controls.Add(this.TipoVehiculoBox);
            this.panel2.Controls.Add(this.btnEditarPatrulla);
            this.panel2.Controls.Add(this.EstadoVehiculoBox);
            this.panel2.Controls.Add(this.btnAgregarPatrulla);
            this.panel2.Controls.Add(this.textNroVehiculo);
            this.panel2.Controls.Add(this.labelEstado);
            this.panel2.Controls.Add(this.labelCodigo);
            this.panel2.Controls.Add(this.labelTipo);
            this.panel2.Location = new System.Drawing.Point(68, 197);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(499, 802);
            this.panel2.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1000, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 37);
            this.label1.TabIndex = 27;
            this.label1.Text = "Lista de Vehiculos";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(1142, 143);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(146, 35);
            this.btnBuscar.TabIndex = 32;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // textBoxBuscar
            // 
            this.textBoxBuscar.Location = new System.Drawing.Point(642, 147);
            this.textBoxBuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxBuscar.Name = "textBoxBuscar";
            this.textBoxBuscar.Size = new System.Drawing.Size(478, 26);
            this.textBoxBuscar.TabIndex = 31;
            this.textBoxBuscar.TextChanged += new System.EventHandler(this.textBoxBuscar_TextChanged);
            // 
            // btnVehiculosEliminado
            // 
            this.btnVehiculosEliminado.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVehiculosEliminado.Location = new System.Drawing.Point(1408, 134);
            this.btnVehiculosEliminado.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnVehiculosEliminado.Name = "btnVehiculosEliminado";
            this.btnVehiculosEliminado.Size = new System.Drawing.Size(224, 55);
            this.btnVehiculosEliminado.TabIndex = 36;
            this.btnVehiculosEliminado.Text = "Ver Eliminados";
            this.btnVehiculosEliminado.UseVisualStyleBackColor = true;
            this.btnVehiculosEliminado.Click += new System.EventHandler(this.btnVehiculosEliminado_Click);
            // 
            // dataGridViewPatrullas
            // 
            this.dataGridViewPatrullas.AllowUserToAddRows = false;
            this.dataGridViewPatrullas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPatrullas.Location = new System.Drawing.Point(610, 197);
            this.dataGridViewPatrullas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewPatrullas.Name = "dataGridViewPatrullas";
            this.dataGridViewPatrullas.RowHeadersWidth = 62;
            this.dataGridViewPatrullas.Size = new System.Drawing.Size(1022, 802);
            this.dataGridViewPatrullas.TabIndex = 0;
            this.dataGridViewPatrullas.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPatrullas_CellValueChanged);
            this.dataGridViewPatrullas.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridUsuarios_CurrentCellDirtyStateChanged);
            this.dataGridViewPatrullas.SelectionChanged += new System.EventHandler(this.DataGridViewPatrullas_SelectionChanged);
            // 
            // UCPatrullasComisario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnVehiculosEliminado);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.textBoxBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewPatrullas);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UCPatrullasComisario";
            this.Size = new System.Drawing.Size(1743, 1075);
            this.Load += new System.EventHandler(this.UCPatrullasComisario_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatrullas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelCodigo;
        private System.Windows.Forms.Button btnAgregarPatrulla;
        private System.Windows.Forms.Button btnEditarPatrulla;
        private System.Windows.Forms.Button btnEliminarPatrulla;
        private System.Windows.Forms.TextBox textNroVehiculo;
        private System.Windows.Forms.Label labelTipo;
        private System.Windows.Forms.ComboBox TipoVehiculoBox;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.ComboBox EstadoVehiculoBox;
        private System.Windows.Forms.Label labelTitulo_Vehiculos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox textBoxBuscar;
        private System.Windows.Forms.Button btnVehiculosEliminado;
        private System.Windows.Forms.DataGridView dataGridViewPatrullas;
    }
}
