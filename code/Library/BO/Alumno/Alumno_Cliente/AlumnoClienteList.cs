using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

using Csla;
using NHibernate;

using moleQule.Library;
using moleQule.Library.CslaEx;

namespace moleQule.Library.Instruction
{	
	/// <summary>
    /// ReadOnly Business Object Root Collection
	/// ReadOnly Business Object Child Collection
	/// </summary>
    [Serializable()]
	public class AlumnoClienteList : ReadOnlyListBaseEx<AlumnoClienteList, AlumnoClienteInfo>
	{	
		#region Business Methods
			
		#endregion
		 
		#region Common Factory Methods
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Objet creation require use of factory methods
        /// </remarks>
		private AlumnoClienteList() {}
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Objet creation require use of factory methods
        /// </remarks>
		private AlumnoClienteList(IList<AlumnoCliente> list, bool retrieve_childs)
        {
			Childs = retrieve_childs;
            Fetch(list);
        }
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Objet creation require use of factory methods
        /// </remarks>
		private AlumnoClienteList(IDataReader reader, bool retrieve_childs)
        {
			Childs = retrieve_childs;
            Fetch(reader);
        }
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Objet creation require use of factory methods
        /// </remarks>
		private AlumnoClienteList(IList<AlumnoClienteInfo> list, bool retrieve_childs)
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
        public static AlumnoClienteList GetList()
        {
            return AlumnoClienteList.GetList(true);
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <param name="retrieve_childs">Retrieving the childs</param>
        /// <returns></returns>
        public static AlumnoClienteList GetList(bool retrieve_childs)
        {
            CriteriaEx criteria = AlumnoCliente.GetCriteria(AlumnoCliente.OpenSession());
            criteria.Childs = retrieve_childs;

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = AlumnoClienteList.SELECT();

            AlumnoClienteList list = DataPortal.Fetch<AlumnoClienteList>(criteria);
            CloseSession(criteria.SessionCode);
            return list;
        }

        public static AlumnoClienteList GetListByAlumno(long oid, bool retrieve_childs)
        {
            CriteriaEx criteria = AlumnoCliente.GetCriteria(AlumnoCliente.OpenSession());
            criteria.Childs = retrieve_childs;

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = AlumnoClienteList.SELECT_BY_ALUMNO(oid);

            AlumnoClienteList list = DataPortal.Fetch<AlumnoClienteList>(criteria);
            CloseSession(criteria.SessionCode);
            return list;
        }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static AlumnoClienteList GetList(CriteriaEx criteria)
        {
            return AlumnoClienteList.RetrieveList(typeof(AlumnoCliente), AppContext.ActiveSchema.Code, criteria);
        }

        /// <summary>
        /// Construye la lista
        /// </summary>
        /// <param name="list">IList origen</param>
        /// <returns>Lista de objetos de solo lectura</returns>
        /// <remarks>NO OBTIENE LOS HIJOS SI EL OBJETO NO LOS TIENE CARGADOS</remarks>
        public static AlumnoClienteList GetList(IList<AlumnoCliente> list) { return new AlumnoClienteList(list, false); }

        /// <summary>
        /// Construye la lista
        /// </summary>
        /// <param name="list">IList origen</param>
        /// <returns>Lista de objetos de solo lectura</returns>
        /// <remarks>NO OBTIENE LOS HIJOS SI EL OBJETO NO LOS TIENE CARGADOS</remarks>
        public static AlumnoClienteList GetList(IList<AlumnoClienteInfo> list) { return new AlumnoClienteList(list, false); }

        /// <summary>
        /// Devuelve una lista ordenada de todos los elementos
        /// </summary>
        /// <param name="sortProperty">Campo de ordenación</param>
        /// <param name="sortDirection">Sentido de ordenación</param>
        /// <returns>Lista ordenada de elementos</returns>
        public static SortedBindingList<AlumnoClienteInfo> GetSortedList(string sortProperty, ListSortDirection sortDirection)
        {
            SortedBindingList<AlumnoClienteInfo> sortedList = new SortedBindingList<AlumnoClienteInfo>(GetList());

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
        public static SortedBindingList<AlumnoClienteInfo> GetSortedList(string sortProperty, ListSortDirection sortDirection, bool childs)
        {
            SortedBindingList<AlumnoClienteInfo> sortedList = new SortedBindingList<AlumnoClienteInfo>(GetList(childs));

            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }

        #endregion

		#region Child Factory Methods
		
		/// <summary>
		/// Construye la lista
		/// </summary>
		/// <param name="list">IList origen</param>
        /// <returns>Lista de objetos de solo lectura</returns>
		/// <remarks>NO OBTIENE LOS HIJOS SI EL OBJETO NO LOS TIENE CARGADOS</remarks>
		public static AlumnoClienteList GetChildList(IList<AlumnoCliente> list) { return new AlumnoClienteList(list, false); }

		/// <summary>
		/// Construye la lista
		/// </summary>
		/// <param name="list">IList origen</param>
		/// <param name="retrieve_childs">Flag para indicar si quiere obtener los hijos</param>
        /// <returns>Lista de objetos de solo lectura</returns>
		public static AlumnoClienteList GetChildList(IList<AlumnoCliente> list, bool retrieve_childs) { return new AlumnoClienteList(list, retrieve_childs); }

		/// <summary>
        /// Construye la lista
        /// </summary>
        /// <param name="reader">IDataReader</param>
        /// <returns>Lista de objetos de solo lectura</returns>
        /// <remarks>NO OBTIENE LOS HIJOS SI EL OBJETO NO LOS TIENE CARGADOS</remarks>
		public static AlumnoClienteList GetChildList(IDataReader reader) { return new AlumnoClienteList(reader, false); } 
		
		/// <summary>
        /// Construye la lista
        /// </summary>
        /// <param name="reader">IDataReader</param>
        /// <param name="retrieve_childs">Flag para indicar si quiere obtener los hijos</param>
        /// <returns>Lista de objetos de solo lectura</returns>
        public static AlumnoClienteList GetChildList(IDataReader reader, bool retrieve_childs) { return new AlumnoClienteList(reader, retrieve_childs); }

		/// <summary>
		/// Construye la lista
		/// </summary>
		/// <param name="list">IList origen</param>
        /// <returns>Lista de objetos de solo lectura</returns>
		/// <remarks>NO OBTIENE LOS HIJOS SI EL OBJETO NO LOS TIENE CARGADOS</remarks>
        public static AlumnoClienteList GetChildList(IList<AlumnoClienteInfo> list) { return new AlumnoClienteList(list, false); }
		
		#endregion
		
		#region Common Data Access

		/// <summary>
        /// Construye la lista y obtiene los datos de los hijos de la bd
		/// </summary>
		/// <param name="lista">IList origen</param>
		private void Fetch(IList<AlumnoCliente> lista)
		{
			this.RaiseListChangedEvents = false;

			IsReadOnly = false;
			
			foreach (AlumnoCliente item in lista)
				this.AddItem(item.GetInfo(Childs));

			IsReadOnly = true;

			this.RaiseListChangedEvents = true;
		}

        /// <summary>
        /// Construye la lista y obtiene los datos de los hijos de la bd
		/// </summary>
		/// <param name="reader">IDataReader origen</param>
        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            while (reader.Read())
                this.AddItem(AlumnoClienteInfo.GetChild(reader, Childs));

            IsReadOnly = true;

            this.RaiseListChangedEvents = true;
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
                        this.AddItem(AlumnoClienteInfo.GetChild(reader, Childs));

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
            string query;

            query = AlumnoClienteInfo.SELECT(0);

            return query;
        }

        public static string SELECT_BY_ALUMNO(long oid_alumno)
        {
            string query;

            query = AlumnoClienteInfo.SELECT(0);

            if (oid_alumno > 0) query += " WHERE A.\"OID\" = " + oid_alumno.ToString();

            return query;
        }
                
        #endregion
		
	}
}

