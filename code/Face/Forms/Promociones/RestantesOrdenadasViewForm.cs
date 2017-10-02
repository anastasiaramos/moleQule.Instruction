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
    public partial class RestantesOrdenadasViewForm : ItemMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 3; } }

        protected List<ClasePracticaList> _practicas = new List<ClasePracticaList>();
        protected ClaseTeoricaList _teoricas;
        protected ListaClases _lista;

        protected long OidPromocion;

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        protected PlanEstudiosInfo _entity;

        public PlanEstudiosInfo EntityInfo { get { return _entity; } }

        private void RellenaLista()
        {
            foreach (ClaseTeoricaInfo item in _teoricas)
            {
                Clase clase = new Clase(item);
                _lista.Add(clase);
            }

            foreach (ClasePracticaList lista in _practicas)
            {
                if (lista != null)
                {
                    foreach (ClasePracticaInfo item in lista)
                    {
                        Clase clase = new Clase(item);
                        _lista.Add(clase);
                    }
                }
            }

            _lista = _lista.OrdenaLista();

        }

        #endregion

        #region Factory Methods

              /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar.
        /// </summary>
        protected RestantesOrdenadasViewForm() : this(-1, true) { }

        public RestantesOrdenadasViewForm(bool isModal) : this(-1, isModal) { }

        public RestantesOrdenadasViewForm(long oid)
            : this(oid, true) { }
        public RestantesOrdenadasViewForm(long oid, long oid_promocion)
            : this(oid, oid_promocion, true) { }

        public RestantesOrdenadasViewForm(long oid, bool ismodal)
            : this(oid, 0, ismodal)
        {
        }

        public RestantesOrdenadasViewForm(long oid, long oid_promocion, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
            OidPromocion = oid_promocion;
            SetFormData();
            this.Text = Resources.Labels.CLASES_ORDENADAS_VIEW_TITLE;
            _mf_type = ManagerFormType.MFView;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = PlanEstudiosInfo.Get(oid, true);
            _mf_type = ManagerFormType.MFView;
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
            Cancel_BT.Enabled = false;
            Cancel_BT.Visible = false;
            
            this.MaximizeForm();

            PanelesV.Size = this.DisplayRectangle.Size;

            base.FormatControls(); 
        }

        protected override void RefreshMainData()
        {

            if (_practicas.Count == 0)
                for (int i = 0; i < 3; i++)
                    _practicas.Add(null);

            for (int i = 1; i < 3; i++)
            {
                _practicas[i] = ClasePracticaList.GetDisponiblesList(EntityInfo.Oid, OidPromocion, 0, i);
                PgMng.Grow();
            }

            _teoricas = ClaseTeoricaList.GetDisponiblesList(EntityInfo.Oid, OidPromocion, 0);
            PgMng.Grow();

            _lista = new ListaClases();
            RellenaLista();
            PgMng.FillUp();

            Datos_Clases.DataSource = _lista;
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

            Library.Instruction.Reports.Horario.ClasesRpt rpt = reportMng.GetDetailReport(_lista, empresa);
            rpt.SetParameterValue("Empresa", empresa.Name);
            if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(rpt.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);
            ReportViewer.SetReport(rpt);
            ReportViewer.ShowDialog();
        }

        #endregion

        #region Actions

        protected override void SaveAction() { _action_result = DialogResult.Cancel; }

        protected override void PrintAction() { PrintObject(); }

        #endregion

        #region Events

        #endregion

    }
}

