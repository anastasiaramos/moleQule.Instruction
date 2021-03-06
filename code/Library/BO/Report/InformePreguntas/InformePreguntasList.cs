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
    public class InformePreguntasList : ReadOnlyListBaseEx<InformePreguntasList, InformePreguntasInfo>
	{	

		#region Business Methods
			
		#endregion
		 
		#region Factory Methods

        private InformePreguntasList() { }

        public static InformePreguntasList NewList() { return new InformePreguntasList(); }
		
		/// <summary>
		/// Retrieve the complete list from db
		/// </summary>
		/// <param name="get_childs">retrieving the childs</param>
		/// <returns></returns>
		public static InformePreguntasList GetList(string lista_preguntas)
		{
            CriteriaEx criteria = ParteAsistencia.GetCriteria(ParteAsistencia.OpenSession());
			criteria.Childs = false;
			
			//No criteria. Retrieve all de List
            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = InformePreguntasList.SELECT_INFORME_PREGUNTAS(lista_preguntas);
			InformePreguntasList list = DataPortal.Fetch<InformePreguntasList>(criteria);
			
			CloseSession(criteria.SessionCode);
			return list;
		}

		/// <summary>
		/// Retrieve the complete list from db
		/// </summary>
		/// <param name="get_childs">retrieving the childs</param>
		/// <returns></returns>
        public static InformePreguntasList GetList() { return GetList(string.Empty); }
		
		/// <summary>
		/// Devuelve una lista de todos los elementos
		/// </summary>
		/// <returns>Lista de elementos</returns>
		public static InformePreguntasList GetList(CriteriaEx criteria)
		{
			return InformePreguntasList.RetrieveList(typeof(InformePreguntas), AppContext.ActiveSchema.Code, criteria);
		}
		
		/// <summary>
		/// Builds a InformePreguntasList from a IList<!--<InformePreguntasInfo>-->.
		/// Doesnt retrieve child data from DB.
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public static InformePreguntasList GetList(IList<InformePreguntasInfo> list)
		{
			InformePreguntasList flist = new InformePreguntasList();
			
			if (list.Count > 0)
			{
				flist.IsReadOnly = false;
				
				foreach (InformePreguntasInfo item in list)
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
		public static SortedBindingList<InformePreguntasInfo> GetSortedList (string sortProperty, ListSortDirection sortDirection)
		{
			SortedBindingList<InformePreguntasInfo> sortedList = new SortedBindingList<InformePreguntasInfo>(GetList());
			
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
        public static SortedBindingList<InformePreguntasInfo> GetSortedList(string sortProperty, ListSortDirection sortDirection, bool childs)
        {
            SortedBindingList<InformePreguntasInfo> sortedList = new SortedBindingList<InformePreguntasInfo>(GetList());

            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }
		
		/// <summary>
        /// Builds a InformePreguntasList from a IList<!--<InformePreguntas>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>InformePreguntasList</returns>
        public static InformePreguntasList GetList(IList<InformePreguntas> list)
        {
            InformePreguntasList flist = new InformePreguntasList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (InformePreguntas item in list)
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
							this.AddItem(InformePreguntasInfo.Get(reader, Childs));
						}
						IsReadOnly = true;
					}
					else 
					{
						IList list = criteria.List();
						
						if (list.Count > 0)
						{
							IsReadOnly = false;
							foreach(InformePreguntas item in list)
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

            private static string SELECT_INFORME_PREGUNTAS (string lista_preguntas)
            {
                string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
                string preguntas = nHManager.Instance.GetSQLTable(typeof(PreguntaRecord));
                string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
                string tema = nHManager.Instance.GetSQLTable(typeof(TemaRecord));

                string query = @"SELECT (M.""NUMERO"" || ' ' || M.""TEXTO"") AS ""MODULO"", CM.""MODULO_COUNT"" AS ""PREGUNTAS_MODULO"", 
	                                (S.""CODIGO"" || ' ' || S.""TEXTO"") AS ""SUBMODULO"", CS.""SUBMODULO_COUNT"" AS ""PREGUNTAS_SUBMODULO"",
	                                T.""NIVEL"", T.""DESARROLLO"", COUNT(P.""OID"") AS ""N_PREGUNTAS"",
                                    DMC.""DISPONIBLES_MODULO_COUNT"", DSC.""DISPONIBLES_SUBMODULO_COUNT"", DNC.""DISPONIBLES_NIVEL_COUNT"",
                                    P.""OID_MODULO"", P.""OID_SUBMODULO""
                                FROM " + preguntas + @" AS P
                                INNER JOIN " + modulo + @" AS M ON M.""OID"" = P.""OID_MODULO""
                                INNER JOIN " + submodulo + @" AS S ON S.""OID"" = P.""OID_SUBMODULO""
                                INNER JOIN " + tema + @" AS T ON T.""OID"" = P.""OID_TEMA""
                                INNER JOIN (	SELECT M1.""OID"", COUNT(M1.""OID"") AS ""MODULO_COUNT""
		                                FROM " + preguntas + @" AS P1 
		                                INNER JOIN " + modulo + @" AS M1 ON M1.""OID"" = P1.""OID_MODULO""
                                        WHERE P1.""ACTIVA"" = 'TRUE' AND P1.""OID"" IN " + lista_preguntas + @"
		                                GROUP BY M1.""OID"") AS CM ON CM.""OID"" = M.""OID""
                                INNER JOIN (	SELECT S2.""OID"", COUNT(S2.""OID"") AS ""SUBMODULO_COUNT""
		                                FROM " + preguntas + @" AS P2 
		                                INNER JOIN " + submodulo + @" AS S2 ON S2.""OID"" = P2.""OID_SUBMODULO""
                                        WHERE P2.""ACTIVA"" = 'TRUE' AND P2.""OID"" IN " + lista_preguntas + @"
		                                GROUP BY S2.""OID"") AS CS ON CS.""OID"" = S.""OID""
                                INNER JOIN (	SELECT M3.""OID"", COUNT(P3.""OID"") AS ""DISPONIBLES_MODULO_COUNT""
		                                FROM " + preguntas + @" AS P3 
		                                INNER JOIN " + modulo + @" AS M3 ON M3.""OID"" = P3.""OID_MODULO""
                                        WHERE P3.""FECHA_DISPONIBILIDAD"" <= '" + DateTime.Today.Date.ToString("yyyy-MM-dd") + @"' AND P3.""ACTIVA"" = 'TRUE' AND P3.""OID"" IN " + lista_preguntas + @" 
		                                GROUP BY M3.""OID"") AS DMC ON DMC.""OID"" = M.""OID""
                                INNER JOIN (	SELECT S4.""OID"", COUNT(P4.""OID"") AS ""DISPONIBLES_SUBMODULO_COUNT""
		                                FROM " + preguntas + @" AS P4 
		                                INNER JOIN " + submodulo + @" AS S4 ON S4.""OID"" = P4.""OID_SUBMODULO""
                                        WHERE P4.""FECHA_DISPONIBILIDAD"" <= '" + DateTime.Today.Date.ToString("yyyy-MM-dd") + @"' AND P4.""ACTIVA"" = 'TRUE' AND P4.""OID"" IN " + lista_preguntas + @"
		                                GROUP BY S4.""OID"") AS DSC ON DSC.""OID"" = S.""OID""
                                INNER JOIN (	SELECT S5.""OID"", T5.""NIVEL"",  COUNT(P5.""OID"") AS ""DISPONIBLES_NIVEL_COUNT""
		                                FROM " + preguntas + @" AS P5 
		                                INNER JOIN " + submodulo + @" AS S5 ON S5.""OID"" = P5.""OID_SUBMODULO""
                                        INNER JOIN " + tema + @" AS T5 ON T5.""OID"" = P5.""OID_TEMA""
                                        WHERE P5.""FECHA_DISPONIBILIDAD"" <= '" + DateTime.Today.Date.ToString("yyyy-MM-dd") + @"' AND P5.""ACTIVA"" = 'TRUE' AND P5.""OID"" IN " + lista_preguntas + @"
		                                GROUP BY S5.""OID"", T5.""NIVEL"") AS DNC ON DNC.""OID"" = S.""OID"" AND DNC.""NIVEL"" = T.""NIVEL"" 
                                WHERE P.""ACTIVA"" = 'true' 
                                GROUP BY ""MODULO"", ""SUBMODULO"", T.""NIVEL"", M.""NUMERO_ORDEN"", S.""CODIGO_ORDEN"", T.""DESARROLLO"", CM.""MODULO_COUNT"", CS.""SUBMODULO_COUNT"", DMC.""DISPONIBLES_MODULO_COUNT"", DSC.""DISPONIBLES_SUBMODULO_COUNT"", DNC.""DISPONIBLES_NIVEL_COUNT"", P.""OID_MODULO"", P.""OID_SUBMODULO""
                                ORDER BY M.""NUMERO_ORDEN"", S.""CODIGO_ORDEN""";

                return query;

            }

        #endregion
    }
}

