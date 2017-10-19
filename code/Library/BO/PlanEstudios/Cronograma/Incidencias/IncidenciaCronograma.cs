using System;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;
using moleQule.Library.Instruction;

namespace moleQule.Library.Instruction
{
    [Serializable()]
    public class IncidenciaCronogramaRecord : RecordBase
    {
        #region Attributes

        private long _oid_cronograma;
        private string _motivo = string.Empty;
        private string _observaciones = string.Empty;

        #endregion

        #region Properties

        public virtual long OidCronograma { get { return _oid_cronograma; } set { _oid_cronograma = value; } }
        public virtual string Motivo { get { return _motivo; } set { _motivo = value; } }
        public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }

        #endregion

        #region Business Methods

        public IncidenciaCronogramaRecord() { }

        public virtual void CopyValues(IDataReader source)
        {
            if (source == null) return;

            Oid = Format.DataReader.GetInt64(source, "OID");
            _oid_cronograma = Format.DataReader.GetInt64(source, "OID_CRONOGRAMA");
            _motivo = Format.DataReader.GetString(source, "MOTIVO");
            _observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");

        }
        public virtual void CopyValues(IncidenciaCronogramaRecord source)
        {
            if (source == null) return;

            Oid = source.Oid;
            _oid_cronograma = source.OidCronograma;
            _motivo = source.Motivo;
            _observaciones = source.Observaciones;
        }

        #endregion
    }

    [Serializable()]
    public class IncidenciaCronogramaBase
    {
        #region Attributes

        private IncidenciaCronogramaRecord _record = new IncidenciaCronogramaRecord();
        
        #endregion

        #region Properties

        public IncidenciaCronogramaRecord Record { get { return _record; } }

        #endregion

        #region Business Methods

        internal void CopyValues(IDataReader source)
        {
            if (source == null) return;

            _record.CopyValues(source);
        }
        public void CopyValues(IncidenciaCronograma source)
        {
            if (source == null) return;

            _record.CopyValues(source.Base.Record);
        }

        public void CopyValues(IncidenciaCronogramaInfo source)
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
    public class IncidenciaCronograma : BusinessBaseEx<IncidenciaCronograma>
    {
        #region Attributes

        protected IncidenciaCronogramaBase _base = new IncidenciaCronogramaBase();

        private IncidenciaSesionesCronogramas _sesiones = IncidenciaSesionesCronogramas.NewChildList();

        #endregion

        #region Properties

        public IncidenciaCronogramaBase Base { get { return _base; } }

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
        public virtual long OidCronograma
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.OidCronograma;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (!_base.Record.OidCronograma.Equals(value))
                {
                    _base.Record.OidCronograma = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Motivo
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.Motivo;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.Motivo.Equals(value))
                {
                    _base.Record.Motivo = value;
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


        public virtual IncidenciaSesionesCronogramas Sesiones
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _sesiones;
            }

            set
            {
                _sesiones = value;
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _sesiones.IsValid; }
        }
        public override bool IsDirty
        {
            get { return base.IsDirty || _sesiones.IsDirty; }
        }


        #endregion

        #region Business Methods

        public virtual IncidenciaCronograma CloneAsNew()
        {
            IncidenciaCronograma clon = base.Clone();

            //Se definen el Oid y el Coidgo como nueva entidad
            Random rd = new Random();
            clon.Oid = rd.Next();

            clon.SessionCode = IncidenciaCronograma.OpenSession();
            IncidenciaCronograma.BeginTransaction(clon.SessionCode);

            clon.MarkNew();

            return clon;
        }

        protected virtual void CopyFrom(IncidenciaCronogramaInfo source)
        {
            if (source == null) return;

            Oid = source.Oid;
            OidCronograma = source.OidCronograma;
            Motivo = source.Motivo;
            Observaciones = source.Observaciones;
        }

  
        #endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidCronograma", 1));
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

        #region Common Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        protected IncidenciaCronograma() { }

        public virtual IncidenciaCronogramaInfo GetInfo(bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new IncidenciaCronogramaInfo(this, get_childs);
        }

        public virtual IncidenciaCronogramaInfo GetInfo()
        {
            return GetInfo(true);
        }

        #endregion

        #region Root Factory Methods

        public static IncidenciaCronograma New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<IncidenciaCronograma>(new CriteriaCs(-1));
        }

        public static IncidenciaCronograma Get(long oid)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = IncidenciaCronograma.GetCriteria(IncidenciaCronograma.OpenSession());
            criteria.AddOidSearch(oid);
            criteria.Query = SELECT(oid);
            IncidenciaCronograma.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<IncidenciaCronograma>(criteria);
        }

        public static IncidenciaCronograma Get(CriteriaEx criteria)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            IncidenciaCronograma.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<IncidenciaCronograma>(criteria);
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
        /// Elimina todas los IncidenciaCronogramas
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = IncidenciaCronograma.OpenSession();
            ISession sess = IncidenciaCronograma.Session(sessCode);
            ITransaction trans = IncidenciaCronograma.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from IncidenciaCronograma");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                IncidenciaCronograma.CloseSession(sessCode);
            }
        }

        public override IncidenciaCronograma Save()
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

                _sesiones.Update(this);

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

        private IncidenciaCronograma(IncidenciaCronograma source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private IncidenciaCronograma(int session_code, IDataReader reader, bool childs)
        {
            MarkAsChild();
            Childs = childs;
            Fetch(session_code, reader);
        }

        public static IncidenciaCronograma NewChild(Cronograma parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            IncidenciaCronograma obj = new IncidenciaCronograma();
            obj.OidCronograma = parent.Oid;
            return obj;
        }

        internal static IncidenciaCronograma GetChild(IncidenciaCronograma source)
        {
            return new IncidenciaCronograma(source);
        }

        internal static IncidenciaCronograma GetChild(int session_code, IDataReader reader, bool childs)
        {
            return new IncidenciaCronograma(session_code, reader, childs);
        }
        
        internal static IncidenciaCronograma GetChild(int session_code, IDataReader reader)
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

        private void Fetch(IncidenciaCronograma source)
        {
            try
            {
                SessionCode = source.SessionCode;

                _base.CopyValues(source);

                CriteriaEx criteria = IncidenciaSesionCronograma.GetCriteria(Session());
                criteria.AddEq("OidIncidencia", this.Oid);
                _sesiones = IncidenciaSesionesCronogramas.GetChildList(criteria.List<IncidenciaSesionCronograma>());
                
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
                    IncidenciaSesionCronograma.DoLOCK(Session(session_code));

                    //PENDIENTE
                    //string query = IncidenciaSesionesCronogramas.SELECT_BY_INCIDENCIA(this.Oid);
                    //IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    //_sesiones = IncidenciaSesionesCronogramas.GetChildList(reader);
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Insert(Cronograma parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidCronograma = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                parent.Session().Save(this.Base.Record);

                _sesiones.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Update(Cronograma parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidCronograma = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                IncidenciaCronogramaRecord obj = parent.Session().Get<IncidenciaCronogramaRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);

                _sesiones.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(Cronograma parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                SessionCode = parent.SessionCode;
                Session().Delete(Session().Get<IncidenciaCronogramaRecord>(Oid));
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

                    IncidenciaCronograma.DoLOCK(Session());

                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        IncidenciaSesionCronograma.DoLOCK(Session());

                        //PENDIENTE
                        //string query = IncidenciaSesionesCronogramas.SELECT_SESIONES_PLAN(this.Oid);
                        //reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        //_sesiones = IncidenciaSesionesCronogramas.GetChildList(reader);
                    }
                }
                else
                {
                    _base.Record.CopyValues((IncidenciaCronogramaRecord)(criteria.UniqueResult()));

                    //Session().Lock(Session().Get<IncidenciaCronogramaRecord>(Oid), LockMode.UpgradeNoWait);

                    if (Childs)
                    {
                        criteria = IncidenciaSesionCronograma.GetCriteria(Session());
                        criteria.AddEq("OidIncidencia", this.Oid);
                        _sesiones = IncidenciaSesionesCronogramas.GetChildList(criteria.List<IncidenciaSesionCronograma>());
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
                    IncidenciaCronogramaRecord obj = Session().Get<IncidenciaCronogramaRecord>(Oid);
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
                IncidenciaCronogramaRecord obj = (IncidenciaCronogramaRecord)(criteria.UniqueResult());
                Session().Delete(Session().Get<IncidenciaCronogramaRecord>(obj.Oid));

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

            query = "SELECT IC.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string ic = nHManager.Instance.GetSQLTable(typeof(IncidenciaCronogramaRecord));

            query = "   FROM   " + ic + "   AS IC";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.Cronograma != null && conditions.Cronograma.Oid > 0)
                query += " AND IC.\"OID_CRONOGRAMA\" = " + conditions.Cronograma.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions);

            if (lockTable) query += " FOR UPDATE OF IC NOWAIT";

            return query;
        }

        #endregion

    }
}

