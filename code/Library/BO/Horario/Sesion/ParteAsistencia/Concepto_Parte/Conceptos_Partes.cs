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
	public class Conceptos_Partes : BusinessListBaseEx<Conceptos_Partes, Concepto_Parte>
	{
	
	     #region Business Methods
		 
		 
			public Concepto_Parte NewItem(ParteAsistencia parent)
			{
				this.AddItem(Concepto_Parte.NewChild(parent));
				return this[Count - 1];
			}
        
		 #endregion
		 
	     #region Factory Methods
		 
		 	private Conceptos_Partes()
			{
				MarkAsChild();
			}
			
			private Conceptos_Partes(IList<Concepto_Parte> lista)
			{
				MarkAsChild();
				Fetch(lista);
			}

			private Conceptos_Partes(IDataReader reader)
			{
				MarkAsChild();
				Fetch(reader);
			}

			public static Conceptos_Partes NewChildList() { return new Conceptos_Partes(); }
			
			public static Conceptos_Partes GetChildList(IList<Concepto_Parte> lista) { return new Conceptos_Partes(lista); }

			public static Conceptos_Partes GetChildList(IDataReader reader) { return new Conceptos_Partes(reader); }

		 #endregion
		 
		 #region Child Data Access
		 
		 	// called to copy objects data from list
			private void Fetch(IList<Concepto_Parte> lista)
			{
				this.RaiseListChangedEvents = false;
				
				foreach (Concepto_Parte item in lista)
					this.AddItem(Concepto_Parte.GetChild(item));
				
				this.RaiseListChangedEvents = true;
			}

			private void Fetch(IDataReader reader)
			{
				this.RaiseListChangedEvents = false;

				while (reader.Read())
					this.AddItem(Concepto_Parte.GetChild(reader));

				this.RaiseListChangedEvents = true;
			}


			internal void Update(ParteAsistencia parent)
			{
				this.RaiseListChangedEvents = false;

				// update (thus deleting) any deleted child objects
				foreach (Concepto_Parte obj in DeletedList)
					obj.DeleteSelf(parent);

				// now that they are deleted, remove them from memory too
				DeletedList.Clear();

				// AddItem/update any current child objects
				foreach (Concepto_Parte obj in this)
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

                return Concepto_Parte.SELECT(conditions, true);
            }

            #endregion

        }
}

