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
    public class RegistroDisponibilidadList : ReadOnlyListBaseEx<RegistroDisponibilidadList, RegistroDisponibilidadInfo>
	{	

		#region Business Methods
			
		#endregion
		 
		#region Factory Methods
		 
		private RegistroDisponibilidadList() {}
		
		/// <summary>
		/// Retrieve the complete list from db
		/// </summary>
		/// <param name="get_childs">retrieving the childs</param>
		/// <returns></returns>
		public static RegistroDisponibilidadList GetList(DateTime fecha_inicio, bool all)
		{
			CriteriaEx criteria = Disponibilidad.GetCriteria(Disponibilidad.OpenSession());
			criteria.Childs = false;
			
			//No criteria. Retrieve all de List
			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = RegistroDisponibilidadList.SELECT_DISPONIBILIDAD_SEMANAL(fecha_inicio, all);
			RegistroDisponibilidadList list = DataPortal.Fetch<RegistroDisponibilidadList>(criteria);
			
			CloseSession(criteria.SessionCode);
			return list;
		}
		
		/// <summary>
		/// Default call for GetList(bool get_childs)
		/// </summary>
		/// <returns></returns>
		public static RegistroDisponibilidadList GetList(DateTime fecha_inicio)
		{
			return RegistroDisponibilidadList.GetList(fecha_inicio, true);
		}
		
		/// <summary>
		/// Devuelve una lista de todos los elementos
		/// </summary>
		/// <returns>Lista de elementos</returns>
		public static RegistroDisponibilidadList GetList(CriteriaEx criteria)
		{
			return RegistroDisponibilidadList.RetrieveList(typeof(RegistroDisponibilidad), AppContext.ActiveSchema.Code, criteria);
		}
		
		/// <summary>
		/// Builds a RegistroDisponibilidadList from a IList<!--<RegistroDisponibilidadInfo>-->.
		/// Doesnt retrieve child data from DB.
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public static RegistroDisponibilidadList GetList(IList<RegistroDisponibilidadInfo> list)
		{
			RegistroDisponibilidadList flist = new RegistroDisponibilidadList();
			
			if (list.Count > 0)
			{
				flist.IsReadOnly = false;
				
				foreach (RegistroDisponibilidadInfo item in list)
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
		public static SortedBindingList<RegistroDisponibilidadInfo> GetSortedList (DateTime fecha_inicio, string sortProperty, ListSortDirection sortDirection)
		{
			SortedBindingList<RegistroDisponibilidadInfo> sortedList = new SortedBindingList<RegistroDisponibilidadInfo>(GetList(fecha_inicio));
			
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
        public static SortedBindingList<RegistroDisponibilidadInfo> GetSortedList(DateTime fecha_inicio, string sortProperty, ListSortDirection sortDirection, bool childs)
        {
            SortedBindingList<RegistroDisponibilidadInfo> sortedList = new SortedBindingList<RegistroDisponibilidadInfo>(GetList(fecha_inicio, childs));

            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }
		
		/// <summary>
        /// Builds a RegistroDisponibilidadList from a IList<!--<RegistroDisponibilidad>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>RegistroDisponibilidadList</returns>
        public static RegistroDisponibilidadList GetList(IList<RegistroDisponibilidad> list)
        {
            RegistroDisponibilidadList flist = new RegistroDisponibilidadList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (RegistroDisponibilidad item in list)
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
							this.AddItem(RegistroDisponibilidadInfo.Get(reader, Childs));
						}
						IsReadOnly = true;
					}
					else 
					{
						IList list = criteria.List();
						
						if (list.Count > 0)
						{
							IsReadOnly = false;
							foreach(RegistroDisponibilidad item in list)
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

            private static string SELECT_DISPONIBILIDAD_SEMANAL(DateTime fecha_inicio, bool all)
            {
                string empleado = nHManager.Instance.GetSQLTable(typeof(InstructorRecord));
                string disponibilidad = nHManager.Instance.GetSQLTable(typeof(DisponibilidadRecord));

                string fecha = fecha_inicio.Year.ToString("0000") +
                    "-" + fecha_inicio.Month.ToString("00") +
                    "-" + fecha_inicio.Day.ToString("00");

                long m_ini = ModulePrincipal.GetHoraInicioDisponibilidadMananaSetting();
                long m_fin = ModulePrincipal.GetHoraFinDisponibilidadMananaSetting();
                long t1_ini = ModulePrincipal.GetHoraInicioDisponibilidadTarde1Setting();
                long t1_fin = ModulePrincipal.GetHoraFinDisponibilidadTarde1Setting();
                long t2_ini = ModulePrincipal.GetHoraInicioDisponibilidadTarde2Setting();
                long t2_fin = ModulePrincipal.GetHoraFinDisponibilidadTarde2Setting();

                bool autorizados = ModulePrincipal.GetMostrarInstructoresAutorizadosSetting();

                string m_str = string.Empty;
                string t1_str = string.Empty;
                string t2_str = string.Empty;
                string ms_str = string.Empty;
                string t1s_str = string.Empty;
                string t2s_str = string.Empty;

                m_str = " \"L8AM\" = TRUE";
                for (long i = m_ini - 1; i < m_fin; i++)
                {
                    m_str += " OR \"L" + i.ToString() + "\" = TRUE";

                    if (i < 5)
                    {
                        if (ms_str != string.Empty)
                            ms_str += " OR ";
                        ms_str += "\"S" + i.ToString() + "\" = TRUE";
                    }
                }

                for (long i = t1_ini - 1; i < t1_fin; i++)
                {
                    if (t1_str != string.Empty)
                        t1_str += " OR ";
                    t1_str += "\"L" + i.ToString() + "\" = TRUE";

                    if (i < 5)
                    {
                        if (t1s_str != string.Empty)
                            t1s_str += " OR ";
                        t1s_str += "\"S" + i.ToString() + "\" = TRUE";
                    }
                }

                for (long i = t2_ini - 1; i < t2_fin; i++)
                {
                    if (t2_str != string.Empty)
                        t2_str += " OR ";
                    t2_str += "\"L" + i.ToString() + "\" = TRUE";

                    if (i < 5)
                    {
                        if (t2s_str != string.Empty)
                            t2s_str += " OR ";
                        t2s_str += "\"S" + i.ToString() + "\" = TRUE";
                    }
                }

                string query = "SELECT DISTINCT I.\"OID\", I.\"APELLIDOS\", I.\"NOMBRE_PROPIO\", ";

                query += " \"ND_L\" AS \"LUNES_ND\", \"ND_M\" AS \"MARTES_ND\", \"ND_X\" AS \"MIERCOLES_ND\", \"ND_J\" AS \"JUEVES_ND\", \"ND_V\" AS \"VIERNES_ND\", \"ND_S\" AS \"SABADO_ND\"";

                if (m_str != string.Empty)
                    query += ",(" + m_str + ") AS \"LUNES_M\" " +
                        ",(" + m_str.Replace("L", "M") + ") AS \"MARTES_M\" " +
                        ",(" + m_str.Replace("L", "X") + ") AS \"MIERCOLES_M\" " +
                        ",(" + m_str.Replace("L", "J") + ") AS \"JUEVES_M\" " +
                        ",(" + m_str.Replace("L", "V") + ") AS \"VIERNES_M\" ";
                else
                    query += ", FALSE AS \"LUNES_M\" " +
                        ", FALSE AS \"MARTES_M\" " +
                        ", FALSE AS \"MIERCOLES_M\" " +
                        ", FALSE AS \"JUEVES_M\" " +
                        ", FALSE AS \"VIERNES_M\" ";

                if (ms_str != string.Empty)
                    query += ",(" + ms_str + ") AS \"SABADO_M\" ";
                else
                    query += ", FALSE AS \"SABADO_M\" ";

                if (t1_str != string.Empty)
                    query += ",(" + t1_str + ") AS \"LUNES_T1\" " +
                        ",(" + t1_str.Replace("L", "M") + ") AS \"MARTES_T1\" " +
                        ",(" + t1_str.Replace("L", "X") + ") AS \"MIERCOLES_T1\" " +
                        ",(" + t1_str.Replace("L", "J") + ") AS \"JUEVES_T1\" " +
                        ",(" + t1_str.Replace("L", "V") + ") AS \"VIERNES_T1\" ";
                else
                    query += ", FALSE AS \"LUNES_T1\" " +
                        ", FALSE AS \"MARTES_T1\" " +
                        ", FALSE AS \"MIERCOLES_T1\" " +
                        ", FALSE AS \"JUEVES_T1\" " +
                        ", FALSE AS \"VIERNES_T1\" ";

                if (t1s_str != string.Empty)
                    query += ",(" + t1s_str + ") AS \"SABADO_T1\" ";
                else
                    query += ", FALSE AS \"SABADO_T1\" ";

                if (t2_str != string.Empty)
                    query += ",(" + t2_str + ") AS \"LUNES_T2\" " +
                        ",(" + t2_str.Replace("L", "M") + ") AS \"MARTES_T2\" " +
                        ",(" + t2_str.Replace("L", "X") + ") AS \"MIERCOLES_T2\" " +
                        ",(" + t2_str.Replace("L", "J") + ") AS \"JUEVES_T2\" " +
                        ",(" + t2_str.Replace("L", "V") + ") AS \"VIERNES_T2\" ";
                else
                    query += ", FALSE AS \"LUNES_T2\" " +
                        ", FALSE AS \"MARTES_T2\" " +
                        ", FALSE AS \"MIERCOLES_T2\" " +
                        ", FALSE AS \"JUEVES_T2\" " +
                        ", FALSE AS \"VIERNES_T2\" ";

                if (t2s_str != string.Empty)
                    query += ",(" + t2s_str + ") AS \"SABADO_T2\" ";
                else
                    query += ", FALSE AS \"SABADO_T2\" ";

                query += "FROM " + empleado + " AS I " +
                                "INNER JOIN " + disponibilidad + " AS D ON (D.\"OID_INSTRUCTOR\" = I.\"OID\") " +
                                "WHERE D.\"FECHA_INICIO\" = '" + fecha + "' " +
                                "AND (";

                for (long i = m_ini - 1; i < t2_fin; i++)
                {
                    query += "\"L" + i.ToString() + "\" OR ";
                    query += "\"M" + i.ToString() + "\" OR ";
                    query += "\"X" + i.ToString() + "\" OR ";
                    query += "\"J" + i.ToString() + "\" OR ";
                    query += "\"V" + i.ToString() + "\" OR ";
                }

                for (long i = m_ini - 1; i < 5; i++)
                    query += "\"S" + i.ToString() + "\" OR ";

                query += "\"L8AM\" OR \"M8AM\" OR \"X8AM\" OR \"J8AM\" OR \"V8AM\" OR \"ND_L\" OR \"ND_M\" OR \"ND_X\" OR \"ND_J\" OR \"ND_V\" OR \"ND_S\") ";
                if (autorizados) query += "AND I.\"MTOE\" = 'TRUE' ";


                if (all)
                {
                    query +=
                        "UNION " +
                        "SELECT DISTINCT I.\"OID\", I.\"APELLIDOS\", I.\"NOMBRE_PROPIO\", ";

                    query += " \"ND_L\" AS \"LUNES_ND\", \"ND_M\" AS \"MARTES_ND\", \"ND_X\" AS \"MIERCOLES_ND\", \"ND_J\" AS \"JUEVES_ND\", \"ND_V\" AS \"VIERNES_ND\", \"ND_S\" AS \"SABADO_ND\"";

                    if (m_str != string.Empty)
                        query += ",(" + m_str + ") AS \"LUNES_M\" " +
                            ",(" + m_str.Replace("L", "M") + ") AS \"MARTES_M\" " +
                            ",(" + m_str.Replace("L", "X") + ") AS \"MIERCOLES_M\" " +
                            ",(" + m_str.Replace("L", "J") + ") AS \"JUEVES_M\" " +
                            ",(" + m_str.Replace("L", "V") + ") AS \"VIERNES_M\" ";
                    else
                        query += ", FALSE AS \"LUNES_M\" " +
                            ", FALSE AS \"MARTES_M\" " +
                            ", FALSE AS \"MIERCOLES_M\" " +
                            ", FALSE AS \"JUEVES_M\" " +
                            ", FALSE AS \"VIERNES_M\" ";

                    if (ms_str != string.Empty)
                        query += ",(" + ms_str + ") AS \"SABADO_M\" ";
                    else
                        query += ", FALSE AS \"SABADO_M\" ";

                    if (t1_str != string.Empty)
                        query += ",(" + t1_str + ") AS \"LUNES_T1\" " +
                            ",(" + t1_str.Replace("L", "M") + ") AS \"MARTES_T1\" " +
                            ",(" + t1_str.Replace("L", "X") + ") AS \"MIERCOLES_T1\" " +
                            ",(" + t1_str.Replace("L", "J") + ") AS \"JUEVES_T1\" " +
                            ",(" + t1_str.Replace("L", "V") + ") AS \"VIERNES_T1\" ";
                    else
                        query += ", FALSE AS \"LUNES_T1\" " +
                            ", FALSE AS \"MARTES_T1\" " +
                            ", FALSE AS \"MIERCOLES_T1\" " +
                            ", FALSE AS \"JUEVES_T1\" " +
                            ", FALSE AS \"VIERNES_T1\" ";

                    if (t1s_str != string.Empty)
                        query += ",(" + t1s_str + ") AS \"SABADO_T1\" ";
                    else
                        query += ", FALSE AS \"SABADO_T1\" ";

                    if (t2_str != string.Empty)
                        query += ",(" + t2_str + ") AS \"LUNES_T2\" " +
                            ",(" + t2_str.Replace("L", "M") + ") AS \"MARTES_T2\" " +
                            ",(" + t2_str.Replace("L", "X") + ") AS \"MIERCOLES_T2\" " +
                            ",(" + t2_str.Replace("L", "J") + ") AS \"JUEVES_T2\" " +
                            ",(" + t2_str.Replace("L", "V") + ") AS \"VIERNES_T2\" ";
                    else
                        query += ", FALSE AS \"LUNES_T2\" " +
                            ", FALSE AS \"MARTES_T2\" " +
                            ", FALSE AS \"MIERCOLES_T2\" " +
                            ", FALSE AS \"JUEVES_T2\" " +
                            ", FALSE AS \"VIERNES_T2\" ";

                    if (t2s_str != string.Empty)
                        query += ",(" + t2s_str + ") AS \"SABADO_T2\" ";
                    else
                        query += ", FALSE AS \"SABADO_T2\" ";

                    query += "FROM " + empleado + " AS I " +
                                    "INNER JOIN " + disponibilidad + " AS D ON (D.\"OID_INSTRUCTOR\" = I.\"OID\") " +
                                    "WHERE D.\"FECHA_INICIO\" = '" + fecha + "' " +
                                    "AND NOT (";

                    for (long i = m_ini - 1; i < t2_fin; i++)
                    {
                        query += "\"L" + i.ToString() + "\" OR ";
                        query += "\"M" + i.ToString() + "\" OR ";
                        query += "\"X" + i.ToString() + "\" OR ";
                        query += "\"J" + i.ToString() + "\" OR ";
                        query += "\"V" + i.ToString() + "\" OR ";
                    }

                    for (long i = m_ini - 1; i < 5; i++)
                        query += "\"S" + i.ToString() + "\" OR ";

                    query += "\"L8AM\" OR \"M8AM\" OR \"X8AM\" OR \"J8AM\" OR \"V8AM\" OR \"ND_L\" OR \"ND_M\" OR \"ND_X\" OR \"ND_J\" OR \"ND_V\" OR \"ND_S\") ";
                    if (autorizados) query += "AND I.\"MTOE\" = 'TRUE' ";

                    query +=

                    "UNION  " +
                    "SELECT I.\"OID\", I.\"APELLIDOS\", I.\"NOMBRE_PROPIO\", " +
                    "FALSE AS \"LUNES_ND\", FALSE AS \"MARTES_ND\", FALSE AS \"MIERCOLES_ND\", FALSE AS \"JUEVES_ND\", FALSE AS \"VIERNES_ND\", FALSE AS \"SABADO_ND\", FALSE AS \"LUNES_M\", " +
                    "FALSE AS \"MARTES_M\", FALSE AS \"MIERCOLES_M\", FALSE AS \"JUEVES_M\", FALSE AS \"VIERNES_M\", " +
                    "FALSE AS \"SABADO_M\", FALSE AS \"LUNES_T1\", FALSE AS \"MARTES_T1\", FALSE AS \"MIERCOLES_T1\", " +
                    "FALSE AS \"JUEVES_T1\", FALSE AS \"VIERNES_T1\", FALSE AS \"SABADO_T1\", FALSE AS \"LUNES_T2\", " +
                    "FALSE AS \"MARTES_T2\", FALSE AS \"MIERCOLES_T2\", FALSE AS \"JUEVES_T2\", FALSE AS \"VIERNES_T2\", " +
                    "FALSE AS \"SABADO_T2\" " +
                    "FROM " + empleado + " AS I " +
                    "WHERE (I.\"ACTIVO\" = TRUE AND I.\"OID\" NOT IN (SELECT D.\"OID_INSTRUCTOR\" " +
                    "                        FROM " + disponibilidad + " AS D " +
                    "                        WHERE D.\"FECHA_INICIO\" = '" + fecha + "')) ";
                    if (autorizados) query += "OR I.\"MTOE\" = 'FALSE' ";
                }

                 query += "ORDER BY \"APELLIDOS\", \"NOMBRE_PROPIO\";";

                return query;
            }

        #endregion
    }
}

