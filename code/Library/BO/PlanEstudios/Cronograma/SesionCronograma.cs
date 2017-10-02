using System;
using System.ComponentModel;
using System.Data;
using System.Collections.Generic;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;

using moleQule.Library;

using NHibernate;
using System.Reflection;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class SesionCronogramaRecord : RecordBase
	{
		#region Attributes

		private long _oid_cronograma;
		private long _oid_clase_teorica;
		private long _oid_clase_practica;
		private long _semana;
		private long _dia;
		private long _turno;
		private long _numero;
		private string _texto = string.Empty;
        private DateTime _fecha;
        private DateTime _hora;
  
		#endregion
		
		#region Properties
		
		public virtual long OidCronograma { get { return _oid_cronograma; } set { _oid_cronograma = value; } }
		public virtual long OidClaseTeorica { get { return _oid_clase_teorica; } set { _oid_clase_teorica = value; } }
		public virtual long OidClasePractica { get { return _oid_clase_practica; } set { _oid_clase_practica = value; } }
		public virtual long Semana { get { return _semana; } set { _semana = value; } }
		public virtual long Dia { get { return _dia; } set { _dia = value; } }
		public virtual long Turno { get { return _turno; } set { _turno = value; } }
		public virtual long Numero { get { return _numero; } set { _numero = value; } }
		public virtual string Texto { get { return _texto; } set { _texto = value; } }
        public virtual DateTime Fecha { get { return _fecha; } set { _fecha = value; } }
        public virtual DateTime Hora { get { return _hora; } set { _hora = value; } }

		#endregion
		
		#region Business Methods
		
		public SesionCronogramaRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_cronograma = Format.DataReader.GetInt64(source, "OID_CRONOGRAMA");
			_oid_clase_teorica = Format.DataReader.GetInt64(source, "OID_CLASE_TEORICA");
			_oid_clase_practica = Format.DataReader.GetInt64(source, "OID_CLASE_PRACTICA");
			_semana = Format.DataReader.GetInt64(source, "SEMANA");
			_dia = Format.DataReader.GetInt64(source, "DIA");
			_turno = Format.DataReader.GetInt64(source, "TURNO");
			_numero = Format.DataReader.GetInt64(source, "NUMERO");
			_texto = Format.DataReader.GetString(source, "TEXTO");
            _fecha = Format.DataReader.GetDateTime(source, "FECHA");
            _hora = Format.DataReader.GetDateTime(source, "HORA");

		}		
		public virtual void CopyValues(SesionCronogramaRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_cronograma = source.OidCronograma;
			_oid_clase_teorica = source.OidClaseTeorica;
			_oid_clase_practica = source.OidClasePractica;
			_semana = source.Semana;
			_dia = source.Dia;
			_turno = source.Turno;
			_numero = source.Numero;
			_texto = source.Texto;
            _fecha = source.Fecha;
            _hora = source.Hora;
		}
		
		#endregion	
	}

    [Serializable()]
	public class SesionCronogramaBase 
	{	 
		#region Attributes
		
		private SesionCronogramaRecord _record = new SesionCronogramaRecord();
        
        //atributos auxiliares
        private string _clase = string.Empty;
        private string _modulo = string.Empty;
        private string _duracion = string.Empty;
		
		#endregion
		
		#region Properties
		
		public SesionCronogramaRecord Record { get { return _record; } }

        public virtual string Clase { get { return _clase; } set { _clase = value; } }
        public virtual string Modulo { get { return _modulo; } set { _modulo = value; } }
        public virtual string Duracion { get { return _duracion; } set { _duracion = value; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);

            _clase = source["CLASE"].ToString();
            _modulo = source["MODULO"].ToString();
            _duracion = source["DURACION"].ToString();
		}		
		public void CopyValues(SesionCronograma source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _clase = source.Clase;
            _modulo = source.Modulo;
            _duracion = source.Duracion;
		}
		public void CopyValues(SesionCronogramaInfo source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _clase = source.Clase;
            _modulo = source.Modulo;
            _duracion = source.Duracion;
		}
		
		#endregion	
	}
		
	/// <summary>
	/// Editable Root Business Object
	/// </summary>	
    [Serializable()]
	public class SesionCronograma : BusinessBaseEx<SesionCronograma>
	{	 
		#region Attributes

        protected string _submodulo = string.Empty;
        protected string _titulo = string.Empty;
        protected string _alias = string.Empty;
        protected ETipoClase _tipo;
        private long _orden_primario = 0;
        private long _orden_secundario = 0;
        private long _orden_terciario = 0;
        private long _incompatible;
        private long _grupo = 3;
		
		protected SesionCronogramaBase _base = new SesionCronogramaBase();
		

		#endregion
		
		#region Properties
		
		public SesionCronogramaBase Base { get { return _base; } }
		
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
		public virtual long OidCronograma
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidCronograma;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidCronograma.Equals(value))
				{
					_base.Record.OidCronograma = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidClaseTeorica
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidClaseTeorica;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidClaseTeorica.Equals(value))
				{
					_base.Record.OidClaseTeorica = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidClasePractica
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidClasePractica;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidClasePractica.Equals(value))
				{
					_base.Record.OidClasePractica = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long Semana
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Semana;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Semana.Equals(value))
				{
					_base.Record.Semana = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long Dia
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Dia;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Dia.Equals(value))
				{
					_base.Record.Dia = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long Turno
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Turno;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Turno.Equals(value))
				{
					_base.Record.Turno = value;
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
		public virtual string Texto
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Texto;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Texto.Equals(value))
				{
					_base.Record.Texto = value;
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
                //CanWriteProperty(true);

                if (!_base.Record.Fecha.Equals(value))
                {
                    _base.Record.Fecha = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual DateTime Hora
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.Hora;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //CanWriteProperty(true);

                if (!_base.Record.Hora.Equals(value))
                {
                    _base.Record.Hora = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Clase { get { return _base.Clase; } set { _base.Clase = value; } }
        public virtual string Modulo { get { return _base.Modulo; } set { _base.Modulo = value; } }
        public virtual string Duracion { get { return _base.Duracion; } set { _base.Duracion = value; } }
        public virtual string Submodulo { get { return _submodulo; } set { _submodulo = value; } }
        public virtual string Titulo { get { return _titulo; } set { _titulo = value; } }
        public virtual string Alias { get { return _alias; } set { _alias = value; } }
        public virtual ETipoClase ETipoClase { get { return _tipo; } set { _tipo = value; } }
        public virtual string Tipo { get { return Library.Instruction.EnumText<ETipoClase>.GetLabel(ETipoClase); } }
        public virtual long OrdenPrimario { get { return _orden_primario; } set { _orden_primario = value; } }
        public virtual long OrdenSecundario { get { return _orden_secundario; } set { _orden_secundario = value; } }
        public virtual long OrdenTerciario { get { return _orden_terciario; } set { _orden_terciario = value; } }
        public virtual long Grupo { get { return _grupo; } set { _grupo = value; } }
        public virtual long Incompatible { get { return _incompatible; } set { _incompatible = value; } }
        public virtual string FechaLabel { get { return _base.Record.Fecha.ToString("dd/MM/yyyy"); } }
        public virtual string HoraLabel { get { return _base.Record.Hora.ToString("HH:mm"); } }
		
		#endregion
		
		#region Business Methods
		
		public virtual SesionCronograma CloneAsNew()
		{
			SesionCronograma clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = SesionCronograma.OpenSession();
			SesionCronograma.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(SesionCronogramaInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidCronograma = source.OidCronograma;
			OidClaseTeorica = source.OidClaseTeorica;
			OidClasePractica = source.OidClasePractica;
			Semana = source.Semana;
			Dia = source.Dia;
			Turno = source.Turno;
			Numero = source.Numero;
			Texto = source.Texto;
            Fecha = source.Fecha;
            Hora = source.Hora;
		}
		
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidCronograma", 1));

            //SOLO UNO DE LOS TRES TIENE QUE SER MAYOR QUE 0

            //ValidationRules.AddRule(CommonRules.MinValue<long>,
            //new CommonRules.MinValueRuleArgs<long>("OidClaseTeorica", 1));

            //ValidationRules.AddRule(CommonRules.MinValue<long>,
            //new CommonRules.MinValueRuleArgs<long>("OidClasePractica", 1));
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
        	protected SesionCronograma() 
            {
            }

        public virtual SesionCronogramaInfo GetInfo(bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new SesionCronogramaInfo(this);
        }

        public virtual SesionCronogramaInfo GetInfo()
        {
            return GetInfo(true);
        }

        #endregion

        #region Root Factory Methods

        public static SesionCronograma New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<SesionCronograma>(new CriteriaCs(-1));
        }

        public static SesionCronograma Get(long oid)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = SesionCronograma.GetCriteria(SesionCronograma.OpenSession());
            criteria.AddOidSearch(oid);
            SesionCronograma.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<SesionCronograma>(criteria);
        }

        public static SesionCronograma Get(CriteriaEx criteria)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            SesionCronograma.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<SesionCronograma>(criteria);
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
        /// Elimina todas los SesionCronogramas
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = SesionCronograma.OpenSession();
            ISession sess = SesionCronograma.Session(sessCode);
            ITransaction trans = SesionCronograma.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from SesionCronograma");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                SesionCronograma.CloseSession(sessCode);
            }
        }

        public override SesionCronograma Save()
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

                //_asistencias.Update(this);

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

        public SesionCronograma(SesionCronograma source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private SesionCronograma(IDataReader reader, bool childs)
        {
            MarkAsChild();
            Childs = childs;
            Fetch(reader);
        }

        public static SesionCronograma NewChild(Cronograma parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            SesionCronograma obj = new SesionCronograma();
            obj.OidCronograma = parent.Oid;
            return obj;
        }

        public static SesionCronograma NewChild(ClaseTeorica parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            SesionCronograma obj = new SesionCronograma();
            obj.OidClaseTeorica = parent.Oid;
            return obj;
        }

        public static SesionCronograma NewChild(ClasePractica parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            SesionCronograma obj = new SesionCronograma();
            obj.OidClasePractica = parent.Oid;
            return obj;
        }

        internal static SesionCronograma GetChild(SesionCronograma source)
        {
            return new SesionCronograma(source);
        }

        internal static SesionCronograma GetChild(IDataReader reader, bool childs)
        {
            return new SesionCronograma(reader, childs);
        }


        internal static SesionCronograma GetChild(IDataReader reader)
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

        private void Fetch(SesionCronograma source)
        {
            try
            {
                SessionCode = source.SessionCode;

                _base.CopyValues(source);

                //CriteriaEx criteria = ParteAsistencia.GetCriteria(Session());
                //criteria.AddEq("OidSesionCronograma", this.Oid);
                //_asistencias = ParteAsistencias.GetChildList(criteria.List<ParteAsistencia>());


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


        internal void Insert(Cronograma parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la SesionCronograma del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidCronograma = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                parent.Session().Save(this.Base.Record);

                //_asistencias.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Update(Cronograma parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la SesionCronograma del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidCronograma = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                SesionCronogramaRecord obj = parent.Session().Get<SesionCronogramaRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);

                //_asistencias.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }


        internal void DeleteSelf(Cronograma parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                SessionCode = parent.SessionCode;
                Session().Delete(Session().Get<SesionCronogramaRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }

        internal void Insert(ClaseTeorica parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la SesionCronograma del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidClaseTeorica = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                parent.Session().Save(this.Base.Record);

                //_asistencias.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Update(ClaseTeorica parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la SesionCronograma del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidClaseTeorica = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                SesionCronogramaRecord obj = parent.Session().Get<SesionCronogramaRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);

                //_asistencias.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }


        internal void DeleteSelf(ClaseTeorica parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                SessionCode = parent.SessionCode;
                Session().Delete(Session().Get<SesionCronogramaRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }

        internal void Insert(ClasePractica parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la SesionCronograma del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidClasePractica = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                parent.Session().Save(this.Base.Record);

                //_asistencias.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Update(ClasePractica parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la SesionCronograma del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidClasePractica = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                SesionCronogramaRecord obj = parent.Session().Get<SesionCronogramaRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);

                //_asistencias.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }


        internal void DeleteSelf(ClasePractica parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                SessionCode = parent.SessionCode;
                Session().Delete(Session().Get<SesionCronogramaRecord>(Oid));
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

					SesionCronograma.DoLOCK( Session());

                    IDataReader reader = SesionCronograma.DoSELECT(AppContext.ActiveSchema.Code, Session(), criteria.Oid);

                    if (reader.Read())
                        _base.CopyValues(reader);
                }
                else
                {
                    _base.Record.CopyValues((SesionCronogramaRecord)(criteria.UniqueResult()));

                    //Session().Lock(Session().Get<SesionCronogramaRecord>(Oid), LockMode.UpgradeNoWait);
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
                    SesionCronogramaRecord obj = Session().Get<SesionCronogramaRecord>(Oid);
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
                SesionCronogramaRecord obj = (SesionCronogramaRecord)(criteria.UniqueResult());
                Session().Delete(Session().Get<SesionCronogramaRecord>(obj.Oid));

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

        #region SQL

        internal static string SELECT_FIELDS()
        {
            string query;

            query = "SELECT SC.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string sc = nHManager.Instance.GetSQLTable(typeof(SesionCronogramaRecord));

            query = "   FROM   " + sc + "   AS SC";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.Cronograma != null && conditions.Cronograma.Oid > 0)
                query += " AND SC.\"OID_CRONOGRAMA\" = " + conditions.Cronograma.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions);

            if (lockTable) query += " FOR UPDATE OF SC NOWAIT";

            return query;
        }
        
        #endregion

    }
}

