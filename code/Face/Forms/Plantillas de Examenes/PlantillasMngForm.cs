using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Csla;
using CslaEx;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin02;

using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class PlantillasMngForm : EntityMngSkinForm
    {

        #region Business Methods

        public const string ID = "PlantillasMngForm";
        public static Type Type { get { return typeof(PlantillasMngForm); } }

        protected override int BarSteps { get { return 3; } }

        /// <summary>
        ///  Lista de objetos de sólo lectura
        /// </summary>
        private PlantillaExamenList _lista;

        /// <summary>
        ///  Lista filtrada de sólo lectura
        /// </summary>
        private PlantillaExamenList _lista_filtrada = null;

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

        public PlantillaExamenList Lista { get { return _lista; } }

        #endregion

        #region Factory Methods

        public PlantillasMngForm()
        {
            InitializeComponent();
            this.Text = Resources.Labels.PLANTILLA_EXAMEN;
        }

        #endregion

        #region Autorizacion

        /// <summary>Aplica las reglas de validación de usuarios al formulario.
        /// <returns>void</returns>
        /// </summary>
        protected override void ApplyAuthorizationRules()
        {
            Tabla.Visible = PlantillaExamen.CanGetObject();
            Add_Button.Enabled = PlantillaExamen.CanAddObject();
            Edit_Button.Enabled = PlantillaExamen.CanEditObject();
            Delete_Button.Enabled = PlantillaExamen.CanDeleteObject();
            View_Button.Enabled = PlantillaExamen.CanGetObject();
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
                visibles.Add(Modulo.Name);
                visibles.Add(Codigo.Name);
                visibles.Add(Desarrollo.Name);
                visibles.Add(Idioma.Name);
                visibles.Add(NPreguntas.Name);

                ControlTools.ShowDataGridColumns(Tabla, visibles);

                VScrollBar vs = new VScrollBar();

                int rowWidth = (int)(Tabla.Width - vs.Width
                                                    - Tabla.RowHeadersWidth
                                                    - Tabla.Columns[Codigo.Name].Width
                                                    - Tabla.Columns[Desarrollo.Name].Width
                                                    - Tabla.Columns[NPreguntas.Name].Width
                                                    - Tabla.Columns[Idioma.Name].Width);

                Tabla.Columns[Modulo.Name].Width = (int)(rowWidth * 0.995);
            }

        }

        /// <summary>
        /// Toma la lista de bancos de la base de datos y rellena la tabla.
        /// </summary>
        protected override void RefreshMainData()
        {
            _lista = PlantillaExamenList.GetList(false);
            Bar.Grow(string.Empty, "Plantillas");

            Datos.DataSource = PlantillaExamenList.SortList(_lista,
                                                        this.GetGridSortProperty(Tabla),
                                                        this.GetGridSortDirection(Tabla));
            Bar.FillUp(string.Empty, "Ordenar Lista");
        }


        /// <summary>
        /// Selecciona un elemento de la tabla
        /// </summary>
        /// <param name="oid">Identificar del elemento</param>
        protected override void Select(long oid)
        {
            int foundIndex = Datos.IndexOf(moleQule.Library.Instruction.PlantillaExamenList.GetList().GetItem(oid));
            Datos.Position = foundIndex;
        }

        /// <summary>
        /// Filtra la tabla
        /// </summary>
        /// <param name="oid">Identificar del elemento</param>
        protected override void Filter(object filtro)
        {
            _lista_filtrada = ((PlantillaExamenList)filtro).Clone();

            if (Filtros.SelectedTab != Filtros.TabPages["Advanced_TP"])
                Filtros.SelectedTab = Filtros.TabPages["Advanced_TP"];
            else
            {
                try
                {
                    Datos.DataSource =
                        PlantillaExamenList.SortList(_lista_filtrada, "Codigo", ListSortDirection.Ascending);
                }
                catch (Exception)
                {
                    Datos.DataSource = _lista;
                }
            }
        }

        /// <summary>
        /// Aplica el filtro correspondiente según la pestaña
        /// </summary>
        protected override void ApplyFilter()
        {
            switch (Filtros.SelectedTab.Name)
            {
                case "Todos_TP":
                    {
                        RefreshMainData();

                    } break;

                case "Advanced_TP":
                    {
                        try
                        {
                            foreach (EntityDriverForm item in _list_active_form)
                            {
                                if (item is PlantillaLocalizeForm)
                                {
                                    ((LocalizeForm)item).Filter();
                                }
                            }

                            Datos.DataSource =
                                PlantillaExamenList.SortList(_lista_filtrada, "Codigo", ListSortDirection.Ascending);
                        }
                        catch (Exception)
                        {
                            Datos.DataSource = _lista;
                        }

                    } break;
                case "Modulo_TP":
                    {
                        try
                        {
                            CriteriaEx criteria = PlantillaExamen.GetCriteria(PlantillaExamen.OpenSession());
                            criteria.AddEq("OidModulo", ActiveItem.OidModulo);
                            _lista = PlantillaExamenList.GetListByModulo(ActiveItem.OidModulo);
                            Datos.DataSource = PlantillaExamenList.SortList(_lista,
                                                                    "Codigo",
                                                                    ListSortDirection.Ascending);
                        }
                        catch (Exception)
                        {
                            _lista = null;
                        }

                    } break;


            }
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
                        ModuloList modulos = ModuloList.GetList(false);

                        foreach (DataGridViewRow row in Tabla.Rows)
                        {
                            item = (PlantillaExamenInfo)row.DataBoundItem;
                            if (item.OidModulo != 0)
                                row.Cells[Modulo.Name].Value = modulos.GetItem(item.OidModulo).Texto;
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                            //if (item.Idioma == "Espanol")
                            //    row.Cells[Idioma.Name].Value = "Español";
                            //else
                            //{
                            //    if (item.Idioma == "Ingles")
                            //        row.Cells[Idioma.Name].Value = "Inglés";
                            //    else
                            //        row.Cells[Idioma.Name].Value = item.Idioma;
                            //}
                            //Datos.MoveNext();
                        }

                    } break;
            }
        }


        #endregion

        #region Buttons

        /// <summary>
        /// Abre el formulario para añadir item
        /// <returns>void</returns>
        /// </summary>
        public override void OpenAddForm()
        {

            try
            {
                AddForm(new PlantillaAddForm());
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
        ///// Abre el formulario para ver item
        ///// <returns>void</returns>
        ///// </summary>
        public override void OpenViewForm()
        {

            try
            {
                AddForm(new PlantillaViewForm(ActiveOID));
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
                PlantillaEditForm form = new PlantillaEditForm(ActiveOID);
                if (form.EntityInfo != null)
                    AddForm(form);
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

            if (MessageBox.Show(moleQule.Face.Resources.Messages.DELETE_CONFIRM,
                                moleQule.Face.Resources.Labels.ADVISE_TITLE,
                                MessageBoxButtons.YesNoCancel,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    PlantillaExamen.Delete(oid);

                    //Se eliminan todos los formularios de ese objeto
                    foreach (EntityDriverForm form in _list_active_form)
                    {
                        if (form is ItemMngBaseForm)
                        {
                            if (((ItemMngBaseForm)form).Oid == oid)
                            {
                                form.Dispose();
                                break;
                            }
                        }
                    }
                }
                catch (DataPortalException ex)
                {
                    MessageBox.Show(iQExceptionHandler.GetiQException(ex).Message);
                }
                finally
                {
                    RefreshList();
                }
            }
        }

        public override void OpenLocalizeForm()
        {

            try
            {
                PlantillaLocalizeForm form = new PlantillaLocalizeForm();
                form.Lista = _lista;
                form.SortProperty = this.GetGridSortProperty(Tabla);
                form.SortDirection = this.GetGridSortDirection(Tabla);
                AddForm(form);
                //Recalculamos el alto del formulario para ajustarlo al tamaño 
                //que nos deja el LocalizeForm
                ResizeHeight(form);
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


        ///// <summary>Imprime la lista del objetos
        ///// <returns>void</returns>
        ///// </summary>
        public override void PrintList()
        {
        //    ClienteReportMng reportMng = new ClienteReportMng(AppContext.ActiveSchema);

        //    InstructorListRpt report = reportMng.GetInstructorListReport(InstructorList.GetList((IList<InstructorInfo>)Datos.List));

        //    if (report != null)
        //    {
        //        ReportViewer.SetReport(report);
        //        ReportViewer.ShowDialog();
        //    }
        //    else
        //    {
        //        MessageBox.Show(Resources.Messages.NO_DATA_REPORTS,
        //                        Labels.EMPTY_REPORT,
        //                        MessageBoxButtons.OK,
        //                        MessageBoxIcon.Exclamation);
        //    }
        }

        #endregion

        #region Events

        private void PlantillasMngForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataGridViewColumn col;

            if (Tabla.CurrentCell == null)
            {
                if (Tabla.SortedColumn != null)
                    col = Tabla.SortedColumn;
                else
                    col = Tabla.Columns[0];
            }
            else
                col = Tabla.Columns[Tabla.CurrentCell.ColumnIndex];

            if (col.ValueType != null)
            {
                if (col.ValueType.Name == "Int32") return;
                if (col.ValueType.Name == "Int64") return;
                if (col.ValueType.Name == "Single") return;
                if (col.ValueType.Name == "Double") return;

                string car = e.KeyChar.ToString();
                CriteriaEx criteria = PlantillaExamen.GetCriteria(PlantillaExamen.OpenSession());

                criteria.AddStartsWith(col.DataPropertyName, car);

                // Buscamos las palabras que empiecen por el caracter
                PlantillaExamenList lista = PlantillaExamenList.GetList(criteria);
                SortedBindingList<PlantillaExamenInfo> list =
                    PlantillaExamenList.GetSortedList(lista, col.DataPropertyName, ListSortDirection.Ascending);

                int foundIndex;

                // Nos situamos en la primera aparicion de esa lista en la 
                // que se muestra. Esto se hace pq se ha consultado la bd y no la lista actual
                // lo que puede dar lugar a inconsistencias si otro usuario a cambiado la bd
                foreach (PlantillaExamenInfo cli in list)
                {
                    foundIndex = Datos.IndexOf(cli);
                    if (foundIndex != -1)
                    {
                        Datos.Position = foundIndex;
                        break;
                    }
                }
            }
        }

        private void Tabla_DoubleClick(object sender, EventArgs e)
        {
            OpenEditForm();
        }

        private void Tabla_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (_lista == null) return;
            SetUnlinkedGridValues("Tabla");
        }

        #endregion
    }
}
