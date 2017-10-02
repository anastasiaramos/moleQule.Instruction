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
    public class RegistroFaltasList : ReadOnlyListBaseEx<RegistroFaltasList, RegistroFaltasInfo>
	{	

		#region Business Methods
			
		#endregion
		 
		#region Factory Methods

        private RegistroFaltasList() { }

        public static RegistroFaltasList NewList() { return new RegistroFaltasList(); }
		
		/// <summary>
		/// Retrieve the complete list from db
		/// </summary>
		/// <param name="get_childs">retrieving the childs</param>
		/// <returns></returns>
		public static RegistroFaltasList GetList(bool childs)
		{
            CriteriaEx criteria = ParteAsistencia.GetCriteria(ParteAsistencia.OpenSession());
			criteria.Childs = childs;
			
			//No criteria. Retrieve all de List
			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = RegistroFaltasList.SELECT_FALTAS_ALUMNOS();
			RegistroFaltasList list = DataPortal.Fetch<RegistroFaltasList>(criteria);
			
			CloseSession(criteria.SessionCode);
			return list;
		}
		
		/// <summary>
		/// Default call for GetList(bool get_childs)
		/// </summary>
		/// <returns></returns>
		public static RegistroFaltasList GetList()
		{
			return RegistroFaltasList.GetList(true);
		}
		
		/// <summary>
		/// Devuelve una lista de todos los elementos
		/// </summary>
		/// <returns>Lista de elementos</returns>
		public static RegistroFaltasList GetList(CriteriaEx criteria)
		{
			return RegistroFaltasList.RetrieveList(typeof(RegistroFaltas), AppContext.ActiveSchema.Code, criteria);
		}
		
		/// <summary>
		/// Builds a RegistroFaltasList from a IList<!--<RegistroFaltasInfo>-->.
		/// Doesnt retrieve child data from DB.
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public static RegistroFaltasList GetList(IList<RegistroFaltasInfo> list)
		{
			RegistroFaltasList flist = new RegistroFaltasList();
			
			if (list.Count > 0)
			{
				flist.IsReadOnly = false;
				
				foreach (RegistroFaltasInfo item in list)
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
		public static SortedBindingList<RegistroFaltasInfo> GetSortedList (string sortProperty, ListSortDirection sortDirection)
		{
			SortedBindingList<RegistroFaltasInfo> sortedList = new SortedBindingList<RegistroFaltasInfo>(GetList());
			
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
        public static SortedBindingList<RegistroFaltasInfo> GetSortedList(string sortProperty, ListSortDirection sortDirection, bool childs)
        {
            SortedBindingList<RegistroFaltasInfo> sortedList = new SortedBindingList<RegistroFaltasInfo>(GetList(childs));

            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }
		
		/// <summary>
        /// Builds a RegistroFaltasList from a IList<!--<RegistroFaltas>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>RegistroFaltasList</returns>
        public static RegistroFaltasList GetList(IList<RegistroFaltas> list)
        {
            RegistroFaltasList flist = new RegistroFaltasList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (RegistroFaltas item in list)
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
							this.AddItem(RegistroFaltasInfo.Get(reader, Childs));
						}
						IsReadOnly = true;
					}
					else 
					{
						IList list = criteria.List();
						
						if (list.Count > 0)
						{
							IsReadOnly = false;
							foreach(RegistroFaltas item in list)
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

            private static string SELECT_FALTAS_ALUMNOS()
            {
                string parte = nHManager.Instance.GetSQLTable(typeof(ParteAsistenciaRecord));
                string clase_parte = nHManager.Instance.GetSQLTable(typeof(Clase_ParteRecord));
                string alumno_parte = nHManager.Instance.GetSQLTable(typeof(AlumnoParteRecord));
                string alumno = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));
                string clase_teorica = nHManager.Instance.GetSQLTable(typeof(ClaseTeoricaRecord));
                string clase_practica = nHManager.Instance.GetSQLTable(typeof(ClasePracticaRecord));
                string clase_extra = nHManager.Instance.GetSQLTable(typeof(ClaseExtraRecord));
                string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
                string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
                string empleado = nHManager.Instance.GetSQLTable(typeof(InstructorRecord));
                string alumno_promocion = nHManager.Instance.GetSQLTable(typeof(AlumnoPromocionRecord));
                string promocion = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));
                string plan_estudios = nHManager.Instance.GetSQLTable(typeof(PlanEstudiosRecord));
                string plan_extra = nHManager.Instance.GetSQLTable(typeof(PlanExtraRecord));
                string submodulo_instructor = nHManager.Instance.GetSQLTable(typeof(Submodulo_InstructorRecord));
                string horario = nHManager.Instance.GetSQLTable(typeof(HorarioRecord));

                string query1 = "SELECT DISTINCT a.\"NOMBRE\" AS \"NOMBRE\", a.\"APELLIDOS\" AS \"APELLIDOS\", a.\"N_EXPEDIENTE\" AS \"N_EXPEDIENTE\", " +
                                "   c.\"ALIAS\" AS \"CLASE\", m.\"NUMERO_MODULO\" AS \"NUMERO_MODULO\", m.\"TEXTO\" AS \"MODULO\", pr.\"OID\" AS \"OID_PROMOCION\", " +
                                "   s.\"CODIGO\" AS \"SUBMODULO\", p.\"FECHA\" AS \"FECHA\", p.\"HORA_INICIO\" AS \"HORA\",  e.\"NOMBRE\" AS \"PROFESOR\", " +
                                "    a.\"OID\" AS \"OID_ALUMNO\", m.\"NUMERO_ORDEN\" AS \"ORDEN_MODULO\", s.\"CODIGO_ORDEN\" AS \"ORDEN_SUBMODULO\", " +
                                "   1 AS \"TIPO\", pr.\"NOMBRE\" AS \"PROMOCION\", c.\"OID\" AS \"OID_CLASE\", m.\"OID\" AS \"OID_MODULO\", s.\"OID\" AS \"OID_SUBMODULO\", ap.\"RECUPERADA\" AS \"RECUPERADA\", ap.\"FECHA_RECUPERACION\" AS \"FECHA_RECUPERACION\" " +
                                "FROM " + parte + " AS p " +
                                "INNER JOIN " + clase_parte + " AS cp ON (cp.\"OID_PARTE\" = p.\"OID\") " +
                                "INNER JOIN " + alumno_parte + " AS ap ON (ap.\"OID_PARTE\" = p.\"OID\" AND ap.\"FALTA\" = 'true') " +
                                "INNER JOIN " + alumno + " AS a ON (a.\"OID\" = ap.\"OID_ALUMNO\") " +
                                "INNER JOIN " + clase_teorica + " AS c ON (c.\"OID\" = cp.\"OID_CLASE\" AND cp.\"TIPO\" = 1) " +
                                "INNER JOIN " + modulo + " AS m ON (m.\"OID\" = c.\"OID_MODULO\") " +
                                "INNER JOIN " + submodulo + " AS s ON (s.\"OID\" = c.\"OID_SUBMODULO\") " +
                                "INNER JOIN " + empleado + " AS e ON (e.\"OID\" = p.\"OID_INSTRUCTOR\" AND e.\"OID\" NOT IN ( " +
                                                                                                                        "SELECT si.\"OID_INSTRUCTOR\" " +
                                                                                                                        "FROM " + submodulo_instructor + " AS si " +
                                                                                                                        "WHERE si.\"OID_SUBMODULO\" = s.\"OID\" AND p.\"FECHA\" BETWEEN COALESCE(si.\"FECHA_INICIO\", '01-01-0001') AND COALESCE(si.\"FECHA_FIN\", '12-31-9999'))) " +

                                "INNER JOIN " + alumno_promocion + " as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\") " +
                                "INNER JOIN " + horario + " as h ON (h.\"OID\" = p.\"OID_HORARIO\") " +
                                "INNER JOIN " + promocion + " as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\" AND h.\"OID_PROMOCION\" = pr.\"OID\")   " +
                                "INNER JOIN " + plan_estudios + " as pl ON (pl.\"OID\" = pr.\"OID_PLAN\") " +
                                "UNION " +
                                "SELECT DISTINCT a.\"NOMBRE\" AS \"NOMBRE\", a.\"APELLIDOS\" AS \"APELLIDOS\", a.\"N_EXPEDIENTE\" AS \"N_EXPEDIENTE\", " +
                                "   c.\"ALIAS\" AS \"CLASE\", m.\"NUMERO_MODULO\" AS \"NUMERO_MODULO\", m.\"TEXTO\" AS \"MODULO\", pr.\"OID\" AS \"OID_PROMOCION\", " +
                                "    s.\"CODIGO\" AS \"SUBMODULO\", p.\"FECHA\" AS \"FECHA\", p.\"HORA_INICIO\" AS \"HORA\", e.\"NOMBRE\" AS \"PROFESOR\", " +
                                "    a.\"OID\" AS \"OID_ALUMNO\", m.\"NUMERO_ORDEN\" AS \"ORDEN_MODULO\", s.\"CODIGO_ORDEN\" AS \"ORDEN_SUBMODULO\", " +
                                "   2 AS \"TIPO\", pr.\"NOMBRE\" AS \"PROMOCION\", c.\"OID\" AS \"OID_CLASE\", m.\"OID\" AS \"OID_MODULO\", s.\"OID\" AS \"OID_SUBMODULO\", ap.\"RECUPERADA\" AS \"RECUPERADA\", ap.\"FECHA_RECUPERACION\" AS \"FECHA_RECUPERACION\" " +
                                "FROM " + parte + " AS p " +
                                "INNER JOIN " + clase_parte + " AS cp ON (cp.\"OID_PARTE\" = p.\"OID\") " +
                                "INNER JOIN " + alumno_parte + " AS ap ON (ap.\"OID_PARTE\" = p.\"OID\" AND ap.\"FALTA\" = 'true') " +
                                "INNER JOIN " + alumno + " AS a ON (a.\"OID\" = ap.\"OID_ALUMNO\") " +
                                "INNER JOIN " + clase_practica + " AS c ON (c.\"OID\" = cp.\"OID_CLASE\" AND cp.\"TIPO\" = 2) " +
                                "INNER JOIN " + modulo + " AS m ON (m.\"OID\" = c.\"OID_MODULO\") " +
                                "INNER JOIN " + submodulo + " AS s ON (s.\"OID\" = c.\"OID_SUBMODULO\") " +
                                "INNER JOIN " + empleado + " AS e ON (e.\"OID\" = p.\"OID_INSTRUCTOR\" AND e.\"OID\" NOT IN ( " +
                                                                                                                        "SELECT si.\"OID_INSTRUCTOR\" " +
                                                                                                                        "FROM " + submodulo_instructor + " AS si " +
                                                                                                                        "WHERE si.\"OID_SUBMODULO\" = s.\"OID\" AND p.\"FECHA\" BETWEEN COALESCE(si.\"FECHA_INICIO\", '01-01-0001') AND COALESCE(si.\"FECHA_FIN\", '12-31-9999'))) " +

                                "INNER JOIN " + alumno_promocion + " as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\") " +
                                "INNER JOIN " + horario + " as h ON (h.\"OID\" = p.\"OID_HORARIO\") " +
                                "INNER JOIN " + promocion + " as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\" AND h.\"OID_PROMOCION\" = pr.\"OID\")  " +
                                "INNER JOIN " + plan_estudios + " as pl ON (pl.\"OID\" = pr.\"OID_PLAN\") " +
                                "UNION " +
                                "SELECT DISTINCT a.\"NOMBRE\" AS \"NOMBRE\", a.\"APELLIDOS\" AS \"APELLIDOS\", a.\"N_EXPEDIENTE\" AS \"N_EXPEDIENTE\", " +
                                "   c.\"ALIAS\" AS \"CLASE\", m.\"NUMERO_MODULO\" AS \"NUMERO_MODULO\", m.\"TEXTO\" AS \"MODULO\", pr.\"OID\" AS \"OID_PROMOCION\", " +
                                "    s.\"CODIGO\" AS \"SUBMODULO\", p.\"FECHA\" AS \"FECHA\", p.\"HORA_INICIO\" AS \"HORA\",  e.\"NOMBRE\" AS \"PROFESOR\", " +
                                "    a.\"OID\" AS \"OID_ALUMNO\", m.\"NUMERO_ORDEN\" AS \"ORDEN_MODULO\", s.\"CODIGO_ORDEN\" AS \"ORDEN_SUBMODULO\", " +
                                "   3 AS \"TIPO\", pr.\"NOMBRE\" AS \"PROMOCION\", c.\"OID\" AS \"OID_CLASE\", m.\"OID\" AS \"OID_MODULO\", s.\"OID\" AS \"OID_SUBMODULO\", ap.\"RECUPERADA\" AS \"RECUPERADA\", ap.\"FECHA_RECUPERACION\" AS \"FECHA_RECUPERACION\" " +
                                "FROM " + parte + " AS p " +
                                "INNER JOIN " + clase_parte + " AS cp ON (cp.\"OID_PARTE\" = p.\"OID\") " +
                                "INNER JOIN " + alumno_parte + " AS ap ON (ap.\"OID_PARTE\" = p.\"OID\" AND ap.\"FALTA\" = 'true') " +
                                "INNER JOIN " + alumno + " AS a ON (a.\"OID\" = ap.\"OID_ALUMNO\") " +
                                "INNER JOIN " + clase_extra + " AS c ON (c.\"OID\" = cp.\"OID_CLASE\" AND cp.\"TIPO\" = 3) " +
                                "INNER JOIN " + modulo + " AS m ON (m.\"OID\" = c.\"OID_MODULO\") " +
                                "INNER JOIN " + submodulo + " AS s ON (s.\"OID\" = c.\"OID_SUBMODULO\") " +
                                "INNER JOIN " + empleado + " AS e ON (e.\"OID\" = p.\"OID_INSTRUCTOR\" AND e.\"OID\" NOT IN ( " +
                                                                                                                        "SELECT si.\"OID_INSTRUCTOR\" " +
                                                                                                                        "FROM " + submodulo_instructor + " AS si " +
                                                                                                                        "WHERE si.\"OID_SUBMODULO\" = s.\"OID\" AND p.\"FECHA\" BETWEEN COALESCE(si.\"FECHA_INICIO\", '01-01-0001') AND COALESCE(si.\"FECHA_FIN\", '12-31-9999'))) " +
                                "INNER JOIN " + alumno_promocion + " as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\") " +
                                "INNER JOIN " + horario + " as h ON (h.\"OID\" = p.\"OID_HORARIO\") " +
                                "INNER JOIN " + promocion + " as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\" AND h.\"OID_PROMOCION\" = pr.\"OID\")  " +
                                "INNER JOIN " + plan_extra + " as pl ON (pl.\"OID\" = pr.\"OID_PLAN_EXTRA\") " +
                                "UNION " +
                                "SELECT DISTINCT a.\"NOMBRE\" AS \"NOMBRE\", a.\"APELLIDOS\" AS \"APELLIDOS\", a.\"N_EXPEDIENTE\" AS \"N_EXPEDIENTE\", " +
                                "   c.\"ALIAS\" AS \"CLASE\", m.\"NUMERO_MODULO\" AS \"NUMERO_MODULO\", m.\"TEXTO\" AS \"MODULO\", pr.\"OID\" AS \"OID_PROMOCION\", " +
                                "   s.\"CODIGO\" AS \"SUBMODULO\", p.\"FECHA\" AS \"FECHA\", p.\"HORA_INICIO\" AS \"HORA\",  ea.\"NOMBRE\" AS \"PROFESOR\", " +
                                "    a.\"OID\" AS \"OID_ALUMNO\", m.\"NUMERO_ORDEN\" AS \"ORDEN_MODULO\", s.\"CODIGO_ORDEN\" AS \"ORDEN_SUBMODULO\", " +
                                "   1 AS \"TIPO\", pr.\"NOMBRE\" AS \"PROMOCION\", c.\"OID\" AS \"OID_CLASE\", m.\"OID\" AS \"OID_MODULO\", s.\"OID\" AS \"OID_SUBMODULO\", ap.\"RECUPERADA\" AS \"RECUPERADA\", ap.\"FECHA_RECUPERACION\" AS \"FECHA_RECUPERACION\" " +
                                "FROM " + parte + " AS p " +
                                "INNER JOIN " + clase_parte + " AS cp ON (cp.\"OID_PARTE\" = p.\"OID\") " +
                                "INNER JOIN " + alumno_parte + " AS ap ON (ap.\"OID_PARTE\" = p.\"OID\" AND ap.\"FALTA\" = 'true') " +
                                "INNER JOIN " + alumno + " AS a ON (a.\"OID\" = ap.\"OID_ALUMNO\") " +
                                "INNER JOIN " + clase_teorica + " AS c ON (c.\"OID\" = cp.\"OID_CLASE\" AND cp.\"TIPO\" = 1) " +
                                "INNER JOIN " + modulo + " AS m ON (m.\"OID\" = c.\"OID_MODULO\") " +
                                "INNER JOIN " + submodulo + " AS s ON (s.\"OID\" = c.\"OID_SUBMODULO\") " +
                                "INNER JOIN " + empleado + " AS e ON (e.\"OID\" = p.\"OID_INSTRUCTOR\") " +
                                "INNER JOIN (   SELECT \"OID_INSTRUCTOR\", " +
                                "                   \"OID_SUBMODULO\", " +
                                "                   MIN(COALESCE(\"FECHA_INICIO\", '01-01-0001')) AS \"FECHA_INICIO\", " +
                                "                   MAX(COALESCE(\"FECHA_FIN\", '12-31-9999')) AS \"FECHA_FIN\", " +
                                "                   MIN(\"OID_INSTRUCTOR_SUPLENTE\") AS \"OID_INSTRUCTOR_SUPLENTE\" " +
                                "               FROM " + submodulo_instructor + " " +
                                "               GROUP BY \"OID_SUBMODULO\", \"OID_INSTRUCTOR\") AS si ON (si.\"OID_INSTRUCTOR\" = e.\"OID\" AND si.\"OID_SUBMODULO\" = s.\"OID\" AND p.\"FECHA\" BETWEEN si.\"FECHA_INICIO\" AND si.\"FECHA_FIN\") " +
                                "INNER JOIN " + empleado + " AS ea ON (si.\"OID_INSTRUCTOR_SUPLENTE\" = ea.\"OID\") " +
                                "INNER JOIN " + alumno_promocion + " as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\") " +
                                "INNER JOIN " + horario + " as h ON (h.\"OID\" = p.\"OID_HORARIO\") " +
                                "INNER JOIN " + promocion + " as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\" AND h.\"OID_PROMOCION\" = pr.\"OID\")  " +
                                "INNER JOIN " + plan_estudios + " as pl ON (pl.\"OID\" = pr.\"OID_PLAN\") " +
                                "UNION " +
                                "SELECT DISTINCT a.\"NOMBRE\" AS \"NOMBRE\", a.\"APELLIDOS\" AS \"APELLIDOS\", a.\"N_EXPEDIENTE\" AS \"N_EXPEDIENTE\", " +
                                "   c.\"ALIAS\" AS \"CLASE\", m.\"NUMERO_MODULO\" AS \"NUMERO_MODULO\", m.\"TEXTO\" AS \"MODULO\", pr.\"OID\" AS \"OID_PROMOCION\", " +
                                "    s.\"CODIGO\" AS \"SUBMODULO\", p.\"FECHA\" AS \"FECHA\", p.\"HORA_INICIO\" AS \"HORA\", ea.\"NOMBRE\" AS \"PROFESOR\", " +
                                "    a.\"OID\" AS \"OID_ALUMNO\", m.\"NUMERO_ORDEN\" AS \"ORDEN_MODULO\", s.\"CODIGO_ORDEN\" AS \"ORDEN_SUBMODULO\", " +
                                "   2 AS \"TIPO\", pr.\"NOMBRE\" AS \"PROMOCION\", c.\"OID\" AS \"OID_CLASE\", m.\"OID\" AS \"OID_MODULO\", s.\"OID\" AS \"OID_SUBMODULO\", ap.\"RECUPERADA\" AS \"RECUPERADA\", ap.\"FECHA_RECUPERACION\" AS \"FECHA_RECUPERACION\" " +
                                "FROM " + parte + " AS p " +
                                "INNER JOIN " + clase_parte + " AS cp ON (cp.\"OID_PARTE\" = p.\"OID\") " +
                                "INNER JOIN " + alumno_parte + " AS ap ON (ap.\"OID_PARTE\" = p.\"OID\" AND ap.\"FALTA\" = 'true') " +
                                "INNER JOIN " + alumno + " AS a ON (a.\"OID\" = ap.\"OID_ALUMNO\") " +
                                "INNER JOIN " + clase_practica + " AS c ON (c.\"OID\" = cp.\"OID_CLASE\" AND cp.\"TIPO\" = 2) " +
                                "INNER JOIN " + modulo + " AS m ON (m.\"OID\" = c.\"OID_MODULO\") " +
                                "INNER JOIN " + submodulo + " AS s ON (s.\"OID\" = c.\"OID_SUBMODULO\") " +
                                "INNER JOIN " + empleado + " AS e ON (e.\"OID\" = p.\"OID_INSTRUCTOR\") " +
                                "INNER JOIN (   SELECT \"OID_INSTRUCTOR\", " +
                                "                   \"OID_SUBMODULO\", " +
                                "                   MIN(COALESCE(\"FECHA_INICIO\", '01-01-0001')) AS \"FECHA_INICIO\", " +
                                "                   MAX(COALESCE(\"FECHA_FIN\", '12-31-9999')) AS \"FECHA_FIN\", " +
                                "                   MIN(\"OID_INSTRUCTOR_SUPLENTE\") AS \"OID_INSTRUCTOR_SUPLENTE\" " +
                                "               FROM " + submodulo_instructor + " " +
                                "               GROUP BY \"OID_SUBMODULO\", \"OID_INSTRUCTOR\") AS si ON (si.\"OID_INSTRUCTOR\" = e.\"OID\" AND si.\"OID_SUBMODULO\" = s.\"OID\" AND p.\"FECHA\" BETWEEN si.\"FECHA_INICIO\" AND si.\"FECHA_FIN\") " +
                                "INNER JOIN " + empleado + " AS ea ON (si.\"OID_INSTRUCTOR_SUPLENTE\" = ea.\"OID\") " +
                                "INNER JOIN " + alumno_promocion + " as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\") " +
                                "INNER JOIN " + horario + " as h ON (h.\"OID\" = p.\"OID_HORARIO\") " +
                                "INNER JOIN " + promocion + " as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\" AND h.\"OID_PROMOCION\" = pr.\"OID\")  " +
                                "INNER JOIN " + plan_estudios + " as pl ON (pl.\"OID\" = pr.\"OID_PLAN\") " +
                                "UNION " +
                                "SELECT DISTINCT a.\"NOMBRE\" AS \"NOMBRE\", a.\"APELLIDOS\" AS \"APELLIDOS\", a.\"N_EXPEDIENTE\" AS \"N_EXPEDIENTE\", " +
                                "   c.\"ALIAS\" AS \"CLASE\", m.\"NUMERO_MODULO\" AS \"NUMERO_MODULO\", m.\"TEXTO\" AS \"MODULO\", pr.\"OID\" AS \"OID_PROMOCION\", " +
                                "    s.\"CODIGO\" AS \"SUBMODULO\", p.\"FECHA\" AS \"FECHA\", p.\"HORA_INICIO\" AS \"HORA\",  ea.\"NOMBRE\" AS \"PROFESOR\", " +
                                "    a.\"OID\" AS \"OID_ALUMNO\", m.\"NUMERO_ORDEN\" AS \"ORDEN_MODULO\", s.\"CODIGO_ORDEN\" AS \"ORDEN_SUBMODULO\", " +
                                "   3 AS \"TIPO\", pr.\"NOMBRE\" AS \"PROMOCION\", c.\"OID\" AS \"OID_CLASE\", m.\"OID\" AS \"OID_MODULO\", s.\"OID\" AS \"OID_SUBMODULO\", ap.\"RECUPERADA\" AS \"RECUPERADA\", ap.\"FECHA_RECUPERACION\" AS \"FECHA_RECUPERACION\" " +
                                "FROM " + parte + " AS p " +
                                "INNER JOIN " + clase_parte + " AS cp ON (cp.\"OID_PARTE\" = p.\"OID\") " +
                                "INNER JOIN " + alumno_parte + " AS ap ON (ap.\"OID_PARTE\" = p.\"OID\" AND ap.\"FALTA\" = 'true') " +
                                "INNER JOIN " + alumno + " AS a ON (a.\"OID\" = ap.\"OID_ALUMNO\") " +
                                "INNER JOIN " + clase_extra + " AS c ON (c.\"OID\" = cp.\"OID_CLASE\" AND cp.\"TIPO\" = 3) " +
                                "INNER JOIN " + modulo + " AS m ON (m.\"OID\" = c.\"OID_MODULO\") " +
                                "INNER JOIN " + submodulo + " AS s ON (s.\"OID\" = c.\"OID_SUBMODULO\") " +
                                "INNER JOIN " + empleado + " AS e ON (e.\"OID\" = p.\"OID_INSTRUCTOR\") " +
                                "INNER JOIN (   SELECT \"OID_INSTRUCTOR\", " +  
                                "                   \"OID_SUBMODULO\", " +
                                "                   MIN(COALESCE(\"FECHA_INICIO\", '01-01-0001')) AS \"FECHA_INICIO\", " +
                                "                   MAX(COALESCE(\"FECHA_FIN\", '12-31-9999')) AS \"FECHA_FIN\", " +
                                "                   MIN(\"OID_INSTRUCTOR_SUPLENTE\") AS \"OID_INSTRUCTOR_SUPLENTE\" " +
                                "               FROM " + submodulo_instructor + " " +
                                "               GROUP BY \"OID_SUBMODULO\", \"OID_INSTRUCTOR\") AS si ON (si.\"OID_INSTRUCTOR\" = e.\"OID\" AND si.\"OID_SUBMODULO\" = s.\"OID\" AND p.\"FECHA\" BETWEEN si.\"FECHA_INICIO\" AND si.\"FECHA_FIN\") " +
                                "INNER JOIN " + empleado + " AS ea ON (si.\"OID_INSTRUCTOR_SUPLENTE\" = ea.\"OID\") " +
                                "INNER JOIN " + alumno_promocion + " as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\") " +
                                "INNER JOIN " + horario + " as h ON (h.\"OID\" = p.\"OID_HORARIO\") " +
                                "INNER JOIN " + promocion + " as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\" AND h.\"OID_PROMOCION\" = pr.\"OID\")  " +
                                "INNER JOIN " + plan_extra + " as pl ON (pl.\"OID\" = pr.\"OID_PLAN_EXTRA\") " +
                                "ORDER BY \"OID_ALUMNO\", \"ORDEN_MODULO\", \"ORDEN_SUBMODULO\", \"CLASE\"";

                string query =  "SELECT CONSULTA.*, CS.*, CM.\"COUNT_MODULO\" " +
                                "FROM  " +
                                "(SELECT c.\"OID_MODULO\" AS \"OID_MODULO\", ap.\"OID_ALUMNO\" AS \"OID_ALUMNO\", cp.\"TIPO\" AS \"TIPO\", COUNT(c.\"OID_MODULO\") AS \"COUNT_MODULO\" " +
                                "FROM " + parte + " AS p  " +
	                            "    INNER JOIN " + clase_parte + " AS cp ON (cp.\"OID_PARTE\" = p.\"OID\")  " +
	                            "    INNER JOIN " + alumno_parte + " AS ap ON (ap.\"OID_PARTE\" = p.\"OID\" AND ap.\"FALTA\" = 'true')  " +
	                            "    INNER JOIN " + clase_teorica + " AS c ON (c.\"OID\" = cp.\"OID_CLASE\" AND cp.\"TIPO\" = 1)  " +
                                "GROUP BY \"OID_MODULO\", \"OID_ALUMNO\", cp.\"TIPO\" " +
                                "UNION  " +
                                "SELECT c.\"OID_MODULO\" AS \"OID_MODULO\", ap.\"OID_ALUMNO\" AS \"OID_ALUMNO\", cp.\"TIPO\" AS \"TIPO\", COUNT(c.\"OID_MODULO\") AS \"COUNT_MODULO\" " +
                                "FROM " + parte + " AS p  " +
	                            "    INNER JOIN " + clase_parte + " AS cp ON (cp.\"OID_PARTE\" = p.\"OID\")  " +
	                            "   INNER JOIN " + alumno_parte + " AS ap ON (ap.\"OID_PARTE\" = p.\"OID\" AND ap.\"FALTA\" = 'true')  " +
	                            "    INNER JOIN " + clase_practica + " AS c ON (c.\"OID\" = cp.\"OID_CLASE\" AND cp.\"TIPO\" = 2)  " +
                                "GROUP BY \"OID_MODULO\", \"OID_ALUMNO\", cp.\"TIPO\" " +
                                "UNION  " +
                                "SELECT c.\"OID_MODULO\" AS \"OID_MODULO\", ap.\"OID_ALUMNO\" AS \"OID_ALUMNO\", cp.\"TIPO\" AS \"TIPO\", COUNT(c.\"OID_MODULO\") AS \"COUNT_MODULO\" " +
                                "FROM " + parte + " AS p  " +
	                            "    INNER JOIN " + clase_parte + " AS cp ON (cp.\"OID_PARTE\" = p.\"OID\")  " +
	                            "    INNER JOIN " + alumno_parte + " AS ap ON (ap.\"OID_PARTE\" = p.\"OID\" AND ap.\"FALTA\" = 'true')  " +
	                            "    INNER JOIN " + clase_extra + " AS c ON (c.\"OID\" = cp.\"OID_CLASE\" AND cp.\"TIPO\" = 3)  " +
                                "GROUP BY \"OID_MODULO\", \"OID_ALUMNO\", cp.\"TIPO\") AS CM, " +
                                "(SELECT c.\"OID_MODULO\" AS \"OID_MODULO\", c.\"OID_SUBMODULO\" AS \"OID_SUBMODULO\", ap.\"OID_ALUMNO\" AS \"OID_ALUMNO\", cp.\"TIPO\" AS \"TIPO\", COUNT(c.\"OID_SUBMODULO\") AS \"COUNT_SUBMODULO\" " +
                                "FROM " + parte + " AS p  " +
	                            "    INNER JOIN " + clase_parte + " AS cp ON (cp.\"OID_PARTE\" = p.\"OID\")  " +
	                            "    INNER JOIN " + alumno_parte + " AS ap ON (ap.\"OID_PARTE\" = p.\"OID\" AND ap.\"FALTA\" = 'true')  " +
	                            "    INNER JOIN " + clase_teorica + " AS c ON (c.\"OID\" = cp.\"OID_CLASE\" AND cp.\"TIPO\" = 1)  " +
                                "GROUP BY \"OID_MODULO\", \"OID_SUBMODULO\", \"OID_ALUMNO\", cp.\"TIPO\" " +
                                "UNION  " +
                                "SELECT c.\"OID_MODULO\" AS \"OID_MODULO\", c.\"OID_SUBMODULO\" AS \"OID_SUBMODULO\", ap.\"OID_ALUMNO\" AS \"OID_ALUMNO\", cp.\"TIPO\" AS \"TIPO\", COUNT(c.\"OID_MODULO\") AS \"COUNT_MODULO\" " +
                                "FROM " + parte + " AS p  " +
	                            "    INNER JOIN " + clase_parte + " AS cp ON (cp.\"OID_PARTE\" = p.\"OID\")  " +
	                            "    INNER JOIN " + alumno_parte + " AS ap ON (ap.\"OID_PARTE\" = p.\"OID\" AND ap.\"FALTA\" = 'true')  " +
	                            "    INNER JOIN " + clase_practica + " AS c ON (c.\"OID\" = cp.\"OID_CLASE\" AND cp.\"TIPO\" = 2)  " +
                                "GROUP BY \"OID_MODULO\", \"OID_SUBMODULO\", \"OID_ALUMNO\", cp.\"TIPO\" " +
                                "UNION  " +
                                "SELECT c.\"OID_MODULO\" AS \"OID_MODULO\", c.\"OID_SUBMODULO\" AS \"OID_SUBMODULO\", ap.\"OID_ALUMNO\" AS \"OID_ALUMNO\", cp.\"TIPO\" AS \"TIPO\", COUNT(c.\"OID_MODULO\") AS \"COUNT_MODULO\" " +
                                "FROM " + parte + " AS p  " +
	                            "    INNER JOIN " + clase_parte + " AS cp ON (cp.\"OID_PARTE\" = p.\"OID\")  " +
	                            "    INNER JOIN " + alumno_parte + " AS ap ON (ap.\"OID_PARTE\" = p.\"OID\" AND ap.\"FALTA\" = 'true')  " +
	                            "    INNER JOIN " + clase_extra + " AS c ON (c.\"OID\" = cp.\"OID_CLASE\" AND cp.\"TIPO\" = 3)  " +
                                "GROUP BY \"OID_MODULO\", \"OID_SUBMODULO\", \"OID_ALUMNO\", cp.\"TIPO\") AS CS, " +
                                "( " + query1 + " )AS CONSULTA " +
                                "WHERE CM.\"OID_MODULO\" = CS.\"OID_MODULO\" AND CM.\"OID_ALUMNO\" = CS.\"OID_ALUMNO\" AND CM.\"TIPO\" = CS.\"TIPO\" " +
	                            "    AND CONSULTA.\"OID_MODULO\" = CS.\"OID_MODULO\" AND CONSULTA.\"OID_ALUMNO\" = CS.\"OID_ALUMNO\" AND CONSULTA.\"TIPO\" = CS.\"TIPO\"  " +
                                "    AND CONSULTA.\"OID_SUBMODULO\" = CS.\"OID_SUBMODULO\" ORDER BY \"ORDEN_MODULO\", \"ORDEN_SUBMODULO\", \"FECHA\", CONSULTA.\"OID_ALUMNO\", \"CLASE\"";

                return query;
            }

        #endregion
    }
}

