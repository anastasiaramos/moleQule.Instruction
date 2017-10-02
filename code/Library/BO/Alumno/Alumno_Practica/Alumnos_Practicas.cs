using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library.Instruction;

namespace moleQule.Library.Instruction
{

    /// <summary>
    /// Editable Child Business Object
    /// </summary>
    [Serializable()]
    public class Alumnos_Practicas : BusinessListBaseEx<Alumnos_Practicas, Alumno_Practica>
    {

        #region Business Methods


        public Alumno_Practica NewItem(Alumno parent)
        {
            this.AddItem(Alumno_Practica.NewChild(parent));
            return this[Count - 1];
        }

        public Alumno_Practica NewItem(ClasePractica parent)
        {
            this.AddItem(Alumno_Practica.NewChild(parent));
            return this[Count - 1];
        }

        public Alumno_Practica NewItem(ParteAsistencia parent)
        {
            this.AddItem(Alumno_Practica.NewChild(parent));
            return this[Count - 1];
        }

        #endregion

        #region Factory Methods

        private Alumnos_Practicas()
        {
            MarkAsChild();
        }

        private Alumnos_Practicas(IList<Alumno_Practica> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private Alumnos_Practicas(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static Alumnos_Practicas NewChildList() { return new Alumnos_Practicas(); }

        public static Alumnos_Practicas GetChildList(IList<Alumno_Practica> lista) { return new Alumnos_Practicas(lista); }

        public static Alumnos_Practicas GetChildList(IDataReader reader) { return new Alumnos_Practicas(reader); }

        public static Alumnos_Practicas GetChildList(Alumno parent, bool childs, bool g_childs)
        {
            CriteriaEx criteria = Alumno_Practica.GetCriteria(parent.SessionCode);

            criteria.Query = Alumnos_Practicas.SELECT(parent.GetInfo(false));
            criteria.Childs = childs;
            criteria.GChilds = g_childs;

            return DataPortal.Fetch<Alumnos_Practicas>(criteria);
        }

        public static Alumnos_Practicas GetChildListForForm(Alumno parent, bool childs, bool g_childs)
        {
            CriteriaEx criteria = Alumno_Practica.GetCriteria(parent.SessionCode);

            criteria.Query = Alumnos_Practicas.SELECT_ORDER_BY_CLASE(parent.GetInfo(false));
            criteria.Childs = childs;
            criteria.GChilds = g_childs;

            IDataReader reader = nHManager.Instance.SQLNativeSelect(criteria.Query, parent.Session());
            return Alumnos_Practicas.GetChildList(reader);
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Alumno_Practica> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (Alumno_Practica item in lista)
                this.AddItem(Alumno_Practica.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(Alumno_Practica.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }


        internal void Update(Alumno parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Alumno_Practica obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Alumno_Practica obj in this)
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
            foreach (Alumno_Practica obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Alumno_Practica obj in this)
            {
                if (obj.IsNew)
                    obj.Insert(parent);
                else
                    obj.Update(parent);
            }

            this.RaiseListChangedEvents = true;
        }

        internal void Update(ParteAsistencia parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Alumno_Practica obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Alumno_Practica obj in this)
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

        public static new string SELECT_BY_FIELD(string field, object field_value)
        {
            string alumno_practica = nHManager.Instance.GetSQLTable(typeof(AlumnoPracticaRecord));
            string alumno_parte = nHManager.Instance.GetSQLTable(typeof(AlumnoParteRecord));
            string clase_practica = nHManager.Instance.GetSQLTable(typeof(ClasePracticaRecord));
            string alumno = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));
            field = nHManager.Instance.GetTableField(typeof(AlumnoPracticaRecord), field);

            string query = "SELECT AL.*, P.\"FALTA\" AS \"FALTA\", C.\"ALIAS\" AS \"ALIAS\", TO_ASCII(a.\"APELLIDOS\", 'LATIN1') AS AP, TO_ASCII(a.\"NOMBRE\", 'LATIN1') AS NOM " +
                   "        FROM " + alumno_practica + " AS AL" +
                   "        INNER JOIN   " + alumno_parte + "   AS P ON (AL.\"OID_PARTE\" =  P.\"OID_PARTE\" AND AL.\"OID_ALUMNO\" =  P.\"OID_ALUMNO\") " +
                   "        INNER JOIN   " + clase_practica + "   AS C ON (AL.\"OID_CLASE_PRACTICA\" =  C.\"OID\") " +
                   "        INNER JOIN   " + alumno + " AS A ON (A.\"OID\" = AL.\"OID_ALUMNO\") " +
                   "        WHERE AL.\"" + field + "\" = '" + field_value.ToString() + "' " +
                   "        ORDER BY AP, NOM;";

            return query;
        }

        public static string SELECT(AlumnoInfo item) { return Alumno_Practica.SELECT(new QueryConditions() { Alumno = item }, true); }
        public static string SELECT_ORDER_BY_CLASE(AlumnoInfo item) { return Alumno_Practica.SELECT_ORDER_BY_CLASE(new QueryConditions() { Alumno = item }, true); }
        public static string SELECT(ParteAsistenciaInfo item) { return Alumno_Practica.SELECT(new QueryConditions() { ParteAsistencia = item }, true); }

        #endregion

    }
}

