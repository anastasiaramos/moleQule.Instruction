using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Store;
using moleQule.Library.Common;

namespace moleQule.Library.Instruction
{

    /// <summary>
    /// ReadOnly Root Collection of Business Objects With Child Collection
    /// </summary>
    [Serializable()]
    public class InstructorList : ReadOnlyListBaseEx<InstructorList, InstructorInfo>
    {

        #region Business Methods

        #endregion

        #region Factory Methods

        public static InstructorList NewList() { return new InstructorList(); }
        private InstructorList() { }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <param name="get_childs">retrieving the childs</param>
        /// <returns></returns>
        public static InstructorList GetList(bool childs)
        {
            CriteriaEx criteria = Instructor.GetCriteria(Instructor.OpenSession());
            criteria.Childs = childs;
            criteria.Query = InstructorList.SELECT();

            //No criteria. Retrieve all de List
            InstructorList list = DataPortal.Fetch<InstructorList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <param name="get_childs">retrieving the childs</param>
        /// <returns></returns>
        public static InstructorList GetInstructoresHorariosList(long oid_promocion, DateTime fecha_inicio, DateTime fecha_fin)
        {
            CriteriaEx criteria = Instructor.GetCriteria(Instructor.OpenSession());
            criteria.Childs = false;
            criteria.Query = InstructorList.SELECT_INNER_JOIN_HORARIOS(oid_promocion);

            //No criteria. Retrieve all de List
            InstructorList list = DataPortal.Fetch<InstructorList>(criteria);

            list.LoadInstructor_PromocionChilds(oid_promocion, fecha_inicio, fecha_fin);
            list.LoadSubmoduloInstructorChilds(fecha_inicio, fecha_fin, false);

            CloseSession(criteria.SessionCode);

            //list.IsReadOnly = false;

            //for (int i = 0; i < list.Count - 1; i++)
            //{
            //    for (int j = i + 1; j < list.Count; j++)
            //    {
            //        if (list[i].Promociones.Count > list[j].Promociones.Count)
            //        {
            //            InstructorInfo aux;
            //            aux = list[i].Clone();
            //            list[i] = list[j].Clone();
            //            list[j] = aux;
            //        }
            //    }
            //}

            //list.IsReadOnly = true;

            return list;
        }

        /// <summary>
        /// Default call for GetList(bool get_childs)
        /// </summary>
        /// <returns></returns>
        public static InstructorList GetList()
        {
            return InstructorList.GetList(true);
        }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static InstructorList GetList(CriteriaEx criteria)
        {
            return InstructorList.RetrieveList(typeof(Instructor), AppContext.ActiveSchema.Code, criteria);
        }

        /// <summary>
        /// Builds a ClienteList from a IList<!--<ClienteInfo>-->.
        /// Doesn`t retrieve child data from DB.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static InstructorList GetList(IList<InstructorInfo> list)
        {
            InstructorList flist = new InstructorList();


            if (list.Count > 0)
            {
                flist.IsReadOnly = false;
                foreach (InstructorInfo item in list)
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
        public static SortedBindingList<InstructorInfo> GetSortedList(string sortProperty, ListSortDirection sortDirection)
        {
            return GetSortedList(sortProperty, sortDirection, false);
        }

        /// <summary>
        /// Devuelve una lista ordenada de todos los elementos
        /// </summary>
        /// <param name="sortProperty">Campo de ordenación</param>
        /// <param name="sortDirection">Sentido de ordenación</param>
        /// <returns>Lista ordenada de elementos</returns>
        public static SortedBindingList<InstructorInfo> GetSortedList(string sortProperty, ListSortDirection sortDirection, bool childs)
        {
            SortedBindingList<InstructorInfo> sortedList = new SortedBindingList<InstructorInfo>(GetList(childs));

            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }

        public void LoadInstructor_PromocionChilds(long oid_promocion, DateTime fecha_inicio, DateTime fecha_fin)
        {
            foreach (InstructorInfo item in this)
            {
                item.LoadInstructor_PromocionChilds(oid_promocion, fecha_inicio, fecha_fin);
            }
        }

        public void LoadSubmoduloInstructorChilds(DateTime fecha_inicio, DateTime fecha_fin, bool get_childs)
        {
            foreach (InstructorInfo item in this)
               item.LoadSubmodulosInstructor(fecha_inicio, fecha_fin, get_childs);
        }

        public void LoadChilds(Type type, bool get_childs)
        {
            foreach (InstructorInfo item in this)
            {
                item.LoadChilds(type, get_childs);
            }
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
                        this.AddItem(InstructorInfo.Get(reader, Childs));
                    IsReadOnly = true;
                }
                else
                {
                    IList list = criteria.List();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;
                        foreach (Instructor item in list)
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

        #region Commands

        public SortedDictionary<long, DisponibilidadInfo> GetDisponibilidadesProfesores(DateTime fecha_inicio)
        {
            SortedDictionary<long, DisponibilidadInfo> lista = new SortedDictionary<long, DisponibilidadInfo>();

            string instructores = string.Empty;

            foreach (InstructorInfo item in this)
                instructores += item.Oid.ToString() + ",";

            if (instructores != string.Empty)
            {
                instructores = instructores.Substring(0, instructores.Length - 1);

                //hacer select para traer disponibilidades de los profesores de la lista para la semana seleccionada
                string query = Disponibilidades.SELECT_BY_LIST(instructores, fecha_inicio);
                IDataReader reader = nHManager.Instance.SQLNativeSelect(query);

                while (reader.Read())
                {
                    DisponibilidadInfo dispo = DisponibilidadInfo.Get(reader, false);
                    if (!lista.ContainsKey(dispo.OidInstructor))
                        lista.Add(dispo.OidInstructor, dispo);
                }
            }
            

            return lista;
        }

        /// <summary>
        /// Función que devuelve una lista de sólo lectura de los instructores con capacidad
        /// para dar un submódulo concreto a la promoción que se indica
        /// </summary>
        /// <param name="oid_submodulo"></param>
        /// <param name="oid_promocion"></param>
        /// <returns></returns>
        public InstructorList GetListaCapacitados(long oid_submodulo, long oid_promocion)
        {
            InstructorList lista = new InstructorList();
            lista.IsReadOnly = false;
            foreach (InstructorInfo profesor in this)
            {
                foreach (Instructor_PromocionInfo promocion in profesor.Promociones)
                {
                    if (promocion.OidPromocion == oid_promocion)
                    {
                        foreach (Submodulo_Instructor_PromocionInfo sub in promocion.Submodulos)
                        {
                            if (sub.OidSubmodulo == oid_submodulo)
                            {
                                lista.AddItem(profesor);
                                break;
                            }
                        }
                    }
                }
            }
            lista.IsReadOnly = true;

            return lista;
        }

        public InstructorList GetAuditoresList()
        {
            InstructorList lista = new InstructorList();
            lista.IsReadOnly = false;
            foreach (InstructorInfo empleado in this)
            {
                if (empleado.HasProfile(Perfil.Auditor))
                    lista.Add(empleado);
            }
            lista.IsReadOnly = true;

            return lista;
        }

        public InstructorList GetResponsablesList()
        {
            InstructorList lista = new InstructorList();
            lista.IsReadOnly = false;
            foreach (InstructorInfo empleado in this)
            {
                if (empleado.HasProfile(Perfil.RespCalidad) ||
                    empleado.HasProfile(Perfil.RespInstruccion) ||
                    empleado.HasProfile(Perfil.RExamenes))
                    lista.Add(empleado);
            }
            lista.IsReadOnly = true;

            return lista;
        }

        /// <summary>
        /// Comprueba la disponibilidad de un profesor para una fecha y hora determinadas en base a 
        /// la disponibilidad que éste habrá rellenado previamente
        /// </summary>
        /// <param name="oid_instructor"></param>
        /// <param name="index"></param>
        /// <param name="profesores"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool EstaDisponible(long oid_instructor, int index, DateTime fecha)
        {
            InstructorInfo item = null;

            if (oid_instructor == 0) return false;

            item = this.GetItem(oid_instructor);

            if (item.Disponibilidades == null)
                item.LoadChilds(typeof(Disponibilidad), true);

            foreach (DisponibilidadInfo disp in item.Disponibilidades)
            {
                if (disp.FechaInicio.Date.Equals(fecha.Date))
                    return disp.Semana[index];
            }
            return false;
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
        private static string SELECT_INNER_JOIN_HORARIOS(long oid_promocion)
        {
            string instructor = nHManager.Instance.GetSQLTable(typeof(InstructorRecord));
            string instructor_promocion = nHManager.Instance.GetSQLTable(typeof(Instructor_PromocionRecord));
            string poid_instructor = nHManager.Instance.GetTableField(typeof(Instructor_PromocionRecord), "OidInstructor"); 
            string poid_promocion = nHManager.Instance.GetTableField(typeof(Instructor_PromocionRecord), "OidPromocion");
            string cb = nHManager.Instance.GetSQLTable(typeof(BankAccountRecord));
            string ip = nHManager.Instance.GetSQLTable(typeof(TaxRecord));

            string query;

            query = "SELECT A.*" +
                    "       ," + ((long)ETipoAcreedor.Instructor).ToString() + " AS \"TIPO_ACREEDOR\"" +
                    "       ,0 AS \"CUENTA_ASOCIADA\"" +
                    "       ,''/*IP.\"NOMBRE\"*/ AS \"IMPUESTO\"" +
                    "       ,0/*IP.\"PORCENTAJE\"*/ AS \"P_IMPUESTO\"," +
                    "       0 AS \"OID_MODULO\"," +
                    "       IPR.\"OID_INSTRUCTOR\", IPR.COUNT," +
                    "       '' AS \"TARJETA_ASOCIADA\"," +
                    "       0 AS \"OID_USER\"," +
                    "       '' AS \"USERNAME\"," + 
                    "       0 AS \"USER_STATUS\"," +
                    "       NULL AS \"CREATION_DATE\"," +
                    "       NULL AS \"LAST_LOGIN_DATE\"" +
                    " FROM " + instructor + " AS A," +
                        " (SELECT I_P.\"OID_INSTRUCTOR\", COUNT(\"OID_INSTRUCTOR\")" +
                        " FROM " + instructor_promocion + " AS I_P" +
                        " GROUP BY I_P.\"OID_INSTRUCTOR\") AS IPR," +
                        instructor_promocion + " AS P" +//," +
                        //ip + " AS IP" + //cb + " AS CB" +
                    " WHERE A.\"OID\" = IPR.\"OID_INSTRUCTOR\" AND A.\"ACTIVO\" = true " + 
                    " AND IPR.\"OID_INSTRUCTOR\" = P.\"OID_INSTRUCTOR\" AND P.\"OID_PROMOCION\" = " + 
                    oid_promocion.ToString() + //" AND IP.\"OID\" = A.\"OID_IMPUESTO\"" +// AND" +
                    //" A.\"OID_CUENTA_BANCARIA_ASOCIADA\" = CB.\"OID\"" +
                    " ORDER BY IPR.COUNT";

            return query;
        }

        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        private static string SELECT()
        {
            /*string instructor = nHManager.Instance.GetSQLTable(typeof(InstructorRecord));
            string instructor_promocion = nHManager.Instance.GetSQLTable(typeof(Instructor_PromocionRecord));
            string poid_instructor = nHManager.Instance.GetTableField(typeof(Instructor_Promocion), "OidInstructor");
            string poid_promocion = nHManager.Instance.GetTableField(typeof(Instructor_Promocion), "OidPromocion");
            string cb = nHManager.Instance.GetSQLTable(typeof(CuentaBancariaRecord));
            string ip = nHManager.Instance.GetSQLTable(typeof(ImpuestoRecord));

            string query;

            query = "SELECT A.*" +
                    "       ," + ((long)ETipoAcreedor.Instructor).ToString() + " AS \"TIPO_ACREEDOR\"" +
                    "       ,0 AS \"CUENTA_ASOCIADA\"" +
                    "       ,IP.\"NOMBRE\" AS \"IMPUESTO\"" +
                    "       ,IP.\"PORCENTAJE\" AS \"P_IMPUESTO\"," +
                    "       0 AS \"OID_MODULO\"" +
                    " FROM " + instructor + " AS A," +
                        ip + " AS IP" +//, " + cb + " AS CB" +
                    " WHERE IP.\"OID\" = A.\"OID_IMPUESTO\"";// +
                    //"  AND  A.\"OID_CUENTA_BANCARIA_ASOCIADA\" = CB.\"OID\"";

            return query;*/
            return InstructorInfo.SELECT(0);
        }

        #endregion

    }
}

