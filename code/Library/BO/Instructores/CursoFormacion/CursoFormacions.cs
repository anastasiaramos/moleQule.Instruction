using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

namespace moleQule.Library.Instruction
{

	/// <summary>
	/// Editable Child Business Object
	/// </summary>
	[Serializable()]
	public class CursoFormacions : BusinessListBaseEx<CursoFormacions, CursoFormacion>
	{

		#region Business Methods
        
		public CursoFormacion NewItem(Instructor parent)
		{
			this.AddItem(CursoFormacion.NewChild(parent));
			return this[Count - 1];
		}

		#endregion

		#region Factory Methods

		private CursoFormacions()
		{
			MarkAsChild();
		}

		private CursoFormacions(IList<CursoFormacion> lista)
		{
			MarkAsChild();
			Fetch(lista);
		}

		private CursoFormacions(IDataReader reader)
		{
			MarkAsChild();
			Fetch(reader);
		}

		public static CursoFormacions NewChildList() { return new CursoFormacions(); }

		public static CursoFormacions GetChildList(IList<CursoFormacion> lista) { return new CursoFormacions(lista); }

		public static CursoFormacions GetChildList(IDataReader reader) { return new CursoFormacions(reader); }

		#endregion

		#region Child Data Access

		// called to copy objects data from list
		private void Fetch(IList<CursoFormacion> lista)
		{
			this.RaiseListChangedEvents = false;

			foreach (CursoFormacion item in lista)
				this.AddItem(CursoFormacion.GetChild(item));

			this.RaiseListChangedEvents = true;
		}

		private void Fetch(IDataReader reader)
		{
			this.RaiseListChangedEvents = false;

			while (reader.Read())
				this.AddItem(CursoFormacion.GetChild(reader));

			this.RaiseListChangedEvents = true;
		}


		internal void Update(Instructor parent)
		{
			this.RaiseListChangedEvents = false;

			// update (thus deleting) any deleted child objects
			foreach (CursoFormacion obj in DeletedList)
				obj.DeleteSelf(parent);

			// now that they are deleted, remove them from memory too
			DeletedList.Clear();

			// AddItem/update any current child objects
			foreach (CursoFormacion obj in this)
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

		public static string SELECT_BY_INSTRUCTOR(string schema, string parent_field, object field_value)
		{
			string tabla = "CursoFormacion";
			string columna = "OID_PROFESOR";
			string query;

			schema = (schema == "COMMON") ? schema : Convert.ToInt32(schema).ToString("0000");

			query = "SELECT * " +
					"FROM \"" + schema + "\".\"" + tabla + "\" " +
					"WHERE \"" + columna + "\" = " + field_value.ToString() + ";";

			return query;
		}

        public static string SELECT_BY_INSTRUCTOR(long oid_instructor)
        {
            QueryConditions conditions = new QueryConditions()
            {
                Instructor = InstructorInfo.New()
            };

            conditions.Instructor.Oid = oid_instructor;

            return CursoFormacion.SELECT(conditions, true);
        }

		#endregion

	}
}

