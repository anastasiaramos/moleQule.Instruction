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
    public partial class PromocionUIForm : PromocionForm
    {

        #region Business Methods

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        protected Promocion _entity;

        public override Promocion Entity { get { return _entity; } set { _entity = value; } }
        public override PromocionInfo EntityInfo { get { return (_entity != null) ? _entity.GetInfo(false) : null; } }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar.
        /// </summary>
        protected PromocionUIForm() : this(-1, true) { }

        public PromocionUIForm(bool isModal) : this(-1, isModal) { }

        public PromocionUIForm(long oid) : this(oid, true) { }

        public PromocionUIForm(long oid, bool ismodal)
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
                this.Datos_Alumnos.RaiseListChangedEvents = false;

                Promocion temp = _entity.Clone();
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
                    this.Datos_Alumnos.RaiseListChangedEvents = true;
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

            Alumnos_Grid.Enabled = Datos_Alumnos.Count > 0;
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
        }

        protected override void EditPlanExtraAction()
        {
            //if (PlanExtra_CB.SelectedItem == null) return;

            //_entity.OidPlanExtra = ((PlanExtraInfo)PlanExtra_CB.SelectedItem).Oid;   
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
            if (_entity.FechaInicio == DateTime.MinValue)
                _entity.FechaInicio = DateTime.Today;

            foreach (Sesion_Promocion item in _entity.Sesiones)
                item.HoraInicio = DateTime.Parse(item.Hora);

            if (_entity.Sesiones.Count > 0 && !_entity.CompruebaConfiguracion())
            {
                PgMng.ShowErrorException(Resources.Messages.CONFIGURACION_NO_VALIDA);
                _action_result = DialogResult.Ignore;
                return;
            }
            _action_result = SaveObject() ? DialogResult.OK : DialogResult.Ignore;
        }

        #endregion

        #region Events

        private void PlanEstudios_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (PlanEstudios_CB.SelectedItem == null) return;

            //_entity.OidPlan = ((PlanEstudiosInfo)PlanEstudios_CB.SelectedItem).Oid;   
        }

        private void PlanEstudios_CB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Add) || e.KeyCode.Equals(Keys.Oemplus))
            {
                PlanDocenteUIForm form = new PlanDocenteUIForm(true);
                form.ShowDialog();
                PlanEstudios_CB.ResetText();
            }
        }

        private void CLB_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CLB_1.SelectedIndex)
            {
                case 0:
                    {
                        Entity.H8AM = !Entity.H8AM;
                        CLB_1.SetItemChecked(0, Entity.H8AM);
                    } break;
                case 1:
                    {
                        Entity.H0 = !Entity.H0;
                        CLB_1.SetItemChecked(1, Entity.H0);
                    } break;
                case 2:
                    {
                        Entity.H1 = !Entity.H1;
                        CLB_1.SetItemChecked(2, Entity.H1);
                    } break;
                case 3:
                    {
                        Entity.H2 = !Entity.H2;
                        CLB_1.SetItemChecked(3, Entity.H2);
                    } break;
                case 4:
                    {
                        Entity.H3 = !Entity.H3;
                        CLB_1.SetItemChecked(4, Entity.H3);
                    } break;
                case 5:
                    {
                        Entity.H4 = !Entity.H4;
                        CLB_1.SetItemChecked(5, Entity.H4);
                    } break;
                case 6:
                    {
                        Entity.H5 = !Entity.H5;
                        CLB_1.SetItemChecked(6, Entity.H5);
                    } break;
                case 7:
                    {
                        Entity.H6 = !Entity.H6;
                        CLB_1.SetItemChecked(7, Entity.H6);
                    } break;
            }
        }

        private void CLB_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CLB_2.SelectedIndex)
            {
                case 0:
                    {
                        Entity.H7 = !Entity.H7;
                        CLB_2.SetItemChecked(0, Entity.H7);
                    } break;
                case 1:
                    {
                        Entity.H8 = !Entity.H8;
                        CLB_2.SetItemChecked(1, Entity.H8);
                    } break;
                case 2:
                    {
                        Entity.H9 = !Entity.H9;
                        CLB_2.SetItemChecked(2, Entity.H9);
                    } break;
                case 3:
                    {
                        Entity.H10 = !Entity.H10;
                        CLB_2.SetItemChecked(3, Entity.H10);
                    } break;
                case 4:
                    {
                        Entity.H11 = !Entity.H11;
                        CLB_2.SetItemChecked(4, Entity.H11);
                    } break;
                case 5:
                    {
                        Entity.H12 = !Entity.H12;
                        CLB_2.SetItemChecked(5, Entity.H12);
                    } break;
            }
        }

        private void CLB_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CLB_3.SelectedIndex)
            {
                case 0:
                    {
                        Entity.HS0 = !Entity.HS0;
                        CLB_3.SetItemChecked(0, Entity.HS0);
                    } break;
                case 1:
                    {
                        Entity.HS1 = !Entity.HS1;
                        CLB_3.SetItemChecked(1, Entity.HS1);
                    } break;
                case 2:
                    {
                        Entity.HS2 = !Entity.HS2;
                        CLB_3.SetItemChecked(2, Entity.HS2);
                    } break;
                case 3:
                    {
                        Entity.HS3 = !Entity.HS3;
                        CLB_3.SetItemChecked(3, Entity.HS3);
                    } break;
                case 4:
                    {
                        Entity.HS4 = !Entity.HS4;
                        CLB_3.SetItemChecked(4, Entity.HS4);
                    } break;
            }
        }

        #endregion

    }
}