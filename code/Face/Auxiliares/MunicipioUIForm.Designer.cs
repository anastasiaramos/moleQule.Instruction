namespace molApp.Face.Application
{
    partial class MunicipioUIForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Datos_Grid = new System.Windows.Forms.DataGridView();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Provincia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sessionCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodPostal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nHMngDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.childsDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            this.Paneles2.Panel1.SuspendLayout();
            this.Paneles2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.Controls.Add(this.Datos_Grid);
            this.PanelesV.Size = new System.Drawing.Size(349, 266);
            this.PanelesV.SplitterDistance = 225;
            // 
            // Guardar_Button
            // 
            this.Guardar_Button.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Guardar_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Guardar_Button.Location = new System.Drawing.Point(251, 6);
            // 
            // Cancelar_Button
            // 
            this.Cancelar_Button.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Cancelar_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Cancelar_Button.Location = new System.Drawing.Point(341, 6);
            // 
            // Paneles2
            // 
            this.Paneles2.Size = new System.Drawing.Size(347, 38);
            this.Paneles2.SplitterDistance = 37;
            // 
            // Imprimir_Button
            // 
            this.Imprimir_Button.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Imprimir_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Imprimir_Button.Location = new System.Drawing.Point(161, 6);
            // 
            // Datos
            // 
            this.Datos.DataSource = typeof(molApp.Library.Application.Municipios);
            // 
            // Datos_Grid
            // 
            this.Datos_Grid.AutoGenerateColumns = false;
            this.Datos_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Datos_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Valor,
            this.Provincia,
            this.sessionCodeDataGridViewTextBoxColumn,
            this.oidDataGridViewTextBoxColumn,
            this.CodPostal,
            this.nHMngDataGridViewTextBoxColumn,
            this.childsDataGridViewCheckBoxColumn});
            this.Datos_Grid.DataSource = this.Datos;
            this.Datos_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Datos_Grid.Location = new System.Drawing.Point(0, 0);
            this.Datos_Grid.Name = "Datos_Grid";
            this.Datos_Grid.Size = new System.Drawing.Size(347, 223);
            this.Datos_Grid.TabIndex = 0;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            // 
            // Provincia
            // 
            this.Provincia.DataPropertyName = "Provincia";
            this.Provincia.HeaderText = "Provincia";
            this.Provincia.Name = "Provincia";
            // 
            // sessionCodeDataGridViewTextBoxColumn
            // 
            this.sessionCodeDataGridViewTextBoxColumn.DataPropertyName = "SessionCode";
            this.sessionCodeDataGridViewTextBoxColumn.HeaderText = "SessionCode";
            this.sessionCodeDataGridViewTextBoxColumn.Name = "sessionCodeDataGridViewTextBoxColumn";
            // 
            // oidDataGridViewTextBoxColumn
            // 
            this.oidDataGridViewTextBoxColumn.DataPropertyName = "Oid";
            this.oidDataGridViewTextBoxColumn.HeaderText = "Oid";
            this.oidDataGridViewTextBoxColumn.Name = "oidDataGridViewTextBoxColumn";
            // 
            // CodPostal
            // 
            this.CodPostal.DataPropertyName = "CodPostal";
            this.CodPostal.HeaderText = "C.Postal";
            this.CodPostal.Name = "CodPostal";
            // 
            // nHMngDataGridViewTextBoxColumn
            // 
            this.nHMngDataGridViewTextBoxColumn.DataPropertyName = "nHMng";
            this.nHMngDataGridViewTextBoxColumn.HeaderText = "nHMng";
            this.nHMngDataGridViewTextBoxColumn.Name = "nHMngDataGridViewTextBoxColumn";
            this.nHMngDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // childsDataGridViewCheckBoxColumn
            // 
            this.childsDataGridViewCheckBoxColumn.DataPropertyName = "Childs";
            this.childsDataGridViewCheckBoxColumn.HeaderText = "Childs";
            this.childsDataGridViewCheckBoxColumn.Name = "childsDataGridViewCheckBoxColumn";
            // 
            // MunicipioUIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(349, 266);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "MunicipioUIForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            this.Paneles2.Panel1.ResumeLayout(false);
            this.Paneles2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Datos_Grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Provincia;
        private System.Windows.Forms.DataGridViewTextBoxColumn sessionCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodPostal;
        private System.Windows.Forms.DataGridViewTextBoxColumn nHMngDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn childsDataGridViewCheckBoxColumn;
    }
}
