using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;
using moleQule.Library.Invoice;

namespace moleQule.Library.Instruction
{
	/// <summary>
	/// Editable Child Collection
	/// </summary>
    [Serializable()]
	public class Alumnos : BusinessListBaseEx<Alumnos, Alumno>
	{

        #region Business Methods
        
        #endregion

        #region Factory Methods

        private Alumnos()
        {
            MarkAsChild();
        }

        private Alumnos(IList<Alumno> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private Alumnos(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }


        public static Alumnos NewChildList() { return new Alumnos(); }

        public static Alumnos GetChildList(IList<Alumno> lista) { return new Alumnos(lista); }

        public static Alumnos GetChildList(IDataReader reader, bool childs) { return new Alumnos(reader, childs); }

        public static Alumnos GetChildList(IDataReader reader) { return GetChildList(reader, true); }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Alumno> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (Alumno item in lista)
                this.AddItem(Alumno.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(Alumno.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }
        
        #endregion

        #region SQL

        /// <summary>
        /// Construye el SELECT de la lista
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public new static string SELECT()
        {
            string tabla = nHManager.Instance.Cfg.GetClassMapping(typeof(AlumnoRecord)).Table.Name;
            string schema = Convert.ToInt32(AppContext.ActiveSchema.Code).ToString("0000");

            string query = "SELECT * " +
                            "FROM \"" + schema + "\".\"" + tabla + "\" " +
                            "ORDER BY \"APELLIDOS\", \"NOMBRE\";";

            return query;
        }

        public static string SELECT_FROM_CLIENTE(long oid_cliente)
        {
            string alumno = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));
            string alumno_cliente = nHManager.Instance.GetSQLTable(typeof(AlumnoClienteRecord));

            string query = "SELECT * FROM " + alumno + " AS AL" +
                   "        INNER JOIN   " + alumno_cliente + "   AS ALCL ON (AL.\"OID\" =  ALCL.\"OID_ALUMNO\") " +
                   "        WHERE ALCL.\"OID_CLIENTE\" = '" + oid_cliente.ToString() + "' " +
                   "        ORDER BY \"APELLIDOS\", \"NOMBRE\";";

            return query;
        }


        public static new string SELECT_BY_FIELD(string field, object field_value)
        {
            string alumno = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));
            string promocion = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));
            field = nHManager.Instance.GetTableField(typeof(AlumnoRecord), field);

            string query = "SELECT * FROM " + alumno + " AS AL" +
                   "        WHERE AL.\"" + field + "\" = '" + field_value.ToString() + "' ";

            return query;
        }

        public static string SELECT_FROM_CONVOCATORIA(long oid_convocatoria)
        {
            string alumno = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));
            string alumno_convocatoria = nHManager.Instance.GetSQLTable(typeof(AlumnoConvocatoriaRecord));

            string query = "SELECT * FROM " + alumno + " AS AL" +
                   "        INNER JOIN   " + alumno_convocatoria + "   AS ALCO ON (AL.\"OID\" =  ALCO.\"OID_ALUMNO\") " +
                   "        WHERE ALCO.\"OID\" = '" + oid_convocatoria.ToString() + "' ";

            return query;
        }

        #endregion

    }
}

