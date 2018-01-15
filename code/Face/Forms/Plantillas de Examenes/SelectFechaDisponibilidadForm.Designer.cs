namespace moleQule.Face.Instruction
{
    partial class SelectFechaDisponibilidadForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FechaDisponibilidad_DTP = new System.Windows.Forms.DateTimePicker();
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
            this.SuspendLayout();
            // 
            // Print_BT
            // 
            this.Print_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Print_BT.Location = new System.Drawing.Point(215, 3);
            this.HelpProvider.SetShowHelp(this.Print_BT, true);
            // 
            // Submit_BT
            // 
            this.Submit_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Submit_BT.Location = new System.Drawing.Point(112, 3);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Cancel_BT.Location = new System.Drawing.Point(9, 3);
            this.HelpProvider.SetShowHelp(this.Cancel_BT, true);
            // 
            // Source_GB
            // 
            this.Source_GB.Controls.Add(this.FechaDisponibilidad_DTP);
            this.Source_GB.Location = new System.Drawing.Point(25, 11);
            this.HelpProvider.SetShowHelp(this.Source_GB, true);
            this.Source_GB.Size = new System.Drawing.Size(276, 58);
            this.Source_GB.Text = "Fecha de Disponibilidad:";
            this.Source_GB.Visible = true;
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
            this.PanelesV.Size = new System.Drawing.Size(324, 124);
            this.PanelesV.SplitterDistance = 83;
            // 
            // Progress_Panel
            // 
            this.Progress_Panel.Location = new System.Drawing.Point(-42, -47);
            // 
            // ProgressBK_Panel
            // 
            this.ProgressBK_Panel.Size = new System.Drawing.Size(324, 124);
            // 
            // ProgressInfo_PB
            // 
            this.ProgressInfo_PB.Location = new System.Drawing.Point(130, 113);
            // 
            // Progress_PB
            // 
            this.Progress_PB.Location = new System.Drawing.Point(130, 28);
            // 
            // FechaDisponibilidad_DTP
            // 
            this.FechaDisponibilidad_DTP.Location = new System.Drawing.Point(39, 21);
            this.FechaDisponibilidad_DTP.Name = "FechaDisponibilidad_DTP";
            this.FechaDisponibilidad_DTP.Size = new System.Drawing.Size(200, 21);
            this.FechaDisponibilidad_DTP.TabIndex = 2;
            // 
            // SelectFechaDisponibilidadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(324, 124);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "SelectFechaDisponibilidadForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "Seleccionar Fecha de Disponibilidad";
            this.Source_GB.ResumeLayout(false);
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
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DateTimePicker FechaDisponibilidad_DTP;

    }
}
