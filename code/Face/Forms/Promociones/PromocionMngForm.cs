using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Hipatia;
using moleQule.Library.Instruction;
using moleQule.Library.Instruction.Reports.Promocion;
using moleQule.Face;
using moleQule.Face.Hipatia;

namespace moleQule.Face.Instruction
{
    public partial class PromocionMngForm : PromocionMngBaseForm
    {
        #region Attributes & Properties

        public const string ID = "PromocionMngForm";
        public static Type Type { get { return typeof(PromocionMngForm); } }
        public override Type EntityType { get { return typeof(Promocion); } }

        protected override int BarSteps { get { return base.BarSteps + 3; } }

        protected Promocion _entity;

        #endregion
		
		#region Factory Methods

		public PromocionMngForm()
            : this(false) {}

		public PromocionMngForm(bool isModal)
            : this(isModal, null) { }

        public PromocionMngForm(Form parent)
            : this(false, parent) { }
		
		public PromocionMngForm(bool isModal, Form parent)
			: this(isModal, parent, null) {}
		
		public PromocionMngForm(bool isModal, Form parent, PromocionList list)
			: base(isModal, parent, list)
        {
            InitializeComponent();

            SetView(molView.Normal);
            _sort_property = Codigo.DataPropertyName;

            // Parche para poder abrir el formulario en modo diseño y no perder la configuracion de columnas
            DatosLocal_BS = Datos;
            Tabla.DataSource = DatosLocal_BS;

            SetMainDataGridView(Tabla);
            Datos.DataSource = PromocionList.NewList().GetSortedList();
            base.SortProperty = Codigo.DataPropertyName;
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
            Tabla.Visible = Promocion.CanGetObject();
            Add_Button.Enabled = Promocion.CanAddObject();
            Edit_Button.Enabled = Promocion.CanEditObject();
            Delete_Button.Enabled = Promocion.CanDeleteObject();
            Print_Button.Enabled = Promocion.CanGetObject();
            View_Button.Enabled = Promocion.CanGetObject();
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

            List<DataGridViewColumn> cols = new List<DataGridViewColumn>();
            Observaciones.Tag = 1;

            cols.Add(Observaciones);

            ControlsMng.MaximizeColumns(Tabla, cols);

            ControlsMng.OrderByColumn(Tabla, Codigo, ListSortDirection.Descending);
            SetGridFormat();
            ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla));

            Fields_CB.Text = Codigo.HeaderText;

            SetColumnActive(ControlsMng.GetColumn(Tabla, Codigo.DataPropertyName));

        }

        protected override void SetView(molView view)
        {
            base.SetView(view);

            switch (_view_mode)
            {
                case molView.Select:
                    
                    HideAction(molAction.Add);
                    HideAction(molAction.Edit);
                    HideAction(molAction.Delete);
                    HideAction(molAction.View);

                    break;

                case molView.Normal:

                    ShowAction(molAction.ShowDocuments);

                    break;
            }
        }

        #endregion

        #region Source

        protected void SetMainList(SortedBindingList<PromocionInfo> list, bool order)
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
            PgMng.Grow(string.Empty, "Promocion");

            _selectedOid = ActiveOID;

            switch (DataType)
            {
                case EntityMngFormTypeData.Default:
                    List = PromocionList.GetList(false);
                    break;
                case EntityMngFormTypeData.ByParameter:
                    _sorted_list = List.GetSortedList();
                    break;
            }
            PgMng.Grow(string.Empty, "Lista de Promociones");
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
                        PromocionList listA = PromocionList.GetList(_filter_results);
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
                        PromocionList listD = PromocionList.GetList(_filter_results);
                        listD.RemoveItem(ActiveOID);
                        _filter_results = listD.GetSortedList();
                    }
                    break;
            }

            RefreshSources();
            if (_entity != null) Select(_entity.Oid);
            _entity = null;
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

        public override void OpenAddForm()
        {
            PromocionAddForm form = new PromocionAddForm();
            AddForm(form);
            if (form.ActionResult == DialogResult.OK) _entity = form.Entity;
        }

		/// <summary>
		/// Abre el formulario para ver item
		/// <returns>void</returns>
		/// </summary>
		public override void OpenViewForm()
		{			
			try
			{
				AddForm(new PromocionViewForm(ActiveOID));
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
                PromocionEditForm form = new PromocionEditForm(ActiveOID);
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
                    
                    Promocion.Delete(oid);
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

		/// <summary>Duplica un objeto y abre el formulario para editar item
		/// <returns>void</returns>
		/// </summary>
		/*public override void DuplicateObject(long oid) 
		{
			try
			{
                    Promocion old = Promocion.Get(oid);
                    Promocion dup = old.CloneAsNew();
                    old.CloseSession();
					
                    AddForm(new PromocionAddForm(dup));
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
		}*/

		/// <summary>Imprime la lista del objetos
		/// <returns>void</returns>
		/// </summary>
		public override void PrintList() 
		{
			/*PromocionReportMng reportMng = new PromocionReportMng(AppContext.ActiveSchema);
			
			PromocionListRpt report = reportMng.GetListReport(List);
			
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

        public override void ShowDocumentsAction()
        {
            try
            {
                AgenteInfo agent = AgenteInfo.Get(ActiveItem.TipoEntidad, ActiveItem);
                AgenteEditForm form = new AgenteEditForm(ActiveItem.TipoEntidad, ActiveItem, this);
                AddForm(form);
            }
            catch (HipatiaException ex)
            {
                if (ex.Code == HipatiaCode.NO_AGENTE)
                {
                    AgenteAddForm form = new AgenteAddForm(ActiveItem.TipoEntidad, ActiveItem, this);
                    AddForm(form);
                }
            }
        }

		#endregion

    }

    public partial class PromocionMngBaseForm : Skin06.EntityMngSkinForm<PromocionList, PromocionInfo>
    {
        public PromocionMngBaseForm()
            : this(false, null, null) { }

        public PromocionMngBaseForm(bool isModal, Form parent, PromocionList lista)
            : base(isModal, parent, lista) { }
    }
}
