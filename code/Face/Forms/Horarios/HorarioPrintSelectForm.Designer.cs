namespace moleQule.Face.Instruction
{
    partial class HorarioPrintSelectForm
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
            this.Fecha_CB = new System.Windows.Forms.CheckBox();
            this.FechaImpresion_DTP = new System.Windows.Forms.DateTimePicker();
            this.Source_GB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMng_EP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).BeginInit();
            this.Progress_Panel.SuspendLayout();
            this.ProgressBK_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Progress_PB)).BeginInit();
            this.SuspendLayout();
            // 
            // Submit_BT
            // 
            this.Submit_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Submit_BT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Cancel_BT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // Source_GB
            // 
            this.Source_GB.Controls.Add(this.FechaImpresion_DTP);
            this.Source_GB.Controls.Add(this.Fecha_CB);
            this.Source_GB.Size = new System.Drawing.Size(260, 141);
            this.Source_GB.Text = "Tipo de Horario";
            this.Source_GB.Controls.SetChildIndex(this.Seleccion_RB, 0);
            this.Source_GB.Controls.SetChildIndex(this.Todos_RB, 0);
            this.Source_GB.Controls.SetChildIndex(this.Fecha_CB, 0);
            this.Source_GB.Controls.SetChildIndex(this.FechaImpresion_DTP, 0);
            // 
            // Seleccion_RB
            // 
            this.Seleccion_RB.Location = new System.Drawing.Point(140, 30);
            this.Seleccion_RB.Size = new System.Drawing.Size(65, 17);
            this.Seleccion_RB.Text = "Alumnos";
            // 
            // Todos_RB
            // 
            this.Todos_RB.Location = new System.Drawing.Point(23, 30);
            this.Todos_RB.Size = new System.Drawing.Size(84, 17);
            this.Todos_RB.Text = "Instructores";
            // 
            // Progress_Panel
            // 
            this.Progress_Panel.Location = new System.Drawing.Point(-50, 0);
            // 
            // ProgressBK_Panel
            // 
            this.ProgressBK_Panel.Size = new System.Drawing.Size(318, 219);
            // 
            // ProgressInfo_PB
            // 
            this.ProgressInfo_PB.Location = new System.Drawing.Point(122, 156);
            // 
            // Progress_PB
            // 
            this.Progress_PB.Location = new System.Drawing.Point(122, 71);
            // 
            // Fecha_CB
            // 
            this.Fecha_CB.AutoSize = true;
            this.Fecha_CB.Location = new System.Drawing.Point(54, 75);
            this.Fecha_CB.Name = "Fecha_CB";
            this.Fecha_CB.Size = new System.Drawing.Size(152, 17);
            this.Fecha_CB.TabIndex = 4;
            this.Fecha_CB.Text = "Imprimir Fecha y Hora";
            this.Fecha_CB.UseVisualStyleBackColor = true;
            // 
            // FechaImpresion_DTP
            // 
            this.FechaImpresion_DTP.CustomFormat = "dd/MM/yy HH:mm:ss";
            this.FechaImpresion_DTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FechaImpresion_DTP.Location = new System.Drawing.Point(54, 104);
            this.FechaImpresion_DTP.Name = "FechaImpresion_DTP";
            this.FechaImpresion_DTP.ShowCheckBox = true;
            this.FechaImpresion_DTP.Size = new System.Drawing.Size(152, 21);
            this.FechaImpresion_DTP.TabIndex = 5;
            // 
            // HorarioPrintSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(318, 219);
            this.HelpProvider.SetHelpKeyword(this, "45");
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "HorarioPrintSelectForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Source_GB.ResumeLayout(false);
            this.Source_GB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMng_EP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).EndInit();
            this.Progress_Panel.ResumeLayout(false);
            this.Progress_Panel.PerformLayout();
            this.ProgressBK_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Progress_PB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker FechaImpresion_DTP;
        private System.Windows.Forms.CheckBox Fecha_CB;

    }
}
