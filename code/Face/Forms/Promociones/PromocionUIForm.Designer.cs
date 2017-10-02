namespace moleQule.Face.Instruction
{
    partial class PromocionUIForm
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
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Alumnos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Sesiones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Horas)).BeginInit();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            this.Paneles2.Panel1.SuspendLayout();
            this.Paneles2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            this.ProgressBK_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).BeginInit();
            this.SuspendLayout();
            // 
            // PlanEstudios_CB
            // 
            this.PlanEstudios_CB.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.PlanEstudios_CB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.PlanEstudios_CB.ValueMember = "Oid";
            this.PlanEstudios_CB.SelectedIndexChanged += new System.EventHandler(this.PlanEstudios_CB_SelectedIndexChanged);
            this.PlanEstudios_CB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PlanEstudios_CB_KeyDown);
            // 
            // Clases_BT
            // 
            this.Clases_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Clases_BT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // CLB_1
            // 
            this.CLB_1.CheckOnClick = false;
            this.CLB_1.SelectedIndexChanged += new System.EventHandler(this.CLB_1_SelectedIndexChanged);
            // 
            // CLB_2
            // 
            this.CLB_2.SelectedIndexChanged += new System.EventHandler(this.CLB_2_SelectedIndexChanged);
            // 
            // CLB_3
            // 
            this.CLB_3.SelectedIndexChanged += new System.EventHandler(this.CLB_3_SelectedIndexChanged);
            // 
            // PlanExtra_CB
            // 
            this.PlanExtra_CB.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.PlanExtra_CB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.PlanExtra_CB.ValueMember = "Oid";
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
            // 
            // Submit_BT
            // 
            this.Submit_BT.Location = new System.Drawing.Point(241, 7);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Location = new System.Drawing.Point(331, 7);
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
            // 
            // Imprimir_Button
            // 
            this.Imprimir_Button.Location = new System.Drawing.Point(151, 7);
            this.HelpProvider.SetShowHelp(this.Imprimir_Button, true);
            // 
            // Docs_BT
            // 
            this.Docs_BT.Location = new System.Drawing.Point(290, 7);
            this.HelpProvider.SetShowHelp(this.Docs_BT, true);
            // 
            // PromocionUIForm
            // 
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "PromocionUIForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "PromocionUIForm";
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Alumnos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Sesiones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Horas)).EndInit();
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            this.Paneles2.Panel1.ResumeLayout(false);
            this.Paneles2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            this.ProgressBK_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
