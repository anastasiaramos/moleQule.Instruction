namespace moleQule.Face.Instruction
{
    partial class RevisionForm
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
            System.Windows.Forms.Label versionLabel;
            System.Windows.Forms.Label fechaLabel;
            System.Windows.Forms.Label autorLabel;
            System.Windows.Forms.Label observacionesLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RevisionForm));
            this.versionTextBox = new System.Windows.Forms.TextBox();
            this.fechaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.autorTextBox = new System.Windows.Forms.TextBox();
            this.observacionesTextBox = new System.Windows.Forms.TextBox();
            versionLabel = new System.Windows.Forms.Label();
            fechaLabel = new System.Windows.Forms.Label();
            autorLabel = new System.Windows.Forms.Label();
            observacionesLabel = new System.Windows.Forms.Label();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            this.Paneles2.Panel1.SuspendLayout();
            this.Paneles2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.Controls.Add(observacionesLabel);
            this.PanelesV.Panel1.Controls.Add(this.observacionesTextBox);
            this.PanelesV.Panel1.Controls.Add(autorLabel);
            this.PanelesV.Panel1.Controls.Add(this.autorTextBox);
            this.PanelesV.Panel1.Controls.Add(fechaLabel);
            this.PanelesV.Panel1.Controls.Add(this.fechaDateTimePicker);
            this.PanelesV.Panel1.Controls.Add(versionLabel);
            this.PanelesV.Panel1.Controls.Add(this.versionTextBox);
            this.PanelesV.Size = new System.Drawing.Size(592, 303);
            this.PanelesV.SplitterDistance = 262;
            // 
            // Submit_BT
            // 
            this.Submit_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Submit_BT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Submit_BT.Location = new System.Drawing.Point(251, 6);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Cancel_BT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Cancel_BT.Location = new System.Drawing.Point(341, 6);
            // 
            // Paneles2
            // 
            this.Paneles2.Size = new System.Drawing.Size(590, 38);
            this.Paneles2.SplitterDistance = 37;
            // 
            // Imprimir_Button
            // 
            this.Imprimir_Button.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Imprimir_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Imprimir_Button.Location = new System.Drawing.Point(161, 6);
            // 
            // Datos
            // 
            this.Datos.DataSource = typeof(moleQule.Library.Instruction.RevisionMaterial);
            // 
            // versionLabel
            // 
            versionLabel.AutoSize = true;
            versionLabel.Location = new System.Drawing.Point(78, 42);
            versionLabel.Name = "versionLabel";
            versionLabel.Size = new System.Drawing.Size(52, 13);
            versionLabel.TabIndex = 0;
            versionLabel.Text = "Versión:";
            // 
            // fechaLabel
            // 
            fechaLabel.AutoSize = true;
            fechaLabel.Location = new System.Drawing.Point(262, 43);
            fechaLabel.Name = "fechaLabel";
            fechaLabel.Size = new System.Drawing.Size(43, 13);
            fechaLabel.TabIndex = 2;
            fechaLabel.Text = "Fecha:";
            // 
            // autorLabel
            // 
            autorLabel.AutoSize = true;
            autorLabel.Location = new System.Drawing.Point(88, 92);
            autorLabel.Name = "autorLabel";
            autorLabel.Size = new System.Drawing.Size(42, 13);
            autorLabel.TabIndex = 4;
            autorLabel.Text = "Autor:";
            // 
            // observacionesLabel
            // 
            observacionesLabel.AutoSize = true;
            observacionesLabel.Location = new System.Drawing.Point(37, 139);
            observacionesLabel.Name = "observacionesLabel";
            observacionesLabel.Size = new System.Drawing.Size(93, 13);
            observacionesLabel.TabIndex = 6;
            observacionesLabel.Text = "Observaciones:";
            // 
            // versionTextBox
            // 
            this.versionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Version", true));
            this.versionTextBox.Location = new System.Drawing.Point(136, 39);
            this.versionTextBox.Name = "versionTextBox";
            this.versionTextBox.Size = new System.Drawing.Size(100, 21);
            this.versionTextBox.TabIndex = 1;
            // 
            // fechaDateTimePicker
            // 
            this.fechaDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.Datos, "Fecha", true));
            this.fechaDateTimePicker.Location = new System.Drawing.Point(311, 39);
            this.fechaDateTimePicker.Name = "fechaDateTimePicker";
            this.fechaDateTimePicker.Size = new System.Drawing.Size(200, 21);
            this.fechaDateTimePicker.TabIndex = 3;
            // 
            // autorTextBox
            // 
            this.autorTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Autor", true));
            this.autorTextBox.Location = new System.Drawing.Point(136, 89);
            this.autorTextBox.Name = "autorTextBox";
            this.autorTextBox.Size = new System.Drawing.Size(375, 21);
            this.autorTextBox.TabIndex = 5;
            // 
            // observacionesTextBox
            // 
            this.observacionesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Observaciones", true));
            this.observacionesTextBox.Location = new System.Drawing.Point(136, 136);
            this.observacionesTextBox.Multiline = true;
            this.observacionesTextBox.Name = "observacionesTextBox";
            this.observacionesTextBox.Size = new System.Drawing.Size(375, 85);
            this.observacionesTextBox.TabIndex = 7;
            // 
            // RevisionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(592, 303);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RevisionForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "RevisionForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RevisionForm_FormClosing);
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel1.PerformLayout();
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            this.Paneles2.Panel1.ResumeLayout(false);
            this.Paneles2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox observacionesTextBox;
        private System.Windows.Forms.TextBox autorTextBox;
        private System.Windows.Forms.DateTimePicker fechaDateTimePicker;
        private System.Windows.Forms.TextBox versionTextBox;
    }
}
