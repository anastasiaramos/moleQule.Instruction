using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Application;
using moleQule.Library.Instruction;
using moleQule.Library.Instruction.Reports.Alumno;
using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class FaltasAlumnosMngForm : FaltasAlumnosMngBaseForm
    {
        #region Attributes & Properties

        public const string ID = "FaltasAlumnosMngForm";
        public static Type Type { get { return typeof(FaltasAlumnosMngForm); } }
        public override Type EntityType { get { return typeof(FaltaAlumno); } }

        protected override int BarSteps { get { return base.BarSteps + 3; } }

        protected FaltaAlumno _entity;

        public DataGridViewCellStyle FaltaStyle = new DataGridViewCellStyle();
        public DataGridViewCellStyle ApercibimientoStyle = new DataGridViewCellStyle();
        public DataGridViewCellStyle BloqueadoStyle = new DataGridViewCellStyle();

        #endregion

        #region Factory Methods

        public FaltasAlumnosMngForm() : this(false, null) { }

        public FaltasAlumnosMngForm(Form parent) : this(false, parent, null) { }

        public FaltasAlumnosMngForm(bool isModal, Form parent) : this(isModal, parent, null) { }

        public FaltasAlumnosMngForm(bool isModal, Form parent, AlumnoList list)
            : base(isModal, parent, null)
        {
            InitializeComponent();
            _view_mode = molView.Select;
            // Parche para poder abrir el formulario en modo diseño y no perder la configuracion de columnas
            DatosLocal_BS = Datos;
            Tabla.DataSource = DatosLocal_BS;

            SetMainDataGridView(Tabla);
            Datos.DataSource = AlumnoList.NewList().GetSortedList();
            base.SortProperty = NExpediente.DataPropertyName;

            this.Text = Resources.Labels.FALTAS_ALUMNOS_VIEW_TITLE;
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
            Tabla.Visible = Alumno.CanGetObject();
            Add_Button.Enabled = Alumno.CanAddObject();
            Edit_Button.Enabled = Alumno.CanEditObject();
            Delete_Button.Enabled = Alumno.CanDeleteObject();
            Print_Button.Enabled = Alumno.CanGetObject();
            View_Button.Enabled = Alumno.CanGetObject();
        }

        #endregion

        #region Style & Source

        protected void SetMainList(SortedBindingList<FaltaAlumnoInfo> list, bool order)
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

        /// <summary>Formatea los controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            if (Tabla == null) return;

            base.FormatControls();
            //HideAction(molAction.Add);
            //HideAction(molAction.Edit);
            //HideAction(molAction.Delete);
            //HideAction(molAction.View);
            ShowAction(molAction.Print);

            List<DataGridViewColumn> cols = new List<DataGridViewColumn>();

            Modulo.Tag = 1;
            cols.Add(Modulo);

            ControlsMng.MaximizeColumns(Tabla, cols);
            SetGridFormat();
            ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla));

            Fields_CB.Text = Apellidos.HeaderText;

            ControlTools.Instance.CopyBasicStyle(FaltaStyle);
            FaltaStyle.BackColor = Color.LightBlue;

            ControlTools.Instance.CopyBasicStyle(ApercibimientoStyle);
            ApercibimientoStyle.BackColor = Color.LightSalmon;

            ControlTools.Instance.CopyBasicStyle(BloqueadoStyle);
            BloqueadoStyle.BackColor = Color.LightCoral;
            MaximizeForm();

        }

        protected override void SetRowFormat(DataGridViewRow row)
        {
            if (row.IsNewRow) return;
            FaltaAlumnoInfo item = (FaltaAlumnoInfo)row.DataBoundItem;

            if (item.Porcentaje >= 15)
                row.DefaultCellStyle = BloqueadoStyle;
            else
            {
                if (item.Porcentaje >= 10)
                    row.DefaultCellStyle = ApercibimientoStyle;
                else
                {
                    if (item.Porcentaje >= 5)
                        row.DefaultCellStyle = FaltaStyle;
                }
            }
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
                    List = FaltaAlumnoList.GetList();
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
        }

        /// <summary>
        /// Abre el formulario para ver item
        /// <returns>void</returns>
        /// </summary>
        public override void OpenViewForm()
        {
        }

        /// <summary>
        /// Abre el formulario para editar item
        /// <returns>void</returns>
        /// </summary>
        public override void OpenEditForm()
        {
        }

        /// <summary>
        /// Abre el formulario para borrar item
        /// <returns>void</returns>
        /// </summary>
        public override void DeleteObject(long oid)
        {
        }

        /// <summary>Duplica un objeto y abre el formulario para editar item
        /// <returns>void</returns>
        /// </summary>
        public override void DuplicateObject(long oid)
        {
        }

        /// <summary>Imprime la lista del objetos
        /// <returns>void</returns>
        /// </summary>
        public override void PrintList()
        {
            InformesReportMng reportMng = new InformesReportMng(AppContext.ActiveSchema);

            FaltasAlumnosRpt report = null;
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
                    report = reportMng.GetDetailReport(empresa, _sorted_list);
                    break;

                case IFilterType.Filter:
                    report = reportMng.GetDetailReport(empresa, _filter_results);
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


        protected new SortedBindingList<FaltaAlumnoInfo> Localize(FilterItem item)
        {
            SortedBindingList<FaltaAlumnoInfo> list = null;
            FaltaAlumnoList sourceList = null;

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

    public partial class FaltasAlumnosMngBaseForm : Skin06.EntityMngSkinForm<FaltaAlumnoList, FaltaAlumnoInfo>
    {
        public FaltasAlumnosMngBaseForm()
            : this(false, null, null) { }

        public FaltasAlumnosMngBaseForm(bool isModal, Form parent, FaltaAlumnoList lista)
            : base(isModal, parent, lista) { }
    }
}
