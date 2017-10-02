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
    public class Alumno_Partes : BusinessListBaseEx<Alumno_Partes, Alumno_Parte>
    {

        #region Business Methods


        public Alumno_Parte NewItem(Alumno parent)
        {
            this.AddItem(Alumno_Parte.NewChild(parent));
            return this[Count - 1];
        }

        public Alumno_Parte NewItem(ParteAsistencia parent)
        {
            this.AddItem(Alumno_Parte.NewChild(parent));
            return this[Count - 1];
        }

        #endregion

        #region Factory Methods

        private Alumno_Partes()
        {
            MarkAsChild();
        }

        private Alumno_Partes(IList<Alumno_Parte> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private Alumno_Partes(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static Alumno_Partes NewChildList() { return new Alumno_Partes(); }

        public static Alumno_Partes GetChildList(IList<Alumno_Parte> lista) { return new Alumno_Partes(lista); }

        public static Alumno_Partes GetChildList(IDataReader reader) { return new Alumno_Partes(reader); }

        public static Alumno_Partes GetChildList(Alumno parent, bool childs, bool g_childs)
        {
            CriteriaEx criteria = Alumno_Parte.GetCriteria(parent.SessionCode);

            criteria.Query = Alumno_Partes.SELECT_FALTAS_TEORICAS(parent.Oid);
            criteria.Childs = childs;
            criteria.GChilds = g_childs;

            return DataPortal.Fetch<Alumno_Partes>(criteria);
        }

        public static Alumno_Partes GetChildListForForm(Alumno parent, bool childs, bool g_childs)
        {
            CriteriaEx criteria = Alumno_Parte.GetCriteria(parent.SessionCode);

            criteria.Query = Alumno_Partes.SELECT_ORDER_BY_CLASE(parent.GetInfo(false));
            criteria.Childs = childs;
            criteria.GChilds = g_childs;

            IDataReader reader = nHManager.Instance.SQLNativeSelect(criteria.Query, parent.Session());
            return Alumno_Partes.GetChildList(reader);
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Alumno_Parte> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (Alumno_Parte item in lista)
                this.AddItem(Alumno_Parte.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(Alumno_Parte.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }


        internal void Update(Alumno parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Alumno_Parte obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Alumno_Parte obj in this)
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
            foreach (Alumno_Parte obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Alumno_Parte obj in this)
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

        public static string SELECT_BY_PARTE_ORDERED(long oid_parte)
        {
            string schema = Convert.ToInt32(AppContext.ActiveSchema.Code).ToString("0000");

            string query = "SELECT p.*, TO_ASCII(a.\"APELLIDOS\", 'LATIN1') AS AP, TO_ASCII(a.\"NOMBRE\", 'LATIN1') AS NOM " +
                    "FROM \"" + schema + "\".\"Alumno_Parte\" as p " +
                    "INNER JOIN \"0001\".\"Alumno\" as a on (a.\"OID\" = p.\"OID_ALUMNO\") " +
                    "WHERE p.\"OID_PARTE\" = " + oid_parte.ToString() + " " +
                    "ORDER BY AP, NOM;";
            return query;
        }

        public new static string SELECT_BY_FIELD(string field, object field_value)
        {
            string tabla = nHManager.Instance.GetSQLTable(typeof(AlumnoParteRecord));
            string parte = nHManager.Instance.GetSQLTable(typeof(ParteAsistenciaRecord));
            string columna = nHManager.Instance.GetTableField(typeof(AlumnoParteRecord), field);


            string query = "SELECT * " +
                       "FROM " + tabla + " " +
                       "INNER JOIN " + parte + " as p on (p.\"OID\" = \"OID_PARTE\") " +
                       "WHERE \"" + columna + "\" = " + field_value.ToString() + " " +
                       "ORDER BY p.\"FECHA\", p.\"HORA_INICIO\";";
            return query;
        }

        public static string SELECT_FALTAS_TEORICAS(long oid_alumno)
        {
            string tabla = nHManager.Instance.GetSQLTable(typeof(AlumnoParteRecord));
            string parte = nHManager.Instance.GetSQLTable(typeof(ParteAsistenciaRecord));
            string clase_parte = nHManager.Instance.GetSQLTable(typeof(Clase_ParteRecord));


            string query = "SELECT AP.* " +
                       "FROM " + tabla + " AS AP " +
                       "INNER JOIN " + parte + " as p on (p.\"OID\" = \"OID_PARTE\") " +
                       "WHERE AP.\"OID\" IN ( " +
                       "    SELECT API.\"OID\" "+
                       "    FROM " + tabla + " AS API " +
                       "    INNER JOIN " + parte + " as pI on (pI.\"OID\" = API.\"OID_PARTE\") " +
                       "    INNER JOIN " + clase_parte + " as cp on (cp.\"OID_PARTE\" = pI.\"OID\" AND cp.\"TIPO\" <> 2) " +
                       "    WHERE API.\"OID_ALUMNO\" = " + oid_alumno.ToString() + " AND API.\"FALTA\" = TRUE) " +
                       "ORDER BY p.\"FECHA\", p.\"HORA_INICIO\";";
            return query;
        }

        public static string SELECT(AlumnoInfo item) { return Alumno_Parte.SELECT(new QueryConditions() { Alumno = item }, true); }
        public static string SELECT_ORDER_BY_CLASE(AlumnoInfo item) { return Alumno_Parte.SELECT_ORDER_BY_CLASE(new QueryConditions() { Alumno = item }, true); }
        public static string SELECT(ParteAsistenciaInfo item) { return Alumno_Parte.SELECT(new QueryConditions() { ParteAsistencia = item }, true); }

        #endregion

    }
}

