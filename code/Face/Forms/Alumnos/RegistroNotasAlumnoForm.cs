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
    public partial class RegistroNotasAlumnoForm : RegistroNotasAlumnosMngBaseForm
    {
        #region Attributes & Properties

        public const string ID = "RegistroNotasAlumnoForm";
        public static Type Type { get { return typeof(RegistroNotasAlumnoForm); } }
        public override Type EntityType { get { return typeof(Alumno_Examen); } }

        protected override int BarSteps { get { return base.BarSteps + 3; } }

        protected Alumno_Examen _entity;
        protected AlumnoInfo _item;

        #endregion

        #region Factory Methods

        public RegistroNotasAlumnoForm() : this(false, null, -1) { }

        public RegistroNotasAlumnoForm(Form parent) : this(false, parent, -1) { }

        public RegistroNotasAlumnoForm(bool isModal, Form parent, long oid_alumno)
            : base(isModal, parent, null)
        {
            InitializeComponent();
            //_view_mode = molView.Select;
            SetView(molView.Normal);
            _item = AlumnoInfo.Get(oid_alumno, false);
            //_item.LoadChilds(typeof(Alumno_Examen), true);
            //List = _item.AlumnoExamens;
            // Parche para poder abrir el formulario en modo diseño y no perder la configuracion de columnas
            DatosLocal_BS = Datos;
            Tabla.DataSource = DatosLocal_BS;
            SetMainDataGridView(Tabla);

            Datos.DataSource = Alumno_ExamenList.NewList().GetSortedList();

            base.SortProperty = FechaExamen.DataPropertyName;

            this.Text = Resources.Labels.NOTAS_ALUMNOS;
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

        protected void SetMainList(SortedBindingList<Alumno_ExamenInfo> list, bool order)
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
                    
                    HideAction(molAction.Add);
                    HideAction(molAction.Edit);
                    HideAction(molAction.Delete);
                    HideAction(molAction.View);
                    HideAction(molAction.Select);
                    HideAction(molAction.SelectAll);
                    HideAction(molAction.Unlock);
                    ShowAction(molAction.Print);

                    break;
            }
        }
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

            //SetGridFormat();
            //ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla));

            //Fields_CB.Text = Observaciones.HeaderText;
            //MaximizeForm();
            //ControlsMng.MaximizeColumns(Tabla, cols);

            ControlsMng.MaximizeColumns(Tabla, cols);

            ControlsMng.OrderByColumn(Tabla, Modulo, ListSortDirection.Descending);
            SetGridFormat();
            ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla));

            Fields_CB.Text = Modulo.HeaderText;

            SetColumnActive(ControlsMng.GetColumn(Tabla, Modulo.DataPropertyName));

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
                    if (_item.AlumnoExamens == null || _item.AlumnoExamens.Count == 0)
                        _item.LoadChilds(typeof(Alumno_Examen), true);
                    List = _item.AlumnoExamens;
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

        protected void SetUnlinkedGridValues(string gridName)
        {
            switch (gridName)
            {
                case "Tabla":
                    {
                        ExamenList examenes = ExamenList.GetList(false);
                        foreach (DataGridViewRow row in Tabla.Rows)
                        {
                            if (row.IsNewRow) continue;
                            Alumno_ExamenInfo info = (Alumno_ExamenInfo)row.DataBoundItem;
                            if (info != null)
                            {
                                ExamenInfo examen = examenes.GetItem(info.OidExamen);
                                if (examen != null)
                                {
                                    if (info.Presentado)
                                    {
                                        if (examen.Desarrollo)
                                        {
                                            string calif = string.Empty;
                                            if (info.Respuestas == null)
                                                info = Alumno_ExamenInfo.Get(info.Oid, true);

                                            foreach (Respuesta_Alumno_ExamenInfo item in info.Respuestas)
                                            {
                                                if (calif != string.Empty)
                                                    calif += " - ";
                                                calif += item.Calificacion.ToString() + "%";
                                            }
                                            row.Cells["Calificacion"].Value = calif;
                                        }
                                        else
                                            row.Cells["Calificacion"].Value = info.Calificacion.ToString() + "%";
                                    }
                                    else
                                        row.Cells["Calificacion"].Value = "NP";
                                }
                            }
                        }

                    } break;
            }
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
            AlumnoReportMng reportMng = new AlumnoReportMng(AppContext.ActiveSchema);

            RegistroNotasAlumnoRpt report = null;

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
                    report = reportMng.GetDetailNotasReport(_item, _sorted_list, empresa);
                    break;

                case IFilterType.Filter:
                    report = reportMng.GetDetailNotasReport(_item, _filter_results, empresa);
                    break;
            }

            if (report != null)
            {
                report.SetParameterValue("Empresa", empresa.Name);
                //if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(report.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);
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


        protected new SortedBindingList<Alumno_ExamenInfo> Localize(FilterItem item)
        {
            SortedBindingList<Alumno_ExamenInfo> list = null;
            Alumno_ExamenList sourceList = null;

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

    public partial class RegistroNotasAlumnosMngBaseForm : Skin06.EntityMngSkinForm<Alumno_ExamenList, Alumno_ExamenInfo>
    {
        public RegistroNotasAlumnosMngBaseForm()
            : this(false, null, null) { }

        public RegistroNotasAlumnosMngBaseForm(bool isModal, Form parent, Alumno_ExamenList lista)
            : base(isModal, parent, lista) { }
    }
}
