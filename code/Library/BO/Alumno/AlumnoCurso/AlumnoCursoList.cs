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
	public class AlumnoCursoList : ReadOnlyListBaseEx<AlumnoCursoList, AlumnoCursoInfo>
	{
		 
		 
		#region Factory Methods

			private AlumnoCursoList() { }

			private AlumnoCursoList(IList<AlumnoCurso> lista)
			{
				Fetch(lista);
			}

			private AlumnoCursoList(IDataReader reader)
			{
				Fetch(reader);
			}

			/// <summary>
			/// Builds a Alumno_CursoList from a IList<!--<Alumno_CursoInfo>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>Alumno_CursoList</returns>
			public static AlumnoCursoList GetChildList(IList<AlumnoCursoInfo> list)
			{
				AlumnoCursoList flist = new AlumnoCursoList();

				if (list.Count > 0)
				{
					flist.IsReadOnly = false;

					foreach (AlumnoCursoInfo item in list)
						flist.AddItem(item);

					flist.IsReadOnly = true;
				}

				return flist;
			}

			/// <summary>
			/// Builds a Alumno_CursoList from IList<!--<Alumno_Curso>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>Alumno_CursoList</returns>
			public static AlumnoCursoList GetChildList(IList<AlumnoCurso> list) { return new AlumnoCursoList(list); }

			public static AlumnoCursoList GetChildList(IDataReader reader) { return new AlumnoCursoList(reader); }

            /// <summary>
            /// Devuelve una lista de todos los alumno_cursos asociados a un curso
            /// </summary>
            /// <returns>Lista de elementos</returns>
            public static AlumnoCursoList GetAlumnosList(long oid_curso)
            {
                CriteriaEx criteria = AlumnoCurso.GetCriteria(AlumnoCurso.OpenSession());
                criteria.AddEq("OidCurso", oid_curso);
                AlumnoCursoList list = AlumnoCursoList.RetrieveList(typeof(AlumnoCurso), AppContext.ActiveSchema.Code, criteria);

                CloseSession(criteria.SessionCode);
                return list;
            }

			#endregion

		#region Data Access

			// called to copy objects data from list
			private void Fetch(IList<AlumnoCurso> lista)
			{
				this.RaiseListChangedEvents = false;

				IsReadOnly = false;
				
				foreach (AlumnoCurso item in lista)
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
					this.AddItem(AlumnoCurso.GetChild(reader).GetInfo());

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
                        IDataReader reader = nHManager.Instance.SQLNativeSelect(criteria.Query, Session()); 

						IsReadOnly = false;

						while (reader.Read())
						{
							this.AddItem(AlumnoCursoInfo.Get(reader,Childs));
						}

						IsReadOnly = true;
					}
					else
					{
						IList<AlumnoCurso> list = criteria.List<AlumnoCurso>();

						if (list.Count > 0)
						{
							IsReadOnly = false;

							foreach (AlumnoCurso item in list)
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

