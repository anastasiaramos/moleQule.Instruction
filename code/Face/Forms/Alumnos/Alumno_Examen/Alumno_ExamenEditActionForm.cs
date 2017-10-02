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
    public partial class Alumno_ExamenEditActionForm : ActionSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 4; } }

        public const string ID = "Alumno_ExamenEditActionForm";
        public static Type Type { get { return typeof(Alumno_ExamenEditActionForm); } }

        /// <summary>
        /// Se trata de la empresa actual y que se va a editar.
        /// </summary>
        protected Alumno _entity;
        protected Alumno_Examen _examen;

        public Alumno Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }
        public Alumno_Examen Examen
        {
            get { return _examen; }
            set { _examen = value; }
        }

        protected Library.Instruction.HComboBoxSourceList _combo_opciones;
        protected Library.Instruction.HComboBoxSourceList _combo_examenes;
        protected ExamenList _examenes = null;

        #endregion

        #region Factory Methods

        public Alumno_ExamenEditActionForm() : this(true) { }

        public Alumno_ExamenEditActionForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.ALUMNO_EXAMEN_EDIT_TITLE;
        }

        public void SetSourceData(Alumno item, Alumno_Examen examen)
        {
            _entity = item;
            _examen = examen;
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
            if (_examen != null)
            {
                Datos.DataSource = _examen;
                PgMng.Grow();

                Datos_Respuestas.DataSource = Respuesta_Alumno_Examenes.SortList(_examen.Respuestas,
                                                                                   "Orden",
                                                                                    ListSortDirection.Ascending);
                PgMng.Grow();
            }
        }

        public override void RefreshSecondaryData()
        {
            _examenes = ExamenList.GetList(false);
            _combo_examenes = new Library.Instruction.HComboBoxSourceList(_examenes);
            Datos_Examenes.DataSource = _combo_examenes;
            PgMng.Grow();

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
            switch (gridName)
            {
                case "Respuestas_Grid":
                    PreguntaExamenList preguntas = ExamenInfo.Get(_examen.OidExamen).PreguntaExamenes;
                    foreach (DataGridViewRow row in Respuestas_Grid.Rows)
                    {
                        if (row.IsNewRow) continue;
                        Respuesta_Alumno_Examen info = (Respuesta_Alumno_Examen)row.DataBoundItem;
                        if (info != null)
                        {
                            PreguntaExamenInfo pregunta = preguntas.GetItem(info.OidPreguntaExamen);
                            if (pregunta != null)
                            {
                                row.Cells["Orden"].Value = pregunta.Orden;
                                row.Cells["Pregunta"].Value = pregunta.Texto;
                                row.Cells["Correcta"].Value = false;

                                foreach (RespuestaExamenInfo resp in pregunta.RespuestaExamenes)
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

                    break;
            }
        }

        #endregion

        #region Buttons

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SubmitAction()
        {
            int i = _entity.AlumnoExamens.IndexOf(_entity.AlumnoExamens.GetItem(_examen.Oid));
            _entity.AlumnoExamens[i] = _examen;
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

        private void Alumno_ExamenActionForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Respuestas_Grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetUnlinkedGridValues(Respuestas_Grid.Name);
        }

        private void Respuestas_Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            switch (Respuestas_Grid.Columns[e.ColumnIndex].Name)
            {
                case "Opcion_CBC":
                    {

                    } break;
            }
        }

        #endregion

    }
}

