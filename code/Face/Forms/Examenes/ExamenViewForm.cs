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
    public partial class ExamenViewForm : ExamenForm
    {
        #region Business Methods

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        protected ExamenInfo _entity;

        public override ExamenInfo EntityInfo { get { return _entity; } }

        #endregion

        #region Factory Methods

        public ExamenViewForm(long oid)
            : this(oid, true) { }

        public ExamenViewForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();

            if (EntityInfo != null)
            {
                SetFormData();
                this.Text = Resources.Labels.EXAMEN_EDIT_TITLE + " " + EntityInfo.Titulo.ToUpper();
            }

            _mf_type = ManagerFormType.MFView;
        }

        protected override void GetFormSourceData(long oid)
        {
            Examen examen = Examen.Get(oid, true);

            string[] preguntas = examen.MemoPreguntas.Split(';');

            //se genera la lista de preguntas del examen con la que se va a trabajar
            foreach (string item in preguntas)
            {
                try
                {
                    long oid_pregunta = Convert.ToInt32(item);
                    Pregunta_Examen p_examen = Pregunta_Examen.NewChild(examen);
                    p_examen.OidPregunta = oid_pregunta;
                    examen.Pregunta_Examens.AddItem(p_examen);
                }
                catch
                {
                    continue;
                }
            }

            _entity = examen.GetInfo(true);
            examen.CloseSession();
            _mf_type = ManagerFormType.MFView;
        }


        protected override void SetUnlinkedGridValues(string gridName)
        {
            switch (gridName)
            {
                case "Preguntas_Grid":
                    {
                        if (_entity == null) return;
                        long orden = 1;

                        foreach (DataGridViewRow row in Preguntas_Grid.Rows)
                        {
                            row.Cells[N_Orden.Name].Value = orden.ToString();
                            orden++;

                            Datos.MoveNext();
                        }

                    } break;
            }
        }

        #endregion

        #region Style & Source


        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            SetReadOnlyControls(this.Controls);
            Cancel_BT.Enabled = false;
            Cancel_BT.Visible = false;
            base.FormatControls();
            toolStrip1.Enabled = true;
            Preguntas_BT.Enabled = false;
            Proponer_BT.Enabled = false;
            Quitar_BT.Enabled = false;
            Resumen_BT.Enabled = false;
            Print_BT.Enabled = false;
            Alumnos_BT.Enabled = false;
            Emitir_BT.Enabled = false;
        }

        public override void RefreshSecondaryData()
        {
            PgMng.Grow();

            Preguntas_TB.Text = _entity.PreguntaExamenes.Count.ToString();
            PgMng.Grow();

            Desarrollo_CB.Checked = _entity.Desarrollo;
            PgMng.Grow();

            if (EntityInfo != null && EntityInfo.OidModulo != 0)
            {
                _modulo = ModuloInfo.Get(EntityInfo.OidModulo, false);
                PgMng.Grow(string.Empty, "_modulo");

                _preguntas_modulo = PreguntaList.GetPreguntasModulo(_modulo.Oid);
                PgMng.Grow(string.Empty, "_preguntas");

                _temas = TemaList.GetModuloList(_modulo.Oid, false);
                PgMng.Grow(string.Empty, "_temas");

                _submodulos = SubmoduloList.GetModuloList(_modulo.Oid, false);
                PgMng.Grow(string.Empty, "_submodulos");

                RellenaPreguntas();
            }
            PgMng.Grow();

            base.RefreshSecondaryData();
            PgMng.Grow();
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity;
            Duracion_MTB.Text = _entity.Duracion.TimeOfDay.ToString();

            promociones = PromocionList.GetList(false);
            foreach (PromocionInfo info in promociones)
                _promociones_todas.Add(info.Numero + " - " + info.Nombre, info);

            RellenaPromociones();
        }

        protected override void RellenaPreguntas()
        {
            PreguntaList _preguntas_examen = null;

            string memo = string.Empty;

            foreach (Pregunta_ExamenInfo item in _entity.Preguntas)
            {
                if (memo != string.Empty) memo += ",";
                memo += item.OidPregunta.ToString();
            }

            if (memo != string.Empty)
            {
                _preguntas_examen = PreguntaList.GetPreguntasByList(memo);

                string inactivas = string.Empty;

                foreach (PreguntaInfo item in _preguntas_examen)
                {
                    if (!item.Activa)
                        inactivas += item.Serial.ToString() + ", ";
                }

                if (inactivas != string.Empty)
                {
                    inactivas = inactivas.Substring(0, inactivas.Length - 2);
                    MessageBox.Show(string.Format(Resources.Messages.PREGUNTAS_INACTIVAS, inactivas),
                                                moleQule.Library.Application.AppController.APP_TITLE,
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Exclamation);
                }
            }

            Datos_Preguntas.DataSource = _preguntas_examen;

            Preguntas_TB.Text = Datos_Preguntas.Count.ToString();
        }

        #endregion

        #region Actions

        protected override void SaveAction() { _action_result = DialogResult.Cancel; }

        protected override void ResumenAction()
        {
            ResumenActionForm form = new ResumenActionForm();
            string memo = string.Empty;
            if (_entity.MemoPreguntas != string.Empty) memo = _entity.MemoPreguntas.Substring(0, _entity.MemoPreguntas.Length - 1);
            PreguntaList preguntas = PreguntaList.GetPreguntasByList(memo);
            form.SetSourceData(EntityInfo, _modulo, preguntas);
            form.ShowDialog();
        }

        protected override void ResumenPreguntasAction()
        {
            if (_entity.MemoPreguntas == string.Empty) return;

            ExamenReportMng reportMng = new ExamenReportMng(AppContext.ActiveSchema);

            string lista = _entity.MemoPreguntas.Replace(';', ',');
            lista = lista.Substring(0, lista.Length - 1);
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

            ReportViewer.SetReport(reportMng.GetDetailResumenExamenReport(EntityInfo, 
                                        PreguntaList.GetListaExamen(lista), 
                                        null, 
                                        empresa));
            ReportViewer.ShowDialog();
        }

        protected override void RellenaPromociones()
        {
            if (_entity.Promociones == null) return;

            _promociones_select = new Dictionary<string, PromocionInfo>();

            foreach (ExamenPromocionInfo item in _entity.Promociones)
            {
                PromocionInfo info = promociones.GetItem(item.OidPromocion);
                if (info != null)
                    _promociones_select.Add(info.Numero + " - " + info.Nombre, info);
            }

            Promociones_CLB.Items.Clear();

            foreach (KeyValuePair<string, PromocionInfo> item in _promociones_select)
                Promociones_CLB.Items.Add(item.Key, true);
        }

        #endregion

        #region Events

        protected override void CellContentClick(int column, int row)
        {
            switch (Preguntas_Grid.Columns[column].Name)
            {
                case "Ver_BT":
                    {
                        string memo = _entity.MemoPreguntas;

                        if (memo != string.Empty) memo = memo.Substring(0, memo.Length - 1);
                        memo = memo.Replace(';', ',');

                        PreguntaList preguntas = PreguntaList.GetPreguntasByList(memo);

                        PreguntaInfo info = (PreguntaInfo)Preguntas_Grid.Rows[row].DataBoundItem;
                        PreguntasViewForm form = new PreguntasViewForm(info.Oid, preguntas, true);
                        form.ShowDialog();
                    }
                    break;
            }
        }

        #endregion
    }
}

