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
    public partial class PlanDocenteViewForm : PlanDocenteForm
    {

        #region Business Methods

        /// <summary>
        /// Se trata del objeto actual.
        /// </summary>
        private PlanEstudiosInfo _entity;

        public override PlanEstudiosInfo EntityInfo { get { return _entity; } }

		/// <summary>
		/// Añade una lista de valores de combobox a la lista de combos
		/// </summary>
		protected override void AddComboList(Type tipo)
		{
			switch (tipo.Name)
			{
				case "ClaseTeorica":
					{
						if (_source_list_t.CombosListCount < Teoricas_Grid.Rows.Count)
						{
							for (long i = _source_list_t.CombosListCount; i < Teoricas_Grid.Rows.Count; i++)
								_source_list_t.AddCombosList(((ClaseTeoricaInfo)Teoricas_Grid.Rows[(int)i].DataBoundItem).OidModulo);
						}
					} break;

				case "ClasePractica":
					{
						if (_source_list_p.CombosListCount < Practicas_Grid.Rows.Count)
						{
							for (long i = _source_list_p.CombosListCount; i < Practicas_Grid.Rows.Count; i++)
								_source_list_p.AddCombosList(((ClasePracticaInfo)Practicas_Grid.Rows[(int)i].DataBoundItem).OidModulo);
						}
					} break;
			}
		}

        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar
        /// </summary>
        private PlanDocenteViewForm() : this(-1) { }

        public PlanDocenteViewForm(long oid)
            : base(oid)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.PLAN_DOCENTE_EDIT_TITLE + " " + EntityInfo.Nombre.ToUpper();
            _mf_type = ManagerFormType.MFView;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = PlanEstudiosInfo.Get(oid, true);
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
            //if (_entity.OidProducto > 0)
            //    ProductoInstruccion_TB.Text = _productos.GetItem(_entity.OidProducto).Nombre;
            //if (_entity.OidSerie > 0)
            //    SerieInstruccion_TB.Text = _series.GetItem(_entity.OidSerie).Nombre;
            PgMng.Grow();

            Datos_Teoricas.DataSource = _entity.CTeoricas;
            PgMng.Grow();

            Datos_Practicas.DataSource = _entity.CPracticas;
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
                case "Teoricas_Grid":
                    {
                        foreach (DataGridViewRow row in Teoricas_Grid.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                //_source_list_t.AddCombosList(((ClaseTeoricaInfo)row.DataBoundItem).OidModulo);
                                //(DataGridViewComboBoxCell)(row.Cells["Modulo_CBC"]).Value = 
                                ((DataGridViewComboBoxCell)(row.Cells["Submodulo_CBC"])).DataSource = _source_list_t.GetCombosList(row.Index);
                            }
                        }
                    } break;

                case "Practicas_Grid":
                    {
                        foreach (DataGridViewRow row in Practicas_Grid.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                //_source_list_p.AddCombosList(((ClasePracticaInfo)row.DataBoundItem).OidModulo);
                                ((DataGridViewComboBoxCell)(row.Cells["Submodulo_CBC_P"])).DataSource = _source_list_p.GetCombosList(row.Index);
                            }
                        }
                    } break;
            }
        }

        protected override void ResumenAction()
        {
            if (_entity == null) return;
            List<RegistroResumenPlanDocente> lista_teoricas = null;
            List<RegistroResumenPlanDocente> lista_practicas = null;

            PgMng.Reset(2, 1, Resources.Messages.LOADING_DATA, this);
            try
            {

                lista_teoricas = RegistroResumenPlanDocente.ContabilizaClasesTeoricas(_entity.Oid);
                PgMng.Grow();
                lista_practicas = RegistroResumenPlanDocente.ContabilizaClasesPracticas(_entity.Oid);

            }
            finally
            {
                PgMng.FillUp();
            }

            ResumenPlanDocenteForm form = new ResumenPlanDocenteForm(true, lista_teoricas, lista_practicas, this);
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
            switch (Clases_TC.SelectedTab.Name)
            {
                case "Teoricas_TP":
                    {
                        if (_entity.CTeoricas != null && _entity.CTeoricas.Count > 0)
                        {
                            CronogramaReportMng reportMng = new CronogramaReportMng(AppContext.ActiveSchema);
                            ReportViewer.SetReport(reportMng.GetDetailReport(_entity.CTeoricas));
                            ReportViewer.ShowDialog();
                        }
                    }
                    break;
                case "Practicas_TP":
                    {
                        if (_entity.CPracticas != null && _entity.CPracticas.Count > 0)
                        {
                            CronogramaReportMng reportMng = new CronogramaReportMng(AppContext.ActiveSchema);
                            ReportViewer.SetReport(reportMng.GetDetailReport(_entity.CPracticas));
                            ReportViewer.ShowDialog();
                        }
                    }
                    break;
            }
        }

        #endregion

        #region Events

        #endregion
    }

}
