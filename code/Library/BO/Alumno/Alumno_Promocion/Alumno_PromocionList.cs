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
	public class Alumno_PromocionList : ReadOnlyListBaseEx<Alumno_PromocionList, Alumno_PromocionInfo>
	{
		 
		 
		#region Factory Methods

			private Alumno_PromocionList() { }

			private Alumno_PromocionList(IList<Alumno_Promocion> lista)
			{
				Fetch(lista);
			}

			private Alumno_PromocionList(IDataReader reader)
			{
				Fetch(reader);
			}

			/// <summary>
			/// Builds a Alumno_PromocionList from a IList<!--<Alumno_PromocionInfo>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>Alumno_PromocionList</returns>
			public static Alumno_PromocionList GetChildList(IList<Alumno_PromocionInfo> list)
			{
				Alumno_PromocionList flist = new Alumno_PromocionList();

				if (list.Count > 0)
				{
					flist.IsReadOnly = false;

					foreach (Alumno_PromocionInfo item in list)
						flist.AddItem(item);

					flist.IsReadOnly = true;
				}

				return flist;
			}

			/// <summary>
			/// Builds a Alumno_PromocionList from IList<!--<Alumno_Promocion>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>Alumno_PromocionList</returns>
			public static Alumno_PromocionList GetChildList(IList<Alumno_Promocion> list) { return new Alumno_PromocionList(list); }

            public static Alumno_PromocionList GetChildList(IDataReader reader) { return new Alumno_PromocionList(reader); }
            public static Alumno_PromocionList GetChildList(AlumnoInfo parent, bool childs)
            {
                CriteriaEx criteria = Alumno_Promocion.GetCriteria(Alumno_Promocion.OpenSession());
                criteria.Query = Alumno_PromocionList.SELECT(parent);
                criteria.Childs = childs;

                Alumno_PromocionList list = DataPortal.Fetch<Alumno_PromocionList>(criteria);

                CloseSession(criteria.SessionCode);
                return list;
            }

			#endregion

		#region Data Access

			// called to copy objects data from list
			private void Fetch(IList<Alumno_Promocion> lista)
			{
				this.RaiseListChangedEvents = false;

				IsReadOnly = false;
				
				foreach (Alumno_Promocion item in lista)
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
					this.AddItem(Alumno_Promocion.GetChild(reader).GetInfo());

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
							this.AddItem(Alumno_PromocionInfo.Get(reader,Childs));
						}

						IsReadOnly = true;
					}
					else
					{
						IList<Alumno_Promocion> list = criteria.List<Alumno_Promocion>();

						if (list.Count > 0)
						{
							IsReadOnly = false;

							foreach (Alumno_Promocion item in list)
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

            /// <summary>
            /// Retrieve the complete list from db
            /// </summary>
            /// <returns>AlumnoList</returns>
            public static Alumno_PromocionList GetListaAdmitidos(long oid_modulo, DateTime fecha_examen, Dictionary<string, PromocionInfo> promociones, bool childs)
            {
                CriteriaEx criteria = Alumno_Promocion.GetCriteria(Alumno_Promocion.OpenSession());
                criteria.Childs = childs;
                criteria.Query = Alumno_Promocion.SELECT_ALUMNOS_ADMITIDOS(oid_modulo, fecha_examen, promociones);

                //No criteria. Retrieve all de List
                Alumno_PromocionList list = DataPortal.Fetch<Alumno_PromocionList>(criteria);

                CloseSession(criteria.SessionCode);

                return list;
            }

			#endregion

        #region SQL

            public static string SELECT(AlumnoInfo alumno) { return Alumno_Promocion.SELECT(new QueryConditions() { Alumno = alumno }, false); }

        #endregion


    }
}

