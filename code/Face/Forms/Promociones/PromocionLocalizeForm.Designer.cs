namespace moleQule.Face.Instruction
{
    partial class PromocionLocalizeForm
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
            this.Plan_RB = new System.Windows.Forms.RadioButton();
            this.Campos_Panel.SuspendLayout();
            this.Campos_Groupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            this.SuspendLayout();
            // 
            // Campos_Groupbox
            // 
            this.Campos_Groupbox.Controls.Add(this.Plan_RB);
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
            this.Nombre_RB.Location = new System.Drawing.Point(93, 19);
            this.Nombre_RB.Name = "Nombre_RB";
            this.Nombre_RB.Size = new System.Drawing.Size(69, 17);
            this.Nombre_RB.TabIndex = 0;
            this.Nombre_RB.TabStop = true;
            this.Nombre_RB.Text = "Nombre";
            this.Nombre_RB.UseVisualStyleBackColor = true;
            // 
            // Plan_RB
            // 
            this.Plan_RB.AutoSize = true;
            this.Plan_RB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Plan_RB.Location = new System.Drawing.Point(238, 19);
            this.Plan_RB.Name = "Plan_RB";
            this.Plan_RB.Size = new System.Drawing.Size(99, 17);
            this.Plan_RB.TabIndex = 1;
            this.Plan_RB.TabStop = true;
            this.Plan_RB.Text = "Plan Estudios";
            this.Plan_RB.UseVisualStyleBackColor = true;
            // 
            // PromocionLocalizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(935, 96);
            this.HelpProvider.SetHelpKeyword(this, "40");
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "PromocionLocalizeForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "PromocionLocalizeForm";
            this.Campos_Panel.ResumeLayout(false);
            this.Campos_Groupbox.ResumeLayout(false);
            this.Campos_Groupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton Plan_RB;
        private System.Windows.Forms.RadioButton Nombre_RB;
    }
}
