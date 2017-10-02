namespace moleQule.Face.Instruction
{
    partial class InstructoresPromocionViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstructoresPromocionViewForm));
            this.SC1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Arbol_TV = new System.Windows.Forms.TreeView();
            this.Iconos_IL = new System.Windows.Forms.ImageList(this.components);
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            this.Paneles2.Panel1.SuspendLayout();
            this.Paneles2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            this.SC1.Panel1.SuspendLayout();
            this.SC1.Panel2.SuspendLayout();
            this.SC1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.Controls.Add(this.SC1);
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(1163, 765);
            this.PanelesV.SplitterDistance = 724;
            // 
            // Submit_BT
            // 
            this.Submit_BT.Location = new System.Drawing.Point(251, 6);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Location = new System.Drawing.Point(341, 6);
            this.HelpProvider.SetShowHelp(this.Cancel_BT, true);
            // 
            // Paneles2
            // 
            // 
            // Paneles2.Panel1
            // 
            this.HelpProvider.SetShowHelp(this.Paneles2.Panel1, true);
            // 
            // Paneles2.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.Paneles2.Panel2, true);
            this.HelpProvider.SetShowHelp(this.Paneles2, true);
            this.Paneles2.Size = new System.Drawing.Size(1161, 38);
            this.Paneles2.SplitterDistance = 37;
            // 
            // Imprimir_Button
            // 
            this.Imprimir_Button.Location = new System.Drawing.Point(161, 6);
            this.HelpProvider.SetShowHelp(this.Imprimir_Button, true);
            // 
            // Docs_BT
            // 
            this.Docs_BT.Location = new System.Drawing.Point(300, 6);
            this.HelpProvider.SetShowHelp(this.Docs_BT, true);
            // 
            // SC1
            // 
            this.SC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SC1.IsSplitterFixed = true;
            this.SC1.Location = new System.Drawing.Point(0, 0);
            this.SC1.Name = "SC1";
            this.SC1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SC1.Panel1
            // 
            this.SC1.Panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.SC1.Panel1.Controls.Add(this.label2);
            this.SC1.Panel1.Controls.Add(this.label1);
            this.SC1.Panel1MinSize = 80;
            // 
            // SC1.Panel2
            // 
            this.SC1.Panel2.Controls.Add(this.Arbol_TV);
            this.SC1.Panel2MinSize = 80;
            this.SC1.Size = new System.Drawing.Size(1161, 722);
            this.SC1.SplitterDistance = 80;
            this.SC1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1125, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 33);
            this.label2.TabIndex = 1;
            this.label2.Tag = "No Format";
            this.label2.Text = "|";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 33);
            this.label1.TabIndex = 0;
            this.label1.Tag = "No Format";
            this.label1.Text = "| Asignación de submódulos";
            // 
            // Arbol_TV
            // 
            this.Arbol_TV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Arbol_TV.ImageIndex = 0;
            this.Arbol_TV.ImageList = this.Iconos_IL;
            this.Arbol_TV.Location = new System.Drawing.Point(0, 0);
            this.Arbol_TV.Name = "Arbol_TV";
            this.Arbol_TV.SelectedImageIndex = 0;
            this.Arbol_TV.Size = new System.Drawing.Size(1161, 638);
            this.Arbol_TV.TabIndex = 0;
            // 
            // Iconos_IL
            // 
            this.Iconos_IL.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Iconos_IL.ImageStream")));
            this.Iconos_IL.TransparentColor = System.Drawing.Color.Transparent;
            this.Iconos_IL.Images.SetKeyName(0, "modulo");
            this.Iconos_IL.Images.SetKeyName(1, "submodulo");
            this.Iconos_IL.Images.SetKeyName(2, "promocion");
            // 
            // InstructoresPromocionViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(1163, 765);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InstructoresPromocionViewForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "IntructoresPromocionViewForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlantillaForm_FormClosing);
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            this.Paneles2.Panel1.ResumeLayout(false);
            this.Paneles2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            this.SC1.Panel1.ResumeLayout(false);
            this.SC1.Panel1.PerformLayout();
            this.SC1.Panel2.ResumeLayout(false);
            this.SC1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SC1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView Arbol_TV;
        protected System.Windows.Forms.ImageList Iconos_IL;


    }
}
