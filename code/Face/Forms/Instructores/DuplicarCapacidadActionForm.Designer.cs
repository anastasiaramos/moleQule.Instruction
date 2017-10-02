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
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Promocion_Origen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Promocion_Destino)).BeginInit();
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
            this.Source_GB.Controls.Add(this.label1);
            this.Source_GB.Controls.Add(this.Promocion_O_CB);
            this.Source_GB.Controls.Add(this.Promocion_D_CB);
            this.Source_GB.Controls.Add(this.label2);
            this.Source_GB.Location = new System.Drawing.Point(11, 11);
            this.Source_GB.Size = new System.Drawing.Size(296, 89);
            // 
            // PanelesV
            // 
            this.PanelesV.Size = new System.Drawing.Size(319, 150);
            this.PanelesV.SplitterDistance = 109;
            // 
            // Promocion_O_CB
            // 
            this.Promocion_O_CB.DataSource = this.Datos_Promocion_Origen;
            this.Promocion_O_CB.DisplayMember = "Texto";
            this.Promocion_O_CB.FormattingEnabled = true;
            this.Promocion_O_CB.Location = new System.Drawing.Point(131, 19);
            this.Promocion_O_CB.Name = "Promocion_O_CB";
            this.Promocion_O_CB.Size = new System.Drawing.Size(148, 21);
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
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desde Promoción:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "A Promoción: ";
            // 
            // Promocion_D_CB
            // 
            this.Promocion_D_CB.DataSource = this.Datos_Promocion_Destino;
            this.Promocion_D_CB.DisplayMember = "Texto";
            this.Promocion_D_CB.FormattingEnabled = true;
            this.Promocion_D_CB.Location = new System.Drawing.Point(131, 56);
            this.Promocion_D_CB.Name = "Promocion_D_CB";
            this.Promocion_D_CB.Size = new System.Drawing.Size(148, 21);
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
            this.PanelesV.ResumeLayout(false);
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
