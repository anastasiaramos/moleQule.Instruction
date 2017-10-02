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
	public class AlumnoCursos : BusinessListBaseEx<AlumnoCursos, AlumnoCurso>
	{
	
	     #region Business Methods
		 
			public AlumnoCurso NewItem(Convocatoria_Curso parent)
			{
				this.AddItem(AlumnoCurso.NewChild(parent));
				return this[Count - 1];
			}
        
		 #endregion
		 
	     #region Factory Methods
		 
		 	private AlumnoCursos()
			{
				MarkAsChild();
			}
			
			private AlumnoCursos(IList<AlumnoCurso> lista)
			{
				MarkAsChild();
				Fetch(lista);
			}

			private AlumnoCursos(IDataReader reader)
			{
				MarkAsChild();
				Fetch(reader);
			}

			public static AlumnoCursos NewChildList() { return new AlumnoCursos(); }
			
			public static AlumnoCursos GetChildList(IList<AlumnoCurso> lista) { return new AlumnoCursos(lista); }

			public static AlumnoCursos GetChildList(IDataReader reader) { return new AlumnoCursos(reader); }
			
		 #endregion
		 
		 #region Child Data Access
		 
		 	// called to copy objects data from list
			private void Fetch(IList<AlumnoCurso> lista)
			{
				this.RaiseListChangedEvents = false;
				
				foreach (AlumnoCurso item in lista)
					this.AddItem(AlumnoCurso.GetChild(item));
				
				this.RaiseListChangedEvents = true;
			}

			private void Fetch(IDataReader reader)
			{
				this.RaiseListChangedEvents = false;

				while (reader.Read())
					this.AddItem(AlumnoCurso.GetChild(reader));

				this.RaiseListChangedEvents = true;
			}


			internal void Update(Convocatoria_Curso parent)
			{
				this.RaiseListChangedEvents = false;

				// update (thus deleting) any deleted child objects
				foreach (AlumnoCurso obj in DeletedList)
					obj.DeleteSelf(parent);

				// now that they are deleted, remove them from memory too
				DeletedList.Clear();

				// AddItem/update any current child objects
				foreach (AlumnoCurso obj in this)
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

            public static string SELECT_BY_CONVOCATORIA(long oid_convocatoria)
            {
                QueryConditions conditions = new QueryConditions()
                {
                    Convocatoria_Curso = Convocatoria_CursoInfo.New()
                };

                conditions.Convocatoria_Curso.Oid = oid_convocatoria;

                return AlumnoCurso.SELECT(conditions, true);
            }

            #endregion
	
	}
}

