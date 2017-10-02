using System;
using System.Windows.Forms;

using moleQule.Library.Instruction;
using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class AlumnoEditForm : AlumnoUIForm
    {

        #region Factory Methods

        public AlumnoEditForm(long oid)
            : this(oid, true) { }

        public AlumnoEditForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
            if (Entity != null)
            {
                SetFormData();
                this.Text = Resources.Labels.ALUMNO_EDIT_TITLE + " " + Entity.Nombre.ToUpper();
            }
            _mf_type = ManagerFormType.MFEdit;
        }

        public AlumnoEditForm(Alumno item, bool isModal, Form parent)
            : base(item, isModal, parent)
        {
            InitializeComponent();
            if (Entity != null)
            {
                SetFormData();
                this.Text = Resources.Labels.ALUMNO_EDIT_TITLE + " " + Entity.Nombre.ToUpper();
            }
            _mf_type = ManagerFormType.MFEdit;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = Alumno.GetForForm(oid, true);
            _entity.BeginEdit();
        }

        protected override void GetFormSourceData(long oid, object[] parameteres)
        {
            _entity = (Alumno)parameteres[0];
            _entity.BeginEdit();
        }

        #endregion

        #region Buttons

        #endregion

        #region Events

        private void AlumnoEditForm_FormClosing(object sender, FormClosingEventArgs e)
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