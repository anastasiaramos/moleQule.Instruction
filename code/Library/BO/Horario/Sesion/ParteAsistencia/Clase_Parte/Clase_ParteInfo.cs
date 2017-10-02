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
    public class Clase_ParteInfo : ReadOnlyBaseEx<Clase_ParteInfo>
    {
        #region Attributes

        protected Clase_ParteBase _base = new Clase_ParteBase();


        #endregion

        #region Properties

        public Clase_ParteBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidClase { get { return _base.Record.OidClase; } }
        public long OidParte { get { return _base.Record.OidParte; } }
        public long Tipo { get { return _base.Record.Tipo; } }
        public long Grupo { get { return _base.Record.Grupo; } }



        #endregion

        #region Business Methods

        public void CopyFrom(Clase_Parte source) { _base.CopyValues(source); }

        #endregion		

        #region Factory Methods

        protected Clase_ParteInfo() { /* require use of factory methods */ }

        private Clase_ParteInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal Clase_ParteInfo(Clase_Parte item)
        {
            _base.CopyValues(item);
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Clase_ParteInfo Get(IDataReader reader, bool childs)
        {
            return new Clase_ParteInfo(reader, childs);
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

