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
    public partial class PlanDocenteUIForm : PlanDocenteForm
    {

        #region Business Methods

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        protected PlanEstudios _entity;

        public override PlanEstudios Entity { get { return _entity; } set { _entity = value; } }
        public override PlanEstudiosInfo EntityInfo { get { return (_entity != null) ? _entity.GetInfo(true) : null; } }

		/// <summary>
		/// Añade una lista de valores de combobox a la lista de combos
		/// </summary>
		protected override void AddComboList(Type tipo)
		{
			switch (tipo.Name)
			{
				case "ClaseTeorica":
					{
						if (_source_list_t.CombosListCount < Teoricas_Grid.Rows.Count - 1)
						{
                            for (long i = _source_list_t.CombosListCount; i < Teoricas_Grid.Rows.Count - 1; i++)
                            {
                                _source_list_t.AddCombosList(((ClaseTeorica)Teoricas_Grid.Rows[(int)i].DataBoundItem).OidModulo);
                                ((DataGridViewComboBoxCell)(Teoricas_Grid["Submodulo_CBC", (int)i])).DataSource = _source_list_t.GetCombosList((int)i);

                            }
						}
					} break;

				case "ClasePractica":
					{
                        if (_source_list_p.CombosListCount < Practicas_Grid.Rows.Count - 1)
                        {
                            for (long i = _source_list_p.CombosListCount; i < Practicas_Grid.Rows.Count -1; i++)
                            {
                                _source_list_p.AddCombosList(((ClasePractica)Practicas_Grid.Rows[(int)i].DataBoundItem).OidModulo);
                                ((DataGridViewComboBoxCell)(Practicas_Grid["Submodulo_CBC_P", (int)i])).DataSource = _source_list_p.GetCombosList((int)i);
                            }
                        }
					} break;
			}
		}
		
        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar.
        /// </summary>
        protected PlanDocenteUIForm() : this(-1, true) { }

        public PlanDocenteUIForm(bool isModal) : this(-1, isModal) { }

        public PlanDocenteUIForm(long oid) : this(oid, true) { }

        public PlanDocenteUIForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Guarda en la bd el objeto actual
        /// </summary>
        protected override bool SaveObject()
        {
            using (StatusBusy busy = new StatusBusy(moleQule.Face.Resources.Messages.SAVING))
            {

                this.Datos.RaiseListChangedEvents = false;

                PlanEstudios temp = _entity.Clone();
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

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity;
            //if (_entity.OidProducto > 0)
            //    ProductoInstruccion_TB.Text = _productos.GetItem(_entity.OidProducto).Nombre;
            //if (_entity.OidSerie > 0)
            //    SerieInstruccion_TB.Text = _series.GetItem(_entity.OidSerie).Nombre;
            PgMng.Grow();

            Datos_Teoricas.DataSource = _entity.CTeoricas;
            PgMng.Grow();

            Datos_Practicas.DataSource = _entity.CPracticas;
            PgMng.FillUp();
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
								//_source_list_t.AddCombosList(((ClaseTeorica)row.DataBoundItem).OidModulo);
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
								//_source_list_p.AddCombosList(((ClasePractica)row.DataBoundItem).OidModulo);
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

                lista_teoricas = RegistroResumenPlanDocente.ContabilizaClases(EntityInfo.CTeoricas);
                PgMng.Grow();
                lista_practicas = RegistroResumenPlanDocente.ContabilizaClases(EntityInfo.CPracticas);

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

        #region Actions

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SaveAction()
        {
            foreach (ClaseTeorica clase in _entity.CTeoricas)
            {
                if (clase.IsDirty)
                {
                    SubmoduloInfo submodulo = _submodulos.GetItem(clase.OidSubmodulo);
                    if (submodulo.OidModulo != clase.OidModulo)
                        clase.OidModulo = submodulo.OidModulo;
                }

                if (clase.Alias == string.Empty)
                {
                    //if (clase.Titulo.Length > 11) clase.Alias = clase.Titulo.Substring(0, 12).ToUpper();
                    //else 
                    clase.Alias = clase.Titulo.ToUpper();
                }
                /*else
                {
                    if (clase.Alias.Length > 12) clase.Alias = clase.Alias.Substring(0, 12);
                }*/
                clase.Alias = clase.Alias.ToUpper();

                if (clase.Titulo == string.Empty) 
                { 
                    ModuloInfo modulo = _modulos.GetItem(clase.OidModulo);
                    SubmoduloInfo submodulo = _submodulos.GetItem(clase.OidSubmodulo);
                    clase.Titulo = modulo.Texto + " " + submodulo.Codigo;
                }
            }

            foreach (ClasePractica clase in _entity.CPracticas)
            {
                if (clase.IsDirty)
                {
                    SubmoduloInfo submodulo = _submodulos.GetItem(clase.OidSubmodulo);
                    if (submodulo.OidModulo != clase.OidModulo)
                        clase.OidModulo = submodulo.OidModulo;
                }

                if (clase.Alias == string.Empty)
                {
                    //if (clase.Titulo.Length > 11) clase.Alias = clase.Titulo.Substring(0, 12).ToUpper();
                    //else 
                    clase.Alias = clase.Titulo.ToUpper();
                }
                /*else
                {
                    if (clase.Alias.Length > 11) clase.Alias = clase.Alias.Substring(0, 12);
                }*/
                clase.Alias = clase.Alias.ToUpper();

                if (clase.Titulo == string.Empty) 
                { 
                    ModuloInfo modulo = _modulos.GetItem(clase.OidModulo);
                    SubmoduloInfo submodulo = _submodulos.GetItem(clase.OidSubmodulo);
                    clase.Titulo = modulo.Texto + " " + submodulo.Codigo;
                }
            }

            _action_result = SaveObject() ? DialogResult.OK : DialogResult.Ignore;
        }

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

        protected override void MergePlanesAction()
        {
            PlanEstudiosSelectForm form = new PlanEstudiosSelectForm(true, this);

            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                PlanEstudiosInfo info = form.Selected as PlanEstudiosInfo;

                _entity.Merge(info.Oid);
            }
        }

        #endregion

    }
}
