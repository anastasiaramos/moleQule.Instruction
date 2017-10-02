using System;
using System.Windows.Forms;

namespace moleQule.Face.Instruction
{
    public partial class PlanEstudiosSelectForm : PlanEstudiosMngForm
    {

        #region Factory Methods

        public PlanEstudiosSelectForm()
            : this(true, null) {}

        public PlanEstudiosSelectForm(Form parent) : this(true, parent) { }

        public PlanEstudiosSelectForm(bool isModal, Form parent)
            : base(true, parent)
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
