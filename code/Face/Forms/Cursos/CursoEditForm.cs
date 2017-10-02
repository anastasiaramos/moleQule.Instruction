using System;
using System.Windows.Forms;

using moleQule.Library.Instruction; 

using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class CursoEditForm : CursoUIForm
    {

        #region Factory Methods

        public CursoEditForm(long oid)
            : this(oid, true) { }

        public CursoEditForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
            if (Entity != null)
            {
                SetFormData();
                this.Text = Resources.Labels.CURSO_EDIT_TITLE + " " + Entity.Nombre.ToUpper();
            }
            _mf_type = ManagerFormType.MFEdit;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = Curso.Get(oid);
            _entity.BeginEdit();
            _mf_type = ManagerFormType.MFEdit;
        }

        #endregion

        #region Buttons

        #endregion

        #region Events

        private void CursoEditForm_FormClosing(object sender, FormClosingEventArgs e)
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

