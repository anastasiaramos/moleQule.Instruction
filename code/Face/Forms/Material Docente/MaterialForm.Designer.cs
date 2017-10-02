namespace moleQule.Face.Instruction
{
    partial class MaterialForm
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
            System.Windows.Forms.Label observacionesLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialForm));
            this.Tipo_CB = new System.Windows.Forms.ComboBox();
            this.Datos_Tipo = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.Nombre_CB = new System.Windows.Forms.ComboBox();
            this.Datos_Curso = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.Referencia_GB = new System.Windows.Forms.GroupBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.observacionesTextBox = new System.Windows.Forms.TextBox();
            this.Datos_Alumnos = new System.Windows.Forms.BindingSource(this.components);
            this.Alumnos_Grid = new System.Windows.Forms.DataGridView();
            this.Datos_Promociones = new System.Windows.Forms.BindingSource(this.components);
            this.Datos_ComboAlumnos = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Delete_Button = new System.Windows.Forms.Button();
            this.Edit_Button = new System.Windows.Forms.Button();
            this.Add_Button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Revisiones_Grid = new System.Windows.Forms.DataGridView();
            this.Autor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datos_Revisiones = new System.Windows.Forms.BindingSource(this.components);
            this.Entregado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Alumno_CBC = new System.Windows.Forms.DataGridViewComboBoxColumn();
            nombreLabel = new System.Windows.Forms.Label();
            observacionesLabel = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Tipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Curso)).BeginInit();
            this.Referencia_GB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Alumnos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Alumnos_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Promociones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_ComboAlumnos)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Revisiones_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Revisiones)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.AutoScroll = true;
            this.PanelesV.Panel1.Controls.Add(this.tabControl1);
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(669, 780);
            this.PanelesV.SplitterDistance = 725;
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
            // 
            // Paneles2.Panel1
            // 
            this.HelpProvider.SetShowHelp(this.Paneles2.Panel1, true);
            // 
            // Paneles2.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.Paneles2.Panel2, true);
            this.HelpProvider.SetShowHelp(this.Paneles2, true);
            this.Paneles2.Size = new System.Drawing.Size(667, 52);
            this.Paneles2.SplitterDistance = 27;
            // 
            // Imprimir_Button
            // 
            this.Imprimir_Button.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Imprimir_Button.Location = new System.Drawing.Point(161, 6);
            this.HelpProvider.SetShowHelp(this.Imprimir_Button, true);
            // 
            // Docs_BT
            // 
            this.Docs_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Docs_BT.Location = new System.Drawing.Point(300, 6);
            this.HelpProvider.SetShowHelp(this.Docs_BT, true);
            // 
            // Datos
            // 
            this.Datos.DataSource = typeof(moleQule.Library.Instruction.MaterialDocente);
            // 
            // Progress_Panel
            // 
            this.Progress_Panel.Location = new System.Drawing.Point(155, 96);
            // 
            // ProgressBK_Panel
            // 
            this.ProgressBK_Panel.Size = new System.Drawing.Size(669, 780);
            // 
            // ProgressInfo_PB
            // 
            this.ProgressInfo_PB.Location = new System.Drawing.Point(297, 438);
            // 
            // Progress_PB
            // 
            this.Progress_PB.Location = new System.Drawing.Point(297, 353);
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nombreLabel.Location = new System.Drawing.Point(103, 191);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(37, 13);
            nombreLabel.TabIndex = 4;
            nombreLabel.Text = "Título:";
            // 
            // observacionesLabel
            // 
            observacionesLabel.AutoSize = true;
            observacionesLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            observacionesLabel.Location = new System.Drawing.Point(58, 235);
            observacionesLabel.Name = "observacionesLabel";
            observacionesLabel.Size = new System.Drawing.Size(82, 13);
            observacionesLabel.TabIndex = 5;
            observacionesLabel.Text = "Observaciones:";
            // 
            // Tipo_CB
            // 
            this.Tipo_CB.DataSource = this.Datos_Tipo;
            this.Tipo_CB.DisplayMember = "Texto";
            this.Tipo_CB.FormattingEnabled = true;
            this.Tipo_CB.Location = new System.Drawing.Point(88, 36);
            this.Tipo_CB.Name = "Tipo_CB";
            this.Tipo_CB.Size = new System.Drawing.Size(179, 21);
            this.Tipo_CB.TabIndex = 0;
            this.Tipo_CB.ValueMember = "Oid";
            this.Tipo_CB.SelectedValueChanged += new System.EventHandler(this.Tipo_CB_SelectedValueChanged);
            // 
            // Datos_Tipo
            // 
            this.Datos_Tipo.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo :";
            // 
            // Nombre_CB
            // 
            this.Nombre_CB.DataSource = this.Datos_Curso;
            this.Nombre_CB.DisplayMember = "Texto";
            this.Nombre_CB.FormattingEnabled = true;
            this.Nombre_CB.Location = new System.Drawing.Point(88, 83);
            this.Nombre_CB.Name = "Nombre_CB";
            this.Nombre_CB.Size = new System.Drawing.Size(179, 21);
            this.Nombre_CB.TabIndex = 2;
            this.Nombre_CB.ValueMember = "Oid";
            this.Nombre_CB.SelectedValueChanged += new System.EventHandler(this.Nombre_CB_SelectedValueChanged);
            // 
            // Datos_Curso
            // 
            this.Datos_Curso.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre :";
            // 
            // Referencia_GB
            // 
            this.Referencia_GB.Controls.Add(this.Tipo_CB);
            this.Referencia_GB.Controls.Add(this.label1);
            this.Referencia_GB.Controls.Add(this.label2);
            this.Referencia_GB.Controls.Add(this.Nombre_CB);
            this.Referencia_GB.Location = new System.Drawing.Point(155, 21);
            this.Referencia_GB.Name = "Referencia_GB";
            this.Referencia_GB.Size = new System.Drawing.Size(295, 126);
            this.Referencia_GB.TabIndex = 4;
            this.Referencia_GB.TabStop = false;
            this.Referencia_GB.Text = "Referencia";
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Nombre", true));
            this.nombreTextBox.Location = new System.Drawing.Point(146, 188);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(401, 21);
            this.nombreTextBox.TabIndex = 5;
            // 
            // observacionesTextBox
            // 
            this.observacionesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Observaciones", true));
            this.observacionesTextBox.Location = new System.Drawing.Point(146, 232);
            this.observacionesTextBox.Multiline = true;
            this.observacionesTextBox.Name = "observacionesTextBox";
            this.observacionesTextBox.Size = new System.Drawing.Size(401, 83);
            this.observacionesTextBox.TabIndex = 6;
            // 
            // Datos_Alumnos
            // 
            this.Datos_Alumnos.DataSource = typeof(moleQule.Library.Instruction.Material_Alumno);
            // 
            // Alumnos_Grid
            // 
            this.Alumnos_Grid.AllowUserToOrderColumns = true;
            this.Alumnos_Grid.AutoGenerateColumns = false;
            this.Alumnos_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Entregado,
            this.Alumno_CBC});
            this.Alumnos_Grid.DataSource = this.Datos_Alumnos;
            this.Alumnos_Grid.Location = new System.Drawing.Point(50, 352);
            this.Alumnos_Grid.Name = "Alumnos_Grid";
            this.Alumnos_Grid.Size = new System.Drawing.Size(497, 294);
            this.Alumnos_Grid.TabIndex = 6;
            this.Alumnos_Grid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Alumnos_Grid_CellValueChanged);
            this.Alumnos_Grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Alumnos_Grid_DataBindingComplete);
            this.Alumnos_Grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Alumnos_Grid_DataError);
            // 
            // Datos_Promociones
            // 
            this.Datos_Promociones.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // Datos_ComboAlumnos
            // 
            this.Datos_ComboAlumnos.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(27, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(613, 696);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Referencia_GB);
            this.tabPage1.Controls.Add(this.Alumnos_Grid);
            this.tabPage1.Controls.Add(this.nombreTextBox);
            this.tabPage1.Controls.Add(observacionesLabel);
            this.tabPage1.Controls.Add(nombreLabel);
            this.tabPage1.Controls.Add(this.observacionesTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(605, 670);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Delete_Button);
            this.tabPage2.Controls.Add(this.Edit_Button);
            this.tabPage2.Controls.Add(this.Add_Button);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.Revisiones_Grid);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(605, 670);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Revisiones";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Delete_Button
            // 
            this.Delete_Button.Location = new System.Drawing.Point(388, 609);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(118, 23);
            this.Delete_Button.TabIndex = 4;
            this.Delete_Button.Text = "Borrar Revisión";
            this.Delete_Button.UseVisualStyleBackColor = true;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Edit_Button
            // 
            this.Edit_Button.Location = new System.Drawing.Point(239, 609);
            this.Edit_Button.Name = "Edit_Button";
            this.Edit_Button.Size = new System.Drawing.Size(118, 23);
            this.Edit_Button.TabIndex = 3;
            this.Edit_Button.Text = "Editar Revisión";
            this.Edit_Button.UseVisualStyleBackColor = true;
            this.Edit_Button.Click += new System.EventHandler(this.Edit_Button_Click);
            // 
            // Add_Button
            // 
            this.Add_Button.Location = new System.Drawing.Point(98, 609);
            this.Add_Button.Name = "Add_Button";
            this.Add_Button.Size = new System.Drawing.Size(118, 23);
            this.Add_Button.TabIndex = 2;
            this.Add_Button.Text = "Nueva Revisión";
            this.Add_Button.UseVisualStyleBackColor = true;
            this.Add_Button.Click += new System.EventHandler(this.Add_Button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "REVISIONES";
            // 
            // Revisiones_Grid
            // 
            this.Revisiones_Grid.AllowUserToAddRows = false;
            this.Revisiones_Grid.AllowUserToDeleteRows = false;
            this.Revisiones_Grid.AllowUserToOrderColumns = true;
            this.Revisiones_Grid.AutoGenerateColumns = false;
            this.Revisiones_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Autor,
            this.Version,
            this.Fecha,
            this.Observaciones});
            this.Revisiones_Grid.DataSource = this.Datos_Revisiones;
            this.Revisiones_Grid.Location = new System.Drawing.Point(0, 58);
            this.Revisiones_Grid.Name = "Revisiones_Grid";
            this.Revisiones_Grid.ReadOnly = true;
            this.Revisiones_Grid.Size = new System.Drawing.Size(605, 518);
            this.Revisiones_Grid.TabIndex = 0;
            this.Revisiones_Grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Revisiones_Grid_CellDoubleClick);
            // 
            // Autor
            // 
            this.Autor.DataPropertyName = "Autor";
            this.Autor.HeaderText = "Autor";
            this.Autor.Name = "Autor";
            this.Autor.ReadOnly = true;
            this.Autor.Width = 200;
            // 
            // Version
            // 
            this.Version.DataPropertyName = "Version";
            this.Version.HeaderText = "Versión";
            this.Version.Name = "Version";
            this.Version.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Observaciones
            // 
            this.Observaciones.DataPropertyName = "Observaciones";
            this.Observaciones.HeaderText = "Observaciones";
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.ReadOnly = true;
            // 
            // Datos_Revisiones
            // 
            this.Datos_Revisiones.DataSource = typeof(moleQule.Library.Instruction.RevisionMaterial);
            // 
            // Entregado
            // 
            this.Entregado.DataPropertyName = "Entregado";
            this.Entregado.HeaderText = "Entregado";
            this.Entregado.Name = "Entregado";
            this.Entregado.Width = 70;
            // 
            // Alumno_CBC
            // 
            this.Alumno_CBC.DataPropertyName = "OidAlumno";
            this.Alumno_CBC.DataSource = this.Datos_ComboAlumnos;
            this.Alumno_CBC.DisplayMember = "Texto";
            this.Alumno_CBC.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Alumno_CBC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Alumno_CBC.HeaderText = "Alumno";
            this.Alumno_CBC.Name = "Alumno_CBC";
            this.Alumno_CBC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Alumno_CBC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Alumno_CBC.ValueMember = "Oid";
            // 
            // MaterialForm
            // 
            this.ClientSize = new System.Drawing.Size(669, 780);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MaterialForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "MaterialForm";
            this.PanelesV.Panel1.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Tipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Curso)).EndInit();
            this.Referencia_GB.ResumeLayout(false);
            this.Referencia_GB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Alumnos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Alumnos_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Promociones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_ComboAlumnos)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Revisiones_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Revisiones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Referencia_GB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox observacionesTextBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        protected System.Windows.Forms.BindingSource Datos_Alumnos;
        protected System.Windows.Forms.DataGridView Alumnos_Grid;
        protected System.Windows.Forms.BindingSource Datos_ComboAlumnos;
        protected System.Windows.Forms.BindingSource Datos_Tipo;
        protected System.Windows.Forms.BindingSource Datos_Curso;
        protected System.Windows.Forms.ComboBox Tipo_CB;
        protected System.Windows.Forms.ComboBox Nombre_CB;
        protected System.Windows.Forms.BindingSource Datos_Promociones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Autor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observaciones;
        private System.Windows.Forms.Button Delete_Button;
        private System.Windows.Forms.Button Edit_Button;
        private System.Windows.Forms.Button Add_Button;
        protected System.Windows.Forms.BindingSource Datos_Revisiones;
        protected System.Windows.Forms.DataGridView Revisiones_Grid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Entregado;
        private System.Windows.Forms.DataGridViewComboBoxColumn Alumno_CBC;
    }
}
