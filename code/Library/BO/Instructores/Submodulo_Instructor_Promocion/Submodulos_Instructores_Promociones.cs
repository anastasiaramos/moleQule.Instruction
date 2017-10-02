using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.ComponentModel;

using Csla;
using moleQule.Library.CslaEx;

using NHibernate;
using moleQule.Library;

namespace moleQule.Library.Instruction
{
    /// <summary>
    /// Editable Child Business Object
    /// </summary>
    [Serializable()]
    public class Submodulos_Instructores_Promociones : BusinessListBaseEx<Submodulos_Instructores_Promociones, Submodulo_Instructor_Promocion>
    {

        #region Business Methods


        public Submodulo_Instructor_Promocion NewItem(Submodulo parent)
        {
            this.AddItem(Submodulo_Instructor_Promocion.NewChild(parent));
            return this[Count - 1];
        }

        public Submodulo_Instructor_Promocion NewItem(Instructor parent)
        {
            this.AddItem(Submodulo_Instructor_Promocion.NewChild(parent));
            return this[Count - 1];
        }

        public Submodulo_Instructor_Promocion NewItem(Instructor_Promocion parent)
        {
            this.AddItem(Submodulo_Instructor_Promocion.NewChild(parent));
            return this[Count - 1];
        }

        //public Submodulo_Instructor_Promocion GetItem(long oid)
        //{
        //    foreach (Submodulo_Instructor_Promocion obj in this)
        //        if (obj.Oid == oid)
        //            return obj;
        //    return null;
        //}


        #endregion

        #region Factory Methods

        private Submodulos_Instructores_Promociones()
        {
            MarkAsChild();
        }

        private Submodulos_Instructores_Promociones(IList<Submodulo_Instructor_Promocion> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private Submodulos_Instructores_Promociones(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static Submodulos_Instructores_Promociones NewChildList() { return new Submodulos_Instructores_Promociones(); }

        public static Submodulos_Instructores_Promociones GetChildList(IList<Submodulo_Instructor_Promocion> lista) { return new Submodulos_Instructores_Promociones(lista); }

        public static Submodulos_Instructores_Promociones GetChildList(IDataReader reader) { return new Submodulos_Instructores_Promociones(reader); }

        public Submodulos_Instructores_Promociones GetChildList(long oid_promocion)
        {
            Submodulos_Instructores_Promociones lista = Submodulos_Instructores_Promociones.NewChildList();

            foreach (Submodulo_Instructor_Promocion item in this)
            {
                if (item.OidPromocion == oid_promocion)
                    lista.AddItem(item);
            }

            return lista;
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Submodulo_Instructor_Promocion> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (Submodulo_Instructor_Promocion item in lista)
                this.AddItem(Submodulo_Instructor_Promocion.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(Submodulo_Instructor_Promocion.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }


        internal void Update(Submodulo parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Submodulo_Instructor_Promocion obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Submodulo_Instructor_Promocion obj in this)
            {
                if (obj.IsNew)
                    obj.Insert(parent);
                else
                    obj.Update(parent);
            }

            this.RaiseListChangedEvents = true;
        }

        internal void Update(Instructor parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Submodulo_Instructor_Promocion obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Submodulo_Instructor_Promocion obj in this)
            {
                if (obj.OidSubmodulo != 0)
                {
                    if (obj.IsNew)
                        obj.Insert(parent);
                    else
                        obj.Update(parent);
                }
            }

            this.RaiseListChangedEvents = true;
        }


        internal void Update(Instructor_Promocion parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Submodulo_Instructor_Promocion obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Submodulo_Instructor_Promocion obj in this)
            {
                if (obj.OidPromocion != 0)
                {
                    if (obj.IsNew)
                        obj.Insert(parent);
                    else
                        obj.Update(parent);
                }
            }

            this.RaiseListChangedEvents = true;
        }

        #endregion

        #region SQL

        public static string SELECT_BY_INSTRUCTOR(long oid_instructor)
        {
            string tabla = nHManager.Instance.GetSQLTable(typeof(Submodulo_Instructor_PromocionRecord));
            string s = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
            string m = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string query;

            query = "SELECT SIP.*," +
                    "       M.\"OID\" AS \"OID_MODULO\"" +
                    " FROM " + tabla + " AS SIP" +
                    " LEFT JOIN " + s + " AS S ON SIP.\"OID_SUBMODULO\" = S.\"OID\"" +
                    " LEFT JOIN " + m + " AS M ON S.\"OID_MODULO\" = M.\"OID\"" +
                    " WHERE SIP.\"OID_INSTRUCTOR\" = " + oid_instructor.ToString();

            return query;
        }

        public static string SELECT_TITULAR(long oid_promocion, long oid_submodulo)
        {
            string tabla = nHManager.Instance.GetSQLTable(typeof(Submodulo_Instructor_PromocionRecord));
            string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));

            string query;

            query = "SELECT SIP.*," +
                "       M.\"OID\" AS \"OID_MODULO\"" +
                " FROM " + tabla + " AS SIP" +
                " INNER JOIN " + submodulo + " AS S ON (SIP.\"OID_SUBMODULO\" = S.\"OID\") " +
                " INNER JOIN " + modulo + " AS M ON (S.\"OID_MODULO\" = M.\"OID\") " +
                " WHERE SIP.\"OID_PROMOCION\" = " + oid_promocion.ToString() +
                "   AND SIP.\"OID_SUBMODULO\" = " + oid_submodulo.ToString() +
                "   AND SIP.\"PRIORIDAD\" = 1;";

            return query;
        }

        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public static string SELECT_BY_INSTRUCTOR_PROMOCION(long oid)
        {
            string sip = nHManager.Instance.GetSQLTable(typeof(Submodulo_Instructor_PromocionRecord));
            string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string submodulo_instructor = nHManager.Instance.GetSQLTable(typeof(Submodulo_InstructorRecord));

            string query;

            query = "SELECT SIP.*," +
                    "       M.\"OID\" AS \"OID_MODULO\"" +
                    " FROM " + sip + " AS SIP" +
                    " INNER JOIN " + submodulo + " AS S ON (SIP.\"OID_SUBMODULO\" = S.\"OID\") " +
                    " INNER JOIN " + modulo + " AS M ON (S.\"OID_MODULO\" = M.\"OID\") " +
                    " WHERE SIP.\"OID_INSTRUCTOR_PROMOCION\" = " + oid.ToString();

            if (ModulePrincipal.GetMostrarInstructoresAutorizadosSetting())
            {
                query += " AND S.\"OID\" NOT IN (	SELECT \"OID_SUBMODULO\" " +
                    "                               FROM " + submodulo_instructor + " " +
                    "                               WHERE \"OID_INSTRUCTOR\" = SIP.\"OID_INSTRUCTOR\" AND COALESCE(\"FECHA_FIN\", '12-31-2999') >= current_date) ";
            }

            query += " ORDER BY M.\"NUMERO_ORDEN\", S.\"CODIGO_ORDEN\"";

            return query;
        }

        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public static string SELECT_BY_INSTRUCTOR_PROMOCION(long oid, DateTime fecha_inicio, DateTime fecha_fin)
        {
            string sip = nHManager.Instance.GetSQLTable(typeof(Submodulo_Instructor_PromocionRecord));
            string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string si = nHManager.Instance.GetSQLTable(typeof(Submodulo_InstructorRecord));

            string query;

            query = "SELECT SIP.*," +
                    "       M.\"OID\" AS \"OID_MODULO\"" +
                    " FROM " + sip + " AS SIP" +
                    " INNER JOIN " + submodulo + " AS S ON (SIP.\"OID_SUBMODULO\" = S.\"OID\") " +
                    " INNER JOIN " + modulo + " AS M ON (S.\"OID_MODULO\" = M.\"OID\") " +
                    " WHERE SIP.\"OID_INSTRUCTOR_PROMOCION\" = " + oid.ToString() + " ";

            if (ModulePrincipal.GetMostrarInstructoresAutorizadosSetting())
            {
                query += @" AND S.""OID"" NOT IN (	SELECT ""OID_SUBMODULO""
					                                        FROM " + si + @"
					                                        WHERE ('" + fecha_inicio.ToString("MM-dd-yyyy") + @"' BETWEEN COALESCE(""FECHA_INICIO"", '01-01-0001') AND COALESCE(""FECHA_FIN"", '12-31-2999') OR 
						                                        '" + fecha_fin.ToString("MM-dd-yyyy") + @"' BETWEEN COALESCE(""FECHA_INICIO"", '01-01-0001') AND COALESCE(""FECHA_FIN"", '12-31-2999'))
                                                                 AND ""OID_INSTRUCTOR"" = SIP.""OID_INSTRUCTOR"") ";
            }

            query += " ORDER BY M.\"NUMERO_ORDEN\", S.\"CODIGO_ORDEN\"";

            return query;
        }

        public static string SELECT_BY_PROMOCION(long oid)
        {
            string sip = nHManager.Instance.GetSQLTable(typeof(Submodulo_Instructor_PromocionRecord));
            string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));

            string query;

            query = "SELECT *," +
                    "       M.\"OID\" AS \"OID_MODULO\"" +
                    " FROM " + sip + " AS SIP" +
                    " INNER JOIN " + submodulo + " AS S ON (SIP.\"OID_SUBMODULO\" = S.\"OID\")" +
                    " INNER JOIN " + modulo + " AS M ON (S.\"OID_MODULO\" = M.\"OID\")" +
                    " WHERE SIP.\"OID_PROMOCION\" = " + oid.ToString() +
                    " ORDER BY M.\"NUMERO_ORDEN\", S.\"CODIGO_ORDEN\"";

            return query;
        }

        #endregion

        #region Commands

        public bool IsDuplicated(Submodulo_Instructor_Promocion elem)
        {
            foreach (Submodulo_Instructor_Promocion item in this)
            {
                if (elem.OidSubmodulo == item.OidSubmodulo
                    && elem.OidPromocion == item.OidPromocion)
                    return true;
            }
            return false;
        }

        #endregion
    }
}

