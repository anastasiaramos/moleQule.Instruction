namespace moleQule.Face.Instruction
{
    partial class ConvocatoriaForm
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
            System.Windows.Forms.Label codigoLabel;
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label fechaInicioLabel;
            System.Windows.Forms.Label fechaCaducidadLabel;
            System.Windows.Forms.Label observacionesLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConvocatoriaForm));
            this.Codigo_TB = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fechaCaducidadDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fechaInicioDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.observacionesTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Alumnos_Grid = new System.Windows.Forms.DataGridView();
            this.Datos_Alumnos = new System.Windows.Forms.BindingSource(this.components);
            this.Matricular_B = new System.Windows.Forms.Button();
            this.Eliminar_B = new System.Windows.Forms.Button();
            this.ImprimirM_BT = new System.Windows.Forms.Button();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new CalendarColumn();
            codigoLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            fechaInicioLabel = new System.Windows.Forms.Label();
            fechaCaducidadLabel = new System.Windows.Forms.Label();
            observacionesLabel = new System.Windows.Forms.Label();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            this.Paneles2.Panel1.SuspendLayout();
            this.Paneles2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Alumnos_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Alumnos)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.AutoScroll = true;
            this.PanelesV.Panel1.Controls.Add(this.ImprimirM_BT);
            this.PanelesV.Panel1.Controls.Add(this.Eliminar_B);
            this.PanelesV.Panel1.Controls.Add(this.Matricular_B);
            this.PanelesV.Panel1.Controls.Add(this.Alumnos_Grid);
            this.PanelesV.Panel1.Controls.Add(this.label1);
            this.PanelesV.Panel1.Controls.Add(observacionesLabel);
            this.PanelesV.Panel1.Controls.Add(this.observacionesTextBox);
            this.PanelesV.Panel1.Controls.Add(this.groupBox1);
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(626, 639);
            this.PanelesV.SplitterDistance = 598;
            // 
            // Submit_BT
            // 
            this.Submit_BT.Location = new System.Drawing.Point(251, 6);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            // 
            // Cancel_BT
            // 
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
            this.Paneles2.Size = new System.Drawing.Size(624, 38);
            this.Paneles2.SplitterDistance = 37;
            // 
            // Imprimir_Button
            // 
            this.Imprimir_Button.Location = new System.Drawing.Point(161, 6);
            this.HelpProvider.SetShowHelp(this.Imprimir_Button, true);
            // 
            // Docs_BT
            // 
            this.Docs_BT.Location = new System.Drawing.Point(300, 6);
            this.HelpProvider.SetShowHelp(this.Docs_BT, true);
            // 
            // Datos
            // 
            this.Datos.DataSource = typeof(moleQule.Library.Instruction.Convocatoria_Curso);
            // 
            // codigoLabel
            // 
            codigoLabel.AutoSize = true;
            codigoLabel.Location = new System.Drawing.Point(18, 32);
            codigoLabel.Name = "codigoLabel";
            codigoLabel.Size = new System.Drawing.Size(48, 13);
            codigoLabel.TabIndex = 0;
            codigoLabel.Text = "Código:";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(200, 32);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(54, 13);
            nombreLabel.TabIndex = 2;
            nombreLabel.Text = "Nombre:";
            // 
            // fechaInicioLabel
            // 
            fechaInicioLabel.AutoSize = true;
            fechaInicioLabel.Location = new System.Drawing.Point(63, 79);
            fechaInicioLabel.Name = "fechaInicioLabel";
            fechaInicioLabel.Size = new System.Drawing.Size(77, 13);
            fechaInicioLabel.TabIndex = 4;
            fechaInicioLabel.Text = "Fecha Inicio:";
            // 
            // fechaCaducidadLabel
            // 
            fechaCaducidadLabel.AutoSize = true;
            fechaCaducidadLabel.Location = new System.Drawing.Point(319, 79);
            fechaCaducidadLabel.Name = "fechaCaducidadLabel";
            fechaCaducidadLabel.Size = new System.Drawing.Size(62, 13);
            fechaCaducidadLabel.TabIndex = 6;
            fechaCaducidadLabel.Text = "Fecha Fin:";
            // 
            // observacionesLabel
            // 
            observacionesLabel.AutoSize = true;
            observacionesLabel.Location = new System.Drawing.Point(70, 148);
            observacionesLabel.Name = "observacionesLabel";
            observacionesLabel.Size = new System.Drawing.Size(93, 13);
            observacionesLabel.TabIndex = 2;
            observacionesLabel.Text = "Observaciones:";
            // 
            // Codigo_TB
            // 
            this.Codigo_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Codigo", true));
            this.Codigo_TB.Location = new System.Drawing.Point(72, 29);
            this.Codigo_TB.Name = "Codigo_TB";
            this.Codigo_TB.ReadOnly = true;
            this.Codigo_TB.Size = new System.Drawing.Size(100, 21);
            this.Codigo_TB.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(fechaCaducidadLabel);
            this.groupBox1.Controls.Add(this.fechaCaducidadDateTimePicker);
            this.groupBox1.Controls.Add(fechaInicioLabel);
            this.groupBox1.Controls.Add(this.fechaInicioDateTimePicker);
            this.groupBox1.Controls.Add(nombreLabel);
            this.groupBox1.Controls.Add(this.nombreTextBox);
            this.groupBox1.Controls.Add(codigoLabel);
            this.groupBox1.Controls.Add(this.Codigo_TB);
            this.groupBox1.Location = new System.Drawing.Point(35, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 128);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // fechaCaducidadDateTimePicker
            // 
            this.fechaCaducidadDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.Datos, "FechaCaducidad", true));
            this.fechaCaducidadDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaCaducidadDateTimePicker.Location = new System.Drawing.Point(387, 75);
            this.fechaCaducidadDateTimePicker.Name = "fechaCaducidadDateTimePicker";
            this.fechaCaducidadDateTimePicker.Size = new System.Drawing.Size(108, 21);
            this.fechaCaducidadDateTimePicker.TabIndex = 7;
            // 
            // fechaInicioDateTimePicker
            // 
            this.fechaInicioDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.Datos, "FechaInicio", true));
            this.fechaInicioDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaInicioDateTimePicker.Location = new System.Drawing.Point(146, 75);
            this.fechaInicioDateTimePicker.Name = "fechaInicioDateTimePicker";
            this.fechaInicioDateTimePicker.Size = new System.Drawing.Size(110, 21);
            this.fechaInicioDateTimePicker.TabIndex = 5;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Nombre", true));
            this.nombreTextBox.Location = new System.Drawing.Point(260, 29);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(272, 21);
            this.nombreTextBox.TabIndex = 3;
            // 
            // observacionesTextBox
            // 
            this.observacionesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Observaciones", true));
            this.observacionesTextBox.Location = new System.Drawing.Point(169, 145);
            this.observacionesTextBox.Multiline = true;
            this.observacionesTextBox.Name = "observacionesTextBox";
            this.observacionesTextBox.Size = new System.Drawing.Size(383, 88);
            this.observacionesTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "ALUMNOS MATRICULADOS";
            // 
            // Alumnos_Grid
            // 
            this.Alumnos_Grid.AllowUserToOrderColumns = true;
            this.Alumnos_Grid.AutoGenerateColumns = false;
            this.Alumnos_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Cliente,
            this.Fecha});
            this.Alumnos_Grid.DataSource = this.Datos_Alumnos;
            this.Alumnos_Grid.Location = new System.Drawing.Point(44, 276);
            this.Alumnos_Grid.Name = "Alumnos_Grid";
            this.Alumnos_Grid.Size = new System.Drawing.Size(558, 270);
            this.Alumnos_Grid.TabIndex = 4;
            // 
            // Datos_Alumnos
            // 
            this.Datos_Alumnos.DataSource = typeof(moleQule.Library.Instruction.Alumno_Convocatoria);
            // 
            // Matricular_B
            // 
            this.Matricular_B.Location = new System.Drawing.Point(165, 561);
            this.Matricular_B.Name = "Matricular_B";
            this.Matricular_B.Size = new System.Drawing.Size(75, 23);
            this.Matricular_B.TabIndex = 5;
            this.Matricular_B.Text = "Matricular";
            this.Matricular_B.UseVisualStyleBackColor = true;
            this.Matricular_B.Click += new System.EventHandler(this.Matricular_B_Click);
            // 
            // Eliminar_B
            // 
            this.Eliminar_B.Location = new System.Drawing.Point(246, 561);
            this.Eliminar_B.Name = "Eliminar_B";
            this.Eliminar_B.Size = new System.Drawing.Size(75, 23);
            this.Eliminar_B.TabIndex = 6;
            this.Eliminar_B.Text = "Eliminar";
            this.Eliminar_B.UseVisualStyleBackColor = true;
            this.Eliminar_B.Click += new System.EventHandler(this.Eliminar_B_Click);
            // 
            // ImprimirM_BT
            // 
            this.ImprimirM_BT.Location = new System.Drawing.Point(327, 561);
            this.ImprimirM_BT.Name = "ImprimirM_BT";
            this.ImprimirM_BT.Size = new System.Drawing.Size(133, 23);
            this.ImprimirM_BT.TabIndex = 7;
            this.ImprimirM_BT.Text = "Imprimir Matrícula";
            this.ImprimirM_BT.UseVisualStyleBackColor = true;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Cliente
            // 
            this.Cliente.DataPropertyName = "Cliente";
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Fecha.Width = 75;
            // 
            // ConvocatoriaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(626, 639);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConvocatoriaForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "ConvocatoriaForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConvocatoriaForm_FormClosing);
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel1.PerformLayout();
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            this.Paneles2.Panel1.ResumeLayout(false);
            this.Paneles2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Alumnos_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Alumnos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Codigo_TB;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.DateTimePicker fechaInicioDateTimePicker;
        private System.Windows.Forms.DateTimePicker fechaCaducidadDateTimePicker;
        private System.Windows.Forms.TextBox observacionesTextBox;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.BindingSource Datos_Alumnos;
        protected System.Windows.Forms.DataGridView Alumnos_Grid;
        private System.Windows.Forms.Button Eliminar_B;
        private System.Windows.Forms.Button Matricular_B;
        private System.Windows.Forms.Button ImprimirM_BT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private CalendarColumn Fecha;
    }
}
