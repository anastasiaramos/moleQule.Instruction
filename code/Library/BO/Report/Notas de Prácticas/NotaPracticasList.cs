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
    public class NotaPracticasList : ReadOnlyListBaseEx<NotaPracticasList, NotaPracticasInfo>
	{	

		#region Business Methods
			
		#endregion
		 
		#region Factory Methods
		 
		private NotaPracticasList() {}

        public static NotaPracticasList NewList() { return new NotaPracticasList(); }
		
		/// <summary>
		/// Retrieve the complete list from db
		/// </summary>
		/// <param name="get_childs">retrieving the childs</param>
		/// <returns></returns>
		public static NotaPracticasList GetListByPromo(bool childs, long oid_promo)
		{
            CriteriaEx criteria = ClasePractica.GetCriteria(ClasePractica.OpenSession());
			criteria.Childs = childs;
			
			//No criteria. Retrieve all de List
			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = NotaPracticasList.SELECT_NOTAS_ALUMNOS_BY_PROMO(oid_promo);
			NotaPracticasList list = DataPortal.Fetch<NotaPracticasList>(criteria);
			
			CloseSession(criteria.SessionCode);
			return list;
		}

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <param name="get_childs">retrieving the childs</param>
        /// <returns></returns>
        public static NotaPracticasList GetListByAlumno(bool childs, long oid_alumno)
        {
            CriteriaEx criteria = ClasePractica.GetCriteria(ClasePractica.OpenSession());
            criteria.Childs = childs;

            //No criteria. Retrieve all de List
            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = NotaPracticasList.SELECT_NOTAS_ALUMNOS_BY_ALUMNO(oid_alumno);
            NotaPracticasList list = DataPortal.Fetch<NotaPracticasList>(criteria);

            CloseSession(criteria.SessionCode);
            return list;
        }


        /// <summary>
        /// Default call for GetList(bool get_childs)
        /// </summary>
        /// <returns></returns>
        public static NotaPracticasList GetList(bool childs)
        {
            return NotaPracticasList.GetListByPromo(childs, 0);
        }

		/// <summary>
		/// Default call for GetList(bool get_childs)
		/// </summary>
		/// <returns></returns>
		public static NotaPracticasList GetList()
		{
			return NotaPracticasList.GetListByPromo(true, 0);
		}
		
		/// <summary>
		/// Devuelve una lista de todos los elementos
		/// </summary>
		/// <returns>Lista de elementos</returns>
		public static NotaPracticasList GetList(CriteriaEx criteria)
		{
			return NotaPracticasList.RetrieveList(typeof(NotaPracticas), AppContext.ActiveSchema.Code, criteria);
		}
		
		/// <summary>
		/// Builds a NotaPracticasList from a IList<!--<NotaPracticasInfo>-->.
		/// Doesnt retrieve child data from DB.
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public static NotaPracticasList GetList(IList<NotaPracticasInfo> list)
		{
			NotaPracticasList flist = new NotaPracticasList();
			
			if (list.Count > 0)
			{
				flist.IsReadOnly = false;
				
				foreach (NotaPracticasInfo item in list)
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
		public static SortedBindingList<NotaPracticasInfo> GetSortedList (string sortProperty, ListSortDirection sortDirection)
		{
			SortedBindingList<NotaPracticasInfo> sortedList = new SortedBindingList<NotaPracticasInfo>(GetList());
			
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
        public static SortedBindingList<NotaPracticasInfo> GetSortedList(string sortProperty, ListSortDirection sortDirection, bool childs)
        {
            SortedBindingList<NotaPracticasInfo> sortedList = new SortedBindingList<NotaPracticasInfo>(GetList(childs));

            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }
		
		/// <summary>
        /// Builds a NotaPracticasList from a IList<!--<NotaPracticas>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>NotaPracticasList</returns>
        public static NotaPracticasList GetList(IList<NotaPracticas> list)
        {
            NotaPracticasList flist = new NotaPracticasList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (NotaPracticas item in list)
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
							this.AddItem(NotaPracticasInfo.Get(reader, Childs));
						}
						IsReadOnly = true;
					}
					else 
					{
						IList list = criteria.List();
						
						if (list.Count > 0)
						{
							IsReadOnly = false;
							foreach(NotaPracticas item in list)
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

            private static string SELECT_NOTAS_ALUMNOS_BY_PROMO(long oid_promo)
            {
                string parte = nHManager.Instance.GetSQLTable(typeof(ParteAsistenciaRecord));
                string clase_parte = nHManager.Instance.GetSQLTable(typeof(Clase_ParteRecord));
                string alumno_parte = nHManager.Instance.GetSQLTable(typeof(AlumnoParteRecord));
                string alumno = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));
                string clase_practica = nHManager.Instance.GetSQLTable(typeof(ClasePracticaRecord));
                string alumno_practica = nHManager.Instance.GetSQLTable(typeof(AlumnoPracticaRecord));
                string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
                string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
                string empleado = nHManager.Instance.GetSQLTable(typeof(InstructorRecord));
                string submodulo_instructor = nHManager.Instance.GetSQLTable(typeof(Submodulo_InstructorRecord));
                string alumno_promocion = nHManager.Instance.GetSQLTable(typeof(AlumnoPromocionRecord));
                string promocion = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));
                string horario = nHManager.Instance.GetSQLTable(typeof(HorarioRecord));

                string query = "SELECT DISTINCT a.\"NOMBRE\" AS \"NOMBRE\", a.\"APELLIDOS\" AS \"APELLIDOS\", a.\"N_EXPEDIENTE\" AS \"N_EXPEDIENTE\", " +
                                "   c.\"ALIAS\" AS \"CLASE\", m.\"NUMERO_MODULO\" AS \"NUMERO_MODULO\", m.\"TEXTO\" AS \"MODULO\", " +
                                "    s.\"CODIGO\" AS \"SUBMODULO\", p.\"FECHA\" AS \"FECHA\", p.\"HORA_INICIO\" AS \"HORA\", ea.\"NOMBRE\" AS \"PROFESOR\", " +
                                "    a.\"OID\" AS \"OID_ALUMNO\", m.\"NUMERO_ORDEN\" AS \"ORDEN_MODULO\", s.\"CODIGO_ORDEN\" AS \"ORDEN_SUBMODULO\", " +
                                "   2 AS \"TIPO\", pr.\"NOMBRE\" AS \"PROMOCION\", c.\"OID\" AS \"OID_CLASE\", apr.\"CALIFICACION\" AS \"CALIFICACION\" " +
                                "FROM " + parte + " AS p " +
                                "INNER JOIN " + horario + " AS H ON H.\"OID\" = p.\"OID_HORARIO\" AND H.\"OID_PROMOCION\" = " + oid_promo + " " +
                                "INNER JOIN " + clase_parte + " AS cp ON (cp.\"OID_PARTE\" = p.\"OID\") " +
                                "INNER JOIN " + alumno_parte + " AS ap ON (ap.\"OID_PARTE\" = p.\"OID\") " +
                                "INNER JOIN " + alumno + " AS a ON (a.\"OID\" = ap.\"OID_ALUMNO\" AND a.\"GRUPO\" = cp.\"GRUPO\") " +
                                "INNER JOIN " + clase_practica + " AS c ON (c.\"OID\" = cp.\"OID_CLASE\" AND cp.\"TIPO\" = 2) " +
                                "INNER JOIN " + alumno_practica + " AS apr ON (apr.\"OID_ALUMNO\" = a.\"OID\" AND apr.\"OID_CLASE_PRACTICA\" = c.\"OID\") " +
                                "INNER JOIN " + modulo + " AS m ON (m.\"OID\" = c.\"OID_MODULO\") " +
                                "INNER JOIN " + submodulo + " AS s ON (s.\"OID\" = c.\"OID_SUBMODULO\") " +
                                "INNER JOIN " + empleado + " AS e ON (e.\"OID\" = p.\"OID_INSTRUCTOR\") " +
                                "INNER JOIN " + submodulo_instructor + " AS si ON (si.\"OID_INSTRUCTOR\" = e.\"OID\" AND si.\"OID_SUBMODULO\" = s.\"OID\" AND p.\"FECHA\" BETWEEN si.\"FECHA_INICIO\" AND si.\"FECHA_FIN\") " +
                                "INNER JOIN " + empleado + " AS ea ON (si.\"OID_INSTRUCTOR_SUPLENTE\" = ea.\"OID\") " +
                                "INNER JOIN " + alumno_promocion + " as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\") " +
                                "INNER JOIN " + promocion + " as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\" AND pr.\"OID\" = H.\"OID_PROMOCION\")  " +
                                "UNION " +
                                "SELECT DISTINCT a.\"NOMBRE\" AS \"NOMBRE\", a.\"APELLIDOS\" AS \"APELLIDOS\", a.\"N_EXPEDIENTE\" AS \"N_EXPEDIENTE\", " +
                                "   c.\"ALIAS\" AS \"CLASE\", m.\"NUMERO_MODULO\" AS \"NUMERO_MODULO\", m.\"TEXTO\" AS \"MODULO\", " +
                                "    s.\"CODIGO\" AS \"SUBMODULO\", p.\"FECHA\" AS \"FECHA\", p.\"HORA_INICIO\" AS \"HORA\", e.\"NOMBRE\" AS \"PROFESOR\", " +
                                "    a.\"OID\" AS \"OID_ALUMNO\", m.\"NUMERO_ORDEN\" AS \"ORDEN_MODULO\", s.\"CODIGO_ORDEN\" AS \"ORDEN_SUBMODULO\", " +
                                "   2 AS \"TIPO\", pr.\"NOMBRE\" AS \"PROMOCION\", c.\"OID\" AS \"OID_CLASE\", apr.\"CALIFICACION\" AS \"CALIFICACION\" " +
                                "FROM " + parte + " AS p " +
                                "INNER JOIN " + horario + " AS H ON H.\"OID\" = p.\"OID_HORARIO\" AND H.\"OID_PROMOCION\" = " + oid_promo + " " +
                                "INNER JOIN " + clase_parte + " AS cp ON (cp.\"OID_PARTE\" = p.\"OID\") " +
                                "INNER JOIN " + alumno_parte + " AS ap ON (ap.\"OID_PARTE\" = p.\"OID\") " +
                                "INNER JOIN " + alumno + " AS a ON (a.\"OID\" = ap.\"OID_ALUMNO\" AND a.\"GRUPO\" = cp.\"GRUPO\") " +
                                "INNER JOIN " + clase_practica + " AS c ON (c.\"OID\" = cp.\"OID_CLASE\" AND cp.\"TIPO\" = 2) " +
                                "INNER JOIN " + alumno_practica + " AS apr ON (apr.\"OID_ALUMNO\" = a.\"OID\" AND apr.\"OID_CLASE_PRACTICA\" = c.\"OID\") " +
                                "INNER JOIN " + modulo + " AS m ON (m.\"OID\" = c.\"OID_MODULO\") " +
                                "INNER JOIN " + submodulo + " AS s ON (s.\"OID\" = c.\"OID_SUBMODULO\") " +
                                "INNER JOIN " + empleado + " AS e ON (e.\"OID\" = p.\"OID_INSTRUCTOR\" AND e.\"OID\" NOT IN ( " +
                                                                                                                        "SELECT si.\"OID_INSTRUCTOR\" " +
                                                                                                                        "FROM " + submodulo_instructor + " AS si " +
                                                                                                                        "WHERE si.\"OID_SUBMODULO\" = s.\"OID\" AND p.\"FECHA\" BETWEEN si.\"FECHA_INICIO\" AND si.\"FECHA_FIN\")) " +
                                "INNER JOIN " + alumno_promocion + " as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\") " +
                                "INNER JOIN " + promocion + " as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\" AND pr.\"OID\" = H.\"OID_PROMOCION\")  " +
                                "ORDER BY \"OID_ALUMNO\", \"ORDEN_MODULO\", \"ORDEN_SUBMODULO\", \"CLASE\";";
                return query;
            }


            private static string SELECT_NOTAS_ALUMNOS_BY_ALUMNO(long oid_alumno)
            {
                string parte = nHManager.Instance.GetSQLTable(typeof(ParteAsistenciaRecord));
                string clase_parte = nHManager.Instance.GetSQLTable(typeof(Clase_ParteRecord));
                string alumno_parte = nHManager.Instance.GetSQLTable(typeof(AlumnoParteRecord));
                string alumno = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));
                string clase_practica = nHManager.Instance.GetSQLTable(typeof(ClasePracticaRecord));
                string alumno_practica = nHManager.Instance.GetSQLTable(typeof(AlumnoPracticaRecord));
                string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
                string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
                string empleado = nHManager.Instance.GetSQLTable(typeof(InstructorRecord));
                string submodulo_instructor = nHManager.Instance.GetSQLTable(typeof(Submodulo_InstructorRecord));
                string alumno_promocion = nHManager.Instance.GetSQLTable(typeof(AlumnoPromocionRecord));
                string promocion = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));
                string horario = nHManager.Instance.GetSQLTable(typeof(HorarioRecord));

                string query = "SELECT DISTINCT a.\"NOMBRE\" AS \"NOMBRE\", a.\"APELLIDOS\" AS \"APELLIDOS\", a.\"N_EXPEDIENTE\" AS \"N_EXPEDIENTE\", " +
                                "   c.\"ALIAS\" AS \"CLASE\", m.\"NUMERO_MODULO\" AS \"NUMERO_MODULO\", m.\"TEXTO\" AS \"MODULO\", " +
                                "    s.\"CODIGO\" AS \"SUBMODULO\", p.\"FECHA\" AS \"FECHA\", p.\"HORA_INICIO\" AS \"HORA\", ea.\"NOMBRE\" AS \"PROFESOR\", " +
                                "    a.\"OID\" AS \"OID_ALUMNO\", m.\"NUMERO_ORDEN\" AS \"ORDEN_MODULO\", s.\"CODIGO_ORDEN\" AS \"ORDEN_SUBMODULO\", " +
                                "   2 AS \"TIPO\", pr.\"NOMBRE\" AS \"PROMOCION\", c.\"OID\" AS \"OID_CLASE\", apr.\"CALIFICACION\" AS \"CALIFICACION\" " +
                                "FROM " + parte + " AS p " +
                                "INNER JOIN " + horario + " AS H ON H.\"OID\" = p.\"OID_HORARIO\" " +
                                "INNER JOIN " + clase_parte + " AS cp ON (cp.\"OID_PARTE\" = p.\"OID\") " +
                                "INNER JOIN " + alumno_parte + " AS ap ON (ap.\"OID_PARTE\" = p.\"OID\") " +
                                "INNER JOIN " + alumno + " AS a ON (a.\"OID\" = ap.\"OID_ALUMNO\" AND a.\"GRUPO\" = cp.\"GRUPO\" AND a.\"OID\" = " + oid_alumno + ") " +
                                "INNER JOIN " + clase_practica + " AS c ON (c.\"OID\" = cp.\"OID_CLASE\" AND cp.\"TIPO\" = 2) " +
                                "INNER JOIN " + alumno_practica + " AS apr ON (apr.\"OID_ALUMNO\" = a.\"OID\" AND apr.\"OID_CLASE_PRACTICA\" = c.\"OID\") " +
                                "INNER JOIN " + modulo + " AS m ON (m.\"OID\" = c.\"OID_MODULO\") " +
                                "INNER JOIN " + submodulo + " AS s ON (s.\"OID\" = c.\"OID_SUBMODULO\") " +
                                "INNER JOIN " + empleado + " AS e ON (e.\"OID\" = p.\"OID_INSTRUCTOR\") " +
                                "INNER JOIN " + submodulo_instructor + " AS si ON (si.\"OID_INSTRUCTOR\" = e.\"OID\" AND si.\"OID_SUBMODULO\" = s.\"OID\" AND p.\"FECHA\" BETWEEN si.\"FECHA_INICIO\" AND si.\"FECHA_FIN\") " +
                                "INNER JOIN " + empleado + " AS ea ON (si.\"OID_INSTRUCTOR_SUPLENTE\" = ea.\"OID\") " +
                                "INNER JOIN " + alumno_promocion + " as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\") " +
                                "INNER JOIN " + promocion + " as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\" AND pr.\"OID\" = H.\"OID_PROMOCION\")  " +
                                "UNION " +
                                "SELECT DISTINCT a.\"NOMBRE\" AS \"NOMBRE\", a.\"APELLIDOS\" AS \"APELLIDOS\", a.\"N_EXPEDIENTE\" AS \"N_EXPEDIENTE\", " +
                                "   c.\"ALIAS\" AS \"CLASE\", m.\"NUMERO_MODULO\" AS \"NUMERO_MODULO\", m.\"TEXTO\" AS \"MODULO\", " +
                                "    s.\"CODIGO\" AS \"SUBMODULO\", p.\"FECHA\" AS \"FECHA\", p.\"HORA_INICIO\" AS \"HORA\", e.\"NOMBRE\" AS \"PROFESOR\", " +
                                "    a.\"OID\" AS \"OID_ALUMNO\", m.\"NUMERO_ORDEN\" AS \"ORDEN_MODULO\", s.\"CODIGO_ORDEN\" AS \"ORDEN_SUBMODULO\", " +
                                "   2 AS \"TIPO\", pr.\"NOMBRE\" AS \"PROMOCION\", c.\"OID\" AS \"OID_CLASE\", apr.\"CALIFICACION\" AS \"CALIFICACION\" " +
                                "FROM " + parte + " AS p " +
                                "INNER JOIN " + horario + " AS H ON H.\"OID\" = p.\"OID_HORARIO\" " +
                                "INNER JOIN " + clase_parte + " AS cp ON (cp.\"OID_PARTE\" = p.\"OID\") " +
                                "INNER JOIN " + alumno_parte + " AS ap ON (ap.\"OID_PARTE\" = p.\"OID\") " +
                                "INNER JOIN " + alumno + " AS a ON (a.\"OID\" = ap.\"OID_ALUMNO\" AND a.\"GRUPO\" = cp.\"GRUPO\" AND a.\"OID\" = " + oid_alumno + ") " +
                                "INNER JOIN " + clase_practica + " AS c ON (c.\"OID\" = cp.\"OID_CLASE\" AND cp.\"TIPO\" = 2) " +
                                "INNER JOIN " + alumno_practica + " AS apr ON (apr.\"OID_ALUMNO\" = a.\"OID\" AND apr.\"OID_CLASE_PRACTICA\" = c.\"OID\") " +
                                "INNER JOIN " + modulo + " AS m ON (m.\"OID\" = c.\"OID_MODULO\") " +
                                "INNER JOIN " + submodulo + " AS s ON (s.\"OID\" = c.\"OID_SUBMODULO\") " +
                                "INNER JOIN " + empleado + " AS e ON (e.\"OID\" = p.\"OID_INSTRUCTOR\" AND e.\"OID\" NOT IN ( " +
                                                                                                                        "SELECT si.\"OID_INSTRUCTOR\" " +
                                                                                                                        "FROM " + submodulo_instructor + " AS si " +
                                                                                                                        "WHERE si.\"OID_SUBMODULO\" = s.\"OID\" AND p.\"FECHA\" BETWEEN si.\"FECHA_INICIO\" AND si.\"FECHA_FIN\")) " +
                                "INNER JOIN " + alumno_promocion + " as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\") " +
                                "INNER JOIN " + promocion + " as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\" AND pr.\"OID\" = H.\"OID_PROMOCION\")  " +
                                "ORDER BY \"OID_ALUMNO\", \"ORDEN_MODULO\", \"ORDEN_SUBMODULO\", \"CLASE\";";
                return query;
            }

        #endregion
    }
}

