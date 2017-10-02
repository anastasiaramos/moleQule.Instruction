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
    public class Clase_ParteList : ReadOnlyListBaseEx<Clase_ParteList, Clase_ParteInfo>
	{
		 
		 
		#region Factory Methods

			private Clase_ParteList() { }

			private Clase_ParteList(IList<Clase_Parte> lista)
			{
				Fetch(lista);
			}

			private Clase_ParteList(IDataReader reader)
			{
				Fetch(reader);
			}

			/// <summary>
			/// Builds a Clase_ParteList from a IList<!--<Clase_ParteInfo>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>Clase_ParteList</returns>
			public static Clase_ParteList GetChildList(IList<Clase_ParteInfo> list)
			{
				Clase_ParteList flist = new Clase_ParteList();

				if (list.Count > 0)
				{
					flist.IsReadOnly = false;

					foreach (Clase_ParteInfo item in list)
						flist.AddItem(item);

					flist.IsReadOnly = true;
				}

				return flist;
			}

			/// <summary>
			/// Builds a Clase_ParteList from IList<!--<Clase_Parte>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>Clase_ParteList</returns>
			public static Clase_ParteList GetChildList(IList<Clase_Parte> list) { return new Clase_ParteList(list); }

			public static Clase_ParteList GetChildList(IDataReader reader) { return new Clase_ParteList(reader); }

			#endregion

		#region Data Access

			// called to copy objects data from list
			private void Fetch(IList<Clase_Parte> lista)
			{
				this.RaiseListChangedEvents = false;

				IsReadOnly = false;
				
				foreach (Clase_Parte item in lista)
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
					this.AddItem(Clase_Parte.GetChild(reader).GetInfo());

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
						IDataReader reader = Conceptos_Partes.DoNativeSELECT(AppContext.ActiveSchema.Code, Session());

						IsReadOnly = false;

						while (reader.Read())
						{
							this.AddItem(Clase_ParteInfo.Get(reader,Childs));
						}

						IsReadOnly = true;
					}
					else
					{
						IList<Clase_Parte> list = criteria.List<Clase_Parte>();

						if (list.Count > 0)
						{
							IsReadOnly = false;

							foreach (Clase_Parte item in list)
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

        #region SQL 

            public static string SELECT(ParteAsistenciaInfo item) { return Clase_Parte.SELECT(new QueryConditions() { ParteAsistencia = item }, false); }

        #endregion


    }
}

