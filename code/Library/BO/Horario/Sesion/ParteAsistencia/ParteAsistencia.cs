using System;
using System.ComponentModel;
using System.Data;
using System.Reflection;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Store;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class ParteAsistenciaRecord : RecordBase
	{
		#region Attributes

		private string _observaciones = string.Empty;
		private long _oid_horario;
		private string _texto = string.Empty;
		private DateTime _duracion;
		private string _sesiones = string.Empty;
		private long _oid_instructor;
		private DateTime _fecha;
		private DateTime _hora;
		private long _tipo;
		private string _n_horas = string.Empty;
		private string _hora_inicio = string.Empty;
		private bool _confirmada = false;
		private long _oid_instructor_efectivo;
  
		#endregion
		
		#region Properties
		
		public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
		public virtual long OidHorario { get { return _oid_horario; } set { _oid_horario = value; } }
		public virtual string Texto { get { return _texto; } set { _texto = value; } }
		public virtual DateTime Duracion { get { return _duracion; } set { _duracion = value; } }
		public virtual string Sesiones { get { return _sesiones; } set { _sesiones = value; } }
		public virtual long OidInstructor { get { return _oid_instructor; } set { _oid_instructor = value; } }
		public virtual DateTime Fecha { get { return _fecha; } set { _fecha = value; } }
		public virtual DateTime Hora { get { return _hora; } set { _hora = value; } }
		public virtual long Tipo { get { return _tipo; } set { _tipo = value; } }
		public virtual string NHoras { get { return _n_horas; } set { _n_horas = value; } }
		public virtual string HoraInicio { get { return _hora_inicio; } set { _hora_inicio = value; } }
		public virtual bool Confirmada { get { return _confirmada; } set { _confirmada = value; } }
		public virtual long OidInstructorEfectivo { get { return _oid_instructor_efectivo; } set { _oid_instructor_efectivo = value; } }

		#endregion
		
		#region Business Methods
		
		public ParteAsistenciaRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");
			_oid_horario = Format.DataReader.GetInt64(source, "OID_HORARIO");
			_texto = Format.DataReader.GetString(source, "TEXTO");
			_duracion = Format.DataReader.GetDateTime(source, "DURACION");
			_sesiones = Format.DataReader.GetString(source, "SESIONES");
			_oid_instructor = Format.DataReader.GetInt64(source, "OID_INSTRUCTOR");
			_fecha = Format.DataReader.GetDateTime(source, "FECHA");
			_hora = Format.DataReader.GetDateTime(source, "HORA");
			_tipo = Format.DataReader.GetInt64(source, "TIPO");
			_n_horas = Format.DataReader.GetString(source, "N_HORAS");
			_hora_inicio = Format.DataReader.GetString(source, "HORA_INICIO");
			_confirmada = Format.DataReader.GetBool(source, "CONFIRMADA");
			_oid_instructor_efectivo = Format.DataReader.GetInt64(source, "OID_INSTRUCTOR_EFECTIVO");

		}		
		public virtual void CopyValues(ParteAsistenciaRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_observaciones = source.Observaciones;
			_oid_horario = source.OidHorario;
			_texto = source.Texto;
			_duracion = source.Duracion;
			_sesiones = source.Sesiones;
			_oid_instructor = source.OidInstructor;
			_fecha = source.Fecha;
			_hora = source.Hora;
			_tipo = source.Tipo;
			_n_horas = source.NHoras;
			_hora_inicio = source.HoraInicio;
			_confirmada = source.Confirmada;
			_oid_instructor_efectivo = source.OidInstructorEfectivo;
		}
		
		#endregion	
	}

    [Serializable()]
	public class ParteAsistenciaBase 
	{	 
		#region Attributes
		
		private ParteAsistenciaRecord _record = new ParteAsistenciaRecord();

        private string _instructor = string.Empty;
        private string _instructor_efectivo = string.Empty;
        private string _promocion = string.Empty;
		
		#endregion
		
		#region Properties
		
		public ParteAsistenciaRecord Record { get { return _record; } }

        public virtual string Instructor { get { return _instructor; } }
        public virtual string Promocion { get { return _promocion; } }
        public virtual string InstructorEfectivo { get { return _instructor_efectivo; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);

            _instructor = Format.DataReader.GetString(source, "INSTRUCTOR");
            _promocion = Format.DataReader.GetString(source, "PROMOCION");
            _instructor_efectivo = Format.DataReader.GetString(source, "INSTRUCTOR_EFECTIVO");
		}		
		public void CopyValues(ParteAsistencia source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _instructor = source.Instructor;
            _promocion = source.Promocion;
            _instructor_efectivo = source.InstructorEfectivo;
		}
		public void CopyValues(ParteAsistenciaInfo source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _instructor = source.Instructor;
            _promocion = source.Promocion;
            _instructor_efectivo = source.InstructorEfectivo;
		}
		
		#endregion	
	}
		
	/// <summary>
	/// Editable Root Business Object
	/// </summary>	
    [Serializable()]
	public class ParteAsistencia : BusinessBaseEx<ParteAsistencia>
	{	 
		#region Attributes
		
		protected ParteAsistenciaBase _base = new ParteAsistenciaBase();

        private Alumno_Partes _alumnos = Alumno_Partes.NewChildList();
        //private Conceptos_Partes _conceptos = Conceptos_Partes.NewChildList();
        private Alumnos_Practicas _alumnos_practicas = Alumnos_Practicas.NewChildList();
        private Clases_Partes _clases = Clases_Partes.NewChildList();
		

		#endregion
		
		#region Properties
		
		public ParteAsistenciaBase Base { get { return _base; } }

        public override long Oid
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.Oid;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //CanWriteProperty(true);
                if (!_base.Record.Oid.Equals(value))
                {
                    _base.Record.Oid = value;
                    //PropertyHasChanged();
                }
            }
        }
        public virtual long OidInstructor
        {

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.OidInstructor;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (!_base.Record.OidInstructor.Equals(value))
                {
                    _base.Record.OidInstructor = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual long OidHorario
        {

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.OidHorario;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (!_base.Record.OidHorario.Equals(value))
                {
                    _base.Record.OidHorario = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Sesiones
        {

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.Sesiones;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_base.Record.Sesiones.Equals(value))
                {
                    _base.Record.Sesiones = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Texto
        {

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.Texto;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_base.Record.Texto.Equals(value))
                {
                    _base.Record.Texto = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string NHoras
        {

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.NHoras;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (!_base.Record.NHoras.Equals(value))
                {
                    _base.Record.NHoras = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual DateTime Fecha
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.Fecha;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (!_base.Record.Fecha.Equals(value))
                {
                    _base.Record.Fecha = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string HoraInicio
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.HoraInicio;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (!_base.Record.HoraInicio.Equals(value))
                {
                    _base.Record.HoraInicio = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Observaciones
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.Observaciones;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_base.Record.Observaciones.Equals(value))
                {
                    _base.Record.Observaciones = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual long Tipo
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.Tipo;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (!_base.Record.Tipo.Equals(value))
                {
                    _base.Record.Tipo = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual long OidInstructorEfectivo
        {

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.OidInstructorEfectivo;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (!_base.Record.OidInstructorEfectivo.Equals(value))
                {
                    _base.Record.OidInstructorEfectivo = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool Confirmada
        {

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.Confirmada;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (!_base.Record.Confirmada.Equals(value))
                {
                    _base.Record.Confirmada = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual Alumno_Partes Alumno_Partes
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _alumnos;
            }

            set
            {
                _alumnos = value;
            }
        }
        //public virtual Conceptos_Partes Conceptos
        //{
        //    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        //    get
        //    {
        //        CanReadProperty(true);
        //        return _conceptos;
        //    }

        //    set
        //    {
        //        _conceptos = value;
        //    }
        //}
        public virtual Alumnos_Practicas Alumnos_Practicas
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _alumnos_practicas;
            }

            set
            {
                _alumnos_practicas = value;
            }
        }
        public virtual Clases_Partes Clases
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _clases;
            }

            set
            {
                _clases = value;
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _alumnos.IsValid && /*_conceptos.IsValid &&*/ _alumnos_practicas.IsValid && _clases.IsValid; }
        }
        public override bool IsDirty
        {
            get { return base.IsDirty || _alumnos.IsDirty || /*_conceptos.IsDirty ||*/ _alumnos_practicas.IsDirty || _clases.IsDirty; }
        }

        public virtual string Instructor { get { return _base.Instructor; } }
        public virtual string Promocion { get { return _base.Promocion; } }
        public virtual string InstructorEfectivo { get { return _base.InstructorEfectivo; } }
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual ParteAsistencia CloneAsNew()
		{
			ParteAsistencia clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = ParteAsistencia.OpenSession();
			ParteAsistencia.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(ParteAsistenciaInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			Observaciones = source.Observaciones;
			OidHorario = source.OidHorario;
			Texto = source.Texto;
			//Duracion = source.Duracion;
			Sesiones = source.Sesiones;
			OidInstructor = source.OidInstructor;
			Fecha = source.Fecha;
			//Hora = source.Hora;
			Tipo = source.Tipo;
			NHoras = source.NHoras;
			HoraInicio = source.HoraInicio;
			Confirmada = source.Confirmada;
			OidInstructorEfectivo = source.OidInstructorEfectivo;
		}
		
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidHorario", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidInstructor", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidInstructorEfectivo", 1));

        }

        #endregion

        #region Autorization Rules

        public static bool CanAddObject()
        {
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.PARTE_ASISTENCIA);
        }

        public static bool CanGetObject()
        {
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.PARTE_ASISTENCIA);
        }

        public static bool CanDeleteObject()
        {
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.PARTE_ASISTENCIA);
        }

        public static bool CanEditObject()
        {
            return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.PARTE_ASISTENCIA);
        }

        #endregion

        #region Common Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        protected ParteAsistencia() { }

        public virtual ParteAsistenciaInfo GetInfo(bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new ParteAsistenciaInfo(this, get_childs);
        }

        public virtual ParteAsistenciaInfo GetInfo() { return GetInfo(true); }

        #endregion

        #region Root Factory Methods

        public static ParteAsistencia New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<ParteAsistencia>(new CriteriaCs(-1));
        }

        public static ParteAsistencia Get(long oid)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = ParteAsistencia.GetCriteria(ParteAsistencia.OpenSession());

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = ParteAsistencia.SELECT(oid);

            ParteAsistencia.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<ParteAsistencia>(criteria);
        }

        public static ParteAsistencia Get(CriteriaEx criteria)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            ParteAsistencia.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<ParteAsistencia>(criteria);
        }

        /// <summary>
        /// Borrado inmediato, no cabe "undo"
        /// (La función debe ser "estática")
        /// </summary>
        /// <param name="oid"></param>
        public static void Delete(long oid)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            DataPortal.Delete(new CriteriaCs(oid));
        }

        /// <summary>
        /// Elimina todas los ParteAsistencias
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = ParteAsistencia.OpenSession();
            ISession sess = ParteAsistencia.Session(sessCode);
            ITransaction trans = ParteAsistencia.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from ParteAsistencia");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                ParteAsistencia.CloseSession(sessCode);
            }
        }

        public override ParteAsistencia Save()
        {
            // Por interfaz Root/Child
            if (IsChild) throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);

            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
            else if (!CanEditObject())
            {
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
            }

            try
            {
                ValidationRules.CheckRules();

                base.Save();

                _alumnos.Update(this);
                //_conceptos.Update(this);
                _alumnos_practicas.Update(this);
                _clases.Update(this);

                if (!SharedTransaction) Transaction().Commit();
                return this;
            }
            catch (Exception ex)
            {
                if (!SharedTransaction) if (!SharedTransaction && Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(ex);
                return this;
            }
            finally
            {
                if (!SharedTransaction)
                {
                    if (CloseSessions && (this.IsNew || Transaction().WasCommitted)) CloseSession();
                    else BeginTransaction();
                }
            }
        }

        #endregion

        #region Child Factory Methods

        private ParteAsistencia(ParteAsistencia source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private ParteAsistencia(int session_code ,IDataReader reader, bool childs)
        {
            MarkAsChild();
            Childs = childs;
            Fetch(session_code, reader);
        }

        public static ParteAsistencia NewChild(Horario parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            ParteAsistencia obj = new ParteAsistencia();
            obj.OidHorario = parent.Oid;
            return obj;
        }

        internal static ParteAsistencia GetChild(ParteAsistencia source)
        {
            return new ParteAsistencia(source);
        }

        internal static ParteAsistencia GetChild(int session_code, IDataReader reader, bool childs)
        {
            return new ParteAsistencia(session_code, reader, childs);
        }


        internal static ParteAsistencia GetChild(int session_code, IDataReader reader)
        {
            return GetChild(session_code, reader, true);
        }

        public virtual void CreateAlumnosList(AlumnoList alumnos, long grupo)
        {
            Alumno_Partes = Alumno_Partes.NewChildList();

            foreach (AlumnoInfo item in alumnos)
            {
                if ((item.Grupo == grupo) || (grupo == 3))
                {
                    Alumno_Parte obj = Alumno_Parte.NewChild(this);

                    obj.OidAlumno = item.Oid;

                    this.Alumno_Partes.Add(obj);
                }
            }
        }

        public virtual void CreatePartePracticas(long oid_clase_practica)
        {
            Alumnos_Practicas = Alumnos_Practicas.NewChildList();

            foreach (Alumno_Parte item in Alumno_Partes)
            {
                Alumno_Practica obj = Alumno_Practica.NewChild(this);

                obj.OidAlumno = item.OidAlumno;
                obj.OidClasePractica = oid_clase_practica;
                if (item.Falta)
                    obj.Calificacion = Resources.Labels.FALTA_ASISTENCIA_LABEL;
                else
                    obj.Calificacion = Resources.Labels.SIN_CALIFICAR_LABEL;

                this.Alumnos_Practicas.Add(obj);
            }
        }

        public virtual void UpdateAlumnosPracticas()
        {
            ParteAsistenciaInfo item = ParteAsistenciaInfo.Get(this.Oid, true);

            foreach (Alumno_Practica practica in Alumnos_Practicas)
            {
                foreach (Alumno_Parte parte in Alumno_Partes)
                {
                    if (practica.OidAlumno == parte.OidAlumno)
                    {
                        if (parte.Falta)
                            practica.Calificacion = Resources.Labels.FALTA_ASISTENCIA_LABEL;
                        else
                        {
                            Alumno_ParteInfo ant = item.Alumno_Partes.GetItem(parte.Oid);
                            if (ant != null && ant.Falta)
                                practica.Calificacion = Resources.Labels.SIN_CALIFICAR_LABEL;
                        }
                        break;
                    }
                }
            }
        }


        /// <summary>
        /// Borrado aplazado, es posible el undo 
        /// (La función debe ser "no estática")
        /// </summary>
        public override void Delete()
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            MarkDeleted();
        }


        #endregion

        #region Common Data Access

        [RunLocal()]
        private void DataPortal_Create(CriteriaCs criteria)
        {
            Random r = new Random();
            Oid = (long)r.Next();
        }

        #endregion

        #region Child Data Access

        private void Fetch(ParteAsistencia source)
        {
            try
            {
                SessionCode = source.SessionCode;

                _base.CopyValues(source);

                CriteriaEx criteria = Alumno_Parte.GetCriteria(Session());
                criteria.AddEq("OidParte", this.Oid);
                _alumnos = Alumno_Partes.GetChildList(criteria.List<Alumno_Parte>());

                criteria = Alumno_Practica.GetCriteria(Session());
                criteria.AddEq("OidParte", this.Oid);
                _alumnos_practicas = Alumnos_Practicas.GetChildList(criteria.List<Alumno_Practica>());

                //criteria = Concepto_Parte.GetCriteria(Session());
                //criteria.AddEq("OidParte", this.Oid);
                //_conceptos = Conceptos_Partes.GetChildList(criteria.List<Concepto_Parte>());

                criteria = Clase_Parte.GetCriteria(Session());
                criteria.AddEq("OidParte", this.Oid);
                _clases = Clases_Partes.GetChildList(criteria.List<Clase_Parte>());


            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        private void Fetch(int session_code, IDataReader source)
        {
            try
            {
                _base.CopyValues(source);

                if (Childs)
                {
                    Alumno_Parte.DoLOCK( Session(session_code));

                    string query = Alumno_Partes.SELECT(GetInfo(false));
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _alumnos = Alumno_Partes.GetChildList(reader);

                    Alumno_Practica.DoLOCK(Session(session_code));

                    query = Alumnos_Practicas.SELECT(GetInfo(false));
                    reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _alumnos_practicas = Alumnos_Practicas.GetChildList(reader);

                    //Concepto_Parte.DoLOCK(Session(session_code));

                    //query = Conceptos_Partes.SELECT_BY_PARTE(this.Oid);
                    //reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    //_conceptos = Conceptos_Partes.GetChildList(reader);

                    Clase_Parte.DoLOCK(Session(session_code));

                    query = Clases_Partes.SELECT_BY_PARTE(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _clases = Clases_Partes.GetChildList(reader);
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Insert(Horario parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidHorario = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                parent.Session().Save(this.Base.Record);

                _alumnos.Update(this);
                //_conceptos.Update(this);
                _alumnos_practicas.Update(this);
                _clases.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Update(Horario parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidHorario = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                ParteAsistenciaRecord obj = parent.Session().Get<ParteAsistenciaRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);

                _alumnos.Update(this);
                //_conceptos.Update(this);
                _alumnos_practicas.Update(this);
                _clases.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(Horario parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                SessionCode = parent.SessionCode;
                Session().Delete(Session().Get<ParteAsistenciaRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }


        #endregion

        #region Root Data Access

        // called to retrieve data from the database
        private void DataPortal_Fetch(CriteriaEx criteria)
        {
            try
            {
                SessionCode = criteria.SessionCode;

                Childs = criteria.Childs;

                if (nHMng.UseDirectSQL)
                {
                    ParteAsistencia.DoLOCK( Session());
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query);

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        Alumno_Parte.DoLOCK( Session());

                        string query = Alumno_Partes.SELECT_BY_PARTE_ORDERED(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _alumnos = Alumno_Partes.GetChildList(reader);

                        Alumno_Practica.DoLOCK(Session());

                        query = Alumnos_Practicas.SELECT(GetInfo(false));
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _alumnos_practicas = Alumnos_Practicas.GetChildList(reader);

                        //Concepto_Parte.DoLOCK(Session());

                        //query = Conceptos_Partes.SELECT_BY_PARTE(this.Oid);
                        //reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        //_conceptos = Conceptos_Partes.GetChildList(reader);

                        Clase_Parte.DoLOCK(Session());

                        query = Clases_Partes.SELECT_BY_PARTE(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _clases = Clases_Partes.GetChildList(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                if (Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(ex);
            }
        }

        [Transactional(TransactionalTypes.Manual)]
        protected override void DataPortal_Insert()
        {
            try
            {
                SessionCode = OpenSession();
                BeginTransaction();
                Session().Save(this.Base.Record);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
        }

        [Transactional(TransactionalTypes.Manual)]
        protected override void DataPortal_Update()
        {
            if (IsDirty)
            {
                try
                {
                    ParteAsistenciaRecord obj = Session().Get<ParteAsistenciaRecord>(Oid);
                    obj.CopyValues(this.Base.Record);
                    Session().Update(obj);
                }
                catch (Exception ex)
                {
                    iQExceptionHandler.TreatException(ex);
                }
            }
        }

        // deferred deletion
        [Transactional(TransactionalTypes.Manual)]
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new CriteriaCs(Oid));
        }

        // inmediate deletion
        [Transactional(TransactionalTypes.Manual)]
        private void DataPortal_Delete(CriteriaCs criterio)
        {
            try
            {
                //Iniciamos la conexion y la transaccion
                SessionCode = OpenSession();
                BeginTransaction();

                CriteriaEx criteria = GetCriteria();
                criteria.AddOidSearch(criterio.Oid);

                // Obtenemos el objeto
                ParteAsistenciaRecord obj = (ParteAsistenciaRecord)(criteria.UniqueResult());
                Session().Delete(Session().Get<ParteAsistenciaRecord>(obj.Oid));

                Transaction().Commit();
            }
            catch (Exception ex)
            {
                if (Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                CloseSession();
            }
        }

        #endregion

        #region Commands

        //public virtual bool GeneraAlbaran()
        //{
        //    /*VariableList lista = VariableList.GetList();

        //    VariableInfo v_serie = lista.GetItem(ModuleControler.GetInstruccionSerieVariableName());
        //    SerieInfo serie = SerieInfo.Get(Convert.ToInt64(v_serie.Value), false);
        //    if (serie.Oid == 0)
        //        return false;

        //    VariableInfo v_producto = lista.GetItem(ModuleControler.GetInstruccionProductoVariableName());
        //    ProductoInfo producto = ProductoInfo.Get(Convert.ToInt64(v_producto.Value), false);
        //    if (producto.Oid == 0)
        //        return false;*/

        //    SerieInfo serie = null;
        //    ProductInfo producto = null;

        //    try
        //    {
        //        if (Tipo == 1 || Tipo == 2)
        //        {
        //            HorarioInfo horario = HorarioInfo.Get(OidHorario, false);
        //            PlanEstudiosInfo plan = PlanEstudiosInfo.Get(horario.OidPlan, false);
        //            serie = SerieInfo.Get(plan.OidSerie, false);
        //            producto = ProductInfo.Get(plan.OidProducto, false);
        //        }
        //        else
        //        {
        //            if (Clases.Count > 0)
        //            {
        //                ClaseExtraInfo clase = ClaseExtraInfo.Get(Clases[0].OidClase);
        //                PlanExtraInfo plan = PlanExtraInfo.Get(clase.OidPlan, false);
        //                serie = SerieInfo.Get(plan.OidSerie, false);
        //                producto = ProductInfo.Get(plan.OidProducto, false);
        //            }
        //        }

        //        if (producto == null || serie == null)
        //            return false;
        //    }
        //    catch { return false; }


        //    if (Conceptos != null && Conceptos.Count > 0)
        //    {
        //        foreach (Concepto_Parte item in Conceptos)
        //        {
        //            InputDeliveryLineInfo concpt = InputDeliveryLineInfo.Get(item.OidConcepto);
        //            if (concpt != null && concpt.Oid != 0)
        //            {
        //                InputDeliveryInfo info = InputDeliveryInfo.Get(concpt.OidAlbaran, ETipoAcreedor.Instructor);
        //                if (info.Facturado)
        //                    return false;
        //                InputDelivery alb = InputDelivery.Get(concpt.OidAlbaran, ETipoAcreedor.Instructor, true, SessionCode);
        //                if (alb != null)
        //                {
        //                    alb.Conceptos.Remove(concpt.Oid);
        //                    alb.CalculateTotal();
        //                    alb.Save();
        //                    //alb.CloseSession();
        //                }

        //                if (alb.Conceptos.Count == 0)
        //                    InputDelivery.Delete(alb.Oid, alb.ETipoAcreedor);
        //            }
        //        }
        //    }

        //    this.Conceptos = Conceptos_Partes.NewChildList();
        //    Concepto_Parte concepto = this.Conceptos.NewItem(this);
            
        //    InputDeliveryList albaranes = InputDeliveryList.GetListByAcreedor(false, ETipoAcreedor.Instructor, this.OidInstructorEfectivo, ETipoAlbaranes.NoFacturados, 
        //        new DateTime(this.Fecha.Year, this.Fecha.Month, 1), new DateTime(this.Fecha.Year, this.Fecha.Month, DateTime.DaysInMonth(this.Fecha.Year, this.Fecha.Month)));

        //    long oid_albaran = 0;

        //    foreach (InputDeliveryInfo albaran_info in albaranes)
        //    {
        //        if (albaran_info.Fecha.Month == this.Fecha.Month
        //            && albaran_info.Fecha.Year == this.Fecha.Year
        //            && !albaran_info.Facturado)
        //        {
        //            oid_albaran = albaran_info.Oid;
        //            break;
        //        }
        //    }

        //    InputDelivery albaran = null;

        //    InstructorInfo instructor = InstructorInfo.Get(this.OidInstructorEfectivo, true);

        //    if (oid_albaran != 0)
        //        albaran = InputDelivery.Get(oid_albaran, ETipoAcreedor.Instructor, true, SessionCode);
        //    else
        //    {
        //        albaran = InputDelivery.New();
        //        albaran.SessionCode = SessionCode;
        //        albaran.ETipoAcreedor = ETipoAcreedor.Instructor;
        //        albaran.OidAcreedor = this.OidInstructorEfectivo;
        //        albaran.OidSerie = serie.Oid;
        //        albaran.Fecha = this.Fecha;
        //        albaran.OidAlmacen = 0;
        //        while (albaran.Fecha.Day != DateTime.DaysInMonth(albaran.Fecha.Year, albaran.Fecha.Month))
        //            albaran.Fecha = albaran.Fecha.AddDays(1);

        //        albaran.PIRPF = instructor.PIRPF;
        //    }

        //    InputDeliveryLine concepto_albaran = InputDeliveryLine.NewChild(albaran);

        //    concepto_albaran.Compra(albaran, serie, instructor, producto);
        //    concepto_albaran.Concepto += " " + this.Fecha.ToShortDateString() + " " + this.HoraInicio + " " + this.Promocion;
        //    concepto_albaran.CantidadKilos = Convert.ToDateTime(this.NHoras).Hour;
        //    concepto_albaran.CantidadBultos = concepto_albaran.CantidadKilos / producto.KilosBulto;
        //    concepto_albaran = albaran.Compra(producto, concepto_albaran);
        //    concepto_albaran.OidAlmacen = 0;
        //    albaran.CalculateTotal();
        //    albaran.Save();
        //    //SUPER PARCHE DE LA VIDA!! 
        //    if (nHManager.Instance.Sessions.Count > 5)
        //        CloseSession(nHManager.Instance.Sessions.Count - 1);
        //    //albaran.CloseSession();

        //    concepto.OidConcepto = concepto_albaran.Oid;

        //    return true;
        //}

        #endregion

        #region SQL

        internal static string SELECT_FIELDS()
        {
            string query;

            query = "SELECT PA.*," +
                    "       E.\"NOMBRE\" AS \"INSTRUCTOR\"," +
                    "       EE.\"NOMBRE\" AS \"INSTRUCTOR_EFECTIVO\"," +
                    "       P.\"NOMBRE\" AS \"PROMOCION\"";

            return query;
        }

        internal static string SELECT(long oid, bool lock_table)
        {
            string pa = nHManager.Instance.GetSQLTable(typeof(ParteAsistenciaRecord));
            string e = nHManager.Instance.GetSQLTable(typeof(InstructorRecord));
            string h = nHManager.Instance.GetSQLTable(typeof(HorarioRecord));
            string p = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));
            string c_p = nHManager.Instance.GetSQLTable(typeof(Clase_ParteRecord));
            string sm = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
            string si = nHManager.Instance.GetSQLTable(typeof(Submodulo_InstructorRecord));
            string ct = nHManager.Instance.GetSQLTable(typeof(ClaseTeoricaRecord));
            string ce = nHManager.Instance.GetSQLTable(typeof(ClaseExtraRecord));
            string cp = nHManager.Instance.GetSQLTable(typeof(ClasePracticaRecord));

            bool autorizado = ModulePrincipal.GetMostrarInstructoresAutorizadosSetting();

            string query;

            if (!autorizado)
            {
                query = ParteAsistencia.SELECT_FIELDS() +
                        " FROM " + pa + " AS PA" +
                        " INNER JOIN " + e + " AS E ON PA.\"OID_INSTRUCTOR\" = E.\"OID\"" +
                        " INNER JOIN " + e + " AS EE ON PA.\"OID_INSTRUCTOR_EFECTIVO\" = EE.\"OID\"" +
                        " INNER JOIN " + h + " AS H ON PA.\"OID_HORARIO\" = H.\"OID\"" +
                        " INNER JOIN " + p + " AS P ON H.\"OID_PROMOCION\" = P.\"OID\"";

                if (oid > 0) query += " WHERE PA.\"OID\" = " + oid.ToString();
            }
            else
            {
                query = "SELECT PA.*," +
                        "   COALESCE(IA.\"NOMBRE\", E.\"NOMBRE\") AS \"INSTRUCTOR\"," +
                        "   EE.\"NOMBRE\" AS \"INSTRUCTOR_EFECTIVO\"," +
                        "   P.\"NOMBRE\" AS \"PROMOCION\"" +
                        " FROM " + pa + " AS PA" +
                        " INNER JOIN " + e + " AS E ON PA.\"OID_INSTRUCTOR\" = E.\"OID\"" +
                        " INNER JOIN " + e + " AS EE ON PA.\"OID_INSTRUCTOR_EFECTIVO\" = EE.\"OID\"" +
                        " INNER JOIN " + h + " AS H ON PA.\"OID_HORARIO\" = H.\"OID\"" +
                        " INNER JOIN " + p + " AS P ON H.\"OID_PROMOCION\" = P.\"OID\"" +
                        " LEFT JOIN (	SELECT CP.\"OID_PARTE\"" +
                        "            , MIN(\"OID_SUBMODULO\") AS \"OID_SUBMODULO\"" +
                        "        FROM " + c_p + " AS CP" +
                        "        INNER JOIN (	SELECT SM.\"OID\" AS \"OID_SUBMODULO\"" +
                        "                    , COALESCE(CT.\"OID\", 0) AS \"OID_CLASE_TEORICA\"" +
                        "                    , COALESCE(CP.\"OID\", 0) AS \"OID_CLASE_PRACTICA\"" +
                        "                    , COALESCE(CE.\"OID\", 0) AS \"OID_CLASE_EXTRA\"" +
                        "                FROM " + sm + " AS SM" +
                        "                LEFT JOIN " + ct + " AS CT ON CT.\"OID_SUBMODULO\" = SM.\"OID\"" +
                        "                LEFT JOIN " + cp + " AS CP ON CP.\"OID_SUBMODULO\" = SM.\"OID\"" +
                        "                LEFT JOIN " + ce + " AS CE ON CE.\"OID_SUBMODULO\" = SM.\"OID\")" +
                        "            AS CL ON (CP.\"OID_CLASE\" = CL.\"OID_CLASE_TEORICA\" AND CP.\"TIPO\" = 1)" +
                        "                OR (CP.\"OID_CLASE\" = CL.\"OID_CLASE_PRACTICA\" AND CP.\"TIPO\" = 2)" +
                        "                OR (CP.\"OID_CLASE\" = CL.\"OID_CLASE_EXTRA\" AND CP.\"TIPO\" = 3)" +
                        "        GROUP BY CP.\"OID_PARTE\")" +
                        "    AS CP ON CP.\"OID_PARTE\" = PA.\"OID\"" +
                        " LEFT JOIN " + si + " AS SI ON SI.\"OID_INSTRUCTOR\" = E.\"OID\" AND SI.\"OID_SUBMODULO\" = CP.\"OID_SUBMODULO\" AND PA.\"FECHA\" BETWEEN COALESCE(SI.\"FECHA_INICIO\", '01-01-0001') AND COALESCE(SI.\"FECHA_FIN\", '12-31-9999')" +
                        " LEFT JOIN " + e + " AS IA ON IA.\"OID\" = SI.\"OID_INSTRUCTOR_SUPLENTE\"";

                if (oid > 0) query += " WHERE PA.\"OID\" = " + oid.ToString();
            
            }

            if (lock_table) query += " FOR UPDATE OF PA NOWAIT";

            return query;
        }

        internal new static string SELECT(long oid) { return ParteAsistencia.SELECT(oid, true); }

        #endregion
    }
}

