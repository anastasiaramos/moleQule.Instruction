using System;
using System.Windows.Forms;

using moleQule.Library.Instruction; 

using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class InstructorAddForm : InstructorUIForm
    {

        #region Factory Methods

        public InstructorAddForm() : this(true) {}

        public InstructorAddForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();

            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.INSTRUCTOR_ADD_TITLE;
        }

        public InstructorAddForm(Instructor source)
            : base()
        {
            InitializeComponent();

			_entity = source.Clone();
            _entity.BeginEdit();
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.INSTRUCTOR_ADD_TITLE;
        }

        protected override void GetFormSourceData()
        {
            _entity = Instructor.New();
            _entity.BeginEdit();
        }
      
        #endregion

        #region Buttons

        #endregion
    }
}