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
	public class CursoFormacionList : ReadOnlyListBaseEx<CursoFormacionList, CursoFormacionInfo>
	{
		 
		 
		#region Factory Methods

			private CursoFormacionList() { }

			private CursoFormacionList(IList<CursoFormacion> lista)
			{
				Fetch(lista);
			}

			private CursoFormacionList(IDataReader reader)
			{
				Fetch(reader);
			}

			/// <summary>
			/// Builds a CursoFormacionList from a IList<!--<CursoFormacionInfo>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>CursoFormacionList</returns>
			public static CursoFormacionList GetChildList(IList<CursoFormacionInfo> list)
			{
				CursoFormacionList flist = new CursoFormacionList();

				if (list.Count > 0)
				{
					flist.IsReadOnly = false;

					foreach (CursoFormacionInfo item in list)
						flist.AddItem(item);

					flist.IsReadOnly = true;
				}

				return flist;
			}

			/// <summary>
			/// Builds a CursoFormacionList from IList<!--<CursoFormacion>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>CursoFormacionList</returns>
			public static CursoFormacionList GetChildList(IList<CursoFormacion> list) { return new CursoFormacionList(list); }

			public static CursoFormacionList GetChildList(IDataReader reader) { return new CursoFormacionList(reader); }

			#endregion

		#region Data Access

			// called to copy objects data from list
			private void Fetch(IList<CursoFormacion> lista)
			{
				this.RaiseListChangedEvents = false;

				IsReadOnly = false;
				
				foreach (CursoFormacion item in lista)
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
					this.AddItem(CursoFormacion.GetChild(reader).GetInfo());

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
						IDataReader reader = CursoFormacions.DoNativeSELECT(AppContext.ActiveSchema.Code, Session());

						IsReadOnly = false;

						while (reader.Read())
						{
							this.AddItem(CursoFormacionInfo.Get(reader,Childs));
						}

						IsReadOnly = true;
					}
					else
					{
						IList<CursoFormacion> list = criteria.List<CursoFormacion>();

						if (list.Count > 0)
						{
							IsReadOnly = false;

							foreach (CursoFormacion item in list)
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

