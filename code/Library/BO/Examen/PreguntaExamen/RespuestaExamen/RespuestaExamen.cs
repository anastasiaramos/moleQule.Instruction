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
	public class RespuestaExamenRecord : RecordBase
	{
		#region Attributes

		private long _oid_pregunta;
		private string _texto = string.Empty;
		private string _opcion = string.Empty;
		private bool _correcta = false;
		private long _oid_pregunta_old;
		private long _oid_respuesta_old;
		private long _oid_examen;
		private long _oid_respuesta;
  
		#endregion
		
		#region Properties
		
				public virtual long OidPregunta { get { return _oid_pregunta; } set { _oid_pregunta = value; } }
		public virtual string Texto { get { return _texto; } set { _texto = value; } }
		public virtual string Opcion { get { return _opcion; } set { _opcion = value; } }
		public virtual bool Correcta { get { return _correcta; } set { _correcta = value; } }
		public virtual long OidPreguntaOld { get { return _oid_pregunta_old; } set { _oid_pregunta_old = value; } }
		public virtual long OidRespuestaOld { get { return _oid_respuesta_old; } set { _oid_respuesta_old = value; } }
		public virtual long OidExamen { get { return _oid_examen; } set { _oid_examen = value; } }
		public virtual long OidRespuesta { get { return _oid_respuesta; } set { _oid_respuesta = value; } }

		#endregion
		
		#region Business Methods
		
		public RespuestaExamenRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_pregunta = Format.DataReader.GetInt64(source, "OID_PREGUNTA");
			_texto = Format.DataReader.GetString(source, "TEXTO");
			_opcion = Format.DataReader.GetString(source, "OPCION");
			_correcta = Format.DataReader.GetBool(source, "CORRECTA");
			_oid_pregunta_old = Format.DataReader.GetInt64(source, "OID_PREGUNTA_OLD");
			_oid_respuesta_old = Format.DataReader.GetInt64(source, "OID_RESPUESTA_OLD");
			_oid_examen = Format.DataReader.GetInt64(source, "OID_EXAMEN");
			_oid_respuesta = Format.DataReader.GetInt64(source, "OID_RESPUESTA");

		}		
		public virtual void CopyValues(RespuestaExamenRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_pregunta = source.OidPregunta;
			_texto = source.Texto;
			_opcion = source.Opcion;
			_correcta = source.Correcta;
			_oid_pregunta_old = source.OidPreguntaOld;
			_oid_respuesta_old = source.OidRespuestaOld;
			_oid_examen = source.OidExamen;
			_oid_respuesta = source.OidRespuesta;
		}
		
		#endregion	
	}

    [Serializable()]
	public class RespuestaExamenBase 
	{	 
		#region Attributes
		
		private RespuestaExamenRecord _record = new RespuestaExamenRecord();
		
		#endregion
		
		#region Properties
		
		public RespuestaExamenRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(RespuestaExamen source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(RespuestaExamenInfo source)
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
	public class RespuestaExamen : BusinessBaseEx<RespuestaExamen>
	{	 
		#region Attributes
		
		protected RespuestaExamenBase _base = new RespuestaExamenBase();
		

		#endregion
		
		#region Properties
		
		public RespuestaExamenBase Base { get { return _base; } }
		
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
		public virtual string Opcion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Opcion;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Opcion.Equals(value))
				{
					_base.Record.Opcion = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool Correcta
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Correcta;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Correcta.Equals(value))
				{
					_base.Record.Correcta = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidPreguntaOld
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidPreguntaOld;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidPreguntaOld.Equals(value))
				{
					_base.Record.OidPreguntaOld = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidRespuestaOld
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidRespuestaOld;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidRespuestaOld.Equals(value))
				{
					_base.Record.OidRespuestaOld = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidExamen
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidExamen;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidExamen.Equals(value))
				{
					_base.Record.OidExamen = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidRespuesta
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidRespuesta;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidRespuesta.Equals(value))
				{
					_base.Record.OidRespuesta = value;
					PropertyHasChanged();
				}
			}
		}
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual RespuestaExamen CloneAsNew()
		{
			RespuestaExamen clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = RespuestaExamen.OpenSession();
			RespuestaExamen.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(RespuestaExamenInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidPregunta = source.OidPregunta;
			Texto = source.Texto;
			Opcion = source.Opcion;
			Correcta = source.Correcta;
			OidPreguntaOld = source.OidPreguntaOld;
			OidRespuestaOld = source.OidRespuestaOld;
			OidExamen = source.OidExamen;
			OidRespuesta = source.OidRespuesta;
		}
        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        public virtual void CopyValues(Respuesta source)
        {
            if (source == null) return;
            Texto = source.Texto;
            Opcion = source.Opcion;
            Correcta = source.Correcta;
        }
        
        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        public virtual void CopyValues(RespuestaInfo source)
        {
            if (source == null) return;
            _base.Record.Texto = source.Texto;
            _base.Record.Opcion = source.Opcion;
            _base.Record.Correcta = source.Correcta;

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
        public RespuestaExamen()
        {
            MarkAsChild();
            Random r = new Random();
            Oid = (long)r.Next();
        }

        private RespuestaExamen(RespuestaExamen source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private RespuestaExamen(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static RespuestaExamen NewChild(PreguntaExamen parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            RespuestaExamen obj = new RespuestaExamen();
            obj.OidPregunta = parent.Oid;
            return obj;
        }

        internal static RespuestaExamen GetChild(RespuestaExamen source)
        {
            return new RespuestaExamen(source);
        }

        internal static RespuestaExamen GetChild(IDataReader reader)
        {
            return new RespuestaExamen(reader);
        }

        public virtual RespuestaExamenInfo GetInfo()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new RespuestaExamenInfo(this);

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
        public override RespuestaExamen Save()
        {
            throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
        }


        #endregion

        #region Child Data Access

        private void Fetch(RespuestaExamen source)
        {
            _base.CopyValues(source);
            MarkOld();
        }

        private void Fetch(IDataReader reader)
        {
            _base.CopyValues(reader);
            MarkOld();
        }

        internal void Insert(PreguntaExamen parent)
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

        internal void Update(PreguntaExamen parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidPregunta = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                RespuestaExamenRecord obj = parent.Session().Get<RespuestaExamenRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(PreguntaExamen parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                parent.Session().Delete(parent.Session().Get<RespuestaExamenRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }


        #endregion

    }
}

