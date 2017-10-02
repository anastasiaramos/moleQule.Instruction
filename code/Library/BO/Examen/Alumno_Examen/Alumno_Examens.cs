using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

namespace moleQule.Library.Instruction
{
	/// <summary>
	/// Editable Child Business Object
	/// </summary>
    [Serializable()]
	public class Alumno_Examens : BusinessListBaseEx<Alumno_Examens, Alumno_Examen>
	{

        #region Business Methods

        public Alumno_Examen NewItem(Alumno parent)
        {
            this.AddItem(Alumno_Examen.NewChild(parent));
            return this[Count - 1];
        }

        public Alumno_Examen NewItem(Examen parent)
        {
            this.AddItem(Alumno_Examen.NewChild(parent));
            return this[Count - 1];
        }

        public Alumno_Examen GetItemByExamen(long oid)
        {
            foreach (Alumno_Examen item in this)
                if (item.OidExamen == oid) return item;
            
            return null;
        }

        #endregion

        #region Factory Methods

        private Alumno_Examens()
        {
            MarkAsChild();
        }

        private Alumno_Examens(IList<Alumno_Examen> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private Alumno_Examens(int session_code, IDataReader reader)
        {
            MarkAsChild();
            Fetch(session_code, reader);
        }

        public static Alumno_Examens NewChildList() { return new Alumno_Examens(); }

        public static Alumno_Examens GetChildList(IList<Alumno_Examen> lista) { return new Alumno_Examens(lista); }

        public static Alumno_Examens GetChildList(int session_code, IDataReader reader) { return new Alumno_Examens(session_code, reader); }

        public static Alumno_Examens GetChildList(Alumno parent, bool childs, bool g_childs)
        {
            CriteriaEx criteria = Alumno_Examen.GetCriteria(parent.SessionCode);

            criteria.Query = Alumno_Examens.SELECT(parent.GetInfo(false));
            criteria.Childs = childs;
            criteria.GChilds = g_childs;

            IDataReader reader = nHManager.Instance.SQLNativeSelect(criteria.Query, parent.Session());
            return Alumno_Examens.GetChildList(parent.SessionCode, reader);
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Alumno_Examen> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (Alumno_Examen item in lista)
                this.AddItem(Alumno_Examen.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(int session_code, IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(Alumno_Examen.GetChild(session_code, reader));

            this.RaiseListChangedEvents = true;
        }


        internal void Update(Alumno parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Alumno_Examen obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Alumno_Examen obj in this)
            {
                if (obj.IsNew)
                    obj.Insert(parent);
                else
                    obj.Update(parent);
            }

            this.RaiseListChangedEvents = true;
        }

        internal void Update(Examen parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Alumno_Examen obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Alumno_Examen obj in this)
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

        public new static string SELECT_BY_FIELD(string field, object field_value)
        {
            string alumno_examen = nHManager.Instance.GetSQLTable(typeof(AlumnoExamenRecord));
            string examen = nHManager.Instance.GetSQLTable(typeof(ExamenRecord));
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            
            field = nHManager.Instance.GetTableField(typeof(AlumnoExamenRecord), field);

            string query = string.Empty;

            query = "SELECT AE.*, E.\"FECHA_EXAMEN\", E.\"DESARROLLO\", M.\"NUMERO_MODULO\", M.\"TEXTO\" " +
                "FROM " + alumno_examen + " AS AE " +
                "INNER JOIN " + examen + " AS E ON (E.\"OID\" = AE.\"OID_EXAMEN\") " +
                "INNER JOIN " + modulo + " AS M ON (M.\"OID\" = E.\"OID_MODULO\") " +
                "WHERE AE.\"" + field + "\" = " + field_value.ToString() + " " +
                "ORDER BY M.\"NUMERO_ORDEN\", E.\"DESARROLLO\", E.\"FECHA_EXAMEN\";";

            return query;
        }

        public static string SELECT(AlumnoInfo item) { return Alumno_Examen.SELECT(new QueryConditions() { Alumno = item }, false); }
        public static string SELECT(ExamenInfo item) { return Alumno_Examen.SELECT(new QueryConditions() { Examen = item }, true); }

        #endregion

    }
}

