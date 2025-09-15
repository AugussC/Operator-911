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
            this.labelNroPlaca = new System.Windows.Forms.Label();
            this.textBoxNroPlaca = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelApellido = new System.Windows.Forms.Label();
            this.labelDNI = new System.Windows.Forms.Label();
            this.textBoxDNI = new System.Windows.Forms.TextBox();
            this.textBoxTelefono = new System.Windows.Forms.TextBox();
            this.labelTelefono = new System.Windows.Forms.Label();
            this.btnAgregarPatrulla = new System.Windows.Forms.Button();
            this.btnEditarPatrulla = new System.Windows.Forms.Button();
            this.btnEliminarPatrulla = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nro_Placa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelTitulo_Patrullas = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelNroPlaca
            // 
            this.labelNroPlaca.AutoSize = true;
            this.labelNroPlaca.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNroPlaca.Location = new System.Drawing.Point(37, 187);
            this.labelNroPlaca.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNroPlaca.Name = "labelNroPlaca";
            this.labelNroPlaca.Size = new System.Drawing.Size(109, 22);
            this.labelNroPlaca.TabIndex = 0;
            this.labelNroPlaca.Text = "Nro de Placa";
            // 
            // textBoxNroPlaca
            // 
            this.textBoxNroPlaca.Location = new System.Drawing.Point(41, 214);
            this.textBoxNroPlaca.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxNroPlaca.Name = "textBoxNroPlaca";
            this.textBoxNroPlaca.Size = new System.Drawing.Size(522, 26);
            this.textBoxNroPlaca.TabIndex = 1;
            this.textBoxNroPlaca.TextChanged += new System.EventHandler(this.textBoxNroPlaca_TextChanged);
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(41, 296);
            this.textBoxNombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(522, 26);
            this.textBoxNombre.TabIndex = 2;
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(41, 380);
            this.textBoxApellido.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(522, 26);
            this.textBoxApellido.TabIndex = 3;
            this.textBoxApellido.TextChanged += new System.EventHandler(this.textBoxApellido_TextChanged);
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre.Location = new System.Drawing.Point(37, 269);
            this.labelNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(72, 22);
            this.labelNombre.TabIndex = 4;
            this.labelNombre.Text = "Nombre";
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelApellido.Location = new System.Drawing.Point(37, 353);
            this.labelApellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(72, 22);
            this.labelApellido.TabIndex = 5;
            this.labelApellido.Text = "Apellido";
            // 
            // labelDNI
            // 
            this.labelDNI.AutoSize = true;
            this.labelDNI.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDNI.Location = new System.Drawing.Point(37, 442);
            this.labelDNI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDNI.Name = "labelDNI";
            this.labelDNI.Size = new System.Drawing.Size(339, 22);
            this.labelDNI.TabIndex = 6;
            this.labelDNI.Text = "Documento Nacional de Indentidad (DNI)";
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Location = new System.Drawing.Point(41, 469);
            this.textBoxDNI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.Size = new System.Drawing.Size(522, 26);
            this.textBoxDNI.TabIndex = 7;
            // 
            // textBoxTelefono
            // 
            this.textBoxTelefono.Location = new System.Drawing.Point(41, 556);
            this.textBoxTelefono.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxTelefono.Name = "textBoxTelefono";
            this.textBoxTelefono.Size = new System.Drawing.Size(522, 26);
            this.textBoxTelefono.TabIndex = 8;
            // 
            // labelTelefono
            // 
            this.labelTelefono.AutoSize = true;
            this.labelTelefono.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTelefono.Location = new System.Drawing.Point(37, 529);
            this.labelTelefono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTelefono.Name = "labelTelefono";
            this.labelTelefono.Size = new System.Drawing.Size(79, 22);
            this.labelTelefono.TabIndex = 9;
            this.labelTelefono.Text = "Telefono";
            // 
            // btnAgregarPatrulla
            // 
            this.btnAgregarPatrulla.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarPatrulla.Location = new System.Drawing.Point(95, 649);
            this.btnAgregarPatrulla.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAgregarPatrulla.Name = "btnAgregarPatrulla";
            this.btnAgregarPatrulla.Size = new System.Drawing.Size(126, 46);
            this.btnAgregarPatrulla.TabIndex = 10;
            this.btnAgregarPatrulla.Text = "Agregar";
            this.btnAgregarPatrulla.UseVisualStyleBackColor = true;
            // 
            // btnEditarPatrulla
            // 
            this.btnEditarPatrulla.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarPatrulla.Location = new System.Drawing.Point(240, 649);
            this.btnEditarPatrulla.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditarPatrulla.Name = "btnEditarPatrulla";
            this.btnEditarPatrulla.Size = new System.Drawing.Size(126, 46);
            this.btnEditarPatrulla.TabIndex = 11;
            this.btnEditarPatrulla.Text = "Editar";
            this.btnEditarPatrulla.UseVisualStyleBackColor = true;
            // 
            // btnEliminarPatrulla
            // 
            this.btnEliminarPatrulla.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarPatrulla.Location = new System.Drawing.Point(388, 649);
            this.btnEliminarPatrulla.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEliminarPatrulla.Name = "btnEliminarPatrulla";
            this.btnEliminarPatrulla.Size = new System.Drawing.Size(126, 46);
            this.btnEliminarPatrulla.TabIndex = 12;
            this.btnEliminarPatrulla.Text = "Eliminar";
            this.btnEliminarPatrulla.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nro_Placa,
            this.Apellido,
            this.Nombre,
            this.DNI,
            this.Telefono});
            this.dataGridView1.Location = new System.Drawing.Point(721, 197);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(911, 802);
            this.dataGridView1.TabIndex = 13;
            // 
            // Nro_Placa
            // 
            this.Nro_Placa.HeaderText = "Nro Placa";
            this.Nro_Placa.MinimumWidth = 8;
            this.Nro_Placa.Name = "Nro_Placa";
            this.Nro_Placa.Width = 150;
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.MinimumWidth = 8;
            this.Apellido.Name = "Apellido";
            this.Apellido.Width = 150;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 8;
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 150;
            // 
            // DNI
            // 
            this.DNI.HeaderText = "DNI";
            this.DNI.MinimumWidth = 8;
            this.DNI.Name = "DNI";
            this.DNI.Width = 150;
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.MinimumWidth = 8;
            this.Telefono.Name = "Telefono";
            this.Telefono.Width = 150;
            // 
            // labelTitulo_Patrullas
            // 
            this.labelTitulo_Patrullas.AutoSize = true;
            this.labelTitulo_Patrullas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo_Patrullas.Location = new System.Drawing.Point(132, 84);
            this.labelTitulo_Patrullas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitulo_Patrullas.Name = "labelTitulo_Patrullas";
            this.labelTitulo_Patrullas.Size = new System.Drawing.Size(336, 37);
            this.labelTitulo_Patrullas.TabIndex = 24;
            this.labelTitulo_Patrullas.Text = "Administrar Patrullas";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(1676, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(117, 1075);
            this.panel1.TabIndex = 26;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.labelNroPlaca);
            this.panel2.Controls.Add(this.labelTitulo_Patrullas);
            this.panel2.Controls.Add(this.textBoxNroPlaca);
            this.panel2.Controls.Add(this.labelNombre);
            this.panel2.Controls.Add(this.btnEliminarPatrulla);
            this.panel2.Controls.Add(this.textBoxNombre);
            this.panel2.Controls.Add(this.btnEditarPatrulla);
            this.panel2.Controls.Add(this.labelApellido);
            this.panel2.Controls.Add(this.btnAgregarPatrulla);
            this.panel2.Controls.Add(this.textBoxApellido);
            this.panel2.Controls.Add(this.textBoxTelefono);
            this.panel2.Controls.Add(this.labelTelefono);
            this.panel2.Controls.Add(this.labelDNI);
            this.panel2.Controls.Add(this.textBoxDNI);
            this.panel2.Location = new System.Drawing.Point(68, 197);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(616, 802);
            this.panel2.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1026, 100);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 37);
            this.label1.TabIndex = 28;
            this.label1.Text = "Lista de patrullas";
            // 
            // UCPoliciasComisario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UCPoliciasComisario";
            this.Size = new System.Drawing.Size(1743, 1075);
            this.Load += new System.EventHandler(this.UCPoliciasComisario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNroPlaca;
        private System.Windows.Forms.TextBox textBoxNroPlaca;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.Label labelDNI;
        private System.Windows.Forms.TextBox textBoxDNI;
        private System.Windows.Forms.TextBox textBoxTelefono;
        private System.Windows.Forms.Label labelTelefono;
        private System.Windows.Forms.Button btnAgregarPatrulla;
        private System.Windows.Forms.Button btnEditarPatrulla;
        private System.Windows.Forms.Button btnEliminarPatrulla;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nro_Placa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.Label labelTitulo_Patrullas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}
