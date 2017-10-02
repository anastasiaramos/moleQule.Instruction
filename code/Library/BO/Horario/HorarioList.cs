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
	public class HorarioList : ReadOnlyListBaseEx<HorarioList, HorarioInfo>
	{

		#region Child Factory Methods

		private HorarioList() { }

        public static HorarioList NewList() { return new HorarioList(); }

		private HorarioList(IList<Horario> lista)
		{
			Fetch(lista);
		}

		private HorarioList(IDataReader reader)
		{
			Fetch(reader);
		}

		/// <summary>
		/// Builds a HorarioList from a IList<!--<HorarioInfo>-->
		/// </summary>
		/// <param name="list"></param>
		/// <returns>HorarioList</returns>
		public static HorarioList GetChildList(IList<HorarioInfo> list)
		{
			HorarioList flist = new HorarioList();

			if (list.Count > 0)
			{
				flist.IsReadOnly = false;

				foreach (HorarioInfo item in list)
					flist.AddItem(item);

				flist.IsReadOnly = true;
			}

			return flist;
		}


		/// <summary>
		/// Builds a HorarioList from IList<!--<Horario>-->
		/// </summary>
		/// <param name="list"></param>
		/// <returns>HorarioList</returns>
		public static HorarioList GetChildList(IList<Horario> list) { return new HorarioList(list); }

		public static HorarioList GetChildList(IDataReader reader) { return new HorarioList(reader); }

		#endregion

		#region Root Factory Methods

		//  private HorarioList() { }

		/// <summary>
		/// Retrieve the complete list from db
		/// </summary>
		/// <returns>HorarioList</returns>
		public static HorarioList GetList(bool childs)
		{
			CriteriaEx criteria = Horario.GetCriteria(Horario.OpenSession());
			criteria.Childs = childs;
            criteria.Query = Horarios.SELECT();
			//No criteria. Retrieve all de List
			HorarioList list = DataPortal.Fetch<HorarioList>(criteria);

			CloseSession(criteria.SessionCode);

			return list;
		}

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>HorarioList</returns>
        public static HorarioList GetHorariosPromocionList(long oid_promocion, long oid_plan, DateTime fecha, bool childs)
        {
            CriteriaEx criteria = Horario.GetCriteria(Horario.OpenSession());
            criteria.Childs = childs;

            criteria.Query = Horario.SELECT_BY_PLAN_BY_PROMOCION(oid_plan, oid_promocion, fecha);
            
            HorarioList list = DataPortal.Fetch<HorarioList>(criteria);
            CloseSession(criteria.SessionCode);

            return list;
        }

		/// <summary>
		/// Retrieve the complete list from db
		/// </summary>
		/// <returns>HorarioList</returns>
		public static HorarioList GetList()
		{
			return GetList(true);
		}

        public static HorarioList GetFilteredFechaList(HorarioList lista, DateTime fecha_inicio, DateTime fecha_fin)
        {
            HorarioList list = new HorarioList();

            list.IsReadOnly = false;

            foreach (HorarioInfo item in lista)
            {
                if (item.FechaFinal.Date >= fecha_inicio.Date
                    && item.FechaInicial <= fecha_fin.Date)
                    list.Add(item);
            }

            list.IsReadOnly = true;

            return list;
        }

		/// <summary>
		/// Devuelve una lista de todos los elementos
		/// </summary>
		/// <returns>Lista de elementos</returns>
		public static HorarioList GetList(CriteriaEx criteria)
		{
			return HorarioList.RetrieveList(typeof(Horario), AppContext.ActiveSchema.Code, criteria);
		}

		/// <summary>
		/// Builds a HorarioList from a IList<!--<HorarioInfo>-->
		/// Doesn`t retrieve child data from DB.
		/// </summary>
		/// <param name="list"></param>
		/// <returns>HorarioList</returns>
		public static HorarioList GetList(IList<HorarioInfo> list)
		{
			HorarioList flist = new HorarioList();

			if (list.Count > 0)
			{
				flist.IsReadOnly = false;

				foreach (HorarioInfo item in list)
					flist.AddItem(item);

				flist.IsReadOnly = true;
			}

			return flist;
		}

		/// <summary>
		/// Builds a HorarioList from a IList<!--<Horario>-->
		/// </summary>
		/// <param name="list"></param>
		/// <returns>Horario</returns>
		public static HorarioList GetList(IList<Horario> list)
		{
			HorarioList flist = new HorarioList();

			if (list != null)
			{
				flist.IsReadOnly = false;

				foreach (Horario item in list)
					flist.AddItem(item.GetInfo());

				flist.IsReadOnly = true;
			}

			return flist;
		}

        public void LoadChilds(Type type, bool get_childs)
        {
            foreach (HorarioInfo item in this)
                item.LoadChilds(type, get_childs);
        }

		/// <summary>
		/// Devuelve una lista ordenada de todos los elementos
		/// </summary>
		/// <param name="sortProperty">Campo de ordenación</param>
		/// <param name="sortDirection">Sentido de ordenación</param>
		/// <returns>Lista ordenada de elementos</returns>
		public static SortedBindingList<HorarioInfo> GetSortedList(string sortProperty,
																	ListSortDirection sortDirection)
		{
			SortedBindingList<HorarioInfo> sortedList =
				new SortedBindingList<HorarioInfo>(GetList());
			sortedList.ApplySort(sortProperty, sortDirection);
			return sortedList;
		}

		#endregion

		#region Child Data Access

		// called to copy objects data from list
		private void Fetch(IList<Horario> lista)
		{
			this.RaiseListChangedEvents = false;

			IsReadOnly = false;

			foreach (Horario item in lista)
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
                this.AddItem(HorarioInfo.Get(reader, true)/*;.GetChild(reader).GetInfo()*/);

			IsReadOnly = true;

			this.RaiseListChangedEvents = true;
		}

		#endregion

		#region Root Data Access

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
                    if (criteria.Query == string.Empty)
                        criteria.Query = Horarios.SELECT();

                    IDataReader reader = null;
                   
                    reader = nHMng.SQLNativeSelect(criteria.Query, Session());

					IsReadOnly = false;

					while (reader.Read())
					{
						this.AddItem(HorarioInfo.Get(reader, Childs));
					}

					IsReadOnly = true;
				}
				else
				{
					IList<Horario> list = criteria.List<Horario>();

					if (list.Count > 0)
					{
						IsReadOnly = false;

						foreach (Horario item in list)
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

					foreach (Horario item in list)
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

	}
}

