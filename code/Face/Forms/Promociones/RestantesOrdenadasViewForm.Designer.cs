namespace moleQule.Face.Instruction
{
    partial class RestantesOrdenadasViewForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RestantesOrdenadasViewForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.moduloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.submoduloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tituloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aliasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoClaseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordenPrimarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordenSecundarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordenTerciarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.incompatibleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datos_Clases = new System.Windows.Forms.BindingSource(this.components);
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            this.Paneles2.Panel1.SuspendLayout();
            this.Paneles2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Clases)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.Controls.Add(this.dataGridView1);
            this.PanelesV.Size = new System.Drawing.Size(768, 510);
            this.PanelesV.SplitterDistance = 469;
            // 
            // Submit_BT
            // 
            this.Submit_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Submit_BT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Submit_BT.Location = new System.Drawing.Point(251, 6);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Cancel_BT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Cancel_BT.Location = new System.Drawing.Point(341, 6);
            // 
            // Paneles2
            // 
            this.Paneles2.Size = new System.Drawing.Size(766, 38);
            this.Paneles2.SplitterDistance = 37;
            // 
            // Imprimir_Button
            // 
            this.Imprimir_Button.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Imprimir_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Imprimir_Button.Location = new System.Drawing.Point(161, 6);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.moduloDataGridViewTextBoxColumn,
            this.submoduloDataGridViewTextBoxColumn,
            this.tituloDataGridViewTextBoxColumn,
            this.aliasDataGridViewTextBoxColumn,
            this.tipoClaseDataGridViewTextBoxColumn,
            this.grupoDataGridViewTextBoxColumn,
            this.ordenPrimarioDataGridViewTextBoxColumn,
            this.ordenSecundarioDataGridViewTextBoxColumn,
            this.ordenTerciarioDataGridViewTextBoxColumn,
            this.incompatibleDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.Datos_Clases;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(766, 467);
            this.dataGridView1.TabIndex = 0;
            // 
            // moduloDataGridViewTextBoxColumn
            // 
            this.moduloDataGridViewTextBoxColumn.DataPropertyName = "Modulo";
            this.moduloDataGridViewTextBoxColumn.HeaderText = "Módulo";
            this.moduloDataGridViewTextBoxColumn.Name = "moduloDataGridViewTextBoxColumn";
            this.moduloDataGridViewTextBoxColumn.ReadOnly = true;
            this.moduloDataGridViewTextBoxColumn.Width = 290;
            // 
            // submoduloDataGridViewTextBoxColumn
            // 
            this.submoduloDataGridViewTextBoxColumn.DataPropertyName = "Submodulo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.submoduloDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.submoduloDataGridViewTextBoxColumn.HeaderText = "Submódulo";
            this.submoduloDataGridViewTextBoxColumn.Name = "submoduloDataGridViewTextBoxColumn";
            this.submoduloDataGridViewTextBoxColumn.ReadOnly = true;
            this.submoduloDataGridViewTextBoxColumn.Width = 80;
            // 
            // tituloDataGridViewTextBoxColumn
            // 
            this.tituloDataGridViewTextBoxColumn.DataPropertyName = "Titulo";
            this.tituloDataGridViewTextBoxColumn.HeaderText = "Título";
            this.tituloDataGridViewTextBoxColumn.Name = "tituloDataGridViewTextBoxColumn";
            this.tituloDataGridViewTextBoxColumn.ReadOnly = true;
            this.tituloDataGridViewTextBoxColumn.Width = 290;
            // 
            // aliasDataGridViewTextBoxColumn
            // 
            this.aliasDataGridViewTextBoxColumn.DataPropertyName = "Alias";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.aliasDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.aliasDataGridViewTextBoxColumn.HeaderText = "Alias";
            this.aliasDataGridViewTextBoxColumn.Name = "aliasDataGridViewTextBoxColumn";
            this.aliasDataGridViewTextBoxColumn.ReadOnly = true;
            this.aliasDataGridViewTextBoxColumn.Width = 80;
            // 
            // tipoClaseDataGridViewTextBoxColumn
            // 
            this.tipoClaseDataGridViewTextBoxColumn.DataPropertyName = "TipoClase";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tipoClaseDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.tipoClaseDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tipoClaseDataGridViewTextBoxColumn.Name = "tipoClaseDataGridViewTextBoxColumn";
            this.tipoClaseDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoClaseDataGridViewTextBoxColumn.Width = 80;
            // 
            // grupoDataGridViewTextBoxColumn
            // 
            this.grupoDataGridViewTextBoxColumn.DataPropertyName = "Grupo";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grupoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.grupoDataGridViewTextBoxColumn.HeaderText = "Grupo";
            this.grupoDataGridViewTextBoxColumn.Name = "grupoDataGridViewTextBoxColumn";
            this.grupoDataGridViewTextBoxColumn.ReadOnly = true;
            this.grupoDataGridViewTextBoxColumn.Width = 50;
            // 
            // ordenPrimarioDataGridViewTextBoxColumn
            // 
            this.ordenPrimarioDataGridViewTextBoxColumn.DataPropertyName = "OrdenPrimario";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ordenPrimarioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.ordenPrimarioDataGridViewTextBoxColumn.HeaderText = "Orden Primario";
            this.ordenPrimarioDataGridViewTextBoxColumn.Name = "ordenPrimarioDataGridViewTextBoxColumn";
            this.ordenPrimarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.ordenPrimarioDataGridViewTextBoxColumn.Width = 80;
            // 
            // ordenSecundarioDataGridViewTextBoxColumn
            // 
            this.ordenSecundarioDataGridViewTextBoxColumn.DataPropertyName = "OrdenSecundario";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ordenSecundarioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.ordenSecundarioDataGridViewTextBoxColumn.HeaderText = "Orden Secundario";
            this.ordenSecundarioDataGridViewTextBoxColumn.Name = "ordenSecundarioDataGridViewTextBoxColumn";
            this.ordenSecundarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.ordenSecundarioDataGridViewTextBoxColumn.Width = 80;
            // 
            // ordenTerciarioDataGridViewTextBoxColumn
            // 
            this.ordenTerciarioDataGridViewTextBoxColumn.DataPropertyName = "OrdenTerciario";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ordenTerciarioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.ordenTerciarioDataGridViewTextBoxColumn.HeaderText = "Orden Terciario";
            this.ordenTerciarioDataGridViewTextBoxColumn.Name = "ordenTerciarioDataGridViewTextBoxColumn";
            this.ordenTerciarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.ordenTerciarioDataGridViewTextBoxColumn.Width = 80;
            // 
            // incompatibleDataGridViewTextBoxColumn
            // 
            this.incompatibleDataGridViewTextBoxColumn.DataPropertyName = "Incompatible";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.incompatibleDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.incompatibleDataGridViewTextBoxColumn.HeaderText = "Incompatible";
            this.incompatibleDataGridViewTextBoxColumn.Name = "incompatibleDataGridViewTextBoxColumn";
            this.incompatibleDataGridViewTextBoxColumn.ReadOnly = true;
            this.incompatibleDataGridViewTextBoxColumn.Width = 90;
            // 
            // Datos_Clases
            // 
            this.Datos_Clases.DataSource = typeof(moleQule.Library.Instruction.Clase);
            // 
            // RestantesOrdenadasViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(768, 510);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RestantesOrdenadasViewForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            this.Paneles2.Panel1.ResumeLayout(false);
            this.Paneles2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Clases)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource Datos_Clases;
        private System.Windows.Forms.DataGridViewTextBoxColumn moduloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn submoduloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tituloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aliasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoClaseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordenPrimarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordenSecundarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordenTerciarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn incompatibleDataGridViewTextBoxColumn;

    }
}
