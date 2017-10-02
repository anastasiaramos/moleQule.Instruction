namespace moleQule.Face.Instruction
{
    partial class InstructorLocalizeForm
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
            this.Nombre_RB = new System.Windows.Forms.RadioButton();
            this.ID_RB = new System.Windows.Forms.RadioButton();
            this.Alias_RB = new System.Windows.Forms.RadioButton();
            this.Campos_Panel.SuspendLayout();
            this.Campos_Groupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            this.SuspendLayout();
            // 
            // Campos_Groupbox
            // 
            this.Campos_Groupbox.Controls.Add(this.Alias_RB);
            this.Campos_Groupbox.Controls.Add(this.ID_RB);
            this.Campos_Groupbox.Controls.Add(this.Nombre_RB);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Size = new System.Drawing.Size(127, 13);
            // 
            // Nombre_RB
            // 
            this.Nombre_RB.AutoSize = true;
            this.Nombre_RB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nombre_RB.Location = new System.Drawing.Point(83, 18);
            this.Nombre_RB.Name = "Nombre_RB";
            this.Nombre_RB.Size = new System.Drawing.Size(69, 17);
            this.Nombre_RB.TabIndex = 0;
            this.Nombre_RB.TabStop = true;
            this.Nombre_RB.Text = "Nombre";
            this.Nombre_RB.UseVisualStyleBackColor = true;
            // 
            // ID_RB
            // 
            this.ID_RB.AutoSize = true;
            this.ID_RB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_RB.Location = new System.Drawing.Point(352, 18);
            this.ID_RB.Name = "ID_RB";
            this.ID_RB.Size = new System.Drawing.Size(37, 17);
            this.ID_RB.TabIndex = 1;
            this.ID_RB.TabStop = true;
            this.ID_RB.Text = "Id";
            this.ID_RB.UseVisualStyleBackColor = true;
            // 
            // Alias_RB
            // 
            this.Alias_RB.AutoSize = true;
            this.Alias_RB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Alias_RB.Location = new System.Drawing.Point(226, 18);
            this.Alias_RB.Name = "Alias_RB";
            this.Alias_RB.Size = new System.Drawing.Size(52, 17);
            this.Alias_RB.TabIndex = 2;
            this.Alias_RB.TabStop = true;
            this.Alias_RB.Text = "Alias";
            this.Alias_RB.UseVisualStyleBackColor = true;
            // 
            // InstructorLocalizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(990, 96);
            this.HelpProvider.SetHelpKeyword(this, "40");
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "InstructorLocalizeForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "InstructorLocalizeForm";
            this.Campos_Panel.ResumeLayout(false);
            this.Campos_Groupbox.ResumeLayout(false);
            this.Campos_Groupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton Nombre_RB;
        private System.Windows.Forms.RadioButton ID_RB;
        private System.Windows.Forms.RadioButton Alias_RB;
    }
}
