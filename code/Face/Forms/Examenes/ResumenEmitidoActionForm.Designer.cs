namespace moleQule.Face.Instruction
{
    partial class ResumenEmitidoActionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResumenEmitidoActionForm));
            this.Preguntas_Grid = new System.Windows.Forms.DataGridView();
            this.tituloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nivelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nPreguntasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datos_Preguntas = new System.Windows.Forms.BindingSource(this.components);
            this.Modulo_TB = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.Preguntas_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Preguntas)).BeginInit();
            this.SuspendLayout();
            // 
            // Print_BT
            // 
            this.Print_BT.Enabled = true;
            this.Print_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ErrorMng_EP.SetIconAlignment(this.Print_BT, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.Print_BT.Location = new System.Drawing.Point(251, 2);
            this.HelpProvider.SetShowHelp(this.Print_BT, true);
            this.Print_BT.Visible = true;
            // 
            // Submit_BT
            // 
            this.Submit_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ErrorMng_EP.SetIconAlignment(this.Submit_BT, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.Submit_BT.Location = new System.Drawing.Point(73, 8);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ErrorMng_EP.SetIconAlignment(this.Cancel_BT, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.Cancel_BT.Location = new System.Drawing.Point(163, 8);
            this.HelpProvider.SetShowHelp(this.Cancel_BT, true);
            // 
            // Source_GB
            // 
            this.Source_GB.Controls.Add(this.Preguntas_Grid);
            this.Source_GB.Location = new System.Drawing.Point(3, 69);
            this.HelpProvider.SetShowHelp(this.Source_GB, true);
            this.Source_GB.Size = new System.Drawing.Size(622, 327);
            this.Source_GB.Text = "Nº Preguntas";
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.Controls.Add(this.Modulo_TB);
            this.PanelesV.Panel1.Controls.Add(this.groupBox1);
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(632, 441);
            this.PanelesV.SplitterDistance = 401;
            // 
            // Progress_Panel
            // 
            this.Progress_Panel.Location = new System.Drawing.Point(112, 24);
            // 
            // ProgressBK_Panel
            // 
            this.ProgressBK_Panel.Size = new System.Drawing.Size(632, 441);
            // 
            // ProgressInfo_PB
            // 
            this.ProgressInfo_PB.Location = new System.Drawing.Point(284, 272);
            // 
            // Progress_PB
            // 
            this.Progress_PB.Location = new System.Drawing.Point(284, 187);
            // 
            // Preguntas_Grid
            // 
            this.Preguntas_Grid.AllowUserToAddRows = false;
            this.Preguntas_Grid.AllowUserToDeleteRows = false;
            this.Preguntas_Grid.AutoGenerateColumns = false;
            this.Preguntas_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Preguntas_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tituloDataGridViewTextBoxColumn,
            this.nivelDataGridViewTextBoxColumn,
            this.nPreguntasDataGridViewTextBoxColumn});
            this.Preguntas_Grid.DataSource = this.Datos_Preguntas;
            this.Preguntas_Grid.Location = new System.Drawing.Point(4, 20);
            this.Preguntas_Grid.Name = "Preguntas_Grid";
            this.Preguntas_Grid.ReadOnly = true;
            this.Preguntas_Grid.Size = new System.Drawing.Size(613, 301);
            this.Preguntas_Grid.TabIndex = 0;
            // 
            // tituloDataGridViewTextBoxColumn
            // 
            this.tituloDataGridViewTextBoxColumn.DataPropertyName = "Titulo";
            this.tituloDataGridViewTextBoxColumn.HeaderText = "Submódulo";
            this.tituloDataGridViewTextBoxColumn.Name = "tituloDataGridViewTextBoxColumn";
            this.tituloDataGridViewTextBoxColumn.ReadOnly = true;
            this.tituloDataGridViewTextBoxColumn.Width = 380;
            // 
            // nivelDataGridViewTextBoxColumn
            // 
            this.nivelDataGridViewTextBoxColumn.DataPropertyName = "Nivel";
            this.nivelDataGridViewTextBoxColumn.HeaderText = "Tema";
            this.nivelDataGridViewTextBoxColumn.Name = "nivelDataGridViewTextBoxColumn";
            this.nivelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nPreguntasDataGridViewTextBoxColumn
            // 
            this.nPreguntasDataGridViewTextBoxColumn.DataPropertyName = "NPreguntas";
            this.nPreguntasDataGridViewTextBoxColumn.HeaderText = "Preguntas";
            this.nPreguntasDataGridViewTextBoxColumn.Name = "nPreguntasDataGridViewTextBoxColumn";
            this.nPreguntasDataGridViewTextBoxColumn.ReadOnly = true;
            this.nPreguntasDataGridViewTextBoxColumn.Width = 80;
            // 
            // Datos_Preguntas
            // 
            this.Datos_Preguntas.DataSource = typeof(moleQule.Library.Instruction.RegistroResumen);
            // 
            // Modulo_TB
            // 
            this.Modulo_TB.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Modulo_TB.Location = new System.Drawing.Point(75, 30);
            this.Modulo_TB.Name = "Modulo_TB";
            this.Modulo_TB.ReadOnly = true;
            this.Modulo_TB.Size = new System.Drawing.Size(480, 27);
            this.Modulo_TB.TabIndex = 2;
            this.Modulo_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(69, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 52);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Módulo";
            // 
            // ResumenEmitidoActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(632, 441);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ResumenEmitidoActionForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResumenActionForm_FormClosing);
            this.Source_GB.ResumeLayout(false);
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel1.PerformLayout();
            this.PanelesV.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelesV)).EndInit();
            this.PanelesV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMng_EP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).EndInit();
            this.Progress_Panel.ResumeLayout(false);
            this.Progress_Panel.PerformLayout();
            this.ProgressBK_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Progress_PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Preguntas_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Preguntas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Preguntas_Grid;
        private System.Windows.Forms.BindingSource Datos_Preguntas;
        private System.Windows.Forms.TextBox Modulo_TB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tituloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nPreguntasDataGridViewTextBoxColumn;
    }
}
