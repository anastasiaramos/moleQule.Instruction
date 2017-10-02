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
	public class MaterialDocenteList : ReadOnlyListBaseEx<MaterialDocenteList, MaterialDocenteInfo>
	{

        #region Child Factory Methods

        private MaterialDocenteList() { }

        public static MaterialDocenteList NewList() { return new MaterialDocenteList(); }

        private MaterialDocenteList(IList<MaterialDocente> lista)
        {
            Fetch(lista);
        }

        private MaterialDocenteList(IDataReader reader)
        {
            Fetch(reader);
        }

        /// <summary>
        /// Builds a MaterialDocenteList from a IList<!--<MaterialDocenteInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>MaterialDocenteList</returns>
        public static MaterialDocenteList GetChildList(IList<MaterialDocenteInfo> list)
        {
            MaterialDocenteList flist = new MaterialDocenteList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (MaterialDocenteInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }


        /// <summary>
        /// Builds a MaterialDocenteList from IList<!--<MaterialDocente>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>MaterialDocenteList</returns>
        public static MaterialDocenteList GetChildList(IList<MaterialDocente> list) { return new MaterialDocenteList(list); }

        public static MaterialDocenteList GetChildList(IDataReader reader) { return new MaterialDocenteList(reader); }

        #endregion

        #region Root Factory Methods

        //  private MaterialDocenteList() { }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>MaterialDocenteList</returns>
        public static MaterialDocenteList GetList(bool childs)
        {
            CriteriaEx criteria = MaterialDocente.GetCriteria(MaterialDocente.OpenSession());
            criteria.Childs = childs;

            criteria.Query = MaterialDocenteList.SELECT();
            
            MaterialDocenteList list = DataPortal.Fetch<MaterialDocenteList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>MaterialDocenteList</returns>
        public static MaterialDocenteList GetList()
        {
            return GetList(true);
        }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static MaterialDocenteList GetList(CriteriaEx criteria)
        {
            return MaterialDocenteList.RetrieveList(typeof(MaterialDocente), AppContext.ActiveSchema.Code, criteria);
        }

        /// <summary>
        /// Builds a MaterialDocenteList from a IList<!--<MaterialDocenteInfo>-->
        /// Doesn`t retrieve child data from DB.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>MaterialDocenteList</returns>
        public static MaterialDocenteList GetList(IList<MaterialDocenteInfo> list)
        {
            MaterialDocenteList flist = new MaterialDocenteList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (MaterialDocenteInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a MaterialDocenteList from a IList<!--<MaterialDocente>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>MaterialDocente</returns>
        public static MaterialDocenteList GetList(IList<MaterialDocente> list)
        {
            MaterialDocenteList flist = new MaterialDocenteList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (MaterialDocente item in list)
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
        public static SortedBindingList<MaterialDocenteInfo> GetSortedList(string sortProperty,
                                                                    ListSortDirection sortDirection)
        {
            SortedBindingList<MaterialDocenteInfo> sortedList =
                new SortedBindingList<MaterialDocenteInfo>(GetList());
            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<MaterialDocente> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (MaterialDocente item in lista)
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
                this.AddItem(MaterialDocenteInfo.Get(reader));

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
                        this.AddItem(MaterialDocenteInfo.Get(reader, Childs));
                    }

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

                    foreach (MaterialDocente item in list)
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

        public static string SELECT() { return MaterialDocenteInfo.SELECT(0); }

        #endregion

    }
}

