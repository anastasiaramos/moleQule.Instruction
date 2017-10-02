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
	/// ReadOnly Root Collection of Business Objects With Child Collection
	/// </summary>
    [Serializable()]
	public class PlanEstudiosList : ReadOnlyListBaseEx<PlanEstudiosList, PlanEstudiosInfo>
	{

        #region Business Methods


        #endregion

        #region Factory Methods

        private PlanEstudiosList() { }

        public static PlanEstudiosList NewList() { return new PlanEstudiosList(); }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <param name="get_childs">retrieving the childs</param>
        /// <returns></returns>
        public static PlanEstudiosList GetList(bool childs)
        {
            CriteriaEx criteria = PlanEstudios.GetCriteria(PlanEstudios.OpenSession());
            criteria.Childs = childs;
            criteria.Query = PlanEstudiosList.SELECT();

            //No criteria. Retrieve all de List
            PlanEstudiosList list = DataPortal.Fetch<PlanEstudiosList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Default call for GetList(bool get_childs)
        /// </summary>
        /// <returns></returns>
        public static PlanEstudiosList GetList()
        {
            return PlanEstudiosList.GetList(true);
        }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static PlanEstudiosList GetList(CriteriaEx criteria)
        {
            return PlanEstudiosList.RetrieveList(typeof(PlanEstudios), AppContext.ActiveSchema.Code, criteria);
        }

        /// <summary>
        /// Builds a ClienteList from a IList<!--<ClienteInfo>-->.
        /// Doesn`t retrieve child data from DB.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static PlanEstudiosList GetList(IList<PlanEstudiosInfo> list)
        {
            PlanEstudiosList flist = new PlanEstudiosList();


            if (list.Count > 0)
            {
                flist.IsReadOnly = false;
                foreach (PlanEstudiosInfo item in list)
                    flist.AddItem(item);

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
        public static SortedBindingList<PlanEstudiosInfo> GetSortedList(string sortProperty, ListSortDirection sortDirection)
        {
            SortedBindingList<PlanEstudiosInfo> sortedList = new SortedBindingList<PlanEstudiosInfo>(GetList());

            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }

        #endregion

        #region Data Access

        // called to retrieve data from database
        protected override void Fetch(CriteriaEx criteria)
        {
            this.RaiseListChangedEvents = false;

            SessionCode = criteria.SessionCode;
            Childs = criteria.Childs;

            try
            {
                if (nHMng.UseDirectSQL)
                {
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(criteria.Query, Session());

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(PlanEstudiosInfo.Get(reader, Childs));
                    }
                    IsReadOnly = true;
                }
                else
                {
                    IList list = criteria.List();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;
                        foreach (PlanEstudios item in list)
                            this.AddItem(item.GetInfo(false));

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

        #region SQL

        public static string SELECT() { return PlanEstudios.SELECT(new QueryConditions(), false); }

        #endregion

    }
}

