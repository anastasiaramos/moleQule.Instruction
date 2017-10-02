namespace moleQule.Face.Instruction
{
    partial class NotaDesarrolloAlumnoInputForm
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
            this.Observaciones_TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Respuestas_Grid = new System.Windows.Forms.DataGridView();
            this.Presentado_CB = new System.Windows.Forms.CheckBox();
            this.Datos_Respuestas = new System.Windows.Forms.BindingSource(this.components);
            this.ordenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Calificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            this.Source_GB.SuspendLayout();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            this.ProgressBK_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Respuestas_Grid)).BeginInit();
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
            this.Source_GB.Controls.Add(this.Presentado_CB);
            this.Source_GB.Controls.Add(this.label3);
            this.Source_GB.Controls.Add(this.Respuestas_Grid);
            this.Source_GB.Controls.Add(this.label2);
            this.Source_GB.Controls.Add(this.Observaciones_TB);
            this.Source_GB.Location = new System.Drawing.Point(11, 11);
            this.HelpProvider.SetShowHelp(this.Source_GB, true);
            this.Source_GB.Size = new System.Drawing.Size(476, 274);
            this.Source_GB.Text = "";
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(500, 332);
            this.PanelesV.SplitterDistance = 292;
            // 
            // ProgressBK_Panel
            // 
            this.ProgressBK_Panel.Location = new System.Drawing.Point(46, 87);
            // 
            // Observaciones_TB
            // 
            this.Observaciones_TB.Location = new System.Drawing.Point(113, 155);
            this.Observaciones_TB.Multiline = true;
            this.Observaciones_TB.Name = "Observaciones_TB";
            this.Observaciones_TB.Size = new System.Drawing.Size(349, 107);
            this.Observaciones_TB.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Observaciones:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(306, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "NOTAS";
            // 
            // Respuestas_Grid
            // 
            this.Respuestas_Grid.AllowUserToAddRows = false;
            this.Respuestas_Grid.AllowUserToDeleteRows = false;
            this.Respuestas_Grid.AutoGenerateColumns = false;
            this.Respuestas_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Respuestas_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ordenDataGridViewTextBoxColumn,
            this.Calificacion});
            this.Respuestas_Grid.DataSource = this.Datos_Respuestas;
            this.Respuestas_Grid.Location = new System.Drawing.Point(202, 40);
            this.Respuestas_Grid.Name = "Respuestas_Grid";
            this.Respuestas_Grid.Size = new System.Drawing.Size(252, 104);
            this.Respuestas_Grid.TabIndex = 7;
            // 
            // Presentado_CB
            // 
            this.Presentado_CB.AutoSize = true;
            this.Presentado_CB.Location = new System.Drawing.Point(34, 40);
            this.Presentado_CB.Name = "Presentado_CB";
            this.Presentado_CB.Size = new System.Drawing.Size(91, 17);
            this.Presentado_CB.TabIndex = 9;
            this.Presentado_CB.Text = "Presentado";
            this.Presentado_CB.UseVisualStyleBackColor = true;
            // 
            // Datos_Respuestas
            // 
            this.Datos_Respuestas.DataSource = typeof(moleQule.Library.Instruction.Respuesta_Alumno_Examen);
            // 
            // ordenDataGridViewTextBoxColumn
            // 
            this.ordenDataGridViewTextBoxColumn.DataPropertyName = "Orden";
            this.ordenDataGridViewTextBoxColumn.HeaderText = "Orden";
            this.ordenDataGridViewTextBoxColumn.Name = "ordenDataGridViewTextBoxColumn";
            // 
            // Calificacion
            // 
            this.Calificacion.DataPropertyName = "Calificacion";
            this.Calificacion.HeaderText = "Calificación";
            this.Calificacion.Name = "Calificacion";
            // 
            // NotaDesarrolloAlumnoInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(500, 332);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "NotaDesarrolloAlumnoInputForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "Modificar Notas Alumno";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreguntasPlantillaInputForm_FormClosing);
            this.Controls.SetChildIndex(this.ProgressBK_Panel, 0);
            this.Controls.SetChildIndex(this.PanelesV, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            this.Source_GB.ResumeLayout(false);
            this.Source_GB.PerformLayout();
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            this.ProgressBK_Panel.ResumeLayout(false);
            this.ProgressBK_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Respuestas_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Respuestas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Observaciones_TB;
        private System.Windows.Forms.CheckBox Presentado_CB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView Respuestas_Grid;
        private System.Windows.Forms.BindingSource Datos_Respuestas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Calificacion;


    }
}
