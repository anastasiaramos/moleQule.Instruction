using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using iTextSharp.text;
using iTextSharp.text.pdf;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Hipatia;
using moleQule.Library.Instruction.Reports.Horario;
using moleQule.Library.Application;
using moleQule.Library.Instruction;
using moleQule.Face;
using moleQule.Face.Common;

namespace moleQule.Face.Instruction
{
    public partial class ClasesRestantesCronogramaMngForm : ClasesRestantesCronogramaMngBaseForm
    {
        #region Attributes & Properties

        public const string ID = "ClasesRestantesCronogramaMngForm";
        public static Type Type { get { return typeof(ClasesRestantesCronogramaMngForm); } }
        public override Type EntityType { get { return typeof(SesionCronograma); } }

        protected override int BarSteps { get { return base.BarSteps + 3; } }

        protected CronogramaInfo _cronograma = null;
        protected int _total_dias;

        public DataGridViewCellStyle SemanaParStyle = new DataGridViewCellStyle();

        #endregion

        #region Factory Methods

        public ClasesRestantesCronogramaMngForm() : this(false, null) { }

        public ClasesRestantesCronogramaMngForm(bool isModal, Form parent) : this(isModal, parent, null, 5) { }

        public ClasesRestantesCronogramaMngForm(bool isModal, Form parent, CronogramaInfo cronograma, int total_dias)
            : base(isModal, parent, cronograma.Sesiones)
        {
            InitializeComponent();
            _view_mode = molView.Select;
            _cronograma = cronograma;
            _total_dias = total_dias;
            
            // Parche para poder abrir el formulario en modo diseño y no perder la configuracion de columnas
            DatosLocal_BS = Datos;
            Tabla.DataSource = DatosLocal_BS;
            SetMainDataGridView(Tabla);
            Datos.DataSource = SesionCronogramaList.NewList().GetSortedList();
            
            this.Text = Resources.Labels.ORDENAR_CLASES_TITLE;
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
            Tabla.Visible = SesionCronograma.CanGetObject();
            Add_Button.Enabled = SesionCronograma.CanAddObject();
            Edit_Button.Enabled = SesionCronograma.CanEditObject();
            Delete_Button.Enabled = SesionCronograma.CanDeleteObject();
            Print_Button.Enabled = SesionCronograma.CanGetObject();
            View_Button.Enabled = SesionCronograma.CanGetObject();
        }

        #endregion

        #region Style & Source

        protected void SetMainList(SortedBindingList<SesionCronogramaInfo> list, bool order)
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

            Modulo.Tag = 0.5;
            Titulo.Tag = 0.5;
            cols.Add(Modulo);
            cols.Add(Titulo);

            ControlTools.Instance.CopyBasicStyle(SemanaParStyle);
            SemanaParStyle.BackColor = System.Drawing.Color.LightBlue;

            ControlsMng.MaximizeColumns(Tabla, cols);
            SetGridFormat();
            ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla));

            Fields_CB.Text = Numero.HeaderText;

        }

        protected override void SetRowFormat(DataGridViewRow row)
        {
            if (!row.Displayed) return;
            if (row.IsNewRow) return;

            SesionCronogramaInfo item = (SesionCronogramaInfo)row.DataBoundItem;

            if (_total_dias == 6)
            {
                if (item.Dia % 2 == 0)
                    row.DefaultCellStyle = SemanaParStyle;
            }
            else
            {
                if ((item.Semana % 2 == 1 && item.Dia % 2 == 0) || (item.Semana % 2 == 0 && item.Dia % 2 == 1))
                    row.DefaultCellStyle = SemanaParStyle;
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
                    List = _cronograma.Sesiones;
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

            base.SortProperty = "Turno";
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
            ETipoImpresionCronograma tipo = ETipoImpresionCronograma.Lista;
            SelectEnumInputForm form = new SelectEnumInputForm(true);

            form.SetDataSource(Library.Instruction.EnumText<ETipoImpresionCronograma>.GetList(false, false, false));
            form.ShowDialog(this);

            if (form.ActionResult == DialogResult.OK)
            {
                ComboBoxSource combo = form.Selected as ComboBoxSource;
                tipo = (ETipoImpresionCronograma)combo.Oid;
            }
            
            ClaseTeoricaList teoricas = ClaseTeoricaList.GetList();
            ClasePracticaList practicas = ClasePracticaList.GetList(false);
            List<ClasePracticaList> lista_practicas = new List<ClasePracticaList>();
            lista_practicas.Add(null);
            lista_practicas.Add(practicas);
            lista_practicas.Add(practicas);
            ModuloList modulos = ModuloList.GetList(false);

            CronogramaReportMng reportMng = new CronogramaReportMng(AppContext.ActiveSchema);
            CronogramaRpt report = null;

            switch (FilterType)
            {
                case IFilterType.None:
                    if (tipo == ETipoImpresionCronograma.Lista)
                    {
                        bool defecto = moleQule.Library.Instruction.ModulePrincipal.GetImpresionEmpresaDefaultBoolSetting();
                        CompanyInfo empresa = null;

                        if (defecto)
                            empresa = CompanyInfo.Get(moleQule.Library.Instruction.ModulePrincipal.GetImpresionEmpresaDefaultOidSetting(), false);
                        while (empresa == null)
                        {
                            moleQule.Face.Common.CompanySelectForm sform = new Common.CompanySelectForm(this);
                            DialogResult result = sform.ShowDialog();

                            try
                            {
                                if (result == DialogResult.OK)
                                    empresa = form.Selected as CompanyInfo;
                            }
                            catch
                            { empresa = null; }
                        }

                        report = reportMng.GetCronogramaReport(_cronograma, empresa, modulos, teoricas, practicas, _sorted_list);

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
                    else
                    {
                        Dictionary<Horario, ListaSesiones> horarios = Cronograma.GetHorarios(_sorted_list, teoricas, practicas);
                        
                        if (horarios.Count > 0)
                        {
                            PgMng.Reset(horarios.Count + 5, 1, Resources.Messages.LOADING_DATA, this);

                            try
                            {
                                InstructorList instructores = InstructorList.GetList(false);
                                PgMng.Grow();                                

                                //EntidadInfo entidad = EntidadInfo.Get(typeof(Promocion), true);
                                //Agente agente = null;

                                //PromocionInfo promocion = PromocionInfo.Get(_cronograma.OidPromocion, true);

                                //if (entidad.Agentes.GetItemByProperty("OidAgenteExt", promocion.Oid) != null)
                                //    agente = Agente.Get(typeof(Promocion), promocion);
                                //else
                                //{
                                //    agente = Agente.New();
                                //    agente.CopyFrom(entidad, promocion);
                                //    agente.Codigo = agente.GetCode();
                                //}

                                PgMng.Grow();

                                string sFile = "C:\\cronograma.pdf";
                                FileStream fs = new FileStream(sFile, FileMode.Create, FileAccess.Write, FileShare.None);
                                Document doc = new Document();
                                PdfSmartCopy copy = new PdfSmartCopy(doc, fs);

                                doc.Open();

                                foreach (KeyValuePair<Horario, ListaSesiones> item in horarios)
                                {
                                    item.Key.OidPlan = _cronograma.OidPlan;
                                    item.Key.OidPromocion = _cronograma.OidPromocion;
                                    HorarioRpt rpt = reportMng.GetHorarioReport(item.Key.GetInfo(false), true, teoricas, lista_practicas, null, instructores, modulos, item.Value, false, DateTime.Now);
                                    PdfReader reader = new PdfReader(rpt.ExportToStream(ExportFormatType.PortableDocFormat));
                                    copy.AddPage(copy.GetImportedPage(reader, 1));
                                    rpt.Close();
                                    rpt.Dispose();
                                    PgMng.Grow();
                                }

                                doc.Close();

                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                process.StartInfo.FileName = sFile;
                                process.Start();
                                try
                                {
                                    process.WaitForExit();
                                }
                                catch { }
                                PgMng.Grow();

                                //Documento documento = Documento.New();
                                //documento.Fecha = DateTime.Now;
                                //documento.FechaAlta = DateTime.Now;
                                //documento.Nombre = documento.Fecha.ToString("yyyyMMdd") + "_CRONOGRAMA";
                                //documento.Ruta = "C:\\";
                                //documento.Tipo = "PDF";


                                //AgenteDocumento agente_documento = agente.Documentos.NewItem(agente);
                                //agente_documento.OidDocumento = documento.Oid;

                                //agente.Save();
                            }
                            catch (Exception ex) { throw ex; }
                            finally { PgMng.FillUp(); }
                        }
                    }
                    break;

                case IFilterType.Filter:
                    if (tipo == ETipoImpresionCronograma.Lista)
                    {
                        bool defecto = moleQule.Library.Instruction.ModulePrincipal.GetImpresionEmpresaDefaultBoolSetting();
                        CompanyInfo empresa = null;

                        if (defecto)
                            empresa = CompanyInfo.Get(moleQule.Library.Instruction.ModulePrincipal.GetImpresionEmpresaDefaultOidSetting(), false);
                        while (empresa == null)
                        {
                            moleQule.Face.Common.CompanySelectForm sform = new Common.CompanySelectForm(this);
                            DialogResult result = sform.ShowDialog();

                            try
                            {
                                if (result == DialogResult.OK)
                                    empresa = form.Selected as CompanyInfo;
                            }
                            catch
                            { empresa = null; }
                        }

                        report = reportMng.GetCronogramaReport(_cronograma, empresa, modulos, teoricas, practicas, _filter_results);

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
                    else
                    {
                        Dictionary<Horario, ListaSesiones> horarios = Cronograma.GetHorarios(_filter_results, teoricas, practicas);

                        if (horarios.Count > 0)
                        {
                            PgMng.Reset(horarios.Count + 5, 1, Resources.Messages.LOADING_DATA, this);

                            try
                            {
                                InstructorList instructores = InstructorList.GetList(false);
                                PgMng.Grow();

                                //EntidadInfo entidad = EntidadInfo.Get(typeof(Promocion), true);
                                //Agente agente = null;

                                //PromocionInfo promocion = PromocionInfo.Get(_cronograma.OidPromocion, true);

                                //if (entidad.Agentes.GetItemByProperty("OidAgenteExt", promocion.Oid) != null)
                                //    agente = Agente.Get(typeof(Promocion), promocion);
                                //else
                                //{
                                //    agente = Agente.New();
                                //    agente.CopyFrom(entidad, promocion);
                                //    agente.Codigo = agente.GetCode();
                                //}

                                PgMng.Grow();

                                string sFile = "C:\\cronograma.pdf";
                                FileStream fs = new FileStream(sFile, FileMode.Create, FileAccess.Write, FileShare.None);
                                Document doc = new Document();
                                PdfSmartCopy copy = new PdfSmartCopy(doc, fs);

                                doc.Open();

                                foreach (KeyValuePair<Horario, ListaSesiones> item in horarios)
                                {
                                    item.Key.OidPlan = _cronograma.OidPlan;
                                    item.Key.OidPromocion = _cronograma.OidPromocion;
                                    HorarioRpt rpt = reportMng.GetHorarioReport(item.Key.GetInfo(false), true, teoricas, lista_practicas, null, instructores, modulos, item.Value, false, DateTime.Now);
                                    PdfReader reader = new PdfReader(rpt.ExportToStream(ExportFormatType.PortableDocFormat));
                                    copy.AddPage(copy.GetImportedPage(reader, 1));
                                    rpt.Close();
                                    rpt.Dispose();
                                    PgMng.Grow();
                                }

                                doc.Close();

                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                process.StartInfo.FileName = sFile;
                                process.Start();
                                try
                                {
                                    process.WaitForExit();
                                }
                                catch { }
                                PgMng.Grow();

                                //Documento documento = Documento.New();
                                //documento.Fecha = DateTime.Now;
                                //documento.FechaAlta = DateTime.Now;
                                //documento.Nombre = documento.Fecha.ToString("yyyyMMdd") + "_CRONOGRAMA";
                                //documento.Ruta = "C:\\";
                                //documento.Tipo = "PDF";


                                //AgenteDocumento agente_documento = agente.Documentos.NewItem(agente);
                                //agente_documento.OidDocumento = documento.Oid;

                                //agente.Save();
                            }
                            catch (Exception ex) { throw ex; }
                            finally { PgMng.FillUp(); }
                        }
                    }
                    break;
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

        protected new SortedBindingList<SesionCronogramaInfo> Localize(FilterItem item)
        {
            SortedBindingList<SesionCronogramaInfo> list = null;
            SesionCronogramaList sourceList = null;

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

    public partial class ClasesRestantesCronogramaMngBaseForm : Skin06.EntityMngSkinForm<SesionCronogramaList, SesionCronogramaInfo>
    {
        public ClasesRestantesCronogramaMngBaseForm()
            : this(false, null, null) { }

        public ClasesRestantesCronogramaMngBaseForm(bool isModal, Form parent, SesionCronogramaList lista)
            : base(isModal, parent, lista) { }
    }
}
