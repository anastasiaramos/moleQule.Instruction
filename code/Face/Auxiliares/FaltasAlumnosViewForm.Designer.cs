namespace molApp.Face.Modules.Instruction
{
    partial class FaltasAlumnosViewForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Alumnos_Grid = new System.Windows.Forms.DataGridView();
            this.Promocion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NExpediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalClases = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Porcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            this.Paneles2.Panel1.SuspendLayout();
            this.Paneles2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Alumnos_Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.Controls.Add(this.Alumnos_Grid);
            this.PanelesV.Size = new System.Drawing.Size(1157, 611);
            this.PanelesV.SplitterDistance = 570;
            // 
            // Guardar_Button
            // 
            this.Guardar_Button.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Guardar_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Guardar_Button.Location = new System.Drawing.Point(252, 6);
            // 
            // Cancelar_Button
            // 
            this.Cancelar_Button.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Cancelar_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Cancelar_Button.Location = new System.Drawing.Point(348, 6);
            // 
            // Paneles2
            // 
            this.Paneles2.Size = new System.Drawing.Size(1155, 38);
            this.Paneles2.SplitterDistance = 37;
            // 
            // Imprimir_Button
            // 
            this.Imprimir_Button.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Imprimir_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Imprimir_Button.Location = new System.Drawing.Point(156, 6);
            // 
            // Datos
            // 
            this.Datos.DataSource = typeof(molApp.Library.Modules.Quality.FaltaAlumnoInfo);
            // 
            // Alumnos_Grid
            // 
            this.Alumnos_Grid.AutoGenerateColumns = false;
            this.Alumnos_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize; 
            this.Alumnos_Grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Alumnos_Grid_DataBindingComplete);
            this.Alumnos_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Promocion,
            this.NExpediente,
            this.Codigo,
            this.Nombre,
            this.Apellidos,
            this.Modulo,
            this.Duracion,
            this.TotalClases,
            this.Porcentaje});
            this.Alumnos_Grid.DataSource = this.Datos;
            this.Alumnos_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Alumnos_Grid.Location = new System.Drawing.Point(0, 0);
            this.Alumnos_Grid.Name = "Alumnos_Grid";
            this.Alumnos_Grid.Size = new System.Drawing.Size(1155, 568);
            this.Alumnos_Grid.TabIndex = 4;
            // 
            // Promocion
            // 
            this.Promocion.DataPropertyName = "Promocion";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Promocion.DefaultCellStyle = dataGridViewCellStyle1;
            this.Promocion.HeaderText = "Promoción";
            this.Promocion.Name = "Promocion";
            // 
            // NExpediente
            // 
            this.NExpediente.DataPropertyName = "NExpediente";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NExpediente.DefaultCellStyle = dataGridViewCellStyle2;
            this.NExpediente.HeaderText = "Nº Expediente";
            this.NExpediente.Name = "NExpediente";
            this.NExpediente.Width = 80;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle3;
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 80;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 200;
            // 
            // Apellidos
            // 
            this.Apellidos.DataPropertyName = "Apellidos";
            this.Apellidos.HeaderText = "Apellidos";
            this.Apellidos.Name = "Apellidos";
            this.Apellidos.Width = 300;
            // 
            // Modulo
            // 
            this.Modulo.DataPropertyName = "Modulo";
            this.Modulo.HeaderText = "Módulo";
            this.Modulo.Name = "Modulo";
            this.Modulo.Width = 300;
            // 
            // Duracion
            // 
            this.Duracion.DataPropertyName = "Duracion";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Duracion.DefaultCellStyle = dataGridViewCellStyle4;
            this.Duracion.HeaderText = "Faltas";
            this.Duracion.Name = "Duracion";
            this.Duracion.Width = 80;
            // 
            // TotalClases
            // 
            this.TotalClases.DataPropertyName = "TotalClases";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TotalClases.DefaultCellStyle = dataGridViewCellStyle5;
            this.TotalClases.HeaderText = "Total Clases";
            this.TotalClases.Name = "TotalClases";
            this.TotalClases.Width = 80;
            // 
            // Porcentaje
            // 
            this.Porcentaje.DataPropertyName = "Porcentaje";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.Porcentaje.DefaultCellStyle = dataGridViewCellStyle6;
            this.Porcentaje.HeaderText = "Porcentaje";
            this.Porcentaje.Name = "Porcentaje";
            this.Porcentaje.Width = 80;
            // 
            // FaltasAlumnosViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(1157, 611);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "FaltasAlumnosViewForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "Faltas de Alumnos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FaltasAlumnosViewForm_FormClosing);
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            this.Paneles2.Panel1.ResumeLayout(false);
            this.Paneles2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Alumnos_Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Alumnos_Grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Promocion;
        private System.Windows.Forms.DataGridViewTextBoxColumn NExpediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duracion;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalClases;
        private System.Windows.Forms.DataGridViewTextBoxColumn Porcentaje;
    }
}
