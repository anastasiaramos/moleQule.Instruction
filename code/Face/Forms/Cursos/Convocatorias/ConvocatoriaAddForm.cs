using System;
using System.Windows.Forms;

using moleQule.Library.Instruction; 

using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class ConvocatoriaAddForm : ConvocatoriaForm
    {

        #region Factory Methods

        public ConvocatoriaAddForm(Curso curso) 
            : this(true, curso) { }

        public ConvocatoriaAddForm(bool isModal, Curso curso)
            : base(isModal)
        {
            InitializeComponent();
            _curso = curso;
            _entity = _curso.Convocatorias.NewItem(_curso);
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.CONVOCATORIA_ADD_TITLE;
        }

        public ConvocatoriaAddForm(Convocatoria_Curso source)
            : base()
        {
            InitializeComponent();
            _entity = source.Clone();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.CONVOCATORIA_ADD_TITLE;
        }

        protected override void GetFormSourceData()
        {
        }

        #endregion

        #region Actions

        protected override void CancelAction()
        {
            _curso.Convocatorias.Remove(_entity);
            _action_result = DialogResult.Cancel;
            Close();
        }

        #endregion
    }
}