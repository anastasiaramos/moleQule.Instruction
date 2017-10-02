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
	public class Curso_Instructors : BusinessListBaseEx<Curso_Instructors, Curso_Instructor>
	{

		#region Business Methods


		public Curso_Instructor NewItem(Curso parent)
		{
			this.AddItem(Curso_Instructor.NewChild(parent));
			return this[Count - 1];
		}

		public Curso_Instructor NewItem(Instructor parent)
		{
			this.AddItem(Curso_Instructor.NewChild(parent));
			return this[Count - 1];
		}

		#endregion

		#region Factory Methods

		private Curso_Instructors()
		{
			MarkAsChild();
		}

		private Curso_Instructors(IList<Curso_Instructor> lista)
		{
			MarkAsChild();
			Fetch(lista);
		}

		private Curso_Instructors(IDataReader reader)
		{
			MarkAsChild();
			Fetch(reader);
		}

		public static Curso_Instructors NewChildList() { return new Curso_Instructors(); }

		public static Curso_Instructors GetChildList(IList<Curso_Instructor> lista) { return new Curso_Instructors(lista); }

		public static Curso_Instructors GetChildList(IDataReader reader) { return new Curso_Instructors(reader); }

		#endregion

		#region Child Data Access

		// called to copy objects data from list
		private void Fetch(IList<Curso_Instructor> lista)
		{
			this.RaiseListChangedEvents = false;

			foreach (Curso_Instructor item in lista)
				this.AddItem(Curso_Instructor.GetChild(item));

			this.RaiseListChangedEvents = true;
		}

		private void Fetch(IDataReader reader)
		{
			this.RaiseListChangedEvents = false;

			while (reader.Read())
				this.AddItem(Curso_Instructor.GetChild(reader));

			this.RaiseListChangedEvents = true;
		}


		internal void Update(Curso parent)
		{
			this.RaiseListChangedEvents = false;

			// update (thus deleting) any deleted child objects
			foreach (Curso_Instructor obj in DeletedList)
				obj.DeleteSelf(parent);

			// now that they are deleted, remove them from memory too
			DeletedList.Clear();

			// AddItem/update any current child objects
			foreach (Curso_Instructor obj in this)
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
			foreach (Curso_Instructor obj in DeletedList)
				obj.DeleteSelf(parent);

			// now that they are deleted, remove them from memory too
			DeletedList.Clear();

			// AddItem/update any current child objects
			foreach (Curso_Instructor obj in this)
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
			string tabla = "Curso_Instructor";
			string columna = "OID_PROFESOR";
			string query;

			schema = (schema == "COMMON") ? schema : Convert.ToInt32(schema).ToString("0000");

			query = "SELECT * " +
					"FROM \"" + schema + "\".\"" + tabla + "\" " +
					"WHERE \"" + columna + "\" = " + field_value.ToString() + ";";

			return query;
		}

        public static string SELECT_BY_CURSO(long oid_curso)
        {
            QueryConditions conditions = new QueryConditions()
            {
                Curso = CursoInfo.New()
            };

            conditions.Curso.Oid = oid_curso;

            return Curso_Instructor.SELECT(conditions, true);
        }

		#endregion
	}
}

