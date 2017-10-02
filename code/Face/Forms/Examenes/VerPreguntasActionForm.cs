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
    public partial class VerPreguntasActionForm : ActionSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return 3; } }

        public const string ID = "VerPreguntasActionForm";
        public static Type Type { get { return typeof(VerPreguntasActionForm); } }

        private PreguntaExamens _preguntas;
        private RespuestaExamens _respuestas;

        #endregion

        #region Factory Methods

        public VerPreguntasActionForm(bool IsModal, PreguntaExamens preguntas)
            : base(IsModal)
        {
            InitializeComponent();
            _preguntas = preguntas;
            SetFormData();
            this.Text = Resources.Labels.VER_PREGUNTAS_TITLE;
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
            Datos_Preguntas.DataSource = _preguntas;
            PgMng.Grow();

            SetRespuestas();
            PgMng.FillUp();

        }

        private void SetRespuestas()
        {
            if (Datos_Preguntas.Current != null)
            {
                _respuestas = ((PreguntaExamen)Datos_Preguntas.Current).RespuestaExamens;

                RespuestaA_TB.Text = string.Empty;
                RespuestaB_TB.Text = string.Empty;
                RespuestaC_TB.Text = string.Empty;
                CorrectaA_CB.Checked = false;
                CorrectaB_CB.Checked = false;
                CorrectaC_CB.Checked = false;

                foreach (RespuestaExamen respuesta in _respuestas)
                {
                    switch (respuesta.Opcion)
                    {
                        case "A":
                            {
                                RespuestaA_TB.Text = respuesta.Texto;
                                CorrectaA_CB.Checked = respuesta.Correcta;
                            }
                            break;
                        case "B":
                            {
                                RespuestaB_TB.Text = respuesta.Texto;
                                CorrectaB_CB.Checked = respuesta.Correcta;
                            }
                            break;
                        case "C":
                            {
                                RespuestaC_TB.Text = respuesta.Texto;
                                CorrectaC_CB.Checked = respuesta.Correcta;
                            }
                            break;
                    }
                }
            }
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

        private void VerPreguntasActionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           Cerrar();
        }
        
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            SetRespuestas();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            SetRespuestas();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            SetRespuestas();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            SetRespuestas();
        }

        #endregion


    }
}

