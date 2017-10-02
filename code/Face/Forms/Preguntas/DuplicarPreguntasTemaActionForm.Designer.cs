namespace moleQule.Face.Instruction
{
    partial class DuplicarPreguntasTemaActionForm
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
            this.Tema_O_CB = new System.Windows.Forms.ComboBox();
            this.Datos_Tema_Origen = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Tema_D_CB = new System.Windows.Forms.ComboBox();
            this.Datos_Tema_Destino = new System.Windows.Forms.BindingSource(this.components);
            this.Source_GB.SuspendLayout();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            this.ProgressBK_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Tema_Origen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Tema_Destino)).BeginInit();
            this.SuspendLayout();
            // 
            // Print_BT
            // 
            this.Print_BT.Location = new System.Drawing.Point(208, 60);
            this.HelpProvider.SetShowHelp(this.Print_BT, true);
            this.Print_BT.Size = new System.Drawing.Size(87, 23);
            // 
            // Submit_BT
            // 
            this.Submit_BT.Location = new System.Drawing.Point(73, 8);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Location = new System.Drawing.Point(292, 6);
            this.HelpProvider.SetShowHelp(this.Cancel_BT, true);
            // 
            // Source_GB
            // 
            this.Source_GB.Controls.Add(this.label1);
            this.Source_GB.Controls.Add(this.Tema_O_CB);
            this.Source_GB.Controls.Add(this.Tema_D_CB);
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
            // ProgressBK_Panel
            // 
            this.ProgressBK_Panel.Location = new System.Drawing.Point(-44, -3);
            // 
            // Tema_O_CB
            // 
            this.Tema_O_CB.DataSource = this.Datos_Tema_Origen;
            this.Tema_O_CB.DisplayMember = "Texto";
            this.Tema_O_CB.FormattingEnabled = true;
            this.Tema_O_CB.Location = new System.Drawing.Point(103, 19);
            this.Tema_O_CB.Name = "Tema_O_CB";
            this.Tema_O_CB.Size = new System.Drawing.Size(176, 21);
            this.Tema_O_CB.TabIndex = 0;
            this.Tema_O_CB.ValueMember = "Oid";
            // 
            // Datos_Tema_Origen
            // 
            this.Datos_Tema_Origen.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desde Tema:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "A Tema: ";
            // 
            // Tema_D_CB
            // 
            this.Tema_D_CB.DataSource = this.Datos_Tema_Destino;
            this.Tema_D_CB.DisplayMember = "Texto";
            this.Tema_D_CB.FormattingEnabled = true;
            this.Tema_D_CB.Location = new System.Drawing.Point(103, 56);
            this.Tema_D_CB.Name = "Tema_D_CB";
            this.Tema_D_CB.Size = new System.Drawing.Size(176, 21);
            this.Tema_D_CB.TabIndex = 2;
            this.Tema_D_CB.ValueMember = "Oid";
            // 
            // Datos_Tema_Destino
            // 
            this.Datos_Tema_Destino.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // DuplicarPreguntasTemaActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(319, 150);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "DuplicarPreguntasTemaActionForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "DuplicarPreguntasTemaActionForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DuplicarCapacidadActionForm_FormClosing);
            this.Source_GB.ResumeLayout(false);
            this.Source_GB.PerformLayout();
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            this.ProgressBK_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Tema_Origen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Tema_Destino)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.ComboBox Tema_O_CB;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.ComboBox Tema_D_CB;
        private System.Windows.Forms.BindingSource Datos_Tema_Destino;
        private System.Windows.Forms.BindingSource Datos_Tema_Origen;
    }
}
