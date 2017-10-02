using System;
using System.Windows.Forms;

using moleQule.Face;

using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class RevisionEditForm : RevisionForm
    {

        #region Factory Methods

        public RevisionEditForm(long oid)
            : this(oid, true) { }

        public RevisionEditForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
            if (Entity != null)
            {
                SetFormData();
                this.Text = Resources.Labels.REVISION_EDIT_TITLE + " " + Entity.Version.ToUpper();
            }
            _mf_type = ManagerFormType.MFEdit;
        }

        public RevisionEditForm(RevisionMaterial entity, MaterialDocente material, bool ismodal)
            : base(0, ismodal)
        {
            InitializeComponent();
            _material = material;
            _entity = entity;
            if (_entity != null)
            {
                SetFormData();
                this.Text = Resources.Labels.REVISION_EDIT_TITLE + " " + _entity.Version.ToUpper();
            }
            _mf_type = ManagerFormType.MFEdit;
        }

        protected override void GetFormSourceData(long oid)
        {
            if (oid != 0)
            {
                _entity = RevisionMaterial.Get(oid);
                _entity.BeginEdit();
            }
            _mf_type = ManagerFormType.MFEdit;
        }

        #endregion

        #region Actions

        #endregion

    }
}

