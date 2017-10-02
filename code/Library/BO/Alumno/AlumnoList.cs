using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;

using moleQule.Library.Invoice;

namespace moleQule.Library.Instruction
{
	/// <summary>
	/// Read Only Child Collection of Business Objects
	/// </summary>
    [Serializable()]
	public class AlumnoList : ReadOnlyListBaseEx<AlumnoList, AlumnoInfo>
	{

        #region Child Factory Methods

        public AlumnoList() { }

        private AlumnoList(IList<Alumno> lista)
        {
            Fetch(lista);
        }

        private AlumnoList(IDataReader reader)
        {
            Fetch(reader);
        }

        /// <summary>
        /// Builds a AlumnoList from a IList<!--<AlumnoInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>AlumnoList</returns>
        public static AlumnoList GetChildList(IList<AlumnoInfo> list)
        {
            AlumnoList flist = new AlumnoList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (AlumnoInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a AlumnoList from IList<!--<Alumno>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>AlumnoList</returns>
        public static AlumnoList GetChildList(IList<Alumno> list) { return new AlumnoList(list); }

        public static AlumnoList GetChildList(IDataReader reader) { return new AlumnoList(reader); }

        #endregion

        #region Root Factory Methods

        public static AlumnoList NewList() { return new AlumnoList(); }
        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>AlumnoList</returns>
        public static AlumnoList GetList(bool childs)
        {
            CriteriaEx criteria = Alumno.GetCriteria(Alumno.OpenSession());
            criteria.Childs = childs;
            criteria.Query = AlumnoList.SELECT();

            //No criteria. Retrieve all de List
            AlumnoList list = DataPortal.Fetch<AlumnoList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>AlumnoList</returns>
        public static AlumnoList GetOrdenAlfabeticoList(bool childs)
        {
            CriteriaEx criteria = Alumno.GetCriteria(Alumno.OpenSession());
            criteria.Childs = childs;
            criteria.Query = AlumnoList.SELECT_ORDEN_ALFABETICO();

            //No criteria. Retrieve all de List
            AlumnoList list = DataPortal.Fetch<AlumnoList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>AlumnoList</returns>
        public static AlumnoList GetOrdenAlfabeticoList(bool childs, List<Alumno_ExamenInfo> lista_ordenada)
        {
            CriteriaEx criteria = Alumno.GetCriteria(Alumno.OpenSession());
            criteria.Childs = childs;
            string oids = string.Empty;

            foreach (Alumno_ExamenInfo item in lista_ordenada)
            {
                if (oids.Length > 0)
                    oids += ", ";
                oids += item.OidAlumno.ToString();
            }

            criteria.Query = AlumnoList.SELECT_ORDEN_ALFABETICO(oids);

            //No criteria. Retrieve all de List
            AlumnoList list = DataPortal.Fetch<AlumnoList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>AlumnoList</returns>
        public static AlumnoList GetAlumnosAdmitidosList(long oid_modulo, bool desarrollo, long oid_examen, ExamenPromocionList promociones, DateTime fecha_examen, bool childs)
        {
            CriteriaEx criteria = Alumno.GetCriteria(Alumno.OpenSession());
            criteria.Childs = childs;
            criteria.Query = AlumnoList.SELECT_ALUMNOS_ADMITIDOS(oid_modulo, desarrollo, oid_examen, promociones, fecha_examen);

            //No criteria. Retrieve all de List
            AlumnoList list = DataPortal.Fetch<AlumnoList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }


        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>AlumnoList</returns>
        public static AlumnoList GetList(bool childs, string order_property)
        {
            CriteriaEx criteria = Alumno.GetCriteria(Alumno.OpenSession());
            criteria.Childs = childs;
            criteria.Query = AlumnoList.SELECT(order_property);

            //No criteria. Retrieve all de List
            AlumnoList list = DataPortal.Fetch<AlumnoList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        public static AlumnoList GetListByCliente(bool childs, long oid_cliente)
        {
            CriteriaEx criteria = Alumno.GetCriteria(Alumno.OpenSession());
            criteria.Childs = childs;
            criteria.Query = AlumnoList.SELECT_BY_CLIENTE(oid_cliente);

            //No criteria. Retrieve all de List
            AlumnoList list = DataPortal.Fetch<AlumnoList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        public static AlumnoList GetListByConvocatoria(bool childs, long oid_convocatoria)
        {
            CriteriaEx criteria = Alumno.GetCriteria(Alumno.OpenSession());
            criteria.Childs = childs;
            criteria.Query = AlumnoList.SELECT_BY_CONVOCATORIA(oid_convocatoria);

            //No criteria. Retrieve all de List
            AlumnoList list = DataPortal.Fetch<AlumnoList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        public static AlumnoList GetListByExamen(bool childs, long oid_examen)
        {
            CriteriaEx criteria = Alumno.GetCriteria(Alumno.OpenSession());
            criteria.Childs = childs;
            criteria.Query = AlumnoList.SELECT_BY_EXAMEN(oid_examen);

            //No criteria. Retrieve all de List
            AlumnoList list = DataPortal.Fetch<AlumnoList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>AlumnoList</returns>
        public static AlumnoList GetListByPromocion(long oid_promocion, bool get_childs)
        {
            CriteriaEx criteria = Alumno.GetCriteria(Alumno.OpenSession());
            criteria.Childs = get_childs;
            criteria.Query = AlumnoList.SELECT_BY_PROMOCION(oid_promocion);

            //No criteria. Retrieve all de List
            AlumnoList list = DataPortal.Fetch<AlumnoList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>AlumnoList</returns>
        public static AlumnoList GetList()
        {
            return GetList(true);
        }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static AlumnoList GetList(CriteriaEx criteria)
        {
            return AlumnoList.RetrieveList(typeof(Alumno), AppContext.ActiveSchema.Code, criteria);
        }

        /// <summary>
        /// Builds a AlumnoList from a IList<!--<AlumnoInfo>-->
        /// Doesn`t retrieve child data from DB.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>AlumnoList</returns>
        public static AlumnoList GetList(IList<AlumnoInfo> list)
        {
            AlumnoList flist = new AlumnoList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (AlumnoInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a AlumnoList from a IList<!--<Alumno>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Alumno</returns>
        public static AlumnoList GetList(IList<Alumno> list)
        {
            AlumnoList flist = new AlumnoList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (Alumno item in list)
                    flist.AddItem(item.GetInfo());

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
        public static SortedBindingList<AlumnoInfo> GetSortedList(string sortProperty,
                                                                    ListSortDirection sortDirection)
        {
            SortedBindingList<AlumnoInfo> sortedList =
                new SortedBindingList<AlumnoInfo>(GetList(false));
            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Alumno> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (Alumno item in lista)
                this.AddItem(item.GetInfo());

            IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }

        // called to copy objects data from list
        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            while (reader.Read())
                this.AddItem(Alumno.GetChild(reader).GetInfo());

            IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }

        // called to retrieve data from db
        protected override void Fetch(CriteriaEx criteria)
        {
            this.RaiseListChangedEvents = false;

            Childs = criteria.Childs;
            SessionCode = criteria.SessionCode;

            try
            {
                if (nHMng.UseDirectSQL)
                {
                    //Alumno.DoLOCK( Session());
                    IDataReader reader = null;
                    
                    reader = nHMng.SQLNativeSelect(criteria.Query);

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(AlumnoInfo.Get(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList<Alumno> list = criteria.List<Alumno>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (Alumno item in list)
                            this.AddItem(item.GetInfo());

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

        #region Root Data Access

        // called to retrieve data from db
        protected override void Fetch(string hql)
        {
            this.RaiseListChangedEvents = false;

            try
            {
                IList list = nHMng.HQLSelect(hql);

                if (list.Count > 0)
                {
                    IsReadOnly = false;

                    foreach (Alumno item in list)
                        this.AddItem(item.GetInfo());

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

        #region Commands

        public static AlumnoList CreateAlumnosList(AlumnoList alumnos, long grupo)
        {
            AlumnoList lista = new AlumnoList();

            foreach (AlumnoInfo item in alumnos)
            {
                lista.IsReadOnly = false;
                if ((item.Grupo == grupo) || (grupo == 3))
                {
                    lista.AddItem(item);
                }
                lista.IsReadOnly = true;
            }

            return lista;
        }

        public static AlumnoList CreateAlumnosList(AlumnoList alumnos, Alumno_ParteList lista_parte)
        {
            AlumnoList lista = new AlumnoList();

            foreach (Alumno_ParteInfo item in lista_parte)
            {
                lista.IsReadOnly = false;

                AlumnoInfo alumno = null;
                alumno = alumnos.GetItem(item.OidAlumno);
                if (alumno != null)
                    lista.AddItem(alumno);
                //else
                //{
                //    AlumnoInfo al = AlumnoInfo.Get(item.OidAlumno, true);
                //    lista.AddItem(al);
                //}

                lista.IsReadOnly = true;
            }

            return lista;
        }

        #endregion

        #region SQL

        public static string SELECT()
        {
            return AlumnoInfo.SELECT(0);
        }

        public static string SELECT(string order_property)
        {
            return AlumnoInfo.SELECT(0, order_property);
        }

        public static string SELECT_ORDEN_ALFABETICO()
        {
            string a = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));
            string p = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));

            string query = "SELECT A.*, TO_ASCII(A.\"APELLIDOS\", 'LATIN1') AS AP, TO_ASCII(A.\"NOMBRE\", 'LATIN1') AS NOM " +
                    " FROM " + a + " AS A";

            query += " ORDER BY AP, NOM;";

            return query;
        }

        public static string SELECT_ORDEN_ALFABETICO(string lista)
        {
            string a = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));
            string p = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));

            string query = "SELECT A.*, TO_ASCII(A.\"APELLIDOS\", 'LATIN1') AS AP, TO_ASCII(A.\"NOMBRE\", 'LATIN1') AS NOM " +
                    " FROM " + a + " AS A" +
                    " WHERE A.\"OID\" IN (" + lista + ")";

            query += " ORDER BY AP, NOM;";

            return query;
        }

        public static string SELECT_ALUMNOS_ADMITIDOS(long oid_modulo, bool desarrollo, long oid_examen, ExamenPromocionList promociones, DateTime fecha_examen)
        {
            bool criterio_nota = ModulePrincipal.GetCriterioPorcentajeMinimoExamenAprobadoSetting();
            bool criterio_faltas = ModulePrincipal.GetCriterioPorcentajeMaximoFaltasModuloSetting();

            long porcentaje_nota = ModulePrincipal.GetPorcentajeMinimoExamenAprobadoSetting();
            long porcentaje_faltas = ModulePrincipal.GetPorcentajeMaximoFaltasModuloSetting();

            string clase_teorica = nHManager.Instance.GetSQLTable(typeof(ClaseTeoricaRecord));
            string plan_estudios = nHManager.Instance.GetSQLTable(typeof(PlanEstudiosRecord));
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string promocion = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));
            string alumno_promocion = nHManager.Instance.GetSQLTable(typeof(AlumnoPromocionRecord));
            string alumno = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));
            string alumno_examen = nHManager.Instance.GetSQLTable(typeof(AlumnoExamenRecord));
            string examen = nHManager.Instance.GetSQLTable(typeof(ExamenRecord));
            string parte_asistencia = nHManager.Instance.GetSQLTable(typeof(ParteAsistenciaRecord));
            string clase_parte = nHManager.Instance.GetSQLTable(typeof(Clase_ParteRecord));
            string plan_extra = nHManager.Instance.GetSQLTable(typeof(PlanExtraRecord));
            string clase_extra = nHManager.Instance.GetSQLTable(typeof(ClaseExtraRecord));
            string respuesta_alumno_examen = nHManager.Instance.GetSQLTable(typeof(Respuesta_Alumno_ExamenRecord));
            string pregunta_examen = nHManager.Instance.GetSQLTable(typeof(PreguntaExamenRecord));
            string horario = nHManager.Instance.GetSQLTable(typeof(HorarioRecord));

            string query = "SELECT DISTINCT A.*, TO_ASCII(A.\"APELLIDOS\", 'LATIN1') AS AP, TO_ASCII(A.\"NOMBRE\", 'LATIN1') AS NOM " +
                        "FROM " + plan_estudios + " AS P " +
                /*"INNER JOIN " + clase_teorica + " AS C ON (C.\"OID_PLAN\" = P.\"OID\") " +
                "INNER JOIN " + modulo + " AS M ON (C.\"OID_MODULO\" = M.\"OID\") " +*/
                        "INNER JOIN " + promocion + " AS PR ON (PR.\"OID_PLAN\" = P.\"OID\") " +
                        "INNER JOIN " + alumno_promocion + " AS APR ON (APR.\"OID_PROMOCION\" = PR.\"OID\") " +
                        "INNER JOIN " + alumno + " AS A ON (A.\"OID\" = APR.\"OID_ALUMNO\") " +
                        "WHERE TRUE "; //M.\"OID\" = " + oid_modulo.ToString() + "  ";

            if (criterio_nota)
            {
                if (!desarrollo)
                {
                    query += "    AND A.\"OID\" NOT IN ( " +
                            "            SELECT AL.\"OID\" " +
                            "            FROM " + alumno + " AS AL " +
                            "            INNER JOIN " + alumno_examen + " AS AE ON (AE.\"OID_ALUMNO\" = AL.\"OID\") " +
                            "            INNER JOIN " + examen + " AS E ON (E.\"OID\" = AE.\"OID_EXAMEN\") " +
                            "            WHERE E.\"OID_MODULO\" = " + oid_modulo.ToString() + " AND AE.\"PRESENTADO\" = TRUE AND E.\"DESARROLLO\" = " + desarrollo.ToString() + " AND E.\"OID\" != " + oid_examen.ToString() + " " +
                            "            AND AE.\"CALIFICACION\" >= " + porcentaje_nota.ToString() + " "+
                            ") ";
                }
                else
                {
                    query += "    AND A.\"OID\" NOT IN ( " +
                            "           SELECT DISTINCT AL.\"OID\" "  +          
                            "            FROM " + alumno + " AS AL "  +    
                            "            INNER JOIN " + alumno_examen + " AS AE ON (AE.\"OID_ALUMNO\" = AL.\"OID\") "  +        
                            "            INNER JOIN " + examen + " AS E ON (E.\"OID\" = AE.\"OID_EXAMEN\")  "  +
                            "            INNER JOIN ( "  +
                            "                SELECT AE.\"OID\" AS \"OID_ALUMNO_EXAMEN\", COUNT(R.\"CALIFICACION\") AS \"APROBADAS\"  "  +     
                            "                FROM " + alumno + " AS AL "  +
                            "                INNER JOIN " + alumno_examen + " AS AE ON (AE.\"OID_ALUMNO\" = AL.\"OID\") "  +     
                            "                INNER JOIN " + examen + " AS E ON (E.\"OID\" = AE.\"OID_EXAMEN\") "  +
                            "                INNER JOIN " + respuesta_alumno_examen + " AS R ON (R.\"OID_ALUMNO_EXAMEN\" = AE.\"OID\") "  +       
                            "                WHERE E.\"OID_MODULO\" = " + oid_modulo.ToString() + " AND E.\"DESARROLLO\" = " + desarrollo.ToString() + " AND R.\"CALIFICACION\" >= " + porcentaje_nota.ToString() + " "  +
                            "                GROUP BY AE.\"OID\") AS Q1 ON (Q1.\"OID_ALUMNO_EXAMEN\" = AE.\"OID\") "  +
                            "            INNER JOIN ( "  +
                            "                SELECT E.\"OID\" AS \"OID_EXAMEN\", COUNT(P.\"OID\") AS \"TOTALES\" "  +
                            "                FROM " + examen + " AS E "  +
                            "                INNER JOIN " + pregunta_examen + " AS P ON (P.\"OID_EXAMEN\" = E.\"OID\")  "  +
                            "                WHERE E.\"OID_MODULO\" = " + oid_modulo.ToString() + " AND E.\"DESARROLLO\" = " + desarrollo.ToString() + " AND E.\"OID\" != " + oid_examen.ToString() + " " +
                            "                GROUP BY E.\"OID\") AS Q2 ON (Q2.\"OID_EXAMEN\" = E.\"OID\") "  +
                            "            WHERE Q1.\"APROBADAS\" = Q2.\"TOTALES\" " +
                            ") ";
                }
            }


            if (criterio_faltas)
                query += "    AND A.\"OID\" NOT IN ( " +
                        "        SELECT AL.\"OID_ALUMNO\" " +
                        "        FROM ( " +
                        "            SELECT CAST(SUM(\"DURACION\") / SUM(QUERY1.\"TOTAL\") * 100 as numeric(10,2)) AS \"PORC\", \"OID_MODULO\", QUERY1.\"OID_ALUMNO\" " +
                        "            FROM(     " +
                        "                SELECT m.\"OID\" AS \"OID_MODULO\", a.\"OID\" AS \"OID_ALUMNO\", pr.\"OID\" AS \"OID_PROMOCION\", COUNT(cp.\"OID\") AS \"DURACION\", QUERY2.\"TOTAL\" AS \"TOTAL\"   " +
                        "                FROM        (         " +
                        "                    SELECT PE.\"OID\" AS \"PLAN2\", MOD.\"TEXTO\" AS \"MODULO2\", COUNT(C.\"OID\") AS \"TOTAL\"  " +
                        "                    FROM " + plan_estudios + " AS PE         " +
                        "                    INNER JOIN " + clase_teorica + " AS C ON ( C.\"OID_PLAN\" = PE.\"OID\")  " +
                        "                    INNER JOIN " + modulo + " AS MOD ON ( C.\"OID_MODULO\" = MOD.\"OID\")   " +
                        "                    GROUP BY \"PLAN2\", \"MODULO2\"        ) AS QUERY2, \"0001\".\"Alumno_Parte\" as ap   " +
                        "                INNER JOIN " + alumno + " as a ON (a.\"OID\" = ap.\"OID_ALUMNO\")      " +
                        "                INNER JOIN " + parte_asistencia + " as p ON (p.\"OID\" = ap.\"OID_PARTE\")      " +
                        "                INNER JOIN " + horario + " AS hr ON (hr.\"OID\" = p.\"OID_HORARIO\")   " +
                        "                INNER JOIN " + alumno_promocion + " as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\")   " +
                        "                INNER JOIN " + promocion + " as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\" AND hr.\"OID_PROMOCION\" = pr.\"OID\")      " +
                        "                INNER JOIN " + plan_estudios + " as pl ON (pl.\"OID\" = pr.\"OID_PLAN\")      " +
                        "                INNER JOIN " + clase_parte + " as cp ON (p.\"OID\" = cp.\"OID_PARTE\")      " +
                        "                INNER JOIN " + clase_teorica + " as ct ON  (ct.\"OID\" = cp.\"OID_CLASE\")      " +
                        "                INNER JOIN " + modulo + " as m ON (m.\"OID\" = ct.\"OID_MODULO\")      " +
                        "                WHERE ap.\"FALTA\" = 'true' AND ap.\"RECUPERADA\" = 'false' AND cp.\"TIPO\" = 1         AND \"PLAN2\" = pl.\"OID\" AND \"MODULO2\" = m.\"TEXTO\"    " +
                        /*"                GROUP BY \"TOTAL\", m.\"OID\", a.\"OID\", pr.\"OID\"     " +
                        "                UNION     " +
                        "                SELECT m.\"OID\" AS \"OID_MODULO\", a.\"OID\" AS \"OID_ALUMNO\", pr.\"OID\" AS \"OID_PROMOCION\", COUNT(cp.\"OID\") AS \"DURACION\", QUERY2.\"TOTAL\" AS \"TOTAL\"     " +
                        "                FROM        (         " +
                        "                    SELECT PE.\"OID\" AS \"PLAN2\", MOD.\"TEXTO\" AS \"MODULO2\", COUNT(C.\"OID\") AS \"TOTAL\"     " +
                        "                    FROM " + plan_extra + " AS PE         " +
                        "                    INNER JOIN " + clase_extra + " AS C ON ( C.\"OID_PLAN\" = PE.\"OID\")   " +
                        "                    INNER JOIN " + modulo + " AS MOD ON ( C.\"OID_MODULO\" = MOD.\"OID\")   " +
                        "                    GROUP BY \"PLAN2\", \"MODULO2\"        ) AS QUERY2, \"0001\".\"Alumno_Parte\" as ap     " +
                        "                INNER JOIN " + alumno + " as a ON (a.\"OID\" = ap.\"OID_ALUMNO\")      " +
                        "                INNER JOIN " + parte_asistencia + " as p ON (p.\"OID\" = ap.\"OID_PARTE\")   " +
                        "                INNER JOIN " + horario + " AS hr ON (hr.\"OID\" = p.\"OID_HORARIO\")   " +
                        "                INNER JOIN " + alumno_promocion + " as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\")   " +
                        "                INNER JOIN " + promocion + " as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\" AND hr.\"OID_PROMOCION\" = pr.\"OID\")      " +
                        "                INNER JOIN " + plan_extra + " as pl ON (pl.\"OID\" = pr.\"OID_PLAN_EXTRA\")      " +
                        "                INNER JOIN " + clase_parte + " as cp ON (p.\"OID\" = cp.\"OID_PARTE\")      " +
                        "                INNER JOIN " + clase_extra + " as ct ON  (ct.\"OID\" = cp.\"OID_CLASE\")      " +
                        "                INNER JOIN " + modulo + " as m ON (m.\"OID\" = ct.\"OID_MODULO\")      " +
                        "                WHERE ap.\"FALTA\" = 'true' AND ap.\"RECUPERADA\" = 'false' AND cp.\"TIPO\" = 3         AND \"PLAN2\" = pl.\"OID\" AND \"MODULO2\" = m.\"TEXTO\"    " +
                        */"                GROUP BY \"TOTAL\", m.\"OID\", a.\"OID\", pr.\"OID\"    ) AS QUERY1 " +
                        "            WHERE \"OID_MODULO\" = " + oid_modulo.ToString() + " " +
                        "            GROUP BY \"OID_MODULO\", QUERY1.\"OID_ALUMNO\")AS AL " +
                        "      WHERE AL.\"PORC\" > " + porcentaje_faltas.ToString() + " " +
                        ") ";

            /*query += @" AND A.""OID"" NOT IN (
                            SELECT ""OID_ALUMNO""
                            FROM (
	                            SELECT  ""OID_ALUMNO"",
		                            COALESCE(	(SELECT DISTINCT xi.""FECHA_EXAMEN""
				                            FROM    (	SELECT AE.""OID"", AE.""OID_ALUMNO"", EX.""FECHA_EXAMEN""
						                            FROM " + alumno_examen + @" AS AE
						                            INNER JOIN " + examen + @" AS EX ON AE.""OID_EXAMEN"" = EX.""OID""
						                            WHERE AE.""PRESENTADO"" = 'TRUE' AND EX.""OID_MODULO"" = " + oid_modulo.ToString() + @" AND EX.""FECHA_EXAMEN"" > '2012-08-31' AND EX.""DESARROLLO"" = " + desarrollo.ToString() + @") xi
				                            WHERE   xi.""OID_ALUMNO"" = xo.""OID_ALUMNO""
				                            ORDER BY ""FECHA_EXAMEN"" DESC
				                            OFFSET 0 LIMIT 1), '9999-12-31') AS ""FECHA1"",
		                            COALESCE(
				                            (SELECT DISTINCT xi.""FECHA_EXAMEN""
				                            FROM    (	SELECT AE.""OID"", AE.""OID_ALUMNO"", EX.""FECHA_EXAMEN""
						                            FROM " + alumno_examen + @" AS AE
						                            INNER JOIN " + examen + @" AS EX ON AE.""OID_EXAMEN"" = EX.""OID""
						                            WHERE AE.""PRESENTADO"" = 'TRUE' AND EX.""OID_MODULO"" = " + oid_modulo.ToString() + @" AND EX.""FECHA_EXAMEN"" > '2012-08-31' AND EX.""DESARROLLO"" = " + desarrollo.ToString() + @") xi
				                            WHERE   xi.""OID_ALUMNO"" = xo.""OID_ALUMNO""
				                            ORDER BY ""FECHA_EXAMEN"" DESC
				                            OFFSET 1 LIMIT 1), '9999-12-31') AS ""FECHA2"",
		                            COALESCE(
				                            (SELECT DISTINCT xi.""FECHA_EXAMEN""
				                            FROM    (	SELECT AE.""OID"", AE.""OID_ALUMNO"", EX.""FECHA_EXAMEN""
						                            FROM " + alumno_examen + @" AS AE
						                            INNER JOIN " + examen + @" AS EX ON AE.""OID_EXAMEN"" = EX.""OID""
						                            WHERE AE.""PRESENTADO"" = 'TRUE' AND EX.""OID_MODULO"" = " + oid_modulo.ToString() + @" AND EX.""FECHA_EXAMEN"" > '2012-08-31' AND EX.""DESARROLLO"" = " + desarrollo.ToString() + @") xi
				                            WHERE   xi.""OID_ALUMNO"" = xo.""OID_ALUMNO""
				                            ORDER BY ""FECHA_EXAMEN"" DESC
				                            OFFSET 2 LIMIT 1), '9999-12-31') AS ""FECHA3""
	                            FROM    (	SELECT  DISTINCT ""OID_ALUMNO""
			                            FROM    (	SELECT AE.""OID"", AE.""OID_ALUMNO"", EX.""FECHA_EXAMEN""
					                            FROM " + alumno_examen + @" AS AE
					                            INNER JOIN " + examen + @" AS EX ON AE.""OID_EXAMEN"" = EX.""OID""
					                            WHERE AE.""PRESENTADO"" = 'TRUE' AND EX.""OID_MODULO"" = " + oid_modulo.ToString() + @" AND EX.""FECHA_EXAMEN"" > '2012-08-31' AND EX.""DESARROLLO"" = " + desarrollo.ToString() + @") AS XM) xo
                            ) AS Q
                            WHERE ""FECHA1"" != '9999-12-31' AND ""FECHA2"" != '9999-12-31' AND ""FECHA3"" != '9999-12-31'
	                            AND date '" + fecha_examen.ToString("yyyy-MM-dd") + @"' - interval '1 year' <= ""FECHA1"")";*/

            query += @" AND A.""OID"" NOT IN (
                            SELECT ""OID_ALUMNO""
                            FROM (
	                            SELECT  DISTINCT MAX(xi.""FECHA_EXAMEN"") AS ""FECHA_EXAMEN"", COUNT(xi.""FECHA_EXAMEN"") AS ""PRESENTADOS"", ""OID_ALUMNO""
                                FROM    (	SELECT AE.""OID"", AE.""OID_ALUMNO"", EX.""FECHA_EXAMEN""
						                    FROM " + alumno_examen + @" AS AE
						                    INNER JOIN " + examen + @" AS EX ON AE.""OID_EXAMEN"" = EX.""OID""
						                    WHERE AE.""PRESENTADO"" = 'TRUE' AND EX.""OID_MODULO"" = " + oid_modulo.ToString() + @" AND EX.""FECHA_EXAMEN"" > '2012-08-31' AND EX.""FECHA_EXAMEN"" < '" + fecha_examen.ToString("yyyy-MM-dd") + @"' AND EX.""DESARROLLO"" = " + desarrollo.ToString() + @") xi
				                            GROUP BY ""OID_ALUMNO""
				                            ORDER BY ""FECHA_EXAMEN""
	                      ) AS Q
                            WHERE ""PRESENTADOS"" % 3 = 0 AND ""FECHA_EXAMEN"" != '9999-12-31'
	                            AND date '" + fecha_examen.ToString("yyyy-MM-dd") + @"' - interval '1 year' <= ""FECHA_EXAMEN"")";


            if (oid_examen > 0)
            {
                //ExamenInfo info = ExamenInfo.Get(oid_examen, false);

                //info.LoadChilds(typeof(ExamenPromocion), false);

                if (promociones.Count > 0)
                {
//                    string ep = nHManager.Instance.GetSQLTable(typeof(ExamenPromocionRecord));

//                    query += @" AND PR.""OID"" IN ( SELECT ""OID_PROMOCION""
//                                                    FROM " + ep + @"
//                                                    WHERE ""OID_EXAMEN"" = " + oid_examen.ToString() + @")";
                    string list_promos = "(";

                    foreach (ExamenPromocionInfo expr in promociones)
                        list_promos += expr.OidPromocion.ToString() + ", ";

                    list_promos = list_promos.Substring(0, list_promos.Length - 2);

                    list_promos += ")";

                    query += @" AND PR.""OID"" IN " + list_promos;
                }
            }
            query += " ORDER BY \"APELLIDOS\", \"NOMBRE\";";

            return query;
        }

        public static string SELECT_BY_CLIENTE(long oid_cliente)
        {
            string ac = nHManager.Instance.GetSQLTable(typeof(AlumnoClienteRecord));

            string query = AlumnoInfo.SELECT(0);

            query += " INNER JOIN " + ac + " AS AC ON (A.\"OID\" = AC.\"OID_ALUMNO\")" +
                        " WHERE AC.\"OID_CLIENTE\" = '" + oid_cliente.ToString() + "' " +
                        " ORDER BY A.\"APELLIDOS\", A.\"NOMBRE\"";

            return query;
        }

        public static string SELECT_BY_CONVOCATORIA(long oid_convocatoria)
        {
            string ac = nHManager.Instance.GetSQLTable(typeof(AlumnoConvocatoriaRecord));

            string query = AlumnoInfo.SELECT(0);

            query += " INNER JOIN   " + ac + " AS AC ON (A.\"OID\" =  AC.\"OID_ALUMNO\") " +
                        " WHERE AC.\"OID\" = '" + oid_convocatoria.ToString() + "'";

            return query;
        }

        public static string SELECT_BY_EXAMEN(long oid_examen)
        {
            string ae = nHManager.Instance.GetSQLTable(typeof(AlumnoExamenRecord));

            string query = AlumnoInfo.SELECT(0);

            query += " INNER JOIN   " + ae + " AS AE ON (A.\"OID\" =  AE.\"OID_ALUMNO\") " +
                        " WHERE AE.\"OID_EXAMEN\" = '" + oid_examen.ToString() + "'";

            return query;
        }

        public static string SELECT_BY_PROMOCION(long oid_promocion)
        {
            string ap = nHManager.Instance.GetSQLTable(typeof(AlumnoPromocionRecord));

            string query = AlumnoInfo.SELECT(0);

            query +=    " INNER JOIN " + ap + " AS AP ON AP.\"OID_ALUMNO\" = A.\"OID\" " +
                        " WHERE AP.\"OID_PROMOCION\" = " + oid_promocion.ToString() +
                        " ORDER BY TO_ASCII(A.\"APELLIDOS\", 'LATIN1'), TO_ASCII(A.\"NOMBRE\", 'LATIN1')";

            return query;
        }

        #endregion

    }
}

