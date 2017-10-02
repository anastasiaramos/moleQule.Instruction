using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

namespace moleQule.Library.Instruction
{
	/// <summary>
	/// Editable Child Collection
	/// </summary>
    [Serializable()]
	public class RevisionMaterials : BusinessListBaseEx<RevisionMaterials, RevisionMaterial>
	{
        #region Business Methods

        public RevisionMaterial NewItem(MaterialDocente parent)
        {
            this.AddItem(RevisionMaterial.NewChild(parent));
            return this[Count - 1];
        }

        #endregion

        #region Factory Methods

        private RevisionMaterials()
        {
            MarkAsChild();
        }

        private RevisionMaterials(IList<RevisionMaterial> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private RevisionMaterials(int session_code, IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(session_code, reader);
        }

        public static RevisionMaterials NewChildList() { return new RevisionMaterials(); }

        public static RevisionMaterials GetChildList(IList<RevisionMaterial> lista) { return new RevisionMaterials(lista); }

        public static RevisionMaterials GetChildList(int session_code, IDataReader reader, bool childs) { return new RevisionMaterials(session_code, reader, childs); }

        public static RevisionMaterials GetChildList(int session_code, IDataReader reader) { return GetChildList(session_code, reader, true); }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<RevisionMaterial> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (RevisionMaterial item in lista)
                this.AddItem(RevisionMaterial.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(int session_code, IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(RevisionMaterial.GetChild(session_code, reader));

            this.RaiseListChangedEvents = true;
        }


        internal void Update(MaterialDocente parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (RevisionMaterial obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (RevisionMaterial obj in this)
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

        public static string SELECT_BY_MATERIAL(long oid_material)
        {
            QueryConditions conditions = new QueryConditions()
            {
                MaterialDocente = MaterialDocenteInfo.New()
            };

            conditions.MaterialDocente.Oid = oid_material;

            return RevisionMaterial.SELECT(conditions, true);
        }

        #endregion
	
	}
}

