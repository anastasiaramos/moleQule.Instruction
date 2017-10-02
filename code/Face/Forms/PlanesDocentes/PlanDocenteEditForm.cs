using System;
using System.Windows.Forms;

using moleQule.Library.Instruction; 

using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class PlanDocenteEditForm : PlanDocenteUIForm
    {

        #region Factory Methods

        public PlanDocenteEditForm(long oid)
            : this(oid, true) { }

        public PlanDocenteEditForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
			InitializeComponent();
            if (Entity != null)
            {
                SetFormData();
                this.Text = Resources.Labels.PLAN_DOCENTE_EDIT_TITLE + " " + Entity.Nombre.ToUpper();
            }
            _mf_type = ManagerFormType.MFEdit;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = PlanEstudios.Get(oid);
            _entity.BeginEdit();
            _mf_type = ManagerFormType.MFEdit;
        }

        #endregion

        #region Buttons

        #endregion

        #region Events

        private void PlanDocenteEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_entity != null && !_entity.SharedTransaction)
            {
                if (_entity.CloseSessions) Entity.CloseSession();
                //_entity = null;
            }
        }

        #endregion

    }
}

