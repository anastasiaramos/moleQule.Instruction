using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin01;

using moleQule.Library.Common;
using moleQule.Library.Instruction;


namespace moleQule.Face.Instruction
{
    public partial class ResumenActionForm : ActionSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return 2; } }

        public const string ID = "ResumenActionForm";
        public static Type Type { get { return typeof(ResumenActionForm); } }

        protected SubmoduloList _submodulos = null;
        protected TemaList _temas = null;
        protected ModuloInfo _modulo = null;
        List<RegistroResumen> lista = null;
        protected PreguntaList _preguntas_modulo = null;
        protected Pregunta_Examens _preguntas_examen = null;
        protected Pregunta_ExamenList _preguntas_exameninfo = null;
        protected ExamenInfo _examen = null;

        #endregion

        #region Factory Methods

        public ResumenActionForm()
            : this(true, string.Empty) { }

        public ResumenActionForm(bool IsModal, string memo_preguntas)
            : base(IsModal)
        {
            InitializeComponent();
            SetFormData();
        }

        public void SetSourceData(Examen item, ModuloInfo modulo, PreguntaList preguntas)
        {
            _modulo = modulo;
            _submodulos = SubmoduloList.GetModuloList(_modulo.Oid, false);
            _temas = TemaList.GetModuloList(_modulo.Oid, false);
            _preguntas_modulo = preguntas;
            _preguntas_examen = item.Pregunta_Examens;
            _examen = item.GetInfo(false);

            this.Text = Resources.Labels.RESUMEN_EXAMEN_TITLE;
            lista = new List<RegistroResumen>();
            //string memo_preguntas = ";" + item;
            long contador = 0;

            foreach (SubmoduloInfo obj in _submodulos)
            {
                foreach (TemaInfo tema in _temas)
                {
                    if (tema.OidSubmodulo == obj.Oid)
                    {
                        foreach (Pregunta_Examen p in _preguntas_examen)
                        {
                            PreguntaInfo info = _preguntas_modulo.GetItem(p.OidPregunta);
                            if (info.OidTema == tema.Oid)
                            {
                                lista = RegistroResumen.ContabilizaPregunta(lista, obj.Oid, obj.Codigo + " " + obj.Texto, tema.Codigo);
                                contador++;
                            }
                        }
                    }
                }
            }
            lista.Add(new RegistroResumen("TODOS", "TODOS", contador));

            RefreshMainData();
        }


        public void SetSourceData(ExamenInfo item, ModuloInfo modulo, PreguntaList preguntas)
        {
            _modulo = modulo;
            _submodulos = SubmoduloList.GetModuloList(_modulo.Oid, false);
            _temas = TemaList.GetModuloList(_modulo.Oid, false);
            _preguntas_modulo = preguntas;
            _preguntas_exameninfo = item.Preguntas;
            _examen = item;

            this.Text = Resources.Labels.RESUMEN_EXAMEN_TITLE;
            lista = new List<RegistroResumen>();
            //string memo_preguntas = ";" + item;
            long contador = 0;

            foreach (SubmoduloInfo obj in _submodulos)
            {
                foreach (TemaInfo tema in _temas)
                {
                    if (tema.OidSubmodulo == obj.Oid)
                    {
                        foreach (Pregunta_ExamenInfo p in _preguntas_exameninfo)
                        {
                            PreguntaInfo info = _preguntas_modulo.GetItem(p.OidPregunta);
                            if (info.OidTema == tema.Oid)
                            {
                                lista = RegistroResumen.ContabilizaPregunta(lista, obj.Oid, obj.Codigo + " " + obj.Texto, tema.Codigo);
                                contador++;
                            }
                        }
                    }
                }
            }
            lista.Add(new RegistroResumen("TODOS", "TODOS", contador));

            RefreshMainData();
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
            Datos_Preguntas.DataSource = lista;
            PgMng.Grow();

            if (_modulo != null)
                Modulo_TB.Text = _modulo.NumeroModulo + ".- " + _modulo.Texto;
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

        protected override void PrintAction()
        {
            ExamenReportMng reportMng = new ExamenReportMng(AppContext.ActiveSchema);

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

            ISchemaInfo schema = AppContext.ActiveSchema;
            try
            {
                schema = empresa as ISchemaInfo;
                if (schema == null) schema = AppContext.ActiveSchema;
            }
            catch
            {
            }

            ReportViewer.SetReport(reportMng.GetDetailResumenExamenReport(_examen,
                lista, null,empresa));
            ReportViewer.ShowDialog();
        }

        #endregion

        #region Events

        private void ResumenActionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cerrar();
        }


        #endregion

    }
}

