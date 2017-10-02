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
    public class ClasePracticaList : ReadOnlyListBaseEx<ClasePracticaList, ClasePracticaInfo>
    {

        #region Child Factory Methods

        public ClasePracticaList() { }

        public static ClasePracticaList NewList() { return new ClasePracticaList(); }

        private ClasePracticaList(IList<ClasePractica> lista)
        {
            Fetch(lista);
        }

        private ClasePracticaList(IDataReader reader)
        {
            Fetch(reader);
        }

        /// <summary>
        /// Builds a ClasePracticaList from a IList<!--<ClasePracticaInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>ClasePracticaList</returns>
        public static ClasePracticaList GetChildList(IList<ClasePracticaInfo> list)
        {
            ClasePracticaList flist = new ClasePracticaList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (ClasePracticaInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }


        /// <summary>
        /// Builds a ClasePracticaList from IList<!--<ClasePractica>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>ClasePracticaList</returns>
        public static ClasePracticaList GetChildList(IList<ClasePractica> list) { return new ClasePracticaList(list); }

        public static ClasePracticaList GetChildList(IDataReader reader) { return new ClasePracticaList(reader); }

        #endregion

        #region Root Factory Methods


        /// <summary>
        /// Obtiene el objeto a partir de la lista clave-valor
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        //public override ClasePracticaInfo GetItem(long oid) { return (ClasePracticaInfo)HashList[oid]; }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>ClasePracticaList</returns>
        public static ClasePracticaList GetList()
        {
            return GetList(true);
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>ClasePracticaList</returns>
        public static ClasePracticaList GetList(bool childs)
        {
            CriteriaEx criteria = ClasePractica.GetCriteria(ClasePractica.OpenSession());
            criteria.Childs = childs;

            //No criteria. Retrieve all de List
            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = ClasePracticas.SELECT();
            ClasePracticaList list = DataPortal.Fetch<ClasePracticaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        public static ClasePracticaList GetListBySubmodulo(long oid)
        {
            CriteriaEx criteria = ClasePractica.GetCriteria(ClasePractica.OpenSession());

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = ClasePracticaList.SELECT_BY_SUBMODULO(oid);

            ClasePracticaList list = DataPortal.Fetch<ClasePracticaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>ClasePracticaList</returns>
        public static ClasePracticaList GetClasesPlanList(long oid_plan)
        {
            CriteriaEx criteria = ClasePractica.GetCriteria(ClasePractica.OpenSession());
            criteria.Childs = false;

            //No criteria. Retrieve all de List
            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = ClasePracticas.SELECT_CLASES_PRACTICAS_PLAN(oid_plan);
            ClasePracticaList list = DataPortal.Fetch<ClasePracticaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>ClasePracticaList</returns>
        public static ClasePracticaList GetClasesOrdenadasPlanList(long oid_plan, long oid_promocion = 0, int grupo = 0)
        {
            CriteriaEx criteria = ClasePractica.GetCriteria(ClasePractica.OpenSession());

            //No criteria. Retrieve all de List
            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = ClasePracticas.SELECT_CLASES_PRACTICAS_PLAN_ORDENADAS(oid_plan, oid_promocion, grupo);
            ClasePracticaList list = DataPortal.Fetch<ClasePracticaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>ClasePracticaList</returns>
        public static ClasePracticaList GetDisponiblesList(long oid_plan, long oid_promocion, long oid_horario, long grupo)
        {
            CriteriaEx criteria = ClasePractica.GetCriteria(ClasePractica.OpenSession());
            criteria.Childs = false;

            //No criteria. Retrieve all de List
            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = ClasePracticas.SELECT_CLASES_PRACTICAS_DISPONIBLES(oid_plan, oid_promocion, oid_horario, grupo);
            ClasePracticaList list = DataPortal.Fetch<ClasePracticaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>ClasePracticaList</returns>
        public static ClasePracticaList GetImpartidasList(long oid_promocion, DateTime fecha, long grupo)
        {
            CriteriaEx criteria = ClasePractica.GetCriteria(ClasePractica.OpenSession());
            criteria.Childs = false;

            //No criteria. Retrieve all de List
            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = ClasePractica.SELECT_IMPARTIDAS(oid_promocion, fecha, grupo,false);
            ClasePracticaList list = DataPortal.Fetch<ClasePracticaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>ClasePracticaList</returns>
        public static ClasePracticaList GetNoImpartidasList(long oid_plan, long oid_promocion, long grupo = 0)
        {
            CriteriaEx criteria = ClasePractica.GetCriteria(ClasePractica.OpenSession());

            //No criteria. Retrieve all de List
            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = ClasePracticas.SELECT_CLASES_PRACTICAS_NO_IMPARTIDAS(oid_plan, oid_promocion, grupo);
            ClasePracticaList list = DataPortal.Fetch<ClasePracticaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>ClasePracticaList</returns>
        public static ClasePracticaList GetProgramadasList(long oid_plan, long oid_promocion)
        {
            CriteriaEx criteria = ClasePractica.GetCriteria(ClasePractica.OpenSession());

            //No criteria. Retrieve all de List
            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = ClasePracticas.SELECT_CLASES_PRACTICAS_PROGRAMADAS(oid_plan, oid_promocion);
            ClasePracticaList list = DataPortal.Fetch<ClasePracticaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }
        
        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static ClasePracticaList GetList(CriteriaEx criteria)
        {
            return ClasePracticaList.RetrieveList(typeof(ClasePractica), AppContext.ActiveSchema.Code, criteria);
        }

        /// <summary>
        /// Builds a ClasePracticaList from a IList<!--<ClasePracticaInfo>-->
        /// Doesn`t retrieve child data from DB.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>ClasePracticaList</returns>
        public static ClasePracticaList GetList(IList<ClasePracticaInfo> list)
        {
            ClasePracticaList flist = new ClasePracticaList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (ClasePracticaInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a ClasePracticaList from a IList<!--<ClasePractica>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>ClasePractica</returns>
        public static ClasePracticaList GetList(IList<ClasePractica> list)
        {
            ClasePracticaList flist = new ClasePracticaList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (ClasePractica item in list)
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
        public static SortedBindingList<ClasePracticaInfo> GetSortedList(string sortProperty,
                                                                    ListSortDirection sortDirection)
        {
            SortedBindingList<ClasePracticaInfo> sortedList =
                new SortedBindingList<ClasePracticaInfo>(GetList());
            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }

        private static int CompareClasesbyOrder(ClasePracticaInfo x, ClasePracticaInfo y)
        {
            if (x.CodigoOrden == y.CodigoOrden)
            {
                if (x.OrdenTerciario == y.OrdenTerciario)
                {
                    if (x.Grupo == y.Grupo)
                        return 0;
                    else
                    {
                        if (x.Grupo < y.Grupo)
                            return -1;
                        else
                            return 1;
                    }
                }
                else
                {
                    if (x.OrdenTerciario < y.OrdenTerciario)
                        return 1;
                    else
                        return -1;
                }
            }
            else
            {
                if (x.CodigoOrden.CompareTo(y.CodigoOrden) == 1)
                    return 1;
                else
                    return -1;
            }
        }

        public List<ClasePracticaInfo> OrdenaLista()
        {
            List<ClasePracticaInfo> lista = new List<ClasePracticaInfo>();

            foreach (ClasePracticaInfo item in this)
                lista.Add(item);

            lista.Sort(CompareClasesbyOrder);

            return lista;
        }

        /// <summary>
        /// Pega dos listas
        /// </summary>
        /// <param name="criteria">Filtro</param>
        /// <returns>Lista</returns>
        public static ClasePracticaList Merge(ClasePracticaList list1, ClasePracticaList list2)
        {
            ClasePracticaList list = new ClasePracticaList();

            list.IsReadOnly = false;

            foreach (ClasePracticaInfo item in list1)
                list.Add(item);

            foreach (ClasePracticaInfo item in list2)
                list.Add(item);

            list.IsReadOnly = true;

            return list;
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<ClasePractica> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (ClasePractica item in lista)
                this.AddItem(item.GetInfo());

            IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }

        // called to copy objects data from list
        private void Fetch(IDataReader reader)
        {
            while (reader.Read())
                this.AddItem(ClasePractica.GetChild(reader).GetInfo());

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

                    while (reader.Read())
                        this.AddItem(ClasePracticaInfo.Get(reader, Childs));
                }
                else
                {
                    IList<ClasePractica> list = criteria.List<ClasePractica>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (ClasePractica item in list)
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
        public List<ClasePracticaInfo> GetClasesOrdenadas()
        {
            SubmoduloList submodulos = SubmoduloList.GetList(false);
            ModuloList modulos = ModuloList.GetList(false);
            List<ClasePracticaInfo> clases = new List<ClasePracticaInfo>();

            foreach (ClasePracticaInfo clase in this)
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
                        ClasePracticaInfo aux = clases[i];
                        clases[i] = clases[j];
                        clases[j] = aux;
                    }
                    else
                    {
                        if (codigo_i == codigo_j
                            && clases[i].OrdenTerciario > clases[j].OrdenTerciario)
                        {
                            ClasePracticaInfo aux = clases[i];
                            clases[i] = clases[j];
                            clases[j] = aux;
                        }

                    }
                }
            }

            return clases;
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

                    foreach (ClasePractica item in list)
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

        public static string SELECT_BY_SUBMODULO(long oid_submodulo) { return ClasePracticas.SELECT_BY_SUBMODULO(oid_submodulo, false); }

        #endregion
    }
}

