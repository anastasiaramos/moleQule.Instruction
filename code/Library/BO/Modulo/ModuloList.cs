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
	public class ModuloList : ReadOnlyListBaseEx<ModuloList, ModuloInfo>
	{
	
	    #region Business Methods
	
			
		 #endregion
		 
		#region Factory Methods

        private ModuloList() { }

        public static ModuloList NewList() { return new ModuloList(); }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <param name="get_childs">retrieving the childs</param>
        /// <returns></returns>
        public static ModuloList GetList(bool childs)
        {
            CriteriaEx criteria = Modulo.GetCriteria(Modulo.OpenSession());
            criteria.Childs = childs;
            criteria.Query = ModuloList.SELECT_ORDERED("NumeroOrden");

            //No criteria. Retrieve all de List
            ModuloList list = DataPortal.Fetch<ModuloList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }
        
        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <param name="get_childs">retrieving the childs</param>
        /// <returns></returns>
        public static ModuloList GetListByPromocion(bool childs, long oid_promocion)
        {
            CriteriaEx criteria = Modulo.GetCriteria(Modulo.OpenSession());
            criteria.Childs = childs;
            criteria.Query = ModuloList.SELECT_BY_PROMOCION(oid_promocion);

            //No criteria. Retrieve all de List
            ModuloList list = DataPortal.Fetch<ModuloList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <param name="get_childs">retrieving the childs</param>
        /// <returns></returns>
        public static ModuloList GetOrderedList(bool childs)
        {
            CriteriaEx criteria = Modulo.GetCriteria(Modulo.OpenSession());
            criteria.Childs = childs;
            criteria.Query = ModuloList.SELECT_ORDERED("NumeroOrden");

            //No criteria. Retrieve all de List
            ModuloList list = DataPortal.Fetch<ModuloList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Default call for GetList(bool get_childs)
        /// </summary>
        /// <returns></returns>
        public static ModuloList GetList()
        {
            return ModuloList.GetList(true);
        }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static ModuloList GetList(CriteriaEx criteria)
        {
            return ModuloList.RetrieveList(typeof(Modulo), AppContext.ActiveSchema.Code, criteria);
        }

        /// <summary>
        /// Builds a ClienteList from a IList<!--<ClienteInfo>-->.
        /// Doesn`t retrieve child data from DB.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static ModuloList GetList(IList<ModuloInfo> list)
        {
            ModuloList flist = new ModuloList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;
                foreach (ModuloInfo item in list)
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
        public static SortedBindingList<ModuloInfo> GetSortedList(string sortProperty, ListSortDirection sortDirection)
        {
            SortedBindingList<ModuloInfo> sortedList = new SortedBindingList<ModuloInfo>(GetList(false));

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
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query);

					IsReadOnly = false;

					while (reader.Read())
					{
						this.AddItem(ModuloInfo.Get(reader, Childs));
					}
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
        /// Construye el SELECT de la lista y lo ejecuta
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public static string SELECT_ORDERED(string order_field)
        {
            string tabla = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string columna = nHManager.Instance.GetTableField(typeof(ModuloRecord), order_field);

            string query = "SELECT *" +
                           " FROM " + tabla +
                           " ORDER BY \"" + columna + "\"";

            return query;
        }

        public static string SELECT_BY_PROMOCION(long oid_promocion)
        { 
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string teorica = nHManager.Instance.GetSQLTable(typeof(ClaseTeoricaRecord));
            string practica = nHManager.Instance.GetSQLTable(typeof(ClasePracticaRecord));
            string plan = nHManager.Instance.GetSQLTable(typeof(PlanEstudiosRecord));
            string promocion = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));

            string query =  "SELECT DISTINCT m.* " +
                            "FROM " + modulo + " AS m " +
                            "INNER JOIN " + teorica + " AS ct ON (ct.\"OID_MODULO\" = m.\"OID\") " +
                            "INNER JOIN " + plan + " AS p ON (p.\"OID\" = ct.\"OID_PLAN\") " +
                            "INNER JOIN " + promocion + " AS pr ON (pr.\"OID_PLAN\" = p.\"OID\" AND pr.\"OID\" = " + oid_promocion.ToString() + ") " +
                            "UNION " +
                            "SELECT DISTINCT m.* " +
                            "FROM " + modulo + " AS m " +
                            "INNER JOIN " + practica + " AS ct ON (ct.\"OID_MODULO\" = m.\"OID\") " +
                            "INNER JOIN " + plan + " AS p ON (p.\"OID\" = ct.\"OID_PLAN\") " +
                            "INNER JOIN " + promocion + " AS pr ON (pr.\"OID_PLAN\" = p.\"OID\" AND pr.\"OID\" = " + oid_promocion.ToString() + ") " +
                            "ORDER BY \"NUMERO_ORDEN\"";
            return query;
        }

        #endregion

    }
}

