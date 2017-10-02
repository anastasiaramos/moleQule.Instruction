namespace moleQule.Face.Instruction
{
    partial class DisponibilidadSemanalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisponibilidadSemanalForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.FechaFin_DTP = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MostrarTodos_CB = new System.Windows.Forms.CheckBox();
            this.Anterior_BT = new System.Windows.Forms.Button();
            this.Siguiente_BT = new System.Windows.Forms.Button();
            this.Fecha_DTP = new System.Windows.Forms.DateTimePicker();
            this.Disponibilidades_Grid = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lunes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Martes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Miercoles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jueves = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Viernes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sabado = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Disponibilidades_Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.Controls.Add(this.splitContainer1);
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(769, 609);
            this.PanelesV.SplitterDistance = 554;
            // 
            // Submit_BT
            // 
            this.Submit_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Submit_BT.Location = new System.Drawing.Point(124, 8);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Cancel_BT.Location = new System.Drawing.Point(191, 8);
            this.HelpProvider.SetShowHelp(this.Cancel_BT, true);
            this.Cancel_BT.Visible = false;
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
            this.Paneles2.Size = new System.Drawing.Size(767, 52);
            // 
            // Imprimir_Button
            // 
            this.Imprimir_Button.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Imprimir_Button.Location = new System.Drawing.Point(364, 8);
            this.HelpProvider.SetShowHelp(this.Imprimir_Button, true);
            // 
            // Docs_BT
            // 
            this.Docs_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Docs_BT.Location = new System.Drawing.Point(274, 8);
            this.HelpProvider.SetShowHelp(this.Docs_BT, true);
            // 
            // Datos
            // 
            this.Datos.DataSource = typeof(moleQule.Library.Instruction.RegistroDisponibilidad);
            this.Datos.DataSourceChanged += new System.EventHandler(this.Datos_DataSourceChanged);
            // 
            // Progress_Panel
            // 
            this.Progress_Panel.Location = new System.Drawing.Point(205, 96);
            // 
            // ProgressBK_Panel
            // 
            this.ProgressBK_Panel.Size = new System.Drawing.Size(769, 609);
            // 
            // ProgressInfo_PB
            // 
            this.ProgressInfo_PB.Location = new System.Drawing.Point(347, 353);
            // 
            // Progress_PB
            // 
            this.Progress_PB.Location = new System.Drawing.Point(347, 268);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.FechaFin_DTP);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.MostrarTodos_CB);
            this.splitContainer1.Panel1.Controls.Add(this.Anterior_BT);
            this.splitContainer1.Panel1.Controls.Add(this.Siguiente_BT);
            this.splitContainer1.Panel1.Controls.Add(this.Fecha_DTP);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Disponibilidades_Grid);
            this.splitContainer1.Size = new System.Drawing.Size(767, 552);
            this.splitContainer1.SplitterDistance = 69;
            this.splitContainer1.TabIndex = 0;
            // 
            // FechaFin_DTP
            // 
            this.FechaFin_DTP.Enabled = false;
            this.FechaFin_DTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaFin_DTP.Location = new System.Drawing.Point(464, 23);
            this.FechaFin_DTP.Name = "FechaFin_DTP";
            this.FechaFin_DTP.Size = new System.Drawing.Size(97, 21);
            this.FechaFin_DTP.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(432, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "al";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Semana del ";
            // 
            // MostrarTodos_CB
            // 
            this.MostrarTodos_CB.AutoSize = true;
            this.MostrarTodos_CB.Location = new System.Drawing.Point(588, 49);
            this.MostrarTodos_CB.Name = "MostrarTodos_CB";
            this.MostrarTodos_CB.Size = new System.Drawing.Size(95, 17);
            this.MostrarTodos_CB.TabIndex = 3;
            this.MostrarTodos_CB.Text = "Mostrar Todos";
            this.MostrarTodos_CB.UseVisualStyleBackColor = true;
            this.MostrarTodos_CB.CheckedChanged += new System.EventHandler(this.MostrarTodos_CB_CheckedChanged);
            // 
            // Anterior_BT
            // 
            this.Anterior_BT.Image = global::moleQule.Face.Instruction.Properties.Resources.Izquierda;
            this.Anterior_BT.Location = new System.Drawing.Point(3, 3);
            this.Anterior_BT.Name = "Anterior_BT";
            this.Anterior_BT.Size = new System.Drawing.Size(75, 65);
            this.Anterior_BT.TabIndex = 2;
            this.Anterior_BT.UseVisualStyleBackColor = true;
            this.Anterior_BT.Click += new System.EventHandler(this.Anterior_BT_Click);
            // 
            // Siguiente_BT
            // 
            this.Siguiente_BT.Image = global::moleQule.Face.Instruction.Properties.Resources.Derecha;
            this.Siguiente_BT.Location = new System.Drawing.Point(689, 3);
            this.Siguiente_BT.Name = "Siguiente_BT";
            this.Siguiente_BT.Size = new System.Drawing.Size(75, 65);
            this.Siguiente_BT.TabIndex = 1;
            this.Siguiente_BT.UseVisualStyleBackColor = true;
            this.Siguiente_BT.Click += new System.EventHandler(this.Siguiente_BT_Click);
            // 
            // Fecha_DTP
            // 
            this.Fecha_DTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Fecha_DTP.Location = new System.Drawing.Point(298, 23);
            this.Fecha_DTP.Name = "Fecha_DTP";
            this.Fecha_DTP.Size = new System.Drawing.Size(97, 21);
            this.Fecha_DTP.TabIndex = 0;
            this.Fecha_DTP.ValueChanged += new System.EventHandler(this.Fecha_DTP_ValueChanged);
            // 
            // Disponibilidades_Grid
            // 
            this.Disponibilidades_Grid.AllowUserToAddRows = false;
            this.Disponibilidades_Grid.AllowUserToDeleteRows = false;
            this.Disponibilidades_Grid.AllowUserToOrderColumns = true;
            this.Disponibilidades_Grid.AutoGenerateColumns = false;
            this.Disponibilidades_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Disponibilidades_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Apellidos,
            this.Lunes,
            this.Martes,
            this.Miercoles,
            this.Jueves,
            this.Viernes,
            this.Sabado});
            this.Disponibilidades_Grid.DataSource = this.Datos;
            this.Disponibilidades_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Disponibilidades_Grid.Location = new System.Drawing.Point(0, 0);
            this.Disponibilidades_Grid.MultiSelect = false;
            this.Disponibilidades_Grid.Name = "Disponibilidades_Grid";
            this.Disponibilidades_Grid.ReadOnly = true;
            this.Disponibilidades_Grid.RowTemplate.Height = 18;
            this.Disponibilidades_Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Disponibilidades_Grid.Size = new System.Drawing.Size(767, 479);
            this.Disponibilidades_Grid.TabIndex = 0;
            this.Disponibilidades_Grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Disponibilidades_Grid_CellContentDoubleClick);
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Apellidos
            // 
            this.Apellidos.DataPropertyName = "Apellidos";
            this.Apellidos.HeaderText = "Apellidos";
            this.Apellidos.Name = "Apellidos";
            this.Apellidos.ReadOnly = true;
            // 
            // Lunes
            // 
            this.Lunes.DataPropertyName = "Lunes";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Lunes.DefaultCellStyle = dataGridViewCellStyle1;
            this.Lunes.HeaderText = "L";
            this.Lunes.Name = "Lunes";
            this.Lunes.ReadOnly = true;
            this.Lunes.Width = 50;
            // 
            // Martes
            // 
            this.Martes.DataPropertyName = "Martes";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Martes.DefaultCellStyle = dataGridViewCellStyle2;
            this.Martes.HeaderText = "M";
            this.Martes.Name = "Martes";
            this.Martes.ReadOnly = true;
            this.Martes.Width = 50;
            // 
            // Miercoles
            // 
            this.Miercoles.DataPropertyName = "Miercoles";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Miercoles.DefaultCellStyle = dataGridViewCellStyle3;
            this.Miercoles.HeaderText = "X";
            this.Miercoles.Name = "Miercoles";
            this.Miercoles.ReadOnly = true;
            this.Miercoles.Width = 50;
            // 
            // Jueves
            // 
            this.Jueves.DataPropertyName = "Jueves";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Jueves.DefaultCellStyle = dataGridViewCellStyle4;
            this.Jueves.HeaderText = "J";
            this.Jueves.Name = "Jueves";
            this.Jueves.ReadOnly = true;
            this.Jueves.Width = 50;
            // 
            // Viernes
            // 
            this.Viernes.DataPropertyName = "Viernes";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Viernes.DefaultCellStyle = dataGridViewCellStyle5;
            this.Viernes.HeaderText = "V";
            this.Viernes.Name = "Viernes";
            this.Viernes.ReadOnly = true;
            this.Viernes.Width = 50;
            // 
            // Sabado
            // 
            this.Sabado.DataPropertyName = "Sabado";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Sabado.DefaultCellStyle = dataGridViewCellStyle6;
            this.Sabado.HeaderText = "S";
            this.Sabado.Name = "Sabado";
            this.Sabado.ReadOnly = true;
            this.Sabado.Width = 50;
            // 
            // DisponibilidadSemanalForm
            // 
            this.ClientSize = new System.Drawing.Size(769, 609);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DisponibilidadSemanalForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "Disponibilidad Semanal de Instructores";
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
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Disponibilidades_Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView Disponibilidades_Grid;
        private System.Windows.Forms.DateTimePicker Fecha_DTP;
        private System.Windows.Forms.Button Siguiente_BT;
        private System.Windows.Forms.Button Anterior_BT;
        private System.Windows.Forms.DateTimePicker FechaFin_DTP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox MostrarTodos_CB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lunes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Martes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Miercoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jueves;
        private System.Windows.Forms.DataGridViewTextBoxColumn Viernes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sabado;
    }
}
