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
	public class PromocionList : ReadOnlyListBaseEx<PromocionList, PromocionInfo>
    {

        #region Business Methods

        /// <summary>
        /// Añade un elemento en blanco para que funcionen los combobox
        /// </summary>
        public void AddEmptyItem()
        {
            IsReadOnly = false;

            Promocion newItem = Promocion.New();
            newItem.Oid = 0;
            newItem.Nombre = string.Empty;
            this.Insert(0, newItem.GetInfo(false));

            IsReadOnly = true;
        }

        #endregion

        #region Child Factory Methods

        private PromocionList() { }

        public static PromocionList NewList() { return new PromocionList(); }

        private PromocionList(IList<Promocion> lista)
        {
            Fetch(lista);
        }

        private PromocionList(IDataReader reader)
        {
            Fetch(reader);
        }

        /// <summary>
        /// Builds a PromocionList from a IList<!--<PromocionInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>PromocionList</returns>
        public static PromocionList GetChildList(IList<PromocionInfo> list)
        {
            PromocionList flist = new PromocionList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (PromocionInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }


        /// <summary>
        /// Builds a PromocionList from IList<!--<Promocion>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>PromocionList</returns>
        public static PromocionList GetChildList(IList<Promocion> list) { return new PromocionList(list); }

        public static PromocionList GetChildList(IDataReader reader) { return new PromocionList(reader); }
        public static PromocionList GetChildList(AlumnoInfo parent, bool childs)
        {
            CriteriaEx criteria = Promocion.GetCriteria(Promocion.OpenSession());
            criteria.Query = PromocionList.SELECT_BY_ALUMNO(parent);
            criteria.Childs = childs;

            PromocionList list = DataPortal.Fetch<PromocionList>(criteria);

            CloseSession(criteria.SessionCode);
            return list;
        }

        #endregion

        #region Root Factory Methods

        //  private PromocionList() { }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>PromocionList</returns>
        public static PromocionList GetList(bool childs)
        {
            CriteriaEx criteria = Promocion.GetCriteria(Promocion.OpenSession());
            criteria.Childs = childs;
            criteria.Query = PromocionList.SELECT();

            PromocionList list = DataPortal.Fetch<PromocionList>(criteria);

            CloseSession(criteria.SessionCode);
            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>PromocionList</returns>
        public static PromocionList GetByModuloList(long oid_modulo, bool childs)
        {
            CriteriaEx criteria = Promocion.GetCriteria(Promocion.OpenSession());
            criteria.Childs = childs;
            criteria.Query = PromocionList.SELECT_BY_MODULO(oid_modulo);

            PromocionList list = DataPortal.Fetch<PromocionList>(criteria);

            CloseSession(criteria.SessionCode);
            return list;
        }

        /// <summary>
        /// Default call for GetList(bool get_childs)
        /// </summary>
        /// <returns></returns>
        public static PromocionList GetList()
        {
            return PromocionList.GetList(true);
        }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static PromocionList GetList(CriteriaEx criteria)
        {
            return PromocionList.RetrieveList(typeof(Promocion), AppContext.ActiveSchema.Code, criteria);
        }

        /// <summary>
        /// Builds a PromocionList from a IList<!--<PromocionInfo>-->
        /// Doesn`t retrieve child data from DB.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>PromocionList</returns>
        public static PromocionList GetList(IList<PromocionInfo> list)
        {
            PromocionList flist = new PromocionList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (PromocionInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a PromocionList from a IList<!--<Promocion>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Promocion</returns>
        public static PromocionList GetList(IList<Promocion> list)
        {
            PromocionList flist = new PromocionList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (Promocion item in list)
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
        public static SortedBindingList<PromocionInfo> GetSortedList(string sortProperty,
                                                                    ListSortDirection sortDirection)
        {
            SortedBindingList<PromocionInfo> sortedList =
                new SortedBindingList<PromocionInfo>(GetList(false));
            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }


        /// <summary>
        /// Obtiene el objeto a partir de la lista clave-valor
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        //public override PromocionInfo GetItem(long oid) { return (PromocionInfo)HashList[oid]; }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Promocion> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (Promocion item in lista)
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
                this.AddItem(Promocion.GetChild(reader).GetInfo());

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

                    //Promocion.DoLOCK( Session());

                    //IDataReader reader = Promocions.SELECT( Session());
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(criteria.Query, Session());

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(PromocionInfo.Get(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList<Promocion> list = criteria.List<Promocion>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (Promocion item in list)
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

                    foreach (Promocion item in list)
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

        public static string SELECT_BY_MODULO(long oid_modulo)
        {
            string clase_teorica = nHManager.Instance.GetSQLTable(typeof(ClaseTeoricaRecord));
            string plan_estudios = nHManager.Instance.GetSQLTable(typeof(PlanEstudiosRecord));
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string promocion = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));

            string query = "SELECT DISTINCT PR.* " +
                        "FROM " + plan_estudios + " AS P " +
                        "INNER JOIN " + clase_teorica + " AS C ON (C.\"OID_PLAN\" = P.\"OID\") " +
                        "INNER JOIN " + modulo + " AS M ON (C.\"OID_MODULO\" = M.\"OID\") " +
                        "INNER JOIN " + promocion + " AS PR ON (PR.\"OID_PLAN\" = P.\"OID\") " +
                        "WHERE M.\"OID\" = " + oid_modulo.ToString() + "  " +
                        "ORDER BY PR.\"NUMERO\";";

            return query;
        }

        public static string SELECT_BY_ALUMNO(AlumnoInfo alumno)
        {
            string clase_teorica = nHManager.Instance.GetSQLTable(typeof(ClaseTeoricaRecord));
            string plan_estudios = nHManager.Instance.GetSQLTable(typeof(PlanEstudiosRecord));
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string promocion = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));
            string alumno_promocion = nHManager.Instance.GetSQLTable(typeof(Alumno_Promocion));

            string query = "SELECT DISTINCT PR.* " +
                        "FROM " + plan_estudios + " AS P " +
                        "INNER JOIN " + clase_teorica + " AS C ON (C.\"OID_PLAN\" = P.\"OID\") " +
                        "INNER JOIN " + modulo + " AS M ON (C.\"OID_MODULO\" = M.\"OID\") " +
                        "INNER JOIN " + promocion + " AS PR ON (PR.\"OID_PLAN\" = P.\"OID\") " +
                        "INNER JOIN " + alumno_promocion + " AS AE ON (AP.\"OID_PROMOCION\" = PR.\"OID\") " +
                        "WHERE AP.\"OID_ALUMNO\" = " + alumno.Oid.ToString() + "  " +
                        "ORDER BY PR.\"NUMERO\";";

            return query;
        }
        public static string SELECT() { return Promocion.SELECT(new QueryConditions(), false); }

        #endregion

    }
}

