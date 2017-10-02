using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;

namespace moleQule.Library.Instruction
{

    /// <summary>
    /// Editable Child Collection
    /// </summary>
    [Serializable()]
    public class Submodulos_Instructores : BusinessListBaseEx<Submodulos_Instructores, Submodulo_Instructor>
    {

        #region Business Methods

        public Submodulo_Instructor NewItem(Instructor parent)
        {
            this.AddItem(Submodulo_Instructor.NewChild(parent));
            return this[Count - 1];
        }

        public Submodulo_Instructor NewItem(Submodulo parent)
        {
            this.AddItem(Submodulo_Instructor.NewChild(parent));
            return this[Count - 1];
        }

        #endregion

        #region Factory Methods

        private Submodulos_Instructores()
        {
            MarkAsChild();
        }

        private Submodulos_Instructores(IList<Submodulo_Instructor> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }


        private Submodulos_Instructores(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }



        public static Submodulos_Instructores NewChildList() { return new Submodulos_Instructores(); }

        public static Submodulos_Instructores GetChildList(IList<Submodulo_Instructor> lista) { return new Submodulos_Instructores(lista); }

        public static Submodulos_Instructores GetChildList(IDataReader reader) { return new Submodulos_Instructores(reader); }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Submodulo_Instructor> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (Submodulo_Instructor item in lista)
                this.AddItem(Submodulo_Instructor.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(Submodulo_Instructor.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }


        internal void Update(Instructor parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Submodulo_Instructor obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Submodulo_Instructor obj in this)
            {
                if (obj.IsNew)
                    obj.Insert(parent);
                else
                    obj.Update(parent);
            }

            this.RaiseListChangedEvents = true;
        }

        internal void Update(Submodulo parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Submodulo_Instructor obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Submodulo_Instructor obj in this)
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

        public static string SELECT()
        {
            string submodulo_ = nHManager.Instance.GetSQLTable(typeof(Submodulo_InstructorRecord));
            string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));

            string query;

            query = "SELECT *, M.\"OID\" AS \"OID_MODULO\"" +
                   " FROM " + submodulo_ + " AS SI" +
                   " INNER JOIN " + submodulo + " AS S ON (\"OID_SUBMODULO\" = S.\"OID\")" +
                   " INNER JOIN " + modulo + " AS M ON (S.\"OID_MODULO\" = M.\"OID\")" +
                   " ORDER BY M.\"NUMERO_ORDEN\", S.\"CODIGO_ORDEN\"";

            return query;
        }

        public static string SELECT_BY_INSTRUCTOR(long oid_instructor)
        {
            string tabla = nHManager.Instance.GetSQLTable(typeof(Submodulo_InstructorRecord));
            string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));

            string query;
            
            query = "SELECT SI.*," +
                    "       M.\"OID\" AS \"OID_MODULO\"" +
                    " FROM " + tabla + " AS SI" +
                    " INNER JOIN " + submodulo + " AS S ON (SI.\"OID_SUBMODULO\" = S.\"OID\")" +
                    " INNER JOIN " + modulo + " AS M ON (S.\"OID_MODULO\" = M.\"OID\")" +
                    " WHERE SI.\"OID_INSTRUCTOR\" = " + oid_instructor.ToString() +
                    " ORDER BY M.\"NUMERO_ORDEN\", S.\"CODIGO_ORDEN\"";

            return query;
        }

        public static string SELECT_BY_FIELD(string oid_instructor, long oid)
        {
            string tabla = nHManager.Instance.GetSQLTable(typeof(Submodulo_InstructorRecord));
            string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord)); 
            string oid_submodulo = nHManager.Instance.GetTableField(typeof(Submodulo_InstructorRecord), "OidSubmodulo");
 
            string query;

            query = "SELECT SI.*," +
                    "       M.\"OID\" AS \"OID_MODULO\"" +
                    " FROM " + tabla + " AS SI" +
                    " INNER JOIN " + submodulo + " AS S ON (SI.\"OID_SUBMODULO\" = S.\"OID\")" +
                    " INNER JOIN " + modulo + " AS M ON (S.\"OID_MODULO\" = M.\"OID\")" +
                    " WHERE SI.\"OID_INSTRUCTOR\" = " + oid.ToString() +
                    " ORDER BY M.\"NUMERO_ORDEN\", S.\"CODIGO_ORDEN\"";

            return query;
        }

        #endregion

    }
}

