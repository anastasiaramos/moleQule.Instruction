using System;
using System.ComponentModel;
using System.Data;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;

using moleQule.Library;

using NHibernate;
using System.Reflection;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class Convocatoria_CursoRecord : RecordBase
	{
		#region Attributes

		private string _codigo = string.Empty;
		private long _serial;
		private string _nombre = string.Empty;
		private DateTime _fecha_inicio;
		private DateTime _fecha_caducidad;
		private string _observaciones = string.Empty;
		private long _oid_curso;
  
		#endregion
		
		#region Properties
		
				public virtual string Codigo { get { return _codigo; } set { _codigo = value; } }
		public virtual long Serial { get { return _serial; } set { _serial = value; } }
		public virtual string Nombre { get { return _nombre; } set { _nombre = value; } }
		public virtual DateTime FechaInicio { get { return _fecha_inicio; } set { _fecha_inicio = value; } }
		public virtual DateTime FechaCaducidad { get { return _fecha_caducidad; } set { _fecha_caducidad = value; } }
		public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
		public virtual long OidCurso { get { return _oid_curso; } set { _oid_curso = value; } }

		#endregion
		
		#region Business Methods
		
		public Convocatoria_CursoRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_codigo = Format.DataReader.GetString(source, "CODIGO");
			_serial = Format.DataReader.GetInt64(source, "SERIAL");
			_nombre = Format.DataReader.GetString(source, "NOMBRE");
			_fecha_inicio = Format.DataReader.GetDateTime(source, "FECHA_INICIO");
			_fecha_caducidad = Format.DataReader.GetDateTime(source, "FECHA_CADUCIDAD");
			_observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");
			_oid_curso = Format.DataReader.GetInt64(source, "OID_CURSO");

		}		
		public virtual void CopyValues(Convocatoria_CursoRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_codigo = source.Codigo;
			_serial = source.Serial;
			_nombre = source.Nombre;
			_fecha_inicio = source.FechaInicio;
			_fecha_caducidad = source.FechaCaducidad;
			_observaciones = source.Observaciones;
			_oid_curso = source.OidCurso;
		}
		
		#endregion	
	}

    [Serializable()]
	public class Convocatoria_CursoBase 
	{	 
		#region Attributes
		
		private Convocatoria_CursoRecord _record = new Convocatoria_CursoRecord();
		
		#endregion
		
		#region Properties
		
		public Convocatoria_CursoRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(Convocatoria_Curso source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(Convocatoria_CursoInfo source)
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
	public class Convocatoria_Curso : BusinessBaseEx<Convocatoria_Curso>
	{	 
		#region Attributes
		
		protected Convocatoria_CursoBase _base = new Convocatoria_CursoBase();

        private Alumno_Convocatorias _alumnos = Alumno_Convocatorias.NewChildList();
		

		#endregion
		
		#region Properties
		
		public Convocatoria_CursoBase Base { get { return _base; } }
		
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
		public virtual string Codigo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Codigo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Codigo.Equals(value))
				{
					_base.Record.Codigo = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long Serial
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Serial;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.Serial.Equals(value))
				{
					_base.Record.Serial = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Nombre
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Nombre;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Nombre.Equals(value))
				{
					_base.Record.Nombre = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual DateTime FechaInicio
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.FechaInicio;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.FechaInicio.Equals(value))
				{
					_base.Record.FechaInicio = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual DateTime FechaCaducidad
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.FechaCaducidad;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.FechaCaducidad.Equals(value))
				{
					_base.Record.FechaCaducidad = value;
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
		public virtual long OidCurso
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidCurso;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.OidCurso.Equals(value))
				{
					_base.Record.OidCurso = value;
					PropertyHasChanged();
				}
			}
		}
			

        public virtual Alumno_Convocatorias Alumnos
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

        public override bool IsValid
        {
            get { return base.IsValid && _alumnos.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _alumnos.IsDirty; }
        }
		
		#endregion
		
		#region Business Methods
		
		public virtual Convocatoria_Curso CloneAsNew()
		{
			Convocatoria_Curso clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.GetNewCode();
			
			clon.SessionCode = Convocatoria_Curso.OpenSession();
			Convocatoria_Curso.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(Convocatoria_CursoInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			Codigo = source.Codigo;
			Serial = source.Serial;
			Nombre = source.Nombre;
			FechaInicio = source.FechaInicio;
			FechaCaducidad = source.FechaCaducidad;
			Observaciones = source.Observaciones;
			OidCurso = source.OidCurso;
		}
		
		
        public virtual void GetNewCode()
        {
            Serial = SerialInfo.GetNext(typeof(Convocatoria_Curso));
            Codigo = Serial.ToString(Resources.Defaults.CONVOCATORIA_CODE_FORMAT);
        }				
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidCurso", 1));

            ValidationRules.AddRule(Csla.Validation.CommonRules.StringRequired, "Nombre");
        }

        #endregion

        #region Autorization Rules

        public static bool CanAddObject()
        {
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.CURSO);

        }

        public static bool CanGetObject()
        {
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.CURSO);

        }

        public static bool CanDeleteObject()
        {
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.CURSO);

        }
        public static bool CanEditObject()
        {
            return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.CURSO);

        }

        #endregion

        #region Common Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        protected Convocatoria_Curso() 
        {
            Random r = new Random();
            Oid = (long)r.Next();
            GetNewCode();

            _alumnos = Alumno_Convocatorias.NewChildList();
        }

        public virtual Convocatoria_CursoInfo GetInfo(bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new Convocatoria_CursoInfo(this, get_childs);
        }

        public virtual Convocatoria_CursoInfo GetInfo()
        {
            return GetInfo(true);
        }

        #endregion

        #region Root Factory Methods

        public static Convocatoria_Curso New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<Convocatoria_Curso>(new CriteriaCs(-1));
        }

        public static Convocatoria_Curso Get(long oid)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = Convocatoria_Curso.GetCriteria(Convocatoria_Curso.OpenSession());
            criteria.AddOidSearch(oid);
            Convocatoria_Curso.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Convocatoria_Curso>(criteria);
        }

        public static Convocatoria_Curso Get(CriteriaEx criteria)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Convocatoria_Curso.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Convocatoria_Curso>(criteria);
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
        /// Elimina todas los Convocatoria_Cursos
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = Convocatoria_Curso.OpenSession();
            ISession sess = Convocatoria_Curso.Session(sessCode);
            ITransaction trans = Convocatoria_Curso.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from Convocatoria_Curso");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                Convocatoria_Curso.CloseSession(sessCode);
            }
        }

        public override Convocatoria_Curso Save()
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

        private Convocatoria_Curso(Convocatoria_Curso source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private Convocatoria_Curso(int session_code, IDataReader reader, bool childs)
        {
            MarkAsChild();
            Childs = childs;
            Fetch(session_code, reader);
        }

        public static Convocatoria_Curso NewChild(Curso parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Convocatoria_Curso obj = new Convocatoria_Curso();
            obj.OidCurso = parent.Oid;
            obj.MarkAsChild();
            return obj;
        }

        internal static Convocatoria_Curso GetChild(Convocatoria_Curso source)
        {
            return new Convocatoria_Curso(source);
        }

        internal static Convocatoria_Curso GetChild(int session_code, IDataReader reader, bool childs)
        {
            return new Convocatoria_Curso(session_code, reader, childs);
        }
        
        internal static Convocatoria_Curso GetChild(int session_code, IDataReader reader)
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


        #endregion

        #region Common Data Access

        [RunLocal()]
        private void DataPortal_Create(CriteriaCs criteria)
        {
        }

        #endregion

        #region Child Data Access

        private void Fetch(Convocatoria_Curso source)
        {
            try
            {
                SessionCode = source.SessionCode;

                _base.CopyValues(source);

                if (Childs)
                {
                    CriteriaEx criteria = Alumno_Convocatoria.GetCriteria(Session());
                    criteria.AddEq("OidConvocatoria", this.Oid);
                    _alumnos = Alumno_Convocatorias.GetChildList(criteria.List<Alumno_Convocatoria>());
                }
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
                    Alumno_Convocatoria.DoLOCK( Session(session_code));

                    string query = Alumno_Convocatorias.SELECT_BY_CONVOCATORIA(this.Oid);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _alumnos = Alumno_Convocatorias.GetChildList(reader);
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Insert(Curso parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidCurso = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                GetNewCode();

                parent.Session().Save(this.Base.Record);

                _alumnos.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Update(Curso parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidCurso = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                Convocatoria_CursoRecord obj = parent.Session().Get<Convocatoria_CursoRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);

                _alumnos.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(Curso parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                SessionCode = parent.SessionCode;
                Session().Delete(Session().Get<Convocatoria_CursoRecord>(Oid));
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

                    Convocatoria_Curso.DoLOCK( Session());

                    IDataReader reader = Convocatoria_Curso.DoSELECT(AppContext.ActiveSchema.Code, Session(), criteria.Oid);

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        Alumno_Convocatoria.DoLOCK( Session());

                        string query = Alumno_Convocatorias.SELECT_BY_CONVOCATORIA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _alumnos = Alumno_Convocatorias.GetChildList(reader);

                    }
                }
                else
                {
                    _base.Record.CopyValues((Convocatoria_CursoRecord)(criteria.UniqueResult()));

                    //Session().Lock(Session().Get<Convocatoria_CursoRecord>(Oid), LockMode.UpgradeNoWait);

                    if (Childs)
                    {
                        criteria = Alumno_Convocatoria.GetCriteria(Session());
                        criteria.AddEq("OidConvocatoria", this.Oid);
                        _alumnos = Alumno_Convocatorias.GetChildList(criteria.List<Alumno_Convocatoria>());
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
                GetNewCode();
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
                    Convocatoria_CursoRecord obj = Session().Get<Convocatoria_CursoRecord>(Oid);
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
                Convocatoria_CursoRecord obj = (Convocatoria_CursoRecord)(criteria.UniqueResult());
                Session().Delete(Session().Get<Convocatoria_CursoRecord>(obj.Oid));

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

        public static bool Exists(string codigo)
        {
            ExistsCmd result;
            result = DataPortal.Execute<ExistsCmd>(new ExistsCmd(codigo));
            return result.Exists;
        }

        [Serializable()]
        private class ExistsCmd : CommandBase
        {
            private string _codigo;
            private bool _exists = false;

            public bool Exists
            {
                get { return _exists; }
            }

            public ExistsCmd(string codigo)
            {
                _codigo = codigo;
            }

            protected override void DataPortal_Execute()
            {
                // Buscar por codigo
                CriteriaEx criteria = Convocatoria_Curso.GetCriteria(Convocatoria_Curso.OpenSession());
                criteria.AddCodeSearch(_codigo);
                Convocatoria_CursoList list = Convocatoria_CursoList.GetList(criteria);
                _exists = !(list.Count == 0);
            }
        }



        #endregion

        #region SQL

        internal static string SELECT_FIELDS()
        {
            string query;

            query = "SELECT CC.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string convocatoria_curso = nHManager.Instance.GetSQLTable(typeof(Convocatoria_CursoRecord));

            query = "   FROM   " + convocatoria_curso + "   AS CC";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.Curso != null && conditions.Curso.Oid > 0)
                query += " AND CC.\"OID_CURSO\" = " + conditions.Curso.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions);

            if (lockTable) query += " FOR UPDATE OF CC NOWAIT";

            return query;
        }


        #endregion

    }
}

