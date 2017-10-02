using System;
using System.ComponentModel;
using System.Data;

using Csla;
using Csla.Validation;  
using NHibernate;

using moleQule.Library;
using moleQule.Library.CslaEx;
using moleQule.Library.Invoice;

namespace moleQule.Library.Instruction
{
    [Serializable()]
    public class AlumnoConvocatoriaRecord : RecordBase
    {
        #region Attributes

        private long _oid_convocatoria;
        private long _oid_alumno;
        private long _oid_cliente;
        private DateTime _fecha;

        #endregion

        #region Properties

        public virtual long OidConvocatoria { get { return _oid_convocatoria; } set { _oid_convocatoria = value; } }
        public virtual long OidAlumno { get { return _oid_alumno; } set { _oid_alumno = value; } }
        public virtual long OidCliente { get { return _oid_cliente; } set { _oid_cliente = value; } }
        public virtual DateTime Fecha { get { return _fecha; } set { _fecha = value; } }

        #endregion

        #region Business Methods

        public AlumnoConvocatoriaRecord() { }

        public virtual void CopyValues(IDataReader source)
        {
            if (source == null) return;

            Oid = Format.DataReader.GetInt64(source, "OID");
            _oid_convocatoria = Format.DataReader.GetInt64(source, "OID_CONVOCATORIA");
            _oid_alumno = Format.DataReader.GetInt64(source, "OID_ALUMNO");
            _oid_cliente = Format.DataReader.GetInt64(source, "OID_CLIENTE");
            _fecha = Format.DataReader.GetDateTime(source, "FECHA");

        }
        public virtual void CopyValues(AlumnoConvocatoriaRecord source)
        {
            if (source == null) return;

            Oid = source.Oid;
            _oid_convocatoria = source.OidConvocatoria;
            _oid_alumno = source.OidAlumno;
            _oid_cliente = source.OidCliente;
            _fecha = source.Fecha;
        }

        #endregion
    }

    [Serializable()]
    public class AlumnoConvocatoriaBase
    {
        #region Attributes

        private AlumnoConvocatoriaRecord _record = new AlumnoConvocatoriaRecord();

        //unlinked properties
        private string _nombre = string.Empty;
        private string _cliente = string.Empty;

        #endregion

        #region Properties

        public AlumnoConvocatoriaRecord Record { get { return _record; } }

        //unlinked 
        public virtual string Nombre { get { return _nombre; } set { _nombre = value; } }
        public virtual string Cliente { get { return _cliente; } set { _cliente = value; } }

        #endregion

        #region Business Methods

        internal void CopyValues(IDataReader source)
        {
            if (source == null) return;

            _record.CopyValues(source); 

            _nombre = Format.DataReader.GetString(source, "NOMBRE");
            _cliente = Format.DataReader.GetString(source, "CLIENTE");
        }
        public void CopyValues(Alumno_Convocatoria source)
        {
            if (source == null) return;

            _record.CopyValues(source.Base.Record);

            _nombre = source.Nombre;
            _cliente = source.Cliente;
        }
        public void CopyValues(Alumno_ConvocatoriaInfo source)
        {
            if (source == null) return;

            _record.CopyValues(source.Base.Record);

            _nombre = source.Nombre;
            _cliente = source.Cliente;
        }

        #endregion
    }
		
	/// <summary>
	/// Editable Child Business Object
	/// </summary>
    [Serializable()]
	public class Alumno_Convocatoria : BusinessBaseEx<Alumno_Convocatoria>
	{

        #region Attributes
		
		protected AlumnoConvocatoriaBase _base = new AlumnoConvocatoriaBase();
        
        #endregion

        #region Properties
		
		public AlumnoConvocatoriaBase Base { get { return _base; } }
		
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
		public virtual long OidCliente
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidCliente;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.OidCliente.Equals(value))
				{
					_base.Record.OidCliente = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual DateTime Fecha
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Fecha;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.Fecha.Equals(value))
				{
					_base.Record.Fecha = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual string Nombre { get { return _base.Nombre; } set { _base.Nombre = value; } }
        public virtual string Cliente { get { return _base.Nombre; } set { _base.Cliente = value; } }

        #endregion

        #region Business Methods


        #endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidConvocatoria", 1));

            ValidationRules.AddRule(
                Csla.Validation.CommonRules.StringRequired, "Nombre");


            ValidationRules.AddRule(
                Csla.Validation.CommonRules.StringRequired, "Cliente");
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
        public Alumno_Convocatoria()
        {
            MarkAsChild();
            Random r = new Random();
            Oid = (long)r.Next();
            Fecha = DateTime.Today;
        }

        private Alumno_Convocatoria(Alumno_Convocatoria source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private Alumno_Convocatoria(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static Alumno_Convocatoria NewChild(Convocatoria_Curso parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Alumno_Convocatoria obj = new Alumno_Convocatoria();
            obj.OidConvocatoria = parent.Oid;
            return obj;
        }

        public static Alumno_Convocatoria NewChild(Convocatoria_Curso parent, AlumnoInfo alumno, ClienteInfo cliente)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Alumno_Convocatoria obj = new Alumno_Convocatoria();
            obj.OidConvocatoria = parent.Oid;
            obj.OidAlumno = alumno.Oid;
            obj.Nombre = alumno.Nombre + " " + alumno.Apellidos;
            obj.Cliente = cliente.Nombre;
            obj.OidCliente = cliente.Oid;

            return obj;
        }

        public static Alumno_Convocatoria NewChild(Convocatoria_Curso parent, AlumnoClienteInfo source)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Alumno_Convocatoria obj = new Alumno_Convocatoria();
            obj.OidConvocatoria = parent.Oid;
            obj.OidAlumno = source.OidAlumno;
            obj.Nombre = source.Alumno;
            obj.Cliente = source.Cliente;
            obj.OidCliente = source.OidCliente;

            return obj;
        }

        internal static Alumno_Convocatoria GetChild(Alumno_Convocatoria source)
        {
            return new Alumno_Convocatoria(source);
        }

        internal static Alumno_Convocatoria GetChild(IDataReader reader)
        {
            return new Alumno_Convocatoria(reader);
        }

        public virtual Alumno_ConvocatoriaInfo GetInfo()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new Alumno_ConvocatoriaInfo(this);
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
        public override Alumno_Convocatoria Save()
        {
            throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
        }


        #endregion

        #region Child Data Access

        private void Fetch(Alumno_Convocatoria source)
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

                AlumnoConvocatoriaRecord obj = parent.Session().Get<AlumnoConvocatoriaRecord>(Oid);
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
                parent.Session().Delete(parent.Session().Get<Alumno_Convocatoria>(Oid));
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

            query = "SELECT AC.*," +
                    "           AL.\"NOMBRE\" ||' '|| AL.\"APELLIDOS\" AS \"NOMBRE\"," +
                    "           CL.\"NOMBRE\" AS \"CLIENTE\"";

            return query;
        }

        internal static string JOIN()
        {
            string query;
            
            string alumno_convocatoria= nHManager.Instance.GetSQLTable(typeof(AlumnoConvocatoriaRecord));                    
            string cliente = nHManager.Instance.GetSQLTable(typeof(ClientRecord));
            string alumno = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));

            query = "   FROM   " + alumno_convocatoria + "   AS AC" +
                    "   INNER JOIN   " + cliente + "   AS CL ON (AC.\"OID_CLIENTE\" =  CL.\"OID\")" +
                    "   INNER JOIN   " + alumno + "   AS AL ON (AC.\"OID_ALUMNO\" = AL.\"OID\")"; 

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            string alumno_convocatoria = nHManager.Instance.GetSQLTable(typeof(AlumnoConvocatoriaRecord));
            string cliente = nHManager.Instance.GetSQLTable(typeof(ClientRecord));
            string alumno = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));

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

