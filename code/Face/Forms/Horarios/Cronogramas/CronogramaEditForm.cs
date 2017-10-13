using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using moleQule.Library.Instruction; 

using moleQule.Face;

using moleQule.Library.CslaEx;

using moleQule.Library;

namespace moleQule.Face.Instruction
{
    public partial class CronogramaEditForm : CronogramaForm
    {
        #region Business Methods

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        protected Cronograma _entity;

        public override Cronograma Entity { get { return _entity; } }
        public override CronogramaInfo EntityInfo { get { return (_entity != null) ? _entity.GetInfo(false) : null; } }


        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar.
        /// </summary>
        protected CronogramaEditForm() : this(-1, true) { }

        public CronogramaEditForm(bool isModal) : this(-1, isModal) { }

        public CronogramaEditForm(long oid)
            : this(oid, true) { }

        public CronogramaEditForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.CRONOGRAMA_EDIT_TITLE;
            _mf_type = ManagerFormType.MFView;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = Cronograma.Get(oid);
            _mf_type = ManagerFormType.MFView;
        }

        /// <summary>
        /// Guarda en la bd el objeto actual
        /// </summary>
        protected override bool SaveObject()
        {
            using (StatusBusy busy = new StatusBusy(moleQule.Face.Resources.Messages.SAVING))
            {
                this.Datos.RaiseListChangedEvents = false;

                Cronograma temp = _entity.Clone();
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
            Imprimir_Button.Enabled = false;
            Imprimir_Button.Visible = false;
            
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity;
            PgMng.Grow(string.Empty, "Datos");

            Datos_Sesiones.DataSource = _entity.Sesiones;
            PgMng.Grow(string.Empty, "Datos_Sesiones");
            //PgMng.ShowCronos();

            base.RefreshMainData();
            PgMng.FillUp();
        }

        public override void RefreshSecondaryData()
        {
            Plan_TB.Text = PlanEstudiosInfo.Get(_entity.OidPlan).Nombre;
            PgMng.Grow(string.Empty, "Plan_TB");

            Promocion_TB.Text = PromocionInfo.Get(_entity.OidPromocion).Nombre;
            PgMng.Grow(string.Empty, "Promocion_TB");
            //PgMng.ShowCronos();
        }

        /// <summary>
        /// Asigna los valores del grid que no están asociados a propiedades
        /// </summary>
        protected override void SetUnlinkedGridValues(string gridName)
        {
            switch (gridName)
            {
                case "Sesiones_Grid":
                    {
                        int count = 1;
                        foreach (DataGridViewRow row in Sesiones_Grid.Rows)
                        {
                            if (row.IsNewRow) continue;
                            SesionCronograma info = (SesionCronograma)row.DataBoundItem;
                            if (info != null)
                            {
                                if (info.OidClasePractica != 0)
                                {
                                    row.DefaultCellStyle.BackColor = Color.RoyalBlue;
                                    row.Cells[Duracion.Name].Value = info.Duracion;
                                }
                                else
                                {
                                    if (info.OidClaseTeorica == -1)
                                        row.DefaultCellStyle.BackColor = Color.Red;
                                    else
                                        row.DefaultCellStyle.BackColor = Color.White;
                                }
                                row.Cells[Indice.Name].Value = count++;
                            }
                        }
                    } break;
            }
        }

        protected override void OrdenarAction(int fila)
        {
            OrdenarClasesInputForm form = new OrdenarClasesInputForm(true, fila + 1, this);
            form.SetSourceData(Entity, Sesiones_Grid.Rows.Count, _teoricas, _practicas);
            form.ShowDialog();

            Sesiones_Grid.Refresh();
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
            _action_result = SaveObject() ? DialogResult.OK : DialogResult.Ignore;
        }

        #endregion

        #region Events

        private void CronogramaEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_entity != null && !_entity.SharedTransaction)
            {
                if (_entity.CloseSessions) Entity.CloseSession();
                //_entity = null;
            }
        }

        #endregion

    }
}



