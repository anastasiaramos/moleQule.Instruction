using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Csla;

using moleQule.Face;
using moleQule.Face.Hipatia;
using moleQule.Face.Common;
using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.CslaEx; 
using moleQule.Library.Instruction;
using moleQule.Library.Hipatia;

namespace moleQule.Face.Instruction
{
    public partial class DiasNoLectivosForm : moleQule.Face.Skin01.ItemMngSkinForm
    {
        #region Attributes & Properties

        public const string ID = "DiasNoLectivosForm";
        public static Type Type { get { return typeof(DiasNoLectivosForm); } }
        public override Type EntityType { get { return typeof(Festivo); } }
        
        protected override int BarSteps { get { return base.BarSteps + 3; } }

        public virtual Festivo Entity { get { return null; } set { } }
        public virtual FestivoInfo EntityInfo { get { return null; } }

        public SortedBindingList<FestivoInfo> List = null;

        public long ActiveOID { get { return (ActiveItem != null) ? ActiveItem.Oid : -1; } }
        public FestivoInfo ActiveItem { get { return (Festivos_DGW.CurrentRow == null) ? null : ((Festivos_DGW.CurrentRow.DataBoundItem != null) ? (FestivoInfo)Festivos_DGW.CurrentRow.DataBoundItem : null); } }

        #endregion

        #region Factory Methods

        public DiasNoLectivosForm()
			: this(null) { }

        public DiasNoLectivosForm(Form parent) 
			: this(-1, parent) { }

        public DiasNoLectivosForm(long oid, Form parent)
            : base(oid, new object[1]{null}, true, parent) 
        {
            InitializeComponent();
            SetFormData();
        }

        public DiasNoLectivosForm(long oid, FestivoList festivos, Form parent)
            : base(oid, new object[1] {festivos}, true, parent)
        {
            InitializeComponent();
            SetFormData();
        }

        protected override void GetFormSourceData(object[] parameters)
        {
            if (parameters[0] != null)
                List = (SortedBindingList<FestivoInfo>)parameters[0];
        }

        #endregion

        #region Authorization
        
        #endregion

        #region Layout

        public override void FormatControls()
        {
            Cancel_BT.Enabled = false;
            Cancel_BT.Visible = false;

            base.FormatControls();
        }

		public override void FitColumns()
		{
			CurrencyManager cm;
			List<DataGridViewColumn> cols = new List<DataGridViewColumn>();

			cm = (CurrencyManager)BindingContext[Festivos_DGW.DataSource];
			cm.SuspendBinding();

            Titulo.Tag = 0.5;
            Descripcion.Tag = 0.5;

			cols.Add(Titulo);
            cols.Add(Descripcion);

            ControlsMng.MaximizeColumns(Festivos_DGW, cols);
		}

		protected override void SetView(molView view)
		{
			base.SetView(view);

			switch (_view_mode)
			{
				case molView.Select:
				case molView.Normal:
				case molView.Enbebbed:

					ShowAction(molAction.CustomAction1);
					HideAction(molAction.CustomAction2);
					HideAction(molAction.CustomAction3);
					HideAction(molAction.CustomAction4);
					HideAction(molAction.ShowDocuments);
					break;
			}
		}

        #endregion

		#region Source

        protected override void RefreshMainData()
        {
            List = FestivoList.GetList(FInicio_DTP.Value, FFin_DTP.Value);

            Datos.DataSource = List;
            PgMng.Grow();
            
            DateTime[] bolded = FestivoList.GetBoldedList(List);
            Calendario_MC.BoldedDates = bolded;

            base.RefreshMainData();
        }

		#endregion

		#region Print

		public override void PrintObject()
        {
            CronogramaReportMng reportMng = new CronogramaReportMng(AppContext.ActiveSchema);
            ReportViewer.SetReport(reportMng.GetCalendarioFestivos(List, FInicio_DTP.Value, FFin_DTP.Value));
            ReportViewer.ShowDialog();
        }

        protected override void SaveAction() { Close(); }
       
        protected override void PrintAction()
        {
            PrintObject();
        }

        #endregion

        #region Actions

        #endregion

        #region Buttons

        private void FestivoAdd_BT_Click(object sender, EventArgs e)
        {
            FestivoAddForm form = new FestivoAddForm(this);
            form.ShowDialog();

            if (form.ActionResult == DialogResult.OK)
                RefreshMainData();
        }

        private void EditFestivo_BT_Click(object sender, EventArgs e)
        {
            if (Festivos_DGW.CurrentRow != null)
            {
                FestivoEditForm form = new FestivoEditForm(ActiveOID, this);
                form.ShowDialog();

                if (form.ActionResult == DialogResult.OK)
                    RefreshMainData();
            }
        }

        private void DeleteFestivo_BT_Click(object sender, EventArgs e)
        {
            if (Festivos_DGW.CurrentRow != null)
            {
                Festivo.Delete(ActiveOID);
                RefreshMainData();
            }
        }

        #endregion

        #region Events

        private void FInicio_DTP_ValueChanged(object sender, EventArgs e)
        {
            RefreshMainData();
        }

        private void FFin_DTP_ValueChanged(object sender, EventArgs e)
        {
            RefreshMainData();
        }

        #endregion

    }
}
