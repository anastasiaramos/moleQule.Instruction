using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Instruction;
using moleQule.Library.Instruction.Reports.Examen;
using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class FormularioNotasPracticasMngForm : FormularioNotasPracticasMngBaseForm
    {

        #region Attributes & Properties

        public const string ID = "FormularioNotasPracticasMngForm";
        public static Type Type { get { return typeof(FormularioNotasPracticasMngForm); } }
        public override Type EntityType { get { return typeof(ParteAsistencia); } }

        protected override int BarSteps { get { return base.BarSteps + 3; } }

        protected ParteAsistencia _entity;

        #endregion

        #region Factory Methods

        public FormularioNotasPracticasMngForm()
            : this(false) { }

        public FormularioNotasPracticasMngForm(bool isModal)
            : this(isModal, null) { }

        public FormularioNotasPracticasMngForm(Form parent)
            : this(false, parent) { }

        public FormularioNotasPracticasMngForm(bool isModal, Form parent)
            : this(isModal, parent, null) { }

        public FormularioNotasPracticasMngForm(bool isModal, Form parent, ParteAsistenciaList list)
            : base(isModal, parent, list)
        {
            InitializeComponent();
            SetView(molView.Normal);
            _sort_property = Fecha.Name;

            // Parche para poder abrir el formulario en modo diseño y no perder la configuracion de columnas
            DatosLocal_BS = Datos;
            Tabla.DataSource = DatosLocal_BS;
            SetMainDataGridView(Tabla);

            Datos.DataSource = ParteAsistenciaList.NewList().GetSortedList();
            base.SortProperty = Fecha.DataPropertyName;
        }

        #endregion

        #region Business Methods

        protected override Type GetColumnType(string column_name)
        {
            return Tabla.Columns[column_name] != null ? Tabla.Columns[column_name].ValueType : null;
        }

        protected override string GetColumnProperty(string column_name)
        {
            return Tabla.Columns[column_name] != null ? Tabla.Columns[column_name].DataPropertyName : null;
        }

        #endregion

        #region Autorizacion

        /// <summary>Aplica las reglas de validación de usuarios al formulario.
        /// <returns>void</returns>
        /// </summary>
        protected override void ApplyAuthorizationRules()
        {
            Tabla.Visible = ParteAsistencia.CanGetObject();
            Add_Button.Enabled = ParteAsistencia.CanAddObject();
            Edit_Button.Enabled = ParteAsistencia.CanEditObject();
            Delete_Button.Enabled = ParteAsistencia.CanDeleteObject();
            Print_Button.Enabled = ParteAsistencia.CanGetObject();
            View_Button.Enabled = ParteAsistencia.CanGetObject();
        }

        #endregion

        #region Style

        /// <summary>Formatea los controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            if (Tabla == null) return;

            base.FormatControls();

            HideAction(molAction.Add);
            HideAction(molAction.Print);
            HideAction(molAction.Delete);

            List<DataGridViewColumn> cols = new List<DataGridViewColumn>();
            Instructor.Tag = 1;

            cols.Add(Instructor);

            ControlsMng.MaximizeColumns(Tabla, cols);

            ControlsMng.OrderByColumn(Tabla, Fecha, ListSortDirection.Ascending);
            SetGridFormat();
            ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla));

            Fields_CB.Text = Fecha.HeaderText;

            SetColumnActive(ControlsMng.GetColumn(Tabla, Fecha.DataPropertyName));
        }

        #endregion

        #region Source

        protected void SetMainList(SortedBindingList<ParteAsistenciaInfo> list, bool order)
        {
            base.SortProperty = SortProperty;
            base.SortDirection = SortDirection;

            int currentColumn = (Tabla.CurrentCell != null) ? Tabla.CurrentCell.ColumnIndex : -1;

            Datos.DataSource = list;
            Datos.ResetBindings(true);

            if (order)
            {
                ControlsMng.OrderByColumn(Tabla, Tabla.Columns[base.SortProperty], base.SortDirection, true);
            }

            if (currentColumn != -1) ControlsMng.SetCurrentCell(Tabla, currentColumn);

            SetGridFormat();
        }

        /// <summary>
        /// Toma la lista de bancos de la base de datos y rellena la tabla.
        /// </summary>
        protected override void RefreshMainData()
        {
            PgMng.Grow(string.Empty, "ParteAsistencia");

            _selectedOid = ActiveOID;

            switch (DataType)
            {
                case EntityMngFormTypeData.Default:
                    List = ParteAsistenciaList.GetPracticasList(false);
                    break;

                case EntityMngFormTypeData.ByParameter:
                    _sorted_list = List.GetSortedList();
                    break;
            }
            PgMng.Grow(string.Empty, "Lista de Partes de Asistencia");
        }

        protected override void RefreshSources()
        {
            switch (FilterType)
            {
                case IFilterType.None:
                    SetMainList(_sorted_list, true);
                    PgMng.Grow(string.Empty, "Ordenar Lista");
                    break;

                case IFilterType.Filter:
                    SetMainList(_filter_results, true);
                    PgMng.Grow(string.Empty, "Ordenar Lista");
                    break;
            }
            base.RefreshSources();
        }

        public override void UpdateList()
        {
            switch (_current_action)
            {
                case molAction.Add:
                    if (_entity == null) return;
                    List.AddItem(_entity.GetInfo(false));
                    if (FilterType == IFilterType.Filter)
                    {
                        ParteAsistenciaList listA = ParteAsistenciaList.GetList(_filter_results);
                        listA.AddItem(_entity.GetInfo(false));
                        _filter_results = listA.GetSortedList();
                    }
                    break;

                case molAction.Edit:
                case molAction.Lock:
                case molAction.Unlock:
                    if (_entity == null) return;
                    ActiveItem.CopyFrom(_entity);
                    break;

                case molAction.Delete:
                    if (ActiveItem == null) return;
                    List.RemoveItem(ActiveOID);
                    if (FilterType == IFilterType.Filter)
                    {
                        ParteAsistenciaList listD = ParteAsistenciaList.GetList(_filter_results);
                        listD.RemoveItem(ActiveOID);
                        _filter_results = listD.GetSortedList();
                    }
                    break;
            }

            _entity = null;
            RefreshSources();
        }

        /// <summary>
        /// Selecciona un elemento de la tabla
        /// </summary>
        /// <param name="oid">Identificar del elemento</param>
        protected override void Select(long oid)
        {
            int foundIndex = Datos.IndexOf(List.GetItem(oid));
            Datos.Position = foundIndex;
        }

        /// <summary>
        /// Filtra la tabla
        /// </summary>
        /// <param name="oid">Identificar del elemento</param>
        protected override void SetFilter(bool on)
        {
            try
            {
                SetMainList(on ? _filter_results : _sorted_list, true);
            }
            catch (Exception)
            {
                SetMainList(_sorted_list, true);
            }

            base.SetFilter(on);
        }

        #endregion

        #region Actions

        /// <summary>
        /// Abre el formulario para añadir item
        /// <returns>void</returns>
        /// </summary>
        /* public override void OpenAddForm()
         {
             try
             {
                 AddForm(new PAsistenciaAddForm());
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
         }*/

        /// <summary>
        /// Abre el formulario para ver item
        /// <returns>void</returns>
        /// </summary>
        public override void OpenViewForm()
        {
            try
            {
                AddForm(new FormularioNotasPracticasViewForm(ActiveOID));
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

        /// <summary>
        /// Abre el formulario para editar item
        /// <returns>void</returns>
        /// </summary>
        public override void OpenEditForm()
        {
            try
            {
                FormularioNotasPracticasEditForm form = new FormularioNotasPracticasEditForm(ActiveOID);
                if (form.Entity != null)
                {
                    AddForm(form);
                    _entity = form.Entity;
                }
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

        /// <summary>
        /// Abre el formulario para borrar item
        /// <returns>void</returns>
        /// </summary>
        public override void DeleteObject(long oid)
        {
            //if (MessageBox.Show(moleQule.Face.Resources.Messages.DELETE_CONFIRM,
            //                    moleQule.Face.Resources.Labels.ADVISE_TITLE,
            //                    MessageBoxButtons.YesNoCancel,
            //                    MessageBoxIcon.Question) == DialogResult.Yes)
            //{
                try
                {
                    //ParteAsistenciaInfo parte = ParteAsistenciaInfo.Get(oid, true);
                    //if (parte.Conceptos.Count > 0)
                    //{
                    //    PgMng.ShowInfoException(Resources.Messages.PARTE_CON_CONCEPTOS_ASOCIADOS);
                    //    _action_result = DialogResult.Ignore;
                    //    return;
                    //}
                    ParteAsistencia.Delete(oid);
                    _action_result = DialogResult.OK;

                    //Se eliminan todos los formularios de ese objeto
                    foreach (ItemMngBaseForm form in _list_active_form)
                    {
                        if (form.Oid == oid)
                        {
                            form.Dispose();
                            break;
                        }
                    }
                }
                catch (Csla.DataPortalException ex)
                {
                    MessageBox.Show(iQExceptionHandler.GetiQException(ex).Message);
                }
            //}
        }

        /// <summary>Imprime la lista del objetos
        /// <returns>void</returns>
        /// </summary>
        public override void PrintList()
        {
            /*ParteAsistenciaReportMng reportMng = new ParteAsistenciaReportMng(AppContext.ActiveSchema);
			
            ParteAsistenciaListRpt report = reportMng.GetListReport(List);
			
            if (report != null)
            {
                ReportViewer.SetReport(report);
                ReportViewer.ShowDialog();
            }
            else
            {
                MessageBox.Show(moleQule.Face.Resources.Messages.NO_DATA_REPORTS,
                                moleQule.Face.Resources.Labels.ADVISE_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }*/
        }

        protected override bool DoFind(object value)
        {
            FilterItem fItem = new FilterItem();
            fItem.Column = ((DataGridViewColumn)(Fields_CB.SelectedItem)).Name;
            fItem.Value = value;
            fItem.FilterProperty = FilterProperty;
            fItem.Operation = _operation;
            _search_results = Localize(fItem);
            return _search_results != null;
        }

        protected override bool DoFilter(FilterItem fItem)
        {
            _filter_results = Localize(fItem);
            return _filter_results != null;
        }


        protected new SortedBindingList<ParteAsistenciaInfo> Localize(FilterItem item)
        {
            SortedBindingList<ParteAsistenciaInfo> list = null;
            ParteAsistenciaList sourceList = null;

            switch (FilterType)
            {
                case IFilterType.None:
                    if (List == null)
                    {
                        MessageBox.Show(Face.Resources.Messages.NO_RESULTS);
                        return null;
                    }
                    sourceList = List;
                    break;

                case IFilterType.Filter:
                    if (FilteredList == null)
                    {
                        MessageBox.Show(Face.Resources.Messages.NO_RESULTS);
                        return null;
                    }
                    sourceList = FilteredList;
                    break;
                default:
                    sourceList = List;
                    break;
            }

            if (item.FilterProperty == IFilterProperty.All)
            {
                FCriteria criteria = GetCriteria(string.Empty, item.Value, null, item.Operation);
                list = sourceList.GetSortedSubList(criteria, _properties_list);
            }
            else
            {
                FCriteria criteria = GetCriteria(item.Column, item.Value, null, item.Operation);
                list = sourceList.GetSortedSubList(criteria, _properties_list);
            }

            if (list.Count == 0)
            {
                MessageBox.Show(Face.Resources.Messages.NO_RESULTS);
                return sourceList.GetSortedList();
            }

            DatosSearch.DataSource = list;
            DatosSearch.MoveFirst();

            AddFilterLabel(item);

            return list;
        }

        #endregion

    }

    public partial class FormularioNotasPracticasMngBaseForm : Skin06.EntityMngSkinForm<ParteAsistenciaList, ParteAsistenciaInfo>
    {
        public FormularioNotasPracticasMngBaseForm()
            : this(false, null, null) { }

        public FormularioNotasPracticasMngBaseForm(bool isModal, Form parent, ParteAsistenciaList lista)
            : base(isModal, parent, lista) { }
    }
}
