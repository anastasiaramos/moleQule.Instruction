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
    public partial class DisponibilidadUIForm : DisponibilidadForm
    {

        #region Business Methods

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        protected Instructor _entity;

        public override Instructor Entity { get { return _entity; } set { _entity = value; } }
        public override InstructorInfo EntityInfo { get { return (_entity != null) ? _entity.GetInfo(false) : null; } }

        protected bool _has_parent = false;

        #endregion

        #region Factory Methods

        public DisponibilidadUIForm() : this(true) {}

        public DisponibilidadUIForm(bool ismodal)
            : base(ismodal)
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

                if (_has_parent) return true;

                Instructor temp = _entity;
                temp.ApplyEdit();

                // do the save
                try
                {
                    temp.Save();
                    _entity = temp;
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
            if (_entity != null) Datos.DataSource = _entity;
        }

        /// <summary>
        /// Asigna los datos de origen para controles que dependen de otros
        /// </summary>
        /// <param name="controlName"></param>
        protected override void SetDependentControlSource(string controlName)
        {
            try
            {
                switch (controlName)
                {
                    case "Fecha_DTP":
                        {
                            PgMng.Reset(6, 1, Face.Resources.Messages.REFRESHING_DATA, this);

                            if (_entity != null && (Fecha_DTP.Value != _day 
                                || (_disponibilidad != null && _disponibilidad.OidInstructor != _entity.Oid)))
                            {
                                _day = Fecha_DTP.Value;
                                while (_day.DayOfWeek != System.DayOfWeek.Monday)
                                    _day = _day.AddDays(-1);

                                FFIn_Label.Text = "A Sábado, " + _day.AddDays(5).ToShortDateString();
                                FInicio_Label.Text = "De Lunes, " + _day.ToShortDateString();

                                if (_day < Fecha_DTP.MinDate)
                                    Fecha_DTP.Value = Fecha_DTP.MinDate;
                                else
                                    Fecha_DTP.Value = _day;

                                PgMng.Grow();

                                if (_disponibilidad != null && _disponibilidad.IsDirty)
                                {
                                    /*foreach (Disponibilidad item in _entity.Disponibilidades)
                                    {
                                        if (item.Oid == _disponibilidad.Oid)
                                        {
                                            int index = _entity.Disponibilidades.IndexOf(item);
                                            _disponibilidad.ClasesSemanales = Convert.ToInt64(Clases_TB.Text);
                                            //_entity.Disponibilidades[index] = _disponibilidad;
                                            break;
                                        }
                                    }*/
                                    _disponibilidad.ClasesSemanales = Convert.ToInt64(Clases_TB.Text);
                                    _disponibilidad.Observaciones = Observaciones_TB.Text;
                                }

                                PgMng.Grow();

                                if (_entity.Disponibilidades != null)
                                {
                                    Disponibilidad disp = null;

                                    foreach (Disponibilidad item in _entity.Disponibilidades)
                                    {
                                        if (item.FechaInicio.Date.Equals(_day.Date))
                                        {
                                            disp = item;
                                            break;
                                        }
                                    }

                                    PgMng.Grow();

                                    Datos_Disponibilidad.DataSource = _entity.Disponibilidades;
                                    if (disp == null) // hay que crear la nueva disponibilidad
                                    {
                                        _disponibilidad = _entity.Disponibilidades.NewItem(_entity);
                                        _disponibilidad.FechaInicio = _day;
                                        _disponibilidad.FechaFin = _day.AddDays(4);
                                        PgMng.Grow();

                                        L8AM_CB.Checked = false;
                                        M8AM_CB.Checked = false;
                                        X8AM_CB.Checked = false;
                                        J8AM_CB.Checked = false;
                                        V8AM_CB.Checked = false;
                                        L1_CB.Checked = false;
                                        L2_CB.Checked = false;
                                        L3_CB.Checked = false;
                                        L4_CB.Checked = false;
                                        L5_CB.Checked = false;
                                        L6_CB.Checked = false;
                                        L7_CB.Checked = false;
                                        L8_CB.Checked = false;
                                        L9_CB.Checked = false;
                                        L10_CB.Checked = false;
                                        L11_CB.Checked = false;
                                        L12_CB.Checked = false;
                                        M1_CB.Checked = false;
                                        M2_CB.Checked = false;
                                        M3_CB.Checked = false;
                                        M4_CB.Checked = false;
                                        M5_CB.Checked = false;
                                        M6_CB.Checked = false;
                                        M7_CB.Checked = false;
                                        M8_CB.Checked = false;
                                        M9_CB.Checked = false;
                                        M10_CB.Checked = false;
                                        M11_CB.Checked = false;
                                        M12_CB.Checked = false;
                                        X1_CB.Checked = false;
                                        X2_CB.Checked = false;
                                        X3_CB.Checked = false;
                                        X4_CB.Checked = false;
                                        X5_CB.Checked = false;
                                        X6_CB.Checked = false;
                                        X7_CB.Checked = false;
                                        X8_CB.Checked = false;
                                        X9_CB.Checked = false;
                                        X10_CB.Checked = false;
                                        X11_CB.Checked = false;
                                        X12_CB.Checked = false;
                                        J1_CB.Checked = false;
                                        J2_CB.Checked = false;
                                        J3_CB.Checked = false;
                                        J4_CB.Checked = false;
                                        J5_CB.Checked = false;
                                        J6_CB.Checked = false;
                                        J7_CB.Checked = false;
                                        J8_CB.Checked = false;
                                        J9_CB.Checked = false;
                                        J10_CB.Checked = false;
                                        J11_CB.Checked = false;
                                        J12_CB.Checked = false;
                                        V1_CB.Checked = false;
                                        V2_CB.Checked = false;
                                        V3_CB.Checked = false;
                                        V4_CB.Checked = false;
                                        V5_CB.Checked = false;
                                        V6_CB.Checked = false;
                                        V7_CB.Checked = false;
                                        V8_CB.Checked = false;
                                        V9_CB.Checked = false;
                                        V10_CB.Checked = false;
                                        V11_CB.Checked = false;
                                        V12_CB.Checked = false;
                                        S1_CB.Checked = false;
                                        S2_CB.Checked = false;
                                        S3_CB.Checked = false;
                                        S4_CB.Checked = false;
                                        S0_CB.Checked = false;
                                        L0_CB.Checked = false;
                                        M0_CB.Checked = false;
                                        X0_CB.Checked = false;
                                        J0_CB.Checked = false;
                                        V0_CB.Checked = false;
                                        ND_L_CB.Checked = false;
                                        ND_M_CB.Checked = false;
                                        ND_X_CB.Checked = false;
                                        ND_J_CB.Checked = false;
                                        ND_V_CB.Checked = false;
                                        ND_S_CB.Checked = false;
                                        Clases_TB.Text = "15";
                                        Observaciones_TB.Text = string.Empty;
                                        PgMng.Grow();
                                    }
                                    else
                                    {//hay que editar la que existe
                                        _disponibilidad = disp;

                                        Fecha_DTP.Value = _disponibilidad.FechaInicio;
                                        FFIn_Label.Text = "A Sábado, " + _disponibilidad.FechaFin.ToShortDateString();
                                        FInicio_Label.Text = "De Lunes, " + _disponibilidad.FechaInicio.ToShortDateString();
                                        PgMng.Grow();

                                        L8AM_CB.Checked = _disponibilidad.L8AM;
                                        M8AM_CB.Checked = _disponibilidad.M8AM;
                                        X8AM_CB.Checked = _disponibilidad.X8AM;
                                        J8AM_CB.Checked = _disponibilidad.J8AM;
                                        V8AM_CB.Checked = _disponibilidad.V8AM;
                                        L1_CB.Checked = _disponibilidad.L1;
                                        L2_CB.Checked = _disponibilidad.L2;
                                        L3_CB.Checked = _disponibilidad.L3;
                                        L4_CB.Checked = _disponibilidad.L4;
                                        L5_CB.Checked = _disponibilidad.L5;
                                        L6_CB.Checked = _disponibilidad.L6;
                                        L7_CB.Checked = _disponibilidad.L7;
                                        L8_CB.Checked = _disponibilidad.L8;
                                        L9_CB.Checked = _disponibilidad.L9;
                                        L10_CB.Checked = _disponibilidad.L10;
                                        L11_CB.Checked = _disponibilidad.L11;
                                        L12_CB.Checked = _disponibilidad.L12;
                                        M1_CB.Checked = _disponibilidad.M1;
                                        M2_CB.Checked = _disponibilidad.M2;
                                        M3_CB.Checked = _disponibilidad.M3;
                                        M4_CB.Checked = _disponibilidad.M4;
                                        M5_CB.Checked = _disponibilidad.M5;
                                        M6_CB.Checked = _disponibilidad.M6;
                                        M7_CB.Checked = _disponibilidad.M7;
                                        M8_CB.Checked = _disponibilidad.M8;
                                        M9_CB.Checked = _disponibilidad.M9;
                                        M10_CB.Checked = _disponibilidad.M10;
                                        M11_CB.Checked = _disponibilidad.M11;
                                        M12_CB.Checked = _disponibilidad.M12;
                                        X1_CB.Checked = _disponibilidad.X1;
                                        X2_CB.Checked = _disponibilidad.X2;
                                        X3_CB.Checked = _disponibilidad.X3;
                                        X4_CB.Checked = _disponibilidad.X4;
                                        X5_CB.Checked = _disponibilidad.X5;
                                        X6_CB.Checked = _disponibilidad.X6;
                                        X7_CB.Checked = _disponibilidad.X7;
                                        X8_CB.Checked = _disponibilidad.X8;
                                        X9_CB.Checked = _disponibilidad.X9;
                                        X10_CB.Checked = _disponibilidad.X10;
                                        X11_CB.Checked = _disponibilidad.X11;
                                        X12_CB.Checked = _disponibilidad.X12;
                                        J1_CB.Checked = _disponibilidad.J1;
                                        J2_CB.Checked = _disponibilidad.J2;
                                        J3_CB.Checked = _disponibilidad.J3;
                                        J4_CB.Checked = _disponibilidad.J4;
                                        J5_CB.Checked = _disponibilidad.J5;
                                        J6_CB.Checked = _disponibilidad.J6;
                                        J7_CB.Checked = _disponibilidad.J7;
                                        J8_CB.Checked = _disponibilidad.J8;
                                        J9_CB.Checked = _disponibilidad.J9;
                                        J10_CB.Checked = _disponibilidad.J10;
                                        J11_CB.Checked = _disponibilidad.J11;
                                        J12_CB.Checked = _disponibilidad.J12;
                                        V1_CB.Checked = _disponibilidad.V1;
                                        V2_CB.Checked = _disponibilidad.V2;
                                        V3_CB.Checked = _disponibilidad.V3;
                                        V4_CB.Checked = _disponibilidad.V4;
                                        V5_CB.Checked = _disponibilidad.V5;
                                        V6_CB.Checked = _disponibilidad.V6;
                                        V7_CB.Checked = _disponibilidad.V7;
                                        V8_CB.Checked = _disponibilidad.V8;
                                        V9_CB.Checked = _disponibilidad.V9;
                                        V10_CB.Checked = _disponibilidad.V10;
                                        V11_CB.Checked = _disponibilidad.V11;
                                        V12_CB.Checked = _disponibilidad.V12;
                                        S1_CB.Checked = _disponibilidad.S1;
                                        S2_CB.Checked = _disponibilidad.S2;
                                        S3_CB.Checked = _disponibilidad.S3;
                                        S4_CB.Checked = _disponibilidad.S4;
                                        S0_CB.Checked = _disponibilidad.S0;
                                        L0_CB.Checked = _disponibilidad.L0;
                                        M0_CB.Checked = _disponibilidad.M0;
                                        X0_CB.Checked = _disponibilidad.X0;
                                        J0_CB.Checked = _disponibilidad.J0;
                                        V0_CB.Checked = _disponibilidad.V0;
                                        ND_L_CB.Checked = _disponibilidad.NdL;
                                        ND_M_CB.Checked = _disponibilidad.NdM;
                                        ND_X_CB.Checked = _disponibilidad.NdX;
                                        ND_J_CB.Checked = _disponibilidad.NdJ;
                                        ND_V_CB.Checked = _disponibilidad.NdV;
                                        ND_S_CB.Checked = _disponibilidad.NdS;
                                        Clases_TB.Text = _disponibilidad.ClasesSemanales.ToString();
                                        Observaciones_TB.Text = _disponibilidad.Observaciones.ToString();
                                        PgMng.Grow();

                                    }
                                }
                            }

                        } break;
                    case "Instructores_CB":
                        {
                            PgMng.Reset(3, 1, Face.Resources.Messages.REFRESHING_DATA, this);

                            if (_entity != null && !(this is DisponibilidadEditForm))
                            {
                                if (_entity.IsDirty) SaveObject();
                                _entity.CloseSession();

                            }
                            PgMng.Grow();
                            if (Instructores_CB.SelectedItem != null && ((ComboBoxSource)Instructores_CB.SelectedItem).Oid != 0)
                            {
                                if (_entity != null)
                                {
                                    if (_entity.Oid != ((ComboBoxSource)Instructores_CB.SelectedItem).Oid)
                                    {
                                        if (this is DisponibilidadEditForm)
                                        {
                                            if (_entity.IsDirty) SaveObject();
                                            _entity.CloseSession();
                                        }
                                        _entity = Instructor.Get(((ComboBoxSource)Instructores_CB.SelectedItem).Oid, false);
                                        _entity.LoadChilds(typeof(Disponibilidad), false, false);
                                        _entity.BeginEdit();
                                        Datos_Disponibilidad.DataSource = _entity.Disponibilidades;
                                    }
                                }
                                else
                                {
                                    _entity = Instructor.Get(((ComboBoxSource)Instructores_CB.SelectedItem).Oid, false, _session_code);
                                    _entity.LoadChilds(typeof(Disponibilidad), false, false);
                                    _entity.BeginEdit();
                                    Datos_Disponibilidad.DataSource = _entity.Disponibilidades;
                                }

                                Fecha_DTP.Value = DateTime.Today;                                
                               SetDependentControlSource(Fecha_DTP.Name);
                            }

                        } break;
                    case "Clases_TB":
                        {
                            PgMng.Reset(1, 1, Face.Resources.Messages.REFRESHING_DATA, this);
                            if (_disponibilidad != null)
                            {
                                try
                                {
                                    _disponibilidad.ClasesSemanales = Convert.ToInt64(Clases_TB.Text);
                                }
                                catch 
                                {
                                    _disponibilidad.ClasesSemanales = 15;
                                }
                            }

                        } break;
                }
            }
            finally
            {
                PgMng.FillUp();
            }
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
            if (_entity == null)
            {
                _action_result = DialogResult.OK;
                return;
            }

            _action_result = SaveObject() ? DialogResult.OK : DialogResult.Ignore;
        }

        #endregion

        #region Events

        private void DisponibilidadUIForm_FormClosing(object sender, FormClosingEventArgs e)
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