using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;

namespace moleQule.Library.Instruction
{
	/// <summary>
	/// ReadOnly Child Business Object with ReadOnly Childs
	/// </summary>
	[Serializable()]
	public class HorarioInfo : ReadOnlyBaseEx<HorarioInfo>
    {
        #region Attributes

        protected HorarioBase _base = new HorarioBase();

        private SesionList _sesiones = null;
        private ParteAsistenciaList _asistencias = null;


        #endregion

        #region Properties

        public HorarioBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidPlan { get { return _base.Record.OidPlan; } }
        public long OidPromocion { get { return _base.Record.OidPromocion; } }
        public DateTime FechaInicial { get { return _base.Record.FechaInicial; } }
        public DateTime FechaFinal { get { return _base.Record.FechaFinal; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }
        public bool H8AM { get { return _base.Record.H8AM; } }
        public bool H1 { get { return _base.Record.H1; } }
        public bool H2 { get { return _base.Record.H2; } }
        public bool H3 { get { return _base.Record.H3; } }
        public bool H4 { get { return _base.Record.H4; } }
        public bool H5 { get { return _base.Record.H5; } }
        public bool H6 { get { return _base.Record.H6; } }
        public bool H7 { get { return _base.Record.H7; } }
        public bool H8 { get { return _base.Record.H8; } }
        public bool H9 { get { return _base.Record.H9; } }
        public bool H10 { get { return _base.Record.H10; } }
        public bool Hs1 { get { return _base.Record.Hs1; } }
        public bool Hs2 { get { return _base.Record.Hs2; } }
        public bool Hs3 { get { return _base.Record.Hs3; } }
        public bool Hs4 { get { return _base.Record.Hs4; } }
        public bool H0 { get { return _base.Record.H0; } }
        public bool Hs0 { get { return _base.Record.Hs0; } }
        public bool H11 { get { return _base.Record.H11; } }
        public bool H12 { get { return _base.Record.H12; } }

        //Propiedades adicionales
        public string Plan { get { return _base.Plan; } }
        public string Promocion { get { return _base.Promocion; } }

        public virtual SesionList Sesions { get { return _sesiones; } }
        public virtual ParteAsistenciaList Asistencias { get { return _asistencias; } }



        #endregion

        #region Business Methods

        public void CopyFrom(Horario source) { _base.CopyValues(source); }
        
        public HorarioPrint GetPrintObject(InstructorList instructores, ModuloList modulos)
        {
            return HorarioPrint.New(this, instructores, modulos);
        }

        #endregion		

		#region Factory Methods

		protected HorarioInfo() { /* require use of factory methods */ }

		private HorarioInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}

		internal HorarioInfo(Horario item, bool copy_childs)
		{
            _base.CopyValues(item);

            if (copy_childs)
            {
                _sesiones = (item.Sesions != null) ? SesionList.GetChildList(item.Sesions) : null;
                _asistencias = (item.Asistencias != null) ? ParteAsistenciaList.GetChildList(item.Asistencias) : null;
            }
		}


		/// <summary>
		/// Devuelve un ClienteInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
		public static HorarioInfo Get(long oid)
		{
			return Get(oid, false);
		}

		/// <summary>
		/// Devuelve un ClienteInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
		public static HorarioInfo Get(long oid, bool childs)
		{
			CriteriaEx criteria = Horario.GetCriteria(Horario.OpenSession());
			
            criteria.Childs = childs;
            if (nHManager.Instance.UseDirectSQL) 
                criteria.Query = HorarioInfo.SELECT(oid);
            else 
                criteria.AddOidSearch(oid);
            
            HorarioInfo obj = DataPortal.Fetch<HorarioInfo>(criteria);
			Horario.CloseSession(criteria.SessionCode);
			return obj;
		}

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static HorarioInfo GetLast(long oid_promocion, bool childs)
        {
            CriteriaEx criteria = Horario.GetCriteria(Horario.OpenSession());

            criteria.Childs = childs;
            criteria.Query = HorarioInfo.SELECT_LAST(oid_promocion);

            HorarioInfo obj = DataPortal.Fetch<HorarioInfo>(criteria);
            Horario.CloseSession(criteria.SessionCode);
            return obj;
        }

		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static HorarioInfo Get(IDataReader reader, bool childs)
		{
			return new HorarioInfo(reader, childs);
		}

        public void LoadChilds(Type type, bool get_childs)
        {
            if (type.Equals(typeof(Sesion)))
            {
                int sesion = Horario.OpenSession();
                string query = SesionList.SELECT_BY_HORARIO(this.Oid);
                IDataReader reader = nHMng.SQLNativeSelect(query, Session());
                _sesiones = SesionList.GetChildList(reader);
                Horario.CloseSession(sesion);
            }
        }

		#endregion

		#region Data Access

		// called to retrieve data from db
		private void DataPortal_Fetch(CriteriaEx criteria)
		{
			SessionCode = criteria.SessionCode;
			Childs = criteria.Childs;

			try
			{
				SessionCode = criteria.SessionCode;
				Childs = criteria.Childs;

				if (nHMng.UseDirectSQL)
				{
					IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

					if (reader.Read())
						_base.CopyValues(reader);
					
					if (Childs)
					{
						string query = string.Empty;

						query = SesionList.SELECT_BY_HORARIO(Oid);
                        reader = nHMng.SQLNativeSelect(query, Session());
						_sesiones = SesionList.GetChildList(reader);

                        query = ParteAsistenciaList.SELECT_BY_HORARIO(Oid);
                        reader = nHMng.SQLNativeSelect(query, Session());
                        _asistencias = ParteAsistenciaList.GetChildList(reader);
					}
				}
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
		}

		//called to copy data from IDataReader
		private void Fetch(IDataReader source)
		{
			try
			{
				_base.CopyValues(source);

				if (Childs)
				{
					string query = string.Empty;
                    IDataReader reader;

					query = SesionList.SELECT_BY_HORARIO(Oid);
					reader = nHMng.SQLNativeSelect(query, Session());
                    _sesiones = SesionList.GetChildList(reader);

                    query = ParteAsistenciaList.SELECT_BY_HORARIO(Oid);
                    reader = nHMng.SQLNativeSelect(query, Session());
                    _asistencias = ParteAsistenciaList.GetChildList(reader);
				}
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
		}

		#endregion

        #region SQL

        public static string SELECT(long oid) { return Horario.SELECT(oid, false); }

        public static string SELECT_LAST(long oid_promocion)
        {
            string horario = nHManager.Instance.GetSQLTable(typeof(HorarioRecord));
            string plan = nHManager.Instance.GetSQLTable(typeof(PlanEstudiosRecord));
            string promocion = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));

            string query = string.Empty;

            query = @"  SELECT H.*,
                            PL.""NOMBRE"" AS ""PLAN"", 
                            PR.""NOMBRE"" AS ""PROMOCION""
                        FROM " + horario + @" AS H
                        INNER JOIN " + promocion + @" AS PR ON PR.""OID"" = H.""OID_PROMOCION""
                        INNER JOIN " + plan + @" AS PL ON PL.""OID"" = H.""OID_PLAN""
                        WHERE H.""OID"" = (   SELECT MAX(""OID"")
                                            FROM " + horario + @"
                                            WHERE ""OID_PROMOCION"" = " + oid_promocion.ToString() + ");";
            return query;
        }

        #endregion
	}
}

