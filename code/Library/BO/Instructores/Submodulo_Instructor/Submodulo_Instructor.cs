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
	public class Submodulo_InstructorRecord : RecordBase
	{
		#region Attributes

		private long _oid_instructor;
		private long _oid_submodulo;
		private long _oid_instructor_suplente;
		private DateTime _fecha_inicio;
		private DateTime _fecha_fin;
  
		#endregion
		
		#region Properties
		
				public virtual long OidInstructor { get { return _oid_instructor; } set { _oid_instructor = value; } }
		public virtual long OidSubmodulo { get { return _oid_submodulo; } set { _oid_submodulo = value; } }
		public virtual long OidInstructorSuplente { get { return _oid_instructor_suplente; } set { _oid_instructor_suplente = value; } }
		public virtual DateTime FechaInicio { get { return _fecha_inicio; } set { _fecha_inicio = value; } }
		public virtual DateTime FechaFin { get { return _fecha_fin; } set { _fecha_fin = value; } }

		#endregion
		
		#region Business Methods
		
		public Submodulo_InstructorRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_instructor = Format.DataReader.GetInt64(source, "OID_INSTRUCTOR");
			_oid_submodulo = Format.DataReader.GetInt64(source, "OID_SUBMODULO");
			_oid_instructor_suplente = Format.DataReader.GetInt64(source, "OID_INSTRUCTOR_SUPLENTE");
			_fecha_inicio = Format.DataReader.GetDateTime(source, "FECHA_INICIO");
			_fecha_fin = Format.DataReader.GetDateTime(source, "FECHA_FIN");

		}		
		public virtual void CopyValues(Submodulo_InstructorRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_instructor = source.OidInstructor;
			_oid_submodulo = source.OidSubmodulo;
			_oid_instructor_suplente = source.OidInstructorSuplente;
			_fecha_inicio = source.FechaInicio;
			_fecha_fin = source.FechaFin;
		}
		
		#endregion	
	}

    [Serializable()]
	public class Submodulo_InstructorBase 
	{	 
		#region Attributes
		
		private Submodulo_InstructorRecord _record = new Submodulo_InstructorRecord();

        //atributos auxiliares 
        private long _oid_modulo;
		
		#endregion
		
		#region Properties
		
		public Submodulo_InstructorRecord Record { get { return _record; } }

        public virtual long OidModulo { get { return _oid_modulo; } set { _oid_modulo = value; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);

            _oid_modulo = Convert.ToInt32(source["OID_MODULO"]);
		}		
		public void CopyValues(Submodulo_Instructor source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _oid_modulo = source.OidModulo;
		}
		public void CopyValues(Submodulo_InstructorInfo source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _oid_modulo = source.OidModulo;
		}
		
		#endregion	
	}
		
	/// <summary>
	/// Editable Root Business Object
	/// </summary>	
    [Serializable()]
	public class Submodulo_Instructor : BusinessBaseEx<Submodulo_Instructor>
	{	 
		#region Attributes
		
		protected Submodulo_InstructorBase _base = new Submodulo_InstructorBase();
		

		#endregion
		
		#region Properties
		
		public Submodulo_InstructorBase Base { get { return _base; } }
		
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
				//CanReadProperty(true);
				return _base.Record.OidInstructor;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidInstructor.Equals(value))
				{
					_base.Record.OidInstructor = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidSubmodulo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidSubmodulo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidSubmodulo.Equals(value))
				{
					_base.Record.OidSubmodulo = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidInstructorSuplente
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidInstructorSuplente;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidInstructorSuplente.Equals(value))
				{
					_base.Record.OidInstructorSuplente = value;
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
				//CanWriteProperty(true);
				
				if (!_base.Record.FechaInicio.Equals(value))
				{
					_base.Record.FechaInicio = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual DateTime FechaFin
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.FechaFin;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.FechaFin.Equals(value))
				{
					_base.Record.FechaFin = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual long OidModulo { get { return _base.OidModulo; } set { _base.OidModulo = value; } }
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual Submodulo_Instructor CloneAsNew()
		{
			Submodulo_Instructor clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = Submodulo_Instructor.OpenSession();
			Submodulo_Instructor.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(Submodulo_InstructorInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidInstructor = source.OidInstructor;
			OidSubmodulo = source.OidSubmodulo;
			OidInstructorSuplente = source.OidInstructorSuplente;
			FechaInicio = source.FechaInicio;
			FechaFin = source.FechaFin;
		}
		
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidInstructor", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidSubmodulo", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidInstructorSuplente", 1));
        }

        #endregion

        #region Autorization Rules

        public static bool CanAddObject()
        {
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.INSTRUCTOR);

        }

        public static bool CanGetObject()
        {
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.INSTRUCTOR);

        }

        public static bool CanDeleteObject()
        {
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.INSTRUCTOR);

        }
        public static bool CanEditObject()
        {
            return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.INSTRUCTOR);

        }

        #endregion

        #region Common Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        public Submodulo_Instructor()
        {
            MarkAsChild();
            Random r = new Random();
            Oid = (long)r.Next();
            FechaInicio = DateTime.MinValue;
            FechaFin = DateTime.MaxValue;
        }

        public virtual Submodulo_InstructorInfo GetInfo(bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new Submodulo_InstructorInfo(this);
        }

        public virtual Submodulo_InstructorInfo GetInfo()
        {
            return GetInfo(true);
        }

        #endregion

        #region Root Factory Methods

        public static Submodulo_Instructor New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<Submodulo_Instructor>(new CriteriaCs(-1));
        }

        public static Submodulo_Instructor Get(long oid)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = Submodulo_Instructor.GetCriteria(Submodulo_Instructor.OpenSession());
            criteria.AddOidSearch(oid);
            Submodulo_Instructor.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Submodulo_Instructor>(criteria);
        }

        public static Submodulo_Instructor Get(CriteriaEx criteria)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Submodulo_Instructor.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Submodulo_Instructor>(criteria);
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
        /// Elimina todas los Submodulo_Instructors
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = Submodulo_Instructor.OpenSession();
            ISession sess = Submodulo_Instructor.Session(sessCode);
            ITransaction trans = Submodulo_Instructor.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from Submodulo_Instructor");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                Submodulo_Instructor.CloseSession(sessCode);
            }
        }

        public override Submodulo_Instructor Save()
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

        private Submodulo_Instructor(Submodulo_Instructor source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private Submodulo_Instructor(IDataReader reader, bool childs)
        {
            MarkAsChild();
            Childs = childs;
            Fetch(reader);
        }

        public static Submodulo_Instructor NewChild(Instructor parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Submodulo_Instructor obj = new Submodulo_Instructor();
            obj.OidInstructor = parent.Oid;
            return obj;
        }

        public static Submodulo_Instructor NewChild(Submodulo parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Submodulo_Instructor obj = new Submodulo_Instructor();
            obj.OidSubmodulo = parent.Oid;
            return obj;
        }

        internal static Submodulo_Instructor GetChild(Submodulo_Instructor source)
        {
            return new Submodulo_Instructor(source);
        }

        internal static Submodulo_Instructor GetChild(IDataReader reader, bool childs)
        {
            return new Submodulo_Instructor(reader, childs);
        }


        internal static Submodulo_Instructor GetChild(IDataReader reader)
        {
            return GetChild(reader, true);
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

        private void Fetch(Submodulo_Instructor source)
        {
            try
            {
                SessionCode = source.SessionCode;

                _base.CopyValues(source);

            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        private void Fetch(IDataReader source)
        {
            try
            {
                _base.CopyValues(source);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }


        internal void Insert(Instructor parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidInstructor = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                parent.Session().Save(this.Base.Record);

            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Update(Instructor parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidInstructor = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                Submodulo_InstructorRecord obj = parent.Session().Get<Submodulo_InstructorRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);

            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }


        internal void DeleteSelf(Instructor parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                SessionCode = parent.SessionCode;
                Session().Delete(Session().Get<Submodulo_InstructorRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }

        internal void Insert(Submodulo parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidSubmodulo = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                parent.Session().Save(this.Base.Record);

            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Update(Submodulo parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidSubmodulo = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                Submodulo_InstructorRecord obj = parent.Session().Get<Submodulo_InstructorRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);

            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }


        internal void DeleteSelf(Submodulo parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                SessionCode = parent.SessionCode;
                Session().Delete(Session().Get<Submodulo_InstructorRecord>(Oid));
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

                    Submodulo_Instructor.DoLOCK( Session());

                    IDataReader reader = Submodulo_Instructor.DoSELECT(AppContext.ActiveSchema.Code, Session(), criteria.Oid);

                    if (reader.Read())
                        _base.CopyValues(reader);
                }
                else
                {
                    _base.Record.CopyValues((Submodulo_InstructorRecord)(criteria.UniqueResult()));

                    //Session().Lock(Session().Get<Submodulo_InstructorRecord>(Oid), LockMode.UpgradeNoWait);
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
                    Submodulo_InstructorRecord obj = Session().Get<Submodulo_InstructorRecord>(Oid);
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
                Submodulo_InstructorRecord obj = (Submodulo_InstructorRecord)(criteria.UniqueResult());
                Session().Delete(Session().Get<Submodulo_InstructorRecord>(obj.Oid));

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

            query = "SELECT SI.*" +
                " , S.\"OID_MODULO\" AS \"OID_MODULO\"";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string submodulo_instructor = nHManager.Instance.GetSQLTable(typeof(Submodulo_InstructorRecord));
            string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));

            query = "   FROM   " + submodulo_instructor + "   AS SI" +
                " INNER JOIN " + submodulo + " AS S ON S.\"OID\" = SI.\"OID_SUBMODULO\"";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;
            string si = nHManager.Instance.GetSQLTable(typeof(Submodulo_InstructorRecord));

            query = "   WHERE TRUE";

            if (conditions.Instructor != null && conditions.Instructor.Oid > 0)
                query += " AND SI.\"OID_INSTRUCTOR\" = " + conditions.Instructor.Oid;

            if (ModulePrincipal.GetMostrarInstructoresAutorizadosSetting())
            { 
                query += @" AND SI.""OID_SUBMODULO"" NOT IN (	SELECT ""OID_SUBMODULO""
					                                            FROM " + si + @"
					                                            WHERE ('" + conditions.FechaAuxIniLabel + @"' BETWEEN COALESCE(""FECHA_INICIO"", '01-01-0001') AND COALESCE(""FECHA_FIN"", '12-31-2999') OR 
						                                            '" + conditions.FechaAuxFinLabel + @"' BETWEEN COALESCE(""FECHA_INICIO"", '01-01-0001') AND COALESCE(""FECHA_FIN"", '12-31-2999'))";

                if (conditions.Instructor != null && conditions.Instructor.Oid > 0)
                    query += " AND \"OID_INSTRUCTOR\" = " + conditions.Instructor.Oid;

                query += ") ";
            }

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions);

            if (lockTable) query += " FOR UPDATE OF SI NOWAIT";

            return query;
        }


        #endregion

    }
}

