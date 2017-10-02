using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library.Instruction;

namespace moleQule.Library.Instruction
{

    /// <summary>
    /// Editable Child Collection
    /// </summary>
    [Serializable()]
    public class Instructor_Promociones : BusinessListBaseEx<Instructor_Promociones, Instructor_Promocion>
    {

        #region Business Methods


        public Instructor_Promocion NewItem(Instructor parent)
        {
            this.AddItem(Instructor_Promocion.NewChild(parent));
            return this[Count - 1];
        }

        public Instructor_Promocion GetByOidPromocion(long oid_promocion)
        {
            foreach (Instructor_Promocion obj in this)
                if (obj.OidPromocion == oid_promocion)
                    return obj;
            return null;
        }

        #endregion

        #region Factory Methods

        private Instructor_Promociones()
        {
            MarkAsChild();
        }

        private Instructor_Promociones(IList<Instructor_Promocion> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private Instructor_Promociones(int session_code, IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(session_code, reader);
        }

        public static Instructor_Promociones NewChildList() { return new Instructor_Promociones(); }

        public static Instructor_Promociones GetChildList(IList<Instructor_Promocion> lista) { return new Instructor_Promociones(lista); }

        public static Instructor_Promociones GetChildList(int session_code, IDataReader reader, bool childs) { return new Instructor_Promociones(session_code, reader, childs); }

        public static Instructor_Promociones GetChildList(int session_code, IDataReader reader) { return GetChildList(session_code, reader, true); }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <param name="get_childs">retrieving the childs</param>
        /// <returns></returns>
        public static Instructor_Promociones GetList()
        {
            Instructor_Promociones lista = Instructor_Promociones.NewChildList();

            Instructor_PromocionList submodulos = Instructor_PromocionList.GetList(false);

            foreach (Instructor_PromocionInfo info in submodulos)
            {
                Instructor_Promocion item = Instructor_Promocion.Get(info.Oid);
                item.MarkItemChild();
                lista.AddItem(item);
            }

            return lista;
        }


        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Instructor_Promocion> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (Instructor_Promocion item in lista)
                this.AddItem(Instructor_Promocion.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(int session_code, IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(Instructor_Promocion.GetChild(session_code, reader));

            this.RaiseListChangedEvents = true;
        }


        internal void Update(Instructor parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Instructor_Promocion obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Instructor_Promocion obj in this)
            {
                if (!obj.IsDirty) continue;
                if (obj.IsNew)
                    obj.Insert(parent);
                else
                    obj.Update(parent);
            }

            this.RaiseListChangedEvents = true;
        }

        #endregion

        #region SQL

        public static string SELECT_BY_INSTRUCTOR(long oid_instructor)
        {
            string tabla = nHManager.Instance.GetSQLTable(typeof(Instructor_PromocionRecord));
            string promocion = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));
            string query;

            query = "SELECT *" +
                    " FROM " + tabla + " AS IP " +
                    " INNER JOIN " + promocion + " AS P ON (IP.\"OID_PROMOCION\" = P.\"OID\") " +
                    " WHERE IP.\"OID_INSTRUCTOR\" = " + oid_instructor.ToString() + 
                    " ORDER BY P.\"NOMBRE\"";

            return query;
        }

        public static string SELECT_BY_INSTRUCTOR_PROMOCION(long oid_instructor, long oid_promocion)
        {
            string tabla = nHManager.Instance.GetSQLTable(typeof(Instructor_PromocionRecord));
            string promocion = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));
            string query;

            query = "SELECT *" +
                    " FROM " + tabla + " AS IP " +
                    " INNER JOIN " + promocion + " AS P ON (IP.\"OID_PROMOCION\" = P.\"OID\") " +
                    " WHERE IP.\"OID_INSTRUCTOR\" = " + oid_instructor.ToString() + " AND IP.\"OID_PROMOCION\" = " + oid_promocion.ToString() + ";";

            return query;
        }

        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public static string SELECT_BY_FIELD(string schema, string oid_instructor, long oid)
        {
            string instructor_promocion = nHManager.Instance.Cfg.GetClassMapping(typeof(Instructor_PromocionRecord)).Table.Name;
            string promocion = nHManager.Instance.Cfg.GetClassMapping(typeof(PromocionRecord)).Table.Name;
            string oid_promocion = nHManager.Instance.GetTableField(typeof(Instructor_PromocionRecord), "OidPromocion");
            string _oid = nHManager.Instance.GetTableField(typeof(Submodulo_Instructor_PromocionRecord), oid_instructor);

            string query;

            string esquema = Convert.ToInt32(schema).ToString("0000");

            query = "SELECT * " +
                    "FROM \"" + esquema + "\".\"" + instructor_promocion + "\" " +
                    "INNER JOIN \"" + esquema + "\".\"" + promocion + "\" AS p ON (\"" + oid_promocion + "\" = p.\"OID\") " +
                    "WHERE \"" + _oid + "\" = " + oid.ToString() + " " +
                    "ORDER BY p.\"NOMBRE\";";

            return query;
        }

        #endregion

    }
}

