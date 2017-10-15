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
	public class InformePreguntas : BusinessBaseEx<InformePreguntas>
	{
	 
		#region Attributes

        private long _oid_modulo;
        private string _modulo = string.Empty;
        private int _preguntas_modulo;
        private long _oid_submodulo;
        private string _submodulo = string.Empty;
        private int _preguntas_submodulo;
        private int _nivel;
        private int _n_preguntas;
        private bool _desarrollo;
					
        #endregion

        #region Properties

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

                if (!_modulo.Equals(value))
                {
                    _modulo = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual int PreguntasModulo
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _preguntas_modulo;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_preguntas_modulo.Equals(value))
                {
                    _preguntas_modulo = value;
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
        public virtual int PreguntasSubmodulo
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _preguntas_submodulo;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_preguntas_submodulo.Equals(value))
                {
                    _preguntas_submodulo = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual int Nivel
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _nivel;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_nivel.Equals(value))
                {
                    _nivel = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual int NPreguntas
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _n_preguntas;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_n_preguntas.Equals(value))
                {
                    _n_preguntas = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool Desarrollo
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _desarrollo;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_desarrollo.Equals(value))
                {
                    _desarrollo = value;
                    PropertyHasChanged();
                }
            }
        }

		
        #endregion

        #region Business Methods
        
        /// <summary>
		/// Clona la entidad y sus subentidades y las marca como nuevas
		/// </summary>
		/// <returns>Una entidad clon</returns>
			
		public virtual InformePreguntas CloneAsNew()
		{
			InformePreguntas clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			clon.SessionCode = InformePreguntas.OpenSession();
			InformePreguntas.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
			
		/// <summary>
		/// Copia los atributos del objeto
		/// </summary>
		/// <param name="source">Objeto origen</param>
		protected void CopyValues (InformePreguntas source)
		{
			if (source == null) return;
			
			Oid = source.Oid;
            _oid_modulo = source.OidModulo;
            _modulo = source.Modulo;
            _preguntas_modulo = source.PreguntasModulo;
            _oid_submodulo = source.OidSubmodulo;
            _submodulo = source.Submodulo;
            _preguntas_submodulo = source.PreguntasSubmodulo;
            _nivel = source.Nivel;
            _n_preguntas = source.NPreguntas;
            _desarrollo = source.Desarrollo;
		}


        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(IDataReader reader)
        {
            if (reader == null) return;

            Oid = Convert.ToInt64(Format.DataReader.GetString(reader, "OID_MODULO") + Format.DataReader.GetString(reader, "OID_SUBMODULO") + Format.DataReader.GetString(reader, "NIVEL") + (Format.DataReader.GetBool(reader, "DESARROLLO") ? "0" : "1"));
            _oid_modulo = Format.DataReader.GetInt64(reader, "OID_MODULO");
            _modulo = DBNull.Value.Equals(reader["MODULO"]) ? string.Empty : reader["MODULO"].ToString();
            _preguntas_modulo = Format.DataReader.GetInt32(reader, "PREGUNTAS_MODULO");
            _oid_submodulo = Format.DataReader.GetInt64(reader, "OID_SUBMODULO");
            _submodulo = DBNull.Value.Equals(reader["SUBMODULO"]) ? string.Empty : reader["SUBMODULO"].ToString();
            _preguntas_submodulo = Format.DataReader.GetInt32(reader, "PREGUNTAS_SUBMODULO");
            _nivel = Format.DataReader.GetInt32(reader, "NIVEL");
            _n_preguntas = Format.DataReader.GetInt32(reader, "N_PREGUNTAS");
            _desarrollo = Format.DataReader.GetBool(reader, "DESARROLLO");
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
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.MODULO);
		}
		
		public static bool CanGetObject()
		{
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.MODULO);
		}
		
		public static bool CanDeleteObject()
		{
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.MODULO);
		}
		
		public static bool CanEditObject()
		{
            return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.MODULO);
		}
		 
		#endregion
		 
		#region Root Factory Methods
		 
		public static InformePreguntas New()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return DataPortal.Create<InformePreguntas>(new CriteriaCs(-1));
		}
			
		public static InformePreguntas Get(long oid)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			CriteriaEx criteria = InformePreguntas.GetCriteria(InformePreguntas.OpenSession());
		
			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = InformePreguntas.SELECT( oid);
			else
				criteria.AddOidSearch(oid);
			
			InformePreguntas.BeginTransaction(criteria.Session);
			
			return DataPortal.Fetch<InformePreguntas>(criteria);
		}
		
		internal static InformePreguntas Get(IDataReader reader)
		{
			return new InformePreguntas(reader, true);
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
			int sessCode = InformePreguntas.OpenSession();
			ISession sess = InformePreguntas.Session(sessCode);
			ITransaction trans = InformePreguntas.BeginTransaction(sessCode);
			
			try
			{	
				sess.Delete("from InformePreguntas");
				trans.Commit();
			}
			catch (Exception ex)
			{
				if (trans != null) trans.Rollback();
				iQExceptionHandler.TreatException(ex);
			}
			finally
			{
				InformePreguntas.CloseSession(sessCode);
			}
		}
		
		public override InformePreguntas Save()
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
		protected InformePreguntas () 
        {
        }		
		
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE. LAS UTILIZAN LAS FUNCIONES DE CREACION DE LISTAS
		/// </summary>
        private InformePreguntas(InformePreguntas source, bool retrieve_childs)
        {
			MarkAsChild();
			Childs = retrieve_childs;
            Fetch(source);
        }
		
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE. LAS UTILIZAN LAS FUNCIONES DE CREACION DE LISTAS
		/// </summary>
        private InformePreguntas(IDataReader source, bool retrieve_childs)
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
        public static InformePreguntas NewChild() 
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<InformePreguntas>(new CriteriaCs(-1));
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
        internal static InformePreguntas GetChild(InformePreguntas source)
		{
            return new InformePreguntas(source, false);
		}
		
		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="source">Area con los datos para el objeto</param>
		/// <param name="retrieve_childs">Flag para obtener también los hijos</param>
		/// <returns>Objeto creado</returns>
		/// <remarks>La utiliza la BusinessListBaseEx correspondiente para montar la lista<remarks/>
        internal static InformePreguntas GetChild(InformePreguntas source, bool retrieve_childs)
		{
            return new InformePreguntas(source, retrieve_childs);
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
        internal static InformePreguntas GetChild(IDataReader source)
        {
            return new InformePreguntas(source, false);
        }
		
		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="source">IDataReader con los datos para el objeto</param>
		/// <param name="retrieve_childs">Flag para obtener también los hijos</param>
		/// <returns>Objeto creado</returns>
		/// <remarks>La utiliza la BusinessListBaseEx correspondiente para montar la lista<remarks/>
        internal static InformePreguntas GetChild(IDataReader source, bool retrieve_childs)
        {
            return new InformePreguntas(source, retrieve_childs);
        }
		
		/// <summary>
		/// Construye y devuelve un objeto de solo lectura copia de si mismo.
		/// También copia los datos de los hijos del objeto.
		/// </summary>
		/// <returns>Réplica de solo lectura del objeto</returns>
        public virtual InformePreguntasInfo GetInfo()
		{
			return GetInfo(true);
		}
		
		/// <summary>
		/// Construye y devuelve un objeto de solo lectura copia de si mismo.
		/// </summary>
		/// <param name="get_childs">Flag para solicitar que se copien los hijos</param>
		/// <returns>Réplica de solo lectura del objeto</returns>
        public virtual InformePreguntasInfo GetInfo(bool get_childs)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new InformePreguntasInfo(this, get_childs);
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
        private void Fetch(InformePreguntas source)
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
                    InformePreguntas.DoLOCK(Session());
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
                    InformePreguntas obj = Session().Get<InformePreguntas>(Oid);
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
                Session().Delete((SesionRecord)(criterio.UniqueResult()));
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

