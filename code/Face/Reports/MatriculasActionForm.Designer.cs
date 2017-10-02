namespace moleQule.Face.Instruction
{
    partial class MatriculasActionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatriculasActionForm));
            this.Alumno_GB = new System.Windows.Forms.GroupBox();
            this.Alumno_TB = new System.Windows.Forms.TextBox();
            this.Alumno_BT = new System.Windows.Forms.Button();
            this.TodosAlumno_CkB = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Promocion_GB = new System.Windows.Forms.GroupBox();
            this.TodosPromocion_CkB = new System.Windows.Forms.CheckBox();
            this.Promocion_TB = new System.Windows.Forms.TextBox();
            this.Promocion_BT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Datos_TiposPro = new System.Windows.Forms.BindingSource(this.components);
            this.Documentos_GB = new System.Windows.Forms.GroupBox();
            this.Documentos_CLB = new System.Windows.Forms.CheckedListBox();
            this.Datos_TiposExp = new System.Windows.Forms.BindingSource(this.components);
            this.Source_GB.SuspendLayout();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            this.Alumno_GB.SuspendLayout();
            this.Promocion_GB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_TiposPro)).BeginInit();
            this.Documentos_GB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_TiposExp)).BeginInit();
            this.SuspendLayout();
            // 
            // Submit_BT
            // 
            this.Submit_BT.Location = new System.Drawing.Point(242, 7);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            this.Submit_BT.Text = "&Imprimir";
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Location = new System.Drawing.Point(332, 7);
            this.HelpProvider.SetShowHelp(this.Cancel_BT, true);
            // 
            // Source_GB
            // 
            this.Source_GB.Controls.Add(this.Documentos_GB);
            this.Source_GB.Controls.Add(this.Promocion_GB);
            this.Source_GB.Controls.Add(this.Alumno_GB);
            this.Source_GB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Source_GB.Location = new System.Drawing.Point(0, 0);
            this.HelpProvider.SetShowHelp(this.Source_GB, true);
            this.Source_GB.Size = new System.Drawing.Size(661, 274);
            this.Source_GB.Text = "";
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(663, 316);
            this.PanelesV.SplitterDistance = 276;
            // 
            // Alumno_GB
            // 
            this.Alumno_GB.Controls.Add(this.Alumno_TB);
            this.Alumno_GB.Controls.Add(this.Alumno_BT);
            this.Alumno_GB.Controls.Add(this.TodosAlumno_CkB);
            this.Alumno_GB.Controls.Add(this.label2);
            this.Alumno_GB.Location = new System.Drawing.Point(46, 83);
            this.Alumno_GB.Name = "Alumno_GB";
            this.Alumno_GB.Size = new System.Drawing.Size(568, 51);
            this.Alumno_GB.TabIndex = 24;
            this.Alumno_GB.TabStop = false;
            this.Alumno_GB.Text = "Alumnos";
            // 
            // Alumno_TB
            // 
            this.Alumno_TB.Location = new System.Drawing.Point(86, 19);
            this.Alumno_TB.Name = "Alumno_TB";
            this.Alumno_TB.ReadOnly = true;
            this.Alumno_TB.Size = new System.Drawing.Size(290, 21);
            this.Alumno_TB.TabIndex = 16;
            // 
            // Alumno_BT
            // 
            this.Alumno_BT.Enabled = false;
            this.Alumno_BT.Image = global::moleQule.Face.Instruction.Properties.Resources.select_16;
            this.Alumno_BT.Location = new System.Drawing.Point(382, 18);
            this.Alumno_BT.Name = "Alumno_BT";
            this.Alumno_BT.Size = new System.Drawing.Size(42, 23);
            this.Alumno_BT.TabIndex = 15;
            this.Alumno_BT.UseVisualStyleBackColor = true;
            this.Alumno_BT.Click += new System.EventHandler(this.Cliente_BT_Click);
            // 
            // TodosAlumno_CkB
            // 
            this.TodosAlumno_CkB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TodosAlumno_CkB.AutoSize = true;
            this.TodosAlumno_CkB.Checked = true;
            this.TodosAlumno_CkB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TodosAlumno_CkB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TodosAlumno_CkB.Location = new System.Drawing.Point(455, 21);
            this.TodosAlumno_CkB.Name = "TodosAlumno_CkB";
            this.TodosAlumno_CkB.Size = new System.Drawing.Size(95, 17);
            this.TodosAlumno_CkB.TabIndex = 14;
            this.TodosAlumno_CkB.Text = "Mostrar Todos";
            this.TodosAlumno_CkB.UseVisualStyleBackColor = true;
            this.TodosAlumno_CkB.CheckedChanged += new System.EventHandler(this.TodosCliente_CkB_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Selección:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Promocion_GB
            // 
            this.Promocion_GB.Controls.Add(this.TodosPromocion_CkB);
            this.Promocion_GB.Controls.Add(this.Promocion_TB);
            this.Promocion_GB.Controls.Add(this.Promocion_BT);
            this.Promocion_GB.Controls.Add(this.label1);
            this.Promocion_GB.Location = new System.Drawing.Point(46, 26);
            this.Promocion_GB.Name = "Promocion_GB";
            this.Promocion_GB.Size = new System.Drawing.Size(568, 51);
            this.Promocion_GB.TabIndex = 32;
            this.Promocion_GB.TabStop = false;
            this.Promocion_GB.Text = "Promociones";
            // 
            // TodosPromocion_CkB
            // 
            this.TodosPromocion_CkB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TodosPromocion_CkB.AutoSize = true;
            this.TodosPromocion_CkB.Checked = true;
            this.TodosPromocion_CkB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TodosPromocion_CkB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TodosPromocion_CkB.Location = new System.Drawing.Point(455, 21);
            this.TodosPromocion_CkB.Name = "TodosPromocion_CkB";
            this.TodosPromocion_CkB.Size = new System.Drawing.Size(95, 17);
            this.TodosPromocion_CkB.TabIndex = 19;
            this.TodosPromocion_CkB.Text = "Mostrar Todos";
            this.TodosPromocion_CkB.UseVisualStyleBackColor = true;
            this.TodosPromocion_CkB.CheckedChanged += new System.EventHandler(this.TodosProducto_CkB_CheckedChanged);
            // 
            // Promocion_TB
            // 
            this.Promocion_TB.Location = new System.Drawing.Point(86, 19);
            this.Promocion_TB.Name = "Promocion_TB";
            this.Promocion_TB.ReadOnly = true;
            this.Promocion_TB.Size = new System.Drawing.Size(290, 21);
            this.Promocion_TB.TabIndex = 18;
            // 
            // Promocion_BT
            // 
            this.Promocion_BT.Enabled = false;
            this.Promocion_BT.Image = global::moleQule.Face.Instruction.Properties.Resources.select_16;
            this.Promocion_BT.Location = new System.Drawing.Point(382, 18);
            this.Promocion_BT.Name = "Promocion_BT";
            this.Promocion_BT.Size = new System.Drawing.Size(42, 23);
            this.Promocion_BT.TabIndex = 17;
            this.Promocion_BT.UseVisualStyleBackColor = true;
            this.Promocion_BT.Click += new System.EventHandler(this.Producto_BT_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Selección:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Documentos_GB
            // 
            this.Documentos_GB.Controls.Add(this.Documentos_CLB);
            this.Documentos_GB.Location = new System.Drawing.Point(46, 140);
            this.Documentos_GB.Name = "Documentos_GB";
            this.Documentos_GB.Size = new System.Drawing.Size(568, 109);
            this.Documentos_GB.TabIndex = 35;
            this.Documentos_GB.TabStop = false;
            this.Documentos_GB.Text = "Documentos";
            // 
            // Documentos_CLB
            // 
            this.Documentos_CLB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Documentos_CLB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Documentos_CLB.FormattingEnabled = true;
            this.Documentos_CLB.Location = new System.Drawing.Point(153, 30);
            this.Documentos_CLB.Name = "Documentos_CLB";
            this.Documentos_CLB.Size = new System.Drawing.Size(262, 48);
            this.Documentos_CLB.TabIndex = 0;
            // 
            // MatriculasActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(663, 316);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MatriculasActionForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "Documentos: Alumnos";
            this.Source_GB.ResumeLayout(false);
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            this.Alumno_GB.ResumeLayout(false);
            this.Alumno_GB.PerformLayout();
            this.Promocion_GB.ResumeLayout(false);
            this.Promocion_GB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_TiposPro)).EndInit();
            this.Documentos_GB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos_TiposExp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Alumno_GB;
        private System.Windows.Forms.CheckBox TodosAlumno_CkB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox Promocion_GB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Promocion_TB;
        private System.Windows.Forms.Button Promocion_BT;
        private System.Windows.Forms.TextBox Alumno_TB;
        private System.Windows.Forms.Button Alumno_BT;
        private System.Windows.Forms.GroupBox Documentos_GB;
        private System.Windows.Forms.BindingSource Datos_TiposPro;
        private System.Windows.Forms.BindingSource Datos_TiposExp;
        private System.Windows.Forms.CheckBox TodosPromocion_CkB;
        private System.Windows.Forms.CheckedListBox Documentos_CLB;
    }
}
