namespace moleQule.Face.Instruction
{
    partial class Alumno_ExamenUIForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Calificacion_TB = new System.Windows.Forms.TextBox();
            this.Datos = new System.Windows.Forms.BindingSource(this.components);
            this.Observaciones_TB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Respuestas_Grid = new System.Windows.Forms.DataGridView();
            this.Datos_Respuestas = new System.Windows.Forms.BindingSource(this.components);
            this.Examen_TB = new System.Windows.Forms.TextBox();
            this.Examen_BT = new System.Windows.Forms.Button();
            this.Calcular_BT = new System.Windows.Forms.Button();
            this.Datos_Examenes = new System.Windows.Forms.BindingSource(this.components);
            this.Datos_Opciones = new System.Windows.Forms.BindingSource(this.components);
            this.Incorrectas_TB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Orden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pregunta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpcionCorrecta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Correcto_BC = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source_GB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelesV)).BeginInit();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMng_EP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).BeginInit();
            this.Progress_Panel.SuspendLayout();
            this.ProgressBK_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Progress_PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Respuestas_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Respuestas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Examenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Opciones)).BeginInit();
            this.SuspendLayout();
            // 
            // Print_BT
            // 
            this.Print_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Print_BT.Location = new System.Drawing.Point(215, 0);
            this.HelpProvider.SetShowHelp(this.Print_BT, true);
            // 
            // Submit_BT
            // 
            this.Submit_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Submit_BT.Location = new System.Drawing.Point(353, 8);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Cancel_BT.Location = new System.Drawing.Point(443, 8);
            this.HelpProvider.SetShowHelp(this.Cancel_BT, true);
            // 
            // Source_GB
            // 
            this.Source_GB.Controls.Add(this.Incorrectas_TB);
            this.Source_GB.Controls.Add(this.label4);
            this.Source_GB.Controls.Add(this.Calcular_BT);
            this.Source_GB.Controls.Add(this.Examen_BT);
            this.Source_GB.Controls.Add(this.Examen_TB);
            this.Source_GB.Controls.Add(this.label3);
            this.Source_GB.Controls.Add(this.Observaciones_TB);
            this.Source_GB.Controls.Add(this.Calificacion_TB);
            this.Source_GB.Controls.Add(this.label2);
            this.Source_GB.Controls.Add(this.label1);
            this.Source_GB.Location = new System.Drawing.Point(11, 11);
            this.HelpProvider.SetShowHelp(this.Source_GB, true);
            this.Source_GB.Size = new System.Drawing.Size(860, 161);
            this.Source_GB.Text = "";
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.Controls.Add(this.Respuestas_Grid);
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(884, 604);
            this.PanelesV.SplitterDistance = 564;
            // 
            // Progress_Panel
            // 
            this.Progress_Panel.Location = new System.Drawing.Point(238, 24);
            // 
            // ProgressBK_Panel
            // 
            this.ProgressBK_Panel.Size = new System.Drawing.Size(884, 604);
            // 
            // ProgressInfo_PB
            // 
            this.ProgressInfo_PB.Location = new System.Drawing.Point(410, 353);
            // 
            // Progress_PB
            // 
            this.Progress_PB.Location = new System.Drawing.Point(410, 268);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(143, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Examen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(128, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Calificación:";
            // 
            // Calificacion_TB
            // 
            this.Calificacion_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Calificacion", true));
            this.Calificacion_TB.Location = new System.Drawing.Point(198, 57);
            this.Calificacion_TB.Name = "Calificacion_TB";
            this.Calificacion_TB.Size = new System.Drawing.Size(98, 21);
            this.Calificacion_TB.TabIndex = 3;
            // 
            // Datos
            // 
            this.Datos.DataSource = typeof(moleQule.Library.Instruction.Alumno_Examen);
            // 
            // Observaciones_TB
            // 
            this.Observaciones_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Observaciones", true));
            this.Observaciones_TB.Location = new System.Drawing.Point(198, 93);
            this.Observaciones_TB.Multiline = true;
            this.Observaciones_TB.Name = "Observaciones_TB";
            this.Observaciones_TB.Size = new System.Drawing.Size(552, 51);
            this.Observaciones_TB.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(110, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Observaciones:";
            // 
            // Respuestas_Grid
            // 
            this.Respuestas_Grid.AllowUserToAddRows = false;
            this.Respuestas_Grid.AllowUserToDeleteRows = false;
            this.Respuestas_Grid.AllowUserToOrderColumns = true;
            this.Respuestas_Grid.AutoGenerateColumns = false;
            this.Respuestas_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Respuestas_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Orden,
            this.Pregunta,
            this.OpcionCorrecta,
            this.Correcto_BC,
            this.dataGridViewTextBoxColumn1});
            this.Respuestas_Grid.DataSource = this.Datos_Respuestas;
            this.Respuestas_Grid.Location = new System.Drawing.Point(11, 186);
            this.Respuestas_Grid.Name = "Respuestas_Grid";
            this.Respuestas_Grid.Size = new System.Drawing.Size(860, 363);
            this.Respuestas_Grid.TabIndex = 2;
            this.Respuestas_Grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Respuestas_Grid_CellContentClick);
            this.Respuestas_Grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Respuestas_Grid_DataBindingComplete);
            // 
            // Datos_Respuestas
            // 
            this.Datos_Respuestas.DataSource = typeof(moleQule.Library.Instruction.Respuesta_Alumno_Examen);
            // 
            // Examen_TB
            // 
            this.Examen_TB.Location = new System.Drawing.Point(198, 20);
            this.Examen_TB.Name = "Examen_TB";
            this.Examen_TB.Size = new System.Drawing.Size(519, 21);
            this.Examen_TB.TabIndex = 6;
            // 
            // Examen_BT
            // 
            this.Examen_BT.Image = global::moleQule.Face.Instruction.Properties.Resources.select_16;
            this.Examen_BT.Location = new System.Drawing.Point(723, 20);
            this.Examen_BT.Name = "Examen_BT";
            this.Examen_BT.Size = new System.Drawing.Size(27, 21);
            this.Examen_BT.TabIndex = 49;
            this.Examen_BT.UseVisualStyleBackColor = true;
            this.Examen_BT.Click += new System.EventHandler(this.Examen_BT_Click);
            // 
            // Calcular_BT
            // 
            this.Calcular_BT.Location = new System.Drawing.Point(322, 55);
            this.Calcular_BT.Name = "Calcular_BT";
            this.Calcular_BT.Size = new System.Drawing.Size(75, 23);
            this.Calcular_BT.TabIndex = 50;
            this.Calcular_BT.Text = "Calcular";
            this.Calcular_BT.UseVisualStyleBackColor = true;
            this.Calcular_BT.Click += new System.EventHandler(this.Calcular_BT_Click);
            // 
            // Datos_Examenes
            // 
            this.Datos_Examenes.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // Datos_Opciones
            // 
            this.Datos_Opciones.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // Incorrectas_TB
            // 
            this.Incorrectas_TB.Location = new System.Drawing.Point(508, 57);
            this.Incorrectas_TB.Name = "Incorrectas_TB";
            this.Incorrectas_TB.Size = new System.Drawing.Size(41, 21);
            this.Incorrectas_TB.TabIndex = 52;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(438, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 51;
            this.label4.Text = "Incorrectas:";
            // 
            // Orden
            // 
            this.Orden.DataPropertyName = "Orden";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Orden.DefaultCellStyle = dataGridViewCellStyle1;
            this.Orden.HeaderText = "Orden";
            this.Orden.Name = "Orden";
            this.Orden.ReadOnly = true;
            this.Orden.Width = 60;
            // 
            // Pregunta
            // 
            this.Pregunta.DataPropertyName = "Pregunta";
            this.Pregunta.HeaderText = "Pregunta";
            this.Pregunta.Name = "Pregunta";
            this.Pregunta.ReadOnly = true;
            this.Pregunta.Width = 540;
            // 
            // OpcionCorrecta
            // 
            this.OpcionCorrecta.DataPropertyName = "OpcionCorrecta";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.OpcionCorrecta.DefaultCellStyle = dataGridViewCellStyle2;
            this.OpcionCorrecta.HeaderText = "Opción Correcta";
            this.OpcionCorrecta.Name = "OpcionCorrecta";
            this.OpcionCorrecta.ReadOnly = true;
            this.OpcionCorrecta.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OpcionCorrecta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OpcionCorrecta.Width = 60;
            // 
            // Correcto_BC
            // 
            this.Correcto_BC.DataPropertyName = "Correcta";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = null;
            this.Correcto_BC.DefaultCellStyle = dataGridViewCellStyle3;
            this.Correcto_BC.HeaderText = "Correcto";
            this.Correcto_BC.Name = "Correcto_BC";
            this.Correcto_BC.Width = 80;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Orden";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn1.HeaderText = "Orden";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // Alumno_ExamenUIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(884, 604);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "Alumno_ExamenUIForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "Notas del Examen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Alumno_ExamenUIForm_FormClosing);
            this.Source_GB.ResumeLayout(false);
            this.Source_GB.PerformLayout();
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelesV)).EndInit();
            this.PanelesV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMng_EP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).EndInit();
            this.Progress_Panel.ResumeLayout(false);
            this.Progress_Panel.PerformLayout();
            this.ProgressBK_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Progress_PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Respuestas_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Respuestas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Examenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Opciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.BindingSource Datos_Examenes;
        protected System.Windows.Forms.TextBox Calificacion_TB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Observaciones_TB;
        protected System.Windows.Forms.BindingSource Datos_Respuestas;
        protected System.Windows.Forms.BindingSource Datos_Opciones;
        protected System.Windows.Forms.DataGridView Respuestas_Grid;
        protected System.Windows.Forms.BindingSource Datos;
        protected System.Windows.Forms.TextBox Examen_TB;
        protected System.Windows.Forms.Button Examen_BT;
        private System.Windows.Forms.Button Calcular_BT;
        protected System.Windows.Forms.TextBox Incorrectas_TB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Orden;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pregunta;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpcionCorrecta;
        private System.Windows.Forms.DataGridViewButtonColumn Correcto_BC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}
