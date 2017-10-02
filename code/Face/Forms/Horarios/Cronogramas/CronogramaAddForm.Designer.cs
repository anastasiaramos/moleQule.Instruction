namespace moleQule.Face.Instruction
{
    partial class CronogramaAddForm
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
            System.Windows.Forms.Label oidPlanLabel;
            System.Windows.Forms.Label oidPromocionLabel;
            System.Windows.Forms.Label observacionesLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CronogramaAddForm));
            this.Plan_CB = new System.Windows.Forms.ComboBox();
            this.Datos_Planes = new System.Windows.Forms.BindingSource(this.components);
            this.Promocion_CB = new System.Windows.Forms.ComboBox();
            this.Datos_Promociones = new System.Windows.Forms.BindingSource(this.components);
            this.observacionesTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Sesiones_Grid = new System.Windows.Forms.DataGridView();
            this.HoraInicio_CBC = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Datos_Horas = new System.Windows.Forms.BindingSource(this.components);
            this.nHorasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datos_Sesiones = new System.Windows.Forms.BindingSource(this.components);
            this.Practicas_NUD = new System.Windows.Forms.NumericUpDown();
            this.Sabado_GB = new System.Windows.Forms.GroupBox();
            this.CLB_3 = new System.Windows.Forms.CheckedListBox();
            this.Semana_GB = new System.Windows.Forms.GroupBox();
            this.CLB_1 = new System.Windows.Forms.CheckedListBox();
            this.CLB_2 = new System.Windows.Forms.CheckedListBox();
            this.Semana_NUD = new System.Windows.Forms.NumericUpDown();
            this.Generar_BT = new System.Windows.Forms.Button();
            oidPlanLabel = new System.Windows.Forms.Label();
            oidPromocionLabel = new System.Windows.Forms.Label();
            observacionesLabel = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Planes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Promociones)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sesiones_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Horas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Sesiones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Practicas_NUD)).BeginInit();
            this.Sabado_GB.SuspendLayout();
            this.Semana_GB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Semana_NUD)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.Controls.Add(this.Generar_BT);
            this.PanelesV.Panel1.Controls.Add(this.groupBox1);
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(596, 487);
            this.PanelesV.SplitterDistance = 432;
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
            this.Paneles2.Size = new System.Drawing.Size(594, 52);
            this.Paneles2.SplitterDistance = 27;
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
            this.Docs_BT.Location = new System.Drawing.Point(190, 8);
            this.HelpProvider.SetShowHelp(this.Docs_BT, true);
            // 
            // Datos
            // 
            this.Datos.DataSource = typeof(moleQule.Library.Instruction.Cronograma);
            // 
            // Progress_Panel
            // 
            this.Progress_Panel.Location = new System.Drawing.Point(119, 96);
            // 
            // ProgressBK_Panel
            // 
            this.ProgressBK_Panel.Size = new System.Drawing.Size(596, 487);
            // 
            // ProgressInfo_PB
            // 
            this.ProgressInfo_PB.Location = new System.Drawing.Point(261, 292);
            // 
            // Progress_PB
            // 
            this.Progress_PB.Location = new System.Drawing.Point(261, 207);
            // 
            // oidPlanLabel
            // 
            oidPlanLabel.AutoSize = true;
            oidPlanLabel.Location = new System.Drawing.Point(15, 23);
            oidPlanLabel.Name = "oidPlanLabel";
            oidPlanLabel.Size = new System.Drawing.Size(74, 13);
            oidPlanLabel.TabIndex = 0;
            oidPlanLabel.Text = "Plan Estudios:";
            // 
            // oidPromocionLabel
            // 
            oidPromocionLabel.AutoSize = true;
            oidPromocionLabel.Location = new System.Drawing.Point(29, 61);
            oidPromocionLabel.Name = "oidPromocionLabel";
            oidPromocionLabel.Size = new System.Drawing.Size(60, 13);
            oidPromocionLabel.TabIndex = 2;
            oidPromocionLabel.Text = "Promoción:";
            // 
            // observacionesLabel
            // 
            observacionesLabel.AutoSize = true;
            observacionesLabel.Location = new System.Drawing.Point(6, 311);
            observacionesLabel.Name = "observacionesLabel";
            observacionesLabel.Size = new System.Drawing.Size(82, 13);
            observacionesLabel.TabIndex = 4;
            observacionesLabel.Text = "Observaciones:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(21, 101);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(144, 13);
            label1.TabIndex = 6;
            label1.Text = "Semana Comienzo Prácticas:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(290, 101);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(148, 13);
            label2.TabIndex = 22;
            label2.Text = "Número Prácticas Semanales:";
            // 
            // Plan_CB
            // 
            this.Plan_CB.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.Datos, "OidPlan", true));
            this.Plan_CB.DataSource = this.Datos_Planes;
            this.Plan_CB.DisplayMember = "Texto";
            this.Plan_CB.FormattingEnabled = true;
            this.Plan_CB.Location = new System.Drawing.Point(105, 20);
            this.Plan_CB.Name = "Plan_CB";
            this.Plan_CB.Size = new System.Drawing.Size(461, 21);
            this.Plan_CB.TabIndex = 1;
            this.Plan_CB.ValueMember = "Oid";
            this.Plan_CB.SelectedValueChanged += new System.EventHandler(this.Plan_CB_SelectedIndexChanged);
            // 
            // Datos_Planes
            // 
            this.Datos_Planes.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // Promocion_CB
            // 
            this.Promocion_CB.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.Datos, "OidPromocion", true));
            this.Promocion_CB.DataSource = this.Datos_Promociones;
            this.Promocion_CB.DisplayMember = "Texto";
            this.Promocion_CB.FormattingEnabled = true;
            this.Promocion_CB.Location = new System.Drawing.Point(105, 58);
            this.Promocion_CB.Name = "Promocion_CB";
            this.Promocion_CB.Size = new System.Drawing.Size(461, 21);
            this.Promocion_CB.TabIndex = 3;
            this.Promocion_CB.ValueMember = "Oid";
            this.Promocion_CB.SelectedIndexChanged += new System.EventHandler(this.Promocion_CB_SelectedIndexChanged);
            // 
            // Datos_Promociones
            // 
            this.Datos_Promociones.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // observacionesTextBox
            // 
            this.observacionesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Observaciones", true));
            this.observacionesTextBox.Location = new System.Drawing.Point(105, 308);
            this.observacionesTextBox.Multiline = true;
            this.observacionesTextBox.Name = "observacionesTextBox";
            this.observacionesTextBox.Size = new System.Drawing.Size(461, 68);
            this.observacionesTextBox.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Sesiones_Grid);
            this.groupBox1.Controls.Add(this.Practicas_NUD);
            this.groupBox1.Controls.Add(label2);
            this.groupBox1.Controls.Add(this.Sabado_GB);
            this.groupBox1.Controls.Add(this.Semana_GB);
            this.groupBox1.Controls.Add(this.Semana_NUD);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(observacionesLabel);
            this.groupBox1.Controls.Add(this.Plan_CB);
            this.groupBox1.Controls.Add(this.observacionesTextBox);
            this.groupBox1.Controls.Add(oidPlanLabel);
            this.groupBox1.Controls.Add(this.Promocion_CB);
            this.groupBox1.Controls.Add(oidPromocionLabel);
            this.groupBox1.Location = new System.Drawing.Point(7, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(579, 383);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // Sesiones_Grid
            // 
            this.Sesiones_Grid.AutoGenerateColumns = false;
            this.Sesiones_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Sesiones_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HoraInicio_CBC,
            this.nHorasDataGridViewTextBoxColumn});
            this.Sesiones_Grid.DataSource = this.Datos_Sesiones;
            this.Sesiones_Grid.Location = new System.Drawing.Point(363, 148);
            this.Sesiones_Grid.Name = "Sesiones_Grid";
            this.Sesiones_Grid.Size = new System.Drawing.Size(203, 125);
            this.Sesiones_Grid.TabIndex = 25;
            this.Sesiones_Grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Sesiones_Grid_DataError);
            // 
            // HoraInicio_CBC
            // 
            this.HoraInicio_CBC.DataPropertyName = "Hora";
            this.HoraInicio_CBC.DataSource = this.Datos_Horas;
            this.HoraInicio_CBC.DisplayMember = "Texto";
            this.HoraInicio_CBC.HeaderText = "Hora Inicio";
            this.HoraInicio_CBC.Name = "HoraInicio_CBC";
            this.HoraInicio_CBC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HoraInicio_CBC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.HoraInicio_CBC.ValueMember = "Texto";
            this.HoraInicio_CBC.Width = 70;
            // 
            // Datos_Horas
            // 
            this.Datos_Horas.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // nHorasDataGridViewTextBoxColumn
            // 
            this.nHorasDataGridViewTextBoxColumn.DataPropertyName = "NHoras";
            dataGridViewCellStyle1.NullValue = null;
            this.nHorasDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.nHorasDataGridViewTextBoxColumn.HeaderText = "Nº Horas";
            this.nHorasDataGridViewTextBoxColumn.Name = "nHorasDataGridViewTextBoxColumn";
            this.nHorasDataGridViewTextBoxColumn.Width = 70;
            // 
            // Datos_Sesiones
            // 
            this.Datos_Sesiones.DataSource = typeof(moleQule.Library.Instruction.Sesiones_Promociones);
            // 
            // Practicas_NUD
            // 
            this.Practicas_NUD.Location = new System.Drawing.Point(470, 99);
            this.Practicas_NUD.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.Practicas_NUD.Name = "Practicas_NUD";
            this.Practicas_NUD.Size = new System.Drawing.Size(61, 21);
            this.Practicas_NUD.TabIndex = 23;
            // 
            // Sabado_GB
            // 
            this.Sabado_GB.Controls.Add(this.CLB_3);
            this.Sabado_GB.Location = new System.Drawing.Point(242, 138);
            this.Sabado_GB.Name = "Sabado_GB";
            this.Sabado_GB.Size = new System.Drawing.Size(115, 164);
            this.Sabado_GB.TabIndex = 21;
            this.Sabado_GB.TabStop = false;
            this.Sabado_GB.Text = "Sábado";
            // 
            // CLB_3
            // 
            this.CLB_3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CLB_3.FormattingEnabled = true;
            this.CLB_3.Items.AddRange(new object[] {
            "9:00 - 10:00",
            "10:00 - 11:00",
            "11:00 - 12:00",
            "12:00 - 13:00",
            "13:00 - 14:00"});
            this.CLB_3.Location = new System.Drawing.Point(6, 20);
            this.CLB_3.Name = "CLB_3";
            this.CLB_3.Size = new System.Drawing.Size(102, 116);
            this.CLB_3.TabIndex = 17;
            // 
            // Semana_GB
            // 
            this.Semana_GB.Controls.Add(this.CLB_1);
            this.Semana_GB.Controls.Add(this.CLB_2);
            this.Semana_GB.Location = new System.Drawing.Point(6, 138);
            this.Semana_GB.Name = "Semana_GB";
            this.Semana_GB.Size = new System.Drawing.Size(223, 164);
            this.Semana_GB.TabIndex = 20;
            this.Semana_GB.TabStop = false;
            this.Semana_GB.Text = "De Lunes a Viernes";
            // 
            // CLB_1
            // 
            this.CLB_1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CLB_1.CheckOnClick = true;
            this.CLB_1.FormattingEnabled = true;
            this.CLB_1.Items.AddRange(new object[] {
            "8:00 - 9:00",
            "9:00 - 10:00",
            "10:00 - 11:00",
            "11:00 - 12:00",
            "12:00 - 13:00",
            "13:00 - 14:00",
            "14:00 - 15:00",
            "15:00 - 16:00"});
            this.CLB_1.Location = new System.Drawing.Point(6, 19);
            this.CLB_1.Name = "CLB_1";
            this.CLB_1.Size = new System.Drawing.Size(102, 132);
            this.CLB_1.TabIndex = 15;
            // 
            // CLB_2
            // 
            this.CLB_2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CLB_2.FormattingEnabled = true;
            this.CLB_2.Items.AddRange(new object[] {
            "16:00 - 17:00",
            "17:00 - 18:00",
            "18:00 - 19:00",
            "19:00 - 20:00",
            "20:00 - 21:00",
            "21:00 - 22:00"});
            this.CLB_2.Location = new System.Drawing.Point(114, 20);
            this.CLB_2.Name = "CLB_2";
            this.CLB_2.Size = new System.Drawing.Size(102, 132);
            this.CLB_2.TabIndex = 16;
            // 
            // Semana_NUD
            // 
            this.Semana_NUD.Location = new System.Drawing.Point(196, 99);
            this.Semana_NUD.Name = "Semana_NUD";
            this.Semana_NUD.Size = new System.Drawing.Size(61, 21);
            this.Semana_NUD.TabIndex = 7;
            // 
            // Generar_BT
            // 
            this.Generar_BT.Location = new System.Drawing.Point(220, 390);
            this.Generar_BT.Name = "Generar_BT";
            this.Generar_BT.Size = new System.Drawing.Size(155, 36);
            this.Generar_BT.TabIndex = 7;
            this.Generar_BT.Text = "Generar Cronograma";
            this.Generar_BT.UseVisualStyleBackColor = true;
            this.Generar_BT.Click += new System.EventHandler(this.Generar_BT_Click);
            // 
            // CronogramaAddForm
            // 
            this.ClientSize = new System.Drawing.Size(596, 487);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CronogramaAddForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "CronogramaForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CronogramaForm_FormClosing);
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
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Planes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Promociones)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sesiones_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Horas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Sesiones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Practicas_NUD)).EndInit();
            this.Sabado_GB.ResumeLayout(false);
            this.Semana_GB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Semana_NUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox Plan_CB;
        private System.Windows.Forms.TextBox observacionesTextBox;
        private System.Windows.Forms.ComboBox Promocion_CB;
        private System.Windows.Forms.Button Generar_BT;
        private System.Windows.Forms.BindingSource Datos_Planes;
        private System.Windows.Forms.BindingSource Datos_Promociones;
        private System.Windows.Forms.NumericUpDown Semana_NUD;
        private System.Windows.Forms.GroupBox Sabado_GB;
        protected System.Windows.Forms.CheckedListBox CLB_3;
        private System.Windows.Forms.GroupBox Semana_GB;
        protected System.Windows.Forms.CheckedListBox CLB_1;
        protected System.Windows.Forms.CheckedListBox CLB_2;
        private System.Windows.Forms.NumericUpDown Practicas_NUD;
        protected System.Windows.Forms.BindingSource Datos_Sesiones;
        protected System.Windows.Forms.BindingSource Datos_Horas;
        protected System.Windows.Forms.DataGridView Sesiones_Grid;
        private System.Windows.Forms.DataGridViewComboBoxColumn HoraInicio_CBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn nHorasDataGridViewTextBoxColumn;
    }
}
