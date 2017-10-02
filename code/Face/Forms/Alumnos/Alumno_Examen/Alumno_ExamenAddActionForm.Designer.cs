namespace moleQule.Face.Instruction
{
    partial class Alumno_ExamenAddActionForm
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
            this.Datos = new System.Windows.Forms.BindingSource(this.components);
            this.Datos_Examenes = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Calificacion_TB = new System.Windows.Forms.TextBox();
            this.Observaciones_TB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Respuestas_Grid = new System.Windows.Forms.DataGridView();
            this.Datos_Opciones = new System.Windows.Forms.BindingSource(this.components);
            this.Datos_Respuestas = new System.Windows.Forms.BindingSource(this.components);
            this.Examen_TB = new System.Windows.Forms.TextBox();
            this.Examen_BT = new System.Windows.Forms.Button();
            this.Orden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pregunta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opcion_CBC = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Correcta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Source_GB.SuspendLayout();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Examenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Respuestas_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Opciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Respuestas)).BeginInit();
            this.SuspendLayout();
            // 
            // Submit_BT
            // 
            this.Submit_BT.Location = new System.Drawing.Point(73, 8);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Location = new System.Drawing.Point(163, 8);
            this.HelpProvider.SetShowHelp(this.Cancel_BT, true);
            // 
            // Source_GB
            // 
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
            // Datos
            // 
            this.Datos.DataSource = typeof(moleQule.Library.Instruction.Alumno_Examen);
            // 
            // Datos_Examenes
            // 
            this.Datos_Examenes.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Examen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Calificación:";
            // 
            // Calificacion_TB
            // 
            this.Calificacion_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Calificacion", true));
            this.Calificacion_TB.Location = new System.Drawing.Point(122, 57);
            this.Calificacion_TB.Name = "Calificacion_TB";
            this.Calificacion_TB.Size = new System.Drawing.Size(98, 21);
            this.Calificacion_TB.TabIndex = 3;
            // 
            // Observaciones_TB
            // 
            this.Observaciones_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Observaciones", true));
            this.Observaciones_TB.Location = new System.Drawing.Point(122, 93);
            this.Observaciones_TB.Multiline = true;
            this.Observaciones_TB.Name = "Observaciones_TB";
            this.Observaciones_TB.Size = new System.Drawing.Size(715, 51);
            this.Observaciones_TB.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
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
            this.Opcion_CBC,
            this.Correcta});
            this.Respuestas_Grid.DataSource = this.Datos_Respuestas;
            this.Respuestas_Grid.Location = new System.Drawing.Point(11, 186);
            this.Respuestas_Grid.Name = "Respuestas_Grid";
            this.Respuestas_Grid.Size = new System.Drawing.Size(860, 363);
            this.Respuestas_Grid.TabIndex = 2;
            this.Respuestas_Grid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Respuestas_Grid_CellValueChanged);
            this.Respuestas_Grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Respuestas_Grid_DataBindingComplete);
            // 
            // Datos_Opciones
            // 
            this.Datos_Opciones.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // Datos_Respuestas
            // 
            this.Datos_Respuestas.DataSource = typeof(moleQule.Library.Instruction.Respuesta_Alumno_Examen);
            // 
            // Examen_TB
            // 
            this.Examen_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Calificacion", true));
            this.Examen_TB.Location = new System.Drawing.Point(122, 20);
            this.Examen_TB.Name = "Examen_TB";
            this.Examen_TB.Size = new System.Drawing.Size(519, 21);
            this.Examen_TB.TabIndex = 6;
            // 
            // Examen_BT
            // 
            this.Examen_BT.Image = global::moleQule.Face.Instruction.Properties.Resources.select_16;
            this.Examen_BT.Location = new System.Drawing.Point(647, 20);
            this.Examen_BT.Name = "Examen_BT";
            this.Examen_BT.Size = new System.Drawing.Size(27, 21);
            this.Examen_BT.TabIndex = 49;
            this.Examen_BT.UseVisualStyleBackColor = true;
            this.Examen_BT.Click += new System.EventHandler(this.Examen_BT_Click);
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
            this.Pregunta.Width = 600;
            // 
            // Opcion_CBC
            // 
            this.Opcion_CBC.DataPropertyName = "Opcion";
            this.Opcion_CBC.DataSource = this.Datos_Opciones;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Opcion_CBC.DefaultCellStyle = dataGridViewCellStyle2;
            this.Opcion_CBC.DisplayMember = "Texto";
            this.Opcion_CBC.HeaderText = "Opción";
            this.Opcion_CBC.Name = "Opcion_CBC";
            this.Opcion_CBC.ValueMember = "Texto";
            this.Opcion_CBC.Width = 60;
            // 
            // Correcta
            // 
            this.Correcta.HeaderText = "Correcta";
            this.Correcta.Name = "Correcta";
            this.Correcta.ReadOnly = true;
            this.Correcta.Width = 60;
            // 
            // Alumno_ExamenAddActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(884, 604);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "Alumno_ExamenAddActionForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "Notas del Examen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Alumno_ExamenActionForm_FormClosing);
            this.Source_GB.ResumeLayout(false);
            this.Source_GB.PerformLayout();
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Examenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Respuestas_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Opciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Respuestas)).EndInit();
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
        private System.Windows.Forms.Button Examen_BT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Orden;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pregunta;
        private System.Windows.Forms.DataGridViewComboBoxColumn Opcion_CBC;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Correcta;
    }
}
