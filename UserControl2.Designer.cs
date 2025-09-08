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
            this.labelCodigo = new System.Windows.Forms.Label();
            this.btnAgregarPatrulla = new System.Windows.Forms.Button();
            this.btnEditarPatrulla = new System.Windows.Forms.Button();
            this.btnEliminarPatrulla = new System.Windows.Forms.Button();
            this.textNroVehiculo = new System.Windows.Forms.TextBox();
            this.labelTipo = new System.Windows.Forms.Label();
            this.TipoVehiculoBox = new System.Windows.Forms.ComboBox();
            this.labelEstado = new System.Windows.Forms.Label();
            this.EstadoVehiculoBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 212);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1114, 430);
            this.dataGridView1.TabIndex = 0;
            // 
            // labelCodigo
            // 
            this.labelCodigo.AutoSize = true;
            this.labelCodigo.Location = new System.Drawing.Point(42, 17);
            this.labelCodigo.Name = "labelCodigo";
            this.labelCodigo.Size = new System.Drawing.Size(68, 13);
            this.labelCodigo.TabIndex = 1;
            this.labelCodigo.Text = "Nro Vehiculo";
            // 
            // btnAgregarPatrulla
            // 
            this.btnAgregarPatrulla.Location = new System.Drawing.Point(438, 176);
            this.btnAgregarPatrulla.Name = "btnAgregarPatrulla";
            this.btnAgregarPatrulla.Size = new System.Drawing.Size(84, 30);
            this.btnAgregarPatrulla.TabIndex = 2;
            this.btnAgregarPatrulla.Text = "Agregar";
            this.btnAgregarPatrulla.UseVisualStyleBackColor = true;
            // 
            // btnEditarPatrulla
            // 
            this.btnEditarPatrulla.Location = new System.Drawing.Point(528, 176);
            this.btnEditarPatrulla.Name = "btnEditarPatrulla";
            this.btnEditarPatrulla.Size = new System.Drawing.Size(84, 30);
            this.btnEditarPatrulla.TabIndex = 3;
            this.btnEditarPatrulla.Text = "Editar";
            this.btnEditarPatrulla.UseVisualStyleBackColor = true;
            // 
            // btnEliminarPatrulla
            // 
            this.btnEliminarPatrulla.Location = new System.Drawing.Point(618, 176);
            this.btnEliminarPatrulla.Name = "btnEliminarPatrulla";
            this.btnEliminarPatrulla.Size = new System.Drawing.Size(84, 30);
            this.btnEliminarPatrulla.TabIndex = 4;
            this.btnEliminarPatrulla.Text = "Eliminar";
            this.btnEliminarPatrulla.UseVisualStyleBackColor = true;
            // 
            // textNroVehiculo
            // 
            this.textNroVehiculo.Location = new System.Drawing.Point(45, 33);
            this.textNroVehiculo.Name = "textNroVehiculo";
            this.textNroVehiculo.Size = new System.Drawing.Size(688, 20);
            this.textNroVehiculo.TabIndex = 5;
            // 
            // labelTipo
            // 
            this.labelTipo.AutoSize = true;
            this.labelTipo.Location = new System.Drawing.Point(42, 67);
            this.labelTipo.Name = "labelTipo";
            this.labelTipo.Size = new System.Drawing.Size(28, 13);
            this.labelTipo.TabIndex = 6;
            this.labelTipo.Text = "Tipo";
            // 
            // TipoVehiculoBox
            // 
            this.TipoVehiculoBox.FormattingEnabled = true;
            this.TipoVehiculoBox.Items.AddRange(new object[] {
            "Auto",
            "Moto"});
            this.TipoVehiculoBox.Location = new System.Drawing.Point(45, 83);
            this.TipoVehiculoBox.Name = "TipoVehiculoBox";
            this.TipoVehiculoBox.Size = new System.Drawing.Size(688, 21);
            this.TipoVehiculoBox.TabIndex = 7;
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Location = new System.Drawing.Point(42, 118);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(40, 13);
            this.labelEstado.TabIndex = 8;
            this.labelEstado.Text = "Estado";
            // 
            // EstadoVehiculoBox
            // 
            this.EstadoVehiculoBox.FormattingEnabled = true;
            this.EstadoVehiculoBox.Items.AddRange(new object[] {
            "Patrulla",
            "En Base"});
            this.EstadoVehiculoBox.Location = new System.Drawing.Point(45, 134);
            this.EstadoVehiculoBox.Name = "EstadoVehiculoBox";
            this.EstadoVehiculoBox.Size = new System.Drawing.Size(688, 21);
            this.EstadoVehiculoBox.TabIndex = 9;
            // 
            // UCPatrullasComisario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Name = "UCPatrullasComisario";
            this.Size = new System.Drawing.Size(1162, 699);
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
    }
}
