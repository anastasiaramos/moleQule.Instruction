using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Face;
using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class CapacidadActionForm : Skin01.ActionSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 2; } }

        public const string ID = "CapacidadActionForm";
        public static Type Type { get { return typeof(CapacidadActionForm); } }

        /// <summary>
        /// Se trata de la empresa actual y que se va a editar.
        /// </summary>
        private Instructor _entity;

        public Instructor Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        protected Library.Instruction.HComboBoxSourceList _combo_modulos;
        protected Library.Instruction.HComboBoxSourceList _combo_promociones;

        #endregion

        #region Factory Methods

        public CapacidadActionForm()
            : this(true) { }

        public CapacidadActionForm(bool IsModal)
            : base(IsModal)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.CAPACIDAD_TITLE;
        }

        public void SetSourceData(Instructor item)
        {
            _entity = item;
        }

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();

        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
        }


        public override void RefreshSecondaryData()
        {
            ModuloList modulos = ModuloList.GetList(false);
            _combo_modulos = new Library.Instruction.HComboBoxSourceList(modulos);

            Datos_Modulos.DataSource = _combo_modulos;
            PgMng.Grow();

            PromocionList promociones = PromocionList.GetList(false);
            _combo_promociones = new Library.Instruction.HComboBoxSourceList(promociones);
            PgMng.Grow();

            Datos_Promociones.DataSource = _combo_promociones;
        }

        #endregion

        #region Buttons

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SubmitAction()
        {
            if (((ComboBoxSource)Modulo_CB.SelectedItem).Oid == 0
                || ((ComboBoxSource)Promocion_CB.SelectedItem).Oid == 0)
            {
                MessageBox.Show("Debe seleccionar un módulo y una promoción válidos");
                return;
            }
            ModuloInfo modulo = ModuloInfo.Get(((ComboBoxSource)Modulo_CB.SelectedItem).Oid, false);
            SubmoduloList submodulos = SubmoduloList.GetModuloList(modulo.Oid,false);

            long oid_promocion = ((ComboBoxSource)Promocion_CB.SelectedItem).Oid;

            Instructor_Promocion promo = null;

            foreach (Instructor_Promocion item in Entity.Promociones)
            {
                if (item.OidPromocion == oid_promocion)
                {
                    promo = item;
                    break;
                }
            }

            if (promo == null)
            {
                promo = Instructor_Promocion.NewChild(Entity);
                promo.MarkItemNew();

                promo.OidPromocion = oid_promocion;
                Entity.Promociones.AddItem(promo);
            }

            foreach (SubmoduloInfo item in submodulos)
            {
                Submodulo_Instructor_Promocion elem = Submodulo_Instructor_Promocion.NewChild(promo);
                elem.MarkItemNew();

                elem.OidPromocion = oid_promocion;
                elem.OidSubmodulo = item.Oid;
                elem.OidModulo = item.OidModulo;
                elem.OidInstructor = Entity.Oid;
                elem.Prioridad = (long)Prioridad_NUD.Value;

                if (!promo.Submodulos.IsDuplicated(elem))
                    promo.Submodulos.AddItem(elem);
            }

            _action_result = DialogResult.OK;
            Close();

        }

        /// <summary>
        /// Implementa Undo_button_Click
        /// </summary>
        protected override void CancelAction()
        {
            if (!IsModal)
                _entity.CancelEdit();
            _action_result = DialogResult.Cancel;

            Cerrar();
        }

        #endregion

        #region Events

        private void CapacidadActionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Esta función solo se llama si se le da a la X o
            // se el formulario es modal
            if (!this.IsModal)
            {
                e.Cancel = true;
                Entity.CancelEdit();
            }

            Cerrar();

        }

        #endregion


    }
}

