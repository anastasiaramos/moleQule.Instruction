using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;

using moleQule.Library.Common;

namespace moleQule.Library.Instruction
{
    /// <summary>
    /// ReadOnly Child Business Object with ReadOnly Childs
    /// </summary>
    [Serializable()]
    public class ExamenInfo : ReadOnlyBaseEx<ExamenInfo>
    {
        #region Attributes

        protected ExamenBase _base = new ExamenBase();

        private Pregunta_ExamenList _preguntas = null;
        private PreguntaExamenList _pregunta_examenes = null;
        private Alumno_ExamenList _alumnos = null;
        private ExamenPromocionList _promociones = null;


        #endregion

        #region Properties

        public ExamenBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidPromocion { get { return _base.Record.OidPromocion; } }
        public long OidProfesor { get { return _base.Record.OidProfesor; } }
        public long OidModulo { get { return _base.Record.OidModulo; } }
        public DateTime FechaExamen { get { return _base.Record.FechaExamen; } }
        public DateTime FechaCreacion { get { return _base.Record.FechaCreacion; } }
        public DateTime FechaEmision { get { return _base.Record.FechaEmision; } }
        public string Tipo { get { return _base.Record.Tipo; } }
        public bool Desarrollo { get { return _base.Record.Desarrollo; } }
        public string Titulo { get { return _base.Record.Titulo; } }
        public DateTime Duracion { get { return _base.Record.Duracion; } }
        public string MemoPreguntas { get { return _base.Record.MemoPreguntas; } }
        public long Numero { get { return _base.Record.Numero; } }

        public virtual Pregunta_ExamenList Preguntas { get { return _preguntas; } }
        public virtual Alumno_ExamenList Alumnos { get { return _alumnos; } }
        public virtual PreguntaExamenList PreguntaExamenes { get { return _pregunta_examenes; } }
        public virtual ExamenPromocionList Promociones { get { return _promociones; } }

        public string Modulo { get { return _base.Modulo; } }
        public string Promocion { get { return _base.Promocion; } }
        public string Instructor { get { return _base.Instructor; } }
        public bool Emitido { get { return (!FechaEmision.Date.Equals(DateTime.MinValue.Date) && !FechaEmision.Date.Equals(DateTime.MaxValue.Date)); } }




        #endregion

        #region Business Methods

        public void CopyFrom(Examen source) { _base.CopyValues(source); }
        
        public ExamenPrint GetPrintObject(CompanyInfo empresa, string promocion, string observaciones)
        {
            return ExamenPrint.New(this, empresa, promocion, observaciones);
        }

        public ExamenPrint GetPrintObject(CompanyInfo empresa, string observaciones)
        {
            return GetPrintObject(empresa, null, observaciones);
        }

        #endregion		

        #region Common Factory Methods

        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Object creation require use of factory methods
        /// </remarks>
        protected ExamenInfo() { /* require use of factory methods */ }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reader"><see cref="IDataReader"/> origen de los datos</param>
        /// <param name="get_childs">Flag para obtener los hijos de la bd</param>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Object creation require use of factory methods
        /// </remarks>
        private ExamenInfo(IDataReader reader, bool retrieve_childs)
        {
            Childs = retrieve_childs;
            Fetch(reader);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reader"><see cref="BusinessBaseEx"/> origen</param>
        /// <param name="copy_childs">Flag para copiar los hijos</param>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Object creation require use of factory methods
        /// </remarks>
        internal ExamenInfo(Examen item, bool copy_childs)
        {
            _base.CopyValues(item);

            if (copy_childs)
            {
                _alumnos = (item.Alumnos != null) ? Alumno_ExamenList.GetChildList(item.Alumnos) : null;
                _preguntas = (item.Pregunta_Examens != null) ? Pregunta_ExamenList.GetChildList(item.Pregunta_Examens) : null;
                _pregunta_examenes = (item.PreguntaExamens != null) ? PreguntaExamenList.GetChildList(item.PreguntaExamens) : null;
                _promociones = (item.Promociones != null) ? ExamenPromocionList.GetChildList(item.Promociones) : null;
            }
        }

        /// <summary>
        /// Obtiene un <see cref="ReadOnlyBaseEx"/> a partir de un <see cref="IDataReader"/>
        /// </summary>
        /// <param name="reader"><see cref="IDataReader"/> con los datos del objeto</param>
        /// <returns>Objeto <see cref="ReadOnlyBaseEx"/> construido a partir del registro</returns>
        /// <remarks>
        /// NO OBTIENE los datos de los hijos. Para ello utiliza GetChild(IDataReader reader, bool retrieve_childs)
        /// La utiliza la ReadOnlyListBaseEx correspondiente para montar la lista
        /// <remarks/>
        public static ExamenInfo GetChild(IDataReader reader)
        {
            return GetChild(reader, false);
        }

        /// <summary>
        /// Obtiene un <see cref="ReadOnlyBaseEx"/> a partir de un <see cref="IDataReader"/>
        /// </summary>
        /// <param name="reader"><see cref="IDataReader"/> con los datos del objeto</param>
        /// <param name="get_childs">Flag para obtener los hijos de la bd</param>
        /// <returns>Objeto <see cref="ReadOnlyBaseEx"/> construido a partir del registro</returns>
        /// <remarks>La utiliza la ReadOnlyListBaseEx correspondiente para montar la lista<remarks/>
        public static ExamenInfo GetChild(IDataReader reader, bool retrieve_childs)
        {
            return new ExamenInfo(reader, retrieve_childs);
        }

        public void LoadChilds(Type type, bool get_childs)
        {
            if (type.Equals(typeof(ExamenPromocion)))
            {
                int sesion = Examen.OpenSession();
                string query = ExamenPromocionList.SELECT(this);
                IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(sesion));
                _promociones = ExamenPromocionList.GetChildList(sesion, reader);
                Examen.CloseSession(sesion);
            }
        }

        public static ExamenInfo New(long oid = 0) { return new ExamenInfo() { Oid = oid }; }

        #endregion

        #region Root Factory Methods

        /// <summary>
        /// Obtiene un <see cref="ReadOnlyBaseEx"/> de la base de datos
        /// </summary>
        /// <param name="oid">Oid del objeto</param>
        /// <returns>Objeto <see cref="ReadOnlyBaseEx"/> construido a partir del registro</returns>
        public static ExamenInfo Get(long oid)
        {
            return Get(oid, false);
        }

        /// <summary>
        /// Obtiene un <see cref="ReadOnlyBaseEx"/> de la base de datos
        /// </summary>
        /// <param name="oid">Oid del objeto</param>
        /// <param name="get_childs">Flag para obtener los hijos de la bd</param>
        /// <returns>Objeto <see cref="ReadOnlyBaseEx"/> construido a partir del registro</returns>
        public static ExamenInfo Get(long oid, bool retrieve_childs)
        {
            CriteriaEx criteria = Examen.GetCriteria(Examen.OpenSession());
            criteria.Childs = retrieve_childs;

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = ExamenInfo.SELECT(oid);
            else
                criteria.AddOidSearch(oid);

            ExamenInfo obj = DataPortal.Fetch<ExamenInfo>(criteria);
            Examen.CloseSession(criteria.SessionCode);
            return obj;
        }

        public static DateTime GetUltimoByPreguntaIncluida(long oid_pregunta, DateTime fecha_examen)
        {
            CriteriaEx criteria = Examen.GetCriteria(Examen.OpenSession());
            string e = nHManager.Instance.GetSQLTable(typeof(ExamenRecord));
            string pe = nHManager.Instance.GetSQLTable(typeof(PreguntaExamenRecord));

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = "SELECT MAX(EX.\"FECHA_EXAMEN\") AS \"FECHA_EXAMEN\" " +
                                    "FROM " + e + " AS EX " +
                                    "INNER JOIN " + pe + " AS PE ON PE.\"OID_EXAMEN\" = EX.\"OID\" " +
                                    "WHERE PE.\"OID_PREGUNTA\" = " + oid_pregunta.ToString() + " AND EX.\"FECHA_EXAMEN\" <> '" + fecha_examen.ToString("yyyy-MM-dd") + "'";

            IDataReader reader = null;
            DateTime fecha = DateTime.MinValue;

            reader = nHManager.Instance.SQLNativeSelect(criteria.Query);

            if (reader.Read())
                fecha = Format.DataReader.GetDateTime(reader, "FECHA_EXAMEN");

            Examen.CloseSession(criteria.SessionCode);
            return fecha;
        }

        #endregion

        #region Root Data Access

        /// <summary>
        /// Obtiene un registro de la base de datos
        /// </summary>
        /// <param name="criteria"><see cref="CriteriaEx"/> con los criterios</param>
        /// <remarks>
        /// La llama el DataPortal
        /// </remarks>
        private void DataPortal_Fetch(CriteriaEx criteria)
        {
            SessionCode = criteria.SessionCode;
            Childs = criteria.Childs;

            try
            {
                if (nHMng.UseDirectSQL)
                {
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        string query = string.Empty;

                        query = Alumno_ExamenList.SELECT_BY_EXAMEN(this.Oid);
                        reader = nHMng.SQLNativeSelect(query, Session());
                        _alumnos = Alumno_ExamenList.GetChildList(reader);

                        query = Pregunta_ExamenList.SELECT_BY_EXAMEN(this.Oid);
                        reader = nHMng.SQLNativeSelect(query, Session());
                        _preguntas = Pregunta_ExamenList.GetChildList(reader);

                        query = PreguntaExamenList.SELECT_BY_EXAMEN(this.Oid);
                        reader = nHMng.SQLNativeSelect(query, Session());
                        _pregunta_examenes = PreguntaExamenList.GetChildList(reader, true);

                        query = ExamenPromocionList.SELECT(this);
                        reader = nHMng.SQLNativeSelect(query, Session());
                        _promociones = ExamenPromocionList.GetChildList(SessionCode, reader);
                    }
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
        }

        #endregion

        #region Child Data Access

        /// <summary>
        /// Obtiene un objeto a partir de un <see cref="IDataReader"/>.
        /// Obtiene los hijos si los tiene y se solicitan
        /// </summary>
        /// <param name="criteria"><see cref="IDataReader"/> con los datos</param>
        /// <remarks>
        /// La utiliza el <see cref="ReadOnlyListBaseEx"/> correspondiente para construir los objetos de la lista
        /// </remarks>
        private void Fetch(IDataReader source)
        {
            try
            {
                _base.CopyValues(source);

                if (Childs)
                {
                    string query = string.Empty;
                    IDataReader reader;

                    query = Alumno_ExamenList.SELECT_BY_EXAMEN(this.Oid);
                    reader = nHMng.SQLNativeSelect(query, Session());
                    _alumnos = Alumno_ExamenList.GetChildList(reader);

                    query = Pregunta_ExamenList.SELECT_BY_EXAMEN(this.Oid);
                    reader = nHMng.SQLNativeSelect(query, Session());
                    _preguntas = Pregunta_ExamenList.GetChildList(reader);

                    query = PreguntaExamenList.SELECT_BY_EXAMEN(this.Oid);
                    reader = nHMng.SQLNativeSelect(query, Session());
                    _pregunta_examenes = PreguntaExamenList.GetChildList(reader, true);

                    query = ExamenPromocionList.SELECT(this);
                    reader = nHMng.SQLNativeSelect(query, Session());
                    _promociones = ExamenPromocionList.GetChildList(SessionCode, reader);
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
        }

        #endregion

        #region SQL

        internal static string SELECT(long oid) { return Examen.SELECT(oid, false); }

        #endregion
    }
}

