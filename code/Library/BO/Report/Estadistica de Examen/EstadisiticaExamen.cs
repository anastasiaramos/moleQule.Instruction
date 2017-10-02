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
	public class EstadisticaExamen : BusinessBaseEx<EstadisticaExamen>
	{
	 
		#region Attributes
		
        private long _numero_pregunta;
        private long _total_fallos = 0;
        private decimal _porcentaje_fallos = 0;
        private bool _anulada = false;
        private string _numero_pregunta_banco = string.Empty;
        private long _nivel;
        private string _tema = string.Empty;
					
#endregion

        #region Properties
        
        public virtual long NumeroPregunta
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _numero_pregunta;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_numero_pregunta.Equals(value))
                {
                    _numero_pregunta = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual long TotalFallos
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _total_fallos;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_total_fallos.Equals(value))
                {
                    _total_fallos = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual decimal PorcentajeFallos
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _porcentaje_fallos;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_porcentaje_fallos.Equals(value))
                {
                    _porcentaje_fallos = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool Anulada
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _anulada;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_anulada.Equals(value))
                {
                    _anulada = value;
                    PropertyHasChanged();
                }
            }
        }
		public virtual string NumeroPreguntaBanco
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _numero_pregunta_banco;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				
					if (value == null) value = string.Empty;
				
				if (!_numero_pregunta_banco .Equals(value))
				{
					_numero_pregunta_banco = value;
					PropertyHasChanged();
				}
			}
        }
        public virtual long Nivel
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
		public virtual string Tema
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _tema;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				
					if (value == null) value = string.Empty;
				
				if (!_tema .Equals(value))
				{
					_tema = value;
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
			
		public virtual EstadisticaExamen CloneAsNew()
		{
			EstadisticaExamen clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			clon.SessionCode = EstadisticaExamen.OpenSession();
			EstadisticaExamen.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
			
		/// <summary>
		/// Copia los atributos del objeto
		/// </summary>
		/// <param name="source">Objeto origen</param>
		protected void CopyValues (EstadisticaExamen source)
		{
			if (source == null) return;
			
			Oid = source.Oid;
            _numero_pregunta = source.NumeroPregunta;
            _total_fallos = source.TotalFallos;
            _porcentaje_fallos = source.PorcentajeFallos;
            _anulada = source.Anulada;
            _numero_pregunta_banco = source.NumeroPreguntaBanco;
            _nivel = source.Nivel;
            _tema = source.Tema;
		}


        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(IDataReader source)
        {
            if (source == null) return;

            Oid = Format.DataReader.GetInt64(source, "OID");
            _numero_pregunta = Format.DataReader.GetInt64(source, "NUMERO_PREGUNTA");
            _total_fallos = Format.DataReader.GetInt64(source, "TOTAL_FALLOS");
            _porcentaje_fallos = Format.DataReader.GetDecimal(source, "PORCENTAJE_FALLOS");
            _anulada = Format.DataReader.GetBool(source, "ANULADA");
            _numero_pregunta_banco = Format.DataReader.GetString(source, "NUMERO_PREGUNTA_BANCO");
            _nivel = Format.DataReader.GetInt64(source, "NIVEL");
            _tema = Format.DataReader.GetString(source, "TEMA");

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
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.EXAMEN);
		}
		
		public static bool CanGetObject()
		{
			return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.EXAMEN);
		}
		
		public static bool CanDeleteObject()
		{
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.EXAMEN);
		}
		
		public static bool CanEditObject()
		{
			return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.EXAMEN);
		}
		 
		#endregion
		 
		#region Root Factory Methods
		 
		public static EstadisticaExamen New()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return DataPortal.Create<EstadisticaExamen>(new CriteriaCs(-1));
		}
			
		public static EstadisticaExamen Get(long oid)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			CriteriaEx criteria = EstadisticaExamen.GetCriteria(EstadisticaExamen.OpenSession());
		
			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = EstadisticaExamen.SELECT( oid);
			else
				criteria.AddOidSearch(oid);
			
			EstadisticaExamen.BeginTransaction(criteria.Session);
			
			return DataPortal.Fetch<EstadisticaExamen>(criteria);
		}
		
		internal static EstadisticaExamen Get(IDataReader reader)
		{
			return new EstadisticaExamen(reader, true);
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
			int sessCode = EstadisticaExamen.OpenSession();
			ISession sess = EstadisticaExamen.Session(sessCode);
			ITransaction trans = EstadisticaExamen.BeginTransaction(sessCode);
			
			try
			{	
				sess.Delete("from EstadisticaExamen");
				trans.Commit();
			}
			catch (Exception ex)
			{
				if (trans != null) trans.Rollback();
				iQExceptionHandler.TreatException(ex);
			}
			finally
			{
				EstadisticaExamen.CloseSession(sessCode);
			}
		}
		
		public override EstadisticaExamen Save()
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
		public EstadisticaExamen () 
        {
        }		
		
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE. LAS UTILIZAN LAS FUNCIONES DE CREACION DE LISTAS
		/// </summary>
        private EstadisticaExamen(EstadisticaExamen source, bool retrieve_childs)
        {
			MarkAsChild();
			Childs = retrieve_childs;
            Fetch(source);
        }
		
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE. LAS UTILIZAN LAS FUNCIONES DE CREACION DE LISTAS
		/// </summary>
        private EstadisticaExamen(IDataReader source, bool retrieve_childs)
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
        public static EstadisticaExamen NewChild() 
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<EstadisticaExamen>(new CriteriaCs(-1));
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
        internal static EstadisticaExamen GetChild(EstadisticaExamen source)
		{
            return new EstadisticaExamen(source, false);
		}
		
		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="source">Area con los datos para el objeto</param>
		/// <param name="retrieve_childs">Flag para obtener también los hijos</param>
		/// <returns>Objeto creado</returns>
		/// <remarks>La utiliza la BusinessListBaseEx correspondiente para montar la lista<remarks/>
        internal static EstadisticaExamen GetChild(EstadisticaExamen source, bool retrieve_childs)
		{
            return new EstadisticaExamen(source, retrieve_childs);
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
        internal static EstadisticaExamen GetChild(IDataReader source)
        {
            return new EstadisticaExamen(source, false);
        }
		
		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="source">IDataReader con los datos para el objeto</param>
		/// <param name="retrieve_childs">Flag para obtener también los hijos</param>
		/// <returns>Objeto creado</returns>
		/// <remarks>La utiliza la BusinessListBaseEx correspondiente para montar la lista<remarks/>
        internal static EstadisticaExamen GetChild(IDataReader source, bool retrieve_childs)
        {
            return new EstadisticaExamen(source, retrieve_childs);
        }
		
		/// <summary>
		/// Construye y devuelve un objeto de solo lectura copia de si mismo.
		/// También copia los datos de los hijos del objeto.
		/// </summary>
		/// <returns>Réplica de solo lectura del objeto</returns>
        public virtual EstadisticaExamenInfo GetInfo()
		{
			return GetInfo(true);
		}
		
		/// <summary>
		/// Construye y devuelve un objeto de solo lectura copia de si mismo.
		/// </summary>
		/// <param name="get_childs">Flag para solicitar que se copien los hijos</param>
		/// <returns>Réplica de solo lectura del objeto</returns>
        public virtual EstadisticaExamenInfo GetInfo(bool get_childs)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new EstadisticaExamenInfo(this, get_childs);
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
        private void Fetch(EstadisticaExamen source)
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
                    EstadisticaExamen.DoLOCK(Session());
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
                    EstadisticaExamen obj = Session().Get<EstadisticaExamen>(Oid);
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
                Session().Delete((ExamenRecord)(criterio.UniqueResult()));
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

