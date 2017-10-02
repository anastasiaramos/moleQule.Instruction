namespace moleQule.Face.Instruction
{
    partial class PracticasActionForm
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
            this.Submodulo_NUD = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.Modulo_NUD = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Incompatible_NUD = new System.Windows.Forms.NumericUpDown();
            this.Source_GB.SuspendLayout();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Modulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Submodulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Clases_NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Submodulo_NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Modulo_NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Incompatible_NUD)).BeginInit();
            this.SuspendLayout();
            // 
            // Submit_BT
            // 
            this.Submit_BT.Location = new System.Drawing.Point(73, 8);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Location = new System.Drawing.Point(292, 6);
            // 
            // Source_GB
            // 
            this.Source_GB.Controls.Add(this.Incompatible_NUD);
            this.Source_GB.Controls.Add(this.label6);
            this.Source_GB.Controls.Add(this.Clases_NUD);
            this.Source_GB.Controls.Add(this.Submodulo_NUD);
            this.Source_GB.Controls.Add(this.label1);
            this.Source_GB.Controls.Add(this.Modulo_NUD);
            this.Source_GB.Controls.Add(this.label4);
            this.Source_GB.Controls.Add(this.label3);
            this.Source_GB.Controls.Add(this.Modulo_CB);
            this.Source_GB.Controls.Add(this.Submodulo_CB);
            this.Source_GB.Controls.Add(this.label2);
            this.Source_GB.Controls.Add(this.label5);
            this.Source_GB.Location = new System.Drawing.Point(29, 9);
            this.Source_GB.Size = new System.Drawing.Size(629, 173);
            // 
            // PanelesV
            // 
            this.PanelesV.Size = new System.Drawing.Size(671, 239);
            this.PanelesV.SplitterDistance = 198;
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
            this.label2.Location = new System.Drawing.Point(34, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Práctica:";
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
            this.Clases_NUD.Location = new System.Drawing.Point(242, 136);
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
            this.label3.Location = new System.Drawing.Point(174, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nº Clases:";
            // 
            // Submodulo_NUD
            // 
            this.Submodulo_NUD.Location = new System.Drawing.Point(459, 97);
            this.Submodulo_NUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Submodulo_NUD.Name = "Submodulo_NUD";
            this.Submodulo_NUD.Size = new System.Drawing.Size(39, 21);
            this.Submodulo_NUD.TabIndex = 6;
            this.Submodulo_NUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(148, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Orden Módulo:";
            // 
            // Modulo_NUD
            // 
            this.Modulo_NUD.Location = new System.Drawing.Point(242, 97);
            this.Modulo_NUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Modulo_NUD.Name = "Modulo_NUD";
            this.Modulo_NUD.Size = new System.Drawing.Size(39, 21);
            this.Modulo_NUD.TabIndex = 8;
            this.Modulo_NUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(343, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Orden Submódulo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(368, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Incompatible:";
            // 
            // Incompatible_NUD
            // 
            this.Incompatible_NUD.Location = new System.Drawing.Point(459, 136);
            this.Incompatible_NUD.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.Incompatible_NUD.Name = "Incompatible_NUD";
            this.Incompatible_NUD.Size = new System.Drawing.Size(39, 21);
            this.Incompatible_NUD.TabIndex = 13;
            // 
            // PracticasActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(671, 239);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "PracticasActionForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "PracticasActionForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PracticasActionForm_FormClosing);
            this.Source_GB.ResumeLayout(false);
            this.Source_GB.PerformLayout();
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Modulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Submodulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Clases_NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Submodulo_NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Modulo_NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Incompatible_NUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.ComboBox Modulo_CB;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.ComboBox Submodulo_CB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown Clases_NUD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown Modulo_NUD;
        private System.Windows.Forms.NumericUpDown Submodulo_NUD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource Datos_Submodulos;
        private System.Windows.Forms.BindingSource Datos_Modulos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown Incompatible_NUD;
    }
}
