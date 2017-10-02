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
	public class Alumno_ParteList : ReadOnlyListBaseEx<Alumno_ParteList, Alumno_ParteInfo>
	{
		 
		 
		#region Factory Methods

			private Alumno_ParteList() { }

			private Alumno_ParteList(IList<Alumno_Parte> lista)
			{
				Fetch(lista);
			}

			private Alumno_ParteList(IDataReader reader)
			{
				Fetch(reader);
			}

			/// <summary>
			/// Builds a Alumno_ParteList from a IList<!--<Alumno_ParteInfo>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>Alumno_ParteList</returns>
			public static Alumno_ParteList GetChildList(IList<Alumno_ParteInfo> list)
			{
				Alumno_ParteList flist = new Alumno_ParteList();

				if (list.Count > 0)
				{
					flist.IsReadOnly = false;

					foreach (Alumno_ParteInfo item in list)
						flist.AddItem(item);

					flist.IsReadOnly = true;
				}

				return flist;
			}

			/// <summary>
			/// Builds a Alumno_ParteList from IList<!--<Alumno_Parte>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>Alumno_ParteList</returns>
			public static Alumno_ParteList GetChildList(IList<Alumno_Parte> list) { return new Alumno_ParteList(list); }

			public static Alumno_ParteList GetChildList(IDataReader reader) { return new Alumno_ParteList(reader); }

			#endregion

		#region Data Access

			// called to copy objects data from list
			private void Fetch(IList<Alumno_Parte> lista)
			{
				this.RaiseListChangedEvents = false;

				IsReadOnly = false;
				
				foreach (Alumno_Parte item in lista)
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
					this.AddItem(Alumno_Parte.GetChild(reader).GetInfo());

				IsReadOnly = true;

				this.RaiseListChangedEvents = true;
			}

			// called to retrieve data from db
            //protected override void Fetch(CriteriaEx criteria)
            //{
            //    this.RaiseListChangedEvents = false;

            //    SessionCode = criteria.SessionCode;
            //    Childs = criteria.Childs;

            //    try
            //    {
            //        if (nHMng.UseDirectSQL)
            //        {
            //            IDataReader reader = nHManager.Instance.SQLNativeSelect(criteria.Query, Session());

            //            IsReadOnly = false;

            //            while (reader.Read())
            //            {
            //                this.AddItem(Alumno_ParteInfo.Get(reader,Childs));
            //            }

            //            IsReadOnly = true;
            //        }
            //        else
            //        {
            //            IList<Alumno_Parte> list = criteria.List<Alumno_Parte>();

            //            if (list.Count > 0)
            //            {
            //                IsReadOnly = false;

            //                foreach (Alumno_Parte item in list)
            //                    this.AddItem(item.GetInfo());

            //                IsReadOnly = true;
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        iQExceptionHandler.TreatException(ex);
            //    }

            //    this.RaiseListChangedEvents = true;
            //}

			#endregion

        #region SQL 

        public static string SELECT(AlumnoInfo item) { return Alumno_Parte.SELECT(new QueryConditions() { Alumno = item }, false); }

        #endregion


    }
}

