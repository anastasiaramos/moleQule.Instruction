using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Store;
using moleQule.Library.Invoice;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class InstructorRecord : ProviderBaseRecord
	{
		#region Attributes

        private string _nombre_propio = string.Empty;
		private string _apellidos = string.Empty;
		private string _nivel_estudios = string.Empty;
		private long _perfil;
		private string _foto = string.Empty;
		private bool _activo;
        private DateTime _inicio_contrato;
        private DateTime _fin_contrato;
        //private Decimal _irpf;
        private decimal _sueldo_bruto;
        private bool _mtoe = true;

		#endregion

		#region Properties

        public virtual string NombrePropio{get{return _nombre_propio;}set{_nombre_propio = value;}}
		public virtual string Apellidos { get { return _apellidos; } set { _apellidos = value; } }
        public virtual string NivelEstudios{get{return _nivel_estudios;}set{_nivel_estudios = value;}}
		public virtual string Foto { get { return _foto; } set { _foto = value; } }
		public virtual long Perfil { get { return _perfil; } set { _perfil = value; } }
        public virtual bool Activo {get{return _activo;}set{_activo = value;}}
		public virtual DateTime InicioContrato { get { return _inicio_contrato; } set { _inicio_contrato = value; } }
		public virtual DateTime FinContrato { get { return _fin_contrato; } set { _fin_contrato = value; } }
		//public virtual Decimal IRPF { get { return _irpf; } set { _irpf = value; } }
        public virtual Decimal SueldoBruto { get { return _sueldo_bruto; } set { _sueldo_bruto = value; } }
        public virtual bool MTOE { get { return _mtoe; } set { _mtoe = value; } }


		#endregion

		#region Business Methods

		public InstructorRecord() { }

        public override void CopyValues(IDataReader source)
        {
            if (source == null) return;

            base.CopyValues(source);

            _nombre_propio = Format.DataReader.GetString(source, "NOMBRE_PROPIO");
            _apellidos = Format.DataReader.GetString(source, "APELLIDOS");            
            _nivel_estudios = Format.DataReader.GetString(source, "NIVEL_ESTUDIOS");
            _foto = Format.DataReader.GetString(source, "FOTO");
            _perfil = Format.DataReader.GetInt64(source, "PERFIL");
            _activo = Format.DataReader.GetBool(source, "ACTIVO");
            _inicio_contrato = Format.DataReader.GetDateTime(source, "INICIO_CONTRATO");
            _fin_contrato = Format.DataReader.GetDateTime(source, "FIN_CONTRATO");
            //_irpf = Format.DataReader.GetDecimal(source, "P_IRPF");
            _sueldo_bruto = Format.DataReader.GetDecimal(source, "SUELDO_BRUTO");
            _mtoe = Format.DataReader.GetBool(source, "MTOE");
        }

        public virtual void CopyValues(InstructorRecord source)
        {
            if (source == null) return;

            base.CopyValues(source);

            _nombre_propio = source.NombrePropio;
			_apellidos = source.Apellidos;
			_nivel_estudios = source.NivelEstudios;
			_perfil = source.Perfil;
			_foto = source.Foto;
			_activo = source.Activo;
            _inicio_contrato = source.InicioContrato;
            _fin_contrato = source.FinContrato;
            //_irpf = source.IRPF;
            _sueldo_bruto = source.SueldoBruto;
            _mtoe = source.MTOE;
        }

		#endregion
	}

	[Serializable()]
	public class InstructorBase
	{
		#region Attributes

		protected InstructorRecord _record = new InstructorRecord();
        protected ProviderBase _proveedor_base = new ProviderBase();

		#endregion

		#region Properties

		public InstructorRecord Record { get { return _record; } }
        public ProviderBase ProviderBase { get { return _proveedor_base; } }

		#endregion

		#region Business Methods

		public void CopyValues(IDataReader source)
		{
            if (source == null) return;

            _record.CopyValues(source);

            _proveedor_base.OidAcreedor = _record.Oid;

            string oid = ((long)(_record.TipoAcreedor + 1)).ToString("00") + "00000" + Format.DataReader.GetInt64(source, "OID").ToString();
            _record.Oid = Convert.ToInt64(oid);

            _proveedor_base.CopyCommonValues(source);
		}
		public void CopyValues(Instructor source)
		{
            if (source == null) return;

            _record.CopyValues(source.Base.Record);
            _proveedor_base.CopyCommonValues(source);

            _proveedor_base.OidAcreedor = _record.Oid;
		}
		public void CopyValues(InstructorInfo source)
		{
            if (source == null) return;

            _record.CopyValues(source.Base.Record);
            _proveedor_base.CopyCommonValues(source);

            _proveedor_base.OidAcreedor = _record.Oid;
		}

		#endregion
	}

	[Serializable()]
    public class Instructor : BusinessBaseEx<Instructor>, IAcreedor, ITitular
    {
        #region IUser

        public virtual long OidUser { get { return _base.ProviderBase.OidUser; } set { _base.ProviderBase.OidUser = value; } }
        public virtual string Username { get { return _base.ProviderBase.Username; } set { _base.ProviderBase.Username = value; } }
        public virtual EEstadoItem EUserStatus { get { return _base.ProviderBase.EUserStatus; } set { _base.ProviderBase.EUserStatus = value; } }
        public virtual string UserStatusLabel { get { return _base.ProviderBase.UserStatusLabel; } }
        public virtual DateTime CreationDate { get { return _base.ProviderBase.CreationDate; } set { _base.ProviderBase.CreationDate = value; } }
        public virtual DateTime LastLoginDate { get { return _base.ProviderBase.LastLoginDate; } set { _base.ProviderBase.LastLoginDate = value; } }

        #endregion

        #region ITitular

        public virtual ETipoTitular ETipoTitular { get { return ETipoTitular.Instructor; } }

        #endregion

        #region IAcreedor

        public ProviderBase ProviderBase { get { return _base.ProviderBase; } }

        public virtual long TipoAcreedor
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.TipoAcreedor;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_base.Record.TipoAcreedor.Equals(value))
                {
                    _base.Record.TipoAcreedor = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual ETipoAcreedor ETipoAcreedor { get { return (ETipoAcreedor)_base.Record.TipoAcreedor; } set { _base.Record.TipoAcreedor = (long)value; } }
        public virtual IAcreedor IClone() { return Clone() as IAcreedor; }
        public virtual IAcreedor ISave() { return Save() as IAcreedor; }
        public virtual IAcreedor ISave(Payment item) { return Save() as IAcreedor; }
        public virtual IAcreedorInfo IGetInfo() { return GetInfo(false) as IAcreedorInfo; }

        #endregion

		#region Attributes

        InstructorBase _base = new InstructorBase();
        
        private Payments _pagos = Payments.NewChildList();
		private CursoFormacions _cursos_formacion = CursoFormacions.NewChildList();
		//private Submodulos_Instructores _submodulos = Submodulos_Instructores.NewChildList();
		private Disponibilidades _disponibilidades = Disponibilidades.NewChildList();
		private Instructor_Promociones _promociones = Instructor_Promociones.NewChildList();

        #endregion

        #region Properties

		public InstructorBase Base { get { return _base; } }

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
        public virtual long Serial
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.Serial;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_base.Record.Serial.Equals(value))
                {
                    _base.Record.Serial = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string ID
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.Identificador;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
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
                CanReadProperty(true);
                return _base.Record.TipoId;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (!_base.Record.TipoId.Equals(value))
                {
                    _base.Record.TipoId = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual long FormaPago
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.FormaPago;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_base.Record.FormaPago.Equals(value))
                {
                    _base.Record.FormaPago = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual long MedioPago
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.MedioPago;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_base.Record.MedioPago.Equals(value))
                {
                    _base.Record.MedioPago = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual long DiasPago
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.DiasPago;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_base.Record.DiasPago.Equals(value))
                {
                    _base.Record.DiasPago = value;
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
                return _base.Record.Codigo;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.Codigo.Equals(value))
                {
                    _base.Record.Codigo = value;
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
                if (_base.Record.Nombre == string.Empty)
                    _base.Record.Nombre = _base.Record.NombrePropio + " " + _base.Record.Apellidos;
                return _base.Record.Nombre;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.Nombre.Equals(value))
                {
                    _base.Record.Nombre = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Alias
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.Alias;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.Alias.Equals(value))
                {
                    _base.Record.Alias = value;
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
                return _base.Record.CodPostal;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.CodPostal.Equals(value))
                {
                    _base.Record.CodPostal = value;
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
                return _base.Record.Direccion;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.Direccion.Equals(value))
                {
                    _base.Record.Direccion = value;
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
                return _base.Record.Localidad;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

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
                CanReadProperty(true);
                return _base.Record.Municipio;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

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
                CanReadProperty(true);
                return _base.Record.Provincia;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

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
                CanReadProperty(true);
                return _base.Record.Telefono;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.Telefono.Equals(value))
                {
                    _base.Record.Telefono = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Pais
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.Pais;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.Pais.Equals(value))
                {
                    _base.Record.Pais = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Contacto
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.Contacto;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.Contacto.Equals(value))
                {
                    _base.Record.Contacto = value;
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
                return _base.Record.Email;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.Email.Equals(value))
                {
                    _base.Record.Email = value;
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
                return _base.Record.Observaciones;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.Observaciones.Equals(value))
                {
                    _base.Record.Observaciones = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual long OidTarjetaAsociada
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.OidTarjetaAsociada;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //CanWriteProperty(true);

                if (!_base.Record.OidTarjetaAsociada.Equals(value))
                {
                    _base.Record.OidTarjetaAsociada = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual Decimal PIRPF
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.PIRPF;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //CanWriteProperty(true);

                if (!_base.Record.PIRPF.Equals(value))
                {
                    _base.Record.PIRPF = Decimal.Round(value, 2);
                    PropertyHasChanged();
                }
            }
        }
        public virtual string NombrePropio
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.NombrePropio;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Record.NombrePropio.Equals(value))
                {
                    _base.Record.NombrePropio = value;
                    Nombre = _base.Record.NombrePropio + " " + _base.Record.Apellidos;
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
				return _base.Record.Apellidos;
			}

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				if (value == null) value = string.Empty;
				if (!_base.Record.Apellidos.Equals(value))
				{
					_base.Record.Apellidos = value;
                    Nombre = _base.Record.NombrePropio + " " + _base.Record.Apellidos;
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
				return _base.Record.NivelEstudios;
			}

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				if (value == null) value = string.Empty;
				if (!_base.Record.NivelEstudios.Equals(value))
				{
					_base.Record.NivelEstudios = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long Perfil
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _base.Record.Perfil;
			}

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				if (!_base.Record.Perfil.Equals(value))
				{
					_base.Record.Perfil = value;
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
				return _base.Record.Foto;
			}

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				if (value == null) value = string.Empty;
				if (!_base.Record.Foto.Equals(value))
				{
					_base.Record.Foto = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool Activo
		{

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _base.Record.Activo;
			}

			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				////CanWriteProperty(true);
				if (!_base.Record.Activo.Equals(value))
				{
					_base.Record.Activo = value;
					PropertyHasChanged();
				}
			}
        }
        public virtual DateTime InicioContrato
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.InicioContrato;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_base.Record.InicioContrato.Equals(value))
                {
                    _base.Record.InicioContrato = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual DateTime FinContrato
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.FinContrato;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_base.Record.FinContrato.Equals(value))
                {
                    _base.Record.FinContrato = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string CuentaBancaria
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.CuentaBancaria;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_base.Record.CuentaBancaria.Equals(value))
                {
                    _base.Record.CuentaBancaria = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual long OidCuentaBAsociada
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.OidCuentaBAsociada;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_base.Record.OidCuentaBAsociada.Equals(value))
                {
                    _base.Record.OidCuentaBAsociada = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string CuentaContable
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.CuentaContable;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_base.Record.CuentaContable.Equals(value))
                {
                    _base.Record.CuentaContable = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual long OidImpuesto
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.OidImpuesto;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_base.Record.OidImpuesto.Equals(value))
                {
                    _base.Record.OidImpuesto = value;
                    PropertyHasChanged();
                }
            }
        }
        //public virtual Decimal IRPF
        //{
        //    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        //    get
        //    {
        //        CanReadProperty(true);
        //        return _base.Record.IRPF;
        //    }

        //    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        //    set
        //    {
        //        ////CanWriteProperty(true);

        //        if (!_base.Record.IRPF.Equals(value))
        //        {
        //            _base.Record.IRPF = value;
        //            PropertyHasChanged();
        //        }
        //    }
        //}
        public virtual long Estado
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.Estado;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_base.Record.Estado.Equals(value))
                {
                    _base.Record.Estado = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual Decimal SueldoBruto
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.SueldoBruto;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_base.Record.SueldoBruto.Equals(value))
                {
                    _base.Record.SueldoBruto = Decimal.Round(value, 2);
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool MTOE
        {

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.MTOE;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (!_base.Record.MTOE.Equals(value))
                {
                    _base.Record.MTOE = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual ProductoProveedores Productos
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.ProviderBase.Productos;
            }
        }
        public virtual Payments Pagos
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.ProviderBase.Pagos;
            }
        }			 
        public virtual CursoFormacions CursosFormacion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _cursos_formacion;
			}

			set
			{
				_cursos_formacion = value;
			}
		}
        //public virtual Submodulos_Instructores Submodulos
        //{
        //    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        //    get
        //    {
        //        CanReadProperty(true);
        //        return _submodulos;
        //    }

        //    set
        //    {
        //        _submodulos = value;
        //    }
        //}
		public virtual Disponibilidades Disponibilidades
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _disponibilidades;
			}

			set
			{
				_disponibilidades = value;
			}
		}
        public virtual Instructor_Promociones Promociones
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

        //NO ENLAZADAS
        public virtual EFormaPago EFormaPago { get { return _base.ProviderBase.EFormaPago; } set { _base.ProviderBase.EFormaPago = value; } }
        public virtual EMedioPago EMedioPago { get { return _base.ProviderBase.EMedioPago; } set { _base.ProviderBase.EMedioPago = value; } }
        public virtual string FormaPagoLabel { get { return _base.ProviderBase.FormaPagoLabel; } }
        public virtual string MedioPagoLabel { get { return _base.ProviderBase.MedioPagoLabel; } }
        public virtual string CuentaAsociada { get { return _base.ProviderBase.CuentaAsociada; } set { _base.ProviderBase.CuentaAsociada = value; PropertyHasChanged(); } }
        public virtual string Impuesto { get { return (_base.Record.OidImpuesto != 0) ? _base.ProviderBase.Impuesto : Library.Common.EnumText<ETipoImpuesto>.GetLabel(ETipoImpuesto.Defecto); } }
        public virtual decimal PImpuesto { get { return _base.ProviderBase.PImpuesto; } }
        public virtual string TarjetaAsociada { get { return _base.ProviderBase.TarjetaAsociada; } set { _base.ProviderBase.TarjetaAsociada = value; PropertyHasChanged(); } }

        
        //NO ENLAZADOS
        public virtual long OidAcreedor { get { return _base.ProviderBase.OidAcreedor; } set { _base.ProviderBase.OidAcreedor = value; } }

		public override bool IsValid
		{
			get { return base.IsValid
                                && _pagos.IsValid 
                                && _cursos_formacion.IsValid 
                                && _disponibilidades.IsValid 
                                && _promociones.IsValid 
                                //&& _submodulos.IsValid
                                && _base.ProviderBase._producto_proveedores.IsValid
                                && _base.ProviderBase._pagos.IsValid;
            }
		}
		public override bool IsDirty
		{
			get { return base.IsDirty
                                || _pagos.IsDirty 
                                || _cursos_formacion.IsDirty 
                                || _disponibilidades.IsDirty 
                                || _promociones.IsDirty 
                                //|| _submodulos.IsDirty
                                || _base.ProviderBase._producto_proveedores.IsDirty
                                || _base.ProviderBase._pagos.IsDirty;
            }
		}

        #endregion

        #region Business Methods

        public virtual Instructor CloneAsNew()
		{
			Instructor clon = base.Clone();

			// Se define el Oid como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();

			clon.SessionCode = Instructor.OpenSession();
			Instructor.BeginTransaction(clon.SessionCode);

			clon.MarkNew();
            clon.Pagos.MarkAsNew();
			clon.CursosFormacion.MarkAsNew();
			//clon.Submodulos.MarkAsNew();
			clon.Disponibilidades.MarkAsNew();
			clon.Promociones.MarkAsNew();

			return clon;
        }

        protected void CopyValues(Instructor source)
        {
            if (source == null) return;

            _base.CopyValues(source);

            //Pte. de quitar de aqui cuando se adapten todos los Acreedores
            _base.Record.Estado = source.Estado;
            Oid = source.Oid;
        }
        protected void CopyValues(IDataReader source)
        {
            if (source == null) return;

            _base.CopyValues(source);
            Oid = Format.DataReader.GetInt64(source, "OID");

            //Pte. de quitar de aqui cuando se adapten todos los Acreedores
            _base.Record.Estado = Format.DataReader.GetInt64(source, "ESTADO");
        }
        
        public virtual void SetImpuesto(ImpuestoInfo source)
        {
            if (source == null)
            {
                OidImpuesto = 0;
                _base.ProviderBase.Impuesto = Library.Common.EnumText<ETipoImpuesto>.GetLabel(ETipoImpuesto.Defecto);
                _base.ProviderBase.PImpuesto = 0;
            }
            else
            {
                OidImpuesto = source.Oid;
                _base.ProviderBase.Impuesto = source.Nombre;
                _base.ProviderBase.PImpuesto = source.Porcentaje;
            }
        }

        public virtual void GetNewCode()
        {
            _base.Record.Serial = SerialInfo.GetNext(typeof(Employee));
            _base.Record.Codigo = _base.Record.Serial.ToString(Resources.Defaults.EMPLEADO_CODE_FORMAT);
        }

        public virtual bool HasProfile(Perfil profile)
        {
            byte bit = Convert.ToByte(Math.Log(Convert.ToDouble((long)profile), 2));
            return ((Perfil >> bit) % 2) == 1;
        }

        public virtual void UpdateDisponibilidades(Instructor obj)
        {
            foreach (Disponibilidad item in obj.Disponibilidades)
            {
                //if (item.IsDirty)
                {
                    Disponibilidad disp = Disponibilidades.GetItem(item.Oid);

                    if (disp != null)
                        disp.CopyFrom(item.GetInfo());
                    else
                        Disponibilidades.AddItem(item);

                }
            }
        }
		
        #endregion

		#region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(
                Csla.Validation.CommonRules.StringRequired, "NombrePropio");

            ValidationRules.AddRule(
                Csla.Validation.CommonRules.StringRequired, "Apellidos");

            ValidationRules.AddRule(
                Csla.Validation.CommonRules.StringRequired, "Alias");
        }

		#endregion

		#region Autorization Rules

		public static bool CanAddObject()
		{
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.INSTRUCTOR);

		}

		public static bool CanGetObject()
		{
			return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.INSTRUCTOR);

		}

		public static bool CanDeleteObject()
		{
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.INSTRUCTOR);

		}
		public static bool CanEditObject()
		{
			return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.INSTRUCTOR);

		}

		#endregion

		#region Factory Methods

		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION New
		/// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
		/// pero es protected por exigencia de NHibernate.
		/// </summary>
		protected Instructor() { }

		private Instructor(IDataReader reader)
		{
			Fetch(reader);
		}
        
		private Instructor(Instructor source)
		{
			Fetch(source);
		}

		public static Instructor New()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			return DataPortal.Create<Instructor>(new CriteriaCs(-1));
		}

        public static Instructor Get(long oid) { return Get(oid, true); }

        public static Instructor Get(long oid, bool childs)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

			CriteriaEx criteria = Instructor.GetCriteria(Instructor.OpenSession());
            criteria.Childs = childs;
            criteria.Query = ProviderBaseInfo.SELECT_BASE(oid, ETipoAcreedor.Instructor, false);
			
			Instructor.BeginTransaction(criteria.Session);
			return DataPortal.Fetch<Instructor>(criteria);
		}

		internal static Instructor Get(IDataReader reader)
		{
			return new Instructor(reader);
		}

		internal static Instructor Get(Instructor source)
		{
			return new Instructor(source);
		}

        internal static Instructor GetChild(IDataReader reader)
        {
            Instructor obj = new Instructor(reader);
            obj.MarkAsChild();
            return obj;
        }

        public void LoadChilds(Type type, bool get_childs)
        {
            if (type.Equals(typeof(Payment)))
            {
                _base.ProviderBase.Pagos = Payments.GetChildList(this, get_childs);
            }
        }
        
        public virtual void LoadChilds(Type type, bool get_childs, bool get_gchilds)
        {
            if (type.Equals(typeof(Disponibilidad)))
            {
                bool autorizados = ModulePrincipal.GetMostrarInstructoresAutorizadosSetting();
                if (!autorizados || (autorizados && MTOE))
                    _disponibilidades = Disponibilidades.GetChildList(this, get_childs, get_gchilds);
            }
        }

		/// <summary>
		/// Construye y devuelve un objeto de solo lectura copia de si mismo.
		/// </summary>
		/// <param name="get_childs">True si se quiere que traiga los hijos</param>
		/// <returns></returns>
		public virtual InstructorInfo GetInfo(bool get_childs)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

	        return new InstructorInfo(this, get_childs);
		}

		public virtual InstructorInfo GetInfo()
		{
			return GetInfo(true);
		}

		public static void Delete(long oid)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

			DataPortal.Delete(new CriteriaCs(oid));
		}

		/// <summary>
		/// Elimina todos los Clientes, Contactos de Cliente y Cuentas de Cliente
		/// </summary>
		public static void DeleteAll()
		{
			//Iniciamos la conexion y la transaccion
			int sessCode = Instructor.OpenSession();
			ISession sess = Instructor.Session(sessCode);
			ITransaction trans = Instructor.BeginTransaction(sessCode);

			try
			{
				sess.Delete("from  Instructor");
				trans.Commit();
			}
			catch (Exception ex)
			{
				if (trans != null) trans.Rollback();
				iQExceptionHandler.TreatException(ex);
			}
			finally
			{
				Instructor.CloseSession(sessCode);
			}
		}

		public override Instructor Save()
		{
			// Por la posible doble interfaz Root/Child
			if (IsChild)
			{ 
                throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
            }

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
				if (!this.IsDirty)
					return this;
                base.Save();

                _base.ProviderBase.Productos.Update(this);
                _base.ProviderBase.Pagos.Update(this);

                _pagos.Update(this);
                _cursos_formacion.Update(this);
                //_submodulos.Update(this);

                bool autorizados = ModulePrincipal.GetMostrarInstructoresAutorizadosSetting();

                if (!autorizados || (autorizados && !MTOE))
                {
                    _disponibilidades.Update(this);
                    _promociones.Update(this);
                }

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

		#region Common Data Access

		[RunLocal()]
		private void DataPortal_Create(CriteriaCs criteria)
		{
			Random r = new Random();
            Oid = (long)r.Next();
            GetNewCode();

			_cursos_formacion = CursoFormacions.NewChildList();
			//_submodulos = Submodulos_Instructores.NewChildList();
			_disponibilidades = Disponibilidades.NewChildList();
			_promociones = Instructor_Promociones.NewChildList();
		}

		#endregion

		#region Root Data Access

		private void DataPortal_Fetch(CriteriaEx criteria)
		{
            try
            {
                SessionCode = criteria.SessionCode;
                Childs = criteria.Childs;

                if (nHMng.UseDirectSQL)
                {
                    Instructor.DoLOCK(Session());
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query);

                    if (reader.Read())
                        CopyValues(reader);

                    if (Childs)
                    {
                        string query = string.Empty;

                        ProductoProveedor.DoLOCK(Session());
                        query = ProductoProveedores.SELECT(this);
                        reader = nHMng.SQLNativeSelect(query, Session());
                        _base.ProviderBase.Productos = ProductoProveedores.GetChildList(SessionCode, reader);

                        Payment.DoLOCK(Session());
                        query = Payments.SELECT(this);
                        reader = nHMng.SQLNativeSelect(query, Session());
                        _base.ProviderBase.Pagos = Payments.GetChildList(SessionCode, reader);	

                        CursoFormacion.DoLOCK(Session());
                        query = CursoFormacions.SELECT_BY_INSTRUCTOR(AppContext.ActiveSchema.Code, "OidProfesor", this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _cursos_formacion = CursoFormacions.GetChildList(reader);

                        //Submodulo_Instructor.DoLOCK(Session());
                        //query = Submodulos_Instructores.SELECT_BY_INSTRUCTOR(this.Oid);
                        //reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        //_submodulos = Submodulos_Instructores.GetChildList(reader);

                        bool autorizados = ModulePrincipal.GetMostrarInstructoresAutorizadosSetting();
                        if (!autorizados || (autorizados && MTOE))
                        {
                            Disponibilidad.DoLOCK(Session());
                            query = Disponibilidades.SELECT_BY_INSTRUCTOR(this.Oid);
                            reader = nHManager.Instance.SQLNativeSelect(query, Session());
                            _disponibilidades = Disponibilidades.GetChildList(reader);

                            Instructor_Promocion.DoLOCK(Session());
                            query = Instructor_Promociones.SELECT_BY_INSTRUCTOR(this.Oid);
                            reader = nHManager.Instance.SQLNativeSelect(query, Session());
                            _promociones = Instructor_Promociones.GetChildList(criteria.SessionCode, reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(ex);
            }
		}

		private void Fetch(Instructor source)
		{
			CopyValues(source);
			MarkOld();
		}

		//Fetch independiente de DataPortal para generar un Cliente a partir de un IDataReader
		private void Fetch(IDataReader source)
		{
			try
			{
				CopyValues(source);
			}
            catch (Exception ex)
            {
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
                //si hay codigo o serial, hay que obtenerlos aquí
                GetNewCode();
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
					InstructorRecord obj = Session().Get<InstructorRecord>(Oid);

					obj.CopyValues(this.Base.Record);
					Session().Update(obj);
                    MarkOld();
				}
                catch (Exception ex)
                {
                    iQExceptionHandler.TreatException(ex);
                }
			}
		}

		[Transactional(TransactionalTypes.Manual)]
		protected override void DataPortal_DeleteSelf()
		{
            DataPortal_Delete(new CriteriaCs(Oid));
		}

		[Transactional(TransactionalTypes.Manual)]
		private void DataPortal_Delete(CriteriaCs criteria)
		{
			try
            {
                // Iniciamos la conexion y la transaccion
                SessionCode = OpenSession();
                BeginTransaction();

                //Si no hay integridad referencial, aquí se deben borrar las listas hijo
                CriteriaEx criterio = GetCriteria();
                criterio.AddOidSearch(criteria.Oid);

                InstructorRecord obj = (InstructorRecord)(criterio.UniqueResult());
                _base.Record.CopyValues(obj);

                _base.ProviderBase.Productos = ProductoProveedores.GetChildList(this, false);
                _base.ProviderBase.Productos.Clear();
                _base.ProviderBase.Productos.Update(this);

                Session().Delete(obj);
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
        
        internal void DeleteSelf(Instructores parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                SessionCode = parent.SessionCode;
                Session().Delete(Session().Get<InstructorRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }

        internal void Insert(Instructores parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            try
            {
                ValidationRules.CheckRules();

                //si hay codigo o serial, hay que obtenerlos aquí
                GetNewCode();

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

        internal void Update(Instructores parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            SessionCode = parent.SessionCode;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                InstructorRecord obj = Session().Get<InstructorRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                Session().Update(obj);

                _base.ProviderBase._producto_proveedores.Update(this);
                _base.ProviderBase._pagos.Update(this);
                _cursos_formacion.Update(this);
                //_submodulos.Update(this);
                _disponibilidades.Update(this);
                _promociones.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }
        
		#endregion

		#region Commands

		public virtual bool ExisteAlias(string alias, long oid)
		{
            string query = Instructor.SELECT_BY_ALIAS(alias);

			int sesion = Instructor.OpenSession();

			IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(sesion));

			while (reader.Read())
			{
				if ((long)reader["OID"] != oid)
				{
					CloseSession(sesion);
					return true;
				}
			}

			CloseSession(sesion);
			return false;
		}

        
        public Disponibilidad GetPredeterminado()
        {
            Disponibilidad disp = null;

            if (Disponibilidades != null && Disponibilidades.Count > 0)
            {
                foreach (Disponibilidad item in Disponibilidades)
                {
                    if (item.Predeterminado)
                    {
                        disp = item.Clone();
                        break;
                    }
                }
            }

            return disp;
        }

        //public static ListaProfesores GetInstructoresHorarios(DateTime time, long oid_promocion)
        //{
        //    ListaProfesores lista = new ListaProfesores();
        //    string query = INNER_JOIN_HORARIOS(time, oid_promocion);
        //    int sesion = Instructor.OpenSession();

        //    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(sesion));
        //    while (reader.Read())
        //    {
        //        if (((DateTime)reader["FECHA_INICIO"]).ToShortDateString().Equals(time.ToShortDateString()))
        //        {
        //            bool activo = (bool)reader["ACTIVO"];
        //            if (activo)
        //            {
        //                Profesor item = new Profesor();

        //                item.Oid = (long)reader["OID_INSTRUCTOR"];
        //                item.Prioridad = (long)reader["PRIORIDAD"];
        //                item.OidSubmodulo = (long)reader["OID_SUBMODULO"];
        //                item.Semana[0] = (bool)reader["L1"];
        //                item.Semana[1] = (bool)reader["L2"];
        //                item.Semana[2] = (bool)reader["M1"];
        //                item.Semana[3] = (bool)reader["M2"];
        //                item.Semana[4] = (bool)reader["X1"];
        //                item.Semana[5] = (bool)reader["X2"];
        //                item.Semana[6] = (bool)reader["J1"];
        //                item.Semana[7] = (bool)reader["J2"];
        //                item.Semana[8] = (bool)reader["V1"];
        //                item.Semana[9] = (bool)reader["V2"];
        //                item.ClasesSemanales = (long)reader["CLASES_SEMANALES"];

        //                lista.Add(item);
        //            }
        //        }
        //    }

        //    CloseSession(sesion);

        //    return lista;
        //}

        #endregion

        #region SQL

        public new static string SELECT(long oid) { return SELECT(oid, true); }
        public static string SELECT_BY_ALIAS(string alias)
        {
            return SELECT(0,false) + " AND \"ALIAS\" = '" + alias + "'";
        }

        internal static string SELECT(long oid, bool lockTable)
        {
            moleQule.Library.Store.QueryConditions conditions = new moleQule.Library.Store.QueryConditions { TipoAcreedor = new ETipoAcreedor[1] { ETipoAcreedor.Instructor } };
            if (oid != 0) conditions.Acreedor = ProviderBaseInfo.New(oid, ETipoAcreedor.Instructor);

            string query = ProviderBaseInfo.SELECT_FIELDS(ETipoAcreedor.Instructor) + @"
                            , A.""NOMBRE_PROPIO""
                            , A.""APELLIDOS""
                            , A.""NIVEL_ESTUDIOS""
                            , A.""FOTO""
                            , A.""PERFIL""
                            , A.""ACTIVO""
                            , A.""INICIO_CONTRATO""
                            , A.""FIN_CONTRATO""
                            , A.""SUELDO_BRUTO""
                            , A.""MTOE""" +
                            ProviderBaseInfo.JOIN(conditions) +
                            ProviderBaseInfo.WHERE(conditions);

            if (lockTable) query += " FOR UPDATE OF A NOWAIT";

            return query;
        }

        #endregion

	}
}

