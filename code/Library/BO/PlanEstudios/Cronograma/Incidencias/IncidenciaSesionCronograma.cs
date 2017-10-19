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
	public class IncidenciaSesionCronogramaRecord : RecordBase
	{
		#region Attributes

		private long _oid_incidencia;
		private long _oid_clase_teorica_programada;
		private long _oid_clase_practica_programada;
        private long _oid_clase_teorica_asignada;
        private long _oid_clase_practica_asignada;
        private DateTime _fecha_clase_programada;
        private DateTime _fecha_clase_asignada;
        private DateTime _hora_clase_programada;
        private DateTime _hora_clase_asignada;
  
		#endregion
		
		#region Properties

        public virtual long OidIncidencia { get { return _oid_incidencia; } set { _oid_incidencia = value; } }
        public virtual long OidClaseTeoricaProgramada { get { return _oid_clase_teorica_programada; } set { _oid_clase_teorica_programada = value; } }
        public virtual long OidClasePracticaProgramada { get { return _oid_clase_practica_programada; } set { _oid_clase_practica_programada = value; } }
        public virtual long OidClaseTeoricaAsignada { get { return _oid_clase_teorica_asignada; } set { _oid_clase_teorica_asignada = value; } }
        public virtual long OidClasePracticaAsignada { get { return _oid_clase_practica_asignada; } set { _oid_clase_practica_asignada = value; } }
        public virtual DateTime FechaClaseProgramada { get { return _fecha_clase_programada; } set { _fecha_clase_programada = value; } }
        public virtual DateTime FechaClaseAsignada { get { return _fecha_clase_asignada; } set { _fecha_clase_asignada = value; } }
        public virtual DateTime HoraClaseProgramada { get { return _hora_clase_programada; } set { _hora_clase_programada = value; } }
        public virtual DateTime HoraClaseAsignada { get { return _hora_clase_asignada; } set { _hora_clase_asignada = value; } }

		#endregion
		
		#region Business Methods
		
		public IncidenciaSesionCronogramaRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
            _oid_incidencia = Format.DataReader.GetInt64(source, "OID_INCIDENCIA");
            _oid_clase_teorica_programada = Format.DataReader.GetInt64(source, "OID_CLASE_TEORICA_PROGRAMADA");
            _oid_clase_practica_programada = Format.DataReader.GetInt64(source, "OID_CLASE_PRACTICA_PROGRAMADA");
            _oid_clase_teorica_asignada = Format.DataReader.GetInt64(source, "OID_CLASE_TEORICA_ASIGNADA");
            _oid_clase_practica_asignada = Format.DataReader.GetInt64(source, "OID_CLASE_PRACTICA_ASIGNADA");
            _fecha_clase_programada = Format.DataReader.GetDateTime(source, "FECHA_CLASE_PROGRAMADA");
            _fecha_clase_asignada = Format.DataReader.GetDateTime(source, "FECHA_CLASE_ASIGNADA");
            _hora_clase_programada = Format.DataReader.GetDateTime(source, "HORA_CLASE_PROGRAMADA");
            _fecha_clase_asignada = Format.DataReader.GetDateTime(source, "HORA_CLASE_ASIGNADA");

		}		
		public virtual void CopyValues(IncidenciaSesionCronogramaRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
            _oid_incidencia = source.OidIncidencia;
            _oid_clase_teorica_programada = source.OidClaseTeoricaProgramada;
            _oid_clase_practica_programada = source.OidClasePracticaProgramada;
            _oid_clase_teorica_asignada = source.OidClaseTeoricaAsignada;
            _oid_clase_practica_asignada = source.OidClasePracticaAsignada;
            _fecha_clase_programada = source.FechaClaseProgramada;
            _fecha_clase_asignada = source.FechaClaseAsignada;
            _hora_clase_programada = source.HoraClaseProgramada;
            _hora_clase_asignada = source.HoraClaseAsignada;
		}
		
		#endregion	
	}

    [Serializable()]
	public class IncidenciaSesionCronogramaBase 
	{	 
		#region Attributes
		
		private IncidenciaSesionCronogramaRecord _record = new IncidenciaSesionCronogramaRecord();
        
        //atributos auxiliares
        private string _clase_programada = string.Empty;
        private string _modulo_clase_programada = string.Empty;
        private string _clase_asignada = string.Empty;
        private string _modulo_clase_asignada = string.Empty;
		
		#endregion
		
		#region Properties
		
		public IncidenciaSesionCronogramaRecord Record { get { return _record; } }

        public virtual string ClaseProgramada { get { return _clase_programada; } set { _clase_programada = value; } }
        public virtual string ModuloClaseProgramada { get { return _modulo_clase_programada; } set { _modulo_clase_programada = value; } }
        public virtual string ClaseAsignada { get { return _clase_asignada; } set { _clase_asignada = value; } }
        public virtual string ModuloClaseAsignada { get { return _modulo_clase_asignada; } set { _modulo_clase_asignada = value; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);

            _clase_programada = source["CLASE_PROGRAMADA"].ToString();
            _modulo_clase_programada = source["MODULO_PROGRAMADO"].ToString();
            _clase_asignada = source["CLASE_ASIGNADA"].ToString();
            _modulo_clase_asignada = source["MODULO_ASIGNADO"].ToString();
		}		
		public void CopyValues(IncidenciaSesionCronograma source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _clase_programada = source.ClaseProgramada;
            _modulo_clase_programada = source.ModuloClaseProgramada;
            _clase_asignada = source.ClaseAsignada;
            _modulo_clase_asignada = source.ModuloClaseAsignada;
		}
		public void CopyValues(IncidenciaSesionCronogramaInfo source)
		{
			if (source == null) return;

            _record.CopyValues(source.Base.Record);

            _clase_programada = source.ClaseProgramada;
            _modulo_clase_programada = source.ModuloClaseProgramada;
            _clase_asignada = source.ClaseAsignada;
            _modulo_clase_asignada = source.ModuloClaseAsignada;
		}
		
		#endregion	
	}
		
	/// <summary>
	/// Editable Root Business Object
	/// </summary>	
    [Serializable()]
	public class IncidenciaSesionCronograma : BusinessBaseEx<IncidenciaSesionCronograma>
	{	 
		#region Attributes
		
		protected IncidenciaSesionCronogramaBase _base = new IncidenciaSesionCronogramaBase();
		
		#endregion
		
		#region Properties
		
		public IncidenciaSesionCronogramaBase Base { get { return _base; } }
		
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
        public virtual long OidIncidencia
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidIncidencia;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);

                if (!_base.Record.OidIncidencia.Equals(value))
				{
                    _base.Record.OidIncidencia = value;
					PropertyHasChanged();
				}
			}
		}
        public virtual long OidClaseTeoricaProgramada
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidClaseTeoricaProgramada;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);

                if (!_base.Record.OidClaseTeoricaProgramada.Equals(value))
				{
                    _base.Record.OidClaseTeoricaProgramada = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidClasePracticaProgramada
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
                return _base.Record.OidClasePracticaProgramada;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);

                if (!_base.Record.OidClasePracticaProgramada.Equals(value))
				{
                    _base.Record.OidClasePracticaProgramada = value;
					PropertyHasChanged();
				}
			}
		}
        public virtual DateTime FechaClaseProgramada
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.FechaClaseProgramada;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //CanWriteProperty(true);

                if (!_base.Record.FechaClaseProgramada.Equals(value))
                {
                    _base.Record.FechaClaseProgramada = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual DateTime HoraClaseProgramada
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.HoraClaseProgramada;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //CanWriteProperty(true);

                if (!_base.Record.HoraClaseProgramada.Equals(value))
                {
                    _base.Record.HoraClaseProgramada = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual long OidClaseTeoricaAsignada
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.OidClaseTeoricaAsignada;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //CanWriteProperty(true);

                if (!_base.Record.OidClaseTeoricaAsignada.Equals(value))
                {
                    _base.Record.OidClaseTeoricaAsignada = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual long OidClasePracticaAsignada
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.OidClasePracticaAsignada;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //CanWriteProperty(true);

                if (!_base.Record.OidClasePracticaAsignada.Equals(value))
                {
                    _base.Record.OidClasePracticaAsignada = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual DateTime FechaClaseAsignada
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.FechaClaseAsignada;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //CanWriteProperty(true);

                if (!_base.Record.FechaClaseAsignada.Equals(value))
                {
                    _base.Record.FechaClaseAsignada = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual DateTime HoraClaseAsignada
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.HoraClaseAsignada;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //CanWriteProperty(true);

                if (!_base.Record.HoraClaseAsignada.Equals(value))
                {
                    _base.Record.HoraClaseAsignada = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ClaseProgramada { get { return _base.ClaseProgramada; } set { _base.ClaseProgramada = value; } }
        public virtual string ModuloClaseProgramada { get { return _base.ModuloClaseProgramada; } set { _base.ModuloClaseProgramada = value; } }
        public virtual string ClaseAsignada { get { return _base.ClaseAsignada; } set { _base.ClaseAsignada = value; } }
        public virtual string ModuloClaseAsignada { get { return _base.ModuloClaseAsignada; } set { _base.ModuloClaseAsignada = value; } }

		#endregion
		
		#region Business Methods
		
		public virtual IncidenciaSesionCronograma CloneAsNew()
		{
			IncidenciaSesionCronograma clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = IncidenciaSesionCronograma.OpenSession();
			IncidenciaSesionCronograma.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(IncidenciaSesionCronogramaInfo source)
		{
			if (source == null) return;

            Oid = source.Oid;
            OidIncidencia = source.OidIncidencia;
            OidClaseTeoricaProgramada = source.OidClaseTeoricaProgramada;
            OidClasePracticaProgramada = source.OidClasePracticaProgramada;
            OidClaseTeoricaAsignada = source.OidClaseTeoricaAsignada;
            OidClasePracticaAsignada = source.OidClasePracticaAsignada;
            FechaClaseProgramada = source.FechaClaseProgramada;
            FechaClaseAsignada = source.FechaClaseAsignada;
            HoraClaseProgramada = source.HoraClaseProgramada;
            HoraClaseAsignada = source.HoraClaseAsignada;
		}
		
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidIncidencia", 1));

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
        	protected IncidenciaSesionCronograma() 
            {
            }

        public virtual IncidenciaSesionCronogramaInfo GetInfo(bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new IncidenciaSesionCronogramaInfo(this);
        }

        public virtual IncidenciaSesionCronogramaInfo GetInfo()
        {
            return GetInfo(true);
        }

        #endregion

        #region Root Factory Methods

        public static IncidenciaSesionCronograma New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<IncidenciaSesionCronograma>(new CriteriaCs(-1));
        }

        public static IncidenciaSesionCronograma Get(long oid)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = IncidenciaSesionCronograma.GetCriteria(IncidenciaSesionCronograma.OpenSession());
            criteria.AddOidSearch(oid);
            IncidenciaSesionCronograma.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<IncidenciaSesionCronograma>(criteria);
        }

        public static IncidenciaSesionCronograma Get(CriteriaEx criteria)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            IncidenciaSesionCronograma.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<IncidenciaSesionCronograma>(criteria);
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
        /// Elimina todas los IncidenciaSesionCronogramas
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = IncidenciaSesionCronograma.OpenSession();
            ISession sess = IncidenciaSesionCronograma.Session(sessCode);
            ITransaction trans = IncidenciaSesionCronograma.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from IncidenciaSesionCronograma");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                IncidenciaSesionCronograma.CloseSession(sessCode);
            }
        }

        public override IncidenciaSesionCronograma Save()
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

        public IncidenciaSesionCronograma(IncidenciaSesionCronograma source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private IncidenciaSesionCronograma(IDataReader reader, bool childs)
        {
            MarkAsChild();
            Childs = childs;
            Fetch(reader);
        }

        public static IncidenciaSesionCronograma NewChild(IncidenciaCronograma parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            IncidenciaSesionCronograma obj = new IncidenciaSesionCronograma();
            obj.OidIncidencia = parent.Oid;
            return obj;
        }
        
        internal static IncidenciaSesionCronograma GetChild(IncidenciaSesionCronograma source)
        {
            return new IncidenciaSesionCronograma(source);
        }

        internal static IncidenciaSesionCronograma GetChild(IDataReader reader, bool childs)
        {
            return new IncidenciaSesionCronograma(reader, childs);
        }


        internal static IncidenciaSesionCronograma GetChild(IDataReader reader)
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

        private void Fetch(IncidenciaSesionCronograma source)
        {
            try
            {
                SessionCode = source.SessionCode;

                _base.CopyValues(source);

                //CriteriaEx criteria = ParteAsistencia.GetCriteria(Session());
                //criteria.AddEq("OidIncidenciaSesionCronograma", this.Oid);
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


        internal void Insert(IncidenciaCronograma parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la IncidenciaSesionCronograma del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidIncidencia = parent.Oid;

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

        internal void Update(IncidenciaCronograma parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la IncidenciaSesionCronograma del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidIncidencia = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                IncidenciaSesionCronogramaRecord obj = parent.Session().Get<IncidenciaSesionCronogramaRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }


        internal void DeleteSelf(IncidenciaCronograma parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                SessionCode = parent.SessionCode;
                Session().Delete(Session().Get<IncidenciaSesionCronogramaRecord>(Oid));
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

					IncidenciaSesionCronograma.DoLOCK( Session());

                    IDataReader reader = IncidenciaSesionCronograma.DoSELECT(AppContext.ActiveSchema.Code, Session(), criteria.Oid);

                    if (reader.Read())
                        _base.CopyValues(reader);
                }
                else
                {
                    _base.Record.CopyValues((IncidenciaSesionCronogramaRecord)(criteria.UniqueResult()));

                    //Session().Lock(Session().Get<IncidenciaSesionCronogramaRecord>(Oid), LockMode.UpgradeNoWait);
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
                    IncidenciaSesionCronogramaRecord obj = Session().Get<IncidenciaSesionCronogramaRecord>(Oid);
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
                IncidenciaSesionCronogramaRecord obj = (IncidenciaSesionCronogramaRecord)(criteria.UniqueResult());
                Session().Delete(Session().Get<IncidenciaSesionCronogramaRecord>(obj.Oid));

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

            query = "SELECT ISC.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string isc = nHManager.Instance.GetSQLTable(typeof(IncidenciaSesionCronogramaRecord));

            query = "   FROM   " + isc + "   AS ISC";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            //if (conditions.Cronograma != null && conditions.Cronograma.Oid > 0)
            //    query += " AND ISC.\"OID_INCIDENCIA\" = " + conditions.Cronograma.Oid;

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

