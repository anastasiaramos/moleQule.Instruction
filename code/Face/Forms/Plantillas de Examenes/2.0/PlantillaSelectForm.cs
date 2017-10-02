using System;
using System.Windows.Forms;

using moleQule.Library.Modules.Instruction;

namespace molApp.Face.Modules.Instruction
{
    public partial class PlantillaSelectForm : PlantillaMngForm
    {

        #region Factory Methods

        public PlantillaSelectForm()
            : this(null) {}

        public PlantillaSelectForm(Form parent)
            : this(parent, null) {}

        public PlantillaSelectForm(Form parent, PlantillaExamenList list)
            : base(true, parent, list)
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }
		
        #endregion

        #region Style & Source

        /// <summary>Formatea los controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            SetSelectView();
            base.FormatControls();
        }

        #endregion

        #region Actions

        /// <summary>
        /// Accion por defecto. Se usa para el Double_Click del Grid
        /// <returns>void</returns>
        /// </summary>
        public override void DefaultAction() { SelectObject(); }

        #endregion
    }
}
