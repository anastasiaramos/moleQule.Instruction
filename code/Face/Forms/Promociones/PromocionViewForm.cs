using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;
using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class PromocionViewForm : PromocionForm
    {

        #region Business Methods

        /// <summary>
        /// Se trata del objeto actual.
        /// </summary>
        private PromocionInfo _entity;

        public override PromocionInfo EntityInfo { get { return _entity; } }



        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar
        /// </summary>
        private PromocionViewForm() : this(-1) { }

        public PromocionViewForm(long oid)
            : base(oid)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.PROMOCION_EDIT_TITLE + " " + EntityInfo.Nombre.ToUpper();
            _mf_type = ManagerFormType.MFView;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = PromocionInfo.Get(oid, true);
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
            Clases_BT.Enabled = true;
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

            Datos_Sesiones.DataSource = _entity.Sesiones;

            base.RefreshMainData();
            PgMng.FillUp();
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

        #endregion

        #region Events

        #endregion
    }

}
