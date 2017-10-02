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
	public class ClaseExtraRecord : RecordBase
	{
		#region Attributes

		private long _oid_plan;
		private long _oid_modulo;
		private long _oid_submodulo;
		private string _titulo = string.Empty;
		private string _observaciones = string.Empty;
		private string _alias = string.Empty;
		private long _total_clases;
		private long _orden;
  
		#endregion
		
		#region Properties
		
				public virtual long OidPlan { get { return _oid_plan; } set { _oid_plan = value; } }
		public virtual long OidModulo { get { return _oid_modulo; } set { _oid_modulo = value; } }
		public virtual long OidSubmodulo { get { return _oid_submodulo; } set { _oid_submodulo = value; } }
		public virtual string Titulo { get { return _titulo; } set { _titulo = value; } }
		public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
		public virtual string Alias { get { return _alias; } set { _alias = value; } }
		public virtual long TotalClases { get { return _total_clases; } set { _total_clases = value; } }
		public virtual long Orden { get { return _orden; } set { _orden = value; } }

		#endregion
		
		#region Business Methods
		
		public ClaseExtraRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_plan = Format.DataReader.GetInt64(source, "OID_PLAN");
			_oid_modulo = Format.DataReader.GetInt64(source, "OID_MODULO");
			_oid_submodulo = Format.DataReader.GetInt64(source, "OID_SUBMODULO");
			_titulo = Format.DataReader.GetString(source, "TITULO");
			_observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");
			_alias = Format.DataReader.GetString(source, "ALIAS");
			_total_clases = Format.DataReader.GetInt64(source, "TOTAL_CLASES");
			_orden = Format.DataReader.GetInt64(source, "ORDEN");

		}		
		public virtual void CopyValues(ClaseExtraRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_plan = source.OidPlan;
			_oid_modulo = source.OidModulo;
			_oid_submodulo = source.OidSubmodulo;
			_titulo = source.Titulo;
			_observaciones = source.Observaciones;
			_alias = source.Alias;
			_total_clases = source.TotalClases;
			_orden = source.Orden;
		}
		
		#endregion	
	}

    [Serializable()]
	public class ClaseExtraBase 
	{	 
		#region Attributes
		
		private ClaseExtraRecord _record = new ClaseExtraRecord();

        // Atributos auxiliares
        string _modulo = string.Empty;
        string _submodulo = string.Empty;
        long _estado=1;
        private long _tipo = 2;
		
		#endregion
		
		#region Properties
		
		public ClaseExtraRecord Record { get { return _record; } }

        public virtual string Modulo { get { return _modulo; } set { _modulo = value; } }
        public virtual string Submodulo { get { return _submodulo; } set { _submodulo = value; } }
        public virtual long Estado { get { return _estado; } set { _estado = value; } }
        public virtual long Tipo { get { return _tipo; } set { _tipo = value; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;

            _record.CopyValues(source);

            _modulo = Format.DataReader.GetString(source, "MODULO");
            _submodulo = Format.DataReader.GetString(source, "SUBMODULO");
            _estado = Format.DataReader.GetInt32(source, "ESTADO");
		}		
		public void CopyValues(ClaseExtra source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _modulo = source.Modulo;
            _submodulo = source.Submodulo;
            _estado = source.Estado;
            _tipo = source.Tipo;
		}
		public void CopyValues(ClaseExtraInfo source)
		{
			if (source == null) return;

            _record.CopyValues(source.Base.Record);

            _modulo = source.Modulo;
            _submodulo = source.Submodulo;
            _estado = source.Estado;
            _tipo = source.Tipo;
		}
		
		#endregion	
	}
		
	/// <summary>
	/// Editable Root Business Object
	/// </summary>	
    [Serializable()]
	public class ClaseExtra : BusinessBaseEx<ClaseExtra>
	{	 
		#region Attributes
		
		protected ClaseExtraBase _base = new ClaseExtraBase();

        private Sesions _sesions = Sesions.NewChildList();
		

		#endregion
		
		#region Properties
		
		public ClaseExtraBase Base { get { return _base; } }
		
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
		public virtual long OidPlan
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidPlan;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.OidPlan.Equals(value))
				{
					_base.Record.OidPlan = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidModulo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidModulo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.OidModulo.Equals(value))
				{
					_base.Record.OidModulo = value;
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
				//////CanWriteProperty(true);
				
				if (!_base.Record.OidSubmodulo.Equals(value))
				{
					_base.Record.OidSubmodulo = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Titulo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Titulo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Titulo.Equals(value))
				{
					_base.Record.Titulo = value;
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
		public virtual string Alias
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Alias;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Alias.Equals(value))
				{
					_base.Record.Alias = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long TotalClases
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.TotalClases;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.TotalClases.Equals(value))
				{
					_base.Record.TotalClases = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long Orden
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Orden;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.Orden.Equals(value))
				{
					_base.Record.Orden = value;
					PropertyHasChanged();
				}
			}
		}		

        public virtual string Modulo { get { return _base.Modulo; } set { _base.Modulo = value; } }
        public virtual string Submodulo { get { return _base.Submodulo; } set { _base.Submodulo = value; } }
        public virtual long Estado { get { return _base.Estado; } set { _base.Estado = value; } }
        public virtual long Tipo { get { return _base.Tipo; } set { _base.Tipo = value; } }


        public virtual Sesions Sesions
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _sesions;
            }

            set
            {
                _sesions = value;
            }
        }
		
		#endregion
		
		#region Business Methods
		
		public virtual ClaseExtra CloneAsNew()
		{
			ClaseExtra clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = ClaseExtra.OpenSession();
			ClaseExtra.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(ClaseExtraInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidPlan = source.OidPlan;
			OidModulo = source.OidModulo;
			OidSubmodulo = source.OidSubmodulo;
			Titulo = source.Titulo;
			Observaciones = source.Observaciones;
			Alias = source.Alias;
			TotalClases = source.TotalClases;
			Orden = source.Orden;
		}
		
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidPlan", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidModulo", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidSubmodulo", 1));

            ValidationRules.AddRule(
          Csla.Validation.CommonRules.StringRequired, "Alias");

            ValidationRules.AddRule(
           Csla.Validation.CommonRules.StringRequired, "Titulo");
        }

        #endregion

        #region Autorization Rules

        public static bool CanAddObject()
        {
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.PLAN_EXTRA);
        }

        public static bool CanGetObject()
        {
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.PLAN_EXTRA);
        }

        public static bool CanDeleteObject()
        {
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.PLAN_EXTRA);
        }

        public static bool CanEditObject()
        {
            return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.PLAN_EXTRA);
        }

        #endregion

        #region Common Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        public ClaseExtra()
        {
            MarkAsChild();
            Random r = new Random();
            Oid = (long)r.Next();
        }

        public virtual ClaseExtraInfo GetInfo(bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(Library.Resources.Messages.USER_NOT_ALLOWED);

            return new ClaseExtraInfo(this, get_childs);
        }
        public virtual ClaseExtraInfo GetInfo()
        {
            return GetInfo(true);
        }

        #endregion

        #region Root Factory Methods

        public static ClaseExtra New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<ClaseExtra>(new CriteriaCs(-1));
        }

        public static ClaseExtra Get(long oid)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = ClaseExtra.GetCriteria(ClaseExtra.OpenSession());
            criteria.AddOidSearch(oid);
            ClaseExtra.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<ClaseExtra>(criteria);
        }

        public static ClaseExtra Get(CriteriaEx criteria)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            ClaseExtra.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<ClaseExtra>(criteria);
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
        /// Elimina todas los ClaseExtras
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = ClaseExtra.OpenSession();
            ISession sess = ClaseExtra.Session(sessCode);
            ITransaction trans = ClaseExtra.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from ClaseExtra");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                ClaseExtra.CloseSession(sessCode);
            }
        }

        public override ClaseExtra Save()
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

                _sesions.Update(this);

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

        private ClaseExtra(ClaseExtra source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private ClaseExtra(IDataReader reader, bool childs)
        {
            MarkAsChild();
            Childs = childs;
            Fetch(reader);
        }

        public static ClaseExtra NewChild(PlanExtra parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            ClaseExtra obj = new ClaseExtra();
            obj.OidPlan = parent.Oid;
            return obj;
        }

        public static ClaseExtra NewChild(Modulo parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            ClaseExtra obj = new ClaseExtra();
            obj.OidModulo = parent.Oid;
            return obj;
        }

        public static ClaseExtra NewChild(Submodulo parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            ClaseExtra obj = new ClaseExtra();
            obj.OidSubmodulo = parent.Oid;
            return obj;
        }

        internal static ClaseExtra GetChild(ClaseExtra source)
        {
            return new ClaseExtra(source);
        }

        internal static ClaseExtra GetChild(IDataReader reader, bool childs)
        {
            return new ClaseExtra(reader, childs);
        }


        internal static ClaseExtra GetChild(IDataReader reader)
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

        private void Fetch(ClaseExtra source)
        {
            try
            {
                SessionCode = source.SessionCode;

                _base.CopyValues(source);

                CriteriaEx criteria = Sesion.GetCriteria(Session());
                criteria.AddEq("OidClaseExtra", this.Oid);
                _sesions = Sesions.GetChildList(criteria.List<Sesion>());


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

                //if (Childs)
                //{
                //    Sesion.DoLOCK( Session());

                //    string query = Sesions.SELECT_BY_CLASE_EXTRA(this.Oid);
                //    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session());
                //    _sesions = Sesions.GetChildList(reader);
                //}
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }


        internal void Insert(PlanExtra parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidPlan = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                parent.Session().Save(this.Base.Record);

                _sesions.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Update(PlanExtra parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidPlan = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                ClaseExtraRecord obj = parent.Session().Get<ClaseExtraRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);

                _sesions.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }


        internal void DeleteSelf(PlanExtra parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                SessionCode = parent.SessionCode;
                Session().Delete(Session().Get<ClaseExtraRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }

        internal void Insert(Modulo parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidModulo = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                parent.Session().Save(this.Base.Record);

                _sesions.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Update(Modulo parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidModulo = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                ClaseExtraRecord obj = parent.Session().Get<ClaseExtraRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);

                _sesions.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }


        internal void DeleteSelf(Modulo parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                SessionCode = parent.SessionCode;
                Session().Delete(Session().Get<ClaseExtraRecord>(Oid));
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

                _sesions.Update(this);
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

                ClaseExtraRecord obj = parent.Session().Get<ClaseExtraRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);

                _sesions.Update(this);
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
                Session().Delete(Session().Get<ClaseExtraRecord>(Oid));
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

                    ClaseExtra.DoLOCK( Session());

                    IDataReader reader = ClaseExtra.DoSELECT(AppContext.ActiveSchema.Code, Session(), criteria.Oid);

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        Sesion.DoLOCK( Session());

                        string query = Sesions.SELECT_BY_CLASE_EXTRA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _sesions = Sesions.GetChildList(reader);
                    }
                }
                else
                {
                    _base.Record.CopyValues((ClaseExtraRecord)(criteria.UniqueResult()));

                    //Session().Lock(Session().Get<ClaseExtraRecord>(Oid), LockMode.UpgradeNoWait);

                    if (Childs)
                    {
                        criteria = Sesion.GetCriteria(Session());
                        criteria.AddEq("OidClaseExtra", this.Oid);
                        _sesions = Sesions.GetChildList(criteria.List<Sesion>());
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
                    ClaseExtraRecord obj = Session().Get<ClaseExtraRecord>(Oid);
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
                ClaseExtraRecord obj = (ClaseExtraRecord)(criteria.UniqueResult());
                Session().Delete(Session().Get<ClaseExtraRecord>(obj.Oid));

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

        public static bool SesionExists(long oid_clase_extra)
        {
            SesionExistsCmd result;
            result = DataPortal.Execute<SesionExistsCmd>(new SesionExistsCmd(oid_clase_extra));
            return result.Exists;
        }

        [Serializable()]
        private class SesionExistsCmd : CommandBase
        {
            private long _oid_clase_extra;
            private bool _exists = false;

            public bool Exists
            {
                get { return _exists; }
            }

            public SesionExistsCmd(long oid_clase_extra)
            {
                _oid_clase_extra = oid_clase_extra;
            }

            protected override void DataPortal_Execute()
            {
                // Buscar por codigo
                CriteriaEx criteria = Sesion.GetCriteria(Sesion.OpenSession());
                criteria.AddEq("OidClaseExtra", _oid_clase_extra);
                SesionList list = SesionList.GetList(criteria);
                _exists = !(list.Count == 0);
            }
        }



        #endregion

        #region SQL

        internal static string SELECT_FIELDS()
        {
            string query;

            query = "SELECT CE.*," +
                    "       S.\"CODIGO\" AS \"SUBMODULO\", S.\"CODIGO_ORDEN\"," +
                    "       M.\"NUMERO_MODULO\", M.\"TEXTO\" AS \"MODULO\"," +
                    "       0 AS GRUPO," +
                    "       0 AS \"ESTADO\"";

            return query;
        }

        public new static string SELECT(long oid)
        {
            string clase = nHManager.Instance.GetSQLTable(typeof(ClaseExtraRecord));
            string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));

            string query;

            query = SELECT_FIELDS() +
                    " FROM " + clase + " AS CE " +
                    " INNER JOIN " + submodulo + " AS S ON (CE.\"OID_SUBMODULO\" = S.\"OID\")" +
                    " INNER JOIN " + modulo + " AS M ON (CE.\"OID_MODULO\" = M.\"OID\")";

            if (oid > 0) query += " WHERE CE.\"OID\" = " + oid.ToString();

            return query;
        }

        #endregion
    }
}

