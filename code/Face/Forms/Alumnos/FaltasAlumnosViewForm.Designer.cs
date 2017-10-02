namespace moleQule.Face.Instruction
{
    partial class FaltasAlumnosViewForm
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
            this.Alumnos_Grid = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NExpediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clasesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Promocion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CModulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.submoduloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalClases = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Porcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            this.Paneles2.Panel1.SuspendLayout();
            this.Paneles2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Alumnos_Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.Controls.Add(this.Alumnos_Grid);
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(1157, 611);
            this.PanelesV.SplitterDistance = 570;
            // 
            // Submit_BT
            // 
            this.Submit_BT.Location = new System.Drawing.Point(252, 6);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Location = new System.Drawing.Point(348, 6);
            this.HelpProvider.SetShowHelp(this.Cancel_BT, true);
            // 
            // Paneles2
            // 
            // 
            // Paneles2.Panel1
            // 
            this.HelpProvider.SetShowHelp(this.Paneles2.Panel1, true);
            // 
            // Paneles2.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.Paneles2.Panel2, true);
            this.HelpProvider.SetShowHelp(this.Paneles2, true);
            this.Paneles2.Size = new System.Drawing.Size(1155, 38);
            this.Paneles2.SplitterDistance = 37;
            // 
            // Imprimir_Button
            // 
            this.Imprimir_Button.Location = new System.Drawing.Point(156, 6);
            this.HelpProvider.SetShowHelp(this.Imprimir_Button, true);
            // 
            // Docs_BT
            // 
            this.Docs_BT.Location = new System.Drawing.Point(300, 6);
            this.HelpProvider.SetShowHelp(this.Docs_BT, true);
            // 
            // Datos
            // 
            this.Datos.DataSource = typeof(moleQule.Library.Instruction.FaltaAlumnoInfo);
            // 
            // Alumnos_Grid
            // 
            this.Alumnos_Grid.AutoGenerateColumns = false;
            this.Alumnos_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Alumnos_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Apellidos,
            this.NExpediente,
            this.Codigo,
            this.clasesDataGridViewTextBoxColumn,
            this.Duracion,
            this.Promocion,
            this.CModulo,
            this.submoduloDataGridViewTextBoxColumn,
            this.TotalClases,
            this.Porcentaje});
            this.Alumnos_Grid.DataSource = this.Datos;
            this.Alumnos_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Alumnos_Grid.Location = new System.Drawing.Point(0, 0);
            this.Alumnos_Grid.Name = "Alumnos_Grid";
            this.Alumnos_Grid.Size = new System.Drawing.Size(1155, 568);
            this.Alumnos_Grid.TabIndex = 4;
            this.Alumnos_Grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Alumnos_Grid_DataBindingComplete);
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "nombreDataGridViewTextBoxColumn";
            // 
            // apellidosDataGridViewTextBoxColumn
            // 
            this.Apellidos.DataPropertyName = "Apellidos";
            this.Apellidos.HeaderText = "Apellidos";
            this.Apellidos.Name = "apellidosDataGridViewTextBoxColumn";
            // 
            // nExpedienteDataGridViewTextBoxColumn
            // 
            this.NExpediente.DataPropertyName = "NExpediente";
            this.NExpediente.HeaderText = "NExpediente";
            this.NExpediente.Name = "nExpedienteDataGridViewTextBoxColumn";
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "codigoDataGridViewTextBoxColumn";
            // 
            // clasesDataGridViewTextBoxColumn
            // 
            this.clasesDataGridViewTextBoxColumn.DataPropertyName = "Clases";
            this.clasesDataGridViewTextBoxColumn.HeaderText = "Clases";
            this.clasesDataGridViewTextBoxColumn.Name = "clasesDataGridViewTextBoxColumn";
            // 
            // duracionDataGridViewTextBoxColumn
            // 
            this.Duracion.DataPropertyName = "Duracion";
            this.Duracion.HeaderText = "Duracion";
            this.Duracion.Name = "duracionDataGridViewTextBoxColumn";
            // 
            // promocionDataGridViewTextBoxColumn
            // 
            this.Promocion.DataPropertyName = "Promocion";
            this.Promocion.HeaderText = "Promocion";
            this.Promocion.Name = "promocionDataGridViewTextBoxColumn";
            // 
            // moduloDataGridViewTextBoxColumn
            // 
            this.CModulo.DataPropertyName = "Modulo";
            this.CModulo.HeaderText = "Modulo";
            this.CModulo.Name = "moduloDataGridViewTextBoxColumn";
            // 
            // submoduloDataGridViewTextBoxColumn
            // 
            this.submoduloDataGridViewTextBoxColumn.DataPropertyName = "Submodulo";
            this.submoduloDataGridViewTextBoxColumn.HeaderText = "Submodulo";
            this.submoduloDataGridViewTextBoxColumn.Name = "submoduloDataGridViewTextBoxColumn";
            // 
            // totalClasesDataGridViewTextBoxColumn
            // 
            this.TotalClases.DataPropertyName = "TotalClases";
            this.TotalClases.HeaderText = "TotalClases";
            this.TotalClases.Name = "totalClasesDataGridViewTextBoxColumn";
            // 
            // porcentajeDataGridViewTextBoxColumn
            // 
            this.Porcentaje.DataPropertyName = "Porcentaje";
            this.Porcentaje.HeaderText = "Porcentaje";
            this.Porcentaje.Name = "porcentajeDataGridViewTextBoxColumn";
            // 
            // FaltasAlumnosViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(1157, 611);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "FaltasAlumnosViewForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "Faltas de Alumnos";
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            this.Paneles2.Panel1.ResumeLayout(false);
            this.Paneles2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Alumnos_Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Alumnos_Grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn NExpediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clasesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duracion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Promocion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CModulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn submoduloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalClases;
        private System.Windows.Forms.DataGridViewTextBoxColumn Porcentaje;
    }
}
