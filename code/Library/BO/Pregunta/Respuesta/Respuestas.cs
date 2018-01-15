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
    public class Respuestas : BusinessListBaseEx<Respuestas, Respuesta>
    {

        #region Business Methods

        public Respuesta NewItem(Pregunta parent)
        {
            this.AddItem(Respuesta.NewChild(parent));
            return this[Count - 1];
        }

        #endregion

        #region Factory Methods

        private Respuestas()
        {
            MarkAsChild();
        }

        private Respuestas(IList<Respuesta> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private Respuestas(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static Respuestas NewChildList() { return new Respuestas(); }

        public static Respuestas GetChildList(IList<Respuesta> lista) { return new Respuestas(lista); }

        public static Respuestas GetChildList(IDataReader reader) { return new Respuestas(reader); }

        public static Respuestas GetChildList(Pregunta parent)
        {
            CriteriaEx criteria = Respuesta.GetCriteria(parent.SessionCode);
            criteria.Query = Respuestas.SELECT_BY_PREGUNTA(parent.Oid);
            criteria.Childs = false;

            return DataPortal.Fetch<Respuestas>(criteria);
        }

        public static Respuestas GetChildList(RespuestaExamenList lista)
        {
            Respuestas list = new Respuestas();

            foreach (RespuestaExamenInfo item in lista)
                list.AddItem(Respuesta.NewChild(item));

            return list;
        }

        #endregion

        #region Root Data Access

        private void DataPortal_Fetch(CriteriaEx criteria)
        {
            Fetch(criteria);
        }

        private void Fetch(CriteriaEx criteria)
        {
            this.RaiseListChangedEvents = false;

            SessionCode = criteria.SessionCode;

            try
            {
                if (nHMng.UseDirectSQL)
                {
                    Respuesta.DoLOCK(Session());
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(criteria.Query, Session());

                    while (reader.Read())
                    {
                        Respuesta obj = Respuesta.GetChild(reader);
                        this.AddItem(obj);
                    }
               }
            }
            catch (NHibernate.ADOException)
            {
                if (Transaction() != null) Transaction().Rollback();
                throw new iQLockException(moleQule.Library.Resources.Messages.LOCK_ERROR);
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
        private void Fetch(IList<Respuesta> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (Respuesta item in lista)
                this.AddItem(Respuesta.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(Respuesta.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }

        internal void Update(Pregunta parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Respuesta obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Respuesta obj in this)
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

        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public new static string SELECT()
        {
            string respuesta = nHManager.Instance.GetSQLTable(typeof(RespuestaRecord));

            string query;

            query = Respuesta.SELECT_FIELDS() +
                    " FROM " + respuesta + "AS R" +
                    " ORDER BY R.\"OID_PREGUNTA\", R.\"OPCION\" " + ";";

            return query;
        }

        internal static string SELECT_BY_PREGUNTA(long oid_pregunta, bool lock_table)
        {
            string r = nHManager.Instance.GetSQLTable(typeof(RespuestaRecord));

            string query;

            query = Respuesta.SELECT_FIELDS() +
                    " FROM " + r + " AS R" +
                    " WHERE R.\"OID_PREGUNTA\" = " + oid_pregunta.ToString();

            if (lock_table) query += " FOR UPDATE OF R NOWAIT";

            return query;
        }

        internal static string SELECT_BY_PREGUNTA(long oid) { return Respuestas.SELECT_BY_PREGUNTA(oid, true); }

        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public static string SELECT_BY_MODULO(string schema, long oid_modulo)
        {
            string respuesta = nHManager.Instance.Cfg.GetClassMapping(typeof(RespuestaRecord)).Table.Name;
            string pregunta = nHManager.Instance.Cfg.GetClassMapping(typeof(PreguntaRecord)).Table.Name;
            string oid_pregunta = nHManager.Instance.GetTableField(typeof(RespuestaRecord), "OidPregunta");
            string opcion = nHManager.Instance.GetTableField(typeof(RespuestaRecord), "Opcion");
            string c_oid_modulo = nHManager.Instance.GetTableField(typeof(PreguntaRecord), "OidModulo");

            string query;

            string esquema = Convert.ToInt32(schema).ToString("0000");

            query = "SELECT R.* " +
                    "FROM \"" + esquema + "\".\"" + respuesta + "\" AS R " +
                    "INNER JOIN \"" + esquema + "\".\"" + pregunta + "\" AS P ON (P.\"OID\" = R.\"" + oid_pregunta +  "\") " +
                    "WHERE P.\"" + c_oid_modulo + "\" = " + oid_modulo.ToString() + " " +
                    "ORDER BY R.\"" + oid_pregunta + "\", R.\"" + opcion + "\" " + ";";

            return query;
        }
        
        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public static string SELECT_BY_LIST(string lista_preguntas)
        {
            string pregunta = nHManager.Instance.GetSQLTable(typeof(PreguntaRecord));
            string respuesta = nHManager.Instance.GetSQLTable(typeof(RespuestaRecord));
            string oid_pregunta = nHManager.Instance.GetTableField(typeof(RespuestaRecord), "OidPregunta");
            string opcion = nHManager.Instance.GetTableField(typeof(RespuestaRecord), "Opcion");

            string query;


            query = "SELECT R.* " +
                    "FROM " + respuesta + " AS R " + 
                    "INNER JOIN " + pregunta + " AS p ON (p.\"OID\" = R.\"" + oid_pregunta + "\") " +
                    "WHERE p.\"OID\" IN (" + lista_preguntas + ") " +
                    "ORDER BY R.\"" + oid_pregunta + "\", R.\"" + opcion + "\" " + ";";

            return query;
        }

        #endregion

    }
}

