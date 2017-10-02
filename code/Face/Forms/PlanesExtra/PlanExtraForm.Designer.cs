namespace moleQule.Face.Instruction
{
    partial class PlanExtraForm
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
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label fechaLabel;
            System.Windows.Forms.Label observacionesLabel;
            System.Windows.Forms.Label label16;
            System.Windows.Forms.Label label17;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanExtraForm));
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.fechaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.observacionesTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Resumen_BT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Clases_Grid = new System.Windows.Forms.DataGridView();
            this.Modulo_CBC = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Datos_Modulos = new System.Windows.Forms.BindingSource(this.components);
            this.Submodulo_CBC = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Datos_Submodulos = new System.Windows.Forms.BindingSource(this.components);
            this.Titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datos_Clases = new System.Windows.Forms.BindingSource(this.components);
            this.Add_Clases_BT = new System.Windows.Forms.Button();
            this.FacturacionInstruccion_GB = new System.Windows.Forms.GroupBox();
            this.ProductoInstruccion_BT = new System.Windows.Forms.Button();
            this.ProductoInstruccion_TB = new System.Windows.Forms.TextBox();
            this.SerieInstruccion_TB = new System.Windows.Forms.TextBox();
            this.SerieInstruccion_BT = new System.Windows.Forms.Button();
            nombreLabel = new System.Windows.Forms.Label();
            fechaLabel = new System.Windows.Forms.Label();
            observacionesLabel = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PanelesV)).BeginInit();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Paneles2)).BeginInit();
            this.Paneles2.Panel1.SuspendLayout();
            this.Paneles2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMng_EP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).BeginInit();
            this.Progress_Panel.SuspendLayout();
            this.ProgressBK_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Progress_PB)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Clases_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Modulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Submodulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Clases)).BeginInit();
            this.FacturacionInstruccion_GB.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.AutoScroll = true;
            this.PanelesV.Panel1.Controls.Add(this.FacturacionInstruccion_GB);
            this.PanelesV.Panel1.Controls.Add(this.Add_Clases_BT);
            this.PanelesV.Panel1.Controls.Add(this.Clases_Grid);
            this.PanelesV.Panel1.Controls.Add(this.label1);
            this.PanelesV.Panel1.Controls.Add(this.groupBox1);
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(1113, 689);
            this.PanelesV.SplitterDistance = 634;
            // 
            // Submit_BT
            // 
            this.Submit_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Submit_BT.Location = new System.Drawing.Point(251, 6);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Cancel_BT.Location = new System.Drawing.Point(341, 6);
            this.HelpProvider.SetShowHelp(this.Cancel_BT, true);
            // 
            // Paneles2
            // 
            this.ErrorMng_EP.SetError(this.Paneles2, "F1 Ayuda        ");
            // 
            // Paneles2.Panel1
            // 
            this.HelpProvider.SetShowHelp(this.Paneles2.Panel1, true);
            // 
            // Paneles2.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.Paneles2.Panel2, true);
            this.HelpProvider.SetShowHelp(this.Paneles2, true);
            this.Paneles2.Size = new System.Drawing.Size(1111, 52);
            this.Paneles2.SplitterDistance = 30;
            // 
            // Imprimir_Button
            // 
            this.Imprimir_Button.Enabled = true;
            this.Imprimir_Button.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Imprimir_Button.Location = new System.Drawing.Point(161, 6);
            this.HelpProvider.SetShowHelp(this.Imprimir_Button, true);
            this.Imprimir_Button.Visible = true;
            // 
            // Docs_BT
            // 
            this.Docs_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Docs_BT.Location = new System.Drawing.Point(190, 8);
            this.HelpProvider.SetShowHelp(this.Docs_BT, true);
            // 
            // Datos
            // 
            this.Datos.DataSource = typeof(moleQule.Library.Instruction.PlanExtra);
            // 
            // Progress_Panel
            // 
            this.Progress_Panel.Location = new System.Drawing.Point(377, 96);
            // 
            // ProgressBK_Panel
            // 
            this.ProgressBK_Panel.Size = new System.Drawing.Size(1113, 689);
            // 
            // ProgressInfo_PB
            // 
            this.ProgressInfo_PB.Location = new System.Drawing.Point(519, 393);
            // 
            // Progress_PB
            // 
            this.Progress_PB.Location = new System.Drawing.Point(519, 308);
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(11, 21);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(48, 13);
            nombreLabel.TabIndex = 0;
            nombreLabel.Text = "Nombre:";
            // 
            // fechaLabel
            // 
            fechaLabel.AutoSize = true;
            fechaLabel.Location = new System.Drawing.Point(57, 66);
            fechaLabel.Name = "fechaLabel";
            fechaLabel.Size = new System.Drawing.Size(40, 13);
            fechaLabel.TabIndex = 4;
            fechaLabel.Text = "Fecha:";
            // 
            // observacionesLabel
            // 
            observacionesLabel.AutoSize = true;
            observacionesLabel.Location = new System.Drawing.Point(405, 21);
            observacionesLabel.Name = "observacionesLabel";
            observacionesLabel.Size = new System.Drawing.Size(82, 13);
            observacionesLabel.TabIndex = 6;
            observacionesLabel.Text = "Observaciones:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label16.Location = new System.Drawing.Point(88, 43);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(35, 13);
            label16.TabIndex = 56;
            label16.Text = "Serie:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label17.Location = new System.Drawing.Point(70, 76);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(54, 13);
            label17.TabIndex = 59;
            label17.Text = "Producto:";
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Nombre", true));
            this.nombreTextBox.Location = new System.Drawing.Point(71, 18);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(316, 21);
            this.nombreTextBox.TabIndex = 1;
            // 
            // fechaDateTimePicker
            // 
            this.fechaDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Fecha", true));
            this.fechaDateTimePicker.Location = new System.Drawing.Point(106, 62);
            this.fechaDateTimePicker.Name = "fechaDateTimePicker";
            this.fechaDateTimePicker.Size = new System.Drawing.Size(235, 21);
            this.fechaDateTimePicker.TabIndex = 5;
            // 
            // observacionesTextBox
            // 
            this.observacionesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Observaciones", true));
            this.observacionesTextBox.Location = new System.Drawing.Point(504, 18);
            this.observacionesTextBox.Multiline = true;
            this.observacionesTextBox.Name = "observacionesTextBox";
            this.observacionesTextBox.Size = new System.Drawing.Size(471, 65);
            this.observacionesTextBox.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Resumen_BT);
            this.groupBox1.Controls.Add(this.fechaDateTimePicker);
            this.groupBox1.Controls.Add(this.nombreTextBox);
            this.groupBox1.Controls.Add(observacionesLabel);
            this.groupBox1.Controls.Add(nombreLabel);
            this.groupBox1.Controls.Add(this.observacionesTextBox);
            this.groupBox1.Controls.Add(fechaLabel);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1089, 98);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // Resumen_BT
            // 
            this.Resumen_BT.Location = new System.Drawing.Point(994, 37);
            this.Resumen_BT.Name = "Resumen_BT";
            this.Resumen_BT.Size = new System.Drawing.Size(75, 23);
            this.Resumen_BT.TabIndex = 8;
            this.Resumen_BT.Text = "Resumen";
            this.Resumen_BT.UseVisualStyleBackColor = true;
            this.Resumen_BT.Click += new System.EventHandler(this.Resumen_BT_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(512, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "CLASES EXTRA";
            // 
            // Clases_Grid
            // 
            this.Clases_Grid.AllowUserToOrderColumns = true;
            this.Clases_Grid.AutoGenerateColumns = false;
            this.Clases_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Modulo_CBC,
            this.Submodulo_CBC,
            this.Titulo,
            this.Alias,
            this.Observaciones});
            this.Clases_Grid.DataSource = this.Datos_Clases;
            this.Clases_Grid.Location = new System.Drawing.Point(11, 281);
            this.Clases_Grid.Name = "Clases_Grid";
            this.Clases_Grid.Size = new System.Drawing.Size(1089, 326);
            this.Clases_Grid.TabIndex = 10;
            this.Clases_Grid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Clases_Grid_CellValueChanged);
            this.Clases_Grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Clases_Grid_DataError);
            this.Clases_Grid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.Clases_Grid_RowsAdded);
            this.Clases_Grid.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.Clases_Grid_UserDeletingRow);
            // 
            // Modulo_CBC
            // 
            this.Modulo_CBC.DataPropertyName = "OidModulo";
            this.Modulo_CBC.DataSource = this.Datos_Modulos;
            this.Modulo_CBC.DisplayMember = "Texto";
            this.Modulo_CBC.HeaderText = "Módulo";
            this.Modulo_CBC.Name = "Modulo_CBC";
            this.Modulo_CBC.ValueMember = "Oid";
            this.Modulo_CBC.Width = 150;
            // 
            // Datos_Modulos
            // 
            this.Datos_Modulos.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // Submodulo_CBC
            // 
            this.Submodulo_CBC.DataPropertyName = "OidSubmodulo";
            this.Submodulo_CBC.DataSource = this.Datos_Submodulos;
            this.Submodulo_CBC.DisplayMember = "Texto";
            this.Submodulo_CBC.HeaderText = "Submódulo";
            this.Submodulo_CBC.Name = "Submodulo_CBC";
            this.Submodulo_CBC.ValueMember = "Oid";
            this.Submodulo_CBC.Width = 150;
            // 
            // Datos_Submodulos
            // 
            this.Datos_Submodulos.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // Titulo
            // 
            this.Titulo.DataPropertyName = "Titulo";
            this.Titulo.HeaderText = "Título";
            this.Titulo.Name = "Titulo";
            this.Titulo.Width = 300;
            // 
            // Alias
            // 
            this.Alias.DataPropertyName = "Alias";
            this.Alias.HeaderText = "Alias";
            this.Alias.Name = "Alias";
            // 
            // Observaciones
            // 
            this.Observaciones.DataPropertyName = "Observaciones";
            this.Observaciones.HeaderText = "Observaciones";
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.Width = 200;
            // 
            // Datos_Clases
            // 
            this.Datos_Clases.DataSource = typeof(moleQule.Library.Instruction.ClaseExtra);
            // 
            // Add_Clases_BT
            // 
            this.Add_Clases_BT.Location = new System.Drawing.Point(475, 620);
            this.Add_Clases_BT.Name = "Add_Clases_BT";
            this.Add_Clases_BT.Size = new System.Drawing.Size(157, 23);
            this.Add_Clases_BT.TabIndex = 11;
            this.Add_Clases_BT.Text = "Añadir Clases Múltiples";
            this.Add_Clases_BT.UseVisualStyleBackColor = true;
            this.Add_Clases_BT.Click += new System.EventHandler(this.Add_Clases_BT_Click);
            // 
            // FacturacionInstruccion_GB
            // 
            this.FacturacionInstruccion_GB.Controls.Add(this.ProductoInstruccion_BT);
            this.FacturacionInstruccion_GB.Controls.Add(this.ProductoInstruccion_TB);
            this.FacturacionInstruccion_GB.Controls.Add(this.SerieInstruccion_TB);
            this.FacturacionInstruccion_GB.Controls.Add(label16);
            this.FacturacionInstruccion_GB.Controls.Add(this.SerieInstruccion_BT);
            this.FacturacionInstruccion_GB.Controls.Add(label17);
            this.FacturacionInstruccion_GB.Location = new System.Drawing.Point(345, 115);
            this.FacturacionInstruccion_GB.Name = "FacturacionInstruccion_GB";
            this.FacturacionInstruccion_GB.Size = new System.Drawing.Size(420, 118);
            this.FacturacionInstruccion_GB.TabIndex = 62;
            this.FacturacionInstruccion_GB.TabStop = false;
            this.FacturacionInstruccion_GB.Text = "Facturación Albaranes de Instructor";
            // 
            // ProductoInstruccion_BT
            // 
            this.ProductoInstruccion_BT.Image = global::moleQule.Face.Instruction.Properties.Resources.select_16;
            this.ProductoInstruccion_BT.Location = new System.Drawing.Point(318, 72);
            this.ProductoInstruccion_BT.Name = "ProductoInstruccion_BT";
            this.ProductoInstruccion_BT.Size = new System.Drawing.Size(33, 21);
            this.ProductoInstruccion_BT.TabIndex = 57;
            this.ProductoInstruccion_BT.UseVisualStyleBackColor = true;
            this.ProductoInstruccion_BT.Click += new System.EventHandler(this.ProductoInstruccion_BT_Click);
            // 
            // ProductoInstruccion_TB
            // 
            this.ProductoInstruccion_TB.Location = new System.Drawing.Point(130, 73);
            this.ProductoInstruccion_TB.Name = "ProductoInstruccion_TB";
            this.ProductoInstruccion_TB.ReadOnly = true;
            this.ProductoInstruccion_TB.Size = new System.Drawing.Size(182, 21);
            this.ProductoInstruccion_TB.TabIndex = 58;
            this.ProductoInstruccion_TB.TabStop = false;
            // 
            // SerieInstruccion_TB
            // 
            this.SerieInstruccion_TB.Location = new System.Drawing.Point(130, 40);
            this.SerieInstruccion_TB.Name = "SerieInstruccion_TB";
            this.SerieInstruccion_TB.ReadOnly = true;
            this.SerieInstruccion_TB.Size = new System.Drawing.Size(182, 21);
            this.SerieInstruccion_TB.TabIndex = 55;
            this.SerieInstruccion_TB.TabStop = false;
            // 
            // SerieInstruccion_BT
            // 
            this.SerieInstruccion_BT.Image = global::moleQule.Face.Instruction.Properties.Resources.select_16;
            this.SerieInstruccion_BT.Location = new System.Drawing.Point(318, 39);
            this.SerieInstruccion_BT.Name = "SerieInstruccion_BT";
            this.SerieInstruccion_BT.Size = new System.Drawing.Size(33, 21);
            this.SerieInstruccion_BT.TabIndex = 54;
            this.SerieInstruccion_BT.UseVisualStyleBackColor = true;
            this.SerieInstruccion_BT.Click += new System.EventHandler(this.SerieInstruccion_BT_Click);
            // 
            // PlanExtraForm
            // 
            this.ClientSize = new System.Drawing.Size(1113, 689);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PlanExtraForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "PlanExtraForm";
            this.Shown += new System.EventHandler(this.PlanExtraForm_Shown);
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel1.PerformLayout();
            this.PanelesV.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelesV)).EndInit();
            this.PanelesV.ResumeLayout(false);
            this.Paneles2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Paneles2)).EndInit();
            this.Paneles2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMng_EP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).EndInit();
            this.Progress_Panel.ResumeLayout(false);
            this.Progress_Panel.PerformLayout();
            this.ProgressBK_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Progress_PB)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Clases_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Modulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Submodulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Clases)).EndInit();
            this.FacturacionInstruccion_GB.ResumeLayout(false);
            this.FacturacionInstruccion_GB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox observacionesTextBox;
        private System.Windows.Forms.DateTimePicker fechaDateTimePicker;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.DataGridView Clases_Grid;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.BindingSource Datos_Clases;
        protected System.Windows.Forms.BindingSource Datos_Modulos;
        protected System.Windows.Forms.BindingSource Datos_Submodulos;
        private System.Windows.Forms.DataGridViewComboBoxColumn Modulo_CBC;
        private System.Windows.Forms.DataGridViewComboBoxColumn Submodulo_CBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alias;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observaciones;
        protected System.Windows.Forms.Button Add_Clases_BT;
        protected System.Windows.Forms.Button Resumen_BT;
        private System.Windows.Forms.GroupBox FacturacionInstruccion_GB;
        protected System.Windows.Forms.Button ProductoInstruccion_BT;
        protected System.Windows.Forms.TextBox ProductoInstruccion_TB;
        protected System.Windows.Forms.TextBox SerieInstruccion_TB;
        protected System.Windows.Forms.Button SerieInstruccion_BT;
    }
}
