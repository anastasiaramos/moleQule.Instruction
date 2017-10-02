using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Face;
using moleQule.Face.Skin01;

using moleQule.Library.Instruction;


namespace moleQule.Face.Instruction
{
    public partial class ResumenPlanDocenteForm : ActionSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return 4; } }

        public const string ID = "ResumenPlanDocenteForm";
        public static Type Type { get { return typeof(ResumenPlanDocenteForm); } }

        List<RegistroResumenPlanDocente> _lista_teoricas = null;
        List<RegistroResumenPlanDocente> _lista_practicas = null;
        long _total_practicas = 0;
        long _total_teoricas = 0;

        #endregion

        #region Factory Methods

        public ResumenPlanDocenteForm()
            : this(true, null, null, null) { }

        public ResumenPlanDocenteForm(bool IsModal, List<RegistroResumenPlanDocente> lista_teoricas,
            List<RegistroResumenPlanDocente> lista_practicas, Form parent)
            : base(IsModal, parent)
        {
            InitializeComponent();
            _lista_teoricas = lista_teoricas;
            _lista_practicas = lista_practicas;
            SetFormData();
        }


        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();

        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos_Teoricas.DataSource = _lista_teoricas;
            PgMng.Grow();

            _total_teoricas = 0;
            foreach (RegistroResumenPlanDocente item in _lista_teoricas)
                _total_teoricas += item.NClasesSubmodulo;
            Teoricas_TB.Text = _total_teoricas.ToString();
            PgMng.Grow();

            Datos_Practicas.DataSource = _lista_practicas;
            PgMng.Grow();

            _total_practicas = 0;
            foreach (RegistroResumenPlanDocente item in _lista_practicas)
                _total_practicas += item.NClasesSubmodulo;
            Practicas_TB.Text = _total_practicas.ToString();
            PgMng.FillUp();
        }

        #endregion

        #region Buttons

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SubmitAction()
        {

            _action_result = DialogResult.OK;
            Close();

        }

        /// <summary>
        /// Implementa Undo_button_Click
        /// </summary>
        protected override void CancelAction()
        {
            _action_result = DialogResult.Cancel;
            Cerrar();
        }

        #endregion

        #region Events

        private void ResumenPlanDocenteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cerrar();
        }


        #endregion

        #region Actions

        protected override void PrintAction()
        {
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

            switch(Resumen_TC.SelectedTab.Name)
            {
                case "Teoricas_TP":
                    {
                        if (_lista_teoricas != null && _lista_teoricas.Count > 0)
                        {
                            
                            CronogramaReportMng reportMng = new CronogramaReportMng(AppContext.ActiveSchema);
                            Library.Instruction.Reports.PlanEstudios.ResumenRpt rpt = reportMng.GetDetailReport(_lista_teoricas,empresa);
                            rpt.SetParameterValue("Empresa", empresa.Name);
                            if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(rpt.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);
                            ReportViewer.ShowDialog();
                        }
                    }
                    break;
                case "Practicas_TP":
                    {
                        if (_lista_practicas != null && _lista_practicas.Count > 0)
                        {
                            CronogramaReportMng reportMng = new CronogramaReportMng(AppContext.ActiveSchema);
                            Library.Instruction.Reports.PlanEstudios.ResumenRpt rpt = reportMng.GetDetailReport(_lista_practicas, empresa);
                            rpt.SetParameterValue("Empresa", empresa.Name);
                            if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(rpt.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);
                            ReportViewer.SetReport(rpt);
                            ReportViewer.ShowDialog();
                        }
                    }
                    break;
        }

        }

        #endregion

    }
}

