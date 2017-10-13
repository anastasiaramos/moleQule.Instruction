using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Face;
using moleQule.Face.Skin01;

using moleQule.Library.Instruction; 


namespace moleQule.Face.Instruction
{
    public partial class CronogramaForm : ItemMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return 14; } }

        protected ClasePracticaList _practicas;
        protected ClaseTeoricaList _teoricas;
        protected ModuloList _modulos;

        public virtual Cronograma Entity { get { return null; } set { } }
        public virtual CronogramaInfo EntityInfo { get { return null; } }

        #endregion

        #region Factory Methods

        public CronogramaForm() : this(-1, true) { }

        public CronogramaForm(bool isModal) : this(-1, isModal) { }

        public CronogramaForm(long oid) : this(oid, true) { }

        public CronogramaForm(long oid, bool ismodal)
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

            Imprimir_Button.Visible = true;
            Imprimir_Button.Enabled = true;

            base.FormatControls();

            List<string> visibles = new List<string>();

            visibles.Add(Clase.Name);
            visibles.Add(Semana.Name);
            visibles.Add(Dia.Name);
            visibles.Add(Asignatura.Name);
            visibles.Add(Numero.Name);
            visibles.Add(Duracion.Name);
            visibles.Add(Ordenar.Name);
            visibles.Add(Indice.Name);
            visibles.Add(Fecha.Name);
            visibles.Add(Hora.Name);

            ControlTools.ShowDataGridColumns(Sesiones_Grid, visibles);

            VScrollBar vs = new VScrollBar();

            int rowWidth = (int)(Sesiones_Grid.Width - vs.Width
                                                - Sesiones_Grid.RowHeadersWidth
                                                - Sesiones_Grid.Columns[Semana.Name].Width
                                                - Sesiones_Grid.Columns[Dia.Name].Width
                                                - Sesiones_Grid.Columns[Asignatura.Name].Width
                                                - Sesiones_Grid.Columns[Numero.Name].Width
                                                - Sesiones_Grid.Columns[Ordenar.Name].Width
                                                - Sesiones_Grid.Columns[Indice.Name].Width
                                                - Sesiones_Grid.Columns[Duracion.Name].Width
                                                - Sesiones_Grid.Columns[Fecha.Name].Width
                                                - Sesiones_Grid.Columns[Hora.Name].Width);

            Sesiones_Grid.Columns[Clase.Name].Width = (int)(rowWidth * 0.995);
        }

        protected override void RefreshMainData()
        {
            _practicas = ClasePracticaList.GetClasesPlanList(EntityInfo.OidPlan);
            PgMng.Grow();

            _teoricas = ClaseTeoricaList.GetClasesPlanList(EntityInfo.OidPlan);
            PgMng.Grow();

            _modulos = ModuloList.GetList(false);
            PgMng.FillUp();
        }

        protected virtual void OrdenarAction(int fila) { }

        #endregion

        #region Validation & Format

        #endregion

        #region Print

        public override void PrintObject()
        {
            CronogramaReportMng reportMng = new CronogramaReportMng(AppContext.ActiveSchema);
            
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

            Library.Instruction.Reports.Horario.CronogramaRpt rpt = reportMng.GetCronogramaReport(EntityInfo, CompanyInfo.Get(AppContext.ActiveSchema.Oid)
            , _modulos, _teoricas, _practicas);
            rpt.SetParameterValue("Empresa", empresa.Name); 
            if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(rpt.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);
            ReportViewer.SetReport(rpt);
            ReportViewer.ShowDialog();
        }

        #endregion

        #region Buttons

        protected override void PrintAction()
        {
            PrintObject();
        }

        #endregion

        #region Events

        private void Sesiones_Grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (Sesiones_Grid.Rows.Count > 0)
                SetUnlinkedGridValues(Sesiones_Grid.Name);
        }

        private void Sesiones_Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Sesiones_Grid.Columns[e.ColumnIndex].Name == "Ordenar")
                OrdenarAction(e.RowIndex);
        }

        #endregion


    }
}

