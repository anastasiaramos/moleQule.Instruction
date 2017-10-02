using System;
using System.Collections.Generic;
using System.Data;

using Csla;

using moleQule.Library;
using moleQule.Library.CslaEx;
using moleQule.Library.Invoice;

namespace moleQule.Library.Instruction
{

	/// <summary>
	/// ReadOnly Root Collection of Business Objects With Child Collection
	/// </summary>
    [Serializable()]
	public class Alumno_ConvocatoriaList : ReadOnlyListBaseEx<Alumno_ConvocatoriaList, Alumno_ConvocatoriaInfo>
	{
		 		 
		#region Factory Methods

		private Alumno_ConvocatoriaList() { }

		private Alumno_ConvocatoriaList(IList<Alumno_Convocatoria> lista)
		{
			Fetch(lista);
		}

		private Alumno_ConvocatoriaList(IDataReader reader)
		{
			Fetch(reader);
		}

		/// <summary>
		/// Builds a Alumno_CursoList from a IList<!--<Alumno_CursoInfo>-->
		/// </summary>
		/// <param name="list"></param>
		/// <returns>Alumno_CursoList</returns>
		public static Alumno_ConvocatoriaList GetChildList(IList<Alumno_ConvocatoriaInfo> list)
		{
			Alumno_ConvocatoriaList flist = new Alumno_ConvocatoriaList();

			if (list.Count > 0)
			{
				flist.IsReadOnly = false;

				foreach (Alumno_ConvocatoriaInfo item in list)
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
		public static Alumno_ConvocatoriaList GetChildList(IList<Alumno_Convocatoria> list) { return new Alumno_ConvocatoriaList(list); }

		public static Alumno_ConvocatoriaList GetChildList(IDataReader reader) { return new Alumno_ConvocatoriaList(reader); }

        /// <summary>
        /// Devuelve una lista de todos los alumno_cursos asociados a un curso
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static Alumno_ConvocatoriaList GetAlumnosList(long oid_curso)
        {
            CriteriaEx criteria = Alumno_Convocatoria.GetCriteria(Alumno_Convocatoria.OpenSession());
            criteria.AddEq("OidCurso", oid_curso);
            Alumno_ConvocatoriaList list = Alumno_ConvocatoriaList.RetrieveList(typeof(Alumno_Convocatoria), AppContext.ActiveSchema.Code, criteria);

            CloseSession(criteria.SessionCode);
            return list;
        }        

		#endregion

	    #region Data Access

		// called to copy objects data from list
		private void Fetch(IList<Alumno_Convocatoria> lista)
		{
			this.RaiseListChangedEvents = false;

			IsReadOnly = false;
			
			foreach (Alumno_Convocatoria item in lista)
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
				this.AddItem(Alumno_Convocatoria.GetChild(reader).GetInfo());

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
						this.AddItem(Alumno_ConvocatoriaInfo.Get(reader,Childs));
					}

					IsReadOnly = true;
				}
				else
				{
					IList<Alumno_Convocatoria> list = criteria.List<Alumno_Convocatoria>();

					if (list.Count > 0)
					{
						IsReadOnly = false;

						foreach (Alumno_Convocatoria item in list)
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


        /// <summary>
        /// Construye el SELECT de la lista
        /// </summary>       
        /// <returns></returns>
        public static string SELECT(long oid_convocatoria)
        {
            string alumno_convocatoria= nHManager.Instance.GetSQLTable(typeof(AlumnoConvocatoriaRecord));                    
            string cliente = nHManager.Instance.GetSQLTable(typeof(ClientRecord));
            string alumno = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));


            string query = "SELECT  ALCO.*, " +
                "           AL.\"NOMBRE\" ||' '|| AL.\"APELLIDOS\" AS \"NOMBRE\"," +
                "           CL.\"NOMBRE\" AS \"CLIENTE\" " +                
                "           FROM   " + alumno_convocatoria + "   AS ALCO " +
                "           INNER JOIN   " + cliente + "   AS CL ON (ALCO.\"OID_CLIENTE\" =  CL.\"OID\") " +
                "           INNER JOIN   " + alumno  + "   AS AL ON (ALCO.\"OID_ALUMNO\" = AL.\"OID\") " +                            
                "           WHERE ALCO.\"OID_CONVOCATORIA\" = '" + oid_convocatoria.ToString() + "' ";

            return query;
        }

        #endregion

	
	}
}

