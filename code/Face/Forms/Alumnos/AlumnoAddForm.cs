using System;
using System.Windows.Forms;

using moleQule.Face;

using moleQule.Library.Instruction;

namespace moleQule.Face.Instruction
{
    public partial class AlumnoAddForm : AlumnoUIForm
    {

        #region Factory Methods

        public AlumnoAddForm() : this(true) {}

        public AlumnoAddForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.ALUMNO_ADD_TITLE;
            _mf_type = ManagerFormType.MFAdd;
        }

        public AlumnoAddForm(Alumno source)
            : base()
        {
            InitializeComponent();
            _entity = source.Clone();
            _entity.BeginEdit();
            SetFormData();
            this.Text = Resources.Labels.ALUMNO_ADD_TITLE;
            _mf_type = ManagerFormType.MFAdd;
        }

        protected override void GetFormSourceData()
        {
            _entity = Alumno.New();
            _entity.BeginEdit();
        }

        #endregion

        #region Buttons

        #endregion
    }
}

