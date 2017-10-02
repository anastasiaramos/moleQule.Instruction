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
	public class RespuestaExamens : BusinessListBaseEx<RespuestaExamens, RespuestaExamen>
	{

        #region Business Methods


        public RespuestaExamen NewItem(PreguntaExamen parent)
        {
            this.AddItem(RespuestaExamen.NewChild(parent));
            return this[Count - 1];
        }

        #endregion

        #region Factory Methods

        private RespuestaExamens()
        {
            MarkAsChild();
        }

        private RespuestaExamens(IList<RespuestaExamen> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private RespuestaExamens(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static RespuestaExamens NewChildList() { return new RespuestaExamens(); }

        public static RespuestaExamens GetChildList(IList<RespuestaExamen> lista) { return new RespuestaExamens(lista); }

        public static RespuestaExamens GetChildList(IDataReader reader) { return new RespuestaExamens(reader); }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<RespuestaExamen> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (RespuestaExamen item in lista)
                this.AddItem(RespuestaExamen.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(RespuestaExamen.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }


        internal void Update(PreguntaExamen parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (RespuestaExamen obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (RespuestaExamen obj in this)
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

        internal static string SELECT_BY_PREGUNTA_EXAMEN(long oid_pregunta, long oid_examen, bool lock_table)
        {
            string re = nHManager.Instance.GetSQLTable(typeof(RespuestaExamenRecord));

            string query;

            query = "SELECT *" +
                    " FROM " + re + " AS RE" +
                    " WHERE RE.\"OID_PREGUNTA\" = " + oid_pregunta.ToString() + 
                    "   AND RE.\"OID_EXAMEN\" = " + oid_examen.ToString() +
                    " ORDER BY RE.\"OPCION\"";

            if (lock_table) query += " FOR UPDATE OF RE NOWAIT";

            return query;
        }

        public static string SELECT_BY_PREGUNTA_EXAMEN(long oid_pregunta, long oid_examen) 
        { 
            return SELECT_BY_PREGUNTA_EXAMEN(oid_pregunta, oid_examen, true); 
        }

        #endregion

    }
}

