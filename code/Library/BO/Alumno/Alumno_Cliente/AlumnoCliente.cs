using System;
using System.Collections;
using System.Collections.Generic;
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
    public class AlumnoClienteRecord : RecordBase
    {
        #region Attributes

        private long _oid_alumno;
        private long _oid_cliente;

        #endregion

        #region Properties

        public virtual long OidAlumno { get { return _oid_alumno; } set { _oid_alumno = value; } }
        public virtual long OidCliente { get { return _oid_cliente; } set { _oid_cliente = value; } }

        #endregion

        #region Business Methods

        public AlumnoClienteRecord() { }

        public virtual void CopyValues(IDataReader source)
        {
            if (source == null) return;

            Oid = Format.DataReader.GetInt64(source, "OID");
            _oid_alumno = Format.DataReader.GetInt64(source, "OID_ALUMNO");
            _oid_cliente = Format.DataReader.GetInt64(source, "OID_CLIENTE");

        }
        public virtual void CopyValues(AlumnoClienteRecord source)
        {
            if (source == null) return;

            Oid = source.Oid;
            _oid_alumno = source.OidAlumno;
            _oid_cliente = source.OidCliente;
        }

        #endregion
    }

    [Serializable()]
    public class AlumnoClienteBase
    {
        #region Attributes

        private AlumnoClienteRecord _record = new AlumnoClienteRecord();

        //Unlinked Properties
        private string _n_alumno = string.Empty;
        private string _alumno = string.Empty;
        private string _cliente = string.Empty;

        #endregion

        #region Properties

        public AlumnoClienteRecord Record { get { return _record; } }

        public virtual string NAlumno
        {
            get
            {
                return _n_alumno;
            }

            set
            {
                if (value == null) value = string.Empty;
                if (!_n_alumno.Equals(value))
                {
                    _n_alumno = value;
                }
            }
        }
        public virtual string Cliente
        {
            get
            {
                return _cliente;
            }

            set
            {
                if (value == null) value = string.Empty;
                if (!_cliente.Equals(value))
                {
                    _cliente = value;
                }
            }
        }
        public virtual string Alumno
        {
            get
            {
                return _alumno;
            }

            set
            {
                if (value == null) value = string.Empty;
                if (!_alumno.Equals(value))
                {
                    _alumno = value;
                }
            }
        }

        #endregion

        #region Business Methods

        internal void CopyValues(IDataReader source)
        {
            if (source == null) return;

            _record.CopyValues(source);

            _n_alumno = Format.DataReader.GetString(source, "N_ALUMNO");
            _alumno = Format.DataReader.GetString(source, "ALUMNO");
            _cliente = Format.DataReader.GetString(source, "CLIENTE");
        }
        public void CopyValues(AlumnoCliente source)
        {
            if (source == null) return;

            _record.CopyValues(source.Base.Record);

            _n_alumno = source.NAlumno;
            _alumno = source.Alumno;
            _cliente = source.Cliente;
        }
        public void CopyValues(AlumnoClienteInfo source)
        {
            if (source == null) return;

            _record.CopyValues(source.Base.Record);

            _n_alumno = source.NAlumno;
            _alumno = source.Alumno;
            _cliente = source.Cliente;
        }

        #endregion
    }
		
	/// <summary>
	/// Editable Child Business Object
	/// </summary>	
    [Serializable()]
	public class AlumnoCliente : BusinessBaseEx<AlumnoCliente>
	{

        #region Attributes 

        protected AlumnoClienteBase _base = new AlumnoClienteBase();
		
        #endregion

        #region Properties 

        public AlumnoClienteBase Base { get { return _base; } }

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
                    //PropertyHasChanged();
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
                    //PropertyHasChanged();
                }
            }
        }

        public string NAlumno { get { return _base.NAlumno; } set { _base.NAlumno = value; } }
        public string Alumno { get { return _base.Alumno; } set { _base.Alumno = value; } }
        public string Cliente { get { return _base.Cliente; } set { _base.Cliente = value; } }
        
		/// <summary>
        /// Indica si el objeto está validado
        /// </summary>
		/// <remarks>Para añadir una lista: && _lista.IsValid<remarks/>
		public override bool IsValid
		{
			get { return base.IsValid ; }
		}
		
        /// <summary>
        /// Indica si el objeto está "sucio" (se ha modificado) y se debe actualizar en la base de datos
        /// </summary>
		/// <remarks>Para añadir una lista: || _lista.IsDirty<remarks/>
		public override bool IsDirty
		{
			get { return base.IsDirty ; }
		}
		
		#endregion
		
		#region Business Methods

		/// <summary>
		/// Clona la entidad y sus subentidades y las marca como nuevas
		/// </summary>
		/// <returns>Una entidad clon</returns>
		public virtual AlumnoCliente CloneAsNew()
		{
			AlumnoCliente clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = AlumnoCliente.OpenSession();
			AlumnoCliente.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		/// <summary>
		/// Copia los atributos del objeto
		/// </summary>
		/// <param name="source">Objeto origen de solo lectura</param>
		protected virtual void CopyFrom (AlumnoClienteInfo source)
		{
			if (source == null) return;
			
			Oid = source.Oid;
			OidAlumno = source.OidAlumno;
			OidCliente = source.OidCliente;

            NAlumno = source.NAlumno;
            Alumno = source.Alumno;
            Cliente = source.Cliente;
		}		
			
		#endregion
		 
	    #region Validation Rules

		/// <summary>
		/// Añade las reglas de validación necesarias para el objeto
		/// </summary>
		protected override void AddBusinessRules()
		{
			
			//Código para valores requeridos o que haya que validar
			
		}
		 
		#endregion
		 
		#region Autorization Rules
		
		public static bool CanAddObject()
		{
            return AutorizationRulesControler.CanAddObject(moleQule.Library.Invoice.Resources.SecureItems.CLIENTE);
		}
		
		public static bool CanGetObject()
		{
            return AutorizationRulesControler.CanGetObject(moleQule.Library.Invoice.Resources.SecureItems.CLIENTE);
		}
		
		public static bool CanDeleteObject()
		{
            return AutorizationRulesControler.CanDeleteObject(moleQule.Library.Invoice.Resources.SecureItems.CLIENTE);
		}
		
		public static bool CanEditObject()
		{
            return AutorizationRulesControler.CanEditObject(moleQule.Library.Invoice.Resources.SecureItems.CLIENTE);
		}

		#endregion
		 
		#region Common Factory Methods
		 
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION New o NewChild
		/// Debería ser private para CSLA porque la creación requiere el uso de los Factory Methods,
		/// pero debe ser protected por exigencia de NHibernate.
		/// Debe ser public para que funcionen los DataGridView
		/// </summary>
		protected AlumnoCliente ()
		{
			// Si se necesita constructor público para este objeto hay que añadir el MarkAsChild() debido a la interfaz Child
			// y el código que está en el DataPortal_Create debería ir aquí
		}		
		
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE. LAS UTILIZAN LAS FUNCIONES DE CREACION DE LISTAS
		/// </summary>
		private AlumnoCliente(AlumnoCliente source, bool retrieve_childs)
        {
			MarkAsChild();
			Childs = retrieve_childs;
            Fetch(source);
        }
		
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE. LAS UTILIZAN LAS FUNCIONES DE CREACION DE LISTAS
		/// </summary>
        private AlumnoCliente(IDataReader source, bool retrieve_childs)
        {
            MarkAsChild();	
			Childs = retrieve_childs;
            Fetch(source);
        }

		/// <summary>
		/// Crea un nuevo objeto
		/// </summary>
		/// <returns>Nuevo objeto creado</returns>
		/// La utiliza la BusinessListBaseEx correspondiente para crear nuevos elementos
		public static AlumnoCliente NewChild() 
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return DataPortal.Create<AlumnoCliente>(new CriteriaCs(-1));
		}
		
		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="source">AlumnoCliente con los datos para el objeto</param>
		/// <returns>Objeto creado</returns>
		/// <remarks>
		/// La utiliza la BusinessListBaseEx correspondiente para montar la lista
		/// NO OBTIENE los hijos. Para ello utilice GetChild(AlumnoCliente source, bool retrieve_childs)
		/// <remarks/>
		internal static AlumnoCliente GetChild(AlumnoCliente source)
		{
			return new AlumnoCliente(source, false);
		}
		
		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="source">AlumnoCliente con los datos para el objeto</param>
		/// <param name="retrieve_childs">Flag para obtener también los hijos</param>
		/// <returns>Objeto creado</returns>
		/// <remarks>La utiliza la BusinessListBaseEx correspondiente para montar la lista<remarks/>
		internal static AlumnoCliente GetChild(AlumnoCliente source, bool retrieve_childs)
		{
			return new AlumnoCliente(source, retrieve_childs);
		}

		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="reader">DataReader con los datos para el objeto</param>
		/// <returns>Objeto creado</returns>
		/// <remarks>
		/// La utiliza la BusinessListBaseEx correspondiente para montar la lista
		/// NO OBTIENE los hijos. Para ello utilice GetChild(IDataReader source, bool retrieve_childs)
		/// <remarks/>
        internal static AlumnoCliente GetChild(IDataReader source)
        {
            return new AlumnoCliente(source, false);
        }
		
		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="source">IDataReader con los datos para el objeto</param>
		/// <param name="retrieve_childs">Flag para obtener también los hijos</param>
		/// <returns>Objeto creado</returns>
		/// <remarks>La utiliza la BusinessListBaseEx correspondiente para montar la lista<remarks/>
        internal static AlumnoCliente GetChild(IDataReader source, bool retrieve_childs)
        {
            return new AlumnoCliente(source, retrieve_childs);
        }
		
		/// <summary>
		/// Construye y devuelve un objeto de solo lectura copia de si mismo.
		/// También copia los datos de los hijos del objeto.
		/// </summary>
		/// <returns>Réplica de solo lectura del objeto</returns>
		public virtual AlumnoClienteInfo GetInfo()
		{
			return GetInfo(true);
		}
		
		/// <summary>
		/// Construye y devuelve un objeto de solo lectura copia de si mismo.
		/// </summary>
		/// <param name="get_childs">Flag para solicitar que se copien los hijos</param>
		/// <returns>Réplica de solo lectura del objeto</returns>
		public virtual AlumnoClienteInfo GetInfo (bool get_childs)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return new AlumnoClienteInfo(this, get_childs);
		}
		
		#endregion
						
		#region Child Factory Methods
		
		
		/// <summary>
		/// Crea un nuevo objeto hijo
		/// </summary>
		/// <param name="parent">Objeto padre</param>
		/// <returns>Nuevo objeto creado</returns>
		internal static AlumnoCliente NewChild(Cliente parent)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

			AlumnoCliente item = new AlumnoCliente();
			item.MarkAsChild();
			item.OidCliente = parent.Oid;
			return item;
		}
		
		
		/// <summary>
        /// Borrado aplazado, es posible el undo 
        /// (La función debe ser "no estática")
        /// </summary>
        public override void Delete()
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException(moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            MarkDeleted();
        }
		
		/// <summary>
		/// No se debe utilizar esta función para guardar. Hace falta el padre, que
		/// debe utilizar Insert o Update en sustitución de Save.
		/// </summary>
		/// <returns></returns>
		public override AlumnoCliente Save()
		{
			throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
		}
		
		#endregion
		
		#region Common Data Access
		
		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="criteria">Criterios de consulta</param>
		/// <remarks>La llama el DataPortal a partir del New o NewChild</remarks>		
		[RunLocal()]
		private void DataPortal_Create(CriteriaCs criteria)
		{
			
			// El código va al constructor porque los DataGrid no llamana al DataPortal sino directamente al constructor
			
		}
		
		/// <summary>
		/// Construye el objeto y se encarga de obtener los
		/// hijos si los tiene y se solicitan
		/// </summary>
		/// <param name="source">Objeto fuente</param>
		private void Fetch(AlumnoCliente source)
		{
            try
            {
                SessionCode = source.SessionCode;

                _base.CopyValues(source);
				
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

			MarkOld();
		}

		/// <summary>
		/// Construye el objeto y se encarga de obtener los
		/// hijos si los tiene y se solicitan
		/// </summary>
		/// <param name="source">DataReader fuente</param>
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

            MarkOld();
        }

		/// <summary>
		/// Inserta el registro en la base de datos
		/// </summary>
		/// <param name="parent">Lista padre</param>
		/// <remarks>La utiliza la BusinessListBaseEx correspondiente para insertar elementos<remarks/>
		internal void Insert(AlumnoClientes parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;
			
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
	
		/// <summary>
		/// Actualiza el registro en la base de datos
		/// </summary>
		/// <param name="parent">Lista padre</param>
		/// <remarks>La utiliza la BusinessListBaseEx correspondiente para actualizar elementos<remarks/>
		internal void Update(AlumnoClientes parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;
			
			try
			{
				ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

				SessionCode = parent.SessionCode;
				AlumnoClienteRecord obj = Session().Get<AlumnoClienteRecord>(Oid);
				obj.CopyValues(this.Base.Record);
				Session().Update(obj);
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
			
			MarkOld();
		}
		
		/// <summary>
		/// Borra el registro de la base de datos
		/// </summary>
		/// <param name="parent">Lista padre</param>
		/// <remarks>La utiliza la BusinessListBaseEx correspondiente para borrar elementos<remarks/>
		internal void DeleteSelf(AlumnoClientes parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

			// if we're new then don't update the database
			if (this.IsNew) return;
			
			try
			{
				SessionCode = parent.SessionCode;
				Session().Delete(Session().Get<AlumnoClienteRecord>(Oid));
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
		
			MarkNew(); 
		}

		#endregion
		
		#region Child Data Access

		
		/// <summary>
		/// Inserta un registro en la base de datos
		/// </summary>
		/// <param name="parent">Objeto padre</param>
		internal void Insert(Cliente parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

			//Debe obtener la sesion del padre pq el objeto es padre a su vez
			SessionCode = parent.SessionCode;

			OidCliente = parent.Oid;	
			

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

		/// <summary>
		/// Actualiza un registro en la base de datos
		/// </summary>
		/// <param name="parent">Objeto padre</param>
		internal void Update(Cliente parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

			//Debe obtener la sesion del padre pq el objeto es padre a su vez
			SessionCode = parent.SessionCode;

			OidCliente = parent.Oid;

			try
			{
				ValidationRules.CheckRules();

				if (!IsValid)
					throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

				AlumnoClienteRecord obj = parent.Session().Get<AlumnoClienteRecord>(Oid);
				obj.CopyValues(this.Base.Record);
				parent.Session().Update(obj);

				
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}

			MarkOld();
		}

		/// <summary>
		/// Borra un registro de la base de datos.
		/// </summary>
		/// <param name="parent">Objeto padre</param>
		/// <remarks>Borrado inmediato<remarks/>
		internal void DeleteSelf(Cliente parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

			// if we're new then don't update the database
			if (this.IsNew) return;

			try
			{
				SessionCode = parent.SessionCode;
				Session().Delete(Session().Get<AlumnoClienteRecord>(Oid));
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}

			MarkNew();
		}
		
		#endregion
				
	}
}

