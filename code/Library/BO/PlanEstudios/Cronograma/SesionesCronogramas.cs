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
    public class SesionesCronogramas : BusinessListBaseEx<SesionesCronogramas, SesionCronograma>
    {

        #region Business Methods

        public SesionCronograma NewItem(Cronograma parent)
        {
            this.AddItem(SesionCronograma.NewChild(parent));
            return this[Count - 1];
        }

        public SesionCronograma NewItem(ClaseTeorica parent)
        {
            this.AddItem(SesionCronograma.NewChild(parent));
            return this[Count - 1];
        }

        public SesionCronograma NewItem(ClasePractica parent)
        {
            this.AddItem(SesionCronograma.NewChild(parent));
            return this[Count - 1];
        }

        #endregion

        #region Factory Methods

        private SesionesCronogramas()
        {
            MarkAsChild();
        }

        private SesionesCronogramas(IList<SesionCronograma> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private SesionesCronogramas(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }


        public static SesionesCronogramas NewChildList() { return new SesionesCronogramas(); }

        public static SesionesCronogramas GetChildList(IList<SesionCronograma> lista) { return new SesionesCronogramas(lista); }

        public static SesionesCronogramas GetChildList(IDataReader reader, bool childs) { return new SesionesCronogramas(reader, childs); }

        public static SesionesCronogramas GetChildList(IDataReader reader) { return GetChildList(reader, true); }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<SesionCronograma> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (SesionCronograma item in lista)
                this.AddItem(SesionCronograma.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(SesionCronograma.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }


        internal void Update(Cronograma parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (SesionCronograma obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (SesionCronograma obj in this)
            {
                if (obj.IsNew)
                    obj.Insert(parent);
                else
                    obj.Update(parent);
            }

            this.RaiseListChangedEvents = true;
        }

        internal void Update(ClaseTeorica parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (SesionCronograma obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (SesionCronograma obj in this)
            {
                if (obj.IsNew)
                    obj.Insert(parent);
                else
                    obj.Update(parent);
            }

            this.RaiseListChangedEvents = true;
        }

        internal void Update(ClasePractica parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (SesionCronograma obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (SesionCronograma obj in this)
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

        public static string SELECT_BY_CRONOGRAMA(long oid_cronograma)
        {
            QueryConditions conditions = new QueryConditions()
            {
                Cronograma = CronogramaInfo.New()
            };

            conditions.Cronograma.Oid = oid_cronograma;

            return SesionCronograma.SELECT(conditions, true);
        }
        
        /// <summary>
        /// Construye la tabla 
        /// Devuelve lista de sesiones de un cronograma determinado
        /// </summary>
        /// <returns></returns>
        public static string SELECT_SESIONES_PLAN(long oid_cronograma)
        {
            string sesion_cronograma = nHManager.Instance.Cfg.GetClassMapping(typeof(SesionCronogramaRecord)).Table.Name;
            string practica = nHManager.Instance.Cfg.GetClassMapping(typeof(ClasePracticaRecord)).Table.Name;
            string teorica = nHManager.Instance.Cfg.GetClassMapping(typeof(ClaseTeoricaRecord)).Table.Name;
            string modulo = nHManager.Instance.Cfg.GetClassMapping(typeof(ModuloRecord)).Table.Name;

            string query;

            string esquema = Convert.ToInt32(AppContext.ActiveSchema.Code).ToString("0000");
            esquema = "\"" + esquema + "\"";

            query = "SELECT s.*, '5:00' AS DURACION, p.\"TITULO\" AS CLASE, m.\"ALIAS\" AS MODULO " +
                    "FROM " + esquema + ".\"" + sesion_cronograma + "\" AS s " +
                        "INNER JOIN " + esquema + ".\"" + practica + "\" AS p ON (s.\"OID_CLASE_PRACTICA\" = p.\"OID\") " +
                        "INNER JOIN " + esquema + ".\"" + modulo + "\" AS m ON (p.\"OID_MODULO\" = m.\"OID\") " +
                    "WHERE \"OID_CRONOGRAMA\" = " + oid_cronograma.ToString() + " " +
                    "AND \"OID_CLASE_PRACTICA\" <> 0 " +
                    "UNION " +
                    "SELECT s.*, '1:00' AS DURACION, t.\"TITULO\" AS CLASE, m.\"ALIAS\" AS MODULO " +
                    "FROM " + esquema + ".\"" + sesion_cronograma + "\" AS s " +
                        "INNER JOIN " + esquema + ".\"" + teorica + "\" AS t ON (s.\"OID_CLASE_TEORICA\" = t.\"OID\") " +
                        "INNER JOIN " + esquema + ".\"" + modulo + "\" AS m ON (t.\"OID_MODULO\" = m.\"OID\") " +
                    "WHERE \"OID_CRONOGRAMA\" = " + oid_cronograma.ToString() + " " +
                    "AND \"OID_CLASE_TEORICA\" > 0 " +
                    /*"UNION " +
                    "SELECT s.*, '5:00' AS DURACION, s.\"TEXTO\" AS CLASE, m.\"ALIAS\" AS MODULO " +
                    "FROM " + esquema + ".\"" + sesion_cronograma + "\" AS s " +
                        "INNER JOIN " + esquema + ".\"" + modulo + "\" AS m ON (s.\"TURNO\" = m.\"OID\") " +
                    "WHERE \"OID_CRONOGRAMA\" = " + oid_cronograma.ToString() + " " +
                    "AND \"OID_CLASE_TEORICA\" = -1 " +*/
                    "ORDER BY \"SEMANA\", \"DIA\", \"TURNO\";";


            return query;
        }

        #endregion
    }
}

