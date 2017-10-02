namespace moleQule.Face.Instruction
{
    partial class VerPreguntasActionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerPreguntasActionForm));
            this.Navegador = new System.Windows.Forms.BindingNavigator(this.components);
            this.Datos_Preguntas = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.Pregunta_TB = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gdfd = new System.Windows.Forms.GroupBox();
            this.RespuestaC_TB = new System.Windows.Forms.TextBox();
            this.CorrectaC_CB = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RespuestaB_TB = new System.Windows.Forms.TextBox();
            this.CorrectaB_CB = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RespuestaA_TB = new System.Windows.Forms.TextBox();
            this.CorrectaA_CB = new System.Windows.Forms.CheckBox();
            this.Source_GB.SuspendLayout();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Navegador)).BeginInit();
            this.Navegador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Preguntas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gdfd.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Submit_BT
            // 
            this.Submit_BT.Location = new System.Drawing.Point(73, 8);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Location = new System.Drawing.Point(163, 8);
            // 
            // Source_GB
            // 
            this.Source_GB.Controls.Add(this.Pregunta_TB);
            this.Source_GB.Location = new System.Drawing.Point(6, 28);
            this.Source_GB.Size = new System.Drawing.Size(464, 117);
            this.Source_GB.Text = "Pregunta";
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.Controls.Add(this.groupBox1);
            this.PanelesV.Panel1.Controls.Add(this.Navegador);
            this.PanelesV.Size = new System.Drawing.Size(478, 512);
            this.PanelesV.SplitterDistance = 472;
            // 
            // Navegador
            // 
            this.Navegador.AddNewItem = null;
            this.Navegador.BindingSource = this.Datos_Preguntas;
            this.Navegador.CountItem = this.bindingNavigatorCountItem;
            this.Navegador.DeleteItem = null;
            this.Navegador.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.Navegador.Location = new System.Drawing.Point(0, 0);
            this.Navegador.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.Navegador.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.Navegador.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.Navegador.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.Navegador.Name = "Navegador";
            this.Navegador.PositionItem = this.bindingNavigatorPositionItem;
            this.Navegador.Size = new System.Drawing.Size(476, 25);
            this.Navegador.TabIndex = 2;
            this.Navegador.Text = "bindingNavigator1";
            // 
            // Datos_Preguntas
            // 
            this.Datos_Preguntas.DataSource = typeof(moleQule.Library.Instruction.PreguntaExamen);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(38, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Mover primero";
            this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Mover anterior";
            this.bindingNavigatorMovePreviousItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Posición";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posición actual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Mover siguiente";
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Mover último";
            this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
            // 
            // Pregunta_TB
            // 
            this.Pregunta_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos_Preguntas, "Texto", true));
            this.Pregunta_TB.Enabled = false;
            this.Pregunta_TB.Location = new System.Drawing.Point(8, 20);
            this.Pregunta_TB.Multiline = true;
            this.Pregunta_TB.Name = "Pregunta_TB";
            this.Pregunta_TB.Size = new System.Drawing.Size(450, 91);
            this.Pregunta_TB.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gdfd);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(6, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 314);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Respuestas";
            // 
            // gdfd
            // 
            this.gdfd.Controls.Add(this.RespuestaC_TB);
            this.gdfd.Controls.Add(this.CorrectaC_CB);
            this.gdfd.Location = new System.Drawing.Point(7, 211);
            this.gdfd.Name = "gdfd";
            this.gdfd.Size = new System.Drawing.Size(449, 94);
            this.gdfd.TabIndex = 3;
            this.gdfd.TabStop = false;
            this.gdfd.Text = "C";
            // 
            // RespuestaC_TB
            // 
            this.RespuestaC_TB.Enabled = false;
            this.RespuestaC_TB.Location = new System.Drawing.Point(28, 12);
            this.RespuestaC_TB.Multiline = true;
            this.RespuestaC_TB.Name = "RespuestaC_TB";
            this.RespuestaC_TB.Size = new System.Drawing.Size(415, 76);
            this.RespuestaC_TB.TabIndex = 1;
            // 
            // CorrectaC_CB
            // 
            this.CorrectaC_CB.AutoSize = true;
            this.CorrectaC_CB.Enabled = false;
            this.CorrectaC_CB.Location = new System.Drawing.Point(7, 21);
            this.CorrectaC_CB.Name = "CorrectaC_CB";
            this.CorrectaC_CB.Size = new System.Drawing.Size(15, 14);
            this.CorrectaC_CB.TabIndex = 0;
            this.CorrectaC_CB.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CorrectaC_CB.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RespuestaB_TB);
            this.groupBox3.Controls.Add(this.CorrectaB_CB);
            this.groupBox3.Location = new System.Drawing.Point(8, 114);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(449, 94);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "B";
            // 
            // RespuestaB_TB
            // 
            this.RespuestaB_TB.Enabled = false;
            this.RespuestaB_TB.Location = new System.Drawing.Point(28, 12);
            this.RespuestaB_TB.Multiline = true;
            this.RespuestaB_TB.Name = "RespuestaB_TB";
            this.RespuestaB_TB.Size = new System.Drawing.Size(415, 76);
            this.RespuestaB_TB.TabIndex = 1;
            // 
            // CorrectaB_CB
            // 
            this.CorrectaB_CB.AutoSize = true;
            this.CorrectaB_CB.Enabled = false;
            this.CorrectaB_CB.Location = new System.Drawing.Point(7, 21);
            this.CorrectaB_CB.Name = "CorrectaB_CB";
            this.CorrectaB_CB.Size = new System.Drawing.Size(15, 14);
            this.CorrectaB_CB.TabIndex = 0;
            this.CorrectaB_CB.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CorrectaB_CB.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RespuestaA_TB);
            this.groupBox2.Controls.Add(this.CorrectaA_CB);
            this.groupBox2.Location = new System.Drawing.Point(8, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(449, 94);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "A";
            // 
            // RespuestaA_TB
            // 
            this.RespuestaA_TB.Enabled = false;
            this.RespuestaA_TB.Location = new System.Drawing.Point(28, 12);
            this.RespuestaA_TB.Multiline = true;
            this.RespuestaA_TB.Name = "RespuestaA_TB";
            this.RespuestaA_TB.Size = new System.Drawing.Size(415, 76);
            this.RespuestaA_TB.TabIndex = 1;
            // 
            // CorrectaA_CB
            // 
            this.CorrectaA_CB.AutoSize = true;
            this.CorrectaA_CB.Enabled = false;
            this.CorrectaA_CB.Location = new System.Drawing.Point(7, 21);
            this.CorrectaA_CB.Name = "CorrectaA_CB";
            this.CorrectaA_CB.Size = new System.Drawing.Size(15, 14);
            this.CorrectaA_CB.TabIndex = 0;
            this.CorrectaA_CB.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CorrectaA_CB.UseVisualStyleBackColor = true;
            // 
            // VerPreguntasActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(478, 512);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "VerPreguntasActionForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "Detalle de Preguntas del Exámen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VerPreguntasActionForm_FormClosing);
            this.Source_GB.ResumeLayout(false);
            this.Source_GB.PerformLayout();
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel1.PerformLayout();
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Navegador)).EndInit();
            this.Navegador.ResumeLayout(false);
            this.Navegador.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Preguntas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.gdfd.ResumeLayout(false);
            this.gdfd.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingNavigator Navegador;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.TextBox Pregunta_TB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox RespuestaA_TB;
        private System.Windows.Forms.CheckBox CorrectaA_CB;
        private System.Windows.Forms.GroupBox gdfd;
        private System.Windows.Forms.TextBox RespuestaC_TB;
        private System.Windows.Forms.CheckBox CorrectaC_CB;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox RespuestaB_TB;
        private System.Windows.Forms.CheckBox CorrectaB_CB;
        private System.Windows.Forms.BindingSource Datos_Preguntas;

    }
}
