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
	public class PlanEstudiosRecord : RecordBase
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
		
		public PlanEstudiosRecord(){}
		
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
		public virtual void CopyValues(PlanEstudiosRecord source)
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
	public class PlanEstudiosBase 
	{	 
		#region Attributes
		
		private PlanEstudiosRecord _record = new PlanEstudiosRecord();
		
		#endregion
		
		#region Properties
		
		public PlanEstudiosRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(PlanEstudios source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(PlanEstudiosInfo source)
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
	public class PlanEstudios : BusinessBaseEx<PlanEstudios>
	{	 
		#region Attributes
		
		protected PlanEstudiosBase _base = new PlanEstudiosBase();

        private ClaseTeoricas _c_teoricas = ClaseTeoricas.NewChildList();
        private ClasePracticas _c_practicas = ClasePracticas.NewChildList();
		

		#endregion
		
		#region Properties
		
		public PlanEstudiosBase Base { get { return _base; } }

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

        public virtual ClaseTeoricas CTeoricas
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _c_teoricas;
            }

            set
            {
                _c_teoricas = value;
            }
        }
        public virtual ClasePracticas CPracticas
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _c_practicas;
            }

            set
            {
                _c_practicas = value;
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _c_teoricas.IsValid && _c_practicas.IsValid; }
        }
        public override bool IsDirty
        {
            get { return base.IsDirty || _c_teoricas.IsDirty || _c_practicas.IsDirty; }
        }
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual PlanEstudios CloneAsNew()
		{
			PlanEstudios clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = PlanEstudios.OpenSession();
			PlanEstudios.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
            clon.CPracticas.MarkAsNew();
            clon.CTeoricas.MarkAsNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(PlanEstudiosInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			Nombre = source.Nombre;
			Fecha = source.Fecha;
			Observaciones = source.Observaciones;
			OidProducto = source.OidProducto;
			OidSerie = source.OidSerie;
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
                                    //new CommonRules.MinValueRuleArgs<long>("OidSerie", 1));

        }

        #endregion

        #region Autorization Rules

        public static bool CanAddObject()
        {
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.PLAN_ESTUDIOS);

        }

        public static bool CanGetObject()
        {
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.PLAN_ESTUDIOS);

        }

        public static bool CanDeleteObject()
        {
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.PLAN_ESTUDIOS);

        }
        public static bool CanEditObject()
        {
            return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.PLAN_ESTUDIOS);

        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION New
        /// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
        /// pero es protected por exigencia de NHibernate.
        /// </summary>
        protected PlanEstudios() 
        {
            Fecha = DateTime.Today;
        }

        private PlanEstudios(IDataReader reader)
        {
            Fetch(reader);
        }

        private PlanEstudios(PlanEstudios source)
        {
            Fetch(source);
        }

        public static PlanEstudios New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
            return DataPortal.Create<PlanEstudios>(new CriteriaCs(-1));
        }

        public static PlanEstudios Get(long oid) { return PlanEstudios.Get(oid, true); }

        public static PlanEstudios Get(long oid, bool childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = PlanEstudios.GetCriteria(PlanEstudios.OpenSession());
            criteria.Childs = childs;
            criteria.Query = PlanEstudios.SELECT(oid);

            criteria.AddOidSearch(oid);
            PlanEstudios.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<PlanEstudios>(criteria);
        }

        internal static PlanEstudios Get(IDataReader reader)
        {
            return new PlanEstudios(reader);
        }

        internal static PlanEstudios Get(PlanEstudios source)
        {
            return new PlanEstudios(source);
        }

        /// <summary>
        /// Construye y devuelve un objeto de solo lectura copia de si mismo.
        /// </summary>
        /// <param name="get_childs">True si se quiere que traiga los hijos</param>
        /// <returns></returns>
        public virtual PlanEstudiosInfo GetInfo(bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new PlanEstudiosInfo(this, get_childs);
        }

        public virtual PlanEstudiosInfo GetInfo()
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
        /// Elimina todos los Planes de Estudio y sus listas
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = PlanEstudios.OpenSession();
            ISession sess = PlanEstudios.Session(sessCode);
            ITransaction trans = PlanEstudios.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from  PlanEstudios");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                PlanEstudios.CloseSession(sessCode);
            }
        }

        public override PlanEstudios Save()
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

                _c_teoricas.Update(this);
                _c_practicas.Update(this);

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

            _c_teoricas = ClaseTeoricas.NewChildList();
            _c_practicas = ClasePracticas.NewChildList();
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
                    PlanEstudios.DoLOCK(Session());
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        string query = string.Empty;

                        ClaseTeorica.DoLOCK( Session());
                        query = ClaseTeoricas.SELECT_BY_PLAN(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _c_teoricas = ClaseTeoricas.GetChildList(reader);
                        
						ClasePractica.DoLOCK( Session());
                        query = ClasePracticas.SELECT_BY_PLAN(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _c_practicas = ClasePracticas.GetChildList(reader);
                    }
                }
                else
                {
                    _base.Record.CopyValues((PlanEstudiosRecord)(criteria.UniqueResult()));
                    //Session().Lock(Session().Get<PlanEstudiosRecord>(Oid), LockMode.UpgradeNoWait);

                    if (Childs)
                    {

                        criteria = ClaseTeorica.GetCriteria(Session());
                        criteria.AddEq("OidPlan", this.Oid);
                        _c_teoricas = ClaseTeoricas.GetChildList(criteria.List<ClaseTeorica>());

                        criteria = ClasePractica.GetCriteria(Session());
                        criteria.AddEq("OidPlan", this.Oid);
                        _c_practicas = ClasePracticas.GetChildList(criteria.List<ClasePractica>());

                    }
                }
            }
            catch (Exception ex)
            {
                if (Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(ex);
            }
        }

        private void Fetch(PlanEstudios source)
        {
            _base.CopyValues(source);
            MarkOld();
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
                    PlanEstudiosRecord obj = Session().Get<PlanEstudiosRecord>(Oid);

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
                Session().Delete((PlanEstudiosRecord)(criterio.UniqueResult()));

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

        /// <summary>
        /// Función para la unión de dos planes de estudio
        /// </summary>
        /// <param name="oid"></param>
        public virtual void Merge(long oid)
        {
            PlanEstudios merge_plan = PlanEstudios.Get(oid, true);

            ClaseTeoricas cteoricas = merge_plan.CTeoricas.Clone();

            foreach (ClaseTeorica ct in cteoricas)
                CTeoricas.Add(ct);

            ClasePracticas cpracticas = merge_plan.CPracticas.Clone();

            foreach (ClasePractica cp in cpracticas)
                CPracticas.Add(cp);

            merge_plan.CloseSession();
        }

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

            string pe = nHManager.Instance.GetSQLTable(typeof(PlanEstudiosRecord));

            query = "   FROM   " + pe + "   AS PE";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.PlanEstudios != null && conditions.PlanEstudios.Oid > 0)
                query += " AND PE.\"OID\" = " + conditions.PlanEstudios.Oid;

            return query;
        }

        public new static string SELECT(long oid) { return SELECT(oid, true); }

        internal static string SELECT(long oid, bool lockTable)
        {
            return SELECT(new QueryConditions { PlanEstudios = PlanEstudiosInfo.New(oid) }, lockTable);
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

