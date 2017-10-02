using System;
using System.ComponentModel;
using System.Data;

using Csla;
using Csla.Validation;
using NHibernate;

using moleQule.Library;
using moleQule.Library.CslaEx;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class AlumnoExamenRecord : RecordBase
	{
		#region Attributes

		private long _oid_alumno;
		private long _oid_examen;
		private string _observaciones = string.Empty;
		private bool _presentado = false;
		private Decimal _calificacion;
  
		#endregion
		
		#region Properties
		
				public virtual long OidAlumno { get { return _oid_alumno; } set { _oid_alumno = value; } }
		public virtual long OidExamen { get { return _oid_examen; } set { _oid_examen = value; } }
		public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
		public virtual bool Presentado { get { return _presentado; } set { _presentado = value; } }
		public virtual Decimal Calificacion { get { return _calificacion; } set { _calificacion = value; } }

		#endregion
		
		#region Business Methods
		
		public AlumnoExamenRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_alumno = Format.DataReader.GetInt64(source, "OID_ALUMNO");
			_oid_examen = Format.DataReader.GetInt64(source, "OID_EXAMEN");
			_observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");
			_presentado = Format.DataReader.GetBool(source, "PRESENTADO");
			_calificacion = Format.DataReader.GetDecimal(source, "CALIFICACION");

		}		
		public virtual void CopyValues(AlumnoExamenRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_alumno = source.OidAlumno;
			_oid_examen = source.OidExamen;
			_observaciones = source.Observaciones;
			_presentado = source.Presentado;
			_calificacion = source.Calificacion;
		}
		
		#endregion	
	}

    [Serializable()]
	public class AlumnoExamenBase 
	{	 
		#region Attributes
		
		private AlumnoExamenRecord _record = new AlumnoExamenRecord();

        protected long _oid_promocion;
        protected string _modulo = string.Empty;
        protected DateTime _fecha_examen;
        protected bool _desarrollo = false;
        protected string _calificacion_string = string.Empty;
		
		#endregion
		
		#region Properties
		
		public AlumnoExamenRecord Record { get { return _record; } }

        public long OidPromocion { get { return _oid_promocion; } set { _oid_promocion = value; } }
        public string Modulo { get { return _modulo; } }
        public DateTime FechaExamen { get { return _fecha_examen; } }
        public bool Desarrollo { get { return _desarrollo; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);

            _record.Observaciones = DBNull.Value.Equals(source["OBSERVACIONES"]) ? string.Empty : source["OBSERVACIONES"].ToString();
            _modulo = Format.DataReader.GetString(source, "NUMERO_MODULO") + " " + Format.DataReader.GetString(source, "TEXTO");
            _fecha_examen = Format.DataReader.GetDateTime(source, "FECHA_EXAMEN");
            _desarrollo = Format.DataReader.GetBool(source, "DESARROLLO");
		}		
		public void CopyValues(Alumno_Examen source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(Alumno_ExamenInfo source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		
		#endregion	
	}
		
	/// <summary>
	/// Editable Root Business Object
	/// </summary>	
    [Serializable()]
	public class Alumno_Examen : BusinessBaseEx<Alumno_Examen>
	{	 
		#region Attributes
		
		protected AlumnoExamenBase _base = new AlumnoExamenBase();

        private Respuesta_Alumno_Examenes _respuestas = Respuesta_Alumno_Examenes.NewChildList();		

		#endregion
		
		#region Properties
		
		public AlumnoExamenBase Base { get { return _base; } }
		
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
				//////CanWriteProperty(true);
				if (!_base.Record.Oid.Equals(value))
				{
					_base.Record.Oid = value;
					//PropertyHasChanged();
				}
			}
		}
		public virtual long OidAlumno
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidAlumno;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.OidAlumno.Equals(value))
				{
					_base.Record.OidAlumno = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidExamen
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidExamen;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.OidExamen.Equals(value))
				{
					_base.Record.OidExamen = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Observaciones
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Observaciones;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Observaciones.Equals(value))
				{
					_base.Record.Observaciones = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool Presentado
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Presentado;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.Presentado.Equals(value))
				{
					_base.Record.Presentado = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual Decimal Calificacion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Calificacion;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.Calificacion.Equals(value))
				{
					_base.Record.Calificacion = value;
					PropertyHasChanged();
				}
			}
		}

        public long OidPromocion { get { return _base.OidPromocion; } set { _base.OidPromocion = value; } }
        public string Modulo { get { return _base.Modulo; } }
        public DateTime FechaExamen { get { return _base.FechaExamen; } }
        public bool Desarrollo { get { return _base.Desarrollo; } }
	
        
        public virtual Respuesta_Alumno_Examenes Respuestas
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _respuestas;
            }

            set
            {
                _respuestas = value;
            }
        }
		
		
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidAlumno", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                   new CommonRules.MinValueRuleArgs<long>("OidExamen", 1));
            
        }

        #endregion

        #region Autorization Rules

        public static bool CanAddObject()
        {
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.ALUMNO);

        }

        public static bool CanGetObject()
        {
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.ALUMNO);

        }

        public static bool CanDeleteObject()
        {
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.ALUMNO);

        }
        public static bool CanEditObject()
        {
            return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.ALUMNO);

        }

        #endregion

        #region Common Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los Factory Methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        public Alumno_Examen()
        {
            MarkAsChild();
            Random r = new Random();
            Oid = (long)r.Next();
        }

        public virtual Alumno_ExamenInfo GetInfo(bool get_childs)
        {

            if (!CanGetObject())
                throw new System.Security.SecurityException(moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new Alumno_ExamenInfo(this, get_childs);

        }

        public virtual Alumno_ExamenInfo GetInfo()
        {
            return GetInfo(true);
        }

        #endregion

        #region Child Factory Methods

        private Alumno_Examen(Alumno_Examen source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private Alumno_Examen(int session_code, IDataReader reader, bool childs)
        {
            MarkAsChild();
            Childs = childs;
            Fetch(session_code, reader);
        }

        public static Alumno_Examen NewChild(Alumno parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Alumno_Examen obj = new Alumno_Examen();
            obj.OidAlumno = parent.Oid;
            return obj;
        }

        public static Alumno_Examen NewChild(Examen parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Alumno_Examen obj = new Alumno_Examen();
            obj.OidExamen = parent.Oid;
            return obj;
        }

        internal static Alumno_Examen GetChild(Alumno_Examen source)
        {
            return new Alumno_Examen(source);
        }

        internal static Alumno_Examen GetChild(int session_code, IDataReader reader, bool childs)
        {
            return new Alumno_Examen(session_code, reader, childs);
        }

        internal static Alumno_Examen GetChild(int session_code, IDataReader reader)
        {
            return GetChild(session_code, reader, true);
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

        /// <summary>
        /// No se debe utilizar esta función para guardar. Hace falta el padre.
        /// Utilizar Insert o Update en sustitución de Save.
        /// </summary>
        /// <returns></returns>
        public override Alumno_Examen Save()
        {
            throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
        }


        #endregion

        #region Root Factory Methods

        public static Alumno_Examen New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<Alumno_Examen>(new CriteriaCs(-1));
        }

        public static Alumno_Examen Get(long oid)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = Alumno_Examen.GetCriteria(Alumno_Examen.OpenSession());

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = Alumno_Examen.SELECT(oid);
            else
                criteria.AddOidSearch(oid);

            Alumno_Examen.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Alumno_Examen>(criteria);
        }

        public static Alumno_Examen Get(CriteriaEx criteria)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Alumno_Examen.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Alumno_Examen>(criteria);
        }

        public virtual void LoadChilds(Type type, bool get_childs)
        {
            if (type.Equals(typeof(Respuesta_Alumno_Examenes)))
            {
                _respuestas = Respuesta_Alumno_Examenes.GetChildList(this, get_childs);
            }
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
        /// Elimina todas los Submodulos
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = Alumno_Examen.OpenSession();
            ISession sess = Alumno_Examen.Session(sessCode);
            ITransaction trans = Alumno_Examen.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from Alumno_Examen");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                Alumno_Examen.CloseSession(sessCode);
            }
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

        private void Fetch(Alumno_Examen source)
        {
            try
            {
                SessionCode = source.SessionCode;

                _base.CopyValues(source);

                CriteriaEx criteria;

                criteria = Respuesta_Alumno_Examen.GetCriteria(Session());
                criteria.AddEq("OidAlumnoExamen", this.Oid);
                _respuestas = Respuesta_Alumno_Examenes.GetChildList(criteria.List<Respuesta_Alumno_Examen>());

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

                    string query;

                    Respuesta_Alumno_Examen.DoLOCK(Session(session_code));
                    query = Respuesta_Alumno_Examenes.SELECT_BY_ALUMNO_EXAMEN(this.Oid);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _respuestas = Respuesta_Alumno_Examenes.GetChildList(reader);
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Insert(Alumno parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidAlumno = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                parent.Session().Save(this.Base.Record);

                _respuestas.Update(this, parent.Session());
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Update(Alumno parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidAlumno = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                AlumnoExamenRecord obj = parent.Session().Get<AlumnoExamenRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);

                _respuestas.Update(this, parent.Session());
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(Alumno parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                parent.Session().Delete(parent.Session().Get<AlumnoExamenRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }

        internal void Insert(Examen parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidExamen = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                parent.Session().Save(this.Base.Record);

                _respuestas.Update(this, parent.Session());
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Update(Examen parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidExamen = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                AlumnoExamenRecord obj = parent.Session().Get<AlumnoExamenRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);

                _respuestas.Update(this, parent.Session());
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(Examen parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                parent.Session().Delete(parent.Session().Get<AlumnoExamenRecord>(Oid));
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

                    Alumno_Examen.DoLOCK(Session());
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        string query;

                        Respuesta_Alumno_Examen.DoLOCK(Session());
                        query = Respuesta_Alumno_Examenes.SELECT_BY_ALUMNO_EXAMEN(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _respuestas = Respuesta_Alumno_Examenes.GetChildList(reader);
                    }
                }
                else
                {
                    _base.Record.CopyValues((AlumnoExamenRecord)(criteria.UniqueResult()));

                    //Session().Lock(Session().Get<AlumnoExamenRecord>(Oid), LockMode.UpgradeNoWait);

                    if (Childs)
                    {
                        criteria = Respuesta_Alumno_Examen.GetCriteria(Session());
                        criteria.AddEq("OidAlumnoExamen", this.Oid);
                        _respuestas = Respuesta_Alumno_Examenes.GetChildList(criteria.List<Respuesta_Alumno_Examen>());

                    }
                }
            }
            catch (NHibernate.ADOException)
            {
                if (Transaction() != null) Transaction().Rollback();
                throw new iQLockException(moleQule.Library.Resources.Messages.LOCK_ERROR);
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

                _respuestas.Update(this, Session());
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
                    AlumnoExamenRecord obj = Session().Get<AlumnoExamenRecord>(Oid);
                    obj.CopyValues(this.Base.Record);
                    Session().Update(obj);

                    _respuestas.Update(this, Session());
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
                AlumnoExamenRecord obj = (AlumnoExamenRecord)(criteria.UniqueResult());
                Session().Delete(Session().Get<AlumnoExamenRecord>(obj.Oid));

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

        #region SQL

        internal static string SELECT_FIELDS()
        {
            string query;

            query = "SELECT AE.*," +
                    "   E.\"FECHA_EXAMEN\"," +
                    "   E.\"DESARROLLO\"," +
                    "   M.\"NUMERO_MODULO\"," +
                    "   M.\"TEXTO\"";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string alumno_examen = nHManager.Instance.GetSQLTable(typeof(AlumnoExamenRecord));
            string examen = nHManager.Instance.GetSQLTable(typeof(ExamenRecord));
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));

            query = " FROM " + alumno_examen + " AS AE" +
                    " INNER JOIN " + examen + " AS E ON (E.\"OID\" = AE.\"OID_EXAMEN\")" +
                    " INNER JOIN " + modulo + " AS M ON (M.\"OID\" = E.\"OID_MODULO\")";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.Examen != null && conditions.Examen.Oid > 0)
                query += " AND AE.\"OID_EXAMEN\" = " + conditions.Examen.Oid;
            if (conditions.Alumno != null && conditions.Alumno.Oid > 0)
                query += " AND AE.\"OID_ALUMNO\" = " + conditions.Alumno.Oid;

            return query;
        }

        internal static string ORDER()
        {
            string query;

            query = " ORDER BY M.\"NUMERO_ORDEN\", E.\"DESARROLLO\", E.\"FECHA_EXAMEN\"";

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {

            string query = string.Empty;

            query = SELECT_FIELDS() +
                JOIN() +
                WHERE(conditions) +
                ORDER();
            
            if (lockTable) query += " FOR UPDATE OF AE NOWAIT";

            return query;
        }


        #endregion

    }
}

