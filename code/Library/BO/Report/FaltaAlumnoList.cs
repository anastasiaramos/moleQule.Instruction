using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

using CslaEx;
using moleQule.Library;
using moleQule.Library.Security;

namespace moleQule.Library.Instruction
{
    public class FaltaAlumnoInfo
    {
        private string _nombre = string.Empty;
        private string _apellidos = string.Empty;
        private string _n_expediente = string.Empty;
        private string _codigo = string.Empty;
        private long _duracion;
        private string _promocion = string.Empty;
        private string _modulo = string.Empty;
        private long _total_clases;
        private decimal _porcentaje = 0;

        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Apellidos { get { return _apellidos; } set { _apellidos = value; } }
        public string NExpediente { get { return _n_expediente; } set { _n_expediente = value; } }
        public string Codigo { get { return _codigo; } set { _codigo = value; } }
        public long Duracion { get { return _duracion; } set { _duracion = value; } }
        public string Promocion { get { return _promocion; } set { _promocion = value; } }
        public string Modulo { get { return _modulo; } set { _modulo = value; } }
        public long TotalClases { get { return _total_clases; } set { _total_clases = value; } }
        public decimal Porcentaje { get { return _porcentaje; } set { _porcentaje = value; } }

        private FaltaAlumnoInfo(IDataReader reader) 
        {
            _nombre = DBNull.Value.Equals(reader["NOMBRE_ALUMNO"]) ? string.Empty : reader["NOMBRE_ALUMNO"].ToString();
            _apellidos = DBNull.Value.Equals(reader["APELLIDO_ALUMNO"]) ? string.Empty : reader["APELLIDO_ALUMNO"].ToString();
            _n_expediente = DBNull.Value.Equals(reader["EXP_ALUMNO"]) ? string.Empty : reader["EXP_ALUMNO"].ToString();
            _codigo = DBNull.Value.Equals(reader["CODIGO_ALUMNO"]) ? string.Empty : reader["CODIGO_ALUMNO"].ToString();
            _duracion = Format.DataReader.GetInt64(reader, "DURACION");
            _promocion = DBNull.Value.Equals(reader["PROMOCION"]) ? string.Empty : reader["PROMOCION"].ToString();
            _modulo = DBNull.Value.Equals(reader["MODULO"]) ? string.Empty : reader["MODULO"].ToString();
            _total_clases = DBNull.Value.Equals(reader["TOTAL"]) ? 0 : Convert.ToInt32(reader["TOTAL"]);
            _porcentaje = Format.DataReader.GetDecimal(reader, "PORC");
        }

        public static List<FaltaAlumnoInfo> GetFaltasAlumnos()
        {
            string query = SELECT_FALTAS_ALUMNOS();
            int sesion = Alumno_Partes.OpenSession();
            List<FaltaAlumnoInfo> lista = new List<FaltaAlumnoInfo>();

            IDataReader reader = nHManager.Instance.SQLNativeSelect(query);

            while (reader.Read())
            {
                lista.Add(new FaltaAlumnoInfo(reader));
            }

            Alumno_Parte.CloseSession(sesion);
            return lista;
        }

        public static List<FaltaAlumnoInfo> GetEstadisticasFaltasAlumnos()
        {
            /*List<FaltaAlumnoInfo> lista = new List<FaltaAlumnoInfo>();

            Hashtable clases_modulo = new Hashtable();
            ModuloList modulos = ModuloList.GetList(false);

            PlanEstudiosList planes = PlanEstudiosList.GetList(false);

            foreach (PlanEstudiosInfo plan in planes)
            {
                Hashtable lista_modulos = new Hashtable();
                ClaseTeoricaList teoricas = ClaseTeoricaList.GetClasesPlanList(plan.Oid);
                //ClasePracticaList practicas = ClasePracticaList.GetClasesPlanList(plan.Oid);
                foreach (ModuloInfo modulo in modulos)
                {
                    int total_clases = 0;
                    SubmoduloList submodulos = SubmoduloList.GetModuloList(modulo.Oid, false);
                    foreach (SubmoduloInfo submodulo in submodulos)
                    {
                        foreach (ClaseTeoricaInfo teorica in teoricas)
                        {
                            if (teorica.OidSubmodulo == submodulo.Oid)
                                total_clases++;
                        }
                        /*foreach (ClasePracticaInfo practica in practicas)
                        {
                            if (practica.OidSubmodulo == submodulo.Oid)
                                total_clases += 5;
                        }*/
                    /*}
                    if (total_clases > 0)
                        lista_modulos.Add(modulo.Texto, total_clases);
                }
                clases_modulo.Add(plan.Oid, lista_modulos);
            }*/

            return GetFaltasAlumnos();

            /*foreach (FaltaAlumnoInfo item in lista_completa)
            {
                bool esta = false;

                foreach (FaltaAlumnoInfo elem in lista)
                {
                    if (elem.NExpediente == item.NExpediente
                        && elem.Modulo == item.Modulo)
                    {
                        elem.Duracion += item.Duracion;
                        esta = true;
                        break;
                    }
                }

                if (!esta)
                    lista.Add(item);
            }

            foreach (FaltaAlumnoInfo item in lista)
            {
                if (clases_modulo.ContainsKey(item.OidPlan) &&
                    ((Hashtable)clases_modulo[item.OidPlan]).ContainsKey(item.Modulo))
                {
                    item.TotalClases = ((int)((Hashtable)clases_modulo[item.OidPlan])[item.Modulo]);
                    item.Porcentaje = ((float)item.Duracion / item.TotalClases) * 100;
                }
                else
                {
                    item.TotalClases = 0;
                    item.Porcentaje = 100;
                }
            }*/
        }

        private static string SELECT_FALTAS_ALUMNOS()
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
                "ORDER BY EXP_ALUMNO, ORDEN_SUBMODULO, ORDEN_CLASE; ";*/
            string query = "SELECT \"PROMOCION\", \"EXP_ALUMNO\", \"CODIGO_ALUMNO\", \"NOMBRE_ALUMNO\", \"APELLIDO_ALUMNO\", \"MODULO\", SUM(\"DURACION\") AS \"DURACION\", QUERY1.\"TOTAL\" AS \"TOTAL\", CAST(SUM(\"DURACION\") / QUERY1.\"TOTAL\" * 100 as numeric(10,2)) AS \"PORC\" " +
                            "FROM( " +
                            "SELECT pr.\"NOMBRE\" AS \"PROMOCION\", a.\"N_EXPEDIENTE\" AS \"EXP_ALUMNO\", a.\"CODIGO\" AS \"CODIGO_ALUMNO\", a.\"NOMBRE\" AS \"NOMBRE_ALUMNO\", a.\"APELLIDOS\" AS \"APELLIDO_ALUMNO\", " + 
                            "m.\"TEXTO\" AS \"MODULO\", cast(substring(p.\"N_HORAS\" from 1 for position (':' in p.\"N_HORAS\")-1) as bigint) AS \"DURACION\", QUERY2.\"TOTAL\" AS \"TOTAL\" " +
                            "FROM " +
                            "( "+
                            "SELECT PE.\"OID\" AS \"PLAN2\", MOD.\"TEXTO\" AS \"MODULO2\", COUNT(C.\"OID\") AS \"TOTAL\" " +
                            "FROM \"0001\".\"PlanEstudios\" AS PE " +
                            "INNER JOIN \"0001\".\"ClaseTeorica\" AS C ON ( C.\"OID_PLAN\" = PE.\"OID\") " +
                            "INNER JOIN \"0001\".\"Modulo\" AS MOD ON ( C.\"OID_MODULO\" = MOD.\"OID\") " +
                            "GROUP BY \"PLAN2\", \"MODULO2\" " +
                            ") AS QUERY2, \"0001\".\"Alumno_Parte\" as ap " +
                            "INNER JOIN \"0001\".\"Alumno\" as a ON (a.\"OID\" = ap.\"OID_ALUMNO\")  " +
                            "INNER JOIN \"0001\".\"ParteAsistencia\" as p ON (p.\"OID\" = ap.\"OID_PARTE\")  " +
                            "INNER JOIN \"0001\".\"Promocion\" as pr ON (pr.\"OID\" = a.\"OID_PROMOCION\")  " +
                            "INNER JOIN \"0001\".\"PlanEstudios\" as pl ON (pl.\"OID\" = pr.\"OID_PLAN\")  " +
                            "INNER JOIN \"0001\".\"ClaseTeorica\" as ct ON  " +
	                        "    (cast(substring(p.\"SESIONES\" from 1 for position(' ' in p.\"SESIONES\")) as bigint)  = ct.\"OID\" AND p.\"TIPO\" = 0)  " +
                            "INNER JOIN \"0001\".\"Modulo\" as m ON (m.\"OID\" = ct.\"OID_MODULO\")  " +
                            "WHERE ap.\"FALTA\" = 'true'  " +
                            "AND \"PLAN2\" = pl.\"OID\" AND \"MODULO2\" = m.\"TEXTO\") AS QUERY1 " +
                            "GROUP BY \"PROMOCION\", \"EXP_ALUMNO\", \"CODIGO_ALUMNO\", \"NOMBRE_ALUMNO\", \"APELLIDO_ALUMNO\", \"MODULO\", \"TOTAL\" " +
                            "ORDER BY \"PROMOCION\", \"EXP_ALUMNO\", \"MODULO\";";
            return query;
        }

    }
}
