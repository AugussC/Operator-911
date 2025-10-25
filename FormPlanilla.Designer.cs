namespace Operador_911
{
    partial class FormPlanilla
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridHorarios = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportarPlanilla = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHorarios)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridHorarios
            // 
            this.dataGridHorarios.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHorarios.Location = new System.Drawing.Point(1, 40);
            this.dataGridHorarios.Name = "dataGridHorarios";
            this.dataGridHorarios.Size = new System.Drawing.Size(1130, 524);
            this.dataGridHorarios.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(459, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 25);
            this.label1.TabIndex = 29;
            this.label1.Text = "Lista de Horarios";
            // 
            // btnExportarPlanilla
            // 
            this.btnExportarPlanilla.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnExportarPlanilla.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExportarPlanilla.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExportarPlanilla.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarPlanilla.Location = new System.Drawing.Point(12, 5);
            this.btnExportarPlanilla.Name = "btnExportarPlanilla";
            this.btnExportarPlanilla.Size = new System.Drawing.Size(139, 29);
            this.btnExportarPlanilla.TabIndex = 30;
            this.btnExportarPlanilla.Text = "Exportar Planilla";
            this.btnExportarPlanilla.UseVisualStyleBackColor = false;
            this.btnExportarPlanilla.Click += new System.EventHandler(this.btnExportarPlanilla_Click);
            // 
            // FormPlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 561);
            this.Controls.Add(this.btnExportarPlanilla);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridHorarios);
            this.Name = "FormPlanilla";
            this.Text = "FormPlanilla";
            this.Load += new System.EventHandler(this.FormPlanilla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHorarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridHorarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportarPlanilla;
    }
}