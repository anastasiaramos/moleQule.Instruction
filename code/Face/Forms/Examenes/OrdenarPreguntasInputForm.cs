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
    public partial class OrdenarPreguntasInputForm : InputSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return 15; } }

        public const string ID = "OrdenarPreguntasInputForm";
        public static Type Type { get { return typeof(OrdenarPreguntasInputForm); } }

        /// <summary>
        /// Se trata de la empresa actual y que se va a editar.
        /// </summary>
        private Examen _entity;
        private int _index;
        private int _count;

        public Examen Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        #endregion

        #region Factory Methods

        public OrdenarPreguntasInputForm()
            : this(true,0) { }

        public OrdenarPreguntasInputForm(bool IsModal, int pos)
            : base(IsModal)
        {
            InitializeComponent();
            _index = pos;
            SetFormData();
            this.Text = Resources.Labels.ORDENAR_PREGUNTAS_EXAMEN_TITLE;
        }

        public void SetSourceData(Examen item, int count)
        {
            _entity = item;
            _count = count;
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
            OrdenViejo_TB.Text = _index.ToString();
            PgMng.FillUp();
        }

        #endregion

        #region Buttons

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SubmitAction()
        {
            int orden_nuevo = 0;

            try 
            {
                orden_nuevo = Convert.ToInt16(OrdenNuevo_TB.Text);
            }
            catch 
            {
                MessageBox.Show("El valor introducido no es válido");
                return;
            }
            if (OrdenNuevo_TB.Text != string.Empty)
            {
                if (orden_nuevo > _count)
                {
                    MessageBox.Show("El valor introducido es menor que el número de preguntas del examen.");
                    return;
                }

                if (orden_nuevo < 1)
                {
                    MessageBox.Show("El valor introducido debe ser mayor que 0.");
                    return;
                }

                if (_index != orden_nuevo)
                {
                    Pregunta_Examens aux = _entity.Pregunta_Examens.Clone();
                    _entity.Pregunta_Examens = Pregunta_Examens.NewChildList();
                    Pregunta_Examen copia = aux[(int)_index - 1];
                    aux.RemoveAt((int)_index - 1);

                    bool insertada = false;
                    //se inserta la pregunta seleccionada en el nuevo índice 
                    //se van copiando las demás hasta encontrar el hueco donde se quiere insertar la seleccionada
                    foreach (Pregunta_Examen item in aux)
                    {
                        if (_entity.Pregunta_Examens.Count == orden_nuevo - 1)
                        {
                            _entity.Pregunta_Examens.AddItem(copia);
                            insertada = true;
                        }
                        _entity.Pregunta_Examens.AddItem(item);
                    }

                    if (!insertada) _entity.Pregunta_Examens.AddItem(copia);
                }

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

        private void PracticasActionForm_FormClosing(object sender, FormClosingEventArgs e)
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

