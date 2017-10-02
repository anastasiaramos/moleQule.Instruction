using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

using Csla;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;

namespace moleQule.Library.Instruction
{	
	/// <summary>
	/// ReadOnly Business Object Root Collection
	/// </summary>
    [Serializable()]
	public class FestivoList : ReadOnlyListBaseEx<FestivoList, FestivoInfo>
	{	
		#region Business Methods

        public static DateTime[] GetBoldedList(SortedBindingList<FestivoInfo> list)
        {
            Dictionary<DateTime, DateTime> fechas = new Dictionary<DateTime, DateTime>();

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; list[i].FechaInicio.Date.AddDays(j) <= list[i].FechaFin.Date; j++)
                {
                    if (!fechas.ContainsKey(list[i].FechaInicio.Date.AddDays(j)))
                        fechas.Add(list[i].FechaInicio.Date.AddDays(j), list[i].FechaInicio.Date.AddDays(j));
                }
            }

            DateTime[] bolded = new DateTime[fechas.Count];
            int index = 0;

            foreach (DateTime date in fechas.Values)
                bolded[index++] = date;

            return bolded;
        }
			
		#endregion
		 
		#region Common Factory Methods
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Objet creation require use of factory methods
        /// </remarks>
		private FestivoList() {}
		private FestivoList(IList<Festivo> list, bool childs)
        {
			Childs = childs;
            Fetch(list);
        }
		private FestivoList(IList<FestivoInfo> list, bool childs)
        {
			Childs = childs;
            Fetch(list);
        }
		
		#endregion
		
		#region Root Factory Methods
		
		public static FestivoList NewList() { return new FestivoList(); }
		
		public static FestivoList GetList() { return FestivoList.GetList(true); }
		public static FestivoList GetList(bool childs)
		{
			//No criteria. Retrieve all de List
			
            return GetList(SELECT(), childs);
            
		}
		
		private static FestivoList GetList(string query, bool childs)
		{
			CriteriaEx criteria = Festivo.GetCriteria(Festivo.OpenSession());
			criteria.Childs = childs;
			
            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = query;

			FestivoList list = DataPortal.Fetch<FestivoList>(criteria);
			CloseSession(criteria.SessionCode);
			return list;
		}

        public static SortedBindingList<FestivoInfo> GetList(DateTime fecha_inicio, DateTime fecha_fin)
        {
            CriteriaEx criteria = Festivo.GetCriteria(Festivo.OpenSession());
            criteria.Childs = false;

            List<FestivoInfo> list = new List<FestivoInfo>();
            List<FestivoInfo> festivos = new List<FestivoInfo>();

            string query = SELECT_BY_DATE(fecha_inicio, fecha_fin);
                        
            try
            {
                IDataReader reader = nHManager.Instance.SQLNativeSelect(query, criteria.Session);
                    
                while (reader.Read())
                    list.Add(FestivoInfo.GetChild(criteria.SessionCode, reader, false));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            CloseSession(criteria.SessionCode);

            foreach (FestivoInfo info in list)
            {
                if (!info.Anual)
                    festivos.Add(info);
                else 
                {
                    TimeSpan span = info.FechaFin.Date.Subtract(info.FechaInicio.Date);

                    for (int i = Math.Max(fecha_inicio.Year, info.FechaInicio.Year); i <= fecha_fin.Year; i++)
                    {
                        DateTime date_inicio = new DateTime(i, info.FechaInicio.Month, info.FechaInicio.Day);

                        if (date_inicio.Date > info.FechaInicio.Date)
                        {
                            FestivoInfo nuevo = FestivoInfo.New();
                            nuevo.CopyFrom(info);

                            nuevo.FechaInicio = date_inicio;
                            nuevo.FechaFin = date_inicio + span;
                            festivos.Add(nuevo);
                        }
                        else
                            festivos.Add(info);
                    }
                }
            }

            SortedBindingList<FestivoInfo> ordenada = new SortedBindingList<FestivoInfo>(festivos);
            ordenada.ApplySort("FechaInicio", ListSortDirection.Ascending);

            return ordenada;
        }
		
		/// <summary>
		/// Devuelve una lista de todos los elementos
		/// </summary>
		/// <returns>Lista de elementos</returns>
		public static FestivoList GetList(CriteriaEx criteria)
		{
			return FestivoList.RetrieveList(typeof(Festivo), AppContext.ActiveSchema.Code, criteria);
		}
        public static FestivoList GetList(IList<Festivo> list) { return new FestivoList(list,false); }
        public static FestivoList GetList(IList<FestivoInfo> list) { return new FestivoList(list, false); }
		
		/// <summary>
		/// Devuelve una lista ordenada de todos los elementos
		/// </summary>
		/// <param name="sortProperty">Campo de ordenación</param>
		/// <param name="sortDirection">Sentido de ordenación</param>
		/// <returns>Lista ordenada de elementos</returns>
		public static SortedBindingList<FestivoInfo> GetSortedList (string sortProperty, ListSortDirection sortDirection)
		{
			SortedBindingList<FestivoInfo> sortedList = new SortedBindingList<FestivoInfo>(GetList());
			
			sortedList.ApplySort(sortProperty, sortDirection);
			return sortedList;
		}
        public static SortedBindingList<FestivoInfo> GetSortedList(string sortProperty, ListSortDirection sortDirection, bool childs)
        {
            SortedBindingList<FestivoInfo> sortedList = new SortedBindingList<FestivoInfo>(GetList(childs));

            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }
			
		#endregion
		
		#region Common Data Access

		/// <summary>
        /// Construye la lista y obtiene los datos de los hijos de la bd
		/// </summary>
		/// <param name="lista">IList origen</param>
		private void Fetch(IList<Festivo> lista)
		{
			this.RaiseListChangedEvents = false;

			IsReadOnly = false;
			
			foreach (Festivo item in lista)
				this.AddItem(item.GetInfo(Childs));

			IsReadOnly = true;

			this.RaiseListChangedEvents = true;
		}

        /// <summary>
        /// Construye la lista y obtiene los datos de los hijos de la bd
		/// </summary>
		/// <param name="reader">IDataReader origen</param>
        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            while (reader.Read())
                this.AddItem(FestivoInfo.GetChild(SessionCode, reader, Childs));

            IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }
		
        #endregion

		#region Root Data Access
		 
		/// <summary>
		/// Construye el objeto y se encarga de obtener los
        /// hijos si los tiene y se solicitan
        /// </summary>
        /// <param name="criteria">Criterios de la consulta</param>
		protected override void Fetch(CriteriaEx criteria)
		{
			this.RaiseListChangedEvents = false;
			
			SessionCode = criteria.SessionCode;
			Childs = criteria.Childs;
			
			try
			{
				if (nHMng.UseDirectSQL)
				{					
					IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session()); 
					
					IsReadOnly = false;
					
					while (reader.Read())
						this.AddItem(FestivoInfo.GetChild(SessionCode, reader, Childs));

					IsReadOnly = true;
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

        public static string SELECT() { return FestivoInfo.SELECT(new QueryConditions()); }
		public static string SELECT(QueryConditions conditions) { return Festivo.SELECT(conditions, false); }

        public static string SELECT_BY_DATE(DateTime fecha_inicio, DateTime fecha_fin)
        { 
            string festivo = nHManager.Instance.GetSQLTable(typeof(FestivoRecord));
            QueryConditions conditions = new QueryConditions(){FechaIni = fecha_inicio, FechaFin = fecha_fin};

            string query = @"SELECT *
                            FROM " + festivo + @" 
                            WHERE ""ANUAL"" = 'TRUE' OR 
                                (""ANUAL"" = 'FALSE' AND (""FECHA_INICIO"" BETWEEN '" + conditions.FechaIniLabel + "' AND '" + conditions.FechaFinLabel + @"'
                                                        OR ""FECHA_INICIO"" BETWEEN '" + conditions.FechaIniLabel + "' AND '" + conditions.FechaFinLabel + @"'))
                            ORDER BY ""ANUAL"", ""FECHA_INICIO""";
            return query;
        }
		
		#endregion		
	}
}
