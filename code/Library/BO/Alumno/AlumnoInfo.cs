using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;
using NHibernate.Impl;

using moleQule.Library;

using moleQule.Library.Hipatia;

namespace moleQule.Library.Instruction
{
	/// <summary>
	/// ReadOnly Child Business Object with ReadOnly Childs
	/// </summary>
	[Serializable()]
    public class AlumnoInfo : ReadOnlyBaseEx<AlumnoInfo>, IAgenteHipatia
    {
        #region IAgenteHipatia

        public string NombreHipatia { get { return Apellidos + ", " + Nombre; } }
        public string IDHipatia { get { return Codigo; } }
        public string ObservacionesHipatia { get { return Observaciones; } }
        public Type TipoEntidad { get { return typeof(Alumno); } }

        #endregion

        #region Attributes

        protected AlumnoBase _base = new AlumnoBase();

        private Alumno_ParteList _alumno_partes = null;
        private Material_AlumnoList _material_alumnos = null;
        private Alumno_ExamenList _alumno_examens = null;
        private Alumno_PracticaList _alumnos_practicas = null;
        private Alumno_PromocionList _promociones = null;


        #endregion

        #region Properties

        public AlumnoBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public string NExpediente { get { return _base.Record.NExpediente; } }
        public long Serial { get { return _base.Record.Serial; } }
        public string Nombre { get { return _base.Record.Nombre; } }
        public string Apellidos { get { return _base.Record.Apellidos; } }
        public string Id { get { return _base.Record.Identificador; } }
        public long TipoId { get { return _base.Record.TipoId; } }
        public string Email { get { return _base.Record.Email; } }
        public string Direccion { get { return _base.Record.Direccion; } }
        public string CodPostal { get { return _base.Record.CodPostal; } }
        public string Localidad { get { return _base.Record.Localidad; } }
        public string Municipio { get { return _base.Record.Municipio; } }
        public string Provincia { get { return _base.Record.Provincia; } }
        public string Telefono { get { return _base.Record.Telefono; } }
        public string NivelEstudios { get { return _base.Record.NivelEstudios; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }
        public string Foto { get { return _base.Record.Foto; } }
        public string Codigo { get { return _base.Record.Codigo; } }
        public long Grupo { get { return _base.Record.Grupo; } }
        public DateTime FechaNacimiento { get { return _base.Record.FechaNacimiento; } }
        public bool Requisitos { get { return _base.Record.Requisitos; } }
        public bool PruebaAcceso { get { return _base.Record.PruebaAcceso; } }
        public string LugarTrabajo { get { return _base.Record.LugarTrabajo; } }
        public string LugarEstudio { get { return _base.Record.LugarEstudio; } }
        public string Formacion { get { return _base.Record.Formacion; } }
        public string Idiomas { get { return _base.Record.Idiomas; } }

        public Alumno_ParteList AlumnoPartes { get { return _alumno_partes; } }
        public Material_AlumnoList MaterialAlumnos { get { return _material_alumnos; } }
        public Alumno_ExamenList AlumnoExamens { get { return _alumno_examens; } }
        public Alumno_PracticaList AlumnosPracticas { get { return _alumnos_practicas; } }
        public Alumno_PromocionList Promociones { get { return _promociones; } }



        #endregion

		#region Attributes

		/*protected string _n_expediente = string.Empty;
		protected long _serial;
		protected string _codigo = string.Empty;
		protected string _nombre = string.Empty;
		protected string _apellidos = string.Empty;
		protected string _id = string.Empty;
		protected long _tipo_id;
        protected DateTime _fecha_nacimiento;
		protected string _email = string.Empty;
		protected string _direccion = string.Empty;
		protected string _cod_postal = string.Empty;
		protected string _localidad = string.Empty;
		protected string _municipio = string.Empty;
		protected string _provincia = string.Empty;
		protected string _telefono = string.Empty;
		protected string _nivel_estudios = string.Empty;
		protected string _observaciones = string.Empty;
		protected string _foto = string.Empty;
		protected long _grupo;
        protected string _lugar_trabajo = string.Empty;
        protected string _lugar_estudio = string.Empty;
        protected bool _requisitos;
        protected bool _prueba_acceso;
        private string _formacion = string.Empty;
        private string _idiomas = string.Empty;*/
        
        #endregion

        #region Properties

		/*public string NExpediente { get { return _n_expediente; } }
		public long Serial { get { return _serial; } }
		public string Codigo { get { return _codigo; } }
		public string Nombre { get { return _nombre; } }
		public string Apellidos { get { return _apellidos; } }
		public string Id { get { return _id; } }
		public long TipoId { get { return _tipo_id; } }
        public DateTime FechaNacimiento { get { return _fecha_nacimiento; } }
		public string Email { get { return _email; } }
		public string Direccion { get { return _direccion; } }
		public string CodPostal { get { return _cod_postal; } }
		public string Localidad { get { return _localidad; } }
		public string Municipio { get { return _municipio; } }
		public string Provincia { get { return _provincia; } }
		public string Telefono { get { return _telefono; } }
		public string NivelEstudios { get { return _nivel_estudios; } }
		public string Observaciones { get { return _observaciones; } }
		public string Foto { get { return _foto; } }
		public long Grupo { get { return _grupo; } }
        public bool Requisitos { get { return _requisitos; } }
        public bool PruebaAcceso { get { return _prueba_acceso; } }
        public string LugarTrabajo { get { return _lugar_trabajo; } }
        public string LugarEstudio { get { return _lugar_estudio; } }
        public string Formacion { get { return _formacion; } }
        public string Idiomas { get { return _idiomas; } }*/
        
        #endregion

        #region Business Methods
        
        public void CopyFrom(Alumno source)
        {
            _base.CopyValues(source);
        }

		public AlumnoPrint GetPrintObject()
		{
			return AlumnoPrint.New(this);
		}

		#endregion

		#region Factory Methods

		protected AlumnoInfo() { /* require use of factory methods */ }

		private AlumnoInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}

		internal AlumnoInfo(Alumno source, bool copy_childs)
		{
            _base.CopyValues(source);

            if (copy_childs)
            {
                _alumno_partes = (source.AlumnoPartes != null) ? Alumno_ParteList.GetChildList(source.AlumnoPartes) : null;
                _material_alumnos = (source.MaterialAlumnos != null) ? Material_AlumnoList.GetChildList(source.MaterialAlumnos) : null;
                _alumno_examens = (source.AlumnoExamens != null) ? Alumno_ExamenList.GetChildList(source.AlumnoExamens) : null;
                _alumnos_practicas = (source.AlumnosPracticas != null) ? Alumno_PracticaList.GetChildList(source.AlumnosPracticas) : null;
                _promociones = (source.Promociones != null) ? Alumno_PromocionList.GetChildList(source.Promociones) : null;
            }
		}
        
		/// <summary>
		/// Devuelve un ClienteInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
		public static AlumnoInfo Get(long oid)
		{
			return Get(oid, false);
		}

		/// <summary>
		/// Devuelve un ClienteInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
		public static AlumnoInfo Get(long oid, bool childs)
		{
			CriteriaEx criteria = Alumno.GetCriteria(Alumno.OpenSession());
            criteria.Childs = childs;

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = AlumnoInfo.SELECT(oid);
            else
                criteria.AddOidSearch(oid);

            AlumnoInfo obj = DataPortal.Fetch<AlumnoInfo>(criteria);
			Alumno.CloseSession(criteria.SessionCode);
			return obj;
		}

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static AlumnoInfo GetForForm(long oid, bool childs)
        {
            CriteriaEx criteria = Alumno.GetCriteria(Alumno.OpenSession());
            criteria.Childs = childs;

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = AlumnoInfo.SELECT(oid);
            else
                criteria.AddOidSearch(oid);

            criteria.AddDistinctValue("TipoClase", 2);

            AlumnoInfo obj = DataPortal.Fetch<AlumnoInfo>(criteria);
            Alumno.CloseSession(criteria.SessionCode);
            return obj;
        }

		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static AlumnoInfo Get(IDataReader reader, bool childs)
		{
			return new AlumnoInfo(reader, childs);
		}

		#endregion

		#region Root Data Access

		// called to retrieve data from db
		private void DataPortal_Fetch(CriteriaEx criteria)
		{
			SessionCode = criteria.SessionCode;
			Childs = criteria.Childs;

			try
			{
				SessionCode = criteria.SessionCode;
				Childs = criteria.Childs;

				if (nHMng.UseDirectSQL)
				{

					IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

					if (reader.Read())
						_base.CopyValues(reader);

					if (Childs)
					{
                        string query = string.Empty;

                        foreach (CriteriaImpl.CriterionEntry item in criteria.IterateExpressionEntries())
                        {
                            if (item.ToString() == "not TipoClase = 2")
                                query = Alumno_Partes.SELECT_FALTAS_TEORICAS(this.Oid);
                        }

                        if (query == string.Empty)
                            query = Alumno_ParteList.SELECT(this);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _alumno_partes = Alumno_ParteList.GetChildList(reader);

                        query = Material_AlumnoList.SELECT(this);
						reader = nHManager.Instance.SQLNativeSelect(query, Session());
						_material_alumnos = Material_AlumnoList.GetChildList(reader);

                        query = Alumno_ExamenList.SELECT(this);
						reader = nHManager.Instance.SQLNativeSelect(query, Session());
						_alumno_examens = Alumno_ExamenList.GetChildList(reader);

                        query = Alumno_PracticaList.SELECT(this);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _alumnos_practicas = Alumno_PracticaList.GetChildList(reader);

                        query = Alumno_PromocionList.SELECT(this);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _promociones = Alumno_PromocionList.GetChildList(reader);
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
				_base.CopyValues(source);

				if (Childs)
				{
                    string query = Alumno_ParteList.SELECT(this);
					IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session());
					_alumno_partes = Alumno_ParteList.GetChildList(reader);

                    query = Material_AlumnoList.SELECT(this);
					reader = nHManager.Instance.SQLNativeSelect(query, Session());
					_material_alumnos = Material_AlumnoList.GetChildList(reader);

                    query = Alumno_ExamenList.SELECT(this);
					reader = nHManager.Instance.SQLNativeSelect(query, Session());
					_alumno_examens = Alumno_ExamenList.GetChildList(reader);

                    query = Alumno_PracticaList.SELECT(this);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _alumnos_practicas = Alumno_PracticaList.GetChildList(reader);

                    query = Alumno_PromocionList.SELECT(this);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _promociones = Alumno_PromocionList.GetChildList(reader);

				}
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
		}

        public void LoadChilds(Type type, bool get_childs)
        {
            if (type.Equals(typeof(Alumno_Examen)))
            {
                _alumno_examens = Alumno_ExamenList.GetChildList(this, get_childs);
            }
            else if (type.Equals(typeof(Alumno_Promocion)))
            {
                _promociones = Alumno_PromocionList.GetChildList(this, get_childs);
            }
        }

		#endregion

        #region SQL

        public static string SELECT(long oid)
        {
            return SELECT(oid, string.Empty);
        }

        public static string SELECT(long oid, string order_property)
        {
            string a = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));
            string p = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));
            string query;

            query = "SELECT A.*" +
                    " FROM " + a + " AS A";

            if (oid > 0)
                query += " WHERE A.\"OID\" = '" + oid.ToString() + "' ";

            if (order_property != string.Empty)
            {
                string order = nHManager.Instance.GetTableField(typeof(AlumnoRecord), order_property);
                query += " ORDER BY A.\"" + order + "\";";
 
            }
            return query;
        }

        #endregion

	}

    /// <summary>
    /// ReadOnly Root Object
    /// </summary>
    [Serializable()]
    public class SerialAlumnoInfo : SerialInfo
    {
        #region Attributes

        private string _n_promocion = string.Empty;

        #endregion

        #region Properties

        public string NPromocion { get { return _n_promocion; } }

        #endregion

        #region Business Methods

        protected new void CopyValues(IDataReader source)
        {
            base.CopyValues(source);

            _n_promocion = Format.DataReader.GetString(source, "N_PROMOCION");
        }

        #endregion

        #region Common Factory Methods

        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Object creation require use of factory methods
        /// </remarks>
        protected SerialAlumnoInfo() { /* require use of factory methods */ }


        #endregion

        #region Root Factory Methods

 /*       public static SerialAlumnoInfo GetNExpediente(long oid_promocion)
        {
            CriteriaEx criteria = Alumno.GetCriteria(Alumno.OpenSession());
            criteria.Childs = false;

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = SELECT_BY_PROMOCION(oid_promocion);

            SerialAlumnoInfo obj = DataPortal.Fetch<SerialAlumnoInfo>(criteria);
            Alumno.CloseSession(criteria.SessionCode);

            if (obj.NExpediente > 0)
            {
                int index = 0;
                if (obj.NExpedienteng().Length > 2) index = obj.Value.Length - 2;
                int code = Convert.ToInt32(obj.Value.Substring(index)) + 1;
                obj.Value = Convert.ToInt64(obj.NPromocion + code.ToString("00"));
            }
            else
                obj.Value = Convert.ToInt64(obj.NPromocion + "01");

            return obj;
        }*/

        /// <summary>
        /// Obtiene el siguiente serial para una entidad desde la base de datos
        /// </summary>
        /// <param name="entity">Tipo de Entidad</param>
        /// <returns>Objeto <see cref="ReadOnlyBaseEx"/>Construido a partir del registro</returns>
        public static long GetNext()
        {
            return SerialInfo.Get(typeof(Alumno)).Value + 1;
        }

        /// <summary>
        /// Obtiene el siguiente serial para una entidad desde la base de datos
        /// </summary>
        /// <param name="entity">Tipo de Entidad</param>
        /// <returns>Objeto <see cref="ReadOnlyBaseEx"/>Construido a partir del registro</returns>
        /*public static long GetNextNExpediente(long oid_promocion)
        {
            return Get(oid_promocion).Value + 1;
        }*/

        #endregion

        #region Root Data Access

        #endregion

        #region SQL

        public static string SELECT_BY_PROMOCION(long oid_promocion)
        {
            string a = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));
            string ap = nHManager.Instance.GetSQLTable(typeof(AlumnoPromocionRecord));
            string p = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));

            string query;

            query = "SELECT MAX(\"N_EXPEDIENTE\") AS \"SERIAL\"," +
                    "   P.\"NUMERO\" AS \"N_PROMOCION\"" +
                    " FROM " + a + " AS A" +
                    " INNER JOIN " + ap + " AS AP ON AP.\"OID_ALUMNO\" = A.\"OID\"" +
                    " INNER JOIN " + p + " AS P ON AP.\"OID_PROMOCION\" = P.\"OID\"" +
                    " WHERE A.\"OID_PROMOCION\" = " + oid_promocion.ToString();

            return query;
        }

        #endregion

    }
}

