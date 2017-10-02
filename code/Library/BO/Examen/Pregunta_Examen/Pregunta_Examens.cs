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
	public class Pregunta_Examens : BusinessListBaseEx<Pregunta_Examens, Pregunta_Examen>
	{

        #region Business Methods

        public Pregunta_Examen NewItem(Pregunta parent)
        {
            this.AddItem(Pregunta_Examen.NewChild(parent));
            return this[Count - 1];
        }

        public Pregunta_Examen NewItem(Examen parent)
        {
            this.AddItem(Pregunta_Examen.NewChild(parent));
            return this[Count - 1];
        }

        #endregion

        #region Factory Methods

        private Pregunta_Examens()
        {
            MarkAsChild();
        }

        private Pregunta_Examens(IList<Pregunta_Examen> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private Pregunta_Examens(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static Pregunta_Examens NewChildList() { return new Pregunta_Examens(); }

        public static Pregunta_Examens GetChildList(IList<Pregunta_Examen> lista) { return new Pregunta_Examens(lista); }

        public static Pregunta_Examens GetChildList(IDataReader reader) { return new Pregunta_Examens(reader); }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Pregunta_Examen> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (Pregunta_Examen item in lista)
                this.AddItem(Pregunta_Examen.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(Pregunta_Examen.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }


        internal void Update(Pregunta parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Pregunta_Examen obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Pregunta_Examen obj in this)
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
            foreach (Pregunta_Examen obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Pregunta_Examen obj in this)
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

        public static string SELECT_BY_EXAMEN(long oid_examen) { return SELECT_BY_EXAMEN(oid_examen, true); }
        public static string SELECT_BY_EXAMEN(long oid_examen, bool lockTable)
        {
            QueryConditions conditions = new QueryConditions()
            {
                Examen = ExamenInfo.New()
            };

            conditions.Examen.Oid = oid_examen;

            return Pregunta_Examen.SELECT(conditions, lockTable);
        }   

        #endregion
    }
}

