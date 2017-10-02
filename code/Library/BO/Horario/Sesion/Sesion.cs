using System;
using System.ComponentModel;
using System.Data;
using System.Collections.Generic;
using System.Reflection;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Instruction;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class SesionRecord : RecordBase
	{
		#region Attributes

		private long _oid_horario;
		private long _oid_clase_teorica;
		private long _oid_clase_practica;
		private long _oid_clase_extra;
		private long _oid_profesor;
		private DateTime _fecha;
		private string _observaciones = string.Empty;
		private long _grupo;
		private long _estado;
		private DateTime _hora;
		private bool _forzada = false;
  
		#endregion
		
		#region Properties
		
				public virtual long OidHorario { get { return _oid_horario; } set { _oid_horario = value; } }
		public virtual long OidClaseTeorica { get { return _oid_clase_teorica; } set { _oid_clase_teorica = value; } }
		public virtual long OidClasePractica { get { return _oid_clase_practica; } set { _oid_clase_practica = value; } }
		public virtual long OidClaseExtra { get { return _oid_clase_extra; } set { _oid_clase_extra = value; } }
		public virtual long OidProfesor { get { return _oid_profesor; } set { _oid_profesor = value; } }
		public virtual DateTime Fecha { get { return _fecha; } set { _fecha = value; } }
		public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
		public virtual long Grupo { get { return _grupo; } set { _grupo = value; } }
		public virtual long Estado { get { return _estado; } set { _estado = value; } }
		public virtual DateTime Hora { get { return _hora; } set { _hora = value; } }
		public virtual bool Forzada { get { return _forzada; } set { _forzada = value; } }

		#endregion
		
		#region Business Methods
		
		public SesionRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_horario = Format.DataReader.GetInt64(source, "OID_HORARIO");
			_oid_clase_teorica = Format.DataReader.GetInt64(source, "OID_CLASE_TEORICA");
			_oid_clase_practica = Format.DataReader.GetInt64(source, "OID_CLASE_PRACTICA");
			_oid_clase_extra = Format.DataReader.GetInt64(source, "OID_CLASE_EXTRA");
			_oid_profesor = Format.DataReader.GetInt64(source, "OID_PROFESOR");
			_fecha = Format.DataReader.GetDateTime(source, "FECHA");
			_observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");
			_grupo = Format.DataReader.GetInt64(source, "GRUPO");
			_estado = Format.DataReader.GetInt64(source, "ESTADO");
			_hora = Format.DataReader.GetDateTime(source, "HORA");
            _forzada = Format.DataReader.GetBool(source, "FORZADA"); 
            
            long oid_autorizado = Format.DataReader.GetInt64(source, "OID_AUTORIZADO");
            _oid_profesor = oid_autorizado != 0 ? oid_autorizado : _oid_profesor;

		}		
		public virtual void CopyValues(SesionRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_horario = source.OidHorario;
			_oid_clase_teorica = source.OidClaseTeorica;
			_oid_clase_practica = source.OidClasePractica;
			_oid_clase_extra = source.OidClaseExtra;
			_oid_profesor = source.OidProfesor;
			_fecha = source.Fecha;
			_observaciones = source.Observaciones;
			_grupo = source.Grupo;
			_estado = source.Estado;
			_hora = source.Hora;
			_forzada = source.Forzada;
		}
		
		#endregion	
	}

    [Serializable()]
	public class SesionBase 
	{	 
		#region Attributes
		
		private SesionRecord _record = new SesionRecord();
		
		#endregion
		
		#region Properties
		
		public SesionRecord Record { get { return _record; } }

		public EEstado EStatus { get { return (EEstado)_record.Estado; } }
		public string StatusLabel { get { return Library.Common.EnumText<EEstado>.GetLabel(EStatus); } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(Sesion source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(SesionInfo source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		
		#endregion	
	}
		
	/// <summary>
	/// Editable Root Business Object
	/// </summary>	
    [Serializable()]
	public class Sesion : BusinessBaseEx<Sesion>
	{	 
		#region Attributes
		
		protected SesionBase _base = new SesionBase();
		

		#endregion
		
		#region Properties
		
		public SesionBase Base { get { return _base; } }
		
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
		public virtual long OidHorario
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidHorario;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidHorario.Equals(value))
				{
					_base.Record.OidHorario = value;
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
		public virtual long OidClaseExtra
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidClaseExtra;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidClaseExtra.Equals(value))
				{
					_base.Record.OidClaseExtra = value;
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
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Observaciones.Equals(value))
				{
					_base.Record.Observaciones = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long Grupo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Grupo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Grupo.Equals(value))
				{
					_base.Record.Grupo = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long Estado
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Estado;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Estado.Equals(value))
				{
					_base.Record.Estado = value;
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
		public virtual bool Forzada
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Forzada;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Forzada.Equals(value))
				{
					_base.Record.Forzada = value;
					PropertyHasChanged();
				}
			}
		}
	
		
		//LINKED
		public virtual EEstado EStatus { get { return _base.EStatus; } set { Estado = (long)value; } }
		public virtual string StatusLabel { get { return _base.StatusLabel; } }
		
		
		#endregion
		
		#region Business Methods
		
		public virtual Sesion CloneAsNew()
		{
			Sesion clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = Sesion.OpenSession();
			Sesion.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(SesionInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidHorario = source.OidHorario;
			OidClaseTeorica = source.OidClaseTeorica;
			OidClasePractica = source.OidClasePractica;
			OidClaseExtra = source.OidClaseExtra;
			OidProfesor = source.OidProfesor;
			Fecha = source.Fecha;
			Observaciones = source.Observaciones;
			Grupo = source.Grupo;
			Estado = source.Estado;
			Hora = source.Hora;
			Forzada = source.Forzada;
		}
		
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidHorario", 1));

            //SOLO UNO DE LOS TRES TIENE QUE SER MAYOR QUE 0

            //ValidationRules.AddRule(CommonRules.MinValue<long>,
            //new CommonRules.MinValueRuleArgs<long>("OidClaseTeorica", 1));

            //ValidationRules.AddRule(CommonRules.MinValue<long>,
            //new CommonRules.MinValueRuleArgs<long>("OidClasePractica", 1));

            //ValidationRules.AddRule(CommonRules.MinValue<long>,
            //new CommonRules.MinValueRuleArgs<long>("OidClaseExtra", 1));

            //ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    //new CommonRules.MinValueRuleArgs<long>("OidProfesor", 1));
        }

        #endregion

        #region Autorization Rules

        public static bool CanAddObject()
        {
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.HORARIO);

        }

        public static bool CanGetObject()
        {
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.HORARIO);

        }

        public static bool CanDeleteObject()
        {
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.HORARIO);

        }
        public static bool CanEditObject()
        {
            return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.HORARIO);

        }

        #endregion

        #region Common Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        protected Sesion() { }
        
		public virtual SesionInfo GetInfo(bool get_childs)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new SesionInfo(this, get_childs);
		}

		public virtual SesionInfo GetInfo() { return GetInfo(true); }

        #endregion

        #region Root Factory Methods

        public static Sesion New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<Sesion>(new CriteriaCs(-1));
        }

        public static Sesion Get(long oid)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = Sesion.GetCriteria(Sesion.OpenSession());
            criteria.AddOidSearch(oid);
            Sesion.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Sesion>(criteria);
        }

        public static Sesion Get(CriteriaEx criteria)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Sesion.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Sesion>(criteria);
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
        /// Elimina todas los Sesions
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = Sesion.OpenSession();
            ISession sess = Sesion.Session(sessCode);
            ITransaction trans = Sesion.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from Sesion");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                Sesion.CloseSession(sessCode);
            }
        }

        public override Sesion Save()
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

        private Sesion(Sesion source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private Sesion(IDataReader reader, bool childs)
        {
            MarkAsChild();
            Childs = childs;
            Fetch(reader);
        }

        public static Sesion NewChild(Horario parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Sesion obj = new Sesion();
            obj.OidHorario = parent.Oid;
            return obj;
        }

        public static Sesion NewChild(ClaseTeorica parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Sesion obj = new Sesion();
            obj.OidClaseTeorica = parent.Oid;
            return obj;
        }

        public static Sesion NewChild(ClasePractica parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Sesion obj = new Sesion();
            obj.OidClasePractica = parent.Oid;
            return obj;
        }

        public static Sesion NewChild(ClaseExtra parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Sesion obj = new Sesion();
            obj.OidClaseExtra = parent.Oid;
            return obj;
        }

        public static Sesion NewChild(Instructor parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Sesion obj = new Sesion();
            obj.OidProfesor = parent.Oid;
            return obj;
        }

        internal static Sesion GetChild(Sesion source)
        {
            return new Sesion(source);
        }

        internal static Sesion GetChild(IDataReader reader, bool childs)
        {
            return new Sesion(reader, childs);
        }


        internal static Sesion GetChild(IDataReader reader)
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

        private void Fetch(Sesion source)
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


        internal void Insert(Horario parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidHorario = parent.Oid;

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

        internal void Update(Horario parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidHorario = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                SesionRecord obj = parent.Session().Get<SesionRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }


        internal void DeleteSelf(Horario parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                SessionCode = parent.SessionCode;
                Session().Delete(Session().Get<SesionRecord>(Oid));
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

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidClaseTeorica = parent.Oid;

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

        internal void Update(ClaseTeorica parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidClaseTeorica = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                SesionRecord obj = parent.Session().Get<SesionRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
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
                Session().Delete(Session().Get<SesionRecord>(Oid));
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

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidClasePractica = parent.Oid;

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

        internal void Update(ClasePractica parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidClasePractica = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                SesionRecord obj = parent.Session().Get<SesionRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
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
                Session().Delete(Session().Get<SesionRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }


        internal void Insert(ClaseExtra parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidClaseExtra = parent.Oid;

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

        internal void Update(ClaseExtra parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidClaseExtra = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                SesionRecord obj = parent.Session().Get<SesionRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }


        internal void DeleteSelf(ClaseExtra parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                SessionCode = parent.SessionCode;
                Session().Delete(Session().Get<SesionRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }


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

                SesionRecord obj = parent.Session().Get<SesionRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
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
                Session().Delete(Session().Get<SesionRecord>(Oid));
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

                    Sesion.DoLOCK( Session());

                    IDataReader reader = Sesion.DoSELECT(AppContext.ActiveSchema.Code, Session(), criteria.Oid);

                    if (reader.Read())
                        _base.CopyValues(reader);

                }
                else
                {
                    _base.Record.CopyValues((SesionRecord)(criteria.UniqueResult()));

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
                    SesionRecord obj = Session().Get<SesionRecord>(Oid);
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
                SesionRecord obj = (SesionRecord)(criteria.UniqueResult());
                Session().Delete(Session().Get<SesionRecord>(obj.Oid));

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

        public static long GetSesionViernesTarde(long oid_plan, long oid_promocion, DateTime fecha_inicial)
        {
            long oid_horario = Horario.GetHorario(oid_plan, oid_promocion, fecha_inicial);
            string query = SELECT_SESION_BY_OID_HORARIO(oid_horario);
            int sesion = Sesion.OpenSession();

            IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(sesion));

            while (reader.Read())
            {
                DateTime fecha = DateTime.Parse(reader["FECHA"].ToString());
                DateTime hora = DateTime.Parse(reader["HORA"].ToString());
                if (fecha.ToShortDateString() == fecha_inicial.AddDays(-3).ToShortDateString()
                    && hora.ToShortTimeString() == "18:45")
                    return (long)reader["OID_PROFESOR"];
            }

            CloseSession(sesion);

            return 0;
        }

        /// <summary>
        /// Comprueba que no haya otro grupo haciendo alguna práctica incompatible con la actual en el mismo momento
        /// </summary>
        /// <param name="oid_clase"></param>
        /// <param name="fecha"></param>
        /// <param name="hora"></param>
        /// <param name="oid_promocion"></param>
        /// <param name="incompatible"></param>
        /// <returns></returns>
        public static bool SesionesSimultaneas(long oid_clase, DateTime fecha, DateTime hora, long oid_promocion, long incompatible)
        {
            string query = SELECT_SESIONES_SIMULTANEAS(oid_clase, fecha, hora);
            int sesion = Sesion.OpenSession();

            IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(sesion));

            while (reader.Read())
            {
                DateTime _fecha = DateTime.Parse(reader["FECHA"].ToString());
                DateTime _hora = DateTime.Parse(reader["HORA"].ToString());
                long incompatible_reader = (long)reader["INCOMPATIBLE"];
                long _oid_promocion = HorarioInfo.Get((long)reader["OID_HORARIO"]).OidPromocion;
                if (fecha.ToShortDateString() == _fecha.ToShortDateString()
                    && hora.ToShortTimeString() == _hora.ToShortTimeString()
                    && _oid_promocion != oid_promocion
                    && incompatible == incompatible_reader)
                    return true;
            }

            CloseSession(sesion);

            return false;
        }

        public static List<ListaSesiones> CargaSesionesProfesores(DateTime fecha, long oid_promocion)
        {
            HorarioList horarios = HorarioList.GetList(false);
            ClasePracticaList practicas = ClasePracticaList.GetList();
            if (horarios != null)
            {
                List<ListaSesiones> lista = new List<ListaSesiones>();
                foreach (HorarioInfo info in horarios)
                {
                    if (info.FechaInicial.ToShortDateString() == fecha.ToShortDateString() && info.OidPromocion != oid_promocion)
                    {
                        ListaSesiones list = new ListaSesiones(fecha);
                        Horario item = Horario.Get(info.Oid);
                        foreach (Sesion ses in item.Sesions)
                        {
                            foreach (SesionAuxiliar aux in list)
                            {
                                if (ses.Fecha.ToShortDateString() == aux.Fecha.ToShortDateString()
                                    && ses.Hora.ToShortTimeString() == aux.Hora.ToShortTimeString())
                                {
                                    aux.OidProfesor = ses.OidProfesor;
                                    aux.OidClasePractica = ses.OidClasePractica;
                                    if (ses.OidClasePractica != 0)
                                        aux.Incompatible = practicas.GetItem(ses.OidClasePractica).Incompatible;
                                    else
                                        aux.Incompatible = 0;
                                    break;
                                }
                            }
                        }
                        lista.Add(list);
                        item.CloseSession();
                    }
                }
                return lista;
            }
            return null;

        }

        public virtual bool IsEqual(SesionInfo source)
        {
            return (source.Fecha.Date == Fecha.Date
                && source.Hora.Hour == Hora.Hour
                && source.OidProfesor == OidProfesor
                && source.OidClaseTeorica == OidClaseTeorica
                && source.OidClasePractica == OidClasePractica
                && source.OidClaseExtra == OidClaseExtra
                && source.Grupo == Grupo
                && source.OidHorario == OidHorario);
        }

        #endregion
        

        #region SQL

        internal static string SELECT_FIELDS()
        {
            string query;

            query = "SELECT S.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string s = nHManager.Instance.GetSQLTable(typeof(SesionRecord));

            query = "   FROM   " + s + "   AS S";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.ClaseExtra != null && conditions.ClaseExtra.Oid > 0)
                query += " AND S.\"OID_CLASE_EXTRA\" = " + conditions.ClaseExtra.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions);

            if (lockTable) query += " FOR UPDATE OF S NOWAIT";

            return query;
        }


        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        private static string SELECT_SESION_BY_OID_HORARIO(long oid_horario)
        {
            string sesion = nHManager.Instance.Cfg.GetClassMapping(typeof(SesionRecord)).Table.Name;

            string query;

            string esquema = Convert.ToInt32(AppContext.ActiveSchema.Code).ToString("0000");

            query = "SELECT *  " +
                    "FROM \"" + esquema + "\".\"" + sesion + "\" " +
                    "WHERE \"OID_HORARIO\" = " + oid_horario.ToString() + ";";

            return query;
        }

        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        private static string SELECT_SESIONES_SIMULTANEAS(long oid_clase, DateTime fecha, DateTime hora)
        {
            string sesion = nHManager.Instance.Cfg.GetClassMapping(typeof(SesionRecord)).Table.Name;
            string clase_practica = nHManager.Instance.Cfg.GetClassMapping(typeof(ClasePracticaRecord)).Table.Name;

            string query;

            string esquema = Convert.ToInt32(AppContext.ActiveSchema.Code).ToString("0000");

            query = "SELECT s.*, c.\"INCOMPATIBLE\"  " +
                    "FROM \"" + esquema + "\".\"" + sesion + "\" AS s " +
                    "INNER JOIN \"" + esquema + "\".\"" + clase_practica + "\" AS c " +
                    "ON (s.\"OID_CLASE_PRACTICA\" = c.\"OID\") " +
                    "WHERE \"OID_CLASE_PRACTICA\" = " + oid_clase.ToString() + ";";

            return query;
        }

        #endregion
    }
}

