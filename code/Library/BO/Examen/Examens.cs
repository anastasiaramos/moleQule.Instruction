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
    public class Examens : BusinessListBaseEx<Examens, Examen>
    {

        #region Business Methods


        //public Examen NewItem(Promocion parent)
        //{
        //    this.AddItem(Examen.NewChild(parent));
        //    return this[Count - 1];
        //}

        public Examen NewItem(Instructor parent)
        {
            this.AddItem(Examen.NewChild(parent));
            return this[Count - 1];
        }

        //public Examen NewItem(Modulo parent)
        //{
        //    this.AddItem(Examen.NewChild(parent));
        //    return this[Count - 1];
        //}

        #endregion

        #region Factory Methods

        private Examens()
        {
            MarkAsChild();
        }

        private Examens(IList<Examen> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private Examens(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }


        public static Examens NewChildList() { return new Examens(); }

        public static Examens GetChildList(IList<Examen> lista) { return new Examens(lista); }

        public static Examens GetChildList(IDataReader reader, bool childs) { return new Examens(reader, childs); }

        public static Examens GetChildList(IDataReader reader) { return GetChildList(reader, true); }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Examen> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (Examen item in lista)
                this.AddItem(Examen.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(Examen.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }


        //internal void Update(Promocion parent)
        //{
        //    this.RaiseListChangedEvents = false;

        //    // update (thus deleting) any deleted child objects
        //    foreach (Examen obj in DeletedList)
        //        obj.DeleteSelf(parent);

        //    // now that they are deleted, remove them from memory too
        //    DeletedList.Clear();

        //    // AddItem/update any current child objects
        //    foreach (Examen obj in this)
        //    {
        //        if (obj.IsNew)
        //            obj.Insert(parent);
        //        else
        //            obj.Update(parent);
        //    }

        //    this.RaiseListChangedEvents = true;
        //}

        internal void Update(Instructor parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Examen obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Examen obj in this)
            {
                if (obj.IsNew)
                    obj.Insert(parent);
                else
                    obj.Update(parent);
            }

            this.RaiseListChangedEvents = true;
        }

        //internal void Update(Modulo parent)
        //{
        //    this.RaiseListChangedEvents = false;

        //    // update (thus deleting) any deleted child objects
        //    foreach (Examen obj in DeletedList)
        //        obj.DeleteSelf(parent);

        //    // now that they are deleted, remove them from memory too
        //    DeletedList.Clear();

        //    // AddItem/update any current child objects
        //    foreach (Examen obj in this)
        //    {
        //        if (obj.IsNew)
        //            obj.Insert(parent);
        //        else
        //            obj.Update(parent);
        //    }

        //    this.RaiseListChangedEvents = true;
        //}

        #endregion

        #region SQL

        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public static string SELECT_EXAMENES_PENDIENTES(long oid_promocion)
        {
            string examen = nHManager.Instance.Cfg.GetClassMapping(typeof(ExamenRecord)).Table.Name;

            string query;

            query = "SELECT e.* " +
                    "FROM \"0001\".\"Examen\" as e " +
                    "WHERE e.\"OID_PROMOCION\" = " + oid_promocion.ToString() + ";";

            return query;
        }

        public static string SELECT_BY_INSTRUCTOR(string schema, string parent_field, object field_value)
        {
            string tabla = "Examen";
            string columna = "OID_PROFESOR";
            string query;

            schema = (schema == "COMMON") ? schema : Convert.ToInt32(schema).ToString("0000");

            query = "SELECT * " +
                    "FROM \"" + schema + "\".\"" + tabla + "\" " +
                    "WHERE \"" + columna + "\" = " + field_value.ToString() + ";";

            return query;
        }

        public static new string SELECT_BY_FIELD(string field, object field_value)
        {
            string e = nHManager.Instance.GetSQLTable(typeof(ExamenRecord));
            string m = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string em = nHManager.Instance.GetSQLTable(typeof(InstructorRecord));
            string p = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));
            string columna = nHManager.Instance.GetTableField(typeof(ExamenRecord), field);

            string query;

            query = Examen.SELECT_FIELDS() +
                    " FROM " + e + " AS E" +
                    " INNER JOIN " + m + " AS M ON E.\"OID_MODULO\" = M.\"OID\"" +
                    " LEFT JOIN " + em + " AS EM ON E.\"OID_PROFESOR\" = EM.\"OID\"" +
                    " LEFT JOIN " + p + " AS P ON E.\"OID_PROMOCION\" = P.\"OID\"" +
                    "WHERE \"" + columna + "\" = " + field_value.ToString() + ";";
            
            return query;
        }


        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public static string SELECT_BY_FECHA(DateTime fecha_examen)
        {
            string examen = nHManager.Instance.GetSQLTable(typeof(ExamenRecord));
            string instructor = nHManager.Instance.GetSQLTable(typeof(InstructorRecord));
            string promocion = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string fecha = fecha_examen.Year.ToString() + "-" +
                           fecha_examen.Month.ToString() + "-" +
                           fecha_examen.Day.ToString();

            string query;

            query = "SELECT e.*, " +
                    "'' AS \"INSTRUCTOR\", '' AS \"PROMOCION\", '' AS \"MODULO\" " +
                    //i.\"ALIAS\" AS \"INSTRUCTOR\", p.\"NOMBRE\" AS \"PROMOCION\", m.\"TEXTO\" AS \"MODULO\" " +
                    "FROM " + examen + " AS e " +
                    //"INNER JOIN " + instructor + " AS i ON (i.\"OID\" = e.\"OID_PROFESOR\") " +
                    //"INNER JOIN " + promocion + " AS p ON (i.\"OID\" = e.\"OID_PROMOCION\") " +
                    //"INNER JOIN " + modulo + " AS m ON (i.\"OID\" = e.\"OID_MODULO\") " +
                    "WHERE e.\"FECHA_EXAMEN\" = '" + fecha + "';";

            return query;
        }

        #endregion

    }
}

