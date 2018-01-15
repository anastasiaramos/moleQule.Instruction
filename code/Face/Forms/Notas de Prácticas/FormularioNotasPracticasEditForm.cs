using System;
using System.Windows.Forms;

using moleQule.Library.Instruction;
using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class FormularioNotasPracticasEditForm : FormularioNotasPracticasUIForm
    {

        #region Factory Methods

        public FormularioNotasPracticasEditForm(long oid)
            : this(oid, true) { }

        public FormularioNotasPracticasEditForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
            if (Entity != null)
            {
                SetFormData();
                this.Text = Resources.Labels.FORMULARIO_NOTAS_EDIT_TITLE;
            }
            _mf_type = ManagerFormType.MFEdit;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = ParteAsistencia.Get(oid, true);
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
            {
                if (_entity.CloseSessions) Entity.CloseSession();
                //_entity = null;
            }
        }

        #endregion

    }
}

