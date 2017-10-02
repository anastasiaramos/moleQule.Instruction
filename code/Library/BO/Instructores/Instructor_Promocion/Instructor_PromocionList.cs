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
    public class Instructor_PromocionList : ReadOnlyListBaseEx<Instructor_PromocionList, Instructor_PromocionInfo>
    {
        #region Business Methods

        public Instructor_PromocionInfo GetItemByPromocion(long oid_promocion)
        {
            foreach (Instructor_PromocionInfo item in this)
                if (item.OidPromocion == oid_promocion)
                    return item;

            return null;
        }

        #endregion

        #region Child Factory Methods

        private Instructor_PromocionList() { }

        private Instructor_PromocionList(IList<Instructor_Promocion> lista)
        {
            Fetch(lista);
        }

        private Instructor_PromocionList(IDataReader reader, bool childs)
        {
            Fetch(reader, childs);
        }

        /// <summary>
        /// Builds a Instructor_PromocionList from a IList<!--<Instructor_PromocionInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Instructor_PromocionList</returns>
        public static Instructor_PromocionList GetChildList(IList<Instructor_PromocionInfo> list)
        {
            Instructor_PromocionList flist = new Instructor_PromocionList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (Instructor_PromocionInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }


        /// <summary>
        /// Builds a Instructor_PromocionList from IList<!--<Instructor_Promocion>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Instructor_PromocionList</returns>
        public static Instructor_PromocionList GetChildList(IList<Instructor_Promocion> list) { return new Instructor_PromocionList(list); }

        public static Instructor_PromocionList GetChildList(IDataReader reader, bool childs = true) { return new Instructor_PromocionList(reader, childs); }
        public static Instructor_PromocionList GetChildList(IDataReader reader, DateTime fecha_inicio, DateTime fecha_fin) 
        { 
            Instructor_PromocionList list = new Instructor_PromocionList(reader, false);

            foreach (Instructor_PromocionInfo info in list)
                info.LoadSubmodulo_Instructor_PromocionChilds(info.Oid, fecha_inicio, fecha_fin);

            return list;
        }

        #endregion

        #region Root Factory Methods

        //  private Instructor_PromocionList() { }


        //public override Instructor_PromocionInfo GetItem(long oid_promocion)
        //{
        //    Instructor_PromocionInfo item = null;
        //    try { return (Instructor_PromocionInfo)HashList[oid_promocion]; }
        //    catch { return null; }
        //    //if (KeyValueList.TryGetValue(oid_promocion, out item))
        //    //    return item;
        //    //else return null;
        //    //return KeyValueList[oid_promocion];
        //}

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>Instructor_PromocionList</returns>
        public static Instructor_PromocionList GetList(bool childs)
        {
            CriteriaEx criteria = Instructor_Promocion.GetCriteria(Instructor_PromocionList.OpenSession());
            criteria.Childs = childs;

            //No criteria. Retrieve all de List
            Instructor_PromocionList list = DataPortal.Fetch<Instructor_PromocionList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

 
        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>Instructor_PromocionList</returns>
        public static Instructor_PromocionList GetList()
        {
            return GetList(true);
        }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static Instructor_PromocionList GetList(CriteriaEx criteria)
        {
            return Instructor_PromocionList.RetrieveList(typeof(Instructor_Promocion), AppContext.ActiveSchema.Code, criteria);
        }

        /// <summary>
        /// Builds a Instructor_PromocionList from a IList<!--<Instructor_PromocionInfo>-->
        /// Doesn`t retrieve child data from DB.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Instructor_PromocionList</returns>
        public static Instructor_PromocionList GetList(IList<Instructor_PromocionInfo> list)
        {
            Instructor_PromocionList flist = new Instructor_PromocionList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (Instructor_PromocionInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a Instructor_PromocionList from a IList<!--<Instructor_Promocion>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Instructor_Promocion</returns>
        public static Instructor_PromocionList GetList(IList<Instructor_Promocion> list)
        {
            Instructor_PromocionList flist = new Instructor_PromocionList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (Instructor_Promocion item in list)
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
        public static SortedBindingList<Instructor_PromocionInfo> GetSortedList(string sortProperty,
                                                                    ListSortDirection sortDirection)
        {
            SortedBindingList<Instructor_PromocionInfo> sortedList =
                new SortedBindingList<Instructor_PromocionInfo>(GetList());
            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Instructor_Promocion> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (Instructor_Promocion item in lista)
                this.AddItem(item.GetInfo());

            IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }

        // called to copy objects data from list
        private void Fetch(IDataReader reader, bool childs)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            while (reader.Read())
            {
                Instructor_PromocionInfo item = Instructor_PromocionInfo.Get(reader, childs);
                this.AddItem(item);
            }

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
                    IDataReader reader = Instructor_Promociones.DoNativeSELECT(AppContext.ActiveSchema.Code, Session());

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(Instructor_PromocionInfo.Get(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList<Instructor_Promocion> list = criteria.List<Instructor_Promocion>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (Instructor_Promocion item in list)
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

                    foreach (Instructor_Promocion item in list)
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

    }
}

