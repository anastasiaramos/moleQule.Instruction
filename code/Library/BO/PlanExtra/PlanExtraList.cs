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
	public class PlanExtraList : ReadOnlyListBaseEx<PlanExtraList, PlanExtraInfo>
	{
	
	    #region Business Methods
	
			
		 #endregion
		 
		#region Factory Methods
		 
		 	private PlanExtraList() { }

            public static PlanExtraList NewList() { return new PlanExtraList(); }

			/// <summary>
			/// Retrieve the complete list from db
			/// </summary>
			/// <param name="get_childs">retrieving the childs</param>
			/// <returns></returns>
			public static PlanExtraList GetList(bool childs)
			{
				CriteriaEx criteria = PlanExtra.GetCriteria(PlanExtra.OpenSession());
				criteria.Childs = childs;
				criteria.Query = PlanExtraList.SELECT();

				//No criteria. Retrieve all de List
				PlanExtraList list = DataPortal.Fetch<PlanExtraList>(criteria);

				CloseSession(criteria.SessionCode);

				return list;
			}

			/// <summary>
			/// Default call for GetList(bool get_childs)
			/// </summary>
			/// <returns></returns>
			public static PlanExtraList GetList()
			{
				return PlanExtraList.GetList(true);
			}

			/// <summary>
			/// Devuelve una lista de todos los elementos
			/// </summary>
			/// <returns>Lista de elementos</returns>
			public static PlanExtraList GetList(CriteriaEx criteria)
			{
				return PlanExtraList.RetrieveList(typeof(PlanExtra), AppContext.ActiveSchema.Code, criteria);
			}

			/// <summary>
			/// Builds a ClienteList from a IList<!--<ClienteInfo>-->.
			/// Doesn`t retrieve child data from DB.
			/// </summary>
			/// <param name="list"></param>
			/// <returns></returns>
			public static PlanExtraList GetList(IList<PlanExtraInfo> list)
			{
				PlanExtraList flist = new PlanExtraList();


				if (list.Count > 0)
				{
					flist.IsReadOnly = false;
				foreach (PlanExtraInfo item in list)
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
			public static SortedBindingList<PlanExtraInfo> GetSortedList(	string sortProperty, ListSortDirection sortDirection)
			{
				SortedBindingList<PlanExtraInfo> sortedList = new SortedBindingList<PlanExtraInfo>(GetList());

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
						//PlanExtra.DoLOCK( Session());
						IDataReader reader = nHManager.Instance.SQLNativeSelect(criteria.Query, Session()); 

						IsReadOnly = false;

						while (reader.Read())
						{
							this.AddItem(PlanExtraInfo.Get(reader,Childs));
						}
						IsReadOnly = true;
					}
					else 
					{
						IList list = criteria.List();

						if (list.Count > 0)
						{
							IsReadOnly = false;
								foreach (PlanExtra item in list)
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

            #region SQL

            public static string SELECT() { return PlanExtra.SELECT(new QueryConditions(), false); }

            #endregion
	
	}
}

