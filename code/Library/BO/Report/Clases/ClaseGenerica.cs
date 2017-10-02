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

	/// <summary>
	/// Editable Root Business Object With Editable Child Collection
	/// </summary>
    [Serializable()]
	public class ClaseGenerica : BusinessBaseEx<ClaseGenerica>
	{
	 
		#region Attributes

		private string _titulo = string.Empty;
        private long _oid_submodulo = 0;
        private long _oid_modulo = 0;
        private long _tipo = 0;
        private long _orden_primario = 0;
        private long _orden_secundario = 0;
        private long _orden_terciario = 0;
        private long _estado = 1;
        private long _incompatible;
        private long _grupo = 3;
        private string _modulo = string.Empty;
        private string _submodulo = string.Empty;
        private string _alias = string.Empty;
					
        #endregion

        #region Properties

        
		public virtual string Titulo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _titulo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				
					if (value == null) value = string.Empty;
				
				if (!_titulo .Equals(value))
				{
					_titulo = value;
					PropertyHasChanged();
				}
			}
        }
        public virtual long OidSubmodulo
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _oid_submodulo;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_oid_submodulo.Equals(value))
                {
                    _oid_submodulo = value;
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
                return _oid_modulo;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_oid_modulo.Equals(value))
                {
                    _oid_modulo = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual long Tipo
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _tipo;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_tipo.Equals(value))
                {
                    _tipo = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual long OrdenPrimario
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _orden_primario;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_orden_primario.Equals(value))
                {
                    _orden_primario = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual long OrdenSecundario
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _orden_secundario;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_orden_secundario.Equals(value))
                {
                    _orden_secundario = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual long OrdenTerciario
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _orden_terciario;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_orden_terciario.Equals(value))
                {
                    _orden_terciario = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual long Estado
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _estado;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_estado.Equals(value))
                {
                    _estado = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual long Incompatible
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _incompatible;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_incompatible.Equals(value))
                {
                    _incompatible = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual long Grupo
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _grupo;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_grupo.Equals(value))
                {
                    _grupo = value;
                    PropertyHasChanged();
                }
            }
        }
		public virtual string Modulo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _modulo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				
					if (value == null) value = string.Empty;
				
				if (!_modulo .Equals(value))
				{
					_modulo = value;
					PropertyHasChanged();
				}
			}
        }
		public virtual string Submodulo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _submodulo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				
					if (value == null) value = string.Empty;
				
				if (!_submodulo .Equals(value))
				{
					_submodulo = value;
					PropertyHasChanged();
				}
			}
        }
		public virtual string Alias
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _alias;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				
					if (value == null) value = string.Empty;
				
				if (!_alias .Equals(value))
				{
					_alias = value;
					PropertyHasChanged();
				}
			}
        }

        public virtual ETipoClase ETipoClase { get { return (ETipoClase)_tipo; } } 
		public virtual string TipoClase { get { return Instruction.EnumText<ETipoClase>.GetLabel(ETipoClase); } }
        public virtual EEstadoClase EEstadoClase{get{return (EEstadoClase)_estado;}}
        public virtual string EstadoClaseLabel{get{return Instruction.EnumText<EEstadoClase>.GetLabel(EEstadoClase);}}
        		
#endregion

        #region Business Methods
        
        /// <summary>
		/// Clona la entidad y sus subentidades y las marca como nuevas
		/// </summary>
		/// <returns>Una entidad clon</returns>
			
		public virtual ClaseGenerica CloneAsNew()
		{
			ClaseGenerica clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			clon.SessionCode = ClaseGenerica.OpenSession();
			ClaseGenerica.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
			
		/// <summary>
		/// Copia los atributos del objeto
		/// </summary>
		/// <param name="source">Objeto origen</param>
		protected void CopyValues (ClaseGenerica source)
		{
			if (source == null) return;
			
			Oid = source.Oid;
            _titulo = source.Titulo;
            _oid_submodulo = source.OidSubmodulo;
            _oid_modulo = source.OidModulo;
            _tipo = source.Tipo;
            _orden_primario = source.OrdenPrimario;
            _orden_secundario=source.OrdenSecundario;
            _orden_terciario = source.OrdenTerciario;
            _estado = source.Estado;
            _incompatible = source.Incompatible;
            _grupo = source.Grupo;
            _modulo = source.Modulo;
            _submodulo = source.Submodulo;
            _alias = source.Alias;
		}

        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(IDataReader source)
        {
            if (source == null) return;
            CopyValues(source);
        }
			
		#endregion
		 
	    #region Validation Rules

        protected override void AddBusinessRules()
        {
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
		 
		#region Root Factory Methods
		 
		public static ClaseGenerica New()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return DataPortal.Create<ClaseGenerica>(new CriteriaCs(-1));
		}
			
		public static ClaseGenerica Get(long oid)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			CriteriaEx criteria = ClaseGenerica.GetCriteria(ClaseGenerica.OpenSession());
		
			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = ClaseGenerica.SELECT( oid);
			else
				criteria.AddOidSearch(oid);
			
			ClaseGenerica.BeginTransaction(criteria.Session);
			
			return DataPortal.Fetch<ClaseGenerica>(criteria);
		}
		
		internal static ClaseGenerica Get(IDataReader reader)
		{
			return new ClaseGenerica(reader, true);
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
		/// Elimina todos los Area. 
		/// Si no existe integridad referencial, hay que eliminar las listas hijo en esta función.
		/// </summary>
		public static void DeleteAll()
		{
			//Iniciamos la conexion y la transaccion
			int sessCode = ClaseGenerica.OpenSession();
			ISession sess = ClaseGenerica.Session(sessCode);
			ITransaction trans = ClaseGenerica.BeginTransaction(sessCode);
			
			try
			{	
				sess.Delete("from ClaseGenerica");
				trans.Commit();
			}
			catch (Exception ex)
			{
				if (trans != null) trans.Rollback();
				iQExceptionHandler.TreatException(ex);
			}
			finally
			{
				ClaseGenerica.CloseSession(sessCode);
			}
		}
		
		public override ClaseGenerica Save()
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
		
        #region Common Factory Methods
		 
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION New o NewChild
		/// Debería ser private para CSLA porque la creación requiere el uso de los Factory Methods,
		/// pero debe ser protected por exigencia de NHibernate.
		/// </summary>
		public ClaseGenerica () 
        {
        }		
		
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE. LAS UTILIZAN LAS FUNCIONES DE CREACION DE LISTAS
		/// </summary>
        private ClaseGenerica(ClaseGenerica source, bool retrieve_childs)
        {
			MarkAsChild();
			Childs = retrieve_childs;
            Fetch(source);
        }
		
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE. LAS UTILIZAN LAS FUNCIONES DE CREACION DE LISTAS
		/// </summary>
        private ClaseGenerica(IDataReader source, bool retrieve_childs)
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
        public static ClaseGenerica NewChild() 
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<ClaseGenerica>(new CriteriaCs(-1));
		}
		
		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="source">Area con los datos para el objeto</param>
		/// <returns>Objeto creado</returns>
		/// <remarks>
		/// La utiliza la BusinessListBaseEx correspondiente para montar la lista
		/// NO OBTIENE los hijos. Para ello utilice GetChild(Area source, bool retrieve_childs)
		/// <remarks/>
        internal static ClaseGenerica GetChild(ClaseGenerica source)
		{
            return new ClaseGenerica(source, false);
		}
		
		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="source">Area con los datos para el objeto</param>
		/// <param name="retrieve_childs">Flag para obtener también los hijos</param>
		/// <returns>Objeto creado</returns>
		/// <remarks>La utiliza la BusinessListBaseEx correspondiente para montar la lista<remarks/>
        internal static ClaseGenerica GetChild(ClaseGenerica source, bool retrieve_childs)
		{
            return new ClaseGenerica(source, retrieve_childs);
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
        internal static ClaseGenerica GetChild(IDataReader source)
        {
            return new ClaseGenerica(source, false);
        }
		
		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="source">IDataReader con los datos para el objeto</param>
		/// <param name="retrieve_childs">Flag para obtener también los hijos</param>
		/// <returns>Objeto creado</returns>
		/// <remarks>La utiliza la BusinessListBaseEx correspondiente para montar la lista<remarks/>
        internal static ClaseGenerica GetChild(IDataReader source, bool retrieve_childs)
        {
            return new ClaseGenerica(source, retrieve_childs);
        }
		
		/// <summary>
		/// Construye y devuelve un objeto de solo lectura copia de si mismo.
		/// También copia los datos de los hijos del objeto.
		/// </summary>
		/// <returns>Réplica de solo lectura del objeto</returns>
        public virtual ClaseGenericaInfo GetInfo()
		{
			return GetInfo(true);
		}
		
		/// <summary>
		/// Construye y devuelve un objeto de solo lectura copia de si mismo.
		/// </summary>
		/// <param name="get_childs">Flag para solicitar que se copien los hijos</param>
		/// <returns>Réplica de solo lectura del objeto</returns>
        public virtual ClaseGenericaInfo GetInfo(bool get_childs)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new ClaseGenericaInfo(this);
		}
		
		#endregion

		#region Common Data Access
		 
		[RunLocal()]
		private void DataPortal_Create(CriteriaCs criteria)
		{
			Random r = new Random();
            Oid = (long)r.Next();
		}
		 
        /// <summary>
        /// Construye el objeto y se encarga de obtener los
        /// hijos si los tiene y se solicitan
        /// </summary>
        /// <param name="source">Objeto fuente</param>
        private void Fetch(ClaseGenerica source)
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
                    ClaseGenerica.DoLOCK(Session());
					IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());
					
					if (reader.Read())
						CopyValues(reader);
				}
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
				Session().Save(this);
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
                    ClaseGenerica obj = Session().Get<ClaseGenerica>(Oid);
					obj.CopyValues(this);
					Session().Update(obj);
				}
				catch (Exception ex)
				{
					iQExceptionHandler.TreatException(ex);
				}
			}
		}
		
		//Deferred deletion
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
					
				//Si no hay integridad referencial, aquí se deben borrar las listas hijo
				CriteriaEx criterio = GetCriteria();
				criterio.AddOidSearch(criteria.Oid);
                Session().Delete((ClaseTeoricaRecord)(criterio.UniqueResult()));
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

	}
}

