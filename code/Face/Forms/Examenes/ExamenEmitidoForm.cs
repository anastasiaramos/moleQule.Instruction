using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin01;

using moleQule.Library.Common;
using moleQule.Library.Instruction;
using moleQule.Library.Instruction.Reports.Examen;

namespace moleQule.Face.Instruction
{
    public partial class ExamenEmitidoForm : ItemMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 4; } }

        public virtual Examen Entity { get { return null; } set { } }
        public virtual ExamenInfo EntityInfo { get { return Entity.GetInfo(true); } }

        protected bool _cerrado = true;
        protected PreguntaExamens _preguntas = null;
        protected ModuloInfo _modulo = null;
        protected SubmoduloList _submodulos = null;
        protected TemaList _temas = null;
        protected Preguntas _preguntas_examen = null;
        protected PreguntaList _lista_preguntas = null;

        protected PromocionList promociones = null;
        protected Dictionary<string, PromocionInfo> _promociones_select = new Dictionary<string, PromocionInfo>();
        protected Dictionary<string, PromocionInfo> _promociones_todas = new Dictionary<string, PromocionInfo>();

        //flag que se activa al intentar liberar un examen para no actualizar continuamente la lista de preguntas mostradas
        protected bool _liberar = false;

        ChartMng _chart_mng; 

        #endregion

        #region Factory Methods

        public ExamenEmitidoForm() : this(-1, true) { }

        public ExamenEmitidoForm(bool isModal) : this(-1, isModal) { }

        public ExamenEmitidoForm(long oid) : this(oid, true) { }

        public ExamenEmitidoForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
        }

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();

            List<DataGridViewColumn> cols = new List<DataGridViewColumn>();
            Texto.Tag = "1";

            cols.Add(Texto);

            ControlsMng.MaximizeColumns(Preguntas_Grid, cols);
            ControlsMng.MarkGridColumn(Preguntas_Grid, ControlsMng.GetCurrentColumn(Preguntas_Grid));
        }

        public override void RefreshSecondaryData()
        {
            ModuloList modulos = ModuloList.GetList(false);
            Library.Instruction.HComboBoxSourceList _combo_modulos = new Library.Instruction.HComboBoxSourceList(modulos);
            Datos_Modulos.DataSource = _combo_modulos;
            PgMng.Grow(string.Empty, "_combo_modulos");

            InstructorList instructores = InstructorList.GetList(false);
            Library.Instruction.HComboBoxSourceList _combo_instructores = new Library.Instruction.HComboBoxSourceList(instructores);
            Datos_Instructores.DataSource = _combo_instructores;
            PgMng.Grow(string.Empty, "_combo_instructores");

            PromocionList promociones = PromocionList.GetList(false);
            Library.Instruction.HComboBoxSourceList _combo_promociones = new Library.Instruction.HComboBoxSourceList(promociones);
            ComboBoxSource combo = new ComboBoxSource(-1, "No especificado");
            _combo_promociones.Add(combo);
            Datos_Promociones.DataSource = _combo_promociones;
            PgMng.Grow(string.Empty, "_combo_promociones");

            _lista_preguntas = PreguntaList.GetPreguntasModulo(Entity.OidModulo);
            PgMng.Grow(string.Empty, "Preguntas del Módulo");
            //_submodulos = SubmoduloList.GetList(false);
            //_temas = TemaList.GetList(false);
        }

        protected Chart GetChart()
        {
            if (_chart_mng == null)
            {
                _chart_mng = new ChartMng(MainBaseForm.Instance, typeof(Skin05.ChartSkinForm));
            }

            return _chart_mng.NewChart();
        }
        
        protected override void SetUnlinkedGridValues(string gridName) {}

        protected virtual void Quitar_Button() { }
        protected virtual void SetPreguntas_Button() { }
        protected virtual void Emitir_Button() { }
        protected virtual void LiberarAction() { }
        protected virtual void Resumen_Button() { }
        protected virtual void Proponer_Button() { }
        protected virtual void CellContentClick(int column, int row) { }
        protected virtual void CellEndEdit(int column, int row) { }
        protected virtual void Desarrollo_Check() { }
        protected virtual void AlumnosButton() { }
        protected virtual void ResumenPreguntasButton() { }

        #endregion

        #region Validation & Format

        #endregion

        #region Print

        #endregion

        #region Actions

        protected DataPoint BuildPoint(EstadisticaExamenInfo item)
        {
            DataPoint point = new DataPoint();
            point.XValue = item.NumeroPregunta;
            point.YValues = !item.Anulada ? new double[1] { (double)item.PorcentajeFallos } : new double[1] { 0 };
            point.AxisLabel = item.NumeroPregunta.ToString();
            point.Label = !item.Anulada && item.PorcentajeFallos > 0  ? item.PorcentajeFallos.ToString("N2")  + "%": string.Empty;

            return point;
        }

        protected void ShowChartAction(EstadisticaExamenList estadisticas)
        {
            if (estadisticas == null || estadisticas.Count == 0) return;

            Chart chart = GetChart();

            foreach (EstadisticaExamenInfo item in estadisticas)
            {
                System.Windows.Forms.DataVisualization.Charting.Series serie = new System.Windows.Forms.DataVisualization.Charting.Series
                {
                    Name = item.NumeroPregunta.ToString(),
                    ChartType = SeriesChartType.StackedColumn,
                    Color = item.PorcentajeFallos < 85 ? Color.FromArgb(216, 43, 43) : Color.FromArgb(255,0,0),
                    BorderColor = item.PorcentajeFallos < 85 ? Color.Gray : Color.Red,
                    IsValueShownAsLabel = false,
                    IsXValueIndexed = true
                };

                chart.Series.Add(serie);
                serie.Font = new Font(serie.Font.FontFamily, 5, serie.Font.Style);
                serie.Points.Add(BuildPoint(item));
            }

            chart.ChartAreas[0].AxisY.Maximum = 104.99;
            chart.ChartAreas[0].AxisY.Interval = 5;
            chart.ChartAreas[0].AxisX.Interval = 1;

            chart.ChartAreas[0].AxisY.Title = "% Fallos";
            chart.ChartAreas[0].AxisX.Title = "Preguntas";
            chart.ChartAreas[0].AxisX.LabelAutoFitMinFontSize = 5;
            chart.ChartAreas[0].AxisX.LabelStyle.Font = new Font(chart.ChartAreas[0].AxisX.LabelStyle.Font.FontFamily, 4, chart.ChartAreas[0].AxisX.LabelStyle.Font.Style);
            chart.Titles[0].Text = "Estadísticas de Fallo de Preguntas en Examen: " + EntityInfo.Titulo;
            
            chart.AlignDataPointsByAxisLabel();

            _chart_mng.ChartForm.Plano_RB.Checked = true;
            _chart_mng.ChartForm.Datos_GB.Visible = false;
            _chart_mng.ChartForm.Estilo_GB.Visible = false;

            _chart_mng.ShowChart();
        }

        protected virtual void RellenaPromociones() { }

        #endregion

        #region Buttons

        private void Quitar_BT_Click(object sender, EventArgs e)
        {
            Quitar_Button();
        }

        private void Preguntas_BT_Click(object sender, EventArgs e)
        {
            SetPreguntas_Button();
        }

        private void Cerrar_BT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Emitir_BT_Click(object sender, EventArgs e)
        {
            Emitir_Button();
        }

        private void Liberar_BT_Click(object sender, EventArgs e)
        {
            LiberarAction();
        }

        private void Resumen_BT_Click(object sender, EventArgs e)
        {
            Resumen_Button();
        }

        private void Proponer_BT_Click(object sender, EventArgs e)
        {
            Proponer_Button();
        }

        private void Imprimir_BT_Click(object sender, EventArgs e)
        {
            if (EntityInfo.FechaEmision.Date > DateTime.Today.Date)
            {
                MessageBox.Show(Resources.Messages.EXAMEN_NO_EMITIDO);
                return;
            }

            if (EntityInfo.Desarrollo)
            { 
                //tiene que llamar a ExamenDesarrolloReportForm
                ExamenDesarrolloReportForm form = new ExamenDesarrolloReportForm(true, EntityInfo, null, null);
                form.ShowDialog();
            }
            else
            {
                //tiene que llamar a ExamenTestReportForm
                ExamenTestReportForm form = new ExamenTestReportForm(true, EntityInfo, null,  null);
                form.ShowDialog();
            }
        }

        private void Estadisticas_BT_Click(object sender, EventArgs e)
        {

            if (EntityInfo.FechaEmision.Date > DateTime.Today.Date)
            {
                MessageBox.Show(Resources.Messages.EXAMEN_NO_EMITIDO);
                return;
            }

            if (!EntityInfo.Desarrollo)
            {
                EstadisticaExamenList estadisticas = EstadisticaExamenList.GetList(Entity);
                ShowChartAction(estadisticas);

                ExamenReportMng reportMng = new ExamenReportMng(AppContext.ActiveSchema);

                EstadisticaExamenRpt rpt = reportMng.GetEstadisticaReport(EntityInfo, estadisticas, CompanyInfo.Get(AppContext.ActiveSchema.Oid, false));

                ReportViewer.SetReport(rpt);
                ReportViewer.ShowDialog();

            }
        }

        private void Notas_BT_Click(object sender, EventArgs e)
        {
            NotasAlumnosForm form = new NotasAlumnosForm(true);
            form.SetSourceData(Entity);
            form.ShowDialog();

            if (EntityInfo.FechaEmision.Date > DateTime.Today.Date)
            {
                MessageBox.Show(Resources.Messages.EXAMEN_NO_EMITIDO);
                return;
            }
        }
        
        private void Alumnos_BT_Click(object sender, EventArgs e)
        {
            AlumnosButton();
        }

        private void ResumenPreguntas_BT_Click(object sender, EventArgs e)
        {
            ResumenPreguntasButton();
        }

        private void Promocion_BT_Click(object sender, EventArgs e)
        {
            if (promociones == null) return;

            try
            {
                PromocionSelectForm form = new PromocionSelectForm(this, promociones);

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (form.Selected is PromocionInfo)
                    {
                        PromocionInfo info = form.Selected as PromocionInfo;

                        ExamenPromocion item = Entity.Promociones.GetItem(new FCriteria<long>("OidPromocion", info.Oid));
                        if (item == null)
                        {
                            ExamenPromocion nuevo = Entity.Promociones.NewItem(Entity);
                            nuevo.OidPromocion = info.Oid;
                        }

                    }
                    else if (form.Selected is SortedBindingList<PromocionInfo>)
                    {
                        SortedBindingList<PromocionInfo> promos = form.Selected as SortedBindingList<PromocionInfo>;

                        foreach (PromocionInfo info in promos)
                        {
                            ExamenPromocion item = Entity.Promociones.GetItem(new FCriteria<long>("OidPromocion", info.Oid));
                            if (item == null)
                            {
                                ExamenPromocion nuevo = Entity.Promociones.NewItem(Entity);
                                nuevo.OidPromocion = info.Oid;
                            }
                        }
                    }

                    RellenaPromociones();
                }
            }
            catch { throw new iQException("Promocion_BT_Click"); }
        }

        private void ClearPromociones_BT_Click(object sender, EventArgs e)
        {
            if (Entity.Alumnos != null && Entity.Alumnos.Count > 0)
            {
                MessageBox.Show("No se pueden eliminar todos los cursos de un examen que tiene alumnos asociados.");
            }
            else
            {
                try
                {
                    Entity.Promociones.RemoveAll();
                    RellenaPromociones();
                }
                catch { throw new iQException("ClearPromociones_BT_Click"); }
            }
        }
        
        #endregion

        #region Events

        private void Preguntas_Grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetUnlinkedGridValues(Preguntas_Grid.Name);
        }

        private void Preguntas_Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CellContentClick(e.ColumnIndex, e.RowIndex);
        }

        /// <summary>
        /// si se cambia el tipo de examen, habrá que eliminar de la lista las preguntas que no sean del mismo tipo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void desarrolloCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Desarrollo_Check();
        }

        private void FExamen_DTP_ValueChanged(object sender, EventArgs e)
        {
            if (FExamen_DTP.Value.Date.Equals(Entity.FechaExamen.Date)
                && FExamen_DTP.Checked) return;

            if (FExamen_DTP.Checked)
                Entity.FechaExamen = FExamen_DTP.Value;
            else
                Entity.FechaExamen = DateTime.MaxValue;
        }

        private void Preguntas_Grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CellEndEdit(e.ColumnIndex, e.RowIndex);
        }
        
        #endregion


    }
}


