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
	public class ClaseExtraList : ReadOnlyListBaseEx<ClaseExtraList, ClaseExtraInfo>
	{

        #region Child Factory Methods

        private ClaseExtraList() { }

        private ClaseExtraList(IList<ClaseExtra> lista)
        {
            Fetch(lista);
        }

        private ClaseExtraList(IDataReader reader)
        {
            Fetch(reader);
        }

        /// <summary>
        /// Builds a ClaseExtraList from a IList<!--<ClaseExtraInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>ClaseExtraList</returns>
        public static ClaseExtraList GetChildList(IList<ClaseExtraInfo> list)
        {
            ClaseExtraList flist = new ClaseExtraList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (ClaseExtraInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }


        /// <summary>
        /// Builds a ClaseExtraList from IList<!--<ClaseExtra>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>ClaseExtraList</returns>
        public static ClaseExtraList GetChildList(IList<ClaseExtra> list) { return new ClaseExtraList(list); }

        public static ClaseExtraList GetChildList(IDataReader reader) { return new ClaseExtraList(reader); }

        #endregion

        #region Root Factory Methods

        //  private ClaseExtraList() { }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>ClaseExtraList</returns>
        public static ClaseExtraList GetList()
        {
            CriteriaEx criteria = ClaseExtra.GetCriteria(ClaseExtra.OpenSession());
            criteria.Query = ClaseExtras.SELECT();

            //No criteria. Retrieve all de List
            ClaseExtraList list = DataPortal.Fetch<ClaseExtraList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>ClaseExtraList</returns>
        public static ClaseExtraList GetDisponiblesList(long oid_promocion, long oid_horario)
        {
            CriteriaEx criteria = ClaseExtra.GetCriteria(ClaseExtra.OpenSession());
            criteria.Query = ClaseExtras.SELECT_CLASES_EXTRAS_DISPONIBLES(oid_promocion, oid_horario);

            //No criteria. Retrieve all de List
            ClaseExtraList list = DataPortal.Fetch<ClaseExtraList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>ClasePracticaList</returns>
        public static ClaseExtraList GetClasesPlanList(long oid_plan)
        {
            CriteriaEx criteria = ClaseExtra.GetCriteria(ClaseExtra.OpenSession());

            //No criteria. Retrieve all de List
            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = ClaseExtras.SELECT_CLASES_EXTRAS_PLAN(oid_plan);
            ClaseExtraList list = DataPortal.Fetch<ClaseExtraList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static ClaseExtraList GetList(CriteriaEx criteria)
        {
            return ClaseExtraList.RetrieveList(typeof(ClaseExtra), AppContext.ActiveSchema.Code, criteria);
        }

        /// <summary>
        /// Builds a ClaseExtraList from a IList<!--<ClaseExtraInfo>-->
        /// Doesn`t retrieve child data from DB.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>ClaseExtraList</returns>
        public static ClaseExtraList GetList(IList<ClaseExtraInfo> list)
        {
            ClaseExtraList flist = new ClaseExtraList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (ClaseExtraInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a ClaseExtraList from a IList<!--<ClaseExtra>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>ClaseExtra</returns>
        public static ClaseExtraList GetList(IList<ClaseExtra> list)
        {
            ClaseExtraList flist = new ClaseExtraList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (ClaseExtra item in list)
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
        public static SortedBindingList<ClaseExtraInfo> GetSortedList(string sortProperty,
                                                                    ListSortDirection sortDirection)
        {
            SortedBindingList<ClaseExtraInfo> sortedList =
                new SortedBindingList<ClaseExtraInfo>(GetList());
            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }

        public List<ClaseExtraInfo> GetClasesOrdenadas()
        {
            SubmoduloList submodulos = SubmoduloList.GetList(false);
            ModuloList modulos = ModuloList.GetList(false);
            List<ClaseExtraInfo> clases = new List<ClaseExtraInfo>();

            foreach (ClaseExtraInfo clase in this)
                clases.Add(clase);

            for (int i = 0; i < clases.Count - 1; i++)
            {
                for (int j = i + 1; j < clases.Count; j++)
                {
                    string codigo_i = submodulos.GetItem(clases[i].OidSubmodulo).CodigoOrden;
                    string codigo_j = submodulos.GetItem(clases[j].OidSubmodulo).CodigoOrden;
                    int valor = codigo_i.CompareTo(codigo_j);

                    if (valor == 1)
                    {
                        ClaseExtraInfo aux = clases[i];
                        clases[i] = clases[j];
                        clases[j] = aux;
                    }
                }
            }

            return clases;
        }


        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<ClaseExtra> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (ClaseExtra item in lista)
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
                this.AddItem(ClaseExtra.GetChild(reader).GetInfo());

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

                    //ClaseExtra.DoLOCK( Session());

                    IDataReader reader = null;

                    reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(ClaseExtraInfo.Get(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList<ClaseExtra> list = criteria.List<ClaseExtra>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (ClaseExtra item in list)
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

                    foreach (ClaseExtra item in list)
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

