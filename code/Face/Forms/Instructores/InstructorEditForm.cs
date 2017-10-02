using System;
using System.Windows.Forms;

using moleQule.Library.Instruction; 

using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class InstructorEditForm : InstructorUIForm
    {

        #region Factory Methods

        public InstructorEditForm(long oid)
            : this(oid, true) { }

        public InstructorEditForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();

			if (Entity != null)
            {
                SetFormData();
                this.Text = Resources.Labels. INSTRUCTOR_EDIT_TITLE + " " + Entity.Nombre.ToUpper();
            }

            _mf_type = ManagerFormType.MFEdit;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = Instructor.Get(oid);
            _entity.BeginEdit();
            _mf_type = ManagerFormType.MFEdit;
        }

        #endregion

        #region Actions

        #endregion

        #region Events 
        

        private void InstructorEditForm_FormClosing(object sender, FormClosingEventArgs e)
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

