namespace moleQule.Face.Instruction
{
    partial class PlantillaAddForm
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
            System.Windows.Forms.Label desarrolloLabel;
            System.Windows.Forms.Label idiomaLabel;
            System.Windows.Forms.Label oidModuloLabel;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlantillaAddForm));
            this.desarrolloCheckBox = new System.Windows.Forms.CheckBox();
            this.Idioma_CB = new System.Windows.Forms.ComboBox();
            this.Datos_Idiomas = new System.Windows.Forms.BindingSource(this.components);
            this.Modulo_CB = new System.Windows.Forms.ComboBox();
            this.Datos_Modulos = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            desarrolloLabel = new System.Windows.Forms.Label();
            idiomaLabel = new System.Windows.Forms.Label();
            oidModuloLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PanelesV)).BeginInit();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Paneles2)).BeginInit();
            this.Paneles2.Panel1.SuspendLayout();
            this.Paneles2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMng_EP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).BeginInit();
            this.Progress_Panel.SuspendLayout();
            this.ProgressBK_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Progress_PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Idiomas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Modulos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.Controls.Add(this.groupBox1);
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            this.PanelesV.Panel1MinSize = 180;
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(464, 249);
            this.PanelesV.SplitterDistance = 194;
            // 
            // Submit_BT
            // 
            this.Submit_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Submit_BT.Location = new System.Drawing.Point(251, 6);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Cancel_BT.Location = new System.Drawing.Point(341, 6);
            this.HelpProvider.SetShowHelp(this.Cancel_BT, true);
            // 
            // Paneles2
            // 
            this.ErrorMng_EP.SetError(this.Paneles2, "F1 Ayuda        ");
            // 
            // Paneles2.Panel1
            // 
            this.HelpProvider.SetShowHelp(this.Paneles2.Panel1, true);
            // 
            // Paneles2.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.Paneles2.Panel2, true);
            this.HelpProvider.SetShowHelp(this.Paneles2, true);
            this.Paneles2.Size = new System.Drawing.Size(462, 52);
            this.Paneles2.SplitterDistance = 30;
            // 
            // Imprimir_Button
            // 
            this.Imprimir_Button.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Imprimir_Button.Location = new System.Drawing.Point(161, 6);
            this.HelpProvider.SetShowHelp(this.Imprimir_Button, true);
            // 
            // Docs_BT
            // 
            this.Docs_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Docs_BT.Location = new System.Drawing.Point(190, 6);
            this.HelpProvider.SetShowHelp(this.Docs_BT, true);
            // 
            // Datos
            // 
            this.Datos.DataSource = typeof(moleQule.Library.Instruction.PlantillaExamen);
            // 
            // Progress_Panel
            // 
            this.Progress_Panel.Location = new System.Drawing.Point(53, 15);
            // 
            // ProgressBK_Panel
            // 
            this.ProgressBK_Panel.Size = new System.Drawing.Size(464, 249);
            // 
            // ProgressInfo_PB
            // 
            this.ProgressInfo_PB.Location = new System.Drawing.Point(195, 173);
            // 
            // Progress_PB
            // 
            this.Progress_PB.Location = new System.Drawing.Point(195, 88);
            // 
            // desarrolloLabel
            // 
            desarrolloLabel.AutoSize = true;
            desarrolloLabel.Location = new System.Drawing.Point(269, 104);
            desarrolloLabel.Name = "desarrolloLabel";
            desarrolloLabel.Size = new System.Drawing.Size(59, 13);
            desarrolloLabel.TabIndex = 0;
            desarrolloLabel.Text = "Desarrollo:";
            // 
            // idiomaLabel
            // 
            idiomaLabel.AutoSize = true;
            idiomaLabel.Location = new System.Drawing.Point(19, 104);
            idiomaLabel.Name = "idiomaLabel";
            idiomaLabel.Size = new System.Drawing.Size(43, 13);
            idiomaLabel.TabIndex = 2;
            idiomaLabel.Text = "Idioma:";
            // 
            // oidModuloLabel
            // 
            oidModuloLabel.AutoSize = true;
            oidModuloLabel.Location = new System.Drawing.Point(18, 23);
            oidModuloLabel.Name = "oidModuloLabel";
            oidModuloLabel.Size = new System.Drawing.Size(45, 13);
            oidModuloLabel.TabIndex = 4;
            oidModuloLabel.Text = "Módulo:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(24, 63);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(37, 13);
            label1.TabIndex = 7;
            label1.Text = "Título:";
            // 
            // desarrolloCheckBox
            // 
            this.desarrolloCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.Datos, "Desarrollo", true));
            this.desarrolloCheckBox.Location = new System.Drawing.Point(343, 99);
            this.desarrolloCheckBox.Name = "desarrolloCheckBox";
            this.desarrolloCheckBox.Size = new System.Drawing.Size(28, 24);
            this.desarrolloCheckBox.TabIndex = 1;
            // 
            // Idioma_CB
            // 
            this.Idioma_CB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Idioma", true));
            this.Idioma_CB.DataSource = this.Datos_Idiomas;
            this.Idioma_CB.DisplayMember = "Texto";
            this.Idioma_CB.FormattingEnabled = true;
            this.Idioma_CB.Location = new System.Drawing.Point(75, 100);
            this.Idioma_CB.Name = "Idioma_CB";
            this.Idioma_CB.Size = new System.Drawing.Size(121, 21);
            this.Idioma_CB.TabIndex = 3;
            this.Idioma_CB.ValueMember = "Texto";
            // 
            // Datos_Idiomas
            // 
            this.Datos_Idiomas.DataSource = typeof(moleQule.Library.ComboBoxSourceList);
            // 
            // Modulo_CB
            // 
            this.Modulo_CB.DataSource = this.Datos_Modulos;
            this.Modulo_CB.DisplayMember = "Texto";
            this.Modulo_CB.FormattingEnabled = true;
            this.Modulo_CB.Location = new System.Drawing.Point(75, 20);
            this.Modulo_CB.Name = "Modulo_CB";
            this.Modulo_CB.Size = new System.Drawing.Size(342, 21);
            this.Modulo_CB.TabIndex = 5;
            this.Modulo_CB.ValueMember = "Oid";
            this.Modulo_CB.SelectedIndexChanged += new System.EventHandler(this.Modulo_CB_SelectedIndexChanged);
            // 
            // Datos_Modulos
            // 
            this.Datos_Modulos.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.Modulo_CB);
            this.groupBox1.Controls.Add(desarrolloLabel);
            this.groupBox1.Controls.Add(this.desarrolloCheckBox);
            this.groupBox1.Controls.Add(idiomaLabel);
            this.groupBox1.Controls.Add(oidModuloLabel);
            this.groupBox1.Controls.Add(this.Idioma_CB);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 156);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Nombre", true));
            this.textBox1.Location = new System.Drawing.Point(75, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(342, 21);
            this.textBox1.TabIndex = 6;
            // 
            // PlantillaAddForm
            // 
            this.ClientSize = new System.Drawing.Size(464, 249);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PlantillaAddForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "PlantillaAddForm";
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelesV)).EndInit();
            this.PanelesV.ResumeLayout(false);
            this.Paneles2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Paneles2)).EndInit();
            this.Paneles2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMng_EP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).EndInit();
            this.Progress_Panel.ResumeLayout(false);
            this.Progress_Panel.PerformLayout();
            this.ProgressBK_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Progress_PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Idiomas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Modulos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox Modulo_CB;
        private System.Windows.Forms.BindingSource Datos_Modulos;
        private System.Windows.Forms.ComboBox Idioma_CB;
        private System.Windows.Forms.BindingSource Datos_Idiomas;
        private System.Windows.Forms.CheckBox desarrolloCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
    }
}
