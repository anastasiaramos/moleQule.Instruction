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
    public class Preguntas_Plantillas : BusinessListBaseEx<Preguntas_Plantillas, Preguntas_Plantilla>
    {

        #region Business Methods

        public Preguntas_Plantilla NewItem(PlantillaExamen parent)
        {
            this.AddItem(Preguntas_Plantilla.NewChild(parent));
            return this[Count - 1];
        }

        #endregion

        #region Factory Methods

        private Preguntas_Plantillas()
        {
            MarkAsChild();
        }

        private Preguntas_Plantillas(IList<Preguntas_Plantilla> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private Preguntas_Plantillas(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static Preguntas_Plantillas NewChildList() { return new Preguntas_Plantillas(); }

        public static Preguntas_Plantillas GetChildList(IList<Preguntas_Plantilla> lista) { return new Preguntas_Plantillas(lista); }

        public static Preguntas_Plantillas GetChildList(IDataReader reader) { return new Preguntas_Plantillas(reader); }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Preguntas_Plantilla> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (Preguntas_Plantilla item in lista)
                this.AddItem(Preguntas_Plantilla.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(Preguntas_Plantilla.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }


        internal void Update(PlantillaExamen parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Preguntas_Plantilla obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Preguntas_Plantilla obj in this)
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

        public static string SELECT_BY_PLANTILLA(long oid_plantilla) { return SELECT_BY_PLANTILLA(oid_plantilla, true); }
        public static string SELECT_BY_PLANTILLA(long oid_plantilla, bool lockTable)
        {
            QueryConditions conditions = new QueryConditions()
            {
                PlantillaExamen = PlantillaExamenInfo.New()
            };

            conditions.PlantillaExamen.Oid = oid_plantilla;

            return Preguntas_Plantilla.SELECT(conditions, lockTable);
        }

        #endregion

    }
}

