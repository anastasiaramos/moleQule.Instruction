using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using NHibernate;
using moleQule.Library;

namespace moleQule.Library.Instruction
{

	/// <summary>
	/// Editable Child Collection
	/// </summary>
	[Serializable()]
	public class Submodulos : BusinessListBaseEx<Submodulos, Submodulo>
	{

		#region Business Methods


		public Submodulo NewItem(Modulo parent)
		{
			this.AddItem(Submodulo.NewChild(parent));
			return this[Count - 1];
		}

		#endregion

		#region Factory Methods

		private Submodulos()
		{
			MarkAsChild();
		}

		private Submodulos(IList<Submodulo> lista)
		{
			MarkAsChild();
			Fetch(lista);
		}

		private Submodulos(int session_code, IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(session_code, reader);
		}

		public static Submodulos NewChildList() { return new Submodulos(); }

		public static Submodulos GetChildList(IList<Submodulo> lista) { return new Submodulos(lista); }

		public static Submodulos GetChildList(int session_code, IDataReader reader, bool childs) { return new Submodulos(session_code, reader, childs); }

		public static Submodulos GetChildList(int session_code, IDataReader reader) { return GetChildList(session_code, reader, true); }

        public static Submodulos GetChildList(Modulo parent, bool childs, bool g_childs)
        {
            CriteriaEx criteria = Submodulo.GetCriteria(parent.SessionCode);

            criteria.Query = Submodulos.SELECT_BY_MODULO(parent.Oid);
            criteria.Childs = childs;
            criteria.GChilds = g_childs;

            return DataPortal.Fetch<Submodulos>(criteria);
        }

        /// <summary>
		/// Retrieve the complete list from db
		/// </summary>
		public static Submodulos GetList()
		{
			Submodulos lista = Submodulos.NewChildList();

			SubmoduloList submodulos = SubmoduloList.GetList(false);

			foreach (SubmoduloInfo info in submodulos)
			{
				Submodulo item = Submodulo.Get(info.Oid);
				item.MarkItemChild();
				lista.AddItem(item);
			}

			return lista;
		}
        
        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        public static Submodulos GetListByModulo(long oid_modulo)
        {
            Submodulos lista = Submodulos.NewChildList();

            string query = Submodulos.SELECT_BY_MODULO(oid_modulo);
            IDataReader reader = nHManager.Instance.SQLNativeSelect(query);
            int session_code = Submodulo.OpenSession();

            while (reader.Read())
                lista.AddItem(Submodulo.GetChild(session_code, reader, true, true));

            CloseSession(session_code);

            return lista;
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
                    Submodulo.DoLOCK(Session());
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                    while (reader.Read())
                        this.AddItem(Submodulo.GetChild(criteria.SessionCode, reader, Childs, criteria.GChilds));
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

		#region Child Data Access

		// called to copy objects data from list
		private void Fetch(IList<Submodulo> lista)
		{
			this.RaiseListChangedEvents = false;

			foreach (Submodulo item in lista)
				this.AddItem(Submodulo.GetChild(item));

			this.RaiseListChangedEvents = true;
		}

		private void Fetch(int session_code, IDataReader reader)
		{
			this.RaiseListChangedEvents = false;

			while (reader.Read())
				this.AddItem(Submodulo.GetChild(session_code, reader));

			this.RaiseListChangedEvents = true;
		}

		internal void Update(Modulo parent)
		{
			this.RaiseListChangedEvents = false;

			// update (thus deleting) any deleted child objects
			foreach (Submodulo obj in DeletedList)
				obj.DeleteSelf(parent);

			// now that they are deleted, remove them from memory too
			DeletedList.Clear();

			// AddItem/update any current child objects
			foreach (Submodulo obj in this)
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

        public static string SELECT_BY_MODULO(long oid_modulo) { return SELECT_BY_MODULO(oid_modulo, true); }
        public static string SELECT_BY_MODULO(long oid_modulo, bool lockTable)
        {
            QueryConditions conditions = new QueryConditions()
            {
                Modulo = ModuloInfo.New()
            };

            conditions.Modulo.Oid = oid_modulo;

            return Submodulo.SELECT(conditions, lockTable);
        }

		public static string SELECT_BY_OID(string schema, ISession sesion, object field_value)
		{
			int esquema = Convert.ToInt32(schema);
			string query = "SELECT * " +
							"FROM \"" + esquema.ToString("0000") + "\".\"Submodulo\" " +
							"WHERE \"OID\" = " + field_value.ToString() + "";

			return query;
		}

		#endregion

	}
}

