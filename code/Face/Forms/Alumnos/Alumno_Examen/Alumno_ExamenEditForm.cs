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
    public partial class Alumno_ExamenEditForm : Alumno_ExamenUIForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps; } }

        public new const string ID = "Alumno_ExamenEditForm";
        public new static Type Type { get { return typeof(Alumno_ExamenEditForm); } }

        #endregion

        #region Factory Methods

        public Alumno_ExamenEditForm() : base(true) { }

        public void SetSourceData(Alumno item, Alumno_Examen alumno_examen)
        {
            _entity = item;
            _alumno_examen = alumno_examen;
            //_alumno_examen.LoadChilds(typeof(Respuesta_Alumno_Examenes), false);
            _examen = ExamenInfo.Get(_alumno_examen.OidExamen, true);
            
            RefreshMainData();
        }

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();

            Examen_BT.Enabled = false;            
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            if (_examen != null)
            {
                Examen_TB.Text = _examen.Titulo;
                SetRespuestas();
            }

            base.RefreshMainData();
        }

        #endregion

        #region Buttons

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SubmitAction()
        {
            if (_entity.AlumnoExamens != null && _entity.AlumnoExamens.Count > 0)
            {
                int i = _entity.AlumnoExamens.IndexOf(_entity.AlumnoExamens.GetItem(_alumno_examen.Oid));
                _entity.AlumnoExamens[i] = _alumno_examen;
            }
            _action_result = DialogResult.OK;
            Close();
        }

        protected override void SetRespuestas()
        {
            if (_alumno_examen.Respuestas.Count == 0)
                base.SetRespuestas();
            else
            {
                foreach (Respuesta_Alumno_Examen item in _alumno_examen.Respuestas)
                {
                    if (_examen.PreguntaExamenes.Contains(item.OidPreguntaExamen))
                        item.Pregunta = _examen.PreguntaExamenes.GetItem(item.OidPreguntaExamen).Texto;
                }
            }
        }

        #endregion

        #region Events

        #endregion

    }
}

