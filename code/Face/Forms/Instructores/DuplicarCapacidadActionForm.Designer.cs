namespace moleQule.Face.Instruction
{
    partial class DuplicarCapacidadActionForm
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
            this.Promocion_O_CB = new System.Windows.Forms.ComboBox();
            this.Datos_Promocion_Origen = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Promocion_D_CB = new System.Windows.Forms.ComboBox();
            this.Datos_Promocion_Destino = new System.Windows.Forms.BindingSource(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Promocion_Origen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Promocion_Destino)).BeginInit();
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
            this.Submit_BT.Location = new System.Drawing.Point(73, 8);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ErrorMng_EP.SetIconAlignment(this.Cancel_BT, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.Cancel_BT.Location = new System.Drawing.Point(292, 6);
            this.HelpProvider.SetShowHelp(this.Cancel_BT, true);
            // 
            // Source_GB
            // 
            this.Source_GB.Controls.Add(this.label1);
            this.Source_GB.Controls.Add(this.Promocion_O_CB);
            this.Source_GB.Controls.Add(this.Promocion_D_CB);
            this.Source_GB.Controls.Add(this.label2);
            this.Source_GB.Location = new System.Drawing.Point(11, 11);
            this.HelpProvider.SetShowHelp(this.Source_GB, true);
            this.Source_GB.Size = new System.Drawing.Size(296, 89);
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
            this.PanelesV.Size = new System.Drawing.Size(319, 150);
            this.PanelesV.SplitterDistance = 109;
            // 
            // Progress_Panel
            // 
            this.Progress_Panel.Location = new System.Drawing.Point(-44, 24);
            // 
            // ProgressBK_Panel
            // 
            this.ProgressBK_Panel.Size = new System.Drawing.Size(319, 150);
            // 
            // ProgressInfo_PB
            // 
            this.ProgressInfo_PB.Location = new System.Drawing.Point(127, 126);
            // 
            // Progress_PB
            // 
            this.Progress_PB.Location = new System.Drawing.Point(127, 41);
            // 
            // Promocion_O_CB
            // 
            this.Promocion_O_CB.DataSource = this.Datos_Promocion_Origen;
            this.Promocion_O_CB.DisplayMember = "Texto";
            this.Promocion_O_CB.FormattingEnabled = true;
            this.Promocion_O_CB.Location = new System.Drawing.Point(103, 19);
            this.Promocion_O_CB.Name = "Promocion_O_CB";
            this.Promocion_O_CB.Size = new System.Drawing.Size(176, 21);
            this.Promocion_O_CB.TabIndex = 0;
            this.Promocion_O_CB.ValueMember = "Oid";
            // 
            // Datos_Promocion_Origen
            // 
            this.Datos_Promocion_Origen.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desde Curso:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "A Curso: ";
            // 
            // Promocion_D_CB
            // 
            this.Promocion_D_CB.DataSource = this.Datos_Promocion_Destino;
            this.Promocion_D_CB.DisplayMember = "Texto";
            this.Promocion_D_CB.FormattingEnabled = true;
            this.Promocion_D_CB.Location = new System.Drawing.Point(103, 56);
            this.Promocion_D_CB.Name = "Promocion_D_CB";
            this.Promocion_D_CB.Size = new System.Drawing.Size(176, 21);
            this.Promocion_D_CB.TabIndex = 2;
            this.Promocion_D_CB.ValueMember = "Oid";
            // 
            // Datos_Promocion_Destino
            // 
            this.Datos_Promocion_Destino.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // DuplicarCapacidadActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(319, 150);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "DuplicarCapacidadActionForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "DuplicarCapacidadActionForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DuplicarCapacidadActionForm_FormClosing);
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
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Promocion_Origen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Promocion_Destino)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.ComboBox Promocion_O_CB;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.ComboBox Promocion_D_CB;
        private System.Windows.Forms.BindingSource Datos_Promocion_Destino;
        private System.Windows.Forms.BindingSource Datos_Promocion_Origen;
    }
}
