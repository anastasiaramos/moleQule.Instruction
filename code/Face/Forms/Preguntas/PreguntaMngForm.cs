using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Instruction; 
using moleQule.Library.Instruction.Reports;
using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class PreguntaMngForm : Skin02.EntityLMngSkinForm
    {

        #region Attributes & Properties

        public const string ID = "PreguntaMngForm";
        public static Type Type { get { return typeof(PreguntaMngForm); } }
        public override Type EntityType { get { return typeof(Pregunta); } }

        protected override int BarSteps { get { return base.BarSteps + 5; } }

        protected ModuloList _modulos = null;
        protected Library.Instruction.HComboBoxSourceList _combo_modulos;
        protected Library.Instruction.HComboBoxSourceList _combo_tipo;
        protected Library.Instruction.HComboBoxSourceList _combo_idioma;
        protected TemaList _temas = null;

        private new Preguntas List 
        { 
            get { return _item_list as Preguntas; }
            set { _item_list = value; _sorted_list = (value as Preguntas).GetSortedList(); } 
        }
        internal new SortedBindingList<Pregunta> SortedList { get { return _sorted_list; } }
        internal new Preguntas FilteredList { get { return Preguntas.GetList(_filter_results); } }

        private new SortedBindingList<Pregunta> _sorted_list = null;
        private new SortedBindingList<Pregunta> _filter_results = null;
        private new SortedBindingList<Pregunta> _search_results = null;
        protected List<string> _properties_list = new List<string>();
        
        /// <summary>
        /// Devuelve el OID del objeto activo seleccionado de la tabla
        /// </summary>
        /// <returns></returns>
        public override long ActiveOID { get { return ActiveItem != null ? ActiveItem.Oid : -1; } }

        /// <summary>
        /// Devuelve el objeto activo seleccionado de la tabla
        /// </summary>
        /// <returns></returns>
        public Pregunta ActiveItem { get { return (Datos.Current != null) ? Datos.Current as Pregunta : null; } }

        /// <summary>
        /// Devuelve el objeto activo seleccionado de la tabla
        /// </summary>
        /// <returns></returns>
        public SortedBindingList<Pregunta> ActiveList { get { return (Datos.List as SortedBindingList<Pregunta>); } }

        public override long ActiveFoundOID { get { return (DatosSearch.Current != null) ? ((Pregunta)(DatosSearch.Current)).Oid : -1; } }

        public override string SortProperty { get { return this.GetGridSortProperty(Tabla); } }
        public override ListSortDirection SortDirection { get { return this.GetGridSortDirection(Tabla); } }

        public string CurrentModulo { get { return (Modulo_CB.SelectedItem != null) ? (Modulo_CB.SelectedItem as ComboBoxSource).Texto : string.Empty; } }
        public long CurrentModuloOid { get { return (Modulo_CB.SelectedItem != null) ? (Modulo_CB.SelectedItem as ComboBoxSource).Oid : -1; } }
        public string CurrentTema { get { return (Tema_CB.SelectedItem != null) ? (Tema_CB.SelectedItem as ComboBoxSource).Texto : string.Empty; } }
        
        public DataGridViewCellStyle DisponibleStyle = new DataGridViewCellStyle();
        public DataGridViewCellStyle ReservadaStyle = new DataGridViewCellStyle();
        public DataGridViewCellStyle BloqueadaStyle = new DataGridViewCellStyle();

        #endregion

        #region Factory Methods

        public PreguntaMngForm()
            : this(false) { }

        public PreguntaMngForm(bool isModal)
            : this(isModal, null) { }

        public PreguntaMngForm(Form parent)
            : this(false, parent) { }

        public PreguntaMngForm(bool isModal, Form parent)
            : this(isModal, parent, null) { }

        public PreguntaMngForm(bool isModal, Form parent, PreguntaList list)
            : base(isModal, parent, list)
        {
            InitializeComponent();
            SetView(molView.Normal);

            // Parche para poder abrir el formulario en modo diseño y no perder la configuracion de columnas
            DatosLocal_BS = Datos;
            Tabla.DataSource = DatosLocal_BS;
            Datos.DataSource = PreguntaList.NewList().GetSortedList();

            TablaBase = Tabla;

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
            Tabla.Visible = Pregunta.CanGetObject();
            Add_Button.Enabled = Pregunta.CanAddObject();
            Edit_Button.Enabled = Pregunta.CanEditObject();
            Delete_Button.Enabled = Pregunta.CanDeleteObject();
            Print_Button.Enabled = Pregunta.CanGetObject();
            View_Button.Enabled = Pregunta.CanGetObject();
        }

        #endregion

        #region Source

        protected void SetMainList(SortedBindingList<Pregunta> list, bool order)
        {
            base.SortProperty = SortProperty;
            base.SortDirection = SortDirection;

            int currentColumn = (Tabla.CurrentCell != null) ? Tabla.CurrentCell.ColumnIndex : -1;

            Datos.DataSource = list;

            if (order)
            {
                ControlsMng.OrderByColumn(Tabla, Tabla.Columns[base.SortProperty], base.SortDirection);
                ControlsMng.SetCurrentCell(Tabla);
            }

            if (currentColumn != -1)
            {
                ControlsMng.SetCurrentCell(Tabla, currentColumn);
                //SetGridFormat();
            }
        } 

        /// <summary>
        /// Toma la List de bancos de la base de datos y rellena la tabla.
        /// </summary>
        protected override void RefreshMainData()
        {
            PgMng.Grow(string.Empty, "Pregunta");

            _selectedOid = ActiveOID;

            if (Datos.Count <= 1)
            {
                switch (DataType)
                {
                    case EntityMngFormTypeData.Default:
                        List = Preguntas.GetList(false);//.GetPreguntasModulo(CurrentModuloOid, false);
                        break;
                }
                PgMng.Grow(string.Empty, "Lista de Preguntas");
            }
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
                    SetMainList(ActiveList, true);
                    PgMng.Grow(string.Empty, "Ordenar Lista");
                    break;
            }
            base.RefreshSources();

            _properties_list = ControlsMng.GetPropertiesList(TablaBase);
        }

        public override void UpdateList()
        {
            RefreshSources();
        }


        public override void RefreshSecondaryData()
        {
            _modulos = ModuloList.GetOrderedList(false);
            _combo_modulos = new Library.Instruction.HComboBoxSourceList(_modulos, false);
            Datos_Modulos.DataSource = _combo_modulos;
            PgMng.Grow(string.Empty, "Modulos");

            _temas = TemaList.GetList(false);
            _combo_modulos.Childs = new Library.Instruction.HComboBoxSourceList(_temas);
            PgMng.Grow(string.Empty, "Temas");

            if (_combo_modulos.Count > 1) Modulo_CB.SelectedItem = _combo_modulos[0];
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

        #region Style

        public override void FormatControls()
        {
            if (Tabla == null) return;

            base.FormatControls();

            Preguntas_LB.Left = (this.Width - Preguntas_LB.Width) / 2;
            Respuestas_LB.Left = (this.Width - Respuestas_LB.Width) / 2;

            Contenido_Panel.SplitterDistance = 1000;
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
            Texto.Tag = 0.6;
            Modulo.Tag = 0.4;

            cols.Add(Texto);
            cols.Add(Modulo);

            ControlsMng.MaximizeColumns(Tabla, cols);
            ControlsMng.OrderByColumn(Tabla, Codigo, ListSortDirection.Ascending);

            Fields_CB.Text = Codigo.HeaderText;

            cols.Clear();

            Respuesta.Tag = "1";
            cols.Add(Respuesta);

            ControlsMng.MaximizeColumns(Respuestas_Grid, cols);
            
            ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla));
            ControlsMng.MarkGridColumn(Respuestas_Grid, ControlsMng.GetCurrentColumn(Respuestas_Grid));


            ControlTools.Instance.CopyBasicStyle(DisponibleStyle);
            DisponibleStyle.BackColor = Color.LightGreen;

            ControlTools.Instance.CopyBasicStyle(ReservadaStyle);
            ReservadaStyle.BackColor = Color.LightBlue;

            ControlTools.Instance.CopyBasicStyle(BloqueadaStyle);
            BloqueadaStyle.BackColor = Color.WhiteSmoke;

            SetColumnActive(ControlsMng.GetColumn(Tabla, Texto.DataPropertyName));

        }

        protected override void SetRowFormat(DataGridViewRow row)
        {
            if (row.IsNewRow) return;
            Pregunta item = (Pregunta)row.DataBoundItem;

            if (item.Activa)
            {
                if (item.FechaDisponibilidad.Date <= DateTime.Today)
                    row.DefaultCellStyle = DisponibleStyle;
                else
                    row.DefaultCellStyle = ReservadaStyle;
            }
            else
                row.DefaultCellStyle = BloqueadaStyle;
        }

        #endregion

        #region Actions

        public override void OpenAddForm()
        {
            try
            {
                PreguntasAddForm form = new PreguntasAddForm(true, List);
                AddForm(form);

                ExecuteAction(molAction.FilterAll);
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
                PreguntaList plist = PreguntaList.GetList(ActiveList);
                AddForm(new PreguntasViewForm(ActiveOID, plist, true));
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
                PreguntasEditForm form = new PreguntasEditForm(ActiveItem, ActiveList, true);
                if (form.Lista != null)
                    AddForm(form);
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
                    if (!List.Contains(ActiveOID))
                    {
                        PreguntaInfo item = PreguntaInfo.Get(ActiveOID, false);
                        if (item != null)
                        {
                            List = Preguntas.GetPreguntasModulo(item.OidModulo);
                            _filter_results = Preguntas.SortList(List, SortProperty, SortDirection);
                            //ApplyFilter();
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido cargar la pregunta seleccionada");
                        }
                    }
                    Pregunta pregunta = List.GetItem(oid);
                    if (pregunta.Reservada)
                        MessageBox.Show("No se puede eliminar una pregunta incluída en un examen" +
                                        Environment.NewLine +
                                        "que aún no se ha celebrado.");
                    else
                    {
                        Pregunta.Delete(oid);
                        List.Remove(pregunta);

                        _action_result = DialogResult.OK;

                        ExecuteAction(molAction.FilterAll);

                    }
                }
                catch (DataPortalException ex)
                {
                    MessageBox.Show(iQExceptionHandler.GetiQException(ex).Message);
                }
            //}
        }

        public override void PrintList()
        {
            //Separamos las preguntas tipo test de las de desarrollo
            //PreguntaList _all = null;

            PreguntaList List = PreguntaList.GetList(Datos.List as IList<Pregunta>);
            //_all = List;

            //PreguntaList test = PreguntaList.SeparaPreguntasTest(_all);
            //PreguntaList desarrollo = PreguntaList.SeparaPreguntasDesarrollo(_all);

            //PreguntaExamens p_test = PreguntaExamens.NewChildList();
            //PreguntaExamens p_desarrollo = PreguntaExamens.NewChildList();

            //Preguntas preguntas = Preguntas.NewChildList();

            //long orden = 1;

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

            //foreach (PreguntaInfo item in test)
            //{
            //    PreguntaExamen pexamen = PreguntaExamen.New();
            //    Pregunta pregunta_examen = Pregunta.New();
            //    pexamen.CopyValues(item);
            //    pregunta_examen.Base.CopyValues(item);
            //    pexamen.Orden = orden;
            //    orden++;
            //    p_test.AddItem(pexamen);
            //    pregunta_examen.MarkItemChild();
            //    preguntas.AddItem(pregunta_examen);
            //    foreach (RespuestaInfo res in item.Respuestas)
            //    {
            //        if (res.OidPregunta == item.Oid)
            //        {
            //            RespuestaExamen rexamen = RespuestaExamen.NewChild(pexamen);
            //            rexamen.CopyValues(res);
            //            pexamen.RespuestaExamens.AddItem(rexamen);
            //        }
            //    }
            //}

            //foreach (PreguntaInfo item in desarrollo)
            //{
            //    PreguntaExamen pexamen = PreguntaExamen.New();
            //    Pregunta pregunta_examen = Pregunta.New();
            //    pexamen.CopyValues(item);
            //    pregunta_examen.Base.CopyValues(item);
            //    pexamen.Orden = orden;
            //    orden++;
            //    p_desarrollo.AddItem(pexamen);
            //    pregunta_examen.MarkItemChild();
            //    preguntas.AddItem(pregunta_examen);
            //}

            ExamenReportMng reportMng = new ExamenReportMng(AppContext.ActiveSchema);

            if (List.Count > 0)
            {
                Library.Instruction.Reports.Preguntas.PreguntasListRpt report = reportMng.GetPreguntasListReport(List);
                report.SetParameterValue("Empresa", empresa.Name);
                if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(report.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);
                ReportViewer.SetReport(report);
                ReportViewer.ShowDialog();
            }
            /*if (p_test.Count > 0)
            {
                Library.Instruction.Reports.Examen.PreguntasTestRpt r_test = reportMng.GetDetailPreguntasTestReport(p_test, preguntas);
                r_test.SetParameterValue("Empresa", empresa.Name);
                if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(r_test.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);
                ReportViewer.SetReport(r_test);
                ReportViewer.ShowDialog();
            }

            if (p_desarrollo.Count > 0)
            {
                Library.Instruction.Reports.Examen.PreguntasDesarrolloRpt r_desarrollo = reportMng.GetDetailPreguntasDesarrolloReport(p_desarrollo, preguntas);
                r_desarrollo.SetParameterValue("Empresa", empresa.Name);
                if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(r_desarrollo.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);
                ReportViewer.SetReport(r_desarrollo);
                ReportViewer.ShowDialog();
            }*/
        }

        protected override bool DoFind(object value)
        {
            _search_results = Localize(value, Tabla.Columns[((DataGridViewColumn)(Fields_CB.SelectedItem)).Name].DataPropertyName);
            return _search_results != null;
        }

        protected override bool DoFilter(object value, object secondValue = null)
        {
            _filter_results = Localize(value, Tabla.Columns[((DataGridViewColumn)(Fields_CB.SelectedItem)).Name].DataPropertyName);
            return _filter_results != null;
        }

        protected override bool DoFilter(FilterItem fItem)
        {
            _filter_results = Localize(fItem);
            return _filter_results != null;
        }

        protected override bool DoFilterByFirst(string value, string column_name)
        {
            if (column_name == null)
                column_name = ControlsMng.GetCurrentColumn(Tabla).Name;

            _filter_results = Localize(value, column_name);
            return _filter_results != null;
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
        
        protected new SortedBindingList<Pregunta> Localize(object value, string column_name)
        {
            SortedBindingList<Pregunta> list = null;

            Preguntas sourceList = null;

            switch (FilterType)
            {
                case IFilterType.None:
                    if (List == null)
                    {
                        MessageBox.Show(moleQule.Face.Resources.Messages.NO_RESULTS);
                        return null;
                    }
                    sourceList = List;
                    //_filter_values = string.Empty;
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
                MessageBox.Show(Resources.Messages.NO_RESULTS);
                return sourceList.GetSortedList();
            }

            DatosSearch.DataSource = list;
            DatosSearch.MoveFirst();

            AddFilterItem(column_name, value);

            Tabla.Focus();

            return list;
        }
        
        protected new SortedBindingList<Pregunta> Localize(FilterItem item)
        {
            SortedBindingList<Pregunta> list = null;
            Preguntas sourceList = null;

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

            AddFilterItem(item);

            return list;
        }
        
        #endregion

        #region Buttons

        #endregion

        #region Events

        private void PreguntaMngForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (List != null) List.CloseSession();
        }

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
            //SetGridFormat();
            ControlsMng.SetCurrentCell(Tabla);
            ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla));
            Fields_CB.Text = ControlsMng.GetCurrentColumn(Tabla).HeaderText;
        }

        private void Tabla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla));
            Fields_CB.Text = ControlsMng.GetCurrentColumn(Tabla).HeaderText;
        }

        private void Tabla_SelectionChanged(object sender, EventArgs e)
        {
            if (ActiveItem != null)
            {
                if (ActiveItem.Respuestas.Count == 0) ActiveItem.LoadRespuestas();
                Datos_Respuestas.DataSource = ActiveItem.Respuestas;
            }

            foreach (DataGridViewRow row in Respuestas_Grid.Rows)
            {
                row.DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
            }
        }

        private void Modulo_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Modulo_CB.SelectedItem != null)
            {
                Datos_Temas.DataSource = _combo_modulos.GetFilteredChilds(CurrentModuloOid);
                Tema_CB.SelectedItem = _combo_modulos.Childs[0];

                FilterByModuloAction();
            }
        }

        private void Tema_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tema_CB.SelectedItem != null)
            {
                if (CurrentTema != string.Empty)
                {
                    if (DoFilterByProperty(CurrentTema, Tema.Name))
                    {
                        _filter_type = IFilterType.Filter;
                        SetFilter(true);
                    }
                }
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
