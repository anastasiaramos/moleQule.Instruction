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
	public class PlanEstudiosInfo : ReadOnlyBaseEx<PlanEstudiosInfo>
	{

        #region Business Methods

        protected PlanEstudiosBase _base = new PlanEstudiosBase();

        private ClaseTeoricaList _c_teoricas = null;
        private ClasePracticaList _c_practicas = null;


        #endregion

        #region Properties

        public PlanEstudiosBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public string Nombre { get { return _base.Record.Nombre; } }
        public DateTime Fecha { get { return _base.Record.Fecha; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }
        public long OidProducto { get { return _base.Record.OidProducto; } }
        public long OidSerie { get { return _base.Record.OidSerie; } }

        public virtual ClaseTeoricaList CTeoricas { get { return _c_teoricas; } }
        public virtual ClasePracticaList CPracticas { get { return _c_practicas; } }


        #endregion

        #region Business Methods

        public void CopyFrom(PlanEstudios source) { _base.CopyValues(source); }

        #endregion		

        #region Factory Methods

        private PlanEstudiosInfo() { /* require use of factory methods */ }

        private PlanEstudiosInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal PlanEstudiosInfo(PlanEstudios item, bool copy_childs)
        {
            _base.CopyValues(item);
            
            if (copy_childs)
            {
                _c_teoricas = (item.CTeoricas != null) ? ClaseTeoricaList.GetChildList(item.CTeoricas) : null;
                _c_practicas = (item.CPracticas != null) ? ClasePracticaList.GetChildList(item.CPracticas) : null;
            }

        }

        public static PlanEstudiosInfo New(long oid = 0) { return new PlanEstudiosInfo() { Oid = oid }; }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static PlanEstudiosInfo Get(long oid)
        {
            return Get(oid, false);
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static PlanEstudiosInfo Get(long oid, bool childs)
        {
            CriteriaEx criteria = PlanEstudios.GetCriteria(PlanEstudios.OpenSession());
            criteria.Childs = childs;

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = PlanEstudiosInfo.SELECT(oid);

            PlanEstudiosInfo obj = DataPortal.Fetch<PlanEstudiosInfo>(criteria);
            PlanEstudios.CloseSession(criteria.SessionCode);
            return obj;
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static PlanEstudiosInfo Get(IDataReader reader, bool childs)
        {
            return new PlanEstudiosInfo(reader, childs);
        }

        #endregion

        #region Data Access

        // called to retrieve data from db
        private void DataPortal_Fetch(CriteriaEx criteria)
        {
            _base.Record.Oid = 0;
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
                        string query = string.Empty;

                        query = ClaseTeoricas.SELECT_BY_PLAN(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _c_teoricas = ClaseTeoricaList.GetChildList(reader);

                        query = ClasePracticas.SELECT_BY_PLAN(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _c_practicas = ClasePracticaList.GetChildList(reader);
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

                    query = ClaseTeoricas.SELECT_BY_PLAN(this.Oid);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _c_teoricas = ClaseTeoricaList.GetChildList(reader);

                    query = ClasePracticas.SELECT_BY_PLAN(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _c_practicas = ClasePracticaList.GetChildList(reader);

                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
        }

        #endregion


        #region SQL

        public static string SELECT(long oid) { return PlanEstudios.SELECT(oid, false); }

        #endregion	
	}
}

