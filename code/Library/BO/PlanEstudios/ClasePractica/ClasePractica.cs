using System;
using System.ComponentModel;
using System.Data;

using Csla;
using Csla.Validation;  
using moleQule.Library.CslaEx;

using moleQule.Library;

using NHibernate;
using System.Reflection;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class ClasePracticaRecord : RecordBase
	{
		#region Attributes

		private long _oid_plan;
		private long _oid_modulo;
		private long _oid_submodulo;
		private long _orden_primario;
		private long _orden_secundario;
		private string _titulo = string.Empty;
		private string _observaciones = string.Empty;
		private long _orden_terciario;
		private string _alias = string.Empty;
		private long _incompatible;
		private long _total_clases;
		private long _duracion;
  
		#endregion
		
		#region Properties
		
				public virtual long OidPlan { get { return _oid_plan; } set { _oid_plan = value; } }
		public virtual long OidModulo { get { return _oid_modulo; } set { _oid_modulo = value; } }
		public virtual long OidSubmodulo { get { return _oid_submodulo; } set { _oid_submodulo = value; } }
		public virtual long OrdenPrimario { get { return _orden_primario; } set { _orden_primario = value; } }
		public virtual long OrdenSecundario { get { return _orden_secundario; } set { _orden_secundario = value; } }
		public virtual string Titulo { get { return _titulo; } set { _titulo = value; } }
		public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
		public virtual long OrdenTerciario { get { return _orden_terciario; } set { _orden_terciario = value; } }
		public virtual string Alias { get { return _alias; } set { _alias = value; } }
		public virtual long Incompatible { get { return _incompatible; } set { _incompatible = value; } }
		public virtual long TotalClases { get { return _total_clases; } set { _total_clases = value; } }
		public virtual long Duracion { get { return _duracion; } set { _duracion = value; } }

		#endregion
		
		#region Business Methods
		
		public ClasePracticaRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_plan = Format.DataReader.GetInt64(source, "OID_PLAN");
			_oid_modulo = Format.DataReader.GetInt64(source, "OID_MODULO");
			_oid_submodulo = Format.DataReader.GetInt64(source, "OID_SUBMODULO");
			_orden_primario = Format.DataReader.GetInt64(source, "ORDEN_PRIMARIO");
			_orden_secundario = Format.DataReader.GetInt64(source, "ORDEN_SECUNDARIO");
			_titulo = Format.DataReader.GetString(source, "TITULO");
			_observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");
			_orden_terciario = Format.DataReader.GetInt64(source, "ORDEN_TERCIARIO");
			_alias = Format.DataReader.GetString(source, "ALIAS");
			_incompatible = Format.DataReader.GetInt64(source, "INCOMPATIBLE");
			_total_clases = Format.DataReader.GetInt64(source, "TOTAL_CLASES");
			_duracion = Format.DataReader.GetInt64(source, "DURACION");

		}		
		public virtual void CopyValues(ClasePracticaRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_plan = source.OidPlan;
			_oid_modulo = source.OidModulo;
			_oid_submodulo = source.OidSubmodulo;
			_orden_primario = source.OrdenPrimario;
			_orden_secundario = source.OrdenSecundario;
			_titulo = source.Titulo;
			_observaciones = source.Observaciones;
			_orden_terciario = source.OrdenTerciario;
			_alias = source.Alias;
			_incompatible = source.Incompatible;
			_total_clases = source.TotalClases;
			_duracion = source.Duracion;
		}
		
		#endregion	
	}

    [Serializable()]
	public class ClasePracticaBase 
	{	 
		#region Attributes
		
		private ClasePracticaRecord _record = new ClasePracticaRecord();
        
        // Atributos auxiliares
        string _modulo = string.Empty;
        string _submodulo = string.Empty;
        string _codigo_orden = string.Empty;
        long _estado;
        long _grupo;
        string _instructor = string.Empty;
        DateTime _fecha;
        DateTime _hora;
        long _total_modulo;
        long _total_submodulo;
        long _tipo = 1;
		
		#endregion
		
		#region Properties
		
		public ClasePracticaRecord Record { get { return _record; } }

        public string Modulo { get { return _modulo; } set { _modulo = value; } }
        public string Submodulo { get { return _submodulo; } set { _submodulo = value; } }
        public string CodigoOrden { get { return _codigo_orden; } }
        //Está definido el ser porque es necesario modificarlo en lógica de negocio
        //pero nunca se modifica en la base de datos
        public long Estado { get { return _estado; } set { _estado = value; } }
        public long Grupo { get { return _grupo; } set { _grupo = value; } }
        public virtual EEstadoClase EEstadoClase { get { return (EEstadoClase)_estado; } set{_estado = (long)value;}}
        public virtual string Instructor { get { return _instructor; } }
        public virtual DateTime Fecha { get { return _fecha; } }
        public virtual DateTime Hora { get { return _hora; } }
        public virtual long TotalModulo { get { return _total_modulo; } }
        public virtual long TotalSubmodulo { get { return _total_submodulo; } }
        public virtual long Tipo { get { return _tipo; } }
        		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
            
            _modulo = Format.DataReader.GetString(source, "MODULO");
            _submodulo = Format.DataReader.GetString(source, "SUBMODULO");
            _codigo_orden = Format.DataReader.GetString(source, "CODIGO_ORDEN") + "." + _record.OrdenTerciario.ToString("000");
            _estado = Format.DataReader.GetInt32(source, "ESTADO");
            _grupo = Format.DataReader.GetInt32(source, "GRUPO");
            _instructor = Format.DataReader.GetString(source, "INSTRUCTOR");
            _fecha = Format.DataReader.GetDateTime(source, "FECHA");
            _hora = Format.DataReader.GetDateTime(source, "HORA");
            _total_modulo = Format.DataReader.GetInt64(source, "COUNT_MODULO");
            _total_submodulo = Format.DataReader.GetInt64(source, "COUNT_SUBMODULO");

            long oid_merge = Format.DataReader.GetInt64(source, "OID_MERGE");
            if (oid_merge > 0)
                _record.Oid = oid_merge;
		}		
		public void CopyValues(ClasePractica source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _modulo = source.Modulo;
            _submodulo = source.Submodulo;
            _codigo_orden = source.CodigoOrden;
            _estado = source.Estado;
            _grupo = source.Grupo;
		}
		public void CopyValues(ClasePracticaInfo source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _modulo = source.Modulo;
            _submodulo = source.Submodulo;
            _codigo_orden = source.CodigoOrden;
            _estado = source.Estado;
            _grupo = source.Grupo;
		}
		
		#endregion	
	}
		
	/// <summary>
	/// Editable Root Business Object
	/// </summary>	
    [Serializable()]
	public class ClasePractica : BusinessBaseEx<ClasePractica>
	{	 
		#region Attributes
		
		protected ClasePracticaBase _base = new ClasePracticaBase();
		

		#endregion
		
		#region Properties
		
		public ClasePracticaBase Base { get { return _base; } }
		
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
		public virtual long OidPlan
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidPlan;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.OidPlan.Equals(value))
				{
					_base.Record.OidPlan = value;
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
				//////CanWriteProperty(true);
				
				if (!_base.Record.OidModulo.Equals(value))
				{
					_base.Record.OidModulo = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidSubmodulo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidSubmodulo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.OidSubmodulo.Equals(value))
				{
					_base.Record.OidSubmodulo = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OrdenPrimario
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OrdenPrimario;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.OrdenPrimario.Equals(value))
				{
					_base.Record.OrdenPrimario = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OrdenSecundario
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OrdenSecundario;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.OrdenSecundario.Equals(value))
				{
					_base.Record.OrdenSecundario = value;
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
				//////CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Titulo.Equals(value))
				{
					_base.Record.Titulo = value;
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
		public virtual long OrdenTerciario
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OrdenTerciario;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.OrdenTerciario.Equals(value))
				{
					_base.Record.OrdenTerciario = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Alias
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Alias;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Alias.Equals(value))
				{
					_base.Record.Alias = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long Incompatible
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Incompatible;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.Incompatible.Equals(value))
				{
					_base.Record.Incompatible = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long TotalClases
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.TotalClases;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.TotalClases.Equals(value))
				{
					_base.Record.TotalClases = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long Duracion
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
				//////CanWriteProperty(true);
				
				if (!_base.Record.Duracion.Equals(value))
				{
					_base.Record.Duracion = value;
					PropertyHasChanged();
				}
			}
		}	

        public virtual long Laboratorio { get { return _base.Record.Incompatible; } }

        public string Modulo { get { return _base.Modulo; } set { _base.Modulo = value; } }
        public string Submodulo { get { return _base.Submodulo; } set { _base.Submodulo = value; } }
        public string CodigoOrden { get { return _base.CodigoOrden; } }
        //Está definido el ser porque es necesario modificarlo en lógica de negocio
        //pero nunca se modifica en la base de datos
        public long Estado { get { return _base.Estado; } set { _base.Estado = value; } }
        public long Grupo { get { return _base.Grupo; } set { _base.Grupo = value; } }
        public virtual EEstadoClase EEstadoClase { get { return (EEstadoClase)_base.Estado; } set{_base.Estado = (long)value;}}
        public virtual string Instructor { get { return _base.Instructor; } }
        public virtual DateTime Fecha { get { return _base.Fecha; } }
        public virtual DateTime Hora { get { return _base.Hora; } }
        public virtual long TotalModulo { get { return _base.TotalModulo; } }
        public virtual long TotalSubmodulo { get { return _base.TotalSubmodulo; } }
        public virtual long Tipo { get { return _base.Tipo; } }
        		
		#endregion
		
		#region Business Methods
		
		public virtual ClasePractica CloneAsNew()
		{
			ClasePractica clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = ClasePractica.OpenSession();
			ClasePractica.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(ClasePracticaInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidPlan = source.OidPlan;
			OidModulo = source.OidModulo;
			OidSubmodulo = source.OidSubmodulo;
			OrdenPrimario = source.OrdenPrimario;
			OrdenSecundario = source.OrdenSecundario;
			Titulo = source.Titulo;
			Observaciones = source.Observaciones;
			OrdenTerciario = source.OrdenTerciario;
			Alias = source.Alias;
			Incompatible = source.Incompatible;
			TotalClases = source.TotalClases;
			Duracion = source.Duracion;
		}
		
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidPlan", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidModulo", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidSubmodulo", 1));

            ValidationRules.AddRule(CommonRules.MaxValue<long>,
                                    new CommonRules.MaxValueRuleArgs<long>("Incompatible", 5));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("Incompatible", 0));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OrdenPrimario", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OrdenSecundario", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OrdenTerciario", 1));

            ValidationRules.AddRule(
          Csla.Validation.CommonRules.StringRequired, "Alias");

            ValidationRules.AddRule(
           Csla.Validation.CommonRules.StringRequired, "Titulo");
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

        #region Common Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        public ClasePractica()
        {
            MarkAsChild();
            Random r = new Random();
            Oid = (long)r.Next();
        }

        public virtual ClasePracticaInfo GetInfo(bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

             return new ClasePracticaInfo(this);
        }

        public virtual ClasePracticaInfo GetInfo()
        {
            return GetInfo(true);
        }

        #endregion

        #region Root Factory Methods

        public static ClasePractica New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<ClasePractica>(new CriteriaCs(-1));
        }

        public static ClasePractica Get(long oid)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = ClasePractica.GetCriteria(ClasePractica.OpenSession());
            criteria.AddOidSearch(oid);
            ClasePractica.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<ClasePractica>(criteria);
        }

        public static ClasePractica Get(CriteriaEx criteria)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            ClasePractica.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<ClasePractica>(criteria);
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
        /// Elimina todas los ClasePracticas
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = ClasePractica.OpenSession();
            ISession sess = ClasePractica.Session(sessCode);
            ITransaction trans = ClasePractica.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from ClasePractica");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                ClasePractica.CloseSession(sessCode);
            }
        }

        public override ClasePractica Save()
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

        private ClasePractica(ClasePractica source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private ClasePractica(IDataReader reader, bool childs)
        {
            MarkAsChild();
            Childs = childs;
            Fetch(reader);
        }

        public static ClasePractica NewChild(PlanEstudios parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            ClasePractica obj = new ClasePractica();
            obj.OidPlan = parent.Oid;
            return obj;
        }

        public static ClasePractica NewChild(Modulo parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            ClasePractica obj = new ClasePractica();
            obj.OidModulo = parent.Oid;
            return obj;
        }

        public static ClasePractica NewChild(Submodulo parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            ClasePractica obj = new ClasePractica();
            obj.OidSubmodulo = parent.Oid;
            return obj;
        }

        internal static ClasePractica GetChild(ClasePractica source)
        {
            return new ClasePractica(source);
        }

        internal static ClasePractica GetChild(IDataReader reader, bool childs)
        {
            return new ClasePractica(reader, childs);
        }


        internal static ClasePractica GetChild(IDataReader reader)
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

        private void Fetch(ClasePractica source)
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


        internal void Insert(PlanEstudios parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidPlan = parent.Oid;

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

        internal void Update(PlanEstudios parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidPlan = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                ClasePracticaRecord obj = parent.Session().Get<ClasePracticaRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);

            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }


        internal void DeleteSelf(PlanEstudios parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                SessionCode = parent.SessionCode;
                Session().Delete(Session().Get<ClasePracticaRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }

        internal void Insert(Modulo parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidModulo = parent.Oid;

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

        internal void Update(Modulo parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidModulo = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                ClasePracticaRecord obj = parent.Session().Get<ClasePracticaRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);

            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }


        internal void DeleteSelf(Modulo parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                SessionCode = parent.SessionCode;
                Session().Delete(Session().Get<ClasePracticaRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }

        internal void Insert(Submodulo parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidSubmodulo = parent.Oid;

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

        internal void Update(Submodulo parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidSubmodulo = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                ClasePracticaRecord obj = parent.Session().Get<ClasePracticaRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);

            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }


        internal void DeleteSelf(Submodulo parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                SessionCode = parent.SessionCode;
                Session().Delete(Session().Get<ClasePracticaRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }

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

                    ClasePractica.DoLOCK( Session());

                    string query = SELECT(criteria.Oid);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query);

                    if (reader.Read())
                        _base.CopyValues(reader);
                }
                else
                {
                    _base.Record.CopyValues((ClasePracticaRecord)(criteria.UniqueResult()));

                    //Session().Lock(Session().Get<ClasePracticaRecord>(Oid), LockMode.UpgradeNoWait);
                }
            }
            catch (NHibernate.ADOException)
            {
                if (Transaction() != null) Transaction().Rollback();
                throw new iQLockException(moleQule.Library.Resources.Messages.LOCK_ERROR);
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
                    ClasePracticaRecord obj = Session().Get<ClasePracticaRecord>(Oid);
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
                ClasePracticaRecord obj = (ClasePracticaRecord)(criteria.UniqueResult());
                Session().Delete(Session().Get<ClasePracticaRecord>(obj.Oid));

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

        public static bool SesionExists(long oid_clase_practica)
        {
            SesionExistsCmd result;
            result = DataPortal.Execute<SesionExistsCmd>(new SesionExistsCmd(oid_clase_practica));
            return result.Exists;
        }

        [Serializable()]
        private class SesionExistsCmd : CommandBase
        {
            private long _oid_clase_practica;
            private bool _exists = false;

            public bool Exists
            {
                get { return _exists; }
            }

            public SesionExistsCmd(long oid_clase_practica)
            {
                _oid_clase_practica = oid_clase_practica;
            }

            protected override void DataPortal_Execute()
            {
                // Buscar por codigo
                CriteriaEx criteria = Sesion.GetCriteria(Sesion.OpenSession());
                criteria.AddEq("OidClasePractica", _oid_clase_practica);
                SesionList list = SesionList.GetList(criteria);
                _exists = !(list.Count == 0);
            }
        }



        #endregion

        #region SQL

        internal static string SELECT_FIELDS()
        {
            string query;

            query = "SELECT CP.*," +
                    "       (S.\"CODIGO\" || ' ' || S.\"TEXTO\") AS \"SUBMODULO\", S.\"CODIGO_ORDEN\"," +
                    "       M.\"NUMERO_MODULO\", M.\"TEXTO\" AS \"MODULO\"," +
                    "       0 AS \"GRUPO\"," +
                    "       1 AS \"ESTADO\"," +
                    "       S.\"CODIGO_ORDEN\" AS \"CODIGO_ORDEN\"," +
                    "       '' AS \"INSTRUCTOR\"," +
                    "       '1999-01-08' AS \"FECHA\"," +
                    "       '00:00:00' AS \"HORA\"," +
                    "       0 AS \"COUNT_MODULO\"," +
                    "       0 AS \"COUNT_SUBMODULO\"," +
                    "       0 AS \"OID_MERGE\"";

            return query;
        }

        public new static string SELECT(long oid)
        {
            string clase = nHManager.Instance.GetSQLTable(typeof(ClasePracticaRecord));
            string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));

            string query;

            query = SELECT_FIELDS() +
                    " FROM " + clase + " AS CP " +
                    " INNER JOIN " + submodulo + " AS S ON (CP.\"OID_SUBMODULO\" = S.\"OID\")" +
                    " INNER JOIN " + modulo + " AS M ON (CP.\"OID_MODULO\" = M.\"OID\")";

            if (oid > 0) query += " WHERE CP.\"OID\" = " + oid.ToString();

            return query;
        }

        public static string SELECT_IMPARTIDAS(long oid_promocion, DateTime fecha, long grupo, bool lockTable)
        {
            string cp = nHManager.Instance.GetSQLTable(typeof(ClasePracticaRecord));
            string s = nHManager.Instance.GetSQLTable(typeof(SesionRecord));
            string h = nHManager.Instance.GetSQLTable(typeof(HorarioRecord));
            string m = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string sm = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));

            string query = @"SELECT CP.*,
                                SM.""CODIGO"" AS ""SUBMODULO"",
                                SM.""CODIGO_ORDEN"",
                                M.""NUMERO_ORDEN"",
                                M.""TEXTO"" AS ""MODULO"",
                                S.""ESTADO"" AS ""ESTADO"",
                                '' AS ""INSTRUCTOR"",
                                S.""FECHA"" AS ""FECHA"",
                                S.""HORA"" AS ""HORA"",
                                0 AS ""COUNT_MODULO"",
                                0 AS ""COUNT_SUBMODULO"",
                                S.""GRUPO"" AS ""GRUPO"",
                                0 AS ""OID_MERGE""
                            FROM " + cp + @" AS CP
                            INNER JOIN " + s + @" AS S ON S.""OID_CLASE_PRACTICA"" = CP.""OID"" AND S.""ESTADO"" = 3
                            INNER JOIN " + h + @" AS H ON H.""OID"" = S.""OID_HORARIO""
                            INNER JOIN " + m + @" AS M ON M.""OID"" = CP.""OID_MODULO""
                            INNER JOIN " + sm + @"  AS SM ON SM.""OID"" = CP.""OID_SUBMODULO""
                            WHERE H.""OID_PROMOCION"" = " + oid_promocion.ToString() + @" AND S.""FECHA"" <= '" + fecha.ToString("yyyy/MM/dd") + @"' AND S.""GRUPO"" = " + grupo.ToString() + @"
                            ORDER BY M.""NUMERO_ORDEN"", SM.""CODIGO_ORDEN"", CP.""ORDEN_TERCIARIO""";

            if (lockTable) query += " FOR UPDATE OF CP NOWAIT";

            return query;
        }

        #endregion

    }
}

