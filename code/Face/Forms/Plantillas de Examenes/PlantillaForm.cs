using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Instruction;
using moleQule.Library.Common;

namespace moleQule.Face.Instruction
{
    public partial class PlantillaForm : moleQule.Face.Skin01.ItemMngSkinForm
    {

        #region Business Methods

        protected ModuloInfo _modulo = null;
        protected SubmoduloList _submodulos = null;
        protected TemaList _temas = null;

        public virtual PlantillaExamen Entity { get { return null; } set { } }
        public virtual PlantillaExamenInfo EntityInfo { get { return null; } }

        #endregion

        #region Factory Methods

        public PlantillaForm() : this(-1, true) { }

        public PlantillaForm(bool isModal) : this(-1, isModal) { }

        public PlantillaForm(long oid) : this(oid, true) { }

        public PlantillaForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
        }

        #endregion

        #region Style & Source

        /// <summary>
        /// Función que se debe definir en el EditForm, que mostrará un formulario para cambiar el número 
        /// de pregutnas de un submódulo determinado
        /// </summary>
        /// <param name="node">Nodo que representa la preguntas_plantilla que se quiere modificar</param>
        protected virtual void SetNPreguntas(TreeNode node) { }
        protected virtual void PrintDisponiblesAction()
        {
            SelectFechaDisponibilidadForm select_form = new SelectFechaDisponibilidadForm();
            if (select_form.ShowDialog() == DialogResult.OK)
            {
                InformePlantillaList List = InformePlantillaList.GetDisponiblesList(EntityInfo.Oid, select_form.FechaDisponibilidad_DTP.Value.Date);

                ExamenReportMng reportMng = new ExamenReportMng(AppContext.ActiveSchema);

                if (List.Count > 0)
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

                    moleQule.Library.Instruction.Reports.Examen.InformeDisponiblesPlantillaRpt report = reportMng.GetInformeDisponiblesPlantillaReport(EntityInfo, List);
                    report.SetParameterValue("Empresa", empresa.Name);
                    report.SetParameterValue("FechaDisponibilidad", select_form.FechaDisponibilidad_DTP.Value.Date);
                    if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(report.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);
                    ReportViewer.SetReport(report);
                    ReportViewer.ShowDialog();
                }
            }
        }

        #endregion

        #region Validation & Format

        #endregion

        #region Print

        #endregion

        #region Buttons

        #endregion

        #region Events

        private void Arbol_TV_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SetNPreguntas(e.Node);
        }

        private void Disponibles_BT_Click(object sender, EventArgs e)
        {
            PrintDisponiblesAction();
        }

        #endregion

    }
}


