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
    public partial class DuplicarPreguntasTemaActionForm : ActionSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 1; } }

        public const string ID = "DuplicarPreguntasActionForm";
        public static Type Type { get { return typeof(DuplicarPreguntasTemaActionForm); } }
        public override Type EntityType { get { return typeof(Pregunta); } }


        protected Library.Instruction.HComboBoxSourceList _combo_temas;

        #endregion

        #region Factory Methods

        public DuplicarPreguntasTemaActionForm()
            : this(true, null) { }

        public DuplicarPreguntasTemaActionForm(Form parent)
            : this(true, parent) { }

        public DuplicarPreguntasTemaActionForm(bool IsModal, Form parent)
            : base(IsModal, parent)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.DUPLICAR_PREGUNTAS_TEMA_TITLE;
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
            TemaList temas = TemaList.GetList(false);
            _combo_temas = new Library.Instruction.HComboBoxSourceList(temas);

            Datos_Tema_Origen.DataSource = _combo_temas;
            PgMng.Grow();

            Datos_Tema_Destino.DataSource = _combo_temas;
        }

        #endregion

        #region Buttons

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SubmitAction()
        {
            if (((ComboBoxSource)Tema_O_CB.SelectedItem).Oid == 0
                || ((ComboBoxSource)Tema_D_CB.SelectedItem).Oid == 0)
            {
                MessageBox.Show("Debe seleccionar temas de origen y destino válidos");
                return;
            }

            if (((ComboBoxSource)Tema_O_CB.SelectedItem).Oid == 
                ((ComboBoxSource)Tema_D_CB.SelectedItem).Oid)
            {
                MessageBox.Show("Debe seleccionar temas de origen y destino diferentes");
                return;
            }

            Tema.CompletaDuplicado(((ComboBoxSource)Tema_O_CB.SelectedItem).Oid, ((ComboBoxSource)Tema_D_CB.SelectedItem).Oid);

            PgMng.ShowInfoException(Resources.Messages.TEMA_DUPLICADO_OK);

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

        private void DuplicarCapacidadActionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Esta función solo se llama si se le da a la X o
            // se el formulario es modal
            if (!this.IsModal)
            {
                e.Cancel = true;
            }

            Cerrar();

        }

        #endregion


    }
}

