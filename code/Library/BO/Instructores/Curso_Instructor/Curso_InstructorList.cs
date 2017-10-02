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
	public class Curso_InstructorList : ReadOnlyListBaseEx<Curso_InstructorList, Curso_InstructorInfo>
	{
		 
		 
		#region Factory Methods

			private Curso_InstructorList() { }

			private Curso_InstructorList(IList<Curso_Instructor> lista)
			{
				Fetch(lista);
			}

			private Curso_InstructorList(IDataReader reader)
			{
				Fetch(reader);
			}

			/// <summary>
			/// Builds a Curso_InstructorList from a IList<!--<Curso_InstructorInfo>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>Curso_InstructorList</returns>
			public static Curso_InstructorList GetChildList(IList<Curso_InstructorInfo> list)
			{
				Curso_InstructorList flist = new Curso_InstructorList();

				if (list.Count > 0)
				{
					flist.IsReadOnly = false;

					foreach (Curso_InstructorInfo item in list)
						flist.AddItem(item);

					flist.IsReadOnly = true;
				}

				return flist;
			}

			/// <summary>
			/// Builds a Curso_InstructorList from IList<!--<Curso_Instructor>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>Curso_InstructorList</returns>
			public static Curso_InstructorList GetChildList(IList<Curso_Instructor> list) { return new Curso_InstructorList(list); }

			public static Curso_InstructorList GetChildList(IDataReader reader) { return new Curso_InstructorList(reader); }

			#endregion

		#region Data Access

			// called to copy objects data from list
			private void Fetch(IList<Curso_Instructor> lista)
			{
				this.RaiseListChangedEvents = false;

				IsReadOnly = false;
				
				foreach (Curso_Instructor item in lista)
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
					this.AddItem(Curso_Instructor.GetChild(reader).GetInfo());

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
						IDataReader reader = Curso_Instructors.DoNativeSELECT(AppContext.ActiveSchema.Code, Session());

						IsReadOnly = false;

						while (reader.Read())
						{
							this.AddItem(Curso_InstructorInfo.Get(reader,Childs));
						}

						IsReadOnly = true;
					}
					else
					{
						IList<Curso_Instructor> list = criteria.List<Curso_Instructor>();

						if (list.Count > 0)
						{
							IsReadOnly = false;

							foreach (Curso_Instructor item in list)
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

