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
	public class CursoRecord : RecordBase
	{
		#region Attributes

		private string _codigo = string.Empty;
		private long _serial;
		private string _nombre = string.Empty;
		private long _n_horas;
		private string _observaciones = string.Empty;
  
		#endregion
		
		#region Properties
		
				public virtual string Codigo { get { return _codigo; } set { _codigo = value; } }
		public virtual long Serial { get { return _serial; } set { _serial = value; } }
		public virtual string Nombre { get { return _nombre; } set { _nombre = value; } }
		public virtual long NHoras { get { return _n_horas; } set { _n_horas = value; } }
		public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }

		#endregion
		
		#region Business Methods
		
		public CursoRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_codigo = Format.DataReader.GetString(source, "CODIGO");
			_serial = Format.DataReader.GetInt64(source, "SERIAL");
			_nombre = Format.DataReader.GetString(source, "NOMBRE");
			_n_horas = Format.DataReader.GetInt64(source, "N_HORAS");
			_observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");

		}		
		public virtual void CopyValues(CursoRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_codigo = source.Codigo;
			_serial = source.Serial;
			_nombre = source.Nombre;
			_n_horas = source.NHoras;
			_observaciones = source.Observaciones;
		}
		
		#endregion	
	}

    [Serializable()]
	public class CursoBase 
	{	 
		#region Attributes
		
		private CursoRecord _record = new CursoRecord();
		
		#endregion
		
		#region Properties
		
		public CursoRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(Curso source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(CursoInfo source)
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
	public class Curso : BusinessBaseEx<Curso>
	{	 
		#region Attributes
		
		protected CursoBase _base = new CursoBase();

        private Curso_Instructors _c_profesores = Curso_Instructors.NewChildList();
        private Convocatoria_Cursos _convocatorias = Convocatoria_Cursos.NewChildList();
        private MaterialDocentes _materiales = MaterialDocentes.NewChildList();
		

		#endregion
		
		#region Properties
		
		public CursoBase Base { get { return _base; } }
		
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
		public virtual long NHoras
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.NHoras;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.NHoras.Equals(value))
				{
					_base.Record.NHoras = value;
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

        public virtual Curso_Instructors Curso_Instructors
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _c_profesores;
            }

            set
            {
                _c_profesores = value;
            }
        }
        public virtual Convocatoria_Cursos Convocatorias
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _convocatorias;
            }

            set
            {
                _convocatorias = value;
            }
        }
        public virtual MaterialDocentes MaterialDocentes
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _materiales;
            }

            set
            {
                _materiales = value;
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _c_profesores.IsValid && _convocatorias.IsValid && _materiales.IsValid; }
        }
        public override bool IsDirty
        {
            get { return base.IsDirty || _c_profesores.IsDirty || _convocatorias.IsDirty || _materiales.IsDirty; }
        }
	
		
		
		#endregion
		
		#region Business Methods
		

        public virtual Curso CloneAsNew()
        {
            Curso clon = base.Clone();

            // Se definen el Oid y el Codigo como nueva entidad
            Random rd = new Random();
            clon.Oid = rd.Next();

            clon.Codigo = (0).ToString(Resources.Defaults.CURSO_CODE_FORMAT);
            clon.SessionCode = Curso.OpenSession();
            Curso.BeginTransaction(clon.SessionCode);

            clon.MarkNew();
            clon.Curso_Instructors.MarkAsNew();
            clon.Convocatorias.MarkAsNew();
            clon.MaterialDocentes.MarkAsNew();
            return clon;
        }

        public virtual void GetNewCode()
        {
            Serial = SerialAlumnoInfo.GetNext(typeof(Curso));
            Codigo = Serial.ToString(Resources.Defaults.CURSO_CODE_FORMAT);
        }
		
		protected virtual void CopyFrom(CursoInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			Codigo = source.Codigo;
			Serial = source.Serial;
			Nombre = source.Nombre;
			NHoras = source.NHoras;
			Observaciones = source.Observaciones;
		}
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(
                Csla.Validation.CommonRules.StringRequired, "Codigo");

            ValidationRules.AddRule(
                Csla.Validation.CommonRules.StringRequired, "Nombre");
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

        #region Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION New
        /// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
        /// pero es protected por exigencia de NHibernate.
        /// </summary>
        protected Curso() {}

        private Curso(IDataReader reader)
        {
            Fetch(reader);
        }

        public static Curso New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
            
            return DataPortal.Create<Curso>(new CriteriaCs(-1));
        }

        public static Curso Get(long oid)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = Curso.GetCriteria(Curso.OpenSession());
            criteria.Query = Curso.SELECT(oid);
            
            Curso.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Curso>(criteria);
        }

        internal static Curso Get(IDataReader reader)
        {
            return new Curso(reader);
        }

        /// <summary>
        /// Construye y devuelve un objeto de solo lectura copia de si mismo.
        /// </summary>
        /// <param name="get_childs">True si se quiere que traiga los hijos</param>
        /// <returns></returns>
        public virtual CursoInfo GetInfo(bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new CursoInfo(this, get_childs);
        }

        public virtual CursoInfo GetInfo()
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
        /// Elimina todos los Cursos y sus listas
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = Curso.OpenSession();
            ISession sess = Curso.Session(sessCode);
            ITransaction trans = Curso.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from  Curso");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                Curso.CloseSession(sessCode);
            }
        }

        public override Curso Save()
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

                _convocatorias.Update(this);
                _c_profesores.Update(this);
                _materiales.Update(this);

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
            GetNewCode();

            _c_profesores = Curso_Instructors.NewChildList();
            _convocatorias = Convocatoria_Cursos.NewChildList();
            _materiales = MaterialDocentes.NewChildList();
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
                    Curso.DoLOCK(Session());
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query);

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        string query = string.Empty;

                        Curso_Instructor.DoLOCK(Session());

                        query = Curso_Instructors.SELECT_BY_CURSO(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _c_profesores = Curso_Instructors.GetChildList(reader);

                        Convocatoria_Curso.DoLOCK(Session());

                        query = Convocatoria_Cursos.SELECT_BY_CURSO(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _convocatorias = Convocatoria_Cursos.GetChildList(criteria.SessionCode, reader);

                        MaterialDocente.DoLOCK(Session());

                        query = MaterialDocentes.SELECT_BY_CURSO(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _materiales = MaterialDocentes.GetChildList(criteria.SessionCode, reader);
                    }
                }
            }
            catch (Exception exception)
            {
                if (Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(exception);
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
                    CursoRecord obj = Session().Get<CursoRecord>(Oid);

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
                Session().Delete((CursoRecord)(criterio.UniqueResult()));

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
                CriteriaEx criteria = Curso.GetCriteria(Curso.OpenSession());
                criteria.AddCodeSearch(_codigo);
                CursoList list = CursoList.GetList(criteria);
                _exists = !(list.Count == 0);
            }
        }

        #endregion

        #region SQL

        internal static string SELECT_FIELDS()
        {
            string query;

            query = "SELECT C.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string curso = nHManager.Instance.GetSQLTable(typeof(CursoRecord));

            query = "   FROM   " + curso + "   AS C";

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

            if (lockTable) query += " FOR UPDATE OF C NOWAIT";

            return query;
        }


        #endregion
	
	}
}

