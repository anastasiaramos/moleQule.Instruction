using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Face;

using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class AlumnoViewForm : AlumnoForm
    {

        #region Business Methods

        /// <summary>
        /// Se trata del objeto actual.
        /// </summary>
        private AlumnoInfo _entity;

        public override AlumnoInfo EntityInfo { get { return _entity; } }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar
        /// </summary>
        private AlumnoViewForm() : this(-1) { }

        public AlumnoViewForm(long oid)
            : base(oid)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.ALUMNO_EDIT_TITLE + " " + EntityInfo.Nombre.ToUpper();
            _mf_type = ManagerFormType.MFView;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = AlumnoInfo.GetForForm(oid, true);
            _mf_type = ManagerFormType.MFView;
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
            PrintCertificado_BT.Enabled = true;
            base.FormatControls();
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity;
            PgMng.Grow();

            Datos_Alumno_Examen.DataSource = _entity.AlumnoExamens;
            PgMng.Grow();

            Datos_Alumno_Practica.DataSource = _entity.AlumnosPracticas;
            PgMng.Grow();

            Datos_Alumnos_Promociones.DataSource = _entity.Promociones;

            FCriteria<bool> criteria = new FCriteria<bool>("Falta", true);
            Datos_Alumno_Parte.DataSource = _entity.AlumnoPartes.GetSubList(criteria);

            base.RefreshMainData();
            PgMng.FillUp();
        }

        /// <summary>
        /// Asigna los datos de origen para controles que dependen de otros
        /// </summary>
        /// <param name="controlName"></param>
        protected override void SetDependentControlSource(string controlName)
        {
            switch (controlName)
            {
                case "ID_GB":
                    {
                        NIF_RB.Checked = (EntityInfo.TipoId == (long)TipoId.NIF);
                        NIE_RB.Checked = (EntityInfo.TipoId == (long)TipoId.NIE);
                        DNI_RB.Checked = (EntityInfo.TipoId == (long)TipoId.DNI);

                    } break;
                case "Grupo_GB":
                    {
                        G0_RB.Checked = (EntityInfo.Grupo == (long)moleQule.Library.Instruction.Grupo.SinGrupo);
                        GA_RB.Checked = (EntityInfo.Grupo == (long)moleQule.Library.Instruction.Grupo.A);
                        GB_RB.Checked = (EntityInfo.Grupo == (long)moleQule.Library.Instruction.Grupo.B);
                    } break;
            }
        }


        protected override void SetUnlinkedGridValues(string gridName)
        {
            switch (gridName)
            {
                case "Examenes_Grid":
                    {
                        ExamenList examenes = ExamenList.GetList(false);
                        foreach (DataGridViewRow row in Examenes_Grid.Rows)
                        {
                            if (row.IsNewRow) continue;
                            Alumno_ExamenInfo info = (Alumno_ExamenInfo)row.DataBoundItem;
                            if (info != null)
                            {
                                ExamenInfo examen = examenes.GetItem(info.OidExamen);
                                if (examen != null)
                                {
                                    row.Cells["Examen"].Value = examen.Titulo;
                                    if (info.Presentado)
                                    {
                                        if (examen.Desarrollo)
                                        {
                                            string calif = string.Empty;
                                            if (info.Respuestas == null)
                                                info = Alumno_ExamenInfo.Get(info.Oid, true);
                                            foreach (Respuesta_Alumno_ExamenInfo item in info.Respuestas)
                                            {
                                                if (calif != string.Empty)
                                                    calif += " - ";
                                                calif += item.Calificacion.ToString() + "%";
                                            }
                                            row.Cells["Calificacion"].Value = calif;
                                        }
                                        else
                                            row.Cells["Calificacion"].Value = info.Calificacion.ToString();
                                    }
                                    else
                                        row.Cells["Calificacion"].Value = "NP";
                                }
                            }
                        }

                    } break;
                case "Practicas_Grid":
                    {
                        //ClasePracticaList practicas = ClasePracticaList.GetList();
                        foreach (DataGridViewRow row in Practicas_Grid.Rows)
                        {
                            if (row.IsNewRow) continue;
                            Alumno_PracticaInfo info = (Alumno_PracticaInfo)row.DataBoundItem;
                            if (info != null)
                            {
                                if (info.Calificacion == Resources.Labels.NO_APTO_LABEL)
                                {
                                    if (info.Falta)
                                        row.DefaultCellStyle = FaltaStyle;
                                    else
                                        row.DefaultCellStyle = NoAptaStyle;
                                }
                                else
                                {
                                    if (info.Calificacion == Resources.Labels.FALTA_ASISTENCIA_LABEL)
                                        row.DefaultCellStyle = FaltaStyle;
                                    else
                                    {
                                        if (info.Calificacion == Resources.Labels.APTO_LABEL)
                                            row.DefaultCellStyle = AptaStyle;
                                    }
                                }
                            }
                            if (info.Recuperada)
                                row.DefaultCellStyle = AptaStyle;
                        }

                    } break;
                case "Faltas_Grid":
                    {
                        ParteAsistenciaList partes = ParteAsistenciaList.GetList(false);
                        foreach (DataGridViewRow row in Faltas_Grid.Rows)
                        {
                            if (row.IsNewRow) continue;
                            Alumno_ParteInfo info = (Alumno_ParteInfo)row.DataBoundItem;
                            if (info != null)
                            {
                                ParteAsistenciaInfo item = partes.GetItem(info.OidParte);
                                if (item != null)
                                {
                                    row.Cells["Clase"].Value = item.Texto;
                                    row.Cells["Fecha"].Value = item.Fecha;
                                    row.Cells["Hora"].Value = item.HoraInicio;
                                }

                            }
                        }
                    }
                    break;
            }
        }

        #endregion

        #region Validation & Format


        #endregion

        #region Print

        //public override void PrintData(long entidad, PrintSource source, PrintType type)
        //{
        //    switch (entidad)
        //    {
        //        case Entidad.Historia:
        //            {
        //                ClienteReportMng rptMng = new ClienteReportMng(AppContext.ActiveSchema);
        //                List<HistoriaInfo> list = new List<HistoriaInfo>();

        //                switch (source)
        //                {
        //                    case PrintSource.All:
        //                        {
        //                            foreach (DataGridViewRow row in Historias_Grid.Rows)
        //                                list.Add((HistoriaInfo)(row.DataBoundItem));

        //                        } break;

        //                    case PrintSource.Selection:
        //                        {
        //                            foreach (DataGridViewRow row in Historias_Grid.SelectedRows)
        //                                list.Add((HistoriaInfo)(row.DataBoundItem));

        //                        } break;
        //                }

        //                if (list.Count == 0) return;

        //                ReportViewer.SetReport(rptMng.GetHistoriaListReport(EntityInfo,
        //                                                                HistoriaList.GetChildList(list)));

        //            } break;
        //    }

        //    ReportViewer.ShowDialog();
        //}


        #endregion

        #region Actions

        protected override void SaveAction() { _action_result = DialogResult.Cancel; }

        #endregion

        #region Buttons

        private void PrintCertificado_BT_Click(object sender, EventArgs e)
        {
            AlumnoReportMng reportMng = new AlumnoReportMng(AppContext.ActiveSchema);

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

            Library.Instruction.Reports.Alumno.CertificadoNotasRpt rpt = reportMng.GetDetailReport(_entity, empresa);
            rpt.SetParameterValue("Empresa", empresa.Name);
            if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(rpt.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);
            ReportViewer.SetReport(rpt);
            ReportViewer.ShowDialog();
        }

        #endregion

        #region Events

        #endregion
    }

}
