using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;

using moleQule.Library.Application;
using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class PreguntasViewForm : PreguntasForm
    {
        #region Business Methods

        public PreguntaList _lista_info = null;

        public override PreguntaList ListaInfo { get { return _lista_info; } set { _lista_info = value; } }

        #endregion

        #region Factory Methods

        public PreguntasViewForm()
            : this(true) { }

        public PreguntasViewForm(bool ismodal)
            : base(ismodal)
        {
            InitializeComponent();
            if (ListaInfo != null)
            {
                SetFormData();
                this.Text = Resources.Labels.PREGUNTA_EDIT_TITLE;
            }
            _mf_type = ManagerFormType.MFView;
        }

        public PreguntasViewForm(long oid, PreguntaList preguntas, bool ismodal)
            : base(ismodal)
        {
            InitializeComponent();
            ListaInfo = preguntas;
            _pregunta_info = PreguntaInfo.Get(oid,true);
            if (ListaInfo != null)
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

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            SetReadOnlyControls(this.Controls);
            Cancel_BT.Enabled = false;
            Cancel_BT.Visible = false;
            base.FormatControls();
            Respuestas_BT.Enabled = true;
            Anterior_BT.Enabled = true;
            Siguiente_BT.Enabled = true;
            Respuestas_BT.Visible = false;
            
            Imagen_PictureBox.Enabled = true;
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            if (_pregunta_info != null) Datos.DataSource = _pregunta_info;
            PgMng.Grow();

            Images.Show(_pregunta_info.Imagen, AppController.FOTOS_PREGUNTAS_PATH, Imagen_PictureBox);
            PgMng.Grow();

            RellenaHistoria();
            PgMng.Grow();

            Datos_Respuestas.DataSource = RespuestaList.SortList(_pregunta_info.Respuestas, "Opcion", ListSortDirection.Ascending);
            PgMng.Grow();

            base.RefreshMainData();
        }

        private void RellenaHistoria()
        {
            Historia_TB.Text = string.Empty;

            foreach (HistoriaInfo item in _pregunta_info.Historias)
                Historia_TB.Text += item.Texto + Environment.NewLine;
        }

        protected override void SetPreguntaSiguiente()
        {
            int index = ListaInfo.IndexOf(_pregunta_info);
            if (index < ListaInfo.Count - 1)
            {
                _pregunta_info = PreguntaInfo.Get(ListaInfo[index + 1].Oid,true);
                //Datos.DataSource = _pregunta_info;
                //RellenaHistoria();
                //Datos_Respuestas.DataSource = _pregunta_info.Respuestas;
                //Images.Show(_pregunta_info.Imagen, Principal.FOTOS_PREGUNTAS_PATH, Imagen_PictureBox);
                RefreshMainData();
            }
            SetDependentControlSource(Modulo_CB.Name);
        }

        protected override void SetPreguntaAnterior()
        {
            int index = ListaInfo.IndexOf(_pregunta_info);
            if (index > 0)
            {
                _pregunta_info = PreguntaInfo.Get(ListaInfo[index - 1].Oid,true);
                //Datos.DataSource = _pregunta_info;
                //RellenaHistoria();
                //Datos_Respuestas.DataSource = _pregunta_info.Respuestas;
                //Images.Show(_pregunta_info.Imagen, Principal.FOTOS_PREGUNTAS_PATH, Imagen_PictureBox);
                RefreshMainData();
            }
            SetDependentControlSource(Modulo_CB.Name);
        }

        protected override void ShowImagen()
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
                            Tema_CB.SelectedItem = _combo_modulos.Childs.Buscar(_pregunta_info.OidTema);
                        }

                    } break;
                case "Tema_CB":
                    {
                        if (_pregunta_info != null)
                        {
                            TemaInfo tema = _temas.GetItem(_pregunta_info.OidTema);
                            if (tema.Desarrollo)
                                Tipo_CB.SelectedItem = ETipoPregunta.Desarrollo.ToString();//_combo_tipo.Buscar(1);
                            else
                                Tipo_CB.SelectedItem = ETipoPregunta.Test.ToString();//_combo_tipo.Buscar(2);
                            Nivel_TB.Text = tema.Nivel.ToString();
                        }

                    } break;
            }
        }

        #endregion

        #region Validation & Format


        #endregion

        #region Actions

        protected override void SaveAction() { _action_result = DialogResult.Cancel; }

        #endregion

        #region Events

        #endregion
    }

}
