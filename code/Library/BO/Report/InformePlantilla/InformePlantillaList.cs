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
    public class InformePlantillaList : ReadOnlyListBaseEx<InformePlantillaList, InformePlantillaInfo>
	{	

		#region Business Methods
			
		#endregion
		 
		#region Factory Methods

        private InformePlantillaList() { }

        public static InformePlantillaList NewList() { return new InformePlantillaList(); }
		
		/// <summary>
		/// Retrieve the complete list from db
		/// </summary>
		/// <param name="get_childs">retrieving the childs</param>
		/// <returns></returns>
		public static InformePlantillaList GetList(long oid_plantilla)
		{
            CriteriaEx criteria = ParteAsistencia.GetCriteria(ParteAsistencia.OpenSession());
			criteria.Childs = false;
			
			//No criteria. Retrieve all de List
			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = InformePlantillaList.SELECT_INFORME_PLANTILLA(oid_plantilla);
			InformePlantillaList list = DataPortal.Fetch<InformePlantillaList>(criteria);
			
			CloseSession(criteria.SessionCode);
			return list;
		}

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <param name="get_childs">retrieving the childs</param>
        /// <returns></returns>
        public static InformePlantillaList GetDisponiblesList(long oid_plantilla, DateTime fecha_disponibilidad)
        {
            CriteriaEx criteria = ParteAsistencia.GetCriteria(ParteAsistencia.OpenSession());
            criteria.Childs = false;

            //No criteria. Retrieve all de List
            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = InformePlantillaList.SELECT_INFORME_DISPONIBILIDAD_PLANTILLA(oid_plantilla, fecha_disponibilidad);
            InformePlantillaList list = DataPortal.Fetch<InformePlantillaList>(criteria);

            CloseSession(criteria.SessionCode);
            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <param name="get_childs">retrieving the childs</param>
        /// <returns></returns>
        public static InformePlantillaList GetDisponiblesDesarrolloList(long oid_plantilla, DateTime fecha_disponibilidad)
        {
            CriteriaEx criteria = ParteAsistencia.GetCriteria(ParteAsistencia.OpenSession());
            criteria.Childs = false;

            //No criteria. Retrieve all de List
            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = InformePlantillaList.SELECT_INFORME_DISPONIBILIDAD_PLANTILLA_DESARROLLO(oid_plantilla, fecha_disponibilidad);
            InformePlantillaList list = DataPortal.Fetch<InformePlantillaList>(criteria);

            CloseSession(criteria.SessionCode);
            return list;
        }

		/// <summary>
		/// Retrieve the complete list from db
		/// </summary>
		/// <param name="get_childs">retrieving the childs</param>
		/// <returns></returns>
        public static InformePlantillaList GetList() { return GetList(-1); }
		
		/// <summary>
		/// Devuelve una lista de todos los elementos
		/// </summary>
		/// <returns>Lista de elementos</returns>
		public static InformePlantillaList GetList(CriteriaEx criteria)
		{
			return InformePlantillaList.RetrieveList(typeof(InformePlantilla), AppContext.ActiveSchema.Code, criteria);
		}
		
		/// <summary>
		/// Builds a InformePlantillaList from a IList<!--<InformePlantillaInfo>-->.
		/// Doesnt retrieve child data from DB.
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public static InformePlantillaList GetList(IList<InformePlantillaInfo> list)
		{
			InformePlantillaList flist = new InformePlantillaList();
			
			if (list.Count > 0)
			{
				flist.IsReadOnly = false;
				
				foreach (InformePlantillaInfo item in list)
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
		public static SortedBindingList<InformePlantillaInfo> GetSortedList (string sortProperty, ListSortDirection sortDirection)
		{
			SortedBindingList<InformePlantillaInfo> sortedList = new SortedBindingList<InformePlantillaInfo>(GetList());
			
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
        public static SortedBindingList<InformePlantillaInfo> GetSortedList(string sortProperty, ListSortDirection sortDirection, bool childs)
        {
            SortedBindingList<InformePlantillaInfo> sortedList = new SortedBindingList<InformePlantillaInfo>(GetList());

            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }
		
		/// <summary>
        /// Builds a InformePlantillaList from a IList<!--<InformePlantilla>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>InformePlantillaList</returns>
        public static InformePlantillaList GetList(IList<InformePlantilla> list)
        {
            InformePlantillaList flist = new InformePlantillaList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (InformePlantilla item in list)
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
							this.AddItem(InformePlantillaInfo.Get(reader, Childs));
						}
						IsReadOnly = true;
					}
					else 
					{
						IList list = criteria.List();
						
						if (list.Count > 0)
						{
							IsReadOnly = false;
							foreach(InformePlantilla item in list)
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

            private static string SELECT_INFORME_PLANTILLA (long oid_plantilla)
            {
                string plantilla = nHManager.Instance.GetSQLTable(typeof(PlantillaExamenRecord));
                string preguntas = nHManager.Instance.GetSQLTable(typeof(Preguntas_PlantillaRecord));
                string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
                string tema = nHManager.Instance.GetSQLTable(typeof(TemaRecord));

                string query = @"SELECT S.""OID"", (S.""CODIGO"" || ' ' || S.""TEXTO"") AS ""SUBMODULO"", 
                                T.""OID"" AS ""OID_TEMA"", (T.""CODIGO"" || ' ' || T.""NOMBRE"") AS ""TEMA"", 
                                ""NIVEL"", SUM(PP.""N_PREGUNTAS"") AS ""N_PREGUNTAS"", 0 AS ""DISPONIBLES""
                                FROM " + plantilla + @" AS P
                                INNER JOIN " + preguntas + @" AS PP ON PP.""OID_PLANTILLA"" = P.""OID"" AND PP.""N_PREGUNTAS"" > 0
                                INNER JOIN " + submodulo + @" AS S ON S.""OID"" = PP.""OID_SUBMODULO""
                                INNER JOIN " + tema + @" AS T ON T.""OID"" = PP.""OID_TEMA""
                                WHERE P.""OID"" = " + oid_plantilla.ToString() + @"
                                GROUP BY ""SUBMODULO"", ""NIVEL"", S.""CODIGO_ORDEN"", S.""OID"", T.""OID"", ""TEMA""
                                ORDER BY S.""CODIGO_ORDEN"", T.""CODIGO_ORDEN"", ""NIVEL""";

                return query;
            }

            private static string SELECT_INFORME_DISPONIBILIDAD_PLANTILLA(long oid_plantilla, DateTime fecha_disponibilidad)
            {
                string plantilla = nHManager.Instance.GetSQLTable(typeof(PlantillaExamenRecord));
                string preg_plantilla = nHManager.Instance.GetSQLTable(typeof(Preguntas_PlantillaRecord));
                string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
                string tema = nHManager.Instance.GetSQLTable(typeof(TemaRecord));
                string preguntas = nHManager.Instance.GetSQLTable(typeof(PreguntaRecord));

                string query = @"SELECT S.""OID"", (S.""CODIGO"" || ' ' || S.""TEXTO"") AS ""SUBMODULO"", 
                                T.""OID"" AS ""OID_TEMA"", (T.""CODIGO"" || ' ' || T.""NOMBRE"") AS ""TEMA"", 
                                ""NIVEL"", SUM(PP.""N_PREGUNTAS"") AS ""N_PREGUNTAS"", COALESCE(CP.""DISPONIBLES"", 0) AS ""DISPONIBLES""
                                FROM " + plantilla + @" AS P
                                INNER JOIN " + preg_plantilla + @" AS PP ON PP.""OID_PLANTILLA"" = P.""OID"" AND PP.""N_PREGUNTAS"" > 0
                                INNER JOIN " + submodulo + @" AS S ON S.""OID"" = PP.""OID_SUBMODULO""
                                INNER JOIN " + tema + @" AS T ON T.""OID"" = PP.""OID_TEMA""
                                LEFT JOIN (	SELECT COUNT(P.""OID"") AS ""DISPONIBLES"", P.""OID_SUBMODULO"", P.""OID_TEMA""
		                                        FROM " + preguntas + @" AS P
		                                        WHERE P.""FECHA_DISPONIBILIDAD"" <= '" + fecha_disponibilidad.ToString("yyyy-MM-dd") + @"' AND P.""ACTIVA"" = 'TRUE'
		                                        GROUP BY P.""OID_SUBMODULO"", P.""OID_TEMA"") AS CP ON CP.""OID_SUBMODULO"" = PP.""OID_SUBMODULO"" AND PP.""OID_TEMA"" = CP.""OID_TEMA""
                                WHERE P.""OID"" = " + oid_plantilla.ToString() + @"
                                GROUP BY ""SUBMODULO"", ""NIVEL"", S.""CODIGO_ORDEN"", S.""OID"", T.""OID"", ""TEMA"", CP.""DISPONIBLES""
                                ORDER BY S.""CODIGO_ORDEN"", T.""CODIGO_ORDEN"", ""NIVEL""";

                return query;
            }

            private static string SELECT_INFORME_DISPONIBILIDAD_PLANTILLA_DESARROLLO(long oid_plantilla, DateTime fecha_disponibilidad)
            {
                string plantilla = nHManager.Instance.GetSQLTable(typeof(PlantillaExamenRecord));
                string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
                string tema = nHManager.Instance.GetSQLTable(typeof(TemaRecord));
                string preguntas = nHManager.Instance.GetSQLTable(typeof(PreguntaRecord));

                string query = @"SELECT S.""OID"", (S.""CODIGO"" || ' ' || S.""TEXTO"") AS ""SUBMODULO"", 
                                T.""OID"" AS ""OID_TEMA"", (T.""CODIGO"" || ' ' || T.""NOMBRE"") AS ""TEMA"", 
                                ""NIVEL"", P.""N_PREGUNTAS"" AS ""N_PREGUNTAS"", COALESCE(CP.""DISPONIBLES"", 0) AS ""DISPONIBLES""
                                FROM " + plantilla + @" AS P
                                INNER JOIN " + submodulo + @" AS S ON S.""OID_MODULO"" = P.""OID_MODULO""
                                INNER JOIN " + tema + @" AS T ON T.""OID_MODULO"" = P.""OID_MODULO"" AND T.""OID_SUBMODULO"" = S.""OID""
                                LEFT JOIN (	SELECT COUNT(P.""OID"") AS ""DISPONIBLES"", P.""OID_SUBMODULO"", P.""OID_TEMA""
		                                        FROM " + preguntas + @" AS P
		                                        WHERE P.""FECHA_DISPONIBILIDAD"" <= '" + fecha_disponibilidad.ToString("yyyy-MM-dd") + @"' AND P.""ACTIVA"" = 'TRUE'
		                                        GROUP BY P.""OID_SUBMODULO"", P.""OID_TEMA"") AS CP ON CP.""OID_SUBMODULO"" = S.""OID"" AND T.""OID"" = CP.""OID_TEMA""
                                WHERE P.""OID"" = " + oid_plantilla.ToString() + @" AND T.""DESARROLLO"" = 'TRUE' 
                                GROUP BY ""SUBMODULO"", ""NIVEL"", S.""CODIGO_ORDEN"", S.""OID"", T.""OID"", ""TEMA"", CP.""DISPONIBLES"", P.""N_PREGUNTAS""
                                ORDER BY S.""CODIGO_ORDEN"", T.""CODIGO_ORDEN"", ""NIVEL""";

                return query;
            }

        #endregion
    }
}

