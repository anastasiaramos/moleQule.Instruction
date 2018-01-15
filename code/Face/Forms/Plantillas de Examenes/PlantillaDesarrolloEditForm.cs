using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin01;

using moleQule.Library.Common;
using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class PlantillaDesarrolloEditForm : ItemMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 3; } }

        public ModuloList _modulos;

        protected PlantillaExamen _entity;
        private long _propuesto = 0;

        public PlantillaExamen Entity { get { return _entity; } set { _entity = value; } }
        public PlantillaExamenInfo EntityInfo { get { return (_entity != null) ? _entity.GetInfo(false) : null; } }

        #endregion

        #region Factory Methods

        public PlantillaDesarrolloEditForm(long oid) : this(oid, true) {}
        
        public PlantillaDesarrolloEditForm(long oid, bool isModal)
            : base(oid, isModal)
        {
            InitializeComponent();

            if (Entity != null)
            {
                SetFormData();
                this.Text = Resources.Labels.PLANTILLA_EXAMEN_EDIT_TITLE;
            }

            _mf_type = ManagerFormType.MFEdit;
        }

        public PlantillaDesarrolloEditForm(PlantillaExamen source)
            : base()
        {
            InitializeComponent();

            _entity = source.Clone();
            _entity.BeginEdit();
            SetFormData();
            _mf_type = ManagerFormType.MFEdit;
            this.Text = Resources.Labels.PLANTILLA_EXAMEN_EDIT_TITLE;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = PlantillaExamen.Get(oid, false);
            _entity.BeginEdit();
        }

        /// <summary>
        /// Guarda en la bd el objeto actual
        /// </summary>
        protected override bool SaveObject()
        {
            using (StatusBusy busy = new StatusBusy(moleQule.Face.Resources.Messages.SAVING))
            {

                this.Datos.RaiseListChangedEvents = false;

                PlantillaExamen temp = _entity.Clone();
                temp.ApplyEdit();

                // do the save
                try
                {
                    _entity = temp.Save();
                    _entity.ApplyEdit();


                    //Decomentar si se va a mantener en memoria
                    //_entity.BeginEdit();
                    return true;
                }
                catch (iQValidationException ex)
                {
                    MessageBox.Show(iQExceptionHandler.GetAllMessages(ex) +
                                    Environment.NewLine + ex.SysMessage,
                                    moleQule.Library.Application.AppController.APP_TITLE,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    return false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(iQExceptionHandler.GetAllMessages(ex),
                                    moleQule.Library.Application.AppController.APP_TITLE,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    return false;
                }
                finally
                {
                    this.Datos.RaiseListChangedEvents = true;
                }
            }

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

        public override void RefreshSecondaryData()
        {
            //Library.Instruction.HComboBoxSourceList _combo_idiomas = new Library.Instruction.HComboBoxSourceList();
            //_combo_idiomas.Add(new ComboBoxSource(0, ""));
            //_combo_idiomas.Add(new ComboBoxSource(1, "Español"));
            //_combo_idiomas.Add(new ComboBoxSource(2, "Inglés"));
            Datos_Idiomas.DataSource = Library.Common.EnumText<EIdioma>.GetList(false);
            PgMng.Grow(string.Empty, "Idiomas");
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            _entity.Idioma = Library.Common.EnumText<EIdioma>.GetLabel(EIdioma.Todos);
            Datos.DataSource = _entity;
            PgMng.Grow();
        }


        #endregion

        #region Validation & Format

        #endregion

        #region Print

        protected override void PrintAction()
        {

            SelectFechaDisponibilidadForm select_form = new SelectFechaDisponibilidadForm();
            if (select_form.ShowDialog() == DialogResult.OK)
            {
                InformePlantillaList List = InformePlantillaList.GetDisponiblesDesarrolloList(EntityInfo.Oid, select_form.FechaDisponibilidad_DTP.Value.Date);

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

                    moleQule.Library.Instruction.Reports.Examen.InformeDisponiblesPlantillaDesarrolloRpt report = reportMng.GetInformeDisponiblesPlantillaDesarrolloReport(EntityInfo, List);
                    report.SetParameterValue("Empresa", empresa.Name);
                    report.SetParameterValue("FechaDisponibilidad", select_form.FechaDisponibilidad_DTP.Value.Date);
                    if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(report.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);
                    ReportViewer.SetReport(report);
                    ReportViewer.ShowDialog();
                }
            }
        }

        #endregion

        #region Actions

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SaveAction()
        {
            _action_result = SaveObject() ? DialogResult.OK : DialogResult.Ignore;
        }

        protected override void CancelAction()
        {
            _entity.CancelEdit();
            _entity.CloseSession();
            Close();
        }

        #endregion

        #region Events
                
        #endregion

    }
}


