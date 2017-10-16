namespace moleQule.Face.Instruction
{
    partial class FestivoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FestivoForm));
            this.FInicio_DTP = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FFin_DTP = new System.Windows.Forms.DateTimePicker();
            this.Anual_CB = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Intervalo_CB = new System.Windows.Forms.CheckBox();
            this.Titulo_TB = new System.Windows.Forms.TextBox();
            this.Tipo_TB = new System.Windows.Forms.TextBox();
            this.Tipo_BT = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Descripcion_TB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PanelesV)).BeginInit();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pie_Panel)).BeginInit();
            this.Pie_Panel.Panel1.SuspendLayout();
            this.Pie_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Content_Panel)).BeginInit();
            this.Content_Panel.Panel2.SuspendLayout();
            this.Content_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMng_EP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).BeginInit();
            this.Progress_Panel.SuspendLayout();
            this.ProgressBK_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Progress_PB)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
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
            this.PanelesV.Size = new System.Drawing.Size(437, 433);
            this.PanelesV.SplitterDistance = 393;
            // 
            // Submit_BT
            // 
            this.Submit_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Submit_BT.Location = new System.Drawing.Point(297, 2);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Cancel_BT.Location = new System.Drawing.Point(164, 2);
            this.HelpProvider.SetShowHelp(this.Cancel_BT, true);
            // 
            // Pie_Panel
            // 
            // 
            // Pie_Panel.Panel1
            // 
            this.HelpProvider.SetShowHelp(this.Pie_Panel.Panel1, true);
            // 
            // Pie_Panel.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.Pie_Panel.Panel2, true);
            this.HelpProvider.SetShowHelp(this.Pie_Panel, true);
            this.Pie_Panel.Size = new System.Drawing.Size(435, 37);
            // 
            // Content_Panel
            // 
            // 
            // Content_Panel.Panel1
            // 
            this.HelpProvider.SetShowHelp(this.Content_Panel.Panel1, true);
            // 
            // Content_Panel.Panel2
            // 
            this.Content_Panel.Panel2.Controls.Add(this.groupBox3);
            this.Content_Panel.Panel2.Controls.Add(this.groupBox2);
            this.Content_Panel.Panel2.Controls.Add(this.groupBox1);
            this.HelpProvider.SetShowHelp(this.Content_Panel.Panel2, true);
            this.HelpProvider.SetShowHelp(this.Content_Panel, true);
            this.Content_Panel.Size = new System.Drawing.Size(435, 391);
            // 
            // Datos
            // 
            this.Datos.DataSource = typeof(moleQule.Library.Instruction.Festivo);
            // 
            // Progress_Panel
            // 
            this.Progress_Panel.Location = new System.Drawing.Point(39, 102);
            // 
            // ProgressBK_Panel
            // 
            this.ProgressBK_Panel.Size = new System.Drawing.Size(437, 433);
            // 
            // ProgressInfo_PB
            // 
            this.ProgressInfo_PB.Location = new System.Drawing.Point(181, 265);
            // 
            // Progress_PB
            // 
            this.Progress_PB.Location = new System.Drawing.Point(181, 180);
            // 
            // FInicio_DTP
            // 
            this.FInicio_DTP.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.Datos, "FechaInicio", true));
            this.FInicio_DTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FInicio_DTP.Location = new System.Drawing.Point(99, 20);
            this.FInicio_DTP.Name = "FInicio_DTP";
            this.FInicio_DTP.Size = new System.Drawing.Size(102, 21);
            this.FInicio_DTP.TabIndex = 0;
            this.FInicio_DTP.ValueChanged += new System.EventHandler(this.FInicio_DTP_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha Inicio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha Fin:";
            // 
            // FFin_DTP
            // 
            this.FFin_DTP.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.Datos, "FechaFin", true));
            this.FFin_DTP.Enabled = false;
            this.FFin_DTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FFin_DTP.Location = new System.Drawing.Point(99, 51);
            this.FFin_DTP.Name = "FFin_DTP";
            this.FFin_DTP.Size = new System.Drawing.Size(102, 21);
            this.FFin_DTP.TabIndex = 2;
            // 
            // Anual_CB
            // 
            this.Anual_CB.AutoSize = true;
            this.Anual_CB.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.Datos, "Anual", true));
            this.Anual_CB.Location = new System.Drawing.Point(258, 25);
            this.Anual_CB.Name = "Anual_CB";
            this.Anual_CB.Size = new System.Drawing.Size(133, 17);
            this.Anual_CB.TabIndex = 4;
            this.Anual_CB.Text = "Repetir todos los años";
            this.Anual_CB.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Intervalo_CB);
            this.groupBox1.Controls.Add(this.FInicio_DTP);
            this.groupBox1.Controls.Add(this.Anual_CB);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.FFin_DTP);
            this.groupBox1.Location = new System.Drawing.Point(9, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 88);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // Intervalo_CB
            // 
            this.Intervalo_CB.AutoSize = true;
            this.Intervalo_CB.Location = new System.Drawing.Point(258, 53);
            this.Intervalo_CB.Name = "Intervalo_CB";
            this.Intervalo_CB.Size = new System.Drawing.Size(70, 17);
            this.Intervalo_CB.TabIndex = 5;
            this.Intervalo_CB.Text = "Intervalo";
            this.Intervalo_CB.UseVisualStyleBackColor = true;
            this.Intervalo_CB.CheckedChanged += new System.EventHandler(this.Intervalo_CB_CheckedChanged);
            // 
            // Titulo_TB
            // 
            this.Titulo_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Titulo", true));
            this.Titulo_TB.Location = new System.Drawing.Point(22, 24);
            this.Titulo_TB.Name = "Titulo_TB";
            this.Titulo_TB.Size = new System.Drawing.Size(371, 21);
            this.Titulo_TB.TabIndex = 6;
            // 
            // Tipo_TB
            // 
            this.Tipo_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "TipoLabel", true));
            this.Tipo_TB.Location = new System.Drawing.Point(22, 60);
            this.Tipo_TB.Name = "Tipo_TB";
            this.Tipo_TB.ReadOnly = true;
            this.Tipo_TB.Size = new System.Drawing.Size(316, 21);
            this.Tipo_TB.TabIndex = 7;
            // 
            // Tipo_BT
            // 
            this.Tipo_BT.Image = global::moleQule.Face.Instruction.Properties.Resources.select_16;
            this.Tipo_BT.Location = new System.Drawing.Point(344, 58);
            this.Tipo_BT.Name = "Tipo_BT";
            this.Tipo_BT.Size = new System.Drawing.Size(49, 23);
            this.Tipo_BT.TabIndex = 8;
            this.Tipo_BT.UseVisualStyleBackColor = true;
            this.Tipo_BT.Click += new System.EventHandler(this.Tipo_BT_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Tipo_TB);
            this.groupBox2.Controls.Add(this.Tipo_BT);
            this.groupBox2.Controls.Add(this.Titulo_TB);
            this.groupBox2.Location = new System.Drawing.Point(9, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(414, 100);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Día No Lectivo";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Descripcion_TB);
            this.groupBox3.Location = new System.Drawing.Point(9, 207);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(414, 140);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Descripción";
            // 
            // Descripcion_TB
            // 
            this.Descripcion_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Descripcion", true));
            this.Descripcion_TB.Location = new System.Drawing.Point(22, 23);
            this.Descripcion_TB.Multiline = true;
            this.Descripcion_TB.Name = "Descripcion_TB";
            this.Descripcion_TB.Size = new System.Drawing.Size(371, 104);
            this.Descripcion_TB.TabIndex = 0;
            // 
            // FestivoForm
            // 
            this.ClientSize = new System.Drawing.Size(437, 433);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FestivoForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "FestivoForm";
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelesV)).EndInit();
            this.PanelesV.ResumeLayout(false);
            this.Pie_Panel.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Pie_Panel)).EndInit();
            this.Pie_Panel.ResumeLayout(false);
            this.Content_Panel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Content_Panel)).EndInit();
            this.Content_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMng_EP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).EndInit();
            this.Progress_Panel.ResumeLayout(false);
            this.Progress_Panel.PerformLayout();
            this.ProgressBK_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Progress_PB)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Tipo_BT;
        private System.Windows.Forms.TextBox Titulo_TB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker FInicio_DTP;
        private System.Windows.Forms.CheckBox Anual_CB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker FFin_DTP;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox Descripcion_TB;
        private System.Windows.Forms.GroupBox groupBox2;
        protected System.Windows.Forms.TextBox Tipo_TB;
        protected System.Windows.Forms.CheckBox Intervalo_CB;
    }
}
