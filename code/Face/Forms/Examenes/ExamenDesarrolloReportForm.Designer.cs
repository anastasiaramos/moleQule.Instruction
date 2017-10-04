namespace moleQule.Face.Instruction
{
    partial class ExamenDesarrolloReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExamenDesarrolloReportForm));
            this.Portada_CB = new System.Windows.Forms.CheckBox();
            this.Preguntas_CB = new System.Windows.Forms.CheckBox();
            this.Dialogo = new System.Windows.Forms.SaveFileDialog();
            this.TipoImpresion_GB = new System.Windows.Forms.GroupBox();
            this.PDF_CkB = new System.Windows.Forms.CheckBox();
            this.Doc_CkB = new System.Windows.Forms.CheckBox();
            this.CReports_CkB = new System.Windows.Forms.CheckBox();
            this.ModeloRespuesta_CB = new System.Windows.Forms.CheckBox();
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
            this.TipoImpresion_GB.SuspendLayout();
            this.SuspendLayout();
            // 
            // Print_BT
            // 
            this.Print_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ErrorMng_EP.SetIconAlignment(this.Print_BT, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.Print_BT.Location = new System.Drawing.Point(251, 2);
            this.HelpProvider.SetShowHelp(this.Print_BT, true);
            // 
            // Submit_BT
            // 
            this.Submit_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ErrorMng_EP.SetIconAlignment(this.Submit_BT, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.Submit_BT.Location = new System.Drawing.Point(39, 8);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ErrorMng_EP.SetIconAlignment(this.Cancel_BT, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.Cancel_BT.Location = new System.Drawing.Point(129, 8);
            this.HelpProvider.SetShowHelp(this.Cancel_BT, true);
            // 
            // Source_GB
            // 
            this.Source_GB.Controls.Add(this.ModeloRespuesta_CB);
            this.Source_GB.Controls.Add(this.Preguntas_CB);
            this.Source_GB.Controls.Add(this.Portada_CB);
            this.Source_GB.Location = new System.Drawing.Point(29, 11);
            this.HelpProvider.SetShowHelp(this.Source_GB, true);
            this.Source_GB.Size = new System.Drawing.Size(196, 129);
            this.Source_GB.Text = "Documentos";
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.Controls.Add(this.TipoImpresion_GB);
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(260, 361);
            this.PanelesV.SplitterDistance = 321;
            // 
            // Progress_Panel
            // 
            this.Progress_Panel.Location = new System.Drawing.Point(-74, 71);
            // 
            // ProgressBK_Panel
            // 
            this.ProgressBK_Panel.Size = new System.Drawing.Size(260, 361);
            // 
            // ProgressInfo_PB
            // 
            this.ProgressInfo_PB.Location = new System.Drawing.Point(98, 232);
            // 
            // Progress_PB
            // 
            this.Progress_PB.Location = new System.Drawing.Point(98, 147);
            // 
            // Portada_CB
            // 
            this.Portada_CB.AutoSize = true;
            this.Portada_CB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Portada_CB.Location = new System.Drawing.Point(56, 37);
            this.Portada_CB.Name = "Portada_CB";
            this.Portada_CB.Size = new System.Drawing.Size(64, 17);
            this.Portada_CB.TabIndex = 0;
            this.Portada_CB.Text = "Portada";
            this.Portada_CB.UseVisualStyleBackColor = true;
            // 
            // Preguntas_CB
            // 
            this.Preguntas_CB.AutoSize = true;
            this.Preguntas_CB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Preguntas_CB.Location = new System.Drawing.Point(56, 66);
            this.Preguntas_CB.Name = "Preguntas_CB";
            this.Preguntas_CB.Size = new System.Drawing.Size(75, 17);
            this.Preguntas_CB.TabIndex = 1;
            this.Preguntas_CB.Text = "Preguntas";
            this.Preguntas_CB.UseVisualStyleBackColor = true;
            // 
            // TipoImpresion_GB
            // 
            this.TipoImpresion_GB.Controls.Add(this.PDF_CkB);
            this.TipoImpresion_GB.Controls.Add(this.Doc_CkB);
            this.TipoImpresion_GB.Controls.Add(this.CReports_CkB);
            this.TipoImpresion_GB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TipoImpresion_GB.Location = new System.Drawing.Point(30, 162);
            this.TipoImpresion_GB.Name = "TipoImpresion_GB";
            this.TipoImpresion_GB.Size = new System.Drawing.Size(196, 136);
            this.TipoImpresion_GB.TabIndex = 3;
            this.TipoImpresion_GB.TabStop = false;
            this.TipoImpresion_GB.Text = "Tipo de Impresión";
            // 
            // PDF_CkB
            // 
            this.PDF_CkB.AutoSize = true;
            this.PDF_CkB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PDF_CkB.Location = new System.Drawing.Point(47, 100);
            this.PDF_CkB.Name = "PDF_CkB";
            this.PDF_CkB.Size = new System.Drawing.Size(99, 17);
            this.PDF_CkB.TabIndex = 4;
            this.PDF_CkB.Text = "Exportar a PDF";
            this.PDF_CkB.UseVisualStyleBackColor = true;
            // 
            // Doc_CkB
            // 
            this.Doc_CkB.AutoSize = true;
            this.Doc_CkB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Doc_CkB.Location = new System.Drawing.Point(47, 67);
            this.Doc_CkB.Name = "Doc_CkB";
            this.Doc_CkB.Size = new System.Drawing.Size(102, 17);
            this.Doc_CkB.TabIndex = 3;
            this.Doc_CkB.Text = "Exportar a DOC";
            this.Doc_CkB.UseVisualStyleBackColor = true;
            // 
            // CReports_CkB
            // 
            this.CReports_CkB.AutoSize = true;
            this.CReports_CkB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CReports_CkB.Location = new System.Drawing.Point(47, 33);
            this.CReports_CkB.Name = "CReports_CkB";
            this.CReports_CkB.Size = new System.Drawing.Size(75, 17);
            this.CReports_CkB.TabIndex = 2;
            this.CReports_CkB.Text = "Impresora";
            this.CReports_CkB.UseVisualStyleBackColor = true;
            // 
            // ModeloRespuesta_CB
            // 
            this.ModeloRespuesta_CB.AutoSize = true;
            this.ModeloRespuesta_CB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModeloRespuesta_CB.Location = new System.Drawing.Point(56, 93);
            this.ModeloRespuesta_CB.Name = "ModeloRespuesta_CB";
            this.ModeloRespuesta_CB.Size = new System.Drawing.Size(129, 17);
            this.ModeloRespuesta_CB.TabIndex = 2;
            this.ModeloRespuesta_CB.Text = "Modelo de Respuesta";
            this.ModeloRespuesta_CB.UseVisualStyleBackColor = true;
            // 
            // ExamenDesarrolloReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackgroundImage = global::moleQule.Face.Instruction.Properties.Resources.Imprimir;
            this.ClientSize = new System.Drawing.Size(260, 361);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExamenDesarrolloReportForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "Imprimir";
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
            this.TipoImpresion_GB.ResumeLayout(false);
            this.TipoImpresion_GB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox Portada_CB;
        private System.Windows.Forms.CheckBox Preguntas_CB;
        private System.Windows.Forms.SaveFileDialog Dialogo;
        private System.Windows.Forms.GroupBox TipoImpresion_GB;
        private System.Windows.Forms.CheckBox PDF_CkB;
        private System.Windows.Forms.CheckBox Doc_CkB;
        private System.Windows.Forms.CheckBox CReports_CkB;
        private System.Windows.Forms.CheckBox ModeloRespuesta_CB;
    }
}
