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
    public class EstadisticaExamenList : ReadOnlyListBaseEx<EstadisticaExamenList, EstadisticaExamenInfo>
	{	

		#region Business Methods
			
		#endregion
		 
		#region Factory Methods

        private EstadisticaExamenList() { }

        public static EstadisticaExamenList NewList() { return new EstadisticaExamenList(); }
		
		/// <summary>
		/// Retrieve the complete list from db
		/// </summary>
		/// <param name="get_childs">retrieving the childs</param>
		/// <returns></returns>
		public static EstadisticaExamenList GetList(long oid_examen, bool childs)
		{
			CriteriaEx criteria = EstadisticaExamen.GetCriteria(EstadisticaExamen.OpenSession());
			criteria.Childs = childs;
			
			//No criteria. Retrieve all de List
			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = EstadisticaExamenList.SELECT_PORCENTAJE_FALLOS(oid_examen);
			EstadisticaExamenList list = DataPortal.Fetch<EstadisticaExamenList>(criteria);
			
			CloseSession(criteria.SessionCode);
			return list;
		}

        public static EstadisticaExamenList GetList(Examen examen)
        {
            EstadisticaExamenList list = new EstadisticaExamenList();

            int total_alumnos = 0;
            Hashtable cont_fallos = new Hashtable();

            foreach (PreguntaExamen preg in examen.PreguntaExamens)
            {
                EstadisticaExamen item = new EstadisticaExamen();

                item.Oid = preg.Oid;
                item.NumeroPregunta = preg.Orden;
                item.TotalFallos = 0;
                item.PorcentajeFallos = 0;
                item.Anulada = preg.Anulada;
                item.NumeroPreguntaBanco = preg.NPregunta;
                item.Nivel = preg.Nivel;
                item.Tema = preg.Tema;
                
                cont_fallos.Add(preg.Orden, item);
            }

            foreach (Alumno_Examen alumno in examen.Alumnos)
            {
                if (alumno.Presentado)
                {
                    total_alumnos++;
                    foreach (Respuesta_Alumno_Examen resp in alumno.Respuestas)
                    {
                        PreguntaExamen preg = examen.PreguntaExamens.GetItem(resp.OidPreguntaExamen);

                        if (!preg.Anulada)
                        {
                            if (!resp.Correcta)
                                ((EstadisticaExamen)cont_fallos[resp.Orden]).TotalFallos++;
                        }
                    }
                }
            }

            list.IsReadOnly = false;

            foreach (PreguntaExamen preg in examen.PreguntaExamens)
            {
                EstadisticaExamen item = (EstadisticaExamen)cont_fallos[preg.Orden];

                if (!preg.Anulada)
                    item.PorcentajeFallos = total_alumnos != 0 ? Decimal.Round((decimal)item.TotalFallos / total_alumnos, 2) * 100 : 0;

                list.Add(item.GetInfo());
            }

            list.IsReadOnly = true;

            return list;
        }
		
		/// <summary>
		/// Default call for GetList(bool get_childs)
		/// </summary>
		/// <returns></returns>
		public static EstadisticaExamenList GetList(long oid_examen)
		{
			return EstadisticaExamenList.GetList(oid_examen, true);
		}

        /// <summary>
        /// Default call for GetList(bool get_childs)
        /// </summary>
        /// <returns></returns>
        public static EstadisticaExamenList GetList()
        {
            return EstadisticaExamenList.GetList(-1, true);
        }

        /// <summary>
        /// Default call for GetList(bool get_childs)
        /// </summary>
        /// <returns></returns>
        public static EstadisticaExamenList GetList(bool get_childs)
        {
            return EstadisticaExamenList.GetList(-1, get_childs);
        }
		
		/// <summary>
		/// Devuelve una lista de todos los elementos
		/// </summary>
		/// <returns>Lista de elementos</returns>
		public static EstadisticaExamenList GetList(CriteriaEx criteria)
		{
			return EstadisticaExamenList.RetrieveList(typeof(EstadisticaExamen), AppContext.ActiveSchema.Code, criteria);
		}
		
		/// <summary>
		/// Builds a EstadisticaExamenList from a IList<!--<EstadisticaExamenInfo>-->.
		/// Doesnt retrieve child data from DB.
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public static EstadisticaExamenList GetList(IList<EstadisticaExamenInfo> list)
		{
			EstadisticaExamenList flist = new EstadisticaExamenList();
			
			if (list.Count > 0)
			{
				flist.IsReadOnly = false;
				
				foreach (EstadisticaExamenInfo item in list)
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
		public static SortedBindingList<EstadisticaExamenInfo> GetSortedList (string sortProperty, ListSortDirection sortDirection)
		{
			SortedBindingList<EstadisticaExamenInfo> sortedList = new SortedBindingList<EstadisticaExamenInfo>(GetList());
			
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
        public static SortedBindingList<EstadisticaExamenInfo> GetSortedList(string sortProperty, ListSortDirection sortDirection, bool childs)
        {
            SortedBindingList<EstadisticaExamenInfo> sortedList = new SortedBindingList<EstadisticaExamenInfo>(GetList(childs));

            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }
		
		/// <summary>
        /// Builds a EstadisticaExamenList from a IList<!--<EstadisticaExamen>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>EstadisticaExamenList</returns>
        public static EstadisticaExamenList GetList(IList<EstadisticaExamen> list)
        {
            EstadisticaExamenList flist = new EstadisticaExamenList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (EstadisticaExamen item in list)
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
							this.AddItem(EstadisticaExamenInfo.Get(reader, Childs));
						}
						IsReadOnly = true;
					}
					else 
					{
						IList list = criteria.List();
						
						if (list.Count > 0)
						{
							IsReadOnly = false;
							foreach(EstadisticaExamen item in list)
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

            private static string SELECT_PORCENTAJE_FALLOS(long oid_examen)
            {
                string examen = nHManager.Instance.GetSQLTable(typeof(ExamenRecord));
                string pregunta_examen = nHManager.Instance.GetSQLTable(typeof(PreguntaExamenRecord));
                string respuesta = nHManager.Instance.GetSQLTable(typeof(Respuesta_Alumno_ExamenRecord));
                string alumno_examen = nHManager.Instance.GetSQLTable(typeof(AlumnoExamenRecord));
                string tema = nHManager.Instance.GetSQLTable(typeof(TemaRecord));
                string pregunta = nHManager.Instance.GetSQLTable(typeof(PreguntaRecord));

                string query = 
                    "SELECT P.\"OID\" AS \"OID\"" +
	                "   , P.\"ORDEN\" AS \"NUMERO_PREGUNTA\"" +
                    "	, COUNT(P.\"ORDEN\") AS \"TOTAL_FALLOS\"" +
                    "	, CASE WHEN A.\"PRESENTADOS\" > 0 THEN cast(COUNT(P.\"ORDEN\")AS numeric(10,2))/A.\"PRESENTADOS\" * 100 ELSE 0 END AS \"PORCENTAJE_FALLOS\"" +
                    "	, P.\"ANULADA\" AS \"ANULADA\"" +
                    "	, PR.\"CODIGO\" AS \"NUMERO_PREGUNTA_BANCO\"" +
	                "    , PR.\"NIVEL\" AS \"NIVEL\"" +
	                "    , T.\"CODIGO\" || ' ' || T.\"NOMBRE\" AS \"TEMA\"" +
                    " FROM " + examen + "  AS E" +
                    " INNER JOIN " + pregunta_examen + "  AS P ON P.\"OID_EXAMEN\" = E.\"OID\"" +
                    " INNER JOIN " + respuesta + "  AS R ON R.\"OID_PREGUNTA_EXAMEN\" = P.\"OID\"" +
                    " INNER JOIN (	SELECT A.\"OID_EXAMEN\", COUNT(A.\"OID\") AS \"PRESENTADOS\"" +
		            "        FROM " + alumno_examen + "  AS A" +
		            "        WHERE A.\"PRESENTADO\" = TRUE" +
		            "        GROUP BY A.\"OID_EXAMEN\")" +
	                "    AS A ON A.\"OID_EXAMEN\" = E.\"OID\"" +
                    " INNER JOIN " + pregunta + "  AS PR ON PR.\"OID\" = P.\"OID_PREGUNTA\"" +
                    " INNER JOIN " + tema + "  AS T ON T.\"OID\" = PR.\"OID_TEMA\"" +
                    " WHERE P.\"ANULADA\" = FALSE AND R.\"CORRECTA\" = FALSE AND E.\"OID\" = " + oid_examen.ToString() +
                    " GROUP BY P.\"OID\", P.\"ORDEN\", A.\"PRESENTADOS\", P.\"ANULADA\", PR.\"CODIGO\", PR.\"NIVEL\", T.\"CODIGO\", T.\"NOMBRE\"" +
                    " UNION" +
                    " SELECT P.\"OID\" AS \"OID\"" +
	                "    ,  P.\"ORDEN\" AS \"NUMERO_PREGUNTA\"" +
	                "    , 0 AS \"TOTAL_FALLOS\"" +
	                "    , 0 AS \"PORCENTAJE_FALLOS\"" +
	                "    , P.\"ANULADA\" AS \"ANULADA\"" +
	                "    , PR.\"CODIGO\" AS \"NUMERO_PREGUNTA_BANCO\"" +
	                "    , PR.\"NIVEL\" AS \"NIVEL\"" +
	                "    , T.\"CODIGO\" || ' ' || T.\"NOMBRE\" AS \"TEMA\"" +
                    " FROM " + examen + "  AS E" +
                    " INNER JOIN " + pregunta_examen + "  AS P ON P.\"OID_EXAMEN\" = E.\"OID\"" +
                    " INNER JOIN " + pregunta + "  AS PR ON PR.\"OID\" = P.\"OID_PREGUNTA\"" +
                    " INNER JOIN " + tema + "  AS T ON T.\"OID\" = PR.\"OID_TEMA\"" +
                    " WHERE P.\"ANULADA\" = FALSE AND E.\"OID\" = " + oid_examen.ToString() +
	                "    AND P.\"OID\" NOT IN (	SELECT P.\"OID\" " +
				    "                FROM " + pregunta_examen + "  AS P" +
				    "                INNER JOIN " + respuesta + "  AS R ON R.\"OID_PREGUNTA_EXAMEN\" = P.\"OID\"" +
				    "                WHERE R.\"CORRECTA\" = FALSE)" +
                    " GROUP BY P.\"OID\", P.\"ORDEN\", P.\"ANULADA\", PR.\"CODIGO\", PR.\"NIVEL\", T.\"CODIGO\", T.\"NOMBRE\"" +
                    " UNION " +
                    " SELECT P.\"OID\" AS \"OID\"" +
	                "    ,  P.\"ORDEN\" AS \"NUMERO_PREGUNTA\"" +
	                "    , 0 AS \"TOTAL_FALLOS\"" +
	                "    , 0 AS \"PORCENTAJE_FALLOS\"" +
	                "    , P.\"ANULADA\" AS \"ANULADA\"" +
	                "    , PR.\"CODIGO\" AS \"NUMERO_PREGUNTA_BANCO\"" +
	                "    , PR.\"NIVEL\" AS \"NIVEL\"" +
	                "    , T.\"CODIGO\" || ' ' || T.\"NOMBRE\" AS \"TEMA\"" +
                    " FROM " + examen + "  AS E " +
                    " INNER JOIN " + pregunta_examen + "  AS P ON P.\"OID_EXAMEN\" = E.\"OID\"" +
                    " INNER JOIN " + pregunta + "  AS PR ON PR.\"OID\" = P.\"OID_PREGUNTA\"" +
                    " INNER JOIN " + tema + "  AS T ON T.\"OID\" = PR.\"OID_TEMA\"" +
                    " WHERE P.\"ANULADA\" = TRUE AND E.\"OID\" = " + oid_examen.ToString() +
                    " GROUP BY P.\"OID\", P.\"ORDEN\", P.\"ANULADA\", PR.\"CODIGO\", PR.\"NIVEL\", T.\"CODIGO\", T.\"NOMBRE\"" +
                    " ORDER BY \"NUMERO_PREGUNTA\"";

                return query;
            }

        #endregion
    }
}

