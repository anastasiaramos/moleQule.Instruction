using System;
using System.Windows.Forms;

using Csla;

using moleQule.Face;

using moleQule.Library.Instruction;

namespace moleQule.Face.Instruction
{
    public partial class PreguntasEditForm : PreguntasUIForm
    {

        #region Factory Methods

        public PreguntasEditForm(Pregunta pregunta, SortedBindingList<Pregunta> preguntas, bool ismodal)
            : base(ismodal)
        {
            InitializeComponent();

            Lista = preguntas;
            _pregunta = pregunta;
            _copia_pregunta = _pregunta.Clone();
            if (Lista != null)
            {
                SetFormData();
                this.Text = Resources.Labels.PREGUNTA_EDIT_TITLE;
            }
            _mf_type = ManagerFormType.MFEdit;

            int index = Lista.IndexOf(_pregunta);
            EnableButtons(index);
        }

        protected override void GetFormSourceData()
        {
        }

        #endregion

        #region Buttons

        /// <summary>
        /// Implementa Undo_button_Click
        /// </summary>
        protected override void CancelAction()
        {
            _pregunta.CancelEdit();
            // Decomentar si se mantiene oculto en memoria
            //Entity.BeginEdit();

            if (!this.IsModal)
            {
                //foreach (PreguntaInfo item in Lista)
                //Lista.CloseSession();
            }
            _action_result = DialogResult.Cancel;
            
            Close();
        }

        #endregion

    }
}
