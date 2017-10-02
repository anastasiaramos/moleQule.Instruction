namespace moleQule.Face.Instruction
{
    partial class ResumenPlanExtraForm
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
            this.components = new System.ComponentModel.Container();
            this.Resumen_TC = new System.Windows.Forms.TabControl();
            this.Teoricas_TP = new System.Windows.Forms.TabPage();
            this.Extras_Grid = new System.Windows.Forms.DataGridView();
            this.moduloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.submoduloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nClasesModuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nClasesSubmoduloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datos_Extras = new System.Windows.Forms.BindingSource(this.components);
            this.Teoricas_TB = new System.Windows.Forms.TextBox();
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
            this.Resumen_TC.SuspendLayout();
            this.Teoricas_TP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Extras_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Extras)).BeginInit();
            this.SuspendLayout();
            // 
            // Print_BT
            // 
            this.Print_BT.Enabled = true;
            this.Print_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ErrorMng_EP.SetIconAlignment(this.Print_BT, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.Print_BT.Location = new System.Drawing.Point(658, 8);
            this.HelpProvider.SetShowHelp(this.Print_BT, true);
            this.Print_BT.Size = new System.Drawing.Size(87, 32);
            this.Print_BT.Text = "&Imprimir";
            this.Print_BT.Visible = true;
            // 
            // Submit_BT
            // 
            this.Submit_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ErrorMng_EP.SetIconAlignment(this.Submit_BT, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.Submit_BT.Location = new System.Drawing.Point(478, 8);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ErrorMng_EP.SetIconAlignment(this.Cancel_BT, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.Cancel_BT.Location = new System.Drawing.Point(568, 8);
            this.HelpProvider.SetShowHelp(this.Cancel_BT, true);
            // 
            // Source_GB
            // 
            this.Source_GB.Controls.Add(this.Teoricas_TB);
            this.Source_GB.Location = new System.Drawing.Point(18, 21);
            this.HelpProvider.SetShowHelp(this.Source_GB, true);
            this.Source_GB.Size = new System.Drawing.Size(195, 55);
            this.Source_GB.Text = "Nº de clases total";
            // 
            // PanelesV
            // 
            this.PanelesV.IsSplitterFixed = true;
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.Controls.Add(this.Resumen_TC);
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(1224, 686);
            this.PanelesV.SplitterDistance = 645;
            // 
            // Progress_Panel
            // 
            this.Progress_Panel.Location = new System.Drawing.Point(408, 24);
            // 
            // ProgressBK_Panel
            // 
            this.ProgressBK_Panel.Size = new System.Drawing.Size(1224, 686);
            // 
            // ProgressInfo_PB
            // 
            this.ProgressInfo_PB.Location = new System.Drawing.Point(580, 394);
            // 
            // Progress_PB
            // 
            this.Progress_PB.Location = new System.Drawing.Point(580, 309);
            // 
            // Resumen_TC
            // 
            this.Resumen_TC.Controls.Add(this.Teoricas_TP);
            this.Resumen_TC.Location = new System.Drawing.Point(18, 82);
            this.Resumen_TC.Name = "Resumen_TC";
            this.Resumen_TC.SelectedIndex = 0;
            this.Resumen_TC.Size = new System.Drawing.Size(1186, 558);
            this.Resumen_TC.TabIndex = 2;
            // 
            // Teoricas_TP
            // 
            this.Teoricas_TP.Controls.Add(this.Extras_Grid);
            this.Teoricas_TP.Location = new System.Drawing.Point(4, 22);
            this.Teoricas_TP.Name = "Teoricas_TP";
            this.Teoricas_TP.Padding = new System.Windows.Forms.Padding(3);
            this.Teoricas_TP.Size = new System.Drawing.Size(1178, 532);
            this.Teoricas_TP.TabIndex = 0;
            this.Teoricas_TP.Text = "Extras";
            this.Teoricas_TP.UseVisualStyleBackColor = true;
            // 
            // Extras_Grid
            // 
            this.Extras_Grid.AllowUserToAddRows = false;
            this.Extras_Grid.AllowUserToDeleteRows = false;
            this.Extras_Grid.AllowUserToOrderColumns = true;
            this.Extras_Grid.AutoGenerateColumns = false;
            this.Extras_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Extras_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.moduloDataGridViewTextBoxColumn,
            this.submoduloDataGridViewTextBoxColumn,
            this.nClasesModuloDataGridViewTextBoxColumn,
            this.nClasesSubmoduloDataGridViewTextBoxColumn});
            this.Extras_Grid.DataSource = this.Datos_Extras;
            this.Extras_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Extras_Grid.Location = new System.Drawing.Point(3, 3);
            this.Extras_Grid.Name = "Extras_Grid";
            this.Extras_Grid.ReadOnly = true;
            this.Extras_Grid.Size = new System.Drawing.Size(1172, 526);
            this.Extras_Grid.TabIndex = 1;
            // 
            // moduloDataGridViewTextBoxColumn
            // 
            this.moduloDataGridViewTextBoxColumn.DataPropertyName = "Modulo";
            this.moduloDataGridViewTextBoxColumn.HeaderText = "Módulo";
            this.moduloDataGridViewTextBoxColumn.Name = "moduloDataGridViewTextBoxColumn";
            this.moduloDataGridViewTextBoxColumn.ReadOnly = true;
            this.moduloDataGridViewTextBoxColumn.Width = 400;
            // 
            // submoduloDataGridViewTextBoxColumn
            // 
            this.submoduloDataGridViewTextBoxColumn.DataPropertyName = "Submodulo";
            this.submoduloDataGridViewTextBoxColumn.HeaderText = "Submódulo";
            this.submoduloDataGridViewTextBoxColumn.Name = "submoduloDataGridViewTextBoxColumn";
            this.submoduloDataGridViewTextBoxColumn.ReadOnly = true;
            this.submoduloDataGridViewTextBoxColumn.Width = 500;
            // 
            // nClasesModuloDataGridViewTextBoxColumn
            // 
            this.nClasesModuloDataGridViewTextBoxColumn.DataPropertyName = "NClasesModulo";
            this.nClasesModuloDataGridViewTextBoxColumn.HeaderText = "Nº Clases Módulo";
            this.nClasesModuloDataGridViewTextBoxColumn.Name = "nClasesModuloDataGridViewTextBoxColumn";
            this.nClasesModuloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nClasesSubmoduloDataGridViewTextBoxColumn
            // 
            this.nClasesSubmoduloDataGridViewTextBoxColumn.DataPropertyName = "NClasesSubmodulo";
            this.nClasesSubmoduloDataGridViewTextBoxColumn.HeaderText = "Nº Clases Submódulo";
            this.nClasesSubmoduloDataGridViewTextBoxColumn.Name = "nClasesSubmoduloDataGridViewTextBoxColumn";
            this.nClasesSubmoduloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Datos_Extras
            // 
            this.Datos_Extras.DataSource = typeof(moleQule.Library.Instruction.RegistroResumenPlanDocente);
            // 
            // Teoricas_TB
            // 
            this.Teoricas_TB.Location = new System.Drawing.Point(19, 23);
            this.Teoricas_TB.Name = "Teoricas_TB";
            this.Teoricas_TB.ReadOnly = true;
            this.Teoricas_TB.Size = new System.Drawing.Size(159, 21);
            this.Teoricas_TB.TabIndex = 0;
            // 
            // ResumenPlanExtraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1224, 686);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "ResumenPlanExtraForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "Resumen de Clases";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResumenPlanExtraForm_FormClosing);
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
            this.Resumen_TC.ResumeLayout(false);
            this.Teoricas_TP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Extras_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Extras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Resumen_TC;
        private System.Windows.Forms.TabPage Teoricas_TP;
        private System.Windows.Forms.BindingSource Datos_Extras;
        private System.Windows.Forms.DataGridView Extras_Grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn moduloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn submoduloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nClasesModuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nClasesSubmoduloDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox Teoricas_TB;
    }
}
