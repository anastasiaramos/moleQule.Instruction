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
	public class Horarios : BusinessListBaseEx<Horarios, Horario>
	{

		#region Business Methods

		public Horario NewItem(PlanEstudios parent)
		{
			this.AddItem(Horario.NewChild(parent));
			return this[Count - 1];
		}

        //public Horario NewItem(Promocion parent)
        //{
        //    this.AddItem(Horario.NewChild(parent));
        //    return this[Count - 1];
        //}

		#endregion

		#region Factory Methods

		private Horarios()
		{
			MarkAsChild();
		}

		private Horarios(IList<Horario> lista)
		{
			MarkAsChild();
			Fetch(lista);
		}

		private Horarios(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}

		public static Horarios NewChildList() { return new Horarios(); }

		public static Horarios GetChildList(IList<Horario> lista) { return new Horarios(lista); }

		public static Horarios GetChildList(IDataReader reader, bool childs) { return new Horarios(reader, childs); }

		public static Horarios GetChildList(IDataReader reader) { return GetChildList(reader, true); }

		#endregion

		#region Child Data Access

		// called to copy objects data from list
		private void Fetch(IList<Horario> lista)
		{
			this.RaiseListChangedEvents = false;

			foreach (Horario item in lista)
				this.AddItem(Horario.GetChild(item));

			this.RaiseListChangedEvents = true;
		}

		private void Fetch(IDataReader reader)
		{
			this.RaiseListChangedEvents = false;

			while (reader.Read())
				this.AddItem(Horario.GetChild(reader));

			this.RaiseListChangedEvents = true;
		}

		internal void Update(PlanEstudios parent)
		{
			this.RaiseListChangedEvents = false;

			// update (thus deleting) any deleted child objects
			foreach (Horario obj in DeletedList)
				obj.DeleteSelf(parent);

			// now that they are deleted, remove them from memory too
			DeletedList.Clear();

			// AddItem/update any current child objects
			foreach (Horario obj in this)
			{
				if (obj.IsNew)
					obj.Insert(parent);
				else
					obj.Update(parent);
			}

			this.RaiseListChangedEvents = true;
		}

        //internal void Update(Promocion parent)
        //{
        //    this.RaiseListChangedEvents = false;

        //    // update (thus deleting) any deleted child objects
        //    foreach (Horario obj in DeletedList)
        //        obj.DeleteSelf(parent);

        //    // now that they are deleted, remove them from memory too
        //    DeletedList.Clear();

        //    // AddItem/update any current child objects
        //    foreach (Horario obj in this)
        //    {
        //        if (obj.IsNew)
        //            obj.Insert(parent);
        //        else
        //            obj.Update(parent);
        //    }

        //    this.RaiseListChangedEvents = true;
        //}

		#endregion

		#region SQL

		public new static string SELECT()
		{
            string query;
            query = Horario.SELECT(0, false);
			return query;
		}

        public new static string SELECT_BY_FIELD(string property, object value)
        {
            string h = nHManager.Instance.GetSQLTable(typeof(HorarioRecord));
            string pl = nHManager.Instance.GetSQLTable(typeof(PlanEstudiosRecord));
            string pr = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));
            string label = nHManager.Instance.GetTableField(typeof(HorarioRecord), property);

            string query;

            query = Horario.SELECT_FIELDS() +
                    " FROM " + h + " AS H" +
                    " INNER JOIN " + pl + " AS PL ON (PL.\"OID\" = H.\"OID_PLAN\") " +
                    " INNER JOIN " + pr + " AS PR ON (PR.\"OID\" = H.\"OID_PROMOCION\")";

            query += " WHERE H.\"" + label + "\" = " + value.ToString();

            return query;
        }
		
		#endregion

	}
}

