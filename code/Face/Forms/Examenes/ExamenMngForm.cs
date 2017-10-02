using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Instruction; 
using moleQule.Library.Instruction.Reports;
using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class ExamenMngForm : Skin02.EntityLMngSkinForm
    {

        #region Attributes & Properties

        public const string ID = "ExamenMngForm";
        public static Type Type { get { return typeof(ExamenMngForm); } }
        public override Type EntityType { get { return typeof(Examen); } }

        protected override int BarSteps { get { return base.BarSteps + 5; } }

        protected Examen _entity;

        protected ModuloList _modulos = null;

        /// <summary>
        /// List de objetos
        /// </summary>
        private new ExamenList List 
        { 
            get { return _item_list as ExamenList; } 
            set { _item_list = value; _sorted_list = (value as ExamenList).GetSortedList(); } 
        }

        /// <summary>
        ///  Lista de objetos de sólo lectura filtrados
        /// </summary>
        internal new ExamenList FilteredList { get { return ExamenList.GetList(_filter_results); } }

        /// <summary>
        ///  Lista de objetos ordenados
        /// </summary>
        internal new SortedBindingList<ExamenInfo> SortedList { get { return _sorted_list; } }
        
        private new SortedBindingList<ExamenInfo> _sorted_list = null;
        private new SortedBindingList<ExamenInfo> _filter_results = null;
        private new SortedBindingList<ExamenInfo> _search_results = null;

        /// <summary>
        /// Devuelve el OID del objeto activo seleccionado de la tabla
        /// </summary>
        /// <returns></returns>
        public override long ActiveOID { get { return ActiveItem != null ? ActiveItem.Oid : -1; } }

        /// <summary>
        /// Devuelve el objeto activo seleccionado de la tabla
        /// </summary>
        /// <returns></returns>
        public ExamenInfo ActiveItem { get { return (Datos.Current != null) ? Datos.Current as ExamenInfo : null; } }

        /// <summary>
        /// Devuelve el objeto activo seleccionado de la tabla
        /// </summary>
        /// <returns></returns>
        public SortedBindingList<ExamenInfo> ActiveList { get { return (Datos.List as SortedBindingList<ExamenInfo>); } }

        public override long ActiveFoundOID { get { return (DatosSearch.Current != null) ? ((ExamenInfo)(DatosSearch.Current)).Oid : -1; } }

        public override string SortProperty { get { return this.GetGridSortProperty(Tabla); } }
        public override ListSortDirection SortDirection { get { return this.GetGridSortDirection(Tabla); } }

        public string CurrentModulo { get { return (Modulo_CB.SelectedItem != null) ? (Modulo_CB.SelectedItem as ComboBoxSource).Texto : string.Empty; } }
        public string CurrentPromocion { get { return (Promocion_CB.SelectedItem != null) ? (Promocion_CB.SelectedItem as ComboBoxSource).Texto : string.Empty; } }

        #endregion

        #region Factory Methods

        public ExamenMngForm()
            : this(false) { }

        public ExamenMngForm(bool isModal)
            : this(isModal, null) { }

        public ExamenMngForm(Form parent)
            : this(false, parent, null) { }

        public ExamenMngForm(bool isModal, Form parent)
            : this(isModal, parent, null) { }

        public ExamenMngForm(bool isModal, Form parent, ExamenList list)
            : base(isModal, parent, list)
        {
            InitializeComponent();
            SetView(molView.Normal);

            // Parche para poder abrir el formulario en modo diseño y no perder la configuracion de columnas
            DatosLocal_BS = Datos;
            Tabla.DataSource = DatosLocal_BS;

            TablaBase = Tabla;
            Datos.DataSource = ExamenList.NewList().GetSortedList();

            SortProperty = Numero.DataPropertyName;
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
            Tabla.Visible = Examen.CanGetObject();
            Add_Button.Enabled = Examen.CanAddObject();
            Edit_Button.Enabled = Examen.CanEditObject();
            Delete_Button.Enabled = Examen.CanDeleteObject();
            Print_Button.Enabled = Examen.CanGetObject();
            View_Button.Enabled = Examen.CanGetObject();
        }

        #endregion

        #region Source

        protected void SetMainList(SortedBindingList<ExamenInfo> list, bool order)
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

        protected override void RefreshMainData()
        {
            PgMng.Grow(string.Empty, "Exámenes");

            _selectedOid = ActiveOID;

            switch (DataType)
            {
                case EntityMngFormTypeData.Default:
                    List = ExamenList.GetList(false);
                    break;

                case EntityMngFormTypeData.ByParameter:
                    _sorted_list = List.GetSortedList();
                    break;
            }
            PgMng.Grow(string.Empty, "Lista de Exámenes");
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

            List<DataGridViewColumn> cols = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn col in Tabla.Columns)
                if (col.Visible) cols.Add(col);

            Fields_CB.DataSource = cols;
            Fields_CB.DisplayMember = "HeaderText";
            Fields_CB.ValueMember = "DataPropertyName";
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
                        ExamenList list = ExamenList.GetList(_filter_results);
                        list.AddItem(_entity.GetInfo(false));
                        _filter_results = list.GetSortedList();
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
                        ExamenList list = ExamenList.GetList(_filter_results);
                        list.RemoveItem(ActiveOID);
                        _filter_results = list.GetSortedList();
                    }
                    break;
            }

            _entity = null;
            RefreshSources();
        }

        public override void RefreshSecondaryData()
        {
            Datos_Modulos.DataSource = new Library.Instruction.HComboBoxSourceList(ModuloList.GetOrderedList(false));
            PgMng.Grow(string.Empty, "Modulos");

            Datos_Promociones.DataSource = new Library.Instruction.HComboBoxSourceList(PromocionList.GetList(false));
            PgMng.Grow(string.Empty, "Promociones");
        }
       
        protected override void Select(long oid)
        {
            int foundIndex = Datos.IndexOf(List.GetItem(oid));
            Datos.Position = foundIndex;
        }

        /// <summary>Aplica el filtro seleccionado
        /// <returns>void</returns>
        /// </summary>
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

        #region Style & Format

        public override void FormatControls()
        {
            if (Tabla == null) return;

            base.FormatControls();

            PanelesSearch.IsSplitterFixed = false;
            PanelesSearch.SplitterDistance = PanelesSearch.Height - PanelesSearch.SplitterWidth
                                                                    - Campos_Panel.Height
                                                                    - Navegador.Height
                                                                    - 4 /*Margen*/
                                                                    - Campos2_Panel.Height
                                                                    - 4;
            PanelesSearch.IsSplitterFixed = true;

            Campos2_Panel.Left = (this.Width - Campos2_Panel.Width) / 2;

            List<DataGridViewColumn> cols = new List<DataGridViewColumn>();
            Titulo.Tag = 0.6;
            Modulo.Tag = 0.4;

            cols.Add(Titulo);
            cols.Add(Modulo);

            ControlsMng.MaximizeColumns(Tabla, cols);
            ControlsMng.OrderByColumn(Tabla, FechaExamen, ListSortDirection.Ascending);
            SetGridFormat();
            if (ControlsMng.GetCurrentCell(Tabla) != null)
            {
                DataGridViewCellStyle estilo = ControlsMng.GetCurrentCell(Tabla).Style;
                estilo.BackColor = Color.LightGray;
                ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla), estilo);
            }

            Fields_CB.Text = FechaExamen.HeaderText;

            SetColumnActive(ControlsMng.GetColumn(Tabla, Titulo.DataPropertyName));
        }

        protected override void SetView(molView view)
        {
            base.SetView(view);

            switch (_view_mode)
            {
                case molView.Select:

                    break;

                case molView.Normal:

                    ShowAction(molAction.Copy);

                    break;
            }
        }

        protected override void SetRowFormat(DataGridViewRow row)
        {
            if (row.IsNewRow) return;
            ExamenInfo item = (ExamenInfo)row.DataBoundItem;

            item = row.DataBoundItem as ExamenInfo;

            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
        }

        #endregion

        #region Actions

        public override void OpenAddForm()
        {
            try
            {
                ExamenAddForm form = new ExamenAddForm(true);
                AddForm(form);
                _entity = form.Entity;
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

        public override void OpenViewForm()
        {
            try
            {
                ExamenInfo examen = ExamenInfo.Get(ActiveOID, false);

                if (examen != null)
                {
                    //Si el examen no está emitido
                    if (examen.FechaEmision.Date.Equals(DateTime.MaxValue.Date))
                        AddForm(new ExamenViewForm(ActiveOID));

                    else //En caso de que el examen haya sido emitido
                    {
                        ExamenEmitidoEditForm form = new ExamenEmitidoEditForm(ActiveOID);
                        if (form.Entity != null)
                            AddForm(form);
                    }
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

        public override void OpenEditForm()
        {
            try
            {
                ExamenInfo examen = ExamenInfo.Get(ActiveOID, false);

                if (examen != null)
                {
                    //Si el examen no está emitido
                    if (examen.FechaEmision.Date.Equals(DateTime.MaxValue.Date))
                    {
                        ExamenEditForm form = new ExamenEditForm(ActiveOID);
                        if (form.Entity != null)
                        {
                            AddForm(form);
                            _entity = form.Entity;
                        }

                    }
                    else //En caso de que el examen haya sido emitido
                    {
                        ExamenEmitidoEditForm form = new ExamenEmitidoEditForm(ActiveOID);
                        if (form.Entity != null)
                        {
                            AddForm(form);
                            _entity = form.Entity;
                        }
                    }
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

        public void OpenEditForm(long oid_examen)
        {
            try
            {
                ExamenInfo examen = ExamenInfo.Get(oid_examen, false);

                if (examen != null)
                {
                    //Si el examen no está emitido
                    if (examen.FechaEmision.Date.Equals(DateTime.MaxValue.Date))
                    {
                        ExamenEditForm form = new ExamenEditForm(oid_examen);
                        if (form.Entity != null)
                        {
                            AddForm(form);
                            _entity = form.Entity;
                        }

                    }
                    else //En caso de que el examen haya sido emitido
                    {
                        ExamenEmitidoEditForm form = new ExamenEmitidoEditForm(oid_examen);
                        if (form.Entity != null)
                        {
                            AddForm(form);
                            _entity = form.Entity;
                        }
                    }
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

        public override void DeleteObject(long oid)
        {
            //if (MessageBox.Show(moleQule.Face.Resources.Messages.DELETE_CONFIRM,
            //                    moleQule.Face.Resources.Labels.ADVISE_TITLE,
            //                    MessageBoxButtons.YesNoCancel,
            //                    MessageBoxIcon.Question) == DialogResult.Yes)
            //{
                try
                {
                    ExamenInfo examen = ExamenInfo.Get(oid, false);
                    if (!examen.FechaEmision.Date.Equals(DateTime.MaxValue.Date)
                        && !examen.FechaEmision.Date.Equals(DateTime.MinValue))
                    {
                        MessageBox.Show("No se puede eliminar un examen que ha sido emitido.");
                        _action_result = DialogResult.Ignore;
                        return;
                    }
                    string memo = examen.MemoPreguntas;
                    if (memo != string.Empty)
                    {
                        MessageBox.Show("No se puede eliminar un examen que incluye preguntas." +
                            Environment.NewLine +
                            "Libere las preguntas.");
                        _action_result = DialogResult.Ignore;
                        return;
                    }
                    Examen.Delete(oid);
                    _action_result = DialogResult.OK;

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
            //}
        }

        /// <summary>Duplica un objeto y abre el formulario para editar item
        /// <returns>void</returns>
        /// </summary>
        public override void CopyObjectAction(long oid)
        {
            try
            {
                Examen new_item = Examen.Duplicate(oid);

                if (new_item != null)
                {
                    ExamenAddForm add_form = new ExamenAddForm(new_item);
                    AddForm(add_form);

                    if (add_form.ActionResult == DialogResult.OK)
                    {
                        PgMng.Reset(3, 1, Resources.Messages.LOADING_DATA, this);

                        new_item = Examen.Get(add_form.Entity.Oid);
                        bool no_disponibles = new_item.DuplicateList(oid);
                        PgMng.Grow();

                        new_item.Save();
                        new_item.CloseSession();
                        PgMng.Grow();

                        if (no_disponibles)
                            PgMng.ShowInfoException(Resources.Messages.EXAMEN_DUPLICADO_CON_PREGUNTAS_NO_DISPONIBLES);

                        PgMng.FillUp();

                        ExamenEditForm form = new ExamenEditForm(new_item.Oid); 
                        AddForm(form);
                    }
                }
            }
            catch (iQException ex)
            {
                MessageBox.Show(ex.Message,
                                moleQule.Face.Resources.Labels.ERROR_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            catch (Csla.DataPortalException ex)
            {
                MessageBox.Show(iQExceptionHandler.GetiQException(ex).Message,
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

            RefreshList();
        }

        public override void PrintList() { }
        protected override bool DoFind(object value)
        {
            _search_results = Localize(value, ((DataGridViewColumn)(Fields_CB.SelectedItem)).Name);
            return _search_results != null;
        }

        //protected bool DoFilter(object value)
        //{
        //    _filter_results = Localize(value, ((DataGridViewColumn)(Fields_CB.SelectedItem)).Name);
        //    return _filter_results != null;
        //}

        protected override bool DoFilter(object value, object secondValue = null)
        {
            _filter_results = Localize(value, Tabla.Columns[((DataGridViewColumn)(Fields_CB.SelectedItem)).Name].DataPropertyName);
            return _filter_results != null;
        }

        protected new SortedBindingList<ExamenInfo> Localize(object value, string column_name)
        {
            SortedBindingList<ExamenInfo> list = null;
            ExamenList sourceList = null;

            switch (FilterType)
            {
                case IFilterType.None:
                    if (List == null)
                    {
                        MessageBox.Show(moleQule.Face.Resources.Messages.NO_RESULTS);
                        return null;
                    }
                    sourceList = List;
                    break;

                case IFilterType.Filter:
                    if (FilteredList == null)
                    {
                        MessageBox.Show(moleQule.Face.Resources.Messages.NO_RESULTS);
                        return null;
                    }
                    sourceList = FilteredList;
                    break;
                default:
                    sourceList = List;
                    break;
            }

            FCriteria criteria = null;
            string related = "none";

            switch (column_name)
            {
                default:
                    criteria = GetCriteria(column_name, value, null, _operation);
                    break;
            }

            switch (related)
            {
                case "none":
                    list = sourceList.GetSortedSubList(criteria);
                    break;
            }

            if (list.Count == 0)
            {
                MessageBox.Show(moleQule.Face.Resources.Messages.NO_RESULTS);
                return sourceList.GetSortedList();
            }

            DatosSearch.DataSource = list;
            DatosSearch.MoveFirst();

            AddFilterItem(column_name, value);

            Tabla.Focus();

            return list;
        }

        protected bool DoFilterByProperty(object value, string column_name)
        {
            _filter_results = Localize(value, column_name);
            return _filter_results != null;
        }

        protected void FilterByModuloAction()
        {
            if (Modulo_CB.SelectedItem != null)
            {
                if (CurrentModulo != string.Empty)
                {
                    _filter_type = IFilterType.None;

                    if (DoFilterByProperty(CurrentModulo, Modulo.Name))
                    {
                        SetFilter(true);
                        _filter_type = IFilterType.Filter;
                    }
                }
                else
                {
                    SetFilter(false);
                    _filter_type = IFilterType.None;
                }
            }
        }

        protected void FilterByPromocionAction()
        {
            if (Promocion_CB.SelectedItem != null)
            {
                FilterByModuloAction();

                if (CurrentPromocion != string.Empty)
                {
                    if (DoFilterByProperty(CurrentPromocion, Promocion.Name))
                    {
                        SetFilter(true);
                        _filter_type = IFilterType.Filter;
                    }
                }
            }
        }
        
        #endregion

        #region Buttons

        #endregion

        #region Events

        private void Tabla_KeyPress(object sender, KeyPressEventArgs e)
        {
            FilterByKey(e.KeyChar.ToString());
        }

        private void Tabla_DoubleClick(object sender, EventArgs e)
        {
            ExecuteAction(molAction.Default);
        }

        private void Tabla_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ControlsMng.SetCurrentCell(Tabla);
            SetGridFormat();
            DataGridViewCellStyle estilo = ControlsMng.GetCurrentCell(Tabla).Style;
            estilo.BackColor = Color.LightGray;
            ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla), estilo);
            Fields_CB.Text = ControlsMng.GetCurrentColumn(Tabla).HeaderText; 
        }

        private void Tabla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellStyle estilo = ControlsMng.GetCurrentCell(Tabla).Style;
            estilo.BackColor = Color.LightGray;
            ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla), estilo);
            Fields_CB.Text = ControlsMng.GetCurrentColumn(Tabla).HeaderText; 
        }

        private void Modulo_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Modulo_CB.SelectedItem != null)
            {
                FilterByModuloAction();
            }
        }

        private void Promocion_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Promocion_CB.SelectedItem != null)
            {
                FilterByPromocionAction();
            }
        }

        private void Tabla_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!_show_colors) return;

            SetRowFormat(Tabla.Rows[e.RowIndex]);
        }

        #endregion

    }
}
