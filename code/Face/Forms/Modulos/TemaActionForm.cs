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
    public partial class TemaActionForm : ActionSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return 15; } }

        public const string ID = "TemaActionForm";
        public static Type Type { get { return typeof(TemaActionForm); } }

        /// <summary>
        /// Se trata de la empresa actual y que se va a editar.
        /// </summary>
        private Submodulo _entity;

        public Submodulo Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        #endregion

        #region Factory Methods

        public TemaActionForm(Submodulo item)
            : this(item, true) { }

        public TemaActionForm(Submodulo item, bool IsModal)
            : base(IsModal)
        {
            _entity = item;
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.TEMA_TITLE;
        }

        public void SetSourceData(Submodulo item)
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
                Datos.DataSource = Temas.SortList(_entity.Temas, "CodigoOrden", ListSortDirection.Ascending);
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
            if (!IsModal)
                _entity.CancelEdit();
            _action_result = DialogResult.Cancel;

            Cerrar();
        }

        #endregion

        #region Events

        private void TemaActionForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Datos_CurrentItemChanged(object sender, EventArgs e)
        {
            if (((Tema)Datos.Current).Oid == Entity.Temas[0].Oid)
            {
                Codigo_TB.ReadOnly = true;
                Nombre_TB.ReadOnly = true;
                Delete_BT.Enabled = false;
                Delete_BT.Visible = false;
            }
            else
            {
                Codigo_TB.ReadOnly = false;
                Nombre_TB.ReadOnly = false;
                Delete_BT.Enabled = true;
                Delete_BT.Visible = true;
            }
        }

        #endregion

    }
}

