using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Face;
using moleQule.Library;
using moleQule.Library.Instruction;

namespace moleQule.Face.Instruction
{
    public partial class HorarioViewForm : HorarioForm,
                                        moleQule.Library.IBackGroundLauncher
    {
        #region Properties

        protected override int BarSteps { get { return base.BarSteps + 11; } }

        #endregion

        #region Business Methods

        /// <summary>
        /// Se trata del objeto actual.
        /// </summary>
        private HorarioInfo _entity;

        public override HorarioInfo EntityInfo { get { return _entity; } }
        
		#endregion

		#region Factory Methods

		/// <summary>
		/// Declarado por exigencia del entorno. No Utilizar.
		/// </summary>
		protected HorarioViewForm() : this(-1, true, null) { }

		public HorarioViewForm(bool isModal, Form parent) : this(-1, isModal, parent) { }

		public HorarioViewForm(long oid, Form parent) : this(oid, true, parent) { }


        public HorarioViewForm(long oid, bool ismodal, Form parent)
            : base(oid, ismodal, parent)
        {
            InitializeComponent();
            _is_modal = false;
            if (EntityInfo != null)
            {
                SetFormData();
                this.Text = Resources.Labels.HORARIO_EDIT_TITLE + " " + EntityInfo.FechaInicial.ToShortDateString() + " A " + EntityInfo.FechaFinal.ToShortDateString();
            }
            _mf_type = ManagerFormType.MFView;
            //RellenaCasillas();
            PgMng.Grow(string.Empty, "Rellenar Casillas");
        }


        protected override void GetFormSourceData(long oid)
        {
            _entity = HorarioInfo.Get(oid, true);
            _mf_type = ManagerFormType.MFView;
        }
        
		#endregion

        #region IBackGroundLauncher

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
                    case BackJob.Horario:
                        DoHorario();
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
                
        protected void DoHorario()
        {

            try
            {
                PgMng.Reset(12, 1, Resources.Messages.UPDATING_PROMOCION_HORARIO, this);
                //Se rellena lo referente al plan
                if (_planes == null) return;

                if (EntityInfo.Plan == null)
                    Plan_CB.Text = _planes.GetItem(EntityInfo.OidPlan).Nombre;
                else
                    Plan_CB.Text = EntityInfo.Plan;
                PgMng.Grow(string.Empty, "Plan");

                //Se rellena lo referente a la promoción
                if (_promociones == null) return;

                if (EntityInfo.Promocion != string.Empty && EntityInfo.Promocion != null)
                    Promocion_CB.Text = EntityInfo.Promocion;
                else
                    Promocion_CB.Text = _promociones.GetItem(EntityInfo.OidPromocion).Nombre;
                PgMng.Grow(string.Empty, "Promocion");

                DateTime hoy = DateTime.Today;

                // si la fecha del horario que se va a cargar es anterior a la del día en el que se edita
                // no se tiene en cuenta si las clases sesiones planificadas se han impartido o no para meterlas
                // en las lista, ya que de ningún modo se va a permitir modificar un horario antiguo
                if (hoy.Date >= EntityInfo.FechaInicial)
                {
                    hoy = EntityInfo.FechaInicial;
                }
                else
                {
                    while (hoy.DayOfWeek != DayOfWeek.Monday)
                        hoy = hoy.AddDays(-1);
                }
                PgMng.Grow(string.Empty, "Hoy");

                for (int i = 1; i < 3; i++)
                    if (_practicas.Count <= i)
                        _practicas.Add(ClasePracticaList.GetDisponiblesList(EntityInfo.OidPlan, EntityInfo.OidPromocion, EntityInfo.Oid, i));
                if (_teoricas == null)
                    _teoricas = ClaseTeoricaList.GetDisponiblesList(EntityInfo.OidPlan, EntityInfo.OidPromocion, EntityInfo.Oid);
                if (_extras == null)
                    _extras = ClaseExtraList.GetDisponiblesList(EntityInfo.OidPromocion, EntityInfo.Oid);
                PgMng.Grow(string.Empty, "clases");

                _day = Fecha_DTP.Value;
                while (_day.DayOfWeek != System.DayOfWeek.Monday)
                    _day = _day.AddDays(-1);

                this.Text = Resources.Labels.HORARIO_ADD_TITLE +
                                "De Lunes, " + _day.ToShortDateString() +
                                " A Sábado, " + _day.AddDays(5).ToShortDateString();

                if (_day < Fecha_DTP.MinDate)
                    Fecha_DTP.Value = Fecha_DTP.MinDate;
                else
                    Fecha_DTP.Value = _day;
                PgMng.Grow(string.Empty, "Fecha_DTP");

                if (_instructores_asignados == null)
                    _instructores_asignados = Sesion.CargaSesionesProfesores(EntityInfo.FechaInicial, EntityInfo.OidPromocion);
                if (_profesores == null)
                    _profesores = InstructorList.GetList(true);

                _disponibilidades = _profesores.GetDisponibilidadesProfesores(_entity.FechaInicial);
                PgMng.Grow(string.Empty, "Instructores y profesores");

                CLB_1.SetItemChecked(0, EntityInfo.H8AM);
                CLB_1.SetItemChecked(1, EntityInfo.H0);
                CLB_1.SetItemChecked(2, EntityInfo.H1);
                CLB_1.SetItemChecked(3, EntityInfo.H2);
                CLB_1.SetItemChecked(4, EntityInfo.H3);
                CLB_1.SetItemChecked(5, EntityInfo.H4);
                CLB_1.SetItemChecked(6, EntityInfo.H5);
                CLB_1.SetItemChecked(7, EntityInfo.H6);
                CLB_1.SetItemChecked(8, EntityInfo.H7);
                CLB_1.SetItemChecked(9, EntityInfo.H8);
                CLB_1.SetItemChecked(10, EntityInfo.H9);
                CLB_1.SetItemChecked(11, EntityInfo.H10);
                CLB_1.SetItemChecked(12, EntityInfo.H11);
                CLB_1.SetItemChecked(13, EntityInfo.H12);

                CLB_2.SetItemChecked(0, EntityInfo.Hs0);
                CLB_2.SetItemChecked(1, EntityInfo.Hs1);
                CLB_2.SetItemChecked(2, EntityInfo.Hs2);
                CLB_2.SetItemChecked(3, EntityInfo.Hs3);
                CLB_2.SetItemChecked(4, EntityInfo.Hs4);
                PgMng.Grow(string.Empty, "Lista horas");

                //Se rellena la fecha
                Fecha_DTP.Value = EntityInfo.FechaInicial;
                this.Text = Resources.Labels.HORARIO_ADD_TITLE +
                    "De Lunes, " + EntityInfo.FechaInicial.ToShortDateString() +
                    " A Sábado, " + EntityInfo.FechaInicial.AddDays(5).ToShortDateString();
                PgMng.Grow(string.Empty, "string fechas");

                //Se rellena el horario
                if (_lista_sesiones == null)
                {
                    _lista_sesiones = new ListaSesiones(EntityInfo.FechaInicial);
                    //ResetSesiones(false);
                    PgMng.Grow(string.Empty, "lista sesiones");

                    Horario.MuestraSesiones(EntityInfo.Sesions, _lista_sesiones, _teoricas, ClasePracticaList.Merge(_practicas[1], _practicas[2]), _extras);
                }

                Confirmar_BT.Enabled = true;
                Marcar_BT.Enabled = true;
                Generar_BT.Enabled = true;
                PgMng.Grow(string.Empty, "MuestraSesiones");

                if (_combo_clases == null)
                    _combo_clases = Submodulo.GetComboClases(_teoricas, ClasePracticaList.Merge(_practicas[1], _practicas[2]), _extras);
                _combo_clases.Childs = _combo_instructores;
                Datos_Clases.DataSource = _combo_clases;
                PgMng.Grow(string.Empty, "combo_clases");

                Lunes_LB.Text = "LUNES (" + EntityInfo.FechaInicial.Day.ToString("00") + "/" +
                    EntityInfo.FechaInicial.Month.ToString("00") + ")";
                Martes_LB.Text = "MARTES (" + EntityInfo.FechaInicial.AddDays(1).Day.ToString("00") + "/" +
                    EntityInfo.FechaInicial.AddDays(1).Month.ToString("00") + ")";
                Miercoles_LB.Text = "MIÉRCOLES (" + EntityInfo.FechaInicial.AddDays(2).Day.ToString("00") + "/" +
                    EntityInfo.FechaInicial.AddDays(2).Month.ToString("00") + ")";
                Jueves_LB.Text = "JUEVES (" + EntityInfo.FechaInicial.AddDays(3).Day.ToString("00") + "/" +
                    EntityInfo.FechaInicial.AddDays(3).Month.ToString("00") + ")";
                Viernes_LB.Text = "VIERNES (" + EntityInfo.FechaInicial.AddDays(4).Day.ToString("00") + "/" +
                    EntityInfo.FechaInicial.AddDays(4).Month.ToString("00") + ")";
                Sabado_LB.Text = "SÁBADO (" + EntityInfo.FechaInicial.AddDays(5).Day.ToString("00") + "/" +
                    EntityInfo.FechaInicial.AddDays(5).Month.ToString("00") + ")";
            }
            finally
            {
                PgMng.FillUp();
            }
        }

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            Plan_CB.Enabled = false;
            Promocion_CB.Enabled = false;
            Fecha_DTP.Enabled = false;
            Generar_BT.Enabled = false;
            Marcar_BT.Enabled = false;
            DiasSuplente.Enabled = false;
            Confirmar_BT.Enabled = false;
            Completar_BT.Enabled = false;
            Clean_BT.Enabled = false;
            Hojas_BT.Enabled = true;
            Horario_Lunes_Grid.ReadOnly = true;
            Horario_Martes_Grid.ReadOnly = true;
            Horario_Miercoles_Grid.ReadOnly = true;
            Horario_Jueves_Grid.ReadOnly = true;
            Horario_Viernes_Grid.ReadOnly = true;
            Horario_Sabado_Grid.ReadOnly = true;
            Imprimir_Button.Enabled = true;
            Imprimir_Button.Visible = true;

            base.FormatControls();

            ResetSesiones(false);
            _generado = true;
            RefreshChildren = true;
        }

        /// <summary>
        /// Asigna los datos de origen para controles que dependen de otros
        /// </summary>
        /// <param name="controlName"></param>
        protected override void SetDependentControlSource(string controlName)
        {
            switch (controlName)
            {
                case "Horario_GB":
                    {
                        if (_lista_sesiones == null)
                        {
                            /*
                            PgMng.Reset(11, 1, Resources.Messages.UPDATING_PROMOCION_HORARIO, this);
                            _back_job = BackJob.Horario;
                            PgMng.StartBackJob(this);
                            PgMng.FillUp();*/
                            DoHorario();
                        }
                    } break;
            }
        }
        
        public override void RefreshSecondaryData()
        {
            base.RefreshSecondaryData();

            _planes = PlanEstudiosList.GetList(false);
            PgMng.Grow(string.Empty, "Planes de Estudio");

            _combo_planes = new Library.Instruction.HComboBoxSourceList(_planes);
            PgMng.Grow(string.Empty, "ComboBox Planes de Estudio");

            _promociones = PromocionList.GetList(false);
            PgMng.Grow(string.Empty, "Promociones");

            _combo_planes.Childs = new Library.Instruction.HComboBoxSourceList(_promociones);
            PgMng.Grow(string.Empty, "ComboBox de Promociones");

            Datos_Planes.DataSource = _combo_planes;
            PgMng.Grow(string.Empty, "Datos_Planes");

            _no_asignables = new List<SesionNoAsignable>();
            PgMng.Grow();
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity;
            PgMng.Grow(string.Empty, "Datos");

            //SetDependentControlSource(Fecha_DTP.Name);
            //PgMng.Grow(string.Empty, "Esquema de datos Fecha del Horario");

            SetDependentControlSource(Horario_GB.Name);
            PgMng.Grow(string.Empty, "Esquema de Datos de Horario");

            relleno_automatico = false;

            Lunes_LB.Text = "LUNES (" + EntityInfo.FechaInicial.Day.ToString("00") + "/" +
                EntityInfo.FechaInicial.Month.ToString("00") + ")";
            Martes_LB.Text = "MARTES (" + EntityInfo.FechaInicial.AddDays(1).Day.ToString("00") + "/" +
                EntityInfo.FechaInicial.AddDays(1).Month.ToString("00") + ")";
            Miercoles_LB.Text = "MIÉRCOLES (" + EntityInfo.FechaInicial.AddDays(2).Day.ToString("00") + "/" +
                EntityInfo.FechaInicial.AddDays(2).Month.ToString("00") + ")";
            Jueves_LB.Text = "JUEVES (" + EntityInfo.FechaInicial.AddDays(3).Day.ToString("00") + "/" +
                EntityInfo.FechaInicial.AddDays(3).Month.ToString("00") + ")";
            Viernes_LB.Text = "VIERNES (" + EntityInfo.FechaInicial.AddDays(4).Day.ToString("00") + "/" +
                EntityInfo.FechaInicial.AddDays(4).Month.ToString("00") + ")";
            Sabado_LB.Text = "SÁBADO (" + EntityInfo.FechaInicial.AddDays(5).Day.ToString("00") + "/" +
                EntityInfo.FechaInicial.AddDays(5).Month.ToString("00") + ")";

        }

        public void ResetSesiones(bool limpiar)
        {
            ClasePracticaList practicas = null;
            if (_practicas.Count > 1)
                practicas = ClasePracticaList.Merge(_practicas[1], _practicas[2]);
            _combo_clases = Submodulo.GetComboClases(_teoricas, practicas, _extras);
            _combo_clases.Childs = _combo_instructores;
            Datos_Clases.DataSource = _combo_clases;

            if (_teoricas != null && _practicas != null && _extras != null && _generado)
            {
                foreach (ClaseTeoricaInfo clase in _teoricas)
                    clase.Estado = 1;
                foreach (ClasePracticaList lista in _practicas)
                    foreach (ClasePracticaInfo clase in lista)
                        clase.Estado = 1;
                foreach (ClaseExtraInfo clase in _extras)
                    clase.Estado = 1;
            }

            if (_lista_sesiones != null && limpiar && _generado)
            {
                foreach (SesionAuxiliar sesion in _lista_sesiones)
                    sesion.AsignaClaseASesion((ClaseTeoricaInfo)null);
            }

            _no_asignables = new List<SesionNoAsignable>();

            if (_lista_sesiones != null)
                RellenaCasillas();
        }

        public override ComboBoxSourceList RellenaComboInstructores(long oid, long tipo, int index, long oid_submodulo)
        {
            _combo_instructores = new Library.Instruction.HComboBoxSourceList(_profesores);

            Datos_Instructores.DataSource = _combo_instructores;
            return _combo_instructores;
        }

        #endregion

        #region Print

        public override void PrintObject()
        {
            PrintSource seleccion = PrintSource.All;
            bool alumno = false;

            HorarioPrintSelectForm form = new HorarioPrintSelectForm(seleccion);
            DialogResult result = form.ShowDialog();

            if (result != DialogResult.Cancel)
            {
                if (form.Source == PrintSource.Selection)
                    alumno = true;
                CronogramaReportMng reportMng = new CronogramaReportMng(AppContext.ActiveSchema);
                Library.Reports.CRViewer viewer = new Library.Reports.CRViewer();
                ModuloList modulos = ModuloList.GetList(false);
                viewer.SetReport(reportMng.GetHorarioReport(EntityInfo, alumno, _teoricas, _practicas, _extras, _profesores, modulos, _lista_sesiones, form.PrintTimestamp, form.Timestamp));
                viewer.ShowDialog();
            }
        }

        #endregion

        #region Actions

        protected override void SaveAction() { _action_result = DialogResult.Cancel; }
        
        /// <summary>
        /// Implementa Undo_button_Click
        /// </summary>
        protected override void CancelAction()
        {
            _action_result = DialogResult.Cancel;
            CancelBackGroundJob(); 
        }
        
        #endregion

        #region Events

        private void Hojas_BT_Click(object sender, EventArgs e)
        {
            PrintSource seleccion = PrintSource.All;
            bool alumno = false;

            PartesPrintSelectForm form = new PartesPrintSelectForm(seleccion);
            DialogResult result = form.ShowDialog();

            if (result != DialogResult.Cancel)
            {
                if (form.Source == PrintSource.Selection)
                    alumno = true;
            }

            CronogramaReportMng reportMng = new CronogramaReportMng(AppContext.ActiveSchema);

            AlumnoList lista = AlumnoList.GetListByPromocion(_entity.OidPromocion, false);

            foreach (ParteAsistenciaInfo item in _entity.Asistencias)
            {
                AlumnoList alumnos = null;
                SesionInfo sesion = null;

                foreach (SesionInfo ses in _entity.Sesions)
                {
                    if (ses.Fecha.ToShortDateString() == item.Fecha.ToShortDateString()
                        && ses.Hora.ToShortTimeString() == DateTime.Parse(item.HoraInicio).ToShortTimeString())
                    {
                        sesion = ses;
                        break;
                    }
                }

                alumnos = AlumnoList.CreateAlumnosList(lista, item.Alumno_Partes);

                if (item.Sesiones != string.Empty && alumnos.Count > 0)
                {
                    if (item.Tipo == 2 || sesion.OidClasePractica > 0)
                        ReportViewer.SetReport(reportMng.GetDetailPracticasReport(sesion, alumnos, item.NHoras,
                            _teoricas, /*ClasePracticaList.Merge(_practicas[1], _practicas[2])*/
                            ClasePracticaList.GetClasesPlanList(_entity.OidPlan), _extras, item.Texto, _entity.OidPromocion, alumno));
                    else
                        ReportViewer.SetReport(reportMng.GetDetailTeoricasReport(sesion, alumnos, item.NHoras,
                            _teoricas, ClasePracticaList.Merge(_practicas[1], _practicas[2]), _extras, item.Texto, _entity.OidPromocion, alumno));
                }

                ReportViewer.ShowDialog();
            }

        }

        #endregion

    }
}
