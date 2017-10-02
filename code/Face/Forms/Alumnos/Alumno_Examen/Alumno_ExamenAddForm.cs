using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin01;

using moleQule.Library.Instruction; 


namespace moleQule.Face.Instruction
{
    public partial class Alumno_ExamenAddForm : Alumno_ExamenUIForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps; } }

        public new const string ID = "Alumno_ExamenAddForm";
        public new static Type Type { get { return typeof(Alumno_ExamenAddForm); } }

        #endregion

        #region Factory Methods

        public Alumno_ExamenAddForm() : base(true) { }

        public void SetSourceData(Alumno item)
        {
            _entity = item;
            _alumno_examen = _entity.AlumnoExamens.NewItem(_entity);
            
            RefreshMainData();
        }

        #endregion

        #region Style & Source

        protected override void SetUnlinkedGridValues(string gridName)
        {
            switch (gridName)
            {
                case "Respuestas_Grid":
                    
                    foreach (DataGridViewRow row in Respuestas_Grid.Rows)
                    {
                        if (row.IsNewRow) continue;                            

                        Respuesta_Alumno_Examen item = row.DataBoundItem as Respuesta_Alumno_Examen;
                        if (item == null) continue;

                        PreguntaExamenInfo pregunta = _examen.PreguntaExamenes.GetItem(item.OidPreguntaExamen);
                        if (pregunta == null) continue;

                        foreach (RespuestaExamenInfo resp in pregunta.RespuestaExamenes)
                        {
                            if (resp.Correcta) 
                            {
                                item.OpcionCorrecta = resp.Opcion;
                                continue;
                            }
                        }
                    }

                break;
            }
        }

        #endregion

        #region Actions

        /// <summary>
        /// Implementa Undo_button_Click
        /// </summary>
        protected override void CancelAction()
        {
            _entity.AlumnoExamens.Remove(_alumno_examen);
            _action_result = DialogResult.Cancel;
            Close();
        }

        #endregion

        #region Buttons

        #endregion

        #region Events

        #endregion

    }
}

