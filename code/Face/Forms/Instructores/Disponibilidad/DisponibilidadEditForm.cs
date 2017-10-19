using System;
using System.Windows.Forms;

using moleQule.Library.Instruction; 

using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class DisponibilidadEditForm : DisponibilidadUIForm
    {

        #region Factory Methods

        public DisponibilidadEditForm(InstructorUIForm form)
            : this(true) 
        {
            _has_parent = true;
        }

        public DisponibilidadEditForm()
            : this(true) { }

        public DisponibilidadEditForm(bool ismodal)
            : base(ismodal)
        {
            InitializeComponent();
            //if (Lista != null)
            //{
                SetFormData();
                this.Text = Resources.Labels.DISPONIBILIDAD_EDIT_TITLE ;
            //}
            _mf_type = ManagerFormType.MFEdit;
        }

        protected override void GetFormSourceData()
        {
            //_lista = Instructores.GetList();
            _mf_type = ManagerFormType.MFEdit;
        }

        #endregion

        #region Buttons

        #endregion

    }
}

