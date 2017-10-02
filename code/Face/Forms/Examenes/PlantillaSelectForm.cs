using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin02;

using moleQule.Library.Instruction; 


namespace moleQule.Face.Instruction
{
    public partial class PlantillaSelectForm : SelectSkinForm
    {

        #region Bussiness Methods

        protected PlantillaExamenList _plantillas = null;

        protected Examen _entity;

        protected ModuloInfo _modulo;

        protected PlantillaExamenInfo _plantilla;

        protected PreguntaList _preguntas = null;

        private bool _guardado = false;

        public PlantillaExamenList Plantillas { get { return _plantillas; } set { _plantillas =value;} }
        public bool Guardado { get { return _guardado; } }

        /// <summary>
        /// Devuelve el OID del objeto activo seleccionado de la tabla
        /// </summary>
        /// <returns></returns>
        public override long ActiveOID
        {
            get
            {
                return Datos.Current != null ? ((PlantillaExamenInfo)Datos.Current).Oid : -1;
            }
        }

        /// <summary>
        /// Devuelve el objeto activo seleccionado de la tabla
        /// </summary>
        /// <returns></returns>
        public PlantillaExamenInfo ActiveItem
        {
            get
            {
                if (Datos.Current != null)
                    return (PlantillaExamenInfo)Datos.Current;
                else
                    return null;
            }
        }

        #endregion

        #region Factory Methods

        public PlantillaSelectForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();
            //FormatControls();

            this.Text = Resources.Labels.SELECT_PLANTILLA;
        }

        public void SetSourceData(Examen item, ModuloInfo modulo, PreguntaList preguntas)
        {
            _entity = item;

            _modulo = modulo;

            _preguntas = preguntas;

            RefreshMainData();
            RefreshSecondaryData();
        }

        public void SetSourceData(Examen item, ModuloInfo modulo)
        {
            SetSourceData(item, modulo, PreguntaList.GetPreguntasModulo(modulo.Oid));
        }

        #endregion

        #region Style & Source


        /// <summary>Formatea los controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();

            List<string> visibles = new List<string>();

            if (Tabla != null)
            {
                visibles.Add(Codigo.Name);
                visibles.Add(Desarrollo.Name);
                visibles.Add(Idioma.Name);
                visibles.Add(NPreguntas.Name);

                ControlTools.ShowDataGridColumns(Tabla, visibles);

                VScrollBar vs = new VScrollBar();

                int rowWidth = (int)(Tabla.Width - vs.Width
                                                    - Tabla.RowHeadersWidth);

                Tabla.Columns[Codigo.Name].Width = (int)(rowWidth * 0.245);
                Tabla.Columns[Desarrollo.Name].Width = (int)(rowWidth * 0.245);
                Tabla.Columns[Idioma.Name].Width = (int)(rowWidth * 0.245);
                Tabla.Columns[NPreguntas.Name].Width = (int)(rowWidth * 0.245);
            }

        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
        }

        public override void RefreshSecondaryData()
        {
            //_modulo = ModuloInfo.Get(_entity.OidModulo, false);

            Titulo.Text = "| " + _modulo.Texto;
            PgMng.Grow();

            Plantillas = PlantillaExamenList.GetListByModulo(_modulo.Oid);
            PgMng.Grow();

            Datos.DataSource = Plantillas;
            PgMng.FillUp();
        }

        /// <summary>
        ///Asigna los valores del grid que no están asociados a propiedades
        /// </summary>
        private void SetUnlinkedGridValues(string gridName)
        {
            switch (gridName)
            {
                case "Tabla":
                    {
                        PlantillaExamenInfo item;

                        foreach (DataGridViewRow row in Tabla.Rows)
                        {
                            item = (PlantillaExamenInfo)row.DataBoundItem;
                            //if (item.Idioma == "Espanol")
                            //    row.Cells[Idioma.Name].Value = "Español";
                            //else
                            //{
                            //    if (item.Idioma == "Ingles")
                            //        row.Cells[Idioma.Name].Value = "Inglés";
                            //    else row.Cells[Idioma.Name].Value = item.Idioma;
                            //}
                            Datos.MoveNext();
                        }

                    } break;
            }
        }

        #endregion

        #region Buttons

        private void Cerrar_BT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Select_Button_Click(object sender, EventArgs e)
        {
            _plantilla = PlantillaExamenInfo.Get(ActiveOID);
            TemaList temas = TemaList.GetModuloList(_modulo.Oid,false);
            _guardado = true;

            //_entity.MemoPreguntas = string.Empty;

            if (_plantilla != null)
            {
                foreach (Preguntas_PlantillaInfo item in _plantilla.Preguntas)
                {
                    long count = item.NPreguntas;

                    foreach (PreguntaInfo info in _preguntas)
                    {
                        if (count == 0) break;
                        if (info.OidTema == item.OidTema
                            && info.FechaDisponibilidad.Date <= DateTime.Today.Date
                            && !info.Reservada
                            && ((info.Tipo == ETipoPregunta.Desarrollo.ToString() && _entity.Desarrollo)
                            || (info.Tipo == ETipoPregunta.Test.ToString() && !_entity.Desarrollo))
                            && info.Activa)
                        {
                            Pregunta_Examen pregunta = Pregunta_Examen.NewChild(_entity);
                            pregunta.OidPregunta = info.Oid;
                            _entity.Pregunta_Examens.AddItem(pregunta);
                            //_entity.MemoPreguntas += info.Oid.ToString() + ";";
                            count--;
                        }
                    }

                    if (count != 0)
                    {

                        TemaInfo tema = temas.GetItem(item.OidTema);
                        MessageBox.Show("No hay suficientes preguntas disponibles para el tema " + tema.Codigo);
                    }
                }
            }
            
            Cerrar();
            Close();
        }


        /// <summary>
        /// Abre el formulario para añadir item
        /// <returns>void</returns>
        /// </summary>
        public override void OpenAddForm()
        {

            try
            {
                PlantillaAddForm form = new PlantillaAddForm(_entity.OidModulo,true);
                form.ShowDialog(this);
                RefreshSecondaryData();
            }
            catch (Csla.DataPortalException ex)
            {
                MessageBox.Show(ex.BusinessException.ToString(),
                                moleQule.Face.Resources.Labels.ERROR_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                                moleQule.Face.Resources.Labels.ERROR_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            finally
            {
                RefreshSecondaryData();
            }
        }

        ///// <summary>
        ///// Abre el formulario para ver item
        ///// <returns>void</returns>
        ///// </summary>
        public override void OpenViewForm()
        {

            try
            {
                PlantillaViewForm form = new PlantillaViewForm(ActiveOID, true);
                form.ShowDialog(this);
                RefreshSecondaryData();
            }
            catch (Csla.DataPortalException ex)
            {
                MessageBox.Show(ex.BusinessException.ToString(),
                                moleQule.Face.Resources.Labels.ERROR_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                                moleQule.Face.Resources.Labels.ERROR_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }

        ///// <summary>
        ///// Abre el formulario para editar item
        ///// <returns>void</returns>
        ///// </summary>
        public override void OpenEditForm()
        {

            try
            {
                PlantillaEditForm form = new PlantillaEditForm(ActiveOID,true);
                if (form.EntityInfo != null)
                    form.ShowDialog(this);
                //RefreshSecondaryData();
            }
            catch (Csla.DataPortalException ex)
            {
                MessageBox.Show(ex.BusinessException.ToString(),
                                moleQule.Face.Resources.Labels.ERROR_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                                moleQule.Face.Resources.Labels.ERROR_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }

        ///// <summary>
        ///// Abre el formulario para borrar item
        ///// <returns>void</returns>
        ///// </summary>
        public override void DeleteObject(long oid)
        {

            //if (MessageBox.Show(moleQule.Face.Resources.Messages.DELETE_CONFIRM,
            //                    moleQule.Face.Resources.Labels.ADVISE_TITLE,
            //                    MessageBoxButtons.YesNoCancel,
            //                    MessageBoxIcon.Question) == DialogResult.Yes)
            //{
                try
                {
                    PlantillaExamen.Delete(oid);
                    RefreshSecondaryData();
                }
                catch (DataPortalException ex)
                {
                    MessageBox.Show(iQExceptionHandler.GetiQException(ex).Message);
                }
                finally
                {
                    RefreshSecondaryData();
                }
            //}
        }

        #endregion

        #region Events

        private void PlantillaSelectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cerrar();
        }

        private void Tabla_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetUnlinkedGridValues(Tabla.Name);
        }

        private void Tabla_DoubleClick(object sender, EventArgs e)
        {
            OpenViewForm();
        }

        #endregion

    }
}

