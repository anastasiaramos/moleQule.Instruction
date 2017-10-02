namespace moleQule.Face.Instruction
{
    partial class OrdenarPreguntasInputForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdenarPreguntasInputForm));
            this.OrdenViejo_TB = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.OrdenNuevo_TB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            this.Source_GB.SuspendLayout();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.Source_GB.Controls.Add(this.groupBox2);
            this.Source_GB.Controls.Add(this.groupBox1);
            this.Source_GB.Location = new System.Drawing.Point(5, 5);
            this.Source_GB.Size = new System.Drawing.Size(223, 84);
            this.Source_GB.Text = "";
            // 
            // PanelesV
            // 
            this.PanelesV.Size = new System.Drawing.Size(233, 135);
            this.PanelesV.SplitterDistance = 95;
            // 
            // OrdenViejo_TB
            // 
            this.OrdenViejo_TB.Location = new System.Drawing.Point(10, 19);
            this.OrdenViejo_TB.Name = "OrdenViejo_TB";
            this.OrdenViejo_TB.ReadOnly = true;
            this.OrdenViejo_TB.Size = new System.Drawing.Size(70, 21);
            this.OrdenViejo_TB.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OrdenViejo_TB);
            this.groupBox1.Location = new System.Drawing.Point(9, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(90, 50);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "De Orden:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.OrdenNuevo_TB);
            this.groupBox2.Location = new System.Drawing.Point(118, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(90, 50);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "A Orden:";
            // 
            // OrdenNuevo_TB
            // 
            this.OrdenNuevo_TB.Location = new System.Drawing.Point(7, 19);
            this.OrdenNuevo_TB.Name = "OrdenNuevo_TB";
            this.OrdenNuevo_TB.Size = new System.Drawing.Size(77, 21);
            this.OrdenNuevo_TB.TabIndex = 0;
            // 
            // OrdenarPreguntasInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(233, 135);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrdenarPreguntasInputForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "Cambiar Orden:";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PracticasActionForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            this.Source_GB.ResumeLayout(false);
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox OrdenViejo_TB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox OrdenNuevo_TB;
    }
}
