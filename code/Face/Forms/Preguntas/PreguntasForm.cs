using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin01;

using moleQule.Library.Common;
using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class PreguntasForm : ListMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 4; } }

        protected Library.Instruction.HComboBoxSourceList _combo_modulos;
        //protected Library.Instruction.HComboBoxSourceList _combo_tipo;
        //protected Library.Instruction.HComboBoxSourceList _combo_idioma;
        protected bool _cambiado = false;
        protected SubmoduloList _submodulos;
        protected TemaList _temas;

        protected Pregunta _pregunta;

        protected PreguntaInfo _pregunta_info;

        public virtual PreguntaList ListaInfo { get { return null; } set { } }
        public virtual SortedBindingList<Pregunta> Lista { get { return null; } set { } }

        #endregion

        #region Factory Methods

        public PreguntasForm() : this(true) {}

        public PreguntasForm(bool ismodal)
            : base(ismodal)
        {
            InitializeComponent();
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

        public override void RefreshSecondaryData()
        {
            ModuloList modulos = ModuloList.GetList(false);
            _combo_modulos = new Library.Instruction.HComboBoxSourceList(modulos, true);
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
            //_combo_tipo.Add(new ComboBoxSource(2, "Test"));
            Datos_Tipos.DataSource = Library.Instruction.EnumText<ETipoPregunta>.GetList();//_combo_tipo;
            PgMng.Grow();
            
            //Library.Instruction.HComboBoxSourceList _combo_idiomas = new Library.Instruction.HComboBoxSourceList();
            //_combo_idiomas.Add(new ComboBoxSource(1, "Español"));
            //_combo_idiomas.Add(new ComboBoxSource(2, "Inglés"));
            Datos_Idiomas.DataSource = Library.Common.EnumText<EIdioma>.GetList(false);// _combo_idiomas;
            PgMng.Grow();
        }

        protected virtual void SetPreguntaAnterior(){}

        protected virtual void SetPreguntaSiguiente() { }

        protected virtual void ShowImagen() { }

        protected virtual void SaveImage(bool replace) {}

        protected void EnableButtons(int index)
        { 
            Anterior_BT.Enabled = (index > 0);
            Siguiente_BT.Enabled = (index < Lista.Count - 1);
        }
        
        #endregion

        #region Validation & Format

        #endregion

        #region Print

        //public override void PrintObject()
        //{
        //}

        //#endregion

        //#region Buttons

        //protected override void PrintAction()
        //{
        //    switch (TabControl.SelectedTab.Name)
        //    {
        //        case "General_TP":
        //            {
        //                PrintObject();
        //            } break;

        //        default:
        //            {
        //                PrintSelectSkinForm psform = new PrintSelectSkinForm(true);
        //                psform.EnableDetail(false);
        //                psform.ShowDialog();
        //                if (psform.DialogResult == DialogResult.Cancel) return;

        //                switch (TabControl.SelectedTab.Name)
        //                {
        //                    case "Redes_TP":
        //                        {
        //                            PrintData(Entidad.Red, psform.Source, psform.Type);
        //                        } break;

        //                }
        //            } break;
        //    }
        //}

        #endregion

        #region Events

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

        private void Examinar_BT_Click(object sender, EventArgs e)
        {
            if (Browser.ShowDialog() == DialogResult.OK)
            {
                SaveImage(false);
            }

            Images.Show(_pregunta.Imagen, moleQule.Library.Application.AppController.FOTOS_PREGUNTAS_PATH, Imagen_PictureBox);
        }

        private void Ninguno_BT_Click(object sender, EventArgs e)
        {
            Images.Delete(_pregunta.Imagen, moleQule.Library.Application.AppController.FOTOS_PREGUNTAS_PATH);
            _pregunta.Imagen = string.Empty;
            Images.Show(_pregunta.Imagen, moleQule.Library.Application.AppController.FOTOS_PREGUNTAS_PATH, Imagen_PictureBox);
        }

        private void Imagen_PictureBox_DoubleClick(object sender, EventArgs e)
        {
            ShowImagen();
        }

        #endregion


    }
}

