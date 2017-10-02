using System;
using System.Collections.Generic;
using System.Data;

using Csla;

using moleQule.Library;
using moleQule.Library.CslaEx;

namespace moleQule.Library.Instruction
{
	/// <summary>
	/// ReadOnly Root Collection of Business Objects With Child Collection
	/// </summary>
    [Serializable()]
	public class Alumno_ExamenList : ReadOnlyListBaseEx<Alumno_ExamenList, Alumno_ExamenInfo>
	{
		 
		 
		#region Factory Methods

			private Alumno_ExamenList() { }

            public static Alumno_ExamenList NewList() { return new Alumno_ExamenList(); }

			private Alumno_ExamenList(IList<Alumno_Examen> lista)
			{
				Fetch(lista);
            }

			private Alumno_ExamenList(IDataReader reader)
			{
				Fetch(reader);
			}

			/// <summary>
			/// Builds a Alumno_ExamenList from a IList<!--<Alumno_ExamenInfo>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>Alumno_ExamenList</returns>
			public static Alumno_ExamenList GetChildList(IList<Alumno_ExamenInfo> list)
			{
				Alumno_ExamenList flist = new Alumno_ExamenList();

				if (list.Count > 0)
				{
					flist.IsReadOnly = false;

					foreach (Alumno_ExamenInfo item in list)
						flist.AddItem(item);

					flist.IsReadOnly = true;
				}

				return flist;
			}

            /// <summary>
            /// Retrieve the complete list from db
            /// </summary>
            /// <returns>AlumnoList</returns>
            public static Alumno_ExamenList GetExamenList(long oid_examen)
            {
                CriteriaEx criteria = Alumno_Examen.GetCriteria(Alumno_Examen.OpenSession());
                criteria.Childs = false;

                QueryConditions conditions = new QueryConditions(){Examen = Examen.New().GetInfo(false)};
                conditions.Examen.Oid = oid_examen;
                criteria.Query = Alumno_Examen.SELECT(conditions, false);
                //No criteria. Retrieve all de List
                Alumno_ExamenList list = DataPortal.Fetch<Alumno_ExamenList>(criteria);

                CloseSession(criteria.SessionCode);

                return list;
            }

			/// <summary>
			/// Builds a Alumno_ExamenList from IList<!--<Alumno_Examen>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>Alumno_ExamenList</returns>
            public static Alumno_ExamenList GetChildList(IList<Alumno_Examen> list) { return new Alumno_ExamenList(list); }

			public static Alumno_ExamenList GetChildList(IDataReader reader) { return new Alumno_ExamenList(reader); }



            /// <summary>
            /// Builds a RegistroFaltasList from a IList<!--<RegistroFaltasInfo>-->.
            /// Doesnt retrieve child data from DB.
            /// </summary>
            /// <param name="list"></param>
            /// <returns></returns>
            public static Alumno_ExamenList GetList(IList<Alumno_ExamenInfo> list)
            {
                Alumno_ExamenList flist = new Alumno_ExamenList();

                if (list.Count > 0)
                {
                    flist.IsReadOnly = false;

                    foreach (Alumno_ExamenInfo item in list)
                        flist.AddItem(item);

                    flist.IsReadOnly = true;
                }

                return flist;
            }

            public static Alumno_ExamenList GetChildList(AlumnoInfo parent, bool childs)
            {
                CriteriaEx criteria = Alumno_Examen.GetCriteria(Alumno_Examen.OpenSession());
                criteria.Query = Alumno_ExamenList.SELECT(parent);
                criteria.Childs = childs;

                Alumno_ExamenList list = DataPortal.Fetch<Alumno_ExamenList>(criteria);

                CloseSession(criteria.SessionCode);
                return list;
            }

		#endregion

		#region Data Access

			// called to copy objects data from list
			private void Fetch(IList<Alumno_Examen> lista)
			{
				this.RaiseListChangedEvents = false;

				IsReadOnly = false;
				
				foreach (Alumno_Examen item in lista)
					this.AddItem(item.GetInfo(true));

				IsReadOnly = true;

				this.RaiseListChangedEvents = true;
			}


			// called to copy objects data from list
			private void Fetch(IDataReader reader)
			{
				this.RaiseListChangedEvents = false;

				IsReadOnly = false;

				while (reader.Read())
					this.AddItem(Alumno_ExamenInfo.Get(reader, Childs));

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
                        IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                        IsReadOnly = false;

                        while (reader.Read())
                            this.AddItem(Alumno_ExamenInfo.Get(SessionCode, reader, Childs));

                        IsReadOnly = true;
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

            public static string SELECT_BY_EXAMEN(long oid_examen)
            {
                QueryConditions conditions = new QueryConditions()
                {
                    Examen = ExamenInfo.New()
                };

                conditions.Examen.Oid = oid_examen;

                return Alumno_Examen.SELECT(conditions, false);
            }

            public static string SELECT(AlumnoInfo item) { return Alumno_Examen.SELECT(new QueryConditions() { Alumno = item }, false); }

        #endregion


    }
}

