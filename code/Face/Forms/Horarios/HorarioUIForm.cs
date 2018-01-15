using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Face;
using moleQule.Library;
using moleQule.Library.Instruction;
using moleQule.Library.Store;

namespace moleQule.Face.Instruction
{
    public partial class HorarioUIForm : HorarioForm,
                                        moleQule.Library.IBackGroundLauncher
    {
        #region Properties

        //protected override int BarSteps { get { return base.BarSteps + 9; } }

        #endregion

        #region Business Methods

        /// <summary>
		/// Se trata del objeto actual y que se va a editar.
		/// </summary>
		protected Horario _entity;

		public override Horario Entity { get { return _entity; } set { _entity = value; } }
		public override HorarioInfo EntityInfo { get { return (_entity != null) ? _entity.GetInfo(false) : null; } }

		protected virtual bool CreaSesiones() { return false; }


        protected void RefreshHorario()
        {
            try
            {
                PgMng.Reset(7, 1, Resources.Messages.UPDATING_PROMOCION_HORARIO, this);
                
                for (int i = 1; i < 3; i++)
                        _practicas[i] = ClasePracticaList.GetDisponiblesList(Entity.OidPlan, Entity.OidPromocion, Entity.Oid, i);
                _teoricas = ClaseTeoricaList.GetDisponiblesList(Entity.OidPlan, Entity.OidPromocion, Entity.Oid);
                _extras = ClaseExtraList.GetDisponiblesList(Entity.OidPromocion, Entity.Oid);
                PgMng.Grow(string.Empty, "clases");
                
                _instructores_asignados = Sesion.CargaSesionesProfesores(Entity.FechaInicial, Entity.OidPromocion);
                _profesores = InstructorList.GetInstructoresHorariosList(EntityInfo.OidPromocion, EntityInfo.FechaInicial, EntityInfo.FechaFinal);

                _disponibilidades = _profesores.GetDisponibilidadesProfesores(_entity.FechaInicial);
                PgMng.Grow(string.Empty, "Instructores y profesores");
                
                //Se rellena el horario
                
                //_lista_sesiones = new ListaSesiones(Entity.FechaInicial);
                //ResetSesiones(false);
                PgMng.Grow(string.Empty, "lista sesiones");

                Horario.MuestraSesiones(Entity.Sesions, _lista_sesiones, _teoricas, ClasePracticaList.Merge(_practicas[1], _practicas[2]), _extras);
                
                _combo_clases = Submodulo.GetComboClases(_teoricas, ClasePracticaList.Merge(_practicas[1], _practicas[2]), _extras);
                _combo_clases.Childs = _combo_instructores;
                Datos_Clases.DataSource = _combo_clases;
                PgMng.Grow(string.Empty, "combo_clases");
            }
            finally
            {
                PgMng.FillUp();
            }
        }

		#endregion

		#region Factory Methods

		/// <summary>
		/// Declarado por exigencia del entorno. No Utilizar.
		/// </summary>
		protected HorarioUIForm() : this(-1, true, null) { }

		public HorarioUIForm(bool isModal, Form parent) : this(-1, isModal, parent) { }

		public HorarioUIForm(long oid, Form parent) : this(oid, true, parent) { }

		public HorarioUIForm(long oid, bool ismodal, Form parent)
			: base(oid, ismodal, parent)
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

                if (!CreaSesiones()) return true;
                if (_entity.IsDirty)
                {
                    if (!CrearPartes())
                    {
                        MessageBox.Show(Resources.Messages.ERROR_CREAR_PARTES);
                        return false;
                    }
                }

				Horario temp = _entity.Clone();
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
                    case BackJob.Refrescar:
                        DoRefresh();
                        break;

                    case BackJob.Promociones:
                        DoPromociones();
                        break;

                    case BackJob.Horario:
                        DoHorario();
                        break;

                    case BackJob.NuevoHorario:
                        DoNuevoHorario();
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

        protected void DoRefresh()
        {
            try
            {
                PgMng.Reset(8, 1, Resources.Messages.LOADING_DATA, this);

                for (int i = 1; i < 3; i++)
                {
                    _practicas[i] = ClasePracticaList.GetDisponiblesList(Entity.OidPlan, Entity.OidPromocion, Entity.Oid, i);
                }
                PgMng.Grow();

                _teoricas = ClaseTeoricaList.GetDisponiblesList(Entity.OidPlan, Entity.OidPromocion, Entity.Oid);
                PgMng.Grow();

                _extras = ClaseExtraList.GetDisponiblesList(Entity.OidPromocion, Entity.Oid);
                PgMng.Grow();

                profesores_encargados.GetEncargados(Entity.OidPlan, Entity.OidPromocion);
                PgMng.Grow();

                _combo_clases = Submodulo.GetComboClases(_teoricas, ClasePracticaList.Merge(_practicas[1], _practicas[2]), _extras);
                Datos_Clases.DataSource = _combo_clases;
                PgMng.Grow();

                _instructores_asignados = Sesion.CargaSesionesProfesores(Entity.FechaInicial, Entity.OidPromocion);
                PgMng.Grow();

                _profesores = InstructorList.GetInstructoresHorariosList(EntityInfo.OidPromocion, EntityInfo.FechaInicial, EntityInfo.FechaFinal);
                PgMng.Grow();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {
                PgMng.FillUp();
            }
        }

        protected virtual void DoPromociones() { }

        protected virtual void DoHorario() { }

        protected void DoNuevoHorario()
        {
            try
            {
                PgMng.Reset(10, 1, Resources.Messages.CREANDO_HORARIO, this);

                if (this is HorarioAddForm && Horario.ExisteHorario(Entity.OidPlan, Entity.OidPromocion, Entity.FechaInicial))
                {
                    MessageBox.Show("Ya existe un horario para la promoción y fecha indicadas, si lo desea modifique el que ya existe.");
                    PgMng.FillUp();
                    return;
                }

                profesores_encargados.GetEncargados(Entity.OidPlan, Entity.OidPromocion);
                PgMng.Grow();

                _combo_clases = Submodulo.GetComboClases(_teoricas, ClasePracticaList.Merge(_practicas[1], _practicas[2]), _extras);
                Datos_Clases.DataSource = _combo_clases;
                PgMng.Grow();

                _instructores_asignados = Sesion.CargaSesionesProfesores(Entity.FechaInicial, Entity.OidPromocion);
                PgMng.Grow();

                if (_profesores == null)
                    _profesores = InstructorList.GetInstructoresHorariosList(EntityInfo.OidPromocion, EntityInfo.FechaInicial, EntityInfo.FechaFinal);
                PgMng.Grow();

                CleanAction();
                PgMng.Grow(string.Empty, "CleanAction");

                if (_generado) ResetNoConfirmadas();
                PgMng.Grow(string.Empty, "ResetNoConfirmadas");

                if (_lista_sesiones == null)
                    _lista_sesiones = new ListaSesiones(Entity.FechaInicial);

                if (!Entity.FechaInicial.Date.Equals(_lista_sesiones[0].Fecha.Date))
                {
                    DateTime fecha = Entity.FechaInicial;
                    for (int i = 0; i < 70; i += 14)
                    {
                        _lista_sesiones[i].Fecha = fecha;
                        _lista_sesiones[i + 1].Fecha = fecha;
                        _lista_sesiones[i + 2].Fecha = fecha;
                        _lista_sesiones[i + 3].Fecha = fecha;
                        _lista_sesiones[i + 4].Fecha = fecha;
                        _lista_sesiones[i + 5].Fecha = fecha;
                        _lista_sesiones[i + 6].Fecha = fecha;
                        _lista_sesiones[i + 7].Fecha = fecha;
                        _lista_sesiones[i + 8].Fecha = fecha;
                        _lista_sesiones[i + 9].Fecha = fecha;
                        _lista_sesiones[i + 10].Fecha = fecha;
                        _lista_sesiones[i + 11].Fecha = fecha;
                        _lista_sesiones[i + 12].Fecha = fecha;
                        _lista_sesiones[i + 13].Fecha = fecha;
                        fecha = fecha.AddDays(1);
                    }
                    for (int i = 70; i < 75; i++)
                        _lista_sesiones[i].Fecha = fecha;
                }

                _lista_sesiones = Entity.SetSesionesActivas(_lista_sesiones);
                PgMng.Grow(string.Empty, "Entity.SetSesionesActivas");

                decimal n_practicas = 11;
                if (Practicas_CB.Checked) n_practicas = NPracticas.Value;

                HorarioController controlador = new HorarioController(_entity, _lista_sesiones,
                                                                        _teoricas, _practicas, _extras, _profesores,
                                                                        profesores_encargados, _instructores_asignados,
                                                                        _disponibilidades, n_practicas, DiasSuplente.Value);

                controlador.Rules[(int)TRule.MismoInstructorMismaSesion] = !MismoInstructorMismaSesion_CB.Checked;
                controlador.Rules[(int)TRule.MismoInstructorMismoDia] = !MismoInstructorMismoDia_CB.Checked;

                controlador.GeneraHorario(_no_asignables);
                PgMng.Grow(string.Empty, "Generación de horario");

                RellenaCasillas();
                PgMng.Grow(string.Empty, "Rellenar Casillas");

                Completar_BT.Enabled = false;
                Marcar_BT.Enabled = true;
                Clean_BT.Enabled = true;
                if (this is HorarioEditForm) Confirmar_BT.Enabled = true;
                _generado = true;
            }
            catch (Exception ex)
            {
                throw ex;
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
            RefreshChildren = true;
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

			SetDependentControlSource(Fecha_DTP.Name);
            PgMng.Grow(string.Empty, "Esquema de datos Fecha del Horario");
			
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


            if (_lista_sesiones != null && limpiar /*&& _generado*/)
            {
                foreach (SesionAuxiliar sesion in _lista_sesiones)
                {
                    if (sesion.EEstadoClase != EEstadoClase.Impartida)
                    {
                        if (sesion.OidClaseTeorica > 0)
                            _teoricas.GetItem(sesion.OidClaseTeorica).Estado = 1;
                        if (sesion.OidClaseExtra > 0)
                            _extras.GetItem(sesion.OidClaseExtra).Estado = 1;
                        if (sesion.OidClasePractica > 0)
                            _practicas[(int)sesion.Grupo].GetItem(sesion.OidClasePractica).Estado = 1;

                        sesion.AsignaClaseASesion((ClaseTeoricaInfo)null);
                    }
                }
            }
            else
            {
                if (_teoricas != null && _practicas != null && _extras != null /*&& _generado*/)
			    {
				    foreach (ClaseTeoricaInfo clase in _teoricas)
                        if (clase.EEstadoClase != EEstadoClase.Impartida)
					        clase.Estado = 1;
                    foreach (ClasePracticaList lista in _practicas)
                        foreach (ClasePracticaInfo clase in lista)
                            if (clase.EEstadoClase != EEstadoClase.Impartida)
					            clase.Estado = 1;
                    foreach (ClaseExtraInfo clase in _extras)
                        if (clase.Estado != (long)EEstadoClase.Impartida)
					        clase.Estado = 1;
			    }
            }

            _no_asignables = new List<SesionNoAsignable>();

            if (_lista_sesiones != null)
                RellenaCasillas();
		}

        public void ResetNoConfirmadas()
        {
            if (_lista_sesiones != null)
            {
                foreach (SesionAuxiliar sesion in _lista_sesiones)
                {
                    if (sesion.Estado != 3)
                    {
                        if (sesion.OidClaseTeorica > 0)
                            _teoricas.GetItem(sesion.OidClaseTeorica).Estado = 1;
                        if (sesion.OidClaseExtra > 0)
                            _extras.GetItem(sesion.OidClaseExtra).Estado = 1;
                        if (sesion.OidClasePractica > 0)
                            _practicas[(int)sesion.Grupo].GetItem(sesion.OidClasePractica).Estado = 1;
                        sesion.AsignaClaseASesion((ClaseTeoricaInfo)null);
                    }
                }
            }

            _no_asignables = new List<SesionNoAsignable>();

            if (_lista_sesiones != null)
                RellenaCasillas();
        }

        protected virtual bool CrearPartes() { return true; }

        public override ComboBoxSourceList RellenaComboInstructores(long oid, long tipo, int index, long oid_submodulo)
        {
            long oid_clase = oid;

            if (oid_clase <= 0)
            {
                ComboBoxSourceList combo_list = new ComboBoxSourceList();
                combo_list.Add(new ComboBoxSource(0, ""));
                Datos_Instructores.DataSource = combo_list;
                return combo_list;
            }

            List<Submodulo_Instructor_PromocionInfo> list = new List<Submodulo_Instructor_PromocionInfo>();
            if (_profesores == null) _profesores = InstructorList.GetInstructoresHorariosList(EntityInfo.OidPromocion, EntityInfo.FechaInicial, EntityInfo.FechaFinal);


            if (_disponibilidades == null) _disponibilidades = _profesores.GetDisponibilidadesProfesores(EntityInfo.FechaInicial);
            DisponibilidadInfo disp = null;

            foreach (InstructorInfo profesor in _profesores)
            {
                if (Horario.ProfesorLibre(_instructores_asignados, index, profesor.Oid,
                                            _lista_sesiones, _profesores, -1, EntityInfo.FechaInicial, _disponibilidades)
                    && _disponibilidades.TryGetValue(profesor.Oid, out disp)
                    && disp.Semana[index])
                {
                    Instructor_PromocionInfo promo = profesor.Promociones.GetItemByProperty("OidPromocion", EntityInfo.OidPromocion);
                    if (tipo != 2)
                    {
                        Submodulo_Instructor_PromocionInfo sub = promo != null ? promo.Submodulos.GetItemByProperty("OidSubmodulo", oid_submodulo) : null;
                        if (sub != null)
                            list.Add(sub);
                    }
                    else
                    {
                        Submodulo_Instructor_PromocionInfo sub = promo != null ? promo.Submodulos.GetItemByProperty("OidModulo", _lista_sesiones[index].OidModulo) : null;
                        if (sub != null)
                            list.Add(sub);
                    }
                }
            }

            //foreach (Submodulo_Instructor_PromocionInfo info in _submodulos)
            //{
            //    if (info.OidSubmodulo == oid_submodulo && info.OidPromocion == EntityInfo.OidPromocion)
            //    {
            //        if (Horario.ProfesorLibre(_instructores_asignados, index, info.OidInstructor,
            //                                _lista_sesiones, _profesores, -1, EntityInfo.FechaInicial, _disponibilidades))
            //            list.Add(info);
            //    }
            //}

            Submodulo_Instructor_PromocionList lista = Submodulo_Instructor_PromocionList.GetChildList(list);

            _combo_instructores = new Library.Instruction.HComboBoxSourceList(lista, _profesores);
            _combo_clases.Childs = _combo_instructores;

            Datos_Instructores.DataSource = _combo_clases.Childs;
            return _combo_clases.Childs;
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
            foreach (SesionAuxiliar sesion in _lista_sesiones)
            {
                if ((sesion.OidClaseTeorica > 0
                    || sesion.OidClasePractica > 0
                    || sesion.OidClaseExtra > 0)
                    && sesion.OidProfesor == 0)
                {
                    MessageBox.Show(Resources.Messages.SESION_SIN_PROFESOR);
                    _action_result = DialogResult.Ignore;
                    return;
                }
            }

            foreach (SesionAuxiliar item in _lista_sesiones)
            {
                if (item.EEstadoClase != EEstadoClase.NoProgramada)
                {
                    _generado = true;
                    break;
                }
            }
			if (!_generado && _entity.Observaciones == string.Empty)
			{
				MessageBox.Show(Resources.Messages.HORARIO_NO_GENERADO);
                _action_result = DialogResult.Ignore;
                return;
			}

            if (_entity.IsNew && Horario.ExisteHorario(_entity.OidPlan, _entity.OidPromocion, _entity.FechaInicial))
			{
				MessageBox.Show(Resources.Messages.HORARIO_EXISTENTE);
                _action_result = DialogResult.Ignore;
                return;
			}

            _action_result = SaveObject() ? DialogResult.OK : DialogResult.Ignore;
		}

        /// <summary>
        /// Implementa Undo_button_Click
        /// </summary>
        protected override void CancelAction()
        {
            _action_result = DialogResult.Cancel;
            CancelBackGroundJob(); 
        }

        protected void LanzaNuevoHorarioBackAction()
        {
            /*PgMng.Reset(5, 1, Resources.Messages.CREANDO_HORARIO, this);
            _back_job = BackJob.NuevoHorario;
            PgMng.StartBackJob(this);
            PgMng.FillUp();*/
            DoNuevoHorario();
        }

        protected override void CleanAction()
        {
            ResetSesiones(true);
            Generar_BT.Enabled = true;
            //Confirmar_BT.Enabled = false;
            Marcar_BT.Enabled = false;
            Completar_BT.Enabled = false;
            _generado = false;
            RellenaCasillas();
        }

        protected override void ModificarPlanAction()
        {
            try
            {
                if (_entity.OidPlan != 0)
                {
                    PlanDocenteEditForm form = new PlanDocenteEditForm(_entity.OidPlan);
                    form.ShowDialog();

                    if (form.ActionResult == DialogResult.OK)
                        RefreshHorario();
                }
            }
            catch { }
        }

        protected override void ModificarInstructoresAction()
        {
            try 
            {
                InstructorSelectForm form = new InstructorSelectForm(this);
                form.ShowDialog();

                if (form.ActionResult == DialogResult.OK)
                {
                    InstructorEditForm edit_form = new InstructorEditForm((form.Selected as InstructorInfo).Oid);
                    edit_form.ShowDialog();

                    if (form.ActionResult == DialogResult.OK)
                        RefreshHorario();
                }
            }
            catch { }
        }

        protected override void VerDisponibilidadesAction()
        {
            try 
            {
                DisponibilidadSemanalForm form = new DisponibilidadSemanalForm(this);
                form.ShowDialog();

                RefreshHorario();
            }
            catch { }
        }

        #endregion

        #region Buttons

        private void Generar_BT_Click(object sender, EventArgs e)
        {
            //SetDependentControlSource(Fecha_DTP.Name);
            LanzaNuevoHorarioBackAction();

            /*PgMng.Reset(4, 1, Resources.Messages.CREANDO_HORARIO, this);
            NuevoHorarioAction();
            RellenaCasillas();
            PgMng.FillUp();*/
        }

		private void Marcar_BT_Click(object sender, EventArgs e)
        {
            foreach (SesionAuxiliar ses in _lista_sesiones)
            {
                if (/*(ses.Fecha.Date < DateTime.Today.Date
                    || (ses.Fecha.Date.Equals(DateTime.Today.TimeOfDay)
                    && ses.Hora.TimeOfDay < DateTime.Today.TimeOfDay))
                    &&*/ (ses.OidClasePractica > 0
                    || ses.OidClaseTeorica > 0
                    || ses.OidClaseExtra > 0))
                {
                    ses.Estado = 3;

                    if (ses.OidClaseTeorica > 0)
                        _teoricas.GetItem(ses.OidClaseTeorica).Estado = ses.Estado;
                    if (ses.OidClasePractica > 0)
                        _practicas[(int)ses.Grupo].GetItem(ses.OidClasePractica).Estado = ses.Estado;
                    if (ses.OidClaseExtra > 0)
                        _extras.GetItem(ses.OidClaseExtra).Estado = ses.Estado;
                }
            }
            RellenaCasillas();
            Confirmar_BT.Enabled = true;
		}

		private void Confirmar_BT_Click(object sender, EventArgs e)
		{
            foreach (SesionAuxiliar ses in _lista_sesiones)
            {
                if (/*(ses.Fecha.Date < DateTime.Today.Date
                    || (ses.Fecha.Date.Equals(DateTime.Today.TimeOfDay)
                    && ses.Hora.TimeOfDay < DateTime.Today.TimeOfDay))
                    &&*/ (ses.OidClasePractica > 0
                    || ses.OidClaseTeorica > 0
                    || ses.OidClaseExtra > 0))
                {
                    ses.Estado = 2;

                    if (ses.OidClaseTeorica > 0)
                        _teoricas.GetItem(ses.OidClaseTeorica).Estado = ses.Estado;
                    if (ses.OidClasePractica > 0)
                        _practicas[(int)ses.Grupo].GetItem(ses.OidClasePractica).Estado = ses.Estado;
                    if (ses.OidClaseExtra > 0)
                        _extras.GetItem(ses.OidClaseExtra).Estado = ses.Estado;
                }
            }
            RellenaCasillas();
		}

		private void Completar_BT_Click(object sender, EventArgs e)
		{
            List<List<long>> lista = Entity.RellenaHorasSemana();
			Horario.RellenaLibres(_teoricas, _profesores, _lista_sesiones, _instructores_asignados,
                                Entity.FechaInicial,_no_asignables, Entity.OidPromocion, lista[2], lista[1], lista[0], DiasSuplente.Value, profesores_encargados,_disponibilidades);
            Horario.OrdenaHorario(75, _lista_sesiones, _profesores, _instructores_asignados, Entity.FechaInicial, Entity.OidPromocion, _disponibilidades);
            RellenaCasillas();
            Completar_BT.Enabled = false;
			if (this is HorarioEditForm) Confirmar_BT.Enabled = true;
			_generado = true;
		}

		#endregion
	}
}
