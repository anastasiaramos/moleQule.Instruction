using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;
using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class PreguntasUIForm : PreguntasForm
    {

        #region Business Methods

        public Pregunta _copia_pregunta = null;
        protected SortedBindingList<Pregunta> _lista = null;

        public override SortedBindingList<Pregunta> Lista { get { return _lista; } set { _lista = value; } }

        #endregion

        #region Factory Methods

        public PreguntasUIForm() : this(true) {}

        public PreguntasUIForm(bool ismodal)
            : base(ismodal)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Guarda en la bd el objeto actual
        /// </summary>
        protected override bool SaveObject()
        {
            using (StatusBusy busy = new StatusBusy(moleQule.Face.Resources.Messages.SAVING))
            {

                this.Datos.RaiseListChangedEvents = false;

                if (_submodulos.GetItem(_pregunta.OidSubmodulo).OidModulo != _pregunta.OidModulo)
                {
                    MessageBox.Show("Debe especificar un submódulo asociado a la pregunta");
                    return false;
                }

                int index = Lista.IndexOf(_pregunta);
                Pregunta temp = _pregunta.CloneAsRoot();
                
                temp.ApplyEdit();

                // do the save
                try
                {
                    Lista[index] = temp.Save();
                    Lista[index].ApplyEdit();

                    Lista[index].MarkItemChild();
                    Lista[index].MarkItemOld();
                    Lista[index].BeginEdit();

                    _pregunta = Lista[index];
                    _copia_pregunta = _pregunta.Clone();

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
        }

        protected override void RefreshMainData()
        {
            if (_pregunta != null) Datos.DataSource = _pregunta;
            PgMng.Grow();

            if (_pregunta.Respuestas.Count == 0) _pregunta.LoadRespuestas();
            Datos_Respuestas.DataSource = Respuestas.SortList(_pregunta.Respuestas, "Opcion", ListSortDirection.Ascending);

            RellenaHistoria();
            PgMng.Grow();

            Images.ShowImage(_pregunta.ImagenWithPath, Imagen_PictureBox);
            PgMng.Grow();

            base.RefreshMainData();
        }

        private void RellenaHistoria()
        {
            Historia_TB.Text = string.Empty;

            if (_pregunta.Historias.Count == 0) _pregunta.LoadHistorias();
            foreach (Historia item in _pregunta.Historias)
                Historia_TB.Text += item.Texto + Environment.NewLine;
        }

        protected override void SetPreguntaSiguiente()
        {
            int index = Lista.IndexOf(_pregunta);

            if (this is PreguntasEditForm)
            {
                if (_pregunta.IsDirty)
                {
                    DialogResult result;

                    result = MessageBox.Show("¿Desea guardar los cambios en la pregunta actual antes de pasar a la siguiente?",
                                                moleQule.Face.Resources.Labels.ADVISE_TITLE, 
                                                MessageBoxButtons.YesNoCancel);

                    if (result == DialogResult.Yes)
                    {
                        CompruebaCambios(index);
                        SaveObject();
                    }
                    else
                    {
                        if (result == DialogResult.Cancel)
                            return;
                        else
                        {
                            //Lista.CancelEdit();
                            //Lista.BeginEdit();
                        }
                    }
                }
            }
            _cambiado = true;
            if (index < Lista.Count - 1)
            {
                _pregunta = Lista[index + 1];
                _copia_pregunta = _pregunta.Clone();
                RefreshMainData();

                if (_pregunta.Tipo == "Desarrollo")
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
                }
                else
                {
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
            }
            _cambiado = false;
            SetDependentControlSource(Modulo_CB.Name);

            EnableButtons(index+1);
        }

        protected override void SetPreguntaAnterior()
        {
            int index = Lista.IndexOf(_pregunta);

            if (this is PreguntasEditForm)
            {
                if (_pregunta.IsDirty)
                {
                    DialogResult result;

                    result = MessageBox.Show("¿Desea guardar los cambios en la pregunta actual antes de pasar a la anterior?",
                                                moleQule.Face.Resources.Labels.ADVISE_TITLE, 
                                                MessageBoxButtons.YesNoCancel);

                    if (result == DialogResult.Yes)
                    {
                        CompruebaCambios(index);
                        SaveObject();
                    }
                    else
                    {
                        if (result == DialogResult.Cancel)
                            return;
                        else
                        {
                            //Lista.CancelEdit();
                            //Lista.BeginEdit();
                        }
                    }
                }
            }
            _cambiado = true;
            if (index > 0)
            {
                _pregunta = Lista[index - 1];
                _copia_pregunta = _pregunta.Clone();
                RefreshMainData();

                if (_pregunta.Tipo == "Desarrollo")
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
                }
                else
                {
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
            }
            _cambiado = false;
            SetDependentControlSource(Modulo_CB.Name);

            EnableButtons(index-1);
        }

        protected override void ShowImagen()
        {
            ImagenPreguntaViewForm form = new ImagenPreguntaViewForm(true, _pregunta.ImagenWithPath);
            form.ShowDialog();
        }

        protected override void SaveImage(bool replace)
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

            _pregunta.Imagen = _pregunta.Oid.ToString("00000") + ext;
            File.Copy(Browser.FileName, _pregunta.ImagenWithPath, true);

        }

        protected override void SetDependentControlSource(string controlName)
        {
            switch (controlName)
            {
                case "Modulo_CB":
                    {
                        if (!_cambiado)
                        {
                            if (Modulo_CB.SelectedItem != null && ((ComboBoxSource)Modulo_CB.SelectedItem).Oid != 0)
                            {
                                Datos_Submodulos.DataSource = _combo_modulos.GetFilteredChilds(((ComboBoxSource)Modulo_CB.SelectedItem).Oid);
                                //Submodulo_CB.SelectedItem = _combo_modulos.Childs.Buscar(_pregunta.OidSubmodulo);
                            }

                        }
                        else
                        {
                            if (Modulo_CB.SelectedValue != null && (long)Modulo_CB.SelectedValue != 0)
                            {
                                Datos_Submodulos.DataSource = _combo_modulos.GetFilteredChilds((long)Modulo_CB.SelectedValue);
                                Submodulo_CB.SelectedItem = _combo_modulos.Childs.Buscar(_pregunta.OidSubmodulo);
                            }
                        }

                    } break;
                case "Submodulo_CB":
                    {
                        if (!_cambiado)
                        {
                            if (Submodulo_CB.SelectedItem != null && ((ComboBoxSource)Submodulo_CB.SelectedItem).Oid != 0)
                            {
                                Datos_Temas.DataSource = _combo_modulos.Childs.GetFilteredChilds(((ComboBoxSource)Submodulo_CB.SelectedItem).Oid);
                                //Tema_CB.SelectedItem = _combo_modulos.Childs.Childs.Buscar(_pregunta.OidTema);
                            }

                        }
                        else
                        {
                            if (Submodulo_CB.SelectedValue != null && (long)Submodulo_CB.SelectedValue != 0)
                            {
                                Datos_Temas.DataSource = _combo_modulos.Childs.GetFilteredChilds((long)Submodulo_CB.SelectedValue);
                                Tema_CB.SelectedItem = _combo_modulos.Childs.Childs.Buscar(_pregunta.OidTema);
                            }
                        }

                    } break;
                case "Tema_CB":
                    {
                        if (!_cambiado)
                        {
                            if (Tema_CB.SelectedItem != null && ((ComboBoxSource)Tema_CB.SelectedItem).Oid != 0)
                            {
                                _pregunta.OidTema = (long)Tema_CB.SelectedValue;
                                _pregunta.OidSubmodulo = (long)Submodulo_CB.SelectedValue;
                                _pregunta.OidModulo = (long)Modulo_CB.SelectedValue;
                            }
                        }
                        else
                        {
                            if (Tema_CB.SelectedValue != null && (long)Tema_CB.SelectedValue != 0)
                            {
                                Datos_Temas.DataSource = _combo_submodulos.Childs.GetFilteredChilds((long)Tema_CB.SelectedValue);
                                if ((long)Tema_CB.SelectedValue != _pregunta.OidTema) Tema_CB.SelectedValue = _pregunta.OidTema;
                                Tema_CB.SelectedItem = _combo_submodulos.Childs.Buscar(_pregunta.OidTema);
                            }
                            Modulo_CB.SelectedValue = _pregunta.OidModulo;
                        }
                        if (_pregunta != null && _pregunta.OidTema != 0)
                        {
                            TemaInfo tema = _temas.GetItem(_pregunta.OidTema);
                            Nivel_TB.Text = tema.Nivel.ToString();
                            if (tema.Desarrollo)
                                Tipo_CB.SelectedItem = ETipoPregunta.Desarrollo.ToString();//_combo_tipo.Buscar(1);
                            else
                                Tipo_CB.SelectedItem = ETipoPregunta.Test.ToString();// _combo_tipo.Buscar(2);
                        }

                    } break;
            }
        }

        #endregion

        #region Validation & Format


        #endregion

        #region Buttons

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SaveAction()
        {
            if (_pregunta.IsDirty) CompruebaCambios(Lista.IndexOf(_pregunta));

            _action_result = SaveObject() ? DialogResult.OK : DialogResult.Ignore;
        }

        private void Respuestas_BT_Click(object sender, EventArgs e)
        {
            RespuestasActionForm form = new RespuestasActionForm(_pregunta);
            form.ShowDialog();
        }

        #endregion
        
        #region Commands

        protected void CompruebaCambios(int index)
        {
            Historia historia = _pregunta.Historias.NewItem(_pregunta);
            historia.Fecha = DateTime.Now.Date;
            historia.Hora = DateTime.Now;

            if (_pregunta.OidModulo != _copia_pregunta.OidModulo)
            {
                historia.Texto = System.Environment.NewLine
                    + "Modificado el campo Modulo; Usuario: " + AppContext.User.Name
                    + "; Valor anterior: " + _copia_pregunta.OidModulo.ToString() + ";";
            }
            if (_pregunta.OidTema != _copia_pregunta.OidTema)
            {
                historia.Texto = System.Environment.NewLine
                    + "Modificado el campo Tema; Usuario: " + AppContext.User.Name
                    + "; Valor anterior: " + _copia_pregunta.OidTema.ToString() + ";";
                _pregunta.OidSubmodulo = _temas.GetItem(_pregunta.OidTema).OidSubmodulo;
            }
            if (_pregunta.Nivel != _copia_pregunta.Nivel)
            {
                historia.Texto = System.Environment.NewLine
                    + "Modificado el campo Nivel; Usuario: " + AppContext.User.Name
                    + "; Valor anterior: " + _copia_pregunta.Nivel.ToString() + ";";
            }
            if (_pregunta.Texto != _copia_pregunta.Texto)
            {
                historia.Texto = System.Environment.NewLine
                    + "Modificado el campo Pregunta; Usuario: " + AppContext.User.Name
                    + "; Valor anterior: " + _copia_pregunta.Texto + ";";
            }
            if (_pregunta.Tipo != _copia_pregunta.Tipo)
            {
                historia.Texto = System.Environment.NewLine
                    + "Modificado el campo Tipo; Usuario: " + AppContext.User.Name
                    + "; Valor anterior: " + _copia_pregunta.Tipo + ";";
            }
            if (_pregunta.Imagen != _copia_pregunta.Imagen)
            {
                historia.Texto = System.Environment.NewLine
                    + "Modificado el campo Imagen; Usuario: " + AppContext.User.Name + ";";
            }
            if (_pregunta.Observaciones != _copia_pregunta.Observaciones)
            {
                historia.Texto = System.Environment.NewLine
                    + "Modificado el campo Observaciones; Usuario: " + AppContext.User.Name
                    + "; Valor anterior: " + _copia_pregunta.Observaciones + ";";
            }
            if (_pregunta.Idioma != _copia_pregunta.Idioma)
            {
                historia.Texto = System.Environment.NewLine
                    + "Modificado el campo Idioma; Usuario: " + AppContext.User.Name
                    + "; Valor anterior: " + _copia_pregunta.Idioma + ";";
            }
            if (_pregunta.Activa != _copia_pregunta.Activa)
            {
                historia.Texto = System.Environment.NewLine
                    + "Modificado el campo Activa; Usuario: " + AppContext.User.Name
                    + "; Valor anterior: " + _copia_pregunta.Activa.ToString() + ";";
            }
            if (_pregunta.Revisada != _copia_pregunta.Revisada)
            {
                historia.Texto = System.Environment.NewLine
                    + "Modificado el campo Revisada; Usuario: " + AppContext.User.Name
                    + "; Valor anterior: " + _copia_pregunta.Revisada.ToString() + ";";
            }
            if (_pregunta.ImagenGrande != _copia_pregunta.ImagenGrande)
            {
                historia.Texto = System.Environment.NewLine
                    + "Modificado el campo Imagen Grande; Usuario: " + AppContext.User.Name
                    + "; Valor anterior: " + _copia_pregunta.ImagenGrande.ToString() + ";";
            }

            if (_pregunta.ModeloRespuesta != _copia_pregunta.ModeloRespuesta)
            {
                historia.Texto = System.Environment.NewLine
                    + "Modificado el campo Modelo de Respuesta; Usuario: " + AppContext.User.Name
                    + "; Valor anterior: " + _copia_pregunta.ModeloRespuesta.ToString() + ";";
            }

            if (historia.Texto == string.Empty)
                _pregunta.Historias.Remove(historia);

            _pregunta.CheckChanges(_copia_pregunta);
        }

        #endregion

        #region Events

        private void PreguntasForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Activa_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_pregunta != null && _pregunta.Reservada && !Activa_CB.Checked)
            {
                MessageBox.Show(string.Format(Resources.Messages.PREGUNTA_RESERVADA),
                                moleQule.Library.Application.AppController.APP_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                Activa_CB.Checked = true;
            }
        }

        #endregion

        private void PreguntasUIForm_Activated(object sender, EventArgs e)
        {

            if (_pregunta.Tipo == "Desarrollo")
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
            }
            else
            {
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
        }

        private void ModeloRespuesta_BT_Click(object sender, EventArgs e)
        {
            if (ModeloRespuestaBrowser.ShowDialog() == DialogResult.OK)
            {
                _pregunta.ModeloRespuesta = _pregunta.Oid.ToString("00000") + "_" + ModeloRespuestaBrowser.SafeFileName;
                File.Copy(ModeloRespuestaBrowser.FileName, moleQule.Library.Application.AppController.MODELOS_PREGUNTAS_PATH + _pregunta.ModeloRespuesta, true);
            }
        }

        private void ModeloRespuestaView_BT_Click(object sender, EventArgs e)
        {
            if (_pregunta.ModeloRespuesta != string.Empty)
                System.Diagnostics.Process.Start(moleQule.Library.Application.AppController.MODELOS_PREGUNTAS_PATH + _pregunta.ModeloRespuesta);
        }

    }
}