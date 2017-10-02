using System;
using System.ComponentModel;
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
	public class MaterialDocenteRecord : RecordBase
	{
		#region Attributes

		private long _oid_curso;
		private string _nombre = string.Empty;
		private string _observaciones = string.Empty;
		private long _oid_modulo;
  
		#endregion
		
		#region Properties
		
		public virtual long OidCurso { get { return _oid_curso; } set { _oid_curso = value; } }
		public virtual string Nombre { get { return _nombre; } set { _nombre = value; } }
		public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
		public virtual long OidModulo { get { return _oid_modulo; } set { _oid_modulo = value; } }

		#endregion
		
		#region Business Methods
		
		public MaterialDocenteRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_curso = Format.DataReader.GetInt64(source, "OID_CURSO");
			_nombre = Format.DataReader.GetString(source, "NOMBRE");
			_observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");
			_oid_modulo = Format.DataReader.GetInt64(source, "OID_MODULO");

		}		
		public virtual void CopyValues(MaterialDocenteRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_curso = source.OidCurso;
			_nombre = source.Nombre;
			_observaciones = source.Observaciones;
			_oid_modulo = source.OidModulo;
		}
		
		#endregion	
	}

    [Serializable()]
	public class MaterialDocenteBase 
	{	 
		#region Attributes
		
		private MaterialDocenteRecord _record = new MaterialDocenteRecord();

        private string _modulo = string.Empty;
        private string _curso = string.Empty;
		
		#endregion
		
		#region Properties
		
		public MaterialDocenteRecord Record { get { return _record; } }

        public virtual string Modulo { get { return _modulo; } set { _modulo = value; } }
        public virtual string Curso { get { return _curso; } set { _curso = value; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);

            _curso = Format.DataReader.GetString(source, "CURSO");
            _modulo = Format.DataReader.GetString(source, "MODULO");
		}		
		public void CopyValues(MaterialDocente source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _modulo = source.Modulo;
            _curso = source.Curso;
		}
		public void CopyValues(MaterialDocenteInfo source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _modulo = source.Modulo;
            _curso = source.Curso;
		}
		
		#endregion	
	}
		
	/// <summary>
	/// Editable Root Business Object
	/// </summary>	
    [Serializable()]
	public class MaterialDocente : BusinessBaseEx<MaterialDocente>
	{	 
		#region Attributes
		
		protected MaterialDocenteBase _base = new MaterialDocenteBase();

        private RevisionMaterials _revisiones = RevisionMaterials.NewChildList();
        private Material_Plans _planes = Material_Plans.NewChildList();
        private Material_Alumnos _alumnos = Material_Alumnos.NewChildList();
		

		#endregion
		
		#region Properties
		
		public MaterialDocenteBase Base { get { return _base; } }
		
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
        public virtual long OidCurso
        {

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.OidCurso;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (!_base.Record.OidCurso.Equals(value))
                {
                    _base.Record.OidCurso = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual long OidModulo
        {

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.OidModulo;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (!_base.Record.OidModulo.Equals(value))
                {
                    _base.Record.OidModulo = value;
                    PropertyHasChanged();
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

        public virtual RevisionMaterials Revisiones
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _revisiones;
            }

            set
            {
                _revisiones = value;
            }
        }
        public virtual Material_Plans Planes
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _planes;
            }

            set
            {
                _planes = value;
            }
        }
        public virtual Material_Alumnos Alumnos
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

        public virtual string Modulo { get { return _base.Modulo; } set { _base.Modulo = value; } }
        public virtual string Curso { get { return _base.Curso; } set { _base.Curso = value; } }

        public override bool IsValid
        {
            get { return base.IsValid && _revisiones.IsValid && _planes.IsValid && _alumnos.IsValid; }
        }
        public override bool IsDirty
        {
            get { return base.IsDirty || _revisiones.IsDirty || _planes.IsDirty || _alumnos.IsDirty; }
        }
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual MaterialDocente CloneAsNew()
		{
			MaterialDocente clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = MaterialDocente.OpenSession();
			MaterialDocente.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
        
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Nombre");
        }

        #endregion

        #region Autorization Rules

        public static bool CanAddObject()
        {
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.MATERIAL_DOCENTE);

        }

        public static bool CanGetObject()
        {
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.MATERIAL_DOCENTE);

        }

        public static bool CanDeleteObject()
        {
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.MATERIAL_DOCENTE);

        }
        public static bool CanEditObject()
        {
            return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.MATERIAL_DOCENTE);

        }

        #endregion

        #region Common Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        protected MaterialDocente() { }

        public virtual MaterialDocenteInfo GetInfo(bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new MaterialDocenteInfo(this, get_childs);
        }

        public virtual MaterialDocenteInfo GetInfo()
        {
            return GetInfo(true);
        }

        #endregion

        #region Root Factory Methods

        public static MaterialDocente New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<MaterialDocente>(new CriteriaCs(-1));
        }

        public static MaterialDocente Get(long oid)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = MaterialDocente.GetCriteria(MaterialDocente.OpenSession());
            criteria.AddOidSearch(oid);
            criteria.Query = MaterialDocenteInfo.SELECT(oid);
            MaterialDocente.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<MaterialDocente>(criteria);
        }

        public static MaterialDocente Get(CriteriaEx criteria)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            MaterialDocente.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<MaterialDocente>(criteria);
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
        /// Elimina todas los MaterialDocentes
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = MaterialDocente.OpenSession();
            ISession sess = MaterialDocente.Session(sessCode);
            ITransaction trans = MaterialDocente.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from MaterialDocente");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                MaterialDocente.CloseSession(sessCode);
            }
        }

        public override MaterialDocente Save()
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

                _revisiones.Update(this);
                _planes.Update(this);
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

        private MaterialDocente(MaterialDocente source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private MaterialDocente(int session_code, IDataReader reader, bool childs)
        {
            MarkAsChild();
            Childs = childs;
            Fetch(session_code, reader);
        }

        public static MaterialDocente NewChild(PlanEstudios parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            MaterialDocente obj = new MaterialDocente();
            obj.OidModulo = parent.Oid;
            return obj;
        }

        public static MaterialDocente NewChild(Curso parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            MaterialDocente obj = new MaterialDocente();
            obj.OidCurso = parent.Oid;
            return obj;
        }

        internal static MaterialDocente GetChild(MaterialDocente source)
        {
            return new MaterialDocente(source);
        }

        internal static MaterialDocente GetChild(int session_code, IDataReader reader, bool childs)
        {
            return new MaterialDocente(session_code, reader, childs);
        }


        internal static MaterialDocente GetChild(int session_code, IDataReader reader)
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

        private void Fetch(MaterialDocente source)
        {
            try
            {
                SessionCode = source.SessionCode;

                _base.CopyValues(source);

                CriteriaEx criteria = RevisionMaterial.GetCriteria(Session());
                criteria.AddEq("OidMaterial", this.Oid);
                _revisiones = RevisionMaterials.GetChildList(criteria.List<RevisionMaterial>());

                criteria = Material_Plan.GetCriteria(Session());
                criteria.AddEq("OidMaterial", this.Oid);
                _planes = Material_Plans.GetChildList(criteria.List<Material_Plan>());

                criteria = Material_Alumno.GetCriteria(Session());
                criteria.AddEq("OidMaterial", this.Oid);
                _alumnos = Material_Alumnos.GetChildList(criteria.List<Material_Alumno>());


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
                    RevisionMaterial.DoLOCK(Session(session_code));

                    string query = RevisionMaterials.SELECT_BY_MATERIAL(this.Oid);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _revisiones = RevisionMaterials.GetChildList(session_code, reader);

                    Material_Plan.DoLOCK(Session(session_code));

                    query = Material_Plans.SELECT(GetInfo(false));
                    reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _planes = Material_Plans.GetChildList(reader);

                    Material_Alumno.DoLOCK(Session(session_code));

                    query = Material_Alumnos.SELECT_BY_MATERIAL(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _alumnos = Material_Alumnos.GetChildList(reader);
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

            OidModulo = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                parent.Session().Save(this.Base.Record);

                _revisiones.Update(this);
                _planes.Update(this);
                _alumnos.Update(this);
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

            OidModulo = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                MaterialDocenteRecord obj = parent.Session().Get<MaterialDocenteRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);

                _revisiones.Update(this);
                _planes.Update(this);
                _alumnos.Update(this);
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
                Session().Delete(Session().Get<MaterialDocenteRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
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

                parent.Session().Save(this.Base.Record);

                _revisiones.Update(this);
                _planes.Update(this);
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

                MaterialDocenteRecord obj = parent.Session().Get<MaterialDocenteRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);

                _revisiones.Update(this);
                _planes.Update(this);
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
                Session().Delete(Session().Get<MaterialDocenteRecord>(Oid));
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

                    MaterialDocente.DoLOCK(Session());

                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        RevisionMaterial.DoLOCK(Session());

                        string query = RevisionMaterials.SELECT_BY_MATERIAL(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _revisiones = RevisionMaterials.GetChildList(criteria.SessionCode, reader);

                        Material_Plan.DoLOCK(Session());

                        query = Material_Plans.SELECT(GetInfo(false));
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _planes = Material_Plans.GetChildList(reader);

                        Material_Alumno.DoLOCK(Session());

                        query = Material_Alumnos.SELECT_BY_MATERIAL(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _alumnos = Material_Alumnos.GetChildList(reader);
                    }
                }
                else
                {
                    _base.Record.CopyValues((MaterialDocenteRecord)(criteria.UniqueResult()));

                    //Session().Lock(Session().Get<MaterialDocenteRecord>(Oid), LockMode.UpgradeNoWait);

                    if (Childs)
                    {
                        criteria = RevisionMaterial.GetCriteria(Session());
                        criteria.AddEq("OidMaterial", this.Oid);
                        _revisiones = RevisionMaterials.GetChildList(criteria.List<RevisionMaterial>());

                        criteria = Material_Plan.GetCriteria(Session());
                        criteria.AddEq("OidMaterial", this.Oid);
                        _planes = Material_Plans.GetChildList(criteria.List<Material_Plan>());

                        criteria = Material_Alumno.GetCriteria(Session());
                        criteria.AddEq("OidMaterial", this.Oid);
                        _alumnos = Material_Alumnos.GetChildList(criteria.List<Material_Alumno>());
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
                    MaterialDocenteRecord obj = Session().Get<MaterialDocenteRecord>(Oid);
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
                MaterialDocenteRecord obj = (MaterialDocenteRecord)(criteria.UniqueResult());
                Session().Delete(Session().Get<MaterialDocenteRecord>(obj.Oid));

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

            query = "SELECT MD.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string material_docente = nHManager.Instance.GetSQLTable(typeof(MaterialDocenteRecord));

            query = "   FROM   " + material_docente + "   AS MD";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.Curso != null && conditions.Curso.Oid > 0)
                query += " AND MD.\"OID_CURSO\" = " + conditions.Curso.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions);

            if (lockTable) query += " FOR UPDATE OF MD NOWAIT";

            return query;
        }


        #endregion
		 
	}
}

