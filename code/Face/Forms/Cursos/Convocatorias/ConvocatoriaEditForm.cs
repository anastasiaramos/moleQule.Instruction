using System;
using System.Windows.Forms;

using moleQule.Library.Instruction; 

using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class ConvocatoriaEditForm : ConvocatoriaForm
    {

        #region Factory Methods

        public ConvocatoriaEditForm(Curso curso, Convocatoria_Curso convocatoria, bool ismodal)
            : base(convocatoria.Oid, ismodal)
        {
            InitializeComponent();

            _curso = curso;
            _entity = convocatoria;

            SetFormData();
            this.Text = Resources.Labels.CONVOCATORIA_EDIT_TITLE + " " + _entity.Nombre.ToUpper();

            _mf_type = ManagerFormType.MFEdit;
        }

        protected override void GetFormSourceData(long oid)
        {
        }

        #endregion

        #region Buttons

        protected override void CancelAction()
        {
            _entity.CancelEdit();
            _action_result = DialogResult.Cancel;
            Close();
        }

        #endregion

    }
}

