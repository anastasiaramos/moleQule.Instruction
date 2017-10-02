using System;
using System.Windows.Forms;

using moleQule.Library.Instruction; 

using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class PlanExtraAddForm : PlanExtraUIForm
    {

        #region Factory Methods

        public PlanExtraAddForm() : this(true) {}

        public PlanExtraAddForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.PLAN_EXTRA_ADD_TITLE;
        }

        public PlanExtraAddForm(PlanExtra source)
            : base()
        {
            InitializeComponent();
            _entity = source.Clone();
            _entity.BeginEdit();
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.PLAN_EXTRA_ADD_TITLE;
        }

        protected override void GetFormSourceData()
        {
            _entity = PlanExtra.New();
            _entity.BeginEdit();
        }

        #endregion

        #region Buttons

        #endregion
    }
}