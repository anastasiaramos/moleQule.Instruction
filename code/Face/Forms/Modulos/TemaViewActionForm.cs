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
    public partial class TemaViewActionForm : ActionSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return 15; } }

        public const string ID = "TemaViewActionForm";
        public static Type Type { get { return typeof(TemaViewActionForm); } }

        /// <summary>
        /// Se trata de la empresa actual y que se va a editar.
        /// </summary>
        private SubmoduloInfo _entity;

        public SubmoduloInfo Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        #endregion

        #region Factory Methods

        public TemaViewActionForm(SubmoduloInfo item)
            : this(item, true) { }

        public TemaViewActionForm(SubmoduloInfo item, bool IsModal)
            : base(IsModal)
        {
            _entity = item;
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.TEMA_TITLE;
        }

        public void SetSourceData(SubmoduloInfo item)
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
            if (_entity != null)
                Datos.DataSource = TemaList.SortList(_entity.Temas, "CodigoOrden", ListSortDirection.Ascending);
        }

        #endregion

        #region Buttons

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SubmitAction()
        {
            _action_result = DialogResult.OK;
            Close();

        }

        /// <summary>
        /// Implementa Undo_button_Click
        /// </summary>
        protected override void CancelAction()
        {
            _action_result = DialogResult.Cancel;
            Cerrar();
        }

        #endregion

        #region Events

        private void TemaActionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cerrar();
        }

        #endregion


    }
}

