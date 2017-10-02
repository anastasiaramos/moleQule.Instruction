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
    public partial class PlanExtraViewForm : PlanExtraForm
    {
        
        #region Business Methods

        /// <summary>
        /// Se trata del objeto actual.
        /// </summary>
        private PlanExtraInfo _entity;

        public override PlanExtraInfo EntityInfo { get { return _entity; } }

		/// <summary>
		/// Añade una lista de valores de combobox a la lista de combos
		/// </summary>
		protected override void AddComboList()
		{
			if (_source_list.CombosListCount < Clases_Grid.Rows.Count)
			{
				for (long i = _source_list.CombosListCount; i < Clases_Grid.Rows.Count; i++)
					_source_list.AddCombosList(((ClaseExtraInfo)Clases_Grid.Rows[(int)i].DataBoundItem).OidModulo);
			}
					
		}

        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar
        /// </summary>
        private PlanExtraViewForm() : this(-1) { }

        public PlanExtraViewForm(long oid)
            : base(oid)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.PLAN_EXTRA_EDIT_TITLE + " " + EntityInfo.Nombre.ToUpper();
            _mf_type = ManagerFormType.MFView;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = PlanExtraInfo.Get(oid, true);
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
            Resumen_BT.Enabled = true;
            base.FormatControls();
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            //_timer.Record("RefreshMainData begin");

            Datos.DataSource = _entity;
            if (_entity.OidProducto > 0)
                ProductoInstruccion_TB.Text = _productos.GetItem(_entity.OidProducto).Nombre;
            if (_entity.OidSerie > 0)
                SerieInstruccion_TB.Text = _series.GetItem(_entity.OidSerie).Nombre;
            PgMng.Grow();

            Datos_Clases.DataSource = _entity.CExtras;
            PgMng.Grow();

            base.RefreshMainData();
            PgMng.FillUp();
            //_timer.Record("RefreshMainData end");
        }

        /// <summary>
        /// Asigna los valores del grid que no están asociados a propiedades
        /// </summary>
        protected override void SetUnlinkedGridValues(string gridName)
        {
            switch (gridName)
            {
                case "Clases_Grid":
                    {
                        foreach (DataGridViewRow row in Clases_Grid.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                _source_list.AddCombosList(((ClaseExtraInfo)row.DataBoundItem).OidModulo);
                                ((DataGridViewComboBoxCell)(row.Cells["Submodulo_CBC"])).DataSource = _source_list.GetCombosList(row.Index);
                            }
                        }
                    } break;
            }
        }

        protected override void ResumenAction()
        {
            if (_entity == null) return;
            List<RegistroResumenPlanDocente> lista_extras = null;

            PgMng.Reset(1, 1, Resources.Messages.LOADING_DATA, this);
            try
            {

                lista_extras = RegistroResumenPlanDocente.ContabilizaClasesExtra(_entity.Oid);

            }
            finally
            {
                PgMng.FillUp();
            }

            ResumenPlanExtraForm form = new ResumenPlanExtraForm(true, lista_extras, this);
            form.ShowDialog();
        }


        #endregion

        #region Validation & Format

        #endregion

        #region Print

        #endregion

        #region Actions

        protected override void SaveAction() { _action_result = DialogResult.Cancel; }
        
        protected override void PrintAction()
        {
            if (_entity.CExtras != null && _entity.CExtras.Count > 0)
            {
                CronogramaReportMng reportMng = new CronogramaReportMng(AppContext.ActiveSchema);
                ReportViewer.SetReport(reportMng.GetDetailReport(_entity.CExtras));
                ReportViewer.ShowDialog();
            }

        }

        #endregion

        #region Events

        #endregion
    }

}
