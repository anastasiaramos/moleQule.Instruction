using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;

namespace moleQule.Library.Instruction
{

	/// <summary>
	/// ReadOnly Root Business Object with ReadOnly Childs
    /// </summary>
	[Serializable()]
	public class PlanExtraInfo : ReadOnlyBaseEx<PlanExtraInfo>
	{

        #region Business Methods

        protected PlanExtraBase _base = new PlanExtraBase();

            private ClaseExtraList _c_extras = null;

		
		#endregion
		
		#region Properties
		
		public PlanExtraBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
		public string Nombre { get { return _base.Record.Nombre; } }
		public DateTime Fecha { get { return _base.Record.Fecha; } }
		public string Observaciones { get { return _base.Record.Observaciones; } }
		public long OidProducto { get { return _base.Record.OidProducto; } }
		public long OidSerie { get { return _base.Record.OidSerie; } }

        public ClaseExtraList CExtras { get { return _c_extras; } }
		
		
		
		#endregion

        #region Business Methods

        public void CopyFrom(PlanExtra source) { _base.CopyValues(source); }
			
		 #endregion
		 
		 #region Factory Methods
		 
		 	private PlanExtraInfo() { /* require use of factory methods */ }

			private PlanExtraInfo(IDataReader reader, bool childs)
			{
				Childs = childs;
				Fetch(reader);
			}
			
			internal PlanExtraInfo(PlanExtra item, bool copy_childs)
			{
                _base.CopyValues(item);

                if (copy_childs)
                {
                    _c_extras = item.CExtras != null ? ClaseExtraList.GetChildList(item.CExtras) : null;
                }
			}
	

			/// <summary>
			/// Devuelve un ClienteInfo tras consultar la base de datos
			/// </summary>
			/// <param name="oid"></param>
			/// <returns></returns>
			public static PlanExtraInfo Get(long oid)
			{
				return Get(oid, false);
			}

			/// <summary>
			/// Devuelve un ClienteInfo tras consultar la base de datos
			/// </summary>
			/// <param name="oid"></param>
			/// <returns></returns>
			public static PlanExtraInfo Get(long oid, bool childs)
			{
				CriteriaEx criteria = PlanExtra.GetCriteria(PlanExtra.OpenSession());
                criteria.Query = PlanExtraInfo.SELECT(oid);
				criteria.Childs = childs;
				PlanExtraInfo obj = DataPortal.Fetch<PlanExtraInfo>(criteria);
				PlanExtra.CloseSession(criteria.SessionCode);
				return obj;
			}


			/// <summary>
			/// Copia los datos al objeto desde un IDataReader 
			/// </summary>
			/// <param name="reader"></param>
			/// <returns></returns>
			public static PlanExtraInfo Get(IDataReader reader, bool childs)
			{
 	   			return new PlanExtraInfo(reader, childs);
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
                    if (nHMng.UseDirectSQL)
                    {
                        IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                        if (reader.Read())
                            _base.CopyValues(reader);

                        if (Childs)
                        {
                            string query = ClaseExtras.SELECT_CLASES_EXTRAS_PLAN(this.Oid);
                            reader = nHManager.Instance.SQLNativeSelect(query, Session());
                            _c_extras = ClaseExtraList.GetChildList(reader);
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
						//ClaseExtra.DoLOCK( Session());

                        string query = ClaseExtras.SELECT_BY_PLAN(this.Oid);
                        IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _c_extras = ClaseExtraList.GetChildList(reader);
					}
				}
				catch (Exception ex)
				{
					iQExceptionHandler.TreatException(ex);
				}
			}
					
		 #endregion

        #region SQL

            public static string SELECT(long oid) { return PlanExtra.SELECT(new QueryConditions() { Oid = oid }, false); }

        #endregion

    }
}

