using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Instruction;

namespace moleQule.Library.Instruction
{

    /// <summary>
    /// ReadOnly Child Business Object with ReadOnly Childs
    /// </summary>
    [Serializable()]
    public class IncidenciaCronogramaInfo : ReadOnlyBaseEx<IncidenciaCronogramaInfo>
    {
        #region Attributes

        protected IncidenciaCronogramaBase _base = new IncidenciaCronogramaBase();

        private IncidenciaSesionCronogramaList _sesiones = null;


        #endregion

        #region Properties

        public IncidenciaCronogramaBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidCronograma { get { return _base.Record.OidCronograma; } }
        public string Motivo { get { return _base.Record.Motivo; } }        
        public string Observaciones { get { return _base.Record.Observaciones; } }

        public virtual IncidenciaSesionCronogramaList Sesiones { get { return _sesiones; } }


        #endregion

        #region Business Methods

        public void CopyFrom(IncidenciaCronograma source) { _base.CopyValues(source); }

        //public IncidenciaCronogramaPrint GetPrintObject(CompanyInfo empresa)
        //{
        //    PromocionInfo promocion = PromocionInfo.Get(this.OidPromocion, false);
        //    PlanEstudiosInfo plan = PlanEstudiosInfo.Get(this.OidPlan, false);
        //    return IncidenciaCronogramaPrint.New(this, empresa, plan, promocion);
        //}

        #endregion		

        #region Factory Methods

        protected IncidenciaCronogramaInfo() { /* require use of factory methods */ }

        private IncidenciaCronogramaInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }
        
        internal IncidenciaCronogramaInfo(IncidenciaCronograma source, bool copy_childs)
		{
            _base.CopyValues(source);

            if (copy_childs)
            {
                _sesiones = (source.Sesiones != null) ? IncidenciaSesionCronogramaList.GetChildList(source.Sesiones) : null;
            }
		}


        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static IncidenciaCronogramaInfo Get(long oid)
        {
            return Get(oid, false);
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static IncidenciaCronogramaInfo Get(long oid, bool childs)
        {
            CriteriaEx criteria = IncidenciaCronograma.GetCriteria(IncidenciaCronograma.OpenSession());
            criteria.AddOidSearch(oid);
            criteria.Childs = childs;
            criteria.Query = IncidenciaCronograma.SELECT(oid);

            IncidenciaCronogramaInfo obj = DataPortal.Fetch<IncidenciaCronogramaInfo>(criteria);
            IncidenciaCronograma.CloseSession(criteria.SessionCode);
            return obj;
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static IncidenciaCronogramaInfo Get(IDataReader reader)
        {
            return new IncidenciaCronogramaInfo(reader, true);
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static IncidenciaCronogramaInfo Get(IDataReader reader, bool childs)
        {
            return new IncidenciaCronogramaInfo(reader, childs);
        }

        public static IncidenciaCronogramaInfo New(long oid = 0) { return new IncidenciaCronogramaInfo() { Oid = oid }; }

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

					//IncidenciaCronograma.DoLOCK( Session());

                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                    if (reader.Read())
                        _base.CopyValues(reader);


                    if (Childs)
                    {
                        string query = string.Empty;

						//IncidenciaSesionCronograma.DoLOCK( Session());

                        //PENDIENTE
                        //query = IncidenciaSesionesCronogramas.SELECT_SESIONES_PLAN(this.Oid);
                        //reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        //_sesiones = IncidenciaSesionCronogramaList.GetChildList(reader);
                    }
                }
                else
                {
                    _base.Record.CopyValues((IncidenciaCronogramaRecord)(criteria.UniqueResult()));

                    if (Childs)
                    {
                        criteria = IncidenciaSesionCronograma.GetCriteria(criteria.Session);
                        criteria.AddEq("OidIncidencia", this.Oid);
                        _sesiones = IncidenciaSesionCronogramaList.GetChildList(criteria.List<IncidenciaSesionCronograma>());
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

					//IncidenciaSesionCronograma.DoLOCK( Session());


                    //PENDIENTE
                    //query = IncidenciaSesionesCronogramas.SELECT_BY_CRONOGRAMA(this.Oid);
                    //IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    //_sesiones = IncidenciaSesionCronogramaList.GetChildList(reader);
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
        }

        #endregion

    }
}

