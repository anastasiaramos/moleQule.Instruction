using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

using Csla;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;
using moleQule.Library.Invoice;

namespace moleQule.Library.Instruction
{
	
	/// <summary>
	/// ReadOnly Business Object Child Collection
	/// </summary>
    [Serializable()]
	public class CursoClienteList : ReadOnlyListBaseEx<CursoClienteList, CursoClienteInfo>
	{		
		 
		#region Common Factory Methods
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Objet creation require use of factory methods
        /// </remarks>
		private CursoClienteList() {}
				
		/// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Objet creation require use of factory methods
        /// </remarks>
		private CursoClienteList(IList<CursoClienteInfo> list, bool retrieve_childs)
        {
			Childs = retrieve_childs;
            Fetch(list);
        }
		
		#endregion
      
        #region Root Factory Methods

        /// <summary>
        /// Default call for GetList(bool retrieve_childs)
        /// </summary>
        /// <returns></returns>
        public static CursoClienteList GetList()
        {
            return CursoClienteList.GetList(true);
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <param name="retrieve_childs">Retrieving the childs</param>
        /// <returns></returns>
        public static CursoClienteList GetList(bool retrieve_childs)
        {
            CriteriaEx criteria = Curso.GetCriteria(Curso.OpenSession());
            criteria.Childs = retrieve_childs;

            //No criteria. Retrieve all de List

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = CursoClienteList.SELECT();

            CursoClienteList list = DataPortal.Fetch<CursoClienteList>(criteria);
            CloseSession(criteria.SessionCode);
            return list;
        }

        public static CursoClienteList GetListByCliente(long oid_cliente)
        {
            CriteriaEx criteria = Curso.GetCriteria(Curso.OpenSession());
            criteria.Childs = false;

            //No criteria. Retrieve all de List

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = CursoClienteList.SELECT_BY_CLIENTE(oid_cliente);

            CursoClienteList list = DataPortal.Fetch<CursoClienteList>(criteria);
            CloseSession(criteria.SessionCode);
            return list;
        }

        public static CursoClienteList GetListByCurso(long oid_curso)
        {
            CriteriaEx criteria = Curso.GetCriteria(Curso.OpenSession());
            criteria.Childs = false;

            //No criteria. Retrieve all de List

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = CursoClienteList.SELECT_BY_CURSO(oid_curso);

            CursoClienteList list = DataPortal.Fetch<CursoClienteList>(criteria);
            CloseSession(criteria.SessionCode);
            return list;
        }

        /// <summary>
        /// Construye la lista
        /// </summary>
        /// <param name="list">IList origen</param>
        /// <returns>Lista de objetos de solo lectura</returns>
        /// <remarks>NO OBTIENE LOS HIJOS SI EL OBJETO NO LOS TIENE CARGADOS</remarks>
        public static CursoClienteList GetList(IList<CursoClienteInfo> list) { return new CursoClienteList(list, false); }

        /// <summary>
        /// Devuelve una lista ordenada de todos los elementos
        /// </summary>
        /// <param name="sortProperty">Campo de ordenación</param>
        /// <param name="sortDirection">Sentido de ordenación</param>
        /// <returns>Lista ordenada de elementos</returns>
        public static SortedBindingList<CursoClienteInfo> GetSortedList(string sortProperty, ListSortDirection sortDirection)
        {
            SortedBindingList<CursoClienteInfo> sortedList = new SortedBindingList<CursoClienteInfo>(GetList());

            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }

        /// <summary>
        /// Devuelve una lista ordenada de todos los elementos y sus hijos
        /// </summary>
        /// <param name="sortProperty">Campo de ordenación</param>
        /// <param name="sortDirection">Sentido de ordenación</param>
        /// <param name="childs">Traer hijos</param>
        /// <returns>Lista ordenada de elementos</returns>
        public static SortedBindingList<CursoClienteInfo> GetSortedList(string sortProperty, ListSortDirection sortDirection, bool childs)
        {
            SortedBindingList<CursoClienteInfo> sortedList = new SortedBindingList<CursoClienteInfo>(GetList(childs));

            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }

        #endregion

        #region Root Data Access

        /// <summary>
        /// Construye el objeto y se encarga de obtener los
        /// hijos si los tiene y se solicitan
        /// </summary>
        /// <param name="criteria">Criterios de la consulta</param>
        protected override void Fetch(CriteriaEx criteria)
        {
            this.RaiseListChangedEvents = false;

            SessionCode = criteria.SessionCode;
            Childs = criteria.Childs;

            try
            {
                if (nHMng.UseDirectSQL)
                {
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                    IsReadOnly = false;

                    while (reader.Read())
                        this.AddItem(CursoClienteInfo.GetChild(reader, Childs));

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
        

        /// <summary>
        /// Construye el SELECT de la lista
        /// </summary>       
        /// <returns></returns>
        public  static string SELECT()
        {            
            string cv = nHManager.Instance.GetSQLTable(typeof(Convocatoria_Curso));
            string cu = nHManager.Instance.GetSQLTable(typeof(Curso));
            string cl = nHManager.Instance.GetSQLTable(typeof(Cliente));
            string acv = nHManager.Instance.GetSQLTable(typeof(Alumno_Convocatoria));
            string ac = nHManager.Instance.GetSQLTable(typeof(AlumnoCliente));

            string query;

            query = "SELECT CC.\"OID\" AS \"OID_CONVOCATORIA\", " + 
                    "       CU.\"OID\" AS \"OID_CURSO\", " +	
                    "       CL.\"OID\" AS \"OID_CLIENTE\", " +
                    "       CU.\"NOMBRE\" AS \"CURSO\", " +
                    "       CL.\"NOMBRE\" AS \"CLIENTE\", " +
                    "       CC.\"NOMBRE\" AS \"CONVOCATORIA\", " +
                    "       COUNT (ACV.\"OID_ALUMNO\") AS \"NALUMNOS\"  " +
                    " FROM " + cu + "   AS CU " + 
                    " LEFT JOIN " + cv + " AS CC ON (CU.\"OID\" = CC.\"OID_CURSO\") " +
                    " LEFT JOIN " + acv + " AS ACV ON (CC.\"OID\" =  ACV.\"OID_CONVOCATORIA\") " +
                    " LEFT JOIN " + ac + " AS ACL ON (ACV.\"OID_ALUMNO\" = ACL.\"OID_ALUMNO\") " +
                    " LEFT JOIN " + cl + " AS CL ON (ACL.\"OID_CLIENTE\" = CL.\"OID\") ";
            
            return query;
        }

        public  static string SELECT_BY_CLIENTE(long oid_cliente)
        {
            string query = SELECT();

            query += " WHERE CL.\"OID\" = '" + oid_cliente.ToString() + "' ";
            query += " GROUP BY CU.\"OID\",CC.\"OID\", CL.\"OID\",CU.\"NOMBRE\",CL.\"NOMBRE\",CC.\"NOMBRE\" ";

            return query;
        }

        public static string SELECT_BY_CURSO(long oid_curso)
        {
            string query = SELECT();

            query += " WHERE CU.\"OID\" = '" + oid_curso.ToString() + "' ";
            query += " GROUP BY CU.\"OID\",CC.\"OID\", CL.\"OID\",CU.\"NOMBRE\",CL.\"NOMBRE\" ";

            return query;
        }

        #endregion
		
	}
}

