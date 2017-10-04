using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;
using Csla;

using moleQule.Face;
using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class PreguntasEmitidasViewForm : Skin01.ListMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 7; } }

        protected Library.Instruction.HComboBoxSourceList _combo_modulos;
        protected Library.Instruction.HComboBoxSourceList _combo_tipo;
        protected Library.Instruction.HComboBoxSourceList _combo_idioma;
        protected bool _cambiado = false;
        protected SubmoduloList _submodulos;
        protected TemaList _temas;

        protected PreguntaExamen _pregunta;
        public PreguntaExamens _lista_info = null;
        private PreguntaList _lista_preguntas = null;

        public virtual PreguntaExamens Lista { get { return _lista_info; } set { _lista_info = value; } }

        #endregion

        #region Factory Methods
        
        public PreguntasEmitidasViewForm()
            : this(true) { }

        public PreguntasEmitidasViewForm(bool ismodal)
            : base(ismodal)
        {
            InitializeComponent();
            if (Lista != null)
            {
                SetFormData();
                this.Text = Resources.Labels.PREGUNTA_EDIT_TITLE;
            }
            _mf_type = ManagerFormType.MFView;
        }

        public PreguntasEmitidasViewForm(long oid, PreguntaExamens preguntas, PreguntaList lista, bool ismodal)
            : base(ismodal)
        {
            InitializeComponent();
            Lista = preguntas;
            _lista_preguntas = lista;
            _pregunta = Lista.GetItem(oid);
            if (Lista != null)
            {
                SetFormData();
                this.Text = Resources.Labels.PREGUNTA_EDIT_TITLE;
            }
            _mf_type = ManagerFormType.MFView;
        }


        protected override void GetFormSourceData()
        {
            //ListaInfo = PreguntaList.GetList();
            _mf_type = ManagerFormType.MFEdit;
        }

        #endregion

        #region Style & Source

        public override void RefreshSecondaryData()
        {
            ModuloList modulos = ModuloList.GetList(false);
            _combo_modulos = new Library.Instruction.HComboBoxSourceList(modulos);
            PgMng.Grow();

            _submodulos = SubmoduloList.GetList(false);
            Library.Instruction.HComboBoxSourceList _combo_submodulos = new Library.Instruction.HComboBoxSourceList(_submodulos);
            _combo_modulos.Childs = _combo_submodulos;
            Datos_Modulos.DataSource = _combo_modulos;
            PgMng.Grow();

            _temas = TemaList.GetList(false);
            Library.Instruction.HComboBoxSourceList _combo_temas = new Library.Instruction.HComboBoxSourceList(_temas);
            _combo_modulos.Childs = _combo_temas;
            PgMng.Grow();

            //_combo_tipo = new Library.Instruction.HComboBoxSourceList();
            //_combo_tipo.Add(new ComboBoxSource(1,"Desarrollo"));
            //_combo_tipo.Add(new ComboBoxSource(2,"Test"));
            Datos_Tipos.DataSource = Library.Instruction.EnumText<ETipoPregunta>.GetList();//_combo_tipo;
            PgMng.Grow();

            //Library.Instruction.HComboBoxSourceList _combo_idiomas = new Library.Instruction.HComboBoxSourceList();
            //_combo_idiomas.Add(new ComboBoxSource(1, "Español"));
            //_combo_idiomas.Add(new ComboBoxSource(2, "Inglés"));
            Datos_Idiomas.DataSource = Library.Common.EnumText<EIdioma>.GetList();//_combo_idiomas;
            PgMng.Grow();
        }

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            SetReadOnlyControls(this.Controls);
            Cancel_BT.Enabled = false;
            Cancel_BT.Visible = false;
            base.FormatControls();
            Anterior_BT.Enabled = true;
            Siguiente_BT.Enabled = true;
            
            Imagen_PictureBox.Enabled = true;
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            if (_pregunta != null) Datos.DataSource = _pregunta;
            PgMng.Grow();

            Images.Show(_pregunta.ImagenWithPath, Imagen_PictureBox);
            PgMng.Grow();

            if (_lista_preguntas != null && _lista_preguntas.Count > 0)
            {
                PreguntaInfo item = _lista_preguntas.GetItem(_pregunta.OidPregunta);
                Numero_TB.Text = item.Codigo;
            }

            SortedBindingList<RespuestaExamen> ordenadas = RespuestaExamens.SortList(_pregunta.RespuestaExamens, "Opcion", ListSortDirection.Ascending);
            List<RespuestaExamen> lista = new List<RespuestaExamen>();

            foreach (RespuestaExamen item in ordenadas)
            {
                if ((_pregunta.Tipo == "Test")
                    || (item.Texto != string.Empty
                    && item.Texto != "."))
                    lista.Add(item);
            }

            Datos_Respuestas.DataSource = lista;
        }

        protected void SetPreguntaSiguiente()
        {
            int index = Lista.IndexOf(_pregunta);
            if (index < Lista.Count - 1)
            {
                _pregunta = Lista.GetItem(Lista[index + 1].Oid);
                RefreshMainData();
            }
            SetDependentControlSource(Modulo_CB.Name);
        }

        protected void SetPreguntaAnterior()
        {
            int index = Lista.IndexOf(_pregunta);
            if (index > 0)
            {
                _pregunta = Lista.GetItem(Lista[index - 1].Oid);
                RefreshMainData();
            }
            SetDependentControlSource(Modulo_CB.Name);
        }

        protected void ShowImagen()
        {
            ImagenPreguntaViewForm form = new ImagenPreguntaViewForm(true, _pregunta.ImagenWithPath);
            form.ShowDialog();
        }

        /// <summary>
        /// Asigna los datos de origen para controles que dependen de otros
        /// </summary>
        /// <param name="controlName"></param>
        protected override void SetDependentControlSource(string controlName)
        {
            switch (controlName)
            {
                case "Modulo_CB":
                    {
                        if (Modulo_CB.SelectedItem != null && ((ComboBoxSource)Modulo_CB.SelectedItem).Oid != 0)
                        {
                            Datos_Temas.DataSource = _combo_modulos.GetFilteredChilds(((ComboBoxSource)Modulo_CB.SelectedItem).Oid);
                            Tema_CB.SelectedItem = _combo_modulos.Childs.Buscar(_pregunta.OidTema);
                        }

                    } break;
                case "Tema_CB":
                    {
                        if (_pregunta != null)
                        {
                            TemaInfo tema = _temas.GetItem(_pregunta.OidTema);

                            if (tema.Desarrollo)
                                Tipo_CB.SelectedIndex = 1;
                            else
                                Tipo_CB.SelectedIndex = 2;
                            Nivel_TB.Text = tema.Nivel.ToString();
                        }

                    } break;
            }
        }

        #endregion

        #region Validation & Format

        #endregion

        #region Actions

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SaveAction()
        {
            _action_result = DialogResult.Cancel;
            Close();
        }

        #endregion

        #region Print

        #endregion

        #region Events

        private void PreguntasForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            PgMng.FillUp();
            Cerrar();
        }

        private void Modulo_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDependentControlSource(Modulo_CB.Name);
        }

        private void Tema_CB_SelectedValueChanged(object sender, EventArgs e)
        {
            SetDependentControlSource(Tema_CB.Name);
        }

        private void Anterior_BT_Click(object sender, EventArgs e)
        {
            SetPreguntaAnterior();
        }

        private void Siguiente_BT_Click(object sender, EventArgs e)
        {
            SetPreguntaSiguiente();
        }

        private void Imagen_PictureBox_DoubleClick(object sender, EventArgs e)
        {
            ShowImagen();
        }

        #endregion

        private void ModeloRespuestaView_BT_Click(object sender, EventArgs e)
        {
            if (_pregunta.ModeloRespuesta != string.Empty)
                System.Diagnostics.Process.Start(_pregunta.ModeloRespuestaPath);
        }

        private void PreguntasEmitidasViewForm_Activated(object sender, EventArgs e)
        {
            if (_pregunta.Tipo == "Desarrollo")
            {
                Respuestas_Grid.Visible = false;
                Respuestas_Grid.Enabled = false;
                ModeloRespuesta_LB.Visible = true;
                ModeloRespuesta_LB.Enabled = true;
                ModeloRespuesta_TB.Visible = true;
                ModeloRespuesta_TB.Enabled = true;
                ModeloRespuestaView_BT.Visible = true;
                ModeloRespuestaView_BT.Enabled = true;
            }
            else
            {
                Respuestas_Grid.Visible = true;
                Respuestas_Grid.Enabled = true;
                ModeloRespuesta_LB.Visible = false;
                ModeloRespuesta_LB.Enabled = false;
                ModeloRespuesta_TB.Visible = false;
                ModeloRespuesta_TB.Enabled = false;
                ModeloRespuestaView_BT.Visible = false;
                ModeloRespuestaView_BT.Enabled = false;
            }
        }

    }
}

