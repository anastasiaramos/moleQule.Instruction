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
    public class IncidenciaSesionCronogramaInfo : ReadOnlyBaseEx<IncidenciaSesionCronogramaInfo>
    {

        #region Business Methods

        protected IncidenciaSesionCronogramaBase _base = new IncidenciaSesionCronogramaBase();

        #endregion

        #region Properties

        public IncidenciaSesionCronogramaBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidIncidencia { get { return _base.Record.OidIncidencia; } }
        public long OidClaseTeoricaProgramada { get { return _base.Record.OidClaseTeoricaProgramada; } }
        public long OidClasePracticaProgramada { get { return _base.Record.OidClasePracticaProgramada; } }
        public DateTime FechaClaseProgramada { get { return _base.Record.FechaClaseProgramada; } }
        public DateTime HoraClaseProgramada { get { return _base.Record.HoraClaseProgramada; } }
        public long OidClaseTeoricaAsignada { get { return _base.Record.OidClaseTeoricaAsignada; } }
        public long OidClasePracticaAsignada { get { return _base.Record.OidClasePracticaAsignada; } }
        public DateTime FechaClaseAsignada { get { return _base.Record.FechaClaseAsignada; } }
        public DateTime HoraClaseAsignada { get { return _base.Record.HoraClaseAsignada; } }

        public virtual string ClaseProgramada { get { return _base.ClaseProgramada; } set { _base.ClaseProgramada = value; } }
        public virtual string ModuloClaseProgramada { get { return _base.ModuloClaseProgramada; } set { _base.ModuloClaseProgramada = value; } }
        public virtual string ClaseAsignada { get { return _base.ClaseAsignada; } set { _base.ClaseAsignada = value; } }
        public virtual string ModuloClaseAsignada { get { return _base.ModuloClaseAsignada; } set { _base.ModuloClaseAsignada = value; } }

        //public IncidenciaSesionCronogramaPrint GetPrintObject(ModuloList modulos, ClaseTeoricaList teoricas, ClasePracticaList practicas)
        //{
        //    return IncidenciaSesionCronogramaPrint.New(this, modulos, teoricas, practicas);
        //}
        
        #endregion

        #region Business Methods

        public void CopyFrom(IncidenciaSesionCronograma source) { _base.CopyValues(source); }

        public void CopyValues(IncidenciaSesionCronograma source)
        {
            _base.CopyValues(source);

            ClaseProgramada = source.ClaseProgramada;
            ModuloClaseProgramada = source.ModuloClaseProgramada;
            ClaseAsignada = source.ClaseAsignada;
            ModuloClaseAsignada = source.ModuloClaseAsignada;
        }

        #endregion

        #region Factory Methods

        protected IncidenciaSesionCronogramaInfo() { /* require use of factory methods */ }

        private IncidenciaSesionCronogramaInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal IncidenciaSesionCronogramaInfo(IncidenciaSesionCronograma item)
        {
            CopyValues(item);

        }


        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static IncidenciaSesionCronogramaInfo Get(long oid)
        {
            return Get(oid, false);
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static IncidenciaSesionCronogramaInfo Get(long oid, bool childs)
        {
            CriteriaEx criteria = IncidenciaSesionCronograma.GetCriteria(IncidenciaSesionCronograma.OpenSession());
            criteria.AddOidSearch(oid);
            criteria.Childs = childs;
            IncidenciaSesionCronogramaInfo obj = DataPortal.Fetch<IncidenciaSesionCronogramaInfo>(criteria);
            IncidenciaSesionCronograma.CloseSession(criteria.SessionCode);
            return obj;
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static IncidenciaSesionCronogramaInfo Get(IDataReader reader, bool childs)
        {
            return new IncidenciaSesionCronogramaInfo(reader, childs);
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

                    IDataReader reader = IncidenciaSesionCronograma.DoSELECT(AppContext.ActiveSchema.Code, Session(), criteria.Oid);

                    if (reader.Read())
                        _base.CopyValues(reader);

                }
                else
                {
                    _base.Record.CopyValues((IncidenciaSesionCronogramaRecord)(criteria.UniqueResult()));

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
           }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
        }

        #endregion

    }
}

