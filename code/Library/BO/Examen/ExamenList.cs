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
    public class ExamenList : ReadOnlyListBaseEx<ExamenList, ExamenInfo>
    {

        #region Child Factory Methods

        private ExamenList() { }

        public static ExamenList NewList() { return new ExamenList(); }


        private ExamenList(IList<Examen> lista)
        {
            Fetch(lista);
        }

        private ExamenList(IDataReader reader, bool childs)
        {
            Fetch(reader, childs);
        }

        private ExamenList(IDataReader reader)
        {
            Fetch(reader, true);
        }

        /// <summary>
        /// Builds a ExamenList from a IList<!--<ExamenInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>ExamenList</returns>
        public static ExamenList GetChildList(IList<ExamenInfo> list)
        {
            ExamenList flist = new ExamenList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (ExamenInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }


        /// <summary>
        /// Builds a ExamenList from IList<!--<Examen>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>ExamenList</returns>
        public static ExamenList GetChildList(IList<Examen> list) { return new ExamenList(list); }

        public static ExamenList GetChildList(IDataReader reader, bool childs) { return new ExamenList(reader, childs); }

        public static ExamenList GetChildList(IDataReader reader) { return ExamenList.GetChildList(reader, true); }

        #endregion

        #region Root Factory Methods

        //  private ExamenList() { }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>ExamenList</returns>
        public static ExamenList GetList(bool childs)
        {
            CriteriaEx criteria = Examen.GetCriteria(Examen.OpenSession());
            criteria.Childs = childs;

            //No criteria. Retrieve all de List
            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = ExamenList.SELECT();
                        
            ExamenList list = DataPortal.Fetch<ExamenList>(criteria);
            CloseSession(criteria.SessionCode);

            return list;
        }


        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>ExamenList</returns>
        private static ExamenList GetFechaList(DateTime fecha_examen)
        {
            CriteriaEx criteria = Examen.GetCriteria(Examen.OpenSession());

            //No criteria. Retrieve all de List
            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = Examens.SELECT_BY_FECHA(fecha_examen);
            criteria.Childs = true;
            ExamenList list = DataPortal.Fetch<ExamenList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        public static List<long> GetPreguntasReservadas(Examen item)
        {
            ExamenList examenes = GetFechaList(item.FechaExamen);
            List<long> list = new List<long>(); 

            foreach (ExamenInfo info in examenes)
            {
                if (info.Oid != item.Oid)
                {
                    if (info.MemoPreguntas != string.Empty)
                    {
                        string[] lista = info.MemoPreguntas.Split(';');
                        foreach (string serial in lista)
                        {
                            if (serial != string.Empty)
                                list.Add(Convert.ToInt32(serial));
                        }
                    }
                    else
                    {
                        foreach (PreguntaExamenInfo pregunta in info.PreguntaExamenes)
                            list.Add(pregunta.OidPregunta);
                    }
                }
            }

            return list;
        }


        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>ExamenList</returns>
        public static ExamenList GetList()
        {
            return GetList(true);
        }


        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>ExamenList</returns>
        public static ExamenList GetEmitidosList()
        {
            ExamenList lista = GetList(false);
            ExamenList lista_emitidos = new ExamenList();

            foreach (ExamenInfo item in lista)
            {
                if (!item.FechaEmision.Date.Equals(DateTime.MaxValue.Date))
                    lista_emitidos.AddItem(item);
            }

            return lista_emitidos;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>ExamenList</returns>
        public static ExamenList GetComboAlumno_ExamenList(long oid_promocion)
        {
            CriteriaEx criteria = Examen.GetCriteria(Examen.OpenSession());

            //No criteria. Retrieve all de List
            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = Examens.SELECT_EXAMENES_PENDIENTES(oid_promocion);
            ExamenList list = DataPortal.Fetch<ExamenList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static ExamenList GetList(CriteriaEx criteria)
        {
            return ExamenList.RetrieveList(typeof(Examen), AppContext.ActiveSchema.Code, criteria);
        }

        /// <summary>
        /// Builds a ExamenList from a IList<!--<ExamenInfo>-->
        /// Doesn`t retrieve child data from DB.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>ExamenList</returns>
        public static ExamenList GetList(IList<ExamenInfo> list)
        {
            ExamenList flist = new ExamenList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (ExamenInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a ExamenList from a IList<!--<Examen>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Examen</returns>
        public static ExamenList GetList(IList<Examen> list)
        {
            ExamenList flist = new ExamenList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (Examen item in list)
                    flist.AddItem(item.GetInfo());

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Devuelve una lista ordenada de todos los elementos
        /// </summary>
        /// <param name="sortProperty">Campo de ordenación</param>
        /// <param name="sortDirection">Sentido de ordenación</param>
        /// <returns>Lista ordenada de elementos</returns>
        public static SortedBindingList<ExamenInfo> GetSortedList(string sortProperty,
                                                                    ListSortDirection sortDirection)
        {
            SortedBindingList<ExamenInfo> sortedList =
                new SortedBindingList<ExamenInfo>(GetList(false));
            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static ExamenList GetModuloList(long oid_modulo)
        {
            CriteriaEx criteria = Examen.GetCriteria(Examen.OpenSession());
            criteria.AddEq("OidModulo", oid_modulo);
            ExamenList list = ExamenList.RetrieveList(typeof(Examen), AppContext.ActiveSchema.Code, criteria);
            CloseSession(criteria.SessionCode);
            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>RespuestaList</returns>
        public void FormatCodigoList()
        {
            foreach (ExamenInfo item in this)
            {
                if (item.Numero == 0)
                {
                    string query = UPDATE_CODIGO(item.Oid);
                    CriteriaEx criteria = Examen.GetCriteria(Examen.OpenSession());
                    nHManager.Instance.SQLNativeExecute(query, Session());
                    CloseSession(criteria.SessionCode);
                }
            }
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Examen> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (Examen item in lista)
                this.AddItem(item.GetInfo());

            IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }

        // called to copy objects data from list
        private void Fetch(IDataReader reader) { Fetch(reader, true); }

        // called to copy objects data from list
        private void Fetch(IDataReader reader, bool childs)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            while (reader.Read())
                this.AddItem(ExamenInfo.GetChild(reader, childs));

            IsReadOnly = true;

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

                    //Examen.DoLOCK( Session());
                    IDataReader reader = null;

                    reader = nHMng.SQLNativeSelect(criteria.Query);

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(ExamenInfo.GetChild(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList<Examen> list = criteria.List<Examen>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (Examen item in list)
                            this.AddItem(item.GetInfo());

                        IsReadOnly = true;
                    }
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
                    IsReadOnly = false;

                    foreach (Examen item in list)
                        this.AddItem(item.GetInfo());

                    IsReadOnly = true;
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
        public ExamenList GetExamenesFiltrados(long oid_modulo, long oid_instructor, long oid_promocion,
                                                    string tipo, DateTime fecha_creacion, DateTime fecha_emision,
                                                    DateTime fecha_examen, bool desarrollo, bool filtro, string texto)
        {
            ExamenList lista = new ExamenList();
            string query = ExamenList.SELECT_EXAMENES_FILTRADOS(oid_modulo, oid_instructor, oid_promocion, tipo,
                                                                fecha_creacion, fecha_examen, fecha_emision, desarrollo, filtro, texto);
            int sesion = Examen.OpenSession();

            IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(sesion));

            lista = ExamenList.GetChildList(reader, false);

            CloseSession(sesion);

            return lista;
        }

        #endregion

        #region SQL

        public static string SELECT() { return ExamenInfo.SELECT(0); }

        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public static string SELECT_EXAMENES_FILTRADOS(long oid_modulo, long oid_instructor, long oid_promocion,
                                                        string tipo, DateTime fecha_creacion, DateTime fecha_examen,
                                                        DateTime fecha_emision, bool desarrollo, bool filtro, string texto)
        {
            string fecha_c = string.Empty;
            fecha_c = "'" + fecha_creacion.Year.ToString() + "-" + fecha_creacion.Month.ToString() + "-" + fecha_creacion.Day.ToString() + "'";
            string fecha_ex = string.Empty;
            fecha_ex = "'" + fecha_examen.Year.ToString() + "-" + fecha_examen.Month.ToString() + "-" + fecha_examen.Day.ToString() + "'";
            string fecha_em = string.Empty;
            fecha_em = "'" + fecha_emision.Year.ToString() + "-" + fecha_emision.Month.ToString() + "-" + fecha_emision.Day.ToString() + "'";
            
            string query = ExamenInfo.SELECT(0);

            query += " WHERE 1=1 ";

            if (oid_modulo != 0)
                query += " AND \"OID_MODULO\" = " + oid_modulo.ToString();

            if (oid_promocion != 0)
                query += " AND \"OID_PROMOCION\" = " + oid_promocion.ToString();

            if (oid_instructor != 0)
                query += " AND \"OID_PROFESOR\" = " + oid_instructor.ToString();

            if (tipo != string.Empty)
                query += " AND \"TIPO\" = '" + tipo + "'";

            if (fecha_creacion != DateTime.MaxValue)
                query += " AND \"FECHA_CREACION\" = " + fecha_c;

            if (fecha_examen != DateTime.MaxValue)
                query += " AND \"FECHA_EXAMEN\" = " + fecha_ex;

            if (filtro)
            {
                if (fecha_emision != DateTime.MaxValue)
                    query += " AND \"FECHA_EMISION\" <= " + fecha_em;
                if (desarrollo)
                    query += " AND \"DESARROLLO\" = true ";
                else
                    query += " AND \"DESARROLLO\" = false ";
            }

            if (texto != string.Empty)
                query += " AND \"TITULO\" ILIKE '%" + texto + "%' ";

            return query;
        }

        private static string UPDATE_CODIGO(long oid)
        {
            string examen = nHManager.Instance.Cfg.GetClassMapping(typeof(ExamenRecord)).Table.Name;
            string numero = nHManager.Instance.GetTableField(typeof(ExamenRecord), "Numero");

            string query;

            string esquema = Convert.ToInt32(AppContext.ActiveSchema.Code).ToString("0000");

            query = "UPDATE " + "\"" + esquema + "\".\"" + examen + "\" " +
                    "SET \"" + numero + "\" = " + oid.ToString() + " " +
                    "WHERE \"OID\" = " + oid.ToString() + ";";

            return query;
        }

        #endregion

    }
}

