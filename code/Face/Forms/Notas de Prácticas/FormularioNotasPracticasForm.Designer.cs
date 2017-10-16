namespace moleQule.Face.Instruction
{
    partial class FormularioNotasPracticasForm
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
            System.Windows.Forms.Label horaLabel;
            System.Windows.Forms.Label fechaFinalLabel;
            System.Windows.Forms.Label observacionesLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioNotasPracticasForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Hora_TB = new System.Windows.Forms.TextBox();
            this.Fecha_TB = new System.Windows.Forms.TextBox();
            this.Alumnos_Grid = new System.Windows.Forms.DataGridView();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alumno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Calificacion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Recuparada = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FechaRecuperacion = new CalendarColumn();
            this.Observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datos_Alumnos = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Horario_TB = new System.Windows.Forms.TextBox();
            this.Promocion_TB = new System.Windows.Forms.TextBox();
            this.observacionesTextBox = new System.Windows.Forms.TextBox();
            this.Instructor_TB = new System.Windows.Forms.TextBox();
            this.Clase_TB = new System.Windows.Forms.TextBox();
            this.Efectivo_Label = new System.Windows.Forms.Label();
            this.ProfesorEfectivo_TB = new System.Windows.Forms.TextBox();
            nombreLabel = new System.Windows.Forms.Label();
            fechaLabel = new System.Windows.Forms.Label();
            horaLabel = new System.Windows.Forms.Label();
            fechaFinalLabel = new System.Windows.Forms.Label();
            observacionesLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.Alumnos_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Alumnos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.AutoScroll = true;
            this.PanelesV.Panel1.Controls.Add(this.ProfesorEfectivo_TB);
            this.PanelesV.Panel1.Controls.Add(this.Efectivo_Label);
            this.PanelesV.Panel1.Controls.Add(this.Clase_TB);
            this.PanelesV.Panel1.Controls.Add(label2);
            this.PanelesV.Panel1.Controls.Add(this.Instructor_TB);
            this.PanelesV.Panel1.Controls.Add(label1);
            this.PanelesV.Panel1.Controls.Add(observacionesLabel);
            this.PanelesV.Panel1.Controls.Add(this.observacionesTextBox);
            this.PanelesV.Panel1.Controls.Add(this.groupBox2);
            this.PanelesV.Panel1.Controls.Add(this.Alumnos_Grid);
            this.PanelesV.Panel1.Controls.Add(this.groupBox1);
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(776, 706);
            this.PanelesV.SplitterDistance = 651;
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
            this.Paneles2.Size = new System.Drawing.Size(774, 52);
            this.Paneles2.SplitterDistance = 30;
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
            this.Datos.DataSource = typeof(moleQule.Library.Instruction.ParteAsistencia);
            // 
            // Progress_Panel
            // 
            this.Progress_Panel.Location = new System.Drawing.Point(209, 96);
            // 
            // ProgressBK_Panel
            // 
            this.ProgressBK_Panel.Size = new System.Drawing.Size(776, 706);
            // 
            // ProgressInfo_PB
            // 
            this.ProgressInfo_PB.Location = new System.Drawing.Point(351, 401);
            // 
            // Progress_PB
            // 
            this.Progress_PB.Location = new System.Drawing.Point(351, 316);
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nombreLabel.Location = new System.Drawing.Point(37, 19);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(60, 13);
            nombreLabel.TabIndex = 0;
            nombreLabel.Text = "Curso:";
            // 
            // fechaLabel
            // 
            fechaLabel.AutoSize = true;
            fechaLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaLabel.Location = new System.Drawing.Point(104, 19);
            fechaLabel.Name = "fechaLabel";
            fechaLabel.Size = new System.Drawing.Size(40, 13);
            fechaLabel.TabIndex = 2;
            fechaLabel.Text = "Fecha:";
            // 
            // horaLabel
            // 
            horaLabel.AutoSize = true;
            horaLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            horaLabel.Location = new System.Drawing.Point(110, 45);
            horaLabel.Name = "horaLabel";
            horaLabel.Size = new System.Drawing.Size(34, 13);
            horaLabel.TabIndex = 4;
            horaLabel.Text = "Hora:";
            // 
            // fechaFinalLabel
            // 
            fechaFinalLabel.AutoSize = true;
            fechaFinalLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaFinalLabel.Location = new System.Drawing.Point(48, 45);
            fechaFinalLabel.Name = "fechaFinalLabel";
            fechaFinalLabel.Size = new System.Drawing.Size(49, 13);
            fechaFinalLabel.TabIndex = 6;
            fechaFinalLabel.Text = "Semana:";
            // 
            // observacionesLabel
            // 
            observacionesLabel.AutoSize = true;
            observacionesLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            observacionesLabel.Location = new System.Drawing.Point(49, 165);
            observacionesLabel.Name = "observacionesLabel";
            observacionesLabel.Size = new System.Drawing.Size(82, 13);
            observacionesLabel.TabIndex = 8;
            observacionesLabel.Text = "Observaciones:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(49, 92);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(52, 13);
            label1.TabIndex = 10;
            label1.Text = "Profesor:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(399, 92);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(37, 13);
            label2.TabIndex = 12;
            label2.Text = "Clase:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Hora_TB);
            this.groupBox1.Controls.Add(this.Fecha_TB);
            this.groupBox1.Controls.Add(horaLabel);
            this.groupBox1.Controls.Add(fechaLabel);
            this.groupBox1.Location = new System.Drawing.Point(402, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 68);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sesión";
            // 
            // Hora_TB
            // 
            this.Hora_TB.Enabled = false;
            this.Hora_TB.Location = new System.Drawing.Point(150, 42);
            this.Hora_TB.Name = "Hora_TB";
            this.Hora_TB.ReadOnly = true;
            this.Hora_TB.Size = new System.Drawing.Size(76, 21);
            this.Hora_TB.TabIndex = 10;
            this.Hora_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Fecha_TB
            // 
            this.Fecha_TB.Location = new System.Drawing.Point(150, 15);
            this.Fecha_TB.Name = "Fecha_TB";
            this.Fecha_TB.ReadOnly = true;
            this.Fecha_TB.Size = new System.Drawing.Size(76, 21);
            this.Fecha_TB.TabIndex = 9;
            this.Fecha_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Alumnos_Grid
            // 
            this.Alumnos_Grid.AllowUserToAddRows = false;
            this.Alumnos_Grid.AllowUserToDeleteRows = false;
            this.Alumnos_Grid.AllowUserToOrderColumns = true;
            this.Alumnos_Grid.AutoGenerateColumns = false;
            this.Alumnos_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero,
            this.Alumno,
            this.Calificacion,
            this.Recuparada,
            this.FechaRecuperacion,
            this.Observaciones});
            this.Alumnos_Grid.DataSource = this.Datos_Alumnos;
            this.Alumnos_Grid.Location = new System.Drawing.Point(45, 213);
            this.Alumnos_Grid.Name = "Alumnos_Grid";
            this.Alumnos_Grid.Size = new System.Drawing.Size(688, 405);
            this.Alumnos_Grid.TabIndex = 7;
            this.Alumnos_Grid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.Alumnos_Grid_CellBeginEdit);
            this.Alumnos_Grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Alumnos_Grid_CellClick);
            this.Alumnos_Grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Alumnos_Grid_DataBindingComplete);
            // 
            // Numero
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Numero.DefaultCellStyle = dataGridViewCellStyle1;
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            this.Numero.Width = 80;
            // 
            // Alumno
            // 
            this.Alumno.HeaderText = "Alumno";
            this.Alumno.Name = "Alumno";
            this.Alumno.ReadOnly = true;
            this.Alumno.Width = 200;
            // 
            // Calificacion
            // 
            this.Calificacion.DataPropertyName = "Calificacion";
            this.Calificacion.HeaderText = "Calificación";
            this.Calificacion.Name = "Calificacion";
            this.Calificacion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Calificacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Recuparada
            // 
            this.Recuparada.DataPropertyName = "Recuperada";
            this.Recuparada.FalseValue = "false";
            this.Recuparada.HeaderText = "Recuperada";
            this.Recuparada.IndeterminateValue = "null";
            this.Recuparada.Name = "Recuparada";
            this.Recuparada.TrueValue = "true";
            this.Recuparada.Width = 70;
            // 
            // FechaRecuperacion
            // 
            this.FechaRecuperacion.DataPropertyName = "FechaRecuperacion";
            this.FechaRecuperacion.HeaderText = "Fecha Recuperación";
            this.FechaRecuperacion.Name = "FechaRecuperacion";
            this.FechaRecuperacion.Width = 90;
            // 
            // Observaciones
            // 
            this.Observaciones.DataPropertyName = "Observaciones";
            this.Observaciones.HeaderText = "Observaciones";
            this.Observaciones.Name = "Observaciones";
            // 
            // Datos_Alumnos
            // 
            this.Datos_Alumnos.DataSource = typeof(moleQule.Library.Instruction.Alumno_Practica);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Horario_TB);
            this.groupBox2.Controls.Add(this.Promocion_TB);
            this.groupBox2.Controls.Add(nombreLabel);
            this.groupBox2.Controls.Add(fechaFinalLabel);
            this.groupBox2.Location = new System.Drawing.Point(45, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(331, 68);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Horario";
            // 
            // Horario_TB
            // 
            this.Horario_TB.Location = new System.Drawing.Point(103, 42);
            this.Horario_TB.Name = "Horario_TB";
            this.Horario_TB.ReadOnly = true;
            this.Horario_TB.Size = new System.Drawing.Size(200, 21);
            this.Horario_TB.TabIndex = 9;
            // 
            // Promocion_TB
            // 
            this.Promocion_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Promocion", true));
            this.Promocion_TB.Location = new System.Drawing.Point(103, 15);
            this.Promocion_TB.Name = "Promocion_TB";
            this.Promocion_TB.ReadOnly = true;
            this.Promocion_TB.Size = new System.Drawing.Size(200, 21);
            this.Promocion_TB.TabIndex = 8;
            // 
            // observacionesTextBox
            // 
            this.observacionesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Observaciones", true));
            this.observacionesTextBox.Location = new System.Drawing.Point(137, 162);
            this.observacionesTextBox.Multiline = true;
            this.observacionesTextBox.Name = "observacionesTextBox";
            this.observacionesTextBox.ReadOnly = true;
            this.observacionesTextBox.Size = new System.Drawing.Size(596, 33);
            this.observacionesTextBox.TabIndex = 9;
            // 
            // Instructor_TB
            // 
            this.Instructor_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Instructor", true));
            this.Instructor_TB.Location = new System.Drawing.Point(107, 89);
            this.Instructor_TB.Name = "Instructor_TB";
            this.Instructor_TB.ReadOnly = true;
            this.Instructor_TB.Size = new System.Drawing.Size(269, 21);
            this.Instructor_TB.TabIndex = 11;
            // 
            // Clase_TB
            // 
            this.Clase_TB.Location = new System.Drawing.Point(445, 88);
            this.Clase_TB.Multiline = true;
            this.Clase_TB.Name = "Clase_TB";
            this.Clase_TB.ReadOnly = true;
            this.Clase_TB.Size = new System.Drawing.Size(288, 22);
            this.Clase_TB.TabIndex = 13;
            // 
            // Efectivo_Label
            // 
            this.Efectivo_Label.AutoSize = true;
            this.Efectivo_Label.Location = new System.Drawing.Point(49, 124);
            this.Efectivo_Label.Name = "Efectivo_Label";
            this.Efectivo_Label.Size = new System.Drawing.Size(94, 13);
            this.Efectivo_Label.TabIndex = 14;
            this.Efectivo_Label.Text = "Profesor Efectivo:";
            // 
            // ProfesorEfectivo_TB
            // 
            this.ProfesorEfectivo_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "InstructorEfectivo", true));
            this.ProfesorEfectivo_TB.Location = new System.Drawing.Point(145, 121);
            this.ProfesorEfectivo_TB.Name = "ProfesorEfectivo_TB";
            this.ProfesorEfectivo_TB.ReadOnly = true;
            this.ProfesorEfectivo_TB.Size = new System.Drawing.Size(270, 21);
            this.ProfesorEfectivo_TB.TabIndex = 15;
            // 
            // FormularioNotasPracticasForm
            // 
            this.ClientSize = new System.Drawing.Size(776, 706);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormularioNotasPracticasForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "PAsistenciaForm";
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
            ((System.ComponentModel.ISupportInitialize)(this.Alumnos_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Alumnos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        protected System.Windows.Forms.TextBox observacionesTextBox;
        protected System.Windows.Forms.BindingSource Datos_Alumnos;
        protected System.Windows.Forms.DataGridView Alumnos_Grid;
        protected System.Windows.Forms.TextBox Horario_TB;
        protected System.Windows.Forms.TextBox Promocion_TB;
        protected System.Windows.Forms.TextBox Hora_TB;
        protected System.Windows.Forms.TextBox Fecha_TB;
        protected System.Windows.Forms.TextBox Instructor_TB;
        protected System.Windows.Forms.TextBox Clase_TB;
        private System.Windows.Forms.Label Efectivo_Label;
        protected System.Windows.Forms.TextBox ProfesorEfectivo_TB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alumno;
        private System.Windows.Forms.DataGridViewButtonColumn Calificacion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Recuparada;
        private CalendarColumn FechaRecuperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observaciones;

    }
}
