using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using NHibernate;

namespace moleQule.Library.Instruction
{

	/// <summary>
	/// Editable Child Collection
	/// </summary>
	[Serializable()]
	public class Temas : BusinessListBaseEx<Temas, Tema>
	{

		#region Business Methods


		public Tema NewItem(Submodulo parent)
		{
			this.AddItem(Tema.NewChild(parent));
			return this[Count - 1];
		}

		#endregion

		#region Factory Methods

		private Temas()
		{
			MarkAsChild();
		}

		private Temas(IList<Tema> lista)
		{
			MarkAsChild();
			Fetch(lista);
		}

		private Temas(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}

		public static Temas NewChildList() { return new Temas(); }

		public static Temas GetChildList(IList<Tema> lista) { return new Temas(lista); }

		public static Temas GetChildList(IDataReader reader, bool childs) { return new Temas(reader, childs); }

		public static Temas GetChildList(IDataReader reader) { return GetChildList(reader, true); }

		/// <summary>
		/// Retrieve the complete list from db
		/// </summary>
		/// <param name="get_childs">retrieving the childs</param>
		/// <returns></returns>
		public static Temas GetList()
		{
			Temas lista = Temas.NewChildList();

			TemaList submodulos = TemaList.GetList(false);

			foreach (TemaInfo info in submodulos)
			{
				Tema item = Tema.Get(info.Oid);
				item.MarkItemChild();
				lista.AddItem(item);
			}

			return lista;
		}


		#endregion

		#region Child Data Access

		// called to copy objects data from list
		private void Fetch(IList<Tema> lista)
		{
			this.RaiseListChangedEvents = false;

			foreach (Tema item in lista)
				this.AddItem(Tema.GetChild(item));

			this.RaiseListChangedEvents = true;
		}

		private void Fetch(IDataReader reader)
		{
			this.RaiseListChangedEvents = false;

			while (reader.Read())
				this.AddItem(Tema.GetChild(reader, Childs));

			this.RaiseListChangedEvents = true;
		}

		internal void Update(Submodulo parent)
		{
			this.RaiseListChangedEvents = false;

			// update (thus deleting) any deleted child objects
			foreach (Tema obj in DeletedList)
				obj.DeleteSelf(parent);

			// now that they are deleted, remove them from memory too
			DeletedList.Clear();

			// AddItem/update any current child objects
			foreach (Tema obj in this)
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

        public static string SELECT_BY_SUBMODULO(long oid_submodulo) { return SELECT_BY_SUBMODULO(oid_submodulo, true); }
        public static string SELECT_BY_SUBMODULO(long oid_submodulo, bool lockTable)
        {
            QueryConditions conditions = new QueryConditions()
            {
                Submodulo = SubmoduloInfo.New()
            };

            conditions.Submodulo.Oid = oid_submodulo;

            return Tema.SELECT(conditions, lockTable);
        }

        public static string SELECT_BY_MODULO(long oid_modulo) { return SELECT_BY_MODULO(oid_modulo, true); }
        public static string SELECT_BY_MODULO(long oid_modulo, bool lockTable)
        {
            QueryConditions conditions = new QueryConditions()
            {
                Modulo = ModuloInfo.New()
            };

            conditions.Modulo.Oid = oid_modulo;

            return Tema.SELECT(conditions, lockTable);
        }

		public static string SELECT_BY_OID(long oid)
		{
            string t = nHManager.Instance.GetSQLTable(typeof(TemaRecord));
			string query = "SELECT * " +
							" FROM \"" +  t + "\"" +
							" WHERE \"OID\" = " + oid.ToString() + ";";

			return query;
		}

		#endregion

	}
}

