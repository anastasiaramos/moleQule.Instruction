using System;
using System.ComponentModel;
using System.Data;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;
using moleQule.Library.Instruction;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class AlumnoPracticaRecord : RecordBase
	{
		#region Attributes

		private long _oid_alumno;
		private long _oid_clase_practica;
		private string _calificacion = string.Empty;
		private string _observaciones = string.Empty;
		private long _oid_parte;
		private bool _recuperada = false;
		private DateTime _fecha_recuperacion;
  
		#endregion
		
		#region Properties
		
				public virtual long OidAlumno { get { return _oid_alumno; } set { _oid_alumno = value; } }
		public virtual long OidClasePractica { get { return _oid_clase_practica; } set { _oid_clase_practica = value; } }
		public virtual string Calificacion { get { return _calificacion; } set { _calificacion = value; } }
		public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
		public virtual long OidParte { get { return _oid_parte; } set { _oid_parte = value; } }
		public virtual bool Recuperada { get { return _recuperada; } set { _recuperada = value; } }
		public virtual DateTime FechaRecuperacion { get { return _fecha_recuperacion; } set { _fecha_recuperacion = value; } }

		#endregion
		
		#region Business Methods
		
		public AlumnoPracticaRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_alumno = Format.DataReader.GetInt64(source, "OID_ALUMNO");
			_oid_clase_practica = Format.DataReader.GetInt64(source, "OID_CLASE_PRACTICA");
			_calificacion = Format.DataReader.GetString(source, "CALIFICACION");
			_observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");
			_oid_parte = Format.DataReader.GetInt64(source, "OID_PARTE");
			_recuperada = Format.DataReader.GetBool(source, "RECUPERADA");
			_fecha_recuperacion = Format.DataReader.GetDateTime(source, "FECHA_RECUPERACION");

		}		
		public virtual void CopyValues(AlumnoPracticaRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_alumno = source.OidAlumno;
			_oid_clase_practica = source.OidClasePractica;
			_calificacion = source.Calificacion;
			_observaciones = source.Observaciones;
			_oid_parte = source.OidParte;
			_recuperada = source.Recuperada;
			_fecha_recuperacion = source.FechaRecuperacion;
		}
		
		#endregion	
	}

    [Serializable()]
	public class Alumno_PracticaBase 
	{	 
		#region Attributes
		
		private AlumnoPracticaRecord _record = new AlumnoPracticaRecord();

        private bool _falta = false;
        private string _alias = string.Empty;
		
		#endregion
		
		#region Properties
		
		public AlumnoPracticaRecord Record { get { return _record; } }

        public virtual bool Falta { get { return _falta; } set { _falta = value; } }
        public virtual string Alias { get { return _alias; } set { _alias = value; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);

            _falta = Format.DataReader.GetBool(source, "FALTA");
            _alias = Format.DataReader.GetString(source, "ALIAS");
		}		
		public void CopyValues(Alumno_Practica source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _falta = source.Falta;
            _alias = source.Alias;
		}
		public void CopyValues(Alumno_PracticaInfo source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _falta = source.Falta;
            _alias = source.Alias;
		}
		
		#endregion	
	}
		
	/// <summary>
	/// Editable Root Business Object
	/// </summary>	
    [Serializable()]
	public class Alumno_Practica : BusinessBaseEx<Alumno_Practica>
	{	 
		#region Attributes
		
		protected Alumno_PracticaBase _base = new Alumno_PracticaBase();
		

		#endregion
		
		#region Properties
		
		public Alumno_PracticaBase Base { get { return _base; } }
		
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
		public virtual long OidAlumno
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidAlumno;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.OidAlumno.Equals(value))
				{
					_base.Record.OidAlumno = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidClasePractica
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidClasePractica;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.OidClasePractica.Equals(value))
				{
					_base.Record.OidClasePractica = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Calificacion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Calificacion;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Calificacion.Equals(value))
				{
					_base.Record.Calificacion = value;
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
		public virtual long OidParte
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidParte;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.OidParte.Equals(value))
				{
					_base.Record.OidParte = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool Recuperada
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Recuperada;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.Recuperada.Equals(value))
				{
					_base.Record.Recuperada = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual DateTime FechaRecuperacion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.FechaRecuperacion;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.FechaRecuperacion.Equals(value))
				{
					_base.Record.FechaRecuperacion = value;
					PropertyHasChanged();
				}
			}
		}
	
        public virtual bool Falta { get { return _base.Falta; } set { _base.Falta = value; } }
        public virtual string Alias { get { return _base.Alias; } set { _base.Alias = value; } }
				
		#endregion
		
		#region Business Methods
		
		public virtual Alumno_Practica CloneAsNew()
		{
			Alumno_Practica clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = Alumno_Practica.OpenSession();
			Alumno_Practica.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(Alumno_PracticaInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidAlumno = source.OidAlumno;
			OidClasePractica = source.OidClasePractica;
			Calificacion = source.Calificacion;
			Observaciones = source.Observaciones;
			OidParte = source.OidParte;
			Recuperada = source.Recuperada;
			FechaRecuperacion = source.FechaRecuperacion;
		}
		
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidAlumno", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                   new CommonRules.MinValueRuleArgs<long>("OidClasePractica", 1));

            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Calificacion");
        }


        #endregion

        #region Autorization Rules

        public static bool CanAddObject()
        {
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.ALUMNO);

        }

        public static bool CanGetObject()
        {
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.ALUMNO);

        }

        public static bool CanDeleteObject()
        {
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.ALUMNO);

        }
        public static bool CanEditObject()
        {
            return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.ALUMNO);

        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los Factory Methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        public Alumno_Practica()
        {
            MarkAsChild();
            Random r = new Random();
            Oid = (long)r.Next();
        }

        private Alumno_Practica(Alumno_Practica source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private Alumno_Practica(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static Alumno_Practica NewItem()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Alumno_Practica obj = new Alumno_Practica();
            return obj;
        }

        public static Alumno_Practica NewChild(Alumno parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Alumno_Practica obj = new Alumno_Practica();
            obj.OidAlumno = parent.Oid;
            return obj;
        }

        public static Alumno_Practica NewChild(ClasePractica parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Alumno_Practica obj = new Alumno_Practica();
            obj.OidClasePractica = parent.Oid;
            return obj;
        }

        public static Alumno_Practica NewChild(ParteAsistencia parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Alumno_Practica obj = new Alumno_Practica();
            obj.OidParte = parent.Oid;
            return obj;
        }

        internal static Alumno_Practica GetChild(Alumno_Practica source)
        {
            return new Alumno_Practica(source);
        }

        internal static Alumno_Practica GetChild(IDataReader reader)
        {
            return new Alumno_Practica(reader);
        }

        public virtual Alumno_PracticaInfo GetInfo()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new Alumno_PracticaInfo(this);

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

        /// <summary>
        /// No se debe utilizar esta función para guardar. Hace falta el padre.
        /// Utilizar Insert o Update en sustitución de Save.
        /// </summary>
        /// <returns></returns>
        public override Alumno_Practica Save()
        {
            throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
        }


        #endregion

        #region Child Data Access

        private void Fetch(Alumno_Practica source)
        {
            _base.CopyValues(source);
            MarkOld();
        }

        private void Fetch(IDataReader reader)
        {
            _base.CopyValues(reader);
            MarkOld();
        }

        internal void Insert(Alumno parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidAlumno = parent.Oid;

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

        internal void Update(Alumno parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidAlumno = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                AlumnoPracticaRecord obj = parent.Session().Get<AlumnoPracticaRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(Alumno parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                parent.Session().Delete(parent.Session().Get<AlumnoPracticaRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }


        internal void Insert(ClasePractica parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidClasePractica = parent.Oid;

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

        internal void Update(ClasePractica parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidClasePractica = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                AlumnoPracticaRecord obj = parent.Session().Get<AlumnoPracticaRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(ClasePractica parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                parent.Session().Delete(parent.Session().Get<AlumnoPracticaRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }


        internal void Insert(ParteAsistencia parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidParte = parent.Oid;

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

        internal void Update(ParteAsistencia parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidParte = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                AlumnoPracticaRecord obj = parent.Session().Get<AlumnoPracticaRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(ParteAsistencia parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                parent.Session().Delete(parent.Session().Get<AlumnoPracticaRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }

        #endregion

        #region SQL

        internal static string SELECT_FIELDS()
        {
            string query;

            query = "SELECT AP.*" +
                " ,AP2.\"FALTA\" AS \"FALTA\"" +
                " ,CP.\"ALIAS\" AS \"ALIAS\"";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string alumno_practica = nHManager.Instance.GetSQLTable(typeof(AlumnoPracticaRecord));
            string alumno_parte = nHManager.Instance.GetSQLTable(typeof(AlumnoParteRecord));
            string clase_practica = nHManager.Instance.GetSQLTable(typeof(ClasePracticaRecord));
            string alumno = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));

            query = " FROM " + alumno_practica + " AS AP" + 
                " INNER JOIN " + alumno + " AS AL ON AL.\"OID\" = AP.\"OID_ALUMNO\"" +
                " INNER JOIN " + alumno_parte + " AP2 ON AP2.\"OID_ALUMNO\" = AP.\"OID_ALUMNO\" AND AP2.\"OID_PARTE\" = AP.\"OID_PARTE\"" +
                " INNER JOIN " + clase_practica + " AS CP ON CP.\"OID\" = AP.\"OID_CLASE_PRACTICA\"";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.Alumno != null && conditions.Alumno.Oid > 0)
                query += " AND AP.\"OID_ALUMNO\" = " + conditions.Alumno.Oid;
            if (conditions.ParteAsistencia != null && conditions.ParteAsistencia.Oid > 0)
                query += " AND AP.\"OID_PARTE\" = " + conditions.ParteAsistencia.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {

            string query = string.Empty;

            query = SELECT_FIELDS() +
                JOIN() +
                WHERE(conditions);

            query += " ORDER BY AL.\"APELLIDOS\", AL.\"NOMBRE\"";

            if (lockTable) query += " FOR UPDATE OF AP NOWAIT";

            return query;
        }

        internal static string SELECT_ORDER_BY_CLASE(QueryConditions conditions, bool lockTable)
        {

            string query = string.Empty;

            query = SELECT_FIELDS() +
                JOIN() +
                WHERE(conditions);

            query += " ORDER BY CP.\"ALIAS\"";

            if (lockTable) query += " FOR UPDATE OF AP NOWAIT";

            return query;
        }


        #endregion

    }
}

