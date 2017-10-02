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
    public class Convocatoria_CursoList : ReadOnlyListBaseEx<Convocatoria_CursoList, Convocatoria_CursoInfo>
    {

        #region Child Factory Methods

        public Convocatoria_CursoList() { }

        private Convocatoria_CursoList(IList<Convocatoria_Curso> lista)
        {
            Fetch(lista);
        }

        private Convocatoria_CursoList(IDataReader reader)
        {
            Fetch(reader);
        }

        /// <summary>
        /// Builds a Convocatoria_CursoList from a IList<!--<Convocatoria_CursoInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Convocatoria_CursoList</returns>
        public static Convocatoria_CursoList GetChildList(IList<Convocatoria_CursoInfo> list)
        {
            Convocatoria_CursoList flist = new Convocatoria_CursoList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (Convocatoria_CursoInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a Convocatoria_CursoList from IList<!--<Convocatoria_Curso>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Convocatoria_CursoList</returns>
        public static Convocatoria_CursoList GetChildList(IList<Convocatoria_Curso> list) { return new Convocatoria_CursoList(list); }

        public static Convocatoria_CursoList GetChildList(IDataReader reader) { return new Convocatoria_CursoList(reader); }


        #endregion

        #region Root Factory Methods

        //  private Convocatoria_CursoList() { }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>Convocatoria_CursoList</returns>
        public static Convocatoria_CursoList GetList(bool childs)
        {
            CriteriaEx criteria = Convocatoria_Curso.GetCriteria(Convocatoria_Curso.OpenSession());
            criteria.Childs = childs;
            //No criteria. Retrieve all de List
            Convocatoria_CursoList list = DataPortal.Fetch<Convocatoria_CursoList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>Convocatoria_CursoList</returns>
        public static Convocatoria_CursoList GetList()
        {
            return GetList(true);
        }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static Convocatoria_CursoList GetList(CriteriaEx criteria)
        {
            return Convocatoria_CursoList.RetrieveList(typeof(Convocatoria_Curso), AppContext.ActiveSchema.Code, criteria);
        }

        /// <summary>
        /// Builds a Convocatoria_CursoList from a IList<!--<Convocatoria_CursoInfo>-->
        /// Doesn`t retrieve child data from DB.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Convocatoria_CursoList</returns>
        public static Convocatoria_CursoList GetList(IList<Convocatoria_CursoInfo> list)
        {
            Convocatoria_CursoList flist = new Convocatoria_CursoList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (Convocatoria_CursoInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a Convocatoria_CursoList from a IList<!--<Convocatoria_Curso>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Convocatoria_Curso</returns>
        public static Convocatoria_CursoList GetList(IList<Convocatoria_Curso> list)
        {
            Convocatoria_CursoList flist = new Convocatoria_CursoList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (Convocatoria_Curso item in list)
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
        public static SortedBindingList<Convocatoria_CursoInfo> GetSortedList(string sortProperty,
                                                                    ListSortDirection sortDirection)
        {
            SortedBindingList<Convocatoria_CursoInfo> sortedList =
                new SortedBindingList<Convocatoria_CursoInfo>(GetList());
            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Convocatoria_Curso> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (Convocatoria_Curso item in lista)
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
                this.AddItem(Convocatoria_CursoInfo.Get(reader));

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
                    IDataReader reader = Convocatoria_Cursos.DoNativeSELECT(AppContext.ActiveSchema.Code, Session());

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(Convocatoria_CursoInfo.Get(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList<Convocatoria_Curso> list = criteria.List<Convocatoria_Curso>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (Convocatoria_Curso item in list)
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

                    foreach (Convocatoria_Curso item in list)
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

