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
    public partial class NotaDesarrolloAlumnoInputForm : InputSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return 15; } }

        public const string ID = "NotaDesarrolloAlumnoInputForm";
        public static Type Type { get { return typeof(NotaDesarrolloAlumnoInputForm); } }

        /// <summary>
        /// Se trata de la empresa actual y que se va a editar.
        /// </summary>
        private Examen _entity;
        private int _index = 0;

        public Examen Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        #endregion

        #region Factory Methods

        public NotaDesarrolloAlumnoInputForm()
            : this(true, null, 0, null) { }

        public NotaDesarrolloAlumnoInputForm(bool IsModal, Examen item, int index, AlumnoInfo alumno)
            : base(IsModal)
        {
            InitializeComponent();
            _entity = item;
            _index = index;
            if (alumno != null)
                Source_GB.Text = alumno.Apellidos + ", " + alumno.Nombre;
            SetFormData();
            this.Text = Resources.Labels.NOTA_ALUMNO_TITLE;
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
            //Nota_TB.Text = Entity.Alumnos[_index].Calificacion.ToString();
            Datos_Respuestas.DataSource = Entity.Alumnos[_index].Respuestas;
            Presentado_CB.Checked = Entity.Alumnos[_index].Presentado;
            PgMng.Grow();

            Observaciones_TB.Text = Entity.Alumnos[_index].Observaciones;         
            PgMng.FillUp();
        }

        #endregion

        #region Buttons

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SubmitAction()
        {
            Alumno_Examen p = Entity.Alumnos[_index];
            //try
            //{
            //    p.Calificacion = Convert.ToDecimal(Nota_TB.Text);
            //}
            //catch
            //{
            //    p.Calificacion = 0;
            //}
            p.Presentado = Presentado_CB.Checked;
            p.Observaciones = Observaciones_TB.Text;
            Entity.Alumnos[_index] = p;

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

