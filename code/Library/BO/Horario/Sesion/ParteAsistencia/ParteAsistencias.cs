using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;

namespace moleQule.Library.Instruction
{
	/// <summary>
	/// Editable Child Collection
	/// </summary>
    [Serializable()]
	public class ParteAsistencias : BusinessListBaseEx<ParteAsistencias, ParteAsistencia>
	{

        #region Business Methods


        public ParteAsistencia NewItem(Horario parent)
        {
            this.AddItem(ParteAsistencia.NewChild(parent));
            return this[Count - 1];
        }

        public ParteAsistencia Contiene(ParteAsistencia obj)
        {
            foreach (ParteAsistencia item in this)
            {
                if (item.OidInstructor == obj.OidInstructor
                    && item.NHoras == obj.NHoras
                    && item.Fecha.ToShortDateString() == obj.Fecha.ToShortDateString()
                    && item.HoraInicio == obj.HoraInicio)
                {
                    foreach (Clase_Parte cp in item.Clases)
                    {
                        if (!obj.Clases.Contiene(cp))
                            return null;
                    }
                    return item;
                }
            }
            return null;
        }

        #endregion

        #region Factory Methods

        private ParteAsistencias()
        {
            MarkAsChild();
        }

        private ParteAsistencias(IList<ParteAsistencia> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private ParteAsistencias(int session_code, IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(session_code, reader);
        }

        public static ParteAsistencias NewChildList() { return new ParteAsistencias(); }

        public static ParteAsistencias GetChildList(IList<ParteAsistencia> lista) { return new ParteAsistencias(lista); }

        public static ParteAsistencias GetChildList(int session_code, IDataReader reader, bool childs) { return new ParteAsistencias(session_code, reader, childs); }

        public static ParteAsistencias GetChildList(int session_code, IDataReader reader) { return GetChildList(session_code, reader, true); }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<ParteAsistencia> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (ParteAsistencia item in lista)
                this.AddItem(ParteAsistencia.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(int session_code, IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(ParteAsistencia.GetChild(session_code, reader));

            this.RaiseListChangedEvents = true;
        }


        public void DoUpdate(Horario parent)
        {
            Update(parent);
            Transaction().Commit();
        }

        internal void Update(Horario parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (ParteAsistencia obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (ParteAsistencia obj in this)
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

        public new static string SELECT()
        {
            string query = ParteAsistencia.SELECT(0, false) +
                           " ORDER BY PA.\"FECHA\", PA.\"HORA_INICIO\"";
                           //" FOR UPDATE OF PA NOWAIT";

            return query;
        }

        public new static string SELECT_BY_FIELD(string field, object value)
        {
            string field_name = nHManager.Instance.GetTableField(typeof(ParteAsistenciaRecord), field);

            string query;

            query = ParteAsistencia.SELECT(0, false) +
                    " WHERE PA.\"" + field_name + "\" = " + value.ToString() + " " +
                    " ORDER BY PA.\"FECHA\", PA.\"HORA_INICIO\"";
                    //" FOR UPDATE OF PA NOWAIT";

            return query;
        }

        internal static string SELECT_BY_HORARIO(long oid_horario, bool lock_table)
        {
            string query;

            query = ParteAsistencia.SELECT(0, false) +
                    " WHERE H.\"OID\" = " + oid_horario.ToString() +
                    " ORDER BY PA.\"FECHA\", P.\"NUMERO\", PA.\"HORA_INICIO\"";

            if (lock_table) query += " FOR UPDATE OF PA NOWAIT";            

            return query;
        }

        public static string SELECT_BY_HORARIO(long oid_horario) { return SELECT_BY_HORARIO(oid_horario, true); }
        
        internal static string SELECT_BY_PROMOCION(long oid_promocion, bool lock_table)
        {
            string query;

            query = ParteAsistencia.SELECT(0, false) +
                    " WHERE P.\"OID\"" + oid_promocion.ToString() +
                    " ORDER BY PA.\"FECHA\", P.\"NUMERO\", PA.\"HORA_INICIO\"";
            
            if (lock_table) query += " FOR UPDATE OF PA NOWAIT";            

            return query;
        }

        public static string SELECT_BY_PROMOCION(long oid_promocion) { return SELECT_BY_PROMOCION(oid_promocion, true); }

        public static string SELECT_PARTES_PRACTICAS()
        {
            string parte_asistencia = nHManager.Instance.GetSQLTable(typeof(ParteAsistenciaRecord));
            string empleado = nHManager.Instance.GetSQLTable(typeof(InstructorRecord));
            string horairo = nHManager.Instance.GetSQLTable(typeof(HorarioRecord));
            string sesion = nHManager.Instance.GetSQLTable(typeof(SesionRecord));
            string clase = nHManager.Instance.GetSQLTable(typeof(ClasePracticaRecord));
            string clase_parte = nHManager.Instance.GetSQLTable(typeof(Clase_ParteRecord));
            string promocion = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));
            string submodulo_instructor = nHManager.Instance.GetSQLTable(typeof(Submodulo_InstructorRecord));

            string query = string.Empty;

            if (ModulePrincipal.GetMostrarInstructoresAutorizadosSetting())
            {
                query = "SELECT DISTINCT PR.\"NOMBRE\" AS \"PROMOCION\", " +
                                    "P.*, " +
                                    "COALESCE(AU.\"AUTORIZADO\", I.\"NOMBRE\") AS \"INSTRUCTOR\", " +
                                    "IE.\"NOMBRE\" AS \"INSTRUCTOR_EFECTIVO\" " +
                                "FROM " + parte_asistencia + " AS P " +
                                "INNER JOIN " + empleado + " AS I ON (P.\"OID_INSTRUCTOR\" = I.\"OID\") " +
                                "INNER JOIN " + empleado + " AS IE ON (P.\"OID_INSTRUCTOR_EFECTIVO\" = IE.\"OID\") " +
                                "INNER JOIN " + horairo + " AS H ON (P.\"OID_HORARIO\" = H.\"OID\") " +
                                "INNER JOIN " + sesion + " AS S ON (S.\"OID_HORARIO\" = H.\"OID\" AND S.\"FECHA\" = P.\"FECHA\") " +
                                "INNER JOIN " + clase + " AS CP ON (S.\"OID_CLASE_PRACTICA\" = CP.\"OID\") " +
                                "LEFT JOIN (    SELECT SI.\"OID_INSTRUCTOR\", SI.\"OID_SUBMODULO\", SI.\"FECHA_INICIO\", SI.\"FECHA_FIN\", IA.\"NOMBRE\" AS \"AUTORIZADO\"" +
                                "               FROM " + submodulo_instructor + " AS SI " +
                                "               INNER JOIN " + empleado + " AS IA ON IA.\"OID\" = SI.\"OID_INSTRUCTOR_SUPLENTE\") " +
                                "       AS AU ON AU.\"OID_INSTRUCTOR\" = I.\"OID\" AND AU.\"OID_SUBMODULO\" = CP.\"OID_SUBMODULO\" AND P.\"FECHA\" BETWEEN COALESCE(AU.\"FECHA_INICIO\", '01-01-0001') AND COALESCE(AU.\"FECHA_FIN\", '12-31-9999') " +
                                "INNER JOIN " + clase_parte + " AS C_P ON (C_P.\"OID_CLASE\" = CP.\"OID\" AND C_P.\"TIPO\" = 2 AND C_P.\"OID_PARTE\" = P.\"OID\") " +
                                "INNER JOIN " + promocion + " AS PR ON (H.\"OID_PROMOCION\" = PR.\"OID\") " +
                                "ORDER BY P.\"FECHA\", \"PROMOCION\";";
            }
            else
            {
                query = "SELECT DISTINCT PR.\"NOMBRE\" AS \"PROMOCION\", " +
                                    "P.*, " +
                                    "I.\"NOMBRE\" AS \"INSTRUCTOR\", " +
                                    "IE.\"NOMBRE\" AS \"INSTRUCTOR_EFECTIVO\" " +
                                "FROM " + parte_asistencia + " AS P " +
                                "INNER JOIN " + empleado + " AS I ON (P.\"OID_INSTRUCTOR\" = I.\"OID\") " +
                                "INNER JOIN " + empleado + " AS IE ON (P.\"OID_INSTRUCTOR_EFECTIVO\" = IE.\"OID\") " +
                                "INNER JOIN " + horairo + " AS H ON (P.\"OID_HORARIO\" = H.\"OID\") " +
                                "INNER JOIN " + sesion + " AS S ON (S.\"OID_HORARIO\" = H.\"OID\" AND S.\"FECHA\" = P.\"FECHA\") " +
                                "INNER JOIN " + clase + " AS CP ON (S.\"OID_CLASE_PRACTICA\" = CP.\"OID\") " +
                                "INNER JOIN " + clase_parte + " AS C_P ON (C_P.\"OID_CLASE\" = CP.\"OID\" AND C_P.\"TIPO\" = 2 AND C_P.\"OID_PARTE\" = P.\"OID\") " +
                                "INNER JOIN " + promocion + " AS PR ON (H.\"OID_PROMOCION\" = PR.\"OID\") " +
                                "ORDER BY P.\"FECHA\", \"PROMOCION\";";
            }

            return query;
        }

        #endregion

    }
}

