using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx; 

namespace moleQule.Library.Instruction
{

	/// <summary>
	/// Editable Child Collection
	/// </summary>
    [Serializable()]
	public class MaterialDocentes : BusinessListBaseEx<MaterialDocentes, MaterialDocente>
	{
	
	     #region Business Methods

            public MaterialDocente NewItem(PlanEstudios parent)
			{
				this.AddItem(MaterialDocente.NewChild(parent));
				return this[Count - 1];
			}
             
            public MaterialDocente NewItem(Curso parent)
			{
				this.AddItem(MaterialDocente.NewChild(parent));
				return this[Count - 1];
			}
			
		 #endregion
		 
	     #region Factory Methods
		 
		 	private MaterialDocentes()
			{
				MarkAsChild();
			}
			
			private MaterialDocentes(IList<MaterialDocente> lista)
			{
				MarkAsChild();
				Fetch(lista);
			}

			private MaterialDocentes(int session_code, IDataReader reader, bool childs)
			{
				Childs = childs;
				Fetch(session_code, reader);
			}


			public static MaterialDocentes NewChildList() { return new MaterialDocentes(); }
			
			public static MaterialDocentes GetChildList(IList<MaterialDocente> lista) { return new MaterialDocentes(lista); }

			public static MaterialDocentes GetChildList(int session_code, IDataReader reader, bool childs) { return new MaterialDocentes(session_code, reader, childs); }

			public static MaterialDocentes GetChildList(int session_code, IDataReader reader) { return GetChildList(session_code, reader, true); }
			
		 #endregion
		 
		 #region Child Data Access
		 
		 	// called to copy objects data from list
			private void Fetch(IList<MaterialDocente> lista)
			{
				this.RaiseListChangedEvents = false;
				
				foreach (MaterialDocente item in lista)
					this.AddItem(MaterialDocente.GetChild(item));
				
				this.RaiseListChangedEvents = true;
			}

			private void Fetch(int session_code, IDataReader reader)
			{
				this.RaiseListChangedEvents = false;

				while (reader.Read())
					this.AddItem(MaterialDocente.GetChild(session_code, reader));

				this.RaiseListChangedEvents = true;
			}


            internal void Update(PlanEstudios parent)
            {
                this.RaiseListChangedEvents = false;

                // update (thus deleting) any deleted child objects
                foreach (MaterialDocente obj in DeletedList)
                    obj.DeleteSelf(parent);

                // now that they are deleted, remove them from memory too
                DeletedList.Clear();

                // AddItem/update any current child objects
                foreach (MaterialDocente obj in this)
                {
                    if (obj.IsNew)
                        obj.Insert(parent);
                    else
                        obj.Update(parent);
                }

                this.RaiseListChangedEvents = true;
            }
             
            internal void Update(Curso parent)
            {
                this.RaiseListChangedEvents = false;

                // update (thus deleting) any deleted child objects
                foreach (MaterialDocente obj in DeletedList)
                    obj.DeleteSelf(parent);

                // now that they are deleted, remove them from memory too
                DeletedList.Clear();

                // AddItem/update any current child objects
                foreach (MaterialDocente obj in this)
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

            public static string SELECT_BY_CURSO(long oid_curso)
            {
                QueryConditions conditions = new QueryConditions()
                {
                    Curso = CursoInfo.New()
                };

                conditions.Curso.Oid = oid_curso;

                return MaterialDocente.SELECT(conditions, true);
            }

            #endregion

        }
}

