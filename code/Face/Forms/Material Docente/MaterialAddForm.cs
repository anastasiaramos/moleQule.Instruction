using System;
using System.Windows.Forms;

using moleQule.Library.Instruction; 

using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class MaterialAddForm : MaterialUIForm
    {

        #region Factory Methods

        public MaterialAddForm() : this(true) {}

        public MaterialAddForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.MATERIAL_ADD_TITLE;
        }

        public MaterialAddForm(MaterialDocente source)
            : base()
        {
            InitializeComponent();
            _entity = source.Clone();
            _entity.BeginEdit();
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.MATERIAL_ADD_TITLE;
        }

        protected override void GetFormSourceData()
        {
            _entity = MaterialDocente.New();
            _entity.BeginEdit();
        }

        #endregion

        #region Actions

        #endregion
    }
}