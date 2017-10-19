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
    public class IncidenciaSesionCronogramaList : ReadOnlyListBaseEx<IncidenciaSesionCronogramaList, IncidenciaSesionCronogramaInfo>
    {

        #region Child Factory Methods

        private IncidenciaSesionCronogramaList() { }

        private IncidenciaSesionCronogramaList(IList<IncidenciaSesionCronograma> lista)
        {
            Fetch(lista);
        }

        private IncidenciaSesionCronogramaList(IDataReader reader)
        {
            Fetch(reader);
        }

        public static IncidenciaSesionCronogramaList NewList() { return new IncidenciaSesionCronogramaList(); }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <param name="get_childs">retrieving the childs</param>
        /// <returns>RedList</returns>
        public static IncidenciaSesionCronogramaList GetChildList(bool childs)
        {
            CriteriaEx criteria = IncidenciaSesionCronograma.GetCriteria(IncidenciaSesionCronograma.OpenSession());
            criteria.Childs = childs;
            criteria.Query = IncidenciaSesionCronogramaList.SELECT();

            //No criteria. Retrieve all de List
            IncidenciaSesionCronogramaList list = DataPortal.Fetch<IncidenciaSesionCronogramaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }


        /// <summary>
        /// Builds a IncidenciaSesionCronogramaList from a IList<!--<IncidenciaSesionCronogramaInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>IncidenciaSesionCronogramaList</returns>
        public static IncidenciaSesionCronogramaList GetChildList(IList<IncidenciaSesionCronogramaInfo> list)
        {
            IncidenciaSesionCronogramaList flist = new IncidenciaSesionCronogramaList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (IncidenciaSesionCronogramaInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }


        /// <summary>
        /// Builds a IncidenciaSesionCronogramaList from IList<!--<IncidenciaSesionCronograma>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>IncidenciaSesionCronogramaList</returns>
        public static IncidenciaSesionCronogramaList GetChildList(IList<IncidenciaSesionCronograma> list) { return new IncidenciaSesionCronogramaList(list); }

        public static IncidenciaSesionCronogramaList GetChildList(IDataReader reader) { return new IncidenciaSesionCronogramaList(reader); }

        #endregion

        #region Root Factory Methods

        //  private IncidenciaSesionCronogramaList() { }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>IncidenciaSesionCronogramaList</returns>
        public static IncidenciaSesionCronogramaList GetList(bool childs)
        {
            CriteriaEx criteria = IncidenciaSesionCronograma.GetCriteria(IncidenciaSesionCronograma.OpenSession());
            criteria.Childs = childs;
            //No criteria. Retrieve all de List
            IncidenciaSesionCronogramaList list = DataPortal.Fetch<IncidenciaSesionCronogramaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>IncidenciaSesionCronogramaList</returns>
        public static IncidenciaSesionCronogramaList GetList()
        {
            return GetList(true);
        }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static IncidenciaSesionCronogramaList GetList(CriteriaEx criteria)
        {
            return IncidenciaSesionCronogramaList.RetrieveList(typeof(IncidenciaSesionCronograma), AppContext.ActiveSchema.Code, criteria);
        }

        /// <summary>
        /// Builds a IncidenciaSesionCronogramaList from a IList<!--<IncidenciaSesionCronogramaInfo>-->
        /// Doesn`t retrieve child data from DB.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>IncidenciaSesionCronogramaList</returns>
        public static IncidenciaSesionCronogramaList GetList(IList<IncidenciaSesionCronogramaInfo> list)
        {
            IncidenciaSesionCronogramaList flist = new IncidenciaSesionCronogramaList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (IncidenciaSesionCronogramaInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a IncidenciaSesionCronogramaList from a IList<!--<IncidenciaSesionCronograma>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>IncidenciaSesionCronograma</returns>
        public static IncidenciaSesionCronogramaList GetList(IList<IncidenciaSesionCronograma> list)
        {
            IncidenciaSesionCronogramaList flist = new IncidenciaSesionCronogramaList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (IncidenciaSesionCronograma item in list)
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
        public static SortedBindingList<IncidenciaSesionCronogramaInfo> GetSortedList(string sortProperty,
                                                                    ListSortDirection sortDirection)
        {
            SortedBindingList<IncidenciaSesionCronogramaInfo> sortedList =
                new SortedBindingList<IncidenciaSesionCronogramaInfo>(GetList());
            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<IncidenciaSesionCronograma> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (IncidenciaSesionCronograma item in lista)
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
                this.AddItem(IncidenciaSesionCronogramaInfo.Get(reader,false));

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

					//IncidenciaSesionCronograma.DoLOCK( Session());

                    IDataReader reader = SesionesCronogramas.DoNativeSELECT(AppContext.ActiveSchema.Code, Session());

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(IncidenciaSesionCronogramaInfo.Get(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList<IncidenciaSesionCronograma> list = criteria.List<IncidenciaSesionCronograma>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (IncidenciaSesionCronograma item in list)
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

                    foreach (IncidenciaSesionCronograma item in list)
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

        #region SQL

        public static string SELECT() { return IncidenciaSesionCronograma.SELECT(new QueryConditions(), false); }

        #endregion

    }
}

