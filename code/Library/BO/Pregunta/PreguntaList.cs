using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;

namespace moleQule.Library.Instruction
{

    /// <summary>
    /// Read Only Child Collection of Business Objects
    /// </summary>
    [Serializable()]
    public class PreguntaList : ReadOnlyListBaseEx<PreguntaList, PreguntaInfo>
    {

        #region Child Factory Methods

        private PreguntaList() { }

        public static PreguntaList NewList() { return new PreguntaList(); }

        private PreguntaList(IList<Pregunta> lista)
        {
            Fetch(lista);
        }

        private PreguntaList(IDataReader reader)
        {
            Fetch(reader);
        }

        /// <summary>
        /// Builds a PreguntaList from a IList<!--<PreguntaInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>PreguntaList</returns>
        public static PreguntaList GetChildList(IList<PreguntaInfo> list)
        {
            PreguntaList flist = new PreguntaList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (PreguntaInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }


        /// <summary>
        /// Builds a PreguntaList from IList<!--<Pregunta>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>PreguntaList</returns>
        public static PreguntaList GetChildList(IList<Pregunta> list) { return new PreguntaList(list); }

        public static PreguntaList GetChildList(IDataReader reader) { return new PreguntaList(reader); }

        #endregion

        #region Root Factory Methods

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>PreguntaList</returns>
        public static PreguntaList GetList(bool childs)
        {
            CriteriaEx criteria = Pregunta.GetCriteria(Pregunta.OpenSession());
            criteria.Childs = childs;
            criteria.Query = Preguntas.SELECT_PREGUNTAS();
            //No criteria. Retrieve all de List
            PreguntaList list = DataPortal.Fetch<PreguntaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>PreguntaList</returns>
        public void FormatImagenList()
        {
            foreach (PreguntaInfo item in this)
            {
                if (item.Imagen != string.Empty && item.Imagen == item.Oid.ToString() + ".jpg")
                {
                    string imagen = item.Oid.ToString("00000") + ".jpg";
                    //cambiar el nombre de la imagen
                    string query = UPDATE_IMAGEN(item.Oid, imagen);
                    CriteriaEx criteria = Pregunta.GetCriteria(Pregunta.OpenSession());
                    nHManager.Instance.SQLNativeExecute(query, Session());
                    CloseSession(criteria.SessionCode);
                }
            }
        }

       
        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>PreguntaList</returns>
        public void FormatCodigoList()
        {
            foreach (PreguntaInfo item in this)
            {
                if (item.OidOld != 0 && item.Codigo == string.Empty)
                {
                    string query = UPDATE_CODIGO(item.Oid, item.OidOld, item.OidOld.ToString("00000"));
                    CriteriaEx criteria = Pregunta.GetCriteria(Pregunta.OpenSession());
                    nHManager.Instance.SQLNativeExecute(query, Session());
                    CloseSession(criteria.SessionCode);
                }
            }

            long serial = Pregunta.GetNewSerial();
            foreach (PreguntaInfo item in this)
            {
                if (item.Serial == 0)
                {
                    string query = UPDATE_CODIGO(item.Oid, serial, serial.ToString("00000"));
                    CriteriaEx criteria = Pregunta.GetCriteria(Pregunta.OpenSession());
                    nHManager.Instance.SQLNativeExecute(query, Session());
                    CloseSession(criteria.SessionCode);
                    serial++;
                }
            }
        }

        public static string UPDATE_IMAGEN(long oid, string imagen)
        {
            string pregunta = nHManager.Instance.Cfg.GetClassMapping(typeof(PreguntaRecord)).Table.Name;
            string c_imagen = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "Imagen");

            string query;

            string esquema = Convert.ToInt32(AppContext.ActiveSchema.Code).ToString("0000");

            query = "UPDATE " + "\"" + esquema + "\".\"" + pregunta + "\" " +
                    "SET \"" + c_imagen + "\" = '" + imagen + "' " +
                    "WHERE \"OID\" = " + oid.ToString() + ";";

            return query;
        }

        private static string UPDATE_CODIGO(long oid, long serial, string codigo)
        {
            string pregunta = nHManager.Instance.Cfg.GetClassMapping(typeof(PreguntaRecord)).Table.Name;
            string c_serial = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "Serial");
            string c_codigo = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "Codigo");

            string query;

            string esquema = Convert.ToInt32(AppContext.ActiveSchema.Code).ToString("0000");

            query = "UPDATE " + "\"" + esquema + "\".\"" + pregunta + "\" " +
                    "SET \"" + c_codigo + "\" = '" + codigo + "', " +
                    "\"" + c_serial + "\" = " + serial.ToString() + " " +
                    "WHERE \"OID\" = " + oid.ToString() + ";";

            return query;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>PreguntaList</returns>
        public static PreguntaList GetList()
        {
            return GetList(true);
        }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static PreguntaList GetList(CriteriaEx criteria)
        {
            return PreguntaList.RetrieveList(typeof(Pregunta), AppContext.ActiveSchema.Code, criteria);
        }

        /// <summary>
        /// Builds a PreguntaList from a IList<!--<PreguntaInfo>-->
        /// Doesn`t retrieve child data from DB.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>PreguntaList</returns>
        public static PreguntaList GetList(IList<PreguntaInfo> list)
        {
            PreguntaList flist = new PreguntaList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (PreguntaInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a PreguntaList from a IList<!--<Pregunta>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Pregunta</returns>
        public static PreguntaList GetList(IList<Pregunta> list, bool childs)
        {
            PreguntaList flist = new PreguntaList();

            if (list != null)
            {
                foreach (Pregunta item in list)
                    flist.AddItem(item.GetInfo(childs));
            }

            return flist;
        }

        /// <summary>
        /// Builds a PreguntaList from a IList<!--<Pregunta>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Pregunta</returns>
        public static PreguntaList GetList(IList<Pregunta> list)
        {
            PreguntaList flist = new PreguntaList();

            if (list != null)
            {
                foreach (Pregunta item in list)
                    flist.AddItem(item.GetInfo(true));
            }

            return flist;
        }

        public static PreguntaList GetOrderedPrintList(IList<Pregunta> list)
        {
            CriteriaEx criteria = Pregunta.GetCriteria(Pregunta.OpenSession());

            string lista_preguntas = "(";

            foreach (Pregunta item in list)
                lista_preguntas += item.Oid + ",";

            if (lista_preguntas.EndsWith(","))
                lista_preguntas = lista_preguntas.Substring(0, lista_preguntas.Length - 1) + ")";

            Pregunta.BeginTransaction(criteria.SessionCode);
            criteria.Query = PreguntaList.SELECT_LISTADO_ORDENADO(lista_preguntas);
            criteria.Childs = false;

            CloseSession(criteria.SessionCode);

            //No criteria. Retrieve all de List
            return DataPortal.Fetch<PreguntaList>(criteria);
        }

        public static PreguntaList GetList(PreguntaExamenList lista)
        {
            PreguntaList list = new PreguntaList();

            foreach (PreguntaExamenInfo item in lista)
                list.AddItem(new PreguntaInfo(item));

            return list;
        }

        /// <summary>
        /// Devuelve una lista ordenada de todos los elementos
        /// </summary>
        /// <param name="sortProperty">Campo de ordenación</param>
        /// <param name="sortDirection">Sentido de ordenación</param>
        /// <returns>Lista ordenada de elementos</returns>
        public static SortedBindingList<PreguntaInfo> GetSortedList(string sortProperty,
                                                                    ListSortDirection sortDirection)
        {
            SortedBindingList<PreguntaInfo> sortedList =
                new SortedBindingList<PreguntaInfo>(GetList(false));
            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static PreguntaList GetModuloList(long oid_modulo)
        {
            CriteriaEx criteria = Pregunta.GetCriteria(Pregunta.OpenSession());
            criteria.AddEq("OidModulo", oid_modulo);
            criteria.Childs = false;
            PreguntaList list = PreguntaList.RetrieveList(typeof(Pregunta), AppContext.ActiveSchema.Code, criteria);
            CloseSession(criteria.SessionCode);
            return list;
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Pregunta> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (Pregunta item in lista)
                this.AddItem(item.GetInfo());

            this.RaiseListChangedEvents = true;

            IsReadOnly = true;
        }

        // called to copy objects data from list
        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(PreguntaInfo.Get(reader, true));

            this.RaiseListChangedEvents = true;
        }

        // called to retrieve data from db
        protected override void Fetch(CriteriaEx criteria)
        {
            this.RaiseListChangedEvents = false;

            Childs = criteria.Childs;
            SessionCode = criteria.SessionCode;

            try
            {
                if (nHMng.UseDirectSQL)
                {
                    IDataReader reader = null;

                    reader = nHMng.SQLNativeSelect(criteria.Query);

                    while (reader.Read())
                        this.AddItem(PreguntaInfo.Get(reader, Childs));
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            this.RaiseListChangedEvents = true;
        }

        #endregion

        #region Root Data Access

        // called to retrieve data from db
        protected override void Fetch(string hql)
        {
            this.RaiseListChangedEvents = false;

            try
            {
                IList list = nHMng.HQLSelect(hql);

                if (list.Count > 0)
                {
                    foreach (Pregunta item in list)
                        this.AddItem(item.GetInfo());
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            this.RaiseListChangedEvents = true;
        }

        #endregion

        #region Commands

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <param name="get_childs">retrieving the childs</param>
        /// <returns></returns>
        public PreguntaList GetPreguntasFiltradas(long oid_modulo, long oid_tema, long nivel,
                                                        string tipo, string idioma, DateTime fecha_alta,
                                                        DateTime fecha_disponibilidad, bool revisada,
                                                        bool activa, string texto, bool filtros, bool reservada, long numero)
        {
            PreguntaList lista = new PreguntaList();
            //string query = PreguntaList.SELECT_PREGUNTAS_FILTRADAS(oid_modulo, oid_submodulo, nivel, tipo,
            //                                                        idioma, fecha_alta, fecha_disponibilidad,
            //                                                        revisada, activa, texto, filtros, reservada);
            //int sesion = Pregunta.OpenSession();

            //IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(sesion));

            lista.RaiseListChangedEvents = false;

            lista.IsReadOnly = false;

            foreach (PreguntaInfo item in this)
            {
                if ((numero == 0 || item.Serial == numero) 
                    && (oid_modulo == 0 || item.OidModulo == oid_modulo)
                    && (oid_tema == 0 || item.OidTema == oid_tema)
                    && (nivel == 0 || item.Nivel == nivel)
                    && (tipo == string.Empty || tipo == item.Tipo)
                    && (idioma == string.Empty || item.Idioma == idioma)
                    && (fecha_alta.Date.Equals(DateTime.MinValue.Date) || fecha_alta.Date.Equals(item.FechaAlta.Date))
                    && (fecha_disponibilidad.Date.Equals(DateTime.MinValue.Date) || fecha_disponibilidad.Date <= item.FechaDisponibilidad.Date)
                    && (!filtros || (filtros && activa == item.Activa && revisada == item.Revisada && reservada == item.Bloqueada
                    && (fecha_disponibilidad.Date.Equals(DateTime.MinValue.Date) && item.FechaDisponibilidad.Date > DateTime.Today.Date)))
                    && (texto == string.Empty || item.Texto.Contains(texto)))

                    lista.AddItem(item);
            }

            //while (reader.Read())
            //{
            //    PreguntaInfo p = this.GetItem((long)reader["OID"]);

            //    lista.AddItem(p);
            //}

            lista.IsReadOnly = true;

            lista.RaiseListChangedEvents = true;

            return lista;
        }


        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <param name="get_childs">retrieving the childs</param>
        /// <returns></returns>
        public static PreguntaList GetPreguntasModulo(long oid_modulo)
        {
            PreguntaList preguntas = PreguntaList.GetList(false);
            return preguntas.GetPreguntasFiltradas(oid_modulo, 0, 0, string.Empty, string.Empty, DateTime.MinValue, DateTime.MinValue,
                                         true, true, string.Empty, false, false,0);
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <param name="get_childs">retrieving the childs</param>
        /// <returns></returns>
        public static PreguntaList GetPreguntasTema(long oid_modulo, long oid_tema)
        {
            PreguntaList preguntas = PreguntaList.GetList(false);
            return preguntas.GetPreguntasFiltradas(oid_modulo, oid_tema, 0, string.Empty, string.Empty, DateTime.MinValue, DateTime.MinValue,
                                         true, true, string.Empty, false, false, 0);
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>PreguntaList</returns>
        public static PreguntaList GetPreguntasDisponiblesModulo(long oid_modulo, bool desarrollo, DateTime fecha_examen, long limit)
        {
            CriteriaEx criteria = Pregunta.GetCriteria(Pregunta.OpenSession());
            criteria.Childs = false;
            criteria.Query = PreguntaList.SELECT_DISPONIBLES_BY_MODULO(oid_modulo, desarrollo, fecha_examen, limit);
            //No criteria. Retrieve all de List
            PreguntaList list = DataPortal.Fetch<PreguntaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>PreguntaList</returns>
        public static PreguntaList GetPreguntasDisponiblesTema(long oid_tema, bool desarrollo, DateTime fecha_examen, long limit)
        {
            CriteriaEx criteria = Pregunta.GetCriteria(Pregunta.OpenSession());
            criteria.Childs = false;
            criteria.Query = PreguntaList.SELECT_DISPONIBLES_BY_TEMA(oid_tema, desarrollo, fecha_examen, limit);
            //No criteria. Retrieve all de List
            PreguntaList list = DataPortal.Fetch<PreguntaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>PreguntaList</returns>
        public static PreguntaList GetPreguntasTema(long oid_tema, bool childs)
        {
            CriteriaEx criteria = Pregunta.GetCriteria(Pregunta.OpenSession());
            criteria.Childs = childs;
            criteria.Query = PreguntaList.SELECT_BY_TEMA(oid_tema);
            //No criteria. Retrieve all de List
            PreguntaList list = DataPortal.Fetch<PreguntaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>PreguntaList</returns>
        public static PreguntaList GetPreguntasTema(long oid_tema)
        {
            return GetPreguntasTema(oid_tema, false);
        }

        public static PreguntaList GetPreguntasByList(string lista_preguntas)
        {
            CriteriaEx criteria = Pregunta.GetCriteria(Pregunta.OpenSession());
            PreguntaList lista = new PreguntaList();

            if (lista_preguntas == string.Empty) lista_preguntas = "-1";
            Pregunta.BeginTransaction(criteria.SessionCode);
            criteria.Query = Preguntas.SELECT_BY_LIST(lista_preguntas);
            criteria.Childs = true;

            //No criteria. Retrieve all de List
            PreguntaList aux = DataPortal.Fetch<PreguntaList>(criteria);
            CloseSession(criteria.SessionCode);

            string[] orden = lista_preguntas.Split(',');

            lista.IsReadOnly = false;

            foreach (string item in orden)
            {
                try
                {
                    long oid = Convert.ToInt32(item);
                    PreguntaInfo pregunta = aux.GetItem(oid);
                    lista.AddItem(pregunta);
                }
                catch { continue; }
            }

            lista.IsReadOnly = true;

            return lista;
        }

        public static PreguntaList GetListaExamen(string lista_preguntas)
        {
            CriteriaEx criteria = Pregunta.GetCriteria(Pregunta.OpenSession());
            PreguntaList lista = new PreguntaList();

            if (lista_preguntas == string.Empty) lista_preguntas = "-1";
            Pregunta.BeginTransaction(criteria.SessionCode);
            criteria.Query = PreguntaList.SELECT_LISTADO_EXAMEN_NO_EMITIDO(lista_preguntas);
            criteria.Childs = false;

            CloseSession(criteria.SessionCode);

            //No criteria. Retrieve all de List
            return DataPortal.Fetch<PreguntaList>(criteria);
        }

        public static PreguntaList GetListaExamen(long oid_examen)
        {
            CriteriaEx criteria = Pregunta.GetCriteria(Pregunta.OpenSession());
            PreguntaList lista = new PreguntaList();

            Pregunta.BeginTransaction(criteria.SessionCode);
            criteria.Query = PreguntaList.SELECT_LISTADO_EXAMEN_EMITIDO(oid_examen);
            criteria.Childs = false;

            CloseSession(criteria.SessionCode);

            //No criteria. Retrieve all de List
            return DataPortal.Fetch<PreguntaList>(criteria);
        }
        
        public static PreguntaList GetPreguntasModulo(long oid_modulo, string memo_preguntas)
        {
            if (memo_preguntas == string.Empty)
                return GetPreguntasModulo(oid_modulo);
            CriteriaEx criteria = Pregunta.GetCriteria(Pregunta.OpenSession());
            string lista_preguntas = string.Empty;

            if (memo_preguntas != string.Empty) memo_preguntas = memo_preguntas.Substring(0, memo_preguntas.Length - 1);
            lista_preguntas = memo_preguntas.Replace(';', ',');

            Pregunta.BeginTransaction(criteria.SessionCode);
            criteria.Query = Preguntas.SELECT_BY_MODULO_LIST(oid_modulo, lista_preguntas);
            criteria.Childs = false;

            CloseSession(criteria.SessionCode);

            //No criteria. Retrieve all de List
            return DataPortal.Fetch<PreguntaList>(criteria);
        }

        public static PreguntaList SeparaPreguntasTest(PreguntaList lista)
        {
            PreguntaList test = new PreguntaList();

            test.IsReadOnly = false;

            foreach (PreguntaInfo item in lista)
            {
                if (item.Tipo == "Test")
                    test.AddItem(item);
            }

            test.IsReadOnly = true;

            return test;
        }

        public static PreguntaList SeparaPreguntasDesarrollo(PreguntaList lista)
        {
            PreguntaList desarrollo = new PreguntaList();

            desarrollo.IsReadOnly = false;

            foreach (PreguntaInfo item in lista)
            {
                if (item.Tipo == "Desarrollo")
                    desarrollo.AddItem(item);
            }

            desarrollo.IsReadOnly = true;

            return desarrollo;
        }

        #endregion

        #region SQL

        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public static string SELECT()
        {
            string query = Pregunta.SELECT(0, false, " ORDER BY \"ORDEN\", \"NIVEL\", \"TIPO\", \"SERIAL\"");

            return query;
        }

        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public static string SELECT_PREGUNTAS()
        {
            string query = Pregunta.SELECT(0, false, " ORDER BY \"ORDEN\", \"SERIAL\"");

            return query;
        }

        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public static string SELECT_PREGUNTAS_FILTRADAS(long oid_modulo, long oid_tema, long nivel,
                                                        string tipo, string idioma, DateTime fecha_alta,
                                                        DateTime fecha_disponibilidad, bool revisada,
                                                        bool activa, string texto, bool filtros, bool reservada,
                                                        long numero)
        {
            string pregunta = nHManager.Instance.Cfg.GetClassMapping(typeof(PreguntaRecord)).Table.Name;
            string fecha = string.Empty;
            fecha = "'" + fecha_alta.Year.ToString() + "-" + fecha_alta.Month.ToString() + "-" + fecha_alta.Day.ToString() + "'";
            string fecha_d = string.Empty;
            fecha_d = "'" + fecha_disponibilidad.Year.ToString() + "-" + fecha_disponibilidad.Month.ToString() + "-" + fecha_disponibilidad.Day.ToString() + "'";
            string fecha_actual = string.Empty;
            fecha_actual = "'" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "'";

            string modulo = nHManager.Instance.Cfg.GetClassMapping(typeof(ModuloRecord)).Table.Name;
            string submodulo = nHManager.Instance.Cfg.GetClassMapping(typeof(SubmoduloRecord)).Table.Name;
            string tema = nHManager.Instance.Cfg.GetClassMapping(typeof(TemaRecord)).Table.Name;
            string c_oid_modulo = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "OidModulo");
            string oid_submodulo = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "OidSubmodulo");
            string c_oid_tema = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "OidTema");
            string h = nHManager.Instance.GetSQLTable(typeof(HistoriaRecord));

            string query;

            string esquema = Convert.ToInt32(AppContext.ActiveSchema.Code).ToString("0000");

            //query = "SELECT * " +
            //        "FROM \"" + esquema + "\".\"" + pregunta + "\" " +
            //        "WHERE 1=1 ";
            query = "SELECT p.*, m.\"TEXTO\" AS \"MODULO\", s.\"TEXTO\" AS \"SUBMODULO\", t.\"CODIGO\" AS \"TEMA\", " +
                    "m.\"NUMERO_MODULO\", s.\"CODIGO\", t.\"CODIGO_ORDEN\" AS \"ORDEN\",  " +
                    "COALESCE(\"LAST_UPDATE\",  p.\"FECHA_ALTA\") AS \"FECHA_MODIFICACION\" " +
                    "FROM \"" + esquema + "\".\"" + pregunta + "\" AS p " +
                    "INNER JOIN \"" + esquema + "\".\"" + modulo + "\" AS m ON (p.\"" + c_oid_modulo + "\" = m.\"OID\") " +
                    "INNER JOIN \"" + esquema + "\".\"" + submodulo + "\" AS s ON (p.\"" + oid_submodulo + "\" = s.\"OID\") " +
                    "INNER JOIN \"" + esquema + "\".\"" + tema + "\" AS t ON (p.\"" + c_oid_tema + "\" = t.\"OID\") " +
                    "LEFT JOIN ( SELECT MAX(H.\"FECHA\") AS \"LAST_UPDATE\", H.\"OID_PREGUNTA\" FROM " + h + " AS H GROUP BY H.\"OID_PREGUNTA\") AS H ON H.\"OID_PREGUNTA\" = p.\"OID\"" +
                    "WHERE 1=1 ";

            if (oid_modulo != 0)
                query += "AND p.\"OID_MODULO\" = " + oid_modulo.ToString() + " ";

            if (oid_tema != 0)
                query += "AND p.\"OID_TEMA\" = " + oid_tema.ToString() + " ";

            if (nivel != 0)
                query += "AND p.\"NIVEL\" = " + nivel.ToString() + " ";

            if (tipo != string.Empty)
                query += "AND p.\"TIPO\" = '" + tipo + "' ";

            if (idioma != string.Empty)
                query += "AND p.\"IDIOMA\" = '" + idioma + "' ";

            if (fecha_alta != DateTime.MinValue)
                query += "AND p.\"FECHA_ALTA\" = " + fecha + " ";

            if (fecha_disponibilidad != DateTime.MinValue)
                query += "AND p.\"FECHA_DISPONIBILIDAD\" <= " + fecha_d + " ";

            if (filtros)
            {
                if (activa)
                    query += "AND p.\"ACTIVA\" = true ";
                else
                    query += "AND p.\"ACTIVA\" = false ";

                if (revisada)
                    query += "AND p.\"REVISADA\" = true ";
                else
                    query += "AND p.\"REVISADA\" = false ";

                if (reservada)
                    query += "AND p.\"BLOQUEADA\" = true ";
                else
                    query += "AND p.\"BLOQUEADA\" = false ";

                if (fecha_disponibilidad.Date.Equals(DateTime.MinValue.Date))
                    query += "AND p.\"FECHA_DISPONIBILIDAD\" > " + fecha_actual + " ";
            }

            if (texto != string.Empty)
                query += "AND p.\"TEXTO\" ILIKE '%" + texto + "%' "; 
            
            if (numero != 0)
                query += "AND p.\"SERIAL\" = " + numero.ToString() + " ";

            query += "ORDER BY \"ORDEN\", \"SERIAL\"";

            return query;
        }


        public static string SELECT_BY_FIELD(string field, long value)
        {
            string search_field = nHManager.Instance.GetTableField(typeof(PreguntaRecord), field);

            string query = Pregunta.SELECT(0, false, " AND P.\"" + search_field + "\" = " + value.ToString() + " ORDER BY \"ORDEN\", P.\"NIVEL\", P.\"TIPO\", P.\"SERIAL\"");
            
            return query;
        }

        public static string SELECT_BY_MODULO(long oid_modulo)
        {
            string subquery = string.Empty;

            if (oid_modulo > 0) subquery += " AND P.\"OID_MODULO\" = " + oid_modulo.ToString();

            subquery += " ORDER BY \"ORDEN\", P.\"NIVEL\", P.\"TIPO\", P.\"SERIAL\"";

            string query = Pregunta.SELECT(0, false, subquery);

            return query;
        }

        public static string SELECT_BY_TEMA(long oid_tema)
        {
            string subquery = string.Empty;

            if (oid_tema > 0) subquery += " AND P.\"OID_TEMA\" = " + oid_tema.ToString();

            subquery += " ORDER BY \"ORDEN\", P.\"NIVEL\", P.\"TIPO\", P.\"SERIAL\"";

            string query = Pregunta.SELECT(0, false, subquery);

            return query;
        }

        public static string SELECT_DISPONIBLES_BY_TEMA(long oid_tema, bool desarrollo, DateTime fecha_examen, long limit = 0)
        {
            string subquery = string.Empty;

            if (oid_tema > 0) subquery += " AND P.\"OID_TEMA\" = " + oid_tema.ToString()
                                        + " AND P.\"ACTIVA\" = 'true' AND P.\"RESERVADA\" = 'false'"
                                        + " AND P.\"FECHA_DISPONIBILIDAD\" <= '" + fecha_examen.ToString("yyyy-MM-dd") + "'";

            if (desarrollo)
                subquery += " AND P.\"TIPO\" = 'Desarrollo'";
            else
                subquery += " AND P.\"TIPO\" = 'Test'";

            subquery += " ORDER BY RANDOM()";
            if (limit > 0) subquery += " LIMIT " + limit.ToString();

            string query = Pregunta.SELECT(0, false, subquery);

            return query;
        }

        public static string SELECT_DISPONIBLES_BY_MODULO(long oid_modulo, bool desarrollo, DateTime fecha_examen, long limit = 0)
        {
            string subquery = string.Empty;

            if (oid_modulo > 0) subquery += " AND P.\"OID_MODULO\" = " + oid_modulo.ToString() 
                                        + " AND P.\"ACTIVA\" = 'true' AND P.\"RESERVADA\" = 'false'"
                                        + " AND P.\"FECHA_DISPONIBILIDAD\" <= '" + fecha_examen.ToString("yyyy-MM-dd") + "'";

            if (desarrollo)
                subquery += " AND P.\"TIPO\" = 'Desarrollo'";
            else
                subquery += " AND P.\"TIPO\" = 'Test'";

            subquery += " ORDER BY RANDOM()";
            if (limit > 0) subquery += " LIMIT " + limit.ToString();

            string query = Pregunta.SELECT(0, false, subquery);

            return query;
        }

        public static string SELECT_BY_TEMA_DUPLICADAS(long oid_tema)
        {
            string subquery = string.Empty;

            if (oid_tema > 0) subquery += " AND P.\"SERIAL\" = 0 AND P.\"OID_TEMA\" = " + oid_tema.ToString();

            subquery += " ORDER BY \"ORDEN\", P.\"NIVEL\", P.\"TIPO\", P.\"SERIAL\"";

            string query = Pregunta.SELECT(0, false, subquery);

            return query;
        }

        public static string SELECT_BY_MODULO_LIST(long oid, string lista_preguntas)
        {
            string pregunta = nHManager.Instance.Cfg.GetClassMapping(typeof(PreguntaRecord)).Table.Name;
            string modulo = nHManager.Instance.Cfg.GetClassMapping(typeof(ModuloRecord)).Table.Name;
            string submodulo = nHManager.Instance.Cfg.GetClassMapping(typeof(SubmoduloRecord)).Table.Name;
            string tema = nHManager.Instance.Cfg.GetClassMapping(typeof(TemaRecord)).Table.Name;
            string oid_modulo = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "OidModulo");
            string oid_submodulo = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "OidSubmodulo");
            string oid_tema = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "OidTema");
            string h = nHManager.Instance.GetSQLTable(typeof(HistoriaRecord));

            string query;

            string esquema = Convert.ToInt32(AppContext.ActiveSchema.Code).ToString("0000");

            query = "SELECT " + //'false' AS \"RESERVADA\", 
                    "       p.*, m.\"TEXTO\" AS \"MODULO\"," +
                    "       s.\"TEXTO\" AS \"SUBMODULO\", s.\"CODIGO\"," +
                    "       t.\"CODIGO\" AS \"TEMA\"," +
                    "       m.\"NUMERO_MODULO\", t.\"CODIGO_ORDEN\" AS \"ORDEN\",  " +
                    "COALESCE(\"LAST_UPDATE\",  p.\"FECHA_ALTA\") AS \"FECHA_MODIFICACION\" " +
                    "FROM \"" + esquema + "\".\"" + pregunta + "\" AS p " +
                    "INNER JOIN \"" + esquema + "\".\"" + modulo + "\" AS m ON (p.\"" + oid_modulo + "\" = m.\"OID\") " +
                    "INNER JOIN \"" + esquema + "\".\"" + submodulo + "\" AS s ON (p.\"" + oid_submodulo + "\" = s.\"OID\") " +
                    "INNER JOIN \"" + esquema + "\".\"" + tema + "\" AS t ON (p.\"" + oid_tema + "\" = t.\"OID\") " +
                    "LEFT JOIN ( SELECT MAX(H.\"FECHA\") AS \"LAST_UPDATE\", H.\"OID_PREGUNTA\" FROM " + h + " AS H GROUP BY H.\"OID_PREGUNTA\") AS H ON H.\"OID_PREGUNTA\" = p.\"OID\"" +
                    //"WHERE p.\"OID\" IN (" + lista_preguntas + ") AND p.\"OID_MODULO\" = " + oid.ToString() + " " +
                    //"UNION " +
                    //"SELECT " + //\"RESERVADA\" AS \"RESERVADA\", 
                    //"p.*, m.\"TEXTO\" AS \"MODULO\", s.\"TEXTO\" AS \"SUBMODULO\", t.\"CODIGO\" AS \"TEMA\", " +
                    //"m.\"NUMERO_MODULO\", s.\"CODIGO\", t.\"CODIGO_ORDEN\" AS \"ORDEN\" " +
                    //"FROM \"" + esquema + "\".\"" + pregunta + "\" AS p " +
                    //"INNER JOIN \"" + esquema + "\".\"" + modulo + "\" AS m ON (p.\"" + oid_modulo + "\" = m.\"OID\") " +
                    //"INNER JOIN \"" + esquema + "\".\"" + submodulo + "\" AS s ON (p.\"" + oid_submodulo + "\" = s.\"OID\") " +
                    //"INNER JOIN \"" + esquema + "\".\"" + tema + "\" AS t ON (p.\"" + oid_tema + "\" = t.\"OID\") " +
                    //"WHERE p.\"OID\" NOT IN (" + lista_preguntas + ") AND p.\"OID_MODULO\" = " + oid.ToString() + " " +
                    "WHERE p.\"OID_MODULO\" = " + oid.ToString() + " " +
                    "ORDER BY \"ORDEN\", \"SERIAL\"";

            return query;
        }

        public static string SELECT_LISTADO_ORDENADO(string lista_preguntas)
        {
            string pregunta = nHManager.Instance.Cfg.GetClassMapping(typeof(PreguntaRecord)).Table.Name;
            string modulo = nHManager.Instance.Cfg.GetClassMapping(typeof(ModuloRecord)).Table.Name;
            string submodulo = nHManager.Instance.Cfg.GetClassMapping(typeof(SubmoduloRecord)).Table.Name;
            string tema = nHManager.Instance.Cfg.GetClassMapping(typeof(TemaRecord)).Table.Name;
            string oid_modulo = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "OidModulo");
            string oid_submodulo = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "OidSubmodulo");
            string oid_tema = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "OidTema");
            string h = nHManager.Instance.GetSQLTable(typeof(HistoriaRecord));

            string query;

            string esquema = Convert.ToInt32(AppContext.ActiveSchema.Code).ToString("0000");

            query = "SELECT " + 
                    "       p.*, (m.\"NUMERO\" || ' ' || m.\"TEXTO\") AS \"MODULO\"," +
                    "       (s.\"CODIGO\" || ' ' || s.\"TEXTO\") AS \"SUBMODULO\", s.\"CODIGO\"," +
                    "       (t.\"CODIGO\" || ' ' || t.\"NOMBRE\") AS \"TEMA\"," +
                    "       m.\"NUMERO_MODULO\", t.\"CODIGO_ORDEN\" AS \"ORDEN\",  " +
                    "COALESCE(\"LAST_UPDATE\",  p.\"FECHA_ALTA\") AS \"FECHA_MODIFICACION\" " +
                    "FROM \"" + esquema + "\".\"" + pregunta + "\" AS p " +
                    "INNER JOIN \"" + esquema + "\".\"" + modulo + "\" AS m ON (p.\"" + oid_modulo + "\" = m.\"OID\") " +
                    "INNER JOIN \"" + esquema + "\".\"" + submodulo + "\" AS s ON (p.\"" + oid_submodulo + "\" = s.\"OID\") " +
                    "INNER JOIN \"" + esquema + "\".\"" + tema + "\" AS t ON (p.\"" + oid_tema + "\" = t.\"OID\") " +
                    "LEFT JOIN ( SELECT MAX(H.\"FECHA\") AS \"LAST_UPDATE\", H.\"OID_PREGUNTA\" FROM " + h + " AS H GROUP BY H.\"OID_PREGUNTA\") AS H ON H.\"OID_PREGUNTA\" = p.\"OID\"" +
                    "WHERE p.\"OID\" = IN " + lista_preguntas + " " +
                    "ORDER BY m.\"NUMERO_ORDEN\", s.\"CODIGO_ORDEN\", t.\"NIVEL\"";

            return query;
        }

        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public static string SELECT_BY_LIST(string lista_preguntas)
        {
            string pregunta = nHManager.Instance.Cfg.GetClassMapping(typeof(PreguntaRecord)).Table.Name;
            string modulo = nHManager.Instance.Cfg.GetClassMapping(typeof(ModuloRecord)).Table.Name;
            string submodulo = nHManager.Instance.Cfg.GetClassMapping(typeof(SubmoduloRecord)).Table.Name;
            string tema = nHManager.Instance.Cfg.GetClassMapping(typeof(TemaRecord)).Table.Name;
            string oid_modulo = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "OidModulo");
            string oid_submodulo = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "OidSubmodulo");
            string oid_tema = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "OidTema");
            string h = nHManager.Instance.GetSQLTable(typeof(HistoriaRecord));

            string query;

            string esquema = Convert.ToInt32(AppContext.ActiveSchema.Code).ToString("0000");

            query = "SELECT p.*, m.\"TEXTO\" AS \"MODULO\", s.\"TEXTO\" AS \"SUBMODULO\", t.\"CODIGO\" AS \"TEMA\", " +
                    "m.\"NUMERO_MODULO\", s.\"CODIGO\", t.\"CODIGO_ORDEN\" AS \"ORDEN\",  " +
                    "COALESCE(\"LAST_UPDATE\",  p.\"FECHA_ALTA\") AS \"FECHA_MODIFICACION\" " +
                    "FROM \"" + esquema + "\".\"" + pregunta + "\" AS p " +
                    "INNER JOIN \"" + esquema + "\".\"" + modulo + "\" AS m ON (p.\"" + oid_modulo + "\" = m.\"OID\") " +
                    "INNER JOIN \"" + esquema + "\".\"" + submodulo + "\" AS s ON (p.\"" + oid_submodulo + "\" = s.\"OID\") " +
                    "INNER JOIN \"" + esquema + "\".\"" + tema + "\" AS t ON (p.\"" + oid_tema + "\" = t.\"OID\") " +
                    "LEFT JOIN ( SELECT MAX(H.\"FECHA\") AS \"LAST_UPDATE\", H.\"OID_PREGUNTA\" FROM " + h + " AS H GROUP BY H.\"OID_PREGUNTA\") AS H ON H.\"OID_PREGUNTA\" = p.\"OID\"" +
                    "WHERE p.\"OID\" IN (" + lista_preguntas + ")";

            return query;
        }

        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public static string SELECT_LISTADO_EXAMEN_NO_EMITIDO(string lista_preguntas)
        {

            string pregunta = nHManager.Instance.Cfg.GetClassMapping(typeof(PreguntaRecord)).Table.Name;
            string modulo = nHManager.Instance.Cfg.GetClassMapping(typeof(ModuloRecord)).Table.Name;
            string submodulo = nHManager.Instance.Cfg.GetClassMapping(typeof(SubmoduloRecord)).Table.Name;
            string tema = nHManager.Instance.Cfg.GetClassMapping(typeof(TemaRecord)).Table.Name;
            string oid_modulo = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "OidModulo");
            string oid_submodulo = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "OidSubmodulo");
            string oid_tema = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "OidTema");
            string h = nHManager.Instance.GetSQLTable(typeof(HistoriaRecord));

            string query;

            string esquema = Convert.ToInt32(AppContext.ActiveSchema.Code).ToString("0000");

            query = "SELECT p.*, m.\"TEXTO\" AS \"MODULO\", s.\"TEXTO\" AS \"SUBMODULO\", t.\"CODIGO\" AS \"TEMA\", " +
                    "m.\"NUMERO_MODULO\", s.\"CODIGO\", t.\"CODIGO_ORDEN\" AS \"ORDEN\",  " +
                    "COALESCE(\"LAST_UPDATE\",  p.\"FECHA_ALTA\") AS \"FECHA_MODIFICACION\" " +
                    "FROM \"" + esquema + "\".\"" + pregunta + "\" AS p " +
                    "INNER JOIN \"" + esquema + "\".\"" + modulo + "\" AS m ON (p.\"" + oid_modulo + "\" = m.\"OID\") " +
                    "INNER JOIN \"" + esquema + "\".\"" + submodulo + "\" AS s ON (p.\"" + oid_submodulo + "\" = s.\"OID\") " +
                    "INNER JOIN \"" + esquema + "\".\"" + tema + "\" AS t ON (p.\"" + oid_tema + "\" = t.\"OID\") " +
                    "LEFT JOIN ( SELECT MAX(H.\"FECHA\") AS \"LAST_UPDATE\", H.\"OID_PREGUNTA\" FROM " + h + " AS H GROUP BY H.\"OID_PREGUNTA\") AS H ON H.\"OID_PREGUNTA\" = p.\"OID\"" +
                    "WHERE p.\"OID\" IN (" + lista_preguntas + ") " +
                    "ORDER BY  \"ORDEN\", p.\"SERIAL\"";

            return query;
        }

        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public static string SELECT_LISTADO_EXAMEN_EMITIDO(long oid_examen)
        {

            string pregunta = nHManager.Instance.Cfg.GetClassMapping(typeof(PreguntaRecord)).Table.Name;
            string modulo = nHManager.Instance.Cfg.GetClassMapping(typeof(ModuloRecord)).Table.Name;
            string submodulo = nHManager.Instance.Cfg.GetClassMapping(typeof(SubmoduloRecord)).Table.Name;
            string tema = nHManager.Instance.Cfg.GetClassMapping(typeof(TemaRecord)).Table.Name;
            string pregunta_examen = nHManager.Instance.Cfg.GetClassMapping(typeof(PreguntaExamenRecord)).Table.Name;
            string oid_modulo = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "OidModulo");
            string oid_submodulo = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "OidSubmodulo");
            string oid_tema = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "OidTema");
            string c_oid_examen = nHManager.Instance.GetTableField(typeof(PreguntaExamenRecord), "OidExamen");
            string oid_pregunta = nHManager.Instance.GetTableField(typeof(PreguntaExamenRecord), "OidPregunta");
            string h = nHManager.Instance.GetSQLTable(typeof(HistoriaRecord));

            string query;

            string esquema = Convert.ToInt32(AppContext.ActiveSchema.Code).ToString("0000");

            query = "SELECT p.*, m.\"TEXTO\" AS \"MODULO\", s.\"TEXTO\" AS \"SUBMODULO\", t.\"CODIGO\" AS \"TEMA\", " +
                    "m.\"NUMERO_MODULO\", s.\"CODIGO\", t.\"CODIGO_ORDEN\" AS \"ORDEN\",  " +
                    "COALESCE(\"LAST_UPDATE\", p.\"FECHA_ALTA\") AS \"FECHA_MODIFICACION\" " +
                    "FROM \"" + esquema + "\".\"" + pregunta + "\" AS p " +
                    "INNER JOIN \"" + esquema + "\".\"" + pregunta_examen + "\" AS pe ON (pe.\"" + oid_pregunta + "\" = p.\"OID\") " +
                    "INNER JOIN \"" + esquema + "\".\"" + modulo + "\" AS m ON (p.\"" + oid_modulo + "\" = m.\"OID\") " +
                    "INNER JOIN \"" + esquema + "\".\"" + submodulo + "\" AS s ON (p.\"" + oid_submodulo + "\" = s.\"OID\") " +
                    "INNER JOIN \"" + esquema + "\".\"" + tema + "\" AS t ON (p.\"" + oid_tema + "\" = t.\"OID\") " +
                    "LEFT JOIN ( SELECT MAX(H.\"FECHA\") AS \"LAST_UPDATE\", H.\"OID_PREGUNTA\" FROM " + h + " AS H GROUP BY H.\"OID_PREGUNTA\") AS H ON H.\"OID_PREGUNTA\" = p.\"OID\"" +
                    "WHERE pe.\"" + c_oid_examen + "\" = " + oid_examen.ToString() + " " +
                    "ORDER BY \"ORDEN\", p.\"SERIAL\"";

            return query;
        }

        #endregion

    }
}

