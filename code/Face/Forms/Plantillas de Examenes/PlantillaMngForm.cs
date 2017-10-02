using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Hipatia;
using moleQule.Library.Instruction;
using moleQule.Face;
using moleQule.Face.Hipatia;

namespace moleQule.Face.Instruction
{
    public partial class PlantillaMngForm : PlantillaMngBaseForm
    {
        #region Attributes & Properties

        public const string ID = "PlantillaMngForm";
        public static Type Type { get { return typeof(PlantillaMngForm); } }
        public override Type EntityType { get { return typeof(PlantillaExamen); } }

        protected override int BarSteps { get { return base.BarSteps + 3; } }

        protected PlantillaExamen _entity;

        #endregion
		
		#region Factory Methods

		public PlantillaMngForm()
            : this(false) {}

		public PlantillaMngForm(bool isModal)
			: this(isModal, null) {}
		
		public PlantillaMngForm(bool isModal, Form parent)
            : this(isModal, parent, null) { }

        public PlantillaMngForm(Form parent)
            : this(false, parent) { }

        public PlantillaMngForm(bool isModal, Form parent, PlantillaExamenList list)
			: base(isModal, parent, list)
		{
			InitializeComponent();
            SetView(molView.Normal);

            // Parche para poder abrir el formulario en modo diseño y no perder la configuracion de columnas
            DatosLocal_BS = Datos;
            Tabla.DataSource = DatosLocal_BS;

            SetMainDataGridView(Tabla);
            Datos.DataSource = PlantillaExamenList.NewList().GetSortedList();
            SortProperty = Codigo.DataPropertyName;
        }
		
		#endregion
        
        #region Layout

        public override void FitColumns()
        {
            List<DataGridViewColumn> cols = new List<DataGridViewColumn>();
            Modulo.Tag = 1;

            cols.Add(Modulo);

            ControlsMng.MaximizeColumns(Tabla, cols);
        }

        protected override void SetView(molView view)
        {
            base.SetView(view);

            switch (_view_mode)
            {
                case molView.Select:

                    ShowAction(molAction.ShowDocuments);

                    break;

                case molView.Normal:

                    ShowAction(molAction.ShowDocuments);

                    break;
            }
        }

        #endregion

        #region Source

        protected override void RefreshMainData()
        {
            PgMng.Grow(string.Empty, "Plantilla de Examen");

            _selectedOid = ActiveOID;

            switch (DataType)
            {
                case EntityMngFormTypeData.Default:
                    List = PlantillaExamenList.GetList(false);
                    break;
                case EntityMngFormTypeData.ByParameter:
                    _sorted_list = List.GetSortedList();
                    break;
            }
            PgMng.Grow(string.Empty, "Lista de Plantillas de Examen");
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
                        PlantillaExamenList listA = PlantillaExamenList.GetList(_filter_results);
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
                        PlantillaExamenList listD = PlantillaExamenList.GetList(_filter_results);
                        listD.RemoveItem(ActiveOID);
                        _filter_results = listD.GetSortedList();
                    }
                    break;
            }

            RefreshSources();
            if (_entity != null) Select(_entity.Oid);
            _entity = null;
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
                PlantillaAddForm form = new PlantillaAddForm();
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

        /// <summary>
        /// Abre el formulario para editar item
        /// <returns>void</returns>
        /// </summary>
        public override void OpenEditForm() 
        {             
            try
            {
                PlantillaEditForm form = new PlantillaEditForm(ActiveOID);
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
                    
                    PlantillaExamen.Delete(oid);
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
                    PlantillaExamen old = PlantillaExamen.Get(oid);
                    PlantillaExamen dup = old.CloneAsNew();
                    old.CloseSession();
					
                    AddForm(new PlantillaExamenAddForm(dup));
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
			/*PlantillaExamenReportMng reportMng = new PlantillaExamenReportMng(AppContext.ActiveSchema);
			
			PlantillaExamenListRpt report = reportMng.GetListReport(List);
			
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
            //try
            //{
            //    AgenteInfo agent = AgenteInfo.Get(ActiveItem.TipoEntidad, ActiveItem);
            //    AgenteEditForm form = new AgenteEditForm(ActiveItem.TipoEntidad, ActiveItem, this);
            //    AddForm(form);
            //}
            //catch (HipatiaException ex)
            //{
            //    if (ex.Code == HipatiaCode.NO_AGENTE)
            //    {
            //        AgenteAddForm form = new AgenteAddForm(ActiveItem.TipoEntidad, ActiveItem, this);
            //        AddForm(form);
            //    }
            //}
        }

		#endregion

    }

    public partial class PlantillaMngBaseForm : Skin06.EntityMngSkinForm<PlantillaExamenList, PlantillaExamenInfo>
    {
        public PlantillaMngBaseForm()
            : this(false, null, null) { }

        public PlantillaMngBaseForm(bool isModal, Form parent, PlantillaExamenList lista)
            : base(isModal, parent, lista) { }
    }
}
