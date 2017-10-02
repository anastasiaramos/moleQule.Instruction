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
    public class AlumnoParteRecord : RecordBase
    {
        #region Attributes

        private long _oid_alumno;
        private long _oid_parte;
        private bool _falta = false;
        private bool _retraso = false;
        private string _observaciones = string.Empty;
        private bool _recuperada = false;
        private DateTime _fecha_recuperacion;

        #endregion

        #region Properties

        public virtual long OidAlumno { get { return _oid_alumno; } set { _oid_alumno = value; } }
        public virtual long OidParte { get { return _oid_parte; } set { _oid_parte = value; } }
        public virtual bool Falta { get { return _falta; } set { _falta = value; } }
        public virtual bool Retraso { get { return _retraso; } set { _retraso = value; } }
        public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
        public virtual bool Recuperada { get { return _recuperada; } set { _recuperada = value; } }
        public virtual DateTime FechaRecuperacion { get { return _fecha_recuperacion; } set { _fecha_recuperacion = value; } }

        #endregion

        #region Business Methods

        public AlumnoParteRecord() { }

        public virtual void CopyValues(IDataReader source)
        {
            if (source == null) return;

            Oid = Format.DataReader.GetInt64(source, "OID");
            _oid_alumno = Format.DataReader.GetInt64(source, "OID_ALUMNO");
            _oid_parte = Format.DataReader.GetInt64(source, "OID_PARTE");
            _falta = Format.DataReader.GetBool(source, "FALTA");
            _retraso = Format.DataReader.GetBool(source, "RETRASO");
            _observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");
            _recuperada = Format.DataReader.GetBool(source, "RECUPERADA");
            _fecha_recuperacion = Format.DataReader.GetDateTime(source, "FECHA_RECUPERACION");

        }
        public virtual void CopyValues(AlumnoParteRecord source)
        {
            if (source == null) return;

            Oid = source.Oid;
            _oid_alumno = source.OidAlumno;
            _oid_parte = source.OidParte;
            _falta = source.Falta;
            _retraso = source.Retraso;
            _observaciones = source.Observaciones;
            _recuperada = source.Recuperada;
            _fecha_recuperacion = source.FechaRecuperacion;
        }

        #endregion
    }

    [Serializable()]
    public class AlumnoParteBase
    {
        #region Attributes

        private AlumnoParteRecord _record = new AlumnoParteRecord();

        #endregion

        #region Properties

        public AlumnoParteRecord Record { get { return _record; } }

        #endregion

        #region Business Methods

        internal void CopyValues(IDataReader source)
        {
            if (source == null) return;

            _record.CopyValues(source);
        }
        public void CopyValues(Alumno_Parte source)
        {
            if (source == null) return;

            _record.CopyValues(source.Base.Record);
        }
        public void CopyValues(Alumno_ParteInfo source)
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
    public class Alumno_Parte : BusinessBaseEx<Alumno_Parte>
    {
        #region Attributes

        protected AlumnoParteBase _base = new AlumnoParteBase();


        #endregion

        #region Properties

        public AlumnoParteBase Base { get { return _base; } }

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
        public virtual bool Falta
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.Falta;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (!_base.Record.Falta.Equals(value))
                {
                    _base.Record.Falta = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool Retraso
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.Retraso;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (!_base.Record.Retraso.Equals(value))
                {
                    _base.Record.Retraso = value;
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



        #endregion

        #region Business Methods

        public virtual Alumno_Parte CloneAsNew()
        {
            Alumno_Parte clon = base.Clone();

            //Se definen el Oid y el Coidgo como nueva entidad
            Random rd = new Random();
            clon.Oid = rd.Next();

            clon.SessionCode = Alumno_Parte.OpenSession();
            Alumno_Parte.BeginTransaction(clon.SessionCode);

            clon.MarkNew();

            return clon;
        }

        protected virtual void CopyFrom(Alumno_ParteInfo source)
        {
            if (source == null) return;

            Oid = source.Oid;
            OidAlumno = source.OidAlumno;
            OidParte = source.OidParte;
            Falta = source.Falta;
            Retraso = source.Retraso;
            Observaciones = source.Observaciones;
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
                                        new CommonRules.MinValueRuleArgs<long>("OidParte", 1));
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
			public Alumno_Parte() 
			{ 
				MarkAsChild();
				Random r = new Random();
                Oid = (long)r.Next();
			}	

			private Alumno_Parte(Alumno_Parte source)
			{
				MarkAsChild();
				Fetch(source);
			}

			private Alumno_Parte(IDataReader reader)
			{
				MarkAsChild();
				Fetch(reader);
			}

			public static Alumno_Parte NewChild(Alumno parent)
			{
				if (!CanAddObject())
					throw new System.Security.SecurityException(
						moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

				Alumno_Parte obj = new Alumno_Parte();
				obj.OidAlumno = parent.Oid;
				return obj;
			}

            public static Alumno_Parte NewChild(ParteAsistencia parent)
            {
                if (!CanAddObject())
                    throw new System.Security.SecurityException(
                        moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

                Alumno_Parte obj = new Alumno_Parte();
                obj.OidParte = parent.Oid;
                return obj;
            }

			internal static Alumno_Parte GetChild(Alumno_Parte source)
			{
				return new Alumno_Parte(source);
			}

			internal static Alumno_Parte GetChild(IDataReader reader)
			{
				return new Alumno_Parte(reader);
			}

			public virtual Alumno_ParteInfo GetInfo()
			{
				if (!CanGetObject())
					throw new System.Security.SecurityException(
					  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

				return new Alumno_ParteInfo(this);

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
			public override Alumno_Parte Save()
			{
				throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
			}

			
		 #endregion
		 
		 #region Child Data Access
		 
		 	private void Fetch(Alumno_Parte source)
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

					AlumnoParteRecord obj = parent.Session().Get<AlumnoParteRecord>(Oid);
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
					parent.Session().Delete(parent.Session().Get<AlumnoParteRecord>(Oid));
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

                    AlumnoParteRecord obj = parent.Session().Get<AlumnoParteRecord>(Oid);
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
                    parent.Session().Delete(parent.Session().Get<AlumnoParteRecord>(Oid));
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

                query = "SELECT AP.*";

                return query;
            }

            internal static string JOIN()
            {
                string query;

                string alumno_parte = nHManager.Instance.GetSQLTable(typeof(AlumnoParteRecord));

                query = "   FROM   " + alumno_parte + "   AS AP";

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

                if (lockTable) query += " FOR UPDATE OF AP NOWAIT";

                return query;
            }

            internal static string SELECT_ORDER_BY_CLASE(QueryConditions conditions, bool lockTable)
            {
                string query = string.Empty;
                string parte = nHManager.Instance.GetSQLTable(typeof(ParteAsistenciaRecord));

                query = SELECT_FIELDS() +
                        JOIN() +
                        " INNER JOIN " + parte + " AS P ON P.\"OID\" = AP.\"OID_PARTE\"" +
                        WHERE(conditions) +
                        " ORDER BY P.\"TEXTO\", P.\"FECHA\", P.\"HORA\"";

                if (lockTable) query += " FOR UPDATE OF AP NOWAIT";

                return query;
            }

        #endregion

    }
}

