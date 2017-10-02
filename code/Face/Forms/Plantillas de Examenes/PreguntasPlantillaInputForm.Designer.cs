namespace moleQule.Face.Instruction
{
    partial class PreguntasPlantillaInputForm
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
            this.NPreguntas_TB = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            this.Source_GB.SuspendLayout();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
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
            this.Source_GB.Controls.Add(this.NPreguntas_TB);
            this.Source_GB.Size = new System.Drawing.Size(251, 78);
            this.Source_GB.Text = "Nº de Preguntas para el Submódulo";
            // 
            // PanelesV
            // 
            this.PanelesV.Size = new System.Drawing.Size(305, 162);
            this.PanelesV.SplitterDistance = 122;
            // 
            // NPreguntas_TB
            // 
            this.NPreguntas_TB.Location = new System.Drawing.Point(17, 31);
            this.NPreguntas_TB.Mask = "99999";
            this.NPreguntas_TB.Name = "NPreguntas_TB";
            this.NPreguntas_TB.PromptChar = ' ';
            this.NPreguntas_TB.Size = new System.Drawing.Size(208, 21);
            this.NPreguntas_TB.TabIndex = 0;
            this.NPreguntas_TB.ValidatingType = typeof(int);
            // 
            // PreguntasPlantillaInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(305, 162);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "PreguntasPlantillaInputForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "Modificar Preguntas Plantilla";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreguntasPlantillaInputForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            this.Source_GB.ResumeLayout(false);
            this.Source_GB.PerformLayout();
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox NPreguntas_TB;

    }
}
