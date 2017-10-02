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
    public class SesionList : ReadOnlyListBaseEx<SesionList, SesionInfo>
    {

        #region Child Factory Methods

        private SesionList() { }

        private SesionList(IList<Sesion> lista)
        {
            Fetch(lista);
        }

        private SesionList(IDataReader reader)
        {
            Fetch(reader);
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <param name="get_childs">retrieving the childs</param>
        /// <returns>RedList</returns>
        public static SesionList GetChildList(bool childs)
        {
            CriteriaEx criteria = Sesion.GetCriteria(Sesion.OpenSession());
            criteria.Childs = childs;
            criteria.Query = SesionList.SELECT();

            //No criteria. Retrieve all de List
            SesionList list = DataPortal.Fetch<SesionList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }


        /// <summary>
        /// Builds a SesionList from a IList<!--<SesionInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>SesionList</returns>
        public static SesionList GetChildList(IList<SesionInfo> list)
        {
            SesionList flist = new SesionList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (SesionInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }


        /// <summary>
        /// Builds a SesionList from IList<!--<Sesion>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>SesionList</returns>
        public static SesionList GetChildList(IList<Sesion> list) { return new SesionList(list); }

        public static SesionList GetChildList(IDataReader reader) { return new SesionList(reader); }

        #endregion

        #region Root Factory Methods

        //  private SesionList() { }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>SesionList</returns>
        public static SesionList GetList(bool childs)
        {
            CriteriaEx criteria = Sesion.GetCriteria(Sesion.OpenSession());
            criteria.Childs = childs;
            //No criteria. Retrieve all de List
            SesionList list = DataPortal.Fetch<SesionList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }


        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>SesionList</returns>
        public static SesionList GetSesionesList()
        {
            CriteriaEx criteria = Sesion.GetCriteria(Sesion.OpenSession());
            criteria.Childs = false;
            criteria.Query = Sesions.SELECT_SESIONES_ORDENADAS();
            //No criteria. Retrieve all de List
            SesionList list = DataPortal.Fetch<SesionList>(criteria);

            CloseSession(criteria.SessionCode);

            SesionList sesiones = new SesionList();
            ClaseTeoricaList teoricas = ClaseTeoricaList.GetList();
            ClasePracticaList practicas = ClasePracticaList.GetList();
            ClaseExtraList extras = ClaseExtraList.GetList();
            int count = 0;
            long oid_modulo = 0;

            sesiones.IsReadOnly = false;

            foreach (SesionInfo item in list)
            {
                if (item.OidClaseTeorica > 0
                    || item.OidClasePractica > 0
                    || item.OidClaseExtra > 0)
                {
                    long oid_modulo_item = 0;
                    if (item.OidClasePractica != 0)
                        oid_modulo_item = practicas.GetItem(item.OidClasePractica).OidModulo;
                    if (item.OidClaseTeorica != 0)
                        oid_modulo_item = teoricas.GetItem(item.OidClaseTeorica).OidModulo;
                    if (item.OidClaseExtra != 0)
                        oid_modulo_item = extras.GetItem(item.OidClaseExtra).OidModulo;

                    if (oid_modulo_item > 0)
                    {
                        if (count == 0)
                        {
                            sesiones.AddItem(item);
                            oid_modulo = oid_modulo_item;
                            count++;
                        }
                        else
                        {
                            SesionInfo ultima = sesiones[sesiones.Count - 1];

                            if (ultima.OidHorario == item.OidHorario
                                && ultima.Fecha.Date.Equals(item.Fecha.Date)
                                && ultima.Hora.AddHours(count).Hour.Equals(item.Hora.Hour)
                                && ultima.OidProfesor == item.OidProfesor
                                && oid_modulo_item == oid_modulo
                                && ((ultima.OidClasePractica != 0 && item.OidClasePractica != 0)
                                || (ultima.OidClaseTeorica != 0 && item.OidClaseTeorica != 0)
                                || (ultima.OidClaseExtra != 0 && item.OidClaseExtra != 0)))
                            {
                                count++;
                                if (count == 3) count = 0;
                            }
                            else
                            {
                                sesiones.AddItem(item);
                                oid_modulo = oid_modulo_item;
                                count = 1;
                            }

                        }
                    }
                }
            }
            sesiones.IsReadOnly = true;

            return sesiones;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>SesionList</returns>
        public static SesionList GetList()
        {
            return GetList(true);
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>HorarioList</returns>
        public static SesionList GetSesionesPromocionList(long oid_promocion, long oid_plan, bool childs)
        {
            CriteriaEx criteria = Sesion.GetCriteria(Sesion.OpenSession());
            criteria.Childs = childs;
            criteria.Query = Sesions.SELECT_SESIONES_PROGRAMADAS(oid_plan, oid_promocion);
            //No criteria. Retrieve all de List
            SesionList list = DataPortal.Fetch<SesionList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static SesionList GetList(CriteriaEx criteria)
        {
            return SesionList.RetrieveList(typeof(Sesion), AppContext.ActiveSchema.Code, criteria);
        }

        /// <summary>
        /// Builds a SesionList from a IList<!--<SesionInfo>-->
        /// Doesn`t retrieve child data from DB.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>SesionList</returns>
        public static SesionList GetList(IList<SesionInfo> list)
        {
            SesionList flist = new SesionList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (SesionInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a SesionList from a IList<!--<Sesion>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Sesion</returns>
        public static SesionList GetList(IList<Sesion> list)
        {
            SesionList flist = new SesionList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (Sesion item in list)
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
        public static SortedBindingList<SesionInfo> GetSortedList(string sortProperty,
                                                                    ListSortDirection sortDirection)
        {
            SortedBindingList<SesionInfo> sortedList =
                new SortedBindingList<SesionInfo>(GetList());
            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Sesion> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (Sesion item in lista)
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
                this.AddItem(Sesion.GetChild(reader).GetInfo());

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
                    IDataReader reader = null;
                    
                    reader = nHManager.Instance.SQLNativeSelect(criteria.Query, Session());

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(SesionInfo.Get(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList<Sesion> list = criteria.List<Sesion>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (Sesion item in list)
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

                    foreach (Sesion item in list)
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

        public static string SELECT_BY_HORARIO(long oid_horario) { return Sesions.SELECT_BY_HORARIO(oid_horario, false); }
        
        public static string SELECT() { return Sesion.SELECT(new QueryConditions(), false); }

        #endregion
    }
}

