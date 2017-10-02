using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Library.Instruction;
using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class Alumno_ExamenUIForm : Skin01.ActionSkinForm
    {

        #region Attributes & Properties

        protected override int BarSteps { get { return base.BarSteps + 3; } }

        public const string ID = "Alumno_ExamenUIForm";
        public static Type Type { get { return typeof(Alumno_ExamenUIForm); } }

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

        protected int _validas = 0;
        protected int _incorrectas = 0;

        #endregion

        #region Factory Methods

        public Alumno_ExamenUIForm() : this(true) {}

        public Alumno_ExamenUIForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();
            SetFormData();
        }

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();

            Source_GB.Text = _entity != null ? Entity.Nombre.ToUpper() + " " + Entity.Apellidos.ToUpper() : string.Empty;
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
                GetValidas();
                CalculaNotaAction();
                PgMng.Grow();
            }
        }

        protected virtual void SetUnlinkedGridValues(string gridName)
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

                        item.Correcta = (item.Opcion == item.OpcionCorrecta);
                        row.Cells[OpcionCorrecta.Name].Style.BackColor = (item.Correcta) ? Color.LightGreen : Color.Red;
                    }

                break;
            }
        }

        protected virtual void SetRespuestas()
        {
            _alumno_examen.OidExamen = _examen.Oid;
            _examen = ExamenInfo.Get(_examen.Oid, true);

            Respuesta_Alumno_Examen respuesta;

            foreach (PreguntaExamenInfo item in _examen.PreguntaExamenes)
            {
                respuesta = _alumno_examen.Respuestas.NewItem(_alumno_examen);
                respuesta.OidPreguntaExamen = item.Oid;
                respuesta.Orden = item.Orden;
                respuesta.Pregunta = item.Texto;
                respuesta.Correcta = true;

                foreach(RespuestaExamenInfo resp in item.RespuestaExamenes)
                {
                    if (resp.Correcta)
                    {
                        respuesta.Opcion = resp.Opcion;
                        respuesta.OpcionCorrecta = resp.Opcion;
                    }
                }
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
            CalculaNotaAction();
            _action_result = DialogResult.OK;
            Close();
        }

        protected void CalculaNotaAction()
        {
            _incorrectas = 0;

            foreach (Respuesta_Alumno_Examen item in _alumno_examen.Respuestas)
            {
                PreguntaExamenInfo pregunta = _examen.PreguntaExamenes.GetItem(item.OidPreguntaExamen);

                if (!pregunta.Anulada)
                {
                    if (item.Opcion != item.OpcionCorrecta)
                        _incorrectas++;
                }
            }

            Incorrectas_TB.Text = _incorrectas.ToString();

            _alumno_examen.Calificacion = Decimal.Round((decimal)(_validas - _incorrectas) / _validas * 100, 2);

        }

        protected void GetValidas()
        {
            _validas = 0;

            foreach (Respuesta_Alumno_Examen item in _alumno_examen.Respuestas)
            {
                PreguntaExamenInfo pregunta = _examen.PreguntaExamenes.GetItem(item.OidPreguntaExamen);

                if (!pregunta.Anulada)
                    _validas++;
            }

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

                if (_entity.AlumnoExamens.GetItemByExamen(_examen.Oid) != null)
                {
                    MessageBox.Show("El examen seleccionado ya ha sido asignado previamente a este alumno",
                                    moleQule.Face.Resources.Labels.ADVISE_TITLE,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                    return;
                }
                
                Examen_TB.Text = _examen.Titulo;
                SetRespuestas();
            }
        }

        #endregion

        #region Events

        private void Alumno_ExamenUIForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cerrar();
        }

        private void Respuestas_Grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetUnlinkedGridValues(Respuestas_Grid.Name);
        }
        
        private void Calcular_BT_Click(object sender, EventArgs e)
        {
            CalculaNotaAction();
        }

        private void Respuestas_Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (Respuestas_Grid.Columns[e.ColumnIndex].Name)
            {
                case "Correcto_BC":

                    Respuesta_Alumno_Examen respuesta = (Respuesta_Alumno_Examen)Respuestas_Grid.Rows[e.RowIndex].DataBoundItem;
                    if (respuesta == null) return;

                    if (respuesta.Correcta)
                        respuesta.Opcion = string.Empty;
                    else
                        respuesta.Opcion = respuesta.OpcionCorrecta;

                    respuesta.Correcta = (respuesta.Opcion == respuesta.OpcionCorrecta);
                    Respuestas_Grid.Rows[e.RowIndex].Cells[OpcionCorrecta.Name].Style.BackColor = (respuesta.Correcta) ? Color.LightGreen : Color.Red;

                    CalculaNotaAction();

                    break;
            }

        }

        #endregion


    }
}

