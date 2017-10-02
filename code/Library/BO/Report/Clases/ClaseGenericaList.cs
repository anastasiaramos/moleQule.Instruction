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
    public class ClaseGenericaList : ReadOnlyListBaseEx<ClaseGenericaList, ClaseGenericaInfo>
	{	

		#region Business Methods
			
		#endregion
		 
		#region Factory Methods

        private ClaseGenericaList() { }

        public static ClaseGenericaList NewList() { return new ClaseGenericaList(); }
		
		/// <summary>
		/// Retrieve the complete list from db
		/// </summary>
		/// <param name="get_childs">retrieving the childs</param>
		/// <returns></returns>
		public static ClaseGenericaList GetList(ClaseTeoricaList teoricas
                                            , ClasePracticaList practicas
                                            , ClaseExtraList extras)
		{
            ClaseGenericaList list = new ClaseGenericaList();
            
            list.IsReadOnly = false;

            foreach (ClaseTeoricaInfo item in teoricas)
            {
                if (item.EEstadoClase != EEstadoClase.Impartida)
                    list.AddItem(new ClaseGenericaInfo(item));
            }
            foreach (ClasePracticaInfo item in practicas)
            {
                if (item.EEstadoClase != EEstadoClase.Impartida)
                    list.AddItem(new ClaseGenericaInfo(item));
            }
            foreach (ClaseExtraInfo item in extras)
            {
                if (item.Estado != 3)
                    list.AddItem(new ClaseGenericaInfo(item));
            }

            list.IsReadOnly = true;
			
			return list;
		}

        public static ClaseGenericaList GetList()
        {
            return new ClaseGenericaList();
        }
		
		/// <summary>
		/// Devuelve una lista de todos los elementos
		/// </summary>
		/// <returns>Lista de elementos</returns>
		public static ClaseGenericaList GetList(CriteriaEx criteria)
		{
			return ClaseGenericaList.RetrieveList(typeof(ClaseGenerica), AppContext.ActiveSchema.Code, criteria);
		}
		
		/// <summary>
		/// Builds a ClaseGenericaList from a IList<!--<ClaseGenericaInfo>-->.
		/// Doesnt retrieve child data from DB.
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public static ClaseGenericaList GetList(IList<ClaseGenericaInfo> list)
		{
			ClaseGenericaList flist = new ClaseGenericaList();
			
			if (list.Count > 0)
			{
				flist.IsReadOnly = false;
				
				foreach (ClaseGenericaInfo item in list)
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
		public static SortedBindingList<ClaseGenericaInfo> GetSortedList (string sortProperty, ListSortDirection sortDirection)
		{
			SortedBindingList<ClaseGenericaInfo> sortedList = new SortedBindingList<ClaseGenericaInfo>(GetList());
			
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
        public static SortedBindingList<ClaseGenericaInfo> GetSortedList(string sortProperty, ListSortDirection sortDirection, bool childs)
        {
            SortedBindingList<ClaseGenericaInfo> sortedList = new SortedBindingList<ClaseGenericaInfo>(GetList());

            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }
		
		/// <summary>
        /// Builds a ClaseGenericaList from a IList<!--<ClaseGenerica>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>ClaseGenericaList</returns>
        public static ClaseGenericaList GetList(IList<ClaseGenerica> list)
        {
            ClaseGenericaList flist = new ClaseGenericaList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (ClaseGenerica item in list)
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
							this.AddItem(ClaseGenericaInfo.Get(reader, Childs));
						}
						IsReadOnly = true;
					}
					else 
					{
						IList list = criteria.List();
						
						if (list.Count > 0)
						{
							IsReadOnly = false;
							foreach(ClaseGenerica item in list)
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

