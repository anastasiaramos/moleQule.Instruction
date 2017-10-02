using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library.Instruction;

namespace moleQule.Library.Instruction
{

    /// <summary>
    /// Editable Child Business Object
    /// </summary>
    [Serializable()]
    public class Material_Alumnos : BusinessListBaseEx<Material_Alumnos, Material_Alumno>
    {

        #region Business Methods

        public Material_Alumno NewItem(MaterialDocente parent)
        {
            this.AddItem(Material_Alumno.NewChild(parent));
            return this[Count - 1];
        }

        public Material_Alumno NewItem(Alumno parent)
        {
            this.AddItem(Material_Alumno.NewChild(parent));
            return this[Count - 1];
        }

        #endregion

        #region Factory Methods

        private Material_Alumnos()
        {
            MarkAsChild();
        }

        private Material_Alumnos(IList<Material_Alumno> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private Material_Alumnos(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static Material_Alumnos NewChildList() { return new Material_Alumnos(); }

        public static Material_Alumnos GetChildList(IList<Material_Alumno> lista) { return new Material_Alumnos(lista); }

        public static Material_Alumnos GetChildList(IDataReader reader) { return new Material_Alumnos(reader); }

        public static Material_Alumnos GetChildList(Alumno parent, bool childs, bool g_childs)
        {
            CriteriaEx criteria = Material_Alumno.GetCriteria(parent.SessionCode);

            criteria.Query = Material_Alumnos.SELECT(parent.GetInfo(false));//.SELECT_BY_ALUMNO(parent.Oid);
            criteria.Childs = childs;
            criteria.GChilds = g_childs;

            IDataReader reader = nHManager.Instance.SQLNativeSelect(criteria.Query, parent.Session());
            return Material_Alumnos.GetChildList(reader);
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Material_Alumno> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (Material_Alumno item in lista)
                this.AddItem(Material_Alumno.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(Material_Alumno.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }


        internal void Update(MaterialDocente parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Material_Alumno obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Material_Alumno obj in this)
            {
                if (obj.IsNew)
                    obj.Insert(parent);
                else
                    obj.Update(parent);
            }

            this.RaiseListChangedEvents = true;
        }

        internal void Update(Alumno parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Material_Alumno obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Material_Alumno obj in this)
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

        public static string SELECT(AlumnoInfo item) { return Material_Alumno.SELECT(new QueryConditions() { Alumno = item }, true); }

        public static string SELECT_BY_MATERIAL(long oid_material)
        {
            QueryConditions conditions = new QueryConditions()
            {
                MaterialDocente = MaterialDocenteInfo.New()
            };

            conditions.MaterialDocente.Oid = oid_material;

            return Material_Alumno.SELECT(conditions, true);
        }

        #endregion

    }
}

