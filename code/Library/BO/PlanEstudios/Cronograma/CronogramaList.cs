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
    public class CronogramaList : ReadOnlyListBaseEx<CronogramaList, CronogramaInfo>
    {

        #region Child Factory Methods

        private CronogramaList() { }

        public static CronogramaList NewList() { return new CronogramaList(); }

        private CronogramaList(IList<Cronograma> lista)
        {
            Fetch(lista);
        }

        private CronogramaList(IDataReader reader)
        {
            Fetch(reader);
        }

        /// <summary>
        /// Builds a CronogramaList from a IList<!--<CronogramaInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>CronogramaList</returns>
        public static CronogramaList GetChildList(IList<CronogramaInfo> list)
        {
            CronogramaList flist = new CronogramaList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (CronogramaInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }


        /// <summary>
        /// Builds a CronogramaList from IList<!--<Cronograma>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>CronogramaList</returns>
        public static CronogramaList GetChildList(IList<Cronograma> list) { return new CronogramaList(list); }

        public static CronogramaList GetChildList(IDataReader reader) { return new CronogramaList(reader); }

        #endregion

        #region Root Factory Methods

        //  private CronogramaList() { }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>CronogramaList</returns>
        public static CronogramaList GetList(bool childs)
        {
            CriteriaEx criteria = Cronograma.GetCriteria(Cronograma.OpenSession());
            criteria.Childs = childs;
            criteria.Query = CronogramaList.SELECT();
            //No criteria. Retrieve all de List
            CronogramaList list = DataPortal.Fetch<CronogramaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>CronogramaList</returns>
        public static CronogramaList GetList()
        {
            return GetList(true);
        }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static CronogramaList GetList(CriteriaEx criteria)
        {
            return CronogramaList.RetrieveList(typeof(Cronograma), AppContext.ActiveSchema.Code, criteria);
        }

        /// <summary>
        /// Builds a CronogramaList from a IList<!--<CronogramaInfo>-->
        /// Doesn`t retrieve child data from DB.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>CronogramaList</returns>
        public static CronogramaList GetList(IList<CronogramaInfo> list)
        {
            CronogramaList flist = new CronogramaList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (CronogramaInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a CronogramaList from a IList<!--<Cronograma>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Cronograma</returns>
        public static CronogramaList GetList(IList<Cronograma> list)
        {
            CronogramaList flist = new CronogramaList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (Cronograma item in list)
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
        public static SortedBindingList<CronogramaInfo> GetSortedList(string sortProperty,
                                                                    ListSortDirection sortDirection)
        {
            SortedBindingList<CronogramaInfo> sortedList =
                new SortedBindingList<CronogramaInfo>(GetList());
            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Cronograma> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (Cronograma item in lista)
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
                this.AddItem(CronogramaInfo.Get(reader));

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
                        this.AddItem(CronogramaInfo.Get(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList<Cronograma> list = criteria.List<Cronograma>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (Cronograma item in list)
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

                    foreach (Cronograma item in list)
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
            return Cronograma.SELECT(0);
        }

        #endregion

    }
}

