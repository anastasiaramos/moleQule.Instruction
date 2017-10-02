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
    public class Alumnos_Promociones : BusinessListBaseEx<Alumnos_Promociones, Alumno_Promocion>
    {

        #region Business Methods


        public Alumno_Promocion NewItem(Alumno parent)
        {
            this.AddItem(Alumno_Promocion.NewChild(parent));
            return this[Count - 1];
        }

        public Alumno_Promocion NewItem(Promocion parent)
        {
            this.AddItem(Alumno_Promocion.NewChild(parent));
            return this[Count - 1];
        }

        #endregion

        #region Factory Methods

        private Alumnos_Promociones()
        {
            MarkAsChild();
        }

        private Alumnos_Promociones(IList<Alumno_Promocion> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private Alumnos_Promociones(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static Alumnos_Promociones NewChildList() { return new Alumnos_Promociones(); }

        public static Alumnos_Promociones GetChildList(IList<Alumno_Promocion> lista) { return new Alumnos_Promociones(lista); }

        public static Alumnos_Promociones GetChildList(IDataReader reader) { return new Alumnos_Promociones(reader); }

        public static Alumnos_Promociones GetChildList(Alumno parent, bool childs = false, bool g_childs = false)
        {
            CriteriaEx criteria = Alumno_Promocion.GetCriteria(parent.SessionCode);

            criteria.Query = Alumnos_Promociones.SELECT(parent.GetInfo(false));// SELECT_BY_ALUMNO(parent.Oid);
            criteria.Childs = childs;
            criteria.GChilds = g_childs;

            IDataReader reader = nHManager.Instance.SQLNativeSelect(criteria.Query, parent.Session());
            return Alumnos_Promociones.GetChildList(reader);
        }

        public static Alumnos_Promociones GetChildList(Promocion parent, bool childs = false, bool g_childs = false)
        {
            CriteriaEx criteria = Alumno_Promocion.GetCriteria(parent.SessionCode);

            criteria.Query = Alumnos_Promociones.SELECT(parent.GetInfo(false));// SELECT_BY_ALUMNO(parent.Oid);
            criteria.Childs = childs;
            criteria.GChilds = g_childs;

            return DataPortal.Fetch<Alumnos_Promociones>(criteria);
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Alumno_Promocion> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (Alumno_Promocion item in lista)
                this.AddItem(Alumno_Promocion.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(Alumno_Promocion.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }


        internal void Update(Alumno parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Alumno_Promocion obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Alumno_Promocion obj in this)
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
            foreach (Alumno_Promocion obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Alumno_Promocion obj in this)
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

        public static string SELECT_BY_PROMOCION_ORDERED(long oid_parte)
        {
            string schema = Convert.ToInt32(AppContext.ActiveSchema.Code).ToString("0000");

            string query = "SELECT p.* " +
                    "FROM \"" + schema + "\".\"Alumno_Promocion\" as p " +
                    "INNER JOIN \"0001\".\"Alumno\" as a on (a.\"OID\" = p.\"OID_ALUMNO\") " +
                    "WHERE p.\"OID_PARTE\" = " + oid_parte.ToString() + " " +
                    "ORDER BY a.\"APELLIDOS\", a.\"NOMBRE\";";
            return query;
        }

        public static string SELECT_BY_PROMOCION(long oid_promocion)
        {
            QueryConditions conditions = new QueryConditions()
            {
                Promocion = PromocionInfo.New()
            };

            conditions.Promocion.Oid = oid_promocion;

            return Alumno_Promocion.SELECT(conditions, true);
        }

        public static string SELECT(AlumnoInfo item) { return Alumno_Promocion.SELECT(new QueryConditions() { Alumno = item }, true); }
        public static string SELECT(PromocionInfo item) { return Alumno_Promocion.SELECT(new QueryConditions() { Promocion = item }, true); }

        #endregion

    }
}

