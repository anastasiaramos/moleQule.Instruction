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
	public class Alumno_PracticaList : ReadOnlyListBaseEx<Alumno_PracticaList, Alumno_PracticaInfo>
	{
		 
		 
		#region Factory Methods

			private Alumno_PracticaList() { }

			private Alumno_PracticaList(IList<Alumno_Practica> lista)
			{
				Fetch(lista);
			}

			private Alumno_PracticaList(IDataReader reader)
			{
				Fetch(reader);
			}

			/// <summary>
			/// Builds a Alumno_PracticaList from a IList<!--<Alumno_PracticaInfo>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>Alumno_PracticaList</returns>
			public static Alumno_PracticaList GetChildList(IList<Alumno_PracticaInfo> list)
			{
				Alumno_PracticaList flist = new Alumno_PracticaList();

				if (list.Count > 0)
				{
					flist.IsReadOnly = false;

					foreach (Alumno_PracticaInfo item in list)
						flist.AddItem(item);

					flist.IsReadOnly = true;
				}

				return flist;
			}

			/// <summary>
			/// Builds a Alumno_PracticaList from IList<!--<Alumno_Practica>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>Alumno_PracticaList</returns>
			public static Alumno_PracticaList GetChildList(IList<Alumno_Practica> list) { return new Alumno_PracticaList(list); }

			public static Alumno_PracticaList GetChildList(IDataReader reader) { return new Alumno_PracticaList(reader); }

		#endregion

		#region Data Access

			// called to copy objects data from list
			private void Fetch(IList<Alumno_Practica> lista)
			{
				this.RaiseListChangedEvents = false;

				IsReadOnly = false;
				
				foreach (Alumno_Practica item in lista)
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
					this.AddItem(Alumno_Practica.GetChild(reader).GetInfo());

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
						//Alumno_Practica.DoLOCK( Session());

						IDataReader reader = Alumnos_Practicas.DoNativeSELECT(AppContext.ActiveSchema.Code, Session());

						IsReadOnly = false;

						while (reader.Read())
						{
							this.AddItem(Alumno_PracticaInfo.Get(reader,Childs));
						}

						IsReadOnly = true;
					}
					else
					{
						IList<Alumno_Practica> list = criteria.List<Alumno_Practica>();

						if (list.Count > 0)
						{
							IsReadOnly = false;

							foreach (Alumno_Practica item in list)
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

            public static string SELECT(AlumnoInfo item) { return Alumno_Practica.SELECT(new QueryConditions() { Alumno = item }, false); }
            public static string SELECT(ParteAsistenciaInfo item) { return Alumno_Practica.SELECT(new QueryConditions() { ParteAsistencia = item }, false); }

        #endregion


    }
}

