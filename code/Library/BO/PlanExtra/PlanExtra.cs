using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;

using moleQule.Library;

using NHibernate;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class PlanExtraRecord : RecordBase
	{
		#region Attributes

		private string _nombre = string.Empty;
		private DateTime _fecha;
		private string _observaciones = string.Empty;
		private long _oid_producto;
		private long _oid_serie;
  
		#endregion
		
		#region Properties
		
				public virtual string Nombre { get { return _nombre; } set { _nombre = value; } }
		public virtual DateTime Fecha { get { return _fecha; } set { _fecha = value; } }
		public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
		public virtual long OidProducto { get { return _oid_producto; } set { _oid_producto = value; } }
		public virtual long OidSerie { get { return _oid_serie; } set { _oid_serie = value; } }

		#endregion
		
		#region Business Methods
		
		public PlanExtraRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_nombre = Format.DataReader.GetString(source, "NOMBRE");
			_fecha = Format.DataReader.GetDateTime(source, "FECHA");
			_observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");
			_oid_producto = Format.DataReader.GetInt64(source, "OID_PRODUCTO");
			_oid_serie = Format.DataReader.GetInt64(source, "OID_SERIE");

		}		
		public virtual void CopyValues(PlanExtraRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_nombre = source.Nombre;
			_fecha = source.Fecha;
			_observaciones = source.Observaciones;
			_oid_producto = source.OidProducto;
			_oid_serie = source.OidSerie;
		}
		
		#endregion	
	}

    [Serializable()]
	public class PlanExtraBase 
	{	 
		#region Attributes
		
		private PlanExtraRecord _record = new PlanExtraRecord();
		
		#endregion
		
		#region Properties
		
		public PlanExtraRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(PlanExtra source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(PlanExtraInfo source)
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
	public class PlanExtra : BusinessBaseEx<PlanExtra>
	{	 
		#region Attributes
		
		protected PlanExtraBase _base = new PlanExtraBase();

        private ClaseExtras _c_extras = ClaseExtras.NewChildList();
		

		#endregion
		
		#region Properties
		
		public PlanExtraBase Base { get { return _base; } }

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
        public virtual string Nombre
        {

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.Nombre;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_base.Record.Nombre.Equals(value))
                {
                    _base.Record.Nombre = value;
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
        public virtual long OidProducto
        {

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.OidProducto;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (!_base.Record.OidProducto.Equals(value))
                {
                    _base.Record.OidProducto = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual long OidSerie
        {

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.OidSerie;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (!_base.Record.OidSerie.Equals(value))
                {
                    _base.Record.OidSerie = value;
                    PropertyHasChanged();
                }
            }
        }


        public virtual ClaseExtras CExtras
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _c_extras;
            }

            set
            {
                _c_extras = value;
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _c_extras.IsValid; }
        }
        public override bool IsDirty
        {
            get { return base.IsDirty || _c_extras.IsDirty; }
        }
	
		
		
		#endregion
		
		#region Business Methods

        /// <summary>
        /// Clona la entidad y sus subentidades y las marca como nuevas
        /// </summary>
        /// <returns>Una entidad clon</returns>

        public virtual PlanExtra CloneAsNew()
        {
            PlanExtra clon = base.Clone();

            // Se define el Oid como nueva entidad
            Random rd = new Random();
            clon.Oid = rd.Next();
            clon.SessionCode = PlanExtra.OpenSession();
            PlanExtra.BeginTransaction(clon.SessionCode);

            clon.MarkNew();
            clon.CExtras.MarkAsNew();
            return clon;
        }
		
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(
                Csla.Validation.CommonRules.StringRequired, "Nombre");
            //ValidationRules.AddRule(CommonRules.MinValue<long>,
            //                        new CommonRules.MinValueRuleArgs<long>("OidProducto", 1));
            //ValidationRules.AddRule(CommonRules.MinValue<long>,
            //                        new CommonRules.MinValueRuleArgs<long>("OidSerie", 1));
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

        #region Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION New
        /// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
        /// pero es protected por exigencia de NHibernate.
        /// </summary>
        protected PlanExtra()
        {
            Fecha = DateTime.Today;
        }

        private PlanExtra(IDataReader reader)
        {
            Fetch(reader);
        }

        public static PlanExtra New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
            return DataPortal.Create<PlanExtra>(new CriteriaCs(-1));
        }

        public static PlanExtra Get(long oid)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = PlanExtra.GetCriteria(PlanExtra.OpenSession());

            criteria.AddOidSearch(oid);
            PlanExtra.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<PlanExtra>(criteria);
        }

        internal static PlanExtra Get(IDataReader reader)
        {
            return new PlanExtra(reader);
        }

        /// <summary>
        /// Construye y devuelve un objeto de solo lectura copia de si mismo.
        /// </summary>
        /// <param name="get_childs">True si se quiere que traiga los hijos</param>
        /// <returns></returns>
        public virtual PlanExtraInfo GetInfo(bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new PlanExtraInfo(this, get_childs);
        }

        public virtual PlanExtraInfo GetInfo()
        {
            return GetInfo(true);
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
        /// Elimina todos los Clientes, Contactos de Cliente y Cuentas de Cliente
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = PlanExtra.OpenSession();
            ISession sess = PlanExtra.Session(sessCode);
            ITransaction trans = PlanExtra.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from  PlanExtra");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                PlanExtra.CloseSession(sessCode);
            }
        }

        public override PlanExtra Save()
        {
            // Por la posible doble interfaz Root/Child
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

                _c_extras.Update(this);

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

        #region Common Data Access

        [RunLocal()]
        private void DataPortal_Create(CriteriaCs criteria)
        {
            Random r = new Random();
            Oid = (long)r.Next();

            _c_extras = ClaseExtras.NewChildList();
        }

        #endregion

        #region Root Data Access

        private void DataPortal_Fetch(CriteriaEx criteria)
        {
            try
            {
                SessionCode = criteria.SessionCode;
                Childs = criteria.Childs;

                if (nHMng.UseDirectSQL)
                {
                    PlanExtra.DoLOCK(Session());
                    IDataReader reader = PlanExtra.DoSELECT(AppContext.ActiveSchema.Code, Session(), criteria.Oid);

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        string query = string.Empty;

                        ClaseExtra.DoLOCK(Session());

                        query = ClaseExtras.SELECT_CLASES_EXTRAS_PLAN(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _c_extras = ClaseExtras.GetChildList(reader);

                    }

                }
                else
                {
                    _base.Record.CopyValues((PlanExtraRecord)(criteria.UniqueResult()));
                    //Session().Lock(Session().Get<PlanExtraRecord>(Oid), LockMode.UpgradeNoWait);

                    if (Childs)
                    {
                        criteria = ClaseExtra.GetCriteria(Session());
                        criteria.AddEq("OidPlan", this.Oid);
                        _c_extras = ClaseExtras.GetChildList(criteria.List<ClaseExtra>());

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

        //Fetch independiente de DataPortal para generar un Cliente a partir de un IDataReader
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
                    PlanExtraRecord obj = Session().Get<PlanExtraRecord>(Oid);

                    obj.CopyValues(this.Base.Record);
                    Session().Update(obj);
                }
                catch (Exception ex)
                {
                    iQExceptionHandler.TreatException(ex);
                }
            }
        }

        [Transactional(TransactionalTypes.Manual)]
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new CriteriaCs(Oid));
        }

        [Transactional(TransactionalTypes.Manual)]
        private void DataPortal_Delete(CriteriaCs criteria)
        {
            try
            {
                // Iniciamos la conexion y la transaccion
                SessionCode = OpenSession();
                BeginTransaction();
                CriteriaEx criterio = GetCriteria();
                criterio.AddOidSearch(criteria.Oid);
                Session().Delete((PlanExtraRecord)(criterio.UniqueResult()));

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

        #endregion

        #region SQL

        internal static string SELECT_FIELDS()
        {
            string query;

            query = "SELECT PE.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string pe = nHManager.Instance.GetSQLTable(typeof(PlanExtraRecord));

            query = "   FROM   " + pe + "   AS PE";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions);

            if (lockTable) query += " FOR UPDATE OF PE NOWAIT";

            return query;
        }


        #endregion

    }
}

