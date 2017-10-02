using System;
using System.ComponentModel;
using System.Collections.Generic;
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
	public class Instructor_PromocionRecord : RecordBase
	{
		#region Attributes

		private long _oid_instructor;
		private long _oid_promocion;
  
		#endregion
		
		#region Properties
		
				public virtual long OidInstructor { get { return _oid_instructor; } set { _oid_instructor = value; } }
		public virtual long OidPromocion { get { return _oid_promocion; } set { _oid_promocion = value; } }

		#endregion
		
		#region Business Methods
		
		public Instructor_PromocionRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_instructor = Format.DataReader.GetInt64(source, "OID_INSTRUCTOR");
			_oid_promocion = Format.DataReader.GetInt64(source, "OID_PROMOCION");

		}		
		public virtual void CopyValues(Instructor_PromocionRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_instructor = source.OidInstructor;
			_oid_promocion = source.OidPromocion;
		}
		
		#endregion	
	}

    [Serializable()]
	public class Instructor_PromocionBase 
	{	 
		#region Attributes
		
		private Instructor_PromocionRecord _record = new Instructor_PromocionRecord();
		
		#endregion
		
		#region Properties
		
		public Instructor_PromocionRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(Instructor_Promocion source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(Instructor_PromocionInfo source)
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
	public class Instructor_Promocion : BusinessBaseEx<Instructor_Promocion>
	{	 
		#region Attributes
		
		protected Instructor_PromocionBase _base = new Instructor_PromocionBase();
		
        private Submodulos_Instructores_Promociones _submodulos = Submodulos_Instructores_Promociones.NewChildList();


		#endregion
		
		#region Properties
		
		public Instructor_PromocionBase Base { get { return _base; } }
		
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
		public virtual long OidPromocion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidPromocion;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidPromocion.Equals(value))
				{
					_base.Record.OidPromocion = value;
					PropertyHasChanged();
				}
			}
		}
	

        public virtual Submodulos_Instructores_Promociones Submodulos
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _submodulos;
            }

            set
            {
                _submodulos = value;
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _submodulos.IsValid; }
        }
        public override bool IsDirty
        {
            get { return base.IsDirty || _submodulos.IsDirty; }
        }
		
		
		#endregion
		
		#region Business Methods
		
        /// <summary>
        /// Clona la entidad y sus subentidades y las marca como nuevas
        /// </summary>
        /// <returns>Una entidad clon</returns>
        public virtual Instructor_Promocion CloneAsNew()
        {
            Instructor_Promocion clon = base.Clone();

            // Se define el Oid como nueva entidad
            Random rd = new Random();
            clon.Oid = rd.Next();

            clon.SessionCode = Instructor_Promocion.OpenSession();
            Instructor_Promocion.BeginTransaction(clon.SessionCode);
            clon.MarkNew();

            return clon;
        }
		
		protected virtual void CopyFrom(Instructor_PromocionInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidInstructor = source.OidInstructor;
			OidPromocion = source.OidPromocion;
		}
		
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidInstructor", 1));


            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidPromocion", 1));

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
        public Instructor_Promocion()
        {
            MarkAsChild();
            Random r = new Random();
            Oid = (long)r.Next();
        }

        public virtual Instructor_PromocionInfo GetInfo(bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new Instructor_PromocionInfo(this, get_childs);
        }

        public virtual Instructor_PromocionInfo GetInfo()
        {
            return GetInfo(true);
        }

        #endregion

        #region Root Factory Methods

        public static Instructor_Promocion New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<Instructor_Promocion>(new CriteriaCs(-1));
        }

        public static Instructor_Promocion Get(long oid)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = Instructor_Promocion.GetCriteria(Instructor_Promocion.OpenSession());
            criteria.AddOidSearch(oid);
            Instructor_Promocion.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Instructor_Promocion>(criteria);
        }

        public static Instructor_Promocion Get(CriteriaEx criteria)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Instructor_Promocion.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Instructor_Promocion>(criteria);
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
        /// Elimina todas los Instructor_Promocions
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = Instructor_Promocion.OpenSession();
            ISession sess = Instructor_Promocion.Session(sessCode);
            ITransaction trans = Instructor_Promocion.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from Instructor_Promocion");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                Instructor_Promocion.CloseSession(sessCode);
            }
        }

        public override Instructor_Promocion Save()
        {
            // Por interfaz Root/Child
            if (IsChild)
            {
                throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
            }

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

                _submodulos.Update(this);

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

        protected Instructor_Promocion(Instructor_Promocion source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private Instructor_Promocion(int session_code, IDataReader reader, bool childs)
        {
            MarkAsChild();
            Childs = childs;
            Fetch(session_code, reader);
        }

        public static Instructor_Promocion NewChild(Instructor parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Instructor_Promocion obj = new Instructor_Promocion();
            obj.OidInstructor = parent.Oid;
            return obj;
        }

        internal static Instructor_Promocion GetChild(Instructor_Promocion source)
        {
            return new Instructor_Promocion(source);
        }

        internal static Instructor_Promocion GetChild(int session_code, IDataReader reader, bool childs)
        {
            return new Instructor_Promocion(session_code, reader, childs);
        }


        internal static Instructor_Promocion GetChild(int session_code, IDataReader reader)
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
            Random r = new Random();
            Oid = (long)r.Next();
        }

        #endregion

        #region Child Data Access

        private void Fetch(Instructor_Promocion source)
        {
            try
            {
                SessionCode = source.SessionCode;

                _base.CopyValues(source);

                CriteriaEx criteria;

                criteria = Submodulo_Instructor_Promocion.GetCriteria(Session());
                criteria.AddEq("OidInstructorPromocion", this.Oid);
                _submodulos = Submodulos_Instructores_Promociones.GetChildList(criteria.List<Submodulo_Instructor_Promocion>());

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

                    Submodulo_Instructor_Promocion.DoLOCK(Session(session_code));

                    query = Submodulos_Instructores_Promociones.SELECT_BY_INSTRUCTOR_PROMOCION(this.Oid);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _submodulos = Submodulos_Instructores_Promociones.GetChildList(reader);
                }
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

                _submodulos.Update(this);
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

                Instructor_PromocionRecord obj = parent.Session().Get<Instructor_PromocionRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);

                _submodulos.Update(this);
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
                Session().Delete(Session().Get<Instructor_PromocionRecord>(Oid));
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

                    Instructor_Promocion.DoLOCK( Session());

                    IDataReader reader = Instructor_Promocion.DoSELECT(AppContext.ActiveSchema.Code, Session(), criteria.Oid);

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        string query;

                        Submodulo_Instructor_Promocion.DoLOCK( Session());

                        query = Submodulos_Instructores_Promociones.SELECT_BY_INSTRUCTOR_PROMOCION(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _submodulos = Submodulos_Instructores_Promociones.GetChildList(reader);

                    }
                }
                else
                {
                    _base.Record.CopyValues((Instructor_PromocionRecord)(criteria.UniqueResult()));

                    //Session().Lock(Session().Get<Instructor_PromocionRecord>(Oid), LockMode.UpgradeNoWait);

                    if (Childs)
                    {
                        criteria = Submodulo_Instructor_Promocion.GetCriteria(Session());
                        criteria.AddEq("OidInstructorPromocion", this.Oid);
                        _submodulos = Submodulos_Instructores_Promociones.GetChildList(criteria.List<Submodulo_Instructor_Promocion>());

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
                    Instructor_PromocionRecord obj = Session().Get<Instructor_PromocionRecord>(Oid);
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
                Instructor_PromocionRecord obj = (Instructor_PromocionRecord)(criteria.UniqueResult());
                Session().Delete(Session().Get<Instructor_PromocionRecord>(obj.Oid));

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

    }
}

