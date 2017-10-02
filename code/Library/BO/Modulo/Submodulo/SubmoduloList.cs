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
	public class SubmoduloList : ReadOnlyListBaseEx<SubmoduloList, SubmoduloInfo>
	{

		#region Child Factory Methods

		private SubmoduloList() { }

		private SubmoduloList(IList<Submodulo> lista)
		{
			Fetch(lista);
		}

		private SubmoduloList(IDataReader reader, bool childs)
		{
			Fetch(reader, childs);
		}

		/// <summary>
		/// Builds a SubmoduloList from a IList<!--<SubmoduloInfo>-->
		/// </summary>
		/// <param name="list"></param>
		/// <returns>SubmoduloList</returns>
		public static SubmoduloList GetChildList(IList<SubmoduloInfo> list)
		{
			SubmoduloList flist = new SubmoduloList();

			if (list.Count > 0)
			{
				flist.IsReadOnly = false;

				foreach (SubmoduloInfo item in list)
					flist.AddItem(item);

				flist.IsReadOnly = true;
			}

			return flist;
		}


		/// <summary>
		/// Builds a SubmoduloList from IList<!--<Submodulo>-->
		/// </summary>
		/// <param name="list"></param>
		/// <returns>SubmoduloList</returns>
		public static SubmoduloList GetChildList(IList<Submodulo> list) { return new SubmoduloList(list); }

        public static SubmoduloList GetChildList(IDataReader reader) { return new SubmoduloList(reader, false); }

        public static SubmoduloList GetChildList(IDataReader reader, bool childs) { return new SubmoduloList(reader, childs); }

		#endregion

		#region Root Factory Methods

		//  private SubmoduloList() { }

		/// <summary>
		/// Retrieve the complete list from db
		/// </summary>
		/// <returns>SubmoduloList</returns>
		public static SubmoduloList GetList(bool childs)
		{
			CriteriaEx criteria = Submodulo.GetCriteria(SubmoduloList.OpenSession());
			criteria.Childs = childs;

			//No criteria. Retrieve all de List
            criteria.Query = SubmoduloList.SELECT();
			SubmoduloList list = DataPortal.Fetch<SubmoduloList>(criteria);

			CloseSession(criteria.SessionCode);

			return list;
		}

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>SubmoduloList</returns>
        public static SubmoduloList GetModuloList(long oid_modulo, bool childs)
        {
            CriteriaEx criteria = Submodulo.GetCriteria(SubmoduloList.OpenSession());
            criteria.Childs = childs;
            criteria.Query = Submodulos.SELECT_BY_MODULO(oid_modulo);

            //No criteria. Retrieve all de List
            SubmoduloList list = DataPortal.Fetch<SubmoduloList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

		/// <summary>
		/// Retrieve the complete list from db
		/// </summary>
		/// <returns>SubmoduloList</returns>
		public static SubmoduloList GetList()
		{
			return GetList(true);
		}

		/// <summary>
		/// Devuelve una lista de todos los elementos
		/// </summary>
		/// <returns>Lista de elementos</returns>
		public static SubmoduloList GetList(CriteriaEx criteria)
		{
			return SubmoduloList.RetrieveList(typeof(Submodulo), AppContext.ActiveSchema.Code, criteria);
		}

		/// <summary>
		/// Builds a SubmoduloList from a IList<!--<SubmoduloInfo>-->
		/// Doesn`t retrieve child data from DB.
		/// </summary>
		/// <param name="list"></param>
		/// <returns>SubmoduloList</returns>
		public static SubmoduloList GetList(IList<SubmoduloInfo> list)
		{
			SubmoduloList flist = new SubmoduloList();

			if (list.Count > 0)
			{
				flist.IsReadOnly = false;

				foreach (SubmoduloInfo item in list)
					flist.AddItem(item);

				flist.IsReadOnly = true;
			}

			return flist;
		}

		/// <summary>
		/// Builds a SubmoduloList from a IList<!--<Submodulo>-->
		/// </summary>
		/// <param name="list"></param>
		/// <returns>Submodulo</returns>
		public static SubmoduloList GetList(IList<Submodulo> list)
		{
			SubmoduloList flist = new SubmoduloList();

			if (list != null)
			{
				flist.IsReadOnly = false;

				foreach (Submodulo item in list)
					flist.AddItem(item.GetInfo());

				flist.IsReadOnly = true;
			}

			return flist;
		}

		/// <summary>
		/// Devuelve una lista de todos los elementos
		/// </summary>
		/// <returns>Lista de elementos</returns>
		public static Submodulo_Instructor_PromocionList GetInstructorList(long oid_instructor)
		{
			Submodulo_Instructor_PromocionList lista = null;

			CriteriaEx criteria = Submodulo_Instructor_Promocion.GetCriteria(Submodulo_Instructor_Promocion.OpenSession());
			criteria.AddEq("OidInstructor", oid_instructor);
			lista = Submodulo_Instructor_PromocionList.RetrieveList(typeof(Submodulo_Instructor_Promocion), AppContext.ActiveSchema.Code, criteria);

            CloseSession(criteria.SessionCode);

			return lista;
		}


		/// <summary>
		/// Devuelve una lista ordenada de todos los elementos
		/// </summary>
		/// <param name="sortProperty">Campo de ordenación</param>
		/// <param name="sortDirection">Sentido de ordenación</param>
		/// <returns>Lista ordenada de elementos</returns>
		public static SortedBindingList<SubmoduloInfo> GetSortedList(string sortProperty,
																	ListSortDirection sortDirection)
		{
			SortedBindingList<SubmoduloInfo> sortedList =
				new SortedBindingList<SubmoduloInfo>(GetList(false));
			sortedList.ApplySort(sortProperty, sortDirection);
			return sortedList;
		}

		public SubmoduloList GetSubmodulosOrdenados()
		{
			for (int i = 0; i < this.Count; i++)
			{
				for (int j = i + 1; j < this.Count; j++)
				{
					if (Convert.ToDouble(this[j].Codigo) < Convert.ToDouble(this[i].Codigo))
					{
						SubmoduloInfo aux = this[i];
						this[i] = this[j];
						this[j] = aux;
					}
				}
			}
			return this;
		}


		#endregion

		#region Child Data Access

		// called to copy objects data from list
		private void Fetch(IList<Submodulo> lista)
		{
			this.RaiseListChangedEvents = false;

			IsReadOnly = false;

			foreach (Submodulo item in lista)
				this.AddItem(item.GetInfo());

			IsReadOnly = true;

			this.RaiseListChangedEvents = true;
		}

		// called to copy objects data from list
		private void Fetch(IDataReader reader, bool childs)
		{
			this.RaiseListChangedEvents = false;

			IsReadOnly = false;

			while (reader.Read())
				this.AddItem(SubmoduloInfo.Get(reader, childs));

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

                    reader = nHManager.Instance.SQLNativeSelect(criteria.Query,Session());

					IsReadOnly = false;

					while (reader.Read())
					{
						this.AddItem(SubmoduloInfo.Get(reader, Childs));
					}

					IsReadOnly = true;
				}
				else
				{
					IList<Submodulo> list = criteria.List<Submodulo>();

					if (list.Count > 0)
					{
						IsReadOnly = false;

						foreach (Submodulo item in list)
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

					foreach (Submodulo item in list)
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

        public static string SELECT() { return Submodulo.SELECT(new QueryConditions(), false); }
        public static string SELECT_BY_MODULO(long oid_modulo) { return Submodulos.SELECT_BY_MODULO(oid_modulo, false); }
        
        #endregion

    }
}

