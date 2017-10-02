using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Csla;
using CslaEx;

using moleQule.Library;
using moleQule.Library.Instruction;
using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class PlanExtraMngForm : Skin02.EntityLMngSkinForm
    {

        #region Attributes & Properties
		
        public const string ID = "PlanExtraMngForm";
        public static Type Type { get { return typeof(PlanExtraMngForm); } }
        public override Type EntityType { get { return typeof(PlanExtra); } }

		protected override int BarSteps { get { return base.BarSteps + 4; } }

        protected PlanExtra _entity;

        private new SortedBindingList<PlanExtraInfo> _filter_results = null;
        private new SortedBindingList<PlanExtraInfo> _sorted_list = null;
        private new SortedBindingList<PlanExtraInfo> _search_results = null;

        /// <summary>
        ///  Lista de objetos de sólo lectura
        /// </summary>
        internal new PlanExtraList List
        {
            get { return _item_list as PlanExtraList; }
            set { _item_list = value; _sorted_list = (value as PlanExtraList).GetSortedList(); }
        }
        internal new SortedBindingList<PlanExtraInfo> SortedList { get { return _sorted_list; } }
        internal new PlanExtraList FilteredList { get { return PlanExtraList.GetList(_filter_results); } }
        internal SortedBindingList<PlanExtraInfo> CurrentList { get { return (Datos.List as SortedBindingList<PlanExtraInfo>); } } 

		/// <summary>
		/// Devuelve el OID del objeto activo seleccionado de la tabla
		/// </summary>
		/// <returns></returns>
		public override long ActiveOID { get { return Datos.Current != null ? ((PlanExtraInfo)Datos.Current).Oid : -1; } }

        /// <summary>
        /// Devuelve el objeto activo seleccionado de la tabla
        /// </summary>
        /// <returns></returns>
        public PlanExtraInfo ActiveItem { get { return (Datos.Current != null) ? (PlanExtraInfo)Datos.Current : null; } }
		
        public override long ActiveFoundOID { get { return (DatosSearch.Current != null) ? ((PlanExtraInfo)(DatosSearch.Current)).Oid : -1; } }

        public override string SortProperty { get { return this.GetGridSortProperty(Tabla); } }
        public override ListSortDirection SortDirection { get { return this.GetGridSortDirection(Tabla); } }
		
		#endregion
		
		#region Factory Methods

		public PlanExtraMngForm()
            : this(false) {}

		public PlanExtraMngForm(bool isModal)
            : this(isModal, null) { }

        public PlanExtraMngForm(Form parent)
            : this(false, parent) { }
		
		public PlanExtraMngForm(bool isModal, Form Parent)
			: base(isModal, Parent)
		{
			InitializeComponent();
            SetView(molView.Normal);

            // Parche para poder abrir el formulario en modo diseño y no perder la configuracion de columnas
            DatosLocal_BS = Datos;
            Tabla.DataSource = DatosLocal_BS;
            TablaBase = Tabla;

            base.SortProperty = Nombre.Name;
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
			Tabla.Visible = PlanExtra.CanGetObject();
            Add_Button.Enabled = PlanExtra.CanAddObject();
            Edit_Button.Enabled = PlanExtra.CanEditObject();
            Delete_Button.Enabled = PlanExtra.CanDeleteObject();
            Print_Button.Enabled = PlanExtra.CanGetObject();
            View_Button.Enabled = PlanExtra.CanGetObject();
		}

		#endregion

		#region Style & Source

		/// <summary>Formatea los controles del formulario
		/// <returns>void</returns>
		/// </summary>
		public override void FormatControls()
		{
            if (Tabla == null) return;

            base.FormatControls();

            HideAction(molAction.Copy);
            HideAction(molAction.Print);

            List<DataGridViewColumn> cols = new List<DataGridViewColumn>();

            Observaciones.Tag = 1;
            cols.Add(Observaciones);

            ControlsMng.MaximizeColumns(Tabla, cols);
            SetGridFormat();
            ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla));
            
            Fields_CB.Text = Nombre.HeaderText;

        }

        #endregion

        #region Source

        protected void SetMainList(SortedBindingList<PlanExtraInfo> list, bool order)
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
            PgMng.Grow(string.Empty, "PlanExtra");

            _selected_oid = ActiveOID;

            switch (DataType)
            {
                case EntityMngFormTypeData.Default:
                    List = PlanExtraList.GetList(false);
                    break;

                case EntityMngFormTypeData.ByParameter:
                    _sorted_list = List.GetSortedList();
                    break;
            }
            PgMng.Grow(string.Empty, "Lista de Productos");
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
                        PlanExtraList listA = PlanExtraList.GetList(_filter_results);
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
                        PlanExtraList listD = PlanExtraList.GetList(_filter_results);
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
        public override void OpenAddForm()
        {
            try
            {
                PlanExtraAddForm form = new PlanExtraAddForm();
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

		/// <summary>
		/// Abre el formulario para ver item
		/// <returns>void</returns>
		/// </summary>
		public override void OpenViewForm()
		{
			
			try
			{
                AddForm(new PlanExtraViewForm(ActiveOID));
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
                PlanExtraEditForm form = new PlanExtraEditForm(ActiveOID);
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
			if (MessageBox.Show(moleQule.Face.Resources.Messages.DELETE_CONFIRM,
								moleQule.Face.Resources.Labels.ADVISE_TITLE,
								MessageBoxButtons.YesNoCancel, 
								MessageBoxIcon.Question) == DialogResult.Yes)
			{
				try
				{                    
                    PlanExtra.Delete(oid);
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
			}
		}

		/// <summary>Duplica un objeto y abre el formulario para editar item
		/// <returns>void</returns>
		/// </summary>
		public override void DuplicateObject(long oid) 
		{
			try
			{
                    PlanExtra old = PlanExtra.Get(oid);
                    PlanExtra dup = old.CloneAsNew();
                    old.CloseSession();
					
                    AddForm(new PlanExtraAddForm(dup));
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

		/// <summary>Imprime la lista del objetos
		/// <returns>void</returns>
		/// </summary>
		public override void PrintList() 
		{
			/*PlanExtraReportMng reportMng = new PlanExtraReportMng(AppContext.ActiveSchema);
			
			PlanExtraListRpt report = reportMng.GetListReport(list);
			
			if (report != null)
			{
				ReportViewer.SetReport(report);
				ReportViewer.ShowDialog();
			}
			else
			{
				MessageBox.Show(Messages.NO_DATA_REPORTS,
								moleQule.Face.Resources.Labels.ADVISE_TITLE,
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);
			}*/
		}

        protected override bool DoFind(object value)
        {
            _search_results = Localize(value, ((DataGridViewColumn)(Fields_CB.SelectedItem)).Name);
            return _search_results != null;
        }

        protected override bool DoFilter(object value)
        {
            _filter_results = Localize(value, ((DataGridViewColumn)(Fields_CB.SelectedItem)).Name);
            return _filter_results != null;
        }

        protected override bool DoFilterByFirst(string value, string column_name)
        {
            if (column_name == null)
                column_name = ControlsMng.GetCurrentColumn(Tabla).DataPropertyName;

            _filter_results = Localize(value, column_name);
            return _filter_results != null;
        }

        protected new SortedBindingList<PlanExtraInfo> Localize(object value, string column_name)
        {
            SortedBindingList<PlanExtraInfo> list = null;
            PlanExtraList sourceList = null;

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
            }

            FCriteria criteria = null;
            string related = "none";

            switch (column_name)
            {
                default:
                    {
                        criteria = GetCriteria(column_name, value, _operation);
                    } break;
            }

            switch (related)
            {
                case "none":
                    {
                        list = sourceList.GetSortedSubList(criteria);
                    } break;
            }

            if (list.Count == 0)
            {
                MessageBox.Show(moleQule.Face.Resources.Messages.NO_RESULTS);
                return sourceList.GetSortedList();
            }

            DatosSearch.DataSource = list;
            DatosSearch.MoveFirst();

            AddFilterLabel(column_name, value);

            Tabla.Focus();

            return list;
        }

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
            ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla));
            Fields_CB.Text = ControlsMng.GetCurrentColumn(Tabla).HeaderText; 
        }
        
        private void Tabla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla));
            Fields_CB.Text = ControlsMng.GetCurrentColumn(Tabla).HeaderText;
        }
		
		#endregion

    }
}
