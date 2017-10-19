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
    public class IncidenciaCronogramaList : ReadOnlyListBaseEx<IncidenciaCronogramaList, IncidenciaCronogramaInfo>
    {

        #region Child Factory Methods

        private IncidenciaCronogramaList() { }

        public static IncidenciaCronogramaList NewList() { return new IncidenciaCronogramaList(); }

        private IncidenciaCronogramaList(IList<IncidenciaCronograma> lista)
        {
            Fetch(lista);
        }

        private IncidenciaCronogramaList(IDataReader reader)
        {
            Fetch(reader);
        }

        /// <summary>
        /// Builds a IncidenciaCronogramaList from a IList<!--<IncidenciaCronogramaInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>IncidenciaCronogramaList</returns>
        public static IncidenciaCronogramaList GetChildList(IList<IncidenciaCronogramaInfo> list)
        {
            IncidenciaCronogramaList flist = new IncidenciaCronogramaList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (IncidenciaCronogramaInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }


        /// <summary>
        /// Builds a IncidenciaCronogramaList from IList<!--<IncidenciaCronograma>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>IncidenciaCronogramaList</returns>
        public static IncidenciaCronogramaList GetChildList(IList<IncidenciaCronograma> list) { return new IncidenciaCronogramaList(list); }

        public static IncidenciaCronogramaList GetChildList(IDataReader reader) { return new IncidenciaCronogramaList(reader); }

        #endregion

        #region Root Factory Methods

        //  private IncidenciaCronogramaList() { }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>IncidenciaCronogramaList</returns>
        public static IncidenciaCronogramaList GetList(bool childs)
        {
            CriteriaEx criteria = IncidenciaCronograma.GetCriteria(IncidenciaCronograma.OpenSession());
            criteria.Childs = childs;
            criteria.Query = IncidenciaCronogramaList.SELECT();
            //No criteria. Retrieve all de List
            IncidenciaCronogramaList list = DataPortal.Fetch<IncidenciaCronogramaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>IncidenciaCronogramaList</returns>
        public static IncidenciaCronogramaList GetList()
        {
            return GetList(true);
        }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static IncidenciaCronogramaList GetList(CriteriaEx criteria)
        {
            return IncidenciaCronogramaList.RetrieveList(typeof(IncidenciaCronograma), AppContext.ActiveSchema.Code, criteria);
        }

        /// <summary>
        /// Builds a IncidenciaCronogramaList from a IList<!--<IncidenciaCronogramaInfo>-->
        /// Doesn`t retrieve child data from DB.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>IncidenciaCronogramaList</returns>
        public static IncidenciaCronogramaList GetList(IList<IncidenciaCronogramaInfo> list)
        {
            IncidenciaCronogramaList flist = new IncidenciaCronogramaList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (IncidenciaCronogramaInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a IncidenciaCronogramaList from a IList<!--<IncidenciaCronograma>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>IncidenciaCronograma</returns>
        public static IncidenciaCronogramaList GetList(IList<IncidenciaCronograma> list)
        {
            IncidenciaCronogramaList flist = new IncidenciaCronogramaList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (IncidenciaCronograma item in list)
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
        public static SortedBindingList<IncidenciaCronogramaInfo> GetSortedList(string sortProperty,
                                                                    ListSortDirection sortDirection)
        {
            SortedBindingList<IncidenciaCronogramaInfo> sortedList =
                new SortedBindingList<IncidenciaCronogramaInfo>(GetList());
            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<IncidenciaCronograma> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (IncidenciaCronograma item in lista)
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
                this.AddItem(IncidenciaCronogramaInfo.Get(reader));

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
                    IDataReader reader = null;

                    reader = nHMng.SQLNativeSelect(criteria.Query);

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(IncidenciaCronogramaInfo.Get(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList<IncidenciaCronograma> list = criteria.List<IncidenciaCronograma>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (IncidenciaCronograma item in list)
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

                    foreach (IncidenciaCronograma item in list)
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

        public static string SELECT()
        {
            return IncidenciaCronograma.SELECT(0);
        }

        #endregion

    }
}

