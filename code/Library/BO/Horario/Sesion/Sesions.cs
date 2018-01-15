using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Instruction;

namespace moleQule.Library.Instruction
{
	/// <summary>
	/// Editable Child Collection
	/// </summary>
	[Serializable()]
	public class Sesions : BusinessListBaseEx<Sesions, Sesion>
	{
		#region Business Methods

		public Sesion NewItem(Horario parent)
		{
			this.AddItem(Sesion.NewChild(parent));
			return this[Count - 1];
		}

		public Sesion NewItem(ClaseTeorica parent)
		{
			this.AddItem(Sesion.NewChild(parent));
			return this[Count - 1];
		}

		public Sesion NewItem(ClasePractica parent)
		{
			this.AddItem(Sesion.NewChild(parent));
			return this[Count - 1];
		}

		public Sesion NewItem(ClaseExtra parent)
		{
			this.AddItem(Sesion.NewChild(parent));
			return this[Count - 1];
		}

		public Sesion NewItem(Instructor parent)
		{
			this.AddItem(Sesion.NewChild(parent));
			return this[Count - 1];
		}

		#endregion

		#region Factory Methods

		private Sesions()
		{
			MarkAsChild();
		}

		private Sesions(IList<Sesion> lista)
		{
			MarkAsChild();
			Fetch(lista);
		}

		private Sesions(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}


		public static Sesions NewChildList() { return new Sesions(); }

		public static Sesions GetChildList(IList<Sesion> lista) { return new Sesions(lista); }

		public static Sesions GetChildList(IDataReader reader, bool childs) { return new Sesions(reader, childs); }

		public static Sesions GetChildList(IDataReader reader) { return GetChildList(reader, true); }

		#endregion

		#region Child Data Access

		// called to copy objects data from list
		private void Fetch(IList<Sesion> lista)
		{
			this.RaiseListChangedEvents = false;

			foreach (Sesion item in lista)
				this.AddItem(Sesion.GetChild(item));

			this.RaiseListChangedEvents = true;
		}

		private void Fetch(IDataReader reader)
		{
			this.RaiseListChangedEvents = false;

			while (reader.Read())
				this.AddItem(Sesion.GetChild(reader));

			this.RaiseListChangedEvents = true;
		}


		internal void Update(Horario parent)
		{
			this.RaiseListChangedEvents = false;

			// update (thus deleting) any deleted child objects
			foreach (Sesion obj in DeletedList)
				obj.DeleteSelf(parent);

			// now that they are deleted, remove them from memory too
			DeletedList.Clear();

			// AddItem/update any current child objects
			foreach (Sesion obj in this)
			{
				if (obj.IsNew)
					obj.Insert(parent);
				else
					obj.Update(parent);
			}

			this.RaiseListChangedEvents = true;
		}

		internal void Update(ClaseTeorica parent)
		{
			this.RaiseListChangedEvents = false;

			// update (thus deleting) any deleted child objects
			foreach (Sesion obj in DeletedList)
				obj.DeleteSelf(parent);

			// now that they are deleted, remove them from memory too
			DeletedList.Clear();

			// AddItem/update any current child objects
			foreach (Sesion obj in this)
			{
				if (obj.IsNew)
					obj.Insert(parent);
				else
					obj.Update(parent);
			}

			this.RaiseListChangedEvents = true;
		}

		internal void Update(ClasePractica parent)
		{
			this.RaiseListChangedEvents = false;

			// update (thus deleting) any deleted child objects
			foreach (Sesion obj in DeletedList)
				obj.DeleteSelf(parent);

			// now that they are deleted, remove them from memory too
			DeletedList.Clear();

			// AddItem/update any current child objects
			foreach (Sesion obj in this)
			{
				if (obj.IsNew)
					obj.Insert(parent);
				else
					obj.Update(parent);
			}

			this.RaiseListChangedEvents = true;
		}

		internal void Update(ClaseExtra parent)
		{
			this.RaiseListChangedEvents = false;

			// update (thus deleting) any deleted child objects
			foreach (Sesion obj in DeletedList)
				obj.DeleteSelf(parent);

			// now that they are deleted, remove them from memory too
			DeletedList.Clear();

			// AddItem/update any current child objects
			foreach (Sesion obj in this)
			{
				if (obj.IsNew)
					obj.Insert(parent);
				else
					obj.Update(parent);
			}

			this.RaiseListChangedEvents = true;
		}

		internal void Update(Instructor parent)
		{
			this.RaiseListChangedEvents = false;

			// update (thus deleting) any deleted child objects
			foreach (Sesion obj in DeletedList)
				obj.DeleteSelf(parent);

			// now that they are deleted, remove them from memory too
			DeletedList.Clear();

			// AddItem/update any current child objects
			foreach (Sesion obj in this)
			{
				if (obj.IsNew)
					obj.Insert(parent);
				else
					obj.Update(parent);
			}

			this.RaiseListChangedEvents = true;
		}

		#endregion

		#region SQL

		public static string SELECT_BY_INSTRUCTOR(long oid_instructor, bool lock_table)
		{
            string s = nHManager.Instance.GetSQLTable(typeof(SesionRecord));
			
            string query;

			query = "SELECT S.* " +
					" FROM " + s + " AS S" +
                    " WHERE S.\"OID_PROFESOR\" = " + oid_instructor.ToString();
            
            if (lock_table) query += " FOR UPDATE OF S NOWAIT";
            
            return query;
		}

        internal static string SELECT_BY_HORARIO(long oid_horario, bool lock_table)
        {
            string s = nHManager.Instance.GetSQLTable(typeof(SesionRecord));
            string i = nHManager.Instance.GetSQLTable(typeof(InstructorRecord));
            string sm = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
            string ct = nHManager.Instance.GetSQLTable(typeof(ClaseTeoricaRecord));
            string cp = nHManager.Instance.GetSQLTable(typeof(ClasePracticaRecord));
            string ce = nHManager.Instance.GetSQLTable(typeof(ClaseExtraRecord));
            string si = nHManager.Instance.GetSQLTable(typeof(Submodulo_InstructorRecord));

            bool autorizados = ModulePrincipal.GetMostrarInstructoresAutorizadosSetting();

            string query;

            if (!autorizados)
                query = "SELECT DISTINCT S.*, S.\"OID_PROFESOR\" AS \"OID_AUTORIZADO\" " +
                    " FROM " + s + " AS S" +
                    " WHERE S.\"OID_HORARIO\" = " + oid_horario.ToString() +
                    " ORDER BY S.\"FECHA\", S.\"HORA\"";
            else
                query = "SELECT DISTINCT S.*," +
                    " COALESCE(I.\"OID\", S.\"OID_PROFESOR\") AS \"OID_AUTORIZADO\"" +
                    " FROM " + s + " AS S" +
                    " INNER JOIN ( SELECT COALESCE(CT.\"OID_SUBMODULO\", COALESCE(CP.\"OID_SUBMODULO\", COALESCE(CE.\"OID_SUBMODULO\", 0))) AS \"OID_SUBMODULO\"," +
                    "           S.\"OID\" AS \"OID_SESION\"" +
                    "       FROM " + s + " AS S" +
                    "       LEFT JOIN " + ct + " AS CT ON CT.\"OID\" = S.\"OID_CLASE_TEORICA\"" +
                    "       LEFT JOIN " + cp + " AS CP ON CP.\"OID\" = S.\"OID_CLASE_PRACTICA\"" +
                    "       LEFT JOIN " + ce + " AS CE ON CE.\"OID\" = S.\"OID_CLASE_EXTRA\")" +
                    "   AS C ON C.\"OID_SESION\" = S.\"OID\"" +
                    " LEFT JOIN " + sm + " AS SM ON SM.\"OID\" = C.\"OID_SUBMODULO\"" +
                    " LEFT JOIN " + si + " AS SI ON SI.\"OID_SUBMODULO\" = SM.\"OID\" AND SI.\"OID_INSTRUCTOR\" = S.\"OID_PROFESOR\" AND S.\"FECHA\" BETWEEN COALESCE(SI.\"FECHA_INICIO\", '01-01-0001') AND COALESCE(SI.\"FECHA_FIN\", '12-31-2999')" +
                    " LEFT JOIN " + i + " AS I ON I.\"OID\" = SI.\"OID_INSTRUCTOR_SUPLENTE\"" +
                    " WHERE S.\"OID_HORARIO\" = " + oid_horario.ToString() +
                    " ORDER BY S.\"FECHA\", S.\"HORA\"";

            //if (lock_table) query += " FOR UPDATE OF S NOWAIT";

            return query;
        }

        public static string SELECT_BY_HORARIO(long oid_horario) { return SELECT_BY_HORARIO(oid_horario, true); }

        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public static string SELECT_SESIONES_PROGRAMADAS(long oid_plan, long oid_promocion)
        {
            string sesion = nHManager.Instance.GetSQLTable(typeof(SesionRecord));
            string horario = nHManager.Instance.GetSQLTable(typeof(HorarioRecord));
            string claset = nHManager.Instance.GetSQLTable(typeof(ClaseTeoricaRecord));
            string clasep = nHManager.Instance.GetSQLTable(typeof(ClasePracticaRecord));
            string oid_modulo = nHManager.Instance.GetTableField(typeof(ClaseTeoricaRecord), "OidModulo");
            string oid_clase_teorica = nHManager.Instance.GetTableField(typeof(SesionRecord), "OidClaseTeorica");
            string oid_clase_practica = nHManager.Instance.GetTableField(typeof(SesionRecord), "OidClasePractica");
            string oid_horario = nHManager.Instance.GetTableField(typeof(SesionRecord), "OidHorario");

            string query;

            query = "SELECT s.*, s.\"OID_PROFESOR\" AS \"OID_AUTORIZADO\", ct.\"OID_MODULO\" AS \"OID_MODULO\" " +
                    "FROM " + sesion + " AS s " +
                    "INNER JOIN " + horario + " AS h ON (" + oid_plan + " = h.\"OID_PLAN\" AND " + oid_promocion + " = h.\"OID_PROMOCION\" AND s.\"" + oid_horario + "\" = h.\"OID\") " +
                    "INNER JOIN " + claset + " AS ct ON (s.\"" + oid_clase_teorica + "\" > 0 AND s.\"" + oid_clase_teorica + "\" = ct.\"OID\") " +
                    "UNION " +
                    "SELECT s.*, cp.\"OID_MODULO\" AS \"OID_MODULO\" " +
                    "FROM " + sesion + " AS s " +
                    "INNER JOIN " + horario + " AS h ON (" + oid_plan + " = h.\"OID_PLAN\" AND " + oid_promocion + " = h.\"OID_PROMOCION\" AND s.\"" + oid_horario + "\" = h.\"OID\") " +
                    "INNER JOIN " + clasep + " AS cp ON (s.\"" + oid_clase_practica + "\" > 0 AND s.\"" + oid_clase_practica + "\" = cp.\"OID\") " +
                    "ORDER BY \"FECHA\", \"HORA\";";

            return query;
        }

        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public static string SELECT_SESIONES(long oid_plan, long oid_promocion)
        {
            string sesion = nHManager.Instance.GetSQLTable(typeof(SesionRecord));
            string horario = nHManager.Instance.GetSQLTable(typeof(HorarioRecord));
            string clase_teorica = nHManager.Instance.GetSQLTable(typeof(ClaseTeoricaRecord));
            string clase_practica = nHManager.Instance.GetSQLTable(typeof(ClasePracticaRecord));
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string sub_inst_pr = nHManager.Instance.GetSQLTable(typeof(Submodulo_Instructor_PromocionRecord));
            string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));

            string query;

            query = "SELECT s.\"OID_PROFESOR\" AS \"OID_INSTRUCTOR\", sub.\"OID\" AS \"OID_MODULO\", false AS \"PRACTICA\", s.\"OID_PROFESOR\" AS \"OID_AUTORIZADO\" " +
                    "FROM " + sesion + " AS s " +
                    "INNER JOIN " + horario + " AS h ON (" + oid_plan + " = h.\"OID_PLAN\" AND " + oid_promocion + " = h.\"OID_PROMOCION\" AND s.\"OID_HORARIO\" = h.\"OID\") " +
                    "INNER JOIN " + clase_teorica + " AS ct ON ( ct.\"OID\" = s.\"OID_CLASE_TEORICA\") " +                    
                    "INNER JOIN " + modulo + " AS m ON (ct.\"OID_MODULO\" = m.\"OID\") " +                    
                    "INNER JOIN " + sub_inst_pr + " AS sip ON (sip.\"OID_INSTRUCTOR\" = s.\"OID_PROFESOR\" AND sip.\"OID_PROMOCION\" = h.\"OID_PROMOCION\" AND sip.\"PRIORIDAD\" = 1) " +
                    "INNER JOIN " + submodulo + " AS sub ON (sub.\"OID\" = sip.\"OID_SUBMODULO\" AND sub.\"OID_MODULO\" = m.\"OID\" AND sub.\"OID\" = ct.\"OID_SUBMODULO\") " +
                    "UNION " +
                    "SELECT s.\"OID_PROFESOR\" AS \"OID_INSTRUCTOR\", sub.\"OID\" AS \"OID_MODULO\", true AS \"PRACTICA\", s.\"OID_PROFESOR\" AS \"OID_AUTORIZADO\" " +
                    "FROM " + sesion + " AS s " +
                    "INNER JOIN " + horario + " AS h ON (" + oid_plan + " = h.\"OID_PLAN\" AND " + oid_promocion + " = h.\"OID_PROMOCION\" AND s.\"OID_HORARIO\" = h.\"OID\") " +
                    "INNER JOIN " + clase_practica + " AS cp ON ( cp.\"OID\" = s.\"OID_CLASE_PRACTICA\") " +                    
                    "INNER JOIN " + modulo + " AS m ON (cp.\"OID_MODULO\" = m.\"OID\") " +                    
                    "INNER JOIN " + sub_inst_pr + " AS sip ON (sip.\"OID_INSTRUCTOR\" = s.\"OID_PROFESOR\" AND sip.\"OID_PROMOCION\" = h.\"OID_PROMOCION\" AND sip.\"PRIORIDAD\" = 1) " +
                    "INNER JOIN " + submodulo + " AS sub ON (sub.\"OID\" = sip.\"OID_SUBMODULO\" AND sub.\"OID_MODULO\" = m.\"OID\" AND sub.\"OID\" = cp.\"OID_SUBMODULO\");";

            return query;
        }

        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public static string SELECT_SESIONES_ORDENADAS()
        {
            string sesion = nHManager.Instance.GetSQLTable(typeof(SesionRecord));

            string query;

            query = "SELECT *, \"OID_PROFESOR\" AS \"OID_AUTORIZADO\" " +
                    "FROM " + sesion + " " +
                    "ORDER BY \"OID_HORARIO\", \"FECHA\", \"HORA\";";

            return query;
        }

        public static string SELECT_BY_CLASE_EXTRA(long oid_clase_extra)
        {
            QueryConditions conditions = new QueryConditions()
            {
                ClaseExtra = ClaseExtraInfo.New()
            };

            conditions.ClaseExtra.Oid = oid_clase_extra;

            return Sesion.SELECT(conditions, true);
        }

		#endregion

	}
}

