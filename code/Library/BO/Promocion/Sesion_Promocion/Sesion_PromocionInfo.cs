using System;
using System.Collections.Generic;
using System.Data;

using moleQule.Library.CslaEx;

using moleQule.Library;

namespace moleQule.Library.Instruction
{

    /// <summary>
    /// ReadOnly Child Business Object
    /// </summary>
    [Serializable()]
    public class Sesion_PromocionInfo : ReadOnlyBaseEx<Sesion_PromocionInfo>
    {

        #region Business Methods

        protected Sesion_PromocionBase _base = new Sesion_PromocionBase();

        #endregion

        #region Properties

        public Sesion_PromocionBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidPromocion { get { return _base.Record.OidPromocion; } }
        public DateTime HoraInicio { get { return _base.Record.HoraInicio; } }
        public long NHoras { get { return _base.Record.NHoras; } }
        public bool Sabado { get { return _base.Record.Sabado; } }
        public long Tipo { get { return _base.Record.Tipo; } }

        public string Hora { get { return _base.Hora; } }

        #endregion

        #region Business Methods

        public void CopyFrom(Sesion_Promocion source) { _base.CopyValues(source); }
        
        #endregion

        #region Factory Methods

        protected Sesion_PromocionInfo() { /* require use of factory methods */ }

        private Sesion_PromocionInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal Sesion_PromocionInfo(Sesion_Promocion item)
        {
            _base.CopyValues(item);
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Sesion_PromocionInfo Get(IDataReader reader, bool childs)
        {
            return new Sesion_PromocionInfo(reader, childs);
        }

        #endregion

        #region Data Access

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

