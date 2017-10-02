namespace moleQule.Face.Instruction
{
    partial class AlumnosSelectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlumnosSelectForm));
            this.Panel1 = new System.Windows.Forms.SplitContainer();
            this.SC2 = new System.Windows.Forms.SplitContainer();
            this.BarraDerecha = new System.Windows.Forms.Label();
            this.Titulo = new System.Windows.Forms.Label();
            this.Cerrar_BT = new System.Windows.Forms.Button();
            this.Imprimir_BT = new System.Windows.Forms.Button();
            this.Filtrar_BT = new System.Windows.Forms.Button();
            this.Submodulo = new System.Windows.Forms.GroupBox();
            this.Promocion_CB = new System.Windows.Forms.ComboBox();
            this.Datos_Promociones = new System.Windows.Forms.BindingSource(this.components);
            this.SC1 = new System.Windows.Forms.SplitContainer();
            this.Arbol_TV = new System.Windows.Forms.TreeView();
            this.Submit_BT = new System.Windows.Forms.Button();
            this.Iconos_IL = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            this.Panel1.Panel1.SuspendLayout();
            this.Panel1.Panel2.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.SC2.Panel1.SuspendLayout();
            this.SC2.Panel2.SuspendLayout();
            this.SC2.SuspendLayout();
            this.Submodulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Promociones)).BeginInit();
            this.SC1.Panel1.SuspendLayout();
            this.SC1.Panel2.SuspendLayout();
            this.SC1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Datos
            // 
            this.Datos.DataSource = typeof(moleQule.Library.Instruction.Alumno_Examen);
            // 
            // Panel1
            // 
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Panel1.Panel1
            // 
            this.Panel1.Panel1.Controls.Add(this.SC2);
            // 
            // Panel1.Panel2
            // 
            this.Panel1.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Panel1.Panel2.Controls.Add(this.SC1);
            this.Panel1.Size = new System.Drawing.Size(978, 460);
            this.Panel1.SplitterDistance = 124;
            this.Panel1.TabIndex = 0;
            // 
            // SC2
            // 
            this.SC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SC2.IsSplitterFixed = true;
            this.SC2.Location = new System.Drawing.Point(0, 0);
            this.SC2.Name = "SC2";
            this.SC2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SC2.Panel1
            // 
            this.SC2.Panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.SC2.Panel1.Controls.Add(this.BarraDerecha);
            this.SC2.Panel1.Controls.Add(this.Titulo);
            this.SC2.Panel1.Controls.Add(this.Cerrar_BT);
            // 
            // SC2.Panel2
            // 
            this.SC2.Panel2.Controls.Add(this.Imprimir_BT);
            this.SC2.Panel2.Controls.Add(this.Filtrar_BT);
            this.SC2.Panel2.Controls.Add(this.Submodulo);
            this.SC2.Size = new System.Drawing.Size(978, 124);
            this.SC2.SplitterDistance = 49;
            this.SC2.TabIndex = 0;
            // 
            // BarraDerecha
            // 
            this.BarraDerecha.AutoSize = true;
            this.BarraDerecha.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarraDerecha.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BarraDerecha.Location = new System.Drawing.Point(647, 14);
            this.BarraDerecha.Name = "BarraDerecha";
            this.BarraDerecha.Size = new System.Drawing.Size(19, 19);
            this.BarraDerecha.TabIndex = 3;
            this.BarraDerecha.Tag = "No Format";
            this.BarraDerecha.Text = "|";
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Titulo.Location = new System.Drawing.Point(127, 14);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(215, 19);
            this.Titulo.TabIndex = 2;
            this.Titulo.Tag = "No Format";
            this.Titulo.Text = "|    Selección de Alumnos";
            // 
            // Cerrar_BT
            // 
            this.Cerrar_BT.Image = global::moleQule.Face.Instruction.Properties.Resources.Cerrar;
            this.Cerrar_BT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cerrar_BT.Location = new System.Drawing.Point(5, 5);
            this.Cerrar_BT.Name = "Cerrar_BT";
            this.Cerrar_BT.Size = new System.Drawing.Size(116, 36);
            this.Cerrar_BT.TabIndex = 0;
            this.Cerrar_BT.Text = "Cerrar";
            this.Cerrar_BT.UseVisualStyleBackColor = true;
            this.Cerrar_BT.Click += new System.EventHandler(this.Cerrar_BT_Click);
            // 
            // Imprimir_BT
            // 
            this.Imprimir_BT.Location = new System.Drawing.Point(516, 24);
            this.Imprimir_BT.Name = "Imprimir_BT";
            this.Imprimir_BT.Size = new System.Drawing.Size(267, 23);
            this.Imprimir_BT.TabIndex = 10;
            this.Imprimir_BT.Text = "Imprimir Control de Asistencia";
            this.Imprimir_BT.UseVisualStyleBackColor = true;
            this.Imprimir_BT.Click += new System.EventHandler(this.Imprimir_BT_Click);
            // 
            // Filtrar_BT
            // 
            this.Filtrar_BT.Location = new System.Drawing.Point(425, 24);
            this.Filtrar_BT.Name = "Filtrar_BT";
            this.Filtrar_BT.Size = new System.Drawing.Size(75, 23);
            this.Filtrar_BT.TabIndex = 9;
            this.Filtrar_BT.Text = "Filtrar";
            this.Filtrar_BT.UseVisualStyleBackColor = true;
            this.Filtrar_BT.Click += new System.EventHandler(this.Filtrar_BT_Click);
            // 
            // Submodulo
            // 
            this.Submodulo.Controls.Add(this.Promocion_CB);
            this.Submodulo.Location = new System.Drawing.Point(9, 6);
            this.Submodulo.Name = "Submodulo";
            this.Submodulo.Size = new System.Drawing.Size(378, 59);
            this.Submodulo.TabIndex = 6;
            this.Submodulo.TabStop = false;
            this.Submodulo.Text = "Promoción";
            // 
            // Promocion_CB
            // 
            this.Promocion_CB.DataSource = this.Datos_Promociones;
            this.Promocion_CB.DisplayMember = "Texto";
            this.Promocion_CB.FormattingEnabled = true;
            this.Promocion_CB.Location = new System.Drawing.Point(6, 20);
            this.Promocion_CB.Name = "Promocion_CB";
            this.Promocion_CB.Size = new System.Drawing.Size(358, 21);
            this.Promocion_CB.TabIndex = 7;
            this.Promocion_CB.ValueMember = "Oid";
            // 
            // Datos_Promociones
            // 
            this.Datos_Promociones.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // SC1
            // 
            this.SC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SC1.IsSplitterFixed = true;
            this.SC1.Location = new System.Drawing.Point(0, 0);
            this.SC1.Name = "SC1";
            this.SC1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SC1.Panel1
            // 
            this.SC1.Panel1.Controls.Add(this.Arbol_TV);
            // 
            // SC1.Panel2
            // 
            this.SC1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.SC1.Panel2.Controls.Add(this.Submit_BT);
            this.SC1.Size = new System.Drawing.Size(978, 332);
            this.SC1.SplitterDistance = 265;
            this.SC1.TabIndex = 1;
            // 
            // Arbol_TV
            // 
            this.Arbol_TV.CheckBoxes = true;
            this.Arbol_TV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Arbol_TV.ImageIndex = 0;
            this.Arbol_TV.ImageList = this.Iconos_IL;
            this.Arbol_TV.Location = new System.Drawing.Point(0, 0);
            this.Arbol_TV.Name = "Arbol_TV";
            this.Arbol_TV.SelectedImageIndex = 0;
            this.Arbol_TV.Size = new System.Drawing.Size(978, 265);
            this.Arbol_TV.TabIndex = 0;
            this.Arbol_TV.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Arbol_TV_NodeMouseDoubleClick);
            this.Arbol_TV.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.Arbol_TV_AfterCheck);
            // 
            // Submit_BT
            // 
            this.Submit_BT.Image = global::moleQule.Face.Instruction.Properties.Resources.Aceptar;
            this.Submit_BT.Location = new System.Drawing.Point(850, 10);
            this.Submit_BT.Name = "Submit_BT";
            this.Submit_BT.Size = new System.Drawing.Size(116, 41);
            this.Submit_BT.TabIndex = 4;
            this.Submit_BT.Text = "Aceptar";
            this.Submit_BT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Submit_BT.UseVisualStyleBackColor = true;
            this.Submit_BT.Click += new System.EventHandler(this.Aceptar_Button_Click);
            // 
            // Iconos_IL
            // 
            this.Iconos_IL.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Iconos_IL.ImageStream")));
            this.Iconos_IL.TransparentColor = System.Drawing.Color.Transparent;
            this.Iconos_IL.Images.SetKeyName(0, "submodulo");
            // 
            // AlumnosSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(978, 460);
            this.Controls.Add(this.Panel1);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AlumnosSelectForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Load += new System.EventHandler(this.AlumnosSelectForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlumnosSelectForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            this.Panel1.Panel1.ResumeLayout(false);
            this.Panel1.Panel2.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.SC2.Panel1.ResumeLayout(false);
            this.SC2.Panel1.PerformLayout();
            this.SC2.Panel2.ResumeLayout(false);
            this.SC2.ResumeLayout(false);
            this.Submodulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Promociones)).EndInit();
            this.SC1.Panel1.ResumeLayout(false);
            this.SC1.Panel2.ResumeLayout(false);
            this.SC1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SC2;
        private System.Windows.Forms.Button Cerrar_BT;
        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.Label BarraDerecha;
        private System.Windows.Forms.GroupBox Submodulo;
        private System.Windows.Forms.ComboBox Promocion_CB;
        private System.Windows.Forms.BindingSource Datos_Promociones;
        public System.Windows.Forms.SplitContainer Panel1;
        private System.Windows.Forms.TreeView Arbol_TV;
        private System.Windows.Forms.Button Filtrar_BT;
        private System.Windows.Forms.SplitContainer SC1;
        private System.Windows.Forms.Button Submit_BT;
        private System.Windows.Forms.Button Imprimir_BT;
        protected System.Windows.Forms.ImageList Iconos_IL;
    }
}
