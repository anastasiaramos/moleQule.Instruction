using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;

namespace moleQule.Library.Instruction
{
    /// <summary>
    /// ReadOnly Root Collection of Business Objects With Child Collection
    /// </summary>
    [Serializable()]
    public class RespuestaList : ReadOnlyListBaseEx<RespuestaList, RespuestaInfo>
    {

        #region Factory Methods

        public RespuestaList() { }

        private RespuestaList(IList<Respuesta> lista)
        {
            Fetch(lista);
        }

        private RespuestaList(IDataReader reader)
        {
            Fetch(reader);
        }

        /// <summary>
        /// Builds a RespuestaList from a IList<!--<RespuestaInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>RespuestaList</returns>
        public static RespuestaList GetChildList(IList<RespuestaInfo> list)
        {
            RespuestaList flist = new RespuestaList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (RespuestaInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }


        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>PreguntaList</returns>
        public static RespuestaList GetList()
        {
            CriteriaEx criteria = Respuesta.GetCriteria(Respuesta.OpenSession());
            criteria.Childs = false;
            criteria.Query = Respuestas.SELECT();
            //No criteria. Retrieve all de List
            RespuestaList list = DataPortal.Fetch<RespuestaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>PreguntaList</returns>
        public static RespuestaList GetModuloList(long oid_modulo)
        {
            CriteriaEx criteria = Respuesta.GetCriteria(Respuesta.OpenSession());
            criteria.Childs = false;
            criteria.Query = Respuestas.SELECT_BY_MODULO(AppContext.ActiveSchema.Code, oid_modulo);
            //No criteria. Retrieve all de List
            RespuestaList list = DataPortal.Fetch<RespuestaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }


        public static RespuestaList GetRespuestasExamenList(string lista_preguntas)
        {
            CriteriaEx criteria = Respuesta.GetCriteria(Respuesta.OpenSession());

            Respuesta.BeginTransaction(criteria.SessionCode);
            criteria.Query = Respuestas.SELECT_BY_LIST(lista_preguntas);
            criteria.Childs = false;

            //No criteria. Retrieve all de List
            RespuestaList list = DataPortal.Fetch<RespuestaList>(criteria);
            CloseSession(criteria.SessionCode);
            return list;
        }

        /// <summary>
        /// Builds a RespuestaList from IList<!--<Respuesta>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>RespuestaList</returns>
        public static RespuestaList GetChildList(IList<Respuesta> list) { return new RespuestaList(list); }

        public static RespuestaList GetChildList(IDataReader reader) { return new RespuestaList(reader); }

        public static RespuestaList GetChildList(RespuestaExamenList lista)
        {
            RespuestaList list = new RespuestaList();

            foreach (RespuestaExamenInfo item in lista)
                list.AddItem(new RespuestaInfo(item));

            return list;
        }

        /// <summary>
        /// Devuelve una lista ordenada de todos los elementos
        /// </summary>
        /// <param name="sortProperty">Campo de ordenación</param>
        /// <param name="sortDirection">Sentido de ordenación</param>
        /// <returns>Lista ordenada de elementos</returns>
        public static SortedBindingList<RespuestaInfo> GetSortedList(string sortProperty,
                                                                    ListSortDirection sortDirection)
        {
            SortedBindingList<RespuestaInfo> sortedList =
                new SortedBindingList<RespuestaInfo>(GetList());
            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }


        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>RespuestaList</returns>
        public void FormatCodigoList()
        {
            foreach (RespuestaInfo item in this)
            {
                if (item.OidOld != 0 && item.Codigo == string.Empty )
                {
                    string query = UPDATE_CODIGO(item.Oid, item.OidOld, item.OidOld.ToString("000000"));
                    CriteriaEx criteria = Respuesta.GetCriteria(Respuesta.OpenSession());
                    nHManager.Instance.SQLNativeExecute(query, Session());
                    CloseSession(criteria.SessionCode);
                }
            }

            long serial = Respuesta.GetNewSerial(null);
            foreach (RespuestaInfo item in this)
            {
                if (item.OidOld == 0 && item.Codigo == string.Empty)
                {
                    string query = UPDATE_CODIGO(item.Oid, serial, serial.ToString("000000"));
                    CriteriaEx criteria = Respuesta.GetCriteria(Respuesta.OpenSession());
                    nHManager.Instance.SQLNativeExecute(query, Session());
                    CloseSession(criteria.SessionCode);
                    serial++;
                }
            }
        }

        #endregion

        #region Data Access

        // called to copy objects data from list
        private void Fetch(IList<Respuesta> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (Respuesta item in lista)
                this.AddItem(item.GetInfo());

            IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }


        // called to copy objects data from list
        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            while (reader.Read())
                this.AddItem(Respuesta.GetChild(reader).GetInfo());

            IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }

        // called to retrieve data from db
        protected override void Fetch(CriteriaEx criteria)
        {
            this.RaiseListChangedEvents = false;

            SessionCode = criteria.SessionCode;
            Childs = criteria.Childs;

            try
            {
                if (nHMng.UseDirectSQL)
                {
                    IDataReader reader = null;
                    
                    reader = nHMng.SQLNativeSelect(criteria.Query);

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(RespuestaInfo.Get(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList<Respuesta> list = criteria.List<Respuesta>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (Respuesta item in list)
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

        #region SQL

        internal static string SELECT_BY_PREGUNTA(long oid_pregunta)
        {
            return Respuestas.SELECT_BY_PREGUNTA(oid_pregunta, false);
        }

        private static string UPDATE_CODIGO(long oid, long serial, string codigo)
        {
            string respuesta = nHManager.Instance.GetSQLTable(typeof(RespuestaRecord));
            string c_serial = nHManager.Instance.GetTableField(typeof(RespuestaRecord), "Serial");
            string c_codigo = nHManager.Instance.GetTableField(typeof(RespuestaRecord), "Codigo");

            string query;

            query = "UPDATE " + respuesta + " " +
                    "SET \"" + c_codigo + "\" = '" + codigo + "', " +
                    "\"" + c_serial + "\" = " + serial.ToString() + " " +
                    "WHERE \"OID\" = " + oid.ToString() + ";";

            return query;
        }

        #endregion

    }
}

