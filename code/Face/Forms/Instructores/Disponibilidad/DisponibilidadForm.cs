using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Csla;
using moleQule.Library.CslaEx;
using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin01;

using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class DisponibilidadForm : ListMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 2; } }

        protected Library.Instruction.HComboBoxSourceList _combo_instructores;
        //protected Instructor _instructor;
        protected DateTime _day;
        protected int _session_code = -1;
        
        protected InstructorList listainfo = null;
        protected Disponibilidad _disponibilidad;

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        public virtual Instructor Entity { get { return null; } set { } }
        public virtual InstructorInfo EntityInfo { get { return null; } }

        #endregion

        #region Factory Methods

        public DisponibilidadForm() : this(true) {}

        public DisponibilidadForm(bool ismodal)
            : base(ismodal)
        {
            InitializeComponent();
        }

        #endregion

        #region Style & Source


        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();

            if (!(this is DisponibilidadAddForm))
                Instructores_CB.Enabled = false;

            //DateTime min = DateTime.MaxValue;

            //PromocionList promociones = PromocionList.GetList(false);
            //foreach (PromocionInfo item in promociones)
            //{
            //    if (item.FechaInicio.Date < min)
            //        min = item.FechaInicio;
            //}
            //while (min.DayOfWeek != DayOfWeek.Monday)
            //    min = min.AddDays(-1);

            //Fecha_DTP.MinDate = min;
        }


        public override void RefreshSecondaryData()
        {
            try
            {
                PgMng.Reset(2, 1, Face.Resources.Messages.REFRESHING_DATA, this);
                listainfo = InstructorList.GetList(false);
                SortedBindingList<InstructorInfo> lista = InstructorList.SortList(listainfo, "Apellidos", ListSortDirection.Ascending);
                _combo_instructores = new Library.Instruction.HComboBoxSourceList(lista);
                PgMng.Grow();

                Datos_Instructores.DataSource = _combo_instructores;
            }
            finally
            {
                PgMng.FillUp();
            }
        }

        public void SeleccionaInstructor(long oid, int sessionCode = -1)
        {
            _session_code = sessionCode;
            if (_combo_instructores != null)
                Instructores_CB.SelectedItem = _combo_instructores.Buscar(oid);
            SetDependentControlSource(Instructores_CB.Name);
        }

        public void SeleccionaInstructor(long oid, DateTime fecha)
        {
            if (_combo_instructores != null)
                Instructores_CB.SelectedItem = _combo_instructores.Buscar(oid);
            SetDependentControlSource(Instructores_CB.Name);
            Fecha_DTP.Value = fecha;
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

        #region Events

        private void Fecha_DTP_ValueChanged(object sender, EventArgs e)
        {
            SetDependentControlSource(Fecha_DTP.Name);
            if (_disponibilidad != null)
            {
                Lunes_LB.Text = "LUNES" + Environment.NewLine + _disponibilidad.FechaInicio.Day.ToString("00")
                    + "/" + _disponibilidad.FechaInicio.Month.ToString("00");
                Martes_LB.Text = "MARTES" + Environment.NewLine + _disponibilidad.FechaInicio.AddDays(1).Day.ToString("00")
                    + "/" + _disponibilidad.FechaInicio.AddDays(1).Month.ToString("00");
                Miercoles_LB.Text = "MIÉRCOLES" + Environment.NewLine + _disponibilidad.FechaInicio.AddDays(2).Day.ToString("00")
                    + "/" + _disponibilidad.FechaInicio.AddDays(2).Month.ToString("00");
                Jueves_LB.Text = "JUEVES" + Environment.NewLine + _disponibilidad.FechaInicio.AddDays(3).Day.ToString("00")
                    + "/" + _disponibilidad.FechaInicio.AddDays(3).Month.ToString("00");
                Viernes_LB.Text = "VIERNES" + Environment.NewLine + _disponibilidad.FechaInicio.AddDays(4).Day.ToString("00")
                    + "/" + _disponibilidad.FechaInicio.AddDays(4).Month.ToString("00");
                Sabado_LB.Text = "SÁBADO" + Environment.NewLine + _disponibilidad.FechaInicio.AddDays(5).Day.ToString("00")
                    + "/" + _disponibilidad.FechaInicio.AddDays(5).Month.ToString("00");
            }
        }

        private void Siguiente_BT_Click(object sender, EventArgs e)
        {
            if (Fecha_DTP.Value.AddDays(7) >= Fecha_DTP.MaxDate)
                Fecha_DTP.Value = DateTime.Today;
            else
                Fecha_DTP.Value = Fecha_DTP.Value.AddDays(7);
        }

        private void Anterior_BT_Click(object sender, EventArgs e)
        {
            if (Fecha_DTP.Value.AddDays(-7) < Fecha_DTP.MinDate)
                Fecha_DTP.Value = Fecha_DTP.MinDate;
            else
                Fecha_DTP.Value = Fecha_DTP.Value.AddDays(-7);
        }

        private void Clases_TB_TextChanged(object sender, EventArgs e)
        {
            SetDependentControlSource(Clases_TB.Name);
        }

        private void Desmarcar_BT_Click(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
            {
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
            }
        }

        private void Marcar_BT_Click(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
            {
                L8AM_CB.Checked = true;
                M8AM_CB.Checked = true;
                X8AM_CB.Checked = true;
                J8AM_CB.Checked = true;
                V8AM_CB.Checked = true;
                L1_CB.Checked = true;
                L2_CB.Checked = true;
                L3_CB.Checked = true;
                L4_CB.Checked = true;
                L5_CB.Checked = true;
                L6_CB.Checked = true;
                L7_CB.Checked = true;
                L8_CB.Checked = true;
                L9_CB.Checked = true;
                L10_CB.Checked = true;
                L11_CB.Checked = true;
                L12_CB.Checked = true;
                M1_CB.Checked = true;
                M2_CB.Checked = true;
                M3_CB.Checked = true;
                M4_CB.Checked = true;
                M5_CB.Checked = true;
                M6_CB.Checked = true;
                M7_CB.Checked = true;
                M8_CB.Checked = true;
                M9_CB.Checked = true;
                M10_CB.Checked = true;
                M11_CB.Checked = true;
                M12_CB.Checked = true;
                X1_CB.Checked = true;
                X2_CB.Checked = true;
                X3_CB.Checked = true;
                X4_CB.Checked = true;
                X5_CB.Checked = true;
                X6_CB.Checked = true;
                X7_CB.Checked = true;
                X8_CB.Checked = true;
                X9_CB.Checked = true;
                X10_CB.Checked = true;
                X11_CB.Checked = true;
                X12_CB.Checked = true;
                J1_CB.Checked = true;
                J2_CB.Checked = true;
                J3_CB.Checked = true;
                J4_CB.Checked = true;
                J5_CB.Checked = true;
                J6_CB.Checked = true;
                J7_CB.Checked = true;
                J8_CB.Checked = true;
                J9_CB.Checked = true;
                J10_CB.Checked = true;
                J11_CB.Checked = true;
                J12_CB.Checked = true;
                V1_CB.Checked = true;
                V2_CB.Checked = true;
                V3_CB.Checked = true;
                V4_CB.Checked = true;
                V5_CB.Checked = true;
                V6_CB.Checked = true;
                V7_CB.Checked = true;
                V8_CB.Checked = true;
                V9_CB.Checked = true;
                V10_CB.Checked = true;
                V11_CB.Checked = true;
                V12_CB.Checked = true;
                S1_CB.Checked = true;
                S2_CB.Checked = true;
                S3_CB.Checked = true;
                S4_CB.Checked = true;
                S0_CB.Checked = true;
                L0_CB.Checked = true;
                M0_CB.Checked = true;
                X0_CB.Checked = true;
                J0_CB.Checked = true;
                V0_CB.Checked = true;
            }
        }

        private void L0_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.L0 = L0_CB.Checked;
        }

        private void M0_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.M0 = M0_CB.Checked;
        }

        private void X0_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.X0 = X0_CB.Checked;
        }

        private void J0_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.J0 = J0_CB.Checked;
        }

        private void V0_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.V0 = V0_CB.Checked;
        }

        private void S0_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.S0 = S0_CB.Checked;
        }

        private void L1_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.L1 = L1_CB.Checked;

        }

        private void M1_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.M1 = M1_CB.Checked;

        }

        private void X1_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.X1 = X1_CB.Checked;

        }

        private void J1_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.J1 = J1_CB.Checked;

        }

        private void V1_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.V1 = V1_CB.Checked;

        }

        private void S1_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.S1 = S1_CB.Checked;

        }

        private void L2_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.L2 = L2_CB.Checked;

        }

        private void M2_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.M2 = M2_CB.Checked;

        }

        private void X2_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.X2 = X2_CB.Checked;

        }

        private void J2_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.J2 = J2_CB.Checked;
        }

        private void V2_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.V2 = V2_CB.Checked;
        }

        private void S2_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.S2 = S2_CB.Checked;
        }

        private void L3_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.L3 = L3_CB.Checked;
        }

        private void M3_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.M3 = M3_CB.Checked;
        }

        private void X3_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.X3 = X3_CB.Checked;
        }

        private void J3_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.J3 = J3_CB.Checked;
        }

        private void V3_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.V3 = V3_CB.Checked;
        }

        private void S3_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.S3 = S3_CB.Checked;
        }

        private void L4_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.L4 = L4_CB.Checked;
        }

        private void M4_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.M4 = M4_CB.Checked;
        }

        private void X4_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.X4 = X4_CB.Checked;
        }

        private void J4_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.J4 = J4_CB.Checked;
        }

        private void V4_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.V4 = V4_CB.Checked;
        }

        private void S4_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.S4 = S4_CB.Checked;
        }

        private void L5_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.L5 = L5_CB.Checked;
        }

        private void M5_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.M5 = M5_CB.Checked;
        }

        private void X5_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.X5 = X5_CB.Checked;
        }

        private void J5_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.J5 = J5_CB.Checked;
        }

        private void V5_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.V5 = V5_CB.Checked;
        }

        private void L6_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.L6 = L6_CB.Checked;
        }

        private void M6_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.M6 = M6_CB.Checked;
        }

        private void X6_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.X6 = X6_CB.Checked;
        }

        private void J6_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.J6 = J6_CB.Checked;
        }

        private void V6_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.V6 = V6_CB.Checked;
        }

        private void L7_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.L7 = L7_CB.Checked;
        }

        private void M7_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.M7 = M7_CB.Checked;
        }

        private void X7_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.X7 = X7_CB.Checked;
        }

        private void J7_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.J7 = J7_CB.Checked;
        }

        private void V7_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.V7 = V7_CB.Checked;
        }

        private void L8_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.L8 = L8_CB.Checked;
        }

        private void M8_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.M8 = M8_CB.Checked;
        }

        private void X8_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.X8 = X8_CB.Checked;
        }

        private void J8_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.J8 = J8_CB.Checked;
        }

        private void V8_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.V8 = V8_CB.Checked;
        }

        private void L9_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.L9 = L9_CB.Checked;
        }

        private void M9_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.M9 = M9_CB.Checked;
        }

        private void X9_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.X9 = X9_CB.Checked;
        }

        private void J9_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.J9 = J9_CB.Checked;
        }

        private void V9_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.V9 = V9_CB.Checked;
        }

        private void L10_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.L10 = L10_CB.Checked;
        }

        private void M10_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.M10 = M10_CB.Checked;
        }

        private void X10_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.X10 = X10_CB.Checked;
        }

        private void J10_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad !=null)
                _disponibilidad.J10 = J10_CB.Checked;
        }

        private void V10_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.V10 = V10_CB.Checked;
        }

        private void L11_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.L11 = L11_CB.Checked;
        }

        private void L12_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.L12 = L12_CB.Checked;
        }

        private void M11_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.M11 = M11_CB.Checked;
        }

        private void M12_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.M12 = M12_CB.Checked;
        }

        private void X11_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.X11 = X11_CB.Checked;
        }

        private void X12_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.X12 = X12_CB.Checked;
        }

        private void J11_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.J11 = J11_CB.Checked;
        }

        private void J12_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.J12 = J12_CB.Checked;
        }

        private void V11_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.V11 = V11_CB.Checked;
        }

        private void V12_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.V12 = V12_CB.Checked;
        }

        private void ND_L_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.NdL = ND_L_CB.Checked;
        }

        private void ND_M_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.NdM = ND_M_CB.Checked;
        }

        private void ND_X_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.NdX = ND_X_CB.Checked;
        }

        private void ND_J_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.NdJ = ND_J_CB.Checked;
        }

        private void ND_V_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.NdV = ND_V_CB.Checked;
        }

        private void ND_S_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.NdS = ND_S_CB.Checked;
        }

        #endregion         

        private void L0_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Lunes_LB.BackColor = Color.White;
            Hora1_LB.BackColor = Color.White;
        }

        private void L0_CB_MouseLeave(object sender, EventArgs e)
        {
            Lunes_LB.BackColor = Color.Transparent;
            Hora1_LB.BackColor = Color.Transparent;
        }

        private void M0_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Martes_LB.BackColor = Color.White;
            Hora1_LB.BackColor = Color.White;
        }

        private void M0_CB_MouseLeave(object sender, EventArgs e)
        {
            Martes_LB.BackColor = Color.Transparent;
            Hora1_LB.BackColor = Color.Transparent;
        }

        private void X0_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Miercoles_LB.BackColor = Color.White;
            Hora1_LB.BackColor = Color.White;
        }

        private void X0_CB_MouseLeave(object sender, EventArgs e)
        {
            Miercoles_LB.BackColor = Color.Transparent;
            Hora1_LB.BackColor = Color.Transparent;
        }

        private void J0_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Jueves_LB.BackColor = Color.White;
            Hora1_LB.BackColor = Color.White;
        }

        private void J0_CB_MouseLeave(object sender, EventArgs e)
        {
            Jueves_LB.BackColor = Color.Transparent;
            Hora1_LB.BackColor = Color.Transparent;
        }

        private void V0_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Viernes_LB.BackColor = Color.White;
            Hora1_LB.BackColor = Color.White;
        }

        private void V0_CB_MouseLeave(object sender, EventArgs e)
        {
            Viernes_LB.BackColor = Color.Transparent;
            Hora1_LB.BackColor = Color.Transparent;
        }

        private void S0_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Sabado_LB.BackColor = Color.White;
            Hora1_LB.BackColor = Color.White;
        }

        private void S0_CB_MouseLeave(object sender, EventArgs e)
        {
            Sabado_LB.BackColor = Color.Transparent;
            Hora1_LB.BackColor = Color.Transparent;
        }

        private void L1_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Lunes_LB.BackColor = Color.White;
            Hora2_LB.BackColor = Color.White;
        }

        private void L1_CB_MouseLeave(object sender, EventArgs e)
        {
            Lunes_LB.BackColor = Color.Transparent;
            Hora2_LB.BackColor = Color.Transparent;
        }

        private void M1_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Martes_LB.BackColor = Color.White;
            Hora2_LB.BackColor = Color.White;
        }

        private void M1_CB_MouseLeave(object sender, EventArgs e)
        {
            Martes_LB.BackColor = Color.Transparent;
            Hora2_LB.BackColor = Color.Transparent;
        }

        private void X1_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Miercoles_LB.BackColor = Color.White;
            Hora2_LB.BackColor = Color.White;
        }

        private void X1_CB_MouseLeave(object sender, EventArgs e)
        {
            Miercoles_LB.BackColor = Color.Transparent;
            Hora2_LB.BackColor = Color.Transparent;
        }

        private void J1_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Jueves_LB.BackColor = Color.White;
            Hora2_LB.BackColor = Color.White;
        }

        private void J1_CB_MouseLeave(object sender, EventArgs e)
        {
            Jueves_LB.BackColor = Color.Transparent;
            Hora2_LB.BackColor = Color.Transparent;
        }

        private void V1_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Viernes_LB.BackColor = Color.White;
            Hora2_LB.BackColor = Color.White;
        }

        private void V1_CB_MouseLeave(object sender, EventArgs e)
        {
            Viernes_LB.BackColor = Color.Transparent;
            Hora2_LB.BackColor = Color.Transparent;
        }

        private void S1_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Sabado_LB.BackColor = Color.White;
            Hora2_LB.BackColor = Color.White;
        }

        private void S1_CB_MouseLeave(object sender, EventArgs e)
        {
            Sabado_LB.BackColor = Color.Transparent;
            Hora2_LB.BackColor = Color.Transparent;
        }

        private void L2_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Lunes_LB.BackColor = Color.White;
            Hora3_LB.BackColor = Color.White;
        }

        private void L2_CB_MouseLeave(object sender, EventArgs e)
        {
            Lunes_LB.BackColor = Color.Transparent;
            Hora3_LB.BackColor = Color.Transparent;
        }

        private void M2_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Martes_LB.BackColor = Color.White;
            Hora3_LB.BackColor = Color.White;
        }

        private void M2_CB_MouseLeave(object sender, EventArgs e)
        {
            Martes_LB.BackColor = Color.Transparent;
            Hora3_LB.BackColor = Color.Transparent;
        }

        private void X2_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Miercoles_LB.BackColor = Color.White;
            Hora3_LB.BackColor = Color.White;
        }

        private void X2_CB_MouseLeave(object sender, EventArgs e)
        {
            Miercoles_LB.BackColor = Color.Transparent;
            Hora3_LB.BackColor = Color.Transparent;
        }

        private void J2_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Jueves_LB.BackColor = Color.White;
            Hora3_LB.BackColor = Color.White;
        }

        private void J2_CB_MouseLeave(object sender, EventArgs e)
        {
            Jueves_LB.BackColor = Color.Transparent;
            Hora3_LB.BackColor = Color.Transparent;
        }

        private void V2_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Viernes_LB.BackColor = Color.White;
            Hora3_LB.BackColor = Color.White;
        }

        private void V2_CB_MouseLeave(object sender, EventArgs e)
        {
            Viernes_LB.BackColor = Color.Transparent;
            Hora3_LB.BackColor = Color.Transparent;
        }

        private void S2_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Sabado_LB.BackColor = Color.White;
            Hora3_LB.BackColor = Color.White;
        }

        private void S2_CB_MouseLeave(object sender, EventArgs e)
        {
            Sabado_LB.BackColor = Color.Transparent;
            Hora3_LB.BackColor = Color.Transparent;
        }

        private void L3_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Lunes_LB.BackColor = Color.White;
            Hora4_LB.BackColor = Color.White;
        }

        private void L3_CB_MouseLeave(object sender, EventArgs e)
        {
            Lunes_LB.BackColor = Color.Transparent;
            Hora4_LB.BackColor = Color.Transparent;
        }

        private void M3_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Martes_LB.BackColor = Color.White;
            Hora4_LB.BackColor = Color.White;
        }

        private void M3_CB_MouseLeave(object sender, EventArgs e)
        {
            Martes_LB.BackColor = Color.Transparent;
            Hora4_LB.BackColor = Color.Transparent;
        }

        private void X3_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Miercoles_LB.BackColor = Color.White;
            Hora4_LB.BackColor = Color.White;
        }

        private void X3_CB_MouseLeave(object sender, EventArgs e)
        {
            Miercoles_LB.BackColor = Color.Transparent;
            Hora4_LB.BackColor = Color.Transparent;
        }

        private void J3_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Jueves_LB.BackColor = Color.White;
            Hora4_LB.BackColor = Color.White;
        }

        private void J3_CB_MouseLeave(object sender, EventArgs e)
        {
            Jueves_LB.BackColor = Color.Transparent;
            Hora4_LB.BackColor = Color.Transparent;
        }

        private void V3_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Viernes_LB.BackColor = Color.White;
            Hora4_LB.BackColor = Color.White;
        }

        private void V3_CB_MouseLeave(object sender, EventArgs e)
        {
            Viernes_LB.BackColor = Color.Transparent;
            Hora4_LB.BackColor = Color.Transparent;
        }

        private void S3_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Sabado_LB.BackColor = Color.White;
            Hora4_LB.BackColor = Color.White;
        }

        private void S3_CB_MouseLeave(object sender, EventArgs e)
        {
            Sabado_LB.BackColor = Color.Transparent;
            Hora4_LB.BackColor = Color.Transparent;
        }
        
        private void L4_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Lunes_LB.BackColor = Color.White;
            Hora5_LB.BackColor = Color.White;
        }

        private void L4_CB_MouseLeave(object sender, EventArgs e)
        {
            Lunes_LB.BackColor = Color.Transparent;
            Hora5_LB.BackColor = Color.Transparent;
        }

        private void M4_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Martes_LB.BackColor = Color.White;
            Hora5_LB.BackColor = Color.White;
        }

        private void M4_CB_MouseLeave(object sender, EventArgs e)
        {
            Martes_LB.BackColor = Color.Transparent;
            Hora5_LB.BackColor = Color.Transparent;
        }

        private void X4_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Miercoles_LB.BackColor = Color.White;
            Hora5_LB.BackColor = Color.White;
        }

        private void X4_CB_MouseLeave(object sender, EventArgs e)
        {
            Miercoles_LB.BackColor = Color.Transparent;
            Hora5_LB.BackColor = Color.Transparent;
        }

        private void J4_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Jueves_LB.BackColor = Color.White;
            Hora5_LB.BackColor = Color.White;
        }

        private void J4_CB_MouseLeave(object sender, EventArgs e)
        {
            Jueves_LB.BackColor = Color.Transparent;
            Hora5_LB.BackColor = Color.Transparent;
        }

        private void V4_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Viernes_LB.BackColor = Color.White;
            Hora5_LB.BackColor = Color.White;
        }

        private void V4_CB_MouseLeave(object sender, EventArgs e)
        {
            Viernes_LB.BackColor = Color.Transparent;
            Hora5_LB.BackColor = Color.Transparent;
        }

        private void S4_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Sabado_LB.BackColor = Color.White;
            Hora5_LB.BackColor = Color.White;
        }

        private void S4_CB_MouseLeave(object sender, EventArgs e)
        {
            Sabado_LB.BackColor = Color.Transparent;
            Hora5_LB.BackColor = Color.Transparent;
        }
        
        private void L5_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Lunes_LB.BackColor = Color.White;
            Hora6_LB.BackColor = Color.White;
        }

        private void L5_CB_MouseLeave(object sender, EventArgs e)
        {
            Lunes_LB.BackColor = Color.Transparent;
            Hora6_LB.BackColor = Color.Transparent;
        }

        private void M5_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Martes_LB.BackColor = Color.White;
            Hora6_LB.BackColor = Color.White;
        }

        private void M5_CB_MouseLeave(object sender, EventArgs e)
        {
            Martes_LB.BackColor = Color.Transparent;
            Hora6_LB.BackColor = Color.Transparent;
        }

        private void X5_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Miercoles_LB.BackColor = Color.White;
            Hora6_LB.BackColor = Color.White;
        }

        private void X5_CB_MouseLeave(object sender, EventArgs e)
        {
            Miercoles_LB.BackColor = Color.Transparent;
            Hora6_LB.BackColor = Color.Transparent;
        }

        private void J5_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Jueves_LB.BackColor = Color.White;
            Hora6_LB.BackColor = Color.White;
        }

        private void J5_CB_MouseLeave(object sender, EventArgs e)
        {
            Jueves_LB.BackColor = Color.Transparent;
            Hora6_LB.BackColor = Color.Transparent;
        }

        private void V5_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Viernes_LB.BackColor = Color.White;
            Hora6_LB.BackColor = Color.White;
        }

        private void V5_CB_MouseLeave(object sender, EventArgs e)
        {
            Viernes_LB.BackColor = Color.Transparent;
            Hora6_LB.BackColor = Color.Transparent;
        }
        
        private void L6_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Lunes_LB.BackColor = Color.White;
            Hora7_LB.BackColor = Color.White;
        }

        private void L6_CB_MouseLeave(object sender, EventArgs e)
        {
            Lunes_LB.BackColor = Color.Transparent;
            Hora7_LB.BackColor = Color.Transparent;
        }

        private void M6_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Martes_LB.BackColor = Color.White;
            Hora7_LB.BackColor = Color.White;
        }

        private void M6_CB_MouseLeave(object sender, EventArgs e)
        {
            Martes_LB.BackColor = Color.Transparent;
            Hora7_LB.BackColor = Color.Transparent;
        }

        private void X6_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Miercoles_LB.BackColor = Color.White;
            Hora7_LB.BackColor = Color.White;
        }

        private void X6_CB_MouseLeave(object sender, EventArgs e)
        {
            Miercoles_LB.BackColor = Color.Transparent;
            Hora7_LB.BackColor = Color.Transparent;
        }

        private void J6_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Jueves_LB.BackColor = Color.White;
            Hora7_LB.BackColor = Color.White;
        }

        private void J6_CB_MouseLeave(object sender, EventArgs e)
        {
            Jueves_LB.BackColor = Color.Transparent;
            Hora7_LB.BackColor = Color.Transparent;
        }

        private void V6_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Viernes_LB.BackColor = Color.White;
            Hora7_LB.BackColor = Color.White;
        }

        private void V6_CB_MouseLeave(object sender, EventArgs e)
        {
            Viernes_LB.BackColor = Color.Transparent;
            Hora7_LB.BackColor = Color.Transparent;
        }
        
        private void L7_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Lunes_LB.BackColor = Color.White;
            Hora8_LB.BackColor = Color.White;
        }

        private void L7_CB_MouseLeave(object sender, EventArgs e)
        {
            Lunes_LB.BackColor = Color.Transparent;
            Hora8_LB.BackColor = Color.Transparent;
        }

        private void M7_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Martes_LB.BackColor = Color.White;
            Hora8_LB.BackColor = Color.White;
        }

        private void M7_CB_MouseLeave(object sender, EventArgs e)
        {
            Martes_LB.BackColor = Color.Transparent;
            Hora8_LB.BackColor = Color.Transparent;
        }

        private void X7_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Miercoles_LB.BackColor = Color.White;
            Hora8_LB.BackColor = Color.White;
        }

        private void X7_CB_MouseLeave(object sender, EventArgs e)
        {
            Miercoles_LB.BackColor = Color.Transparent;
            Hora8_LB.BackColor = Color.Transparent;
        }

        private void J7_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Jueves_LB.BackColor = Color.White;
            Hora8_LB.BackColor = Color.White;
        }

        private void J7_CB_MouseLeave(object sender, EventArgs e)
        {
            Jueves_LB.BackColor = Color.Transparent;
            Hora8_LB.BackColor = Color.Transparent;
        }

        private void V7_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Viernes_LB.BackColor = Color.White;
            Hora8_LB.BackColor = Color.White;
        }

        private void V7_CB_MouseLeave(object sender, EventArgs e)
        {
            Viernes_LB.BackColor = Color.Transparent;
            Hora8_LB.BackColor = Color.Transparent;
        }
        
        private void L8_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Lunes_LB.BackColor = Color.White;
            Hora9_LB.BackColor = Color.White;
        }

        private void L8_CB_MouseLeave(object sender, EventArgs e)
        {
            Lunes_LB.BackColor = Color.Transparent;
            Hora9_LB.BackColor = Color.Transparent;
        }

        private void M8_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Martes_LB.BackColor = Color.White;
            Hora9_LB.BackColor = Color.White;
        }

        private void M8_CB_MouseLeave(object sender, EventArgs e)
        {
            Martes_LB.BackColor = Color.Transparent;
            Hora9_LB.BackColor = Color.Transparent;
        }

        private void X8_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Miercoles_LB.BackColor = Color.White;
            Hora9_LB.BackColor = Color.White;
        }

        private void X8_CB_MouseLeave(object sender, EventArgs e)
        {
            Miercoles_LB.BackColor = Color.Transparent;
            Hora9_LB.BackColor = Color.Transparent;
        }

        private void J8_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Jueves_LB.BackColor = Color.White;
            Hora9_LB.BackColor = Color.White;
        }

        private void J8_CB_MouseLeave(object sender, EventArgs e)
        {
            Jueves_LB.BackColor = Color.Transparent;
            Hora9_LB.BackColor = Color.Transparent;
        }

        private void V8_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Viernes_LB.BackColor = Color.White;
            Hora9_LB.BackColor = Color.White;
        }

        private void V8_CB_MouseLeave(object sender, EventArgs e)
        {
            Viernes_LB.BackColor = Color.Transparent;
            Hora9_LB.BackColor = Color.Transparent;
        }
        
        private void L9_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Lunes_LB.BackColor = Color.White;
            Hora10_LB.BackColor = Color.White;
        }

        private void L9_CB_MouseLeave(object sender, EventArgs e)
        {
            Lunes_LB.BackColor = Color.Transparent;
            Hora10_LB.BackColor = Color.Transparent;
        }

        private void M9_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Martes_LB.BackColor = Color.White;
            Hora10_LB.BackColor = Color.White;
        }

        private void M9_CB_MouseLeave(object sender, EventArgs e)
        {
            Martes_LB.BackColor = Color.Transparent;
            Hora10_LB.BackColor = Color.Transparent;
        }

        private void X9_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Miercoles_LB.BackColor = Color.White;
            Hora10_LB.BackColor = Color.White;
        }

        private void X9_CB_MouseLeave(object sender, EventArgs e)
        {
            Miercoles_LB.BackColor = Color.Transparent;
            Hora10_LB.BackColor = Color.Transparent;
        }

        private void J9_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Jueves_LB.BackColor = Color.White;
            Hora10_LB.BackColor = Color.White;
        }

        private void J9_CB_MouseLeave(object sender, EventArgs e)
        {
            Jueves_LB.BackColor = Color.Transparent;
            Hora10_LB.BackColor = Color.Transparent;
        }

        private void V9_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Viernes_LB.BackColor = Color.White;
            Hora10_LB.BackColor = Color.White;
        }

        private void V9_CB_MouseLeave(object sender, EventArgs e)
        {
            Viernes_LB.BackColor = Color.Transparent;
            Hora10_LB.BackColor = Color.Transparent;
        }


        private void L10_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Lunes_LB.BackColor = Color.White;
            Hora11_LB.BackColor = Color.White;
        }

        private void L10_CB_MouseLeave(object sender, EventArgs e)
        {
            Lunes_LB.BackColor = Color.Transparent;
            Hora11_LB.BackColor = Color.Transparent;
        }

        private void M10_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Martes_LB.BackColor = Color.White;
            Hora11_LB.BackColor = Color.White;
        }

        private void M10_CB_MouseLeave(object sender, EventArgs e)
        {
            Martes_LB.BackColor = Color.Transparent;
            Hora11_LB.BackColor = Color.Transparent;
        }

        private void X10_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Miercoles_LB.BackColor = Color.White;
            Hora11_LB.BackColor = Color.White;
        }

        private void X10_CB_MouseLeave(object sender, EventArgs e)
        {
            Miercoles_LB.BackColor = Color.Transparent;
            Hora11_LB.BackColor = Color.Transparent;
        }

        private void J10_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Jueves_LB.BackColor = Color.White;
            Hora11_LB.BackColor = Color.White;
        }

        private void J10_CB_MouseLeave(object sender, EventArgs e)
        {
            Jueves_LB.BackColor = Color.Transparent;
            Hora11_LB.BackColor = Color.Transparent;
        }

        private void V10_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Viernes_LB.BackColor = Color.White;
            Hora11_LB.BackColor = Color.White;
        }

        private void V10_CB_MouseLeave(object sender, EventArgs e)
        {
            Viernes_LB.BackColor = Color.Transparent;
            Hora11_LB.BackColor = Color.Transparent;
        }

        private void L11_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Lunes_LB.BackColor = Color.White;
            Hora12_LB.BackColor = Color.White;
        }

        private void L11_CB_MouseLeave(object sender, EventArgs e)
        {
            Lunes_LB.BackColor = Color.Transparent;
            Hora12_LB.BackColor = Color.Transparent;
        }

        private void M11_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Martes_LB.BackColor = Color.White;
            Hora12_LB.BackColor = Color.White;
        }

        private void M11_CB_MouseLeave(object sender, EventArgs e)
        {
            Martes_LB.BackColor = Color.Transparent;
            Hora12_LB.BackColor = Color.Transparent;
        }

        private void X11_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Miercoles_LB.BackColor = Color.White;
            Hora12_LB.BackColor = Color.White;
        }

        private void X11_CB_MouseLeave(object sender, EventArgs e)
        {
            Miercoles_LB.BackColor = Color.Transparent;
            Hora12_LB.BackColor = Color.Transparent;
        }

        private void J11_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Jueves_LB.BackColor = Color.White;
            Hora12_LB.BackColor = Color.White;
        }

        private void J11_CB_MouseLeave(object sender, EventArgs e)
        {
            Jueves_LB.BackColor = Color.Transparent;
            Hora12_LB.BackColor = Color.Transparent;
        }

        private void V11_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Viernes_LB.BackColor = Color.White;
            Hora12_LB.BackColor = Color.White;
        }

        private void V11_CB_MouseLeave(object sender, EventArgs e)
        {
            Viernes_LB.BackColor = Color.Transparent;
            Hora12_LB.BackColor = Color.Transparent;
        }

        private void L12_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Lunes_LB.BackColor = Color.White;
            Hora13_LB.BackColor = Color.White;
        }

        private void L12_CB_MouseLeave(object sender, EventArgs e)
        {
            Lunes_LB.BackColor = Color.Transparent;
            Hora13_LB.BackColor = Color.Transparent;
        }

        private void M12_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Martes_LB.BackColor = Color.White;
            Hora13_LB.BackColor = Color.White;
        }

        private void M12_CB_MouseLeave(object sender, EventArgs e)
        {
            Martes_LB.BackColor = Color.Transparent;
            Hora13_LB.BackColor = Color.Transparent;
        }

        private void X12_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Miercoles_LB.BackColor = Color.White;
            Hora13_LB.BackColor = Color.White;
        }

        private void X12_CB_MouseLeave(object sender, EventArgs e)
        {
            Miercoles_LB.BackColor = Color.Transparent;
            Hora13_LB.BackColor = Color.Transparent;
        }

        private void J12_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Jueves_LB.BackColor = Color.White;
            Hora13_LB.BackColor = Color.White;
        }

        private void J12_CB_MouseLeave(object sender, EventArgs e)
        {
            Jueves_LB.BackColor = Color.Transparent;
            Hora13_LB.BackColor = Color.Transparent;
        }

        private void V12_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Viernes_LB.BackColor = Color.White;
            Hora13_LB.BackColor = Color.White;
        }

        private void V12_CB_MouseLeave(object sender, EventArgs e)
        {
            Viernes_LB.BackColor = Color.Transparent;
            Hora13_LB.BackColor = Color.Transparent;
        }

        private void Datos_Instructores_CurrentItemChanged(object sender, EventArgs e)
        {
            //SetDependentControlSource(Instructores_CB.Name);
        }

        private void Instructores_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDependentControlSource(Instructores_CB.Name);
        }

        private void L8AM_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.L8AM = L8AM_CB.Checked;
        }

        private void L8AM_CB_MouseLeave(object sender, EventArgs e)
        {
            Lunes_LB.BackColor = Color.Transparent;
            Hora0_LB.BackColor = Color.Transparent;
        }

        private void L8AM_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Lunes_LB.BackColor = Color.White;
            Hora0_LB.BackColor = Color.White;
        }

        private void M8AM_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.M8AM = M8AM_CB.Checked;
        }

        private void M8AM_CB_MouseLeave(object sender, EventArgs e)
        {
            Martes_LB.BackColor = Color.Transparent;
            Hora0_LB.BackColor = Color.Transparent;
        }

        private void M8AM_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Martes_LB.BackColor = Color.White;
            Hora0_LB.BackColor = Color.White;
        }

        private void X8AM_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.X8AM = X8AM_CB.Checked;
        }

        private void X8AM_CB_MouseLeave(object sender, EventArgs e)
        {
            Miercoles_LB.BackColor = Color.Transparent;
            Hora0_LB.BackColor = Color.Transparent;
        }

        private void X8AM_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Miercoles_LB.BackColor = Color.White;
            Hora0_LB.BackColor = Color.White;
        }

        private void J8AM_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.J8AM = J8AM_CB.Checked;
        }

        private void J8AM_CB_MouseLeave(object sender, EventArgs e)
        {
            Jueves_LB.BackColor = Color.Transparent;
            Hora0_LB.BackColor = Color.Transparent;
        }

        private void J8AM_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Jueves_LB.BackColor = Color.White;
            Hora0_LB.BackColor = Color.White;
        }

        private void V8AM_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (_disponibilidad != null)
                _disponibilidad.V8AM = V8AM_CB.Checked;
        }

        private void V8AM_CB_MouseLeave(object sender, EventArgs e)
        {
            Viernes_LB.BackColor = Color.Transparent;
            Hora0_LB.BackColor = Color.Transparent;
        }

        private void V8AM_CB_MouseMove(object sender, MouseEventArgs e)
        {
            Viernes_LB.BackColor = Color.White;
            Hora0_LB.BackColor = Color.White;
        }

        
    }
}

