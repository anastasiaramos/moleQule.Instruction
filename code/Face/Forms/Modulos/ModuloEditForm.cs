using System;
using System.Windows.Forms;

using moleQule.Library.Instruction; 

using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class ModuloEditForm : ModuloUIForm
    {
        #region Attributes & Properties

        protected override int BarSteps { get { return base.BarSteps + 2; } }

        #endregion

        #region Factory Methods

        public ModuloEditForm(long oid)
            : this(oid, true) { }

        public ModuloEditForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
            if (Entity != null)
            {
                SetFormData();
                this.Text = Resources.Labels.MODULO_EDIT_TITLE + " " + Entity.Codigo.ToUpper();
            }
            _mf_type = ManagerFormType.MFEdit;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = Modulo.Get(oid, false);
            _entity.BeginEdit();
            _mf_type = ManagerFormType.MFEdit;
        }

        #endregion

        #region Style & Source

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            _entity.LoadChilds(typeof(Submodulos), true, false);
            PgMng.Grow();

            _entity.LoadChilds(typeof(Material_Plans), false, false);
            PgMng.Grow();

            base.RefreshMainData();
        }

        #endregion

        #region Buttons

        #endregion

        #region Events

        private void ModuloEditForm_FormClosing(object sender, FormClosingEventArgs e)
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

