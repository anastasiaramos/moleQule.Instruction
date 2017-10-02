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
    public class Submodulo_InstructorList : ReadOnlyListBaseEx<Submodulo_InstructorList, Submodulo_InstructorInfo>
    {

        #region Child Factory Methods

        private Submodulo_InstructorList() { }



        private Submodulo_InstructorList(IList<Submodulo_Instructor> lista)
        {
            Fetch(lista);
        }

        private Submodulo_InstructorList(IDataReader reader)
        {
            Fetch(reader);
        }

        /// <summary>
        /// Builds a Submodulo_InstructorList from a IList<!--<Submodulo_InstructorInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Submodulo_InstructorList</returns>
        public static Submodulo_InstructorList GetChildList(IList<Submodulo_InstructorInfo> list)
        {
            Submodulo_InstructorList flist = new Submodulo_InstructorList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (Submodulo_InstructorInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }


        /// <summary>
        /// Builds a Submodulo_InstructorList from IList<!--<Submodulo_Instructor>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Submodulo_InstructorList</returns>
        public static Submodulo_InstructorList GetChildList(IList<Submodulo_Instructor> list) { return new Submodulo_InstructorList(list); }

        public static Submodulo_InstructorList GetChildList(IDataReader reader) { return new Submodulo_InstructorList(reader); }

        #endregion

        #region Root Factory Methods

        //  private Submodulo_InstructorList() { }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>Submodulo_InstructorList</returns>
        public static Submodulo_InstructorList GetList()
        {
            CriteriaEx criteria = Submodulo_Instructor.GetCriteria(Submodulo_Instructor.OpenSession());

            //No criteria. Retrieve all de List
            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = Submodulos_Instructores.SELECT();
            Submodulo_InstructorList list = DataPortal.Fetch<Submodulo_InstructorList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static Submodulo_InstructorList GetList(CriteriaEx criteria)
        {
            return Submodulo_InstructorList.RetrieveList(typeof(Submodulo_Instructor), AppContext.ActiveSchema.Code, criteria);
        }

        /// <summary>
        /// Builds a Submodulo_InstructorList from a IList<!--<Submodulo_InstructorInfo>-->
        /// Doesn`t retrieve child data from DB.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Submodulo_InstructorList</returns>
        public static Submodulo_InstructorList GetList(IList<Submodulo_InstructorInfo> list)
        {
            Submodulo_InstructorList flist = new Submodulo_InstructorList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (Submodulo_InstructorInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a Submodulo_InstructorList from a IList<!--<Submodulo_Instructor>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Submodulo_Instructor</returns>
        public static Submodulo_InstructorList GetList(IList<Submodulo_Instructor> list)
        {
            Submodulo_InstructorList flist = new Submodulo_InstructorList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (Submodulo_Instructor item in list)
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
        public static SortedBindingList<Submodulo_InstructorInfo> GetSortedList(string sortProperty,
                                                                    ListSortDirection sortDirection)
        {
            SortedBindingList<Submodulo_InstructorInfo> sortedList =
                new SortedBindingList<Submodulo_InstructorInfo>(GetList());
            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Submodulo_Instructor> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (Submodulo_Instructor item in lista)
                this.AddItem(item.GetInfo());

            IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }

        // called to copy objects data from list
        private void Fetch(IDataReader reader)
        {
            IsReadOnly = false;

            while (reader.Read())
                this.AddItem(Submodulo_Instructor.GetChild(reader).GetInfo());

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
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(Submodulo_InstructorInfo.Get(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList<Submodulo_Instructor> list = criteria.List<Submodulo_Instructor>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (Submodulo_Instructor item in list)
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

                    foreach (Submodulo_Instructor item in list)
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

        public static string SELECT(InstructorInfo item) { return Submodulo_Instructor.SELECT(new QueryConditions() { Instructor = item }, false); }
        public static string SELECT_BY_FECHA(InstructorInfo item, DateTime inicio, DateTime fin){return Submodulo_Instructor.SELECT(new QueryConditions(){Instructor = item, FechaAuxIni = inicio, FechaAuxFin = fin},false);}

        #endregion

    }
}

