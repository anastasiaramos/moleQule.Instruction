using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;

namespace moleQule.Library.Instruction
{

	/// <summary>
	/// ReadOnly Root Collection of Business Objects With Child Collection
	/// </summary>
    [Serializable()]
	public class DisponibilidadList : ReadOnlyListBaseEx<DisponibilidadList, DisponibilidadInfo>
	{
		 
		  #region Factory Methods

			private DisponibilidadList() { }

			private DisponibilidadList(IList<Disponibilidad> lista)
			{
				Fetch(lista);
			}

			private DisponibilidadList(IDataReader reader)
			{
				Fetch(reader);
			}

			/// <summary>
			/// Builds a DisponibilidadList from a IList<!--<DisponibilidadInfo>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>DisponibilidadList</returns>
			public static DisponibilidadList GetChildList(IList<DisponibilidadInfo> list)
			{
				DisponibilidadList flist = new DisponibilidadList();

				if (list.Count > 0)
				{
					flist.IsReadOnly = false;

					foreach (DisponibilidadInfo item in list)
						flist.AddItem(item);

					flist.IsReadOnly = true;
				}

				return flist;
			}

			/// <summary>
			/// Builds a DisponibilidadList from IList<!--<Disponibilidad>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>DisponibilidadList</returns>
			public static DisponibilidadList GetChildList(IList<Disponibilidad> list) { return new DisponibilidadList(list); }

			public static DisponibilidadList GetChildList(IDataReader reader) { return new DisponibilidadList(reader); }

			#endregion

		  #region Data Access

			// called to copy objects data from list
			private void Fetch(IList<Disponibilidad> lista)
			{
				this.RaiseListChangedEvents = false;

				IsReadOnly = false;
				
				foreach (Disponibilidad item in lista)
					this.AddItem(item.GetInfo());

				IsReadOnly = true;

				this.RaiseListChangedEvents = true;
			}


			// called to copy objects data from list
			private void Fetch(IDataReader reader)
			{
				this.RaiseListChangedEvents = false;

				IsReadOnly = false;

				while (reader.Read())
					this.AddItem(DisponibilidadInfo.Get(reader,false));

				IsReadOnly = true;

				this.RaiseListChangedEvents = true;
			}

			// called to retrieve data from db
			protected override void Fetch(CriteriaEx criteria)
			{
				this.RaiseListChangedEvents = false;

				SessionCode = criteria.SessionCode;
				Childs = criteria.Childs;

				try
				{
					if (nHMng.UseDirectSQL)
					{
						IDataReader reader = Disponibilidades.DoNativeSELECT(AppContext.ActiveSchema.Code, Session());

						IsReadOnly = false;

						while (reader.Read())
						{
							this.AddItem(DisponibilidadInfo.Get(reader,Childs));
						}

						IsReadOnly = true;
					}
					else
					{
						IList<Disponibilidad> list = criteria.List<Disponibilidad>();

						if (list.Count > 0)
						{
							IsReadOnly = false;

							foreach (Disponibilidad item in list)
								this.AddItem(item.GetInfo());

							IsReadOnly = true;
						}
					}
				}
				catch (Exception ex)
				{
                    iQExceptionHandler.TreatException(ex);
				}

				this.RaiseListChangedEvents = true;
			}

			#endregion

	
	}
}

