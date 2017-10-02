using System;
using System.Collections.Generic;
using System.Data;

using Csla;

using moleQule.Library;
using moleQule.Library.CslaEx;

namespace moleQule.Library.Instruction
{

    /// <summary>
    /// ReadOnly Child Business Object
    /// </summary>
    [Serializable()]
    public class Alumno_ExamenInfo : ReadOnlyBaseEx<Alumno_ExamenInfo>
    {
        #region Attributes

        protected AlumnoExamenBase _base = new AlumnoExamenBase();

        protected string _calificacion_string = string.Empty;

        protected Respuesta_Alumno_ExamenList _respuestas = null;


        #endregion

        #region Properties

        public AlumnoExamenBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidAlumno { get { return _base.Record.OidAlumno; } }
        public long OidExamen { get { return _base.Record.OidExamen; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }
        public bool Presentado { get { return _base.Record.Presentado; } }
        public Decimal Calificacion { get { return _base.Record.Calificacion; } }

        public Respuesta_Alumno_ExamenList Respuestas { get { return _respuestas; } }

        public long OidPromocion { get { return _base.OidPromocion; } set { _base.OidPromocion = value; } }
        public string Modulo { get { return _base.Modulo; } }
        public DateTime FechaExamen { get { return _base.FechaExamen; } }
        public bool Desarrollo { get { return _base.Desarrollo; } }
        public string CalificacionString
        {
            get
            {
                if (_base.Record.Presentado)
                {
                    if (_base.Desarrollo)
                    {
                        if (_respuestas != null)
                        {
                            string calif = string.Empty;

                            foreach (Respuesta_Alumno_ExamenInfo info in _respuestas)
                            {
                                if (calif != string.Empty)
                                    calif += " - ";
                                calif += info.Calificacion.ToString() + "%";
                            }
                            return calif;
                        }
                        else
                        {
                            Alumno_ExamenInfo nuevo = Alumno_ExamenInfo.Get(Oid, true);
                            string calif = string.Empty;
                            foreach (Respuesta_Alumno_ExamenInfo resp in nuevo.Respuestas)
                            {
                                if (calif != string.Empty)
                                    calif += " - ";
                                calif += resp.Calificacion.ToString() + "%";
                            }
                            return calif;
                        }
                    }
                    else
                        return _base.Record.Calificacion.ToString() + "%";
                }
                else
                    return "NP";

            }
            set { _calificacion_string = value; }
        }



        #endregion

        #region Business Methods

        public void CopyFrom(Alumno_Examen source) { _base.CopyValues(source); }

        #endregion		

        #region Factory Methods

        protected Alumno_ExamenInfo() { /* require use of factory methods */ }

        private Alumno_ExamenInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }
        private Alumno_ExamenInfo(int sessionCode, IDataReader reader, bool childs)
        {
            SessionCode = sessionCode;
            Childs = childs;
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
        internal Alumno_ExamenInfo(Alumno_Examen item, bool copy_childs)
        {
            _base.CopyValues(item);

            if (copy_childs)
            {
                _respuestas = (item.Respuestas != null) ? Respuesta_Alumno_ExamenList.GetChildList(item.Respuestas) : null;
            }
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Alumno_ExamenInfo Get(IDataReader reader, bool childs)
        {
            return new Alumno_ExamenInfo(reader, childs);
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Alumno_ExamenInfo Get(int sessionCode, IDataReader reader, bool childs)
        {
            return new Alumno_ExamenInfo(sessionCode, reader, childs);
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static Alumno_ExamenInfo Get(long oid)
        {
            return Get(oid, false);
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static Alumno_ExamenInfo Get(long oid, bool childs)
        {
            CriteriaEx criteria = Alumno_Examen.GetCriteria(Submodulo.OpenSession());
            criteria.AddOidSearch(oid);
            criteria.Childs = childs;
            Alumno_ExamenInfo obj = DataPortal.Fetch<Alumno_ExamenInfo>(criteria);
            Alumno_ExamenInfo.CloseSession(criteria.SessionCode);
            return obj;
        }

        public static Alumno_ExamenInfo New(long oid = 0) { return new Alumno_ExamenInfo() { Oid = oid }; }


        public Alumno_ExamenPrint GetPrintObject(AlumnoInfo alumno, int numero, bool notas)
        {
            Alumno_ExamenPrint itemPrint = Alumno_ExamenPrint.New(this, alumno, numero, notas);
            return itemPrint;
        }

        #endregion

        #region Data Access

        // called to retrieve data from db
        private void DataPortal_Fetch(CriteriaEx criteria)
        {
            SessionCode = criteria.SessionCode;
            Childs = criteria.Childs;

            try
            {
                if (nHMng.UseDirectSQL)
                {

                    IDataReader reader = Alumno_Examen.DoSELECT(AppContext.ActiveSchema.Code, Session(), criteria.Oid);

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        string query = string.Empty;

                        query = Respuesta_Alumno_ExamenList.SELECT(this);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _respuestas = Respuesta_Alumno_ExamenList.GetChildList(reader);
                    }
                }
                else
                {
                    _base.Record.CopyValues((AlumnoExamenRecord)(criteria.UniqueResult()));

                    if (Childs)
                    {

                        criteria = Respuesta_Alumno_Examen.GetCriteria(criteria.Session);
                        criteria.AddEq("OidAlumnoExamen", this.Oid);
                        _respuestas = Respuesta_Alumno_ExamenList.GetChildList(criteria.List<Respuesta_Alumno_Examen>());
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
                    string query = string.Empty;
                    IDataReader reader;

                    query = Respuesta_Alumno_ExamenList.SELECT(this);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _respuestas = Respuesta_Alumno_ExamenList.GetChildList(reader);
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
        }

        #endregion

    }
}

