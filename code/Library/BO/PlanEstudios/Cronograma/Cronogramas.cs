using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library.Instruction;

namespace moleQule.Library.Instruction
{

    /// <summary>
    /// Editable Child Collection
    /// </summary>
    [Serializable()]
    public class Cronogramas : BusinessListBaseEx<Cronogramas, Cronograma>
    {

        #region Business Methods

        public Cronograma NewItem(PlanEstudios parent)
        {
            this.AddItem(Cronograma.NewChild(parent));
            return this[Count - 1];
        }

        public Cronograma NewItem(Promocion parent)
        {
            this.AddItem(Cronograma.NewChild(parent));
            return this[Count - 1];
        }

        #endregion

        #region Factory Methods

        private Cronogramas()
        {
            MarkAsChild();
        }

        private Cronogramas(IList<Cronograma> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private Cronogramas(int session_code, IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(session_code, reader);
        }


        public static Cronogramas NewChildList() { return new Cronogramas(); }

        public static Cronogramas GetChildList(IList<Cronograma> lista) { return new Cronogramas(lista); }

        public static Cronogramas GetChildList(int session_code, IDataReader reader, bool childs) { return new Cronogramas(session_code, reader, childs); }

        public static Cronogramas GetChildList(int session_code, IDataReader reader) { return GetChildList(session_code, reader, true); }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Cronograma> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (Cronograma item in lista)
                this.AddItem(Cronograma.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(int session_code, IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(Cronograma.GetChild(session_code, reader));

            this.RaiseListChangedEvents = true;
        }

        internal void Update(PlanEstudios parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Cronograma obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Cronograma obj in this)
            {
                if (obj.IsNew)
                    obj.Insert(parent);
                else
                    obj.Update(parent);
            }

            this.RaiseListChangedEvents = true;
        }

        internal void Update(Promocion parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Cronograma obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Cronograma obj in this)
            {
                if (obj.IsNew)
                    obj.Insert(parent);
                else
                    obj.Update(parent);
            }

            this.RaiseListChangedEvents = true;
        }

        #endregion

    }
}

