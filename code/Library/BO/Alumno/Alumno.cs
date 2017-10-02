using System;
using System.ComponentModel;
using System.Data;
using System.Reflection;

using Csla;
using Csla.Validation;
using NHibernate;
using NHibernate.Impl;

using moleQule.Library;
using moleQule.Library.CslaEx;

namespace moleQule.Library.Instruction
{
    [Serializable()]
    public class AlumnoRecord : RecordBase
    {
        #region Attributes

        private string _n_expediente = string.Empty;
        private long _serial;
        private string _nombre = string.Empty;
        private string _apellidos = string.Empty;
        private string _identificador = string.Empty;
        private long _tipo_id;
        private string _email = string.Empty;
        private string _direccion = string.Empty;
        private string _cod_postal = string.Empty;
        private string _localidad = string.Empty;
        private string _municipio = string.Empty;
        private string _provincia = string.Empty;
        private string _telefono = string.Empty;
        private string _nivel_estudios = string.Empty;
        private string _observaciones = string.Empty;
        private string _foto = string.Empty;
        private string _codigo = string.Empty;
        private long _grupo;
        private DateTime _fecha_nacimiento;
        private bool _requisitos = false;
        private bool _prueba_acceso = false;
        private string _lugar_trabajo = string.Empty;
        private string _lugar_estudio = string.Empty;
        private string _formacion = string.Empty;
        private string _idiomas = string.Empty;

        #endregion

        #region Properties

        public virtual string NExpediente { get { return _n_expediente; } set { _n_expediente = value; } }
        public virtual long Serial { get { return _serial; } set { _serial = value; } }
        public virtual string Nombre { get { return _nombre; } set { _nombre = value; } }
        public virtual string Apellidos { get { return _apellidos; } set { _apellidos = value; } }
        public virtual string Identificador { get { return _identificador; } set { _identificador = value; } }
        public virtual long TipoId { get { return _tipo_id; } set { _tipo_id = value; } }
        public virtual string Email { get { return _email; } set { _email = value; } }
        public virtual string Direccion { get { return _direccion; } set { _direccion = value; } }
        public virtual string CodPostal { get { return _cod_postal; } set { _cod_postal = value; } }
        public virtual string Localidad { get { return _localidad; } set { _localidad = value; } }
        public virtual string Municipio { get { return _municipio; } set { _municipio = value; } }
        public virtual string Provincia { get { return _provincia; } set { _provincia = value; } }
        public virtual string Telefono { get { return _telefono; } set { _telefono = value; } }
        public virtual string NivelEstudios { get { return _nivel_estudios; } set { _nivel_estudios = value; } }
        public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
        public virtual string Foto { get { return _foto; } set { _foto = value; } }
        public virtual string Codigo { get { return _codigo; } set { _codigo = value; } }
        public virtual long Grupo { get { return _grupo; } set { _grupo = value; } }
        public virtual DateTime FechaNacimiento { get { return _fecha_nacimiento; } set { _fecha_nacimiento = value; } }
        public virtual bool Requisitos { get { return _requisitos; } set { _requisitos = value; } }
        public virtual bool PruebaAcceso { get { return _prueba_acceso; } set { _prueba_acceso = value; } }
        public virtual string LugarTrabajo { get { return _lugar_trabajo; } set { _lugar_trabajo = value; } }
        public virtual string LugarEstudio { get { return _lugar_estudio; } set { _lugar_estudio = value; } }
        public virtual string Formacion { get { return _formacion; } set { _formacion = value; } }
        public virtual string Idiomas { get { return _idiomas; } set { _idiomas = value; } }

        #endregion

        #region Business Methods

        public AlumnoRecord() { }

        public virtual void CopyValues(IDataReader source)
        {
            if (source == null) return;

            Oid = Format.DataReader.GetInt64(source, "OID");
            _n_expediente = Format.DataReader.GetString(source, "N_EXPEDIENTE");
            _serial = Format.DataReader.GetInt64(source, "SERIAL");
            _nombre = Format.DataReader.GetString(source, "NOMBRE");
            _apellidos = Format.DataReader.GetString(source, "APELLIDOS");
            _identificador = Format.DataReader.GetString(source, "ID");
            _tipo_id = Format.DataReader.GetInt64(source, "TIPO_ID");
            _email = Format.DataReader.GetString(source, "EMAIL");
            _direccion = Format.DataReader.GetString(source, "DIRECCION");
            _cod_postal = Format.DataReader.GetString(source, "COD_POSTAL");
            _localidad = Format.DataReader.GetString(source, "LOCALIDAD");
            _municipio = Format.DataReader.GetString(source, "MUNICIPIO");
            _provincia = Format.DataReader.GetString(source, "PROVINCIA");
            _telefono = Format.DataReader.GetString(source, "TELEFONO");
            _nivel_estudios = Format.DataReader.GetString(source, "NIVEL_ESTUDIOS");
            _observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");
            _foto = Format.DataReader.GetString(source, "FOTO");
            _codigo = Format.DataReader.GetString(source, "CODIGO");
            _grupo = Format.DataReader.GetInt64(source, "GRUPO");
            _fecha_nacimiento = Format.DataReader.GetDateTime(source, "FECHA_NACIMIENTO");
            _requisitos = Format.DataReader.GetBool(source, "REQUISITOS");
            _prueba_acceso = Format.DataReader.GetBool(source, "PRUEBA_ACCESO");
            _lugar_trabajo = Format.DataReader.GetString(source, "LUGAR_TRABAJO");
            _lugar_estudio = Format.DataReader.GetString(source, "LUGAR_ESTUDIO");
            _formacion = Format.DataReader.GetString(source, "FORMACION");
            _idiomas = Format.DataReader.GetString(source, "IDIOMAS");

        }
        public virtual void CopyValues(AlumnoRecord source)
        {
            if (source == null) return;

            Oid = source.Oid;
            _n_expediente = source.NExpediente;
            _serial = source.Serial;
            _nombre = source.Nombre;
            _apellidos = source.Apellidos;
            _identificador = source.Identificador;
            _tipo_id = source.TipoId;
            _email = source.Email;
            _direccion = source.Direccion;
            _cod_postal = source.CodPostal;
            _localidad = source.Localidad;
            _municipio = source.Municipio;
            _provincia = source.Provincia;
            _telefono = source.Telefono;
            _nivel_estudios = source.NivelEstudios;
            _observaciones = source.Observaciones;
            _foto = source.Foto;
            _codigo = source.Codigo;
            _grupo = source.Grupo;
            _fecha_nacimiento = source.FechaNacimiento;
            _requisitos = source.Requisitos;
            _prueba_acceso = source.PruebaAcceso;
            _lugar_trabajo = source.LugarTrabajo;
            _lugar_estudio = source.LugarEstudio;
            _formacion = source.Formacion;
            _idiomas = source.Idiomas;
        }

        #endregion
    }

    [Serializable()]
    public class AlumnoBase
    {
        #region Attributes

        private AlumnoRecord _record = new AlumnoRecord();

        #endregion

        #region Properties

        public AlumnoRecord Record { get { return _record; } }

        #endregion

        #region Business Methods

        internal void CopyValues(IDataReader source)
        {
            if (source == null) return;

            _record.CopyValues(source);
        }
        public void CopyValues(Alumno source)
        {
            if (source == null) return;

            _record.CopyValues(source.Base.Record);
        }
        public void CopyValues(AlumnoInfo source)
        {
            if (source == null) return;

            _record.CopyValues(source.Base.Record);
        }

        #endregion
    }
	/// <summary>
	/// Editable Root Business Object With Editable Child Collection
	/// Editable Child Business Object With Editable Child Collection
	/// </summary>
	[Serializable()]
	public class Alumno : BusinessBaseEx<Alumno>
	{
        #region Attributes

        protected AlumnoBase _base = new AlumnoBase();

		/*private string _n_expediente = string.Empty;
		private long _serial;
		private string _codigo = string.Empty;
		private string _nombre = string.Empty;
		private string _apellidos = string.Empty;
		private string _id = string.Empty;
		private long _tipo_id;
        private DateTime _fecha_nacimiento;
		private string _email = string.Empty;
		private string _direccion = string.Empty;
		private string _cod_postal = string.Empty;
		private string _localidad = string.Empty;
		private string _municipio = string.Empty;
		private string _provincia = string.Empty;
		private string _telefono = string.Empty;
		private string _nivel_estudios = string.Empty;
		private string _observaciones = string.Empty;
		private string _foto = string.Empty;
		private long _grupo;
        private string _lugar_trabajo = string.Empty;
        private string _lugar_estudio = string.Empty;
        private bool _requisitos;
        private bool _prueba_acceso;
        private string _formacion = string.Empty;
        private string _idiomas = string.Empty;*/

		private Alumno_Partes _alumno_partes = Alumno_Partes.NewChildList();
		private Material_Alumnos _material_alumnos = Material_Alumnos.NewChildList();
		private Alumno_Examens _alumno_examens = Alumno_Examens.NewChildList();
        private Alumnos_Practicas _alumnos_practicas = Alumnos_Practicas.NewChildList();
        private Alumnos_Promociones _promociones = Alumnos_Promociones.NewChildList();
        
        #endregion

        #region Properties

        public AlumnoBase Base { get { return _base; } }

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
        public virtual string NExpediente
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.NExpediente;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.NExpediente.Equals(value))
                {
                    _base.Record.NExpediente = value;
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
                //////CanWriteProperty(true);

                if (!_base.Record.Serial.Equals(value))
                {
                    _base.Record.Serial = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Nombre
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.Nombre;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.Nombre.Equals(value))
                {
                    _base.Record.Nombre = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Apellidos
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.Apellidos;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.Apellidos.Equals(value))
                {
                    _base.Record.Apellidos = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Id
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.Identificador;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.Identificador.Equals(value))
                {
                    _base.Record.Identificador = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual long TipoId
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.TipoId;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (!_base.Record.TipoId.Equals(value))
                {
                    _base.Record.TipoId = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Email
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.Email;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.Email.Equals(value))
                {
                    _base.Record.Email = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Direccion
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.Direccion;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.Direccion.Equals(value))
                {
                    _base.Record.Direccion = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string CodPostal
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.CodPostal;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.CodPostal.Equals(value))
                {
                    _base.Record.CodPostal = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Localidad
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.Localidad;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.Localidad.Equals(value))
                {
                    _base.Record.Localidad = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Municipio
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.Municipio;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.Municipio.Equals(value))
                {
                    _base.Record.Municipio = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Provincia
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.Provincia;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.Provincia.Equals(value))
                {
                    _base.Record.Provincia = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Telefono
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.Telefono;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.Telefono.Equals(value))
                {
                    _base.Record.Telefono = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string NivelEstudios
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.NivelEstudios;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.NivelEstudios.Equals(value))
                {
                    _base.Record.NivelEstudios = value;
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
        public virtual string Foto
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.Foto;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.Foto.Equals(value))
                {
                    _base.Record.Foto = value;
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
                //////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.Codigo.Equals(value))
                {
                    _base.Record.Codigo = value;
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
                //////CanWriteProperty(true);

                if (!_base.Record.Grupo.Equals(value))
                {
                    _base.Record.Grupo = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual DateTime FechaNacimiento
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.FechaNacimiento;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (!_base.Record.FechaNacimiento.Equals(value))
                {
                    _base.Record.FechaNacimiento = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool Requisitos
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.Requisitos;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (!_base.Record.Requisitos.Equals(value))
                {
                    _base.Record.Requisitos = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool PruebaAcceso
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.PruebaAcceso;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (!_base.Record.PruebaAcceso.Equals(value))
                {
                    _base.Record.PruebaAcceso = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string LugarTrabajo
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.LugarTrabajo;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.LugarTrabajo.Equals(value))
                {
                    _base.Record.LugarTrabajo = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string LugarEstudio
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.LugarEstudio;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.LugarEstudio.Equals(value))
                {
                    _base.Record.LugarEstudio = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Formacion
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.Formacion;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.Formacion.Equals(value))
                {
                    _base.Record.Formacion = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Idiomas
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.Idiomas;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.Idiomas.Equals(value))
                {
                    _base.Record.Idiomas = value;
                    PropertyHasChanged();
                }
            }
        }

		/*public virtual string NExpediente
		{

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _n_expediente;
			}

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				if (value == null) value = string.Empty;
				if (!_n_expediente.Equals(value))
				{
					_n_expediente = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long Serial
		{

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _serial;
			}

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				if (!_serial.Equals(value))
				{
					_serial = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Codigo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _codigo;
			}
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				if (value == null) value = string.Empty;
				if (!_codigo.Equals(value))
				{
					_codigo = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Nombre
		{

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _nombre;
			}

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				if (value == null) value = string.Empty;
				if (!_nombre.Equals(value))
				{
					_nombre = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Apellidos
		{

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _apellidos;
			}

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				if (value == null) value = string.Empty;
				if (!_apellidos.Equals(value))
				{
					_apellidos = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Id
		{

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _id;
			}

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				if (value == null) value = string.Empty;
				if (!_id.Equals(value))
				{
					_id = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long TipoId
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _tipo_id;
			}

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				if (!_tipo_id.Equals(value))
				{
					_tipo_id = value;
					PropertyHasChanged();
				}
			}
		}
        public virtual DateTime FechaNacimiento
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _fecha_nacimiento;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (!_fecha_nacimiento.Equals(value))
                {
                    _fecha_nacimiento = value;
                    PropertyHasChanged();
                }
            }
        }
		public virtual string Email
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _email;
			}

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				if (value == null) value = string.Empty;
				if (!_email.Equals(value))
				{
					_email = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Direccion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _direccion;
			}

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				if (value == null) value = string.Empty;
				if (!_direccion.Equals(value))
				{
					_direccion = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string CodPostal
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _cod_postal;
			}

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				if (value == null) value = string.Empty;
				if (!_cod_postal.Equals(value))
				{
					_cod_postal = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Localidad
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _localidad;
			}

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				if (value == null) value = string.Empty;
				if (!_localidad.Equals(value))
				{
					_localidad = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Municipio
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _municipio;
			}

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				if (value == null) value = string.Empty;
				if (!_municipio.Equals(value))
				{
					_municipio = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Provincia
		{

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _provincia;
			}

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				if (value == null) value = string.Empty;
				if (!_provincia.Equals(value))
				{
					_provincia = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Telefono
		{

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _telefono;
			}

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				if (value == null) value = string.Empty;
				if (!_telefono.Equals(value))
				{
					_telefono = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string NivelEstudios
		{

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _nivel_estudios;
			}

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				if (value == null) value = string.Empty;
				if (!_nivel_estudios.Equals(value))
				{
					_nivel_estudios = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Observaciones
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _observaciones;
			}

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				if (value == null) value = string.Empty;
				if (!_observaciones.Equals(value))
				{
					_observaciones = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Foto
		{

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _foto;
			}

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				if (value == null) value = string.Empty;
				if (!_foto.Equals(value))
				{
					_foto = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long Grupo
		{

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _grupo;
			}

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				if (!_grupo.Equals(value))
				{
					_grupo = value;
					PropertyHasChanged();
				}
			}
		}
        public virtual bool Requisitos
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _requisitos;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (!_requisitos.Equals(value))
                {
                    _requisitos = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool PruebaAcceso
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _prueba_acceso;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (!_prueba_acceso.Equals(value))
                {
                    _prueba_acceso = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string LugarTrabajo
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _lugar_trabajo;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_lugar_trabajo.Equals(value))
                {
                    _lugar_trabajo = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string LugarEstudio
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _lugar_estudio;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_lugar_estudio.Equals(value))
                {
                    _lugar_estudio = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Formacion
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _formacion;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_formacion.Equals(value))
                {
                    _formacion = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Idiomas
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _idiomas;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_idiomas.Equals(value))
                {
                    _idiomas = value;
                    PropertyHasChanged();
                }
            }
        }*/

		public virtual Alumno_Partes AlumnoPartes
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _alumno_partes;
			}

			set
			{
				_alumno_partes = value;
			}
		}
		public virtual Material_Alumnos MaterialAlumnos
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _material_alumnos;
			}

			set
			{
				_material_alumnos = value;
			}
		}
		public virtual Alumno_Examens AlumnoExamens
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _alumno_examens;
			}

			set
			{
				_alumno_examens = value;
			}
        }
        public virtual Alumnos_Practicas AlumnosPracticas
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _alumnos_practicas;
            }

            set
            {
                _alumnos_practicas = value;
            }
        }
        public virtual Alumnos_Promociones Promociones
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _promociones;
            }

            set
            {
                _promociones = value;
            }
        }
        		
        public override bool IsValid
		{
			get { return base.IsValid && _alumno_partes.IsValid && _material_alumnos.IsValid && _alumno_examens.IsValid 
                && _alumnos_practicas.IsValid && _promociones.IsValid; }
		}

		public override bool IsDirty
		{
			get { return base.IsDirty || _alumno_partes.IsDirty || _material_alumnos.IsDirty || _alumno_examens.IsDirty 
                || _alumnos_practicas.IsDirty || _promociones.IsDirty; }
        }

        #endregion

        #region Business Methods

        /// <summary>
		/// Clona la entidad y sus subentidades y las marca como nuevas
		/// </summary>
		/// <returns>Una entidad clon</returns>

		public virtual Alumno CloneAsNew()
		{
			Alumno clon = base.Clone();

			// Se define el Oid como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
            clon.Codigo = (0).ToString(Resources.Defaults.ALUMNO_CODE_FORMAT);

			clon.SessionCode = Alumno.OpenSession();
			Alumno.BeginTransaction(clon.SessionCode);

			clon.MarkNew();
			clon.AlumnoPartes.MarkAsNew();
			clon.MaterialAlumnos.MarkAsNew();
			clon.AlumnoExamens.MarkAsNew();
            clon.AlumnosPracticas.MarkAsNew();
            clon.Promociones.MarkAsNew();

			return clon;
		}

		/// <summary>
		/// Copia los atributos del objeto
		/// </summary>
		/// <param name="source">Objeto origen</param>
        //protected override void CopyValues(Alumno source)
        //{
        //    if (source == null) return;

        //    _oid = source.Oid;
        //    _n_expediente = source.NExpediente;
        //    _serial = source.Serial;
        //    _codigo = source.Codigo;
        //    _nombre = source.Nombre;
        //    _apellidos = source.Apellidos;
        //    _id = source.Id;
        //    _tipo_id = source.TipoId;
        //    _fecha_nacimiento = source.FechaNacimiento;
        //    _email = source.Email;
        //    _direccion = source.Direccion;
        //    _cod_postal = source.CodPostal;
        //    _localidad = source.Localidad;
        //    _municipio = source.Municipio;
        //    _provincia = source.Provincia;
        //    _telefono = source.Telefono;
        //    _nivel_estudios = source.NivelEstudios;
        //    _observaciones = source.Observaciones;
        //    _foto = source.Foto;
        //    _grupo = source.Grupo;
        //    _requisitos = source.Requisitos;
        //    _prueba_acceso = source.PruebaAcceso;
        //    _lugar_trabajo = source.LugarTrabajo;
        //    _lugar_estudio = source.LugarEstudio;
        //    _formacion = source.Formacion;
        //    _idiomas = source.Idiomas;
        //}
        
        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        //protected override void CopyValues(IDataReader source)
        //{
        //    if (source == null) return;

        //    base.CopyValues(source);
        //}

		/// <summary>
		/// Devuelve el siguiente código de Cliente.
		/// </summary>
		/// <returns>Código de 9 cifras</returns>
		public virtual void GetNewCode()
		{
            Serial = SerialAlumnoInfo.GetNext(typeof(Alumno));
 			Codigo = Serial.ToString(Resources.Defaults.ALUMNO_CODE_FORMAT);
		}

        /// <summary>
        /// Devuelve el siguiente Numero de Examen
        /// </summary>
        /// <returns>Código de 9 cifras</returns>
        private static string GetNumeroExpediente()
        {
            // Obtenemos la lista de clientes ordenados por numero
            /*AlumnoList alumnos = AlumnoList.GetListByPromocion(oid_promocion, false);
            SortedBindingList<AlumnoInfo> lista = AlumnoList.SortList(alumnos, "NExpediente", ListSortDirection.Ascending);

            PromocionInfo promocion = PromocionInfo.Get(oid_promocion, false);

            // Obtenemos el último serial de servicio
            string lastcode;

            if (lista.Count > 0)
            {
                lastcode = lista[lista.Count - 1].NExpediente;
                int index = 0;
                if (lastcode.Length > 2) index = lastcode.Length - 2;
                int code = Convert.ToInt32(lastcode.Substring(index)) + 1;
                //lastcode = promocion.Numero + code.ToString("00");

                while (true)
                {
                    lastcode = promocion.Numero + code.ToString("00");

                    bool repetido = false;
                    foreach (AlumnoInfo alumno in lista)
                    {
                        if (alumno.NExpediente == lastcode)
                        {
                            code++;
                            repetido = true;
                            break;
                        }
                    }
                    if (!repetido)
                        break;
                }
            }
            else
            {
                int code = 1;

                AlumnoList lista_completa = AlumnoList.GetList(false);

                while (true)
                {
                    lastcode = promocion.Numero + code.ToString("00");
                    AlumnoInfo item = lista_completa.GetItemByProperty("NExpediente", lastcode);
                    if (item == null)
                        break;
                    else
                        code++;
                }

            }

            return lastcode;*/
            long Serial = SerialAlumnoInfo.GetNext(typeof(Alumno));
            return Serial.ToString(Resources.Defaults.ALUMNO_CODE_FORMAT);
        }
        
		#endregion

		#region Validation Rules

		protected override void AddBusinessRules()
		{
			ValidationRules.AddRule(CommonRules.MinValue<long>,
									new CommonRules.MinValueRuleArgs<long>("Grupo", 0));

            ValidationRules.AddRule(
                Csla.Validation.CommonRules.StringRequired, "Nombre");

            ValidationRules.AddRule(
                Csla.Validation.CommonRules.StringRequired, "Apellidos");
		}


		#endregion

		#region Autorization Rules

		public static bool CanAddObject()
		{
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.ALUMNO);
		}

		public static bool CanGetObject()
		{
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.ALUMNO);

		}

		public static bool CanDeleteObject()
		{
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.ALUMNO);

		}

		public static bool CanEditObject()
		{
			return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.ALUMNO);

		}

		#endregion

		#region Common Factory Methods

		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
		/// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
		/// pero debe ser protected por exigencia de NHibernate
		/// y public para que funcionen los DataGridView
		/// </summary>
        protected Alumno() { Grupo = 1; }

		public virtual AlumnoInfo GetInfo(bool get_childs)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new AlumnoInfo(this, get_childs);
		}

		public virtual AlumnoInfo GetInfo() { return GetInfo(true); }

		#endregion

		#region Root Factory Methods

		public static Alumno New()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

			return DataPortal.Create<Alumno>(new CriteriaCs(-1));
		}

		public static Alumno Get(long oid)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

			CriteriaEx criteria = Alumno.GetCriteria(Alumno.OpenSession());

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = Alumno.SELECT(oid);
            else
                criteria.AddOidSearch(oid);

			Alumno.BeginTransaction(criteria.Session);
			return DataPortal.Fetch<Alumno>(criteria);
		}

        public static Alumno GetForForm(long oid, bool childs, int sessionCode = -1)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = Alumno.GetCriteria(sessionCode != -1 ? sessionCode : Alumno.OpenSession());
            criteria.Childs = false;

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = Alumno.SELECT(oid);
            else
                criteria.AddOidSearch(oid);

            criteria.AddDistinctValue("TipoClase", 2);
            
            Alumno.BeginTransaction(criteria.Session);
            Alumno item = DataPortal.Fetch<Alumno>(criteria);

            if (childs)
            {
                item.LoadChildsForForm(typeof(Alumno_Parte), criteria.SessionCode, true, true);
                item.LoadChildsForForm(typeof(Alumno_Practica), criteria.SessionCode, true, true);
                item.LoadChildsForForm(typeof(Alumno_Examen), criteria.SessionCode, true, true);
                item.LoadChildsForForm(typeof(Alumno_Promocion), criteria.SessionCode, true, true);
                item.LoadChildsForForm(typeof(Material_Alumno), criteria.SessionCode, true, true);
            }

            return item;
        }

		public static Alumno Get(CriteriaEx criteria)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

			Alumno.BeginTransaction(criteria.Session);
			return DataPortal.Fetch<Alumno>(criteria);
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
		/// Elimina todas los Alumnos
		/// </summary>
		public static void DeleteAll()
		{
			//Iniciamos la conexion y la transaccion
			int sessCode = Alumno.OpenSession();
			ISession sess = Alumno.Session(sessCode);
			ITransaction trans = Alumno.BeginTransaction(sessCode);

			try
			{
				sess.Delete("from Alumno");
				trans.Commit();
			}
			catch (Exception ex)
			{
				if (trans != null) trans.Rollback();
				iQExceptionHandler.TreatException(ex);
			}
			finally
			{
				Alumno.CloseSession(sessCode);
			}
		}

		public override Alumno Save()
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

				_alumno_partes.Update(this);
				_material_alumnos.Update(this);
				_alumno_examens.Update(this);
                _alumnos_practicas.Update(this);
                _promociones.Update(this);

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

		private Alumno(Alumno source)
		{
			MarkAsChild();
			Fetch(source);
		}

		private Alumno(IDataReader reader, bool childs)
		{
			MarkAsChild();
			Childs = childs;
			Fetch(reader);
		}
        
		internal static Alumno GetChild(Alumno source)
		{
			return new Alumno(source);
		}

		internal static Alumno GetChild(IDataReader reader, bool childs)
		{
			return new Alumno(reader, childs);
		}


		internal static Alumno GetChild(IDataReader reader)
		{
			return GetChild(reader, true);
		}

        public virtual void LoadChilds(Type type, bool get_childs, bool get_gchilds)
        {
            if (type.Equals(typeof(Alumno_Parte)))
                _alumno_partes = Alumno_Partes.GetChildList(this, get_childs, get_gchilds);
            if (type.Equals(typeof(Alumno_Examen)))
                _alumno_examens = Alumno_Examens.GetChildList(this, get_childs, get_gchilds);
            if (type.Equals(typeof(Alumno_Promocion)))
                _promociones = Alumnos_Promociones.GetChildList(this, get_childs, get_gchilds);
            if (type.Equals(typeof(Material_Alumno)))
                _material_alumnos = Material_Alumnos.GetChildList(this, get_childs, get_gchilds);
            if (type.Equals(typeof(Alumno_Practica)))
                _alumnos_practicas = Alumnos_Practicas.GetChildList(this, get_childs, get_gchilds);
        }

        public virtual void LoadChildsForForm(Type type, int sessionCode, bool get_childs, bool get_gchilds)
        {
            if (this.SessionCode == -1)
                this.SessionCode = sessionCode;

            if (type.Equals(typeof(Alumno_Parte)))
                _alumno_partes = Alumno_Partes.GetChildListForForm(this, get_childs, get_gchilds);
            if (type.Equals(typeof(Alumno_Practica)))
                _alumnos_practicas = Alumnos_Practicas.GetChildListForForm(this, get_childs, get_gchilds);
            if (type.Equals(typeof(Alumno_Examen)))
                _alumno_examens = Alumno_Examens.GetChildList(this, get_childs, get_gchilds);
            if (type.Equals(typeof(Alumno_Promocion)))
                _promociones = Alumnos_Promociones.GetChildList(this, get_childs, get_gchilds);
            if (type.Equals(typeof(Material_Alumno)))
                _material_alumnos = Material_Alumnos.GetChildList(this, get_childs, get_gchilds);
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
            GetNewCode();

			_alumno_partes = Alumno_Partes.NewChildList();
			_material_alumnos = Material_Alumnos.NewChildList();
			_alumno_examens = Alumno_Examens.NewChildList();
            _alumnos_practicas = Alumnos_Practicas.NewChildList();
            _promociones = Alumnos_Promociones.NewChildList();
		}

		#endregion

		#region Child Data Access

		private void Fetch(Alumno source)
		{
			try
			{
				SessionCode = source.SessionCode;

				_base.CopyValues(source);

				CriteriaEx criteria = Alumno_Parte.GetCriteria(Session());
				criteria.AddEq("OidAlumno", this.Oid);
				_alumno_partes = Alumno_Partes.GetChildList(criteria.List<Alumno_Parte>());

				criteria = Material_Alumno.GetCriteria(Session());
				criteria.AddEq("OidAlumno", this.Oid);
				_material_alumnos = Material_Alumnos.GetChildList(criteria.List<Material_Alumno>());

				criteria = Alumno_Examen.GetCriteria(Session());
				criteria.AddEq("OidAlumno", this.Oid);
                _alumno_examens = Alumno_Examens.GetChildList(criteria.List<Alumno_Examen>());

                criteria = Alumno_Practica.GetCriteria(Session());
                criteria.AddEq("OidAlumno", this.Oid);
                _alumnos_practicas = Alumnos_Practicas.GetChildList(criteria.List<Alumno_Practica>());

                criteria = Alumno_Promocion.GetCriteria(Session());
                criteria.AddEq("OidAlumno", this.Oid);
                _promociones = Alumnos_Promociones.GetChildList(criteria.List<Alumno_Promocion>());

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

				if (Childs)
				{

				}
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
					//Alumno.DoLOCK(Session());
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

					if (reader.Read())
						_base.CopyValues(reader);

					if (Childs)
					{
						//Alumno_Parte.DoLOCK(Session());
                        string query = string.Empty;
                        
                        foreach (CriteriaImpl.CriterionEntry item in criteria.IterateExpressionEntries())
                        {
                            if (item.ToString() == "not TipoClase = 2")
                                query = Alumno_Partes.SELECT_FALTAS_TEORICAS(this.Oid);
                        }

                        if (query == string.Empty)
                        query = Alumno_Partes.SELECT(GetInfo(false));
						reader = nHManager.Instance.SQLNativeSelect(query, Session());
						_alumno_partes = Alumno_Partes.GetChildList(reader);

						Material_Alumno.DoLOCK(Session());

                        query = Material_Alumnos.SELECT(GetInfo(false));
						reader = nHManager.Instance.SQLNativeSelect(query, Session());
						_material_alumnos = Material_Alumnos.GetChildList(reader);

						Alumno_Examen.DoLOCK(Session());

                        query = Alumno_Examens.SELECT(GetInfo(false));
						reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _alumno_examens = Alumno_Examens.GetChildList(criteria.SessionCode, reader);

                        Alumno_Practica.DoLOCK(Session());

                        query = Alumnos_Practicas.SELECT(GetInfo(false));
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _alumnos_practicas = Alumnos_Practicas.GetChildList(reader);

                        Alumno_Promocion.DoLOCK(Session());

                        query = Alumnos_Promociones.SELECT(GetInfo(false));
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _promociones = Alumnos_Promociones.GetChildList(reader);

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
				GetNewCode();
                NExpediente = GetNumeroExpediente();
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
					AlumnoRecord obj = Session().Get<AlumnoRecord>(Oid);
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
				AlumnoRecord obj = (AlumnoRecord)(criteria.UniqueResult());
				Session().Delete(Session().Get<AlumnoRecord>(obj.Oid));

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

		public static bool Exists(string codigo)
		{
			ExistsCmd result;
			result = DataPortal.Execute<ExistsCmd>(new ExistsCmd(codigo));
			return result.Exists;
		}

		[Serializable()]
		private class ExistsCmd : CommandBase
		{
			private string _codigo;
			private bool _exists = false;

			public bool Exists
			{
				get { return _exists; }
			}

			public ExistsCmd(string codigo)
			{
				_codigo = codigo;
			}

			protected override void DataPortal_Execute()
			{
				// Buscar por codigo
				CriteriaEx criteria = Alumno.GetCriteria(Alumno.OpenSession());
				criteria.AddCodeSearch(_codigo);
				AlumnoList list = AlumnoList.GetList(criteria);
				_exists = !(list.Count == 0);
			}
		}



		#endregion

        #region SQL

        public static new string SELECT(long oid)
        {
            string alumno = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));
            string promocion = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));

            string query = "SELECT * FROM " + alumno + " AS AL" +
                   "        WHERE AL.\"OID\" = '" + oid.ToString() + "' ";

            return query;
        }

        #endregion

    }
}

