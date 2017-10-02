namespace moleQule.Face.Instruction
{
    partial class PlantillasMngForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlantillasMngForm));
            this.Modulo_TP = new System.Windows.Forms.TabPage();
            this.Tabla = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Idioma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desarrollo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NPreguntas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelesH.Panel2.SuspendLayout();
            this.PanelesH.SuspendLayout();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            this.Filtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelesH
            // 
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel2
            // 
            this.PanelesV.Panel2.Controls.Add(this.Tabla);
            // 
            // Filtros
            // 
            this.Filtros.Controls.Add(this.Modulo_TP);
            this.Filtros.Location = new System.Drawing.Point(549, 3);
            this.Filtros.Size = new System.Drawing.Size(183, 25);
            this.Filtros.Controls.SetChildIndex(this.Modulo_TP, 0);
            this.Filtros.Controls.SetChildIndex(this.Advanced_TP, 0);
            this.Filtros.Controls.SetChildIndex(this.Todos_TP, 0);
            // 
            // Todos_TP
            // 
            this.Todos_TP.Size = new System.Drawing.Size(175, 0);
            // 
            // Advanced_TP
            // 
            this.Advanced_TP.Size = new System.Drawing.Size(175, -1);
            // 
            // Datos
            // 
            this.Datos.DataSource = typeof(moleQule.Library.Instruction.PlantillaExamenInfo);
            // 
            // Modulo_TP
            // 
            this.Modulo_TP.Location = new System.Drawing.Point(4, 22);
            this.Modulo_TP.Name = "Modulo_TP";
            this.Modulo_TP.Padding = new System.Windows.Forms.Padding(3);
            this.Modulo_TP.Size = new System.Drawing.Size(175, 0);
            this.Modulo_TP.TabIndex = 6;
            this.Modulo_TP.Text = "Módulo";
            this.Modulo_TP.UseVisualStyleBackColor = true;
            // 
            // Tabla
            // 
            this.Tabla.AllowUserToAddRows = false;
            this.Tabla.AllowUserToDeleteRows = false;
            this.Tabla.AllowUserToOrderColumns = true;
            this.Tabla.AutoGenerateColumns = false;
            this.Tabla.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Tabla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Tabla.ColumnHeadersHeight = 34;
            this.Tabla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Modulo,
            this.Idioma,
            this.Desarrollo,
            this.NPreguntas});
            this.Tabla.DataSource = this.Datos;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Tabla.DefaultCellStyle = dataGridViewCellStyle7;
            this.Tabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tabla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.Tabla.Location = new System.Drawing.Point(0, 0);
            this.Tabla.Name = "Tabla";
            this.Tabla.ReadOnly = true;
            this.Tabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Tabla.Size = new System.Drawing.Size(1282, 536);
            this.Tabla.TabIndex = 0;
            this.Tabla.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Tabla_DataBindingComplete);
            this.Tabla.DoubleClick += new System.EventHandler(this.Tabla_DoubleClick);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle2;
            this.Codigo.HeaderText = "Número";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Modulo
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.Modulo.DefaultCellStyle = dataGridViewCellStyle3;
            this.Modulo.HeaderText = "Módulo";
            this.Modulo.Name = "Modulo";
            this.Modulo.ReadOnly = true;
            // 
            // Idioma
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.Idioma.DefaultCellStyle = dataGridViewCellStyle4;
            this.Idioma.HeaderText = "Idioma";
            this.Idioma.Name = "Idioma";
            this.Idioma.ReadOnly = true;
            // 
            // Desarrollo
            // 
            this.Desarrollo.DataPropertyName = "Desarrollo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.NullValue = false;
            this.Desarrollo.DefaultCellStyle = dataGridViewCellStyle5;
            this.Desarrollo.HeaderText = "Desarrollo";
            this.Desarrollo.Name = "Desarrollo";
            this.Desarrollo.ReadOnly = true;
            // 
            // NPreguntas
            // 
            this.NPreguntas.DataPropertyName = "NPreguntas";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.NPreguntas.DefaultCellStyle = dataGridViewCellStyle6;
            this.NPreguntas.HeaderText = "Nº Preguntas";
            this.NPreguntas.Name = "NPreguntas";
            this.NPreguntas.ReadOnly = true;
            // 
            // PlantillasMngForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(1284, 605);
            this.HelpProvider.SetHelpKeyword(this, "30");
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PlantillasMngForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "PlantillasMngForm";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PlantillasMngForm_KeyPress);
            this.Controls.SetChildIndex(this.PanelesH, 0);
            this.PanelesH.Panel2.ResumeLayout(false);
            this.PanelesH.ResumeLayout(false);
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            this.Filtros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage Modulo_TP;
        private System.Windows.Forms.DataGridView Tabla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Idioma;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Desarrollo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NPreguntas;
    }
}
