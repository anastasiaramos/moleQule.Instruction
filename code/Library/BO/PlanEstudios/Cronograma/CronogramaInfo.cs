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
    public class CronogramaInfo : ReadOnlyBaseEx<CronogramaInfo>
    {
        #region Attributes

        protected CronogramaBase _base = new CronogramaBase();

        private SesionCronogramaList _sesiones = null;
        private Sesion_PromocionList _configuracion = null;


        #endregion

        #region Properties

        public CronogramaBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidPlan { get { return _base.Record.OidPlan; } }
        public long OidPromocion { get { return _base.Record.OidPromocion; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }
        public DateTime FechaCreacion { get { return _base.Record.FechaCreacion; } }

        public string PlanEstudios { get { return _base.Plan; } }
        public string Promocion { get { return _base.Promocion; } }

        public virtual SesionCronogramaList Sesiones { get { return _sesiones; } }
        public virtual Sesion_PromocionList Configuracion { get { return _configuracion; } }


        #endregion

        #region Business Methods

        public void CopyFrom(Cronograma source) { _base.CopyValues(source); }

        public CronogramaPrint GetPrintObject(CompanyInfo empresa)
        {
            PromocionInfo promocion = PromocionInfo.Get(this.OidPromocion, false);
            PlanEstudiosInfo plan = PlanEstudiosInfo.Get(this.OidPlan, false);
            return CronogramaPrint.New(this, empresa, plan, promocion);
        }

        #endregion		

        #region Factory Methods

        protected CronogramaInfo() { /* require use of factory methods */ }

        private CronogramaInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }
        
        internal CronogramaInfo(Cronograma source, bool copy_childs)
		{
            _base.CopyValues(source);

            if (copy_childs)
            {
                _sesiones = (source.Sesiones != null) ? SesionCronogramaList.GetChildList(source.Sesiones) : null;
                _configuracion = (source.Configuracion != null) ? Sesion_PromocionList.GetChildList(source.Configuracion) : null;
            }
		}


        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static CronogramaInfo Get(long oid)
        {
            return Get(oid, false);
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static CronogramaInfo Get(long oid, bool childs)
        {
            CriteriaEx criteria = Cronograma.GetCriteria(Cronograma.OpenSession());
            criteria.AddOidSearch(oid);
            criteria.Childs = childs;
            criteria.Query = Cronograma.SELECT(oid);

            CronogramaInfo obj = DataPortal.Fetch<CronogramaInfo>(criteria);
            Cronograma.CloseSession(criteria.SessionCode);
            return obj;
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static CronogramaInfo Get(IDataReader reader)
        {
            return new CronogramaInfo(reader, true);
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static CronogramaInfo Get(IDataReader reader, bool childs)
        {
            return new CronogramaInfo(reader, childs);
        }

        public static CronogramaInfo New(long oid = 0) { return new CronogramaInfo() { Oid = oid }; }

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

					//Cronograma.DoLOCK( Session());

                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                    if (reader.Read())
                        _base.CopyValues(reader);


                    if (Childs)
                    {
                        string query = string.Empty;

						//SesionCronograma.DoLOCK( Session());

                        query = SesionesCronogramas.SELECT_SESIONES_PLAN(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _sesiones = SesionCronogramaList.GetChildList(reader);

                        query = Sesiones_Promociones.SELECT(this);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _configuracion = Sesion_PromocionList.GetChildList(reader);
                    }
                }
                else
                {
                    _base.Record.CopyValues((CronogramaRecord)(criteria.UniqueResult()));

                    if (Childs)
                    {
                        criteria = SesionCronograma.GetCriteria(criteria.Session);
                        criteria.AddEq("OidCronograma", this.Oid);
                        _sesiones = SesionCronogramaList.GetChildList(criteria.List<SesionCronograma>());

                        criteria = Sesion_Promocion.GetCriteria(criteria.Session);
                        criteria.AddEq("OidPromocion", this.Oid);
                        criteria.AddEq("Tipo", 2);
                        _configuracion = Sesion_PromocionList.GetChildList(criteria.List<Sesion_Promocion>());
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

					//SesionCronograma.DoLOCK( Session());

                    query = SesionesCronogramas.SELECT_BY_CRONOGRAMA(this.Oid);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _sesiones = SesionCronogramaList.GetChildList(reader);

                    query = Sesiones_Promociones.SELECT(this);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _configuracion = Sesion_PromocionList.GetChildList(reader);
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
        }

        #endregion

        #region SQL

        public static string SELECT(long oid)
        {
            string c = nHManager.Instance.GetSQLTable(typeof(CronogramaRecord));
            string p = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));
            string pe = nHManager.Instance.GetSQLTable(typeof(PlanEstudiosRecord));
            string query;

            query = "SELECT C.*," +
                    "       P.\"NOMBRE\" AS \"PROMOCION\"," +
                    "       PE.\"NOMBRE\" AS \"PLAN\"" +
                    " FROM " + c + " AS C" +
                    " INNER JOIN " + p + " AS P ON C.\"OID_PROMOCION\" = P.\"OID\"" +
                    " INNER JOIN " + pe + " AS PE ON C.\"OID_PLAN\" = PE.\"OID\"";

            if (oid > 0)
                query += " WHERE C.\"OID\" = " + oid.ToString();

            return query;
        }

        #endregion

    }
}

