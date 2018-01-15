using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;

using NHibernate;

namespace moleQule.Library.Instruction
{
	
	/// <summary>
	/// ReadOnly Root Collection of Business Objects With Child Collection
	/// </summary>
    [Serializable()]
    public class FaltaAlumnoList : ReadOnlyListBaseEx<FaltaAlumnoList, FaltaAlumnoInfo>
	{	

		#region Business Methods
			
		#endregion
		 
		#region Factory Methods

        private FaltaAlumnoList() { }

        public static FaltaAlumnoList NewList() { return new FaltaAlumnoList(); }
		
		/// <summary>
		/// Retrieve the complete list from db
		/// </summary>
		/// <param name="get_childs">retrieving the childs</param>
		/// <returns></returns>
		public static FaltaAlumnoList GetListByPromocion(bool childs, long oid_promocion = 0)
		{
            CriteriaEx criteria = Alumno.GetCriteria(Alumno.OpenSession());
			criteria.Childs = childs;
			
			//No criteria. Retrieve all de List
			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = FaltaAlumnoList.SELECT_FALTAS_ALUMNOS(oid_promocion);
			FaltaAlumnoList list = DataPortal.Fetch<FaltaAlumnoList>(criteria);
			
			CloseSession(criteria.SessionCode);
			return list;
		}

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <param name="get_childs">retrieving the childs</param>
        /// <returns></returns>
        public static FaltaAlumnoList GetListByAlumno(bool childs, long oid_alumno)
        {
            CriteriaEx criteria = Alumno.GetCriteria(Alumno.OpenSession());
            criteria.Childs = childs;

            //No criteria. Retrieve all de List
            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = FaltaAlumnoList.SELECT_FALTAS_BY_ALUMNO(oid_alumno);
            FaltaAlumnoList list = DataPortal.Fetch<FaltaAlumnoList>(criteria);

            CloseSession(criteria.SessionCode);
            return list;
        }

		/// <summary>
		/// Default call for GetList(bool get_childs)
		/// </summary>
		/// <returns></returns>
		public static FaltaAlumnoList GetList(long oid_promocion = 0)
		{
			return FaltaAlumnoList.GetListByPromocion(true, oid_promocion);
		}
		
		/// <summary>
		/// Devuelve una lista de todos los elementos
		/// </summary>
		/// <returns>Lista de elementos</returns>
		public static FaltaAlumnoList GetList(CriteriaEx criteria)
		{
			return FaltaAlumnoList.RetrieveList(typeof(FaltaAlumno), AppContext.ActiveSchema.Code, criteria);
		}
		
		/// <summary>
		/// Builds a FaltaAlumnoList from a IList<!--<FaltaAlumnoInfo>-->.
		/// Doesnt retrieve child data from DB.
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public static FaltaAlumnoList GetList(IList<FaltaAlumnoInfo> list)
		{
			FaltaAlumnoList flist = new FaltaAlumnoList();
			
			if (list.Count > 0)
			{
				flist.IsReadOnly = false;
				
				foreach (FaltaAlumnoInfo item in list)
					flist.AddItem(item);
				
				flist.IsReadOnly = true;
			}
			
			return flist;
		}
		
		/// <summary>
		/// Devuelve una lista ordenada de todos los elementos
		/// </summary>
		/// <param name="sortProperty">Campo de ordenación</param>
		/// <param name="sortDirection">Sentido de ordenación</param>
		/// <returns>Lista ordenada de elementos</returns>
		public static SortedBindingList<FaltaAlumnoInfo> GetSortedList (string sortProperty, ListSortDirection sortDirection)
		{
			SortedBindingList<FaltaAlumnoInfo> sortedList = new SortedBindingList<FaltaAlumnoInfo>(GetList());
			
			sortedList.ApplySort(sortProperty, sortDirection);
			return sortedList;
		}
		
		/// <summary>
        /// Devuelve una lista ordenada de todos los elementos y sus hijos
        /// </summary>
        /// <param name="sortProperty">Campo de ordenación</param>
        /// <param name="sortDirection">Sentido de ordenación</param>
        /// <param name="childs">Traer hijos</param>
        /// <returns>Lista ordenada de elementos</returns>
        public static SortedBindingList<FaltaAlumnoInfo> GetSortedList(string sortProperty, ListSortDirection sortDirection, bool childs)
        {
            SortedBindingList<FaltaAlumnoInfo> sortedList = new SortedBindingList<FaltaAlumnoInfo>(GetListByPromocion(childs));

            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }
		
		/// <summary>
        /// Builds a FaltaAlumnoList from a IList<!--<FaltaAlumno>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>FaltaAlumnoList</returns>
        public static FaltaAlumnoList GetList(IList<FaltaAlumno> list)
        {
            FaltaAlumnoList flist = new FaltaAlumnoList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (FaltaAlumno item in list)
                    flist.AddItem(item.GetInfo());

                flist.IsReadOnly = true;
            }

            return flist;
        }
			
		#endregion
		
		#region Data Access
		 
		 	// called to retrieve data from database
			protected override void Fetch(CriteriaEx criteria)
			{
				this.RaiseListChangedEvents = false;
				
				SessionCode = criteria.SessionCode;
				Childs = criteria.Childs;
				
				try
				{
					if (nHMng.UseDirectSQL)
					{
					
						IDataReader reader = nHManager.Instance.SQLNativeSelect(criteria.Query, Session()); 
						
						IsReadOnly = false;
						
						while (reader.Read())
						{
							this.AddItem(FaltaAlumnoInfo.Get(reader, Childs));
						}
						IsReadOnly = true;
					}
					else 
					{
						IList list = criteria.List();
						
						if (list.Count > 0)
						{
							IsReadOnly = false;
							foreach(FaltaAlumno item in list)
								this.AddItem(item.GetInfo(false));
								
							IsReadOnly = true;
						}
					}
				}
				catch (Exception ex)
				{
					iQExceptionHandler.TreatException(ex);
				}
				
				this.RaiseListChangedEvents = true;
			}
			
				
		#endregion

        #region SQL

            private static string SELECT_FALTAS_ALUMNOS(long oid_promocion)
            {
                /*string query = "SELECT a.\"NOMBRE\" AS NOMBRE_ALUMNO, a.\"APELLIDOS\" AS APELLIDO_ALUMNO, a.\"N_EXPEDIENTE\" AS EXP_ALUMNO, " +
                    "a.\"CODIGO\" AS CODIGO_ALUMNO, p.\"SESIONES\" AS SESIONES, p.\"N_HORAS\" AS DURACION, pr.\"NOMBRE\" AS PROMOCION, " +
                    "m.\"TEXTO\" AS MODULO, ct.\"TOTAL_CLASES\" AS TOTAL, sm.\"CODIGO\" AS SUBMODULO, sm.\"CODIGO_ORDEN\" AS ORDEN_SUBMODULO, " +
                    "ct.\"ORDEN_TERCIARIO\" AS ORDEN_CLASE, pl.\"OID\" AS OID_PLAN " +
                    "FROM \"0001\".\"Alumno_Parte\" as ap " +
                    "INNER JOIN \"0001\".\"Alumno\" as a ON (a.\"OID\" = ap.\"OID_ALUMNO\") " +
                    "INNER JOIN \"0001\".\"ParteAsistencia\" as p ON (p.\"OID\" = ap.\"OID_PARTE\") " +
                    "INNER JOIN \"0001\".\"Promocion\" as pr ON (pr.\"OID\" = a.\"OID_PROMOCION\") " +
                    "INNER JOIN \"0001\".\"PlanEstudios\" as pl ON (pl.\"OID\" = pr.\"OID_PLAN\") " +
                    "INNER JOIN \"0001\".\"ClaseTeorica\" as ct ON " +
                    "(cast(substring(p.\"SESIONES\" from 1 for position(' ' in p.\"SESIONES\")) as bigint)  = ct.\"OID\" AND p.\"TIPO\" = 0) " +
                    "INNER JOIN \"0001\".\"Modulo\" as m ON (m.\"OID\" = ct.\"OID_MODULO\") " +
                    "INNER JOIN \"0001\".\"Submodulo\" as sm ON (sm.\"OID\" = ct.\"OID_SUBMODULO\") " +
                    "WHERE ap.\"FALTA\" = 'true' " +
                    "UNION " +
                    "SELECT a.\"NOMBRE\" AS NOMBRE_ALUMNO, a.\"APELLIDOS\" AS APELLIDO_ALUMNO, a.\"N_EXPEDIENTE\" AS EXP_ALUMNO, " +
                    "a.\"CODIGO\" AS CODIGO_ALUMNO, p.\"SESIONES\" AS SESIONES, p.\"N_HORAS\" AS DURACION, pr.\"NOMBRE\" AS PROMOCION, " +
                    "m.\"TEXTO\" AS MODULO, cp.\"TOTAL_CLASES\" AS TOTAL, sm.\"CODIGO\" AS SUBMODULO, sm.\"CODIGO_ORDEN\" AS ORDEN_SUBMODULO, " +
                    "cp.\"ORDEN_TERCIARIO\" AS ORDEN_CLASE, pl.\"OID\" AS OID_PLAN " +
                    "FROM \"0001\".\"Alumno_Parte\" as ap " +
                    "INNER JOIN \"0001\".\"Alumno\" as a ON (a.\"OID\" = ap.\"OID_ALUMNO\") " +
                    "INNER JOIN \"0001\".\"ParteAsistencia\" as p ON (p.\"OID\" = ap.\"OID_PARTE\") " +
                    "INNER JOIN \"0001\".\"Promocion\" as pr ON (pr.\"OID\" = a.\"OID_PROMOCION\") " +
                    "INNER JOIN \"0001\".\"PlanEstudios\" as pl ON (pl.\"OID\" = pr.\"OID_PLAN\") " +
                    "INNER JOIN \"0001\".\"ClasePractica\" as cp ON " +
                    "(cast(substring(p.\"SESIONES\" from 1 for position(' ' in p.\"SESIONES\")) as bigint)  = cp.\"OID\" AND p.\"TIPO\" = 1) " +
                    "INNER JOIN \"0001\".\"Modulo\" as m ON (m.\"OID\" = cp.\"OID_MODULO\") " +
                    "INNER JOIN \"0001\".\"Submodulo\" as sm ON (sm.\"OID\" = cp.\"OID_SUBMODULO\") " +
                    "WHERE ap.\"FALTA\" = 'true' " +
                    "ORDER BY EXP_ALUMNO, ORDEN_SUBMODULO, ORDEN_CLASE; ";
                string query = "SELECT QUERY1.\"OID_PROMOCION\", QUERY1.\"PROMOCION\", \"EXP_ALUMNO\", \"CODIGO_ALUMNO\", \"NOMBRE_ALUMNO\", \"APELLIDO_ALUMNO\", \"MODULO\", SUM(\"DURACION\") AS \"DURACION\", SUM(QUERY1.\"TOTAL\") AS \"TOTAL\", CAST(SUM(\"DURACION\") / SUM(QUERY1.\"TOTAL\") * 100 as numeric(10,2)) AS \"PORC\", \"OID_MODULO\", QUERY1.\"OID_ALUMNO\", " +
                                " \"DURACION_TOTAL\", \"TOTAL_CURSO\", \"PORC_TOTAL\" " +
                                "FROM( " +
                                "   SELECT pr.\"OID\" AS \"OID_PROMOCION\", pr.\"NOMBRE\" AS \"PROMOCION\", a.\"N_EXPEDIENTE\" AS \"EXP_ALUMNO\", a.\"CODIGO\" AS \"CODIGO_ALUMNO\", a.\"NOMBRE\" AS \"NOMBRE_ALUMNO\", a.\"APELLIDOS\" AS \"APELLIDO_ALUMNO\", " +
                                "       m.\"TEXTO\" AS \"MODULO\", m.\"OID\" AS \"OID_MODULO\", a.\"OID\" AS \"OID_ALUMNO\", COUNT(cp.\"OID\") AS \"DURACION\", QUERY2.\"TOTAL\" AS \"TOTAL\" " +
                                "   FROM " +
                                "       ( " +
                                "       SELECT PE.\"OID\" AS \"PLAN2\", MOD.\"TEXTO\" AS \"MODULO2\", COUNT(C.\"OID\") AS \"TOTAL\" " +
                                "       FROM \"0001\".\"PlanEstudios\" AS PE " +
                                "       INNER JOIN \"0001\".\"ClaseTeorica\" AS C ON ( C.\"OID_PLAN\" = PE.\"OID\") " +
                                "       INNER JOIN \"0001\".\"Modulo\" AS MOD ON ( C.\"OID_MODULO\" = MOD.\"OID\") " +
                                "       GROUP BY \"PLAN2\", \"MODULO2\" " +
                                "       ) AS QUERY2, \"0001\".\"Alumno_Parte\" as ap " +
                                "   INNER JOIN \"0001\".\"Alumno\" as a ON (a.\"OID\" = ap.\"OID_ALUMNO\")  " +
                                "   INNER JOIN \"0001\".\"ParteAsistencia\" as p ON (p.\"OID\" = ap.\"OID_PARTE\")  " +
                                "   INNER JOIN \"0001\".\"Horario\" as h ON h.\"OID\" = p.\"OID_HORARIO\"" +
                                "   INNER JOIN \"0001\".\"Alumno_Promocion\" as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\") " +
                                "   INNER JOIN \"0001\".\"Promocion\" as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\")  " +
                                "   INNER JOIN \"0001\".\"PlanEstudios\" as pl ON (pl.\"OID\" = pr.\"OID_PLAN\" AND h.\"OID_PROMOCION\" = pr.\"OID\")  " +
                                "   INNER JOIN \"0001\".\"Clase_Parte\" as cp ON (p.\"OID\" = cp.\"OID_PARTE\")  " +
                                "   INNER JOIN \"0001\".\"ClaseTeorica\" as ct ON  (ct.\"OID\" = cp.\"OID_CLASE\")  " +
                                "   INNER JOIN \"0001\".\"Modulo\" as m ON (m.\"OID\" = ct.\"OID_MODULO\")  " +
                                "   WHERE ap.\"FALTA\" = 'true' AND ap.\"RECUPERADA\" = 'false' AND cp.\"TIPO\" = 1  " +
                                "       AND \"PLAN2\" = pl.\"OID\" AND \"MODULO2\" = m.\"TEXTO\" " +
                                "   GROUP BY pr.\"OID\", \"PROMOCION\", \"EXP_ALUMNO\", \"CODIGO_ALUMNO\", \"NOMBRE_ALUMNO\", \"APELLIDO_ALUMNO\", \"MODULO\", \"TOTAL\", m.\"OID\", a.\"OID\" " +
                                "   UNION " +
                                "   SELECT pr.\"OID\" AS \"OID_PROMOCION\", pr.\"NOMBRE\" AS \"PROMOCION\", a.\"N_EXPEDIENTE\" AS \"EXP_ALUMNO\", a.\"CODIGO\" AS \"CODIGO_ALUMNO\", a.\"NOMBRE\" AS \"NOMBRE_ALUMNO\", a.\"APELLIDOS\" AS \"APELLIDO_ALUMNO\", " +
                                "       m.\"TEXTO\" AS \"MODULO\", m.\"OID\" AS \"OID_MODULO\", a.\"OID\" AS \"OID_ALUMNO\", 0 AS \"DURACION\", QUERY2.\"TOTAL\" AS \"TOTAL\" " +
                                "   FROM " +
                                "       ( " +
                                "       SELECT PE.\"OID\" AS \"PLAN2\", MOD.\"TEXTO\" AS \"MODULO2\", COUNT(C.\"OID\") AS \"TOTAL\" " +
                                "       FROM \"0001\".\"PlanEstudios\" AS PE " +
                                "       INNER JOIN \"0001\".\"ClaseTeorica\" AS C ON ( C.\"OID_PLAN\" = PE.\"OID\") " +
                                "       INNER JOIN \"0001\".\"Modulo\" AS MOD ON ( C.\"OID_MODULO\" = MOD.\"OID\") " +
                                "       GROUP BY \"PLAN2\", \"MODULO2\" " +
                                "       ) AS QUERY2, \"0001\".\"Alumno_Parte\" as ap " +
                                "   INNER JOIN \"0001\".\"Alumno\" as a ON (a.\"OID\" = ap.\"OID_ALUMNO\")  " +
                                "   INNER JOIN \"0001\".\"ParteAsistencia\" as p ON (p.\"OID\" = ap.\"OID_PARTE\")  " +
                                "   INNER JOIN \"0001\".\"Horario\" as h ON h.\"OID\" = p.\"OID_HORARIO\"" +
                                "   INNER JOIN \"0001\".\"Alumno_Promocion\" as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\") " +
                                "   INNER JOIN \"0001\".\"Promocion\" as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\")  " +
                                "   INNER JOIN \"0001\".\"PlanEstudios\" as pl ON (pl.\"OID\" = pr.\"OID_PLAN\" AND h.\"OID_PROMOCION\" = pr.\"OID\")  " +
                                "   INNER JOIN \"0001\".\"Clase_Parte\" as cp ON (p.\"OID\" = cp.\"OID_PARTE\")  " +
                                "   INNER JOIN \"0001\".\"ClaseTeorica\" as ct ON  (ct.\"OID\" = cp.\"OID_CLASE\")  " +
                                "   INNER JOIN \"0001\".\"Modulo\" as m ON (m.\"OID\" = ct.\"OID_MODULO\")  " +
                                "   WHERE ap.\"OID\" NOT IN ( SELECT \"OID\" FROM \"0001\".\"Alumno_Parte\" WHERE \"FALTA\" = 'true' AND \"RECUPERADA\" = 'false') AND cp.\"TIPO\" = 1  " +
                                "       AND \"PLAN2\" = pl.\"OID\" AND \"MODULO2\" = m.\"TEXTO\" " +
                                "   GROUP BY pr.\"OID\", \"PROMOCION\", \"EXP_ALUMNO\", \"CODIGO_ALUMNO\", \"NOMBRE_ALUMNO\", \"APELLIDO_ALUMNO\", \"MODULO\", \"TOTAL\", m.\"OID\", a.\"OID\" " +
                                "   UNION " +
                                "   SELECT pr.\"OID\" AS \"OID_PROMOCION\", pr.\"NOMBRE\" AS \"PROMOCION\", a.\"N_EXPEDIENTE\" AS \"EXP_ALUMNO\", a.\"CODIGO\" AS \"CODIGO_ALUMNO\", a.\"NOMBRE\" AS \"NOMBRE_ALUMNO\", a.\"APELLIDOS\" AS \"APELLIDO_ALUMNO\", " +
                                "       m.\"TEXTO\" AS \"MODULO\", m.\"OID\" AS \"OID_MODULO\", a.\"OID\" AS \"OID_ALUMNO\", COUNT(cp.\"OID\") AS \"DURACION\", QUERY2.\"TOTAL\" AS \"TOTAL\" " +
                                "   FROM " +
                                "       ( " +
                                "       SELECT PE.\"OID\" AS \"PLAN2\", MOD.\"TEXTO\" AS \"MODULO2\", COUNT(C.\"OID\") AS \"TOTAL\" " +
                                "       FROM \"0001\".\"PlanExtra\" AS PE " +
                                "       INNER JOIN \"0001\".\"ClaseExtra\" AS C ON ( C.\"OID_PLAN\" = PE.\"OID\") " +
                                "       INNER JOIN \"0001\".\"Modulo\" AS MOD ON ( C.\"OID_MODULO\" = MOD.\"OID\") " +
                                "       GROUP BY \"PLAN2\", \"MODULO2\" " +
                                "       ) AS QUERY2, \"0001\".\"Alumno_Parte\" as ap " +
                                "   INNER JOIN \"0001\".\"Alumno\" as a ON (a.\"OID\" = ap.\"OID_ALUMNO\")  " +
                                "   INNER JOIN \"0001\".\"ParteAsistencia\" as p ON (p.\"OID\" = ap.\"OID_PARTE\")  " +
                                "   INNER JOIN \"0001\".\"Horario\" as h ON h.\"OID\" = p.\"OID_HORARIO\"" +
                                "   INNER JOIN \"0001\".\"Alumno_Promocion\" as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\") " +
                                "   INNER JOIN \"0001\".\"Promocion\" as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\" AND h.\"OID_PROMOCION\" = pr.\"OID\")  " +
                                "   INNER JOIN \"0001\".\"PlanExtra\" as pl ON (pl.\"OID\" = pr.\"OID_PLAN_EXTRA\")  " +
                                "   INNER JOIN \"0001\".\"Clase_Parte\" as cp ON (p.\"OID\" = cp.\"OID_PARTE\")  " +
                                "   INNER JOIN \"0001\".\"ClaseExtra\" as ct ON  (ct.\"OID\" = cp.\"OID_CLASE\")  " +
                                "   INNER JOIN \"0001\".\"Modulo\" as m ON (m.\"OID\" = ct.\"OID_MODULO\")  " +
                                "   WHERE ap.\"FALTA\" = 'true' AND ap.\"RECUPERADA\" = 'false' AND cp.\"TIPO\" = 3  " +
                                "       AND \"PLAN2\" = pl.\"OID\" AND \"MODULO2\" = m.\"TEXTO\" " +
                                "   GROUP BY pr.\"OID\", \"PROMOCION\", \"EXP_ALUMNO\", \"CODIGO_ALUMNO\", \"NOMBRE_ALUMNO\", \"APELLIDO_ALUMNO\", \"MODULO\", \"TOTAL\", m.\"OID\", a.\"OID\" " +
                                "   UNION " +
                                "   SELECT pr.\"OID\" AS \"OID_PROMOCION\", pr.\"NOMBRE\" AS \"PROMOCION\", a.\"N_EXPEDIENTE\" AS \"EXP_ALUMNO\", a.\"CODIGO\" AS \"CODIGO_ALUMNO\", a.\"NOMBRE\" AS \"NOMBRE_ALUMNO\", a.\"APELLIDOS\" AS \"APELLIDO_ALUMNO\", " +
                                "       m.\"TEXTO\" AS \"MODULO\", m.\"OID\" AS \"OID_MODULO\", a.\"OID\" AS \"OID_ALUMNO\", 0 AS \"DURACION\", QUERY2.\"TOTAL\" AS \"TOTAL\" " +
                                "   FROM " +
                                "       ( " +
                                "       SELECT PE.\"OID\" AS \"PLAN2\", MOD.\"TEXTO\" AS \"MODULO2\", COUNT(C.\"OID\") AS \"TOTAL\" " +
                                "       FROM \"0001\".\"PlanExtra\" AS PE " +
                                "       INNER JOIN \"0001\".\"ClaseExtra\" AS C ON ( C.\"OID_PLAN\" = PE.\"OID\") " +
                                "       INNER JOIN \"0001\".\"Modulo\" AS MOD ON ( C.\"OID_MODULO\" = MOD.\"OID\") " +
                                "       GROUP BY \"PLAN2\", \"MODULO2\" " +
                                "       ) AS QUERY2, \"0001\".\"Alumno_Parte\" as ap " +
                                "   INNER JOIN \"0001\".\"Alumno\" as a ON (a.\"OID\" = ap.\"OID_ALUMNO\")  " +
                                "   INNER JOIN \"0001\".\"ParteAsistencia\" as p ON (p.\"OID\" = ap.\"OID_PARTE\")  " +
                                "   INNER JOIN \"0001\".\"Horario\" as h ON h.\"OID\" = p.\"OID_HORARIO\"" +
                                "   INNER JOIN \"0001\".\"Alumno_Promocion\" as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\") " +
                                "   INNER JOIN \"0001\".\"Promocion\" as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\" AND h.\"OID_PROMOCION\" = pr.\"OID\")  " +
                                "   INNER JOIN \"0001\".\"PlanExtra\" as pl ON (pl.\"OID\" = pr.\"OID_PLAN_EXTRA\")  " +
                                "   INNER JOIN \"0001\".\"Clase_Parte\" as cp ON (p.\"OID\" = cp.\"OID_PARTE\")  " +
                                "   INNER JOIN \"0001\".\"ClaseExtra\" as ct ON  (ct.\"OID\" = cp.\"OID_CLASE\")  " +
                                "   INNER JOIN \"0001\".\"Modulo\" as m ON (m.\"OID\" = ct.\"OID_MODULO\")  " +
                                "   WHERE ap.\"OID\" NOT IN ( SELECT \"OID\" FROM \"0001\".\"Alumno_Parte\" WHERE \"FALTA\" = 'true' AND \"RECUPERADA\" = 'false') AND cp.\"TIPO\" = 3  " +
                                "       AND \"PLAN2\" = pl.\"OID\" AND \"MODULO2\" = m.\"TEXTO\" " +
                                "   GROUP BY pr.\"OID\", \"PROMOCION\", \"EXP_ALUMNO\", \"CODIGO_ALUMNO\", \"NOMBRE_ALUMNO\", \"APELLIDO_ALUMNO\", \"MODULO\", \"TOTAL\", m.\"OID\", a.\"OID\" " +

                                "   ) AS QUERY1 " +
                                "INNER JOIN (" +
                                "   SELECT \"OID_ALUMNO\", \"PROMOCION\", \"DURACION\" AS \"DURACION_TOTAL\", \"TOTAL\" AS \"TOTAL_CURSO\", " +
                                "       CAST(\"DURACION\" / \"TOTAL\" * 100 as numeric(10,2)) AS \"PORC_TOTAL\" " +
                                "   FROM(" +
                                "       SELECT \"PROMOCION\", SUM(\"DURACION\") AS \"DURACION\", SUM(\"TOTAL\") AS \"TOTAL\", " +
		                        "           CAST(SUM(\"DURACION\") / SUM(\"TOTAL\") * 100 as numeric(10,2)) AS \"PORC\", \"OID_ALUMNO\" " + 
	                            "       FROM(  " +
		                        "           SELECT pr.\"NOMBRE\" AS \"PROMOCION\", a.\"OID\" AS \"OID_ALUMNO\",  " +
			                    "               COUNT(cp.\"OID\") AS \"DURACION\", QUERY2.\"TOTAL\" AS \"TOTAL\"  " +
		                        "           FROM (  " +
			                    "               SELECT PE.\"OID\" AS \"PLAN2\", COUNT(C.\"OID\") AS \"TOTAL\"  " +
			                    "               FROM \"0001\".\"PlanEstudios\" AS PE  " +
			                    "               INNER JOIN \"0001\".\"ClaseTeorica\" AS C ON ( C.\"OID_PLAN\" = PE.\"OID\")  " +
			                    "               GROUP BY \"PLAN2\") AS QUERY2, \"0001\".\"Alumno_Parte\" as ap  " +
		                        "           INNER JOIN \"0001\".\"Alumno\" as a ON (a.\"OID\" = ap.\"OID_ALUMNO\")   " +
                                "           INNER JOIN \"0001\".\"ParteAsistencia\" as p ON (p.\"OID\" = ap.\"OID_PARTE\")   " +
                                "           INNER JOIN \"0001\".\"Horario\" as h ON h.\"OID\" = p.\"OID_HORARIO\"" +
		                        "           INNER JOIN \"0001\".\"Alumno_Promocion\" as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\")  " +
                                "           INNER JOIN \"0001\".\"Promocion\" as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\" AND h.\"OID_PROMOCION\" = pr.\"OID\")   " +
		                        "           INNER JOIN \"0001\".\"PlanEstudios\" as pl ON (pl.\"OID\" = pr.\"OID_PLAN\")   " +
		                        "           INNER JOIN \"0001\".\"Clase_Parte\" as cp ON (p.\"OID\" = cp.\"OID_PARTE\")   " +
		                        "           INNER JOIN \"0001\".\"ClaseTeorica\" as ct ON  (ct.\"OID\" = cp.\"OID_CLASE\")   " +
                                "           WHERE ap.\"FALTA\" = 'true' AND ap.\"RECUPERADA\" = 'false' AND cp.\"TIPO\" = 1  AND \"PLAN2\" = pl.\"OID\" " +
		                        "           GROUP BY \"PROMOCION\", \"TOTAL\", a.\"OID\"  " +
                                "           UNION  " +
                                "           SELECT pr.\"NOMBRE\" AS \"PROMOCION\", a.\"OID\" AS \"OID_ALUMNO\",  " +
                                "               0 AS \"DURACION\", QUERY2.\"TOTAL\" AS \"TOTAL\"  " +
                                "           FROM (  " +
                                "               SELECT PE.\"OID\" AS \"PLAN2\", COUNT(C.\"OID\") AS \"TOTAL\"  " +
                                "               FROM \"0001\".\"PlanEstudios\" AS PE  " +
                                "               INNER JOIN \"0001\".\"ClaseTeorica\" AS C ON ( C.\"OID_PLAN\" = PE.\"OID\")  " +
                                "               GROUP BY \"PLAN2\") AS QUERY2, \"0001\".\"Alumno_Parte\" as ap  " +
                                "           INNER JOIN \"0001\".\"Alumno\" as a ON (a.\"OID\" = ap.\"OID_ALUMNO\")   " +
                                "           INNER JOIN \"0001\".\"ParteAsistencia\" as p ON (p.\"OID\" = ap.\"OID_PARTE\")   " +
                                "           INNER JOIN \"0001\".\"Horario\" as h ON h.\"OID\" = p.\"OID_HORARIO\"" +
                                "           INNER JOIN \"0001\".\"Alumno_Promocion\" as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\")  " +
                                "           INNER JOIN \"0001\".\"Promocion\" as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\" AND h.\"OID_PROMOCION\" = pr.\"OID\")   " +
                                "           INNER JOIN \"0001\".\"PlanEstudios\" as pl ON (pl.\"OID\" = pr.\"OID_PLAN\")   " +
                                "           INNER JOIN \"0001\".\"Clase_Parte\" as cp ON (p.\"OID\" = cp.\"OID_PARTE\")   " +
                                "           INNER JOIN \"0001\".\"ClaseTeorica\" as ct ON  (ct.\"OID\" = cp.\"OID_CLASE\")   " +
                                "           WHERE ap.\"OID\" NOT IN ( SELECT \"OID\" FROM \"0001\".\"Alumno_Parte\" WHERE \"FALTA\" = 'true' AND \"RECUPERADA\" = 'false') AND cp.\"TIPO\" = 1  AND \"PLAN2\" = pl.\"OID\" " +
                                "           GROUP BY \"PROMOCION\", \"TOTAL\", a.\"OID\"  " +
                                "           UNION  " +
		                        "           SELECT pr.\"NOMBRE\" AS \"PROMOCION\", a.\"OID\" AS \"OID_ALUMNO\", COUNT(cp.\"OID\") AS \"DURACION\",  " +
			                    "               QUERY2.\"TOTAL\" AS \"TOTAL\"  " +
		                        "           FROM (  " +
			                    "               SELECT PE.\"OID\" AS \"PLAN2\", COUNT(C.\"OID\") AS \"TOTAL\"  " +
			                    "               FROM \"0001\".\"PlanExtra\" AS PE  " +
			                    "               INNER JOIN \"0001\".\"ClaseExtra\" AS C ON ( C.\"OID_PLAN\" = PE.\"OID\")  " +
			                    "               GROUP BY \"PLAN2\") AS QUERY2, \"0001\".\"Alumno_Parte\" as ap  " +
		                        "           INNER JOIN \"0001\".\"Alumno\" as a ON (a.\"OID\" = ap.\"OID_ALUMNO\")   " +
		                        "           INNER JOIN \"0001\".\"ParteAsistencia\" as p ON (p.\"OID\" = ap.\"OID_PARTE\")   " +
                                "           INNER JOIN \"0001\".\"Horario\" as h ON h.\"OID\" = p.\"OID_HORARIO\"" +
		                        "           INNER JOIN \"0001\".\"Alumno_Promocion\" as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\")  " +
		                        "           INNER JOIN \"0001\".\"Promocion\" as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\" AND h.\"OID_PROMOCION\" = pr.\"OID\")   " +
		                        "           INNER JOIN \"0001\".\"PlanExtra\" as pl ON (pl.\"OID\" = pr.\"OID_PLAN_EXTRA\")   " +
		                        "           INNER JOIN \"0001\".\"Clase_Parte\" as cp ON (p.\"OID\" = cp.\"OID_PARTE\")   " +
		                        "           INNER JOIN \"0001\".\"ClaseExtra\" as ct ON  (ct.\"OID\" = cp.\"OID_CLASE\")   " +
		                        "           WHERE ap.\"FALTA\" = 'true' AND ap.\"RECUPERADA\" = 'false' AND cp.\"TIPO\" = 3  AND \"PLAN2\" = pl.\"OID\" " +
		                        "           GROUP BY \"PROMOCION\", \"TOTAL\", a.\"OID\" " +
                                "           UNION  " +
		                        "           SELECT pr.\"NOMBRE\" AS \"PROMOCION\", a.\"OID\" AS \"OID_ALUMNO\", 0 AS \"DURACION\",  " +
			                    "               QUERY2.\"TOTAL\" AS \"TOTAL\"  " +
		                        "           FROM (  " +
			                    "               SELECT PE.\"OID\" AS \"PLAN2\", COUNT(C.\"OID\") AS \"TOTAL\"  " +
			                    "               FROM \"0001\".\"PlanExtra\" AS PE  " +
			                    "               INNER JOIN \"0001\".\"ClaseExtra\" AS C ON ( C.\"OID_PLAN\" = PE.\"OID\")  " +
			                    "               GROUP BY \"PLAN2\") AS QUERY2, \"0001\".\"Alumno_Parte\" as ap  " +
		                        "           INNER JOIN \"0001\".\"Alumno\" as a ON (a.\"OID\" = ap.\"OID_ALUMNO\")   " +
		                        "           INNER JOIN \"0001\".\"ParteAsistencia\" as p ON (p.\"OID\" = ap.\"OID_PARTE\")   " +
                                "           INNER JOIN \"0001\".\"Horario\" as h ON h.\"OID\" = p.\"OID_HORARIO\"" +
		                        "           INNER JOIN \"0001\".\"Alumno_Promocion\" as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\")  " +
		                        "           INNER JOIN \"0001\".\"Promocion\" as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\" AND h.\"OID_PROMOCION\" = pr.\"OID\")   " +
		                        "           INNER JOIN \"0001\".\"PlanExtra\" as pl ON (pl.\"OID\" = pr.\"OID_PLAN_EXTRA\")   " +
		                        "           INNER JOIN \"0001\".\"Clase_Parte\" as cp ON (p.\"OID\" = cp.\"OID_PARTE\")   " +
		                        "           INNER JOIN \"0001\".\"ClaseExtra\" as ct ON  (ct.\"OID\" = cp.\"OID_CLASE\")   " +
                                "           WHERE ap.\"OID\" NOT IN ( SELECT \"OID\" FROM \"0001\".\"Alumno_Parte\" WHERE \"FALTA\" = 'true' AND \"RECUPERADA\" = 'false') AND cp.\"TIPO\" = 3  AND \"PLAN2\" = pl.\"OID\" " +
		                        "           GROUP BY \"PROMOCION\", \"TOTAL\", a.\"OID\" ) AS QUERY1  " +
	                            "       GROUP BY \"PROMOCION\", \"OID_ALUMNO\" ) AS SUPER_QUERY " +
                                "   GROUP BY \"PROMOCION\", \"OID_ALUMNO\", \"DURACION_TOTAL\", \"TOTAL_CURSO\" " +
                                "   ORDER BY \"PROMOCION\") AS SUPER_QUERY ON (SUPER_QUERY.\"OID_ALUMNO\" = QUERY1.\"OID_ALUMNO\" AND SUPER_QUERY.\"PROMOCION\" = QUERY1.\"PROMOCION\") " +                        
                                "GROUP BY QUERY1.\"OID_PROMOCION\", QUERY1.\"PROMOCION\", \"EXP_ALUMNO\", \"CODIGO_ALUMNO\", \"NOMBRE_ALUMNO\", \"APELLIDO_ALUMNO\", \"MODULO\", \"OID_MODULO\", QUERY1.\"OID_ALUMNO\", \"DURACION_TOTAL\", \"TOTAL_CURSO\", \"PORC_TOTAL\" " +
                                "ORDER BY QUERY1.\"PROMOCION\", \"EXP_ALUMNO\", \"MODULO\";";*/

                string pe = nHManager.Instance.GetSQLTable(typeof(PlanEstudiosRecord));
                string ct = nHManager.Instance.GetSQLTable(typeof(ClaseTeoricaRecord));
                string mod = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
                string pa = nHManager.Instance.GetSQLTable(typeof(ParteAsistenciaRecord));
                string cp = nHManager.Instance.GetSQLTable(typeof(Clase_ParteRecord));
                string ap = nHManager.Instance.GetSQLTable(typeof(AlumnoParteRecord));
                string al = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));
                string apr = nHManager.Instance.GetSQLTable(typeof(AlumnoPromocionRecord));
                string h = nHManager.Instance.GetSQLTable(typeof(HorarioRecord));
                string pr = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));

                /*string query = @"SELECT QUERY1.""OID_PROMOCION""
	                                , QUERY1.""PROMOCION""
	                                , ""EXP_ALUMNO""
	                                , ""CODIGO_ALUMNO""
	                                , ""NOMBRE_ALUMNO""
	                                , ""APELLIDO_ALUMNO""
	                                , ""MODULO""
	                                , SUM(""DURACION"") AS ""DURACION""
	                                , SUM(QUERY1.""TOTAL"") AS ""TOTAL""
	                                , CAST(SUM(""DURACION"") / SUM(QUERY1.""TOTAL"") * 100 as numeric(10,2)) AS ""PORC""
	                                , ""OID_MODULO""
	                                , QUERY1.""OID_ALUMNO""
	                                , ""DURACION_TOTAL""
	                                , ""TOTAL_CURSO""
	                                , ""PORC_TOTAL"" 
                                FROM(   SELECT pr.""OID"" AS ""OID_PROMOCION""
		                                    , pr.""NOMBRE"" AS ""PROMOCION""
		                                    , a.""N_EXPEDIENTE"" AS ""EXP_ALUMNO""
		                                    , a.""CODIGO"" AS ""CODIGO_ALUMNO""
		                                    , a.""NOMBRE"" AS ""NOMBRE_ALUMNO""
		                                    , a.""APELLIDOS"" AS ""APELLIDO_ALUMNO""
		                                    , m.""TEXTO"" AS ""MODULO""
		                                    , m.""OID"" AS ""OID_MODULO""
		                                    , a.""OID"" AS ""OID_ALUMNO""
		                                    , COUNT(cp.""OID"") AS ""DURACION""
		                                    , QUERY2.""TOTAL"" AS ""TOTAL""    
	                                    FROM (	SELECT PE.""OID"" AS ""PLAN2""
			                                        , MOD.""TEXTO"" AS ""MODULO2""
			                                        , COUNT(C.""OID"") AS ""TOTAL""        
		                                        FROM " + pe + @" AS PE        
		                                        INNER JOIN " + ct + @" AS C ON ( C.""OID_PLAN"" = PE.""OID"")        
		                                        INNER JOIN " + mod + @" AS MOD ON ( C.""OID_MODULO"" = MOD.""OID"")        
		                                        GROUP BY ""PLAN2"", ""MODULO2""        ) AS QUERY2, " + ap + @" as ap    
	                                    INNER JOIN " + al + @" as a ON (a.""OID"" = ap.""OID_ALUMNO"")     
	                                    INNER JOIN " + pa + @" as p ON (p.""OID"" = ap.""OID_PARTE"")     
	                                    INNER JOIN " + h + @" as h ON h.""OID"" = p.""OID_HORARIO""   
	                                    INNER JOIN " + apr + @" as apromo ON (apromo.""OID_ALUMNO"" = a.""OID"")    
	                                    INNER JOIN " + pr + @" as pr ON (pr.""OID"" = apromo.""OID_PROMOCION"")     
	                                    INNER JOIN " + pe + @" as pl ON (pl.""OID"" = pr.""OID_PLAN"" AND h.""OID_PROMOCION"" = pr.""OID"")     
	                                    INNER JOIN " + cp + @" as cp ON (p.""OID"" = cp.""OID_PARTE"")     
	                                    INNER JOIN " + ct + @" as ct ON  (ct.""OID"" = cp.""OID_CLASE"")     
	                                    INNER JOIN " + mod + @" as m ON (m.""OID"" = ct.""OID_MODULO"")     
	                                    WHERE ap.""FALTA"" = 'true' AND ap.""RECUPERADA"" = 'false' AND cp.""TIPO"" = " + (long)ETipoClase.Teorica + @" AND ""PLAN2"" = pl.""OID"" AND ""MODULO2"" = m.""TEXTO""    
	                                    GROUP BY pr.""OID"", ""PROMOCION"", ""EXP_ALUMNO"", ""CODIGO_ALUMNO"", ""NOMBRE_ALUMNO"", ""APELLIDO_ALUMNO"", ""MODULO"", ""TOTAL"", m.""OID"", a.""OID""    

	                                    UNION    

	                                    SELECT pr.""OID"" AS ""OID_PROMOCION""
		                                    , pr.""NOMBRE"" AS ""PROMOCION""
		                                    , a.""N_EXPEDIENTE"" AS ""EXP_ALUMNO""
		                                    , a.""CODIGO"" AS ""CODIGO_ALUMNO""
		                                    , a.""NOMBRE"" AS ""NOMBRE_ALUMNO""
		                                    , a.""APELLIDOS"" AS ""APELLIDO_ALUMNO""
		                                    , m.""TEXTO"" AS ""MODULO""
		                                    , m.""OID"" AS ""OID_MODULO""
		                                    , a.""OID"" AS ""OID_ALUMNO""
		                                    , 0 AS ""DURACION""
		                                    , QUERY2.""TOTAL"" AS ""TOTAL""    
	                                    FROM (	SELECT PE.""OID"" AS ""PLAN2""
			                                        , MOD.""TEXTO"" AS ""MODULO2""
			                                        , COUNT(C.""OID"") AS ""TOTAL""        
		                                        FROM " + pe + @" AS PE        
		                                        INNER JOIN " + ct + @" AS C ON ( C.""OID_PLAN"" = PE.""OID"")        
		                                        INNER JOIN " + mod + @" AS MOD ON ( C.""OID_MODULO"" = MOD.""OID"")        
		                                        GROUP BY ""PLAN2"", ""MODULO2""        ) AS QUERY2, " + al + @" as a 
	                                    INNER JOIN " + apr + @" as apromo ON (apromo.""OID_ALUMNO"" = a.""OID"")    
	                                    INNER JOIN " + pr + @" as pr ON (pr.""OID"" = apromo.""OID_PROMOCION"")     
	                                    INNER JOIN " + pe + @" as pl ON (pl.""OID"" = pr.""OID_PLAN"" )      
	                                    INNER JOIN " + ct + @" as ct ON  (ct.""OID_PLAN"" = pl.""OID"")     
	                                    INNER JOIN " + mod + @" as m ON (m.""OID"" = ct.""OID_MODULO"")     
	                                    WHERE a.""OID"" NOT IN (	SELECT ap.""OID_ALUMNO"" 
				                                    FROM " + ap + @" AS ap
				                                    INNER JOIN " + cp + @" AS cp2 ON cp2.""TIPO"" = " + (long)ETipoClase.Teorica + @" AND cp2.""OID_PARTE"" = ap.""OID_PARTE""
				                                    INNER JOIN " + ct + @" AS ct2 ON ct2.""OID"" = cp2.""OID_CLASE"" 
				                                    INNER JOIN " + mod + @" AS m2 ON m2.""OID"" = ct2.""OID_MODULO""
                                                    INNER JOIN " + pr + @" AS pr2 ON pr2.""OID_PLAN"" = ct2.""OID_PLAN""
				                                    WHERE pr2.""OID"" = pr.""OID"" AND m2.""OID"" = m.""OID"" AND ""FALTA"" = 'true' AND ""RECUPERADA"" = 'false') AND ""PLAN2"" = pl.""OID"" AND ""MODULO2"" = m.""TEXTO""    
	                                    GROUP BY pr.""OID"", ""PROMOCION"", ""EXP_ALUMNO"", ""CODIGO_ALUMNO"", ""NOMBRE_ALUMNO"", ""APELLIDO_ALUMNO"", ""MODULO"", ""TOTAL"", m.""OID"", a.""OID"") AS QUERY1 
                                INNER JOIN (	SELECT ""OID_ALUMNO""
			                                        , ""PROMOCION""
			                                        , ""DURACION"" AS ""DURACION_TOTAL""
			                                        , ""TOTAL"" AS ""TOTAL_CURSO""
			                                        , CAST(""DURACION"" / ""TOTAL"" * 100 as numeric(10,2)) AS ""PORC_TOTAL""    
		                                        FROM(	SELECT ""PROMOCION""
				                                            , SUM(""DURACION"") AS ""DURACION""
				                                            , SUM(""TOTAL"") AS ""TOTAL""
				                                            , CAST(SUM(""DURACION"") / SUM(""TOTAL"") * 100 as numeric(10,2)) AS ""PORC""
				                                            , ""OID_ALUMNO""        
			                                            FROM (	SELECT pr.""NOMBRE"" AS ""PROMOCION""
					                                                , a.""OID"" AS ""OID_ALUMNO""
					                                                , COUNT(cp.""OID"") AS ""DURACION""
					                                                , QUERY2.""TOTAL"" AS ""TOTAL""             
				                                                FROM (	SELECT PE.""OID"" AS ""PLAN2""
						                                                    , COUNT(C.""OID"") AS ""TOTAL""                 
					                                                    FROM " + pe + @" AS PE                 
					                                                    INNER JOIN " + ct + @" AS C ON ( C.""OID_PLAN"" = PE.""OID"")                 
					                                                    GROUP BY ""PLAN2"") AS QUERY2, " + ap + @" as ap             
				                                                INNER JOIN " + al + @" as a ON (a.""OID"" = ap.""OID_ALUMNO"")              
				                                                INNER JOIN " + pa + @" as p ON (p.""OID"" = ap.""OID_PARTE"")              
				                                                INNER JOIN " + h + @" as h ON h.""OID"" = p.""OID_HORARIO""           
				                                                INNER JOIN " + apr + @" as apromo ON (apromo.""OID_ALUMNO"" = a.""OID"")             
				                                                INNER JOIN " + pr + @" as pr ON (pr.""OID"" = apromo.""OID_PROMOCION"" AND h.""OID_PROMOCION"" = pr.""OID"")              
				                                                INNER JOIN " + pe + @" as pl ON (pl.""OID"" = pr.""OID_PLAN"")              
				                                                INNER JOIN " + cp + @" as cp ON (p.""OID"" = cp.""OID_PARTE"")              
				                                                INNER JOIN " + ct + @" as ct ON  (ct.""OID"" = cp.""OID_CLASE"")              
				                                                WHERE ap.""FALTA"" = 'TRUE' AND ap.""RECUPERADA"" = 'FALSE' AND cp.""TIPO"" = " + (long)ETipoClase.Teorica + @" AND ""PLAN2"" = pl.""OID""            
				                                                GROUP BY ""PROMOCION"", ""TOTAL"", a.""OID"" 
                                                                UNION
                                                                SELECT pr.""NOMBRE"" AS ""PROMOCION""
					                                                , a.""OID"" AS ""OID_ALUMNO""
					                                                , 0 AS ""DURACION""
					                                                , QUERY2.""TOTAL"" AS ""TOTAL""             
				                                                FROM (	SELECT PE.""OID"" AS ""PLAN2""
						                                                    , COUNT(C.""OID"") AS ""TOTAL""                 
					                                                    FROM " + pe + @" AS PE                 
					                                                    INNER JOIN " + ct + @" AS C ON ( C.""OID_PLAN"" = PE.""OID"")                 
					                                                    GROUP BY ""PLAN2"") AS QUERY2, " + al + @" as a               
				                                                INNER JOIN " + apr + @" as apromo ON (apromo.""OID_ALUMNO"" = a.""OID"")             
				                                                INNER JOIN " + pr + @" as pr ON (pr.""OID"" = apromo.""OID_PROMOCION"")              
				                                                INNER JOIN " + pe + @" as pl ON (pl.""OID"" = pr.""OID_PLAN"")               
				                                                INNER JOIN " + ct + @" as ct ON  (ct.""OID_PLAN"" = pl.""OID"")              
				                                                WHERE a.""OID"" NOT IN (	SELECT ap2.""OID_ALUMNO"" 
													                                        FROM " + ap + @" AS ap2													
                                                                                            INNER JOIN " + cp + @" AS cp2 ON cp2.""TIPO"" = 1 AND cp2.""OID_PARTE"" = ap2.""OID_PARTE""
													                                        INNER JOIN " + ct + @" AS ct2 ON ct2.""OID"" = cp2.""OID_CLASE"" 
													                                        INNER JOIN " + pr + @" AS pr2 ON pr2.""OID_PLAN"" = ct2.""OID_PLAN""
													                                        WHERE ""FALTA"" = 'true' AND ""RECUPERADA"" = 'false' AND pr2.""OID"" = pr.""OID"") AND ""PLAN2"" = pl.""OID""            
				                                                GROUP BY ""PROMOCION"", ""TOTAL"", a.""OID"") AS QUERY1         
			                                            GROUP BY ""PROMOCION"", ""OID_ALUMNO"" ) AS SUPER_QUERY    
		                                        GROUP BY ""PROMOCION"", ""OID_ALUMNO"", ""DURACION_TOTAL"", ""TOTAL_CURSO""    
		                                        ORDER BY ""PROMOCION"") AS SUPER_QUERY ON (SUPER_QUERY.""OID_ALUMNO"" = QUERY1.""OID_ALUMNO"" AND SUPER_QUERY.""PROMOCION"" = QUERY1.""PROMOCION"") ";
                if (oid_promocion != 0)
                    query += " WHERE QUERY1.\"OID_PROMOCION\" = " + (long)oid_promocion;
                query += @" GROUP BY QUERY1.""OID_PROMOCION"", QUERY1.""PROMOCION"", ""EXP_ALUMNO"", ""CODIGO_ALUMNO"", ""NOMBRE_ALUMNO"", ""APELLIDO_ALUMNO"", ""MODULO"", ""OID_MODULO"", QUERY1.""OID_ALUMNO"", ""DURACION_TOTAL"", ""TOTAL_CURSO"", ""PORC_TOTAL"" ORDER BY QUERY1.""PROMOCION"", ""EXP_ALUMNO"", ""MODULO""";*/

                string query = @"SELECT DISTINCT PR.""OID"" AS ""OID_PROMOCION""
	                                , PR.""NOMBRE"" AS ""PROMOCION""
	                                , A.""N_EXPEDIENTE"" AS ""EXP_ALUMNO""
	                                , A.""CODIGO"" AS ""CODIGO_ALUMNO""
	                                , A.""NOMBRE"" AS ""NOMBRE_ALUMNO""
	                                , A.""APELLIDOS"" AS ""APELLIDO_ALUMNO""
	                                , A.""OID"" AS ""OID_ALUMNO""
	                                , M.""TEXTO"" AS ""MODULO""
	                                , M.""OID"" AS ""OID_MODULO""
	                                , C1.""CLASES_MODULO"" AS ""TOTAL""
	                                , C2.""CLASES_PLAN"" AS ""TOTAL_CURSO""
	                                , COALESCE(C3.""FALTAS_MODULO"", 0) AS ""DURACION""
	                                , COALESCE(C4.""FALTAS_PLAN"", 0) AS ""DURACION_TOTAL""
                                FROM " + al + @" AS A
                                INNER JOIN " + apr + @" AS APR ON APR.""OID_ALUMNO"" = A.""OID""
                                INNER JOIN " + pr + @" AS PR ON PR.""OID"" = APR.""OID_PROMOCION""
                                INNER JOIN " + pe + @" AS PE ON PE.""OID"" = PR.""OID_PLAN""
                                INNER JOIN " + ct + @" AS CT ON CT.""OID_PLAN"" = PE.""OID""
                                INNER JOIN " + mod + @" AS M ON M.""OID"" = CT.""OID_MODULO""
                                INNER JOIN (	SELECT COUNT(""OID"") AS ""CLASES_MODULO""
			                                        , ""OID_PLAN""
			                                        , ""OID_MODULO""
		                                        FROM " + ct + @"
		                                        GROUP BY ""OID_PLAN"", ""OID_MODULO"") AS C1 ON C1.""OID_PLAN"" = PE.""OID"" AND C1.""OID_MODULO"" = M.""OID""
                                INNER JOIN (	SELECT COUNT(""OID"") AS ""CLASES_PLAN""
			                                        , ""OID_PLAN""
		                                        FROM " + ct + @" 
		                                        GROUP BY ""OID_PLAN"") AS C2 ON C2.""OID_PLAN"" = PE.""OID""
                                LEFT JOIN (	SELECT COUNT(CT.""OID"") AS ""FALTAS_MODULO""
			                                    , CT.""OID_MODULO""
			                                    , CT.""OID_PLAN""
			                                    , AP.""OID_ALUMNO""
		                                    FROM "+ ap + @" AS AP
		                                    INNER JOIN " + pa + @" AS PA ON PA.""OID"" = AP.""OID_PARTE""
		                                    INNER JOIN " + cp + @" AS CP ON CP.""OID_PARTE"" = PA.""OID"" AND CP.""TIPO"" = " + (long)ETipoClase.Teorica + @"
		                                    INNER JOIN " + ct + @" AS CT ON CT.""OID"" = CP.""OID_CLASE""
		                                    WHERE AP.""FALTA"" = 'TRUE' AND AP.""RECUPERADA"" = 'FALSE'
		                                    GROUP BY AP.""OID_ALUMNO"", CT.""OID_MODULO"", CT.""OID_PLAN"") AS C3 ON C3.""OID_ALUMNO"" = A.""OID"" AND C3.""OID_PLAN"" = PE.""OID"" AND C3.""OID_MODULO"" = M.""OID""
                                LEFT JOIN (	SELECT COUNT(CT.""OID"") AS ""FALTAS_PLAN""
			                                    , CT.""OID_PLAN""
			                                    , AP.""OID_ALUMNO""
		                                    FROM " + ap + @" AS AP
		                                    INNER JOIN " + pa + @" AS PA ON PA.""OID"" = AP.""OID_PARTE""
		                                    INNER JOIN " + cp + @" AS CP ON CP.""OID_PARTE"" = PA.""OID"" AND CP.""TIPO"" = " + (long)ETipoClase.Teorica + @"
		                                    INNER JOIN " + ct + @" AS CT ON CT.""OID"" = CP.""OID_CLASE""
		                                    WHERE AP.""FALTA"" = 'TRUE' AND AP.""RECUPERADA"" = 'FALSE'
		                                    GROUP BY AP.""OID_ALUMNO"", CT.""OID_PLAN"") AS C4 ON C4.""OID_ALUMNO"" = A.""OID"" AND C4.""OID_PLAN"" = PE.""OID""
                                
                                ORDER BY ""PROMOCION"", ""CODIGO_ALUMNO"", ""MODULO""";
                return query;
            }

            private static string SELECT_FALTAS_BY_ALUMNO(long oid_alumno)
            {
                /*string query = "SELECT a.\"NOMBRE\" AS NOMBRE_ALUMNO, a.\"APELLIDOS\" AS APELLIDO_ALUMNO, a.\"N_EXPEDIENTE\" AS EXP_ALUMNO, " +
                    "a.\"CODIGO\" AS CODIGO_ALUMNO, p.\"SESIONES\" AS SESIONES, p.\"N_HORAS\" AS DURACION, pr.\"NOMBRE\" AS PROMOCION, " +
                    "m.\"TEXTO\" AS MODULO, ct.\"TOTAL_CLASES\" AS TOTAL, sm.\"CODIGO\" AS SUBMODULO, sm.\"CODIGO_ORDEN\" AS ORDEN_SUBMODULO, " +
                    "ct.\"ORDEN_TERCIARIO\" AS ORDEN_CLASE, pl.\"OID\" AS OID_PLAN " +
                    "FROM \"0001\".\"Alumno_Parte\" as ap " +
                    "INNER JOIN \"0001\".\"Alumno\" as a ON (a.\"OID\" = ap.\"OID_ALUMNO\") " +
                    "INNER JOIN \"0001\".\"ParteAsistencia\" as p ON (p.\"OID\" = ap.\"OID_PARTE\") " +
                    "INNER JOIN \"0001\".\"Promocion\" as pr ON (pr.\"OID\" = a.\"OID_PROMOCION\") " +
                    "INNER JOIN \"0001\".\"PlanEstudios\" as pl ON (pl.\"OID\" = pr.\"OID_PLAN\") " +
                    "INNER JOIN \"0001\".\"ClaseTeorica\" as ct ON " +
                    "(cast(substring(p.\"SESIONES\" from 1 for position(' ' in p.\"SESIONES\")) as bigint)  = ct.\"OID\" AND p.\"TIPO\" = 0) " +
                    "INNER JOIN \"0001\".\"Modulo\" as m ON (m.\"OID\" = ct.\"OID_MODULO\") " +
                    "INNER JOIN \"0001\".\"Submodulo\" as sm ON (sm.\"OID\" = ct.\"OID_SUBMODULO\") " +
                    "WHERE ap.\"FALTA\" = 'true' " +
                    "UNION " +
                    "SELECT a.\"NOMBRE\" AS NOMBRE_ALUMNO, a.\"APELLIDOS\" AS APELLIDO_ALUMNO, a.\"N_EXPEDIENTE\" AS EXP_ALUMNO, " +
                    "a.\"CODIGO\" AS CODIGO_ALUMNO, p.\"SESIONES\" AS SESIONES, p.\"N_HORAS\" AS DURACION, pr.\"NOMBRE\" AS PROMOCION, " +
                    "m.\"TEXTO\" AS MODULO, cp.\"TOTAL_CLASES\" AS TOTAL, sm.\"CODIGO\" AS SUBMODULO, sm.\"CODIGO_ORDEN\" AS ORDEN_SUBMODULO, " +
                    "cp.\"ORDEN_TERCIARIO\" AS ORDEN_CLASE, pl.\"OID\" AS OID_PLAN " +
                    "FROM \"0001\".\"Alumno_Parte\" as ap " +
                    "INNER JOIN \"0001\".\"Alumno\" as a ON (a.\"OID\" = ap.\"OID_ALUMNO\") " +
                    "INNER JOIN \"0001\".\"ParteAsistencia\" as p ON (p.\"OID\" = ap.\"OID_PARTE\") " +
                    "INNER JOIN \"0001\".\"Promocion\" as pr ON (pr.\"OID\" = a.\"OID_PROMOCION\") " +
                    "INNER JOIN \"0001\".\"PlanEstudios\" as pl ON (pl.\"OID\" = pr.\"OID_PLAN\") " +
                    "INNER JOIN \"0001\".\"ClasePractica\" as cp ON " +
                    "(cast(substring(p.\"SESIONES\" from 1 for position(' ' in p.\"SESIONES\")) as bigint)  = cp.\"OID\" AND p.\"TIPO\" = 1) " +
                    "INNER JOIN \"0001\".\"Modulo\" as m ON (m.\"OID\" = cp.\"OID_MODULO\") " +
                    "INNER JOIN \"0001\".\"Submodulo\" as sm ON (sm.\"OID\" = cp.\"OID_SUBMODULO\") " +
                    "WHERE ap.\"FALTA\" = 'true' " +
                    "ORDER BY EXP_ALUMNO, ORDEN_SUBMODULO, ORDEN_CLASE; ";
                string query = "SELECT QUERY1.\"OID_PROMOCION\", QUERY1.\"PROMOCION\", \"EXP_ALUMNO\", \"CODIGO_ALUMNO\", \"NOMBRE_ALUMNO\", \"APELLIDO_ALUMNO\", \"MODULO\", SUM(\"DURACION\") AS \"DURACION\", SUM(QUERY1.\"TOTAL\") AS \"TOTAL\", CAST(SUM(\"DURACION\") / SUM(QUERY1.\"TOTAL\") * 100 as numeric(10,2)) AS \"PORC\", \"OID_MODULO\", QUERY1.\"OID_ALUMNO\", " +
                                " \"DURACION_TOTAL\", \"TOTAL_CURSO\", \"PORC_TOTAL\" " +
                                "FROM( " +
                                "   SELECT pr.\"OID\" AS \"OID_PROMOCION\", pr.\"NOMBRE\" AS \"PROMOCION\", a.\"N_EXPEDIENTE\" AS \"EXP_ALUMNO\", a.\"CODIGO\" AS \"CODIGO_ALUMNO\", a.\"NOMBRE\" AS \"NOMBRE_ALUMNO\", a.\"APELLIDOS\" AS \"APELLIDO_ALUMNO\", " +
                                "       m.\"TEXTO\" AS \"MODULO\", m.\"OID\" AS \"OID_MODULO\", a.\"OID\" AS \"OID_ALUMNO\", COUNT(cp.\"OID\") AS \"DURACION\", QUERY2.\"TOTAL\" AS \"TOTAL\" " +
                                "   FROM " +
                                "       ( " +
                                "       SELECT PE.\"OID\" AS \"PLAN2\", MOD.\"TEXTO\" AS \"MODULO2\", COUNT(C.\"OID\") AS \"TOTAL\" " +
                                "       FROM \"0001\".\"PlanEstudios\" AS PE " +
                                "       INNER JOIN \"0001\".\"ClaseTeorica\" AS C ON ( C.\"OID_PLAN\" = PE.\"OID\") " +
                                "       INNER JOIN \"0001\".\"Modulo\" AS MOD ON ( C.\"OID_MODULO\" = MOD.\"OID\") " +
                                "       GROUP BY \"PLAN2\", \"MODULO2\" " +
                                "       ) AS QUERY2, \"0001\".\"Alumno_Parte\" as ap " +
                                "   INNER JOIN \"0001\".\"Alumno\" as a ON (a.\"OID\" = ap.\"OID_ALUMNO\")  " +
                                "   INNER JOIN \"0001\".\"ParteAsistencia\" as p ON (p.\"OID\" = ap.\"OID_PARTE\")  " +
                                "   INNER JOIN \"0001\".\"Horario\" as h ON h.\"OID\" = p.\"OID_HORARIO\"" +
                                "   INNER JOIN \"0001\".\"Alumno_Promocion\" as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\") " +
                                "   INNER JOIN \"0001\".\"Promocion\" as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\")  " +
                                "   INNER JOIN \"0001\".\"PlanEstudios\" as pl ON (pl.\"OID\" = pr.\"OID_PLAN\" AND h.\"OID_PROMOCION\" = pr.\"OID\")  " +
                                "   INNER JOIN \"0001\".\"Clase_Parte\" as cp ON (p.\"OID\" = cp.\"OID_PARTE\")  " +
                                "   INNER JOIN \"0001\".\"ClaseTeorica\" as ct ON  (ct.\"OID\" = cp.\"OID_CLASE\")  " +
                                "   INNER JOIN \"0001\".\"Modulo\" as m ON (m.\"OID\" = ct.\"OID_MODULO\")  " +
                                "   WHERE ap.\"FALTA\" = 'true' AND ap.\"RECUPERADA\" = 'false' AND cp.\"TIPO\" = 1  " +
                                "       AND \"PLAN2\" = pl.\"OID\" AND \"MODULO2\" = m.\"TEXTO\" " +
                                "   GROUP BY pr.\"OID\", \"PROMOCION\", \"EXP_ALUMNO\", \"CODIGO_ALUMNO\", \"NOMBRE_ALUMNO\", \"APELLIDO_ALUMNO\", \"MODULO\", \"TOTAL\", m.\"OID\", a.\"OID\" " +
                                "   UNION " +
                                "   SELECT pr.\"OID\" AS \"OID_PROMOCION\", pr.\"NOMBRE\" AS \"PROMOCION\", a.\"N_EXPEDIENTE\" AS \"EXP_ALUMNO\", a.\"CODIGO\" AS \"CODIGO_ALUMNO\", a.\"NOMBRE\" AS \"NOMBRE_ALUMNO\", a.\"APELLIDOS\" AS \"APELLIDO_ALUMNO\", " +
                                "       m.\"TEXTO\" AS \"MODULO\", m.\"OID\" AS \"OID_MODULO\", a.\"OID\" AS \"OID_ALUMNO\", 0 AS \"DURACION\", QUERY2.\"TOTAL\" AS \"TOTAL\" " +
                                "   FROM " +
                                "       ( " +
                                "       SELECT PE.\"OID\" AS \"PLAN2\", MOD.\"TEXTO\" AS \"MODULO2\", COUNT(C.\"OID\") AS \"TOTAL\" " +
                                "       FROM \"0001\".\"PlanEstudios\" AS PE " +
                                "       INNER JOIN \"0001\".\"ClaseTeorica\" AS C ON ( C.\"OID_PLAN\" = PE.\"OID\") " +
                                "       INNER JOIN \"0001\".\"Modulo\" AS MOD ON ( C.\"OID_MODULO\" = MOD.\"OID\") " +
                                "       GROUP BY \"PLAN2\", \"MODULO2\" " +
                                "       ) AS QUERY2, \"0001\".\"Alumno_Parte\" as ap " +
                                "   INNER JOIN \"0001\".\"Alumno\" as a ON (a.\"OID\" = ap.\"OID_ALUMNO\")  " +
                                "   INNER JOIN \"0001\".\"ParteAsistencia\" as p ON (p.\"OID\" = ap.\"OID_PARTE\")  " +
                                "   INNER JOIN \"0001\".\"Horario\" as h ON h.\"OID\" = p.\"OID_HORARIO\"" +
                                "   INNER JOIN \"0001\".\"Alumno_Promocion\" as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\") " +
                                "   INNER JOIN \"0001\".\"Promocion\" as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\")  " +
                                "   INNER JOIN \"0001\".\"PlanEstudios\" as pl ON (pl.\"OID\" = pr.\"OID_PLAN\" AND h.\"OID_PROMOCION\" = pr.\"OID\")  " +
                                "   INNER JOIN \"0001\".\"Clase_Parte\" as cp ON (p.\"OID\" = cp.\"OID_PARTE\")  " +
                                "   INNER JOIN \"0001\".\"ClaseTeorica\" as ct ON  (ct.\"OID\" = cp.\"OID_CLASE\")  " +
                                "   INNER JOIN \"0001\".\"Modulo\" as m ON (m.\"OID\" = ct.\"OID_MODULO\")  " +
                                "   WHERE ap.\"OID\" NOT IN ( SELECT \"OID\" FROM \"0001\".\"Alumno_Parte\" WHERE \"FALTA\" = 'true' AND \"RECUPERADA\" = 'false') AND cp.\"TIPO\" = 1  " +
                                "       AND \"PLAN2\" = pl.\"OID\" AND \"MODULO2\" = m.\"TEXTO\" " +
                                "   GROUP BY pr.\"OID\", \"PROMOCION\", \"EXP_ALUMNO\", \"CODIGO_ALUMNO\", \"NOMBRE_ALUMNO\", \"APELLIDO_ALUMNO\", \"MODULO\", \"TOTAL\", m.\"OID\", a.\"OID\" " +
                                "   UNION " +
                                "   SELECT pr.\"OID\" AS \"OID_PROMOCION\", pr.\"NOMBRE\" AS \"PROMOCION\", a.\"N_EXPEDIENTE\" AS \"EXP_ALUMNO\", a.\"CODIGO\" AS \"CODIGO_ALUMNO\", a.\"NOMBRE\" AS \"NOMBRE_ALUMNO\", a.\"APELLIDOS\" AS \"APELLIDO_ALUMNO\", " +
                                "       m.\"TEXTO\" AS \"MODULO\", m.\"OID\" AS \"OID_MODULO\", a.\"OID\" AS \"OID_ALUMNO\", COUNT(cp.\"OID\") AS \"DURACION\", QUERY2.\"TOTAL\" AS \"TOTAL\" " +
                                "   FROM " +
                                "       ( " +
                                "       SELECT PE.\"OID\" AS \"PLAN2\", MOD.\"TEXTO\" AS \"MODULO2\", COUNT(C.\"OID\") AS \"TOTAL\" " +
                                "       FROM \"0001\".\"PlanExtra\" AS PE " +
                                "       INNER JOIN \"0001\".\"ClaseExtra\" AS C ON ( C.\"OID_PLAN\" = PE.\"OID\") " +
                                "       INNER JOIN \"0001\".\"Modulo\" AS MOD ON ( C.\"OID_MODULO\" = MOD.\"OID\") " +
                                "       GROUP BY \"PLAN2\", \"MODULO2\" " +
                                "       ) AS QUERY2, \"0001\".\"Alumno_Parte\" as ap " +
                                "   INNER JOIN \"0001\".\"Alumno\" as a ON (a.\"OID\" = ap.\"OID_ALUMNO\")  " +
                                "   INNER JOIN \"0001\".\"ParteAsistencia\" as p ON (p.\"OID\" = ap.\"OID_PARTE\")  " +
                                "   INNER JOIN \"0001\".\"Horario\" as h ON h.\"OID\" = p.\"OID_HORARIO\"" +
                                "   INNER JOIN \"0001\".\"Alumno_Promocion\" as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\") " +
                                "   INNER JOIN \"0001\".\"Promocion\" as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\" AND h.\"OID_PROMOCION\" = pr.\"OID\")  " +
                                "   INNER JOIN \"0001\".\"PlanExtra\" as pl ON (pl.\"OID\" = pr.\"OID_PLAN_EXTRA\")  " +
                                "   INNER JOIN \"0001\".\"Clase_Parte\" as cp ON (p.\"OID\" = cp.\"OID_PARTE\")  " +
                                "   INNER JOIN \"0001\".\"ClaseExtra\" as ct ON  (ct.\"OID\" = cp.\"OID_CLASE\")  " +
                                "   INNER JOIN \"0001\".\"Modulo\" as m ON (m.\"OID\" = ct.\"OID_MODULO\")  " +
                                "   WHERE ap.\"FALTA\" = 'true' AND ap.\"RECUPERADA\" = 'false' AND cp.\"TIPO\" = 3  " +
                                "       AND \"PLAN2\" = pl.\"OID\" AND \"MODULO2\" = m.\"TEXTO\" " +
                                "   GROUP BY pr.\"OID\", \"PROMOCION\", \"EXP_ALUMNO\", \"CODIGO_ALUMNO\", \"NOMBRE_ALUMNO\", \"APELLIDO_ALUMNO\", \"MODULO\", \"TOTAL\", m.\"OID\", a.\"OID\" " +
                                "   UNION " +
                                "   SELECT pr.\"OID\" AS \"OID_PROMOCION\", pr.\"NOMBRE\" AS \"PROMOCION\", a.\"N_EXPEDIENTE\" AS \"EXP_ALUMNO\", a.\"CODIGO\" AS \"CODIGO_ALUMNO\", a.\"NOMBRE\" AS \"NOMBRE_ALUMNO\", a.\"APELLIDOS\" AS \"APELLIDO_ALUMNO\", " +
                                "       m.\"TEXTO\" AS \"MODULO\", m.\"OID\" AS \"OID_MODULO\", a.\"OID\" AS \"OID_ALUMNO\", 0 AS \"DURACION\", QUERY2.\"TOTAL\" AS \"TOTAL\" " +
                                "   FROM " +
                                "       ( " +
                                "       SELECT PE.\"OID\" AS \"PLAN2\", MOD.\"TEXTO\" AS \"MODULO2\", COUNT(C.\"OID\") AS \"TOTAL\" " +
                                "       FROM \"0001\".\"PlanExtra\" AS PE " +
                                "       INNER JOIN \"0001\".\"ClaseExtra\" AS C ON ( C.\"OID_PLAN\" = PE.\"OID\") " +
                                "       INNER JOIN \"0001\".\"Modulo\" AS MOD ON ( C.\"OID_MODULO\" = MOD.\"OID\") " +
                                "       GROUP BY \"PLAN2\", \"MODULO2\" " +
                                "       ) AS QUERY2, \"0001\".\"Alumno_Parte\" as ap " +
                                "   INNER JOIN \"0001\".\"Alumno\" as a ON (a.\"OID\" = ap.\"OID_ALUMNO\")  " +
                                "   INNER JOIN \"0001\".\"ParteAsistencia\" as p ON (p.\"OID\" = ap.\"OID_PARTE\")  " +
                                "   INNER JOIN \"0001\".\"Horario\" as h ON h.\"OID\" = p.\"OID_HORARIO\"" +
                                "   INNER JOIN \"0001\".\"Alumno_Promocion\" as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\") " +
                                "   INNER JOIN \"0001\".\"Promocion\" as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\" AND h.\"OID_PROMOCION\" = pr.\"OID\")  " +
                                "   INNER JOIN \"0001\".\"PlanExtra\" as pl ON (pl.\"OID\" = pr.\"OID_PLAN_EXTRA\")  " +
                                "   INNER JOIN \"0001\".\"Clase_Parte\" as cp ON (p.\"OID\" = cp.\"OID_PARTE\")  " +
                                "   INNER JOIN \"0001\".\"ClaseExtra\" as ct ON  (ct.\"OID\" = cp.\"OID_CLASE\")  " +
                                "   INNER JOIN \"0001\".\"Modulo\" as m ON (m.\"OID\" = ct.\"OID_MODULO\")  " +
                                "   WHERE ap.\"OID\" NOT IN ( SELECT \"OID\" FROM \"0001\".\"Alumno_Parte\" WHERE \"FALTA\" = 'true' AND \"RECUPERADA\" = 'false') AND cp.\"TIPO\" = 3  " +
                                "       AND \"PLAN2\" = pl.\"OID\" AND \"MODULO2\" = m.\"TEXTO\" " +
                                "   GROUP BY pr.\"OID\", \"PROMOCION\", \"EXP_ALUMNO\", \"CODIGO_ALUMNO\", \"NOMBRE_ALUMNO\", \"APELLIDO_ALUMNO\", \"MODULO\", \"TOTAL\", m.\"OID\", a.\"OID\" " +

                                "   ) AS QUERY1 " +
                                "INNER JOIN (" +
                                "   SELECT \"OID_ALUMNO\", \"PROMOCION\", \"DURACION\" AS \"DURACION_TOTAL\", \"TOTAL\" AS \"TOTAL_CURSO\", " +
                                "       CAST(\"DURACION\" / \"TOTAL\" * 100 as numeric(10,2)) AS \"PORC_TOTAL\" " +
                                "   FROM(" +
                                "       SELECT \"PROMOCION\", SUM(\"DURACION\") AS \"DURACION\", SUM(\"TOTAL\") AS \"TOTAL\", " +
		                        "           CAST(SUM(\"DURACION\") / SUM(\"TOTAL\") * 100 as numeric(10,2)) AS \"PORC\", \"OID_ALUMNO\" " + 
	                            "       FROM(  " +
		                        "           SELECT pr.\"NOMBRE\" AS \"PROMOCION\", a.\"OID\" AS \"OID_ALUMNO\",  " +
			                    "               COUNT(cp.\"OID\") AS \"DURACION\", QUERY2.\"TOTAL\" AS \"TOTAL\"  " +
		                        "           FROM (  " +
			                    "               SELECT PE.\"OID\" AS \"PLAN2\", COUNT(C.\"OID\") AS \"TOTAL\"  " +
			                    "               FROM \"0001\".\"PlanEstudios\" AS PE  " +
			                    "               INNER JOIN \"0001\".\"ClaseTeorica\" AS C ON ( C.\"OID_PLAN\" = PE.\"OID\")  " +
			                    "               GROUP BY \"PLAN2\") AS QUERY2, \"0001\".\"Alumno_Parte\" as ap  " +
		                        "           INNER JOIN \"0001\".\"Alumno\" as a ON (a.\"OID\" = ap.\"OID_ALUMNO\")   " +
                                "           INNER JOIN \"0001\".\"ParteAsistencia\" as p ON (p.\"OID\" = ap.\"OID_PARTE\")   " +
                                "           INNER JOIN \"0001\".\"Horario\" as h ON h.\"OID\" = p.\"OID_HORARIO\"" +
		                        "           INNER JOIN \"0001\".\"Alumno_Promocion\" as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\")  " +
                                "           INNER JOIN \"0001\".\"Promocion\" as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\" AND h.\"OID_PROMOCION\" = pr.\"OID\")   " +
		                        "           INNER JOIN \"0001\".\"PlanEstudios\" as pl ON (pl.\"OID\" = pr.\"OID_PLAN\")   " +
		                        "           INNER JOIN \"0001\".\"Clase_Parte\" as cp ON (p.\"OID\" = cp.\"OID_PARTE\")   " +
		                        "           INNER JOIN \"0001\".\"ClaseTeorica\" as ct ON  (ct.\"OID\" = cp.\"OID_CLASE\")   " +
                                "           WHERE ap.\"FALTA\" = 'true' AND ap.\"RECUPERADA\" = 'false' AND cp.\"TIPO\" = 1  AND \"PLAN2\" = pl.\"OID\" " +
		                        "           GROUP BY \"PROMOCION\", \"TOTAL\", a.\"OID\"  " +
                                "           UNION  " +
                                "           SELECT pr.\"NOMBRE\" AS \"PROMOCION\", a.\"OID\" AS \"OID_ALUMNO\",  " +
                                "               0 AS \"DURACION\", QUERY2.\"TOTAL\" AS \"TOTAL\"  " +
                                "           FROM (  " +
                                "               SELECT PE.\"OID\" AS \"PLAN2\", COUNT(C.\"OID\") AS \"TOTAL\"  " +
                                "               FROM \"0001\".\"PlanEstudios\" AS PE  " +
                                "               INNER JOIN \"0001\".\"ClaseTeorica\" AS C ON ( C.\"OID_PLAN\" = PE.\"OID\")  " +
                                "               GROUP BY \"PLAN2\") AS QUERY2, \"0001\".\"Alumno_Parte\" as ap  " +
                                "           INNER JOIN \"0001\".\"Alumno\" as a ON (a.\"OID\" = ap.\"OID_ALUMNO\")   " +
                                "           INNER JOIN \"0001\".\"ParteAsistencia\" as p ON (p.\"OID\" = ap.\"OID_PARTE\")   " +
                                "           INNER JOIN \"0001\".\"Horario\" as h ON h.\"OID\" = p.\"OID_HORARIO\"" +
                                "           INNER JOIN \"0001\".\"Alumno_Promocion\" as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\")  " +
                                "           INNER JOIN \"0001\".\"Promocion\" as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\" AND h.\"OID_PROMOCION\" = pr.\"OID\")   " +
                                "           INNER JOIN \"0001\".\"PlanEstudios\" as pl ON (pl.\"OID\" = pr.\"OID_PLAN\")   " +
                                "           INNER JOIN \"0001\".\"Clase_Parte\" as cp ON (p.\"OID\" = cp.\"OID_PARTE\")   " +
                                "           INNER JOIN \"0001\".\"ClaseTeorica\" as ct ON  (ct.\"OID\" = cp.\"OID_CLASE\")   " +
                                "           WHERE ap.\"OID\" NOT IN ( SELECT \"OID\" FROM \"0001\".\"Alumno_Parte\" WHERE \"FALTA\" = 'true' AND \"RECUPERADA\" = 'false') AND cp.\"TIPO\" = 1  AND \"PLAN2\" = pl.\"OID\" " +
                                "           GROUP BY \"PROMOCION\", \"TOTAL\", a.\"OID\"  " +
                                "           UNION  " +
		                        "           SELECT pr.\"NOMBRE\" AS \"PROMOCION\", a.\"OID\" AS \"OID_ALUMNO\", COUNT(cp.\"OID\") AS \"DURACION\",  " +
			                    "               QUERY2.\"TOTAL\" AS \"TOTAL\"  " +
		                        "           FROM (  " +
			                    "               SELECT PE.\"OID\" AS \"PLAN2\", COUNT(C.\"OID\") AS \"TOTAL\"  " +
			                    "               FROM \"0001\".\"PlanExtra\" AS PE  " +
			                    "               INNER JOIN \"0001\".\"ClaseExtra\" AS C ON ( C.\"OID_PLAN\" = PE.\"OID\")  " +
			                    "               GROUP BY \"PLAN2\") AS QUERY2, \"0001\".\"Alumno_Parte\" as ap  " +
		                        "           INNER JOIN \"0001\".\"Alumno\" as a ON (a.\"OID\" = ap.\"OID_ALUMNO\")   " +
		                        "           INNER JOIN \"0001\".\"ParteAsistencia\" as p ON (p.\"OID\" = ap.\"OID_PARTE\")   " +
                                "           INNER JOIN \"0001\".\"Horario\" as h ON h.\"OID\" = p.\"OID_HORARIO\"" +
		                        "           INNER JOIN \"0001\".\"Alumno_Promocion\" as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\")  " +
		                        "           INNER JOIN \"0001\".\"Promocion\" as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\" AND h.\"OID_PROMOCION\" = pr.\"OID\")   " +
		                        "           INNER JOIN \"0001\".\"PlanExtra\" as pl ON (pl.\"OID\" = pr.\"OID_PLAN_EXTRA\")   " +
		                        "           INNER JOIN \"0001\".\"Clase_Parte\" as cp ON (p.\"OID\" = cp.\"OID_PARTE\")   " +
		                        "           INNER JOIN \"0001\".\"ClaseExtra\" as ct ON  (ct.\"OID\" = cp.\"OID_CLASE\")   " +
		                        "           WHERE ap.\"FALTA\" = 'true' AND ap.\"RECUPERADA\" = 'false' AND cp.\"TIPO\" = 3  AND \"PLAN2\" = pl.\"OID\" " +
		                        "           GROUP BY \"PROMOCION\", \"TOTAL\", a.\"OID\" " +
                                "           UNION  " +
		                        "           SELECT pr.\"NOMBRE\" AS \"PROMOCION\", a.\"OID\" AS \"OID_ALUMNO\", 0 AS \"DURACION\",  " +
			                    "               QUERY2.\"TOTAL\" AS \"TOTAL\"  " +
		                        "           FROM (  " +
			                    "               SELECT PE.\"OID\" AS \"PLAN2\", COUNT(C.\"OID\") AS \"TOTAL\"  " +
			                    "               FROM \"0001\".\"PlanExtra\" AS PE  " +
			                    "               INNER JOIN \"0001\".\"ClaseExtra\" AS C ON ( C.\"OID_PLAN\" = PE.\"OID\")  " +
			                    "               GROUP BY \"PLAN2\") AS QUERY2, \"0001\".\"Alumno_Parte\" as ap  " +
		                        "           INNER JOIN \"0001\".\"Alumno\" as a ON (a.\"OID\" = ap.\"OID_ALUMNO\")   " +
		                        "           INNER JOIN \"0001\".\"ParteAsistencia\" as p ON (p.\"OID\" = ap.\"OID_PARTE\")   " +
                                "           INNER JOIN \"0001\".\"Horario\" as h ON h.\"OID\" = p.\"OID_HORARIO\"" +
		                        "           INNER JOIN \"0001\".\"Alumno_Promocion\" as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\")  " +
		                        "           INNER JOIN \"0001\".\"Promocion\" as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\" AND h.\"OID_PROMOCION\" = pr.\"OID\")   " +
		                        "           INNER JOIN \"0001\".\"PlanExtra\" as pl ON (pl.\"OID\" = pr.\"OID_PLAN_EXTRA\")   " +
		                        "           INNER JOIN \"0001\".\"Clase_Parte\" as cp ON (p.\"OID\" = cp.\"OID_PARTE\")   " +
		                        "           INNER JOIN \"0001\".\"ClaseExtra\" as ct ON  (ct.\"OID\" = cp.\"OID_CLASE\")   " +
                                "           WHERE ap.\"OID\" NOT IN ( SELECT \"OID\" FROM \"0001\".\"Alumno_Parte\" WHERE \"FALTA\" = 'true' AND \"RECUPERADA\" = 'false') AND cp.\"TIPO\" = 3  AND \"PLAN2\" = pl.\"OID\" " +
		                        "           GROUP BY \"PROMOCION\", \"TOTAL\", a.\"OID\" ) AS QUERY1  " +
	                            "       GROUP BY \"PROMOCION\", \"OID_ALUMNO\" ) AS SUPER_QUERY " +
                                "   GROUP BY \"PROMOCION\", \"OID_ALUMNO\", \"DURACION_TOTAL\", \"TOTAL_CURSO\" " +
                                "   ORDER BY \"PROMOCION\") AS SUPER_QUERY ON (SUPER_QUERY.\"OID_ALUMNO\" = QUERY1.\"OID_ALUMNO\" AND SUPER_QUERY.\"PROMOCION\" = QUERY1.\"PROMOCION\") " +                        
                                "GROUP BY QUERY1.\"OID_PROMOCION\", QUERY1.\"PROMOCION\", \"EXP_ALUMNO\", \"CODIGO_ALUMNO\", \"NOMBRE_ALUMNO\", \"APELLIDO_ALUMNO\", \"MODULO\", \"OID_MODULO\", QUERY1.\"OID_ALUMNO\", \"DURACION_TOTAL\", \"TOTAL_CURSO\", \"PORC_TOTAL\" " +
                                "ORDER BY QUERY1.\"PROMOCION\", \"EXP_ALUMNO\", \"MODULO\";";*/

                string pe = nHManager.Instance.GetSQLTable(typeof(PlanEstudiosRecord));
                string ct = nHManager.Instance.GetSQLTable(typeof(ClaseTeoricaRecord));
                string cpr = nHManager.Instance.GetSQLTable(typeof(ClasePracticaRecord));
                string mod = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
                string pa = nHManager.Instance.GetSQLTable(typeof(ParteAsistenciaRecord));
                string cp = nHManager.Instance.GetSQLTable(typeof(Clase_ParteRecord));
                string ap = nHManager.Instance.GetSQLTable(typeof(AlumnoParteRecord));
                string al = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));
                string apr = nHManager.Instance.GetSQLTable(typeof(AlumnoPromocionRecord));
                string h = nHManager.Instance.GetSQLTable(typeof(HorarioRecord));
                string pr = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));

                /*string query = @"SELECT QUERY1.""OID_PROMOCION""
	                                , QUERY1.""PROMOCION""
	                                , ""EXP_ALUMNO""
	                                , ""CODIGO_ALUMNO""
	                                , ""NOMBRE_ALUMNO""
	                                , ""APELLIDO_ALUMNO""
	                                , ""MODULO""
	                                , SUM(""DURACION"") AS ""DURACION""
	                                , SUM(QUERY1.""TOTAL"") AS ""TOTAL""
	                                , CAST(SUM(""DURACION"") / SUM(QUERY1.""TOTAL"") * 100 as numeric(10,2)) AS ""PORC""
	                                , ""OID_MODULO""
	                                , QUERY1.""OID_ALUMNO""
	                                , ""DURACION_TOTAL""
	                                , ""TOTAL_CURSO""
	                                , ""PORC_TOTAL"" 
                                FROM(   SELECT pr.""OID"" AS ""OID_PROMOCION""
		                                    , pr.""NOMBRE"" AS ""PROMOCION""
		                                    , a.""N_EXPEDIENTE"" AS ""EXP_ALUMNO""
		                                    , a.""CODIGO"" AS ""CODIGO_ALUMNO""
		                                    , a.""NOMBRE"" AS ""NOMBRE_ALUMNO""
		                                    , a.""APELLIDOS"" AS ""APELLIDO_ALUMNO""
		                                    , m.""TEXTO"" AS ""MODULO""
		                                    , m.""OID"" AS ""OID_MODULO""
		                                    , a.""OID"" AS ""OID_ALUMNO""
		                                    , COUNT(cp.""OID"") AS ""DURACION""
		                                    , QUERY2.""TOTAL"" AS ""TOTAL""    
	                                    FROM (	SELECT PE.""OID"" AS ""PLAN2""
			                                        , MOD.""TEXTO"" AS ""MODULO2""
			                                        , COUNT(C.""OID"") AS ""TOTAL""        
		                                        FROM " + pe + @" AS PE        
		                                        INNER JOIN " + ct + @" AS C ON ( C.""OID_PLAN"" = PE.""OID"")        
		                                        INNER JOIN " + mod + @" AS MOD ON ( C.""OID_MODULO"" = MOD.""OID"")        
		                                        GROUP BY ""PLAN2"", ""MODULO2""        ) AS QUERY2, " + ap + @" as ap    
	                                    INNER JOIN " + al + @" as a ON (a.""OID"" = ap.""OID_ALUMNO"")     
	                                    INNER JOIN " + pa + @" as p ON (p.""OID"" = ap.""OID_PARTE"")     
	                                    INNER JOIN " + h + @" as h ON h.""OID"" = p.""OID_HORARIO""   
	                                    INNER JOIN " + apr + @" as apromo ON (apromo.""OID_ALUMNO"" = a.""OID"")    
	                                    INNER JOIN " + pr + @" as pr ON (pr.""OID"" = apromo.""OID_PROMOCION"")     
	                                    INNER JOIN " + pe + @" as pl ON (pl.""OID"" = pr.""OID_PLAN"" AND h.""OID_PROMOCION"" = pr.""OID"")     
	                                    INNER JOIN " + cp + @" as cp ON (p.""OID"" = cp.""OID_PARTE"")     
	                                    INNER JOIN " + ct + @" as ct ON  (ct.""OID"" = cp.""OID_CLASE"")     
	                                    INNER JOIN " + mod + @" as m ON (m.""OID"" = ct.""OID_MODULO"")     
	                                    WHERE ap.""FALTA"" = 'true' AND ap.""RECUPERADA"" = 'false' AND cp.""TIPO"" = " + (long)ETipoClase.Teorica + @" AND ""PLAN2"" = pl.""OID"" AND ""MODULO2"" = m.""TEXTO""    
	                                    GROUP BY pr.""OID"", ""PROMOCION"", ""EXP_ALUMNO"", ""CODIGO_ALUMNO"", ""NOMBRE_ALUMNO"", ""APELLIDO_ALUMNO"", ""MODULO"", ""TOTAL"", m.""OID"", a.""OID""    

	                                    UNION    

	                                    SELECT pr.""OID"" AS ""OID_PROMOCION""
		                                    , pr.""NOMBRE"" AS ""PROMOCION""
		                                    , a.""N_EXPEDIENTE"" AS ""EXP_ALUMNO""
		                                    , a.""CODIGO"" AS ""CODIGO_ALUMNO""
		                                    , a.""NOMBRE"" AS ""NOMBRE_ALUMNO""
		                                    , a.""APELLIDOS"" AS ""APELLIDO_ALUMNO""
		                                    , m.""TEXTO"" AS ""MODULO""
		                                    , m.""OID"" AS ""OID_MODULO""
		                                    , a.""OID"" AS ""OID_ALUMNO""
		                                    , 0 AS ""DURACION""
		                                    , QUERY2.""TOTAL"" AS ""TOTAL""    
	                                    FROM (	SELECT PE.""OID"" AS ""PLAN2""
			                                        , MOD.""TEXTO"" AS ""MODULO2""
			                                        , COUNT(C.""OID"") AS ""TOTAL""        
		                                        FROM " + pe + @" AS PE        
		                                        INNER JOIN " + ct + @" AS C ON ( C.""OID_PLAN"" = PE.""OID"")        
		                                        INNER JOIN " + mod + @" AS MOD ON ( C.""OID_MODULO"" = MOD.""OID"")        
		                                        GROUP BY ""PLAN2"", ""MODULO2""        ) AS QUERY2, " + al + @" as a 
	                                    INNER JOIN " + apr + @" as apromo ON (apromo.""OID_ALUMNO"" = a.""OID"")    
	                                    INNER JOIN " + pr + @" as pr ON (pr.""OID"" = apromo.""OID_PROMOCION"")     
	                                    INNER JOIN " + pe + @" as pl ON (pl.""OID"" = pr.""OID_PLAN"" )      
	                                    INNER JOIN " + ct + @" as ct ON  (ct.""OID_PLAN"" = pl.""OID"")     
	                                    INNER JOIN " + mod + @" as m ON (m.""OID"" = ct.""OID_MODULO"")     
	                                    WHERE a.""OID"" NOT IN (	SELECT ap.""OID_ALUMNO"" 
				                                    FROM " + ap + @" AS ap
				                                    INNER JOIN " + cp + @" AS cp2 ON cp2.""TIPO"" = " + (long)ETipoClase.Teorica + @" AND cp2.""OID_PARTE"" = ap.""OID_PARTE""
				                                    INNER JOIN " + ct + @" AS ct2 ON ct2.""OID"" = cp2.""OID_CLASE"" 
				                                    INNER JOIN " + mod + @" AS m2 ON m2.""OID"" = ct2.""OID_MODULO""
                                                    INNER JOIN " + pr + @" AS pr2 ON pr2.""OID_PLAN"" = ct2.""OID_PLAN""
				                                    WHERE pr2.""OID"" = pr.""OID"" AND m2.""OID"" = m.""OID"" AND ""FALTA"" = 'true' AND ""RECUPERADA"" = 'false') AND ""PLAN2"" = pl.""OID"" AND ""MODULO2"" = m.""TEXTO""    
	                                    GROUP BY pr.""OID"", ""PROMOCION"", ""EXP_ALUMNO"", ""CODIGO_ALUMNO"", ""NOMBRE_ALUMNO"", ""APELLIDO_ALUMNO"", ""MODULO"", ""TOTAL"", m.""OID"", a.""OID"") AS QUERY1 
                                INNER JOIN (	SELECT ""OID_ALUMNO""
			                                        , ""PROMOCION""
			                                        , ""DURACION"" AS ""DURACION_TOTAL""
			                                        , ""TOTAL"" AS ""TOTAL_CURSO""
			                                        , CAST(""DURACION"" / ""TOTAL"" * 100 as numeric(10,2)) AS ""PORC_TOTAL""    
		                                        FROM(	SELECT ""PROMOCION""
				                                            , SUM(""DURACION"") AS ""DURACION""
				                                            , SUM(""TOTAL"") AS ""TOTAL""
				                                            , CAST(SUM(""DURACION"") / SUM(""TOTAL"") * 100 as numeric(10,2)) AS ""PORC""
				                                            , ""OID_ALUMNO""        
			                                            FROM (	SELECT pr.""NOMBRE"" AS ""PROMOCION""
					                                                , a.""OID"" AS ""OID_ALUMNO""
					                                                , COUNT(cp.""OID"") AS ""DURACION""
					                                                , QUERY2.""TOTAL"" AS ""TOTAL""             
				                                                FROM (	SELECT PE.""OID"" AS ""PLAN2""
						                                                    , COUNT(C.""OID"") AS ""TOTAL""                 
					                                                    FROM " + pe + @" AS PE                 
					                                                    INNER JOIN " + ct + @" AS C ON ( C.""OID_PLAN"" = PE.""OID"")                 
					                                                    GROUP BY ""PLAN2"") AS QUERY2, " + ap + @" as ap             
				                                                INNER JOIN " + al + @" as a ON (a.""OID"" = ap.""OID_ALUMNO"")              
				                                                INNER JOIN " + pa + @" as p ON (p.""OID"" = ap.""OID_PARTE"")              
				                                                INNER JOIN " + h + @" as h ON h.""OID"" = p.""OID_HORARIO""           
				                                                INNER JOIN " + apr + @" as apromo ON (apromo.""OID_ALUMNO"" = a.""OID"")             
				                                                INNER JOIN " + pr + @" as pr ON (pr.""OID"" = apromo.""OID_PROMOCION"" AND h.""OID_PROMOCION"" = pr.""OID"")              
				                                                INNER JOIN " + pe + @" as pl ON (pl.""OID"" = pr.""OID_PLAN"")              
				                                                INNER JOIN " + cp + @" as cp ON (p.""OID"" = cp.""OID_PARTE"")              
				                                                INNER JOIN " + ct + @" as ct ON  (ct.""OID"" = cp.""OID_CLASE"")              
				                                                WHERE ap.""FALTA"" = 'TRUE' AND ap.""RECUPERADA"" = 'FALSE' AND cp.""TIPO"" = " + (long)ETipoClase.Teorica + @" AND ""PLAN2"" = pl.""OID""            
				                                                GROUP BY ""PROMOCION"", ""TOTAL"", a.""OID"" 
                                                                UNION
                                                                SELECT pr.""NOMBRE"" AS ""PROMOCION""
					                                                , a.""OID"" AS ""OID_ALUMNO""
					                                                , 0 AS ""DURACION""
					                                                , QUERY2.""TOTAL"" AS ""TOTAL""             
				                                                FROM (	SELECT PE.""OID"" AS ""PLAN2""
						                                                    , COUNT(C.""OID"") AS ""TOTAL""                 
					                                                    FROM " + pe + @" AS PE                 
					                                                    INNER JOIN " + ct + @" AS C ON ( C.""OID_PLAN"" = PE.""OID"")                 
					                                                    GROUP BY ""PLAN2"") AS QUERY2, " + al + @" as a               
				                                                INNER JOIN " + apr + @" as apromo ON (apromo.""OID_ALUMNO"" = a.""OID"")             
				                                                INNER JOIN " + pr + @" as pr ON (pr.""OID"" = apromo.""OID_PROMOCION"")              
				                                                INNER JOIN " + pe + @" as pl ON (pl.""OID"" = pr.""OID_PLAN"")               
				                                                INNER JOIN " + ct + @" as ct ON  (ct.""OID_PLAN"" = pl.""OID"")              
				                                                WHERE a.""OID"" NOT IN (	SELECT ap2.""OID_ALUMNO"" 
													                                        FROM " + ap + @" AS ap2													
                                                                                            INNER JOIN " + cp + @" AS cp2 ON cp2.""TIPO"" = 1 AND cp2.""OID_PARTE"" = ap2.""OID_PARTE""
													                                        INNER JOIN " + ct + @" AS ct2 ON ct2.""OID"" = cp2.""OID_CLASE"" 
													                                        INNER JOIN " + pr + @" AS pr2 ON pr2.""OID_PLAN"" = ct2.""OID_PLAN""
													                                        WHERE ""FALTA"" = 'true' AND ""RECUPERADA"" = 'false' AND pr2.""OID"" = pr.""OID"") AND ""PLAN2"" = pl.""OID""            
				                                                GROUP BY ""PROMOCION"", ""TOTAL"", a.""OID"") AS QUERY1         
			                                            GROUP BY ""PROMOCION"", ""OID_ALUMNO"" ) AS SUPER_QUERY    
		                                        GROUP BY ""PROMOCION"", ""OID_ALUMNO"", ""DURACION_TOTAL"", ""TOTAL_CURSO""    
		                                        ORDER BY ""PROMOCION"") AS SUPER_QUERY ON (SUPER_QUERY.""OID_ALUMNO"" = QUERY1.""OID_ALUMNO"" AND SUPER_QUERY.""PROMOCION"" = QUERY1.""PROMOCION"") ";
                if (oid_promocion != 0)
                    query += " WHERE QUERY1.\"OID_PROMOCION\" = " + (long)oid_promocion;
                query += @" GROUP BY QUERY1.""OID_PROMOCION"", QUERY1.""PROMOCION"", ""EXP_ALUMNO"", ""CODIGO_ALUMNO"", ""NOMBRE_ALUMNO"", ""APELLIDO_ALUMNO"", ""MODULO"", ""OID_MODULO"", QUERY1.""OID_ALUMNO"", ""DURACION_TOTAL"", ""TOTAL_CURSO"", ""PORC_TOTAL"" ORDER BY QUERY1.""PROMOCION"", ""EXP_ALUMNO"", ""MODULO""";*/

                string pre_query = @"SELECT ""OID_PROMOCION""
                                            , ""PROMOCION""
                                            , ""EXP_ALUMNO""
                                            , ""CODIGO_ALUMNO""
                                            , ""NOMBRE_ALUMNO""
                                            , ""APELLIDO_ALUMNO""
                                            , ""OID_ALUMNO""
                                            , ""MODULO""
                                            , ""OID_MODULO""
                                            , SUM(""TOTAL"") AS ""TOTAL""
                                            , CP.""CLASES_PLAN"" + CT.""CLASES_PLAN"" AS ""TOTAL_CURSO""
                                            , SUM(""DURACION"") AS ""DURACION""
                                            , SUM(""DURACION_TOTAL"") AS ""DURACION_TOTAL""
                                    FROM ( ";

                string union_query = @"UNION 

                                    SELECT DISTINCT PR.""OID"" AS ""OID_PROMOCION""
	                                    , PR.""NOMBRE"" AS ""PROMOCION""
	                                    , A.""N_EXPEDIENTE"" AS ""EXP_ALUMNO""
	                                    , A.""CODIGO"" AS ""CODIGO_ALUMNO""
	                                    , A.""NOMBRE"" AS ""NOMBRE_ALUMNO""
	                                    , A.""APELLIDOS"" AS ""APELLIDO_ALUMNO""
	                                    , A.""OID"" AS ""OID_ALUMNO""
	                                    , M.""TEXTO"" AS ""MODULO""
	                                    , M.""OID"" AS ""OID_MODULO""
	                                    , C1.""CLASES_MODULO"" AS ""TOTAL""
	                                    , COALESCE(C3.""FALTAS_MODULO"", 0) AS ""DURACION""
	                                    , COALESCE(C4.""FALTAS_PLAN"", 0) AS ""DURACION_TOTAL""
                                        , COALESCE(C5.""RECUPERACIONES_MODULO"", 0) AS ""RECUPERACIONES""
                                        , 2 AS ""TIPO""
	                                    , PE.""OID"" AS ""OID_PLAN""
                                FROM " + al + @" AS A
                                INNER JOIN " + apr + @" AS APR ON APR.""OID_ALUMNO"" = A.""OID""
                                INNER JOIN " + pr + @" AS PR ON PR.""OID"" = APR.""OID_PROMOCION""
                                INNER JOIN " + pe + @" AS PE ON PE.""OID"" = PR.""OID_PLAN""
                                INNER JOIN " + cpr + @" AS CT ON CT.""OID_PLAN"" = PE.""OID""
                                INNER JOIN " + mod + @" AS M ON M.""OID"" = CT.""OID_MODULO""
                                INNER JOIN (	SELECT COUNT(""OID"") AS ""CLASES_MODULO""
			                                        , ""OID_PLAN""
			                                        , ""OID_MODULO""
		                                        FROM " + cpr + @"
		                                        GROUP BY ""OID_PLAN"", ""OID_MODULO"") AS C1 ON C1.""OID_PLAN"" = PE.""OID"" AND C1.""OID_MODULO"" = M.""OID""
                                LEFT JOIN (	SELECT COUNT(CT.""OID"") AS ""FALTAS_MODULO""
			                                    , CT.""OID_MODULO""
			                                    , CT.""OID_PLAN""
			                                    , AP.""OID_ALUMNO""
		                                    FROM " + ap + @" AS AP
		                                    INNER JOIN " + pa + @" AS PA ON PA.""OID"" = AP.""OID_PARTE""
		                                    INNER JOIN " + cp + @" AS CP ON CP.""OID_PARTE"" = PA.""OID"" AND CP.""TIPO"" = " + (long)ETipoClase.Practica + @"
		                                    INNER JOIN " + cpr + @" AS CT ON CT.""OID"" = CP.""OID_CLASE""
		                                    WHERE AP.""FALTA"" = 'TRUE'
		                                    GROUP BY AP.""OID_ALUMNO"", CT.""OID_MODULO"", CT.""OID_PLAN"") AS C3 ON C3.""OID_ALUMNO"" = A.""OID"" AND C3.""OID_PLAN"" = PE.""OID"" AND C3.""OID_MODULO"" = M.""OID""
                                LEFT JOIN (	SELECT COUNT(CT.""OID"") AS ""FALTAS_PLAN""
			                                    , CT.""OID_PLAN""
			                                    , AP.""OID_ALUMNO""
		                                    FROM " + ap + @" AS AP
		                                    INNER JOIN " + pa + @" AS PA ON PA.""OID"" = AP.""OID_PARTE""
		                                    INNER JOIN " + cp + @" AS CP ON CP.""OID_PARTE"" = PA.""OID"" AND CP.""TIPO"" = " + (long)ETipoClase.Practica + @"
		                                    INNER JOIN " + cpr + @" AS CT ON CT.""OID"" = CP.""OID_CLASE""
		                                    WHERE AP.""FALTA"" = 'TRUE' AND AP.""RECUPERADA"" = 'FALSE'
		                                    GROUP BY AP.""OID_ALUMNO"", CT.""OID_PLAN"") AS C4 ON C4.""OID_ALUMNO"" = A.""OID"" AND C4.""OID_PLAN"" = PE.""OID""
                                LEFT JOIN (	SELECT COUNT(CT.""OID"") AS ""RECUPERACIONES_MODULO""
			                                    , CT.""OID_MODULO""
			                                    , CT.""OID_PLAN""
			                                    , AP.""OID_ALUMNO""
		                                    FROM " + ap + @" AS AP
		                                    INNER JOIN " + pa + @" AS PA ON PA.""OID"" = AP.""OID_PARTE""
		                                    INNER JOIN " + cp + @" AS CP ON CP.""OID_PARTE"" = PA.""OID"" AND CP.""TIPO"" = " + (long)ETipoClase.Practica + @"
		                                    INNER JOIN " + cpr + @" AS CT ON CT.""OID"" = CP.""OID_CLASE""
		                                    WHERE AP.""FALTA"" = 'TRUE' AND AP.""RECUPERADA"" = 'TRUE'
		                                    GROUP BY AP.""OID_ALUMNO"", CT.""OID_MODULO"", CT.""OID_PLAN"") AS C5 ON C5.""OID_ALUMNO"" = A.""OID"" AND C5.""OID_PLAN"" = PE.""OID"" AND C5.""OID_MODULO"" = M.""OID""
                                WHERE A.""OID"" = " + oid_alumno + @") AS X ";

                string query = pre_query + @"SELECT DISTINCT PR.""OID"" AS ""OID_PROMOCION""
	                                , PR.""NOMBRE"" AS ""PROMOCION""
	                                , A.""N_EXPEDIENTE"" AS ""EXP_ALUMNO""
	                                , A.""CODIGO"" AS ""CODIGO_ALUMNO""
	                                , A.""NOMBRE"" AS ""NOMBRE_ALUMNO""
	                                , A.""APELLIDOS"" AS ""APELLIDO_ALUMNO""
	                                , A.""OID"" AS ""OID_ALUMNO""
	                                , M.""TEXTO"" AS ""MODULO""
	                                , M.""OID"" AS ""OID_MODULO""
	                                , C1.""CLASES_MODULO"" AS ""TOTAL""
	                                , COALESCE(C3.""FALTAS_MODULO"", 0) AS ""DURACION""
	                                , COALESCE(C4.""FALTAS_PLAN"", 0) AS ""DURACION_TOTAL""
                                    , COALESCE(C5.""RECUPERACIONES_MODULO"", 0) AS ""RECUPERACIONES""
                                    , 1 AS ""TIPO"" 
	                                , PE.""OID"" AS ""OID_PLAN""
                                FROM " + al + @" AS A
                                INNER JOIN " + apr + @" AS APR ON APR.""OID_ALUMNO"" = A.""OID""
                                INNER JOIN " + pr + @" AS PR ON PR.""OID"" = APR.""OID_PROMOCION""
                                INNER JOIN " + pe + @" AS PE ON PE.""OID"" = PR.""OID_PLAN""
                                INNER JOIN " + ct + @" AS CT ON CT.""OID_PLAN"" = PE.""OID""
                                INNER JOIN " + mod + @" AS M ON M.""OID"" = CT.""OID_MODULO""
                                INNER JOIN (	SELECT COUNT(""OID"") AS ""CLASES_MODULO""
			                                        , ""OID_PLAN""
			                                        , ""OID_MODULO""
		                                        FROM " + ct + @"
		                                        GROUP BY ""OID_PLAN"", ""OID_MODULO"") AS C1 ON C1.""OID_PLAN"" = PE.""OID"" AND C1.""OID_MODULO"" = M.""OID""
                                LEFT JOIN (	SELECT COUNT(CT.""OID"") AS ""FALTAS_MODULO""
			                                    , CT.""OID_MODULO""
			                                    , CT.""OID_PLAN""
			                                    , AP.""OID_ALUMNO""
		                                    FROM " + ap + @" AS AP
		                                    INNER JOIN " + pa + @" AS PA ON PA.""OID"" = AP.""OID_PARTE""
		                                    INNER JOIN " + cp + @" AS CP ON CP.""OID_PARTE"" = PA.""OID"" AND CP.""TIPO"" = " + (long)ETipoClase.Teorica + @"
		                                    INNER JOIN " + ct + @" AS CT ON CT.""OID"" = CP.""OID_CLASE""
		                                    WHERE AP.""FALTA"" = 'TRUE'
		                                    GROUP BY AP.""OID_ALUMNO"", CT.""OID_MODULO"", CT.""OID_PLAN"") AS C3 ON C3.""OID_ALUMNO"" = A.""OID"" AND C3.""OID_PLAN"" = PE.""OID"" AND C3.""OID_MODULO"" = M.""OID""
                                LEFT JOIN (	SELECT COUNT(CT.""OID"") AS ""FALTAS_PLAN""
			                                    , CT.""OID_PLAN""
			                                    , AP.""OID_ALUMNO""
		                                    FROM " + ap + @" AS AP
		                                    INNER JOIN " + pa + @" AS PA ON PA.""OID"" = AP.""OID_PARTE""
		                                    INNER JOIN " + cp + @" AS CP ON CP.""OID_PARTE"" = PA.""OID"" AND CP.""TIPO"" = " + (long)ETipoClase.Teorica + @"
		                                    INNER JOIN " + ct + @" AS CT ON CT.""OID"" = CP.""OID_CLASE""
		                                    WHERE AP.""FALTA"" = 'TRUE' AND AP.""RECUPERADA"" = 'FALSE'
		                                    GROUP BY AP.""OID_ALUMNO"", CT.""OID_PLAN"") AS C4 ON C4.""OID_ALUMNO"" = A.""OID"" AND C4.""OID_PLAN"" = PE.""OID""
                                LEFT JOIN (	SELECT COUNT(CT.""OID"") AS ""RECUPERACIONES_MODULO""
			                                    , CT.""OID_MODULO""
			                                    , CT.""OID_PLAN""
			                                    , AP.""OID_ALUMNO""
		                                    FROM " + ap + @" AS AP
		                                    INNER JOIN " + pa + @" AS PA ON PA.""OID"" = AP.""OID_PARTE""
		                                    INNER JOIN " + cp + @" AS CP ON CP.""OID_PARTE"" = PA.""OID"" AND CP.""TIPO"" = " + (long)ETipoClase.Teorica + @"
		                                    INNER JOIN " + ct + @" AS CT ON CT.""OID"" = CP.""OID_CLASE""
		                                    WHERE AP.""FALTA"" = 'TRUE' AND AP.""RECUPERADA"" = 'TRUE'
		                                    GROUP BY AP.""OID_ALUMNO"", CT.""OID_MODULO"", CT.""OID_PLAN"") AS C5 ON C5.""OID_ALUMNO"" = A.""OID"" AND C5.""OID_PLAN"" = PE.""OID"" AND C5.""OID_MODULO"" = M.""OID""
                                WHERE A.""OID"" = " + oid_alumno + @"
                                " + union_query + @"
                                INNER JOIN (	SELECT COUNT(""OID"") AS ""CLASES_PLAN""
			                                        , ""OID_PLAN""
		                                        FROM " + ct + @" 
		                                        GROUP BY ""OID_PLAN"") AS CT ON CT.""OID_PLAN"" = X.""OID_PLAN""
                                INNER JOIN (	SELECT COUNT(""OID"") AS ""CLASES_PLAN""
			                                        , ""OID_PLAN""
		                                        FROM " + cpr + @" 
		                                        GROUP BY ""OID_PLAN"") AS CP ON CP.""OID_PLAN"" = X.""OID_PLAN""
                                GROUP BY ""OID_PROMOCION"", ""PROMOCION"", ""EXP_ALUMNO"", ""CODIGO_ALUMNO"", ""NOMBRE_ALUMNO"", ""APELLIDO_ALUMNO"", ""OID_ALUMNO"", ""MODULO"", ""OID_MODULO"", ""TOTAL_CURSO""
                                ORDER BY ""PROMOCION"", ""CODIGO_ALUMNO"", ""MODULO""";
                return query;
            }

        #endregion
    }
}

