using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;

namespace moleQule.Library.Instruction
{
    /// <summary>
    /// Editable Child Collection
    /// </summary>
    [Serializable()]
    public class ClasePracticas : BusinessListBaseEx<ClasePracticas, ClasePractica>
    {

        #region Business Methods

        public ClasePractica NewItem(PlanEstudios parent)
        {
            this.AddItem(ClasePractica.NewChild(parent));
            return this[Count - 1];
        }

        public ClasePractica NewItem(Modulo parent)
        {
            this.AddItem(ClasePractica.NewChild(parent));
            return this[Count - 1];
        }

        public ClasePractica NewItem(Submodulo parent)
        {
            this.AddItem(ClasePractica.NewChild(parent));
            return this[Count - 1];
        }

        #endregion

        #region Factory Methods

        private ClasePracticas()
        {
            MarkAsChild();
        }

        private ClasePracticas(IList<ClasePractica> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }


        private ClasePracticas(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }



        public static ClasePracticas NewChildList() { return new ClasePracticas(); }

        public static ClasePracticas GetChildList(IList<ClasePractica> lista) { return new ClasePracticas(lista); }

        public static ClasePracticas GetChildList(IDataReader reader) { return new ClasePracticas(reader); }

        public List<ClasePractica> GetClasesOrdenadas()
        {
            SubmoduloList submodulos = SubmoduloList.GetList(false);
            ModuloList modulos = ModuloList.GetList(false);
            List<ClasePractica> clases = new List<ClasePractica>();

            foreach (ClasePractica clase in this)
                clases.Add(clase);

            for (int i = 0; i < clases.Count - 1; i++)
            {
                for (int j = i + 1; j < clases.Count; j++)
                {
                    string codigo_i = submodulos.GetItem(clases[i].OidSubmodulo).CodigoOrden;
                    string codigo_j = submodulos.GetItem(clases[j].OidSubmodulo).CodigoOrden;
                    int valor = codigo_i.CompareTo(codigo_j);

                    if (valor == 1)
                    {
                        ClasePractica aux = clases[i];
                        clases[i] = clases[j];
                        clases[j] = aux;
                    }
                    else
                    {
                        if (codigo_i == codigo_j
                            && clases[i].OrdenTerciario > clases[j].OrdenTerciario)
                        {
                            ClasePractica aux = clases[i];
                            clases[i] = clases[j];
                            clases[j] = aux;
                        }

                    }
                }
            }

            return clases;
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<ClasePractica> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (ClasePractica item in lista)
                this.AddItem(ClasePractica.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(ClasePractica.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }


        internal void Update(PlanEstudios parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (ClasePractica obj in DeletedList)
                obj.DeleteSelf(parent);

            // 'now' that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (ClasePractica obj in this)
            {
                if (obj.OidModulo != 0 && obj.OidSubmodulo != 0)
                {
                    if (obj.IsNew)
                        obj.Insert(parent);
                    else
                        obj.Update(parent);
                }
            }

            this.RaiseListChangedEvents = true;
        }

        internal void Update(Modulo parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (ClasePractica obj in DeletedList)
                obj.DeleteSelf(parent);

            // 'now' that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (ClasePractica obj in this)
            {
                if (obj.IsNew)
                    obj.Insert(parent);
                else
                    obj.Update(parent);
            }

            this.RaiseListChangedEvents = true;
        }

        internal void Update(Submodulo parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (ClasePractica obj in DeletedList)
                obj.DeleteSelf(parent);

            // 'now' that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (ClasePractica obj in this)
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

        internal static string SELECT_BY_SUBMODULO(long oid, bool lock_table)
        {
            string query;

            query = ClasePractica.SELECT(0) +
                    " WHERE CP.\"OID_SUBMODULO\" = " + oid.ToString();

            if (lock_table) query += " FOR UPDATE OF CP NOWAIT";

            return query;
        }

        public static string SELECT_BY_SUBMODULO(long oid_submodulo) { return SELECT_BY_SUBMODULO(oid_submodulo, true); }

        public static string SELECT_CLASES_PRACTICAS_DISPONIBLES(long oid_plan,
                                                                    long oid_promocion,
                                                                    long oid_horario,
                                                                    long grupo)
        {
            string clase_practica = nHManager.Instance.GetSQLTable(typeof(ClasePracticaRecord));
            string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string horario = nHManager.Instance.GetSQLTable(typeof(HorarioRecord));
            string sesion = nHManager.Instance.GetSQLTable(typeof(SesionRecord));
            string alumno = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));
            string alumno_promo = nHManager.Instance.GetSQLTable(typeof(AlumnoPromocionRecord));
 
            string query;
                        
            query = "SELECT DISTINCT c.*,"
                    +       grupo.ToString() + " AS \"GRUPO\","+
                    "       sm.\"CODIGO\" AS \"SUBMODULO\","+
                    "       m.\"TEXTO\" AS \"MODULO\"," +
                    "       m.\"NUMERO_ORDEN\" AS \"NUMERO_ORDEN\"," +
                    "       1 AS \"ESTADO\","+
                    "       sm.\"CODIGO_ORDEN\" AS \"CODIGO_ORDEN\"," +
                    "       '' AS \"INSTRUCTOR\"," +
                    "       '1999-01-08' AS \"FECHA\"," +
                    "       '00:00:00' AS \"HORA\"," +
                    "       0 AS \"COUNT_MODULO\"," +
                    "       0 AS \"COUNT_SUBMODULO\", " +
                    "       0 AS \"OID_MERGE\"" +
                    " FROM " + clase_practica + " AS c " +
                    "   INNER JOIN " + submodulo + " AS sm ON (c.\"OID_SUBMODULO\" = sm.\"OID\") " +
                    "   INNER JOIN " + modulo + " AS m ON (c.\"OID_MODULO\" = m.\"OID\") " +
                    "WHERE c.\"OID\" NOT IN ( 	SELECT c.\"OID\" " +
                    "							FROM " + sesion + " AS s " +
                    "								INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\") " +
                    "								INNER JOIN " + clase_practica + " AS c ON (s.\"OID_CLASE_PRACTICA\" = c.\"OID\") " +
                    "							WHERE h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " AND s.\"GRUPO\" = " + grupo.ToString() + ") " +
                    "AND c.\"OID_PLAN\" = " + oid_plan.ToString() + 
                    " AND " + grupo.ToString() + " IN (	SELECT \"GRUPO\" " +
					"                                           FROM " + alumno + " AS AL " +
					"                               			INNER JOIN " + alumno_promo + " AS APR ON APR.\"OID_ALUMNO\" = AL.\"OID\" " +
					"                               			WHERE APR.\"OID_PROMOCION\" = " + oid_promocion.ToString() + ") " +
                    "UNION " +
                    "SELECT DISTINCT c.*,"
                    + grupo.ToString() + " AS \"GRUPO\"," +
                    "       sm.\"CODIGO\" AS \"SUBMODULO\"," +
                    "       m.\"TEXTO\" AS \"MODULO\"," +
                    "       m.\"NUMERO_ORDEN\" AS \"NUMERO_ORDEN\"," +
                    "       s.\"ESTADO\" AS \"ESTADO\"," +
                    "       sm.\"CODIGO_ORDEN\" AS \"CODIGO_ORDEN\"," +
                    "       '' AS \"INSTRUCTOR\"," +
                    "       '1999-01-08' AS \"FECHA\"," +
                    "       '00:00:00' AS \"HORA\"," +
                    "       0 AS \"COUNT_MODULO\"," +
                    "       0 AS \"COUNT_SUBMODULO\", " +
                    "       0 AS \"OID_MERGE\"" +
                    " FROM " + clase_practica + " AS c " +
                    "   INNER JOIN " + submodulo + " AS sm ON (c.\"OID_SUBMODULO\" = sm.\"OID\") " +
                    "   INNER JOIN " + modulo + " AS m ON (c.\"OID_MODULO\" = m.\"OID\") " +
                    "   INNER JOIN " + sesion + " AS s ON s.\"OID_CLASE_PRACTICA\" = c.\"OID\" " +
                    "	INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\") " +
                    "WHERE s.\"GRUPO\" = " + grupo.ToString() + " AND h.\"OID\" = " + oid_horario.ToString() +
                    " AND " + grupo.ToString() + " IN (	SELECT \"GRUPO\" " +
                    "                                           FROM " + alumno + " AS AL " +
                    "                               			INNER JOIN " + alumno_promo + " AS APR ON APR.\"OID_ALUMNO\" = AL.\"OID\" " +
                    "                               			WHERE APR.\"OID_PROMOCION\" = " + oid_promocion.ToString() + ") " +
                    "ORDER BY \"ORDEN_PRIMARIO\", \"ORDEN_SECUNDARIO\", \"ORDEN_TERCIARIO\"";//, \"NUMERO_ORDEN\", \"CODIGO_ORDEN\"";

            return query;
        }
        public static string SELECT_CLASES_PRACTICAS_NO_IMPARTIDAS(long oid_plan,
                                                                   long oid_promocion,
                                                                    long grupo = 0)
        {
            string clase_practica = nHManager.Instance.GetSQLTable(typeof(ClasePracticaRecord));
            string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string horario = nHManager.Instance.GetSQLTable(typeof(HorarioRecord));
            string sesion = nHManager.Instance.GetSQLTable(typeof(SesionRecord));
            string alumno = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));
            string alumno_promo = nHManager.Instance.GetSQLTable(typeof(AlumnoPromocionRecord));

            string query1;

            query1 = "SELECT DISTINCT c.*," +
                    "       cast(cast(c.\"OID\" as varchar) || '1' as bigint) AS \"OID_MERGE\"," +
                    "       1 AS \"GRUPO\"," +
                    "       sm.\"CODIGO\" AS \"SUBMODULO\"," +
                    "       m.\"TEXTO\" AS \"MODULO\"," +
                    "       m.\"NUMERO_ORDEN\" AS \"NUMERO_ORDEN\"," +
                    "       1 AS \"ESTADO\"," +
                    "       sm.\"CODIGO_ORDEN\" AS \"CODIGO_ORDEN\"," +
                    "       '' AS \"INSTRUCTOR\"," +
                    "       '1999-01-08' AS \"FECHA\"," +
                    "       '00:00:00' AS \"HORA\"," +
                    "       0 AS \"COUNT_MODULO\"," +
                    "       0 AS \"COUNT_SUBMODULO\"" +
                    " FROM " + clase_practica + " AS c " +
                    "   INNER JOIN " + submodulo + " AS sm ON (c.\"OID_SUBMODULO\" = sm.\"OID\") " +
                    "   INNER JOIN " + modulo + " AS m ON (c.\"OID_MODULO\" = m.\"OID\") " +
                    "WHERE c.\"OID\" NOT IN ( 	SELECT c.\"OID\" " +
                    "							FROM " + sesion + " AS s " +
                    "								INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\") " +
                    "								INNER JOIN " + clase_practica + " AS c ON (s.\"OID_CLASE_PRACTICA\" = c.\"OID\") " +
                    "							WHERE h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " AND s.\"GRUPO\" = 1 AND s.\"ESTADO\" = 3) " +
                    "AND c.\"OID_PLAN\" = " + oid_plan.ToString() + " " +
                    "UNION " +
                    "SELECT DISTINCT c.*," +
                    "       cast(cast(c.\"OID\" as varchar) || '2' as bigint) AS \"OID_MERGE\"," +
                    "       2 AS \"GRUPO\"," +
                    "       sm.\"CODIGO\" AS \"SUBMODULO\"," +
                    "       m.\"TEXTO\" AS \"MODULO\"," +
                    "       m.\"NUMERO_ORDEN\" AS \"NUMERO_ORDEN\"," +
                    "       1 AS \"ESTADO\"," +
                    "       sm.\"CODIGO_ORDEN\" AS \"CODIGO_ORDEN\"," +
                    "       '' AS \"INSTRUCTOR\"," +
                    "       '1999-01-08' AS \"FECHA\"," +
                    "       '00:00:00' AS \"HORA\"," +
                    "       0 AS \"COUNT_MODULO\"," +
                    "       0 AS \"COUNT_SUBMODULO\"" +
                    " FROM " + clase_practica + " AS c " +
                    "   INNER JOIN " + submodulo + " AS sm ON (c.\"OID_SUBMODULO\" = sm.\"OID\") " +
                    "   INNER JOIN " + modulo + " AS m ON (c.\"OID_MODULO\" = m.\"OID\") " +
                    "WHERE c.\"OID\" NOT IN ( 	SELECT c.\"OID\" " +
                    "							FROM " + sesion + " AS s " +
                    "								INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\") " +
                    "								INNER JOIN " + clase_practica + " AS c ON (s.\"OID_CLASE_PRACTICA\" = c.\"OID\") " +
                    "							WHERE h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " AND s.\"GRUPO\" = 2 AND s.\"ESTADO\" = 3) " +
                    "AND c.\"OID_PLAN\" = " + oid_plan.ToString() + " " +
                    "ORDER BY \"ORDEN_PRIMARIO\", \"ORDEN_SECUNDARIO\", \"ORDEN_TERCIARIO\", \"NUMERO_ORDEN\", \"CODIGO_ORDEN\", \"GRUPO\"";

            string query = "SELECT CONTADORES.\"COUNT_MODULO\", CONTADORES.\"COUNT_SUBMODULO\", CONSULTA.* " +
                            "FROM " +
                            "(SELECT Q2.\"OID_MODULO\", Q2.\"OID_SUBMODULO\", Q2.\"GRUPO\", \"COUNT_MODULO\", \"COUNT_SUBMODULO\" " +
                            "FROM " +
                            "(SELECT \"OID_MODULO\", COUNT(\"OID_MODULO\") AS \"COUNT_MODULO\", 1 AS \"GRUPO\" " +
                            "FROM " + clase_practica + " AS c     " +
                            "WHERE c.\"OID\" NOT IN ( 	SELECT c.\"OID\"  " +
                            "            FROM " + sesion + " AS s 								 " +
                            "                INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\")  " +
                            "                INNER JOIN " + clase_practica + " AS c ON (s.\"OID_CLASE_PRACTICA\" = c.\"OID\") 	 " +
                            "            WHERE h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " AND s.\"GRUPO\" = 1 AND s.\"ESTADO\" = 3)  " +
                            "    AND c.\"OID_PLAN\" = " + oid_plan.ToString() + "  " +
                            "GROUP BY c.\"OID_MODULO\" " +
                            "UNION  " +
                            "SELECT \"OID_MODULO\", COUNT(\"OID_MODULO\") AS \"COUNT_MODULO\", 2 AS \"GRUPO\" " +
                            "FROM " + clase_practica + " AS c     " +
                            "WHERE c.\"OID\" NOT IN ( 	SELECT c.\"OID\" 					 " +
                            "            FROM " + sesion + " AS s 							 " +
                            "                INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\") 	 " +
                            "                INNER JOIN " + clase_practica + " AS c ON (s.\"OID_CLASE_PRACTICA\" = c.\"OID\") 	 " +
                            "            WHERE h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " AND s.\"GRUPO\" = 2 AND s.\"ESTADO\" = 3)  " +
                            "    AND c.\"OID_PLAN\" = " + oid_plan.ToString() + "  " +
                            "GROUP BY \"OID_MODULO\") AS Q1, " +
                            "(SELECT \"OID_MODULO\", \"OID_SUBMODULO\", COUNT(\"OID_SUBMODULO\") AS \"COUNT_SUBMODULO\", 1 AS \"GRUPO\" " +
                            "FROM " + clase_practica + " AS c     " +
                            "WHERE c.\"OID\" NOT IN ( 	SELECT c.\"OID\" 			 " +
                            "            FROM " + sesion + " AS s 					 " +
                            "                INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\") 	 " +
                            "                INNER JOIN " + clase_practica + " AS c ON (s.\"OID_CLASE_PRACTICA\" = c.\"OID\") 		 " +
                            "            WHERE h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " AND s.\"GRUPO\" = 1 AND s.\"ESTADO\" = 3)  " +
                            "    AND c.\"OID_PLAN\" = " + oid_plan.ToString() + "  " +
                            "GROUP BY c.\"OID_MODULO\", \"OID_SUBMODULO\" " +
                            "UNION  " +
                            "SELECT \"OID_MODULO\", \"OID_SUBMODULO\", COUNT(\"OID_SUBMODULO\") AS \"COUNT_SUBMODULO\", 2 AS \"GRUPO\" " +
                            "FROM " + clase_practica + " AS c     " +
                            "WHERE c.\"OID\" NOT IN ( 	SELECT c.\"OID\" 			 " +
                            "            FROM " + sesion + " AS s 					 " +
                            "                INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\")  " +
                            "                INNER JOIN " + clase_practica + " AS c ON (s.\"OID_CLASE_PRACTICA\" = c.\"OID\") 	 " +
                            "            WHERE h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " AND s.\"GRUPO\" = 2 AND s.\"ESTADO\" = 3)  " +
                            "    AND c.\"OID_PLAN\" = " + oid_plan.ToString() + "  " +
                            "GROUP BY \"OID_MODULO\", \"OID_SUBMODULO\") AS Q2 " +
                            "WHERE Q1.\"OID_MODULO\" = Q2.\"OID_MODULO\" AND Q1.\"GRUPO\" = Q2.\"GRUPO\") AS CONTADORES, " +
                            "( " + query1 + " ) AS CONSULTA " +
                            "WHERE CONTADORES.\"OID_SUBMODULO\" = CONSULTA.\"OID_SUBMODULO\" AND CONTADORES.\"GRUPO\" = CONSULTA.\"GRUPO\" " +
                            "AND CONSULTA.\"GRUPO\" IN (    SELECT \"GRUPO\" " +
                            "                               FROM " + alumno + " AS AL " +
                            "                               INNER JOIN " + alumno_promo + " AS APR ON APR.\"OID_ALUMNO\" = AL.\"OID\" " +
                            "                               WHERE APR.\"OID_PROMOCION\" = " + oid_promocion.ToString() + ") ";
            if (grupo != 0)
                query += " AND CONSULTA.\"GRUPO\" = " + grupo.ToString();

            return query;
        }



        public static string SELECT_CLASES_PRACTICAS_PROGRAMADAS(long oid_plan,
                                                                   long oid_promocion)
        {
            string clase_practica = nHManager.Instance.GetSQLTable(typeof(ClasePracticaRecord));
            string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string horario = nHManager.Instance.GetSQLTable(typeof(HorarioRecord));
            string sesion = nHManager.Instance.GetSQLTable(typeof(SesionRecord));
            string instructor = nHManager.Instance.GetSQLTable(typeof(InstructorRecord));
            string clase_parte = nHManager.Instance.GetSQLTable(typeof(Clase_ParteRecord));
            string parte = nHManager.Instance.GetSQLTable(typeof(ParteAsistenciaRecord));
            string submodulo_instructor = nHManager.Instance.GetSQLTable(typeof(Submodulo_InstructorRecord));

            string query1;

            bool mostrar_autorizados = moleQule.Library.Instruction.ModulePrincipal.GetMostrarInstructoresAutorizadosSetting();

            query1 = "SELECT DISTINCT c.*," +
                    "       cast(cast(c.\"OID\" as varchar) || '1' as bigint) AS \"OID_MERGE\"," +
                    "       1 AS \"GRUPO\"," +
                    "       sm.\"CODIGO\" AS \"SUBMODULO\"," +
                    "       m.\"TEXTO\" AS \"MODULO\"," +
                    "       m.\"NUMERO_ORDEN\" AS \"NUMERO_ORDEN\"," +
                    "       sm.\"CODIGO_ORDEN\" AS \"CODIGO_ORDEN\"," +
                    "       i.\"NOMBRE\" AS \"INSTRUCTOR\"," +
                    "       p.\"FECHA\" AS \"FECHA\"," +
                    "       p.\"HORA_INICIO\" AS \"HORA\"" +
                    " FROM " + clase_practica + " AS c " +
                    "   INNER JOIN " + clase_parte + " AS cp ON (cp.\"OID_CLASE\" = c.\"OID\" AND cp.\"TIPO\" = 2 AND cp.\"GRUPO\" = 1) " +
                    "   INNER JOIN " + parte + " AS p ON (cp.\"OID_PARTE\" = p.\"OID\") " +
                    "   INNER JOIN " + submodulo + " AS sm ON (c.\"OID_SUBMODULO\" = sm.\"OID\") " +
                    "   INNER JOIN " + modulo + " AS m ON (c.\"OID_MODULO\" = m.\"OID\") " +
                    "	INNER JOIN " + sesion + " AS s ON (s.\"OID_CLASE_PRACTICA\" = c.\"OID\" AND s.\"ESTADO\" = 3) " +
                    "	INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\") " +
                    "	INNER JOIN " + instructor + " AS i ON (s.\"OID_PROFESOR\" = i.\"OID\"";
            if (mostrar_autorizados)
                query1 += " AND i.\"OID\" NOT IN ( " +
                            "SELECT si.\"OID_INSTRUCTOR\" " +
                            "FROM " + submodulo_instructor + " AS si " +
                            "WHERE si.\"OID_SUBMODULO\" = sm.\"OID\" AND p.\"FECHA\" BETWEEN COALESCE(si.\"FECHA_INICIO\", '01-01-0001') AND COALESCE(si.\"FECHA_FIN\", '12-31-2999'))";
            query1 += ") " +
                    "WHERE c.\"OID_PLAN\" = " + oid_plan.ToString() + " AND h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " AND s.\"GRUPO\" = 1 " +
                    "UNION " +
                    "SELECT DISTINCT c.*," +
                    "       cast(cast(c.\"OID\" as varchar) || '2' as bigint) AS \"OID_MERGE\"," +
                    "       2 AS \"GRUPO\"," +
                    "       sm.\"CODIGO\" AS \"SUBMODULO\"," +
                    "       m.\"TEXTO\" AS \"MODULO\"," +
                    "       m.\"NUMERO_ORDEN\" AS \"NUMERO_ORDEN\"," +
                    "       sm.\"CODIGO_ORDEN\" AS \"CODIGO_ORDEN\"," +
                    "       i.\"NOMBRE\" AS \"INSTRUCTOR\"," +
                    "       p.\"FECHA\" AS \"FECHA\"," +
                    "       p.\"HORA_INICIO\" AS \"HORA\"" +
                    " FROM " + clase_practica + " AS c " +
                    "   INNER JOIN " + clase_parte + " AS cp ON (cp.\"OID_CLASE\" = c.\"OID\" AND cp.\"TIPO\" = 2 AND cp.\"GRUPO\" = 2) " +
                    "   INNER JOIN " + parte + " AS p ON (cp.\"OID_PARTE\" = p.\"OID\") " +
                    "   INNER JOIN " + submodulo + " AS sm ON (c.\"OID_SUBMODULO\" = sm.\"OID\") " +
                    "   INNER JOIN " + modulo + " AS m ON (c.\"OID_MODULO\" = m.\"OID\") " +
                    "	INNER JOIN " + sesion + " AS s ON (s.\"OID_CLASE_PRACTICA\" = c.\"OID\" AND s.\"ESTADO\" = 3) " +
                    "	INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\") " +
                    "	INNER JOIN " + instructor + " AS i ON (s.\"OID_PROFESOR\" = i.\"OID\"";
            if (mostrar_autorizados)
                query1 += " AND i.\"OID\" NOT IN ( " +
                            "SELECT si.\"OID_INSTRUCTOR\" " +
                            "FROM " + submodulo_instructor + " AS si " +
                            "WHERE si.\"OID_SUBMODULO\" = sm.\"OID\" AND p.\"FECHA\" BETWEEN COALESCE(si.\"FECHA_INICIO\", '01-01-0001') AND COALESCE(si.\"FECHA_FIN\", '12-31-2999'))";
            query1 += ") " +
                    "WHERE c.\"OID_PLAN\" = " + oid_plan.ToString() + " AND h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " AND s.\"GRUPO\" = 2 " +
                    "UNION " +
                    "SELECT DISTINCT c.*," +
                    "       cast(cast(c.\"OID\" as varchar) || '1' as bigint) AS \"OID_MERGE\"," +
                    "       1 AS \"GRUPO\"," +
                    "       sm.\"CODIGO\" AS \"SUBMODULO\"," +
                    "       m.\"TEXTO\" AS \"MODULO\"," +
                    "       m.\"NUMERO_ORDEN\" AS \"NUMERO_ORDEN\"," +
                    "       sm.\"CODIGO_ORDEN\" AS \"CODIGO_ORDEN\",";
            if (mostrar_autorizados)
                query1 +=
                    "       ia.\"NOMBRE\" AS \"INSTRUCTOR\",";
            else
                query1 +=
                    "       i.\"NOMBRE\" AS \"INSTRUCTOR\",";
            query1 +=
                    "       p.\"FECHA\" AS \"FECHA\"," +
                    "       p.\"HORA_INICIO\" AS \"HORA\"" +
                    " FROM " + clase_practica + " AS c " +
                    "   INNER JOIN " + clase_parte + " AS cp ON (cp.\"OID_CLASE\" = c.\"OID\" AND cp.\"TIPO\" = 2 AND cp.\"GRUPO\" = 1) " +
                    "   INNER JOIN " + parte + " AS p ON (cp.\"OID_PARTE\" = p.\"OID\") " +
                    "   INNER JOIN " + submodulo + " AS sm ON (c.\"OID_SUBMODULO\" = sm.\"OID\") " +
                    "   INNER JOIN " + modulo + " AS m ON (c.\"OID_MODULO\" = m.\"OID\") " +
                    "	INNER JOIN " + sesion + " AS s ON (s.\"OID_CLASE_PRACTICA\" = c.\"OID\" AND s.\"ESTADO\" = 3) " +
                    "	INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\") " +
                    "   INNER JOIN " + instructor + " AS i ON (s.\"OID_PROFESOR\" = i.\"OID\") ";
            if (mostrar_autorizados)
                query1 +=
                        "INNER JOIN " + submodulo_instructor + " AS si ON (si.\"OID_INSTRUCTOR\" = i.\"OID\" AND si.\"OID_SUBMODULO\" = sm.\"OID\" AND p.\"FECHA\" BETWEEN COALESCE(si.\"FECHA_INICIO\", '01-01-0001') AND COALESCE(si.\"FECHA_FIN\", '12-31-2999')) " +
                        "INNER JOIN " + instructor + " AS ia ON (si.\"OID_INSTRUCTOR_SUPLENTE\" = ia.\"OID\") ";
            query1 +=
                    "WHERE c.\"OID_PLAN\" = " + oid_plan.ToString() + " AND h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " AND s.\"GRUPO\" = 1 " +
                    "UNION " +
                    "SELECT DISTINCT c.*," +
                    "       cast(cast(c.\"OID\" as varchar) || '2' as bigint) AS \"OID_MERGE\"," +
                    "       2 AS \"GRUPO\"," +
                    "       sm.\"CODIGO\" AS \"SUBMODULO\"," +
                    "       m.\"TEXTO\" AS \"MODULO\"," +
                    "       m.\"NUMERO_ORDEN\" AS \"NUMERO_ORDEN\"," +
                    "       sm.\"CODIGO_ORDEN\" AS \"CODIGO_ORDEN\",";
            if (mostrar_autorizados)
                query1 +=
                    "       ia.\"NOMBRE\" AS \"INSTRUCTOR\",";
            else
                query1 +=
                    "       i.\"NOMBRE\" AS \"INSTRUCTOR\",";
            query1 +=
                    "       p.\"FECHA\" AS \"FECHA\"," +
                    "       p.\"HORA_INICIO\" AS \"HORA\"" +
                    " FROM " + clase_practica + " AS c " +
                    "   INNER JOIN " + clase_parte + " AS cp ON (cp.\"OID_CLASE\" = c.\"OID\" AND cp.\"TIPO\" = 2 AND cp.\"GRUPO\" = 2) " +
                    "   INNER JOIN " + parte + " AS p ON (cp.\"OID_PARTE\" = p.\"OID\") " +
                    "   INNER JOIN " + submodulo + " AS sm ON (c.\"OID_SUBMODULO\" = sm.\"OID\") " +
                    "   INNER JOIN " + modulo + " AS m ON (c.\"OID_MODULO\" = m.\"OID\") " +
                    "	INNER JOIN " + sesion + " AS s ON (s.\"OID_CLASE_PRACTICA\" = c.\"OID\" AND s.\"ESTADO\" = 3) " +
                    "	INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\") " +
                    "   INNER JOIN " + instructor + " AS i ON (s.\"OID_PROFESOR\" = i.\"OID\") ";
            if (mostrar_autorizados)
                query1 +=
                        "INNER JOIN " + submodulo_instructor + " AS si ON (si.\"OID_INSTRUCTOR\" = i.\"OID\" AND si.\"OID_SUBMODULO\" = sm.\"OID\" AND p.\"FECHA\" BETWEEN COALESCE(si.\"FECHA_INICIO\", '01-01-0001') AND COALESCE(si.\"FECHA_FIN\", '12-31-2999')) " +
                        "INNER JOIN " + instructor + " AS ia ON (si.\"OID_INSTRUCTOR_SUPLENTE\" = ia.\"OID\") ";
            query1 +=
                    "WHERE c.\"OID_PLAN\" = " + oid_plan.ToString() + " AND h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " AND s.\"GRUPO\" = 2 " +
                    "ORDER BY \"FECHA\", \"HORA\", \"GRUPO\"";


            string query = "SELECT \"COUNT_MODULO\", \"COUNT_SUBMODULO\", CONSULTA.* " +
                            "FROM " +
                            "(SELECT Q2.\"OID_MODULO\", Q2.\"OID_SUBMODULO\", \"COUNT_MODULO\", \"COUNT_SUBMODULO\", Q1.\"GRUPO\" " +
                            "FROM " +
                            "(SELECT \"OID_MODULO\", COUNT(\"OID_MODULO\") AS \"COUNT_MODULO\", \"GRUPO\"  " +
                            "FROM (" +
                //clase_practica + " AS c     " +
                //"    INNER JOIN " + clase_parte + " AS cp ON (cp.\"OID_CLASE\" = c.\"OID\" AND cp.\"TIPO\" = 2)  " +
                //"    INNER JOIN " + sesion + " AS s ON (s.\"OID_CLASE_PRACTICA\" = c.\"OID\" AND s.\"ESTADO\" = 3) 	 " +
                //"    INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\")     " +
                            "       SELECT DISTINCT c.*, 1 AS \"GRUPO\", h.\"OID_PROMOCION\"  " +
                            "        FROM " + clase_practica + " AS c      " +
                            "            INNER JOIN " + sesion + " AS s ON (s.\"OID_CLASE_PRACTICA\" = c.\"OID\" AND s.\"ESTADO\" = 3) 	  " +
                            "            INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\")     " +
                            "        WHERE c.\"OID_PLAN\" = " + oid_plan.ToString() + " AND h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " AND s.\"GRUPO\" = 1   " +
                            "        UNION SELECT DISTINCT c.*, 2 AS \"GRUPO\", h.\"OID_PROMOCION\"  " +
                            "        FROM " + clase_practica + " AS c    	  " +
                            "            INNER JOIN " + sesion + " AS s ON (s.\"OID_CLASE_PRACTICA\" = c.\"OID\" AND s.\"ESTADO\" = 3) 	  " +
                            "            INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\")     " +
                            "        WHERE c.\"OID_PLAN\" = " + oid_plan.ToString() + " AND h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " AND s.\"GRUPO\" = 2   " +
                            ") AS c WHERE c.\"OID_PLAN\" = " + oid_plan.ToString() + " AND c.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " " +
                            "GROUP BY \"OID_MODULO\", c.\"GRUPO\") AS Q1, " +
                            "(SELECT \"OID_MODULO\", \"OID_SUBMODULO\", COUNT(\"OID_SUBMODULO\") AS \"COUNT_SUBMODULO\", c.\"GRUPO\"  " +
                            "FROM (" +
                //clase_practica + " AS c     " +
                //"    INNER JOIN " + clase_parte + " AS cp ON (cp.\"OID_CLASE\" = c.\"OID\" AND cp.\"TIPO\" = 2)  " +
                //"    INNER JOIN " + sesion + " AS s ON (s.\"OID_CLASE_PRACTICA\" = c.\"OID\" AND s.\"ESTADO\" = 3) 	 " +
                //"    INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\")     " +
                            "       SELECT DISTINCT c.*, 1 AS \"GRUPO\", h.\"OID_PROMOCION\"  " +
                            "        FROM " + clase_practica + " AS c      " +
                            "            INNER JOIN " + sesion + " AS s ON (s.\"OID_CLASE_PRACTICA\" = c.\"OID\" AND s.\"ESTADO\" = 3) 	  " +
                            "            INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\")     " +
                            "        WHERE c.\"OID_PLAN\" = " + oid_plan.ToString() + " AND h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " AND s.\"GRUPO\" = 1   " +
                            "        UNION SELECT DISTINCT c.*, 2 AS \"GRUPO\", h.\"OID_PROMOCION\"  " +
                            "        FROM " + clase_practica + " AS c    	  " +
                            "            INNER JOIN " + sesion + " AS s ON (s.\"OID_CLASE_PRACTICA\" = c.\"OID\" AND s.\"ESTADO\" = 3) 	  " +
                            "            INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\")     " +
                            "        WHERE c.\"OID_PLAN\" = " + oid_plan.ToString() + " AND h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " AND s.\"GRUPO\" = 2   " +
                            ") AS c WHERE c.\"OID_PLAN\" = " + oid_plan.ToString() + " AND c.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " " +
                            "GROUP BY \"OID_MODULO\", \"OID_SUBMODULO\", c.\"GRUPO\") AS Q2 " +
                            "WHERE Q1.\"OID_MODULO\" = Q2.\"OID_MODULO\" AND Q1.\"GRUPO\" = Q2.\"GRUPO\")AS CONTADORES, " +
                            "( " + query1 + " ) AS CONSULTA " +
                            "WHERE CONTADORES.\"OID_SUBMODULO\" = CONSULTA.\"OID_SUBMODULO\" AND CONTADORES.\"GRUPO\" = CONSULTA.\"GRUPO\";";

            return query;
        }

        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public static string SELECT_BY_PLAN(long oid_plan)
        {
            string query;

            query = ClasePractica.SELECT(0) +
                    " WHERE CP.\"OID_PLAN\" = " + oid_plan.ToString() +
                    " ORDER BY M.\"NUMERO_ORDEN\", S.\"CODIGO_ORDEN\", CP.\"ORDEN_TERCIARIO\"";

            return query;
        }

        public new static string SELECT()
        {
            string query;

            query = ClasePractica.SELECT(0) +
                    "ORDER BY M.\"NUMERO_ORDEN\", S.\"CODIGO_ORDEN\", CP.\"ORDEN_TERCIARIO\"";

            return query;
        }

        public static string SELECT_CLASES_PRACTICAS_PLAN(long oid_plan)
        {
            string query;

            query = ClasePractica.SELECT(0) +
                    "WHERE CP.\"OID_PLAN\" = " + oid_plan.ToString() +
                    "ORDER BY M.\"NUMERO_ORDEN\", S.\"CODIGO_ORDEN\", CP.\"ORDEN_TERCIARIO\"";

            return query;
        }

        public static string SELECT_CLASES_PRACTICAS_PLAN_ORDENADAS(long oid_plan, long oid_promocion = 0, int grupo = 0)
        {
            string query;
            string promo = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));
            string alumno_promo = nHManager.Instance.GetSQLTable(typeof(AlumnoPromocionRecord));
            string alumno = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));

            query = ClasePractica.SELECT(0);
            if (oid_promocion != 0)
                query += "INNER JOIN " + promo + " AS PR ON PR.\"OID_PLAN\" = CP.\"OID_PLAN\" AND PR.\"OID\" = " + oid_promocion.ToString() + " ";
            query += "WHERE CP.\"OID_PLAN\" = " + oid_plan.ToString();
            if (oid_promocion != 0 && grupo != 0)
                query += " AND PR.\"OID\" IN (  SELECT P.\"OID\" " +
                        "   FROM " + promo + " AS P " +
                        "   INNER JOIN " + alumno_promo + " AS AP ON AP.\"OID_PROMOCION\" = P.\"OID\" " +
                        "   INNER JOIN " + alumno + " AS A ON A.\"OID\" = AP.\"OID_ALUMNO\" " +
                        "   WHERE A.\"GRUPO\" = " + grupo.ToString() + ") ";
            query += " ORDER BY CP.\"ORDEN_PRIMARIO\", CP.\"ORDEN_SECUNDARIO\", CP.\"ORDEN_TERCIARIO\", M.\"NUMERO_ORDEN\", S.\"CODIGO_ORDEN\"";

            return query;
        }
        
        #endregion

    }
}

