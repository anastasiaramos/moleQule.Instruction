namespace moleQule.Face.Instruction
{
    partial class CursoUIForm
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
            this.SuspendLayout();
            // 
            // Edit_BT
            // 
            this.Edit_BT.Click += new System.EventHandler(this.Edit_BT_Click);
            // 
            // Delete_BT
            // 
            this.Delete_BT.Click += new System.EventHandler(this.Delete_BT_Click);
            // 
            // Add_BT
            // 
            this.Add_BT.Click += new System.EventHandler(this.Add_BT_Click);

            this.Convocatorias_Grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Convocatorias_Grid_CellDoubleClick);

            // 
            // CursoUIForm
            // 
            this.Name = "CursoUIForm";
            this.Text = "CursoUIForm";
            this.ResumeLayout(false);
        }

        #endregion
    }
}
