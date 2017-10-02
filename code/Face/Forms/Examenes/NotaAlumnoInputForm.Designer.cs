namespace moleQule.Face.Instruction
{
    partial class NotaAlumnoInputForm
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
            this.Nota_TB = new System.Windows.Forms.TextBox();
            this.Observaciones_TB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Presentado_CB = new System.Windows.Forms.CheckBox();
            this.Respuestas_BT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            this.Source_GB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelesV)).BeginInit();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMng_EP)).BeginInit();
            this.ProgressBK_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).BeginInit();
            this.SuspendLayout();
            // 
            // Submit_BT
            // 
            this.Submit_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Submit_BT.Location = new System.Drawing.Point(73, 8);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Cancel_BT.Location = new System.Drawing.Point(163, 8);
            this.HelpProvider.SetShowHelp(this.Cancel_BT, true);
            // 
            // Source_GB
            // 
            this.Source_GB.Controls.Add(this.Respuestas_BT);
            this.Source_GB.Controls.Add(this.Presentado_CB);
            this.Source_GB.Controls.Add(this.label2);
            this.Source_GB.Controls.Add(this.label1);
            this.Source_GB.Controls.Add(this.Observaciones_TB);
            this.Source_GB.Controls.Add(this.Nota_TB);
            this.Source_GB.Location = new System.Drawing.Point(11, 11);
            this.HelpProvider.SetShowHelp(this.Source_GB, true);
            this.Source_GB.Size = new System.Drawing.Size(476, 186);
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
            this.PanelesV.Size = new System.Drawing.Size(500, 254);
            this.PanelesV.SplitterDistance = 214;
            // 
            // ProgressBK_Panel
            // 
            this.ProgressBK_Panel.Location = new System.Drawing.Point(46, 48);
            // 
            // Nota_TB
            // 
            this.Nota_TB.Location = new System.Drawing.Point(107, 20);
            this.Nota_TB.Name = "Nota_TB";
            this.Nota_TB.Size = new System.Drawing.Size(100, 21);
            this.Nota_TB.TabIndex = 0;
            // 
            // Observaciones_TB
            // 
            this.Observaciones_TB.Location = new System.Drawing.Point(107, 64);
            this.Observaciones_TB.Multiline = true;
            this.Observaciones_TB.Name = "Observaciones_TB";
            this.Observaciones_TB.Size = new System.Drawing.Size(349, 107);
            this.Observaciones_TB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nota:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Observaciones:";
            // 
            // Presentado_CB
            // 
            this.Presentado_CB.AutoSize = true;
            this.Presentado_CB.Location = new System.Drawing.Point(213, 24);
            this.Presentado_CB.Name = "Presentado_CB";
            this.Presentado_CB.Size = new System.Drawing.Size(91, 17);
            this.Presentado_CB.TabIndex = 4;
            this.Presentado_CB.Text = "Presentado";
            this.Presentado_CB.UseVisualStyleBackColor = true;
            this.Presentado_CB.CheckedChanged += new System.EventHandler(this.Presentado_CB_CheckedChanged);
            // 
            // Respuestas_BT
            // 
            this.Respuestas_BT.Location = new System.Drawing.Point(359, 11);
            this.Respuestas_BT.Name = "Respuestas_BT";
            this.Respuestas_BT.Size = new System.Drawing.Size(95, 40);
            this.Respuestas_BT.TabIndex = 5;
            this.Respuestas_BT.Text = "Insertar Respuestas";
            this.Respuestas_BT.UseVisualStyleBackColor = true;
            this.Respuestas_BT.Click += new System.EventHandler(this.Respuestas_BT_Click);
            // 
            // NotaAlumnoInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(500, 254);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "NotaAlumnoInputForm";
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
            ((System.ComponentModel.ISupportInitialize)(this.PanelesV)).EndInit();
            this.PanelesV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMng_EP)).EndInit();
            this.ProgressBK_Panel.ResumeLayout(false);
            this.ProgressBK_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox Nota_TB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Observaciones_TB;
        private System.Windows.Forms.CheckBox Presentado_CB;
        private System.Windows.Forms.Button Respuestas_BT;


    }
}
