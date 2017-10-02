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
    public partial class DisponibilidadViewForm : DisponibilidadForm
    {

        #region Business Methods

        /// <summary>
        /// Se trata del objeto actual.
        /// </summary>
        private InstructorInfo _entity;

        public override InstructorInfo EntityInfo { get { return _entity; } }

        protected new DisponibilidadInfo _disponibilidad;

        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar
        /// </summary>
        public DisponibilidadViewForm() : this(true) { }

        public DisponibilidadViewForm(bool ismodal)
            : base(ismodal)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.DISPONIBILIDAD_EDIT_TITLE;
            _mf_type = ManagerFormType.MFView;
        }

        protected override void GetFormSourceData(long oid)
        {
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
            base.FormatControls();

            Fecha_DTP.Enabled = true;

            Siguiente_BT.Enabled = true;
            Anterior_BT.Enabled = true;
            Fecha_DTP.Enabled = true;
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            if (_entity != null) Datos.DataSource = _entity;
            PgMng.FillUp();
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

                            if (_entity != null && Fecha_DTP.Value != _day)
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

                                if (_entity.Disponibilidades != null)
                                {
                                    DisponibilidadInfo disp = null;

                                    foreach (DisponibilidadInfo item in _entity.Disponibilidades)
                                    {
                                        if (item.FechaInicio.Date.Equals(_day.Date))
                                        {
                                            disp = item;
                                            break;
                                        }
                                    }
                                    Datos_Disponibilidad.DataSource = _entity.Disponibilidades;

                                    PgMng.Grow();

                                    if (disp == null) // hay que resetear los checkbox
                                    {
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

                                        PgMng.Grow();
                                    }
                                    else
                                    {//hay que editar la que existe
                                        _disponibilidad = disp;

                                        Fecha_DTP.Value = _disponibilidad.FechaInicio;
                                        FFIn_Label.Text = "A Sábado, " + _disponibilidad.FechaFin.ToShortDateString();
                                        FInicio_Label.Text = "De Lunes, " + _disponibilidad.FechaInicio.ToShortDateString();
                                        PgMng.Grow();

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
                                        Observaciones_TB.Text = _disponibilidad.Observaciones;
                                        PgMng.Grow();

                                    }
                                }
                            }

                        } break;
                    case "Instructores_CB":
                        {
                            if (Instructores_CB.SelectedItem != null && ((ComboBoxSource)Instructores_CB.SelectedItem).Oid != 0)
                            {
                                _entity = InstructorInfo.Get(((ComboBoxSource)Instructores_CB.SelectedItem).Oid, true);
                                Datos_Disponibilidad.DataSource = _entity.Disponibilidades;

                                Fecha_DTP.Value = DateTime.Today;
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

        #region Print

        #endregion

        #region Actions

        protected override void SaveAction() { _action_result = DialogResult.Cancel; }

        #endregion

        #region Events

        #endregion
    }

}
