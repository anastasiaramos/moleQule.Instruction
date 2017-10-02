using System;
using System.ComponentModel;
using System.Data;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class HistoriaRecord : RecordBase
	{
		#region Attributes

		private long _oid_pregunta;
		private DateTime _fecha;
		private string _texto = string.Empty;
		private DateTime _hora;
  
		#endregion
		
		#region Properties
		
				public virtual long OidPregunta { get { return _oid_pregunta; } set { _oid_pregunta = value; } }
		public virtual DateTime Fecha { get { return _fecha; } set { _fecha = value; } }
		public virtual string Texto { get { return _texto; } set { _texto = value; } }
		public virtual DateTime Hora { get { return _hora; } set { _hora = value; } }

		#endregion
		
		#region Business Methods
		
		public HistoriaRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_pregunta = Format.DataReader.GetInt64(source, "OID_PREGUNTA");
			_fecha = Format.DataReader.GetDateTime(source, "FECHA");
			_texto = Format.DataReader.GetString(source, "TEXTO");
			_hora = Format.DataReader.GetDateTime(source, "HORA");

		}		
		public virtual void CopyValues(HistoriaRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_pregunta = source.OidPregunta;
			_fecha = source.Fecha;
			_texto = source.Texto;
			_hora = source.Hora;
		}
		
		#endregion	
	}

    [Serializable()]
	public class HistoriaBase 
	{	 
		#region Attributes
		
		private HistoriaRecord _record = new HistoriaRecord();
		
		#endregion
		
		#region Properties
		
		public HistoriaRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(Historia source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(HistoriaInfo source)
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
	public class Historia : BusinessBaseEx<Historia>
	{	 
		#region Attributes
		
		protected HistoriaBase _base = new HistoriaBase();
		

		#endregion
		
		#region Properties
		
		public HistoriaBase Base { get { return _base; } }
		
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
		public virtual long OidPregunta
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidPregunta;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidPregunta.Equals(value))
				{
					_base.Record.OidPregunta = value;
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
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual Historia CloneAsNew()
		{
			Historia clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = Historia.OpenSession();
			Historia.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(HistoriaInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidPregunta = source.OidPregunta;
			Fecha = source.Fecha;
			Texto = source.Texto;
			Hora = source.Hora;
		}
		
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidPregunta", 1));
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

        #region Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los Factory Methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        public Historia()
        {
            MarkAsChild();
            Random r = new Random();
            Oid = (long)r.Next();
        }

        private Historia(Historia source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private Historia(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static Historia NewChild(Pregunta parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Historia obj = new Historia();
            obj.OidPregunta = parent.Oid;
            return obj;
        }

        internal static Historia GetChild(Historia source)
        {
            return new Historia(source);
        }

        internal static Historia GetChild(IDataReader reader)
        {
            return new Historia(reader);
        }

        public virtual HistoriaInfo GetInfo()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new HistoriaInfo(this, false);
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
        public override Historia Save()
        {
            throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
        }

        #endregion

        #region Child Data Access

        private void Fetch(Historia source)
        {
            _base.CopyValues(source);
            MarkOld();
        }

        private void Fetch(IDataReader reader)
        {
            _base.CopyValues(reader);
            MarkOld();
        }

        internal void Insert(Pregunta parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidPregunta = parent.Oid;

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

        internal void Update(Pregunta parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidPregunta = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                HistoriaRecord obj = parent.Session().Get<HistoriaRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(Pregunta parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                parent.Session().Delete(parent.Session().Get<HistoriaRecord>(Oid));
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

            query = "SELECT H.*";

            return query;
        }

        #endregion

    }
}

