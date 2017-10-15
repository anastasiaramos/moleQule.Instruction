using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using moleQule.Library.CslaEx;

using moleQule.Face;
using moleQule.Library;
using moleQule.Library.Common;

using moleQule.Library.Instruction;

namespace moleQule.Face.Instruction
{
    public partial class PlantillaViewForm : PlantillaForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 4; } }

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        protected PlantillaExamenInfo _entity;

        public override PlantillaExamenInfo EntityInfo { get { return _entity; } }

        /// <summary>
        /// Función recursiva que va creando el árbol de preguntas por submódulo
        /// </summary>
        /// <param name="padre"></param>
        /// <param name="apartado"></param>
        private void SetSubmodulosValues(TreeNode padre, ModuloInfo modulo, SubmoduloList submodulos, TemaList temas)
        {
            TreeNode nodo = new TreeNode(modulo.NumeroModulo + " - " + modulo.Texto);
            nodo.NodeFont = new Font("Tahoma", (float)8.25, FontStyle.Regular);
            nodo.ForeColor = System.Drawing.Color.Black;
            nodo.Tag = EntityInfo;
            nodo.SelectedImageKey = "modulo";

            if (padre == null)
            {

                while (Arbol_TV.Nodes.Count != 0)
                {
                    foreach (TreeNode t in Arbol_TV.Nodes)
                        Arbol_TV.Nodes.Remove(t);
                }

                Arbol_TV.Nodes.Add(nodo);
            }
            else
            {
                padre.Nodes.Add(nodo);
            }

            //foreach (SubmoduloInfo item in submodulos)
            //{
            foreach (TemaInfo tema in temas)
            {
                //if (p.OidSubmodulo == item.Oid)
                //{
                TreeNode pregunta = null;
                Preguntas_PlantillaInfo p = null;

                foreach (Preguntas_PlantillaInfo obj in EntityInfo.Preguntas)
                {
                    if (obj.OidTema == tema.Oid)
                    {
                        p = obj;
                        break;
                    }
                }

                if (p != null)
                {
                    pregunta = new TreeNode(tema.Codigo + " - " + tema.Nombre + " - Nivel : " + tema.Nivel.ToString() + " | Nº Preguntas : " + p.NPreguntas.ToString());
                    pregunta.NodeFont = new Font("Tahoma", (float)8.25, FontStyle.Regular);
                    pregunta.ForeColor = System.Drawing.Color.Black;
                    pregunta.Tag = p;
                    if (p.NPreguntas == 0)
                        pregunta.ImageKey = "submodulo_verde";
                    else
                        pregunta.ImageKey = "submodulo";

                    nodo.Nodes.Add(pregunta);
                }
                //}
            }
            //}

            Arbol_TV.ExpandAll();
        }

        #endregion

        #region Factory Methods

        public PlantillaViewForm() : this(-1, true) { }

        public PlantillaViewForm(long oid)
            : this(oid, true) { }

        public PlantillaViewForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();

            if (EntityInfo != null)
            {
                SetFormData();
                this.Text = Resources.Labels.PLANTILLA_EXAMEN_EDIT_TITLE;
            }

            _mf_type = ManagerFormType.MFView;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = PlantillaExamenInfo.Get(oid, true);
            _mf_type = ManagerFormType.MFView;
        }

        #endregion

        #region Style & Source


        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();
            Cancel_BT.Visible = false;
            Cancel_BT.Enabled = false;
            Idioma_CB.Enabled = false;
            

        }

        public override void RefreshSecondaryData()
        {
            if (_entity != null)
            {
                _modulo = ModuloInfo.Get(_entity.OidModulo, false);
                Modulo_TB.Text = _modulo.Codigo + " " + _modulo.Texto;

                _submodulos = SubmoduloList.GetModuloList(_modulo.Oid, false);
                _temas = TemaList.GetModuloList(_modulo.Oid, false);
            }
            PgMng.Grow();

            NPreguntas_TB.Text = _entity.NPreguntas.ToString();

            PgMng.Grow();

            Datos_Idiomas.DataSource = Library.Common.EnumText<EIdioma>.GetList(false);
            PgMng.Grow();
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity;
            PgMng.Grow();

            SetSubmodulosValues(null, _modulo, _submodulos, _temas);
            PgMng.Grow();
        }

        #endregion

        #region Actions

        protected override void SaveAction() { _action_result = DialogResult.Cancel; }

        protected override void PrintAction()
        {
            InformePlantillaList List = InformePlantillaList.GetList(EntityInfo.Oid);

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

                moleQule.Library.Instruction.Reports.Examen.InformePlantillaRpt report = reportMng.GetInformePlantillaReport(EntityInfo, List);
                report.SetParameterValue("Empresa", empresa.Name);
                if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(report.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);
                ReportViewer.SetReport(report);
                ReportViewer.ShowDialog();
            }
        }

        #endregion

        #region Events

        #endregion
    }

}
