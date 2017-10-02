namespace moleQule.Face.Instruction
{
    partial class PlantillaLocalizeForm
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
            this.Modulo_CB = new System.Windows.Forms.ComboBox();
            this.Datos_Modulos = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Idioma_CB = new System.Windows.Forms.ComboBox();
            this.Datos_Idiomas = new System.Windows.Forms.BindingSource(this.components);
            this.Desarrollo_CB = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Filtro_CB = new System.Windows.Forms.CheckBox();
            this.Filtros_GB = new System.Windows.Forms.GroupBox();
            this.Campos_Panel.SuspendLayout();
            this.Campos_Groupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Modulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Idiomas)).BeginInit();
            this.SuspendLayout();
            // 
            // Campos_Groupbox
            // 
            this.Campos_Groupbox.Controls.Add(this.Filtro_CB);
            this.Campos_Groupbox.Controls.Add(this.label4);
            this.Campos_Groupbox.Controls.Add(this.Desarrollo_CB);
            this.Campos_Groupbox.Controls.Add(this.label2);
            this.Campos_Groupbox.Controls.Add(this.Idioma_CB);
            this.Campos_Groupbox.Controls.Add(this.label1);
            this.Campos_Groupbox.Controls.Add(this.Modulo_CB);
            this.Campos_Groupbox.Controls.Add(this.Filtros_GB);
            // 
            // Valor_TB
            // 
            this.Valor_TB.Tag = "No Format";
            this.Valor_TB.Visible = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.Tag = "No Format";
            this.label3.Visible = false;
            // 
            // Buscar_Button
            // 
            this.Buscar_Button.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Buscar_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Buscar_Button.Location = new System.Drawing.Point(787, 62);
            // 
            // Filtrar_Button
            // 
            this.Filtrar_Button.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Filtrar_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Filtrar_Button.Location = new System.Drawing.Point(787, 91);
            // 
            // Datos
            // 
            this.Datos.DataSource = typeof(moleQule.Library.Instruction.PlantillaExamen);
            // 
            // Modulo_CB
            // 
            this.Modulo_CB.DataSource = this.Datos_Modulos;
            this.Modulo_CB.DisplayMember = "Texto";
            this.Modulo_CB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Modulo_CB.FormattingEnabled = true;
            this.Modulo_CB.Location = new System.Drawing.Point(109, 44);
            this.Modulo_CB.Name = "Modulo_CB";
            this.Modulo_CB.Size = new System.Drawing.Size(249, 21);
            this.Modulo_CB.TabIndex = 0;
            this.Modulo_CB.ValueMember = "Oid";
            // 
            // Datos_Modulos
            // 
            this.Datos_Modulos.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(46, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Módulo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(46, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Idioma: ";
            // 
            // Idioma_CB
            // 
            this.Idioma_CB.DataSource = this.Datos_Idiomas;
            this.Idioma_CB.DisplayMember = "Texto";
            this.Idioma_CB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Idioma_CB.FormattingEnabled = true;
            this.Idioma_CB.Location = new System.Drawing.Point(109, 82);
            this.Idioma_CB.Name = "Idioma_CB";
            this.Idioma_CB.Size = new System.Drawing.Size(249, 21);
            this.Idioma_CB.TabIndex = 2;
            this.Idioma_CB.ValueMember = "Oid";
            // 
            // Datos_Idiomas
            // 
            this.Datos_Idiomas.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // Desarrollo_CB
            // 
            this.Desarrollo_CB.AutoSize = true;
            this.Desarrollo_CB.Location = new System.Drawing.Point(565, 57);
            this.Desarrollo_CB.Name = "Desarrollo_CB";
            this.Desarrollo_CB.Size = new System.Drawing.Size(15, 14);
            this.Desarrollo_CB.TabIndex = 4;
            this.Desarrollo_CB.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(491, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Desarrollo:";
            // 
            // Filtro_CB
            // 
            this.Filtro_CB.AutoSize = true;
            this.Filtro_CB.Location = new System.Drawing.Point(469, 105);
            this.Filtro_CB.Name = "Filtro_CB";
            this.Filtro_CB.Size = new System.Drawing.Size(104, 18);
            this.Filtro_CB.TabIndex = 6;
            this.Filtro_CB.Text = "Activar Filtro";
            this.Filtro_CB.UseVisualStyleBackColor = true;
            this.Filtro_CB.CheckedChanged += new System.EventHandler(this.Filtro_CB_CheckedChanged);
            // 
            // Filtros_GB
            // 
            this.Filtros_GB.Enabled = false;
            this.Filtros_GB.Location = new System.Drawing.Point(436, 22);
            this.Filtros_GB.Name = "Filtros_GB";
            this.Filtros_GB.Size = new System.Drawing.Size(200, 63);
            this.Filtros_GB.TabIndex = 7;
            this.Filtros_GB.TabStop = false;
            this.Filtros_GB.Text = "Filtro";
            // 
            // PlantillaLocalizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1014, 203);
            this.HelpProvider.SetHelpKeyword(this, "40");
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "PlantillaLocalizeForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Campos_Panel.ResumeLayout(false);
            this.Campos_Groupbox.ResumeLayout(false);
            this.Campos_Groupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Modulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Idiomas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Idioma_CB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Modulo_CB;
        private System.Windows.Forms.CheckBox Desarrollo_CB;
        private System.Windows.Forms.CheckBox Filtro_CB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox Filtros_GB;
        private System.Windows.Forms.BindingSource Datos_Modulos;
        private System.Windows.Forms.BindingSource Datos_Idiomas;
    }
}
