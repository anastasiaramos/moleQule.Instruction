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
	public class PreguntaRecord : RecordBase
	{
		#region Attributes

		private long _oid_modulo;
		private long _oid_tema;
		private long _nivel;
		private DateTime _fecha_alta;
		private DateTime _fecha_publicacion;
		private string _texto = string.Empty;
		private string _tipo = string.Empty;
        private string _imagen = string.Empty;
        private string _modelo_respuesta = string.Empty;
		private string _observaciones = string.Empty;
		private DateTime _fecha_disponibilidad;
		private string _idioma = string.Empty;
		private bool _activa = false;
		private bool _revisada = false;
		private bool _imagen_grande = false;
		private bool _bloqueada = false;
		private long _oid_submodulo;
		private long _oid_old;
		private long _serial;
		private string _codigo = string.Empty;
		private bool _reservada = false;
  
		#endregion
		
		#region Properties
		
				public virtual long OidModulo { get { return _oid_modulo; } set { _oid_modulo = value; } }
		public virtual long OidTema { get { return _oid_tema; } set { _oid_tema = value; } }
		public virtual long Nivel { get { return _nivel; } set { _nivel = value; } }
		public virtual DateTime FechaAlta { get { return _fecha_alta; } set { _fecha_alta = value; } }
		public virtual DateTime FechaPublicacion { get { return _fecha_publicacion; } set { _fecha_publicacion = value; } }
		public virtual string Texto { get { return _texto; } set { _texto = value; } }
		public virtual string Tipo { get { return _tipo; } set { _tipo = value; } }
        public virtual string Imagen { get { return _imagen; } set { _imagen = value; } }
        public virtual string ModeloRespuesta { get { return _modelo_respuesta; } set { _modelo_respuesta = value; } }
		public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
		public virtual DateTime FechaDisponibilidad { get { return _fecha_disponibilidad; } set { _fecha_disponibilidad = value; } }
		public virtual string Idioma { get { return _idioma; } set { _idioma = value; } }
		public virtual bool Activa { get { return _activa; } set { _activa = value; } }
		public virtual bool Revisada { get { return _revisada; } set { _revisada = value; } }
		public virtual bool ImagenGrande { get { return _imagen_grande; } set { _imagen_grande = value; } }
		public virtual bool Bloqueada { get { return _bloqueada; } set { _bloqueada = value; } }
		public virtual long OidSubmodulo { get { return _oid_submodulo; } set { _oid_submodulo = value; } }
		public virtual long OidOld { get { return _oid_old; } set { _oid_old = value; } }
		public virtual long Serial { get { return _serial; } set { _serial = value; } }
		public virtual string Codigo { get { return _codigo; } set { _codigo = value; } }
		public virtual bool Reservada { get { return _reservada; } set { _reservada = value; } }

		#endregion
		
		#region Business Methods
		
		public PreguntaRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_modulo = Format.DataReader.GetInt64(source, "OID_MODULO");
			_oid_tema = Format.DataReader.GetInt64(source, "OID_TEMA");
			_nivel = Format.DataReader.GetInt64(source, "NIVEL");
			_fecha_alta = Format.DataReader.GetDateTime(source, "FECHA_ALTA");
			_fecha_publicacion = Format.DataReader.GetDateTime(source, "FECHA_PUBLICACION");
			_texto = Format.DataReader.GetString(source, "TEXTO");
			_tipo = Format.DataReader.GetString(source, "TIPO");
            _imagen = Format.DataReader.GetString(source, "IMAGEN");
            _modelo_respuesta = Format.DataReader.GetString(source, "MODELO_RESPUESTA");
			_observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");
			_fecha_disponibilidad = Format.DataReader.GetDateTime(source, "FECHA_DISPONIBILIDAD");
			_idioma = Format.DataReader.GetString(source, "IDIOMA");
			_activa = Format.DataReader.GetBool(source, "ACTIVA");
			_revisada = Format.DataReader.GetBool(source, "REVISADA");
			_imagen_grande = Format.DataReader.GetBool(source, "IMAGEN_GRANDE");
			_bloqueada = Format.DataReader.GetBool(source, "BLOQUEADA");
			_oid_submodulo = Format.DataReader.GetInt64(source, "OID_SUBMODULO");
			_oid_old = Format.DataReader.GetInt64(source, "OID_OLD");
			_serial = Format.DataReader.GetInt64(source, "SERIAL");
			_codigo = Format.DataReader.GetString(source, "CODIGO");
			_reservada = Format.DataReader.GetBool(source, "RESERVADA");

		}		
		public virtual void CopyValues(PreguntaRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_modulo = source.OidModulo;
			_oid_tema = source.OidTema;
			_nivel = source.Nivel;
			_fecha_alta = source.FechaAlta;
			_fecha_publicacion = source.FechaPublicacion;
			_texto = source.Texto;
			_tipo = source.Tipo;
			_imagen = source.Imagen;
            _modelo_respuesta = source.ModeloRespuesta;
			_observaciones = source.Observaciones;
			_fecha_disponibilidad = source.FechaDisponibilidad;
			_idioma = source.Idioma;
			_activa = source.Activa;
			_revisada = source.Revisada;
			_imagen_grande = source.ImagenGrande;
			_bloqueada = source.Bloqueada;
			_oid_submodulo = source.OidSubmodulo;
			_oid_old = source.OidOld;
			_serial = source.Serial;
			_codigo = source.Codigo;
			_reservada = source.Reservada;
		}
		
		#endregion	
	}

    [Serializable()]
	public class PreguntaBase 
	{	 
		#region Attributes
		
		private PreguntaRecord _record = new PreguntaRecord();

        //NO ENLAZADAS
        private string _modulo;
        private string _submodulo;
        private string _tema;
        private DateTime _fecha_modificacion;
		
		#endregion
		
		#region Properties
		
		public PreguntaRecord Record { get { return _record; } }

        //NO ENLAZADOS
        public virtual bool Disponible { get { return _record.FechaDisponibilidad <= DateTime.Today; } }
        public virtual string ImagenWithPath { get { return ModuleController.FOTOS_PREGUNTAS_PATH + _record.Imagen; } }
        public virtual string ModeloRespuestaPath { get { return ModuleController.MODELO_PREGUNTAS_PATH + _record.ModeloRespuesta; } }
        public virtual string Modulo { get { return _modulo; } set { _modulo = value; } }
        public virtual string Submodulo { get { return _submodulo; } set { _submodulo = value; } }
        public virtual string Tema { get { return _tema; } set { _tema = value; } }
        public virtual DateTime FechaModificacion { get { return _fecha_modificacion; } set { _fecha_modificacion = value; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);

            _modulo = Format.DataReader.GetString(source, "MODULO");
            _submodulo = Format.DataReader.GetString(source, "SUBMODULO");
            _tema = Format.DataReader.GetString(source, "TEMA");
            _fecha_modificacion = Format.DataReader.GetDateTime(source, "FECHA_MODIFICACION");
		}		
		public void CopyValues(Pregunta source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _modulo = source.Modulo;
            _submodulo = source.Submodulo;
            _tema = source.Tema;
            _fecha_modificacion = source.FechaModificacion;
		}
		public void CopyValues(PreguntaInfo source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _modulo = source.Modulo;
            _submodulo = source.Submodulo;
            _tema = source.Tema;
            _fecha_modificacion = source.FechaModificacion;
		}
		
		#endregion	
	}
		
	/// <summary>
	/// Editable Root Business Object
	/// </summary>	
    [Serializable()]
	public class Pregunta : BusinessBaseEx<Pregunta>
	{	 
		#region Attributes
		
		protected PreguntaBase _base = new PreguntaBase();

        private Respuestas _respuestas = Respuestas.NewChildList();
        private Historias _historias = Historias.NewChildList();
		

		#endregion
		
		#region Properties
		
		public PreguntaBase Base { get { return _base; } }
		
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
		public virtual long OidTema
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidTema;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidTema.Equals(value))
				{
					_base.Record.OidTema = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long Nivel
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Nivel;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Nivel.Equals(value))
				{
					_base.Record.Nivel = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual DateTime FechaAlta
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.FechaAlta;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.FechaAlta.Equals(value))
				{
					_base.Record.FechaAlta = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual DateTime FechaPublicacion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.FechaPublicacion;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.FechaPublicacion.Equals(value))
				{
					_base.Record.FechaPublicacion = value;
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
		public virtual string Imagen
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Imagen;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Imagen.Equals(value))
				{
					_base.Record.Imagen = value;
					PropertyHasChanged();
				}
			}
		}
        public virtual string ModeloRespuesta
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.ModeloRespuesta;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.ModeloRespuesta.Equals(value))
                {
                    _base.Record.ModeloRespuesta = value;
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
		public virtual DateTime FechaDisponibilidad
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.FechaDisponibilidad;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.FechaDisponibilidad.Equals(value))
				{
					_base.Record.FechaDisponibilidad = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Idioma
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Idioma;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Idioma.Equals(value))
				{
					_base.Record.Idioma = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool Activa
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Activa;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Activa.Equals(value))
				{
					_base.Record.Activa = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool Revisada
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Revisada;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Revisada.Equals(value))
				{
					_base.Record.Revisada = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool ImagenGrande
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.ImagenGrande;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.ImagenGrande.Equals(value))
				{
					_base.Record.ImagenGrande = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool Bloqueada
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Bloqueada;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Bloqueada.Equals(value))
				{
					_base.Record.Bloqueada = value;
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
				//CanWriteProperty(true);
				
				if (!_base.Record.OidSubmodulo.Equals(value))
				{
					_base.Record.OidSubmodulo = value;
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
		public virtual bool Reservada
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Reservada;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Reservada.Equals(value))
				{
					_base.Record.Reservada = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual Respuestas Respuestas
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _respuestas;
            }

            set
            {
                _respuestas = value;
            }
        }
        public virtual Historias Historias
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _historias;
            }

            set
            {
                _historias = value;
            }
        }

        //NO ENLAZADOS
        public virtual bool Disponible { get { return _base.Record.FechaDisponibilidad <= DateTime.Today; } }
        public virtual string ImagenWithPath { get { return ModuleController.FOTOS_PREGUNTAS_PATH + Imagen; } }
        public virtual string ModeloRespuestaPath { get { return ModuleController.MODELO_PREGUNTAS_PATH + ModeloRespuesta; } }
        public virtual string Modulo { get { return _base.Modulo; } set { _base.Modulo = value; } }
        public virtual string Submodulo { get { return _base.Submodulo; } set { _base.Submodulo = value; } }
        public virtual string Tema { get { return _base.Tema; } set { _base.Tema = value; } }
        public virtual DateTime FechaModificacion { get { return _base.FechaModificacion; } set { _base.FechaModificacion = value; } }

        public override bool IsValid
        {
            get { return base.IsValid && _respuestas.IsValid && _historias.IsValid; }
        }
        public override bool IsDirty
        {
            get { return base.IsDirty || _respuestas.IsDirty || _historias.IsDirty; }
        }
	
		
		
		#endregion
		
		#region Business Methods				
			
        /// <summary>
        /// Clona la entidad y sus subentidades y las marca como nuevas
        /// </summary>
        /// <returns>Una entidad clon</returns>

        public virtual Pregunta CloneAsNew()
        {
            Pregunta clon = base.Clone();

            // Se define el Oid como nueva entidad
            Random rd = new Random();
            clon.Oid = rd.Next();

            clon.SessionCode = Pregunta.OpenSession();
            Pregunta.BeginTransaction(clon.SessionCode);
            clon.MarkNew();

            return clon;
        }

        public virtual Pregunta CloneAsRoot()
        {
            Pregunta clon = base.Clone();
            clon.IsRootClon = true;
            clon.SessionCode = SessionCode;

            return clon;
        }

        public static Pregunta GetCopia(Pregunta source)
        {
            Pregunta pregunta = new Pregunta();
            pregunta.Base.CopyValues(source);
            pregunta.MarkOld();
            pregunta.MarkDirty();
            return pregunta;
        }
        
        /// Copia los atributos del objeto
        /// <summary>        
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyFrom(PreguntaExamenInfo source)
        {
            if (source == null) return;

            CopyFrom(source);

            if (source.RespuestaExamenes != null)
                _respuestas = Respuestas.GetChildList(source.RespuestaExamenes);
        }

        /// <summary>
        /// Devuelve el siguiente código de Módulo.
        /// </summary>
        /// <returns>Código de 9 cifras</returns>
        public static string GetNewCode()
        {
            Int64 lastcode = Pregunta.GetNewSerial();

            // Devolvemos el siguiente codigo de cliente 
            return lastcode.ToString(Resources.Defaults.PREGUNTA_CODE_FORMAT);
        }

        /// <summary>
        /// Devuelve el siguiente Serial de Alumno.
        /// </summary>
        /// <returns>Código de 9 cifras</returns>
        public static Int64 GetNewSerial()
        {
            // Obtenemos la lista de clientes ordenados por serial
            SortedBindingList<PreguntaInfo> preguntas =
                PreguntaList.GetSortedList("Serial", ListSortDirection.Ascending);

            // Obtenemos el último serial de servicio
            Int64 lastcode;

            if (preguntas.Count > 0)
                lastcode = preguntas[preguntas.Count - 1].Serial;
            else
                lastcode = Convert.ToInt64(Resources.Defaults.PREGUNTA_CODE_FORMAT);

            lastcode++;
            return lastcode;
        }
               
        public virtual void CheckChanges(Pregunta pregunta)
        {
            if (pregunta.Respuestas == null) return;

            for (int i = 0; i < Respuestas.Count; i++)
            {
                FCriteria<string> criteria = new FCriteria<string>("Opcion", Respuestas[i].Opcion);
                Respuesta item = pregunta.Respuestas.GetItem(criteria);
                if (item != null)
                    Respuestas[i].CheckChanges(item, this);
                else
                {
                    Historia historia = Historias.NewItem(this);

                    historia.Texto += System.Environment.NewLine
                        + "Nueva respuesta añadida; Opción: " + Respuestas[i].Opcion + "; Usuario: " + AppContext.User.Name + ";";
                    historia.Fecha = DateTime.Now.Date;
                    historia.Hora = DateTime.Now;
                }
            }
            for (int i = 0; i < pregunta.Respuestas.Count; i++)
            {
                FCriteria<string> criteria = new FCriteria<string>("Opcion", pregunta.Respuestas[i].Opcion);
                Respuesta item = Respuestas.GetItem(criteria);
                if (item == null)
                {
                    Historia historia = Historias.NewItem(this);

                    historia.Texto += System.Environment.NewLine
                        + "Respuesta eliminada; Opción: " + pregunta.Respuestas[i].Opcion + "; Usuario: " + AppContext.User.Name + ";";
                    historia.Fecha = DateTime.Now.Date;
                    historia.Hora = DateTime.Now;
                }
            }
        }
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidModulo", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidSubmodulo", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidTema", 1));
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
        protected Pregunta() { }

        protected Pregunta(PreguntaExamenInfo source)
        {
            CopyFrom(source);
        }

        public static Pregunta NewChild(PreguntaExamenInfo source)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Pregunta obj = new Pregunta(source);
            obj.MarkAsChild();
            return obj;
        }

        public virtual PreguntaInfo GetInfo(bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new PreguntaInfo(this, get_childs);
        }

        public virtual PreguntaInfo GetInfo()
        {
            return GetInfo(true);
        }

        public virtual void LoadRespuestas()
        {
            Respuestas = Respuestas.GetChildList(this);
        }

        public virtual void LoadHistorias()
        {
            Historias = Historias.GetChildList(this);
        }

        #endregion

        #region Root Factory Methods

        public static Pregunta New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<Pregunta>(new CriteriaCs(-1));
        }

        public static Pregunta Get(long oid)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = Pregunta.GetCriteria(Pregunta.OpenSession());

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = Pregunta.SELECT(oid);
            else
                criteria.AddOidSearch(oid);

            Pregunta.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Pregunta>(criteria);
        }

        public static Pregunta Get(CriteriaEx criteria)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Pregunta.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Pregunta>(criteria);
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
        /// Elimina todas los Preguntas
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = Pregunta.OpenSession();
            ISession sess = Pregunta.Session(sessCode);
            ITransaction trans = Pregunta.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from Pregunta");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                Pregunta.CloseSession(sessCode);
            }
        }

        public override Pregunta Save()
        {
            // Por interfaz Root/Child
            if (!IsRootClon && IsChild) throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);

            //bool success = false;

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

                base.SaveAsChild();

                _respuestas.Update(this);
                _historias.Update(this);
                
                if (!SharedTransaction) Transaction().Commit();

                //success = true;
                return this;
            }
            catch (iQValidationException ex)
            {
                //Child Validation
                throw new iQValidationException(ex.Message, ex.SysMessage);
            }
            catch (ValidationException ex)
            {
                //Object Validation
                throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR,
                                                ex.Message);
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

        private Pregunta(Pregunta source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private Pregunta(int session_code, IDataReader reader, bool childs)
        {
            MarkAsChild();
            Childs = childs;
            Fetch(session_code, reader);
        }

        //public static Pregunta NewChild(Modulo parent)
        //{
        //    if (!CanAddObject())
        //        throw new System.Security.SecurityException(
        //            moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

        //    Pregunta obj = new Pregunta();
        //    obj.OidModulo = parent.Oid;
        //    return obj;
        //}

        //public static Pregunta NewChild(Tema parent)
        //{
        //    if (!CanAddObject())
        //        throw new System.Security.SecurityException(
        //            moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

        //    Pregunta obj = new Pregunta();
        //    obj.OidTema = parent.Oid;
        //    return obj;
        //}

        internal static Pregunta GetChild(Pregunta source)
        {
            return new Pregunta(source);
        }

        internal static Pregunta GetChild(int session_code, IDataReader reader, bool childs)
        {
            return new Pregunta(session_code, reader, childs);
        }


        internal static Pregunta GetChild(int session_code, IDataReader reader)
        {
            return GetChild(session_code, reader, true);
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

        private void Fetch(Pregunta source)
        {
            try
            {
                SessionCode = source.SessionCode;

                _base.CopyValues(source);

                if (Childs)
                {
                    Respuesta.DoLOCK(Session());

                    string query = Respuestas.SELECT_BY_PREGUNTA(this.Oid);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _respuestas = Respuestas.GetChildList(reader);

                    Historia.DoLOCK(Session());

                    query = Historias.SELECT_BY_PREGUNTA(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _historias = Historias.GetChildList(reader);
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        private void Fetch(int session_code, IDataReader source)
        {
            try
            {
                _base.CopyValues(source);

                if (Childs)
                {
                    Respuesta.DoLOCK( Session(session_code));

                    string query = Respuestas.SELECT_BY_PREGUNTA(this.Oid);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _respuestas = Respuestas.GetChildList(reader);

                    Historia.DoLOCK( Session(session_code));

                    query = Historias.SELECT_BY_PREGUNTA(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _historias = Historias.GetChildList(reader);
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
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

        //        _respuestas.Update(this);
        //        _historias.Update(this);
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

        //        Pregunta obj = parent.Session().Get<Pregunta>(Oid);
        //        obj.CopyValues(this);
        //        parent.Session().Update(obj);

        //        _respuestas.Update(this);
        //        _historias.Update(this);
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
        //        Session().Delete(Session().Get<Pregunta>(Oid));
        //    }
        //    catch (Exception ex)
        //    {
        //        iQExceptionHandler.TreatException(ex);
        //    }

        //    MarkNew();
        //}

        //internal void Insert(Tema parent)
        //{
        //    // if we're not dirty then don't update the database
        //    if (!this.IsDirty) return;

        //    //Debe obtener la sesion del padre pq el objeto es padre a su vez
        //    SessionCode = parent.SessionCode;

        //    _oid_tema = parent.Oid;

        //    try
        //    {
        //        ValidationRules.CheckRules();

        //        if (!IsValid)
        //            throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

        //        parent.Session().Save(this);

        //        _respuestas.Update(this);
        //        _historias.Update(this);
        //    }
        //    catch (Exception ex)
        //    {
        //        iQExceptionHandler.TreatException(ex);
        //    }

        //    MarkOld();
        //}

        //internal void Update(Tema parent)
        //{
        //    // if we're not dirty then don't update the database
        //    if (!this.IsDirty) return;

        //    //Debe obtener la sesion del padre pq el objeto es padre a su vez
        //    SessionCode = parent.SessionCode;

        //    _oid_tema = parent.Oid;

        //    try
        //    {
        //        ValidationRules.CheckRules();

        //        if (!IsValid)
        //            throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

        //        Pregunta obj = parent.Session().Get<Pregunta>(Oid);
        //        obj.CopyValues(this);
        //        parent.Session().Update(obj);

        //        _respuestas.Update(this);
        //        _historias.Update(this);
        //    }
        //    catch (Exception ex)
        //    {
        //        iQExceptionHandler.TreatException(ex);
        //    }

        //    MarkOld();
        //}

        //internal void DeleteSelf(Tema parent)
        //{
        //    // if we're not dirty then don't update the database
        //    if (!this.IsDirty) return;

        //    // if we're new then don't update the database
        //    if (this.IsNew) return;

        //    try
        //    {
        //        SessionCode = parent.SessionCode;
        //        Session().Delete(Session().Get<Pregunta>(Oid));
        //    }
        //    catch (Exception ex)
        //    {
        //        iQExceptionHandler.TreatException(ex);
        //    }

        //    MarkNew();
        //}

        internal void DeleteSelf(Preguntas parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                SessionCode = parent.SessionCode;
                Session().Delete(Session().Get<PreguntaRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }

        internal void Insert(Preguntas parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

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

        internal void Update(Preguntas parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            SessionCode = parent.SessionCode;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                PreguntaRecord obj = Session().Get<PreguntaRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                Session().Update(obj);

                _respuestas.Update(this);
                _historias.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
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
                    Pregunta.DoLOCK(Session());
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        Respuesta.DoLOCK(Session());

                        string query = Respuestas.SELECT_BY_PREGUNTA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _respuestas = Respuestas.GetChildList(reader);

                        Historia.DoLOCK(Session());

                        query = Historias.SELECT_BY_PREGUNTA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _historias = Historias.GetChildList(reader);
                    }
                }
                else
                {
                    _base.Record.CopyValues((PreguntaRecord)(criteria.UniqueResult()));

                    //Session().Lock(Session().Get<PreguntaRecord>(Oid), LockMode.UpgradeNoWait);

                    if (Childs)
                    {
                        criteria = Respuesta.GetCriteria(Session());
                        criteria.AddEq("OidPregunta", this.Oid);
                        _respuestas = Respuestas.GetChildList(criteria.List<Respuesta>());

                        criteria = Historia.GetCriteria(Session());
                        criteria.AddEq("OidPregunta", this.Oid);
                        _historias = Historias.GetChildList(criteria.List<Historia>());
                    }
                }
            }
            catch (Exception exception)
            {
                if (Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(exception);
            }
        }

        [Transactional(TransactionalTypes.Manual)]
        protected override void DataPortal_Insert()
        {
            try
            {
                SessionCode = OpenSession();
                BeginTransaction();
                Codigo = GetNewCode();
                Serial = GetNewSerial();
                Session().Save(this.Base.Record);
            }
            catch (Exception exception)
            {
                iQExceptionHandler.TreatException(exception);
            }
        }

        [Transactional(TransactionalTypes.Manual)]
        protected override void DataPortal_Update()
        {
            if (IsDirty)
            {
                try
                {
                    PreguntaRecord obj = Session().Get<PreguntaRecord>(Oid);
                    obj.CopyValues(this.Base.Record);
                    Session().Update(obj);
                }
                catch (Exception exception)
                {
                    iQExceptionHandler.TreatException(exception);
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
                PreguntaRecord obj = (PreguntaRecord)(criteria.UniqueResult());
                Session().Delete(Session().Get<PreguntaRecord>(obj.Oid));

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

        public static void InitializeReservadas()
        {
            string query = SET_RESERVADAS_FALSE();
            CriteriaEx criteria = Pregunta.GetCriteria(Pregunta.OpenSession());
            nHManager.Instance.SQLNativeExecute(query);
            CloseSession(criteria.SessionCode);
        }

        public static void FormatReservada(long oid)
        {
            string query = UPDATE_RESERVADA(oid);
            CriteriaEx criteria = Pregunta.GetCriteria(Pregunta.OpenSession());
            nHManager.Instance.SQLNativeExecute(query);
            CloseSession(criteria.SessionCode);
        }

        public static void FormatDisponibilidad(long oid, DateTime fecha_disponibilidad)
        {
            string query = UPDATE_DISPONIBILIDAD(oid, fecha_disponibilidad);
            CriteriaEx criteria = Pregunta.GetCriteria(Pregunta.OpenSession());
            nHManager.Instance.SQLNativeExecute(query);
            CloseSession(criteria.SessionCode);
        }

        /// <summary>
        /// Construye un SELECT para el esquema dado
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="sesion">sesión abierta para la transacción</param>
        /// <returns></returns>
        public new static string SELECT(string schema, long oid)
        {
            string pregunta = nHManager.Instance.Cfg.GetClassMapping(typeof(PreguntaRecord)).Table.Name;
            string modulo = nHManager.Instance.Cfg.GetClassMapping(typeof(ModuloRecord)).Table.Name;
            string submodulo = nHManager.Instance.Cfg.GetClassMapping(typeof(SubmoduloRecord)).Table.Name;
            string tema = nHManager.Instance.Cfg.GetClassMapping(typeof(TemaRecord)).Table.Name;
            string oid_modulo = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "OidModulo");
            string oid_submodulo = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "OidSubmodulo");
            string oid_tema = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "OidTema");

            string query;

            string esquema = Convert.ToInt32(schema).ToString("0000");

            query = "SELECT p.*, m.\"TEXTO\" AS \"MODULO\", s.\"TEXTO\" AS \"SUBMODULO\", t.\"CODIGO\" AS \"TEMA\", " +
                    "m.\"NUMERO_MODULO\", s.\"CODIGO\", t.\"CODIGO_ORDEN\" AS \"ORDEN\"  " +
                    "FROM \"" + esquema + "\".\"" + pregunta + "\" AS p " +
                    "INNER JOIN \"" + esquema + "\".\"" + modulo + "\" AS m ON (p.\"" + oid_modulo + "\" = m.\"OID\") " +
                    "INNER JOIN \"" + esquema + "\".\"" + submodulo + "\" AS s ON (p.\"" + oid_submodulo + "\" = s.\"OID\") " +
                    "INNER JOIN \"" + esquema + "\".\"" + tema + "\" AS t ON (p.\"" + oid_tema + "\" = t.\"OID\") " +
                    "WHERE p.\"OID\" = " + oid.ToString() + ";";

            return query;
        }


        public static string SET_RESERVADAS_FALSE()
        {
            string pregunta = nHManager.Instance.Cfg.GetClassMapping(typeof(PreguntaRecord)).Table.Name;
            string c_reservada = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "Reservada");

            string query;

            string esquema = Convert.ToInt32(AppContext.ActiveSchema.Code).ToString("0000");

            query = "UPDATE " + "\"" + esquema + "\".\"" + pregunta + "\" " +
                    "SET \"" + c_reservada + "\" = 'false';";

            return query;
        }

        public static string UPDATE_RESERVADA(long oid)
        {
            string pregunta = nHManager.Instance.Cfg.GetClassMapping(typeof(PreguntaRecord)).Table.Name;
            string c_reservada = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "Reservada");
            string c_bloqueada = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "Bloqueada");
            string c_fecha_disponibilidad = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "FechaDisponibilidad");

            string fecha = DateTime.Today.Year.ToString() + "-" +
                DateTime.Today.Month.ToString() + "-" +
                DateTime.Today.Day.ToString();

            string query;

            string esquema = Convert.ToInt32(AppContext.ActiveSchema.Code).ToString("0000");

            query = "UPDATE " + "\"" + esquema + "\".\"" + pregunta + "\" " +
                    "SET \"" + c_fecha_disponibilidad + "\" = '" + fecha + "', " +
                    "\"" + c_reservada + "\" = 'true', " +
                    "\"" + c_bloqueada + "\" = 'false' " +
                    "WHERE \"OID\" = " + oid.ToString() + ";";

            return query;
        }

        public static string UPDATE_DISPONIBILIDAD(long oid, DateTime fecha_disponibilidad)
        {
            string pregunta = nHManager.Instance.Cfg.GetClassMapping(typeof(PreguntaRecord)).Table.Name;
            string c_fecha_disponibilidad = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "FechaDisponibilidad");

            string fecha = fecha_disponibilidad.Year.ToString() + "-" +
                fecha_disponibilidad.Month.ToString() + "-" +
                fecha_disponibilidad.Day.ToString();

            string query;

            string esquema = Convert.ToInt32(AppContext.ActiveSchema.Code).ToString("0000");

            query = "UPDATE " + "\"" + esquema + "\".\"" + pregunta + "\" " +
                    "SET \"" + c_fecha_disponibilidad + "\" = '" + fecha + "' " +
                    "WHERE \"OID\" = " + oid.ToString() + ";";

            return query;
        }

        #endregion

        #region SQL

        internal static string SELECT_FIELDS()
        {
            string query;

            query = "SELECT P.*," +
                    "       (M.\"NUMERO_MODULO\" || ' ' || M.\"TEXTO\") AS \"MODULO\"," +
                    "       S.\"CODIGO\", S.\"TEXTO\" AS \"SUBMODULO\"," +
                    "       T.\"CODIGO\" AS \"TEMA\"," +
                    "       T.\"CODIGO_ORDEN\" AS \"ORDEN\", " +
                    "       COALESCE(\"LAST_UPDATE\", \"FECHA_ALTA\") AS \"FECHA_MODIFICACION\"";

            return query;
        }

        internal static string SELECT(long oid, bool lock_table, string order)
        {
            string p = nHManager.Instance.GetSQLTable(typeof(PreguntaRecord));
            string s = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
            string t = nHManager.Instance.GetSQLTable(typeof(TemaRecord));
            string m = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string h = nHManager.Instance.GetSQLTable(typeof(HistoriaRecord));

            string query;

            query = Pregunta.SELECT_FIELDS() +
                    " FROM " + p + " AS P" +
                    " INNER JOIN " + m + " AS M ON P.\"OID_MODULO\" = M.\"OID\"" +
                    " INNER JOIN " + t + " AS T ON P.\"OID_TEMA\" = T.\"OID\"" +
                    " INNER JOIN " + s + " AS S ON P.\"OID_SUBMODULO\" = S.\"OID\"" +
                    " LEFT JOIN ( SELECT MAX(H.\"FECHA\") AS \"LAST_UPDATE\", H.\"OID_PREGUNTA\" FROM " + h + " AS H GROUP BY H.\"OID_PREGUNTA\") AS H ON H.\"OID_PREGUNTA\" = P.\"OID\"";

            if (oid > 0)
                query += " WHERE P.\"OID\" = " + oid.ToString();
            else
                query += " WHERE TRUE";

            if (order == string.Empty) query += " ORDER BY P.\"CODIGO\"";
            else query += order;

            if (lock_table) query += " FOR UPDATE OF P NOWAIT";

            return query;
        }

        internal new static string SELECT(long oid) { return Pregunta.SELECT(oid, false, string.Empty); }

        #endregion
        
    }
}

