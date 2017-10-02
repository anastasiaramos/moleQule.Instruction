using System;
using System.Windows.Forms;

using moleQule.Library.Instruction; 

using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class PlanDocenteAddForm : PlanDocenteUIForm
    {

        #region Factory Methods

        public PlanDocenteAddForm() : this(true) {}

        public PlanDocenteAddForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.PLAN_DOCENTE_ADD_TITLE;
        }

        public PlanDocenteAddForm(PlanEstudios source)
            : base()
        {
            InitializeComponent();
            _entity = source.Clone();
            _entity.BeginEdit();
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.PLAN_DOCENTE_ADD_TITLE;
        }

        protected override void GetFormSourceData()
        {
            _entity = PlanEstudios.New();
            _entity.BeginEdit();
        }

        #endregion

        #region Buttons

        #endregion
    }
}