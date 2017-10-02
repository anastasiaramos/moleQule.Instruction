using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class PlantillaExamenRecord : RecordBase
	{
		#region Attributes

		private long _oid_modulo;
		private string _codigo = string.Empty;
		private long _serial;
		private string _idioma = string.Empty;
		private bool _desarrollo = false;
		private long _n_preguntas;
		private string _nombre = string.Empty;
  
		#endregion
		
		#region Properties
		
				public virtual long OidModulo { get { return _oid_modulo; } set { _oid_modulo = value; } }
		public virtual string Codigo { get { return _codigo; } set { _codigo = value; } }
		public virtual long Serial { get { return _serial; } set { _serial = value; } }
		public virtual string Idioma { get { return _idioma; } set { _idioma = value; } }
		public virtual bool Desarrollo { get { return _desarrollo; } set { _desarrollo = value; } }
		public virtual long NPreguntas { get { return _n_preguntas; } set { _n_preguntas = value; } }
		public virtual string Nombre { get { return _nombre; } set { _nombre = value; } }

		#endregion
		
		#region Business Methods
		
		public PlantillaExamenRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_modulo = Format.DataReader.GetInt64(source, "OID_MODULO");
			_codigo = Format.DataReader.GetString(source, "CODIGO");
			_serial = Format.DataReader.GetInt64(source, "SERIAL");
			_idioma = Format.DataReader.GetString(source, "IDIOMA");
			_desarrollo = Format.DataReader.GetBool(source, "DESARROLLO");
			_n_preguntas = Format.DataReader.GetInt64(source, "N_PREGUNTAS");
			_nombre = Format.DataReader.GetString(source, "NOMBRE");

		}		
		public virtual void CopyValues(PlantillaExamenRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_modulo = source.OidModulo;
			_codigo = source.Codigo;
			_serial = source.Serial;
			_idioma = source.Idioma;
			_desarrollo = source.Desarrollo;
			_n_preguntas = source.NPreguntas;
			_nombre = source.Nombre;
		}
		
		#endregion	
	}

    [Serializable()]
	public class PlantillaExamenBase 
	{	 
		#region Attributes
		
		private PlantillaExamenRecord _record = new PlantillaExamenRecord();

        private string _modulo = string.Empty;
		
		#endregion
		
		#region Properties
		
		public PlantillaExamenRecord Record { get { return _record; } }

        public virtual string Modulo { get { return _modulo; } set { _modulo = value; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);

            _modulo = Format.DataReader.GetString(source, "MODULO");
		}		
		public void CopyValues(PlantillaExamen source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _modulo = source.Modulo;
		}
		public void CopyValues(PlantillaExamenInfo source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _modulo = source.Modulo;
		}
		
		#endregion	
	}
		
	/// <summary>
	/// Editable Root Business Object
	/// </summary>	
    [Serializable()]
	public class PlantillaExamen : BusinessBaseEx<PlantillaExamen>
	{	 
		#region Attributes
		
		protected PlantillaExamenBase _base = new PlantillaExamenBase();

        private Preguntas_Plantillas _preguntas = Preguntas_Plantillas.NewChildList();
		

		#endregion
		
		#region Properties
		
		public PlantillaExamenBase Base { get { return _base; } }
		
		public override long Oid
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				////CanReadProperty(true);
				return _base.Record.Oid;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				if (!_base.Record.Oid.Equals(value))
				{
					_base.Record.Oid = value;
					//PropertyHasChanged();
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
                //CanWriteProperty(true);
                if (!_base.Record.OidModulo.Equals(value))
                {
                    _base.Record.OidModulo = value;
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
                //CanWriteProperty(true);
                if (!_base.Record.Serial.Equals(value))
                {
                    _base.Record.Serial = value;
                    PropertyHasChanged();
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
                //CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_base.Record.Codigo.Equals(value))
                {
                    _base.Record.Codigo = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Idioma
        {

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.Idioma;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_base.Record.Idioma.Equals(value))
                {
                    _base.Record.Idioma = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool Desarrollo
        {

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.Desarrollo;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //CanWriteProperty(true);
                if (!_base.Record.Desarrollo.Equals(value))
                {
                    _base.Record.Desarrollo = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual long NPreguntas
        {

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.NPreguntas;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //CanWriteProperty(true);
                if (!_base.Record.NPreguntas.Equals(value))
                {
                    _base.Record.NPreguntas = value;
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
                //CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_base.Record.Nombre.Equals(value))
                {
                    _base.Record.Nombre = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual Preguntas_Plantillas Preguntas
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _preguntas;
            }

            set
            {
                _preguntas = value;
            }
        }

        public virtual string Modulo { get { return _base.Modulo; } set { _base.Modulo = value; } }

        public override bool IsValid
        {
            get { return base.IsValid && _preguntas.IsValid; }
        }
        public override bool IsDirty
        {
            get { return base.IsDirty || _preguntas.IsDirty; }
        }
	
		
		
		#endregion
		
		#region Business Methods
		
        /// <summary>
        /// Clona la entidad y sus subentidades y las marca como nuevas
        /// </summary>
        /// <returns>Una entidad clon</returns>
        public virtual PlantillaExamen CloneAsNew()
        {
            PlantillaExamen clon = base.Clone();

            // Se define el Oid como nueva entidad
            Random rd = new Random();
            clon.Oid = rd.Next();
            clon.Codigo = (0).ToString(Resources.Defaults.PLANTILLA_CODE_FORMAT);

            clon.SessionCode = PlantillaExamen.OpenSession();
            PlantillaExamen.BeginTransaction(clon.SessionCode);
            clon.MarkNew();
            clon.Preguntas.MarkAsNew();

            return clon;
        }

        /// <summary>
        /// Devuelve el siguiente código de Cliente.
        /// </summary>
        /// <returns>Código de 9 cifras</returns>
        public static string GetNewCode()
        {
            Int64 lastcode = PlantillaExamen.GetNewSerial();

            // Devolvemos el siguiente codigo de cliente 
            return lastcode.ToString(Resources.Defaults.PLANTILLA_CODE_FORMAT);
        }

        /// <summary>
        /// Devuelve el siguiente Serial de PlantillaExamen.
        /// </summary>
        /// <returns>Código de 9 cifras</returns>
        private static Int64 GetNewSerial()
        {
            // Obtenemos la lista de clientes ordenados por serial
            SortedBindingList<PlantillaExamenInfo> plantillas =
                PlantillaExamenList.GetSortedList("Serial", ListSortDirection.Ascending);

            // Obtenemos el último serial de servicio
            Int64 lastcode;

            if (plantillas.Count > 0)
                lastcode = plantillas[plantillas.Count - 1].Serial;
            else
                lastcode = Convert.ToInt64(Resources.Defaults.PLANTILLA_CODE_FORMAT);

            lastcode++;
            return lastcode;
        }		
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidModulo", 1));
        }


        #endregion

        #region Autorization Rules

        public static bool CanAddObject()
        {
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.EXAMEN);
        }

        public static bool CanGetObject()
        {
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.EXAMEN);
        }

        public static bool CanDeleteObject()
        {
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.EXAMEN);
        }

        public static bool CanEditObject()
        {
            return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.EXAMEN);
        }

        #endregion

        #region Common Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        public PlantillaExamen()
        {
            //MarkAsChild();
            Random r = new Random();
            Oid = (long)r.Next();
        }

        public virtual PlantillaExamenInfo GetInfo(bool get_childs)
        {
            /*if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            if (get_childs)
            {

                if (nHMng.UseDirectSQL)
                {
                    string query;

                    query = Preguntas_Plantillas.SELECT_BY_FIELD( "OidPlantilla", this.Oid);
                    IDataReader r_preguntas = nHManager.Instance.SQLNativeSelect(query, Session());

                    return new PlantillaExamenInfo(_oid,_oid_modulo, _codigo, _serial, _idioma, _desarrollo, _n_preguntas, _nombre,
                                            Preguntas_PlantillaList.GetChildList(r_preguntas));
                }
                else
                    return new PlantillaExamenInfo(_oid, _oid_modulo, _codigo, _serial, _idioma, _desarrollo, _n_preguntas, _nombre,
                                           Preguntas_PlantillaList.GetChildList(_preguntas));
            }
            else
                return new PlantillaExamenInfo(_oid, _oid_modulo, _codigo, _serial, _idioma, _desarrollo, _n_preguntas, _nombre, null);
             * */
            if (!CanGetObject())
                throw new System.Security.SecurityException(Library.Resources.Messages.USER_NOT_ALLOWED);

            return new PlantillaExamenInfo(this, get_childs);
        }

        public virtual PlantillaExamenInfo GetInfo()
        {
            return GetInfo(true);
        }

        #endregion

        #region Root Factory Methods

        public static PlantillaExamen New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<PlantillaExamen>(new CriteriaCs(-1));
        }

        public static PlantillaExamen Get(long oid, bool childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = PlantillaExamen.GetCriteria(PlantillaExamen.OpenSession());
            criteria.Childs = childs;
            
            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = PlantillaExamen.SELECT(oid);
            else
                criteria.AddOidSearch(oid); 

            PlantillaExamen.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<PlantillaExamen>(criteria);
        }

        public static PlantillaExamen Get(long oid)
        {
            return PlantillaExamen.Get(oid, true);
        }

        public static PlantillaExamen Get(CriteriaEx criteria)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            PlantillaExamen.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<PlantillaExamen>(criteria);
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
        /// Elimina todas los PlantillaExamens
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = PlantillaExamen.OpenSession();
            ISession sess = PlantillaExamen.Session(sessCode);
            ITransaction trans = PlantillaExamen.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from PlantillaExamen");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                PlantillaExamen.CloseSession(sessCode);
            }
        }

        public override PlantillaExamen Save()
        {
            // Por interfaz Root/Child
            if (IsChild)
                throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);

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

                _preguntas.Update(this);

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

        protected PlantillaExamen(PlantillaExamen source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private PlantillaExamen(int session_code, IDataReader reader, bool childs)
        {
            MarkAsChild();
            Childs = childs;
            Fetch(session_code, reader);
        }

        public static PlantillaExamen NewChild(Modulo parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            PlantillaExamen obj = new PlantillaExamen();
            obj.OidModulo = parent.Oid;
            return obj;
        }

        internal static PlantillaExamen GetChild(PlantillaExamen source)
        {
            return new PlantillaExamen(source);
        }

        internal static PlantillaExamen GetChild(int session_code, IDataReader reader, bool childs)
        {
            return new PlantillaExamen(session_code, reader, childs);
        }


        internal static PlantillaExamen GetChild(int session_code, IDataReader reader)
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
            Codigo = (0).ToString(Resources.Defaults.PLANTILLA_CODE_FORMAT);
            _preguntas = Preguntas_Plantillas.NewChildList();
        }

        #endregion

        #region Child Data Access

        private void Fetch(PlantillaExamen source)
        {
            try
            {
                SessionCode = source.SessionCode;

                _base.CopyValues(source);

                CriteriaEx criteria;

                criteria = Preguntas_Plantilla.GetCriteria(Session());
                criteria.AddEq("OidPlantilla", this.Oid);
                _preguntas = Preguntas_Plantillas.GetChildList(criteria.List<Preguntas_Plantilla>());

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

                    Preguntas_Plantilla.DoLOCK( Session(session_code));

                    query = Preguntas_Plantillas.SELECT_BY_PLANTILLA(this.Oid);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _preguntas = Preguntas_Plantillas.GetChildList(reader);

                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }


        //internal void Insert(Modulo parent)
        //{
        //    // if we're not dirty then don't update the database
        //    if (!this.IsDirty) return;

        //    //Debe obtener la sesion del padre pq el objeto es padre a su vez
        //    SessionCode = parent.SessionCode;

        //    _oid_modulo = parent.Oid;

        //    try
        //    {
        //        ValidationRules.CheckRules();

        //        if (!IsValid)
        //            throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

        //        parent.Session().Save(this);

        //        _preguntas.Update(this);
        //    }
        //    catch (Exception ex)
        //    {
        //        iQExceptionHandler.TreatException(ex);
        //    }

        //    MarkOld();
        //}

        //internal void Update(Modulo parent)
        //{
        //    // if we're not dirty then don't update the database
        //    if (!this.IsDirty) return;

        //    //Debe obtener la sesion del padre pq el objeto es padre a su vez
        //    SessionCode = parent.SessionCode;

        //    _oid_modulo = parent.Oid;

        //    try
        //    {
        //        ValidationRules.CheckRules();

        //        if (!IsValid)
        //            throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

        //        PlantillaExamen obj = parent.Session().Get<PlantillaExamen>(Oid);
        //        obj.CopyValues(this);
        //        parent.Session().Update(obj);

        //        _preguntas.Update(this);
        //    }
        //    catch (Exception ex)
        //    {
        //        iQExceptionHandler.TreatException(ex);
        //    }

        //    MarkOld();
        //}


        //internal void DeleteSelf(Modulo parent)
        //{
        //    // if we're not dirty then don't update the database
        //    if (!this.IsDirty) return;

        //    // if we're new then don't update the database
        //    if (this.IsNew) return;

        //    try
        //    {
        //        SessionCode = parent.SessionCode;
        //        Session().Delete(Session().Get<PlantillaExamen>(Oid));
        //    }
        //    catch (Exception ex)
        //    {
        //        iQExceptionHandler.TreatException(ex);
        //    }

        //    MarkNew();
        //}


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
                    PlantillaExamen.DoLOCK(Session());
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        string query;

                        Preguntas_Plantilla.DoLOCK(Session());
                        query = Preguntas_Plantillas.SELECT_BY_PLANTILLA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _preguntas = Preguntas_Plantillas.GetChildList(reader);
                    }
                }
                else
                {
                    _base.Record.CopyValues((PlantillaExamenRecord)(criteria.UniqueResult()));

                    //Session().Lock(Session().Get<PlantillaExamen>(Oid), LockMode.UpgradeNoWait);

                    if (Childs)
                    {
                        criteria = Preguntas_Plantilla.GetCriteria(Session());
                        criteria.AddEq("OidPlantilla", this.Oid);
                        _preguntas = Preguntas_Plantillas.GetChildList(criteria.List<Preguntas_Plantilla>());

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
                Codigo = GetNewCode();
                Serial = GetNewSerial();
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
                    PlantillaExamenRecord obj = Session().Get<PlantillaExamenRecord>(Oid);
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
                PlantillaExamenRecord obj = (PlantillaExamenRecord)(criteria.UniqueResult());
                Session().Delete(Session().Get<PlantillaExamenRecord>(obj.Oid));

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
                CriteriaEx criteria = PlantillaExamen.GetCriteria(PlantillaExamen.OpenSession());
                criteria.AddCodeSearch(_codigo);
                PlantillaExamenList list = PlantillaExamenList.GetList(criteria);
                _exists = !(list.Count == 0);
            }
        }



        #endregion

        #region SQL

        internal static string SELECT_FIELDS()
        {
            string query;

            query = "SELECT PE.*," +
                    "       M.\"NUMERO_MODULO\", M.\"TEXTO\" AS \"MODULO\"";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string pe = nHManager.Instance.GetSQLTable(typeof(PlantillaExamenRecord));
            string mo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));

            query = "   FROM   " + pe + "   AS PE" +
                    "   INNER JOIN " + mo + " AS M ON PE.\"OID_MODULO\" = M.\"OID\"";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.Modulo != null && conditions.Modulo.Oid > 0)
                query += " AND PE.\"OID_MODULO\" = " + conditions.Modulo.Oid;

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

        internal static string SELECT(long oid, bool lock_table)
        {
            string pe = nHManager.Instance.GetSQLTable(typeof(PlantillaExamenRecord));
            string m = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));

            string query;

            query = PlantillaExamen.SELECT_FIELDS() +
                    " FROM " + pe + " AS PE" +
                    " INNER JOIN " + m + " AS M ON PE.\"OID_MODULO\" = M.\"OID\"";

            if (oid > 0) query += " WHERE PE.\"OID\" = " + oid.ToString();

            if (lock_table) query += " FOR UPDATE OF PE NOWAIT";

            return query;
        }

        internal new static string SELECT(long oid) { return PlantillaExamen.SELECT(oid, true); }

        #endregion
    }
}

