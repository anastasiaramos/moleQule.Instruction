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
    public partial class PreguntasPlantillaInputForm : InputSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return 15; } }

        public const string ID = "PreguntasPlantillaInputForm";
        public static Type Type { get { return typeof(PreguntasPlantillaInputForm); } }

        /// <summary>
        /// Se trata de la empresa actual y que se va a editar.
        /// </summary>
        private PlantillaExamen _entity;
        private int _index = 0;

        public PlantillaExamen Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        #endregion

        #region Factory Methods

        public PreguntasPlantillaInputForm()
            : this(true, null, 0) { }

        public PreguntasPlantillaInputForm(bool IsModal, PlantillaExamen item, int index)
            : base(IsModal)
        {
            InitializeComponent();
            _entity = item;
            _index = index;
            SetFormData();
            this.Text = Resources.Labels.PREGUNTAS_PLANTILLA_TITLE;
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
            NPreguntas_TB.Text = Entity.Preguntas[_index].NPreguntas.ToString();
            PgMng.FillUp();
        }

        #endregion

        #region Buttons

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SubmitAction()
        {
            if (NPreguntas_TB.Text != string.Empty)
            {
                if (Convert.ToInt64(NPreguntas_TB.Text) < 0)
                {
                    MessageBox.Show("El valor introducido debe ser mayor o igual que cero.");
                    return;
                }

                Preguntas_Plantilla p = Entity.Preguntas[_index];
                p.NPreguntas = Convert.ToInt64(NPreguntas_TB.Text);
                Entity.Preguntas[_index] = p;

                _action_result = DialogResult.OK;
                Close();
            }

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

        private void PreguntasPlantillaInputForm_FormClosing(object sender, FormClosingEventArgs e)
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

