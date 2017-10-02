using System;
using System.Windows.Forms;

using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class InstructorSelectForm : InstructorMngForm
    {

        #region Factory Methods

        public InstructorSelectForm()
            : this(null) {}

        public InstructorSelectForm(Form parent)
            : base(true, parent, null) {}
		
		public InstructorSelectForm(Form parent, InstructorList list)
            : base(true, parent, list)
        {
            InitializeComponent();
            _view_mode = molView.Select;
            DialogResult = DialogResult.Cancel;
        }
		
        #endregion

        #region Style & Source

        /// <summary>Formatea los controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();
        }

        #endregion

        #region Actions

        /// <summary>
        /// Accion por defecto. Se usa para el Double_Click del Grid
        /// <returns>void</returns>
        /// </summary>
        protected override void DefaultAction() { ExecuteAction(molAction.Select); }

        #endregion

    }
}
