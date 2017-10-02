using System;
using System.Collections.Generic;
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
	public class Material_PlanList : ReadOnlyListBaseEx<Material_PlanList, Material_PlanInfo>
	{		 
		 
		#region Factory Methods

		private Material_PlanList() { }

		private Material_PlanList(IList<Material_Plan> lista)
		{
			Fetch(lista);
		}

		private Material_PlanList(IDataReader reader)
		{
			Fetch(reader);
		}

		/// <summary>
		/// Builds a Material_PlanList from a IList<!--<Material_PlanInfo>-->
		/// </summary>
		/// <param name="list"></param>
		/// <returns>Material_PlanList</returns>
		public static Material_PlanList GetChildList(IList<Material_PlanInfo> list)
		{
			Material_PlanList flist = new Material_PlanList();

			if (list.Count > 0)
			{
				flist.IsReadOnly = false;

				foreach (Material_PlanInfo item in list)
					flist.AddItem(item);

				flist.IsReadOnly = true;
			}

			return flist;
		}

		/// <summary>
		/// Builds a Material_PlanList from IList<!--<Material_Plan>-->
		/// </summary>
		/// <param name="list"></param>
		/// <returns>Material_PlanList</returns>
		public static Material_PlanList GetChildList(IList<Material_Plan> list) { return new Material_PlanList(list); }

		public static Material_PlanList GetChildList(IDataReader reader) { return new Material_PlanList(reader); }

		#endregion

        #region Data Access

        // called to copy objects data from list
        private void Fetch(IList<Material_Plan> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (Material_Plan item in lista)
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
                this.AddItem(Material_Plan.GetChild(reader).GetInfo());

            IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }

        // called to retrieve data from db
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
                        this.AddItem(Material_PlanInfo.GetChild(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList<Material_Plan> list = criteria.List<Material_Plan>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (Material_Plan item in list)
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

        #region SQL

        public static string SELECT_BY_FIELD(string parent_field, object field_value)
        {
            return Material_Plans.SELECT_BY_FIELD(parent_field, field_value, false);
        }

        public static string SELECT(ModuloInfo item) { return Material_Plan.SELECT(new QueryConditions() { Modulo = item }, false); }
        public static string SELECT(MaterialDocenteInfo item) { return Material_Plan.SELECT(new QueryConditions() { MaterialDocente = item }, false); }
        public static string SELECT(RevisionMaterialInfo item) { return Material_Plan.SELECT(new QueryConditions() { RevisionMaterial = item }, false); }

        #endregion
	}
}

