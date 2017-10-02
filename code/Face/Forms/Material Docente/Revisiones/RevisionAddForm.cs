using System;
using System.Windows.Forms;

using moleQule.Face;

using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class RevisionAddForm : RevisionForm
    {

        #region Factory Methods
        
        public RevisionAddForm(long oid_material) : this(true, oid_material) { }

        public RevisionAddForm(bool isModal, long oid_material)
            : base(isModal)
        {
            InitializeComponent();
            SetFormData();
            Entity.OidMaterial = oid_material;
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.REVISION_ADD_TITLE;
        }

        public RevisionAddForm(MaterialDocente material)
            : base()
        {
            InitializeComponent();
            _material = material;
            _entity = _material.Revisiones.NewItem(_material);
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.REVISION_ADD_TITLE;
        }

        public RevisionAddForm(RevisionMaterial source)
            : base()
        {
            InitializeComponent();
            _entity = source.Clone();
            _entity.BeginEdit();
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.REVISION_ADD_TITLE;
        }

        protected override void GetFormSourceData()
        {
            _entity = RevisionMaterial.New();
            _entity.BeginEdit();
        }

        #endregion

        #region Actions

        #endregion
    }
}