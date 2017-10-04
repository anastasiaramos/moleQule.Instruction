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
	public class PreguntaExamenRecord : RecordBase
	{
		#region Attributes

		private long _oid_examen;
		private long _oid_modulo;
		private long _oid_tema;
		private long _nivel;
		private DateTime _fecha_alta;
		private DateTime _fecha_publicacion;
		private string _texto = string.Empty;
		private string _tipo = string.Empty;
        private string _imagen = string.Empty;
        private string _modelo_respuesta = string.Empty;
		private string _idioma = string.Empty;
		private bool _imagen_grande = false;
		private string _observaciones = string.Empty;
		private long _orden;
		private long _oid_submodulo_old;
		private string _codigo_submodulo = string.Empty;
		private long _oid_pregunta_old;
		private long _oid_pregunta;
		private bool _anulada = false;
  
		#endregion
		
		#region Properties
		
				public virtual long OidExamen { get { return _oid_examen; } set { _oid_examen = value; } }
		public virtual long OidModulo { get { return _oid_modulo; } set { _oid_modulo = value; } }
		public virtual long OidTema { get { return _oid_tema; } set { _oid_tema = value; } }
		public virtual long Nivel { get { return _nivel; } set { _nivel = value; } }
		public virtual DateTime FechaAlta { get { return _fecha_alta; } set { _fecha_alta = value; } }
		public virtual DateTime FechaPublicacion { get { return _fecha_publicacion; } set { _fecha_publicacion = value; } }
		public virtual string Texto { get { return _texto; } set { _texto = value; } }
		public virtual string Tipo { get { return _tipo; } set { _tipo = value; } }
        public virtual string Imagen { get { return _imagen; } set { _imagen = value; } }
        public virtual string ModeloRespuesta { get { return _modelo_respuesta; } set { _modelo_respuesta = value; } }
		public virtual string Idioma { get { return _idioma; } set { _idioma = value; } }
		public virtual bool ImagenGrande { get { return _imagen_grande; } set { _imagen_grande = value; } }
		public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
		public virtual long Orden { get { return _orden; } set { _orden = value; } }
		public virtual long OidSubmoduloOld { get { return _oid_submodulo_old; } set { _oid_submodulo_old = value; } }
		public virtual string CodigoSubmodulo { get { return _codigo_submodulo; } set { _codigo_submodulo = value; } }
		public virtual long OidPreguntaOld { get { return _oid_pregunta_old; } set { _oid_pregunta_old = value; } }
		public virtual long OidPregunta { get { return _oid_pregunta; } set { _oid_pregunta = value; } }
		public virtual bool Anulada { get { return _anulada; } set { _anulada = value; } }

		#endregion
		
		#region Business Methods
		
		public PreguntaExamenRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_examen = Format.DataReader.GetInt64(source, "OID_EXAMEN");
			_oid_modulo = Format.DataReader.GetInt64(source, "OID_MODULO");
			_oid_tema = Format.DataReader.GetInt64(source, "OID_TEMA");
			_nivel = Format.DataReader.GetInt64(source, "NIVEL");
			_fecha_alta = Format.DataReader.GetDateTime(source, "FECHA_ALTA");
			_fecha_publicacion = Format.DataReader.GetDateTime(source, "FECHA_PUBLICACION");
			_texto = Format.DataReader.GetString(source, "TEXTO");
			_tipo = Format.DataReader.GetString(source, "TIPO");
            _imagen = Format.DataReader.GetString(source, "IMAGEN");
            _modelo_respuesta = Format.DataReader.GetString(source, "MODELO_RESPUESTA");
			_idioma = Format.DataReader.GetString(source, "IDIOMA");
			_imagen_grande = Format.DataReader.GetBool(source, "IMAGEN_GRANDE");
			_observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");
			_orden = Format.DataReader.GetInt64(source, "ORDEN");
			_oid_submodulo_old = Format.DataReader.GetInt64(source, "OID_SUBMODULO_OLD");
			_codigo_submodulo = Format.DataReader.GetString(source, "CODIGO_SUBMODULO");
			_oid_pregunta_old = Format.DataReader.GetInt64(source, "OID_PREGUNTA_OLD");
			_oid_pregunta = Format.DataReader.GetInt64(source, "OID_PREGUNTA");
			_anulada = Format.DataReader.GetBool(source, "ANULADA");

		}		
		public virtual void CopyValues(PreguntaExamenRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_examen = source.OidExamen;
			_oid_modulo = source.OidModulo;
			_oid_tema = source.OidTema;
			_nivel = source.Nivel;
			_fecha_alta = source.FechaAlta;
			_fecha_publicacion = source.FechaPublicacion;
			_texto = source.Texto;
			_tipo = source.Tipo;
            _imagen = source.Imagen;
            _modelo_respuesta = source.ModeloRespuesta;
			_idioma = source.Idioma;
			_imagen_grande = source.ImagenGrande;
			_observaciones = source.Observaciones;
			_orden = source.Orden;
			_oid_submodulo_old = source.OidSubmoduloOld;
			_codigo_submodulo = source.CodigoSubmodulo;
			_oid_pregunta_old = source.OidPreguntaOld;
			_oid_pregunta = source.OidPregunta;
			_anulada = source.Anulada;
		}
		
		#endregion	
	}

    [Serializable()]
	public class PreguntaExamenBase 
	{	 
		#region Attributes
		
		private PreguntaExamenRecord _record = new PreguntaExamenRecord();

        //NO ENLAZADAS
        private string _submodulo;
        private string _n_pregunta;
        private string _tema;
		
		#endregion
		
		#region Properties
		
		public PreguntaExamenRecord Record { get { return _record; } }

        //NO ENLAZADOS
        public virtual string ImagenWithPath { get { return ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH + Record.OidExamen.ToString("00000") + "\\" + Record.Imagen; } }
        public virtual string ModeloRespuestaPath { get { return ModuleController.MODELO_PREGUNTAS_EXAMEN_PATH + Record.OidExamen.ToString("00000") + "\\" + Record.ModeloRespuesta; } }
        public virtual string Submodulo { get { return _submodulo; } set { _submodulo = value; } }
        public virtual string NPregunta { get { return _n_pregunta; } set { _n_pregunta = value; } }
        public virtual string Tema { get { return _tema; } set { _tema = value; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);

                _submodulo = Format.DataReader.GetString(source, "SUBMODULO");
                _n_pregunta = Format.DataReader.GetString(source, "N_PREGUNTA");
                _tema = Format.DataReader.GetString(source, "TEMA");
		}		
		public void CopyValues(PreguntaExamen source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _submodulo = source.Submodulo;
            _n_pregunta = source.NPregunta;
            _tema = source.Tema;
		}
		public void CopyValues(PreguntaExamenInfo source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _submodulo = source.Submodulo;
            _n_pregunta = source.NPregunta;
            _tema = source.Tema;
		}
		
		#endregion	
	}
		
	/// <summary>
	/// Editable Root Business Object
	/// </summary>	
    [Serializable()]
	public class PreguntaExamen : BusinessBaseEx<PreguntaExamen>
	{	 
		#region Attributes
		
		protected PreguntaExamenBase _base = new PreguntaExamenBase();

        private RespuestaExamens _respuestas = RespuestaExamens.NewChildList();        

		#endregion
		
		#region Properties
		
		public PreguntaExamenBase Base { get { return _base; } }
		
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
		public virtual long Orden
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Orden;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Orden.Equals(value))
				{
					_base.Record.Orden = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidSubmoduloOld
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidSubmoduloOld;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidSubmoduloOld.Equals(value))
				{
					_base.Record.OidSubmoduloOld = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string CodigoSubmodulo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.CodigoSubmodulo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.CodigoSubmodulo.Equals(value))
				{
					_base.Record.CodigoSubmodulo = value;
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
		public virtual bool Anulada
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Anulada;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Anulada.Equals(value))
				{
					_base.Record.Anulada = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual RespuestaExamens RespuestaExamens
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

        //NO ENLAZADOS
        public virtual string ImagenWithPath { get { return ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH + OidExamen.ToString("00000") + "\\" + Imagen; } }
        public virtual string ModeloRespuestaPath { get { return ModuleController.MODELO_PREGUNTAS_EXAMEN_PATH + OidExamen.ToString("00000") + "\\" + ModeloRespuesta; } }
        public virtual string Submodulo { get { return _base.Submodulo; } set { _base.Submodulo = value; } }
        public virtual string NPregunta { get { return _base.NPregunta; } set { _base.NPregunta = value; } }
        public virtual string Tema { get { return _base.Tema; } set { _base.Tema = value; } }

        public override bool IsValid
        {
            get { return base.IsValid && _respuestas.IsValid; }
        }
        public override bool IsDirty
        {
            get { return base.IsDirty || _respuestas.IsDirty; }
        }
	
		
		
		#endregion
		
		#region Business Methods
				
		protected virtual void CopyFrom(PreguntaExamenInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidExamen = source.OidExamen;
			OidModulo = source.OidModulo;
			OidTema = source.OidTema;
			Nivel = source.Nivel;
			FechaAlta = source.FechaAlta;
			FechaPublicacion = source.FechaPublicacion;
			Texto = source.Texto;
			Tipo = source.Tipo;
            Imagen = source.Imagen;
            ModeloRespuesta = source.ModeloRespuesta;
			Idioma = source.Idioma;
			ImagenGrande = source.ImagenGrande;
			Observaciones = source.Observaciones;
			Orden = source.Orden;
			OidSubmoduloOld = source.Base.Record.OidSubmoduloOld;
			CodigoSubmodulo = source.Base.Record.CodigoSubmodulo;
			OidPreguntaOld = source.OidPreguntaOld;
			OidPregunta = source.OidPregunta;
			Anulada = source.Anulada;
		}
        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        public virtual void CopyValues(PreguntaInfo source)
        {
            if (source == null) return;

            _base.Record.OidModulo = source.OidModulo;
            _base.Record.OidTema = source.OidTema;
            _base.Record.OidPregunta = source.Oid;
            _base.Record.Nivel = source.Nivel;
            _base.Record.FechaAlta = source.FechaAlta;
            _base.Record.FechaPublicacion = source.FechaPublicacion;
            _base.Record.Texto = source.Texto;
            _base.Record.Tipo = source.Tipo;
            _base.Record.Imagen = string.Empty;
            _base.Record.ModeloRespuesta = source.ModeloRespuesta;
            _base.Record.Idioma = source.Idioma;
            //if (source.Idioma == "Español") _idioma = "Espanol";
            //else
            //{
            //    if (source.Idioma == "Inglés") _idioma = "Ingles";
            //    else _idioma = source.Idioma;
            //}
            _base.Record.Observaciones = source.Observaciones;
            _base.Record.ImagenGrande = source.ImagenGrande;

            _base.Submodulo = source.Modulo;
            _base.NPregunta = source.Codigo;
            _base.Tema = source.Tema;
        }

        /// <summary>
        /// Clona la entidad y sus subentidades y las marca como nuevas
        /// </summary>
        /// <returns>Una entidad clon</returns>

        public virtual PreguntaExamen CloneAsNew()
        {
            PreguntaExamen clon = base.Clone();

            // Se define el Oid como nueva entidad
            Random rd = new Random();
            clon.Oid = rd.Next();

            clon.SessionCode = PreguntaExamen.OpenSession();
            PreguntaExamen.BeginTransaction(clon.SessionCode);
            clon.MarkNew();

            return clon;
        }
		
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidExamen", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidModulo", 1));

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
        /// Debería ser private para CSLA porque la creación requiere el uso de los Factory Methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        public PreguntaExamen()
        {
            MarkAsChild();
            Random r = new Random();
            Oid = (long)r.Next();
        }

        public virtual PreguntaExamenInfo GetInfo(bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new PreguntaExamenInfo(this, get_childs);
        }

        public virtual PreguntaExamenInfo GetInfo()
        {
            return GetInfo(true);
        }

        #endregion

        #region Root Factory Methods

        public static PreguntaExamen New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<PreguntaExamen>(new CriteriaCs(-1));
        }

        public static PreguntaExamen Get(long oid) { return Get(oid, true); }

        public static PreguntaExamen Get(long oid, bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = PreguntaExamen.GetCriteria(PreguntaExamen.OpenSession());
            criteria.Childs = get_childs;

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = PreguntaExamen.SELECT(oid);
            else
                criteria.AddOidSearch(oid);

            PreguntaExamen.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<PreguntaExamen>(criteria);
        }

        public static PreguntaExamen Get(CriteriaEx criteria)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            PreguntaExamen.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<PreguntaExamen>(criteria);
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
        /// Elimina todas los PreguntaExamens
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = PreguntaExamen.OpenSession();
            ISession sess = PreguntaExamen.Session(sessCode);
            ITransaction trans = PreguntaExamen.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from PreguntaExamen");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                PreguntaExamen.CloseSession(sessCode);
            }
        }

        public override PreguntaExamen Save()
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

                _respuestas.Update(this);

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

        private PreguntaExamen(PreguntaExamen source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private PreguntaExamen(int session_code, IDataReader reader, bool childs)
        {
            MarkAsChild();
            Childs = childs;
            Fetch(session_code, reader);
        }

        public static PreguntaExamen NewChild(Examen parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            PreguntaExamen obj = new PreguntaExamen();
            obj.OidExamen = parent.Oid;
            return obj;
        }

        //public static PreguntaExamen NewChild(Modulo parent)
        //{
        //    if (!CanAddObject())
        //        throw new System.Security.SecurityException(
        //            moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

        //    PreguntaExamen obj = new PreguntaExamen();
        //    obj.OidModulo = parent.Oid;
        //    return obj;
        //}

        //public static PreguntaExamen NewChild(Tema parent)
        //{
        //    if (!CanAddObject())
        //        throw new System.Security.SecurityException(
        //            moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

        //    PreguntaExamen obj = new PreguntaExamen();
        //    obj.OidTema = parent.Oid;
        //    return obj;
        //}

        internal static PreguntaExamen GetChild(PreguntaExamen source)
        {
            return new PreguntaExamen(source);
        }

        internal static PreguntaExamen GetChild(int session_code, IDataReader reader, bool childs)
        {
            return new PreguntaExamen(session_code, reader, childs);
        }
        
        internal static PreguntaExamen GetChild(int session_code, IDataReader reader)
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

        private void Fetch(PreguntaExamen source)
        {
            try
            {
                SessionCode = source.SessionCode;

                _base.CopyValues(source);

                CriteriaEx criteria = RespuestaExamen.GetCriteria(Session());
                criteria.AddEq("OidPregunta", this.Oid);
                _respuestas = RespuestaExamens.GetChildList(criteria.List<RespuestaExamen>());


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
                    RespuestaExamen.DoLOCK( Session(session_code));

                    string query = RespuestaExamens.SELECT_BY_PREGUNTA_EXAMEN(this.Oid, this.OidExamen);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _respuestas = RespuestaExamens.GetChildList(reader);
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

        //        PreguntaExamen obj = parent.Session().Get<PreguntaExamen>(Oid);
        //        obj.CopyValues(this);
        //        parent.Session().Update(obj);

        //        _respuestas.Update(this);
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
        //        Session().Delete(Session().Get<PreguntaExamen>(Oid));
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

        //        PreguntaExamen obj = parent.Session().Get<PreguntaExamen>(Oid);
        //        obj.CopyValues(this);
        //        parent.Session().Update(obj);

        //        _respuestas.Update(this);
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
        //        Session().Delete(Session().Get<PreguntaExamen>(Oid));
        //    }
        //    catch (Exception ex)
        //    {
        //        iQExceptionHandler.TreatException(ex);
        //    }

        //    MarkNew();
        //}

        internal void Insert(Examen parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidExamen = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                parent.Session().Save(this.Base.Record);

                _respuestas.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Update(Examen parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidExamen = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                PreguntaExamenRecord obj = parent.Session().Get<PreguntaExamenRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);

                _respuestas.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }


        internal void DeleteSelf(Examen parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                SessionCode = parent.SessionCode;
                Session().Delete(Session().Get<PreguntaExamenRecord>(Oid));
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
                    PreguntaExamen.DoLOCK(Session());
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(criteria.Query, Session());

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        RespuestaExamen.DoLOCK(Session());

                        string query = RespuestaExamens.SELECT_BY_PREGUNTA_EXAMEN(this.Oid, this.OidExamen);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _respuestas = RespuestaExamens.GetChildList(reader);
                    }
                }
                else
                {
                    _base.Record.CopyValues((PreguntaExamenRecord)(criteria.UniqueResult()));

                    //Session().Lock(Session().Get<PreguntaExamenRecord>(Oid), LockMode.UpgradeNoWait);

                    if (Childs)
                    {
                        criteria = RespuestaExamen.GetCriteria(Session());
                        criteria.AddEq("OidPregutaExamen", this.Oid);
                        _respuestas = RespuestaExamens.GetChildList(criteria.List<RespuestaExamen>());
                    }
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
                    PreguntaExamenRecord obj = Session().Get<PreguntaExamenRecord>(Oid);
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
                PreguntaExamenRecord obj = (PreguntaExamenRecord)(criteria.UniqueResult());
                Session().Delete(Session().Get<PreguntaExamenRecord>(obj.Oid));

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

        public static string SELECT_FIELDS()
        {
            string query;

            query = "SELECT PE.*," +
                    "       COALESCE(P.\"CODIGO\", '00000') AS \"N_PREGUNTA\"," +
                    "       COALESCE(S.\"CODIGO\" || ' ' || S.\"TEXTO\", '') AS \"SUBMODULO\"," +
                    "       COALESCE(T.\"CODIGO\" || ' ' || T.\"NOMBRE\", '') AS \"TEMA\"";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string pe = nHManager.Instance.GetSQLTable(typeof(PreguntaExamenRecord));
            string p = nHManager.Instance.GetSQLTable(typeof(PreguntaRecord));
            string sm = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
            string t = nHManager.Instance.GetSQLTable(typeof(TemaRecord));

            query = "   FROM   " + pe + "   AS PE" +
                    " LEFT JOIN " + p + " AS P ON PE.\"OID_PREGUNTA\" = P.\"OID\"" +
                    " LEFT JOIN " + t + " AS T ON PE.\"OID_TEMA\" = T.\"OID\"" +
                    " LEFT JOIN " + sm + " AS S ON T.\"OID_SUBMODULO\" = S.\"OID\"";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.Examen != null && conditions.Examen.Oid > 0)
                query += " AND PE.\"OID_EXAMEN\" = " + conditions.Examen.Oid;

            if (conditions.Oid > 0)
                query += " AND PE.\"OID\" = " + conditions.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions) +
                    " ORDER BY PE.\"ORDEN\"";

            if (lockTable) query += " FOR UPDATE OF PE NOWAIT";

            return query;
        }

        #endregion
    }
}

