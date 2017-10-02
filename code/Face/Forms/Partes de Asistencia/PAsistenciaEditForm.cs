using System;
using System.Windows.Forms;

using moleQule.Library.Instruction;
using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class PAsistenciaEditForm : PAsistenciaUIForm
    {

        #region Factory Methods

        public PAsistenciaEditForm(long oid)
            : this(oid, true) { }

        public PAsistenciaEditForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
            if (Entity != null)
            {
                SetFormData();
                this.Text = Resources.Labels.P_ASISTENCIA_EDIT_TITLE ;
            }
            _mf_type = ManagerFormType.MFEdit;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = ParteAsistencia.Get(oid);
            _entity.BeginEdit();
            _mf_type = ManagerFormType.MFEdit;
        }

        #endregion

        #region Buttons

        #endregion

        #region Events

        private void PAsistenciaEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_entity != null && !_entity.SharedTransaction)
                if (_entity.CloseSessions) Entity.CloseSession();
        }

        #endregion

    }
}

