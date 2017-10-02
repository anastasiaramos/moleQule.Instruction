using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;

namespace moleQule.Library.Instruction
{
	/// <summary>
	/// Editable Child Business Object
	/// </summary>
    [Serializable()]
	public class Material_Plans : BusinessListBaseEx<Material_Plans, Material_Plan>
	{

        #region Business Methods

        public Material_Plan NewItem(MaterialDocente parent)
        {
            this.AddItem(Material_Plan.NewChild(parent));
            return this[Count - 1];
        }

        public Material_Plan NewItem(Modulo parent)
        {
            this.AddItem(Material_Plan.NewChild(parent));
            return this[Count - 1];
        }

        public Material_Plan NewItem(RevisionMaterial parent)
        {
            this.AddItem(Material_Plan.NewChild(parent));
            return this[Count - 1];
        }

        #endregion

        #region Factory Methods

        private Material_Plans()
        {
            MarkAsChild();
        }

        private Material_Plans(IList<Material_Plan> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private Material_Plans(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static Material_Plans NewChildList() { return new Material_Plans(); }

        public static Material_Plans GetChildList(IList<Material_Plan> lista) { return new Material_Plans(lista); }

        public static Material_Plans GetChildList(IDataReader reader) { return new Material_Plans(reader); }

        public static Material_Plans GetChildList(Modulo parent, bool childs)
        {
            CriteriaEx criteria = Material_Plan.GetCriteria(parent.SessionCode);
            criteria.Query = Material_Plans.SELECT(parent.GetInfo(false));
            criteria.Childs = childs;

            return DataPortal.Fetch<Material_Plans>(criteria);
        }

        #endregion

        #region Root Data Access

        /// <summary>
        /// Construye el objeto y se encarga de obtener los
        /// hijos si los tiene y se solicitan
        /// </summary>
        /// <param name="criteria">Criterios de la consulta</param>
        /// <remarks>LA UTILIZA EL DATAPORTAL</remarks>
        private void DataPortal_Fetch(CriteriaEx criteria)
        {
            Fetch(criteria);
        }

        /// <summary>
        /// Construye el objeto y se encarga de obtener los
        /// hijos si los tiene y se solicitan
        /// </summary>
        /// <param name="criteria">Criterios de la consulta</param>
        private void Fetch(CriteriaEx criteria)
        {
            try
            {
                this.RaiseListChangedEvents = false;
                SessionCode = criteria.SessionCode;
                Childs = criteria.Childs;

                if (nHMng.UseDirectSQL)
                {
                    Material_Plan.DoLOCK(Session());
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                    while (reader.Read())
                        this.AddItem(Material_Plan.GetChild(reader));
                }
            }
            catch (NHibernate.ADOException ex)
            {
                if (Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.ThrowExceptionByCode(ex);
            }
            catch (Exception ex)
            {
                if (Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                this.RaiseListChangedEvents = true;
            }
        }

        #endregion

        #region Child Data Access
		 
	 	// called to copy objects data from list
		private void Fetch(IList<Material_Plan> lista)
		{
			this.RaiseListChangedEvents = false;
			
			foreach (Material_Plan item in lista)
				this.AddItem(Material_Plan.GetChild(item));
			
			this.RaiseListChangedEvents = true;
		}

		private void Fetch(IDataReader reader)
		{
			this.RaiseListChangedEvents = false;

			while (reader.Read())
				this.AddItem(Material_Plan.GetChild(reader));

			this.RaiseListChangedEvents = true;
		}

        internal void Update(MaterialDocente parent)
		{
			this.RaiseListChangedEvents = false;

			// update (thus deleting) any deleted child objects
			foreach (Material_Plan obj in DeletedList)
				obj.DeleteSelf(parent);

			// now that they are deleted, remove them from memory too
			DeletedList.Clear();

			// AddItem/update any current child objects
			foreach (Material_Plan obj in this)
			{
				if (obj.IsNew)
					obj.Insert(parent);
				else
					obj.Update(parent);
			}

			this.RaiseListChangedEvents = true;
		}

        internal void Update(Modulo parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Material_Plan obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Material_Plan obj in this)
            {
                if (obj.IsNew)
                    obj.Insert(parent);
                else
                    obj.Update(parent);
            }

            this.RaiseListChangedEvents = true;
        }

        internal void Update(RevisionMaterial parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Material_Plan obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Material_Plan obj in this)
            {
                if (obj.IsNew)
                    obj.Insert(parent);
                else
                    obj.Update(parent);
            }

            this.RaiseListChangedEvents = true;
        }
	 
        #endregion

        #region SQL

        internal static string SELECT_BY_FIELD(string parent_field, object field_value, bool lock_table)
        {
            string tabla = nHManager.Instance.GetSQLTable(typeof(Material_PlanRecord));
            string m = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string md = nHManager.Instance.GetSQLTable(typeof(MaterialDocenteRecord));
            string r = nHManager.Instance.GetSQLTable(typeof(RevisionMaterialRecord));
            string columna = nHManager.Instance.GetTableField(typeof(Material_PlanRecord), parent_field);

            string query;

            query = Material_Plan.SELECT_FIELDS() +
                    " FROM " + tabla + " AS MP" +
                    " INNER JOIN " + m + " AS M ON MP.\"OID_MODULO\" = M.\"OID\"" +
                    " INNER JOIN " + md + " AS MD ON MP.\"OID_MATERIAL\" = MD.\"OID\"" +
                    " LEFT JOIN " + r + " AS RM ON MP.\"OID_REVISION\" = RM.\"OID\"" +
                    " WHERE MP.\"" + columna + "\" = " + field_value.ToString();

            if (lock_table) query += " FOR UPDATE OF MP NOWAIT";

            return query;
        }

        public new static string SELECT_BY_FIELD(string parent_field, object field_value)
        {
            return Material_Plans.SELECT_BY_FIELD(parent_field, field_value, true);
        }

        public static string SELECT_BY_MATERIAL(long oid_material)
        {
            QueryConditions conditions = new QueryConditions()
            {
                MaterialDocente = MaterialDocenteInfo.New()
            };

            conditions.MaterialDocente.Oid = oid_material;

            return Material_Plan.SELECT(conditions, true);
        }

        public static string SELECT(ModuloInfo item) { return Material_Plan.SELECT(new QueryConditions() { Modulo = item }, true); }
        public static string SELECT(MaterialDocenteInfo item) { return Material_Plan.SELECT(new QueryConditions() { MaterialDocente = item }, true); }
        public static string SELECT(RevisionMaterialInfo item) { return Material_Plan.SELECT(new QueryConditions() { RevisionMaterial = item }, true); }

        #endregion

    }
}

