namespace moleQule.Face.Instruction
{
    partial class PlantillaSelectForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Tabla = new System.Windows.Forms.DataGridView();
            this.Titulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NPreguntas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Idioma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desarrollo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SC1.Panel1.SuspendLayout();
            this.SC1.Panel2.SuspendLayout();
            this.SC1.SuspendLayout();
            this.SC2.Panel1.SuspendLayout();
            this.SC2.Panel2.SuspendLayout();
            this.SC2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).BeginInit();
            this.SuspendLayout();
            // 
            // Select_Button
            // 
            this.Select_Button.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Select_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Select_Button.Location = new System.Drawing.Point(166, 5);
            this.Select_Button.Click += new System.EventHandler(this.Select_Button_Click);
            // 
            // SC1
            // 
            // 
            // SC1.Panel1
            // 
            this.SC1.Panel1.Controls.Add(this.label1);
            this.SC1.Panel1.Controls.Add(this.Titulo);
            // 
            // SC2
            // 
            // 
            // SC2.Panel1
            // 
            this.SC2.Panel1.Controls.Add(this.Tabla);
            // 
            // Datos
            // 
            this.Datos.DataSource = typeof(moleQule.Library.Instruction.PlantillaExamenInfo);
            // 
            // Tabla
            // 
            this.Tabla.AllowUserToAddRows = false;
            this.Tabla.AllowUserToDeleteRows = false;
            this.Tabla.AllowUserToOrderColumns = true;
            this.Tabla.AutoGenerateColumns = false;
            this.Tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Tabla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.NPreguntas,
            this.Idioma,
            this.Desarrollo});
            this.Tabla.DataSource = this.Datos;
            this.Tabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tabla.Location = new System.Drawing.Point(0, 0);
            this.Tabla.Name = "Tabla";
            this.Tabla.ReadOnly = true;
            this.Tabla.Size = new System.Drawing.Size(458, 217);
            this.Tabla.TabIndex = 0;
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Titulo.Location = new System.Drawing.Point(12, 53);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(57, 19);
            this.Titulo.TabIndex = 1;
            this.Titulo.Tag = "No Format";
            this.Titulo.Text = "Título";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(427, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 19);
            this.label1.TabIndex = 2;
            this.label1.Tag = "No Format";
            this.label1.Text = "|";
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // NPreguntas
            // 
            this.NPreguntas.DataPropertyName = "NPreguntas";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NPreguntas.DefaultCellStyle = dataGridViewCellStyle2;
            this.NPreguntas.HeaderText = "Nº Preguntas";
            this.NPreguntas.Name = "NPreguntas";
            this.NPreguntas.ReadOnly = true;
            // 
            // Idioma
            // 
            this.Idioma.DataPropertyName = "Idioma";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Idioma.DefaultCellStyle = dataGridViewCellStyle3;
            this.Idioma.HeaderText = "Idioma";
            this.Idioma.Name = "Idioma";
            this.Idioma.ReadOnly = true;
            // 
            // Desarrollo
            // 
            this.Desarrollo.DataPropertyName = "Desarrollo";
            this.Desarrollo.HeaderText = "Desarrollo";
            this.Desarrollo.Name = "Desarrollo";
            this.Desarrollo.ReadOnly = true;
            // 
            // PlantillaSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(458, 366);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "PlantillaSelectForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.SC1.Panel1.ResumeLayout(false);
            this.SC1.Panel1.PerformLayout();
            this.SC1.Panel2.ResumeLayout(false);
            this.SC1.ResumeLayout(false);
            this.SC2.Panel1.ResumeLayout(false);
            this.SC2.Panel2.ResumeLayout(false);
            this.SC2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Tabla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NPreguntas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Idioma;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Desarrollo;
    }
}
