using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
    public partial class FestivoForm : moleQule.Face.Skin04.ItemMngSkinForm
    {
        #region Attributes & Properties

        public override Type EntityType { get { return typeof(Festivo); } }

        protected override int BarSteps { get { return base.BarSteps + 3; } }

        public virtual Festivo Entity { get { return null; } set { } }
        public virtual FestivoInfo EntityInfo { get { return null; } }

        #endregion

        #region Factory Methods

        public FestivoForm()
			: this(null) { }

        public FestivoForm(Form parent) 
			: this(-1, parent) { }

        public FestivoForm(long oid, Form parent)
            : base(oid, new object[1]{null}, true, parent) 
        {
            InitializeComponent();
        }

        public FestivoForm(long oid, Festivo festivo, Form parent)
            : base(oid, new object[1] {festivo}, true, parent)
        {
            InitializeComponent();
        }

        #endregion

        #region Authorization
        
        #endregion

        #region Layout
        
		protected override void SetView(molView view)
		{
			base.SetView(view);

			switch (_view_mode)
			{
				case molView.Select:
				case molView.Normal:
				case molView.Enbebbed:

					HideAction(molAction.CustomAction1);
					HideAction(molAction.CustomAction2);
					HideAction(molAction.CustomAction3);
					HideAction(molAction.CustomAction4);
					HideAction(molAction.ShowDocuments);
                    HideAction(molAction.Print);
					break;
			}
		}

        #endregion

		#region Source
        
		#endregion

		#region Print

		public override void PrintObject()
        {
            //ReportMng reportMng = new ReportMng(AppContext.ActiveSchema);
            //ReportViewer.SetReport(reportMng.GetClienteReport(EntityInfo));
            //ReportViewer.ShowDialog();
        }

        #endregion

        #region Actions

        protected virtual void SelectTipoAction() { throw new iQImplementationException("SelectTipo"); }
        
        #endregion

        #region Buttons

        private void Tipo_BT_Click(object sender, EventArgs e)
        {
            SelectTipoAction();
        }

        #endregion

        #region Events

        private void Intervalo_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (Intervalo_CB.Checked)
                FFin_DTP.Enabled = true;
            else
            {
                FFin_DTP.Enabled = false;
                FFin_DTP.Value = FInicio_DTP.Value;
            }
        }

        private void FInicio_DTP_ValueChanged(object sender, EventArgs e)
        {
            if (!Intervalo_CB.Checked)
                FFin_DTP.Value = FInicio_DTP.Value;
        }

        #endregion

    }
}
