using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;

namespace moleQule.Library.Instruction
{
	/// <summary>
	/// Editable Child Business Object
	/// </summary>
	[Serializable()]
	public class Disponibilidades : BusinessListBaseEx<Disponibilidades, Disponibilidad>
	{

		#region Business Methods

		public Disponibilidad NewItem(Instructor parent)
		{
			this.AddItem(Disponibilidad.NewChild(parent));
			return this[Count - 1];
		}

		#endregion

		#region Factory Methods

		private Disponibilidades()
		{
			MarkAsChild();
		}

		private Disponibilidades(IList<Disponibilidad> lista)
		{
			MarkAsChild();
			Fetch(lista);
		}

		private Disponibilidades(IDataReader reader)
		{
			MarkAsChild();
			Fetch(reader);
		}

		public static Disponibilidades NewChildList() { return new Disponibilidades(); }

        public static Disponibilidades GetChildList(Instructor parent, bool childs, bool g_childs)
        {
            CriteriaEx criteria = Disponibilidad.GetCriteria(parent.SessionCode);

            criteria.Query = Disponibilidades.SELECT_BY_INSTRUCTOR(parent.Oid);
            criteria.Childs = childs;
            criteria.GChilds = g_childs;

            return DataPortal.Fetch<Disponibilidades>(criteria);
        }

		public static Disponibilidades GetChildList(IList<Disponibilidad> lista) { return new Disponibilidades(lista); }

		public static Disponibilidades GetChildList(IDataReader reader) { return new Disponibilidades(reader); }

		#endregion

		#region Child Data Access

		// called to copy objects data from list
		private void Fetch(IList<Disponibilidad> lista)
		{
			this.RaiseListChangedEvents = false;

			foreach (Disponibilidad item in lista)
				this.AddItem(Disponibilidad.GetChild(item));

			this.RaiseListChangedEvents = true;
		}

		private void Fetch(IDataReader reader)
		{
			this.RaiseListChangedEvents = false;

			while (reader.Read())
				this.AddItem(Disponibilidad.GetChild(reader));

			this.RaiseListChangedEvents = true;
		}


		internal void Update(Instructor parent)
		{
			this.RaiseListChangedEvents = false;

			// update (thus deleting) any deleted child objects
			foreach (Disponibilidad obj in DeletedList)
				obj.DeleteSelf(parent);

			// now that they are deleted, remove them from memory too
			DeletedList.Clear();

			// AddItem/update any current child objects
			foreach (Disponibilidad obj in this)
			{
				if (obj.IsNew)
					obj.Insert(parent);
				else
					obj.Update(parent);
			}

			this.RaiseListChangedEvents = true;
		}

		#endregion


        #region Root Data Access

        /// <summary>
        /// Construye el objeto y se encarga de obtener los
        /// hijos si los tiene y se solicitan
        /// </summary>
        /// <param name="criteria">Criterios de la consulta</param>
        /// <remarks>LA UTILIZA EL DATAPORTAL</remarks>
        private void DataPortal_Fetch(CriteriaEx criteria)
        {
            Fetch(criteria);
        }

        /// <summary>
        /// Construye el objeto y se encarga de obtener los
        /// hijos si los tiene y se solicitan
        /// </summary>
        /// <param name="criteria">Criterios de la consulta</param>
        private void Fetch(CriteriaEx criteria)
        {
            try
            {
                this.RaiseListChangedEvents = false;
                SessionCode = criteria.SessionCode;
                Childs = criteria.Childs;

                if (nHMng.UseDirectSQL)
                {
                    Disponibilidad.DoLOCK(Session());
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                    while (reader.Read())
                        this.AddItem(Disponibilidad.GetChild(reader));
                }
            }
            catch (Exception ex)
            {
                if (Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                this.RaiseListChangedEvents = true;
            }
        }

        #endregion

		#region SQL

		public static string SELECT_BY_INSTRUCTOR(long oid_instructor)
		{
            string tabla = nHManager.Instance.GetSQLTable(typeof(DisponibilidadRecord));
			string query;

			query = "SELECT *" +
					" FROM " + tabla + " AS DP" +
                    " WHERE DP.\"OID_INSTRUCTOR\" = " + oid_instructor.ToString();

			return query;
		}

        public static string SELECT_BY_LIST(string lista_instructores, DateTime fecha_inicio)
        {
            string tabla = nHManager.Instance.GetSQLTable(typeof(DisponibilidadRecord));
            string fecha = "'" + fecha_inicio.Year.ToString() + "-" +
                                fecha_inicio.Month.ToString() + "-" + 
                                fecha_inicio.Day.ToString() + "'";
            string query;

            query = "SELECT *" +
                    " FROM " + tabla + " AS DP" +
                    " WHERE DP.\"OID_INSTRUCTOR\" IN (" + lista_instructores + ")" +
                    " AND DP.\"FECHA_INICIO\" = " + fecha ;

            return query;
        }

		#endregion
	}
}

