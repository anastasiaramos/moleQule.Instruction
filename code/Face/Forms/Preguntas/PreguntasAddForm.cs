using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin01;

using moleQule.Library.Common;
using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class PreguntasAddForm : ItemMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps; } }

        protected Library.Instruction.HComboBoxSourceList _combo_modulos;
        protected Library.Instruction.HComboBoxSourceList _combo_submodulos;
        protected Library.Instruction.HComboBoxSourceList _combo_tipos; 
        protected TemaList _temas = TemaList.GetList(false);

        protected Preguntas _lista = null;
        protected Pregunta _entity;

        public virtual Pregunta Entity { get { return null; } set { } }
        public virtual PreguntaInfo EntityInfo { get { return null; } }

        public bool edit = false; //Determina si al cerrar el formulario habrá que abrir un nuevo formulario para editarla
        public long oid;

        #endregion

        #region Factory Methods

        public PreguntasAddForm() : this(true, null) { }

        public PreguntasAddForm(bool isModal, Preguntas preguntas)
            : base(isModal)
        {
            InitializeComponent();
            _lista = preguntas;
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.PREGUNTA_ADD_TITLE;
        }

        public PreguntasAddForm(Pregunta source)
            : base()
        {
            InitializeComponent();
            _entity = source.Clone();
            _entity.BeginEdit();
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.PREGUNTA_ADD_TITLE;
        }

        protected override void GetFormSourceData()
        {
            _entity = Pregunta.New();

            Respuesta respuesta_a = Respuesta.NewChild(_entity);
            respuesta_a.Opcion = "A";
            _entity.Respuestas.AddItem(respuesta_a);
            Respuesta respuesta_b = Respuesta.NewChild(_entity);
            respuesta_b.Opcion = "B";
            _entity.Respuestas.AddItem(respuesta_b);
            Respuesta respuesta_c = Respuesta.NewChild(_entity);
            respuesta_c.Opcion = "C";
            _entity.Respuestas.AddItem(respuesta_c);

            _entity.BeginEdit();
        }

        protected override bool SaveObject()
        {
            using (StatusBusy busy = new StatusBusy(moleQule.Face.Resources.Messages.SAVING))
            {
                this.Datos.RaiseListChangedEvents = false;

                Pregunta temp = _entity.Clone();
                temp.ApplyEdit();

                // do the save
                try
                {
                    _entity = temp.Save();
                    _entity.ApplyEdit();

                    //Decomentar si se va a mantener en memoria
                    //_entity.BeginEdit();
                    return true;
                }
                catch (iQValidationException ex)
                {
                    MessageBox.Show(iQExceptionHandler.GetAllMessages(ex) +
                                    Environment.NewLine + ex.SysMessage,
                                    moleQule.Library.Application.AppController.APP_TITLE,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    return false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(iQExceptionHandler.GetAllMessages(ex),
                                    moleQule.Library.Application.AppController.APP_TITLE,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    return false;
                }
                finally
                {
                    this.Datos.RaiseListChangedEvents = true;
                }
            }

        }
        
        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();
            ModeloRespuesta_BT.Visible = false;
            ModeloRespuesta_BT.Enabled = false;
            ModeloRespuesta_LB.Visible = false;
            ModeloRespuesta_LB.Enabled = false;
            ModeloRespuesta_TB.Visible = false;
            ModeloRespuesta_TB.Enabled = false;
            ModeloRespuestaView_BT.Visible = false;
            ModeloRespuestaView_BT.Enabled = false;
        }

        public override void RefreshSecondaryData()
        {
            ModuloList modulos = ModuloList.GetList(false);
            _combo_modulos = new Library.Instruction.HComboBoxSourceList(modulos);
            PgMng.Grow();

            Datos_Modulos.DataSource = _combo_modulos;
            SubmoduloList submodulos = SubmoduloList.GetList(false);
            _combo_submodulos = new Library.Instruction.HComboBoxSourceList(submodulos);
            _combo_modulos.Childs = _combo_submodulos;
            PgMng.Grow();

            _temas = TemaList.GetList(false);
            _combo_modulos.Childs.Childs = new Library.Instruction.HComboBoxSourceList(_temas);
            PgMng.Grow();

            //_combo_tipos = new Library.Instruction.HComboBoxSourceList();
            //_combo_tipos.Add(new ComboBoxSource(1,"Desarrollo"));
            //_combo_tipos.Add(new ComboBoxSource(2,"Test"));
            Datos_Tipo.DataSource = Library.Instruction.EnumText<ETipoPregunta>.GetList();//_combo_tipos;
            PgMng.Grow();

            //Library.Instruction.HComboBoxSourceList _combo_idiomas = new Library.Instruction.HComboBoxSourceList();
            //_combo_idiomas.Add(new ComboBoxSource(1,"Español"));
            //_combo_idiomas.Add(new ComboBoxSource(2,"Inglés"));
            Datos_Idioma.DataSource = Library.Common.EnumText<EIdioma>.GetList(false);//_combo_idiomas;
            PgMng.Grow();

            if (_entity != null) Datos.DataSource = _entity;
            PgMng.Grow();

            if (_entity != null) Datos_Respuestas.DataSource = _entity.Respuestas;
            PgMng.Grow();
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
                        if (Datos_Modulos.Current != null && Modulo_CB.SelectedItem != null)
                            Datos_Submodulos.DataSource = _combo_modulos.GetFilteredChilds(((ComboBoxSource)Modulo_CB.SelectedItem).Oid); 

                    } break;
                case "Submodulo_CB":
                    {
                        if (Submodulo_CB.SelectedItem != null && ((ComboBoxSource)Submodulo_CB.SelectedItem).Oid != 0)
                            Datos_Temas.DataSource = _combo_modulos.Childs.GetFilteredChilds(((ComboBoxSource)Submodulo_CB.SelectedItem).Oid);
                    }break;

                case "Tema_CB":
                    {
                        if (_temas != null && Tema_CB.SelectedItem != null)
                        {
                            TemaInfo tema = _temas.GetItem(((ComboBoxSource)Tema_CB.SelectedItem).Oid);
                            if (tema != null && _entity != null)
                            {
                                _entity.OidSubmodulo = tema.OidSubmodulo;
                                _entity.OidTema = tema.Oid;
                                Nivel_TB.Text = tema.Nivel.ToString();
                                _entity.Nivel = tema.Nivel;
                                if (tema.Desarrollo)
                                {
                                    Tipo_TB.Text = ETipoPregunta.Desarrollo.ToString();
                                    _entity.Tipo = ETipoPregunta.Desarrollo.ToString();
                                    Respuestas_Grid.Visible = false;
                                    Respuestas_Grid.Enabled = false;
                                    Respuestas_BT.Visible = false;
                                    Respuestas_BT.Enabled = false;
                                    ModeloRespuesta_TB.Visible = true;
                                    ModeloRespuesta_TB.Enabled = true;
                                    ModeloRespuesta_LB.Visible = true;
                                    ModeloRespuesta_LB.Enabled = true;
                                    ModeloRespuesta_BT.Visible = true;
                                    ModeloRespuesta_BT.Enabled = true;
                                    ModeloRespuestaView_BT.Visible = true;
                                    ModeloRespuestaView_BT.Enabled = true;

                                }
                                else
                                {
                                    Tipo_TB.Text = ETipoPregunta.Test.ToString();
                                    _entity.Tipo = ETipoPregunta.Test.ToString();
                                    ModeloRespuesta_TB.Visible = false;
                                    ModeloRespuesta_TB.Enabled = false;
                                    ModeloRespuesta_LB.Visible = false;
                                    ModeloRespuesta_LB.Enabled = false;
                                    ModeloRespuestaView_BT.Visible = false;
                                    ModeloRespuestaView_BT.Enabled = false;
                                    ModeloRespuesta_BT.Visible = false;
                                    ModeloRespuesta_BT.Enabled = false;
                                    Respuestas_Grid.Visible = true;
                                    Respuestas_Grid.Enabled = true;
                                    Respuestas_BT.Visible = true;
                                    Respuestas_BT.Enabled = true;
                                }
                            }
                        }
                    } break;
            }
        }

        protected void SaveImage(bool replace)
        {
            Bitmap imagen = new Bitmap(Browser.FileName);

            string ext = string.Empty;

            if (imagen.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Jpeg.Guid))
                ext = ".jpg";
            else
            {
                if (imagen.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Bmp.Guid))
                    ext = ".bmp";
                else
                {
                    if (imagen.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Png.Guid))
                        ext = ".png";
                }
            }

            imagen.Dispose();

            if (replace)
            {
                File.Copy(moleQule.Library.Application.AppController.FOTOS_PREGUNTAS_PATH + _entity.Imagen,
                            moleQule.Library.Application.AppController.FOTOS_PREGUNTAS_PATH + _entity.Oid.ToString("00000") + ext,
                            true);
                File.Delete(moleQule.Library.Application.AppController.FOTOS_PREGUNTAS_PATH + _entity.Imagen);
                            _entity.Imagen = _entity.Oid.ToString("00000") + ext;
            }
            else
            {
                _entity.Imagen = _entity.Oid.ToString("00000") + ext;
                File.Copy(Browser.FileName, moleQule.Library.Application.AppController.FOTOS_PREGUNTAS_PATH + _entity.Imagen, true);
            }

        }

        protected void SaveModeloRespuesta()
        {
            _entity.ModeloRespuesta = ModeloRespuestaBrowser.SafeFileName;
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
            if (_entity.Texto == string.Empty)
            {
                MessageBox.Show("El texto de la pregunta no puede estar en blanco.");
                return;
            }
            if (_entity.Tipo == string.Empty)
            {
                MessageBox.Show("Debe seleccionar el tipo de pregunta.");
                return;
            }
            if (((ComboBoxSource)Tema_CB.SelectedItem).Oid == 0 || Datos_Temas.Current == null)
                MessageBox.Show("Debe seleccionar un tema válido");
            else
            {
                _entity.FechaAlta = DateTime.Now;
                _entity.FechaDisponibilidad = DateTime.Now;

                Historia historia = Historia.NewChild(_entity);
                historia.Fecha = DateTime.Now.Date;
                historia.Hora = DateTime.Now;
                historia.Texto = "Pregunta creada por " + AppContext.User.Name;

                _entity.Historias.AddItem(historia);

                if (SaveObject())
                {
                    //Si la pregunta tiene imagen, se renombra después de guardar el objeto
                    //con el Oid asignado por la base de datos y se vuelve a guardar
                    if (_entity.Imagen != string.Empty || _entity.ModeloRespuesta != string.Empty)
                    {
                        if (_entity.Imagen != string.Empty)
                            SaveImage(true);
                        if (_entity.ModeloRespuesta != string.Empty)
                        {
                            _entity.ModeloRespuesta = _entity.Oid.ToString("00000") + "_" + ModeloRespuestaBrowser.SafeFileName;
                            File.Copy(ModeloRespuestaBrowser.FileName, moleQule.Library.Application.AppController.MODELOS_PREGUNTAS_PATH + _entity.ModeloRespuesta, true);
                        }
                        SaveObject();
                    }

                    _entity.CloseSession();

                    _entity.SessionCode = _lista.SessionCode;
                    _entity.MarkItemChild();
                    _lista.AddItem(_entity);

                    _action_result = DialogResult.OK;
                    Close();
                }
                else MessageBox.Show("No se ha podido crear la pregunta.", "Aviso");
            }

        }

        /// <summary>
        /// Implementa Undo_button_Click
        /// </summary>
        protected override void CancelAction()
        {
            _entity.CloseSession();
            _action_result = DialogResult.Cancel;
            Close();
        }

        private void Examinar_BT_Click(object sender, EventArgs e)
        {
            if (Browser.ShowDialog() == DialogResult.OK)
            {
                SaveImage(false);
            }

            Images.Show(_entity.Imagen, moleQule.Library.Application.AppController.FOTOS_PREGUNTAS_PATH, Imagen_PictureBox);
        }

        private void ModeloRespuesta_BT_Click(object sender, EventArgs e)
        {
            if (ModeloRespuestaBrowser.ShowDialog() == DialogResult.OK)
            {
                SaveModeloRespuesta();
            }

        }

        private void Ninguno_BT_Click(object sender, EventArgs e)
        {
            Images.Delete(_entity.Imagen, moleQule.Library.Application.AppController.FOTOS_PREGUNTAS_PATH);
            _entity.Imagen = string.Empty;
            Images.Show(_entity.Imagen, moleQule.Library.Application.AppController.FOTOS_PREGUNTAS_PATH, Imagen_PictureBox);
        }

        private void Respuestas_BT_Click(object sender, EventArgs e)
        {
            RespuestasActionForm form = new RespuestasActionForm(_entity);
            form.ShowDialog();
        }

        #endregion

        #region Events

        private void Modulo_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDependentControlSource(Modulo_CB.Name);
            if (Modulo_CB.SelectedItem != null)
                _entity.Modulo = (Modulo_CB.SelectedItem as ComboBoxSource).Texto;
        }

        private void Submodulo_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDependentControlSource(Submodulo_CB.Name);
            if (Submodulo_CB.SelectedItem != null)
                _entity.Submodulo = (Submodulo_CB.SelectedItem as ComboBoxSource).Texto;
        }

        private void Tema_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDependentControlSource(Tema_CB.Name);
            if (Tema_CB.SelectedItem != null)
                _entity.Tema = (Tema_CB.SelectedItem as ComboBoxSource).Texto;
        }

        #endregion

        private void PreguntasAddForm_Activated(object sender, EventArgs e)
        {
            if (_temas != null && Tema_CB.SelectedItem != null)
            {
                TemaInfo tema = _temas.GetItem(((ComboBoxSource)Tema_CB.SelectedItem).Oid);
                if (tema != null && _entity != null)
                {
                    if (tema.Desarrollo)
                    {
                        Respuestas_Grid.Visible = false;
                        Respuestas_Grid.Enabled = false;
                        Respuestas_BT.Visible = false;
                        Respuestas_BT.Enabled = false;
                        ModeloRespuesta_TB.Visible = true;
                        ModeloRespuesta_TB.Enabled = true;
                        ModeloRespuesta_LB.Visible = true;
                        ModeloRespuesta_LB.Enabled = true;
                        ModeloRespuesta_BT.Visible = true;
                        ModeloRespuesta_BT.Enabled = true;
                        ModeloRespuestaView_BT.Visible = true;
                        ModeloRespuestaView_BT.Enabled = true;
                        return;
                    }
                }
            }

            ModeloRespuesta_TB.Visible = false;
            ModeloRespuesta_TB.Enabled = false;
            ModeloRespuesta_LB.Visible = false;
            ModeloRespuesta_LB.Enabled = false;
            ModeloRespuesta_BT.Visible = false;
            ModeloRespuesta_BT.Enabled = false;
            ModeloRespuestaView_BT.Visible = false;
            ModeloRespuestaView_BT.Enabled = false;
            Respuestas_Grid.Visible = true;
            Respuestas_Grid.Enabled = true;
            Respuestas_BT.Visible = true;
            Respuestas_BT.Enabled = true;

        }

        private void ModeloRespuestaView_BT_Click(object sender, EventArgs e)
        {
            if (ModeloRespuestaBrowser.FileName != null)
                System.Diagnostics.Process.Start(ModeloRespuestaBrowser.FileName);
        }


    }
}

