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
    public class CronogramaRecord : RecordBase
    {
        #region Attributes

        private long _oid_plan;
        private long _oid_promocion;
        private string _observaciones = string.Empty;
        private DateTime _fecha_creacion;

        #endregion

        #region Properties

        public virtual long OidPlan { get { return _oid_plan; } set { _oid_plan = value; } }
        public virtual long OidPromocion { get { return _oid_promocion; } set { _oid_promocion = value; } }
        public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
        public virtual DateTime FechaCreacion { get { return _fecha_creacion; } set { _fecha_creacion = value; } }

        #endregion

        #region Business Methods

        public CronogramaRecord() { }

        public virtual void CopyValues(IDataReader source)
        {
            if (source == null) return;

            Oid = Format.DataReader.GetInt64(source, "OID");
            _oid_plan = Format.DataReader.GetInt64(source, "OID_PLAN");
            _oid_promocion = Format.DataReader.GetInt64(source, "OID_PROMOCION");
            _observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");
            _fecha_creacion = Format.DataReader.GetDateTime(source, "FECHA_CREACION");

        }
        public virtual void CopyValues(CronogramaRecord source)
        {
            if (source == null) return;

            Oid = source.Oid;
            _oid_plan = source.OidPlan;
            _oid_promocion = source.OidPromocion;
            _observaciones = source.Observaciones;
            _fecha_creacion = source.FechaCreacion;
        }

        #endregion
    }

    [Serializable()]
    public class CronogramaBase
    {
        #region Attributes

        private CronogramaRecord _record = new CronogramaRecord();

        private string _plan = string.Empty;
        private string _promocion = string.Empty;

        #endregion

        #region Properties

        public CronogramaRecord Record { get { return _record; } }

        public virtual string Plan { get { return _plan; } set { _plan = value; } }
        public virtual string Promocion { get { return _promocion; } set { _promocion = value; } }

        #endregion

        #region Business Methods

        internal void CopyValues(IDataReader source)
        {
            if (source == null) return;

            _record.CopyValues(source);

            _plan = Format.DataReader.GetString(source, "PLAN");
            _promocion = Format.DataReader.GetString(source, "PROMOCION");
        }
        public void CopyValues(Cronograma source)
        {
            if (source == null) return;

            _record.CopyValues(source.Base.Record);

            _plan = source.Plan;
            _promocion = source.Promocion;
        }
        public void CopyValues(CronogramaInfo source)
        {
            if (source == null) return;

            _record.CopyValues(source.Base.Record);

            _plan = source.PlanEstudios;
            _promocion = source.Promocion;
        }

        #endregion
    }

    /// <summary>
    /// Editable Root Business Object
    /// </summary>	
    [Serializable()]
    public class Cronograma : BusinessBaseEx<Cronograma>
    {
        #region Attributes

        protected CronogramaBase _base = new CronogramaBase();

        private SesionesCronogramas _sesiones = SesionesCronogramas.NewChildList();
        private Sesiones_Promociones _configuracion = Sesiones_Promociones.NewChildList();

        public virtual string Plan { get { return _base.Plan; } set { _base.Plan = value; } }
        public virtual string Promocion { get { return _base.Promocion; } set { _base.Promocion = value; } }


        #endregion

        #region Properties

        public CronogramaBase Base { get { return _base; } }

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
                //////CanWriteProperty(true);

                if (!_base.Record.OidPromocion.Equals(value))
                {
                    _base.Record.OidPromocion = value;
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
        public virtual DateTime FechaCreacion
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.FechaCreacion;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (!_base.Record.FechaCreacion.Equals(value))
                {
                    _base.Record.FechaCreacion = value;
                    PropertyHasChanged();
                }
            }
        }


        public virtual SesionesCronogramas Sesiones
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
        public virtual Sesiones_Promociones Configuracion
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _configuracion;
            }

            set
            {
                _configuracion = value;
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _sesiones.IsValid && _configuracion.IsValid; }
        }
        public override bool IsDirty
        {
            get { return base.IsDirty || _sesiones.IsDirty || _configuracion.IsDirty; }
        }


        #endregion

        #region Business Methods

        public virtual Cronograma CloneAsNew()
        {
            Cronograma clon = base.Clone();

            //Se definen el Oid y el Coidgo como nueva entidad
            Random rd = new Random();
            clon.Oid = rd.Next();

            clon.SessionCode = Cronograma.OpenSession();
            Cronograma.BeginTransaction(clon.SessionCode);

            clon.MarkNew();

            return clon;
        }

        protected virtual void CopyFrom(CronogramaInfo source)
        {
            if (source == null) return;

            Oid = source.Oid;
            OidPlan = source.OidPlan;
            OidPromocion = source.OidPromocion;
            Observaciones = source.Observaciones;
            FechaCreacion = source.FechaCreacion;
        }

        public static Dictionary<Horario, ListaSesiones> GetHorarios(SortedBindingList<SesionCronogramaInfo> sesiones,
                                                                        ClaseTeoricaList teoricas,
                                                                        ClasePracticaList practicas)
        {
            Dictionary<Horario, ListaSesiones> horarios = new Dictionary<Horario, ListaSesiones>();
            Horario horario = null;

            try
            {

                sesiones.ApplySort("Turno", ListSortDirection.Ascending);

                for (int i = 0; i < sesiones.Count; )
                {
                    List<SesionCronogramaInfo> sesiones_semana = new List<SesionCronogramaInfo>();

                    DateTime fecha_inicio = sesiones[i].Fecha;

                    while (fecha_inicio.DayOfWeek != DayOfWeek.Monday)
                        fecha_inicio = fecha_inicio.AddDays(-1);

                    DateTime fecha_fin = fecha_inicio.AddDays(6);

                    while (i < sesiones.Count && sesiones[i].Fecha.Date <= fecha_fin.Date)
                    {
                        sesiones_semana.Add(sesiones[i++]);
                    }

                    ListaSesiones sesiones_horario = new ListaSesiones(fecha_inicio);

                    foreach (SesionAuxiliar aux in sesiones_horario)
                    {
                        aux.Activa = false;

                        foreach (SesionCronogramaInfo info in sesiones_semana)
                        {
                            if (aux.Fecha.Date == info.Fecha.Date
                                && aux.Hora.TimeOfDay == info.Hora.TimeOfDay)
                            {
                                aux.Activa = true;

                                aux.OidClaseTeorica = info.OidClaseTeorica;
                                aux.OidClasePractica = info.OidClasePractica;
                                aux.Titulo = info.Alias;

                                if (info.OidClaseTeorica > 0)
                                {
                                    ClaseTeoricaInfo teorica = teoricas.GetItem(info.OidClaseTeorica);

                                    aux.OidModulo = teorica.OidModulo;
                                    aux.OidSubmodulo = teorica.OidSubmodulo;
                                }
                                else if (info.OidClasePractica > 0)
                                {
                                    ClasePracticaInfo practica = practicas.GetItem(info.OidClasePractica);

                                    aux.OidModulo = practica.OidModulo;
                                    aux.OidSubmodulo = practica.OidSubmodulo;
                                    aux.Incompatible = info.Incompatible;
                                    aux.Grupo = info.Grupo;
                                }

                                break;
                            }
                        }
                    }

                    horario = Horario.New();
                    horario.Oid = horarios.Count;
                    horario.FechaInicial = fecha_inicio;
                    horario.FechaFinal = fecha_inicio.AddDays(5);

                    horarios.Add(horario, sesiones_horario);
                }

                return horarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidPlan", 1));
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
        protected Cronograma() { }

        public virtual CronogramaInfo GetInfo(bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new CronogramaInfo(this, get_childs);
        }

        public virtual CronogramaInfo GetInfo()
        {
            return GetInfo(true);
        }

        #endregion

        #region Root Factory Methods

        public static Cronograma New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<Cronograma>(new CriteriaCs(-1));
        }

        public static Cronograma Get(long oid)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = Cronograma.GetCriteria(Cronograma.OpenSession());
            criteria.AddOidSearch(oid);
            criteria.Query = SELECT(oid);
            Cronograma.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Cronograma>(criteria);
        }

        public static Cronograma Get(CriteriaEx criteria)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Cronograma.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Cronograma>(criteria);
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
        /// Elimina todas los Cronogramas
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = Cronograma.OpenSession();
            ISession sess = Cronograma.Session(sessCode);
            ITransaction trans = Cronograma.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from Cronograma");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                Cronograma.CloseSession(sessCode);
            }
        }

        public override Cronograma Save()
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
                _configuracion.Update(this);

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

        private Cronograma(Cronograma source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private Cronograma(int session_code, IDataReader reader, bool childs)
        {
            MarkAsChild();
            Childs = childs;
            Fetch(session_code, reader);
        }

        public static Cronograma NewChild(PlanEstudios parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Cronograma obj = new Cronograma();
            obj.OidPlan = parent.Oid;
            return obj;
        }

        public static Cronograma NewChild(Promocion parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Cronograma obj = new Cronograma();
            obj.OidPromocion = parent.Oid;
            return obj;
        }

        internal static Cronograma GetChild(Cronograma source)
        {
            return new Cronograma(source);
        }

        internal static Cronograma GetChild(int session_code, IDataReader reader, bool childs)
        {
            return new Cronograma(session_code, reader, childs);
        }


        internal static Cronograma GetChild(int session_code, IDataReader reader)
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

        private void Fetch(Cronograma source)
        {
            try
            {
                SessionCode = source.SessionCode;

                _base.CopyValues(source);

                CriteriaEx criteria = SesionCronograma.GetCriteria(Session());
                criteria.AddEq("OidCronograma", this.Oid);
                _sesiones = SesionesCronogramas.GetChildList(criteria.List<SesionCronograma>());

                criteria = Sesion_Promocion.GetCriteria(Session());
                criteria.AddEq("OidPromocion", this.Oid);
                criteria.AddEq("Tipo", 2);
                _configuracion = Sesiones_Promociones.GetChildList(criteria.List<Sesion_Promocion>());


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
                    SesionCronograma.DoLOCK(Session(session_code));

                    string query = SesionesCronogramas.SELECT_BY_CRONOGRAMA(this.Oid);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _sesiones = SesionesCronogramas.GetChildList(reader);

                    Sesion_Promocion.DoLOCK(Session(session_code));

                    query = Sesiones_Promociones.SELECT(GetInfo(false));
                    reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _configuracion = Sesiones_Promociones.GetChildList(reader);
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Insert(PlanEstudios parent)
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

                _sesiones.Update(this);
                _configuracion.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Update(PlanEstudios parent)
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

                CronogramaRecord obj = parent.Session().Get<CronogramaRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);

                _sesiones.Update(this);
                _configuracion.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(PlanEstudios parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                SessionCode = parent.SessionCode;
                Session().Delete(Session().Get<CronogramaRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }

        internal void Insert(Promocion parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidPromocion = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                parent.Session().Save(this.Base.Record);

                _sesiones.Update(this);
                _configuracion.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Update(Promocion parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidPromocion = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                CronogramaRecord obj = parent.Session().Get<CronogramaRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);

                _sesiones.Update(this);
                _configuracion.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(Promocion parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                SessionCode = parent.SessionCode;
                Session().Delete(Session().Get<CronogramaRecord>(Oid));
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

                    Cronograma.DoLOCK(Session());

                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        SesionCronograma.DoLOCK(Session());

                        string query = SesionesCronogramas.SELECT_SESIONES_PLAN(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _sesiones = SesionesCronogramas.GetChildList(reader);

                        Sesion_Promocion.DoLOCK(Session());

                        query = Sesiones_Promociones.SELECT(GetInfo(false));
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _configuracion = Sesiones_Promociones.GetChildList(reader);
                    }
                }
                else
                {
                    _base.Record.CopyValues((CronogramaRecord)(criteria.UniqueResult()));

                    //Session().Lock(Session().Get<CronogramaRecord>(Oid), LockMode.UpgradeNoWait);

                    if (Childs)
                    {
                        criteria = SesionCronograma.GetCriteria(Session());
                        criteria.AddEq("OidCronograma", this.Oid);
                        _sesiones = SesionesCronogramas.GetChildList(criteria.List<SesionCronograma>());

                        criteria = Sesion_Promocion.GetCriteria(Session());
                        criteria.AddEq("OidPromocion", this.Oid);
                        criteria.AddEq("Tipo", 2);
                        _configuracion = Sesiones_Promociones.GetChildList(criteria.List<Sesion_Promocion>());
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
                    CronogramaRecord obj = Session().Get<CronogramaRecord>(Oid);
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
                CronogramaRecord obj = (CronogramaRecord)(criteria.UniqueResult());
                Session().Delete(Session().Get<CronogramaRecord>(obj.Oid));

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

        public virtual bool GeneraCronograma(DateTime fecha_inicio,
                                               DateTime fecha_fin,
                                               int semana_comienzo,
                                               int clases_dia,
                                               int clases_sabado,
                                               int total_dias,
                                               int practicas_semana,
                                               moleQule.Library.Timer t,
                                               List<bool> activas_dia, List<bool> activas_sabado)
        {
            PromocionInfo promocion = PromocionInfo.Get(OidPromocion, false);
            ClaseTeoricaList teoricas = ClaseTeoricaList.GetClasesOrdenadasPlanList(OidPlan);
            List<ClasePracticaList> practicas = new List<ClasePracticaList>();
            practicas.Add(null);

            AlumnoList alumnos = AlumnoList.GetListByPromocion(OidPromocion, false);

            for (int i = 1; i < 3; i++)
            {
                if (i == 1 && alumnos.Count == 0)
                    practicas.Add(ClasePracticaList.GetClasesOrdenadasPlanList(promocion.OidPlan, promocion.Oid, 0));
                else
                    practicas.Add(ClasePracticaList.GetClasesOrdenadasPlanList(promocion.OidPlan, promocion.Oid, i));
            }

            CronogramaController controlador = new CronogramaController(this, fecha_inicio, fecha_fin, teoricas, practicas, activas_dia, activas_sabado, practicas_semana, semana_comienzo);

            controlador.GeneraCronograma();

            ListaContadores lista_count = new ListaContadores();

            for (int i = 0; i < Sesiones.Count; i++)
            {
                long oid_modulo = 0;
                if (Sesiones[i].OidClasePractica > 0)
                    oid_modulo = practicas[(int)Sesiones[i].Grupo].GetItem(Sesiones[i].OidClasePractica).OidModulo;
                else
                    oid_modulo = teoricas.GetItem(Sesiones[i].OidClaseTeorica).OidModulo;

                if (oid_modulo != 0)
                    Sesiones[i].Numero = lista_count.NuevoContador(oid_modulo);
                Sesiones[i].Turno = i;
            }

            return true;
        }

        public static CronogramaInfo GeneraCronograma(PromocionInfo promocion,
                                                int clases_dia,
                                                int clases_sabado,
                                                int total_dias,
                                                List<bool> activas_dia, List<bool> activas_sabado,
                                                DateTime fecha_fin,
                                                bool restantes)
        {
            Cronograma crono = new Cronograma();
            crono.OidPromocion = promocion.Oid;
            crono.Promocion = promocion.Nombre;

            ClaseTeoricaList teoricas = null;
            List<ClasePracticaList> practicas = new List<ClasePracticaList>();
            practicas.Add(null);

            if (!restantes)
            {
                teoricas = ClaseTeoricaList.GetClasesOrdenadasPlanList(promocion.OidPlan);

                for (int i = 1; i < 3; i++)
                {
                    practicas.Add(ClasePracticaList.GetClasesOrdenadasPlanList(promocion.OidPlan, promocion.Oid, i));
                }
            }
            else
            {
                teoricas = ClaseTeoricaList.GetNoImpartidasList(promocion.OidPlan, 0, promocion.Oid);
                for (int i = 1; i < 3; i++)
                    practicas.Add(ClasePracticaList.GetDisponiblesList(promocion.OidPlan, promocion.Oid, 0, i));
            }

            DateTime fecha_inicio = promocion.FechaInicio;

            if (restantes)
            {
                HorarioInfo horario = HorarioInfo.GetLast(promocion.Oid, false);
                fecha_inicio = horario.FechaInicial.AddDays(7);
            }

            CronogramaController controlador = new CronogramaController(crono, fecha_inicio, fecha_fin, teoricas, practicas, activas_dia, activas_sabado);

            controlador.GeneraCronograma();

            ListaContadores lista_count = new ListaContadores();

            for (int i = 0; i < crono.Sesiones.Count; i++)
            {
                long oid_modulo = 0;
                if (crono.Sesiones[i].OidClasePractica > 0)
                    oid_modulo = practicas[(int)crono.Sesiones[i].Grupo].GetItem(crono.Sesiones[i].OidClasePractica).OidModulo;
                else
                    oid_modulo = teoricas.GetItem(crono.Sesiones[i].OidClaseTeorica).OidModulo;

                if (oid_modulo != 0)
                    crono.Sesiones[i].Numero = lista_count.NuevoContador(oid_modulo);
                crono.Sesiones[i].Turno = i;
            }

            return crono.GetInfo(true);
        }


        /// <summary>
        /// Rellena una lista de sublistas que contienen los índices de comienzo de las clases de determinada duración
        /// lista[0] : 1 hora
        /// lista[1] : 2 horas
        /// lista[2] : 3 horas
        /// </summary>
        /// <returns></returns>
        public virtual List<List<long>> RellenaHorasSemana(List<bool> activas_dia, List<bool> activas_sabado)
        {
            List<bool> horas_lv = new List<bool>();

            PromocionInfo promo = PromocionInfo.Get(this.OidPromocion, true);

            List<List<long>> lista = new List<List<long>>();

            for (int i = 0; i < activas_dia.Count; i++)
                horas_lv.Add(activas_dia[i]);

            if (moleQule.Library.Instruction.Promocion.CompruebaConfiguracion(horas_lv, Sesion_PromocionList.GetChildList(Configuracion)))
            {
                Dictionary<string, int> indices = new Dictionary<string, int>();

                DateTime hora = DateTime.Parse("8:00");

                for (int i = 0; i < 14; i++)
                {
                    lista.Add(new List<long>());
                    indices.Add(hora.ToShortTimeString(), i);
                    hora = hora.AddHours(1);
                }

                foreach (Sesion_Promocion item in Configuracion)
                {
                    int indice = -1;
                    if (indices.TryGetValue(item.HoraInicio.ToShortTimeString(), out indice))
                        lista[(int)item.NHoras - 1].Add(indice);
                }

                return lista;
            }
            else
            {
                horas_lv.Add(false);

                List<bool> horas_s = new List<bool>();

                for (int i = 0; i < activas_sabado.Count; i++)
                    horas_s.Add(activas_sabado[i]);

                horas_s.Add(false);

                List<long> lista_1 = new List<long>();
                List<long> lista_2 = new List<long>();
                List<long> lista_3 = new List<long>();

                int inicio = 0;
                int total = 0;

                for (int i = 0; i < 14; i++)
                {
                    if (horas_lv[i])
                    {
                        if (total == 0)
                            inicio = i;
                        total++;
                    }
                    else
                    {
                        if (total > 1)
                        {
                            while (total > 0)
                            {
                                if (total % 3 == 0)
                                {
                                    while (total > 0)
                                    {
                                        lista_3.Add(inicio);
                                        inicio += 3;
                                        total -= 3;
                                    }
                                }
                                else
                                {
                                    if ((total - 3) > 1)
                                    {
                                        lista_3.Add(inicio);
                                        inicio += 3;
                                        total -= 3;
                                    }
                                    else
                                    {
                                        lista_2.Add(inicio);
                                        inicio += 2;
                                        total -= 2;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (total > 0)
                                lista_1.Add(inicio);
                        }
                        total = 0;
                    }
                }

                total = 0;
                inicio = 0;
                for (int i = 0; i < 6; i++)
                {
                    if (horas_s[i])
                    {
                        if (total == 0)
                            inicio = i;
                        total++;
                    }
                    else
                    {
                        if (total > 1)
                        {
                            while (total > 0)
                            {
                                if (total % 3 == 0)
                                {
                                    while (total > 0)
                                    {
                                        lista_3.Add(inicio + 70);
                                        inicio += 3;
                                        total -= 3;
                                    }
                                }
                                else
                                {
                                    lista_2.Add(inicio + 70);
                                    inicio += 2;
                                    total -= 2;
                                }
                            }
                        }
                        else
                        {
                            if (total > 0)
                                lista_1.Add(inicio + 70);
                        }
                        total = 0;
                    }
                }

                lista.Add(lista_1);
                lista.Add(lista_2);
                lista.Add(lista_3);

                return lista;
            }
        }

        #endregion

        #region SQL

        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        private static string SELECT_CRONOGRAMA(long oid_plan, long oid_promocion)
        {
            string Cronograma = nHManager.Instance.Cfg.GetClassMapping(typeof(CronogramaRecord)).Table.Name;
            string plan = nHManager.Instance.GetSQLTable(typeof(PlanEstudiosRecord));
            string promocion = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));

            string query;

            string esquema = Convert.ToInt32(AppContext.ActiveSchema.Code).ToString("0000");

            query = "SELECT C.* , PL.\"NOMBRE\" AS \"PLAN\", COALESCE(PR.\"NOMBRE\", '') AS \"PROMOCION\" " +
                    "FROM \"" + esquema + "\".\"" + Cronograma + "\" AS C " +
                    "INNER JOIN " + plan + " AS PL ON PL.\"OID\" = C.\"OID_PLAN\" " +
                    "LEFT JOIN " + promocion + " AS PR ON PR.\"OID\" = C.\"OID_PROMOCION\" " +
                    "WHERE C.\"OID_PLAN\" = " + oid_plan.ToString() + " " +
                    "AND C.\"OID_PROMOCION\" = " + oid_promocion.ToString() + ";";

            return query;
        }

        public new static string SELECT(long oid)
        {
            string Cronograma = nHManager.Instance.Cfg.GetClassMapping(typeof(CronogramaRecord)).Table.Name;
            string plan = nHManager.Instance.GetSQLTable(typeof(PlanEstudiosRecord));
            string promocion = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));

            string query;

            string esquema = Convert.ToInt32(AppContext.ActiveSchema.Code).ToString("0000");

            query = "SELECT C.* , PL.\"NOMBRE\" AS \"PLAN\", COALESCE(PR.\"NOMBRE\", '') AS \"PROMOCION\" " +
                    "FROM \"" + esquema + "\".\"" + Cronograma + "\" AS C " +
                    "INNER JOIN " + plan + " AS PL ON PL.\"OID\" = C.\"OID_PLAN\" " +
                    "LEFT JOIN " + promocion + " AS PR ON PR.\"OID\" = C.\"OID_PROMOCION\" ";
            if (oid > 0)
                query += "WHERE C.\"OID\" = " + oid.ToString() + ";";

            return query;
        }

        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        private static string UNION_CLASES(long oid_plan)
        {
            string clase_practica = nHManager.Instance.Cfg.GetClassMapping(typeof(ClasePracticaRecord)).Table.Name;
            string clase_teorica = nHManager.Instance.Cfg.GetClassMapping(typeof(ClaseTeoricaRecord)).Table.Name;

            string query;

            string esquema = Convert.ToInt32(AppContext.ActiveSchema.Code).ToString("0000");

            query = "SELECT \"OID\", \"OID_SUBMODULO\", \"OID_MODULO\" , \"TITULO\",\"ORDEN_PRIMARIO\", \"ORDEN_SECUNDARIO\", \"ORDEN_TERCIARIO\", 0 AS TIPO, 3 AS GRUPO " +
                    "FROM \"" + esquema + "\".\"" + clase_teorica + "\" " +
                    "WHERE \"OID_PLAN\" = " + oid_plan.ToString() + " " +
                    "UNION " +
                    "SELECT \"OID\", \"OID_SUBMODULO\", \"OID_MODULO\" , \"TITULO\",\"ORDEN_PRIMARIO\", \"ORDEN_SECUNDARIO\", \"ORDEN_TERCIARIO\", 1 AS TIPO, 1 AS GRUPO " +
                    "FROM \"" + esquema + "\".\"" + clase_practica + "\" " +
                    "WHERE \"OID_PLAN\" = " + oid_plan.ToString() + " " +
                    "UNION " +
                    "SELECT \"OID\", \"OID_SUBMODULO\", \"OID_MODULO\" , \"TITULO\",\"ORDEN_PRIMARIO\", \"ORDEN_SECUNDARIO\", \"ORDEN_TERCIARIO\", 1 AS TIPO, 2 AS GRUPO " +
                    "FROM \"" + esquema + "\".\"" + clase_practica + "\" " +
                    "WHERE \"OID_PLAN\" = " + oid_plan.ToString() + " " +
                    "ORDER BY \"ORDEN_PRIMARIO\", \"ORDEN_SECUNDARIO\", \"ORDEN_TERCIARIO\";";

            return query;
        }


        #endregion

    }
}

