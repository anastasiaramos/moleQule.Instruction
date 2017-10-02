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
    public partial class PlanExtraUIForm : PlanExtraForm
    {
        #region Business Methods

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        protected PlanExtra _entity;

        public override PlanExtra Entity { get { return _entity; } set { _entity = value; } }
        public override PlanExtraInfo EntityInfo { get { return (_entity != null) ? _entity.GetInfo(false) : null; } }

        /// <summary>
        /// Añade una lista de valores de combobox a la lista de combos
        /// </summary>
        protected override void AddComboList()
        {
            if (_source_list.CombosListCount < Clases_Grid.Rows.Count - 1)
            {
                for (long i = _source_list.CombosListCount; i < Clases_Grid.Rows.Count - 1; i++)
                {
                    _source_list.AddCombosList(((ClaseExtra)Clases_Grid.Rows[(int)i].DataBoundItem).OidModulo);
                    ((DataGridViewComboBoxCell)(Clases_Grid["Submodulo_CBC", (int)i])).DataSource = _source_list.GetCombosList((int)i);

                }
            }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar.
        /// </summary>
        protected PlanExtraUIForm() : this(-1, true) { }

        public PlanExtraUIForm(bool isModal) : this(-1, isModal) { }

        public PlanExtraUIForm(long oid) : this(oid, true) { }

        public PlanExtraUIForm(long oid, bool ismodal)
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

                PlanExtra temp = _entity.Clone();
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
            if (_entity.OidProducto > 0)
                ProductoInstruccion_TB.Text = _productos.GetItem(_entity.OidProducto).Nombre;
            if (_entity.OidSerie > 0)
                SerieInstruccion_TB.Text = _series.GetItem(_entity.OidSerie).Nombre;
            PgMng.Grow();

            Datos_Clases.DataSource = _entity.CExtras;
            PgMng.FillUp();
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
                                //_source_list_t.AddCombosList(((ClaseTeorica)row.DataBoundItem).OidModulo);
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

                lista_extras = RegistroResumenPlanDocente.ContabilizaClases(EntityInfo.CExtras);

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

        #region Buttons

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SaveAction()
        {
            foreach (ClaseExtra clase in _entity.CExtras)
            {
                if (clase.IsDirty)
                {
                    SubmoduloInfo submodulo = _submodulos.GetItem(clase.OidSubmodulo);
                    if (submodulo.OidModulo != clase.OidModulo)
                        clase.OidModulo = submodulo.OidModulo;
                }

                if (clase.Alias == string.Empty)
                {
                    if (clase.Titulo.Length > 11) clase.Alias = clase.Titulo.Substring(0, 12).ToUpper();
                    else clase.Alias = clase.Titulo.ToUpper();
                }
                else
                {
                    if (clase.Alias.Length > 12) clase.Alias = clase.Alias.Substring(0, 12);
                }
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

        #endregion

        #region Actions

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

    }
}
