namespace moleQule.Face.Instruction
{
    partial class HorarioLocalizeForm
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
            this.Plan_RB = new System.Windows.Forms.RadioButton();
            this.Desde_DTP = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.Hasta_DTP = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.Campos_Panel.SuspendLayout();
            this.Campos_Groupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            this.SuspendLayout();
            // 
            // Campos_Panel
            // 
            this.Campos_Panel.Controls.Add(this.Hasta_DTP);
            this.Campos_Panel.Controls.Add(this.label2);
            this.Campos_Panel.Controls.Add(this.Desde_DTP);
            this.Campos_Panel.Controls.Add(this.label1);
            this.Campos_Panel.Size = new System.Drawing.Size(593, 70);
            this.Campos_Panel.Controls.SetChildIndex(this.label1, 0);
            this.Campos_Panel.Controls.SetChildIndex(this.Desde_DTP, 0);
            this.Campos_Panel.Controls.SetChildIndex(this.Campos_Groupbox, 0);
            this.Campos_Panel.Controls.SetChildIndex(this.label2, 0);
            this.Campos_Panel.Controls.SetChildIndex(this.Hasta_DTP, 0);
            // 
            // Campos_Groupbox
            // 
            this.Campos_Groupbox.Controls.Add(this.Plan_RB);
            this.Campos_Groupbox.Controls.Add(this.Promocion_RB);
            this.Campos_Groupbox.Size = new System.Drawing.Size(298, 45);
            // 
            // Valor_TB
            // 
            this.Valor_TB.Location = new System.Drawing.Point(646, 33);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(618, 17);
            this.label3.Size = new System.Drawing.Size(127, 13);
            // 
            // Buscar_Button
            // 
            this.Buscar_Button.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Buscar_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Buscar_Button.Location = new System.Drawing.Point(985, 12);
            // 
            // Filtrar_Button
            // 
            this.Filtrar_Button.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Filtrar_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Filtrar_Button.Location = new System.Drawing.Point(985, 41);
            // 
            // Promocion_RB
            // 
            this.Promocion_RB.AutoSize = true;
            this.Promocion_RB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Promocion_RB.Location = new System.Drawing.Point(192, 19);
            this.Promocion_RB.Name = "Promocion_RB";
            this.Promocion_RB.Size = new System.Drawing.Size(85, 17);
            this.Promocion_RB.TabIndex = 8;
            this.Promocion_RB.TabStop = true;
            this.Promocion_RB.Text = "Promoción";
            this.Promocion_RB.UseVisualStyleBackColor = true;
            // 
            // Plan_RB
            // 
            this.Plan_RB.AutoSize = true;
            this.Plan_RB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Plan_RB.Location = new System.Drawing.Point(24, 19);
            this.Plan_RB.Name = "Plan_RB";
            this.Plan_RB.Size = new System.Drawing.Size(99, 17);
            this.Plan_RB.TabIndex = 10;
            this.Plan_RB.TabStop = true;
            this.Plan_RB.Text = "Plan Estudios";
            this.Plan_RB.UseVisualStyleBackColor = true;
            // 
            // Desde_DTP
            // 
            this.Desde_DTP.Checked = false;
            this.Desde_DTP.CustomFormat = "yy/dd/MM";
            this.Desde_DTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Desde_DTP.Location = new System.Drawing.Point(336, 39);
            this.Desde_DTP.Name = "Desde_DTP";
            this.Desde_DTP.ShowCheckBox = true;
            this.Desde_DTP.Size = new System.Drawing.Size(98, 21);
            this.Desde_DTP.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(337, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Desde:";
            // 
            // Hasta_DTP
            // 
            this.Hasta_DTP.Checked = false;
            this.Hasta_DTP.CustomFormat = "yy/dd/MM";
            this.Hasta_DTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Hasta_DTP.Location = new System.Drawing.Point(471, 39);
            this.Hasta_DTP.Name = "Hasta_DTP";
            this.Hasta_DTP.ShowCheckBox = true;
            this.Hasta_DTP.Size = new System.Drawing.Size(98, 21);
            this.Hasta_DTP.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(472, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hasta:";
            // 
            // HorarioLocalizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(987, 96);
            this.HelpProvider.SetHelpKeyword(this, "40");
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "HorarioLocalizeForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Campos_Panel.ResumeLayout(false);
            this.Campos_Panel.PerformLayout();
            this.Campos_Groupbox.ResumeLayout(false);
            this.Campos_Groupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton Plan_RB;
        private System.Windows.Forms.RadioButton Promocion_RB;
        private System.Windows.Forms.DateTimePicker Hasta_DTP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker Desde_DTP;
        private System.Windows.Forms.Label label1;
    }
}
