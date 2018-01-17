using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;


using Csla;
using moleQule.Library.CslaEx;

using NHibernate;

using moleQule.Library;

namespace moleQule.Library.Instruction
{
    /// <summary>
    /// ReadOnly Root Collection of Business Objects With Child Collection
    /// </summary>
    [Serializable()]
    public class Submodulo_Instructor_PromocionList : ReadOnlyListBaseEx<Submodulo_Instructor_PromocionList, Submodulo_Instructor_PromocionInfo>
    {
        #region Business Methods

        public Submodulo_Instructor_PromocionInfo GetItemBySubmoduloPromocion(long oid_submodulo, long oid_promocion)
        {
            foreach (Submodulo_Instructor_PromocionInfo item in this)
                if ((item.OidSubmodulo == oid_submodulo) && (item.OidPromocion == oid_promocion))
                    return item;

            return null;
        }

        #endregion

        #region Factory Methods

        private Submodulo_Instructor_PromocionList() { }

        private Submodulo_Instructor_PromocionList(IList<Submodulo_Instructor_Promocion> lista)
        {
            Fetch(lista);
        }

        private Submodulo_Instructor_PromocionList(IDataReader reader)
        {
            Fetch(reader);
        }

        public static Submodulo_Instructor_PromocionList GetList()
        {
            CriteriaEx criteria = Submodulo_Instructor_Promocion.GetCriteria(Submodulo_Instructor_Promocion.OpenSession());
            criteria.Query = Submodulo_Instructor_PromocionList.SELECT();

            //No criteria. Retrieve all de List
            Submodulo_Instructor_PromocionList list = DataPortal.Fetch<Submodulo_Instructor_PromocionList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        public static Submodulo_Instructor_PromocionList GetListByInstructor(long oid_instructor)
        {
            CriteriaEx criteria = Submodulo_Instructor_Promocion.GetCriteria(Submodulo_Instructor_Promocion.OpenSession());
            criteria.Query = Submodulo_Instructor_PromocionList.SELECT_BY_INSTRUCTOR(oid_instructor);

            //No criteria. Retrieve all de List
            Submodulo_Instructor_PromocionList list = DataPortal.Fetch<Submodulo_Instructor_PromocionList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        public static Submodulo_Instructor_PromocionList GetChildList(IList<Submodulo_Instructor_PromocionInfo> list)
        {
            Submodulo_Instructor_PromocionList flist = new Submodulo_Instructor_PromocionList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (Submodulo_Instructor_PromocionInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        public static Submodulo_Instructor_PromocionList GetChildList(IList<Submodulo_Instructor_Promocion> list) { return new Submodulo_Instructor_PromocionList(list); }

        public static Submodulo_Instructor_PromocionList GetChildList(IDataReader reader) { return new Submodulo_Instructor_PromocionList(reader); }

        public static SortedBindingList<Submodulo_Instructor_PromocionInfo> GetInstructoresCapacitados(long oid_submodulo)
        {
            Submodulo_Instructor_PromocionList lista = Submodulo_Instructor_PromocionList.GetList();
            Submodulo_Instructor_PromocionList instructores = new Submodulo_Instructor_PromocionList();

            foreach (Submodulo_Instructor_PromocionInfo info in lista)
            {
                if (info.OidSubmodulo == oid_submodulo)
                    instructores.AddItem(info);
            }

            SortedBindingList<Submodulo_Instructor_PromocionInfo> list = lista.ToSortedList("Prioridad", System.ComponentModel.ListSortDirection.Ascending);
            return list;
        }
        
        public Submodulo_Instructor_PromocionList GetChildList(long oid_promocion)
        {
            Submodulo_Instructor_PromocionList lista = new Submodulo_Instructor_PromocionList();

            lista.IsReadOnly = false;

            foreach (Submodulo_Instructor_PromocionInfo item in this)
            {
                if (item.OidPromocion == oid_promocion)
                    lista.AddItem(item);
            }

            lista.IsReadOnly = true;

            return lista;
        }

        public static Submodulo_Instructor_PromocionList GetPromocionList(long oid_promocion)
        {
            string query = Submodulos_Instructores_Promociones.SELECT_BY_PROMOCION(oid_promocion);
            IDataReader reader = nHManager.Instance.SQLNativeSelect(query);
            Submodulo_Instructor_PromocionList submodulos = Submodulo_Instructor_PromocionList.GetChildList(reader);

            if (submodulos == null)
                return null;
            else
                return submodulos;
        }
        
        public Submodulo_Instructor_PromocionList GetTitulares(long oid_submodulo)
        {
            Submodulo_Instructor_PromocionList lista = new Submodulo_Instructor_PromocionList();

            lista.IsReadOnly = false;

            foreach (Submodulo_Instructor_PromocionInfo item in this)
            {
                if (item.OidSubmodulo == oid_submodulo && item.Prioridad == 1)
                    lista.AddItem(item);
            }

            lista.IsReadOnly = true;

            return lista;
        }

        #endregion

        #region Data Access

        // called to copy objects data from list
        private void Fetch(IList<Submodulo_Instructor_Promocion> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (Submodulo_Instructor_Promocion item in lista)
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
            {
                Submodulo_Instructor_PromocionInfo item = Submodulo_Instructor_PromocionInfo.Get(reader, false);
                this.AddItem(item);
            }

            IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }

        // called to retrieve data from db
        protected override void Fetch(CriteriaEx criteria)
        {
            this.RaiseListChangedEvents = false;

            SessionCode = criteria.SessionCode;
            Childs = criteria.Childs;

            try
            {
                if (nHMng.UseDirectSQL)
                {
                    IDataReader reader;
                    IEnumerable list = criteria.IterateExpressionEntries();

                    reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(Submodulo_Instructor_PromocionInfo.Get(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList<Submodulo_Instructor_Promocion> list = criteria.List<Submodulo_Instructor_Promocion>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (Submodulo_Instructor_Promocion item in list)
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

        #region SQL 
        
        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public static string SELECT()
        {
            string tabla = nHManager.Instance.GetSQLTable(typeof(Submodulo_Instructor_PromocionRecord));
            string s = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
            string m = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string p = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));
            string query;

            query = "SELECT SIP.*," +
                    "       COALESCE(M.\"NUMERO\",0) || ' ' || COALESCE(M.\"TEXTO\",'') AS \"MODULO\", " +
                    "       COALESCE(S.\"CODIGO\",'') || ' ' || COALESCE(S.\"TEXTO\",'') AS \"SUBMODULO\", " +
                    "       COALESCE(P.\"NUMERO\",'') || ' ' || COALESCE(P.\"NOMBRE\",'') AS \"PROMOCION\" , " +
                    "       M.\"OID\" AS \"OID_MODULO\"" +
                    " FROM " + tabla + " AS SIP" +
                    " LEFT JOIN " + s + " AS S ON SIP.\"OID_SUBMODULO\" = S.\"OID\"" +
                    " LEFT JOIN " + m + " AS M ON S.\"OID_MODULO\" = M.\"OID\"" +
                    " LEFT JOIN " + p + " AS P ON P.\"OID\" = SIP.\"OID_PROMOCION\"" +
                    " ORDER BY M.\"NUMERO_ORDEN\", S.\"CODIGO_ORDEN\"";

            return query;
        }

        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public static string SELECT_BY_INSTRUCTOR(long oid_instructor)
        {
            string tabla = nHManager.Instance.GetSQLTable(typeof(Submodulo_Instructor_PromocionRecord));
            string s = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
            string m = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string p = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));
            string query;

            query = "SELECT SIP.*," +
                    "       COALESCE(M.\"NUMERO\",0) || ' ' || COALESCE(M.\"TEXTO\",'') AS \"MODULO\", " +
	                "       COALESCE(S.\"CODIGO\",'') || ' ' || COALESCE(S.\"TEXTO\",'') AS \"SUBMODULO\", " +
	                "       COALESCE(P.\"NUMERO\",'') || ' ' || COALESCE(P.\"NOMBRE\",'') AS \"PROMOCION\" , " + 
                    "       M.\"OID\" AS \"OID_MODULO\"" +
                    " FROM " + tabla + " AS SIP" +
                    " LEFT JOIN " + s + " AS S ON SIP.\"OID_SUBMODULO\" = S.\"OID\"" +
                    " LEFT JOIN " + m + " AS M ON S.\"OID_MODULO\" = M.\"OID\"" +
                    " LEFT JOIN " + p + " AS P ON P.\"OID\" = SIP.\"OID_PROMOCION\"" +
                    " WHERE SIP.\"OID_INSTRUCTOR\" = " + oid_instructor.ToString() +
                    " ORDER BY P.\"NUMERO\", M.\"NUMERO_ORDEN\", S.\"CODIGO_ORDEN\"";

            return query;

        }

        #endregion

    }
}

