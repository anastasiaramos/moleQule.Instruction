using System;
using System.Windows.Forms;

namespace moleQule.Face.Instruction
{
    public partial class CursoSelectForm : CursoMngForm
    {

        #region Factory Methods

        public CursoSelectForm()
            : this(true, null) {}

        public CursoSelectForm(Form parent) : this(true, parent) { }

        public CursoSelectForm(bool isModal, Form parent)
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
