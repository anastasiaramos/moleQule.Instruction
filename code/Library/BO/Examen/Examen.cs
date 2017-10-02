using System;
using System.ComponentModel;
using System.Data;
using System.Reflection;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class ExamenRecord : RecordBase
	{
		#region Attributes

		private long _oid_promocion;
		private long _oid_profesor;
		private long _oid_modulo;
		private DateTime _fecha_examen;
		private DateTime _fecha_creacion;
		private DateTime _fecha_emision;
		private string _tipo = string.Empty;
		private bool _desarrollo = false;
		private string _titulo = string.Empty;
		private DateTime _duracion;
		private string _memo_preguntas = string.Empty;
		private long _numero;
  
		#endregion
		
		#region Properties
		
				public virtual long OidPromocion { get { return _oid_promocion; } set { _oid_promocion = value; } }
		public virtual long OidProfesor { get { return _oid_profesor; } set { _oid_profesor = value; } }
		public virtual long OidModulo { get { return _oid_modulo; } set { _oid_modulo = value; } }
		public virtual DateTime FechaExamen { get { return _fecha_examen; } set { _fecha_examen = value; } }
		public virtual DateTime FechaCreacion { get { return _fecha_creacion; } set { _fecha_creacion = value; } }
		public virtual DateTime FechaEmision { get { return _fecha_emision; } set { _fecha_emision = value; } }
		public virtual string Tipo { get { return _tipo; } set { _tipo = value; } }
		public virtual bool Desarrollo { get { return _desarrollo; } set { _desarrollo = value; } }
		public virtual string Titulo { get { return _titulo; } set { _titulo = value; } }
		public virtual DateTime Duracion { get { return _duracion; } set { _duracion = value; } }
		public virtual string MemoPreguntas { get { return _memo_preguntas; } set { _memo_preguntas = value; } }
		public virtual long Numero { get { return _numero; } set { _numero = value; } }

		#endregion
		
		#region Business Methods
		
		public ExamenRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_promocion = Format.DataReader.GetInt64(source, "OID_PROMOCION");
			_oid_profesor = Format.DataReader.GetInt64(source, "OID_PROFESOR");
			_oid_modulo = Format.DataReader.GetInt64(source, "OID_MODULO");
			_fecha_examen = Format.DataReader.GetDateTime(source, "FECHA_EXAMEN");
			_fecha_creacion = Format.DataReader.GetDateTime(source, "FECHA_CREACION");
			_fecha_emision = Format.DataReader.GetDateTime(source, "FECHA_EMISION");
			_tipo = Format.DataReader.GetString(source, "TIPO");
			_desarrollo = Format.DataReader.GetBool(source, "DESARROLLO");
			_titulo = Format.DataReader.GetString(source, "TITULO");
			_duracion = Format.DataReader.GetDateTime(source, "DURACION");
			_memo_preguntas = Format.DataReader.GetString(source, "MEMO_PREGUNTAS");
			_numero = Format.DataReader.GetInt64(source, "NUMERO");

		}		
		public virtual void CopyValues(ExamenRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_promocion = source.OidPromocion;
			_oid_profesor = source.OidProfesor;
			_oid_modulo = source.OidModulo;
			_fecha_examen = source.FechaExamen;
			_fecha_creacion = source.FechaCreacion;
			_fecha_emision = source.FechaEmision;
			_tipo = source.Tipo;
			_desarrollo = source.Desarrollo;
			_titulo = source.Titulo;
			_duracion = source.Duracion;
			_memo_preguntas = source.MemoPreguntas;
			_numero = source.Numero;
		}
		
		#endregion	
	}

    [Serializable()]
	public class ExamenBase 
	{	 
		#region Attributes
		
		private ExamenRecord _record = new ExamenRecord();

        //NO ENLAZADAS
        protected string _promocion = string.Empty;
        protected string _instructor = string.Empty;
        protected string _modulo = string.Empty;
		
		#endregion
		
		#region Properties
		
		public ExamenRecord Record { get { return _record; } }

        //NO ENLAZADAS
        public virtual string Modulo { get { return _modulo; } set { _modulo = value; } }
        public virtual string Promocion { get { return _promocion; } set { _promocion = value; } }
        public virtual string Instructor { get { return _instructor; } set { _instructor = value; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);

                _instructor = Format.DataReader.GetString(source, "INSTRUCTOR");
                _modulo = Format.DataReader.GetString(source, "MODULO");
                _promocion = Format.DataReader.GetString(source, "PROMOCION");
		}		
		public void CopyValues(Examen source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _modulo = source.Modulo;
            _instructor = source.Instructor;
            _promocion = source.Promocion;
		}
		public void CopyValues(ExamenInfo source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _modulo = source.Modulo;
            _instructor = source.Instructor;
            _promocion = source.Promocion;
		}
		
		#endregion	
	}
		
	/// <summary>
	/// Editable Root Business Object
	/// </summary>	
    [Serializable()]
	public class Examen : BusinessBaseEx<Examen>
	{	 
		#region Attributes
		
		protected ExamenBase _base = new ExamenBase();

        private Pregunta_Examens _preguntas = Pregunta_Examens.NewChildList();
        private PreguntaExamens _preguntaexamens = PreguntaExamens.NewChildList();
        private Alumno_Examens _alumnos = Alumno_Examens.NewChildList();
        private ExamenPromociones _promociones = ExamenPromociones.NewChildList();

		#endregion
		
		#region Properties
		
		public ExamenBase Base { get { return _base; } }
		
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
				//CanWriteProperty(true);
				if (!_base.Record.Oid.Equals(value))
				{
					_base.Record.Oid = value;
					//PropertyHasChanged();
				}
			}
		}
		public virtual long OidPromocion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidPromocion;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidPromocion.Equals(value))
				{
					_base.Record.OidPromocion = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidProfesor
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidProfesor;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidProfesor.Equals(value))
				{
					_base.Record.OidProfesor = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidModulo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidModulo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidModulo.Equals(value))
				{
					_base.Record.OidModulo = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual DateTime FechaExamen
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.FechaExamen;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.FechaExamen.Equals(value))
				{
					_base.Record.FechaExamen = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual DateTime FechaCreacion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.FechaCreacion;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.FechaCreacion.Equals(value))
				{
					_base.Record.FechaCreacion = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual DateTime FechaEmision
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.FechaEmision;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.FechaEmision.Equals(value))
				{
					_base.Record.FechaEmision = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Tipo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Tipo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Tipo.Equals(value))
				{
					_base.Record.Tipo = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool Desarrollo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Desarrollo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Desarrollo.Equals(value))
				{
					_base.Record.Desarrollo = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Titulo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Titulo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Titulo.Equals(value))
				{
					_base.Record.Titulo = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual DateTime Duracion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Duracion;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Duracion.Equals(value))
				{
					_base.Record.Duracion = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string MemoPreguntas
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.MemoPreguntas;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.MemoPreguntas.Equals(value))
				{
					_base.Record.MemoPreguntas = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long Numero
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Numero;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Numero.Equals(value))
				{
					_base.Record.Numero = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual Pregunta_Examens Pregunta_Examens
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _preguntas;
            }

            set
            {
                _preguntas = value;
            }
        }
        public virtual PreguntaExamens PreguntaExamens
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _preguntaexamens;
            }

            set
            {
                _preguntaexamens = value;
            }
        }
        public virtual Alumno_Examens Alumnos
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _alumnos;
            }

            set
            {
                _alumnos = value;
            }
        }
        public virtual ExamenPromociones Promociones
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _promociones;
            }

            set
            {
                _promociones = value;
            }
        }

        //NO ENLAZADAS
        public virtual string Modulo { get { return _base.Modulo; } set { _base.Modulo = value; } }
        public virtual string Promocion { get { return _base.Promocion; } set { _base.Promocion = value; } }
        public virtual string Instructor { get { return _base.Instructor; } set { _base.Instructor = value; } }

        public override bool IsValid
        {
            get { return base.IsValid && _preguntas.IsValid && _preguntaexamens.IsValid && _alumnos.IsValid && _promociones.IsValid; }
        }
        //Para añadir una lista: || _lista.IsDirty
        public override bool IsDirty
        {
            get { return base.IsDirty || _preguntas.IsDirty || _preguntaexamens.IsDirty || _alumnos.IsDirty || _promociones.IsDirty; }
        }
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual Examen CloneAsNew()
		{
			Examen clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = Examen.OpenSession();
			Examen.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(ExamenInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidPromocion = source.OidPromocion;
			OidProfesor = source.OidProfesor;
			OidModulo = source.OidModulo;
			FechaExamen = source.FechaExamen;
			FechaCreacion = source.FechaCreacion;
			FechaEmision = source.FechaEmision;
			Tipo = source.Tipo;
			Desarrollo = source.Desarrollo;
			Titulo = source.Titulo;
			Duracion = source.Duracion;
			MemoPreguntas = source.MemoPreguntas;
			Numero = source.Numero;
		}
        
        /// <summary>
        /// Devuelve el siguiente Numero de Examen
        /// </summary>
        /// <returns>Código de 9 cifras</returns>
        private static Int64 GetNewSerial()
        {
            // Obtenemos la lista de clientes ordenados por numero
            SortedBindingList<ExamenInfo> examenes =
                ExamenList.GetSortedList("Numero", ListSortDirection.Ascending);

            // Obtenemos el último serial de servicio
            Int64 lastcode;

            if (examenes.Count > 0)
                lastcode = examenes[examenes.Count - 1].Numero;
            else
                lastcode = 0;

            lastcode++;
            return lastcode;
        }

        public static Examen Duplicate(long oid)
        {
            ExamenInfo old = ExamenInfo.Get(oid, true);

            Examen item = Examen.New();
            
            item.FechaExamen = DateTime.Today;
            item.FechaCreacion = DateTime.Today;
            item.FechaEmision = DateTime.MaxValue;
            item.OidPromocion = old.OidPromocion;
            item.Promocion = old.Promocion;
            item.OidProfesor = old.OidProfesor;
            item.Instructor = old.Instructor;
            item.OidModulo = old.OidModulo;
            item.Modulo = old.Modulo;
            item.Tipo = old.Tipo;
            item.Desarrollo = old.Desarrollo;
            item.Titulo = old.Titulo + "_COPIA";
            item.Duracion = old.Duracion;
            item.MemoPreguntas = old.MemoPreguntas;

            item.Promociones = ExamenPromociones.NewChildList();

            foreach (ExamenPromocionInfo ep in old.Promociones)
            {
                ExamenPromocion nuevo = item.Promociones.NewItem(item);
                nuevo.OidPromocion = ep.OidPromocion;
            }
                        
            return item;
        }

        public bool DuplicateList(long oid)
        {
            ExamenInfo old = ExamenInfo.Get(oid, true);
            bool no_disponibles = false;
            if (old.Emitido)
            {
                MemoPreguntas = string.Empty;

                PreguntaList preguntas = PreguntaList.GetPreguntasModulo(_base.Record.OidModulo);
                foreach (PreguntaExamenInfo pe in old.PreguntaExamenes)
                {
                    PreguntaInfo pregunta = preguntas.GetItem(pe.OidPregunta);
                    if (pregunta.FechaDisponibilidad.Date <= _base.Record.FechaExamen)
                        MemoPreguntas += pe.OidPregunta.ToString() + ";";
                    else
                        no_disponibles = true;
                }
            }

            return no_disponibles;
        }


		
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidModulo", 1));
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

        #region Common Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        protected Examen() { }

        public virtual ExamenInfo GetInfo(bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new ExamenInfo(this, get_childs);
        }

        public virtual ExamenInfo GetInfo()
        {
            return GetInfo(true);
        }

        #endregion

        #region Root Factory Methods

        public static Examen New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<Examen>(new CriteriaCs(-1));
        }

        public static Examen Get(long oid, bool childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = Examen.GetCriteria(Examen.OpenSession());
            criteria.Childs = childs;

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = Examen.SELECT(oid);
            else
                criteria.AddOidSearch(oid);

            Examen.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Examen>(criteria);
        }

        public static Examen Get(long oid)
        {
            return Get(oid, true);
        }

        public static Examen Get(CriteriaEx criteria)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Examen.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Examen>(criteria);
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
        /// Elimina todas los Examens
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = Examen.OpenSession();
            ISession sess = Examen.Session(sessCode);
            ITransaction trans = Examen.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from Examen");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                Examen.CloseSession(sessCode);
            }
        }

        public override Examen Save()
        {
            // Por interfaz Root/Child
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

                _preguntas.Update(this);
                _preguntaexamens.Update(this);
                _alumnos.Update(this);
                _promociones.Update(this);

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

        #region Child Factory Methods

        private Examen(Examen source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private Examen(IDataReader reader, bool childs)
        {
            MarkAsChild();
            Childs = childs;
            Fetch(reader);
        }

        //public static Examen NewChild(Promocion parent)
        //{
        //    if (!CanAddObject())
        //        throw new System.Security.SecurityException(
        //            moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

        //    Examen obj = new Examen();
        //    obj.OidPromocion = parent.Oid;
        //    return obj;
        //}

        public static Examen NewChild(Instructor parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Examen obj = new Examen();
            obj.OidProfesor = parent.Oid;
            return obj;
        }

        //public static Examen NewChild(Modulo parent)
        //{
        //    if (!CanAddObject())
        //        throw new System.Security.SecurityException(
        //            moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

        //    Examen obj = new Examen();
        //    obj.OidModulo = parent.Oid;
        //    return obj;
        //}

        internal static Examen GetChild(Examen source)
        {
            return new Examen(source);
        }

        internal static Examen GetChild(IDataReader reader, bool childs)
        {
            return new Examen(reader, childs);
        }
        
        internal static Examen GetChild(IDataReader reader)
        {
            return GetChild(reader, true);
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

        #endregion

        #region Common Data Access

        [RunLocal()]
        private void DataPortal_Create(CriteriaCs criteria)
        {
            Random r = new Random();
            Oid = (long)r.Next();
        }

        #endregion

        #region Child Data Access

        private void Fetch(Examen source)
        {
            try
            {
                SessionCode = source.SessionCode;

                _base.CopyValues(source);

                CriteriaEx criteria = Pregunta_Examen.GetCriteria(Session());
                criteria.AddEq("OidExamen", this.Oid);
                _preguntas = Pregunta_Examens.GetChildList(criteria.List<Pregunta_Examen>());

                criteria = PreguntaExamen.GetCriteria(Session());
                criteria.AddEq("OidExamen", this.Oid);
                _preguntaexamens = PreguntaExamens.GetChildList(criteria.List<PreguntaExamen>());

                criteria = Alumno_Examen.GetCriteria(Session());
                criteria.AddEq("OidExamen", this.Oid);
                _alumnos = Alumno_Examens.GetChildList(criteria.List<Alumno_Examen>());

                criteria = ExamenPromocion.GetCriteria(Session());
                criteria.AddEq("OidExamen", this.Oid);
                _promociones = ExamenPromociones.GetChildList(criteria.List<ExamenPromocion>());


            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

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


        //internal void Insert(Promocion parent)
        //{
        //    // if we're not dirty then don't update the database
        //    if (!this.IsDirty) return;

        //    //Debe obtener la sesion del padre pq el objeto es padre a su vez
        //    SessionCode = parent.SessionCode;

        //    _oid_promocion = parent.Oid;

        //    try
        //    {
        //        ValidationRules.CheckRules();

        //        if (!IsValid)
        //            throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

        //        parent.Session().Save(this);

        //        _preguntas.Update(this);
        //        _preguntaexamens.Update(this);
        //        _alumnos.Update(this);
        //    }
        //    catch (Exception ex)
        //    {
        //        iQExceptionHandler.TreatException(ex);
        //    }

        //    MarkOld();
        //}

        //internal void Update(Promocion parent)
        //{
        //    // if we're not dirty then don't update the database
        //    if (!this.IsDirty) return;

        //    //Debe obtener la sesion del padre pq el objeto es padre a su vez
        //    SessionCode = parent.SessionCode;

        //    _oid_promocion = parent.Oid;

        //    try
        //    {
        //        ValidationRules.CheckRules();

        //        if (!IsValid)
        //            throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

        //        Examen obj = parent.Session().Get<Examen>(Oid);
        //        obj.CopyValues(this);
        //        parent.Session().Update(obj);

        //        _preguntas.Update(this);
        //        _preguntaexamens.Update(this);
        //        _alumnos.Update(this);
        //    }
        //    catch (Exception ex)
        //    {
        //        iQExceptionHandler.TreatException(ex);
        //    }

        //    MarkOld();
        //}


        //internal void DeleteSelf(Promocion parent)
        //{
        //    // if we're not dirty then don't update the database
        //    if (!this.IsDirty) return;

        //    // if we're new then don't update the database
        //    if (this.IsNew) return;

        //    try
        //    {
        //        SessionCode = parent.SessionCode;
        //        Session().Delete(Session().Get<Examen>(Oid));
        //    }
        //    catch (Exception ex)
        //    {
        //        iQExceptionHandler.TreatException(ex);
        //    }

        //    MarkNew();
        //}

        internal void Insert(Instructor parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidProfesor = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                parent.Session().Save(this.Base.Record);

                _preguntas.Update(this);
                _preguntaexamens.Update(this);
                _alumnos.Update(this);
                _promociones.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Update(Instructor parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidProfesor = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                ExamenRecord obj = parent.Session().Get<ExamenRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);

                _preguntas.Update(this);
                _preguntaexamens.Update(this);
                _alumnos.Update(this); 
                _promociones.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }


        internal void DeleteSelf(Instructor parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                SessionCode = parent.SessionCode;
                Session().Delete(Session().Get<ExamenRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }

        //internal void Insert(Modulo parent)
        //{
        //    // if we're not dirty then don't update the database
        //    if (!this.IsDirty) return;

        //    //Debe obtener la sesion del padre pq el objeto es padre a su vez
        //    SessionCode = parent.SessionCode;

        //    _oid_modulo = parent.Oid;

        //    try
        //    {
        //        ValidationRules.CheckRules();

        //        if (!IsValid)
        //            throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

        //        parent.Session().Save(this);

        //        _preguntas.Update(this);
        //        _preguntaexamens.Update(this);
        //        _alumnos.Update(this);
        //    }
        //    catch (Exception ex)
        //    {
        //        iQExceptionHandler.TreatException(ex);
        //    }

        //    MarkOld();
        //}

        //internal void Update(Modulo parent)
        //{
        //    // if we're not dirty then don't update the database
        //    if (!this.IsDirty) return;

        //    //Debe obtener la sesion del padre pq el objeto es padre a su vez
        //    SessionCode = parent.SessionCode;

        //    _oid_modulo = parent.Oid;

        //    try
        //    {
        //        ValidationRules.CheckRules();

        //        if (!IsValid)
        //            throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

        //        Examen obj = parent.Session().Get<Examen>(Oid);
        //        obj.CopyValues(this);
        //        parent.Session().Update(obj);

        //        _preguntas.Update(this);
        //        _preguntaexamens.Update(this);
        //        _alumnos.Update(this);
        //    }
        //    catch (Exception ex)
        //    {
        //        iQExceptionHandler.TreatException(ex);
        //    }

        //    MarkOld();
        //}


        //internal void DeleteSelf(Modulo parent)
        //{
        //    // if we're not dirty then don't update the database
        //    if (!this.IsDirty) return;

        //    // if we're new then don't update the database
        //    if (this.IsNew) return;

        //    try
        //    {
        //        SessionCode = parent.SessionCode;
        //        Session().Delete(Session().Get<Examen>(Oid));
        //    }
        //    catch (Exception ex)
        //    {
        //        iQExceptionHandler.TreatException(ex);
        //    }

        //    MarkNew();
        //}

        #endregion

        #region Root Data Access

        // called to retrieve data from the database
        private void DataPortal_Fetch(CriteriaEx criteria)
        {
            try
            {
                SessionCode = criteria.SessionCode;

                Childs = criteria.Childs;

                if (nHMng.UseDirectSQL)
                {
                    Examen.DoLOCK(Session());
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(criteria.Query, Session());

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        Pregunta_Examen.DoLOCK(Session());

                        string query = Pregunta_Examens.SELECT_BY_EXAMEN(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _preguntas = Pregunta_Examens.GetChildList(reader);

                        PreguntaExamen.DoLOCK(Session());

                        query = PreguntaExamens.SELECT_BY_EXAMEN(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _preguntaexamens = PreguntaExamens.GetChildList(criteria.SessionCode, reader);

                        Alumno_Examen.DoLOCK(Session());

                        query = Alumno_Examens.SELECT(GetInfo(false));
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _alumnos = Alumno_Examens.GetChildList(criteria.SessionCode, reader);

                        ExamenPromocion.DoLOCK(Session());

                        query = ExamenPromociones.SELECT(this);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _promociones = ExamenPromociones.GetChildList(criteria.SessionCode, reader);
                    }
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
                Numero = GetNewSerial();
                Session().Save(this.Base.Record);
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
                    ExamenRecord obj = Session().Get<ExamenRecord>(Oid);
                    obj.CopyValues(this.Base.Record);
                    Session().Update(obj);
                }
                catch (Exception ex)
                {
                    iQExceptionHandler.TreatException(ex);
                }
            }
        }

        // deferred deletion
        [Transactional(TransactionalTypes.Manual)]
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new CriteriaCs(Oid));
        }

        // inmediate deletion
        [Transactional(TransactionalTypes.Manual)]
        private void DataPortal_Delete(CriteriaCs criterio)
        {
            try
            {
                //Iniciamos la conexion y la transaccion
                SessionCode = OpenSession();
                BeginTransaction();

                CriteriaEx criteria = GetCriteria();
                criteria.AddOidSearch(criterio.Oid);

                // Obtenemos el objeto
                ExamenRecord obj = (ExamenRecord)(criteria.UniqueResult());
                Session().Delete(Session().Get<ExamenRecord>(obj.Oid));

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

        #region SQL

        internal static string SELECT_FIELDS()
        {
            string query;

            query = "SELECT E.*," +
                    "       (EM.\"APELLIDOS\" || ', ' || EM.\"NOMBRE_PROPIO\") AS \"INSTRUCTOR\"," +
                    "       (M.\"NUMERO_MODULO\" || ' ' || M.\"TEXTO\") AS \"MODULO\"," +
                    "       COALESCE(P.\"NOMBRE\", 'ATCs') AS \"PROMOCION\"";

            return query;
        }

        internal static string SELECT(long oid, bool lock_table)
        {
            string e = nHManager.Instance.GetSQLTable(typeof(ExamenRecord));
            string m = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string em = nHManager.Instance.GetSQLTable(typeof(InstructorRecord));
            string p = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));

            string query;

            query = SELECT_FIELDS() +
                    " FROM " + e + " AS E" +
                    " INNER JOIN " + m + " AS M ON E.\"OID_MODULO\" = M.\"OID\"" +
                    " LEFT JOIN " + em + " AS EM ON E.\"OID_PROFESOR\" = EM.\"OID\"" +
                    " LEFT JOIN " + p + " AS P ON E.\"OID_PROMOCION\" = P.\"OID\"";

            if (oid > 0)
                query += " WHERE E.\"OID\" = " + oid.ToString();

            if (lock_table) query += " FOR UPDATE OF E NOWAIT";

            return query;
        }

        internal new static string SELECT(long oid) { return SELECT(oid, true); }

        #endregion
    }
}

