namespace moleQule.Face.Instruction
{
    partial class AlumnosAdmitidosExamenActionForm
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
            this.Modulo_BT = new System.Windows.Forms.Button();
            this.Modulo_TB = new System.Windows.Forms.TextBox();
            this.Promociones_CLB = new System.Windows.Forms.CheckedListBox();
            this.Promocion_BT = new System.Windows.Forms.Button();
            this.FechaExamen_DTP = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ClearPromociones_BT = new System.Windows.Forms.Button();
            this.Source_GB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelesV)).BeginInit();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMng_EP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).BeginInit();
            this.Progress_Panel.SuspendLayout();
            this.ProgressBK_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Progress_PB)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // Print_BT
            // 
            this.Print_BT.Enabled = true;
            this.Print_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ErrorMng_EP.SetIconAlignment(this.Print_BT, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.Print_BT.Location = new System.Drawing.Point(251, 2);
            this.HelpProvider.SetShowHelp(this.Print_BT, true);
            this.Print_BT.Visible = true;
            // 
            // Submit_BT
            // 
            this.Submit_BT.Enabled = false;
            this.Submit_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ErrorMng_EP.SetIconAlignment(this.Submit_BT, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.Submit_BT.Location = new System.Drawing.Point(136, 2);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            this.Submit_BT.Visible = false;
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ErrorMng_EP.SetIconAlignment(this.Cancel_BT, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.Cancel_BT.Location = new System.Drawing.Point(21, 2);
            this.HelpProvider.SetShowHelp(this.Cancel_BT, true);
            // 
            // Source_GB
            // 
            this.Source_GB.Controls.Add(this.groupBox6);
            this.Source_GB.Controls.Add(this.groupBox5);
            this.Source_GB.Controls.Add(this.groupBox2);
            this.Source_GB.Location = new System.Drawing.Point(11, 3);
            this.HelpProvider.SetShowHelp(this.Source_GB, true);
            this.Source_GB.Size = new System.Drawing.Size(572, 294);
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
            this.PanelesV.Size = new System.Drawing.Size(596, 347);
            this.PanelesV.SplitterDistance = 308;
            // 
            // Progress_Panel
            // 
            this.Progress_Panel.Location = new System.Drawing.Point(94, 24);
            // 
            // ProgressBK_Panel
            // 
            this.ProgressBK_Panel.Size = new System.Drawing.Size(596, 347);
            // 
            // ProgressInfo_PB
            // 
            this.ProgressInfo_PB.Location = new System.Drawing.Point(266, 225);
            // 
            // Progress_PB
            // 
            this.Progress_PB.Location = new System.Drawing.Point(266, 140);
            // 
            // Modulo_BT
            // 
            this.Modulo_BT.Image = global::moleQule.Face.Instruction.Properties.Resources.select_16;
            this.Modulo_BT.Location = new System.Drawing.Point(482, 18);
            this.Modulo_BT.Name = "Modulo_BT";
            this.Modulo_BT.Size = new System.Drawing.Size(46, 23);
            this.Modulo_BT.TabIndex = 1;
            this.Modulo_BT.UseVisualStyleBackColor = true;
            this.Modulo_BT.Click += new System.EventHandler(this.Modulo_BT_Click);
            // 
            // Modulo_TB
            // 
            this.Modulo_TB.Location = new System.Drawing.Point(16, 20);
            this.Modulo_TB.Name = "Modulo_TB";
            this.Modulo_TB.ReadOnly = true;
            this.Modulo_TB.Size = new System.Drawing.Size(460, 21);
            this.Modulo_TB.TabIndex = 2;
            // 
            // Promociones_CLB
            // 
            this.Promociones_CLB.FormattingEnabled = true;
            this.Promociones_CLB.Location = new System.Drawing.Point(12, 22);
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
            // FechaExamen_DTP
            // 
            this.FechaExamen_DTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaExamen_DTP.Location = new System.Drawing.Point(224, 20);
            this.FechaExamen_DTP.Name = "FechaExamen_DTP";
            this.FechaExamen_DTP.Size = new System.Drawing.Size(97, 21);
            this.FechaExamen_DTP.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Modulo_TB);
            this.groupBox2.Controls.Add(this.Modulo_BT);
            this.groupBox2.Location = new System.Drawing.Point(14, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(545, 73);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Módulo";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ClearPromociones_BT);
            this.groupBox5.Controls.Add(this.Promociones_CLB);
            this.groupBox5.Controls.Add(this.Promocion_BT);
            this.groupBox5.Location = new System.Drawing.Point(14, 102);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(545, 115);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Promociones";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.FechaExamen_DTP);
            this.groupBox6.Location = new System.Drawing.Point(14, 228);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(545, 52);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Fecha de Examen";
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
            // AlumnosAdmitidosExamenActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(596, 347);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "AlumnosAdmitidosExamenActionForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "Alumnos Admitidos a Examen";
            this.Source_GB.ResumeLayout(false);
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelesV)).EndInit();
            this.PanelesV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMng_EP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).EndInit();
            this.Progress_Panel.ResumeLayout(false);
            this.Progress_Panel.PerformLayout();
            this.ProgressBK_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Progress_PB)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Proveedor_GB;
        private System.Windows.Forms.CheckBox TodosProveedor_CkB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource Datos;
        private moleQule.Face.Controls.mQDateTimePicker FFinal_DTP;
        private System.Windows.Forms.Label label3;
        private moleQule.Face.Controls.mQDateTimePicker FInicial_DTP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox TodosProducto_CkB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource Datos_Productos;
        private System.Windows.Forms.TextBox Producto_TB;
        private System.Windows.Forms.Button Producto_BT;
        private System.Windows.Forms.TextBox Proveedor_TB;
        private System.Windows.Forms.Button Proveedor_BT;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton Producto_RB;
        private System.Windows.Forms.RadioButton Proveedor_RB;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox Serie_TB;
        private System.Windows.Forms.Button Serie_BT;
        private System.Windows.Forms.CheckBox TodosSerie_CkB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox Expediente_GB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox TipoExpediente_CB;
        private System.Windows.Forms.TextBox Expediente_TB;
        private System.Windows.Forms.Button Expediente_BT;
        private System.Windows.Forms.CheckBox TodosExpediente_CkB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource Datos_TiposExp;
        private System.Windows.Forms.Button Modulo_BT;
        private System.Windows.Forms.TextBox Modulo_TB;
        private System.Windows.Forms.Button Promocion_BT;
        private System.Windows.Forms.CheckedListBox Promociones_CLB;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DateTimePicker FechaExamen_DTP;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ClearPromociones_BT;
    }
}
