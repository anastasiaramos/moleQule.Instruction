using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin01;

using moleQule.Library.Common;
using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class PlantillaDesarrolloViewForm : ItemMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 3; } }

        public ModuloList _modulos;

        protected PlantillaExamenInfo _entity;
        private long _propuesto = 0;

        public PlantillaExamenInfo EntityInfo { get { return (_entity != null) ? _entity : null; } }

        #endregion

        #region Factory Methods

        public PlantillaDesarrolloViewForm(long oid) : this(oid, true) {}

        public PlantillaDesarrolloViewForm(long oid, bool isModal)
            : base(oid, isModal)
        {
            InitializeComponent();

            if (EntityInfo != null)
            {
                SetFormData();
                this.Text = Resources.Labels.PLANTILLA_EXAMEN_EDIT_TITLE;
            }

            _mf_type = ManagerFormType.MFView;
        }

        public PlantillaDesarrolloViewForm(PlantillaExamenInfo source)
            : base()
        {
            InitializeComponent();

            _entity = source.Clone();
            SetFormData();
            _mf_type = ManagerFormType.MFView;
            this.Text = Resources.Labels.PLANTILLA_EXAMEN_EDIT_TITLE;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = PlantillaExamenInfo.Get(oid, false);
            _mf_type = ManagerFormType.MFView; 
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
            Datos.DataSource = _entity;
            PgMng.Grow();
        }


        #endregion

        #region Validation & Format

        #endregion

        #region Print

        #endregion

        #region Actions

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SaveAction()
        {
            Close();
        }

        protected override void CancelAction()
        {
            Close();
        }

        #endregion

        #region Events
                
        #endregion

    }
}


