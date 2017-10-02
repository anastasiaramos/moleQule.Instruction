using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Hipatia;

namespace moleQule.Library.Instruction
{

    /// <summary>
    /// ReadOnly Child Business Object with ReadOnly Childs
    /// </summary>
    [Serializable()]
    public class PromocionInfo : ReadOnlyBaseEx<PromocionInfo>, IAgenteHipatia
    {
        #region IAgenteHipatia

        public string NombreHipatia { get { return Nombre; } }
        public string IDHipatia { get { return Numero; } }
        public string ObservacionesHipatia { get { return Observaciones; } }
        public Type TipoEntidad { get { return typeof(Promocion); } }

        #endregion

		#region Attributes

		protected PromocionBase _base = new PromocionBase();

        private Alumno_PromocionList _alumnos = null;
        private Sesion_PromocionList _sesiones = null;
		
		#endregion
		
		#region Properties
		
		public PromocionBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
		public long OidPlan { get { return _base.Record.OidPlan; } }
		public string Nombre { get { return _base.Record.Nombre; } }
		public string Numero { get { return _base.Record.Numero; } }
		public string Observaciones { get { return _base.Record.Observaciones; } }
		public DateTime FechaInicio { get { return _base.Record.FechaInicio; } }
		public DateTime FechaFin { get { return _base.Record.FechaFin; } }
		public DateTime InicioClases { get { return _base.Record.InicioClases; } }
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
		public bool HS1 { get { return _base.Record.Hs1; } }
		public bool HS2 { get { return _base.Record.Hs2; } }
		public bool HS3 { get { return _base.Record.Hs3; } }
		public bool HS4 { get { return _base.Record.Hs4; } }
		public bool H0 { get { return _base.Record.H0; } }
		public bool HS0 { get { return _base.Record.Hs0; } }
		public bool H11 { get { return _base.Record.H11; } }
		public bool H12 { get { return _base.Record.H12; } }
		public long OidPlanExtra { get { return _base.Record.OidPlanExtra; } }


        public virtual Alumno_PromocionList Alumnos { get { return _alumnos; } }
        public virtual Sesion_PromocionList Sesiones { get { return _sesiones; } }
		
		#endregion
		
		#region Business Methods
						
		public void CopyFrom(Promocion source) { _base.CopyValues(source); }
			
		#endregion		

        #region Factory Methods

        protected PromocionInfo() { /* require use of factory methods */ }

        private PromocionInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal PromocionInfo(Promocion item, bool copy_childs)
        {
            _base.CopyValues(item);

            if (copy_childs)
            {
                //_examenes = (item.Examens != null) ? ExamenList.GetChildList(item.Examens) : null;
                _alumnos = (item.Alumnos != null) ? Alumno_PromocionList.GetChildList(item.Alumnos) : null;
                _sesiones = (item.Sesiones != null) ? Sesion_PromocionList.GetChildList(item.Sesiones) : null;
                //_horarios = (item.Horarios != null) ? HorarioList.GetChildList(item.Horarios) : null;
            }
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static PromocionInfo Get(long oid)
        {
            return Get(oid, false);
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static PromocionInfo Get(long oid, bool childs)
        {
            CriteriaEx criteria = Promocion.GetCriteria(Promocion.OpenSession());
            criteria.Childs = childs;

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = PromocionInfo.SELECT(typeof(PromocionRecord), oid);
            else
                criteria.AddOidSearch(oid);
            
            PromocionInfo obj = DataPortal.Fetch<PromocionInfo>(criteria);
            Promocion.CloseSession(criteria.SessionCode);
            return obj;
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static PromocionInfo Get(IDataReader reader, bool childs)
        {
            return new PromocionInfo(reader, childs);
        }

        public static PromocionInfo New(long oid = 0) { return new PromocionInfo() { Oid = oid }; }

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

                        query = moleQule.Library.Instruction.Alumnos_Promociones.SELECT_BY_PROMOCION(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _alumnos = Alumno_PromocionList.GetChildList(reader);

                        query = Sesion_PromocionList.SELECT(this);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _sesiones = Sesion_PromocionList.GetChildList(reader);
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

                    query = moleQule.Library.Instruction.Alumnos_Promociones.SELECT_BY_PROMOCION(this.Oid);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _alumnos = Alumno_PromocionList.GetChildList(reader);

                    query = moleQule.Library.Instruction.Sesiones_Promociones.SELECT(this);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _sesiones = Sesion_PromocionList.GetChildList(reader);
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

