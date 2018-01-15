using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Instruction;

namespace moleQule.Library.Instruction
{

    /// <summary>
    /// Editable Child Collection
    /// </summary>
    [Serializable()]
    public class ClaseExtras : BusinessListBaseEx<ClaseExtras, ClaseExtra>
    {

        #region Business Methods

        public ClaseExtra NewItem(PlanExtra parent)
        {
            this.AddItem(ClaseExtra.NewChild(parent));
            return this[Count - 1];
        }

        public ClaseExtra NewItem(Modulo parent)
        {
            this.AddItem(ClaseExtra.NewChild(parent));
            return this[Count - 1];
        }

        public ClaseExtra NewItem(Submodulo parent)
        {
            this.AddItem(ClaseExtra.NewChild(parent));
            return this[Count - 1];
        }

        #endregion

        #region Factory Methods

        private ClaseExtras()
        {
            MarkAsChild();
        }

        private ClaseExtras(IList<ClaseExtra> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private ClaseExtras(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }


        public static ClaseExtras NewChildList() { return new ClaseExtras(); }

        public static ClaseExtras GetChildList(IList<ClaseExtra> lista) { return new ClaseExtras(lista); }

        public static ClaseExtras GetChildList(IDataReader reader, bool childs) { return new ClaseExtras(reader, childs); }

        public static ClaseExtras GetChildList(IDataReader reader) { return GetChildList(reader, true); }

        public List<ClaseExtra> GetClasesOrdenadas()
        {
            SubmoduloList submodulos = SubmoduloList.GetList(false);
            ModuloList modulos = ModuloList.GetList(false);
            List<ClaseExtra> clases = new List<ClaseExtra>();

            foreach (ClaseExtra clase in this)
                clases.Add(clase);

            for (int i = 0; i < clases.Count - 1; i++)
            {
                for (int j = i + 1; j < clases.Count; j++)
                {
                    string codigo_i = submodulos.GetItem(clases[i].OidSubmodulo).CodigoOrden;
                    string codigo_j = submodulos.GetItem(clases[j].OidSubmodulo).CodigoOrden;
                    int valor = codigo_i.CompareTo(codigo_j);

                    if (valor == 1)
                    {
                        ClaseExtra aux = clases[i];
                        clases[i] = clases[j];
                        clases[j] = aux;
                    }
                }
            }

            return clases;
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<ClaseExtra> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (ClaseExtra item in lista)
                this.AddItem(ClaseExtra.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(ClaseExtra.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }

        internal void Update(PlanExtra parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (ClaseExtra obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (ClaseExtra obj in this)
            {
                if (obj.OidModulo != 0 && obj.OidSubmodulo != 0)
                {
                    if (obj.IsNew)
                        obj.Insert(parent);
                    else
                        obj.Update(parent);
                }
            }

            this.RaiseListChangedEvents = true;
        }

        internal void Update(Modulo parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (ClaseExtra obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (ClaseExtra obj in this)
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
            foreach (ClaseExtra obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (ClaseExtra obj in this)
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

        public new static string SELECT()
        {
            string query;

            query = ClaseExtra.SELECT(0);

            return query;
        }

        public static string SELECT_BY_PLAN(long oid_plan)
        {
            string query;

            query = ClaseExtra.SELECT(0) +
                    " WHERE CE.\"OID_PLAN\" = " + oid_plan.ToString();

            return query;
        }

        public static string SELECT_CLASES_EXTRAS_PLAN(long oid_plan)
        {
            string query;
            
            query = ClaseExtra.SELECT(0) +
                    " WHERE CE.\"OID_PLAN\" = " + oid_plan.ToString();

            return query;
        }

        public static string SELECT_CLASES_EXTRAS_DISPONIBLES(long oid_promocion,
                                                                    long oid_horario)
        {
            string sesion = nHManager.Instance.GetSQLTable(typeof(SesionRecord));
            string horario = nHManager.Instance.GetSQLTable(typeof(HorarioRecord));
            string clase = nHManager.Instance.GetSQLTable(typeof(ClaseExtraRecord));
            string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string promocion = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));
            string plan_extra = nHManager.Instance.GetSQLTable(typeof(PlanExtraRecord));
            string oid_submodulo = nHManager.Instance.GetTableField(typeof(ClaseExtraRecord), "OidSubmodulo");
            string oid_modulo = nHManager.Instance.GetTableField(typeof(ClaseExtraRecord), "OidModulo");

            string query;

            query = "SELECT cl.*, 1 AS \"ESTADO\"," +
                    "       sm.\"CODIGO\" AS \"SUBMODULO\"," +
                    "       m.\"TEXTO\" AS \"MODULO\"," +
                    "       sm.\"CODIGO_ORDEN\" AS \"CODIGO_ORDEN\"" +
                    " FROM " + clase + " AS cl " +
                        "INNER JOIN " + submodulo + " AS sm ON (cl.\"" + oid_submodulo + "\" = sm.\"OID\") " +
                        "INNER JOIN " + modulo + " AS m ON (cl.\"" + oid_modulo + "\" = m.\"OID\") " +
                        "INNER JOIN " + promocion + " AS p ON (p.\"OID\" = " + oid_promocion.ToString() + ") " + 
                        "INNER JOIN " + plan_extra + " AS pl ON (pl.\"OID\" = p.\"OID_PLAN_EXTRA\" AND pl.\"OID\" = cl.\"OID_PLAN\") " + 
                    "WHERE cl.\"OID\" NOT IN ( " +
                        "SELECT c.\"OID\" " +
                        "FROM " + sesion + " AS s " +
                            "INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\") " +
                            "INNER JOIN " + clase + " AS c ON (s.\"OID_CLASE_EXTRA\" = c.\"OID\") " +
                       "WHERE h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " " +
                       "AND s.\"ESTADO\" > 1 ) " +
                    "UNION " +
                    "SELECT cl.*, 2 AS \"ESTADO\"," +
                    "       sm.\"CODIGO\" AS \"SUBMODULO\"," +
                    "       m.\"TEXTO\" AS \"MODULO\"," + 
                    "       sm.\"CODIGO_ORDEN\" AS \"CODIGO_ORDEN\" " +
                    "FROM " + sesion + " AS s " +
                            "INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\") " +
                            "INNER JOIN " + clase + " AS cl ON (s.\"OID_CLASE_EXTRA\" = cl.\"OID\") " +
                            "INNER JOIN " + submodulo + " AS sm ON (cl.\"" + oid_submodulo + "\" = sm.\"OID\") " +
                            "INNER JOIN " + modulo + " AS m ON (cl.\"" + oid_modulo + "\" = m.\"OID\") " +
                            "INNER JOIN " + promocion + " AS p ON (p.\"OID\" = h.\"OID_PROMOCION\") " +
                            "INNER JOIN " + plan_extra + " AS pl ON (pl.\"OID\" = cl.\"OID_PLAN\") " +
                       "WHERE s.\"OID_HORARIO\" = " + oid_horario.ToString() + " " +
                   "ORDER BY \"CODIGO_ORDEN\", \"ORDEN\";";
            return query;
        }


        #endregion

    }
}

