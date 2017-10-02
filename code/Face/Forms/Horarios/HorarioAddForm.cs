using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Face;
using moleQule.Library;
using moleQule.Library.Instruction;

namespace moleQule.Face.Instruction
{
	public partial class HorarioAddForm : HorarioUIForm,
                                        moleQule.Library.IBackGroundLauncher
	{

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 12; } }

        protected override bool CreaSesiones()
        {
            int libres = 0;

            foreach (SesionAuxiliar item in _lista_sesiones)
            {
                if (_profesores == null)
                    _profesores = InstructorList.GetInstructoresHorariosList(EntityInfo.OidPromocion, EntityInfo.FechaInicial, EntityInfo.FechaFinal);

                if (item.Estado > 1 && item.OidClaseTeorica > -1)
                {
                    Sesion sesion = Sesion.NewChild(_entity);

                    /*if (item.OidProfesor == 0)
                    {
                        bool salir = false;
                        
                        foreach (InstructorInfo p in _profesores)
                        {
                            foreach (Instructor_PromocionInfo pr in p.Promociones)
                            {
                                if (pr.OidPromocion == Entity.OidPromocion)
                                {
                                    foreach (Submodulo_Instructor_PromocionInfo sub in pr.Submodulos)
                                    {
                                        if (sub.OidSubmodulo == item.OidSubmodulo && sub.Prioridad == 1)
                                        {
                                            sesion.OidProfesor = p.Oid;
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
                        sesion.OidProfesor = item.OidProfesor;

                    sesion.OidClaseTeorica = item.OidClaseTeorica;
                    sesion.OidClasePractica = item.OidClasePractica;
                    sesion.OidClaseExtra = item.OidClaseExtra;
                    sesion.Fecha = item.Fecha;
                    sesion.Hora = item.Hora;
                    sesion.Forzada = item.Forzada;
                    sesion.Estado = item.Estado;
                    sesion.Grupo = item.Grupo;
                    sesion.MarkItemChild();

                    _entity.Sesions.AddItem(sesion);
                }
                else
                {
                    Sesion sesion = Sesion.NewChild(_entity);

                    sesion.OidClaseTeorica = item.OidClaseTeorica;
                    sesion.OidClasePractica = 0;
                    sesion.OidClaseExtra = 0;
                    sesion.Fecha = item.Fecha;
                    sesion.Hora = item.Hora;
                    sesion.Forzada = item.Forzada;
                    sesion.Estado = 1;
                    sesion.Grupo = item.Grupo;
                    sesion.MarkItemChild();
                    libres++;

                    _entity.Sesions.AddItem(sesion);
                }
                //if (libres == 70) return false;
            }
            return true;
        }

        #endregion

		#region Factory Methods

		public HorarioAddForm() : this(true, null) {}

		public HorarioAddForm(bool isModal, Form parent)
			: base(isModal, parent)
		{
			InitializeComponent();
            _is_modal = isModal;
			SetFormData();
			_mf_type = ManagerFormType.MFAdd;
			this.Text = Resources.Labels.HORARIO_ADD_TITLE;
		}

		protected override void GetFormSourceData()
		{
			_entity = Horario.New();
			_entity.BeginEdit();
		}

		#endregion
        
        #region IBackGroundLauncher

        protected void DoSetFecha()
        {
            try
            {
                if (Fecha_DTP.Value.Date.Equals(Fecha_DTP.MinDate))
                    _day = DateTime.Today;
                else
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

                Entity.FechaInicial = _day;
                Entity.FechaFinal = _day.AddDays(5);

                PgMng.Grow(string.Empty, "Inicializa fecha y ristras");

                _lista_sesiones = new ListaSesiones(Entity.FechaInicial);

                PgMng.Grow(string.Empty, "lista_sesiones");

                _instructores_asignados = Sesion.CargaSesionesProfesores(Entity.FechaInicial, Entity.OidPromocion);
                PgMng.Grow(string.Empty, "instructores_asignados");

                ResetSesiones(true);
                PgMng.Grow(string.Empty, "Reset sesiones");

                if (_profesores != null)
                    _disponibilidades = _profesores.GetDisponibilidadesProfesores(_day);

                Generar_BT.Enabled = true;

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
            catch
            {
                return;
            }
        }

        protected override void DoPromociones()
        {
            try
            {
                PgMng.Reset(15, 1, Resources.Messages.UPDATING_PROMOCION_HORARIO, this);
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

                for (int i = 1; i < 3; i++)
                {
                    ClasePracticaList practicas = ClasePracticaList.GetDisponiblesList(Entity.OidPlan, Entity.OidPromocion, Entity.Oid, i);
                    if (_practicas.Count <= i)
                        _practicas.Add(practicas);
                    else
                        _practicas[i] = practicas;
                    PgMng.Grow(string.Empty, "Rellena clases prácticas grupo " + i.ToString());
                }
                _teoricas = ClaseTeoricaList.GetDisponiblesList(Entity.OidPlan, Entity.OidPromocion, Entity.Oid);
                PgMng.Grow(string.Empty, "Rellena clases teóricas");
                _extras = ClaseExtraList.GetDisponiblesList(Entity.OidPromocion, Entity.Oid);
                PgMng.Grow(string.Empty, "Rellena clases extra");

                //_combo_clases = Submodulo.GetComboClases(_teoricas, ClasePracticaList.Merge(_practicas[1],_practicas[2]), _extras);
                //pmg.Grow("combo clases");

                //pmg.Grow("Rellena fecha");

                while (_day.DayOfWeek != System.DayOfWeek.Monday)
                    _day = _day.AddDays(-1);
                Fecha_DTP.Value = _day;
                DoSetFecha();

                if (Promocion_CB.SelectedItem != null)
                {
                    //ResetSesiones(false);
                    PgMng.Grow(string.Empty, "reset sesiones");
                    _profesores = InstructorList.GetInstructoresHorariosList(((ComboBoxSource)Promocion_CB.SelectedItem).Oid, EntityInfo.FechaInicial, EntityInfo.FechaFinal);
                }

                if (_profesores != null)
                    _disponibilidades = _profesores.GetDisponibilidadesProfesores(_day);
                PgMng.Grow(string.Empty, "_profesores");


                if (Entity.OidPromocion != 0)
                {
                    PromocionInfo promocion = _promociones.GetItem(Entity.OidPromocion);
                    _entity.Promocion = promocion.Nombre;
                    PlanEstudiosInfo plan = _planes.GetItem(promocion.OidPlan);
                    _entity.Plan = plan.Nombre;

                    PgMng.Grow(string.Empty, "Promociones");
                    //_profesores = InstructorList.GetInstructoresHorariosList(Entity.OidPromocion);
                    PgMng.Grow(string.Empty, "GetInstructoresHorarioList");

                    CLB_1.SetItemChecked(0, promocion.H8AM);
                    CLB_1.SetItemChecked(1, promocion.H0);
                    CLB_1.SetItemChecked(2, promocion.H1);
                    CLB_1.SetItemChecked(3, promocion.H2);
                    CLB_1.SetItemChecked(4, promocion.H3);
                    CLB_1.SetItemChecked(5, promocion.H4);
                    CLB_1.SetItemChecked(6, promocion.H5);
                    CLB_1.SetItemChecked(7, promocion.H6);
                    CLB_1.SetItemChecked(8, promocion.H7);
                    CLB_1.SetItemChecked(9, promocion.H8);
                    CLB_1.SetItemChecked(10, promocion.H9);
                    CLB_1.SetItemChecked(11, promocion.H10);
                    CLB_1.SetItemChecked(12, promocion.H11);
                    CLB_1.SetItemChecked(13, promocion.H12);

                    CLB_2.SetItemChecked(0, promocion.HS0);
                    CLB_2.SetItemChecked(1, promocion.HS1);
                    CLB_2.SetItemChecked(2, promocion.HS2);
                    CLB_2.SetItemChecked(3, promocion.HS3);
                    CLB_2.SetItemChecked(4, promocion.HS4);

                    PgMng.Grow(string.Empty, "SetItemChecked");

                    Entity.CopiaConfiguracion(promocion);
                }
                PgMng.Grow(string.Empty, "Inicializa horas disponibles");

                if (!_generado) Generar_BT.Enabled = true;
                Instructores_BT.Enabled = true;
                Planes_BT.Enabled = true;
                Disponibilidades_BT.Enabled = true;

                if (_lista_sesiones == null)
                    _lista_sesiones = new ListaSesiones(Entity.FechaInicial);
                RellenaCasillas();
            }
            finally
            {
                PgMng.FillUp();
            }
        }

        #endregion

		#region Style & Source
        
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
						if (Datos_Planes.Current != null)
						{
							ResetSesiones(true);
							Datos_Promociones.DataSource = _combo_planes.GetFilteredChilds(((ComboBoxSource)Plan_CB.SelectedItem).Oid);
							Entity.OidPlan = ((ComboBoxSource)Plan_CB.SelectedItem).Oid;
						}

						Globals.Instance.Timer.Record("Plan_CB");

					} break;

				case "Promocion_CB":
                    {
                        if (Promocion_CB.SelectedItem != null)
                            Entity.OidPromocion = ((ComboBoxSource)Promocion_CB.SelectedItem).Oid;

                        if (Entity.OidPromocion != 0)
                        {
                            /*PgMng.Reset(10, 1, Resources.Messages.UPDATING_PROMOCION_HORARIO, this);
                            _back_job = BackJob.Promociones;
                            PgMng.StartBackJob(this);
                            PgMng.FillUp();*/
                            DoPromociones();
                        }
					} break;

				case "Fecha_DTP":
					{
						if (Promocion_CB.SelectedItem == null || Plan_CB.SelectedItem == null) break;
                        
                        if (((ComboBoxSource)Promocion_CB.SelectedItem).Oid != 0 && ((ComboBoxSource)Plan_CB.SelectedItem).Oid != 0)
                        {
                            try
                            {
                                PgMng.Reset(5, 1, Resources.Messages.UPDATING_INSTRUCTORES_HORARIO, this);

                                DoSetFecha();
                            }
                            finally
                            {
                                PgMng.FillUp();
                            }

                            if (Horario.ExisteHorario(((ComboBoxSource)Plan_CB.SelectedItem).Oid, ((ComboBoxSource)Promocion_CB.SelectedItem).Oid, _entity.FechaInicial))
                            {
                                MessageBox.Show(Resources.Messages.HORARIO_EXISTENTE);
                                _action_result = DialogResult.Ignore;
                                return;
                            }
						}                        

					} break;
			}
		}

        protected override bool CrearPartes()
        {
            int count = 0;
            long oid_modulo = 0;
            int index = 0;

            PgMng.Reset(4, 1, Resources.Messages.CREANDO_PARTES_ASISTENCIA, this);

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

                foreach (Sesion item in _entity.Sesions)
                {
                    //Desmarca las clases que han sido marcadas como impartidas pero que tienen 
                    //fecha y horas mayor que la actual
                    if (item.Fecha.Date > DateTime.Today.Date
                        /*|| (item.Fecha.Date.Equals(DateTime.Today.Date)
                        && item.Hora.TimeOfDay > DateTime.Today.TimeOfDay)*/
                    && item.Estado == 3)
                        item.Estado = 2;

                    //No genera partes de asistencia para clases que no se han impartido
                    //if (item.Estado != 3)
                    //    continue;

                    //si ya hay un parte para esta práctica no se vuelve a crear
                    if (item.OidClasePractica > 0)
                    {
                        bool esta = false;
                        foreach (ParteAsistencia p in _entity.Asistencias)
                        {
                            //ClasePracticaInfo clase = null;
                            /*foreach (ClasePracticaList listap in _practicas)
                            {
                                clase = listap.GetItem(item.OidClasePractica);
                                if (clase != null) break;
                            }*/
                            //clase = _practicas[(int)item.Grupo].GetItem(item.OidClasePractica);
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
                            /*if (p.Tipo == 2 && p.Sesiones.Contains(item.OidClasePractica.ToString())
                                && !p.Texto.Contains(" G" + Convert.ToString(3 - item.Grupo) + " "))
                            {
                                esta = true;
                                break;
                            }*/
                            if (esta)
                                break;

                        }
                        if (esta) continue;
                    }

                    if (item.OidClaseTeorica > 0
                        || item.OidClasePractica > 0
                        || item.OidClaseExtra > 0)
                    {
                        string aux = string.Empty;
                        long oid_modulo_item = 0;
                        string sesion = string.Empty;
                        long tipo = 0;
                        long oid_clase = 0;
                        long grupo = 3;

                        if (item.OidClasePractica != 0)
                        {

                            ClasePracticaInfo clase = null;
                            /*foreach (ClasePracticaList listap in _practicas)
                            {
                                clase = listap.GetItem(item.OidClasePractica);
                                if (clase != null) break;
                            }*/
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
                                parte.Texto = aux + " ";
                                parte.Sesiones = sesion + " ";
                                parte.Fecha = item.Fecha;
                                parte.HoraInicio = item.Hora.ToString("HH:mm");
                                parte.Tipo = tipo;
                                parte.OidInstructor = item.OidProfesor;
                                parte.OidInstructorEfectivo = item.OidProfesor;
                                parte.CreateAlumnosList(alumnos, item.Grupo);
                                if (index == _entity.Sesions.Count - 1)
                                    parte.NHoras = count.ToString() + ":00";
                                parte.MarkItemChild();
                                _entity.Asistencias.AddItem(parte);
                                oid_modulo = oid_modulo_item;
                                count++;
                                if (tipo == 2)
                                {
                                    _entity.Asistencias[_entity.Asistencias.Count - 1].NHoras = "5:00";
                                    _entity.Asistencias[_entity.Asistencias.Count - 1].CreatePartePracticas(item.OidClasePractica);
                                }
                                else
                                    _entity.Asistencias[_entity.Asistencias.Count - 1].NHoras = count.ToString() + ":00";
                            }
                            else
                            {
                                ParteAsistencia ultima = _entity.Asistencias[_entity.Asistencias.Count - 1];

                                if (ultima.OidHorario == item.OidHorario
                                    && ultima.Fecha.Date.Equals(item.Fecha.Date)
                                    && Convert.ToDateTime(ultima.HoraInicio).AddHours(count).Hour.Equals(item.Hora.Hour)
                                    && ultima.OidInstructor == item.OidProfesor
                                    && oid_modulo_item == oid_modulo
                                    && ((ultima.Tipo == 1 && item.OidClaseTeorica > 0)
                                        ||(ultima.Tipo == 2 && item.OidClasePractica > 0)
                                        ||(ultima.Tipo == 3 && item.OidClaseExtra > 0)))
                                {
                                    count++;
                                    sesion += " ";
                                    if ((item.OidClasePractica > 0 && _entity.Asistencias[_entity.Asistencias.Count - 1].Sesiones != sesion) || item.OidClasePractica == 0)
                                    {
                                        _entity.Asistencias[_entity.Asistencias.Count - 1].Texto += aux + " ";
                                        _entity.Asistencias[_entity.Asistencias.Count - 1].Sesiones += sesion;
                                        _entity.Asistencias[_entity.Asistencias.Count - 1].NHoras = count.ToString() + ":00";
                                        if (index == _entity.Sesions.Count - 1)
                                        {
                                            //_entity.Asistencias[_entity.Asistencias.Count - 1].Fecha = item.Fecha;
                                            //_entity.Asistencias[_entity.Asistencias.Count - 1].Hora = item.Hora;
                                            //_entity.Asistencias[_entity.Asistencias.Count - 1].OidInstructor = item.OidProfesor;
                                            count = 0;
                                        }
                                    }
                                    else
                                    {
                                        ClasePracticaInfo clase = null;
                                        clase = _practicas[(int)item.Grupo].GetItem(item.OidClasePractica);
                                        string texto_aux = clase.Alias + " G" + item.Grupo.ToString() + " ";
                                        if (_entity.Asistencias[_entity.Asistencias.Count - 1].Texto != texto_aux)
                                        {
                                            _entity.Asistencias[_entity.Asistencias.Count - 1].Texto = clase.Alias;

                                            _entity.Asistencias[_entity.Asistencias.Count - 1].CreateAlumnosList(alumnos, 3);
                                            _entity.Asistencias[_entity.Asistencias.Count - 1].CreatePartePracticas(item.OidClasePractica);
                                        }
                                    }
                                }
                                else
                                {
                                    ParteAsistencia parte = ParteAsistencia.NewChild(_entity);
                                    parte.Texto = aux + " ";
                                    parte.Sesiones = sesion + " ";
                                    parte.Fecha = item.Fecha;
                                    parte.HoraInicio = item.Hora.ToString("HH:mm");
                                    parte.Tipo = tipo;
                                    parte.OidInstructor = item.OidProfesor;
                                    parte.OidInstructorEfectivo = item.OidProfesor;
                                    parte.CreateAlumnosList(alumnos, item.Grupo);
                                    if (index == _entity.Sesions.Count - 1)
                                        parte.NHoras = count.ToString() + ":00";
                                    parte.MarkItemChild();
                                    _entity.Asistencias.AddItem(parte);
                                    oid_modulo = oid_modulo_item;
                                    count = 1;
                                    if (tipo == 2)
                                    {
                                        _entity.Asistencias[_entity.Asistencias.Count - 1].NHoras = "5:00";
                                        _entity.Asistencias[_entity.Asistencias.Count - 1].CreatePartePracticas(item.OidClasePractica);
                                    }
                                    else
                                        _entity.Asistencias[_entity.Asistencias.Count - 1].NHoras = count.ToString() + ":00";
                                }
                            }
                            Clase_Parte registro = _entity.Asistencias[_entity.Asistencias.Count - 1].Clases.NewItem(_entity.Asistencias[_entity.Asistencias.Count - 1]);
                            registro.OidClase = oid_clase;
                            registro.Tipo = tipo;
                            registro.Grupo = grupo;
                        }
                    }
                    index++;
                }
                PgMng.Grow();

                return true;
            }
            catch { return false; }
            finally { PgMng.FillUp(); }
        }

		#endregion

	}
}