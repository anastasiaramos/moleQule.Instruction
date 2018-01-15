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
	/// Editable Child Collection
	/// </summary>
	[Serializable()]
	public class ClaseTeoricas : BusinessListBaseEx<ClaseTeoricas, ClaseTeorica>
	{

		#region Business Methods

		public ClaseTeorica NewItem(PlanEstudios parent)
		{
			this.AddItem(ClaseTeorica.NewChild(parent));
			return this[Count - 1];
		}

		public ClaseTeorica NewItem(Modulo parent)
		{
			this.AddItem(ClaseTeorica.NewChild(parent));
			return this[Count - 1];
		}

		public ClaseTeorica NewItem(Submodulo parent)
		{
			this.AddItem(ClaseTeorica.NewChild(parent));
			return this[Count - 1];
		}

		#endregion

		#region Factory Methods

		private ClaseTeoricas()
		{
			MarkAsChild();
		}

		private ClaseTeoricas(IList<ClaseTeorica> lista)
		{
			MarkAsChild();
			Fetch(lista);
		}

		private ClaseTeoricas(IDataReader reader)
		{
			MarkAsChild();
			Fetch(reader);
		}

		public static ClaseTeoricas NewChildList() { return new ClaseTeoricas(); }

		public static ClaseTeoricas GetChildList(IList<ClaseTeorica> lista) { return new ClaseTeoricas(lista); }

		public static ClaseTeoricas GetChildList(IDataReader reader) { return new ClaseTeoricas(reader); }

		public List<ClaseTeorica> GetClasesOrdenadasByPlan(long oid_plan)
		{
			List<ClaseTeorica> lista = new List<ClaseTeorica>();
			string query = ClaseTeoricas.SELECT_BY_PLAN(oid_plan);
			int sesion = ClaseTeorica.OpenSession();

			IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(sesion));

			while (reader.Read())
			{
				ClaseTeorica p = this.GetItem((long)reader["OID"]);

				lista.Add(p);
			}

			CloseSession(sesion);

			return lista;
		}

		#endregion

		#region Child Data Access

		// called to copy objects data from list
		private void Fetch(IList<ClaseTeorica> lista)
		{
			this.RaiseListChangedEvents = false;

			foreach (ClaseTeorica item in lista)
				this.AddItem(ClaseTeorica.GetChild(item));

			this.RaiseListChangedEvents = true;
		}

		private void Fetch(IDataReader reader)
		{
			this.RaiseListChangedEvents = false;

			while (reader.Read())
				this.AddItem(ClaseTeorica.GetChild(reader));

			this.RaiseListChangedEvents = true;
		}

		internal void Update(PlanEstudios parent)
		{
			this.RaiseListChangedEvents = false;

			// update (thus deleting) any deleted child objects
			foreach (ClaseTeorica obj in DeletedList)
				obj.DeleteSelf(parent);

			// 'now' that they are deleted, remove them from memory too
			DeletedList.Clear();

			// AddItem/update any current child objects
			foreach (ClaseTeorica obj in this)
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
			foreach (ClaseTeorica obj in DeletedList)
				obj.DeleteSelf(parent);

			// 'now' that they are deleted, remove them from memory too
			DeletedList.Clear();

			// AddItem/update any current child objects
			foreach (ClaseTeorica obj in this)
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
			foreach (ClaseTeorica obj in DeletedList)
				obj.DeleteSelf(parent);

			// 'now' that they are deleted, remove them from memory too
			DeletedList.Clear();

			// AddItem/update any current child objects
			foreach (ClaseTeorica obj in this)
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

            query = ClaseTeorica.SELECT(0) +
                    " WHERE CT.\"OID_SUBMODULO\" = " + oid.ToString();

            if (lock_table) query += " FOR UPDATE OF CT NOWAIT";

            return query;
        }

        public static string SELECT_BY_SUBMODULO(long oid_submodulo) { return SELECT_BY_SUBMODULO(oid_submodulo, true); }

        public static string SELECT_CLASES_TEORICAS_NO_IMPARTIDAS(long oid_plan, long oid_plan_extra, long oid_promocion)
        {
            string clase = nHManager.Instance.GetSQLTable(typeof(ClaseTeoricaRecord));
            string extra = nHManager.Instance.GetSQLTable(typeof(ClaseExtraRecord));
            string horario = nHManager.Instance.GetSQLTable(typeof(HorarioRecord));
            string sesion = nHManager.Instance.GetSQLTable(typeof(SesionRecord));
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));

            string query =  "SELECT CONTADORES.\"COUNT_MODULO\", CONTADORES.\"COUNT_SUBMODULO\", CONSULTA.* " +
                            "FROM " +
                            "(SELECT C1.\"OID_MODULO\", C2.\"OID_SUBMODULO\", \"COUNT_MODULO\", \"COUNT_SUBMODULO\" " +
                            "FROM " +
                            "(SELECT Q1.\"OID_MODULO\", COUNT(Q1.\"OID_MODULO\") AS \"COUNT_MODULO\" " +
                            "FROM ( " +
                            "SELECT cl.\"OID\", cl.\"OID_MODULO\" " +
                            "FROM " + clase + " AS cl  " +
                            "WHERE cl.\"OID\" NOT IN ( SELECT c.\"OID\"  " +
			                "            FROM " + sesion + " AS s  " +
				            "                INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\")  " +
				            "                INNER JOIN " + clase + " AS c ON (s.\"OID_CLASE_TEORICA\" = c.\"OID\")  " +
			                "            WHERE h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " AND c.\"OID_PLAN\" = " + oid_plan.ToString() + " AND s.\"ESTADO\" = 3 )  " +
	                        "    AND cl.\"OID_PLAN\" = " + oid_plan.ToString() + 
                            "UNION " +
                            "SELECT cl.\"OID\", cl.\"OID_MODULO\" " +
                            "FROM " + extra + " AS cl  " +
                            "WHERE cl.\"OID\" NOT IN ( SELECT c.\"OID\"  " +
                            "            FROM " + sesion + " AS s  " +
                            "                INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\")  " +
                            "                INNER JOIN " + extra + " AS c ON (s.\"OID_CLASE_EXTRA\" = c.\"OID\")  " +
                            "            WHERE h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " AND c.\"OID_PLAN\" = " + oid_plan_extra.ToString() + " AND s.\"ESTADO\" = 3 )  " +
                            "    AND cl.\"OID_PLAN\" = " + oid_plan_extra.ToString() + 
                            " ) AS Q1 " +
                            "GROUP BY Q1.\"OID_MODULO\") AS C1, " +
                            "(SELECT Q2.\"OID_MODULO\", Q2.\"OID_SUBMODULO\", COUNT(Q2.\"OID_SUBMODULO\") AS \"COUNT_SUBMODULO\" " +
                            "FROM ( " +
                            "SELECT cl.\"OID\", cl.\"OID_MODULO\", cl.\"OID_SUBMODULO\" " +
                            "FROM " + clase + " AS cl  " +
                            "WHERE cl.\"OID\" NOT IN ( SELECT c.\"OID\"  " +
			                "            FROM " + sesion + " AS s  " +
				            "                INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\")  " +
				            "                INNER JOIN " + clase + " AS c ON (s.\"OID_CLASE_TEORICA\" = c.\"OID\")  " +
                            "            WHERE h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " AND c.\"OID_PLAN\" = " + oid_plan.ToString() + " AND s.\"ESTADO\" = 3 )  " +
	                        "    AND cl.\"OID_PLAN\" = " + oid_plan.ToString() + 
                            "UNION " +
                            "SELECT cl.\"OID\", cl.\"OID_MODULO\", cl.\"OID_SUBMODULO\" " +
                            "FROM " + extra + " AS cl  " +
                            "WHERE cl.\"OID\" NOT IN ( SELECT c.\"OID\"  " +
                            "            FROM " + sesion + " AS s  " +
                            "                INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\")  " +
                            "                INNER JOIN " + extra + " AS c ON (s.\"OID_CLASE_EXTRA\" = c.\"OID\")  " +
                            "            WHERE h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " AND c.\"OID_PLAN\" = " + oid_plan_extra.ToString() + " AND s.\"ESTADO\" = 3 )  " +
                            "    AND cl.\"OID_PLAN\" = " + oid_plan_extra.ToString() + 
                            " ) AS Q2 " +
                            "GROUP BY Q2.\"OID_MODULO\", Q2.\"OID_SUBMODULO\") AS C2 " +
                            "WHERE C1.\"OID_MODULO\" = C2.\"OID_MODULO\") AS CONTADORES, " +
                            "( " + SELECT_CLASES_TEORICAS_EXTRAS_DISPONIBLES(oid_plan, oid_plan_extra, oid_promocion) + " )AS CONSULTA " +
                            "WHERE CONSULTA.\"OID_SUBMODULO\" = CONTADORES.\"OID_SUBMODULO\"";
            return query;
        }

        public static string SELECT_CLASES_TEORICAS_DISPONIBLES(long oid_plan,
                                                                    long oid_promocion)
        {
            string clase = nHManager.Instance.GetSQLTable(typeof(ClaseTeoricaRecord));
            string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string horario = nHManager.Instance.GetSQLTable(typeof(HorarioRecord));
            string sesion = nHManager.Instance.GetSQLTable(typeof(SesionRecord));

            string query;

            query = "SELECT cl.* ," +
                    "       1 AS \"ESTADO\"," +
                    "       sm.\"CODIGO\" AS \"SUBMODULO\"," +
                    "       m.\"TEXTO\" AS \"MODULO\"," +
                    "       m.\"NUMERO_ORDEN\" AS \"NUMERO_ORDEN\"," +
                    "       sm.\"CODIGO_ORDEN\" AS \"CODIGO_ORDEN\"," +
                    "       '' AS \"INSTRUCTOR\"," +
                    "       '1999-01-08' AS \"FECHA\"," +
                    "       '00:00:00' AS \"HORA\"," +
                    "       0 AS \"COUNT_MODULO\"," +
                    "       0 AS \"COUNT_SUBMODULO\"" +
                    " FROM " + clase + " AS cl " +
                        "INNER JOIN " + submodulo + " AS sm ON (cl.\"OID_SUBMODULO\" = sm.\"OID\") " +
                        "INNER JOIN " + modulo + " AS m ON (cl.\"OID_MODULO\" = m.\"OID\") " +
                    "WHERE cl.\"OID\" NOT IN ( " +
                        "SELECT c.\"OID\" " +
                        "FROM " + sesion + " AS s " +
                            "INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\") " +
                            "INNER JOIN " + clase + " AS c ON (s.\"OID_CLASE_TEORICA\" = c.\"OID\") " +
                       "WHERE h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " " +
                       "AND c.\"OID_PLAN\" = " + oid_plan.ToString() + " " +
                       "AND s.\"ESTADO\" = 3 ) " +
                    "AND cl.\"OID_PLAN\" = " + oid_plan.ToString() + " " +
                   "ORDER BY \"ORDEN_PRIMARIO\", \"ORDEN_SECUNDARIO\", \"ORDEN_TERCIARIO\", \"NUMERO_ORDEN\", \"CODIGO_ORDEN\"";

            return query;
        }


        public static string SELECT_CLASES_TEORICAS_EXTRAS_DISPONIBLES(long oid_plan, long oid_plan_extra,
                                                                    long oid_promocion)
        {
            string clase = nHManager.Instance.GetSQLTable(typeof(ClaseTeoricaRecord));
            string extra = nHManager.Instance.GetSQLTable(typeof(ClaseExtraRecord));
            string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string horario = nHManager.Instance.GetSQLTable(typeof(HorarioRecord));
            string sesion = nHManager.Instance.GetSQLTable(typeof(SesionRecord));

            string query;

            query = "SELECT cl.\"OID\", cl.\"OID_MODULO\", cl.\"OID_SUBMODULO\", cl.\"ORDEN_PRIMARIO\"," +
                    "   cl.\"ORDEN_SECUNDARIO\", cl.\"TITULO\", cl.\"OBSERVACIONES\", cl.\"ORDEN_TERCIARIO\", cl.\"ALIAS\"," +
                    "   cl.\"TOTAL_CLASES\", cl.\"DURACION\", cl.\"OID_PLAN\", " +
                    "       1 AS \"ESTADO\"," +
                    "       sm.\"CODIGO\" AS \"SUBMODULO\"," +
                    "       m.\"TEXTO\" AS \"MODULO\"," +
                    "       m.\"NUMERO_ORDEN\" AS \"NUMERO_ORDEN\"," +
                    "       sm.\"CODIGO_ORDEN\" AS \"CODIGO_ORDEN\"," +
                    "       '' AS \"INSTRUCTOR\"," +
                    "       '1999-01-08' AS \"FECHA\"," +
                    "       '00:00:00' AS \"HORA\"," +
                    "       0 AS \"COUNT_MODULO\"," +
                    "       0 AS \"COUNT_SUBMODULO\"" +
                    " FROM " + clase + " AS cl " +
                        "INNER JOIN " + submodulo + " AS sm ON (cl.\"OID_SUBMODULO\" = sm.\"OID\") " +
                        "INNER JOIN " + modulo + " AS m ON (cl.\"OID_MODULO\" = m.\"OID\") " +
                    "WHERE cl.\"OID\" NOT IN ( " +
                        "SELECT c.\"OID\" " +
                        "FROM " + sesion + " AS s " +
                            "INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\") " +
                            "INNER JOIN " + clase + " AS c ON (s.\"OID_CLASE_TEORICA\" = c.\"OID\") " +
                       "WHERE h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " " +
                       "AND c.\"OID_PLAN\" = " + oid_plan.ToString() + " " +
                       "AND s.\"ESTADO\" = 3 ) " +
                    "AND cl.\"OID_PLAN\" = " + oid_plan.ToString() + " " +
                    "UNION " +
                    "SELECT cl.\"OID\", cl.\"OID_MODULO\", cl.\"OID_SUBMODULO\", 1 AS \"ORDEN_PRIMARIO\"," +
                    "   1 AS \"ORDEN_SECUNDARIO\", cl.\"TITULO\", cl.\"OBSERVACIONES\", 1 AS \"ORDEN_TERCIARIO\", cl.\"ALIAS\"," +
                    "   cl.\"TOTAL_CLASES\", cl.\"ORDEN\" AS \"DURACION\", cl.\"OID_PLAN\", " +
                    "       1 AS \"ESTADO\"," +
                    "       sm.\"CODIGO\" AS \"SUBMODULO\"," +
                    "       m.\"TEXTO\" AS \"MODULO\"," +
                    "       m.\"NUMERO_ORDEN\" AS \"NUMERO_ORDEN\"," +
                    "       sm.\"CODIGO_ORDEN\" AS \"CODIGO_ORDEN\"," +
                    "       '' AS \"INSTRUCTOR\"," +
                    "       '1999-01-08' AS \"FECHA\"," +
                    "       '00:00:00' AS \"HORA\"," +
                    "       0 AS \"COUNT_MODULO\"," +
                    "       0 AS \"COUNT_SUBMODULO\"" +
                    " FROM " + extra + " AS cl " +
                        "INNER JOIN " + submodulo + " AS sm ON (cl.\"OID_SUBMODULO\" = sm.\"OID\") " +
                        "INNER JOIN " + modulo + " AS m ON (cl.\"OID_MODULO\" = m.\"OID\") " +
                    "WHERE cl.\"OID\" NOT IN ( " +
                        "SELECT c.\"OID\" " +
                        "FROM " + sesion + " AS s " +
                            "INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\") " +
                            "INNER JOIN " + extra + " AS c ON (s.\"OID_CLASE_EXTRA\" = c.\"OID\") " +
                       "WHERE h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " " +
                       "AND c.\"OID_PLAN\" = " + oid_plan_extra.ToString() + " " +
                       "AND s.\"ESTADO\" = 3 ) " +
                    "AND cl.\"OID_PLAN\" = " + oid_plan_extra.ToString() + " " +
                   "ORDER BY \"ORDEN_PRIMARIO\", \"ORDEN_SECUNDARIO\", \"ORDEN_TERCIARIO\", \"NUMERO_ORDEN\", \"CODIGO_ORDEN\"";

            return query;
        }

        public static string SELECT_CLASES_TEORICAS_DISPONIBLES_old(    long oid_plan,
                                                                    long oid_promocion,
                                                                    long oid_horario)
        {
            string clase = nHManager.Instance.GetSQLTable(typeof(ClaseTeoricaRecord));
            string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string horario = nHManager.Instance.GetSQLTable(typeof(HorarioRecord));
            string sesion = nHManager.Instance.GetSQLTable(typeof(SesionRecord));

            string query;

            query = "SELECT cl.* ," +
                    "       1 AS \"ESTADO\"," +
                    "       sm.\"CODIGO\" AS \"SUBMODULO\"," +
                    "       m.\"TEXTO\" AS \"MODULO\"," +
                    "       m.\"NUMERO_ORDEN\" AS \"NUMERO_ORDEN\"," +
                    "       sm.\"CODIGO_ORDEN\" AS \"CODIGO_ORDEN\"," +
                    "       '' AS \"INSTRUCTOR\"," +
                    "       '1999-01-08' AS \"FECHA\"," +
                    "       '00:00:00' AS \"HORA\"," +
                    "       0 AS \"COUNT_MODULO\"," +
                    "       0 AS \"COUNT_SUBMODULO\"" +
                    " FROM " + clase + " AS cl " +
                        "INNER JOIN " + submodulo + " AS sm ON (cl.\"OID_SUBMODULO\" = sm.\"OID\") " +
                        "INNER JOIN " + modulo + " AS m ON (cl.\"OID_MODULO\" = m.\"OID\") " +
                    "WHERE cl.\"OID\" NOT IN ( " +
                        "SELECT c.\"OID\" " +
                        "FROM " + sesion + " AS s " +
                            "INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\") " +
                            "INNER JOIN " + clase + " AS c ON (s.\"OID_CLASE_TEORICA\" = c.\"OID\") " +
                       "WHERE h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " " +
                       "AND c.\"OID_PLAN\" = " + oid_plan.ToString() + " " +
                       "AND s.\"ESTADO\" > 1 ) " +
                    "AND cl.\"OID_PLAN\" = " + oid_plan.ToString() + " " +
                    "UNION " +
                    "SELECT cl.*," +
                    "       2 AS \"ESTADO\"," +
                    "       sm.\"CODIGO\" AS \"SUBMODULO\"," +
                    "       m.\"TEXTO\" AS \"MODULO\"," +
                    "       m.\"NUMERO_ORDEN\" AS \"NUMERO_ORDEN\"," +
                    "       sm.\"CODIGO_ORDEN\" AS \"CODIGO_ORDEN\"," +
                    "       '' AS \"INSTRUCTOR\"," +
                    "       '1999-01-08' AS \"FECHA\"," +
                    "       '00:00:00' AS \"HORA\"," +
                    "       0 AS \"COUNT_MODULO\"," +
                    "       0 AS \"COUNT_SUBMODULO\"" +
                    "FROM " + sesion + " AS s " +
                            "INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\") " +
                            "INNER JOIN " + clase + " AS cl ON (s.\"OID_CLASE_TEORICA\" = cl.\"OID\") " +
                            "INNER JOIN " + submodulo + " AS sm ON (cl.\"OID_SUBMODULO\" = sm.\"OID\") " +
                            "INNER JOIN " + modulo + " AS m ON (cl.\"OID_MODULO\" = m.\"OID\") " +
                       "WHERE s.\"OID_HORARIO\" = " + oid_horario.ToString() + " " +
                   "ORDER BY \"ORDEN_PRIMARIO\", \"ORDEN_SECUNDARIO\", \"ORDEN_TERCIARIO\", \"NUMERO_ORDEN\", \"CODIGO_ORDEN\"";
            
            return query;
        }

         public static string SELECT_CLASES_TEORICAS_DISPONIBLES(    long oid_plan,
                                                                    long oid_promocion,
                                                                    long oid_horario)
        {
            string clase = nHManager.Instance.GetSQLTable(typeof(ClaseTeoricaRecord));
            string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string horario = nHManager.Instance.GetSQLTable(typeof(HorarioRecord));
            string sesion = nHManager.Instance.GetSQLTable(typeof(SesionRecord));

            string query;

            query = "SELECT cl.*, 0 AS \"ORDEN_IMPARTIDA\" " +
                    "FROM( " +
	                "    SELECT cl.*  " +
	                "    FROM( " +
		            "        SELECT cl.* , 1 AS \"ESTADO\", sm.\"CODIGO\" AS \"SUBMODULO\", m.\"TEXTO\" AS \"MODULO\", m.\"NUMERO_ORDEN\" AS \"NUMERO_ORDEN\", " +
                    "               sm.\"CODIGO_ORDEN\" AS \"CODIGO_ORDEN\", '' AS \"INSTRUCTOR\", '1999-01-08' AS \"FECHA\", '00:00:00' AS \"HORA\", " +
                    "               0 AS \"COUNT_MODULO\", 0 AS \"COUNT_SUBMODULO\"  " +
		            "        FROM " + clase + " AS cl  " +
		            "        INNER JOIN " + submodulo + " AS sm ON (cl.\"OID_SUBMODULO\" = sm.\"OID\")  " +
		            "        INNER JOIN " + modulo + " AS m ON (cl.\"OID_MODULO\" = m.\"OID\") " +
		            "        WHERE cl.\"OID\" NOT IN (  " +
				    "                SELECT c.\"OID\"  " +
				    "                FROM " + sesion + " AS s  " +
				    "                INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\")  " +
				    "                INNER JOIN " + clase + " AS c ON (s.\"OID_CLASE_TEORICA\" = c.\"OID\")  " +
				    "                WHERE h.\"OID_PROMOCION\" = " + oid_promocion + "  AND c.\"OID_PLAN\" = " + oid_plan + "  AND s.\"ESTADO\" > 1 )  " +
			        "            AND cl.\"OID_PLAN\" = " + oid_plan + " AND cl.\"ORDEN_TERCIARIO\" > 1 " +
		            "        UNION  " +
		            "        SELECT cl.*, s.\"ESTADO\" AS \"ESTADO\", sm.\"CODIGO\" AS \"SUBMODULO\", m.\"TEXTO\" AS \"MODULO\", m.\"NUMERO_ORDEN\" AS \"NUMERO_ORDEN\", " +
                    "               sm.\"CODIGO_ORDEN\" AS \"CODIGO_ORDEN\", '' AS \"INSTRUCTOR\", '1999-01-08' AS \"FECHA\", '00:00:00' AS \"HORA\", " +
                    "               0 AS \"COUNT_MODULO\", 0 AS \"COUNT_SUBMODULO\" " +
		            "        FROM " + sesion + " AS s  " +
		            "        INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\")  " +
		            "        INNER JOIN " + clase + " AS cl ON (s.\"OID_CLASE_TEORICA\" = cl.\"OID\")  " +
		            "        INNER JOIN " + submodulo + " AS sm ON (cl.\"OID_SUBMODULO\" = sm.\"OID\")  " +
		            "        INNER JOIN " + modulo + " AS m ON (cl.\"OID_MODULO\" = m.\"OID\")  " +
		            "        WHERE s.\"OID_HORARIO\" = " + oid_horario + "  AND cl.\"ORDEN_TERCIARIO\" > 1 ) AS cl " +
	                "    WHERE cl.\"OID_SUBMODULO\" NOT IN " +
		            "        (SELECT cl.\"OID_SUBMODULO\" " +
		            "        FROM " + clase + " AS cl  " +
		            "        INNER JOIN " + submodulo + " AS sm ON (cl.\"OID_SUBMODULO\" = sm.\"OID\")  " +
		            "        INNER JOIN " + modulo + " AS m ON (cl.\"OID_MODULO\" = m.\"OID\") " +
		            "        WHERE cl.\"OID\" NOT IN (  " +
				    "                SELECT c.\"OID\"  " +
				    "                FROM " + sesion + " AS s  " +
				    "                INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\")  " +
				    "                INNER JOIN " + clase + " AS c ON (s.\"OID_CLASE_TEORICA\" = c.\"OID\")  " +
				    "                WHERE h.\"OID_PROMOCION\" = " + oid_promocion + "  AND c.\"OID_PLAN\" = " + oid_plan + "  AND s.\"ESTADO\" > 1 )  " +
			        "            AND cl.\"OID_PLAN\" = " + oid_plan + "  AND cl.\"ORDEN_TERCIARIO\" = 1 " +
		            "        UNION  " +
		            "        SELECT cl.\"OID_SUBMODULO\" " +
		            "        FROM " + sesion + " AS s  " +
		            "        INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\")  " +
		            "        INNER JOIN " + clase + " AS cl ON (s.\"OID_CLASE_TEORICA\" = cl.\"OID\")  " +
		            "        INNER JOIN " + submodulo + " AS sm ON (cl.\"OID_SUBMODULO\" = sm.\"OID\")  " +
		            "        INNER JOIN " + modulo + " AS m ON (cl.\"OID_MODULO\" = m.\"OID\")  " +
		            "        WHERE s.\"OID_HORARIO\" = " + oid_horario + "  AND cl.\"ORDEN_TERCIARIO\" = 1)) AS cl	 " +
                    "UNION " +
                    "SELECT cl.*, 1 AS \"ORDEN_IMPARTIDA\" " +
                    "FROM( " +
	                "    SELECT cl.*  " +
	                "    FROM( " +
		            "        SELECT cl.* , 1 AS \"ESTADO\", sm.\"CODIGO\" AS \"SUBMODULO\", m.\"TEXTO\" AS \"MODULO\", m.\"NUMERO_ORDEN\" AS \"NUMERO_ORDEN\", " +
                    "               sm.\"CODIGO_ORDEN\" AS \"CODIGO_ORDEN\", '' AS \"INSTRUCTOR\", '1999-01-08' AS \"FECHA\", '00:00:00' AS \"HORA\", " +
                    "               0 AS \"COUNT_MODULO\", 0 AS \"COUNT_SUBMODULO\"  " +
		            "        FROM " + clase + " AS cl  " +
		            "        INNER JOIN " + submodulo + " AS sm ON (cl.\"OID_SUBMODULO\" = sm.\"OID\")  " +
		            "        INNER JOIN " + modulo + " AS m ON (cl.\"OID_MODULO\" = m.\"OID\") " +
		            "        WHERE cl.\"OID\" NOT IN (  " +
				    "                SELECT c.\"OID\"  " +
				    "                FROM " + sesion + " AS s  " +
				    "                INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\")  " +
				    "                INNER JOIN " + clase + " AS c ON (s.\"OID_CLASE_TEORICA\" = c.\"OID\")  " +
				    "                WHERE h.\"OID_PROMOCION\" = " + oid_promocion + "  AND c.\"OID_PLAN\" = " + oid_plan + "  AND s.\"ESTADO\" > 1 )  " +
			        "            AND cl.\"OID_PLAN\" = " + oid_plan + "  " +
		            "        UNION  " +
                    "        SELECT cl.*, s.\"ESTADO\" AS \"ESTADO\", sm.\"CODIGO\" AS \"SUBMODULO\", m.\"TEXTO\" AS \"MODULO\", m.\"NUMERO_ORDEN\" AS \"NUMERO_ORDEN\", " +
                    "               sm.\"CODIGO_ORDEN\" AS \"CODIGO_ORDEN\", '' AS \"INSTRUCTOR\", '1999-01-08' AS \"FECHA\", '00:00:00' AS \"HORA\", " +
                    "               0 AS \"COUNT_MODULO\", 0 AS \"COUNT_SUBMODULO\" " +
		            "        FROM " + sesion + " AS s  " +
		            "        INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\")  " +
		            "        INNER JOIN " + clase + " AS cl ON (s.\"OID_CLASE_TEORICA\" = cl.\"OID\")  " +
		            "        INNER JOIN " + submodulo + " AS sm ON (cl.\"OID_SUBMODULO\" = sm.\"OID\")  " +
		            "        INNER JOIN " + modulo + " AS m ON (cl.\"OID_MODULO\" = m.\"OID\")  " +
		            "        WHERE s.\"OID_HORARIO\" = " + oid_horario + " ) AS cl " +
	                "    WHERE cl.\"OID_SUBMODULO\" IN " +
		            "        (SELECT cl.\"OID_SUBMODULO\" " +
		            "        FROM " + clase + " AS cl  " +
		            "        INNER JOIN " + submodulo + " AS sm ON (cl.\"OID_SUBMODULO\" = sm.\"OID\")  " +
		            "        INNER JOIN " + modulo + " AS m ON (cl.\"OID_MODULO\" = m.\"OID\") " +
		            "        WHERE cl.\"OID\" NOT IN (  " +
				    "                SELECT c.\"OID\"  " +
				    "                FROM " + sesion + " AS s  " +
				    "                INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\")  " +
				    "                INNER JOIN " + clase + " AS c ON (s.\"OID_CLASE_TEORICA\" = c.\"OID\")  " +
				    "                WHERE h.\"OID_PROMOCION\" = " + oid_promocion + "  AND c.\"OID_PLAN\" = " + oid_plan + "  AND s.\"ESTADO\" > 1 )  " +
			        "            AND cl.\"OID_PLAN\" = " + oid_plan + "  AND cl.\"ORDEN_TERCIARIO\" = 1 " +
		            "        UNION  " +
		            "        SELECT cl.\"OID_SUBMODULO\" " +
		            "        FROM " + sesion + " AS s  " +
		            "        INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\")  " +
		            "        INNER JOIN " + clase + " AS cl ON (s.\"OID_CLASE_TEORICA\" = cl.\"OID\")  " +
		            "        INNER JOIN " + submodulo + " AS sm ON (cl.\"OID_SUBMODULO\" = sm.\"OID\")  " +
		            "        INNER JOIN " + modulo + " AS m ON (cl.\"OID_MODULO\" = m.\"OID\")  " +
		            "        WHERE s.\"OID_HORARIO\" = " + oid_horario + "  AND cl.\"ORDEN_TERCIARIO\" = 1)) AS cl	 " +
                    "ORDER BY \"ORDEN_IMPARTIDA\", \"ORDEN_PRIMARIO\", \"ORDEN_SECUNDARIO\", \"ORDEN_TERCIARIO\", \"NUMERO_ORDEN\", \"CODIGO_ORDEN\";";
            
            return query;
        }


         public static string SELECT_CLASES_TEORICAS_PROGRAMADAS(long oid_plan,
                                                                     long oid_promocion)
         {
             string clase = nHManager.Instance.GetSQLTable(typeof(ClaseTeoricaRecord));
             string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
             string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
             string horario = nHManager.Instance.GetSQLTable(typeof(HorarioRecord));
             string sesion = nHManager.Instance.GetSQLTable(typeof(SesionRecord));
             string instructor = nHManager.Instance.GetSQLTable(typeof(InstructorRecord));
             string submodulo_instructor = nHManager.Instance.GetSQLTable(typeof(Submodulo_InstructorRecord));
             string clase_extra = nHManager.Instance.GetSQLTable(typeof(ClaseExtraRecord));

             bool mostrar_autorizados = moleQule.Library.Instruction.ModulePrincipal.GetMostrarInstructoresAutorizadosSetting();

             string query1;

             query1 = "SELECT DISTINCT cl.\"OID\", cl.\"OID_MODULO\", cl.\"OID_SUBMODULO\", cl.\"ORDEN_PRIMARIO\"," +
                     "   cl.\"ORDEN_SECUNDARIO\", cl.\"TITULO\", cl.\"OBSERVACIONES\", cl.\"ORDEN_TERCIARIO\", cl.\"ALIAS\"," +
                     "   cl.\"TOTAL_CLASES\", cl.\"DURACION\", " +
                     "       sm.\"CODIGO\" AS \"SUBMODULO\"," +
                     "       m.\"TEXTO\" AS \"MODULO\"," +
                     "       m.\"NUMERO_ORDEN\" AS \"NUMERO_ORDEN\"," +
                     "       sm.\"CODIGO_ORDEN\" AS \"CODIGO_ORDEN\"," +
                     "       s.\"FECHA\" AS \"FECHA\"," +
                     "       s.\"HORA\" AS \"HORA\"," +
                     "       s.\"ESTADO\" AS \"ESTADO\",";
             if (mostrar_autorizados)
                 query1 += "       ia.\"NOMBRE\" AS \"INSTRUCTOR\"";
             else
                 query1 += "       i.\"NOMBRE\" AS \"INSTRUCTOR\"";
             query1 += " FROM " + clase + " AS cl " +
                         "INNER JOIN " + submodulo + " AS sm ON (cl.\"OID_SUBMODULO\" = sm.\"OID\") " +
                         "INNER JOIN " + modulo + " AS m ON (cl.\"OID_MODULO\" = m.\"OID\") " +
                         "INNER JOIN " + sesion + " AS s ON (s.\"OID_CLASE_TEORICA\" = cl.\"OID\") " +
                         "INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\") " +
                         "INNER JOIN " + instructor + " AS i ON (s.\"OID_PROFESOR\" = i.\"OID\") ";
             if (mostrar_autorizados)
                 query1 += "INNER JOIN " + submodulo_instructor + " AS si ON (si.\"OID_INSTRUCTOR\" = i.\"OID\" AND si.\"OID_SUBMODULO\" = sm.\"OID\" AND s.\"FECHA\" BETWEEN COALESCE(si.\"FECHA_INICIO\", '01-01-0001') AND COALESCE(si.\"FECHA_FIN\", '12-31-2999')) " +
                 "INNER JOIN " + instructor + " AS ia ON (si.\"OID_INSTRUCTOR_SUPLENTE\" = ia.\"OID\") ";
             query1 += "WHERE h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " " +
                        "AND cl.\"OID_PLAN\" = " + oid_plan.ToString() + " " +
                        "AND s.\"ESTADO\" = 3 " +
                     "UNION " +
                     "SELECT DISTINCT cl.\"OID\", cl.\"OID_MODULO\", cl.\"OID_SUBMODULO\", cl.\"ORDEN_PRIMARIO\"," +
                     "   cl.\"ORDEN_SECUNDARIO\", cl.\"TITULO\", cl.\"OBSERVACIONES\", cl.\"ORDEN_TERCIARIO\", cl.\"ALIAS\"," +
                     "   cl.\"TOTAL_CLASES\", cl.\"DURACION\", " +
                     "       sm.\"CODIGO\" AS \"SUBMODULO\"," +
                     "       m.\"TEXTO\" AS \"MODULO\"," +
                     "       m.\"NUMERO_ORDEN\" AS \"NUMERO_ORDEN\"," +
                     "       sm.\"CODIGO_ORDEN\" AS \"CODIGO_ORDEN\"," +
                     "       s.\"FECHA\" AS \"FECHA\"," +
                     "       s.\"HORA\" AS \"HORA\"," +
                     "       s.\"ESTADO\" AS \"ESTADO\"," +
                     "       i.\"NOMBRE\" AS \"INSTRUCTOR\"" +
                     " FROM " + clase + " AS cl " +
                         "INNER JOIN " + submodulo + " AS sm ON (cl.\"OID_SUBMODULO\" = sm.\"OID\") " +
                         "INNER JOIN " + modulo + " AS m ON (cl.\"OID_MODULO\" = m.\"OID\") " +
                         "INNER JOIN " + sesion + " AS s ON (s.\"OID_CLASE_TEORICA\" = cl.\"OID\") " +
                         "INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\") " +
                         "INNER JOIN " + instructor + " AS i ON (s.\"OID_PROFESOR\" = i.\"OID\"";
             if (mostrar_autorizados)
                 query1 += " AND i.\"OID\" NOT IN ( " +
                             "SELECT si.\"OID_INSTRUCTOR\" " +
                             "FROM " + submodulo_instructor + " AS si " +
                             "WHERE si.\"OID_SUBMODULO\" = sm.\"OID\" AND s.\"FECHA\" BETWEEN COALESCE(si.\"FECHA_INICIO\", '01-01-0001') AND COALESCE(si.\"FECHA_FIN\", '12-31-2999')) ";
             query1 += ") " +
                     "WHERE h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " " +
                        "AND cl.\"OID_PLAN\" = " + oid_plan.ToString() + " " +
                        "AND s.\"ESTADO\" = 3 " +
                     "UNION " +
                     "SELECT DISTINCT cl.\"OID\", cl.\"OID_MODULO\", cl.\"OID_SUBMODULO\", 1 AS \"ORDEN_PRIMARIO\"," +
                     "   1 AS \"ORDEN_SECUNDARIO\", cl.\"TITULO\", cl.\"OBSERVACIONES\", 1 AS \"ORDEN_TERCIARIO\", cl.\"ALIAS\"," +
                     "   cl.\"TOTAL_CLASES\", cl.\"ORDEN\" AS \"DURACION\", " +
                     "       sm.\"CODIGO\" AS \"SUBMODULO\"," +
                     "       m.\"TEXTO\" AS \"MODULO\"," +
                     "       m.\"NUMERO_ORDEN\" AS \"NUMERO_ORDEN\"," +
                     "       sm.\"CODIGO_ORDEN\" AS \"CODIGO_ORDEN\"," +
                     "       s.\"FECHA\" AS \"FECHA\"," +
                     "       s.\"HORA\" AS \"HORA\"," +
                     "       s.\"ESTADO\" AS \"ESTADO\",";
             if (mostrar_autorizados)
                 query1 +=
                     "       ia.\"NOMBRE\" AS \"INSTRUCTOR\"";
             else
                 query1 +=
                     "       i.\"NOMBRE\" AS \"INSTRUCTOR\"";
             query1 +=
                     " FROM " + clase_extra + " AS cl " +
                         "INNER JOIN " + submodulo + " AS sm ON (cl.\"OID_SUBMODULO\" = sm.\"OID\") " +
                         "INNER JOIN " + modulo + " AS m ON (cl.\"OID_MODULO\" = m.\"OID\") " +
                         "INNER JOIN " + sesion + " AS s ON (s.\"OID_CLASE_EXTRA\" = cl.\"OID\") " +
                         "INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\") " +
                         "INNER JOIN " + instructor + " AS i ON (s.\"OID_PROFESOR\" = i.\"OID\") ";
             if (mostrar_autorizados)
                 query1 +=
                         "INNER JOIN " + submodulo_instructor + " AS si ON (si.\"OID_INSTRUCTOR\" = i.\"OID\" AND si.\"OID_SUBMODULO\" = sm.\"OID\" AND s.\"FECHA\" BETWEEN COALESCE(si.\"FECHA_INICIO\", '01-01-0001') AND COALESCE(si.\"FECHA_FIN\", '12-31-2999')) " +
                         "INNER JOIN " + instructor + " AS ia ON (si.\"OID_INSTRUCTOR_SUPLENTE\" = ia.\"OID\") ";
             query1 +=
                     "WHERE h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " " +
                        "AND s.\"ESTADO\" = 3 " +
                     "UNION " +
                     "SELECT DISTINCT cl.\"OID\", cl.\"OID_MODULO\", cl.\"OID_SUBMODULO\", 1 AS \"ORDEN_PRIMARIO\"," +
                     "   1 AS \"ORDEN_SECUNDARIO\", cl.\"TITULO\", cl.\"OBSERVACIONES\", 1 AS \"ORDEN_TERCIARIO\", cl.\"ALIAS\"," +
                     "   cl.\"TOTAL_CLASES\", cl.\"ORDEN\" AS \"DURACION\", " +
                     "       sm.\"CODIGO\" AS \"SUBMODULO\"," +
                     "       m.\"TEXTO\" AS \"MODULO\"," +
                     "       m.\"NUMERO_ORDEN\" AS \"NUMERO_ORDEN\"," +
                     "       sm.\"CODIGO_ORDEN\" AS \"CODIGO_ORDEN\"," +
                     "       s.\"FECHA\" AS \"FECHA\"," +
                     "       s.\"HORA\" AS \"HORA\"," +
                     "       s.\"ESTADO\" AS \"ESTADO\"," +
                     "       i.\"NOMBRE\" AS \"INSTRUCTOR\"" +
                     " FROM " + clase_extra + " AS cl " +
                         "INNER JOIN " + submodulo + " AS sm ON (cl.\"OID_SUBMODULO\" = sm.\"OID\") " +
                         "INNER JOIN " + modulo + " AS m ON (cl.\"OID_MODULO\" = m.\"OID\") " +
                         "INNER JOIN " + sesion + " AS s ON (s.\"OID_CLASE_EXTRA\" = cl.\"OID\") " +
                         "INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\") " +
                         "INNER JOIN " + instructor + " AS i ON (s.\"OID_PROFESOR\" = i.\"OID\"";
             if (mostrar_autorizados)
                 query1 += " AND i.\"OID\" NOT IN ( " +
                             "SELECT si.\"OID_INSTRUCTOR\" " +
                             "FROM " + submodulo_instructor + " AS si " +
                             "WHERE si.\"OID_SUBMODULO\" = sm.\"OID\" AND s.\"FECHA\" BETWEEN COALESCE(si.\"FECHA_INICIO\", '01-01-0001') AND COALESCE(si.\"FECHA_FIN\", '12-31-2999'))";
             query1 += ") " +
                     "WHERE h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " " +
                        "AND s.\"ESTADO\" = 3 " +
                    "ORDER BY \"FECHA\", \"HORA\"";



             string query = "SELECT CONTADORES.\"COUNT_MODULO\", CONTADORES.\"COUNT_SUBMODULO\", CONSULTA.* " +
                             "FROM (SELECT C1.\"OID_MODULO\", \"OID_SUBMODULO\", \"COUNT_MODULO\", \"COUNT_SUBMODULO\" " +
                             "   FROM (SELECT Q1.\"OID_MODULO\", COUNT(Q1.\"OID_MODULO\") AS \"COUNT_MODULO\" " +
                             "       FROM ( SELECT DISTINCT cl.\"OID\", cl.\"OID_MODULO\" " +
                             "           FROM " + clase + " AS cl " +
                             "               INNER JOIN " + sesion + "  AS s ON (s.\"OID_CLASE_TEORICA\" = cl.\"OID\") " +
                             "               INNER JOIN " + horario + " AS h ON (s.\"OID_HORARIO\" = h.\"OID\") " +
                             "           WHERE h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " AND cl.\"OID_PLAN\" = " + oid_plan.ToString() + " AND s.\"ESTADO\" = 3 " +
                             "           UNION " +
                             "           SELECT DISTINCT cl.\"OID\", cl.\"OID_MODULO\" " +
                             "           FROM " + clase_extra + " AS cl " +
                             "               INNER JOIN " + sesion + "  AS s ON (s.\"OID_CLASE_EXTRA\" = cl.\"OID\") " +
                             "               INNER JOIN " + horario + "  AS h ON (s.\"OID_HORARIO\" = h.\"OID\") " +
                             "           WHERE h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + "  AND s.\"ESTADO\" = 3) AS Q1 " +
                             "           GROUP BY Q1.\"OID_MODULO\") AS C1, " +
                             "           (SELECT Q2.\"OID_MODULO\", Q2.\"OID_SUBMODULO\", COUNT(Q2.\"OID_SUBMODULO\") AS \"COUNT_SUBMODULO\" " +
                             "           FROM (SELECT DISTINCT cl.\"OID\", cl.\"OID_MODULO\", cl.\"OID_SUBMODULO\" " +
                             "               FROM " + clase + " AS cl " +
                             "                   INNER JOIN " + sesion + "  AS s ON (s.\"OID_CLASE_TEORICA\" = cl.\"OID\") " +
                             "                   INNER JOIN " + horario + "  AS h ON (s.\"OID_HORARIO\" = h.\"OID\") " +
                             "               WHERE h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + "  AND cl.\"OID_PLAN\" = " + oid_plan.ToString() + "  AND s.\"ESTADO\" = 3 " +
                             "               UNION " +
                             "               SELECT DISTINCT cl.\"OID\", cl.\"OID_MODULO\", cl.\"OID_SUBMODULO\" " +
                             "               FROM " + clase_extra + " AS cl " +
                             "                   INNER JOIN " + sesion + "  AS s ON (s.\"OID_CLASE_EXTRA\" = cl.\"OID\") " +
                             "                   INNER JOIN " + horario + "  AS h ON (s.\"OID_HORARIO\" = h.\"OID\") " +
                             "               WHERE h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + "  AND s.\"ESTADO\" = 3) AS Q2 " +
                             "       GROUP BY Q2.\"OID_MODULO\", Q2.\"OID_SUBMODULO\") AS C2 " +
                             "   WHERE C1.\"OID_MODULO\" = C2.\"OID_MODULO\") AS CONTADORES, " +
                             "   ( " + query1 + ")AS CONSULTA " +
                             "WHERE CONSULTA.\"OID_SUBMODULO\" = CONTADORES.\"OID_SUBMODULO\";";
             return query;
         }

        public static string SELECT_BY_PLAN(long oid_plan)
        {
            string query;

            query = ClaseTeorica.SELECT(0) +
                    "WHERE CT.\"OID_PLAN\" = " + oid_plan.ToString() + " " +
                    "ORDER BY M.\"NUMERO_ORDEN\", S.\"CODIGO_ORDEN\", CT.\"ORDEN_TERCIARIO\"";

            return query;
        }

        public new static string SELECT()
        {
            string query;

            query = ClaseTeorica.SELECT(0) +
                    "ORDER BY M.\"NUMERO_ORDEN\", S.\"CODIGO_ORDEN\", CT.\"ORDEN_TERCIARIO\"";

            return query;
        }

        public static string SELECT_CLASES_TEORICAS_PLAN(long oid_plan)
        {
            string query;

            query = ClaseTeorica.SELECT(0) +
                    " WHERE CT.\"OID_PLAN\" = " + oid_plan.ToString() +
                    " ORDER BY M.\"NUMERO_ORDEN\", S.\"CODIGO_ORDEN\", CT.\"ORDEN_TERCIARIO\"";

            return query;
        }

        public static string SELECT_CLASES_TEORICAS_PLAN_ORDENADAS(long oid_plan)
        {
            string query;

            query = ClaseTeorica.SELECT(0) +
                    " WHERE CT.\"OID_PLAN\" = " + oid_plan.ToString() +
                    " ORDER BY CT.\"ORDEN_PRIMARIO\", CT.\"ORDEN_SECUNDARIO\", CT.\"ORDEN_TERCIARIO\", M.\"NUMERO_ORDEN\", S.\"CODIGO_ORDEN\"";

            return query;
        }

        #endregion

    }
}

