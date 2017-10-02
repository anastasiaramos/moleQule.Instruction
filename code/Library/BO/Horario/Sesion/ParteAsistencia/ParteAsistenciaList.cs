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
	public class ParteAsistenciaList : ReadOnlyListBaseEx<ParteAsistenciaList, ParteAsistenciaInfo>
	{

        #region Child Factory Methods

        private ParteAsistenciaList() { }

        public static ParteAsistenciaList NewList() { return new ParteAsistenciaList(); }

        private ParteAsistenciaList(IList<ParteAsistencia> lista)
        {
            Fetch(lista);
        }

        private ParteAsistenciaList(IDataReader reader)
        {
            Fetch(reader);
        }

        /// <summary>
        /// Builds a ParteAsistenciaList from a IList<!--<ParteAsistenciaInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>ParteAsistenciaList</returns>
        public static ParteAsistenciaList GetChildList(IList<ParteAsistenciaInfo> list)
        {
            ParteAsistenciaList flist = new ParteAsistenciaList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (ParteAsistenciaInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }


        /// <summary>
        /// Builds a ParteAsistenciaList from IList<!--<ParteAsistencia>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>ParteAsistenciaList</returns>
        public static ParteAsistenciaList GetChildList(IList<ParteAsistencia> list) { return new ParteAsistenciaList(list); }

        public static ParteAsistenciaList GetChildList(IDataReader reader) { return new ParteAsistenciaList(reader); }

        #endregion

        #region Root Factory Methods

        //  private ParteAsistenciaList() { }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>ParteAsistenciaList</returns>
        public static ParteAsistenciaList GetList(bool childs)
        {
            CriteriaEx criteria = ParteAsistencia.GetCriteria(ParteAsistencia.OpenSession());

            criteria.Childs = childs;
            if (nHManager.Instance.UseDirectSQL) criteria.Query = ParteAsistenciaList.SELECT();

            ParteAsistenciaList list = DataPortal.Fetch<ParteAsistenciaList>(criteria);
            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>ParteAsistenciaList</returns>
        public static ParteAsistenciaList GetList()
        {
            return GetList(true);
        }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static ParteAsistenciaList GetList(CriteriaEx criteria)
        {
            return ParteAsistenciaList.RetrieveList(typeof(ParteAsistencia), AppContext.ActiveSchema.Code, criteria);
        }

        /// <summary>
        /// Builds a ParteAsistenciaList from a IList<!--<ParteAsistenciaInfo>-->
        /// Doesn`t retrieve child data from DB.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>ParteAsistenciaList</returns>
        public static ParteAsistenciaList GetList(IList<ParteAsistenciaInfo> list)
        {
            ParteAsistenciaList flist = new ParteAsistenciaList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (ParteAsistenciaInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a ParteAsistenciaList from a IList<!--<ParteAsistencia>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>ParteAsistencia</returns>
        public static ParteAsistenciaList GetList(IList<ParteAsistencia> list)
        {
            ParteAsistenciaList flist = new ParteAsistenciaList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (ParteAsistencia item in list)
                    flist.AddItem(item.GetInfo());

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>ParteAsistenciaList</returns>
        public static ParteAsistenciaList GetPracticasList(bool childs)
        {
            CriteriaEx criteria = ParteAsistencia.GetCriteria(ParteAsistencia.OpenSession());

            criteria.Childs = childs;
            if (nHManager.Instance.UseDirectSQL) criteria.Query = ParteAsistencias.SELECT_PARTES_PRACTICAS();

            ParteAsistenciaList list = DataPortal.Fetch<ParteAsistenciaList>(criteria);
            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Devuelve una lista ordenada de todos los elementos
        /// </summary>
        /// <param name="sortProperty">Campo de ordenación</param>
        /// <param name="sortDirection">Sentido de ordenación</param>
        /// <returns>Lista ordenada de elementos</returns>
        public static SortedBindingList<ParteAsistenciaInfo> GetSortedList(string sortProperty,

            ListSortDirection sortDirection)
        {
            SortedBindingList<ParteAsistenciaInfo> sortedList =
                new SortedBindingList<ParteAsistenciaInfo>(GetList());
            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <param name="oid_promocion"></param>
        /// <returns></returns>
        public static ParteAsistenciaList GetByPromocion(long oid_promocion)
        {
            CriteriaEx criteria = ParteAsistencia.GetCriteria(ParteAsistencia.OpenSession());
            
            criteria.Childs = true;
            if (nHManager.Instance.UseDirectSQL) criteria.Query = ParteAsistenciaList.SELECT_BY_PROMOCION(oid_promocion);
            
            ParteAsistenciaList list = DataPortal.Fetch<ParteAsistenciaList>(criteria);
            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <param name="get_childs">retrieving the childs</param>
        /// <returns></returns>
        public static ParteAsistenciaList GetPartesFiltrados(long oid_promocion, DateTime fecha_inicio, DateTime fecha_fin)
        {
            ParteAsistenciaList lista = null;

            lista = GetByPromocion(oid_promocion);

            ParteAsistenciaList filtradas = new ParteAsistenciaList();

            filtradas.IsReadOnly = false;

            foreach (ParteAsistenciaInfo item in lista)
            {
                if (item.Fecha.Date >= fecha_inicio.Date
                    && item.Fecha.Date <= fecha_fin.Date)
                    filtradas.Add(item);
            }

            filtradas.IsReadOnly = true;

            return filtradas;
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<ParteAsistencia> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (ParteAsistencia item in lista)
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
                this.AddItem(ParteAsistenciaInfo.Get(reader, true));

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
                    IDataReader reader;
                    if (criteria.Query == string.Empty)
                    {
                        string query = ParteAsistenciaList.SELECT();
                        reader = nHManager.Instance.SQLNativeSelect(query);
                    }
                    else
                        reader = nHManager.Instance.SQLNativeSelect(criteria.Query);

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(ParteAsistenciaInfo.Get(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList<ParteAsistencia> list = criteria.List<ParteAsistencia>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (ParteAsistencia item in list)
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

                    foreach (ParteAsistencia item in list)
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
            string query = ParteAsistenciaInfo.SELECT(0) +
                           "ORDER BY PA.\"FECHA\" DESC , PA.\"HORA\" DESC ";

            return query;
        }

        public static string SELECT_BY_PROMOCION(long oid_promocion) { return ParteAsistencias.SELECT_BY_PROMOCION(oid_promocion, false); }

        public static string SELECT_BY_HORARIO(long oid_horario) { return ParteAsistencias.SELECT_BY_HORARIO(oid_horario, false); }

        #endregion
	
	}
}

