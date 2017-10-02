using System;
using System.Windows.Forms;

using moleQule.Library.CslaEx;
using moleQule.Face;

using moleQule.Library.Instruction;

namespace moleQule.Face.Instruction
{
    public partial class PromocionEditForm : PromocionUIForm
    {

        #region Factory Methods

        public PromocionEditForm(long oid)
            : this(oid, true) { }

        public PromocionEditForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
            if (Entity != null)
            {
                SetFormData();
                this.Text = Resources.Labels.PROMOCION_EDIT_TITLE + " " + Entity.Nombre.ToUpper();
            }
            _mf_type = ManagerFormType.MFEdit;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = Promocion.Get(oid, false);
            _entity.LoadChilds(typeof(Sesion_Promocion), true);
            _entity.BeginEdit();
        }

        #endregion

        #region Actions

        protected override void  EditarAlumnoAction()
        {
            try
            {
                Alumno item = Alumno.GetForForm((Alumnos_Grid.CurrentRow.DataBoundItem as AlumnoInfo).Oid, true, _entity.SessionCode);
                item.SharedTransaction = true;
                AlumnoEditForm form = new AlumnoEditForm(item, true, this);
                form.ShowDialog();

                if (form.ActionResult == DialogResult.OK)
                {
                    //_entity.LoadChilds(typeof(Alumno_Promocion));
                    Datos_Alumnos.DataSource = Datos_Alumnos.DataSource = AlumnoList.GetListByPromocion(EntityInfo.Oid, false);
                }
            }
            catch { }   
        }

        #endregion

        #region Buttons

        #endregion

        #region Events

        private void PromocionEditForm_FormClosing(object sender, FormClosingEventArgs e)
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