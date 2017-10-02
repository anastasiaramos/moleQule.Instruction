namespace moleQule.Face.Instruction
{
    partial class PreguntasSelectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreguntasSelectForm));
            this.Panel1 = new System.Windows.Forms.SplitContainer();
            this.SC2 = new System.Windows.Forms.SplitContainer();
            this.BarraDerecha = new System.Windows.Forms.Label();
            this.Titulo = new System.Windows.Forms.Label();
            this.Cerrar_BT = new System.Windows.Forms.Button();
            this.Datos_GB = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Examen_TB = new System.Windows.Forms.Label();
            this.Disponibles_TB = new System.Windows.Forms.Label();
            this.Seleccionadas_TB = new System.Windows.Forms.Label();
            this.Filtrar_BT = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Tema_CB = new System.Windows.Forms.ComboBox();
            this.Datos_Temas = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Idioma_CB = new System.Windows.Forms.ComboBox();
            this.Datos_Idiomas = new System.Windows.Forms.BindingSource(this.components);
            this.Submodulo = new System.Windows.Forms.GroupBox();
            this.Submodulo_CB = new System.Windows.Forms.ComboBox();
            this.Datos_Submodulos = new System.Windows.Forms.BindingSource(this.components);
            this.SC1 = new System.Windows.Forms.SplitContainer();
            this.Arbol_TV = new System.Windows.Forms.TreeView();
            this.Submit_BT = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Iconos_IL = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            this.Panel1.Panel1.SuspendLayout();
            this.Panel1.Panel2.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.SC2.Panel1.SuspendLayout();
            this.SC2.Panel2.SuspendLayout();
            this.SC2.SuspendLayout();
            this.Datos_GB.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Temas)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Idiomas)).BeginInit();
            this.Submodulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Submodulos)).BeginInit();
            this.SC1.Panel1.SuspendLayout();
            this.SC1.Panel2.SuspendLayout();
            this.SC1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Datos
            // 
            this.Datos.DataSource = typeof(moleQule.Library.Instruction.Submodulo);
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
            this.SC2.Panel2.Controls.Add(this.Datos_GB);
            this.SC2.Panel2.Controls.Add(this.Filtrar_BT);
            this.SC2.Panel2.Controls.Add(this.groupBox2);
            this.SC2.Panel2.Controls.Add(this.groupBox1);
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
            this.Titulo.Size = new System.Drawing.Size(228, 19);
            this.Titulo.TabIndex = 2;
            this.Titulo.Tag = "No Format";
            this.Titulo.Text = "|    Selección de Preguntas";
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
            // Datos_GB
            // 
            this.Datos_GB.Controls.Add(this.label3);
            this.Datos_GB.Controls.Add(this.label4);
            this.Datos_GB.Controls.Add(this.label5);
            this.Datos_GB.Controls.Add(this.Examen_TB);
            this.Datos_GB.Controls.Add(this.Disponibles_TB);
            this.Datos_GB.Controls.Add(this.Seleccionadas_TB);
            this.Datos_GB.Location = new System.Drawing.Point(793, 4);
            this.Datos_GB.Name = "Datos_GB";
            this.Datos_GB.Size = new System.Drawing.Size(164, 62);
            this.Datos_GB.TabIndex = 10;
            this.Datos_GB.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Examen:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Disponibles:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Seleccionadas:";
            // 
            // Examen_TB
            // 
            this.Examen_TB.AutoSize = true;
            this.Examen_TB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Examen_TB.Location = new System.Drawing.Point(131, 9);
            this.Examen_TB.Name = "Examen_TB";
            this.Examen_TB.Size = new System.Drawing.Size(14, 13);
            this.Examen_TB.TabIndex = 3;
            this.Examen_TB.Text = "0";
            this.Examen_TB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Disponibles_TB
            // 
            this.Disponibles_TB.AutoSize = true;
            this.Disponibles_TB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Disponibles_TB.Location = new System.Drawing.Point(131, 26);
            this.Disponibles_TB.Name = "Disponibles_TB";
            this.Disponibles_TB.Size = new System.Drawing.Size(14, 13);
            this.Disponibles_TB.TabIndex = 4;
            this.Disponibles_TB.Text = "0";
            this.Disponibles_TB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Seleccionadas_TB
            // 
            this.Seleccionadas_TB.AutoSize = true;
            this.Seleccionadas_TB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Seleccionadas_TB.Location = new System.Drawing.Point(131, 43);
            this.Seleccionadas_TB.Name = "Seleccionadas_TB";
            this.Seleccionadas_TB.Size = new System.Drawing.Size(14, 13);
            this.Seleccionadas_TB.TabIndex = 5;
            this.Seleccionadas_TB.Text = "0";
            this.Seleccionadas_TB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Filtrar_BT
            // 
            this.Filtrar_BT.Location = new System.Drawing.Point(651, 24);
            this.Filtrar_BT.Name = "Filtrar_BT";
            this.Filtrar_BT.Size = new System.Drawing.Size(75, 23);
            this.Filtrar_BT.TabIndex = 9;
            this.Filtrar_BT.Text = "Filtrar";
            this.Filtrar_BT.UseVisualStyleBackColor = true;
            this.Filtrar_BT.Click += new System.EventHandler(this.Filtrar_BT_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Tema_CB);
            this.groupBox2.Location = new System.Drawing.Point(199, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 57);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tema";
            // 
            // Tema_CB
            // 
            this.Tema_CB.DataSource = this.Datos_Temas;
            this.Tema_CB.DisplayMember = "Texto";
            this.Tema_CB.FormattingEnabled = true;
            this.Tema_CB.Location = new System.Drawing.Point(12, 20);
            this.Tema_CB.Name = "Tema_CB";
            this.Tema_CB.Size = new System.Drawing.Size(173, 21);
            this.Tema_CB.TabIndex = 8;
            this.Tema_CB.ValueMember = "Oid";
            // 
            // Datos_Temas
            // 
            this.Datos_Temas.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Idioma_CB);
            this.groupBox1.Location = new System.Drawing.Point(400, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 59);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Idioma";
            // 
            // Idioma_CB
            // 
            this.Idioma_CB.DataSource = this.Datos_Idiomas;
            this.Idioma_CB.DisplayMember = "Texto";
            this.Idioma_CB.FormattingEnabled = true;
            this.Idioma_CB.Location = new System.Drawing.Point(14, 20);
            this.Idioma_CB.Name = "Idioma_CB";
            this.Idioma_CB.Size = new System.Drawing.Size(172, 21);
            this.Idioma_CB.TabIndex = 7;
            this.Idioma_CB.ValueMember = "Oid";
            // 
            // Datos_Idiomas
            // 
            this.Datos_Idiomas.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // Submodulo
            // 
            this.Submodulo.Controls.Add(this.Submodulo_CB);
            this.Submodulo.Location = new System.Drawing.Point(9, 6);
            this.Submodulo.Name = "Submodulo";
            this.Submodulo.Size = new System.Drawing.Size(182, 59);
            this.Submodulo.TabIndex = 6;
            this.Submodulo.TabStop = false;
            this.Submodulo.Text = "Submódulo";
            // 
            // Submodulo_CB
            // 
            this.Submodulo_CB.DataSource = this.Datos_Submodulos;
            this.Submodulo_CB.DisplayMember = "Texto";
            this.Submodulo_CB.FormattingEnabled = true;
            this.Submodulo_CB.Location = new System.Drawing.Point(6, 20);
            this.Submodulo_CB.Name = "Submodulo_CB";
            this.Submodulo_CB.Size = new System.Drawing.Size(162, 21);
            this.Submodulo_CB.TabIndex = 7;
            this.Submodulo_CB.ValueMember = "Oid";
            this.Submodulo_CB.SelectedValueChanged += new System.EventHandler(this.Submodulo_CB_SelectedValueChanged);
            // 
            // Datos_Submodulos
            // 
            this.Datos_Submodulos.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
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
            this.SC1.Panel2.Controls.Add(this.groupBox3);
            this.SC1.Size = new System.Drawing.Size(978, 332);
            this.SC1.SplitterDistance = 265;
            this.SC1.TabIndex = 1;
            // 
            // Arbol_TV
            // 
            this.Arbol_TV.CheckBoxes = true;
            this.Arbol_TV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Arbol_TV.Location = new System.Drawing.Point(0, 0);
            this.Arbol_TV.Name = "Arbol_TV";
            this.Arbol_TV.Size = new System.Drawing.Size(978, 265);
            this.Arbol_TV.TabIndex = 0;
            this.Arbol_TV.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.Arbol_TV_AfterCheck);
            // 
            // Submit_BT
            // 
            this.Submit_BT.Image = global::moleQule.Face.Instruction.Properties.Resources.Aceptar;
            this.Submit_BT.Location = new System.Drawing.Point(670, 4);
            this.Submit_BT.Name = "Submit_BT";
            this.Submit_BT.Size = new System.Drawing.Size(116, 41);
            this.Submit_BT.TabIndex = 4;
            this.Submit_BT.Text = "Aceptar";
            this.Submit_BT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Submit_BT.UseVisualStyleBackColor = true;
            this.Submit_BT.Click += new System.EventHandler(this.Aceptar_Button_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBox3);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.pictureBox2);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(5, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(641, 56);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Leyenda";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::moleQule.Face.Instruction.Properties.Resources.Reservada;
            this.pictureBox3.Location = new System.Drawing.Point(20, 37);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(280, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Pregunta Reservada (Incluída en un examen NO emitido)";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::moleQule.Face.Instruction.Properties.Resources.Bloqueada;
            this.pictureBox2.Location = new System.Drawing.Point(20, 17);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(255, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Pregunta Publicada (Incluída en un examen emitido)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::moleQule.Face.Instruction.Properties.Resources.Disponible;
            this.pictureBox1.Location = new System.Drawing.Point(441, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(463, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Pregunta Disponible";
            // 
            // Iconos_IL
            // 
            this.Iconos_IL.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Iconos_IL.ImageStream")));
            this.Iconos_IL.TransparentColor = System.Drawing.Color.Transparent;
            this.Iconos_IL.Images.SetKeyName(0, "submodulo");
            this.Iconos_IL.Images.SetKeyName(1, "disponible");
            this.Iconos_IL.Images.SetKeyName(2, "bloqueada");
            this.Iconos_IL.Images.SetKeyName(3, "reservada");
            this.Iconos_IL.Images.SetKeyName(4, "nivel");
            // 
            // PreguntasSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(978, 460);
            this.Controls.Add(this.Panel1);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PreguntasSelectForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Load += new System.EventHandler(this.PreguntasSelectForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreguntasSelectForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            this.Panel1.Panel1.ResumeLayout(false);
            this.Panel1.Panel2.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.SC2.Panel1.ResumeLayout(false);
            this.SC2.Panel1.PerformLayout();
            this.SC2.Panel2.ResumeLayout(false);
            this.SC2.ResumeLayout(false);
            this.Datos_GB.ResumeLayout(false);
            this.Datos_GB.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Temas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Idiomas)).EndInit();
            this.Submodulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Submodulos)).EndInit();
            this.SC1.Panel1.ResumeLayout(false);
            this.SC1.Panel2.ResumeLayout(false);
            this.SC1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SC2;
        private System.Windows.Forms.Button Cerrar_BT;
        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.Label BarraDerecha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Disponibles_TB;
        private System.Windows.Forms.Label Examen_TB;
        private System.Windows.Forms.Label Seleccionadas_TB;
        private System.Windows.Forms.GroupBox Submodulo;
        private System.Windows.Forms.ComboBox Submodulo_CB;
        private System.Windows.Forms.BindingSource Datos_Submodulos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox Idioma_CB;
        private System.Windows.Forms.BindingSource Datos_Idiomas;
        private System.Windows.Forms.ComboBox Tema_CB;
        private System.Windows.Forms.BindingSource Datos_Temas;
        public System.Windows.Forms.SplitContainer Panel1;
        private System.Windows.Forms.Button Filtrar_BT;
        private System.Windows.Forms.SplitContainer SC1;
        private System.Windows.Forms.Button Submit_BT;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox Datos_GB;
        private System.Windows.Forms.TreeView Arbol_TV;
        protected System.Windows.Forms.ImageList Iconos_IL;
    }
}
