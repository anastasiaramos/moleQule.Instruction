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
	public class Concepto_ParteList : ReadOnlyListBaseEx<Concepto_ParteList, Concepto_ParteInfo>
	{
		 
		 
		#region Factory Methods

			private Concepto_ParteList() { }

			private Concepto_ParteList(IList<Concepto_Parte> lista)
			{
				Fetch(lista);
			}

			private Concepto_ParteList(IDataReader reader)
			{
				Fetch(reader);
			}

			/// <summary>
			/// Builds a Concepto_ParteList from a IList<!--<Concepto_ParteInfo>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>Concepto_ParteList</returns>
			public static Concepto_ParteList GetChildList(IList<Concepto_ParteInfo> list)
			{
				Concepto_ParteList flist = new Concepto_ParteList();

				if (list.Count > 0)
				{
					flist.IsReadOnly = false;

					foreach (Concepto_ParteInfo item in list)
						flist.AddItem(item);

					flist.IsReadOnly = true;
				}

				return flist;
			}

			/// <summary>
			/// Builds a Concepto_ParteList from IList<!--<Concepto_Parte>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>Concepto_ParteList</returns>
			public static Concepto_ParteList GetChildList(IList<Concepto_Parte> list) { return new Concepto_ParteList(list); }

			public static Concepto_ParteList GetChildList(IDataReader reader) { return new Concepto_ParteList(reader); }

			#endregion

		#region Data Access

			// called to copy objects data from list
			private void Fetch(IList<Concepto_Parte> lista)
			{
				this.RaiseListChangedEvents = false;

				IsReadOnly = false;
				
				foreach (Concepto_Parte item in lista)
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
					this.AddItem(Concepto_Parte.GetChild(reader).GetInfo());

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
							this.AddItem(Concepto_ParteInfo.Get(reader,Childs));
						}

						IsReadOnly = true;
					}
					else
					{
						IList<Concepto_Parte> list = criteria.List<Concepto_Parte>();

						if (list.Count > 0)
						{
							IsReadOnly = false;

							foreach (Concepto_Parte item in list)
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

            public static string SELECT(ParteAsistenciaInfo item) { return Concepto_Parte.SELECT(new QueryConditions() { ParteAsistencia = item }, false); }

        #endregion


    }
}

