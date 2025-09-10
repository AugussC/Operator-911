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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nro_Vehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_Patrulla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nro_Vehiculo,
            this.Tipo_Patrulla,
            this.Estado});
            this.dataGridView1.Location = new System.Drawing.Point(772, 103);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(849, 818);
            this.dataGridView1.TabIndex = 0;
            // 
            // Nro_Vehiculo
            // 
            this.Nro_Vehiculo.HeaderText = "Nro Vehiculo";
            this.Nro_Vehiculo.MinimumWidth = 8;
            this.Nro_Vehiculo.Name = "Nro_Vehiculo";
            this.Nro_Vehiculo.Width = 150;
            // 
            // Tipo_Patrulla
            // 
            this.Tipo_Patrulla.HeaderText = "Tipo Patrulla";
            this.Tipo_Patrulla.MinimumWidth = 8;
            this.Tipo_Patrulla.Name = "Tipo_Patrulla";
            this.Tipo_Patrulla.Width = 150;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.MinimumWidth = 8;
            this.Estado.Name = "Estado";
            this.Estado.Width = 150;
            // 
            // labelCodigo
            // 
            this.labelCodigo.AutoSize = true;
            this.labelCodigo.Location = new System.Drawing.Point(83, 419);
            this.labelCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCodigo.Name = "labelCodigo";
            this.labelCodigo.Size = new System.Drawing.Size(99, 20);
            this.labelCodigo.TabIndex = 1;
            this.labelCodigo.Text = "Nro Vehiculo";
            // 
            // btnAgregarPatrulla
            // 
            this.btnAgregarPatrulla.Location = new System.Drawing.Point(194, 709);
            this.btnAgregarPatrulla.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAgregarPatrulla.Name = "btnAgregarPatrulla";
            this.btnAgregarPatrulla.Size = new System.Drawing.Size(126, 46);
            this.btnAgregarPatrulla.TabIndex = 2;
            this.btnAgregarPatrulla.Text = "Agregar";
            this.btnAgregarPatrulla.UseVisualStyleBackColor = true;
            // 
            // btnEditarPatrulla
            // 
            this.btnEditarPatrulla.Location = new System.Drawing.Point(329, 709);
            this.btnEditarPatrulla.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditarPatrulla.Name = "btnEditarPatrulla";
            this.btnEditarPatrulla.Size = new System.Drawing.Size(126, 46);
            this.btnEditarPatrulla.TabIndex = 3;
            this.btnEditarPatrulla.Text = "Editar";
            this.btnEditarPatrulla.UseVisualStyleBackColor = true;
            // 
            // btnEliminarPatrulla
            // 
            this.btnEliminarPatrulla.Location = new System.Drawing.Point(464, 709);
            this.btnEliminarPatrulla.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEliminarPatrulla.Name = "btnEliminarPatrulla";
            this.btnEliminarPatrulla.Size = new System.Drawing.Size(126, 46);
            this.btnEliminarPatrulla.TabIndex = 4;
            this.btnEliminarPatrulla.Text = "Eliminar";
            this.btnEliminarPatrulla.UseVisualStyleBackColor = true;
            // 
            // textNroVehiculo
            // 
            this.textNroVehiculo.Location = new System.Drawing.Point(88, 444);
            this.textNroVehiculo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textNroVehiculo.Name = "textNroVehiculo";
            this.textNroVehiculo.Size = new System.Drawing.Size(577, 26);
            this.textNroVehiculo.TabIndex = 5;
            // 
            // labelTipo
            // 
            this.labelTipo.AutoSize = true;
            this.labelTipo.Location = new System.Drawing.Point(83, 511);
            this.labelTipo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTipo.Name = "labelTipo";
            this.labelTipo.Size = new System.Drawing.Size(39, 20);
            this.labelTipo.TabIndex = 6;
            this.labelTipo.Text = "Tipo";
            // 
            // TipoVehiculoBox
            // 
            this.TipoVehiculoBox.FormattingEnabled = true;
            this.TipoVehiculoBox.Items.AddRange(new object[] {
            "Auto",
            "Moto"});
            this.TipoVehiculoBox.Location = new System.Drawing.Point(88, 536);
            this.TipoVehiculoBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TipoVehiculoBox.Name = "TipoVehiculoBox";
            this.TipoVehiculoBox.Size = new System.Drawing.Size(577, 28);
            this.TipoVehiculoBox.TabIndex = 7;
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Location = new System.Drawing.Point(83, 599);
            this.labelEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(60, 20);
            this.labelEstado.TabIndex = 8;
            this.labelEstado.Text = "Estado";
            // 
            // EstadoVehiculoBox
            // 
            this.EstadoVehiculoBox.FormattingEnabled = true;
            this.EstadoVehiculoBox.Items.AddRange(new object[] {
            "Patrulla",
            "En Base"});
            this.EstadoVehiculoBox.Location = new System.Drawing.Point(88, 623);
            this.EstadoVehiculoBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EstadoVehiculoBox.Name = "EstadoVehiculoBox";
            this.EstadoVehiculoBox.Size = new System.Drawing.Size(577, 28);
            this.EstadoVehiculoBox.TabIndex = 9;
            // 
            // labelTitulo_Vehiculos
            // 
            this.labelTitulo_Vehiculos.AutoSize = true;
            this.labelTitulo_Vehiculos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo_Vehiculos.Location = new System.Drawing.Point(205, 243);
            this.labelTitulo_Vehiculos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitulo_Vehiculos.Name = "labelTitulo_Vehiculos";
            this.labelTitulo_Vehiculos.Size = new System.Drawing.Size(350, 37);
            this.labelTitulo_Vehiculos.TabIndex = 24;
            this.labelTitulo_Vehiculos.Text = "Administrar Vehiculos";
            this.labelTitulo_Vehiculos.Click += new System.EventHandler(this.labelTitulo_Usuarios_Click);
            // 
            // UCPatrullasComisario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelTitulo_Vehiculos);
            this.Controls.Add(this.EstadoVehiculoBox);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.TipoVehiculoBox);
            this.Controls.Add(this.labelTipo);
            this.Controls.Add(this.textNroVehiculo);
            this.Controls.Add(this.btnEliminarPatrulla);
            this.Controls.Add(this.btnEditarPatrulla);
            this.Controls.Add(this.btnAgregarPatrulla);
            this.Controls.Add(this.labelCodigo);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UCPatrullasComisario";
            this.Size = new System.Drawing.Size(1743, 1075);
            this.Load += new System.EventHandler(this.UCPatrullasComisario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelCodigo;
        private System.Windows.Forms.Button btnAgregarPatrulla;
        private System.Windows.Forms.Button btnEditarPatrulla;
        private System.Windows.Forms.Button btnEliminarPatrulla;
        private System.Windows.Forms.TextBox textNroVehiculo;
        private System.Windows.Forms.Label labelTipo;
        private System.Windows.Forms.ComboBox TipoVehiculoBox;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.ComboBox EstadoVehiculoBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nro_Vehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_Patrulla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.Label labelTitulo_Vehiculos;
    }
}
