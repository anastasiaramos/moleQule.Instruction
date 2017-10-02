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
	public class Promocions : BusinessListBaseEx<Promocions, Promocion>
	{
	
	     #region Business Methods
		 
		 
			public Promocion NewItem(PlanEstudios parent)
			{
				this.AddItem(Promocion.NewChild(parent));
				return this[Count - 1];
			}
			
		 #endregion
		 
	     #region Factory Methods
		 
		 	private Promocions()
			{
				MarkAsChild();
			}
			
			private Promocions(IList<Promocion> lista)
			{
				MarkAsChild();
				Fetch(lista);
			}

			private Promocions(IDataReader reader, bool childs)
			{
				Childs = childs;
				Fetch(reader);
			}


			public static Promocions NewChildList() { return new Promocions(); }
			
			public static Promocions GetChildList(IList<Promocion> lista) { return new Promocions(lista); }

			public static Promocions GetChildList(IDataReader reader, bool childs) { return new Promocions(reader, childs); }

			public static Promocions GetChildList(IDataReader reader) { return GetChildList(reader, true); }
			
		 #endregion
		 
		 #region Child Data Access
		 
		 	// called to copy objects data from list
			private void Fetch(IList<Promocion> lista)
			{
				this.RaiseListChangedEvents = false;
				
				foreach (Promocion item in lista)
					this.AddItem(Promocion.GetChild(item));
				
				this.RaiseListChangedEvents = true;
			}

			private void Fetch(IDataReader reader)
			{
				this.RaiseListChangedEvents = false;

				while (reader.Read())
					this.AddItem(Promocion.GetChild(reader));

				this.RaiseListChangedEvents = true;
			}

			internal void Update(PlanEstudios parent)
			{
				this.RaiseListChangedEvents = false;

				// update (thus deleting) any deleted child objects
				foreach (Promocion obj in DeletedList)
					obj.DeleteSelf(parent);

				// now that they are deleted, remove them from memory too
				DeletedList.Clear();

				// AddItem/update any current child objects
				foreach (Promocion obj in this)
				{
					if (obj.IsNew)
						obj.Insert(parent);
					else
						obj.Update(parent);
				}

				this.RaiseListChangedEvents = true;
			}
		 
		 #endregion
	
	}
}

