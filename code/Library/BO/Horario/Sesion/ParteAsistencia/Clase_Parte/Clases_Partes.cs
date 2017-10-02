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
	/// Editable Child Business Object
	/// </summary>
    [Serializable()]
    public class Clases_Partes : BusinessListBaseEx<Clases_Partes, Clase_Parte>
	{
	
	     #region Business Methods
		 
		 
			public Clase_Parte NewItem(ParteAsistencia parent)
			{
				this.AddItem(Clase_Parte.NewChild(parent));
				return this[Count - 1];
			}

            public bool Contiene(Clase_Parte obj)
            {
                foreach (Clase_Parte item in this)
                {
                    if (item.Tipo == obj.Tipo
                        && item.OidClase == obj.OidClase
                        && item.Grupo == obj.Grupo)
                        return true;
                }
                return false;
            }
        
		 #endregion
		 
	     #region Factory Methods
		 
		 	private Clases_Partes()
			{
				MarkAsChild();
			}
			
			private Clases_Partes(IList<Clase_Parte> lista)
			{
				MarkAsChild();
				Fetch(lista);
			}

			private Clases_Partes(IDataReader reader)
			{
				MarkAsChild();
				Fetch(reader);
			}

			public static Clases_Partes NewChildList() { return new Clases_Partes(); }
			
			public static Clases_Partes GetChildList(IList<Clase_Parte> lista) { return new Clases_Partes(lista); }

			public static Clases_Partes GetChildList(IDataReader reader) { return new Clases_Partes(reader); }

		 #endregion
		 
		 #region Child Data Access
		 
		 	// called to copy objects data from list
			private void Fetch(IList<Clase_Parte> lista)
			{
				this.RaiseListChangedEvents = false;
				
				foreach (Clase_Parte item in lista)
					this.AddItem(Clase_Parte.GetChild(item));
				
				this.RaiseListChangedEvents = true;
			}

			private void Fetch(IDataReader reader)
			{
				this.RaiseListChangedEvents = false;

				while (reader.Read())
					this.AddItem(Clase_Parte.GetChild(reader));

				this.RaiseListChangedEvents = true;
			}


			internal void Update(ParteAsistencia parent)
			{
				this.RaiseListChangedEvents = false;

				// update (thus deleting) any deleted child objects
				foreach (Clase_Parte obj in DeletedList)
					obj.DeleteSelf(parent);

				// now that they are deleted, remove them from memory too
				DeletedList.Clear();

				// AddItem/update any current child objects
				foreach (Clase_Parte obj in this)
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

            public static string SELECT_BY_PARTE(long oid_parte)
            {
                QueryConditions conditions = new QueryConditions()
                {
                    ParteAsistencia = ParteAsistenciaInfo.New()
                };

                conditions.ParteAsistencia.Oid = oid_parte;

                return Clase_Parte.SELECT(conditions, true);
            }

            #endregion

        }
}

