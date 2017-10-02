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
    public partial class ResumenPlanExtraForm : ActionSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return 2; } }

        public const string ID = "ResumenPlanExtraForm";
        public static Type Type { get { return typeof(ResumenPlanExtraForm); } }

        List<RegistroResumenPlanDocente> _lista_extras = null;
        long _total_extras = 0;

        #endregion

        #region Factory Methods

        public ResumenPlanExtraForm()
            : this(true, null, null) { }

        public ResumenPlanExtraForm(bool IsModal, List<RegistroResumenPlanDocente> lista_extras, Form parent)
            : base(IsModal, parent)
        {
            InitializeComponent();
            _lista_extras = lista_extras;
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
            Datos_Extras.DataSource = _lista_extras;
            PgMng.Grow();

            _total_extras = 0;
            foreach (RegistroResumenPlanDocente item in _lista_extras)
                _total_extras += item.NClasesSubmodulo;
            Teoricas_TB.Text = _total_extras.ToString();
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

        private void ResumenPlanExtraForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cerrar();
        }


        #endregion

        #region Actions

        protected override void PrintAction()
        {
            if (_lista_extras != null && _lista_extras.Count > 0)
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

                Library.Instruction.Reports.PlanEstudios.ResumenRpt rpt = reportMng.GetDetailReport(_lista_extras, empresa);
                rpt.SetParameterValue("Empresa", empresa.Name);
                if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(rpt.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);
                ReportViewer.SetReport(rpt);
                ReportViewer.ShowDialog();
            }

        }

        #endregion

    }
}

