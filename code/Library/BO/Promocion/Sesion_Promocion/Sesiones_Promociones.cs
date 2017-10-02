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
    /// Editable Child Business Object
    /// </summary>
    [Serializable()]
    public class Sesiones_Promociones : BusinessListBaseEx<Sesiones_Promociones, Sesion_Promocion>
    {

        #region Business Methods


        public Sesion_Promocion NewItem(Promocion parent)
        {
            this.AddItem(Sesion_Promocion.NewChild(parent));
            return this[Count - 1];
        }

        public Sesion_Promocion NewItem(Cronograma parent)
        {
            this.AddItem(Sesion_Promocion.NewChild(parent));
            return this[Count - 1];
        }

        #endregion

        #region Factory Methods

        private Sesiones_Promociones()
        {
            MarkAsChild();
        }

        private Sesiones_Promociones(IList<Sesion_Promocion> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private Sesiones_Promociones(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static Sesiones_Promociones NewChildList() { return new Sesiones_Promociones(); }

        public static Sesiones_Promociones GetChildList(IList<Sesion_Promocion> lista) { return new Sesiones_Promociones(lista); }

        public static Sesiones_Promociones GetChildList(IDataReader reader) { return new Sesiones_Promociones(reader); }

        public static Sesiones_Promociones GetChildList(Promocion parent, bool childs = false, bool g_childs = false)
        {
            string query = Sesiones_Promociones.SELECT(parent.GetInfo(false));
            
            IDataReader reader = nHManager.Instance.SQLNativeSelect(query, parent.Session());
            return Sesiones_Promociones.GetChildList(reader);
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Sesion_Promocion> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (Sesion_Promocion item in lista)
                this.AddItem(Sesion_Promocion.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(Sesion_Promocion.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }


        internal void Update(Promocion parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Sesion_Promocion obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Sesion_Promocion obj in this)
            {
                if (obj.IsNew)
                    obj.Insert(parent);
                else
                    obj.Update(parent);
            }

            this.RaiseListChangedEvents = true;
        }


        internal void Update(Cronograma parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Sesion_Promocion obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Sesion_Promocion obj in this)
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
        
        //public new static string SELECT(long oid_promocion, long tipo)
        //{
        //    string sesion = nHManager.Instance.GetSQLTable(typeof(Sesion_PromocionRecord));

        //    string query;

        //    query = "SELECT *" +
        //            " FROM " + sesion + " AS sp " +
        //            " WHERE sp.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " AND sp.\"TIPO\" = " + tipo.ToString() + " " +
        //            " ORDER BY \"HORA_INICIO\"";

        //    return query;
        //}

        public static string SELECT(PromocionInfo item) { return Sesion_Promocion.SELECT(new QueryConditions() { Promocion = item, ESesionPromocion = ESesionPromocion.Promocion }, true); }
        public static string SELECT(CronogramaInfo item) { return Sesion_Promocion.SELECT(new QueryConditions() { Cronograma = item, ESesionPromocion = ESesionPromocion.Cronograma }, true); }

        #endregion

    }
}

