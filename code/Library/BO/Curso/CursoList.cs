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
	public class CursoList : ReadOnlyListBaseEx<CursoList, CursoInfo>
	{
	
	    #region Business Methods
	
			
		#endregion
		 
		#region Factory Methods
		 
		 	public CursoList() { }

            public static CursoList NewList() { return new CursoList(); }

			/// <summary>
			/// Retrieve the complete list from db
			/// </summary>
			/// <param name="get_childs">retrieving the childs</param>
			/// <returns></returns>
			public static CursoList GetList(bool childs)
			{
				CriteriaEx criteria = Curso.GetCriteria(Curso.OpenSession());
				criteria.Childs = childs;
                criteria.Query = CursoList.SELECT();

				//No criteria. Retrieve all de List
				CursoList list = DataPortal.Fetch<CursoList>(criteria);

				CloseSession(criteria.SessionCode);

				return list;
			}

			/// <summary>
			/// Default call for GetList(bool get_childs)
			/// </summary>
			/// <returns></returns>
			public static CursoList GetList()
			{
				return CursoList.GetList(true);
			}

			/// <summary>
			/// Devuelve una lista de todos los elementos
			/// </summary>
			/// <returns>Lista de elementos</returns>
			public static CursoList GetList(CriteriaEx criteria)
			{
				return CursoList.RetrieveList(typeof(Curso), AppContext.ActiveSchema.Code, criteria);
			}

			/// <summary>
			/// Builds a ClienteList from a IList<!--<ClienteInfo>-->.
			/// Doesn`t retrieve child data from DB.
			/// </summary>
			/// <param name="list"></param>
			/// <returns></returns>
			public static CursoList GetList(IList<CursoInfo> list)
			{
				CursoList flist = new CursoList();


				if (list.Count > 0)
				{
					flist.IsReadOnly = false;
				foreach (CursoInfo item in list)
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
			public static SortedBindingList<CursoInfo> GetSortedList(	string sortProperty, ListSortDirection sortDirection)
			{
				SortedBindingList<CursoInfo> sortedList = new SortedBindingList<CursoInfo>(GetList());

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
						IDataReader reader = nHManager.Instance.SQLNativeSelect(criteria.Query, Session()); 

						IsReadOnly = false;

						while (reader.Read())
						{
							this.AddItem(CursoInfo.Get(reader,Childs));
						}
						IsReadOnly = true;
					}
					else 
					{
						IList list = criteria.List();

						if (list.Count > 0)
						{
							IsReadOnly = false;
								foreach (Curso item in list)
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

        public static string SELECT() { return Curso.SELECT(new QueryConditions(), false); }

        #endregion

    }
}

