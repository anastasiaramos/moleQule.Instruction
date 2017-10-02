using System;
using System.Windows.Forms;

using moleQule.Library.Instruction; 

using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class CursoAddForm : CursoUIForm
    {

        #region Factory Methods

        public CursoAddForm() : this(true) {}

        public CursoAddForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.CURSO_ADD_TITLE;
        }

        public CursoAddForm(Curso source)
            : base()
        {
            InitializeComponent();
            _entity = source.Clone();
            _entity.BeginEdit();
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.CURSO_ADD_TITLE;
        }

        protected override void GetFormSourceData()
        {
            _entity = Curso.New();
            _entity.BeginEdit();
        }

        #endregion

        #region Actions

        #endregion
    }
}