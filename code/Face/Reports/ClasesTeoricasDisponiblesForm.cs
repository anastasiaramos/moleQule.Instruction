﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Instruction.Reports.Promocion;
using moleQule.Library.Application;
using moleQule.Library.Instruction;
using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class ClasesTeoricasDisponiblesForm : ClasesTeoricasDisponiblesMngBaseForm
    {
        #region Attributes & Properties

        public const string ID = "ClasesTeoricasDisponiblesForm";
        public static Type Type { get { return typeof(ClasesTeoricasDisponiblesForm); } }
        public override Type EntityType { get { return typeof(ClaseTeorica); } }

        protected override int BarSteps { get { return base.BarSteps + 3; } }

        protected ClaseTeorica _entity;
        protected PromocionInfo _promocion;

        #endregion

        #region Factory Methods

        public ClasesTeoricasDisponiblesForm() : this(false, null) { }

        public ClasesTeoricasDisponiblesForm(bool isModal, Form parent) : this(isModal, parent, null, null) { }

        public ClasesTeoricasDisponiblesForm(bool isModal, Form parent, ClaseTeoricaList list, PromocionInfo promocion)
            : base(isModal, parent, list)
        {
            InitializeComponent();
            _view_mode = molView.Select;
            _promocion = promocion;
            
            // Parche para poder abrir el formulario en modo diseño y no perder la configuracion de columnas
            DatosLocal_BS = Datos;
            Tabla.DataSource = DatosLocal_BS;
            SetMainDataGridView(Tabla);
            Datos.DataSource = ClaseTeoricaList.NewList().GetSortedList();
            
            this.Text = Resources.Labels.CLASE_HORARIO_TITLE;
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
            Tabla.Visible = ClaseTeorica.CanGetObject();
            Add_Button.Enabled = ClaseTeorica.CanAddObject();
            Edit_Button.Enabled = ClaseTeorica.CanEditObject();
            Delete_Button.Enabled = ClaseTeorica.CanDeleteObject();
            Print_Button.Enabled = ClaseTeorica.CanGetObject();
            View_Button.Enabled = ClaseTeorica.CanGetObject();
        }

        #endregion

        #region Style & Source

        protected void SetMainList(SortedBindingList<ClaseTeoricaInfo> list, bool order)
        {
            //base.SortProperty = SortProperty;
            //base.SortDirection = SortDirection;

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

        /// <summary>Formatea los controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            if (Tabla == null) return;

            base.FormatControls();
            HideAction(molAction.Add);
            HideAction(molAction.Edit);
            HideAction(molAction.Copy);
            HideAction(molAction.Delete);
            HideAction(molAction.Select);
            HideAction(molAction.SelectAll);
            HideAction(molAction.View);
            ShowAction(molAction.Print);

            List<DataGridViewColumn> cols = new List<DataGridViewColumn>();

            Submodulo.Tag = 1;
            cols.Add(Submodulo);

            ControlsMng.MaximizeColumns(Tabla, cols);
            SetGridFormat();
            ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla));

            Fields_CB.Text = Alias.HeaderText;

        }

        /// <summary>
        /// Toma la lista de bancos de la base de datos y rellena la tabla.
        /// </summary>
        protected override void RefreshMainData()
        {
            PgMng.Grow(string.Empty, "Alumno");

            _selectedOid = ActiveOID;

            switch (DataType)
            {
                case EntityMngFormTypeData.Default:
                    List = ClaseTeoricaList.GetList();
                    break;

                case EntityMngFormTypeData.ByParameter:
                    _sorted_list = List.GetSortedList();
                    break;
            }

            PgMng.Grow(string.Empty, "Lista de Alumnos");
        }

        protected override void RefreshSources()
        {
            switch (FilterType)
            {
                case IFilterType.None:
                    SetMainList(_sorted_list, false);
                    PgMng.Grow(string.Empty, "Ordenar Lista");
                    break;

                case IFilterType.Filter:
                    SetMainList(_filter_results, false);
                    PgMng.Grow(string.Empty, "Ordenar Lista");
                    break;
            }

            base.SortProperty = "Modulo";
            base.RefreshSources();
        }

        public override void UpdateList()
        {
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
                SetMainList(on ? _filter_results : _sorted_list, false);
            }
            catch (Exception)
            {
                SetMainList(_sorted_list, false);
            }

            base.SetFilter(on);
        }

        #endregion

        #region Actions
                
        /// <summary>Imprime la lista del objetos
        /// <returns>void</returns>
        /// </summary>
        public override void PrintList()
        {
            PromocionReportMng reportMng = new PromocionReportMng(AppContext.ActiveSchema);

            ClasesTeoricasDisponiblesRpt report = null;

            bool defecto = moleQule.Library.Instruction.ModulePrincipal.GetImpresionEmpresaDefaultBoolSetting();
            CompanyInfo empresa = null;

            if (defecto)
                empresa = CompanyInfo.Get(moleQule.Library.Instruction.ModulePrincipal.GetImpresionEmpresaDefaultOidSetting(), false);
            while (empresa == null)
            {
                moleQule.Face.Common.CompanySelectForm form = new Common.CompanySelectForm(this);
                DialogResult result = form.ShowDialog();

                try
                {
                    if (result == DialogResult.OK)
                        empresa = form.Selected as CompanyInfo;
                }
                catch
                { empresa = null; }
            }

            switch (FilterType)
            {
                case IFilterType.None:
                    report = reportMng.GetDetailReport(empresa, _promocion, _sorted_list);
                    break;

                case IFilterType.Filter:
                    report = reportMng.GetDetailReport(empresa, _promocion, _filter_results);
                    break;
            }

            if (report != null)
            {
                report.SetParameterValue("Empresa", empresa.Name);
                if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(report.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);
                ReportViewer.SetReport(report);
                ReportViewer.ShowDialog();
            }
            else
            {
                MessageBox.Show(Resources.Messages.NO_DATA_REPORTS,
                                moleQule.Face.Resources.Labels.ADVISE_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
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

        protected new SortedBindingList<ClaseTeoricaInfo> Localize(FilterItem item)
        {
            SortedBindingList<ClaseTeoricaInfo> list = null;
            ClaseTeoricaList sourceList = null;

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

    public partial class ClasesTeoricasDisponiblesMngBaseForm : Skin06.EntityMngSkinForm<ClaseTeoricaList, ClaseTeoricaInfo>
    {
        public ClasesTeoricasDisponiblesMngBaseForm()
            : this(false, null, null) { }

        public ClasesTeoricasDisponiblesMngBaseForm(bool isModal, Form parent, ClaseTeoricaList lista)
            : base(isModal, parent, lista) { }
    }
}
