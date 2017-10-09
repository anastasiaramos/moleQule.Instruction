using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Hipatia;
using moleQule.Library.Instruction; 
using moleQule.Library.Instruction.Reports.Instructor;
using moleQule.Face;
using moleQule.Face.Hipatia;

namespace moleQule.Face.Instruction
{
    public partial class ModuloMngForm : ModuloMngBaseForm
    {

        #region Attributes & Properties
		
        public const string ID = "ModuloMngForm";
        public static Type Type { get { return typeof(ModuloMngForm); } }
        public override Type EntityType { get { return typeof(Modulo); } }

		protected override int BarSteps { get { return base.BarSteps + 3; } }

        protected Modulo _entity;
		
		#endregion
		
		#region Factory Methods

		public ModuloMngForm()
            : this(false) {}

		public ModuloMngForm(bool isModal)
            : this(isModal, null) { }

        public ModuloMngForm(Form parent)
            : this(false, parent) { }
		
		public ModuloMngForm(bool isModal, Form parent)
			: this(isModal, parent, null) {}
		
		public ModuloMngForm(bool isModal, Form parent, ModuloList list)
			: base(isModal, parent, list)
        {
            InitializeComponent();
            SetView(molView.Normal);
            _sort_property = NumeroModulo.DataPropertyName;

            // Parche para poder abrir el formulario en modo diseño y no perder la configuracion de columnas
            DatosLocal_BS = Datos;
            Tabla.DataSource = DatosLocal_BS;

            SetMainDataGridView(Tabla);
            Datos.DataSource = ModuloList.NewList().GetSortedList();
            base.SortProperty = NumeroModulo.DataPropertyName;
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

        //#region Layout

        //public override void FitColumns()
        //{
        //    List<DataGridViewColumn> cols = new List<DataGridViewColumn>();
        //    Texto.Tag = 1;

        //    cols.Add(Texto);

        //    ControlsMng.MaximizeColumns(Tabla, cols);
        //}

        //protected override void SetView(molView view)
        //{
        //    base.SetView(view);

        //    switch (_view_mode)
        //    {
        //        case molView.Select:

        //            ShowAction(molAction.ShowDocuments);

        //            break;

        //        case molView.Normal:

        //            ShowAction(molAction.ShowDocuments);

        //            break;
        //    }
        //}

        //#endregion

        #region Autorizacion

        /// <summary>Aplica las reglas de validación de usuarios al formulario.
        /// <returns>void</returns>
        /// </summary>
        protected override void ApplyAuthorizationRules()
        {
            Tabla.Visible = Modulo.CanGetObject();
            Add_Button.Enabled = Modulo.CanAddObject();
            Edit_Button.Enabled = Modulo.CanEditObject();
            Delete_Button.Enabled = Modulo.CanDeleteObject();
            Print_Button.Enabled = Modulo.CanGetObject();
            View_Button.Enabled = Modulo.CanGetObject();
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
            Texto.Tag = 1;

            cols.Add(Texto);

            ControlsMng.MaximizeColumns(Tabla, cols);

            ControlsMng.OrderByColumn(Tabla, NumeroModulo, ListSortDirection.Ascending);
            SetGridFormat();
            ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla));

            Fields_CB.Text = NumeroModulo.HeaderText;

            SetColumnActive(ControlsMng.GetColumn(Tabla, NumeroModulo.DataPropertyName));

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

                    HideAction(molAction.SelectAll);

                    break;

                case molView.Normal:

                    ShowAction(molAction.ShowDocuments);

                    break;
            }
        }

        #endregion

        #region Source

        protected void SetMainList(SortedBindingList<ModuloInfo> list, bool order)
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
            PgMng.Grow(string.Empty, "Modulo");

            _selectedOid = ActiveOID;

            switch (DataType)
            {
                case EntityMngFormTypeData.Default:
                    List = ModuloList.GetList(false);
                    break;
                case EntityMngFormTypeData.ByParameter:
                    _sorted_list = List.GetSortedList();
                    break;
            }
            PgMng.Grow(string.Empty, "Lista de Módulos");
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
                        ModuloList listA = ModuloList.GetList(_filter_results);
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
                        ModuloList listD = ModuloList.GetList(_filter_results);
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
                ModuloAddForm form = new ModuloAddForm();
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
				AddForm(new ModuloViewForm(ActiveOID));
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
                ModuloEditForm form = new ModuloEditForm(ActiveOID);
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
                    
                    Modulo.Delete(oid);
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
                    Modulo old = Modulo.Get(oid);
                    Modulo dup = old.CloneAsNew();
                    old.CloseSession();
					
                    AddForm(new ModuloAddForm(dup));
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
			/*ModuloReportMng reportMng = new ModuloReportMng(AppContext.ActiveSchema);
			
			ModuloListRpt report = reportMng.GetListReport(List);
			
			if (report != null)
			{
				ReportViewer.SetReport(report);
				ReportViewer.ShowDialog();
			}
			else
			{
				MessageBox.Show(Resources.Messages.NO_DATA_REPORTS,
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

    public partial class ModuloMngBaseForm : Skin06.EntityMngSkinForm<ModuloList, ModuloInfo>
    {
        public ModuloMngBaseForm()
            : this(false, null, null) { }

        public ModuloMngBaseForm(bool isModal, Form parent, ModuloList lista)
            : base(isModal, parent, lista) { }
    }
}
