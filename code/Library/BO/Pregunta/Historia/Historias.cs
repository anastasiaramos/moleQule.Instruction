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
    public class Historias : BusinessListBaseEx<Historias, Historia>
    {

        #region Business Methods

        public Historia NewItem(Pregunta parent)
        {
            this.AddItem(Historia.NewChild(parent));
            return this[Count - 1];
        }

        #endregion

        #region Factory Methods

        private Historias()
        {
            MarkAsChild();
        }

        private Historias(IList<Historia> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private Historias(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static Historias NewChildList() { return new Historias(); }

        public static Historias GetChildList(IList<Historia> lista) { return new Historias(lista); }

        public static Historias GetChildList(IDataReader reader) { return new Historias(reader); }

        public static Historias GetChildList(Pregunta parent)
        {
            CriteriaEx criteria = Historia.GetCriteria(parent.SessionCode);
            criteria.Query = Historias.SELECT_BY_PREGUNTA(parent.Oid);
            criteria.Childs = false;

            return DataPortal.Fetch<Historias>(criteria);
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
                    Historia.DoLOCK(Session());
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(criteria.Query, Session());

                    while (reader.Read())
                    {
                        Historia obj = Historia.GetChild(reader);
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
        private void Fetch(IList<Historia> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (Historia item in lista)
                this.AddItem(Historia.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(Historia.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }


        internal void Update(Pregunta parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Historia obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Historia obj in this)
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
            string h = nHManager.Instance.GetSQLTable(typeof(HistoriaRecord));

            string query;

            query = Historia.SELECT_FIELDS() +
                    " FROM " + h + "AS H" +
                    " ORDER BY H.\"OID_PREGUNTA\";";

            return query;
        }

        internal static string SELECT_BY_PREGUNTA(long oid_pregunta, bool lock_table)
        {
            string h = nHManager.Instance.GetSQLTable(typeof(HistoriaRecord));

            string query;

            query = Historia.SELECT_FIELDS() +
                    " FROM " + h + " AS H" +
                    " WHERE H.\"OID_PREGUNTA\" = " + oid_pregunta.ToString();

            if (lock_table) query += " FOR UPDATE OF H NOWAIT";

            return query;
        }

        internal static string SELECT_BY_PREGUNTA(long oid) { return Historias.SELECT_BY_PREGUNTA(oid, true); }

        #endregion
    }
}

