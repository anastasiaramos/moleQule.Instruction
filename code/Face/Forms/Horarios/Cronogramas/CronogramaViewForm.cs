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
    public partial class CronogramaViewForm : CronogramaForm
    {
        #region Business Methods

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        protected CronogramaInfo _entity;

        public override CronogramaInfo EntityInfo { get { return _entity; } }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar.
        /// </summary>
        protected CronogramaViewForm() : this(-1, true) { }

        public CronogramaViewForm(bool isModal) : this(-1, isModal) { }

        public CronogramaViewForm(long oid)
            : this(oid, true) { }

        public CronogramaViewForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.CRONOGRAMA_EDIT_TITLE;
            _mf_type = ManagerFormType.MFView;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = CronogramaInfo.Get(oid, true);
            _mf_type = ManagerFormType.MFView;
        }

        #endregion

        #region Style & Source


        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();
            Cancel_BT.Enabled = false;
            Cancel_BT.Visible = false;
            
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

            base.RefreshMainData();
            PgMng.FillUp();
        }

        public override void RefreshSecondaryData()
        {
            Plan_TB.Text = PlanEstudiosInfo.Get(_entity.OidPlan).Nombre;
            PgMng.Grow(string.Empty, "Plan_TB");

            Promocion_TB.Text = PromocionInfo.Get(_entity.OidPromocion).Nombre;
            PgMng.Grow(string.Empty, "Promocion_TB");
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
                            SesionCronogramaInfo info = (SesionCronogramaInfo)row.DataBoundItem;
                            if (info != null)
                            {
                                if (info.OidClasePractica != 0)
                                {
                                    row.DefaultCellStyle.BackColor = Color.RoyalBlue;
                                    row.Cells[Duracion.Name].Value = 5;
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


        #endregion

        #region Validation & Format


        #endregion

        #region Actions

        protected override void SaveAction() { _action_result = DialogResult.Cancel; }

        #endregion

        #region Events

        #endregion

    }
}

