namespace Operador_911
{
    partial class UCReportesSupervisor
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
            this.dataGridReportes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVerReporte = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.labelDesde = new System.Windows.Forms.Label();
            this.labelHasta = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.btnAlertas_Reportes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReportes)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridReportes
            // 
            this.dataGridReportes.AllowUserToAddRows = false;
            this.dataGridReportes.AllowUserToDeleteRows = false;
            this.dataGridReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridReportes.Location = new System.Drawing.Point(124, 216);
            this.dataGridReportes.Name = "dataGridReportes";
            this.dataGridReportes.RowHeadersVisible = false;
            this.dataGridReportes.RowHeadersWidth = 62;
            this.dataGridReportes.Size = new System.Drawing.Size(843, 424);
            this.dataGridReportes.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(434, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 27);
            this.label1.TabIndex = 16;
            this.label1.Text = "Reportes Recibidos";
            // 
            // btnVerReporte
            // 
            this.btnVerReporte.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerReporte.Location = new System.Drawing.Point(782, 174);
            this.btnVerReporte.Name = "btnVerReporte";
            this.btnVerReporte.Size = new System.Drawing.Size(185, 36);
            this.btnVerReporte.TabIndex = 23;
            this.btnVerReporte.Text = "Visualizar Detalle de Reporte";
            this.btnVerReporte.UseVisualStyleBackColor = true;
            this.btnVerReporte.Click += new System.EventHandler(this.btnVerReporte_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(1117, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(78, 699);
            this.panel1.TabIndex = 27;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(165, 193);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpHasta.TabIndex = 33;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(165, 159);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde.TabIndex = 34;
            // 
            // labelDesde
            // 
            this.labelDesde.AutoSize = true;
            this.labelDesde.Location = new System.Drawing.Point(121, 165);
            this.labelDesde.Name = "labelDesde";
            this.labelDesde.Size = new System.Drawing.Size(38, 13);
            this.labelDesde.TabIndex = 35;
            this.labelDesde.Text = "Desde";
            // 
            // labelHasta
            // 
            this.labelHasta.AutoSize = true;
            this.labelHasta.Location = new System.Drawing.Point(124, 193);
            this.labelHasta.Name = "labelHasta";
            this.labelHasta.Size = new System.Drawing.Size(35, 13);
            this.labelHasta.TabIndex = 36;
            this.labelHasta.Text = "Hasta";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(394, 177);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(65, 29);
            this.btnBuscar.TabIndex = 37;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciar.Location = new System.Drawing.Point(475, 177);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(65, 29);
            this.btnReiniciar.TabIndex = 38;
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.UseVisualStyleBackColor = true;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // btnAlertas_Reportes
            // 
            this.btnAlertas_Reportes.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlertas_Reportes.Location = new System.Drawing.Point(581, 174);
            this.btnAlertas_Reportes.Name = "btnAlertas_Reportes";
            this.btnAlertas_Reportes.Size = new System.Drawing.Size(185, 36);
            this.btnAlertas_Reportes.TabIndex = 39;
            this.btnAlertas_Reportes.Text = "Ver Alertas sin Atender";
            this.btnAlertas_Reportes.UseVisualStyleBackColor = true;
            this.btnAlertas_Reportes.Click += new System.EventHandler(this.btnAlertas_Reportes_Click);
            // 
            // UCReportesSupervisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnAlertas_Reportes);
            this.Controls.Add(this.btnReiniciar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.labelHasta);
            this.Controls.Add(this.labelDesde);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnVerReporte);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridReportes);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UCReportesSupervisor";
            this.Size = new System.Drawing.Size(1162, 699);
            this.Load += new System.EventHandler(this.UCResportesSupervisor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReportes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridReportes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVerReporte;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label labelDesde;
        private System.Windows.Forms.Label labelHasta;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.Button btnAlertas_Reportes;
    }
}
