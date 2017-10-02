using System;
using System.Windows.Forms;

using moleQule.Library.Instruction; 
using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class PromocionAddForm : PromocionUIForm
    {

        #region Factory Methods

        public PromocionAddForm() : this(true) {}

        public PromocionAddForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.PROMOCION_ADD_TITLE;
            _mf_type = ManagerFormType.MFAdd;
        }

        public PromocionAddForm(Promocion source)
            : base()
        {
            InitializeComponent();
            _entity = source.Clone();
            _entity.BeginEdit();
            SetFormData();
            this.Text = Resources.Labels.PROMOCION_ADD_TITLE;
            _mf_type = ManagerFormType.MFAdd;
        }

        protected override void GetFormSourceData()
        {
            _entity = Promocion.New();
            _entity.BeginEdit();
        }

        #endregion

        #region Buttons

        #endregion
    }
}

