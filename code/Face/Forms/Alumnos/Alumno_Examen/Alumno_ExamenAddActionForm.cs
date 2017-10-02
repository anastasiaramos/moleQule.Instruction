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
    public partial class Alumno_ExamenAddActionForm : ActionSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 3; } }

        public const string ID = "Alumno_ExamenAddActionForm";
        public static Type Type { get { return typeof(Alumno_ExamenAddActionForm); } }

        protected Alumno _entity;
        protected Alumno_Examen _alumno_examen;
        protected ExamenInfo _examen;

        public Alumno Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }
        public Alumno_Examen AlumnoExamen
        {
            get { return _alumno_examen; }
            set { _alumno_examen = value; }
        }

        protected Library.Instruction.HComboBoxSourceList _combo_opciones;
        protected Library.Instruction.HComboBoxSourceList _combo_examenes;
        protected ExamenList _examenes = null;
        protected PreguntaExamenList _preguntas = null;

        #endregion

        #region Factory Methods

        public Alumno_ExamenAddActionForm() : this(true) { }

        public Alumno_ExamenAddActionForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.ALUMNO_EXAMEN_ADD_TITLE;
        }

        public void SetSourceData(Alumno item)
        {
            _entity = item;
            _alumno_examen = Alumno_Examen.NewChild(_entity);
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

        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            if (_alumno_examen != null)
            {
                Datos.DataSource = _alumno_examen;
                PgMng.Grow();

                Datos_Respuestas.DataSource = Respuesta_Alumno_Examenes.SortList(_alumno_examen.Respuestas,
                                                                                   "Orden",
													                                ListSortDirection.Ascending);
                PgMng.Grow();
            }
        }

        public override void RefreshSecondaryData()
        {
            _combo_opciones = new Library.Instruction.HComboBoxSourceList();
            _combo_opciones.Add(new ComboBoxSource(1, ""));
            _combo_opciones.Add(new ComboBoxSource(2, "A"));
            _combo_opciones.Add(new ComboBoxSource(3, "B"));
            _combo_opciones.Add(new ComboBoxSource(4, "C"));
            Datos_Opciones.DataSource = _combo_opciones;
            PgMng.Grow();
        }

        protected void SetUnlinkedGridValues(string gridName)
        {
            /*switch (gridName)
            {
                case "Respuestas_Grid":
                    {
                        foreach (DataGridViewRow row in Respuestas_Grid.Rows)
                        {
                            if (row.IsNewRow) continue;
                            
                            Respuesta_Alumno_Examen info = (Respuesta_Alumno_Examen)row.DataBoundItem;
                            
                            if (info != null)
                            {
                                PreguntaExamenInfo pregunta = _preguntas.GetItem(info.OidPreguntaExamen);
                                
                                if (pregunta != null)
                                {
                                    foreach (RespuestaExamenInfo resp in pregunta.RespuestaExamens)
                                    {
                                        if (resp.Opcion == info.Opcion)
                                        {
                                            if (resp.Correcta)
                                            {
                                                row.Cells["Correcta"].Value = true;
                                                info.Correcta = true;
                                            }
                                            else info.Correcta = false;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    } break;
            }*/
        }

        private void SetPreguntas()
        {
            _examen = ExamenInfo.Get(_examen.Oid, true);
            _preguntas = _examen.PreguntaExamenes;

            Respuesta_Alumno_Examen respuesta;

            foreach (PreguntaExamenInfo item in _preguntas)
            {
                respuesta = _alumno_examen.Respuestas.NewItem(_alumno_examen);
                respuesta.OidPreguntaExamen = item.Oid;
                respuesta.Orden = item.Orden;
                respuesta.Pregunta = item.Texto;
            }

            Datos_Respuestas.DataSource = Respuesta_Alumno_Examenes.SortList(   _alumno_examen.Respuestas,
                                                                                "Orden", 
                                                                                ListSortDirection.Ascending);
         }

        #endregion

        #region Actions

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SubmitAction()
        {
            _entity.AlumnoExamens.AddItem(_alumno_examen);
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

        #region Buttons

        private void Examen_BT_Click(object sender, EventArgs e)
        {
            ExamenSelectForm form = new ExamenSelectForm(this);
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                _examen = form.Selected as ExamenInfo;
                Examen_TB.Text = _examen.Titulo;
                SetPreguntas();
            }
        }

        #endregion

        #region Events

        private void Alumno_ExamenActionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cerrar();
        }

        private void Respuestas_Grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetUnlinkedGridValues(Respuestas_Grid.Name);
        }

        private void Respuestas_Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            switch (Respuestas_Grid.Columns[e.ColumnIndex].Name)
            {
                case "Opcion_CBC":

                    Respuesta_Alumno_Examen respuesta = (Respuesta_Alumno_Examen)Respuestas_Grid.Rows[e.RowIndex].DataBoundItem;
                    if (respuesta != null)
                    {
                        PreguntaExamenInfo pregunta = _preguntas.GetItem(respuesta.OidPreguntaExamen);
                        if (pregunta != null)
                        {
                            respuesta.Correcta = false;

                            foreach (RespuestaExamenInfo resp in pregunta.RespuestaExamenes)
                            {
                                if (resp.Opcion == respuesta.Opcion)
                                {
                                    if (resp.Correcta) respuesta.Correcta = true;
                                    break;
                                }
                            }
                        }
                    }

                    Datos_Respuestas.ResetBindings(false);

                    break;
            }
        }

        #endregion



    }
}

