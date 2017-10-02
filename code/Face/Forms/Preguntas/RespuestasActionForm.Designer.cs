namespace moleQule.Face.Instruction
{
    partial class RespuestasActionForm
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
            System.Windows.Forms.Label opcionLabel;
            System.Windows.Forms.Label correctaLabel;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RespuestasActionForm));
            this.Datos_Respuesta = new System.Windows.Forms.BindingSource(this.components);
            this.Respuesta_BN = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.respuestaBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.textoTextBox = new System.Windows.Forms.TextBox();
            this.correctaCheckBox = new System.Windows.Forms.CheckBox();
            this.Opcion_CB = new System.Windows.Forms.ComboBox();
            this.Datos_Opciones = new System.Windows.Forms.BindingSource(this.components);
            this.Numero_TB = new System.Windows.Forms.TextBox();
            opcionLabel = new System.Windows.Forms.Label();
            correctaLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.Source_GB.SuspendLayout();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Respuesta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Respuesta_BN)).BeginInit();
            this.Respuesta_BN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Opciones)).BeginInit();
            this.SuspendLayout();
            // 
            // Submit_BT
            // 
            this.Submit_BT.Location = new System.Drawing.Point(73, 8);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Enabled = false;
            this.Cancel_BT.Location = new System.Drawing.Point(163, 8);
            this.Cancel_BT.Visible = false;
            // 
            // Source_GB
            // 
            this.Source_GB.Controls.Add(this.textoTextBox);
            this.Source_GB.Location = new System.Drawing.Point(44, 75);
            this.Source_GB.Size = new System.Drawing.Size(633, 116);
            this.Source_GB.Text = "Respuesta";
            // 
            // PanelesV
            // 
            this.PanelesV.Location = new System.Drawing.Point(0, 25);
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.Controls.Add(this.Numero_TB);
            this.PanelesV.Panel1.Controls.Add(label1);
            this.PanelesV.Panel1.Controls.Add(this.Opcion_CB);
            this.PanelesV.Panel1.Controls.Add(correctaLabel);
            this.PanelesV.Panel1.Controls.Add(this.correctaCheckBox);
            this.PanelesV.Panel1.Controls.Add(opcionLabel);
            this.PanelesV.Size = new System.Drawing.Size(723, 257);
            this.PanelesV.SplitterDistance = 217;
            // 
            // opcionLabel
            // 
            opcionLabel.AutoSize = true;
            opcionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            opcionLabel.Location = new System.Drawing.Point(244, 38);
            opcionLabel.Name = "opcionLabel";
            opcionLabel.Size = new System.Drawing.Size(48, 13);
            opcionLabel.TabIndex = 1;
            opcionLabel.Text = "Opción:";
            // 
            // correctaLabel
            // 
            correctaLabel.AutoSize = true;
            correctaLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            correctaLabel.Location = new System.Drawing.Point(380, 38);
            correctaLabel.Name = "correctaLabel";
            correctaLabel.Size = new System.Drawing.Size(59, 13);
            correctaLabel.TabIndex = 3;
            correctaLabel.Text = "Correcta:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(70, 38);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(54, 13);
            label1.TabIndex = 6;
            label1.Text = "Número:";
            // 
            // Datos_Respuesta
            // 
            this.Datos_Respuesta.DataSource = typeof(moleQule.Library.Instruction.Respuesta);
            // 
            // Respuesta_BN
            // 
            this.Respuesta_BN.AddNewItem = this.bindingNavigatorAddNewItem;
            this.Respuesta_BN.BindingSource = this.Datos_Respuesta;
            this.Respuesta_BN.CountItem = this.bindingNavigatorCountItem;
            this.Respuesta_BN.DeleteItem = this.bindingNavigatorDeleteItem;
            this.Respuesta_BN.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.respuestaBindingNavigatorSaveItem});
            this.Respuesta_BN.Location = new System.Drawing.Point(0, 0);
            this.Respuesta_BN.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.Respuesta_BN.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.Respuesta_BN.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.Respuesta_BN.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.Respuesta_BN.Name = "Respuesta_BN";
            this.Respuesta_BN.PositionItem = this.bindingNavigatorPositionItem;
            this.Respuesta_BN.Size = new System.Drawing.Size(723, 25);
            this.Respuesta_BN.TabIndex = 1;
            this.Respuesta_BN.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Agregar nuevo";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Eliminar";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Mover primero";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Mover anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Posición";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posición actual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Mover siguiente";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Mover último";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // respuestaBindingNavigatorSaveItem
            // 
            this.respuestaBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.respuestaBindingNavigatorSaveItem.Enabled = false;
            this.respuestaBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("respuestaBindingNavigatorSaveItem.Image")));
            this.respuestaBindingNavigatorSaveItem.Name = "respuestaBindingNavigatorSaveItem";
            this.respuestaBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.respuestaBindingNavigatorSaveItem.Text = "Guardar datos";
            // 
            // textoTextBox
            // 
            this.textoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos_Respuesta, "Texto", true));
            this.textoTextBox.Location = new System.Drawing.Point(6, 20);
            this.textoTextBox.Multiline = true;
            this.textoTextBox.Name = "textoTextBox";
            this.textoTextBox.Size = new System.Drawing.Size(621, 90);
            this.textoTextBox.TabIndex = 1;
            // 
            // correctaCheckBox
            // 
            this.correctaCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.Datos_Respuesta, "Correcta", true));
            this.correctaCheckBox.Location = new System.Drawing.Point(445, 33);
            this.correctaCheckBox.Name = "correctaCheckBox";
            this.correctaCheckBox.Size = new System.Drawing.Size(31, 24);
            this.correctaCheckBox.TabIndex = 4;
            // 
            // Opcion_CB
            // 
            this.Opcion_CB.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.Datos_Respuesta, "Opcion", true));
            this.Opcion_CB.DataSource = this.Datos_Opciones;
            this.Opcion_CB.DisplayMember = "Texto";
            this.Opcion_CB.FormattingEnabled = true;
            this.Opcion_CB.Location = new System.Drawing.Point(299, 35);
            this.Opcion_CB.Name = "Opcion_CB";
            this.Opcion_CB.Size = new System.Drawing.Size(59, 21);
            this.Opcion_CB.TabIndex = 5;
            this.Opcion_CB.ValueMember = "Texto";
            // 
            // Datos_Opciones
            // 
            this.Datos_Opciones.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // Numero_TB
            // 
            this.Numero_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos_Respuesta, "Codigo", true));
            this.Numero_TB.Location = new System.Drawing.Point(131, 35);
            this.Numero_TB.Name = "Numero_TB";
            this.Numero_TB.ReadOnly = true;
            this.Numero_TB.Size = new System.Drawing.Size(100, 21);
            this.Numero_TB.TabIndex = 7;
            // 
            // RespuestasActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(723, 282);
            this.Controls.Add(this.Respuesta_BN);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "RespuestasActionForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RespuestasActionForm_FormClosing);
            this.Controls.SetChildIndex(this.Respuesta_BN, 0);
            this.Controls.SetChildIndex(this.PanelesV, 0);
            this.Source_GB.ResumeLayout(false);
            this.Source_GB.PerformLayout();
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel1.PerformLayout();
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Respuesta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Respuesta_BN)).EndInit();
            this.Respuesta_BN.ResumeLayout(false);
            this.Respuesta_BN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Opciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textoTextBox;
        private System.Windows.Forms.BindingSource Datos_Respuesta;
        private System.Windows.Forms.BindingNavigator Respuesta_BN;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton respuestaBindingNavigatorSaveItem;
        private System.Windows.Forms.CheckBox correctaCheckBox;
        private System.Windows.Forms.ComboBox Opcion_CB;
        private System.Windows.Forms.BindingSource Datos_Opciones;
        private System.Windows.Forms.TextBox Numero_TB;
    }
}
