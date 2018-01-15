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
    public class PlantillaExamenList : ReadOnlyListBaseEx<PlantillaExamenList, PlantillaExamenInfo>
    {

        #region Child Factory Methods

        private PlantillaExamenList() { }

        public static PlantillaExamenList NewList() { return new PlantillaExamenList(); }

        private PlantillaExamenList(IList<PlantillaExamen> lista)
        {
            Fetch(lista);
        }

        private PlantillaExamenList(IDataReader reader)
        {
            Fetch(reader);
        }

        /// <summary>
        /// Builds a PlantillaExamenList from a IList<!--<PlantillaExamenInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>PlantillaExamenList</returns>
        public static PlantillaExamenList GetChildList(IList<PlantillaExamenInfo> list)
        {
            PlantillaExamenList flist = new PlantillaExamenList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (PlantillaExamenInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }


        /// <summary>
        /// Builds a PlantillaExamenList from IList<!--<PlantillaExamen>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>PlantillaExamenList</returns>
        public static PlantillaExamenList GetChildList(IList<PlantillaExamen> list) { return new PlantillaExamenList(list); }

        public static PlantillaExamenList GetChildList(IDataReader reader) { return new PlantillaExamenList(reader); }

        #endregion

        #region Root Factory Methods

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>PlantillaExamenList</returns>
        public static PlantillaExamenList GetList(bool childs)
        {
            CriteriaEx criteria = PlantillaExamen.GetCriteria(PlantillaExamenList.OpenSession());
            criteria.Childs = childs;
            criteria.Query = SELECT();

            PlantillaExamenList list = DataPortal.Fetch<PlantillaExamenList>(criteria);
            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>PlantillaExamenList</returns>
        public static PlantillaExamenList GetListByModulo(long oid_modulo, bool desarrollo)
        {
            CriteriaEx criteria = PlantillaExamen.GetCriteria(PlantillaExamen.OpenSession());
            criteria.Childs = false;

            criteria.Query = PlantillaExamenList.SELECT_BY_MODULO(oid_modulo, desarrollo);

            PlantillaExamenList list = DataPortal.Fetch<PlantillaExamenList>(criteria);
            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>PlantillaExamenList</returns>
        public static PlantillaExamenList GetList()
        {
            return GetList(true);
        }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static PlantillaExamenList GetList(CriteriaEx criteria)
        {
            return PlantillaExamenList.RetrieveList(typeof(PlantillaExamen), AppContext.ActiveSchema.Code, criteria);
        }

        /// <summary>
        /// Builds a PlantillaExamenList from a IList<!--<PlantillaExamenInfo>-->
        /// Doesn`t retrieve child data from DB.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>PlantillaExamenList</returns>
        public static PlantillaExamenList GetList(IList<PlantillaExamenInfo> list)
        {
            PlantillaExamenList flist = new PlantillaExamenList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (PlantillaExamenInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a PlantillaExamenList from a IList<!--<PlantillaExamen>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>PlantillaExamen</returns>
        public static PlantillaExamenList GetList(IList<PlantillaExamen> list)
        {
            PlantillaExamenList flist = new PlantillaExamenList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (PlantillaExamen item in list)
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
        public static SortedBindingList<PlantillaExamenInfo> GetSortedList(string sortProperty,
                                                                    ListSortDirection sortDirection)
        {
            SortedBindingList<PlantillaExamenInfo> sortedList =
                new SortedBindingList<PlantillaExamenInfo>(GetList());
            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        /*public static PlantillaExamenList GetModuloList(long oid_modulo)
        {
            CriteriaEx criteria = PlantillaExamen.GetCriteria(PlantillaExamen.OpenSession());
            criteria.AddEq("OidModulo", oid_modulo);
            PlantillaExamenList list = PlantillaExamenList.RetrieveList(typeof(PlantillaExamen), AppContext.ActiveSchema.Code, criteria);
            //CloseSession(criteria.SessionCode);
            return list;
        }*/

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<PlantillaExamen> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (PlantillaExamen item in lista)
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
                this.AddItem(PlantillaExamenInfo.Get(reader,Childs));

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
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query);

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(PlantillaExamenInfo.Get(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList<PlantillaExamen> list = criteria.List<PlantillaExamen>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (PlantillaExamen item in list)
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

                    foreach (PlantillaExamen item in list)
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
        //public PlantillaExamenList GetPlantillasFiltradas(long oid_modulo, string idioma, bool filtros, bool desarrollo)
        //{
        //    PlantillaExamenList lista = new PlantillaExamenList();
        //    string query = PlantillaExamenList.SELECT_PLANTILLAS_FILTRADAS(oid_modulo, idioma, filtros, desarrollo);
        //    int sesion = PlantillaExamen.OpenSession();

        //    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(sesion));

        //    lista.RaiseListChangedEvents = false;

        //    lista.IsReadOnly = false;

        //    while (reader.Read())
        //    {
        //        PlantillaExamenInfo p = this.GetItem((long)reader["OID"]);

        //        lista.AddItem(p);
        //    }

        //    lista.IsReadOnly = true;

        //    lista.RaiseListChangedEvents = true;

        //    CloseSession(sesion);

        //    return lista;
        //}

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <param name="get_childs">retrieving the childs</param>
        /// <returns></returns>
        public static PlantillaExamenList GetPlantillasFiltradas(long oid_modulo, string idioma, bool filtros, bool desarrollo)
        {
            CriteriaEx criteria = PlantillaExamen.GetCriteria(PlantillaExamenList.OpenSession());
            criteria.Childs = false;
            criteria.Query = PlantillaExamenList.SELECT_PLANTILLAS_FILTRADAS(oid_modulo, idioma, filtros, desarrollo);

            //No criteria. Retrieve all de List
            PlantillaExamenList list = DataPortal.Fetch<PlantillaExamenList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
            
        }


        #endregion

        #region SQL

        public static string SELECT() { return PlantillaExamen.SELECT(0, false); }
        public static string SELECT_BY_MODULO(long oid_modulo, bool desarrollo) { return PlantillaExamenes.SELECT_BY_MODULO(oid_modulo, desarrollo, false); }

        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public static string SELECT_PLANTILLAS_FILTRADAS(long oid_modulo, string idioma, bool filtros, bool desarrollo)
        {
            string plantilla = nHManager.Instance.GetSQLTable(typeof(PlantillaExamenRecord));

            string query;

            query = "SELECT * " +
                    "FROM " + plantilla + " " +
                    "WHERE 1=1 ";

            if (oid_modulo != 0)
                query += "AND \"OID_MODULO\" = " + oid_modulo.ToString() + " ";

            if (idioma != string.Empty)
                query += "AND \"IDIOMA\" = '" + idioma + "' ";

            if (filtros)
            {
                if (desarrollo)
                    query += "AND \"DESARROLLO\" = true ";
                else
                    query += "AND \"DESARROLLO\" = false ";
            }

            query += ";";

            return query;
        }

        #endregion

    }
}

