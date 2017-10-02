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
    public partial class RespuestasActionForm : ActionSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return 15; } }

        public const string ID = "RespuestasActionForm";
        public static Type Type { get { return typeof(RespuestasActionForm); } }

        /// <summary>
        /// Se trata de la empresa actual y que se va a editar.
        /// </summary>
        private Pregunta _entity;

        public Pregunta Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        #endregion

        #region Factory Methods

        public RespuestasActionForm(Pregunta item)
            : this(item, true) {}

        public RespuestasActionForm(Pregunta item, bool IsModal)
            : base(IsModal)
        {
            _entity = item;
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.RESPUESTAS_TITLE;
        }

        public void SetSourceData(Pregunta item)
        {
            _entity = item;
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
            if (_entity != null)
                Datos_Respuesta.DataSource = Respuestas.SortList(_entity.Respuestas, "Opcion", ListSortDirection.Ascending);

            Library.Instruction.HComboBoxSourceList _combo_opciones = new Library.Instruction.HComboBoxSourceList();
            _combo_opciones.Add(new ComboBoxSource(1,"A"));
            _combo_opciones.Add(new ComboBoxSource(2,"B"));
            _combo_opciones.Add(new ComboBoxSource(3,"C"));
            Datos_Opciones.DataSource = _combo_opciones;
        }

        #endregion

        #region Buttons

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SubmitAction()
        {
            bool correcta = false;

            for (int i = 0; i< _entity.Respuestas.Count;i++)
            {
                if (_entity.Respuestas[i].Correcta)
                {
                    if (!correcta)
                        correcta = true;
                    else
                    {
                        MessageBox.Show("Se ha marcado más de una respuesta como correcta");
                        return;
                    }
                }
                for (int j = i + 1; j < _entity.Respuestas.Count; j++)
                {
                    if (_entity.Respuestas[i].Opcion == _entity.Respuestas[j].Opcion)
                    {
                        MessageBox.Show("La opción debe ser única para cada respuesta");
                        return;
                    }
                }
                if (_entity.Respuestas[i].Opcion == string.Empty)
                {
                    MessageBox.Show("Debe asociar una opción a cada respuesta");
                    return;
                }
            }

            if (!correcta && Entity.Tipo == "Test")
            {
                MessageBox.Show("No se ha marcado ninguna respuesta como correcta");
                return;
            }

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

        private void RespuestasActionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsModal)
            {
                e.Cancel = true;
                _entity.CancelEdit();
            }

            Cerrar();
        }

        #endregion


    }
}

