namespace moleQule.Face.Instruction
{
    partial class ExtrasActionForm
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
            this.Modulo_CB = new System.Windows.Forms.ComboBox();
            this.Datos_Modulos = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Submodulo_CB = new System.Windows.Forms.ComboBox();
            this.Datos_Submodulos = new System.Windows.Forms.BindingSource(this.components);
            this.Clases_NUD = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.Source_GB.SuspendLayout();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            this.ProgressBK_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Modulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Submodulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Clases_NUD)).BeginInit();
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
            this.Source_GB.Controls.Add(this.Clases_NUD);
            this.Source_GB.Controls.Add(this.label1);
            this.Source_GB.Controls.Add(this.label3);
            this.Source_GB.Controls.Add(this.Modulo_CB);
            this.Source_GB.Controls.Add(this.Submodulo_CB);
            this.Source_GB.Controls.Add(this.label2);
            this.Source_GB.Location = new System.Drawing.Point(29, 9);
            this.HelpProvider.SetShowHelp(this.Source_GB, true);
            this.Source_GB.Size = new System.Drawing.Size(629, 144);
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
            this.PanelesV.Size = new System.Drawing.Size(671, 212);
            this.PanelesV.SplitterDistance = 171;
            // 
            // ProgressBK_Panel
            // 
            this.ProgressBK_Panel.Location = new System.Drawing.Point(131, 27);
            // 
            // Modulo_CB
            // 
            this.Modulo_CB.DataSource = this.Datos_Modulos;
            this.Modulo_CB.DisplayMember = "Texto";
            this.Modulo_CB.FormattingEnabled = true;
            this.Modulo_CB.Location = new System.Drawing.Point(96, 19);
            this.Modulo_CB.Name = "Modulo_CB";
            this.Modulo_CB.Size = new System.Drawing.Size(514, 21);
            this.Modulo_CB.TabIndex = 0;
            this.Modulo_CB.ValueMember = "Oid";
            this.Modulo_CB.SelectedValueChanged += new System.EventHandler(this.Modulo_CB_SelectedValueChanged);
            // 
            // Datos_Modulos
            // 
            this.Datos_Modulos.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Módulo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Submódulo:";
            // 
            // Submodulo_CB
            // 
            this.Submodulo_CB.DataSource = this.Datos_Submodulos;
            this.Submodulo_CB.DisplayMember = "Texto";
            this.Submodulo_CB.FormattingEnabled = true;
            this.Submodulo_CB.Location = new System.Drawing.Point(96, 56);
            this.Submodulo_CB.Name = "Submodulo_CB";
            this.Submodulo_CB.Size = new System.Drawing.Size(514, 21);
            this.Submodulo_CB.TabIndex = 2;
            this.Submodulo_CB.ValueMember = "Oid";
            // 
            // Datos_Submodulos
            // 
            this.Datos_Submodulos.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // Clases_NUD
            // 
            this.Clases_NUD.Location = new System.Drawing.Point(329, 97);
            this.Clases_NUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Clases_NUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Clases_NUD.Name = "Clases_NUD";
            this.Clases_NUD.Size = new System.Drawing.Size(39, 21);
            this.Clases_NUD.TabIndex = 4;
            this.Clases_NUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nº Clases:";
            // 
            // ExtrasActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(671, 212);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "ExtrasActionForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "ExtrasActionForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExtrasActionForm_FormClosing);
            this.Source_GB.ResumeLayout(false);
            this.Source_GB.PerformLayout();
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            this.ProgressBK_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Modulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Submodulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Clases_NUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.ComboBox Modulo_CB;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.ComboBox Submodulo_CB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown Clases_NUD;
        private System.Windows.Forms.BindingSource Datos_Submodulos;
        private System.Windows.Forms.BindingSource Datos_Modulos;
    }
}
