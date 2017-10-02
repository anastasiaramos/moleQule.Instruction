using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Store;
using moleQule.Library.Invoice;
using moleQule.Library.Hipatia;

namespace moleQule.Library.Instruction
{
	/// <summary>
	/// ReadOnly Root Business Object with ReadOnly Childs
	/// </summary>
	[Serializable()]
    public class InstructorInfo : ReadOnlyBaseEx<InstructorInfo>, IAcreedorInfo, IAgenteHipatia, ITitular
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

        public virtual ETipoTitular ETipoTitular { get { return ETipoTitular.Proveedor; } }

        #endregion

        #region IAcreedorInfo

        public ProviderBase ProviderBase { get { return _base.ProviderBase; } }

        public string NombreTipoAcreedor { get { return EnumText<ETipoAcreedor>.GetLabel(ETipoAcreedor); } }
        public string ETipoAcreedorLabel { get { return NombreTipoAcreedor; } }
        public long TipoAcreedor { get { return _base.Record.TipoAcreedor; } }
        public ETipoAcreedor ETipoAcreedor { get { return (ETipoAcreedor)_base.Record.TipoAcreedor; } set { _base.Record.TipoAcreedor = (long)value; } }


        #endregion

        #region IAgenteHipatia

        public string NombreHipatia { get { return Apellidos + ", " + Nombre; } }
        public string IDHipatia { get { return Codigo; } }
        public string ObservacionesHipatia { get { return Observaciones; } }
        public Type TipoEntidad { get { return typeof(Instructor); } }

        #endregion

        #region Attributes

        protected InstructorBase _base = new InstructorBase();

        protected PaymentList _pagos = null;
        protected CursoFormacionList _cursos_formacion = null;
        protected Submodulo_InstructorList _submodulos = null;
        protected DisponibilidadList _disponibilidades = null;
        protected Instructor_PromocionList _promociones = null;

        #endregion

        #region Properties

        public InstructorBase Base { get { return _base; } }

        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long Serial { get { return _base.Record.Serial; } }
        public string Codigo { get { return _base.Record.Codigo; } }
        public long Estado { get { return _base.Record.Estado; } }
        public string ID { get { return _base.Record.Identificador; } }
        public long TipoId { get { return _base.Record.TipoId; } }
        public string Nombre { get { return _base.Record.Nombre != string.Empty ? _base.Record.Nombre : _base.Record.NombrePropio + " " + _base.Record.Apellidos; } }
        public string Alias { get { return _base.Record.Alias; } }
        public string CodPostal { get { return _base.Record.CodPostal; } }
        public string Direccion { get { return _base.Record.Direccion; } }
        public string Localidad { get { return _base.Record.Localidad; } }
        public string Municipio { get { return _base.Record.Municipio; } }
        public string Provincia { get { return _base.Record.Provincia; } }
        public string Telefono { get { return _base.Record.Telefono; } }
        public string Pais { get { return _base.Record.Pais; } }
        public string Contacto { get { return _base.Record.Contacto; } }
        public string Email { get { return _base.Record.Email; } }
        public long DiasPago { get { return _base.Record.DiasPago; } }
        public long FormaPago { get { return _base.Record.FormaPago; } }
        public long MedioPago { get { return _base.Record.MedioPago; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }
        public string CuentaBancaria { get { return _base.Record.CuentaBancaria; } }
        public long OidCuentaBAsociada { get { return _base.Record.OidCuentaBAsociada; } }
        public string CuentaContable { get { return _base.Record.CuentaContable; } }
        public long OidImpuesto { get { return _base.Record.OidImpuesto; } }
        //public Decimal IRPF { get { return _base.Record.IRPF; } }
        public decimal SueldoBruto { get { return _base.Record.SueldoBruto; } }

        public ProductoProveedorList Productos { get { return _base.ProviderBase._producto_proveedores_list; } }
        public PaymentList Pagos { get { return _base.ProviderBase._pagos_list; } }

        public string NombrePropio { get { return _base.Record.NombrePropio; } }
		public string Apellidos { get { return _base.Record.Apellidos; } }
		public string NivelEstudios { get { return _base.Record.NivelEstudios; } }
		public long Perfil { get { return _base.Record.Perfil; } }
		public string Foto { get { return _base.Record.Foto; } }
		public bool Activo { get { return _base.Record.Activo; } }
        public DateTime InicioContrato { get { return _base.Record.InicioContrato; } }
        public DateTime FinContrato { get { return _base.Record.FinContrato; } }
        public long OidTarjetaAsociada { get { return _base.Record.OidTarjetaAsociada; } }
        public Decimal PIRPF { get { return Decimal.Round(_base.Record.PIRPF, 2); } }
        public bool MTOE { get { return _base.Record.MTOE; } }

		public virtual CursoFormacionList CursosFormacion { get { return _cursos_formacion; } }
		public virtual Submodulo_InstructorList Submodulos { get { return _submodulos; } }
		public virtual DisponibilidadList Disponibilidades { get { return _disponibilidades; } }
		public virtual Instructor_PromocionList Promociones { get { return _promociones; } }

        //NO ENLAZADAS
        public EFormaPago EFormaPago { get { return _base.ProviderBase.EFormaPago; } }
        public EMedioPago EMedioPago { get { return _base.ProviderBase.EMedioPago; } }
        public string FormaPagoLabel { get { return _base.ProviderBase.FormaPagoLabel; } }
        public string MedioPagoLabel { get { return _base.ProviderBase.MedioPagoLabel; } }
        public string CuentaAsociada { get { return _base.ProviderBase.CuentaAsociada; } }
        public string Impuesto { get { return (_base.Record.OidImpuesto != 0) ? _base.ProviderBase.Impuesto : Library.Common.EnumText<ETipoImpuesto>.GetLabel(ETipoImpuesto.Defecto); } }
        public decimal PImpuesto { get { return _base.ProviderBase.PImpuesto; } }
        public virtual string TarjetaAsociada { get { return _base.ProviderBase.TarjetaAsociada; } set { _base.ProviderBase.TarjetaAsociada = value; } }
        public long OidAcreedor { get { return _base.ProviderBase.OidAcreedor; } }

        #endregion
                
        #region Business Methods


        protected void CopyValues(IDataReader source)
        {
            if (source == null) return;

            _base.CopyValues(source);
            Oid = Format.DataReader.GetInt64(source, "OID");

            //Pte. de quitar de aqui cuando se adapten todos los Acreedores
            _base.Record.Estado = Format.DataReader.GetInt64(source, "ESTADO");
        }
        protected void CopyValues(Instructor source)
        {
            if (source == null) return;

            _base.CopyValues(source);
            Oid = source.Oid;

            //Pte. de quitar de aqui cuando se adapten todos los Acreedores
            _base.Record.Estado = source.Estado;
        }

        public void CopyFrom(Instructor source) { CopyValues(source); }

        public virtual bool HasProfile(Perfil profile)
        {
            byte bit = Convert.ToByte(Math.Log(Convert.ToDouble((long)profile), 2));
            return ((Perfil >> bit) % 2) == 1;
        }

        public Decimal GetPrecio(ProductInfo producto, BatchInfo partida, ETipoFacturacion tipo)
        {
            if (Productos == null) LoadChilds(typeof(ProductoProveedor), false);
            return GetPrecio(producto, partida, tipo);
        }
        public Decimal GetDescuento(ProductInfo producto, BatchInfo partida)
        {
            if (Productos == null) LoadChilds(typeof(ProductoProveedor), false);
            return GetDescuento(producto, partida);
        }

		#endregion

		#region Factory Methods

		protected InstructorInfo() { /* require use of factory methods */ }

		private InstructorInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}

		internal InstructorInfo(Instructor item, bool copy_childs)
		{
            CopyValues(item);

            if (copy_childs)
            {
                _base.ProviderBase._producto_proveedores_list = (item.Productos != null) ? ProductoProveedorList.GetChildList(item.Productos) : null;
                _base.ProviderBase._pagos_list = (item.Pagos != null) ? PaymentList.GetChildList(item.Pagos) : null;
                _cursos_formacion = (item.CursosFormacion != null) ? CursoFormacionList.GetChildList(item.CursosFormacion) : null;
                _submodulos = (item.Submodulos != null) ? Submodulo_InstructorList.GetChildList(item.Submodulos) : null;
                _disponibilidades = (item.Disponibilidades != null) ? DisponibilidadList.GetChildList(item.Disponibilidades) : null;
                _promociones = (item.Promociones != null) ? Instructor_PromocionList.GetChildList(item.Promociones) : null;

            }
		}

		/// <summary>
		/// Devuelve un ClienteInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
		public static InstructorInfo Get(long oid)
		{
			return Get(oid, false);
		}

		/// <summary>
		/// Devuelve un ClienteInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
		public static InstructorInfo Get(long oid, bool childs)
		{
			CriteriaEx criteria = Instructor.GetCriteria(Instructor.OpenSession());
			//criteria.AddOidSearch(oid);
			criteria.Childs = childs;
            criteria.Query = InstructorInfo.SELECT(oid);
			InstructorInfo obj = DataPortal.Fetch<InstructorInfo>(criteria);
			Instructor.CloseSession(criteria.SessionCode);
			return obj;
		}

		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static InstructorInfo Get(IDataReader reader, bool childs)
		{
			return new InstructorInfo(reader, childs);
		}

        public void LoadChilds(Type type, bool get_childs)
        {
            if (type.Equals(typeof(ProductoProveedor)))
            {
                _base.ProviderBase._producto_proveedores_list = ProductoProveedorList.GetChildList(this, get_childs);
            }

            if (type.Equals(typeof(Disponibilidad)))
            {
                bool autorizados = ModulePrincipal.GetMostrarInstructoresAutorizadosSetting();
                if (!autorizados || (autorizados && MTOE))
                {
                    int sesion = Instructor.OpenSession();
                    string query = Instruction.Disponibilidades.SELECT_BY_INSTRUCTOR(this.Oid);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(sesion));
                    _disponibilidades = DisponibilidadList.GetChildList(reader);
                    Instructor.CloseSession(sesion);
                }
            }

            if (type.Equals(typeof(Submodulo_Instructor)))
            {
                int sesion = Instructor.OpenSession();
                string query = Submodulo_InstructorList.SELECT(this);
                IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(sesion));
                _submodulos = Submodulo_InstructorList.GetChildList(reader);
                Instructor.CloseSession(sesion);
            }
        }

        public void LoadSubmodulosInstructor(DateTime inicio, DateTime fin, bool get_childs)
        {
            int sesion = Instructor.OpenSession();
            string query = Submodulo_InstructorList.SELECT_BY_FECHA(this, inicio, fin);
            IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(sesion));
            _submodulos = Submodulo_InstructorList.GetChildList(reader);
            Instructor.CloseSession(sesion);
        }

        public void LoadInstructor_PromocionChilds(long oid_promocion, DateTime fecha_inicio, DateTime fecha_fin)
        {
            int sesion = Instructor.OpenSession();
            string query = Instructor_Promociones.SELECT_BY_INSTRUCTOR_PROMOCION(this.Oid, oid_promocion);
            IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(sesion));
            _promociones = Instructor_PromocionList.GetChildList(reader, fecha_inicio, fecha_fin);
            Instructor.CloseSession(sesion);
        }

        public static InstructorInfo New(long oid = 0) { return new InstructorInfo() { Oid = oid }; }

		#endregion

		#region Data Access

		// called to retrieve data from db
		private void DataPortal_Fetch(CriteriaEx criteria)
		{
			try
			{
				SessionCode = criteria.SessionCode;
				Childs = criteria.Childs;

				if (nHMng.UseDirectSQL)
				{

                    IDataReader reader = nHManager.Instance.SQLNativeSelect(criteria.Query, Session()); 
                    
					if (reader.Read())
						CopyValues(reader);
					
					if (Childs)
                    {
                        string query = string.Empty;

                        query = ProductoProveedorList.SELECT(this);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _base.ProviderBase._producto_proveedores_list = ProductoProveedorList.GetChildList(SessionCode, reader);

                        query = PaymentList.SELECT(this);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _base.ProviderBase._pagos_list = PaymentList.GetChildList(SessionCode, reader);	

						query = CursoFormacions.SELECT_BY_INSTRUCTOR(this.Oid);
						reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _cursos_formacion = CursoFormacionList.GetChildList(reader);

                        query = Submodulos_Instructores.SELECT_BY_INSTRUCTOR(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _submodulos = Submodulo_InstructorList.GetChildList(reader);

                        bool autorizados = ModulePrincipal.GetMostrarInstructoresAutorizadosSetting();
                        if (!autorizados || (autorizados && MTOE))
                        {
                            query = Instruction.Disponibilidades.SELECT_BY_INSTRUCTOR(this.Oid);
                            reader = nHManager.Instance.SQLNativeSelect(query, Session());
                            _disponibilidades = DisponibilidadList.GetChildList(reader);

                            query = Instructor_Promociones.SELECT_BY_INSTRUCTOR(this.Oid);
                            reader = nHManager.Instance.SQLNativeSelect(query, Session());
                            _promociones = Instructor_PromocionList.GetChildList(reader);
                        }
					}
				}
    		}
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
		}

		//called to copy data from IDataReader
		private void Fetch(IDataReader source)
		{
			try
			{
				CopyValues(source);

				if (Childs)
				{
                    string query = string.Empty;
                    IDataReader reader;

                    query = ProductoProveedorList.SELECT(this);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _base.ProviderBase._producto_proveedores_list = ProductoProveedorList.GetChildList(SessionCode, reader);

                    query = PaymentList.SELECT(this);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _base.ProviderBase._pagos_list = PaymentList.GetChildList(SessionCode, reader);

					query = CursoFormacions.SELECT_BY_INSTRUCTOR(this.Oid);
					reader = nHManager.Instance.SQLNativeSelect(query, Session());
					_cursos_formacion = CursoFormacionList.GetChildList(reader);

                    bool autorizados = ModulePrincipal.GetMostrarInstructoresAutorizadosSetting();
                    if (!autorizados || (autorizados && MTOE))
                    {
                        query = Submodulos_Instructores.SELECT_BY_INSTRUCTOR(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _submodulos = Submodulo_InstructorList.GetChildList(reader);

                        query = Instruction.Disponibilidades.SELECT_BY_INSTRUCTOR(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _disponibilidades = DisponibilidadList.GetChildList(reader);

                        query = Instructor_Promociones.SELECT_BY_INSTRUCTOR(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _promociones = Instructor_PromocionList.GetChildList(reader);
                    }
				}
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
		}

        #endregion

        #region SQL

        public static string SELECT(long oid) { return Instructor.SELECT(oid, false); }

        #endregion
	}
}

