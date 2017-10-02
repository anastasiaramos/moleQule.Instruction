using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;

using moleQule.Face;
using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Instruction;
using moleQule.Library.Store;

namespace moleQule.Face.Instruction
{
    public partial class HorarioEditForm : HorarioUIForm,
                                            moleQule.Library.IBackGroundLauncher
    {
        #region Properties

        protected override int BarSteps { get { return base.BarSteps + 12; } }

        #endregion

        #region Factory Methods

        public HorarioEditForm(long oid, Form parent)
			: this(oid, true, parent) { }

		public HorarioEditForm(long oid, bool ismodal, Form parent)
			: base(oid, ismodal, parent)
		{
            PgMng.Reset(BarSteps, 1, Resources.Messages.LOADING_DATA, this);
			InitializeComponent();
            _is_modal = ismodal;
			if (Entity != null)
			{
				SetFormData();
				this.Text = Resources.Labels.HORARIO_EDIT_TITLE + " " + Entity.FechaInicial.ToShortDateString() + " A " + Entity.FechaFinal.ToShortDateString();
			}
			_mf_type = ManagerFormType.MFEdit;
            //RellenaCasillas();
            PgMng.FillUp();//.Grow(string.Empty, "Rellenar Casillas");
		}

		protected override void GetFormSourceData(long oid)
		{
			_entity = Horario.Get(oid);
			_entity.BeginEdit();
			_mf_type = ManagerFormType.MFEdit;
		}

		#endregion

		#region Business Methods

		protected override bool CreaSesiones()
        {
            //Sesions lista = _entity.Sesions;

            //_entity.Sesions = Sesions.NewChildList();

            PgMng.Reset(72, 1, Resources.Messages.GENERANDO_SESIONES, this);

            try
            {

                if (_profesores == null)
                    _profesores = InstructorList.GetInstructoresHorariosList(EntityInfo.OidPromocion, EntityInfo.FechaInicial, EntityInfo.FechaFinal);
                PgMng.Grow();

                foreach (SesionAuxiliar item in _lista_sesiones)
                {
                    bool encontrada = false;
                    foreach (Sesion ses in _entity.Sesions)
                    {
                        if (ses.Fecha.ToShortDateString() == item.Fecha.ToShortDateString()
                            && ses.Hora.ToShortTimeString() == item.Hora.ToShortTimeString())
                        {
                            /*if (item.OidProfesor == 0)
                            {
                                foreach (InstructorInfo p in _profesores)
                                {
                                    bool salir = false;
                                    foreach (Instructor_PromocionInfo pr in p.Promociones)
                                    {
                                        if (pr.OidPromocion == Entity.OidPromocion)
                                        {
                                            foreach (Submodulo_Instructor_PromocionInfo sub in pr.Submodulos)
                                            {
                                                if (sub.OidSubmodulo == item.OidSubmodulo && sub.Prioridad == 1)
                                                {
                                                    ses.OidProfesor = p.Oid;
                                                    salir = true;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    if (salir) break;
                                }
                            }
                            else*/
                            ses.OidProfesor = item.OidProfesor;

                            ses.OidClaseTeorica = item.OidClaseTeorica;
                            ses.OidClasePractica = item.OidClasePractica;
                            ses.OidClaseExtra = item.OidClaseExtra;
                            ses.Fecha = DateTime.Parse(item.Fecha.ToShortDateString() + " " + ses.Fecha.ToShortTimeString());
                            ses.Hora = item.Hora;
                            ses.Forzada = item.Forzada;
                            ses.Estado = item.Estado;
                            ses.Grupo = item.Grupo;

                            //_entity.Sesions.AddItem(ses);

                            encontrada = true;
                            break;
                        }
                    }

                    if (!encontrada)
                    {
                        Sesion nueva = Sesion.NewChild(_entity);

                        nueva.OidProfesor = item.OidProfesor;

                        nueva.OidClaseTeorica = item.OidClaseTeorica;
                        nueva.OidClasePractica = item.OidClasePractica;
                        nueva.OidClaseExtra = item.OidClaseExtra;
                        nueva.Fecha = item.Fecha;
                        nueva.Hora = item.Hora;
                        nueva.Forzada = item.Forzada;
                        nueva.Estado = item.Estado;
                        nueva.Grupo = item.Grupo;
                        nueva.MarkItemChild();

                        _entity.Sesions.AddItem(nueva);
                    }
                    PgMng.Grow();
                }

                return true;
            }
            catch { return false; }
            finally { PgMng.FillUp(); }
		}

		#endregion

        #region IBackGroundLauncher

        protected override void DoHorario()
        {
            try
            {
                PgMng.Reset(12, 1, Resources.Messages.UPDATING_PROMOCION_HORARIO, this);
                //Se rellena lo referente al plan
                if (_planes == null) return;

                if (Entity.Plan == null)
                    Plan_CB.Text = _planes.GetItem(Entity.OidPlan).Nombre;
                else
                    Plan_CB.Text = Entity.Plan;
                PgMng.Grow(string.Empty, "Plan");

                //Se rellena lo referente a la promoción
                if (_promociones == null) return;

                if (Entity.Promocion != string.Empty && Entity.Promocion != null)
                    Promocion_CB.Text = Entity.Promocion;
                else
                    Promocion_CB.Text = _promociones.GetItem(Entity.OidPromocion).Nombre;
                PgMng.Grow(string.Empty, "Promocion");

                DateTime hoy = DateTime.Today;

                // si la fecha del horario que se va a cargar es anterior a la del día en el que se edita
                // no se tiene en cuenta si las clases sesiones planificadas se han impartido o no para meterlas
                // en las lista, ya que de ningún modo se va a permitir modificar un horario antiguo
                if (hoy.Date >= Entity.FechaInicial)
                {
                    hoy = Entity.FechaInicial;
                }
                else
                {
                    while (hoy.DayOfWeek != DayOfWeek.Monday)
                        hoy = hoy.AddDays(-1);
                }
                PgMng.Grow(string.Empty, "Hoy");

                for (int i = 1; i < 3; i++)
                    if (_practicas.Count <= i)
                        _practicas.Add(ClasePracticaList.GetDisponiblesList(Entity.OidPlan, Entity.OidPromocion, Entity.Oid, i));
                if (_teoricas == null)
                    _teoricas = ClaseTeoricaList.GetDisponiblesList(Entity.OidPlan, Entity.OidPromocion, Entity.Oid);
                if (_extras == null)
                    _extras = ClaseExtraList.GetDisponiblesList(Entity.OidPromocion, Entity.Oid);
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
                    _instructores_asignados = Sesion.CargaSesionesProfesores(Entity.FechaInicial, Entity.OidPromocion);
                if (_profesores == null)
                    _profesores = InstructorList.GetInstructoresHorariosList(EntityInfo.OidPromocion, EntityInfo.FechaInicial, EntityInfo.FechaFinal);

                _disponibilidades = _profesores.GetDisponibilidadesProfesores(_entity.FechaInicial);
                PgMng.Grow(string.Empty, "Instructores y profesores");

                CLB_1.SetItemChecked(0, Entity.H8AM);
                CLB_1.SetItemChecked(1, Entity.H0);
                CLB_1.SetItemChecked(2, Entity.H1);
                CLB_1.SetItemChecked(3, Entity.H2);
                CLB_1.SetItemChecked(4, Entity.H3);
                CLB_1.SetItemChecked(5, Entity.H4);
                CLB_1.SetItemChecked(6, Entity.H5);
                CLB_1.SetItemChecked(7, Entity.H6);
                CLB_1.SetItemChecked(8, Entity.H7);
                CLB_1.SetItemChecked(9, Entity.H8);
                CLB_1.SetItemChecked(10, Entity.H9);
                CLB_1.SetItemChecked(11, Entity.H10);
                CLB_1.SetItemChecked(12, Entity.H11);
                CLB_1.SetItemChecked(13, Entity.H12);

                CLB_2.SetItemChecked(0, Entity.HS0);
                CLB_2.SetItemChecked(1, Entity.HS1);
                CLB_2.SetItemChecked(2, Entity.HS2);
                CLB_2.SetItemChecked(3, Entity.HS3);
                CLB_2.SetItemChecked(4, Entity.HS4);
                PgMng.Grow(string.Empty, "Lista horas");

                //Se rellena la fecha
                Fecha_DTP.Value = Entity.FechaInicial;
                this.Text = Resources.Labels.HORARIO_ADD_TITLE +
                    "De Lunes, " + Entity.FechaInicial.ToShortDateString() +
                    " A Sábado, " + Entity.FechaInicial.AddDays(5).ToShortDateString();
                PgMng.Grow(string.Empty, "string fechas");

                //Se rellena el horario
                if (_lista_sesiones == null)
                {
                    _lista_sesiones = new ListaSesiones(Entity.FechaInicial);
                    //ResetSesiones(false);
                    PgMng.Grow(string.Empty, "lista sesiones");

                    Horario.MuestraSesiones(Entity.Sesions, _lista_sesiones, _teoricas, ClasePracticaList.Merge(_practicas[1], _practicas[2]), _extras);
                }

                //_lista_sesiones = Entity.SetSesionesActivas(_lista_sesiones);

                Confirmar_BT.Enabled = true;
                Marcar_BT.Enabled = true;
                Generar_BT.Enabled = true;
                Clean_BT.Enabled = true;
                PgMng.Grow(string.Empty, "MuestraSesiones");

                if (_combo_clases == null)
                    _combo_clases = Submodulo.GetComboClases(_teoricas, ClasePracticaList.Merge(_practicas[1], _practicas[2]), _extras);
                _combo_clases.Childs = _combo_instructores;
                Datos_Clases.DataSource = _combo_clases;
                PgMng.Grow(string.Empty, "combo_clases");

                Lunes_LB.Text = "LUNES (" + EntityInfo.FechaInicial.Day.ToString("00") + "/" +
                    Entity.FechaInicial.Month.ToString("00") + ")";
                Martes_LB.Text = "MARTES (" + EntityInfo.FechaInicial.AddDays(1).Day.ToString("00") + "/" +
                    Entity.FechaInicial.AddDays(1).Month.ToString("00") + ")";
                Miercoles_LB.Text = "MIÉRCOLES (" + EntityInfo.FechaInicial.AddDays(2).Day.ToString("00") + "/" +
                    Entity.FechaInicial.AddDays(2).Month.ToString("00") + ")";
                Jueves_LB.Text = "JUEVES (" + EntityInfo.FechaInicial.AddDays(3).Day.ToString("00") + "/" +
                    Entity.FechaInicial.AddDays(3).Month.ToString("00") + ")";
                Viernes_LB.Text = "VIERNES (" + EntityInfo.FechaInicial.AddDays(4).Day.ToString("00") + "/" +
                    Entity.FechaInicial.AddDays(4).Month.ToString("00") + ")";
                Sabado_LB.Text = "SÁBADO (" + EntityInfo.FechaInicial.AddDays(5).Day.ToString("00") + "/" +
                    Entity.FechaInicial.AddDays(5).Month.ToString("00") + ")";
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
			base.FormatControls();

            ResetSesiones(false);
			_generado = true;
			Plan_CB.Enabled = false;
			Promocion_CB.Enabled = false;
            Fecha_DTP.Enabled = false;
            Instructores_BT.Enabled = true;
            Planes_BT.Enabled = true;
            Disponibilidades_BT.Enabled = true;
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

        protected override bool CrearPartes()
        {
            int count = 0;
            long oid_modulo = 0;
            int index = 0;
            long tipo = 0;

            PgMng.Reset(6, 1, Resources.Messages.CREANDO_PARTES_ASISTENCIA, this);

            try
            {
                PromocionInfo promo = PromocionInfo.Get(_entity.OidPromocion, true);
                AlumnoList alumnos = AlumnoList.GetListByPromocion(promo.Oid, true);

                if (promo.Sesiones.Count == 0)
                {
                    Promocion promocion = Promocion.Get(_entity.OidPromocion, false);
                    promocion.LoadChilds(typeof(Sesion_Promocion));
                    List<List<long>> duracion_sesiones = _entity.RellenaHorasSemana();
                    foreach (List<long> lista in duracion_sesiones)
                    {
                        foreach (long item in lista)
                        {
                            Sesion_Promocion ses = Sesion_Promocion.NewChild(promocion);
                            ses.NHoras = duracion_sesiones.IndexOf(lista) + 1;
                            if (item > 69)
                                ses.Sabado = true;
                            ses.HoraInicio = DateTime.Parse((item % 14 + 10).ToString("00") + ":00");
                            promocion.Sesiones.Add(ses);
                        }
                    }
                    promo = promocion.GetInfo(true);
                    promocion.CloseSession();
                }
                PgMng.Grow();

                if (!_entity.IsDirty) return true;

                //guarda la lista de partes de asistencia anterior
                ParteAsistencias partes = _entity.Asistencias.Clone();

                InputDeliveryList albaranes = InputDeliveryList.GetList(true
                                                                , ETipoAcreedor.Instructor
                                                                , new DateTime(_entity.FechaInicial.Year, _entity.FechaInicial.Month, 1, 0, 0, 0)
                                                                , new DateTime(_entity.FechaFinal.Year, _entity.FechaFinal.Month, DateTime.DaysInMonth(_entity.FechaFinal.Year, _entity.FechaFinal.Month), 0,0,0));
                PgMng.Grow();

                ParteAsistencias nueva = ParteAsistencias.NewChildList();
                HorarioInfo horario_old = HorarioInfo.Get(_entity.Oid, true);

                //genera la nueva lista de partes de asistencia
                for (int sesion_ind = 0; sesion_ind<_entity.Sesions.Count;sesion_ind++)
                {
                    Sesion item = _entity.Sesions[sesion_ind];

                    bool confirmada = false;

                    if (item.OidClasePractica != 0)
                    {
                        bool incluida = false;

                        foreach (ParteAsistencia parte_practicas in nueva)
                        {
                            if (parte_practicas.Tipo == 2)
                            {
                                ClasePracticaInfo p_info = _practicas[(int)item.Grupo].GetItem(item.OidClasePractica);
                                if (p_info != null &&
                                    (parte_practicas.Texto.Trim() == p_info.Alias.Trim() + "G" + item.Grupo.ToString()
                                    || parte_practicas.Texto.Trim() == p_info.Alias.Trim()))
                                {
                                    incluida = true;
                                    break;
                                }
                            }
                        }

                        if (incluida)
                            continue;
                    }

                    //Se busca un parte de asistencias confirmado que contenga esta clase
                    foreach (ParteAsistencia parte_old in partes)
                    {
                        DateTime hora_sesion = DateTime.Parse(parte_old.HoraInicio);

                        if (parte_old.Fecha.Date == item.Fecha.Date
                            && hora_sesion.Hour == item.Hora.Hour
                            && parte_old.Confirmada)
                        {
                            int n_horas = DateTime.Parse(parte_old.NHoras).Hour;

                            for (int horas_ind = 0; horas_ind < n_horas; horas_ind++)
                            {
                                if (!_entity.Sesions[sesion_ind + horas_ind].IsEqual(horario_old.Sesions[sesion_ind + horas_ind]))
                                    return false;
                            }

                            //se trata de una teórica o una extra y no hay que comprobar que en ese intervalo exista otra sesión
                            if (item.OidClasePractica == 0)
                                sesion_ind += n_horas - 1;

                            nueva.Add(parte_old);
                            confirmada = true;
                            break;
                        }
                    }

                    if (confirmada)
                        continue;

                    //Desmarca las clases que han sido marcadas como impartidas pero que tienen 
                    //fecha y horas mayor que la actual
                    if (item.Fecha.Date > DateTime.Today.Date
                        && item.Estado == 3)
                        item.Estado = 2;

                    //si ya hay un parte para esta práctica no se vuelve a crear
                    if (item.OidClasePractica > 0)
                    {
                        bool esta = false;
                        foreach (ParteAsistencia p in nueva)
                        {
                            foreach (Clase_Parte cp in p.Clases)
                            {
                                if (cp.Tipo == 2
                                    && cp.OidClase == item.OidClasePractica
                                    && (cp.Grupo == 3 || cp.Grupo == item.Grupo))
                                {
                                    esta = true;
                                    break;
                                }
                            }

                        }
                        if (esta) continue;
                    }

                    if ((item.OidClaseTeorica > 0
                        || item.OidClasePractica > 0
                        || item.OidClaseExtra > 0)
                        && !item.IsDeleted)
                    {
                        string aux = string.Empty;
                        long oid_modulo_item = 0;
                        string sesion = string.Empty;
                        long oid_clase = 0;
                        long grupo = 3;

                        if (item.OidClasePractica != 0)
                        {
                            ClasePracticaInfo clase = null;

                            clase = _practicas[(int)item.Grupo].GetItem(item.OidClasePractica);
                            oid_modulo_item = clase.OidModulo;
                            aux = clase.Alias + " G" + item.Grupo.ToString();
                            sesion = clase.Oid.ToString();
                            tipo = 2;
                            grupo = clase.Grupo;
                            oid_clase = clase.Oid;
                        }
                        if (item.OidClaseTeorica != 0)
                        {
                            ClaseTeoricaInfo clase = _teoricas.GetItem(item.OidClaseTeorica);
                            oid_modulo_item = clase.OidModulo;
                            aux = clase.Alias;
                            sesion = clase.Oid.ToString();
                            tipo = 1;
                            oid_clase = clase.Oid;
                        }
                        if (item.OidClaseExtra != 0)
                        {
                            ClaseExtraInfo clase = _extras.GetItem(item.OidClaseExtra);
                            oid_modulo_item = clase.OidModulo;
                            aux = clase.Alias;
                            sesion = clase.Oid.ToString();
                            tipo = 3;
                            oid_clase = clase.Oid;
                        }

                        if (oid_modulo_item != 0)
                        {
                            if (item.OidClasePractica == 0)
                            {
                                foreach (Sesion_PromocionInfo ses in promo.Sesiones)
                                {
                                    if (ses.HoraInicio.TimeOfDay == item.Hora.TimeOfDay)
                                    {
                                        count = 0;
                                        break;
                                    }
                                }
                            }

                            if (count == 0)
                            {
                                ParteAsistencia parte = ParteAsistencia.NewChild(_entity);
                                parte.Tipo = tipo;
                                parte.Texto = aux + " ";
                                parte.Sesiones = sesion + " ";
                                parte.Fecha = item.Fecha;
                                parte.HoraInicio = item.Hora.ToString("HH:mm");
                                parte.OidInstructor = item.OidProfesor;
                                parte.OidInstructorEfectivo = item.OidProfesor;
                                parte.CreateAlumnosList(alumnos, item.Grupo);
                                if (index == _entity.Sesions.Count - 1)
                                    parte.NHoras = count.ToString() + ":00";
                                parte.MarkItemChild();
                                nueva.AddItem(parte);
                                oid_modulo = oid_modulo_item;
                                count++;
                                if (tipo == 2)
                                {
                                    nueva[nueva.Count - 1].NHoras = "5:00";
                                    nueva[nueva.Count - 1].CreatePartePracticas(item.OidClasePractica);
                                }
                                else
                                    nueva[nueva.Count - 1].NHoras = count.ToString() + ":00";
                            }
                            else
                            {
                                ParteAsistencia ultima = nueva[nueva.Count - 1];

                                if (ultima.OidHorario == item.OidHorario
                                    && ultima.Fecha.Date.Equals(item.Fecha.Date)
                                    && Convert.ToDateTime(ultima.HoraInicio).AddHours(count).Hour.Equals(item.Hora.Hour)
                                    && ultima.OidInstructor == item.OidProfesor
                                    && oid_modulo_item == oid_modulo 
                                    && ((ultima.Tipo == 1 && item.OidClaseTeorica > 0)
                                        || (ultima.Tipo == 2 && item.OidClasePractica > 0)
                                        || (ultima.Tipo == 3 && item.OidClaseExtra > 0)))
                                {
                                    count++;
                                    sesion += " ";
                                    if ((item.OidClasePractica > 0 && nueva[nueva.Count - 1].Sesiones != sesion)
                                        || item.OidClasePractica == 0)
                                    {
                                        nueva[nueva.Count - 1].Texto += aux + " ";
                                        nueva[nueva.Count - 1].Sesiones += sesion;
                                        nueva[nueva.Count - 1].NHoras = count.ToString() + ":00";
                                        if (index == _entity.Sesions.Count - 1)
                                            count = 0;
                                    }
                                    else
                                    {
                                        ClasePracticaInfo clase = null;
                                        clase = _practicas[(int)item.Grupo].GetItem(item.OidClasePractica);
                                        string texto_aux = clase.Alias + " G" + item.Grupo.ToString() + " ";
                                        if (nueva[nueva.Count - 1].Texto != texto_aux)
                                        {
                                            nueva[nueva.Count - 1].Texto = clase.Alias;

                                            nueva[nueva.Count - 1].CreateAlumnosList(alumnos, 3);
                                            nueva[nueva.Count - 1].CreatePartePracticas(item.OidClasePractica);
                                        }
                                    }
                                }
                                else
                                {
                                    ParteAsistencia parte = ParteAsistencia.NewChild(_entity);
                                    parte.Tipo = tipo;
                                    parte.Texto = aux + " ";
                                    parte.Sesiones = sesion + " ";
                                    parte.Fecha = item.Fecha;
                                    parte.HoraInicio = item.Hora.ToString("HH:mm");
                                    parte.OidInstructor = item.OidProfesor;
                                    parte.OidInstructorEfectivo = item.OidProfesor;
                                    parte.CreateAlumnosList(alumnos, item.Grupo);
                                    if (index == _entity.Sesions.Count - 1)
                                        parte.NHoras = count.ToString() + ":00";
                                    parte.MarkItemChild();
                                    nueva.AddItem(parte);
                                    oid_modulo = oid_modulo_item;
                                    count = 1;
                                    if (tipo == 2)
                                    {
                                        nueva[nueva.Count - 1].NHoras = "5:00";
                                        nueva[nueva.Count - 1].CreatePartePracticas(item.OidClasePractica);
                                    }
                                    else
                                        nueva[nueva.Count - 1].NHoras = count.ToString() + ":00";
                                }

                            }
                            Clase_Parte registro = nueva[nueva.Count - 1].Clases.NewItem(nueva[nueva.Count - 1]);
                            registro.OidClase = oid_clase;
                            registro.Tipo = tipo;
                            registro.Grupo = grupo;
                        }
                    }
                    index++;
                }
                PgMng.Grow();
                
                foreach (ParteAsistencia parte_old in partes)
                {
	                bool esta = false;
                    for (int i = 0; i < nueva.Count; i++)
                    {
                        ParteAsistencia parte_new = nueva[i];
                        if (parte_old.Fecha.Date == parte_new.Fecha.Date &&
                            parte_old.HoraInicio == parte_new.HoraInicio &&
                            parte_old.NHoras == parte_new.NHoras &&
                            parte_old.OidInstructor == parte_new.OidInstructor &&
                            parte_old.Tipo == parte_new.Tipo)
                        {
                            esta = true;
                            foreach (Clase_Parte cp_old in parte_old.Clases)
                            {
                                bool esta_clase = false;
                                foreach (Clase_Parte cp_new in parte_new.Clases)
                                {
                                    if (cp_old.OidClase == cp_new.OidClase &&
                                        cp_old.Tipo == cp_new.Tipo &&
                                        cp_old.Grupo == cp_new.Grupo)
                                    {
                                        esta_clase = true;
                                        break;
                                    }
                                }
                                if (!esta_clase)
                                {
                                    if (parte_old.Confirmada)
                                        throw new iQException(Resources.Messages.PARTE_CON_CONCEPTOS_ASOCIADOS);
                                    else
                                    {
                                        esta = false;
                                        break;
                                    }
                                }
                            }
                        }
                        if (esta)
                        {
                            nueva.Remove(parte_new);
                            break;
                        }
                    }
                    if (!esta)
                    {
                        if (parte_old.Confirmada)
                            throw new iQException(Resources.Messages.PARTE_CON_CONCEPTOS_ASOCIADOS);
                        else
                            _entity.Asistencias.Remove(parte_old);
                    }
                }

                /*ParteAsistencias partes_bu = _entity.Asistencias.Clone();
                //_entity.Asistencias = ParteAsistencias.NewChildList();
                //se unen las dos listas
                //partes es la lista de partes de asistencia que existía antes de modificar el horario
                //nueva tiene los partes que se generan a partir del horario modificado
                //Se busca cada parte antiguo en la lista de partes nueva
                foreach (ParteAsistencia item in partes)
                {
                    ParteAsistencia existe = nueva.Contiene(item);

                    if (existe != null)
                    {
                        //Si se trata de una clase práctica
                        if (existe.Tipo == 2 && !existe.Confirmada)
                        {
                            //Si en el parte antiguo la clase práctica no tenía lista de notas de prácticas de alumnos o estaba vacía
                            //se le crea la lista de notas de prácticas de alumnos
                            if (item.Alumnos_Practicas == null || item.Alumnos_Practicas.Count == 0)
                            {
                                if (existe.Alumnos_Practicas.Count > 0)
                                    item.CreatePartePracticas(existe.Alumnos_Practicas[0].OidClasePractica);
                                else
                                    item.Alumnos_Practicas = existe.Alumnos_Practicas.Clone();
                            }
                            else
                            {
                                //si ya tenía lista de notas de prácticas se actualiza
                                foreach (Alumno_Practica alumno_practica in item.Alumnos_Practicas)
                                {
                                    if (alumno_practica.Falta)
                                        alumno_practica.Calificacion = Resources.Labels.NO_APTO_LABEL;
                                }
                            }
                        }

                        _entity.Asistencias.AddItem(item, false);

                        //Método rancio para eliminar el parte que ya existía en la lista original de la lista de partes nuevos
                        int ind = -1;
                        for (int i = 0; i < nueva.Count; i++)
                        {
                            ParteAsistencia obj = nueva[i];

                            if (item.OidInstructor == obj.OidInstructor
                            && item.Sesiones == obj.Sesiones
                            && item.NHoras == obj.NHoras
                            && item.Fecha.ToShortDateString() == obj.Fecha.ToShortDateString()
                            && item.HoraInicio == obj.HoraInicio)
                            {
                                ind = i;
                                break;
                            }
                        }
                        if (ind != -1)
                        {
                            ParteAsistencias aux = nueva.Clone();
                            nueva = ParteAsistencias.NewChildList();
                            for (int i = 0; i < aux.Count; i++)
                            {
                                if (i != ind)
                                    nueva.AddItem(aux[i]);
                            }
                        }
                    }
                    else
                    {
                        if (!item.Confirmada)
                        {
                            //Si no se ha encontrado el parte antiguo, se genera el albarán correspondiente y se elimina el parte antiguo
                            if (item.Conceptos != null && item.Conceptos.Count > 0)
                            {
                                InputDeliveryLineInfo concepto = InputDeliveryLineInfo.Get(item.Conceptos[0].OidConcepto);
                                InputDeliveryInfo albaran = albaranes.GetItem(concepto.OidAlbaran);
                                if (albaran != null && albaran.Facturado)
                                {
                                    _entity.Asistencias = partes_bu;
                                    return false;
                                }
                            }
                            ParteAsistencia.Delete(item.Oid);
                        }
                        else
                        {
                            _entity.Asistencias = partes_bu;

                            return false;
                        }
                    }
                }*/
                PgMng.Grow();

                //Al finalizar se añaden todos los partes nuevos que no tenían coincidencia a la lista de 
                //partes del horario
                foreach (ParteAsistencia item in nueva)
                    _entity.Asistencias.AddItem(item);
                PgMng.Grow();

                return true;
            }
            catch { return false; }
            finally
            {
                PgMng.FillUp();
            }
            
        }

		#endregion

		#region Buttons

		#endregion

        #region Events

        private void HorarioEditForm_FormClosing(object sender, FormClosingEventArgs e)
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

