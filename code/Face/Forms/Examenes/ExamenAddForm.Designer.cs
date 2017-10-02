namespace moleQule.Face.Instruction
{
    partial class ExamenAddForm
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
            System.Windows.Forms.Label oidModuloLabel;
            System.Windows.Forms.Label oidPromocionLabel;
            System.Windows.Forms.Label oidProfesorLabel;
            System.Windows.Forms.Label tipoLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExamenAddForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Instructor_TB = new System.Windows.Forms.TextBox();
            this.Instructor_BT = new System.Windows.Forms.Button();
            this.Modulo_BT = new System.Windows.Forms.Button();
            this.Modulo_TB = new System.Windows.Forms.TextBox();
            this.Titulo_TB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FExamen_DTP = new System.Windows.Forms.DateTimePicker();
            this.FCreacion_DTP = new System.Windows.Forms.DateTimePicker();
            this.Desarrollo_CB = new System.Windows.Forms.CheckBox();
            this.Tipo_CB = new System.Windows.Forms.ComboBox();
            this.Datos_Tipos = new System.Windows.Forms.BindingSource(this.components);
            this.Promocion_CB = new System.Windows.Forms.ComboBox();
            this.Datos_Promociones = new System.Windows.Forms.BindingSource(this.components);
            this.Datos_Instructores = new System.Windows.Forms.BindingSource(this.components);
            this.Datos_Modulos = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ClearPromociones_BT = new System.Windows.Forms.Button();
            this.Promociones_CLB = new System.Windows.Forms.CheckedListBox();
            this.Promocion_BT = new System.Windows.Forms.Button();
            oidModuloLabel = new System.Windows.Forms.Label();
            oidPromocionLabel = new System.Windows.Forms.Label();
            oidProfesorLabel = new System.Windows.Forms.Label();
            tipoLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
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
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Tipos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Promociones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Instructores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Modulos)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.Controls.Add(this.groupBox5);
            this.PanelesV.Panel1.Controls.Add(this.groupBox1);
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            this.PanelesV.Panel1MinSize = 210;
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(577, 400);
            this.PanelesV.SplitterDistance = 345;
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
            this.Paneles2.Size = new System.Drawing.Size(575, 52);
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
            this.Docs_BT.Location = new System.Drawing.Point(282, 9);
            this.HelpProvider.SetShowHelp(this.Docs_BT, true);
            // 
            // Datos
            // 
            this.Datos.DataSource = typeof(moleQule.Library.Instruction.Examen);
            // 
            // Progress_Panel
            // 
            this.Progress_Panel.Location = new System.Drawing.Point(109, 96);
            // 
            // ProgressBK_Panel
            // 
            this.ProgressBK_Panel.Size = new System.Drawing.Size(577, 400);
            // 
            // ProgressInfo_PB
            // 
            this.ProgressInfo_PB.Location = new System.Drawing.Point(251, 248);
            // 
            // Progress_PB
            // 
            this.Progress_PB.Location = new System.Drawing.Point(251, 163);
            // 
            // oidModuloLabel
            // 
            oidModuloLabel.AutoSize = true;
            oidModuloLabel.Location = new System.Drawing.Point(46, 58);
            oidModuloLabel.Name = "oidModuloLabel";
            oidModuloLabel.Size = new System.Drawing.Size(45, 13);
            oidModuloLabel.TabIndex = 0;
            oidModuloLabel.Text = "Módulo:";
            // 
            // oidPromocionLabel
            // 
            oidPromocionLabel.AutoSize = true;
            oidPromocionLabel.Location = new System.Drawing.Point(21, 100);
            oidPromocionLabel.Name = "oidPromocionLabel";
            oidPromocionLabel.Size = new System.Drawing.Size(60, 13);
            oidPromocionLabel.TabIndex = 2;
            oidPromocionLabel.Text = "Promoción:";
            // 
            // oidProfesorLabel
            // 
            oidProfesorLabel.AutoSize = true;
            oidProfesorLabel.Location = new System.Drawing.Point(267, 100);
            oidProfesorLabel.Name = "oidProfesorLabel";
            oidProfesorLabel.Size = new System.Drawing.Size(59, 13);
            oidProfesorLabel.TabIndex = 4;
            oidProfesorLabel.Text = "Instructor:";
            // 
            // tipoLabel
            // 
            tipoLabel.AutoSize = true;
            tipoLabel.Location = new System.Drawing.Point(57, 137);
            tipoLabel.Name = "tipoLabel";
            tipoLabel.Size = new System.Drawing.Size(31, 13);
            tipoLabel.TabIndex = 6;
            tipoLabel.Text = "Tipo:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(30, 179);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(85, 13);
            label1.TabIndex = 10;
            label1.Text = "Fecha Creación:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(316, 179);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(81, 13);
            label2.TabIndex = 12;
            label2.Text = "Fecha Examen:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Instructor_TB);
            this.groupBox1.Controls.Add(this.Instructor_BT);
            this.groupBox1.Controls.Add(this.Modulo_BT);
            this.groupBox1.Controls.Add(this.Modulo_TB);
            this.groupBox1.Controls.Add(this.Titulo_TB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(label2);
            this.groupBox1.Controls.Add(this.FExamen_DTP);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(this.FCreacion_DTP);
            this.groupBox1.Controls.Add(this.Desarrollo_CB);
            this.groupBox1.Controls.Add(tipoLabel);
            this.groupBox1.Controls.Add(this.Tipo_CB);
            this.groupBox1.Controls.Add(oidProfesorLabel);
            this.groupBox1.Controls.Add(oidPromocionLabel);
            this.groupBox1.Controls.Add(this.Promocion_CB);
            this.groupBox1.Controls.Add(oidModuloLabel);
            this.groupBox1.Location = new System.Drawing.Point(11, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 210);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // Instructor_TB
            // 
            this.Instructor_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Instructor", true));
            this.Instructor_TB.Location = new System.Drawing.Point(330, 95);
            this.Instructor_TB.Name = "Instructor_TB";
            this.Instructor_TB.ReadOnly = true;
            this.Instructor_TB.Size = new System.Drawing.Size(151, 21);
            this.Instructor_TB.TabIndex = 17;
            // 
            // Instructor_BT
            // 
            this.Instructor_BT.Image = global::moleQule.Face.Instruction.Properties.Resources.select_16;
            this.Instructor_BT.Location = new System.Drawing.Point(487, 95);
            this.Instructor_BT.Name = "Instructor_BT";
            this.Instructor_BT.Size = new System.Drawing.Size(46, 23);
            this.Instructor_BT.TabIndex = 16;
            this.Instructor_BT.UseVisualStyleBackColor = true;
            this.Instructor_BT.Click += new System.EventHandler(this.Instructor_BT_Click);
            // 
            // Modulo_BT
            // 
            this.Modulo_BT.Image = global::moleQule.Face.Instruction.Properties.Resources.select_16;
            this.Modulo_BT.Location = new System.Drawing.Point(487, 53);
            this.Modulo_BT.Name = "Modulo_BT";
            this.Modulo_BT.Size = new System.Drawing.Size(46, 23);
            this.Modulo_BT.TabIndex = 6;
            this.Modulo_BT.UseVisualStyleBackColor = true;
            this.Modulo_BT.Click += new System.EventHandler(this.Modulo_BT_Click);
            // 
            // Modulo_TB
            // 
            this.Modulo_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Modulo", true));
            this.Modulo_TB.Location = new System.Drawing.Point(97, 55);
            this.Modulo_TB.Name = "Modulo_TB";
            this.Modulo_TB.ReadOnly = true;
            this.Modulo_TB.Size = new System.Drawing.Size(384, 21);
            this.Modulo_TB.TabIndex = 15;
            // 
            // Titulo_TB
            // 
            this.Titulo_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Titulo", true));
            this.Titulo_TB.Location = new System.Drawing.Point(97, 21);
            this.Titulo_TB.Name = "Titulo_TB";
            this.Titulo_TB.Size = new System.Drawing.Size(384, 21);
            this.Titulo_TB.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Título:";
            // 
            // FExamen_DTP
            // 
            this.FExamen_DTP.Checked = false;
            this.FExamen_DTP.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.Datos, "FechaExamen", true));
            this.FExamen_DTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FExamen_DTP.Location = new System.Drawing.Point(413, 175);
            this.FExamen_DTP.Name = "FExamen_DTP";
            this.FExamen_DTP.ShowCheckBox = true;
            this.FExamen_DTP.Size = new System.Drawing.Size(116, 21);
            this.FExamen_DTP.TabIndex = 11;
            // 
            // FCreacion_DTP
            // 
            this.FCreacion_DTP.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.Datos, "FechaCreacion", true));
            this.FCreacion_DTP.Enabled = false;
            this.FCreacion_DTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FCreacion_DTP.Location = new System.Drawing.Point(131, 173);
            this.FCreacion_DTP.Name = "FCreacion_DTP";
            this.FCreacion_DTP.ShowCheckBox = true;
            this.FCreacion_DTP.Size = new System.Drawing.Size(116, 21);
            this.FCreacion_DTP.TabIndex = 9;
            // 
            // Desarrollo_CB
            // 
            this.Desarrollo_CB.AutoSize = true;
            this.Desarrollo_CB.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.Datos, "Desarrollo", true));
            this.Desarrollo_CB.Location = new System.Drawing.Point(351, 137);
            this.Desarrollo_CB.Name = "Desarrollo_CB";
            this.Desarrollo_CB.Size = new System.Drawing.Size(74, 17);
            this.Desarrollo_CB.TabIndex = 8;
            this.Desarrollo_CB.Text = "Desarrollo";
            this.Desarrollo_CB.UseVisualStyleBackColor = true;
            // 
            // Tipo_CB
            // 
            this.Tipo_CB.DataSource = this.Datos_Tipos;
            this.Tipo_CB.DisplayMember = "Texto";
            this.Tipo_CB.FormattingEnabled = true;
            this.Tipo_CB.Location = new System.Drawing.Point(97, 135);
            this.Tipo_CB.Name = "Tipo_CB";
            this.Tipo_CB.Size = new System.Drawing.Size(150, 21);
            this.Tipo_CB.TabIndex = 7;
            this.Tipo_CB.ValueMember = "Oid";
            this.Tipo_CB.SelectedIndexChanged += new System.EventHandler(this.Tipo_CB_SelectedIndexChanged);
            // 
            // Datos_Tipos
            // 
            this.Datos_Tipos.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // Promocion_CB
            // 
            this.Promocion_CB.DataSource = this.Datos_Promociones;
            this.Promocion_CB.DisplayMember = "Texto";
            this.Promocion_CB.FormattingEnabled = true;
            this.Promocion_CB.Location = new System.Drawing.Point(97, 97);
            this.Promocion_CB.Name = "Promocion_CB";
            this.Promocion_CB.Size = new System.Drawing.Size(150, 21);
            this.Promocion_CB.TabIndex = 3;
            this.Promocion_CB.ValueMember = "Oid";
            this.Promocion_CB.SelectedIndexChanged += new System.EventHandler(this.Promocion_CB_SelectedIndexChanged);
            // 
            // Datos_Promociones
            // 
            this.Datos_Promociones.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // Datos_Instructores
            // 
            this.Datos_Instructores.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // Datos_Modulos
            // 
            this.Datos_Modulos.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ClearPromociones_BT);
            this.groupBox5.Controls.Add(this.Promociones_CLB);
            this.groupBox5.Controls.Add(this.Promocion_BT);
            this.groupBox5.Location = new System.Drawing.Point(16, 219);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(545, 115);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Promociones";
            // 
            // ClearPromociones_BT
            // 
            this.ClearPromociones_BT.Image = global::moleQule.Face.Instruction.Properties.Resources.close_16;
            this.ClearPromociones_BT.Location = new System.Drawing.Point(482, 67);
            this.ClearPromociones_BT.Name = "ClearPromociones_BT";
            this.ClearPromociones_BT.Size = new System.Drawing.Size(46, 23);
            this.ClearPromociones_BT.TabIndex = 5;
            this.ClearPromociones_BT.UseVisualStyleBackColor = true;
            this.ClearPromociones_BT.Click += new System.EventHandler(this.ClearPromociones_BT_Click);
            // 
            // Promociones_CLB
            // 
            this.Promociones_CLB.FormattingEnabled = true;
            this.Promociones_CLB.Location = new System.Drawing.Point(12, 22);
            this.Promociones_CLB.MultiColumn = true;
            this.Promociones_CLB.Name = "Promociones_CLB";
            this.Promociones_CLB.Size = new System.Drawing.Size(464, 84);
            this.Promociones_CLB.TabIndex = 3;
            this.Promociones_CLB.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.Promociones_CLB_ItemCheck);
            // 
            // Promocion_BT
            // 
            this.Promocion_BT.Image = global::moleQule.Face.Instruction.Properties.Resources.select_16;
            this.Promocion_BT.Location = new System.Drawing.Point(482, 38);
            this.Promocion_BT.Name = "Promocion_BT";
            this.Promocion_BT.Size = new System.Drawing.Size(46, 23);
            this.Promocion_BT.TabIndex = 4;
            this.Promocion_BT.UseVisualStyleBackColor = true;
            this.Promocion_BT.Click += new System.EventHandler(this.Promocion_BT_Click);
            // 
            // ExamenAddForm
            // 
            this.ClientSize = new System.Drawing.Size(577, 400);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExamenAddForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "ExamenAddForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExamenAddForm_FormClosing);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Tipos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Promociones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Instructores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Modulos)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox Promocion_CB;
        private System.Windows.Forms.ComboBox Tipo_CB;
        private System.Windows.Forms.BindingSource Datos_Instructores;
        protected System.Windows.Forms.BindingSource Datos_Modulos;
        private System.Windows.Forms.BindingSource Datos_Promociones;
        private System.Windows.Forms.BindingSource Datos_Tipos;
        private System.Windows.Forms.CheckBox Desarrollo_CB;
        private System.Windows.Forms.DateTimePicker FCreacion_DTP;
        private System.Windows.Forms.DateTimePicker FExamen_DTP;
        private System.Windows.Forms.TextBox Titulo_TB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button ClearPromociones_BT;
        private System.Windows.Forms.CheckedListBox Promociones_CLB;
        private System.Windows.Forms.Button Promocion_BT;
        private System.Windows.Forms.Button Modulo_BT;
        private System.Windows.Forms.TextBox Modulo_TB;
        private System.Windows.Forms.TextBox Instructor_TB;
        private System.Windows.Forms.Button Instructor_BT;
    }
}
