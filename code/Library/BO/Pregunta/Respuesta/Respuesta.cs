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
	public class RespuestaRecord : RecordBase
	{
		#region Attributes

		private long _oid_pregunta;
		private string _texto = string.Empty;
		private string _opcion = string.Empty;
		private bool _correcta = false;
		private long _oid_old;
		private long _serial;
		private string _codigo = string.Empty;
		private long _oid_pregunta_old;
  
		#endregion
		
		#region Properties
		
				public virtual long OidPregunta { get { return _oid_pregunta; } set { _oid_pregunta = value; } }
		public virtual string Texto { get { return _texto; } set { _texto = value; } }
		public virtual string Opcion { get { return _opcion; } set { _opcion = value; } }
		public virtual bool Correcta { get { return _correcta; } set { _correcta = value; } }
		public virtual long OidOld { get { return _oid_old; } set { _oid_old = value; } }
		public virtual long Serial { get { return _serial; } set { _serial = value; } }
		public virtual string Codigo { get { return _codigo; } set { _codigo = value; } }
		public virtual long OidPreguntaOld { get { return _oid_pregunta_old; } set { _oid_pregunta_old = value; } }

		#endregion
		
		#region Business Methods
		
		public RespuestaRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_pregunta = Format.DataReader.GetInt64(source, "OID_PREGUNTA");
			_texto = Format.DataReader.GetString(source, "TEXTO");
			_opcion = Format.DataReader.GetString(source, "OPCION");
			_correcta = Format.DataReader.GetBool(source, "CORRECTA");
			_oid_old = Format.DataReader.GetInt64(source, "OID_OLD");
			_serial = Format.DataReader.GetInt64(source, "SERIAL");
			_codigo = Format.DataReader.GetString(source, "CODIGO");
			_oid_pregunta_old = Format.DataReader.GetInt64(source, "OID_PREGUNTA_OLD");

		}		
		public virtual void CopyValues(RespuestaRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_pregunta = source.OidPregunta;
			_texto = source.Texto;
			_opcion = source.Opcion;
			_correcta = source.Correcta;
			_oid_old = source.OidOld;
			_serial = source.Serial;
			_codigo = source.Codigo;
			_oid_pregunta_old = source.OidPreguntaOld;
		}
		
		#endregion	
	}

    [Serializable()]
	public class RespuestaBase 
	{	 
		#region Attributes
		
		private RespuestaRecord _record = new RespuestaRecord();
		
		#endregion
		
		#region Properties
		
		public RespuestaRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(Respuesta source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(RespuestaInfo source)
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
	public class Respuesta : BusinessBaseEx<Respuesta>
	{	 
		#region Attributes
		
		protected RespuestaBase _base = new RespuestaBase();
		

		#endregion
		
		#region Properties
		
		public RespuestaBase Base { get { return _base; } }
		
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
		public virtual long OidOld
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidOld;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidOld.Equals(value))
				{
					_base.Record.OidOld = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long Serial
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Serial;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Serial.Equals(value))
				{
					_base.Record.Serial = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Codigo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Codigo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Codigo.Equals(value))
				{
					_base.Record.Codigo = value;
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
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual Respuesta CloneAsNew()
		{
			Respuesta clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = Respuesta.OpenSession();
			Respuesta.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(RespuestaInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidPregunta = source.OidPregunta;
			Texto = source.Texto;
			Opcion = source.Opcion;
			Correcta = source.Correcta;
			OidOld = source.OidOld;
			Serial = source.Serial;
			Codigo = source.Codigo;
			OidPreguntaOld = source.OidPreguntaOld;
		}
        public void CopyFrom(RespuestaExamenInfo source)
        {
            if (source == null) return;

            Oid = source.OidRespuesta;
            _base.Record.OidPregunta = source.OidPregunta;
            _base.Record.Texto = source.Texto;
            _base.Record.Opcion = source.Opcion;
            _base.Record.Correcta = source.Correcta;
            _base.Record.OidPreguntaOld = source.OidPreguntaOld;
        }

        /// <summary>
        /// Devuelve el siguiente código de Módulo.
        /// </summary>
        /// <returns>Código de 9 cifras</returns>
        public static string GetNewCode(Respuestas lista)
        {
            Int64 lastcode = Respuesta.GetNewSerial(lista);

            // Devolvemos el siguiente codigo de cliente 
            return lastcode.ToString(Resources.Defaults.RESPUESTA_CODE_FORMAT);
        }

        /// <summary>
        /// Devuelve el siguiente Serial de Alumno.
        /// </summary>
        /// <returns>Código de 9 cifras</returns>
        public static Int64 GetNewSerial(Respuestas lista)
        {
            // Obtenemos la lista de clientes ordenados por serial
            SortedBindingList<RespuestaInfo> respuestas =
                RespuestaList.GetSortedList("Serial", ListSortDirection.Ascending);

            // Obtenemos el último serial de servicio
            Int64 lastcode;

            if (respuestas.Count > 0)
                lastcode = respuestas[respuestas.Count - 1].Serial;
            else
                lastcode = Convert.ToInt64(Resources.Defaults.RESPUESTA_CODE_FORMAT);

            if (lista != null)
            {
                foreach (Respuesta item in lista)
                {
                    if (item.Serial > lastcode)
                        lastcode = item.Serial;
                }
            }

            lastcode++;
            return lastcode;
        }

        public virtual void CheckChanges(Respuesta respuesta, Pregunta parent)
        {
            Historia historia = parent.Historias.NewItem(parent);

            if (Codigo != respuesta.Codigo)
            {
                historia.Texto += System.Environment.NewLine
                    + "Modificado el campo Codigo en Respuesta " + Opcion + "; Usuario: " + AppContext.User.Name
                    + "; Valor anterior : " + respuesta.Correcta + ";";
                historia.Fecha = DateTime.Now.Date;
                historia.Hora = DateTime.Now;
            }

            if (Texto != respuesta.Texto)
            {
                historia.Texto += System.Environment.NewLine
                    + "Modificado el campo Texto en Respuesta " + Opcion + "; Usuario: " + AppContext.User.Name
                    + "; Valor anterior : " + respuesta.Texto + ";";
                historia.Fecha = DateTime.Now.Date;
                historia.Hora = DateTime.Now;
            }

            if (Opcion != respuesta.Opcion)
            {
                historia.Texto += System.Environment.NewLine
                   + "Modificado el campo Opcion en Respuesta " + Opcion + "; Usuario: " + AppContext.User.Name
                   + "; Valor anterior : " + respuesta.Opcion + ";";
                historia.Fecha = DateTime.Now.Date;
                historia.Hora = DateTime.Now;
            }
            
            if (Correcta != respuesta.Correcta)
            {
                historia.Texto += System.Environment.NewLine
                    + "Modificado el campo Correcta en Respuesta " + Opcion + "; Usuario: " + AppContext.User.Name
                    + "; Valor anterior : " + respuesta.Correcta + ";";
                historia.Fecha = DateTime.Now.Date;
                historia.Hora = DateTime.Now;
            }

            if (historia.Texto == string.Empty)
                parent.Historias.Remove(historia);
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
        public Respuesta()
        {
            MarkAsChild();
            Random r = new Random();
            Oid = (long)r.Next();
        }

        private Respuesta(Respuesta source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private Respuesta(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        protected Respuesta(RespuestaExamenInfo source) 
        {
            MarkAsChild();
            CopyFrom(source); 
        }

        public static Respuesta NewChild(Pregunta parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Respuesta obj = new Respuesta();
            obj.OidPregunta = parent.Oid;
            return obj;
        }

        public static Respuesta NewChild(RespuestaExamenInfo source)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new Respuesta(source);
        }

        internal static Respuesta GetChild(Respuesta source)
        {
            return new Respuesta(source);
        }

        internal static Respuesta GetChild(IDataReader reader)
        {
            return new Respuesta(reader);
        }

        public virtual RespuestaInfo GetInfo()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new RespuestaInfo(this);

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
        public override Respuesta Save()
        {
            throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
        }
        
        #endregion

        #region Child Data Access

        private void Fetch(Respuesta source)
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
            Codigo = GetNewCode(parent.Respuestas);
            Serial = GetNewSerial(parent.Respuestas);

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                parent.Session().Save(this.Base.Record);
            }
            catch (Exception exception)
            {
                iQExceptionHandler.TreatException(exception);
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

                RespuestaRecord obj = parent.Session().Get<RespuestaRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
            }
            catch (Exception exception)
            {
                iQExceptionHandler.TreatException(exception);
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
                parent.Session().Delete(parent.Session().Get<RespuestaRecord>(Oid));
            }
            catch (Exception exception)
            {
                iQExceptionHandler.TreatException(exception);
            }

            MarkNew();
        }


        #endregion

        #region SQL

        internal static string SELECT_FIELDS()
        {
            string query;

            query = "SELECT R.*";

            return query;
        }

        #endregion

    }
}

