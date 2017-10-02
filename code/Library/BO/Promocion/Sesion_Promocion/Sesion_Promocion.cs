using System;
using System.ComponentModel;
using System.Data;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;
using moleQule.Library.Instruction;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class Sesion_PromocionRecord : RecordBase
	{
		#region Attributes

		private long _oid_promocion;
		private DateTime _hora_inicio;
		private long _n_horas;
		private bool _sabado = false;
		private long _tipo;
  
		#endregion
		
		#region Properties
		
				public virtual long OidPromocion { get { return _oid_promocion; } set { _oid_promocion = value; } }
		public virtual DateTime HoraInicio { get { return _hora_inicio; } set { _hora_inicio = value; } }
		public virtual long NHoras { get { return _n_horas; } set { _n_horas = value; } }
		public virtual bool Sabado { get { return _sabado; } set { _sabado = value; } }
		public virtual long Tipo { get { return _tipo; } set { _tipo = value; } }

		#endregion
		
		#region Business Methods
		
		public Sesion_PromocionRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_promocion = Format.DataReader.GetInt64(source, "OID_PROMOCION");
			_hora_inicio = Format.DataReader.GetDateTime(source, "HORA_INICIO");
			_n_horas = Format.DataReader.GetInt64(source, "N_HORAS");
			_sabado = Format.DataReader.GetBool(source, "SABADO");
			_tipo = Format.DataReader.GetInt64(source, "TIPO");

		}		
		public virtual void CopyValues(Sesion_PromocionRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_promocion = source.OidPromocion;
			_hora_inicio = source.HoraInicio;
			_n_horas = source.NHoras;
			_sabado = source.Sabado;
			_tipo = source.Tipo;
		}
		
		#endregion	
	}

    [Serializable()]
	public class Sesion_PromocionBase 
	{	 
		#region Attributes
		
		private Sesion_PromocionRecord _record = new Sesion_PromocionRecord();

        private string _hora = string.Empty;
		
		#endregion
		
		#region Properties
		
		public Sesion_PromocionRecord Record { get { return _record; } }

        public virtual string Hora { get { return _hora; } set { _hora = value; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);

            _hora = _record.HoraInicio.ToString("HH:mm");
		}		
		public void CopyValues(Sesion_Promocion source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _hora = source.Hora;
		}
		public void CopyValues(Sesion_PromocionInfo source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _hora = source.Hora;
		}
		
		#endregion	
	}
		
	/// <summary>
	/// Editable Root Business Object
	/// </summary>	
    [Serializable()]
	public class Sesion_Promocion : BusinessBaseEx<Sesion_Promocion>
	{	 
		#region Attributes
		
		protected Sesion_PromocionBase _base = new Sesion_PromocionBase();
		

		#endregion
		
		#region Properties
		
		public Sesion_PromocionBase Base { get { return _base; } }
		
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
		public virtual DateTime HoraInicio
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.HoraInicio;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.HoraInicio.Equals(value))
				{
					_base.Record.HoraInicio = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long NHoras
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.NHoras;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.NHoras.Equals(value))
				{
					_base.Record.NHoras = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool Sabado
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Sabado;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Sabado.Equals(value))
				{
					_base.Record.Sabado = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long Tipo
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
				
				if (!_base.Record.Tipo.Equals(value))
				{
					_base.Record.Tipo = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual string Hora
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Hora;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (!_base.Hora.Equals(value) && !value.Equals(string.Empty))
                {
                    _base.Record.HoraInicio = DateTime.Parse(value);
                    _base.Hora = value;
                    PropertyHasChanged();
                }
            }
        }
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual Sesion_Promocion CloneAsNew()
		{
			Sesion_Promocion clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = Sesion_Promocion.OpenSession();
			Sesion_Promocion.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(Sesion_PromocionInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidPromocion = source.OidPromocion;
			HoraInicio = source.HoraInicio;
			NHoras = source.NHoras;
			Sabado = source.Sabado;
			Tipo = source.Tipo;
		}
		
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidPromocion", 1));
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("Tipo", 1));

            ValidationRules.AddRule(
                Csla.Validation.CommonRules.StringRequired, "Hora");
        }

        #endregion

        #region Autorization Rules

        public static bool CanAddObject()
        {
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.PROMOCION);

        }

        public static bool CanGetObject()
        {
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.PROMOCION);

        }

        public static bool CanDeleteObject()
        {
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.PROMOCION);

        }
        public static bool CanEditObject()
        {
            return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.PROMOCION);

        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los Factory Methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        public Sesion_Promocion()
        {
            MarkAsChild();
            Random r = new Random();
            Oid = (long)r.Next();
        }

        private Sesion_Promocion(Sesion_Promocion source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private Sesion_Promocion(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static Sesion_Promocion NewChild(Promocion parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Sesion_Promocion obj = new Sesion_Promocion();
            obj.OidPromocion = parent.Oid;
            obj.Tipo = 1;
            return obj;
        }

        public static Sesion_Promocion NewChild(Cronograma parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Sesion_Promocion obj = new Sesion_Promocion();
            obj.OidPromocion = parent.Oid;
            obj.Tipo = 2;
            return obj;
        }

        internal static Sesion_Promocion GetChild(Sesion_Promocion source)
        {
            return new Sesion_Promocion(source);
        }

        internal static Sesion_Promocion GetChild(IDataReader reader)
        {
            return new Sesion_Promocion(reader);
        }

        public virtual Sesion_PromocionInfo GetInfo()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new Sesion_PromocionInfo(this);

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

        /// <summary>
        /// No se debe utilizar esta función para guardar. Hace falta el padre.
        /// Utilizar Insert o Update en sustitución de Save.
        /// </summary>
        /// <returns></returns>
        public override Sesion_Promocion Save()
        {
            throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
        }


        #endregion

        #region Child Data Access

        private void Fetch(Sesion_Promocion source)
        {
            _base.CopyValues(source);
            MarkOld();
        }

        private void Fetch(IDataReader reader)
        {
            _base.CopyValues(reader);
            MarkOld();
        }

        internal void Insert(Promocion parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidPromocion = parent.Oid;
            Tipo = 1;

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

        internal void Update(Promocion parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidPromocion = parent.Oid;
            Tipo = 1;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                Sesion_PromocionRecord obj = parent.Session().Get<Sesion_PromocionRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(Promocion parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                parent.Session().Delete(parent.Session().Get<Sesion_PromocionRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }

        internal void Insert(Cronograma parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidPromocion = parent.Oid;
            Tipo = 2;

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

        internal void Update(Cronograma parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidPromocion = parent.Oid;
            Tipo = 2;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                Sesion_PromocionRecord obj = parent.Session().Get<Sesion_PromocionRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
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
                parent.Session().Delete(parent.Session().Get<Sesion_PromocionRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }


        #endregion

        #region SQL

        internal static string SELECT_FIELDS()
        {
            string query;

            query = "SELECT SP.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string sesion_promocion = nHManager.Instance.GetSQLTable(typeof(Sesion_PromocionRecord));

            query = "   FROM   " + sesion_promocion + "   AS SP";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.Promocion != null && conditions.Promocion.Oid > 0)
                query += " AND SP.\"OID_PROMOCION\" = " + conditions.Promocion.Oid;

            if (conditions.Cronograma != null && conditions.Cronograma.Oid > 0)
                query += " AND SP.\"OID_PROMOCION\" = " + conditions.Cronograma.Oid;

            if (conditions.ESesionPromocion != ESesionPromocion.Todos)
                query += " AND SP.\"TIPO\" = " + (long)conditions.ESesionPromocion;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions) +
                    " ORDER BY \"HORA_INICIO\"";

            if (lockTable) query += " FOR UPDATE OF SP NOWAIT";

            return query;
        }


        #endregion

    }
}

