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
	public class PreguntaExamenList : ReadOnlyListBaseEx<PreguntaExamenList, PreguntaExamenInfo>
	{

        #region Child Factory Methods

        private PreguntaExamenList() { }

        private PreguntaExamenList(IList<PreguntaExamen> lista)
        {
            Fetch(lista);
        }

        private PreguntaExamenList(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        /// <summary>
        /// Builds a PreguntaExamenList from a IList<!--<PreguntaExamenInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>PreguntaExamenList</returns>
        public static PreguntaExamenList GetChildList(IList<PreguntaExamenInfo> list)
        {
            PreguntaExamenList flist = new PreguntaExamenList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (PreguntaExamenInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a PreguntaExamenList from IList<!--<PreguntaExamen>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>PreguntaExamenList</returns>
        public static PreguntaExamenList GetChildList(IList<PreguntaExamen> list) { return new PreguntaExamenList(list); }

        public static PreguntaExamenList GetChildList(IDataReader reader, bool childs) { return new PreguntaExamenList(reader, childs); }

        #endregion

        #region Root Factory Methods

        //  private PreguntaExamenList() { }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>PreguntaExamenList</returns>
        public static PreguntaExamenList GetList(bool childs)
        {
            CriteriaEx criteria = PreguntaExamen.GetCriteria(PreguntaExamen.OpenSession());
            criteria.Childs = childs;
            criteria.Query = PreguntaExamenList.SELECT();

            PreguntaExamenList list = DataPortal.Fetch<PreguntaExamenList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>PreguntaExamenList</returns>
        public static PreguntaExamenList GetList()
        {
            return GetList(true);
        }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static PreguntaExamenList GetList(CriteriaEx criteria)
        {
            return PreguntaExamenList.RetrieveList(typeof(PreguntaExamen), AppContext.ActiveSchema.Code, criteria);
        }

        /// <summary>
        /// Builds a PreguntaExamenList from a IList<!--<PreguntaExamenInfo>-->
        /// Doesn`t retrieve child data from DB.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>PreguntaExamenList</returns>
        public static PreguntaExamenList GetList(IList<PreguntaExamenInfo> list)
        {
            PreguntaExamenList flist = new PreguntaExamenList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (PreguntaExamenInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a PreguntaExamenList from a IList<!--<PreguntaExamen>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>PreguntaExamen</returns>
        public static PreguntaExamenList GetList(IList<PreguntaExamen> list)
        {
            PreguntaExamenList flist = new PreguntaExamenList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (PreguntaExamen item in list)
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
        public static SortedBindingList<PreguntaExamenInfo> GetSortedList(string sortProperty,
                                                                    ListSortDirection sortDirection)
        {
            SortedBindingList<PreguntaExamenInfo> sortedList =
                new SortedBindingList<PreguntaExamenInfo>(GetList());
            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<PreguntaExamen> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (PreguntaExamen item in lista)
                this.AddItem(item.GetInfo(true));

            IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }

        // called to copy objects data from list
        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            while (reader.Read())
                this.AddItem(PreguntaExamenInfo.Get(reader, Childs));

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
                        this.AddItem(PreguntaExamenInfo.Get(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList<PreguntaExamen> list = criteria.List<PreguntaExamen>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (PreguntaExamen item in list)
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

                    foreach (PreguntaExamen item in list)
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

        public static string SELECT() { return PreguntaExamen.SELECT(new QueryConditions(), false); }
        public static string SELECT_BY_EXAMEN(long oid_examen) { return PreguntaExamens.SELECT_BY_EXAMEN(oid_examen, false); }
                
        public static string UPDATE_IMAGEN(long oid, string imagen)
        {
            string pregunta = nHManager.Instance.GetSQLTable(typeof(PreguntaExamenRecord));
            string c_imagen = nHManager.Instance.GetTableField(typeof(PreguntaExamenRecord), "Imagen");

            string query;

            query = "UPDATE " + pregunta +
                    " SET \"" + c_imagen + "\" = '" + imagen + "' " +
                    "WHERE \"OID\" = " + oid.ToString() + ";";

            return query;
        }

        #endregion

   }
}

