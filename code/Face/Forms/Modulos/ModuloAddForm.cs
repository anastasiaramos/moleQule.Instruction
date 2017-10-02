using System;
using System.Windows.Forms;

using moleQule.Library.Instruction; 

using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class ModuloAddForm : ModuloUIForm
    {

        #region Factory Methods

        public ModuloAddForm() : this(true) {}

        public ModuloAddForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.MODULO_ADD_TITLE;
        }

        public ModuloAddForm(Modulo source)
            : base()
        {
            InitializeComponent();
            _entity = source.Clone();
            _entity.BeginEdit();
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.MODULO_ADD_TITLE;
        }

        protected override void GetFormSourceData()
        {
            _entity = Modulo.New();
            _entity.BeginEdit();
        }

        #endregion

        #region Buttons

        #endregion
    }
}