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
	public class RevisionMaterialList : ReadOnlyListBaseEx<RevisionMaterialList, RevisionMaterialInfo>
	{
	
	    #region Child Factory Methods

			private RevisionMaterialList() { }

			private RevisionMaterialList(IList<RevisionMaterial> lista)
			{
				Fetch(lista);
			}

			private RevisionMaterialList(IDataReader reader)
			{
				Fetch(reader);
			}

			/// <summary>
			/// Builds a RevisionMaterialList from a IList<!--<RevisionMaterialInfo>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>RevisionMaterialList</returns>
			public static RevisionMaterialList GetChildList(IList<RevisionMaterialInfo> list)
			{
				RevisionMaterialList flist = new RevisionMaterialList();

				if (list.Count > 0)
				{
					flist.IsReadOnly = false;

					foreach (RevisionMaterialInfo item in list)
						flist.AddItem(item);

					flist.IsReadOnly = true;
				}

				return flist;
			}


			/// <summary>
			/// Builds a RevisionMaterialList from IList<!--<RevisionMaterial>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>RevisionMaterialList</returns>
			public static RevisionMaterialList GetChildList(IList<RevisionMaterial> list) { return new RevisionMaterialList(list); }

			public static RevisionMaterialList GetChildList(IDataReader reader) { return new RevisionMaterialList(reader); }

		#endregion

		#region Root Factory Methods

		  //  private RevisionMaterialList() { }

			/// <summary>
			/// Retrieve the complete list from db
			/// </summary>
			/// <returns>RevisionMaterialList</returns>
			public static RevisionMaterialList GetList(bool childs)
			{
				CriteriaEx criteria = RevisionMaterial.GetCriteria(RevisionMaterial.OpenSession());
                criteria.Childs = true;
                criteria.Query = RevisionMaterialList.SELECT();

				//No criteria. Retrieve all de List
				RevisionMaterialList list = DataPortal.Fetch<RevisionMaterialList>(criteria);

				CloseSession(criteria.SessionCode);

				return list;
			}

            /// <summary>
            /// Retrieve the complete list from db
            /// </summary>
            /// <returns>RevisionMaterialList</returns>
            public static RevisionMaterialList GetList()
            {
                return GetList(true);
            }

			/// <summary>
			/// Devuelve una lista de todos los elementos
			/// </summary>
			/// <returns>Lista de elementos</returns>
			public static RevisionMaterialList GetList(CriteriaEx criteria)
			{
				return RevisionMaterialList.RetrieveList(typeof(RevisionMaterial), AppContext.ActiveSchema.Code, criteria);
			}

			/// <summary>
			/// Builds a RevisionMaterialList from a IList<!--<RevisionMaterialInfo>-->
			/// Doesn`t retrieve child data from DB.
			/// </summary>
			/// <param name="list"></param>
			/// <returns>RevisionMaterialList</returns>
			public static RevisionMaterialList GetList(IList<RevisionMaterialInfo> list)
			{
				RevisionMaterialList flist = new RevisionMaterialList();

				if (list.Count > 0)
				{
					flist.IsReadOnly = false;

					foreach (RevisionMaterialInfo item in list)
						flist.AddItem(item);

					flist.IsReadOnly = true;
				}

				return flist;
			}

			/// <summary>
			/// Builds a RevisionMaterialList from a IList<!--<RevisionMaterial>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>RevisionMaterial</returns>
			public static RevisionMaterialList GetList(IList<RevisionMaterial> list)
			{
				RevisionMaterialList flist = new RevisionMaterialList();

				if (list != null)
				{
					flist.IsReadOnly = false;

					foreach (RevisionMaterial item in list)
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
			public static SortedBindingList<RevisionMaterialInfo> GetSortedList(	string sortProperty,
																		ListSortDirection sortDirection)
			{
				SortedBindingList<RevisionMaterialInfo> sortedList =
					new SortedBindingList<RevisionMaterialInfo>(GetList());
				sortedList.ApplySort(sortProperty, sortDirection);
				return sortedList;
			}

		#endregion

		#region Child Data Access

			// called to copy objects data from list
			private void Fetch(IList<RevisionMaterial> lista)
			{
				this.RaiseListChangedEvents = false;

				IsReadOnly = false;
				
				foreach (RevisionMaterial item in lista)
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
					this.AddItem(RevisionMaterialInfo.Get(reader));

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

						//RevisionMaterial.DoLOCK( Session());

                        IDataReader reader = nHMng.SQLNativeSelect(criteria.Query);

						IsReadOnly = false;

						while (reader.Read())
						{
							this.AddItem(RevisionMaterialInfo.Get(reader,Childs));
						}

						IsReadOnly = true;
					}
					else
					{
						IList<RevisionMaterial> list = criteria.List<RevisionMaterial>();

						if (list.Count > 0)
						{
							IsReadOnly = false;

							foreach (RevisionMaterial item in list)
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

						foreach (RevisionMaterial item in list)
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

            public static string SELECT() { return RevisionMaterial.SELECT(new QueryConditions(), false); }

        #endregion

    }
}

