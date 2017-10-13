using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin01;

using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class CronogramaAddForm : ItemMngSkinForm,
                                        moleQule.Library.IBackGroundLauncher
    {

        #region Business Methods

        public const string ID = "CronogramaAddForm";
        public static Type Type { get { return typeof(CronogramaAddForm); } }

        protected Library.Instruction.HComboBoxSourceList _combo_planes;
        PromocionList _promociones = null;
        private bool _generado = false;

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        protected Cronograma _entity;

        public virtual Cronograma Entity { get { return _entity; } set { _entity = value; } }
        public bool Generado { get { return _generado; } }

        #endregion

        #region Factory Methods

        public CronogramaAddForm() : this(true) {}

        public CronogramaAddForm(bool ismodal)
            : base(ismodal)
        {
            InitializeComponent();
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.CRONOGRAMA_ADD_TITLE;
        }

        public CronogramaAddForm(Cronograma source)
            : base()
        {
            InitializeComponent();
            _entity = source.Clone();
            _entity.BeginEdit();
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.CRONOGRAMA_ADD_TITLE;
        }

        protected override void GetFormSourceData()
        {
            _entity = Cronograma.New();
            _entity.BeginEdit();
        }

        /// <summary>
        /// Guarda en la bd el objeto actual
        /// </summary>
        protected override bool SaveObject()
        {
            using (StatusBusy busy = new StatusBusy(moleQule.Face.Resources.Messages.SAVING))
            {

                this.Datos.RaiseListChangedEvents = false;

                Cronograma temp = _entity;
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

        #region IBackGroundLauncher

        protected new enum BackJob { GetFormData, Cronograma }
        protected new BackJob _back_job = BackJob.GetFormData;

        /// <summary>
        /// La llama el backgroundworker para ejecutar codigo en segundo plano
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public new void BackGroundJob(BackgroundWorker bk)
        {
            try
            {
                switch (_back_job)
                {
                    case BackJob.Cronograma:
                        DoGeneraCronograma();
                        break;

                    default:
                        base.BackGroundJob(bk);
                        return;
                }
                //_finished = true;
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DoGeneraCronograma()
        {
            PgMng.Reset(10, 1, Resources.Messages.GENERANDO_CRONOGRAMA, this);

            try
            {
                int clases_dia = 0;
                int clases_sabado = 0;
                int total_dias = 5;
                PgMng.Grow();

                List<bool> activas_dia = new List<bool>();

                if (CLB_1.CheckedIndices.Contains(0))
                {
                    clases_dia++;
                    activas_dia.Add(true);
                }
                else
                {
                    activas_dia.Add(false);
                }
                if (CLB_1.CheckedIndices.Contains(1))
                {
                    clases_dia++;
                    activas_dia.Add(true);
                }
                else
                {
                    activas_dia.Add(false);
                }
                if (CLB_1.CheckedIndices.Contains(2))
                {
                    clases_dia++;
                    activas_dia.Add(true);
                }
                else
                {
                    activas_dia.Add(false);
                }
                if (CLB_1.CheckedIndices.Contains(3))
                {
                    clases_dia++;
                    activas_dia.Add(true);
                }
                else
                {
                    activas_dia.Add(false);
                }
                if (CLB_1.CheckedIndices.Contains(4))
                {
                    clases_dia++;
                    activas_dia.Add(true);
                }
                else
                {
                    activas_dia.Add(false);
                }
                if (CLB_1.CheckedIndices.Contains(5))
                {
                    clases_dia++;
                    activas_dia.Add(true);
                }
                else
                {
                    activas_dia.Add(false);
                }
                if (CLB_1.CheckedIndices.Contains(6))
                {
                    clases_dia++;
                    activas_dia.Add(true);
                }
                else
                {
                    activas_dia.Add(false);
                }
                if (CLB_1.CheckedIndices.Contains(7))
                {
                    clases_dia++;
                    activas_dia.Add(true);
                }
                else
                { 
                    activas_dia.Add(false);
                }
                if (CLB_2.CheckedIndices.Contains(0))
                {
                    clases_dia++;
                    activas_dia.Add(true);
                }
                else
                {
                    activas_dia.Add(false);
                }
                if (CLB_2.CheckedIndices.Contains(1))
                {
                    clases_dia++;
                    activas_dia.Add(true);
                }
                else
                {
                    activas_dia.Add(false);
                }
                if (CLB_2.CheckedIndices.Contains(2))
                {
                    clases_dia++;
                    activas_dia.Add(true);
                }
                else
                {
                    activas_dia.Add(false);
                }
                if (CLB_2.CheckedIndices.Contains(3))
                {
                    clases_dia++;
                    activas_dia.Add(true);
                }
                else
                {
                    activas_dia.Add(false);
                }
                if (CLB_2.CheckedIndices.Contains(4))
                {
                    clases_dia++;
                    activas_dia.Add(true);
                }
                else
                {
                    activas_dia.Add(false);
                }
                if (CLB_2.CheckedIndices.Contains(5))
                {
                    clases_dia++;
                    activas_dia.Add(true);
                }
                else
                {
                    activas_dia.Add(false);
                }
                PgMng.Grow();

                List<bool> activas_sabado = new List<bool>();

                if (CLB_3.CheckedIndices.Contains(0))
                {
                    clases_sabado++;
                    activas_sabado.Add(true);
                }
                else
                {
                    activas_sabado.Add(false);
                }
                if (CLB_3.CheckedIndices.Contains(1))
                {
                    clases_sabado++;
                    activas_sabado.Add(true);
                }
                else
                {
                    activas_sabado.Add(false);
                }
                if (CLB_3.CheckedIndices.Contains(2))
                {
                    clases_sabado++;
                    activas_sabado.Add(true);
                }
                else
                {
                    activas_sabado.Add(false);
                }
                if (CLB_3.CheckedIndices.Contains(3))
                {
                    clases_sabado++;
                    activas_sabado.Add(true);
                }
                else
                {
                    activas_sabado.Add(false);
                }
                if (CLB_3.CheckedIndices.Contains(4))
                {
                    clases_sabado++;
                    activas_sabado.Add(true);
                }
                else
                {
                    activas_sabado.Add(false);
                }
                PgMng.Grow();

                if (clases_sabado > 0) total_dias = 6;

                _entity.Configuracion = Sesiones_Promociones.NewChildList();

                for (int row_index = 0; row_index < Datos_Sesiones.List.Count; row_index++)
                {
                    Sesion_Promocion sp = Sesion_Promocion.NewChild(_entity);
                    Sesion_Promocion sp_row = ((Sesion_Promocion)Datos_Sesiones.List[row_index]);
                    sp.Hora = sp_row.Hora;
                    sp.HoraInicio = sp_row.HoraInicio;
                    sp.NHoras = sp_row.NHoras;
                    _entity.Configuracion.Add(sp);
                }

                moleQule.Library.Timer t = new moleQule.Library.Timer();
                //t.Start();
                //t.Record("inicio");
                PromocionInfo promocion = PromocionInfo.Get(_entity.OidPromocion, false);
                PlanEstudiosInfo plan = PlanEstudiosInfo.Get(_entity.OidPlan, false);
                if (promocion != null)
                {
                    if (_entity.GeneraCronograma(promocion.Oid != 0 ? promocion.FechaInicio : plan.Fecha, DateTime.MaxValue, (int)Semana_NUD.Value, clases_dia, clases_sabado, total_dias, (int)Practicas_NUD.Value, t, activas_dia, activas_sabado))
                    {
                        //t.Record("fin");
                        //MessageBox.Show(t.GetCronos());
                        //t.Record("GeneraCronograma");
                        //MessageBox.Show("Cronograma generado con éxito");
                        _generado = true;
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido generar el cronograma.\n" +
                            "Compruebe que no se hayan eliminado clases que ya estuvieran planificadas.");
                        _generado = false;
                    }
                }
                else
                {
                    MessageBox.Show("No se ha podido generar el cronograma.\n" +
                        "Seleccione una promoción.");
                    _generado = false;
                }
                //Generar_BT.Enabled = false;
                PgMng.Grow();
            }
            finally { PgMng.FillUp(); }
            if (_generado)
            {
                PgMng.ShowInfoException(Resources.Messages.CRONOGRAMA_GENERADO_CON_EXITO);
                Submit_BT.PerformClick();
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
            if (_entity.OidPromocion <= 0) Generar_BT.Enabled = false;
        }


        public override void RefreshSecondaryData()
        {
            PlanEstudiosList planes = PlanEstudiosList.GetList(false);
            _combo_planes = new Library.Instruction.HComboBoxSourceList(planes);

            Datos_Planes.DataSource = _combo_planes;
            PgMng.Grow(string.Empty, "_combo_planes");

            moleQule.Library.HComboBoxSourceList lista_horas = new moleQule.Library.HComboBoxSourceList();

            lista_horas.Add(new ComboBoxSource(1, "08:00"));
            lista_horas.Add(new ComboBoxSource(2, "09:00"));
            lista_horas.Add(new ComboBoxSource(3, "10:00"));
            lista_horas.Add(new ComboBoxSource(4, "11:00"));
            lista_horas.Add(new ComboBoxSource(5, "12:00"));
            lista_horas.Add(new ComboBoxSource(6, "13:00"));
            lista_horas.Add(new ComboBoxSource(7, "14:00"));
            lista_horas.Add(new ComboBoxSource(8, "15:00"));
            lista_horas.Add(new ComboBoxSource(9, "16:00"));
            lista_horas.Add(new ComboBoxSource(10, "17:00"));
            lista_horas.Add(new ComboBoxSource(11, "18:00"));
            lista_horas.Add(new ComboBoxSource(12, "19:00"));
            lista_horas.Add(new ComboBoxSource(13, "20:00"));
            lista_horas.Add(new ComboBoxSource(14, "21:00"));

            Datos_Horas.DataSource = lista_horas;
            PgMng.Grow(string.Empty, "Datos_Planes.DataSource");

            _promociones = PromocionList.GetList(false);
            _combo_planes.Childs = new Library.Instruction.HComboBoxSourceList(_promociones);
            PgMng.Grow(string.Empty, "_combo_planes.Childs");
            //PgMng.ShowCronos();
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            if (_entity != null) Datos.DataSource = _entity;
            PgMng.FillUp(string.Empty, "RefreshMainData");
            //PgMng.ShowCronos();
        }

        /// <summary>
        /// Asigna los datos de origen para controles que dependen de otros
        /// </summary>
        /// <param name="controlName"></param>
        protected override void SetDependentControlSource(string controlName)
        {
            switch (controlName)
            {
                case "Plan_CB":
                    {
                        //moleQule.Library.Timer t = new moleQule.Library.Timer();
                        if (Datos_Planes.Current != null && Plan_CB.SelectedItem != null)
                        {
                            Datos_Promociones.DataSource = _combo_planes.GetFilteredChilds(((ComboBoxSource)Plan_CB.SelectedItem).Oid);
                            Generar_BT.Enabled = true;
                        }
                        // t.Record("Plan_CB");
                        //MessageBox.Show(t.GetCronos());
                            
                    } break;
                case "Promocion_CB":
                    {
                        //moleQule.Library.Timer t = new moleQule.Library.Timer();
                        if (Datos_Promociones.Current != null)
                        {
                            if (Promocion_CB.SelectedItem != null) _entity.OidPromocion = ((ComboBoxSource)Promocion_CB.SelectedItem).Oid;
                            Generar_BT.Enabled = true;
                        }
                        //t.Record("Promocion_CB");
                        //MessageBox.Show(t.GetCronos());

                    } break;
                case "Semana_GB":
                    {
                        PromocionInfo promo = null;
                        if (Promocion_CB.SelectedItem != null)
                            promo = PromocionInfo.Get(((ComboBoxSource)Promocion_CB.SelectedItem).Oid, true);

                        if (promo != null)
                        {
                            CLB_1.Items[0] = "08:00 - 9:00";
                            CLB_1.Items[1] = "09:00 - 10:00";
                            CLB_1.Items[2] = "10:00 - 11:00";
                            CLB_1.Items[3] = "11:00 - 12:00";
                            CLB_1.Items[4] = "12:00 - 13:00";
                            CLB_1.Items[5] = "13:00 - 14:00";
                            CLB_1.Items[6] = "14:00 - 15:00";
                            CLB_1.Items[7] = "15:00 - 16:00";
                            CLB_2.Items[0] = "16:00 - 17:00";
                            CLB_2.Items[1] = "17:00 - 18:00";
                            CLB_2.Items[2] = "18:00 - 19:00";
                            CLB_2.Items[3] = "19:00 - 20:00";
                            CLB_2.Items[4] = "20:00 - 21:00";
                            CLB_2.Items[5] = "21:00 - 22:00";

                            CLB_1.SetItemChecked(0, promo.H8AM);
                            CLB_1.SetItemChecked(1, promo.H0);
                            CLB_1.SetItemChecked(2, promo.H1);
                            CLB_1.SetItemChecked(3, promo.H2);
                            CLB_1.SetItemChecked(4, promo.H3);
                            CLB_1.SetItemChecked(5, promo.H4);
                            CLB_1.SetItemChecked(6, promo.H5);
                            CLB_1.SetItemChecked(7, promo.H6);
                            CLB_2.SetItemChecked(0, promo.H7);
                            CLB_2.SetItemChecked(1, promo.H8);
                            CLB_2.SetItemChecked(2, promo.H9);
                            CLB_2.SetItemChecked(3, promo.H10);
                            CLB_2.SetItemChecked(4, promo.H11);
                            CLB_2.SetItemChecked(5, promo.H12);

                            _entity.Configuracion = Sesiones_Promociones.NewChildList();

                            foreach (Sesion_PromocionInfo item in promo.Sesiones)
                            {
                                Sesion_Promocion copia_conf = Sesion_Promocion.NewChild(_entity);
                                copia_conf.HoraInicio = item.HoraInicio;
                                copia_conf.Sabado = item.Sabado;
                                copia_conf.NHoras = item.NHoras;
                                copia_conf.Hora = item.Hora;
                                _entity.Configuracion.AddItem(copia_conf);
                            }

                            Datos_Sesiones.DataSource = _entity.Configuracion;
                        }
                    } break;
                case "Sabado_GB":
                    {
                        PromocionInfo promo = null;
                        if (Promocion_CB.SelectedItem != null)
                            promo = _promociones.GetItem(((ComboBoxSource)Promocion_CB.SelectedItem).Oid);

                        if (promo != null)
                        {
                            CLB_3.Items[0] = "09:00 - 10:00";
                            CLB_3.Items[1] = "10:00 - 11:00";
                            CLB_3.Items[2] = "11:00 - 12:00";
                            CLB_3.Items[3] = "12:00 - 13:00";
                            CLB_3.Items[4] = "13:00 - 14:00";

                            CLB_3.SetItemChecked(0, promo.HS0);
                            CLB_3.SetItemChecked(1, promo.HS1);
                            CLB_3.SetItemChecked(2, promo.HS2);
                            CLB_3.SetItemChecked(3, promo.HS3);
                            CLB_3.SetItemChecked(4, promo.HS4);
                        }
                    } break;
            }
        }


        #endregion

        #region Validation & Format

        #endregion

        #region Print

        //public override void PrintObject()
        //{
        //}

        //#endregion

        //#region Buttons

        //protected override void PrintAction()
        //{
        //    switch (TabControl.SelectedTab.Name)
        //    {
        //        case "General_TP":
        //            {
        //                PrintObject();
        //            } break;

        //        default:
        //            {
        //                PrintSelectSkinForm psform = new PrintSelectSkinForm(true);
        //                psform.EnableDetail(false);
        //                psform.ShowDialog();
        //                if (psform.DialogResult == DialogResult.Cancel) return;

        //                switch (TabControl.SelectedTab.Name)
        //                {
        //                    case "Redes_TP":
        //                        {
        //                            PrintData(Entidad.Red, psform.Source, psform.Type);
        //                        } break;

        //                }
        //            } break;
        //    }
        //}

        #endregion

        #region Buttons

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SaveAction()
        {
#if TRACE                    
            moleQule.Library.Timer t = new moleQule.Library.Timer();
#endif            
            if (!_generado)
            {
                MessageBox.Show("No se ha generado ningún cronograma");
                _action_result = DialogResult.Ignore;
                return;
            }
            else
            {
                _entity.FechaCreacion = DateTime.Today;
                if (_entity.Plan == string.Empty)
                {
                    PlanEstudiosInfo plan = PlanEstudiosInfo.Get(_entity.OidPlan, false);
                    if (plan != null)
                        _entity.Plan = plan.Nombre;
                }
                if (_entity.Promocion == string.Empty)
                {
                    PromocionInfo promocion = PromocionInfo.Get(_entity.OidPromocion, false);
                    if (promocion != null)
                        _entity.Promocion = promocion.Nombre;
                }


                foreach (Sesion_Promocion item in _entity.Configuracion)
                    item.HoraInicio = DateTime.Parse(item.Hora);
#if TRACE                    
                t.Record("FechaCreacion");
#endif
                _action_result = SaveObject() ? DialogResult.OK : DialogResult.Ignore;                
            }
        }

        protected override void CancelAction()
        {
            _action_result = DialogResult.Cancel;
            CancelBackGroundJob();
        }

        private void Generar_BT_Click(object sender, EventArgs e)
        {
            //PgMng.Reset(10, 1, moleQule.Face.Resources.Messages.LOADING_DATA, this);
            //_back_job = BackJob.Cronograma;
            //PgMng.StartBackJob(this);
            //PgMng.FillUp();
            DoGeneraCronograma();
        }

        #endregion

        #region Events

        private void CronogramaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_entity != null && !_entity.SharedTransaction)
            {
                if (_entity.CloseSessions) Entity.CloseSession();
                //_entity = null;
            }
        }

        private void Plan_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDependentControlSource(Plan_CB.Name);
        }

        private void Promocion_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDependentControlSource(Promocion_CB.Name);
            SetDependentControlSource(Semana_GB.Name);
            SetDependentControlSource(Sabado_GB.Name);
        }
        
        #endregion

        private void Sesiones_Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

    }
}

