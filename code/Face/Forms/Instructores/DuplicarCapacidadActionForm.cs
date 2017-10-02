using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin01;

using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class DuplicarCapacidadActionForm : ActionSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 1; } }

        public const string ID = "DuplicarCapacidadActionForm";
        public static Type Type { get { return typeof(DuplicarCapacidadActionForm); } }

        /// <summary>
        /// Se trata de la empresa actual y que se va a editar.
        /// </summary>
        private Instructor _entity;

        public Instructor Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        protected Library.Instruction.HComboBoxSourceList _combo_promociones;

        #endregion

        #region Factory Methods

        public DuplicarCapacidadActionForm()
            : this(true) { }

        public DuplicarCapacidadActionForm(bool IsModal)
            : base(IsModal)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.DUPLICAR_CAPACIDAD_TITLE;
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
            PromocionList promociones = PromocionList.GetList(false);
            _combo_promociones = new Library.Instruction.HComboBoxSourceList(promociones);

            Datos_Promocion_Origen.DataSource = _combo_promociones;
            PgMng.Grow();

            Datos_Promocion_Destino.DataSource = _combo_promociones;
        }

        #endregion

        #region Buttons

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SubmitAction()
        {
            if (((ComboBoxSource)Promocion_O_CB.SelectedItem).Oid == 0
                || ((ComboBoxSource)Promocion_D_CB.SelectedItem).Oid == 0)
            {
                MessageBox.Show("Debe seleccionar promociones de origen y destino válidas");
                return;
            }

            if (((ComboBoxSource)Promocion_O_CB.SelectedItem).Oid == 
                ((ComboBoxSource)Promocion_D_CB.SelectedItem).Oid)
            {
                MessageBox.Show("Debe seleccionar promociones de origen y destino diferentes");
                return;
            }

            Submodulos_Instructores_Promociones capacidad_origen = Entity.Promociones.GetByOidPromocion(((ComboBoxSource)Promocion_O_CB.SelectedItem).Oid).Submodulos;
            long oid_promocion = ((ComboBoxSource)Promocion_D_CB.SelectedItem).Oid;

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

            foreach (Submodulo_Instructor_Promocion item in capacidad_origen)
            {
                Submodulo_Instructor_Promocion elem = Submodulo_Instructor_Promocion.NewChild(promo);
                elem.MarkItemNew();

                elem.OidPromocion = oid_promocion;
                elem.OidSubmodulo = item.OidSubmodulo;
                elem.OidModulo = item.OidModulo;
                elem.OidInstructor = item.OidInstructor;
                elem.Prioridad = item.Prioridad;

                if (!promo.Submodulos.IsDuplicated(elem))
                    promo.Submodulos.Add(elem);
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

        private void DuplicarCapacidadActionForm_FormClosing(object sender, FormClosingEventArgs e)
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

