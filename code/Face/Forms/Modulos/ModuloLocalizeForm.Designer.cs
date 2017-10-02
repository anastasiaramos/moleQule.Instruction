namespace moleQule.Face.Instruction
{
    partial class ModuloLocalizeForm
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
            this.Modulo_RB = new System.Windows.Forms.RadioButton();
            this.Codigo_RB = new System.Windows.Forms.RadioButton();
            this.Campos_Panel.SuspendLayout();
            this.Campos_Groupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            this.SuspendLayout();
            // 
            // Campos_Groupbox
            // 
            this.Campos_Groupbox.Controls.Add(this.Codigo_RB);
            this.Campos_Groupbox.Controls.Add(this.Modulo_RB);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Size = new System.Drawing.Size(127, 13);
            // 
            // Modulo_RB
            // 
            this.Modulo_RB.AutoSize = true;
            this.Modulo_RB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Modulo_RB.Location = new System.Drawing.Point(106, 18);
            this.Modulo_RB.Name = "Modulo_RB";
            this.Modulo_RB.Size = new System.Drawing.Size(66, 17);
            this.Modulo_RB.TabIndex = 0;
            this.Modulo_RB.TabStop = true;
            this.Modulo_RB.Text = "Módulo";
            this.Modulo_RB.UseVisualStyleBackColor = true;
            // 
            // Codigo_RB
            // 
            this.Codigo_RB.AutoSize = true;
            this.Codigo_RB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Codigo_RB.Location = new System.Drawing.Point(264, 18);
            this.Codigo_RB.Name = "Codigo_RB";
            this.Codigo_RB.Size = new System.Drawing.Size(63, 17);
            this.Codigo_RB.TabIndex = 1;
            this.Codigo_RB.TabStop = true;
            this.Codigo_RB.Text = "Código";
            this.Codigo_RB.UseVisualStyleBackColor = true;
            // 
            // ModuloLocalizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(935, 96);
            this.HelpProvider.SetHelpKeyword(this, "40");
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ModuloLocalizeForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "ModuloLocalizeForm";
            this.Campos_Panel.ResumeLayout(false);
            this.Campos_Groupbox.ResumeLayout(false);
            this.Campos_Groupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton Codigo_RB;
        private System.Windows.Forms.RadioButton Modulo_RB;
    }
}
