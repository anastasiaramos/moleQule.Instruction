namespace moleQule.Face.Instruction
{
    partial class AlumnoLocalizeForm
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
            this.Promocion_RB = new System.Windows.Forms.RadioButton();
            this.Nombre_RB = new System.Windows.Forms.RadioButton();
            this.Apellidos_RB = new System.Windows.Forms.RadioButton();
            this.Campos_Panel.SuspendLayout();
            this.Campos_Groupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            this.SuspendLayout();
            // 
            // Campos_Groupbox
            // 
            this.Campos_Groupbox.Controls.Add(this.Promocion_RB);
            this.Campos_Groupbox.Controls.Add(this.Apellidos_RB);
            this.Campos_Groupbox.Controls.Add(this.Nombre_RB);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Size = new System.Drawing.Size(127, 13);
            // 
            // Promocion_RB
            // 
            this.Promocion_RB.AutoSize = true;
            this.Promocion_RB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Promocion_RB.Location = new System.Drawing.Point(285, 22);
            this.Promocion_RB.Name = "Promocion_RB";
            this.Promocion_RB.Size = new System.Drawing.Size(85, 17);
            this.Promocion_RB.TabIndex = 3;
            this.Promocion_RB.TabStop = true;
            this.Promocion_RB.Text = "Promoción";
            this.Promocion_RB.UseVisualStyleBackColor = true;
            // 
            // Nombre_RB
            // 
            this.Nombre_RB.AutoSize = true;
            this.Nombre_RB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nombre_RB.Location = new System.Drawing.Point(55, 22);
            this.Nombre_RB.Name = "Nombre_RB";
            this.Nombre_RB.Size = new System.Drawing.Size(69, 17);
            this.Nombre_RB.TabIndex = 1;
            this.Nombre_RB.TabStop = true;
            this.Nombre_RB.Text = "Nombre";
            this.Nombre_RB.UseVisualStyleBackColor = true;
            // 
            // Apellidos_RB
            // 
            this.Apellidos_RB.AutoSize = true;
            this.Apellidos_RB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Apellidos_RB.Location = new System.Drawing.Point(163, 22);
            this.Apellidos_RB.Name = "Apellidos_RB";
            this.Apellidos_RB.Size = new System.Drawing.Size(76, 17);
            this.Apellidos_RB.TabIndex = 2;
            this.Apellidos_RB.TabStop = true;
            this.Apellidos_RB.Text = "Apellidos";
            this.Apellidos_RB.UseVisualStyleBackColor = true;
            // 
            // AlumnoLocalizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(935, 96);
            this.HelpProvider.SetHelpKeyword(this, "40");
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "AlumnoLocalizeForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "AlumnoLocalizeForm";
            this.Campos_Panel.ResumeLayout(false);
            this.Campos_Groupbox.ResumeLayout(false);
            this.Campos_Groupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton Promocion_RB;
        private System.Windows.Forms.RadioButton Nombre_RB;
        private System.Windows.Forms.RadioButton Apellidos_RB;
    }
}
