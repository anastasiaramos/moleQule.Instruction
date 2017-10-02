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
	public class ClaseTeoricaList : ReadOnlyListBaseEx<ClaseTeoricaList, ClaseTeoricaInfo>
	{

		#region Child Factory Methods

		private ClaseTeoricaList() { }

        public static ClaseTeoricaList NewList() { return new ClaseTeoricaList(); }

		private ClaseTeoricaList(IList<ClaseTeorica> lista)
		{
			Fetch(lista);
		}

		private ClaseTeoricaList(IDataReader reader)
		{
			Fetch(reader);
		}

		/// <summary>
		/// Builds a ClaseTeoricaList from a IList<!--<ClaseTeoricaInfo>-->
		/// </summary>
		/// <param name="list"></param>
		/// <returns>ClaseTeoricaList</returns>
		public static ClaseTeoricaList GetChildList(IList<ClaseTeoricaInfo> list)
		{
			ClaseTeoricaList flist = new ClaseTeoricaList();

			if (list.Count > 0)
			{

				foreach (ClaseTeoricaInfo item in list)
					flist.AddItem(item);
			}

			return flist;
		}


		/// <summary>
		/// Builds a ClaseTeoricaList from IList<!--<ClaseTeorica>-->
		/// </summary>
		/// <param name="list"></param>
		/// <returns>ClaseTeoricaList</returns>
		public static ClaseTeoricaList GetChildList(IList<ClaseTeorica> list) { return new ClaseTeoricaList(list); }

		public static ClaseTeoricaList GetChildList(IDataReader reader) { return new ClaseTeoricaList(reader); }

		#endregion

		#region Root Factory Methods

		//  private ClaseTeoricaList() { }

		/// <summary>
		/// Retrieve the complete list from db
		/// </summary>
		/// <returns>ClaseTeoricaList</returns>
		public static ClaseTeoricaList GetList()
		{
			CriteriaEx criteria = ClaseTeorica.GetCriteria(ClaseTeorica.OpenSession());

			//No criteria. Retrieve all de List
            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = ClaseTeoricas.SELECT();
			ClaseTeoricaList list = DataPortal.Fetch<ClaseTeoricaList>(criteria);

			CloseSession(criteria.SessionCode);

			return list;
		}

        public static ClaseTeoricaList GetListBySubmodulo(long oid)
        {
            CriteriaEx criteria = ClaseTeorica.GetCriteria(ClaseTeorica.OpenSession());

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = ClaseTeoricaList.SELECT_BY_SUBMODULO(oid);

            ClaseTeoricaList list = DataPortal.Fetch<ClaseTeoricaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>ClaseTeoricaList</returns>
        public static ClaseTeoricaList GetClasesOrdenadasPlanList(long oid_plan)
        {
            CriteriaEx criteria = ClaseTeorica.GetCriteria(ClaseTeorica.OpenSession());

            //No criteria. Retrieve all de List
            criteria.Query = ClaseTeoricas.SELECT_CLASES_TEORICAS_PLAN_ORDENADAS(oid_plan);
            ClaseTeoricaList list = DataPortal.Fetch<ClaseTeoricaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }/// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>ClaseTeoricaList</returns>
        public static ClaseTeoricaList GetClasesPlanList(long oid_plan)
        {
            CriteriaEx criteria = ClaseTeorica.GetCriteria(ClaseTeorica.OpenSession());

            //No criteria. Retrieve all de List
            criteria.Query = ClaseTeoricas.SELECT_CLASES_TEORICAS_PLAN(oid_plan);
            ClaseTeoricaList list = DataPortal.Fetch<ClaseTeoricaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>ClaseTeoricaList</returns>
        public static ClaseTeoricaList GetImpartidasList(long oid_promocion, DateTime fecha)
        {
            CriteriaEx criteria = ClaseTeorica.GetCriteria(ClaseTeorica.OpenSession());

            //No criteria. Retrieve all de List
            criteria.Query = ClaseTeorica.SELECT_IMPARTIDAS(oid_promocion, fecha, false);
            ClaseTeoricaList list = DataPortal.Fetch<ClaseTeoricaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>ClaseTeoricaList</returns>
        public static ClaseTeoricaList GetNoImpartidasList(long oid_plan, long oid_plan_extra, long oid_promocion)
        {
            CriteriaEx criteria = ClaseTeorica.GetCriteria(ClaseTeorica.OpenSession());

            //No criteria. Retrieve all de List
            criteria.Query = ClaseTeoricas.SELECT_CLASES_TEORICAS_NO_IMPARTIDAS(oid_plan, oid_plan_extra, oid_promocion);
            ClaseTeoricaList list = DataPortal.Fetch<ClaseTeoricaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>ClaseTeoricaList</returns>
        public static ClaseTeoricaList GetDisponiblesList(long oid_plan, long oid_promocion, long oid_horario)
        {
            CriteriaEx criteria = ClaseTeorica.GetCriteria(ClaseTeorica.OpenSession());

            //No criteria. Retrieve all de List
            criteria.Query = ClaseTeoricas.SELECT_CLASES_TEORICAS_DISPONIBLES(oid_plan, oid_promocion, oid_horario);
            ClaseTeoricaList list = DataPortal.Fetch<ClaseTeoricaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>ClaseTeoricaList</returns>
        public static ClaseTeoricaList GetProgramadasList(long oid_plan, long oid_promocion)
        {
            CriteriaEx criteria = ClaseTeorica.GetCriteria(ClaseTeorica.OpenSession());

            //No criteria. Retrieve all de List
            criteria.Query = ClaseTeoricas.SELECT_CLASES_TEORICAS_PROGRAMADAS(oid_plan, oid_promocion);
            ClaseTeoricaList list = DataPortal.Fetch<ClaseTeoricaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

		/// <summary>
		/// Devuelve una lista de todos los elementos
		/// </summary>
		/// <returns>Lista de elementos</returns>
		public static ClaseTeoricaList GetList(CriteriaEx criteria)
		{
			return ClaseTeoricaList.RetrieveList(typeof(ClaseTeorica), AppContext.ActiveSchema.Code, criteria);
		}

		/// <summary>
		/// Builds a ClaseTeoricaList from a IList<!--<ClaseTeoricaInfo>-->
		/// Doesn`t retrieve child data from DB.
		/// </summary>
		/// <param name="list"></param>
		/// <returns>ClaseTeoricaList</returns>
		public static ClaseTeoricaList GetList(IList<ClaseTeoricaInfo> list)
		{
			ClaseTeoricaList flist = new ClaseTeoricaList();

			if (list.Count > 0)
			{

				foreach (ClaseTeoricaInfo item in list)
					flist.AddItem(item);

			}

			return flist;
		}

		/// <summary>
		/// Builds a ClaseTeoricaList from a IList<!--<ClaseTeorica>-->
		/// </summary>
		/// <param name="list"></param>
		/// <returns>ClaseTeorica</returns>
		public static ClaseTeoricaList GetList(IList<ClaseTeorica> list)
		{
			ClaseTeoricaList flist = new ClaseTeoricaList();

			if (list != null)
			{

				foreach (ClaseTeorica item in list)
					flist.AddItem(item.GetInfo());

			}

			return flist;
		}

		/// <summary>
		/// Devuelve una lista ordenada de todos los elementos
		/// </summary>
		/// <param name="sortProperty">Campo de ordenación</param>
		/// <param name="sortDirection">Sentido de ordenación</param>
		/// <returns>Lista ordenada de elementos</returns>
		public static SortedBindingList<ClaseTeoricaInfo> GetSortedList(string sortProperty,
																	ListSortDirection sortDirection)
		{
			SortedBindingList<ClaseTeoricaInfo> sortedList =
				new SortedBindingList<ClaseTeoricaInfo>(GetList());
			sortedList.ApplySort(sortProperty, sortDirection);
			return sortedList;
		}

        //public List<ClaseTeoricaInfo> GetClasesOrdenadas()
        //{
        //    SubmoduloList submodulos = SubmoduloList.GetList(false);
        //    ModuloList modulos = ModuloList.GetList(false);
        //    List<ClaseTeoricaInfo> clases = new List<ClaseTeoricaInfo>();

        //    foreach (ClaseTeoricaInfo clase in this)
        //        clases.AddItem(clase);

        //    for (int i = 0; i < clases.Count - 1; i++)
        //    {
        //        for (int j = i + 1; j < clases.Count; j++)
        //        {
        //            string codigo_i = submodulos.GetItem(clases[i].OidSubmodulo).CodigoOrden;
        //            string codigo_j = submodulos.GetItem(clases[j].OidSubmodulo).CodigoOrden;
        //            int valor = codigo_i.CompareTo(codigo_j);

        //            if (valor == 1)
        //            {
        //                ClaseTeoricaInfo aux = clases[i];
        //                clases[i] = clases[j];
        //                clases[j] = aux;
        //            }
        //            else
        //            {
        //                if (codigo_i == codigo_j
        //                    && clases[i].OrdenTerciario > clases[j].OrdenTerciario)
        //                {
        //                    ClaseTeoricaInfo aux = clases[i];
        //                    clases[i] = clases[j];
        //                    clases[j] = aux;
        //                }

        //            }
        //        }
        //    }

        //    return clases;
        //}

        private static int CompareClasesbyOrder(ClaseTeoricaInfo x, ClaseTeoricaInfo y)
        {
            if (x.CodigoOrden == y.CodigoOrden)
            {
                if (x.OrdenTerciario == y.OrdenTerciario)
                    return 0;
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

        public List<ClaseTeoricaInfo> OrdenaLista()
        {
            List<ClaseTeoricaInfo> lista = new List<ClaseTeoricaInfo>();

            foreach (ClaseTeoricaInfo item in this)
                lista.Add(item);

            lista.Sort(CompareClasesbyOrder);

            return lista;
        }

		#endregion

		#region Child Data Access

		// called to copy objects data from list
		private void Fetch(IList<ClaseTeorica> lista)
		{
			this.RaiseListChangedEvents = false;

			foreach (ClaseTeorica item in lista)
				this.AddItem(item.GetInfo());

			this.RaiseListChangedEvents = true;
		}

		// called to copy objects data from list
		private void Fetch(IDataReader reader)
		{
			this.RaiseListChangedEvents = false;

			while (reader.Read())
				this.AddItem(ClaseTeoricaInfo.Get(reader, Childs));

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
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query,Session());

					IsReadOnly = false;

					while (reader.Read())
					{
						this.AddItem(ClaseTeoricaInfo.Get(reader, Childs));
					}

					IsReadOnly = true;
				}
				else
				{
					IList<ClaseTeorica> list = criteria.List<ClaseTeorica>();

					if (list.Count > 0)
					{
						foreach (ClaseTeorica item in list)
							this.AddItem(item.GetInfo());

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

					foreach (ClaseTeorica item in list)
						this.AddItem(item.GetInfo());
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

        public static string SELECT_BY_SUBMODULO(long oid_submodulo) { return ClaseTeoricas.SELECT_BY_SUBMODULO(oid_submodulo, false); }

        #endregion

    }
}

