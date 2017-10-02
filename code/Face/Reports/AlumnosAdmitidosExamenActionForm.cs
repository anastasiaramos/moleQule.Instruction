using System;
using System.Windows.Forms;
using System.Collections.Generic;

using Csla;
using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Instruction;

using moleQule.Library.Instruction.Reports.Alumno;

namespace moleQule.Face.Instruction
{
    public partial class AlumnosAdmitidosExamenActionForm : Skin01.ActionSkinForm
    {
        #region Attributes & Properties

        protected override int BarSteps { get { return base.BarSteps; } }

        public const string ID = "AlumnosAdmitidosExamenActionForm";
        public static Type Type { get { return typeof(AlumnosAdmitidosExamenActionForm); } }

        ModuloInfo _modulo = null;       
        Dictionary<string, PromocionInfo> _promociones = new Dictionary<string,PromocionInfo>();
        Dictionary<string, PromocionInfo> _promociones_todas = new Dictionary<string, PromocionInfo>();

        #endregion

        #region Factory Methods

        public AlumnosAdmitidosExamenActionForm()
            : this(null) {}

        public AlumnosAdmitidosExamenActionForm(Form parent)
            : base(true, parent)
        {
            InitializeComponent();
            SetFormData();
        }

        #endregion

		#region Business Methods

        protected override void RefreshMainData()
        {
            FechaExamen_DTP.Value = DateTime.Today;
        }
        
		#endregion

        #region Layout
        
        #endregion

        #region Actions

        protected override void PrintAction()
        {
            if (_modulo == null || _promociones.Count == 0) return;

            PgMng.Reset(3, 1, Face.Resources.Messages.RETRIEVING_DATA, this);

            Alumno_PromocionList list = Alumno_PromocionList.GetListaAdmitidos(_modulo.Oid, FechaExamen_DTP.Value, _promociones, false);

            PgMng.Grow(Face.Resources.Messages.BUILDING_REPORT);

            AlumnoReportMng reportMng = new AlumnoReportMng(AppContext.ActiveSchema, string.Empty);

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

            AlumnosAdmitidosExamenRpt rpt = reportMng.GetAlumnosAdmitidosReport(list, _modulo, empresa);
            PgMng.FillUp();

            rpt.SetParameterValue("Empresa", empresa.Name);
            if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(rpt.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);
            ShowReport(rpt);

            _action_result = DialogResult.Ignore;
        }

        #endregion

        #region Buttons
        
        private void Modulo_BT_Click(object sender, EventArgs e)
        {
            ModuloList modulos = ModuloList.GetList(false);
            ModuloSelectForm form = new ModuloSelectForm(this, modulos);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _modulo = form.Selected as ModuloInfo;
                Modulo_TB.Text = _modulo.Texto;
            }
        }

        private void Promocion_BT_Click(object sender, EventArgs e)
        {
            PromocionList lista_promociones = PromocionList.GetList(false);
            if (_promociones_todas.Count == 0)
            {
                foreach (PromocionInfo info in lista_promociones)
                    _promociones_todas.Add(info.Numero + " - " + info.Nombre, info);
            }
            PromocionSelectForm form = new PromocionSelectForm(this, lista_promociones);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                if (form.Selected is PromocionInfo)
                {
                    PromocionInfo info = form.Selected as PromocionInfo;

                    if (!_promociones.ContainsKey(info.Numero + " - " + info.Nombre))
                        _promociones.Add(info.Numero + " - " + info.Nombre, info);
                }
                else if (form.Selected is SortedBindingList<PromocionInfo>)
                {
                    SortedBindingList<PromocionInfo> promociones = form.Selected as SortedBindingList<PromocionInfo>;

                    foreach (PromocionInfo info in promociones)
                    {
                        if (!_promociones.ContainsKey(info.Numero + " - " + info.Nombre))
                            _promociones.Add(info.Numero + " - " + info.Nombre, info);
                    }
                }

                Promociones_CLB.Items.Clear();

                foreach (KeyValuePair<string, PromocionInfo> item in _promociones)
                    Promociones_CLB.Items.Add(item.Key, true);
            }
        }

        private void ClearPromociones_BT_Click(object sender, EventArgs e)
        {
            _promociones.Clear();
            Promociones_CLB.Items.Clear();
        }

        private void Promociones_CLB_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            PgMng.Reset(2, 1, Resources.Messages.LOADING_DATA);

            try
            {
                if (e.NewValue == CheckState.Unchecked)
                {
                    if (_promociones.ContainsKey(Promociones_CLB.Items[e.Index].ToString()))
                        _promociones.Remove(Promociones_CLB.Items[e.Index].ToString());
                    PgMng.Grow();
                }
                else if (e.NewValue == CheckState.Checked)
                {
                    if (!_promociones.ContainsKey(Promociones_CLB.Items[e.Index].ToString()))
                        _promociones.Add(Promociones_CLB.Items[e.Index].ToString(), _promociones_todas[Promociones_CLB.Items[e.Index].ToString()]);
                    PgMng.Grow();
                }
            }
            catch { }
            finally { PgMng.FillUp(); }
            
        }

        #endregion
        
        #region Events
        
        #endregion



    }
}

