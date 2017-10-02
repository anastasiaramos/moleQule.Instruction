using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Application;
using moleQule.Library.Instruction;
using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class ClasesPromocionMngForm : ClasesPromocionMngBaseForm
    {
        #region Attributes & Properties

        public const string ID = "ClasesPromocionMngForm";
        public static Type Type { get { return typeof(ClasesPromocionMngForm); } }
        public override Type EntityType { get { return typeof(ClaseGenerica); } }

        protected override int BarSteps { get { return base.BarSteps + 3; } }

        protected ClaseGenerica _entity;
        protected ClaseTeoricaList _teoricas;
        protected ClasePracticaList _practicas;
        protected ClaseExtraList _extras;

        #endregion

        #region Factory Methods

        public ClasesPromocionMngForm() : this(false, null) { }

        public ClasesPromocionMngForm(Form parent) : this(false, parent) { }

        public ClasesPromocionMngForm(bool isModal, Form parent) : this(isModal, parent, null, null, null) { }

        public ClasesPromocionMngForm(bool isModal, Form parent, ClaseTeoricaList teoricas, ClasePracticaList practicas, ClaseExtraList extras)
            : base(isModal, parent, ClaseGenericaList.GetList(teoricas, practicas, extras))
        {
            InitializeComponent();
            SetView(molView.Normal);
            _teoricas = teoricas;
            _practicas = practicas;
            _extras = extras;
            // Parche para poder abrir el formulario en modo diseño y no perder la configuracion de columnas
            DatosLocal_BS = Datos;
            Tabla.DataSource = DatosLocal_BS;

            SetMainDataGridView(Tabla);
            Datos.DataSource = ClaseGenericaList.NewList().GetSortedList();
            SortProperty = Submodulo.DataPropertyName;

            this.Text = Resources.Labels.CLASE_HORARIO_TITLE;
        }
        
        #endregion#region Layout

        #region Layout

        public override void FitColumns()
        {
            List<DataGridViewColumn> cols = new List<DataGridViewColumn>();
            Alias.Tag = 0.2;
            Modulo.Tag = 0.4;
            Submodulo.Tag = 0.4;

            cols.Add(Alias);
            cols.Add(Modulo);
            cols.Add(Submodulo);

            ControlsMng.MaximizeColumns(Tabla, cols);
        }
        
        protected override void SetView(molView view)
        {
            base.SetView(view);

            switch (_view_mode)
            {
                case molView.Select:

                    HideAction(molAction.Add);
                    HideAction(molAction.Copy);
                    HideAction(molAction.Edit);
                    HideAction(molAction.PrintDetail);
                    HideAction(molAction.CustomAction1);
                    HideAction(molAction.CustomAction2);
                    HideAction(molAction.CustomAction3);
                    HideAction(molAction.CustomAction4);

                    Seleccionar.Visible = true;
                    Seleccionar.ReadOnly = false;

                    break;

                case molView.Normal:

                    ShowAction(molAction.Add);
                    ShowAction(molAction.Copy);
                    ShowAction(molAction.Edit);
                    ShowAction(molAction.PrintDetail);
                    ShowAction(molAction.CustomAction1);
                    ShowAction(molAction.CustomAction2);
                    ShowAction(molAction.CustomAction3);
                    HideAction(molAction.CustomAction4);

                    Seleccionar.Visible = false;
                    Seleccionar.ReadOnly = false;

                    break;
            }
        }

        #endregion

        #region Style & Source

        /// <summary>
        /// Toma la lista de bancos de la base de datos y rellena la tabla.
        /// </summary>
        protected override void RefreshMainData()
        {
            PgMng.Grow(string.Empty, "ClaseGenerica");

            _selectedOid = ActiveOID;

            switch (DataType)
            {
                case EntityMngFormTypeData.Default:
                    List = ClaseGenericaList.GetList(_teoricas, _practicas, _extras);
                    break;

                case EntityMngFormTypeData.ByParameter:
                    _sorted_list = List.GetSortedList();
                    break;
            }

            PgMng.Grow(string.Empty, "Lista de Clases");
        }

        public override void UpdateList()
        {
            switch (_current_action)
            {
                case molAction.Add:
                    if (_entity == null) return;
                    List.AddItem(_entity.GetInfo());
                    if (FilterType == IFilterType.Filter)
                    {
                        ClaseGenericaList listA = ClaseGenericaList.GetList(_filter_results);
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
                        ClaseGenericaList listD = ClaseGenericaList.GetList(_filter_results);
                        listD.RemoveItem(ActiveOID);
                        _filter_results = listD.GetSortedList();
                    }
                    break;
            }

            _entity = null;
            RefreshSources();
        }

        #endregion

        #region Actions

        /// <summary>
        /// Abre el formulario para añadir item
        /// <returns>void</returns>
        /// </summary>
        public override void OpenAddForm()
        {
            //try
            //{
            //    AlumnoAddForm form = new AlumnoAddForm();
            //    AddForm(form);
            //    _entity = form.Entity;
            //}
            //catch (Csla.DataPortalException ex)
            //{
            //    MessageBox.Show(ex.BusinessException.ToString(),
            //                    moleQule.Face.Resources.Labels.ERROR_TITLE,
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Exclamation);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString(),
            //                    moleQule.Face.Resources.Labels.ERROR_TITLE,
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Exclamation);
            //}
        }

        /// <summary>
        /// Abre el formulario para ver item
        /// <returns>void</returns>
        /// </summary>
        public override void OpenViewForm()
        {
            try
            {
                AddForm(new AlumnoViewForm(ActiveOID));
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
            //try
            //{
            //    AlumnoEditForm form = new AlumnoEditForm(ActiveOID);
            //    if (form.Entity != null)
            //    {
            //        AddForm(form);
            //        _entity = form.Entity;
            //    }
            //}
            //catch (Csla.DataPortalException ex)
            //{
            //    MessageBox.Show(ex.BusinessException.ToString(),
            //                    moleQule.Face.Resources.Labels.ERROR_TITLE,
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Exclamation);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString(),
            //                    moleQule.Face.Resources.Labels.ERROR_TITLE,
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Exclamation);
            //}
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
            //    try
            //    {
            //        AlumnoInfo alumno = AlumnoInfo.Get(oid, true);
            //        if (alumno.AlumnoPartes.Count > 0)
            //        {
            //            MessageBox.Show(Resources.Messages.ALUMNO_CON_PARTES_DE_FALTAS);
            //            _action_result = DialogResult.Ignore;
            //            return;
            //        }

            //        //Se elimina la foto					
            //        Images.Delete(List.GetItem(oid).Foto, Controler.FOTOS_ALUMNOS_PATH);

            //        ClaseGenerica.Delete(oid);
            //        _action_result = DialogResult.OK;

            //        //Se eliminan todos los formularios de ese objeto
            //        foreach (ItemMngBaseForm form in _list_active_form)
            //        {
            //            if (form.Oid == oid)
            //            {
            //                form.Dispose();
            //                break;
            //            }
            //        }
            //    }
            //    catch (Csla.DataPortalException ex)
            //    {
            //        MessageBox.Show(iQExceptionHandler.GetiQException(ex).Message);
            //    }
            //}
        }

        /// <summary>Duplica un objeto y abre el formulario para editar item
        /// <returns>void</returns>
        /// </summary>
        public override void DuplicateObject(long oid)
        {
            //try
            //{
            //    ClaseGenerica old = ClaseGenerica.Get(oid);
            //    ClaseGenerica dup = old.CloneAsNew();
            //    old.CloseSession();
            //    dup.Foto = string.Empty;

            //    AddForm(new AlumnoAddForm(dup));
            //}
            //catch (iQException ex)
            //{
            //    MessageBox.Show(ex.Message,
            //                    moleQule.Face.Resources.Labels.ERROR_TITLE,
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Exclamation);
            //}
            //catch (Csla.DataPortalException ex)
            //{
            //    MessageBox.Show(iQExceptionHandler.GetiQException(ex).Message,
            //                    moleQule.Face.Resources.Labels.ERROR_TITLE,
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Exclamation);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString(),
            //                    moleQule.Face.Resources.Labels.ERROR_TITLE,
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Exclamation);
            //}

            //RefreshList();
        }

        /// <summary>Imprime la lista del objetos
        /// <returns>void</returns>
        /// </summary>
        public override void PrintList()
        {
            /*AlumnoReportMng reportMng = new AlumnoReportMng(AppContext.ActiveSchema);
			
            AlumnoListRpt report = reportMng.GetListReport(list);
			
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

        public virtual void SelectAction()
        {
            if (Tabla.CurrentRow != null)
                Tabla.CurrentRow.Cells[Seleccionar.Name].Value = "True";

            ExecuteAction(molAction.Select);
        }

        public override void SelectObject()
        {
            Datos.MoveFirst();
            Datos.MoveLast();

            List<ClaseGenericaInfo> list = new List<ClaseGenericaInfo>();

            foreach (DataGridViewRow row in Tabla.Rows)
            {
                if (row.Cells[Seleccionar.Name].Value != null)
                    if (((DataGridViewCheckBoxCell)row.Cells[Seleccionar.Name]).Value.ToString() == "True")
                        list.Add(row.DataBoundItem as ClaseGenericaInfo);
            }

            _selected = list;
            _action_result = list.Count > 0 ? DialogResult.OK : DialogResult.Cancel;
        }

        #endregion

        #region Events

        private void Tabla_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void Tabla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Tabla.CurrentRow != null && Tabla.Columns[e.ColumnIndex].Name == Seleccionar.Name)
            {
                if (Tabla.CurrentRow.Cells[Seleccionar.Name].Value == null ||
                    Tabla.CurrentRow.Cells[Seleccionar.Name].Value.ToString() != "True")
                    Tabla.CurrentRow.Cells[Seleccionar.Name].Value = "True";
                else
                    Tabla.CurrentRow.Cells[Seleccionar.Name].Value = "False";
            }
        }

        #endregion


    }

    public partial class ClasesPromocionMngBaseForm : Skin06.EntityMngSkinForm<ClaseGenericaList, ClaseGenericaInfo>
    {
        public ClasesPromocionMngBaseForm()
            : this(false, null, null) { }

        public ClasesPromocionMngBaseForm(bool isModal, Form parent, ClaseGenericaList lista)
            : base(isModal, parent, lista) { }
    }
}
