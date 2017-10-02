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
    public class SesionCronogramaList : ReadOnlyListBaseEx<SesionCronogramaList, SesionCronogramaInfo>
    {

        #region Child Factory Methods

        private SesionCronogramaList() { }

        private SesionCronogramaList(IList<SesionCronograma> lista)
        {
            Fetch(lista);
        }

        private SesionCronogramaList(IDataReader reader)
        {
            Fetch(reader);
        }

        public static SesionCronogramaList NewList() { return new SesionCronogramaList(); }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <param name="get_childs">retrieving the childs</param>
        /// <returns>RedList</returns>
        public static SesionCronogramaList GetChildList(bool childs)
        {
            CriteriaEx criteria = SesionCronograma.GetCriteria(SesionCronograma.OpenSession());
            criteria.Childs = childs;
            criteria.Query = SesionCronogramaList.SELECT();

            //No criteria. Retrieve all de List
            SesionCronogramaList list = DataPortal.Fetch<SesionCronogramaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }


        /// <summary>
        /// Builds a SesionCronogramaList from a IList<!--<SesionCronogramaInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>SesionCronogramaList</returns>
        public static SesionCronogramaList GetChildList(IList<SesionCronogramaInfo> list)
        {
            SesionCronogramaList flist = new SesionCronogramaList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (SesionCronogramaInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }


        /// <summary>
        /// Builds a SesionCronogramaList from IList<!--<SesionCronograma>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>SesionCronogramaList</returns>
        public static SesionCronogramaList GetChildList(IList<SesionCronograma> list) { return new SesionCronogramaList(list); }

        public static SesionCronogramaList GetChildList(IDataReader reader) { return new SesionCronogramaList(reader); }

        #endregion

        #region Root Factory Methods

        //  private SesionCronogramaList() { }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>SesionCronogramaList</returns>
        public static SesionCronogramaList GetList(bool childs)
        {
            CriteriaEx criteria = SesionCronograma.GetCriteria(SesionCronograma.OpenSession());
            criteria.Childs = childs;
            //No criteria. Retrieve all de List
            SesionCronogramaList list = DataPortal.Fetch<SesionCronogramaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>SesionCronogramaList</returns>
        public static SesionCronogramaList GetList()
        {
            return GetList(true);
        }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static SesionCronogramaList GetList(CriteriaEx criteria)
        {
            return SesionCronogramaList.RetrieveList(typeof(SesionCronograma), AppContext.ActiveSchema.Code, criteria);
        }

        /// <summary>
        /// Builds a SesionCronogramaList from a IList<!--<SesionCronogramaInfo>-->
        /// Doesn`t retrieve child data from DB.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>SesionCronogramaList</returns>
        public static SesionCronogramaList GetList(IList<SesionCronogramaInfo> list)
        {
            SesionCronogramaList flist = new SesionCronogramaList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (SesionCronogramaInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a SesionCronogramaList from a IList<!--<SesionCronograma>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>SesionCronograma</returns>
        public static SesionCronogramaList GetList(IList<SesionCronograma> list)
        {
            SesionCronogramaList flist = new SesionCronogramaList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (SesionCronograma item in list)
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
        public static SortedBindingList<SesionCronogramaInfo> GetSortedList(string sortProperty,
                                                                    ListSortDirection sortDirection)
        {
            SortedBindingList<SesionCronogramaInfo> sortedList =
                new SortedBindingList<SesionCronogramaInfo>(GetList());
            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<SesionCronograma> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (SesionCronograma item in lista)
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
                this.AddItem(SesionCronogramaInfo.Get(reader,false));

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

					//SesionCronograma.DoLOCK( Session());

                    IDataReader reader = SesionesCronogramas.DoNativeSELECT(AppContext.ActiveSchema.Code, Session());

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(SesionCronogramaInfo.Get(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList<SesionCronograma> list = criteria.List<SesionCronograma>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (SesionCronograma item in list)
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

                    foreach (SesionCronograma item in list)
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

        public static string SELECT() { return SesionCronograma.SELECT(new QueryConditions(), false); }

        #endregion

    }
}

