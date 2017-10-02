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
	public class TemaList : ReadOnlyListBaseEx<TemaList, TemaInfo>
	{

		#region Child Factory Methods

		private TemaList() { }

		private TemaList(IList<Tema> lista)
		{
			Fetch(lista);
		}

		private TemaList(IDataReader reader)
		{
			Fetch(reader);
		}

		/// <summary>
		/// Builds a TemaList from a IList<!--<TemaInfo>-->
		/// </summary>
		/// <param name="list"></param>
		/// <returns>TemaList</returns>
		public static TemaList GetChildList(IList<TemaInfo> list)
		{
			TemaList flist = new TemaList();

			if (list.Count > 0)
			{
				flist.IsReadOnly = false;

				foreach (TemaInfo item in list)
					flist.AddItem(item);

				flist.IsReadOnly = true;
			}

			return flist;
		}


		/// <summary>
		/// Builds a TemaList from IList<!--<Tema>-->
		/// </summary>
		/// <param name="list"></param>
		/// <returns>TemaList</returns>
		public static TemaList GetChildList(IList<Tema> list) { return new TemaList(list); }

		public static TemaList GetChildList(IDataReader reader) { return new TemaList(reader); }

		#endregion

		#region Root Factory Methods

		//  private TemaList() { }

		/// <summary>
		/// Retrieve the complete list from db
		/// </summary>
		/// <returns>TemaList</returns>
		public static TemaList GetList(bool childs)
		{
			CriteriaEx criteria = Tema.GetCriteria(TemaList.OpenSession());
			criteria.Childs = childs;
            criteria.Query = SELECT();

			//No criteria. Retrieve all de List
			TemaList list = DataPortal.Fetch<TemaList>(criteria);

			CloseSession(criteria.SessionCode);

			return list;
		}

		/// <summary>
		/// Retrieve the complete list from db
		/// </summary>
		/// <returns>TemaList</returns>
		public static TemaList GetList()
		{
			return GetList(true);
		}

		/// <summary>
		/// Devuelve una lista de todos los elementos
		/// </summary>
		/// <returns>Lista de elementos</returns>
		public static TemaList GetList(CriteriaEx criteria)
		{
			return TemaList.RetrieveList(typeof(Tema), AppContext.ActiveSchema.Code, criteria);
		}

		/// <summary>
		/// Builds a TemaList from a IList<!--<TemaInfo>-->
		/// Doesn`t retrieve child data from DB.
		/// </summary>
		/// <param name="list"></param>
		/// <returns>TemaList</returns>
		public static TemaList GetList(IList<TemaInfo> list)
		{
			TemaList flist = new TemaList();

			if (list.Count > 0)
			{
				flist.IsReadOnly = false;

				foreach (TemaInfo item in list)
					flist.AddItem(item);

				flist.IsReadOnly = true;
			}

			return flist;
		}


        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>SubmoduloList</returns>
        public static TemaList GetModuloList(long oid_modulo, bool childs)
        {
            CriteriaEx criteria = Tema.GetCriteria(TemaList.OpenSession());
            criteria.Childs = childs;
            criteria.Query = Temas.SELECT_BY_MODULO(oid_modulo);

            //No criteria. Retrieve all de List
            TemaList list = DataPortal.Fetch<TemaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

		/// <summary>
		/// Builds a TemaList from a IList<!--<Tema>-->
		/// </summary>
		/// <param name="list"></param>
		/// <returns>Tema</returns>
		public static TemaList GetList(IList<Tema> list)
		{
			TemaList flist = new TemaList();

			if (list != null)
			{
				flist.IsReadOnly = false;

				foreach (Tema item in list)
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
		public static SortedBindingList<TemaInfo> GetSortedList(string sortProperty,
																	ListSortDirection sortDirection)
		{
			SortedBindingList<TemaInfo> sortedList =
				new SortedBindingList<TemaInfo>(GetList());
			sortedList.ApplySort(sortProperty, sortDirection);
			return sortedList;
		}

		#endregion

		#region Child Data Access

		// called to copy objects data from list
		private void Fetch(IList<Tema> lista)
		{
			this.RaiseListChangedEvents = false;

			IsReadOnly = false;

			foreach (Tema item in lista)
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
				this.AddItem(Tema.GetChild(reader).GetInfo());

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
                    IDataReader reader;
                    
                    reader = nHManager.Instance.SQLNativeSelect(criteria.Query, Session());

					IsReadOnly = false;

					while (reader.Read())
					{
						this.AddItem(TemaInfo.Get(reader, Childs));
					}

					IsReadOnly = true;
				}
				else
				{
					IList<Tema> list = criteria.List<Tema>();

					if (list.Count > 0)
					{
						IsReadOnly = false;

						foreach (Tema item in list)
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

					foreach (Tema item in list)
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

        public static string SELECT() { return Tema.SELECT(new QueryConditions(), false); }
        public static string SELECT_BY_SUBMODULO(long oid_submodulo) { return Temas.SELECT_BY_SUBMODULO(oid_submodulo, false); }

        #endregion

    }
}

