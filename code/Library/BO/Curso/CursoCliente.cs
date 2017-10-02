using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;

using moleQule.Library;

using moleQule.Library.Invoice;

namespace moleQule.Library.Instruction
{
	/// <summary>
	/// Editable Child Business Object
	/// </summary>	
    [Serializable()]
	public class CursoCliente : BusinessBaseEx<CursoCliente>
	{
	 
		#region Attributes & Properties		
		
		private long _oid_curso;
		private long _oid_cliente;

        //Unlinked Properties
        private string _curso;
        private string _cliente;
		
		public virtual long OidCurso
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _oid_curso;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				
				if (!_oid_curso.Equals(value))
				{
					_oid_curso = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidCliente
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _oid_cliente;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				
				if (!_oid_cliente.Equals(value))
				{
					_oid_cliente = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual string Cliente
        {

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _cliente;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_cliente.Equals(value))
                {
                    _cliente = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Curso
        {

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _curso;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_curso.Equals(value))
                {
                    _curso = value;
                    PropertyHasChanged();
                }
            }
        }
	 
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
		public virtual CursoCliente CloneAsNew()
		{
			CursoCliente clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = CursoCliente.OpenSession();
			CursoCliente.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		/// <summary>
		/// Copia los atributos del objeto
		/// </summary>
		/// <param name="source">Objeto origen de solo lectura</param>
		protected virtual void CopyFrom (CursoClienteInfo source)
		{
			if (source == null) return;
			
			Oid = source.Oid;
			_oid_curso = source.OidCurso;
			_oid_cliente = source.OidCliente;

            _curso = source.Curso;
            _cliente = source.Cliente;
		}

        /// <summary>
        /// Carga los valores de un registro apuntado por un IDataReader en el objeto.
        /// Consulta el fichero de mapeo de tablas de nHibernate para rellenar las propiedades.
        /// </summary>
        /// <param name="source"></param>
        protected override void CopyValues(IDataReader source)
        {
            if (source == null) return;

            _base.CopyValues(source);

            _curso = Format.DataReader.GetString(source, "CURSO");
            _cliente = Format.DataReader.GetString(source, "CLIENTE");
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
            return AutorizationRulesControler.CanAddObject(moleQule.Library.Invoice.Resources.SecureItems.FACTURA_EMITIDA);
		}
		
		public static bool CanGetObject()
		{
            return AutorizationRulesControler.CanGetObject(moleQule.Library.Invoice.Resources.SecureItems.FACTURA_EMITIDA);
		}
		
		public static bool CanDeleteObject()
		{
            return AutorizationRulesControler.CanDeleteObject(moleQule.Library.Invoice.Resources.SecureItems.FACTURA_EMITIDA);
		}
		
		public static bool CanEditObject()
		{
            return AutorizationRulesControler.CanEditObject(moleQule.Library.Invoice.Resources.SecureItems.FACTURA_EMITIDA);
		}

		#endregion
		 
		#region Common Factory Methods
		 
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION New o NewChild
		/// Debería ser private para CSLA porque la creación requiere el uso de los Factory Methods,
		/// pero debe ser protected por exigencia de NHibernate.
		/// Debe ser public para que funcionen los DataGridView
		/// </summary>
		 protected CursoCliente ()
		{
			// Si se necesita constructor público para este objeto hay que añadir el MarkAsChild() debido a la interfaz Child
			// y el código que está en el DataPortal_Create debería ir aquí
		
		}
		
		
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE. LAS UTILIZAN LAS FUNCIONES DE CREACION DE LISTAS
		/// </summary>
		private CursoCliente(CursoCliente source, bool retrieve_childs)
        {
			MarkAsChild();
			Childs = retrieve_childs;
            Fetch(source);
        }
		
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE. LAS UTILIZAN LAS FUNCIONES DE CREACION DE LISTAS
		/// </summary>
        private CursoCliente(IDataReader source, bool retrieve_childs)
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
		public static CursoCliente NewChild() 
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return DataPortal.Create<CursoCliente>(new CriteriaCs(-1));
		}
		
		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="source">CursoCliente con los datos para el objeto</param>
		/// <returns>Objeto creado</returns>
		/// <remarks>
		/// La utiliza la BusinessListBaseEx correspondiente para montar la lista
		/// NO OBTIENE los hijos. Para ello utilice GetChild(CursoCliente source, bool retrieve_childs)
		/// <remarks/>
		internal static CursoCliente GetChild(CursoCliente source)
		{
			return new CursoCliente(source, false);
		}
		
		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="source">CursoCliente con los datos para el objeto</param>
		/// <param name="retrieve_childs">Flag para obtener también los hijos</param>
		/// <returns>Objeto creado</returns>
		/// <remarks>La utiliza la BusinessListBaseEx correspondiente para montar la lista<remarks/>
		internal static CursoCliente GetChild(CursoCliente source, bool retrieve_childs)
		{
			return new CursoCliente(source, retrieve_childs);
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
        internal static CursoCliente GetChild(IDataReader source)
        {
            return new CursoCliente(source, false);
        }
		
		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="source">IDataReader con los datos para el objeto</param>
		/// <param name="retrieve_childs">Flag para obtener también los hijos</param>
		/// <returns>Objeto creado</returns>
		/// <remarks>La utiliza la BusinessListBaseEx correspondiente para montar la lista<remarks/>
        internal static CursoCliente GetChild(IDataReader source, bool retrieve_childs)
        {
            return new CursoCliente(source, retrieve_childs);
        }
		
		/// <summary>
		/// Construye y devuelve un objeto de solo lectura copia de si mismo.
		/// También copia los datos de los hijos del objeto.
		/// </summary>
		/// <returns>Réplica de solo lectura del objeto</returns>
		public virtual CursoClienteInfo GetInfo()
		{
			return GetInfo(true);
		}
		
		/// <summary>
		/// Construye y devuelve un objeto de solo lectura copia de si mismo.
		/// </summary>
		/// <param name="get_childs">Flag para solicitar que se copien los hijos</param>
		/// <returns>Réplica de solo lectura del objeto</returns>
		public virtual CursoClienteInfo GetInfo (bool get_childs)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return GetInfo(get_childs);// new CursoClienteInfo(this, get_childs);
		}
		
		#endregion				
		
		#region Child Factory Methods
		
		
		/// <summary>
		/// Crea un nuevo objeto hijo
		/// </summary>
		/// <param name="parent">Objeto padre</param>
		/// <returns>Nuevo objeto creado</returns>
		internal static CursoCliente NewChild(Cliente parent)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

			CursoCliente item = new CursoCliente();
			item.MarkAsChild();
			item.OidCliente = parent.Oid;
			return item;
		}
		
		/// <summary>
		/// Crea un nuevo objeto hijo
		/// </summary>
		/// <param name="parent">Objeto padre</param>
		/// <returns>Nuevo objeto creado</returns>
		internal static CursoCliente NewChild(Curso parent)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

			CursoCliente item = new CursoCliente();
			item.MarkAsChild();
			item.OidCurso = parent.Oid;
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
		public override CursoCliente Save()
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
		private void Fetch(CursoCliente source)
		{
            try
            {
                SessionCode = source.SessionCode;

                CopyValues(source);
				
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
                CopyValues(source);

                
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
		internal void Insert(CursoClientes parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;
			
			try
			{	
				ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

				parent.Session().Save(this);
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
		internal void Update(CursoClientes parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;
			
			try
			{
				ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

				SessionCode = parent.SessionCode;
				CursoCliente obj = Session().Get<CursoCliente>(Oid);
				obj.CopyValues(this);
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
		internal void DeleteSelf(CursoClientes parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

			// if we're new then don't update the database
			if (this.IsNew) return;
			
			try
			{
				SessionCode = parent.SessionCode;
				Session().Delete(Session().Get<CursoCliente>(Oid));
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

			_oid_cliente = parent.Oid;	
			

			try
			{
				ValidationRules.CheckRules();
				
				if (!IsValid)
					throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

				parent.Session().Save(this);	
				
				
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

			_oid_cliente = parent.Oid;

			try
			{
				ValidationRules.CheckRules();

				if (!IsValid)
					throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

				CursoCliente obj = parent.Session().Get<CursoCliente>(Oid);
				obj.CopyValues(this);
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
				Session().Delete(Session().Get<CursoCliente>(Oid));
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}

			MarkNew();
		}
		
		/// <summary>
		/// Inserta un registro en la base de datos
		/// </summary>
		/// <param name="parent">Objeto padre</param>
		internal void Insert(Curso parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

			//Debe obtener la sesion del padre pq el objeto es padre a su vez
			SessionCode = parent.SessionCode;

			_oid_curso = parent.Oid;	
			

			try
			{
				ValidationRules.CheckRules();
				
				if (!IsValid)
					throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

				parent.Session().Save(this);	
				
				
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
		internal void Update(Curso parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

			//Debe obtener la sesion del padre pq el objeto es padre a su vez
			SessionCode = parent.SessionCode;

			_oid_curso = parent.Oid;

			try
			{
				ValidationRules.CheckRules();

				if (!IsValid)
					throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

				CursoCliente obj = parent.Session().Get<CursoCliente>(Oid);
				obj.CopyValues(this);
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
		internal void DeleteSelf(Curso parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

			// if we're new then don't update the database
			if (this.IsNew) return;

			try
			{
				SessionCode = parent.SessionCode;
				Session().Delete(Session().Get<CursoCliente>(Oid));
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

