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
	public class FaltaAlumno : BusinessBaseEx<FaltaAlumno>
	{
	 
		#region Attributes
		
        private string _nombre = string.Empty;
        private string _apellidos = string.Empty;
        private string _n_expediente = string.Empty;
        private string _codigo = string.Empty;
        private long _duracion;
        private string _promocion = string.Empty;
        private string _modulo = string.Empty;
        private long _total_clases;
        private decimal _porcentaje = 0;
        private long _total_faltas;
        private long _total_clases_curso;
        private decimal _porcentaje_total = 0;
        private long _recuperaciones;
        private long _faltas_modulo = 0;
        private decimal _recuperaciones_pendientes = 0;
					
#endregion

        #region Properties

		public virtual string Nombre
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _nombre;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				
					if (value == null) value = string.Empty;
				
				if (!_nombre .Equals(value))
				{
					_nombre = value;
					PropertyHasChanged();
				}
			}
        }
		public virtual string Apellidos
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _apellidos;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				
					if (value == null) value = string.Empty;
				
				if (!_apellidos .Equals(value))
				{
					_apellidos = value;
					PropertyHasChanged();
				}
			}
        }
		public virtual string NExpediente
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _n_expediente;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				
					if (value == null) value = string.Empty;
				
				if (!_n_expediente .Equals(value))
				{
					_n_expediente = value;
					PropertyHasChanged();
				}
			}
        }
		public virtual string Codigo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _codigo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				
					if (value == null) value = string.Empty;
				
				if (!_codigo .Equals(value))
				{
					_codigo = value;
					PropertyHasChanged();
				}
			}
        }
		public virtual long Duracion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _duracion;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
								
				if (!_duracion .Equals(value))
				{
					_duracion = value;
					PropertyHasChanged();
				}
			}
        }
		public virtual string Promocion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _promocion;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				
					if (value == null) value = string.Empty;
				
				if (!_promocion .Equals(value))
				{
					_promocion = value;
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
		public virtual long TotalClases
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _total_clases;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				
				if (!_total_clases .Equals(value))
				{
					_total_clases = value;
					PropertyHasChanged();
				}
			}
        }
		public virtual decimal Porcentaje
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _porcentaje;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				
				if (!_porcentaje .Equals(value))
				{
					_porcentaje = value;
					PropertyHasChanged();
				}
			}
        }
        public virtual long TotalFaltas
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _total_faltas;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_total_faltas.Equals(value))
                {
                    _total_faltas = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual long TotalClasesCurso
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _total_clases_curso;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_total_clases_curso.Equals(value))
                {
                    _total_clases_curso = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual decimal PorcentajeTotal
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _porcentaje_total;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_porcentaje_total.Equals(value))
                {
                    _porcentaje_total = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual long Recuperaciones
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _recuperaciones;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_recuperaciones.Equals(value))
                {
                    _recuperaciones = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual long FaltasModulo
        {
            get
            {
                return _duracion - _recuperaciones;
            }
        }
        public virtual decimal RecuperacionesPendientes
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _recuperaciones_pendientes;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_recuperaciones_pendientes.Equals(value))
                {
                    _recuperaciones_pendientes = value;
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
			
		public virtual FaltaAlumno CloneAsNew()
		{
			FaltaAlumno clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
            clon.Codigo = (0).ToString(Resources.Defaults.DEFAULT_CODE_FORMAT);
			clon.SessionCode = FaltaAlumno.OpenSession();
			FaltaAlumno.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
			
		/// <summary>
		/// Copia los atributos del objeto
		/// </summary>
		/// <param name="source">Objeto origen</param>
		protected void CopyValues (FaltaAlumno source)
		{
			if (source == null) return;
			
			Oid = source.Oid;
			_nombre = source.Nombre;
            _apellidos = source.Apellidos;
            _codigo = source.Codigo;
            _n_expediente = source.NExpediente;
            _duracion = source.Duracion;
            _promocion = source.Promocion;
            _modulo = source.Modulo;
            _total_clases = source.TotalClases;
            _porcentaje = source.Porcentaje;
            _total_faltas = source.TotalFaltas;
            _total_clases_curso = source.TotalClasesCurso;
            _porcentaje_total = source.PorcentajeTotal;
            _recuperaciones = source.Recuperaciones;
            _faltas_modulo = source.FaltasModulo;
            _recuperaciones_pendientes = source.RecuperacionesPendientes;
		}


        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(IDataReader reader)
        {
            if (reader == null) return;

            Oid = Convert.ToInt64(Format.DataReader.GetInt64(reader, "OID_PROMOCION").ToString("0000") +
                                    Format.DataReader.GetInt64(reader, "OID_ALUMNO").ToString("0000") +
                                    Format.DataReader.GetInt64(reader, "OID_MODULO").ToString("0000"));
            _nombre = DBNull.Value.Equals(reader["NOMBRE_ALUMNO"]) ? string.Empty : reader["NOMBRE_ALUMNO"].ToString();
            _apellidos = DBNull.Value.Equals(reader["APELLIDO_ALUMNO"]) ? string.Empty : reader["APELLIDO_ALUMNO"].ToString();
            _n_expediente = DBNull.Value.Equals(reader["EXP_ALUMNO"]) ? string.Empty : reader["EXP_ALUMNO"].ToString();
            _codigo = DBNull.Value.Equals(reader["CODIGO_ALUMNO"]) ? string.Empty : reader["CODIGO_ALUMNO"].ToString();
            _duracion = Format.DataReader.GetInt64(reader, "DURACION");
            _promocion = DBNull.Value.Equals(reader["PROMOCION"]) ? string.Empty : reader["PROMOCION"].ToString();
            _modulo = DBNull.Value.Equals(reader["MODULO"]) ? string.Empty : reader["MODULO"].ToString();
            _total_clases = DBNull.Value.Equals(reader["TOTAL"]) ? 0 : Convert.ToInt32(reader["TOTAL"]);
            _porcentaje = Decimal.Round(((decimal)_duracion + (decimal)_recuperaciones) / _total_clases * 100, 2);
            _total_faltas = DBNull.Value.Equals(reader["DURACION_TOTAL"]) ? 0 : Convert.ToInt32(reader["DURACION_TOTAL"]);
            _total_clases_curso = DBNull.Value.Equals(reader["TOTAL_CURSO"]) ? 0 : Convert.ToInt32(reader["TOTAL_CURSO"]);
            _porcentaje_total = Decimal.Round((decimal)_total_faltas / _total_clases_curso * 100, 2); 
            _recuperaciones = Format.DataReader.GetInt64(reader, "RECUPERACIONES");
            _faltas_modulo = _duracion - _recuperaciones;
            long porcentaje_maximo = moleQule.Library.Instruction.ModulePrincipal.GetPorcentajeMaximoFaltasModuloSetting();
            _recuperaciones_pendientes = _duracion - (_total_clases * porcentaje_maximo / 100);
            if (_recuperaciones_pendientes < 0) _recuperaciones_pendientes = 0;
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
		 
		#region Root Factory Methods
		 
		public static FaltaAlumno New()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return DataPortal.Create<FaltaAlumno>(new CriteriaCs(-1));
		}
			
		public static FaltaAlumno Get(long oid)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			CriteriaEx criteria = FaltaAlumno.GetCriteria(FaltaAlumno.OpenSession());
		
			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = FaltaAlumno.SELECT( oid);
			else
				criteria.AddOidSearch(oid);
			
			FaltaAlumno.BeginTransaction(criteria.Session);
			
			return DataPortal.Fetch<FaltaAlumno>(criteria);
		}
		
		internal static FaltaAlumno Get(IDataReader reader)
		{
			return new FaltaAlumno(reader, true);
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
			int sessCode = FaltaAlumno.OpenSession();
			ISession sess = FaltaAlumno.Session(sessCode);
			ITransaction trans = FaltaAlumno.BeginTransaction(sessCode);
			
			try
			{	
				sess.Delete("from FaltaAlumno");
				trans.Commit();
			}
			catch (Exception ex)
			{
				if (trans != null) trans.Rollback();
				iQExceptionHandler.TreatException(ex);
			}
			finally
			{
				FaltaAlumno.CloseSession(sessCode);
			}
		}
		
		public override FaltaAlumno Save()
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

                Transaction().Commit();

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
		protected FaltaAlumno () 
        {
        }		
		
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE. LAS UTILIZAN LAS FUNCIONES DE CREACION DE LISTAS
		/// </summary>
        private FaltaAlumno(FaltaAlumno source, bool retrieve_childs)
        {
			MarkAsChild();
			Childs = retrieve_childs;
            Fetch(source);
        }
		
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE. LAS UTILIZAN LAS FUNCIONES DE CREACION DE LISTAS
		/// </summary>
        private FaltaAlumno(IDataReader source, bool retrieve_childs)
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
        public static FaltaAlumno NewChild() 
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<FaltaAlumno>(new CriteriaCs(-1));
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
        internal static FaltaAlumno GetChild(FaltaAlumno source)
		{
            return new FaltaAlumno(source, false);
		}
		
		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="source">Area con los datos para el objeto</param>
		/// <param name="retrieve_childs">Flag para obtener también los hijos</param>
		/// <returns>Objeto creado</returns>
		/// <remarks>La utiliza la BusinessListBaseEx correspondiente para montar la lista<remarks/>
        internal static FaltaAlumno GetChild(FaltaAlumno source, bool retrieve_childs)
		{
            return new FaltaAlumno(source, retrieve_childs);
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
        internal static FaltaAlumno GetChild(IDataReader source)
        {
            return new FaltaAlumno(source, false);
        }
		
		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="source">IDataReader con los datos para el objeto</param>
		/// <param name="retrieve_childs">Flag para obtener también los hijos</param>
		/// <returns>Objeto creado</returns>
		/// <remarks>La utiliza la BusinessListBaseEx correspondiente para montar la lista<remarks/>
        internal static FaltaAlumno GetChild(IDataReader source, bool retrieve_childs)
        {
            return new FaltaAlumno(source, retrieve_childs);
        }
		
		/// <summary>
		/// Construye y devuelve un objeto de solo lectura copia de si mismo.
		/// También copia los datos de los hijos del objeto.
		/// </summary>
		/// <returns>Réplica de solo lectura del objeto</returns>
        public virtual FaltaAlumnoInfo GetInfo()
		{
			return GetInfo(true);
		}
		
		/// <summary>
		/// Construye y devuelve un objeto de solo lectura copia de si mismo.
		/// </summary>
		/// <param name="get_childs">Flag para solicitar que se copien los hijos</param>
		/// <returns>Réplica de solo lectura del objeto</returns>
        public virtual FaltaAlumnoInfo GetInfo(bool get_childs)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new FaltaAlumnoInfo(this, get_childs);
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
        private void Fetch(FaltaAlumno source)
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
                    FaltaAlumno.DoLOCK(Session());
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
                    FaltaAlumno obj = Session().Get<FaltaAlumno>(Oid);
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
                Session().Delete((AlumnoRecord)(criterio.UniqueResult()));
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

