using System;
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
    public class AlumnoCursoRecord : RecordBase
    {
        #region Attributes

        private string _empresa = string.Empty;
        private string _nombre = string.Empty;
        private long _oid_convocatoria;
        private string _apellidos = string.Empty;
        private string _ident = string.Empty;

        #endregion

        #region Properties

        public virtual string Empresa { get { return _empresa; } set { _empresa = value; } }
        public virtual string Nombre { get { return _nombre; } set { _nombre = value; } }
        public virtual long OidConvocatoria { get { return _oid_convocatoria; } set { _oid_convocatoria = value; } }
        public virtual string Apellidos { get { return _apellidos; } set { _apellidos = value; } }
        public virtual string Ident { get { return _ident; } set { _ident = value; } }

        #endregion

        #region Business Methods

        public AlumnoCursoRecord() { }

        public virtual void CopyValues(IDataReader source)
        {
            if (source == null) return;

            Oid = Format.DataReader.GetInt64(source, "OID");
            _empresa = Format.DataReader.GetString(source, "EMPRESA");
            _nombre = Format.DataReader.GetString(source, "NOMBRE");
            _oid_convocatoria = Format.DataReader.GetInt64(source, "OID_CONVOCATORIA");
            _apellidos = Format.DataReader.GetString(source, "APELLIDOS");
            _ident = Format.DataReader.GetString(source, "IDENT");

        }
        public virtual void CopyValues(AlumnoCursoRecord source)
        {
            if (source == null) return;

            Oid = source.Oid;
            _empresa = source.Empresa;
            _nombre = source.Nombre;
            _oid_convocatoria = source.OidConvocatoria;
            _apellidos = source.Apellidos;
            _ident = source.Ident;
        }

        #endregion
    }

    [Serializable()]
    public class AlumnoCursoBase
    {
        #region Attributes

        private AlumnoCursoRecord _record = new AlumnoCursoRecord();

        #endregion

        #region Properties

        public AlumnoCursoRecord Record { get { return _record; } }

        #endregion

        #region Business Methods

        internal void CopyValues(IDataReader source)
        {
            if (source == null) return;

            _record.CopyValues(source);
        }
        public void CopyValues(AlumnoCurso source)
        {
            if (source == null) return;

            _record.CopyValues(source.Base.Record);
        }
        public void CopyValues(AlumnoCursoInfo source)
        {
            if (source == null) return;

            _record.CopyValues(source.Base.Record);
        }

        #endregion
    }

	/// <summary>
	/// Editable Child Business Object
	/// </summary>
    [Serializable()]
	public class AlumnoCurso : BusinessBaseEx<AlumnoCurso>
    {
        #region Attributes

        protected AlumnoCursoBase _base = new AlumnoCursoBase();


        #endregion

        #region Properties

        public AlumnoCursoBase Base { get { return _base; } }

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
        public virtual string Empresa
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.Empresa;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.Empresa.Equals(value))
                {
                    _base.Record.Empresa = value;
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
        public virtual long OidConvocatoria
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.OidConvocatoria;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (!_base.Record.OidConvocatoria.Equals(value))
                {
                    _base.Record.OidConvocatoria = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Apellidos
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.Apellidos;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.Apellidos.Equals(value))
                {
                    _base.Record.Apellidos = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Ident
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.Ident;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.Ident.Equals(value))
                {
                    _base.Record.Ident = value;
                    PropertyHasChanged();
                }
            }
        }



        #endregion

        #region Business Methods

        public virtual AlumnoCurso CloneAsNew()
        {
            AlumnoCurso clon = base.Clone();

            //Se definen el Oid y el Coidgo como nueva entidad
            Random rd = new Random();
            clon.Oid = rd.Next();

            clon.SessionCode = AlumnoCurso.OpenSession();
            AlumnoCurso.BeginTransaction(clon.SessionCode);

            clon.MarkNew();

            return clon;
        }

        protected virtual void CopyFrom(AlumnoCursoInfo source)
        {
            if (source == null) return;

            Oid = source.Oid;
            Empresa = source.Empresa;
            Nombre = source.Nombre;
            OidConvocatoria = source.OidConvocatoria;
            Apellidos = source.Apellidos;
            Ident = source.Ident;
        }


        #endregion
		 
	     #region Validation Rules

            protected override void AddBusinessRules()
            {
                ValidationRules.AddRule(CommonRules.MinValue<long>,
                                        new CommonRules.MinValueRuleArgs<long>("OidConvocatoria", 1));

                ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Nombre");

                ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Comercial");

                ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Empresa");
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
			public AlumnoCurso() 
			{ 
				MarkAsChild();
				Random r = new Random();
                Oid = (long)r.Next();
			}	

			private AlumnoCurso(AlumnoCurso source)
			{
				MarkAsChild();
				Fetch(source);
			}

			private AlumnoCurso(IDataReader reader)
			{
				MarkAsChild();
				Fetch(reader);
			}

            public static AlumnoCurso NewChild(Convocatoria_Curso parent)
			{
				if (!CanAddObject())
					throw new System.Security.SecurityException(
						moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

				AlumnoCurso obj = new AlumnoCurso();
				obj.OidConvocatoria = parent.Oid;
				return obj;
			}

			internal static AlumnoCurso GetChild(AlumnoCurso source)
			{
				return new AlumnoCurso(source);
			}

			internal static AlumnoCurso GetChild(IDataReader reader)
			{
				return new AlumnoCurso(reader);
			}

			public virtual AlumnoCursoInfo GetInfo()
			{
				if (!CanGetObject())
					throw new System.Security.SecurityException(
					  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

				return new AlumnoCursoInfo(this);

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
			public override AlumnoCurso Save()
			{
				throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
			}

			
		 #endregion
		 
		 #region Child Data Access
		 
		 	private void Fetch(AlumnoCurso source)
			{
                _base.CopyValues(source);
				MarkOld();
			}

			private void Fetch(IDataReader reader)
			{
                _base.CopyValues(reader);
				MarkOld();
			}

			internal void Insert(Convocatoria_Curso parent)
			{
				// if we're not dirty then don't update the database
				if (!this.IsDirty) return;

				OidConvocatoria = parent.Oid;

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

			internal void Update(Convocatoria_Curso parent)
			{
				// if we're not dirty then don't update the database
				if (!this.IsDirty) return;

				OidConvocatoria = parent.Oid;

				try
				{
					ValidationRules.CheckRules();

					if (!IsValid)
						throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

					AlumnoCursoRecord obj = parent.Session().Get<AlumnoCursoRecord>(Oid);
					obj.CopyValues(this.Base.Record);
					parent.Session().Update(obj);
				}
				catch (Exception ex)
				{
					iQExceptionHandler.TreatException(ex);
				}

				MarkOld();
			}

			internal void DeleteSelf(Convocatoria_Curso parent)
			{
				// if we're not dirty then don't update the database
				if (!this.IsDirty) return;

				// if we're new then don't update the database
				if (this.IsNew) return;

				try
				{
					parent.Session().Delete(parent.Session().Get<AlumnoCursoRecord>(Oid));
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

                query = "SELECT AC.*";

                return query;
            }

            internal static string JOIN()
            {
                string query;

                string alumno_curso = nHManager.Instance.GetSQLTable(typeof(AlumnoCursoRecord));

                query = "   FROM   " + alumno_curso + "   AS AC";

                return query;
            }

            internal static string WHERE(QueryConditions conditions)
            {
                string query;

                query = "   WHERE TRUE";

                if (conditions.Convocatoria_Curso != null && conditions.Convocatoria_Curso.Oid > 0)
                    query += " AND AC.\"OID_CONVOCATORIA\" = " + conditions.Convocatoria_Curso.Oid;

                return query;
            }

            internal static string SELECT(QueryConditions conditions, bool lockTable)
            {
                string query = string.Empty;

                query = SELECT_FIELDS() +
                        JOIN() +
                        WHERE(conditions);

                if (lockTable) query += " FOR UPDATE OF AC NOWAIT";

                return query;
            }


            #endregion
	
	}
}

